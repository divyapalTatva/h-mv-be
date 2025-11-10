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
    [Authorize(Policy = "UserOnly")]
    public class PatientProfileController(IResponseService responseService, IPatientProfileService patientProfileService) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddPatientProfile(PatientProfileRequest patientProfileRequest)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            int id = await patientProfileService.AddPatientProfile(patientProfileRequest);
            return responseService.GetSuccessResponse(HttpStatusCode.OK, id, SuccessMessage.PATIENT_PROFILE_ADD_SUCCESS);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePatientProfile(PatientProfileRequest patientProfileRequest)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            if(patientProfileRequest.Id <= 0)
                throw new InvalidModelStateException(ExceptionMessage.ID_IS_NULL_OR_ZERO);

            int id = await patientProfileService.UpdatePatientProfile(patientProfileRequest);
            return responseService.GetSuccessResponse(HttpStatusCode.OK, id, SuccessMessage.PATIENT_PROFILE_UPDATE_SUCCESS);
        }

        [HttpGet("get-emergency-details")]
        public async Task<IActionResult> GetEmergencyDetails()
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await patientProfileService.GetEmergencyDetails());
        }
    }
}
