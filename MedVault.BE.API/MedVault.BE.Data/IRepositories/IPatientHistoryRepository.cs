using MedVault.BE.Data.Entities.Patient;

namespace MedVault.BE.Data.IRepositories
{
    public interface IPatientHistoryRepository
    {
        Task<int> GetPatientHistoryCountByUserId(int userId);

        Task<PatientHistory?> GetLastPatientHistoryByUserId(int userId);

        Task<int> GetTotoalCheckupByUserId(int userId);
    }
}
