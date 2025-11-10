using MedVault.BE.Data.Entities.Master;
using MedVault.BE.Data.Entities.Patient;

namespace MedVault.BE.Data.IRepositories
{
    public interface IReminderRepository
    {
        Task<List<Reminder>> GetUpcomingReminderByUserId(int userId);
    }
}
