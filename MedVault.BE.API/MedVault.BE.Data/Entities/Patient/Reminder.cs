using MedVault.BE.Data.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedVault.BE.Data.Entities.User;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Data.Entities.Patient
{
    [Table("reminder")]
    public class Reminder : BaseEntity<int>
    {
        [Required]
        [Column("patient_id")]
        [ForeignKey("PatientProfile")]
        public int PatientId { get; set; }

        [Required]
        [Column("type_id")]
        public ReminderType TypeId { get; set; }

        [MaxLength(250)]
        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("reminder_datetime")]
        public DateTime ReminderDateTime { get; set; }

        public virtual PatientProfile PatientProfile { get; set; } = null!;
    }
}
