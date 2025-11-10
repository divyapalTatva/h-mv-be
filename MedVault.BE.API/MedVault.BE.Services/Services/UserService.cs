using Mapster;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.CustomExceptions;
using MedVault.BE.Common.Helpers;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Services.IServices;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Services.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<string> UserRegister(UserRegisterRequest registrationRequest)
        {
            if (await userRepository.UserExists(registrationRequest.Email))
                throw new DataAlreadyExistsException(string.Format(ExceptionMessage.DATA_ALREADY_EXIST, "User"));

            User user = registrationRequest.Adapt<User>();
            user.PasswordHash = EncryptionHelper.Base64Encode(registrationRequest.Password);

            await userRepository.AddUser(user);

            UserRoles userRole = new UserRoles
            {
                UserId = user.Id,
                RoleId = UserRole.User
            };

            await userRepository.AddUserRole(userRole);

            return EncryptionHelper.Base64Encode(user.Id.ToString());
        }
    }
}
