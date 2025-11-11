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
                .Include(x => x.PatientProfile)
                .AsNoTracking()
                .Where(x => x.ReminderDateTime > DateTime.UtcNow && x.PatientProfile.UserId == userId)
                .OrderBy(g => g.ReminderDateTime)
                .ToListAsync();
        }

        public async Task<int> AddReminder(Reminder reminder)
        {
            medVaultDbContext.Reminderes.Add(reminder);
            await medVaultDbContext.SaveChangesAsync();
            return reminder.Id;
        }

        public async Task<Reminder?> GetReminderByIdAndUser(int id, int userId)
        {
            return await medVaultDbContext.Reminderes
                .Include(x => x.PatientProfile)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id && p.PatientProfile.UserId == userId);
        }

        public async Task<int> UpdateReminder(Reminder reminder)
        {
            medVaultDbContext.Reminderes.Update(reminder);
            await medVaultDbContext.SaveChangesAsync();
            return reminder.Id;
        }

        public async Task DeleteReminder(Reminder reminder)
        {
            medVaultDbContext.Reminderes.Remove(reminder);
            await medVaultDbContext.SaveChangesAsync();
        }

        public async Task<List<Reminder>> GetAllReminderByPatientId(int patientId)
        {
            return await medVaultDbContext.Reminderes
                .Where(x => x.PatientId == patientId)
                .OrderBy(r => r.ReminderDateTime)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
