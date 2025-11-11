using MedVault.BE.API.CustomExceptions;
using MedVault.BE.API.Response;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Services.IServices;
using MedVault.BE.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedVault.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "UserOnly")]
    public class ReminderController(IResponseService responseService, IReminderService reminderService) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddReminder(ReminderRequest request)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            int id = await reminderService.AddReminder(request);
            return responseService.GetSuccessResponse(HttpStatusCode.OK, id, "Reminder added successfully.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateReminder(ReminderRequest request)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            if (request.Id <= 0)
                throw new InvalidModelStateException("Reminder ID cannot be null or zero.");

            int id = await reminderService.UpdateReminder(request);
            return responseService.GetSuccessResponse(HttpStatusCode.OK, id, "Reminder updated successfully.");
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            if (id <= 0)
                throw new InvalidModelStateException("Reminder ID cannot be null or zero.");

            await reminderService.DeleteReminder(id);
            return responseService.GetSuccessResponse(HttpStatusCode.OK, "Reminder deleted successfully.");
        }

        [HttpGet("get-all-reminder")]
        public async Task<IActionResult> GetAllReminder()
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await reminderService.GetAllReminder());
        }

        [HttpGet("get-reminder-by-id/{id:int}")]
        public async Task<IActionResult> GetReminderById(int id)
        {
            return responseService.GetSuccessResponse(HttpStatusCode.OK, await reminderService.GetReminderById(id));
        }
    }
}
