using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Common.Models.Response
{
    public class LoginResponse
    {
        public string UserID { get; set; } = string.Empty; 

        public string? AccessToken { get; set; }

        public bool IsOtpSent { get; set; } = false;
    }
}
