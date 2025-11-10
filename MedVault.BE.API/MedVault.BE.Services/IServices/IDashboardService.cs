using MedVault.BE.Common.Models.Response;

namespace MedVault.BE.Services.IServices
{
    public interface IDashboardService
    {
        Task<DashboardSummaryResponse> GetDashboardSummary();
    }
}
