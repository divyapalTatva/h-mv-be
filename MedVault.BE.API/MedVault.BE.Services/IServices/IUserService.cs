using MedVault.BE.Common.Models.Request;

namespace MedVault.BE.Services.IServices
{
    public interface IUserService
    {
        Task<int> UserRegister(UserRegisterRequest registrationRequest);
    }
}
