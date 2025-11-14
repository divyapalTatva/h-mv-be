using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;

namespace MedVault.BE.Services.IServices
{
    public interface IPatientHistoryService
    {
        Task<PageListResponse<PatientHistoryListResponse>> GetPatientHistoryByPagination(PatientHistoryListRequest patientHistoryRequest);

        Task<List<DropdownResponse>> GetAllCategoryType();

        Task<PatientHistoryResponse> GetPatientHistoryById(int id);

        Task<int> SavePatientHistory(PatientHistoryRequest patientHistoryRequest);
    }
}
