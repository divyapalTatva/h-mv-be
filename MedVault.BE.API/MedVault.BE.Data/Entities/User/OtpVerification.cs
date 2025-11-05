using MedVault.BE.Data.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedVault.BE.Data.Entities.User
{
    public class OtpVerification : IdentityEntity<int>
    {
        [Required]
        [Column("user_id")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(6)]
        [Column("OtpCode")]
        public string OtpCode { get; set; } = null!;

        [Required]
        [Column("expiry")]
        public DateTime Expiry { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
