using MedVault.BE.API.CustomExceptions;
using MedVault.BE.API.Response;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedVault.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "DoctorOnly")]
    public class DoctorProfileController(IResponseService responseService, IDoctorProfileService doctorProfileService) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddDoctorProfile(DoctorProfileRequest doctorProfileRequest)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            int id = await doctorProfileService.AddDoctorProfile(doctorProfileRequest);
            return responseService.GetSuccessResponse(HttpStatusCode.OK, id, SuccessMessage.DOCTOR_PROFILE_ADD_SUCCESS);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDoctorProfile(DoctorProfileRequest doctorProfileRequest)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            if (doctorProfileRequest.Id <= 0)
                throw new InvalidModelStateException(ExceptionMessage.ID_IS_NULL_OR_ZERO);

            int id = await doctorProfileService.UpdateDoctorProfile(doctorProfileRequest);
            return responseService.GetSuccessResponse(HttpStatusCode.OK, id, SuccessMessage.DOCTOR_PROFILE_UPDATE_SUCCESS);
        }
    }
}
