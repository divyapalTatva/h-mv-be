using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MedVault.BE.Data.Repositories
{
    public class DoctorProfileRepositories(MedVaultDbContext medVaultDbContext) : IDoctorProfileRepositories
    {
        public async Task<bool> DoctorProfileExists(int userId)
        {
            return await medVaultDbContext.DoctorProfiles.AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> AddDoctorProfile(DoctorProfile profile)
        {
            medVaultDbContext.DoctorProfiles.Add(profile);
            await medVaultDbContext.SaveChangesAsync();
            return profile.Id;
        }

        public async Task<int> UpdateDoctorProfile(DoctorProfile profile)
        {
            medVaultDbContext.DoctorProfiles.Update(profile);
            await medVaultDbContext.SaveChangesAsync();
            return profile.Id;
        }

        public async Task<DoctorProfile?> GetDoctorProfileByIdAndUser(int id, int userId)
        {
            return await medVaultDbContext.DoctorProfiles
                .Include(p => p.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
        }

        public async Task<DoctorProfile?> GetDoctorHospitalByUserId(int userId)
        {
            return await medVaultDbContext.DoctorProfiles
                .Include(p => p.Hospital)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}
