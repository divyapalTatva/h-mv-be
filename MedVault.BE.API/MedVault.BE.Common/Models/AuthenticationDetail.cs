using static MedVault.BE.Common.Enums.Enums;
using System.Data;

namespace MedVault.BE.Common.Models
{
    public class AuthenticationDetail(int id, string firstName, string lastName, string email, UserRole role)
    {
        public int Id { get; set; } = id;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public UserRole Role { get; set; } = role;
        public bool IsProfileFilled { get; set; } = false;
    }
}
