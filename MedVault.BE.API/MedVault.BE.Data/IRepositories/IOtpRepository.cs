using MedVault.BE.Data.Entities.User;

namespace MedVault.BE.Data.IRepositories
{
    public interface IOtpRepository
    {
        Task AddOtp(OtpVerification otp);

        Task<OtpVerification?> GetValidOtp(int userId, string otpCode);

        Task RemoveOtp(OtpVerification otp);
    }
}
