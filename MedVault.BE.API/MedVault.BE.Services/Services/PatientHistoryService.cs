using Mapster;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.CustomExceptions;
using MedVault.BE.Common.Helpers;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.Master;
using MedVault.BE.Data.Entities.Patient;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace MedVault.BE.Services.Services
{
    public class PatientHistoryService(IHttpContextAccessor contextAccessor, IFileService fileService, IPatientHistoryRepository patientHistoryRepository,
        IDocumentCategoryRepository documentCategoryRepository, IPatientProfileRepositories patientProfileRepositories) : IPatientHistoryService
    {
        public async Task<PageListResponse<PatientHistoryListResponse>> GetPatientHistoryByPagination(PatientHistoryListRequest patientHistoryListRequest)
        {
            PageListResponse<PatientHistory> patientHistories = await patientHistoryRepository.GetPatientHistoryByPagination(patientHistoryListRequest);
            return patientHistories.Adapt<PageListResponse<PatientHistoryListResponse>>();
        }

        public async Task<List<DropdownResponse>> GetAllCategoryType()
        {
            List<DocumentCategory> documentCategoryList = await documentCategoryRepository.GetDocumentCategoryForDropdown();
            return documentCategoryList.Adapt<List<DropdownResponse>>();
        }

        public async Task<PatientHistoryResponse> GetPatientHistoryById(int id)
        {
            PatientHistory exstingPatientHistory = await patientHistoryRepository.GetPatientHistoryById(id) ??
                throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Patient History"));

            return exstingPatientHistory.Adapt<PatientHistoryResponse>();
        }

        public async Task<int> SavePatientHistory(PatientHistoryRequest patientHistoryRequest)
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.INVALID_USER_ID);

            // Check if patient profile exists for this user
            PatientProfile patientProfile = await patientProfileRepositories.GetPatientProfileByUser(userId) ??
                throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Patient Profile"));

            if (patientHistoryRequest.Id > 0)
            {
                PatientHistory existingPatientHistory = await patientHistoryRepository.GetPatientHistoryById(patientHistoryRequest.Id) ??
                    throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Patient History"));

                // Update other fields from the request
                patientHistoryRequest.Adapt(existingPatientHistory);

                var existingDocs = existingPatientHistory.MedicalDocumentes.ToList();

                foreach (var incomingDoc in patientHistoryRequest.MedicalDocumentes)
                {
                    if (incomingDoc.Id == 0)
                    {
                        string filePath = await fileService.ValidateAndSaveFile(incomingDoc.DocumentFile, FolderPathConstant.PATIENT_HISTORY_DOCUMENT);

                        existingPatientHistory.MedicalDocumentes.Add(new MedicalDocument
                        {
                            DocumentCategoryId = incomingDoc.DocumentCategoryId,
                            DateOfDocument = incomingDoc.DateOfDocument,
                            FilePath = filePath
                        });
                    }
                    else
                    {
                        var existingDoc = existingDocs.FirstOrDefault(d => d.Id == incomingDoc.Id);
                        if (existingDoc != null)
                        {
                            existingDoc.DocumentCategoryId = incomingDoc.DocumentCategoryId;
                            existingDoc.DateOfDocument = incomingDoc.DateOfDocument;

                            if (incomingDoc.DocumentFile != null)
                            {
                                // Delete old file (optional)
                                await fileService.DeleteFile(existingDoc.FilePath);

                                // Save new one
                                string filePath = await fileService.ValidateAndSaveFile(
                                    incomingDoc.DocumentFile,
                                    FolderPathConstant.PATIENT_HISTORY_DOCUMENT);

                                existingDoc.FilePath = filePath;
                            }
                        }
                    }
                }

                var incomingIds = patientHistoryRequest.MedicalDocumentes.Where(d => d.Id > 0).Select(d => d.Id).ToList();
                var deletedDocs = existingDocs.Where(d => !incomingIds.Contains(d.Id)).ToList();

                foreach (var deletedDoc in deletedDocs)
                {
                    await fileService.DeleteFile(deletedDoc.FilePath);

                    existingPatientHistory.MedicalDocumentes.Remove(deletedDoc);
                }

                await patientHistoryRepository.UpdatePatientHistory(existingPatientHistory);
                return patientHistoryRequest.Id;
            }
            else
            {
                // Add logic
                PatientHistory patientHistory = patientHistoryRequest.Adapt<PatientHistory>();
                patientHistory.PatientId = patientProfile.Id;

                // Map options
                foreach (var medicalDocumentRequest in patientHistoryRequest.MedicalDocumentes)
                {
                    string filePath = await fileService.ValidateAndSaveFile(medicalDocumentRequest.DocumentFile, FolderPathConstant.PATIENT_HISTORY_DOCUMENT);

                    patientHistory.MedicalDocumentes.Add(new MedicalDocument
                    {
                        DocumentCategoryId = medicalDocumentRequest.DocumentCategoryId,
                        DateOfDocument = medicalDocumentRequest.DateOfDocument,
                        FilePath = filePath
                    });
                }

                return await patientHistoryRepository.AddPatientHistory(patientHistory);
            }
        }
    }
}
