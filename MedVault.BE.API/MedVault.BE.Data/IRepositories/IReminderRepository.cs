using MedVault.BE.Data.Entities.Patient;

namespace MedVault.BE.Data.IRepositories
{
    public interface IReminderRepository
    {
        Task<List<Reminder>> GetUpcomingReminderByUserId(int userId);

        Task<int> AddReminder(Reminder reminder);

        Task<Reminder?> GetReminderByIdAndUser(int id, int userId);

        Task<int> UpdateReminder(Reminder reminder);

        Task DeleteReminder(Reminder reminder);

        Task<List<Reminder>> GetAllReminderByPatientId(int patientId);
    }
}
