using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;

namespace MedVault.BE.Services.IServices
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);

        Task<LoginResponse> VerifyOtp(VerifyOtpRequest verifyOtpRequest);
    }
}
