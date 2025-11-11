using static MedVault.BE.Common.Enums.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedVault.BE.Common.Models.Request
{
    public class ReminderRequest
    {
        public int Id { get; set; } = 0;

        [Required]
        public ReminderType TypeId { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        public DateTime ReminderDateTime { get; set; }
    }
}
