using MedVault.BE.Data.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Data.Entities.User
{
    [Table("user_role")]
    public class UserRoles : BaseEntity<int>
    {
        [Required]
        [Column("user_id")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [Column("role_id")]
        public UserRole RoleId { get; set; } = UserRole.User;


        public virtual User User { get; set; } = null!;
    }
}
