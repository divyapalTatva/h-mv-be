using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;

namespace MedVault.BE.Services.IServices
{
    public interface IReminderService
    {
        Task<int> AddReminder(ReminderRequest request);

        Task<int> UpdateReminder(ReminderRequest request);

        Task DeleteReminder(int id);

        Task<List<ReminderResponse>> GetAllReminder();

        Task<ReminderResponse> GetReminderById(int id);
    }
}
