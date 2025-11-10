using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Common.Models.Response
{
    public class DashboardSummaryResponse
    {
        public int TotalRecords { get; set; }
        public List<UpcomingReminders> UpcomingReminders { get; set; }
        public LastPatientRecord LastRecord { get; set; } = null!;
        public int TotalCheckups { get; set; }
        public DoctorHospital Hospital { get; set; } = null!;
    }

    public class DoctorHospital
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
    }

    public class LastPatientRecord
    {
        public DateTime Date { get; set; }
        public int DocumentCount { get; set; }
    }

    public class UpcomingReminders
    {
        public ReminderType TypeId { get; set; }

        public string? Description { get; set; }

        public DateTime ReminderDateTime { get; set; }
    }
}
