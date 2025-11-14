using MedVault.BE.API.CustomExceptions;
using MedVault.BE.API.Response;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net;

namespace MedVault.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "UserOnly")]
    public class PatientHistoryController(IResponseService responseService, IPatientHistoryService patientHistoryService) : ControllerBase
    {
        [HttpPost("get-patient-history-by-pagination")]
        public async Task<IActionResult> GetPatientHistoryByPagination(PatientHistoryListRequest patientHistoryListRequest)
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await patientHistoryService.GetPatientHistoryByPagination(patientHistoryListRequest));
        }

        [HttpGet("get-all-category-type")]
        public async Task<IActionResult> GetAllCategoryType()
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await patientHistoryService.GetAllCategoryType());
        }

        [HttpGet("get-patienthistory-by-id/{id:int}")]
        public async Task<IActionResult> GetPatientHistoryById(int id)
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await patientHistoryService.GetPatientHistoryById(id));
        }

        [HttpPost("save")]
        public async Task<IActionResult> AddUpdatePatientHistory([FromForm] PatientHistoryRequest patientHistoryRequest)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            int savedId = await patientHistoryService.SavePatientHistory(patientHistoryRequest);

            if (patientHistoryRequest.Id > 0)
                return responseService.GetSuccessResponse(HttpStatusCode.OK, savedId, string.Format(SuccessMessage.UPDATED_MESSAGE, "Patient History"));
            else
                return responseService.GetSuccessResponse(HttpStatusCode.OK, savedId, string.Format(SuccessMessage.CREATED_MESSAGE, "Patient History"));
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadFile(string filePath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found");

            var bytes = await System.IO.File.ReadAllBytesAsync(fullPath);

            // Detect MIME type by file extension
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fullPath, out string contentType))
            {
                contentType = "application/octet-stream"; // fallback
            }

            return File(bytes, contentType, Path.GetFileName(fullPath));
        }

    }
}
