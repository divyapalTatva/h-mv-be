using MedVault.BE.Common.Models.Request;

namespace MedVault.BE.Services.IServices
{
    public interface IDoctorProfileService
    {
        Task<int> AddDoctorProfile(DoctorProfileRequest doctorProfileRequest);

        Task<int> UpdateDoctorProfile(DoctorProfileRequest doctorProfileRequest);
    }
}
