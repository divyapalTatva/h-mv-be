using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.Patient;
using MedVault.BE.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MedVault.BE.Data.Repositories
{
    public class PatientHistoryRepository(MedVaultDbContext medVaultDbContext) : IPatientHistoryRepository
    {
        public async Task<PatientHistory?> GetLastPatientHistoryByUserId(int userId)
        {
            return await medVaultDbContext.PatientHistories
                                          .Include(x => x.PatientProfile)
                                          .OrderByDescending(x => x.Id)
                                          .FirstOrDefaultAsync(a => a.PatientProfile.UserId == userId);
        }

        public async Task<int> GetPatientHistoryCountByUserId(int userId)
        {
            return await medVaultDbContext.PatientHistories
                                          .Include(x => x.MedicalDocumentes)
                                          .Include(x => x.PatientProfile)
                                          .AsNoTracking()
                                          .Where(a => a.PatientProfile.UserId == userId)
                                          .CountAsync();
        }

        public async Task<int> GetTotoalCheckupByUserId(int userId)
        {
            return await medVaultDbContext.PatientHistories
                                          .Include(x => x.DoctorProfile)
                                          .AsNoTracking()
                                          .Where(a => a.DoctorProfile.UserId == userId)
                                          .CountAsync();
        }
    }
}
