namespace MedVault.BE.Common.Models.Response
{
    public class PatientHistoryListResponse
    {
        public int Id { get; set; } = 0;

        public string DoctorName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<PatientHistoryDocuments> PatientHistoryDocuments { get; set; } = new List<PatientHistoryDocuments>();
    }

    public class PatientHistoryDocuments
    {
        public string DocumentCategoryName { get; set; }

        public DateTime DateOfDocument { get; set; }

        public string FilePath { get; set; }
    }
}
