using MedVault.BE.Data.Entities.User;

namespace MedVault.BE.Data.IRepositories
{
    public interface IPatientProfileRepositories
    {
        Task<bool> PatientProfileExists(int userId);

        Task<int> AddPatientProfile(PatientProfile profile);

        Task<int> UpdatePatientProfile(PatientProfile profile);

        Task<PatientProfile?> GetPatientProfileByIdAndUser(int id, int userId);
    }
}
