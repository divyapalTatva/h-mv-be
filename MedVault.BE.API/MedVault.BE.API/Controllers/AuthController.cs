using MedVault.BE.API.CustomExceptions;
using MedVault.BE.API.Response;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedVault.BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IResponseService responseService, IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            LoginResponse loginResponse = await authService.Login(loginRequest);

            return responseService.GetSuccessResponse(HttpStatusCode.OK, loginResponse,
                loginResponse.IsOtpSent ? SuccessMessage.OTP_SENT :
                SuccessMessage.LOGIN_SUCCESS);
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpRequest verifyOtpRequest)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelStateException(ModelState);

            LoginResponse loginResponse = await authService.VerifyOtp(verifyOtpRequest);

            return responseService.GetSuccessResponse(HttpStatusCode.OK, loginResponse, SuccessMessage.LOGIN_SUCCESS);
        }
    }
}
