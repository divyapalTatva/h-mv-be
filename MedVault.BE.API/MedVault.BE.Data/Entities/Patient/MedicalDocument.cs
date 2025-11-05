using MedVault.BE.Data.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.Entities.Master;

namespace MedVault.BE.Data.Entities.Patient
{
    public class MedicalDocument : BaseEntity<int>
    {
        [Required]
        [Column("patient_history_id")]
        [ForeignKey("PatientHistory")]
        public int PatientHistoryId { get; set; }

        [Required]
        [Column("document_category_id")]
        [ForeignKey("DocumentCategory")]
        public int DocumentCategoryId { get; set; }

        [Required]
        [Column("date_of_document")]
        public DateTime DateOfDocument { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("file_path")]
        public string FilePath { get; set; }

        public virtual PatientHistory PatientHistory { get; set; } = null!;

        public virtual DocumentCategory DocumentCategory { get; set; } = null!;
    }
}
