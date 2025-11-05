using MedVault.BE.Common.Constants;
using static MedVault.BE.Common.Enums.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedVault.BE.Common.Models.Request
{
    public class PatientProfileRequest
    {
        public int Id { get; set; } = 0;

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public BloodGroup BloodGroup { get; set; }

        [Required]
        [MaxLength(250)]
        public string EmergencyContactName { get; set; } = null!;

        [Required]
        [RegularExpression(ValidationConstants.PHONE_NUMBER_REGEX, ErrorMessage = ExceptionMessage.VALIDATE_PHONE_NUMBER)]
        public long EmergencyContactNumber { get; set; }

        [MaxLength(1000)]
        public string? Allergies { get; set; }
    }
}
