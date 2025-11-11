using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Common.Models.Response
{
    public class ReminderResponse
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public ReminderType TypeId { get; set; }
        public DateTime ReminderDateTime { get; set; }
    }
}
