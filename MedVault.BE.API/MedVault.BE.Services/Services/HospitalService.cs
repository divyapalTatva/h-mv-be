using Mapster;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.Master;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Services.IServices;

namespace MedVault.BE.Services.Services
{
    public class HospitalService(IHospitalRepository hospitalRepository) : IHospitalService
    {
        public async Task<PageListResponse<HospitalResponse>> GetHospitalsByPagination(PageListRequest pageListRequest)
        {
            PageListResponse<Hospital> hospitals = await hospitalRepository.GetHospitalsByPagination(pageListRequest);
            return hospitals.Adapt<PageListResponse<HospitalResponse>>();
        }

        public async Task<List<DropdownResponse>> GetAllHospitals()
        {
            List<Hospital> hospitalList = await hospitalRepository.GetHospitalsForDropdown();
            return hospitalList.Adapt<List<DropdownResponse>>();
        }
    }
}
