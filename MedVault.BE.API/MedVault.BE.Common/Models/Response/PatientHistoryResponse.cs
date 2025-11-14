namespace MedVault.BE.Common.Models.Response
{
    public class PatientHistoryResponse
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public List<PatientHistoryDocumentsResponse> PatientHistoryDocuments { get; set; } = new List<PatientHistoryDocumentsResponse>();
    }

    public class PatientHistoryDocumentsResponse
    {
        public int Id { get; set; }

        public int DocumentCategoryId { get; set; }

        public DateTime DateOfDocument { get; set; }

        public string FilePath { get; set; }
    }
}
