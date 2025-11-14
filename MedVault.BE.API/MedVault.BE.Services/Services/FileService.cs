using MedVault.BE.Common.Constants;
using MedVault.BE.Common.CustomExceptions;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;

namespace MedVault.BE.Services.Services
{
    public class FileService(IConfiguration configuration) : IFileService
    {
        private string GetAllowedExtentions()
        {
            string? extentions = configuration["FileSettings:Extensions"];
            return extentions?.Trim() ?? string.Empty;
        }

        private int GetMaxFileSize()
        {
            string? maxSize = configuration["FileSettings:MaxSizeMB"];

            if (string.IsNullOrEmpty(maxSize))
            {
                return 0; // Default to 0 if maxSize is null or empty
            }
            return int.Parse(maxSize);
        }

        private long MegabytesToBytes(int mb) => mb * 1024L * 1024L;

        public (bool, string) IsValidFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return (false, ExceptionMessage.FILE_IS_NULL);

            // Check file extension
            var allowedExtensions = GetAllowedExtentions().Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension) && !allowedExtensions.Contains("*"))
                return (false, string.Format(ExceptionMessage.FILE_TYPE_NOT_SUPPORTED, string.Join(",", allowedExtensions)));

            // check file size
            int maxFileSize = GetMaxFileSize();
            if (maxFileSize > 0 && file.Length > MegabytesToBytes(maxFileSize))
                return (false, string.Format(ExceptionMessage.FILE_SIZE_EXCEEDED, maxFileSize));

            return (true, string.Empty);
        }

        public async Task<string> ValidateAndSaveFile(IFormFile file, string folderPath)
        {
            (bool isValid, string error) = IsValidFile(file);
            if (!isValid)
                throw new ValidationException(error);

            (bool isUploaded, string path) = await SaveFileAsync(file, folderPath);
            if (!isUploaded)
                throw new ValidationException($"File saving failed: {path}");

            return path;
        }

        public async Task<(bool, string)> SaveFileAsync(IFormFile file, string folderPath)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentNullException(nameof(file), ExceptionMessage.FILE_IS_NULL);

            ArgumentException.ThrowIfNullOrEmpty(folderPath, nameof(folderPath));
            try
            {
                string extension = Path.GetExtension(file.FileName);
                string fileName = $"{Guid.NewGuid()}{extension}";
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), folderPath, fileName);

                string? directory = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory!);
                }

                using FileStream fileStream = new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(fileStream);
                string path = Path.Combine(folderPath, fileName).Replace("\\", "/");

                return (true, path);
            }
            catch (Exception ex)
            {
                return (false, ExceptionMessage.FILE_SAVE_FAILED);
            }
        }

        public async Task<(bool, string)> DeleteFile(string filePath)
        {
            ArgumentException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                return (false, ExceptionMessage.FILE_DELETE_FAILED);
            }
            return (true, string.Empty);
        }
    }
}
