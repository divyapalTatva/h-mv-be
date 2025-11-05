using static MedVault.BE.Common.Enums.Enums;
using System.ComponentModel.DataAnnotations;
using MedVault.BE.Common.Constants;

namespace MedVault.BE.Common.Models.Request
{
    public class VerifyOtpRequest
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(6)]
        public string OtpCode { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }
    }
}
