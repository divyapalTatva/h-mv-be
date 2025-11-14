using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MedVault.BE.Common.Models.Request
{
    public class PatientHistoryRequest
    {
        public int Id { get; set; } = 0;

        [Required]
        public int DoctorId { get; set; }

        [MaxLength(150)]
        public string Title { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; }

        public List<MedicalDocumentRequest> MedicalDocumentes { get; set; } = new();
    }

    public class MedicalDocumentRequest
    {
        public int Id { get; set; } = 0;

        public int DocumentCategoryId { get; set; }

        public DateTime DateOfDocument { get; set; }

        public IFormFile? DocumentFile { get; set; }
    }
}
