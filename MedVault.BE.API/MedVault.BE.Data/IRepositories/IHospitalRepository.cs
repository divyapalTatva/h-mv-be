using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.Master;

namespace MedVault.BE.Data.IRepositories
{
    public interface IHospitalRepository
    {
        Task<PageListResponse<Hospital>> GetHospitalsByPagination(PageListRequest pageListRequest);

        Task<List<Hospital>> GetHospitalsForDropdown();
    }
}
