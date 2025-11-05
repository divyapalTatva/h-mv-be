namespace MedVault.BE.Common.Models.Response
{
    public class HospitalResponse
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string? Address { get; set; }
        public long ContactNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
