using System.ComponentModel.DataAnnotations.Schema;

namespace MedVault.BE.Data.Entities.Common
{
    public abstract class BaseEntity<T> : IdentityEntity<T>, IAuditableEntity
    {
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public int? CreatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by")]
        public int? UpdatedBy { get; set; }
    }
}