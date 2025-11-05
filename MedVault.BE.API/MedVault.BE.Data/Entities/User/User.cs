using MedVault.BE.Common.Constants;
using MedVault.BE.Data.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedVault.BE.Data.Entities.User
{
    [Table("user")]
    public class User : BaseEntity<int>
    {
        [Required]
        [MaxLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
        [Column("middle_name")]
        public string? MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("last_name")]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        [RegularExpression(ValidationConstants.EMAIL_REGEX, ErrorMessage = ExceptionMessage.VALIDATE_EMAIL)]
        [Column("email")]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(ValidationConstants.PHONE_NUMBER_REGEX, ErrorMessage = ExceptionMessage.VALIDATE_PHONE_NUMBER)]
        [Column("phone_number")]
        public long PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("password_hash")]
        public string PasswordHash { get; set; } = null!;

        [Column("is_two_factor_enabled")]
        public bool IsTwoFactorEnabled { get; set; } = true;


        public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
    }
}
