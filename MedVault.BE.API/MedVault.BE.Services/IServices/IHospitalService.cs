using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;

namespace MedVault.BE.Services.IServices
{
    public interface IHospitalService
    {
        Task<PageListResponse<HospitalResponse>> GetHospitalsByPagination(PageListRequest pageListRequest);

        Task<List<DropdownResponse>> GetAllHospitals();
    }
}
