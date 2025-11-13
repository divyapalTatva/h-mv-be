using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;

namespace MedVault.BE.Services.IServices
{
    public interface IPatientHistoryService
    {
        Task<PageListResponse<PatientHistoryResponse>> GetPatientHistoryByPagination(PatientHistoryRequest patientHistoryRequest);

        Task<List<DropdownResponse>> GetAllCategoryType();
    }
}
