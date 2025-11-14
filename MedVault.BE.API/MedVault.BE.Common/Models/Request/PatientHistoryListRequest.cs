namespace MedVault.BE.Common.Models.Request
{
    public class PatientHistoryListRequest : PageListRequest
    {
        public DateTime? CreatedDate { get; set; }

        public int? CategoryType { get; set; } = 0;

        public int? DocotorId { get; set; } = 0;
    }
}
