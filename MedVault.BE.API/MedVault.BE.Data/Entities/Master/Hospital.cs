using MedVault.BE.Common.Constants;
using MedVault.BE.Data.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedVault.BE.Data.Entities.Master
{
    [Table("hospital")]
    public class Hospital : BaseEntity<int>
    {
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Required]
        [MaxLength(150)]
        [Column("hospital_name")]
        public string HospitalName { get; set; } = null!;

        [MaxLength(250)]
        [Column("address")]
        public string? Address { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.PHONE_NUMBER_REGEX, ErrorMessage = ExceptionMessage.VALIDATE_PHONE_NUMBER)]
        [Column("contact_number")]
        public long ContactNumber { get; set; }
    }
}
