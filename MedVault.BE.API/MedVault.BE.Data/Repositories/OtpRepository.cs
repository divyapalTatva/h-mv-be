using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MedVault.BE.Data.Repositories
{
    public class OtpRepository(MedVaultDbContext medVaultDbContext) : IOtpRepository
    {
        public async Task AddOtp(OtpVerification otp)
        {
            medVaultDbContext.OtpVerificationes.Add(otp);
            await medVaultDbContext.SaveChangesAsync();
        }

        public async Task<OtpVerification?> GetValidOtp(int userId, string otpCode)
        {
            return await medVaultDbContext.OtpVerificationes
                .Where(o => o.UserId == userId && o.OtpCode == otpCode && o.Expiry > DateTime.UtcNow)
                .FirstOrDefaultAsync();
        }

        public async Task RemoveOtp(OtpVerification otp)
        {
            medVaultDbContext.OtpVerificationes.Remove(otp);
            await medVaultDbContext.SaveChangesAsync();
        }
    }
}
