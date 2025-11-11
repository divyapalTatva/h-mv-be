using Mapster;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.CustomExceptions;
using MedVault.BE.Common.Helpers;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.Patient;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace MedVault.BE.Services.Services
{
    public class ReminderService(IHttpContextAccessor contextAccessor, IReminderRepository reminderRepository,
        IPatientProfileRepositories patientProfileRepositories) : IReminderService
    {
        public async Task<int> AddReminder(ReminderRequest request)
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.INVALID_USER_ID);

            // Check if patient profile exists for this user
            PatientProfile patientProfile = await patientProfileRepositories.GetPatientProfileByUser(userId) ??
                throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Patient Profile"));

            Reminder reminder = request.Adapt<Reminder>();
            reminder.PatientId = patientProfile.Id;
            await reminderRepository.AddReminder(reminder);
            return reminder.Id;
        }

        public async Task<int> UpdateReminder(ReminderRequest request)
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.INVALID_USER_ID);

            // Check if patient profile exists for this user
            PatientProfile patientProfile = await patientProfileRepositories.GetPatientProfileByUser(userId) ??
                throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Patient Profile"));

            Reminder existingReminder = await reminderRepository.GetReminderByIdAndUser(request.Id, userId)
                ?? throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Reminder"));

            request.Adapt(existingReminder);
            await reminderRepository.UpdateReminder(existingReminder);
            return existingReminder.Id;
        }

        public async Task DeleteReminder(int id)
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.INVALID_USER_ID);

            // Check if patient profile exists for this user
            PatientProfile patientProfile = await patientProfileRepositories.GetPatientProfileByUser(userId) ??
                throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Patient Profile"));

            Reminder existingReminder = await reminderRepository.GetReminderByIdAndUser(id, userId)
                ?? throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Reminder"));

            await reminderRepository.DeleteReminder(existingReminder);
        }

        public async Task<List<ReminderResponse>> GetAllReminder()
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.INVALID_USER_ID);

            // Check if patient profile exists for this user
            PatientProfile patientProfile = await patientProfileRepositories.GetPatientProfileByUser(userId) ??
                throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Patient Profile"));

            var reminders = await reminderRepository.GetAllReminderByPatientId(patientProfile.Id);
            return reminders.Adapt<List<ReminderResponse>>();
        }

        public async Task<ReminderResponse> GetReminderById(int id)
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.INVALID_USER_ID);

            // Check if patient profile exists for this user
            PatientProfile patientProfile = await patientProfileRepositories.GetPatientProfileByUser(userId) ??
                throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Patient Profile"));

            Reminder existingReminder = await reminderRepository.GetReminderByIdAndUser(id, userId)
                ?? throw new EntityNullException(string.Format(ExceptionMessage.DATA_NOT_EXISTS, "Reminder"));
            return existingReminder.Adapt<ReminderResponse>();
        }
    }
}
