using Mapster;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.Master;
using MedVault.BE.Data.Entities.Patient;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Services.IServices;

namespace MedVault.BE.Services.Services
{
    public class PatientHistoryService(IPatientHistoryRepository patientHistoryRepository, IDocumentCategoryRepository documentCategoryRepository) : IPatientHistoryService
    {
        public async Task<PageListResponse<PatientHistoryResponse>> GetPatientHistoryByPagination(PatientHistoryRequest patientHistoryRequest)
        {
            PageListResponse<PatientHistory> patientHistories = await patientHistoryRepository.GetPatientHistoryByPagination(patientHistoryRequest);
            return patientHistories.Adapt<PageListResponse<PatientHistoryResponse>>();
        }

        public async Task<List<DropdownResponse>> GetAllCategoryType()
        {
            List<DocumentCategory> documentCategoryList = await documentCategoryRepository.GetDocumentCategoryForDropdown();
            return documentCategoryList.Adapt<List<DropdownResponse>>();
        }
    }
}
