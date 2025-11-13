using MedVault.BE.Data.Entities.User;

namespace MedVault.BE.Data.IRepositories
{
    public interface IDoctorProfileRepositories
    {
        Task<bool> DoctorProfileExists(int userId);

        Task<int> AddDoctorProfile(DoctorProfile profile);

        Task<int> UpdateDoctorProfile(DoctorProfile profile);

        Task<DoctorProfile?> GetDoctorProfileByIdAndUser(int id, int userId);

        Task<DoctorProfile?> GetDoctorHospitalByUserId(int userId);

        Task<List<DoctorProfile>> GetDoctorsForDropdown();
    }
}
