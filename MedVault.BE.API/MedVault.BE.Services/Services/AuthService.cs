using MedVault.BE.Common.Constants;
using MedVault.BE.Common.CustomExceptions;
using MedVault.BE.Common.Helpers;
using MedVault.BE.Common.Models;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Services.IServices;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Services.Services
{
    public class AuthService(IUserRepository userRepository, IOtpRepository otpRepository,
        IPatientProfileRepositories patientProfileRepositories, IDoctorProfileRepositories doctorProfileRepositories,
        AuthenticationHelper authenticationHelper) : IAuthService
    {
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            User user = await userRepository.GetUserByEmail(loginRequest.Email)
                         ?? throw new ForbiddenException(ExceptionMessage.UNREGISTERED_EMAIL);

            // Validate password
            string encodedPassword = EncryptionHelper.Base64Encode(loginRequest.Password);
            if (user.PasswordHash != encodedPassword)
                throw new ForbiddenException(ExceptionMessage.INCORRECT_PASSWORD);

            // Check if selected role exists for user
            bool hasRole = user.UserRoles.Any(r => r.RoleId == loginRequest.Role);
            if (!hasRole)
                throw new ForbiddenException(string.Format(ExceptionMessage.NOT_HAVING_PERMISSION_FOR_ROLE, loginRequest.Role));

            //Check two-factor authentication
            if (user.IsTwoFactorEnabled)
            {
                string otp = OtpHelper.GenerateOtp(); // e.g., "827364"

                OtpVerification otpEntity = new OtpVerification
                {
                    UserId = user.Id,
                    OtpCode = otp,
                    Expiry = DateTime.UtcNow.AddMinutes(5)
                };

                await otpRepository.AddOtp(otpEntity);

                // Send OTP to email (simplified)
                //await emailService.SendAsync(user.Email, "Your OTP Code", $"Your OTP is {otp}. It will expire in 5 minutes.");

                // Return partial response
                return new LoginResponse
                {
                    UserID = EncryptionHelper.Base64Encode(user.Id.ToString()),
                    IsOtpSent = true
                };
            }
            return await GenerateToken(user, loginRequest.Role);
        }

        public async Task<LoginResponse> VerifyOtp(VerifyOtpRequest verifyOtpRequest)
        {
            int userId = Convert.ToInt32(EncryptionHelper.Base64Decode(verifyOtpRequest.UserId));

            if (userId <= 0)
            {
                throw new BadRequestException(ExceptionMessage.INCORRECT_VERIFY_OTP_REQUEST);
            }

            User user = await userRepository.GetUserById(userId)
                        ?? throw new ForbiddenException(ExceptionMessage.UNREGISTERED_USER);

            // Check if selected role exists for user
            bool hasRole = user.UserRoles.Any(r => r.RoleId == verifyOtpRequest.Role);
            if (!hasRole)
                throw new ForbiddenException(string.Format(ExceptionMessage.NOT_HAVING_PERMISSION_FOR_ROLE, verifyOtpRequest.Role));

            OtpVerification otp = await otpRepository.GetValidOtp(userId, verifyOtpRequest.OtpCode)
                      ?? throw new ForbiddenException(ExceptionMessage.INCORRECT_OTP);

            await otpRepository.RemoveOtp(otp);

            // Generate token now
            return await GenerateToken(user, verifyOtpRequest.Role);
        }

        public async Task<LoginResponse> GenerateToken(User user, UserRole userRole)
        {
            AuthenticationDetail authDetails = new AuthenticationDetail(user.Id, user.FirstName, user.LastName, user.Email, userRole);

            authDetails.IsProfileFilled = userRole switch
            {
                UserRole.User => await patientProfileRepositories.PatientProfileExists(user.Id),
                UserRole.Doctor => await doctorProfileRepositories.DoctorProfileExists(user.Id),
                _ => throw new ForbiddenException(
                    string.Format(ExceptionMessage.NOT_HAVING_PERMISSION_FOR_ROLE, userRole)
                )
            };

            return new LoginResponse
            {
                AccessToken = authenticationHelper.GenerateAccessToken(authDetails),
                IsOtpSent = false
            };
        }
    }
}