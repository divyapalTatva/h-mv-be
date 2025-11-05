using System.ComponentModel.DataAnnotations;

namespace MedVault.BE.Common.Models.Request
{
    public class DoctorProfileRequest
    {
        public int Id { get; set; } = 0;

        [Required]
        [MaxLength(250)]
        public string Specialization { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        public int HospitalId { get; set; }
    }
}
