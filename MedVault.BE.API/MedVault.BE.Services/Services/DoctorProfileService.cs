using Mapster;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.CustomExceptions;
using MedVault.BE.Common.Helpers;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Data.Repositories;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace MedVault.BE.Services.Services
{
    public class DoctorProfileService(IHttpContextAccessor contextAccessor, IDoctorProfileRepositories doctorProfileRepository) : IDoctorProfileService
    {
        public async Task<int> AddDoctorProfile(DoctorProfileRequest doctorProfileRequest)
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.INVALID_USER_ID);

            // Check if doctor profile already exists for this user
            bool exists = await doctorProfileRepository.DoctorProfileExists(userId);
            if (exists)
                throw new DataAlreadyExistsException(string.Format(ExceptionMessage.DATA_ALREADY_EXIST, "Doctor Profile"));

            DoctorProfile doctorProfile = doctorProfileRequest.Adapt<DoctorProfile>();
            doctorProfile.UserId = userId;
            await doctorProfileRepository.AddDoctorProfile(doctorProfile);
            return doctorProfile.Id;
        }

        public async Task<int> UpdateDoctorProfile(DoctorProfileRequest doctorProfileRequest)
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.INVALID_USER_ID);

            DoctorProfile existingDoctorProfile = await doctorProfileRepository.GetDoctorProfileByIdAndUser(doctorProfileRequest.Id, userId)
                            ?? throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Doctor Profile"));

            doctorProfileRequest.Adapt(existingDoctorProfile);
            await doctorProfileRepository.UpdateDoctorProfile(existingDoctorProfile);

            return existingDoctorProfile.Id;
        }
    }
}
