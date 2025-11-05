using MedVault.BE.Data.Entities.Common;
using MedVault.BE.Data.Entities.Master;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedVault.BE.Data.Entities.User
{
    [Table("doctor_profile")]
    public class DoctorProfile : BaseEntity<int>
    {
        [Required]
        [Column("user_id")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("specialization")]
        public string Specialization { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [Column("registration_number")]
        public string RegistrationNumber { get; set; } = null!;

        [Column("hospital_id")]
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }

        [Column("is_verified")]
        public bool IsVerified { get; set; } = false;

        public virtual User User { get; set; } = null!;

        public virtual Hospital Hospital { get; set; }
    }
}