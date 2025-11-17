using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.Patient;

namespace MedVault.BE.Data.IRepositories
{
    public interface IPatientHistoryRepository
    {
        Task<int> GetPatientHistoryCountByUserId(int userId);

        Task<PatientHistory?> GetLastPatientHistoryByUserId(int userId);

        Task<int> GetTotoalCheckupByUserId(int userId);

        Task<PageListResponse<PatientHistory>> GetPatientHistoryByPagination(PatientHistoryListRequest patientHistoryListRequest, int userId);

        Task<int> AddPatientHistory(PatientHistory patientHistory);

        Task UpdatePatientHistory(PatientHistory patientHistory);

        Task<PatientHistory?> GetPatientHistoryById(int id);
    }
}
