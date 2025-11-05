using Mapster;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.CustomExceptions;
using MedVault.BE.Common.Helpers;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace MedVault.BE.Services.Services
{
    public class PatientProfileService(IHttpContextAccessor contextAccessor, IPatientProfileRepositories patientProfileRepositories) : IPatientProfileService
    {
        public async Task<int> AddPatientProfile(PatientProfileRequest patientProfileRequest)
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ?? 
                throw new BadRequestException(ExceptionMessage.ID_IS_NULL_OR_ZERO);

            // Check if patient profile already exists for this user
            bool exists = await patientProfileRepositories.PatientProfileExists(userId);
            if (exists)
                throw new DataAlreadyExistsException(string.Format(ExceptionMessage.DATA_ALREADY_EXIST, "Patient Profile"));

            PatientProfile patientProfile = patientProfileRequest.Adapt<PatientProfile>();
            patientProfile.UserId = userId;
            await patientProfileRepositories.AddPatientProfile(patientProfile);
            return patientProfile.Id;
        }

        public async Task<int> UpdatePatientProfile(PatientProfileRequest patientProfileRequest)
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.ID_IS_NULL_OR_ZERO);

            PatientProfile existingPatientProfile = await patientProfileRepositories.GetPatientProfileByIdAndUser(patientProfileRequest.Id, userId)
                            ?? throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Patient Profile"));

            patientProfileRequest.Adapt(existingPatientProfile);
            await patientProfileRepositories.UpdatePatientProfile(existingPatientProfile);

            return existingPatientProfile.Id;
        }
    }
}