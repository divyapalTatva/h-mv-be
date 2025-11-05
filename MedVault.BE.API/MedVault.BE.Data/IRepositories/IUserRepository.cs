using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.User;

namespace MedVault.BE.Data.IRepositories
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string email);

        Task<int> AddUser(User user);

        Task<int> AddUserRole(UserRoles userRoles);

        Task<User?> GetUserByEmail(string email);

        Task<User?> GetUserById(int userId);
    }
}
