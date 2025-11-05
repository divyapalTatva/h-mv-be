using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MedVault.BE.Data.Repositories
{
    public class UserRepository(MedVaultDbContext medVaultDbContext) : IUserRepository
    {
        public async Task<bool> UserExists(string email)
        {
            return await medVaultDbContext.Users.AsNoTracking().AnyAsync(a => a.Email == email);
        }

        public async Task<int> AddUser(User user)
        {
            medVaultDbContext.Users.Add(user);
            await medVaultDbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> AddUserRole(UserRoles userRoles)
        {
            medVaultDbContext.UserRoles.Add(userRoles);
            await medVaultDbContext.SaveChangesAsync();
            return userRoles.Id;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await medVaultDbContext.Users.Include(u => u.UserRoles)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(a => a.Email.ToLower() == email.ToLower());
        }

        public async Task<User?> GetUserById(int userId)
        {
            return await medVaultDbContext.Users.Include(u => u.UserRoles)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(a => a.Id == userId);
        }
    }
}
