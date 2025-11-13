using MedVault.BE.API.Response;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedVault.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "UserOnly")]
    public class PatientHistoryController(IResponseService responseService, IPatientHistoryService patientHistoryService) : ControllerBase
    {
        [HttpPost("get-patient-history-by-pagination")]
        public async Task<IActionResult> GetPatientHistoryByPagination(PatientHistoryRequest patientHistoryRequest)
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await patientHistoryService.GetPatientHistoryByPagination(patientHistoryRequest));
        }

        [HttpGet("get-all-category-type")]
        public async Task<IActionResult> GetAllCategoryType()
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await patientHistoryService.GetAllCategoryType());
        }
    }
}
