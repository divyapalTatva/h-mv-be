using MedVault.BE.Common.Constants;
using System.ComponentModel.DataAnnotations;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Common.Models.Request
{
    public class LoginRequest
    {
        [Required]
        [RegularExpression(ValidationConstants.EMAIL_REGEX, ErrorMessage = ExceptionMessage.VALIDATE_EMAIL)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }
    }
}
