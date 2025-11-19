using MedVault.BE.Common.Constants;
using System.ComponentModel.DataAnnotations;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Common.Models.Request
{
    public class UserRegisterRequest
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [RegularExpression(ValidationConstants.EMAIL_REGEX, ErrorMessage = ExceptionMessage.VALIDATE_EMAIL)]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(ValidationConstants.PHONE_NUMBER_REGEX, ErrorMessage = ExceptionMessage.VALIDATE_PHONE_NUMBER)]
        public long PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = null!;

        [Required]
        public UserRole Role { get; set; }
    }
}
