using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.Patient;
using MedVault.BE.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MedVault.BE.Data.Repositories
{
    public class ReminderRepository(MedVaultDbContext medVaultDbContext) : IReminderRepository
    {
        public async Task<List<Reminder>> GetUpcomingReminderByUserId(int userId)
        {
            return await medVaultDbContext.Reminderes
                .Include(x =>x.PatientProfile)
                .AsNoTracking()
                .Where(x => x.ReminderDateTime > DateTime.UtcNow && x.PatientProfile.UserId == userId)
                .OrderBy(g => g.ReminderDateTime)
                .ToListAsync();
        }
    }
}
