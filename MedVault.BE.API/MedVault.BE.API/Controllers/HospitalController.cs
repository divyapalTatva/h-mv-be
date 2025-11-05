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
    public class HospitalController(IResponseService responseService, IHospitalService hospitalService) : ControllerBase
    {
        [HttpPost("get-hospitals-by-pagination")]
        public async Task<IActionResult> GetHospitalsByPagination(PageListRequest pageListRequest)
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await hospitalService.GetHospitalsByPagination(pageListRequest));
        }

        [HttpGet("get-all-hospitals")]
        [Authorize(Policy = "UserOrDoctor")]
        public async Task<IActionResult> GetAllHospitals()
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await hospitalService.GetAllHospitals());
        }
    }
}
