using MedVault.BE.Common.Constants;
using MedVault.BE.Data.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Data.Entities.User
{
    [Table("patient_profile")]
    public class PatientProfile : BaseEntity<int>
    {
        [Required]
        [Column("user_id")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [Column("date_of_birth")]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [Column("gender")]
        public Gender Gender { get; set; }

        [Required]
        [Column("blood_group")]
        public BloodGroup BloodGroup { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("emergency_contact_name")]
        public string EmergencyContactName { get; set; } = null!;

        [Required]
        [RegularExpression(ValidationConstants.PHONE_NUMBER_REGEX, ErrorMessage = ExceptionMessage.VALIDATE_PHONE_NUMBER)]
        [Column("emergency_contact_number")]
        public long EmergencyContactNumber { get; set; }

        [MaxLength(1000)]
        [Column("allergies")]
        public string? Allergies { get; set; }

        public virtual User User { get; set; } = null!;
    }
}