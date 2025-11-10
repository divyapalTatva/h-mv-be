using MedVault.BE.Data.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedVault.BE.Data.Entities.Master
{
    [Table("document_category")]
    public class DocumentCategory : BaseEntity<int>
    {
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Required]
        [MaxLength(150)]
        [Column("document_category_name")]
        public string DocumentCategoryName { get; set; } = null!;
    }
}
