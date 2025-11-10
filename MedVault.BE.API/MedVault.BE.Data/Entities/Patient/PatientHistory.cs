using MedVault.BE.Data.Entities.Common;
using MedVault.BE.Data.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedVault.BE.Data.Entities.Patient
{
    [Table("patient_history")]
    public class PatientHistory : BaseEntity<int>
    {
        [Required]
        [Column("patient_id")]
        [ForeignKey("PatientProfile")]
        public int PatientId { get; set; }

        [Required]
        [Column("doctor_id")]
        [ForeignKey("DoctorProfile")]
        public int DoctorId { get; set; }

        [MaxLength(1000)]
        [Column("description")]
        public string? Description { get; set; }

        public virtual PatientProfile PatientProfile { get; set; } = null!;

        public virtual DoctorProfile DoctorProfile { get; set; } = null!;

        public virtual ICollection<MedicalDocument> MedicalDocumentes { get; set; } = new List<MedicalDocument>();
    }
}