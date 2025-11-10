using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MedVault.BE.Data.Repositories
{
    public class PatientProfileRepositories(MedVaultDbContext medVaultDbContext) : IPatientProfileRepositories
    {
        public async Task<bool> PatientProfileExists(int userId)
        {
            return await medVaultDbContext.PatientProfiles.AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> AddPatientProfile(PatientProfile profile)
        {
            medVaultDbContext.PatientProfiles.Add(profile);
            await medVaultDbContext.SaveChangesAsync();
            return profile.Id;
        }

        public async Task<int> UpdatePatientProfile(PatientProfile profile)
        {
            medVaultDbContext.PatientProfiles.Update(profile);
            await medVaultDbContext.SaveChangesAsync();
            return profile.Id;
        }

        public async Task<PatientProfile?> GetPatientProfileByIdAndUser(int id, int userId)
        {
            return await medVaultDbContext.PatientProfiles
                .Include(p => p.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
        }

        public async Task<PatientProfile?> GetPatientProfileByUser(int userId)
        {
            return await medVaultDbContext.PatientProfiles
                .Include(p => p.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}
