using MedVault.BE.API.Response;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedVault.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "UserOrDoctor")]
    public class DashboardController(IResponseService responseService, IDashboardService dashboardService) : ControllerBase
    {
        [HttpGet("get-dashboard-summary")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await dashboardService.GetDashboardSummary());
        }
    }
}
