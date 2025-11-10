using MedVault.BE.API.CustomExceptions;
using MedVault.BE.API.Response;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedVault.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IResponseService responseService, IUserService userService) : ControllerBase
    {
        [HttpPost("user-register")]
        public async Task<IActionResult> UserRegister(UserRegisterRequest userRegisterRequest)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            string userId = await userService.UserRegister(userRegisterRequest);

            return responseService.GetSuccessResponse(HttpStatusCode.OK, userId, SuccessMessage.USER_REGISTERED);
        }
    }
}