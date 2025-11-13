using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;

namespace MedVault.BE.Services.IServices
{
    public interface IDoctorProfileService
    {
        Task<int> AddDoctorProfile(DoctorProfileRequest doctorProfileRequest);

        Task<int> UpdateDoctorProfile(DoctorProfileRequest doctorProfileRequest);

        Task<List<DropdownResponse>> GetAllDoctors();
    }
}
