using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Common.Models.Response
{
    public class EmergencyResponse
    {
        public DateOnly DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public string EmergencyContactName { get; set; } = null!;

        public long EmergencyContactNumber { get; set; }

        public string? Allergies { get; set; }
    }
}