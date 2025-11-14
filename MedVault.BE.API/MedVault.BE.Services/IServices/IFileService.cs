using Microsoft.AspNetCore.Http;

namespace MedVault.BE.Services.IServices
{
    public interface IFileService
    {
        Task<string> ValidateAndSaveFile(IFormFile file, string folderPath);

        Task<(bool, string)> DeleteFile(string filePath);
    }
}
