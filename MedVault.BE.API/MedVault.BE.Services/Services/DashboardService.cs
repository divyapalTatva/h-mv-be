using Mapster;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.CustomExceptions;
using MedVault.BE.Common.Helpers;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.Master;
using MedVault.BE.Data.Entities.Patient;
using MedVault.BE.Data.Entities.User;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Services.IServices;
using Microsoft.AspNetCore.Http;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.Services.Services
{
    public class DashboardService(IHttpContextAccessor contextAccessor, IPatientHistoryRepository patientHistoryRepository,
        IDoctorProfileRepositories doctorProfileRepositories, IReminderRepository reminderRepository) : IDashboardService
    {
        public async Task<DashboardSummaryResponse> GetDashboardSummary()
        {
            int userId = contextAccessor.HttpContext?.User.GetUserId() ??
                throw new BadRequestException(ExceptionMessage.ID_IS_NULL_OR_ZERO);

            UserRole role = contextAccessor.HttpContext?.User.GetUserRole() ??
                throw new BadRequestException(ExceptionMessage.USER_ROLE_NOT_AVAILABLE);

            DashboardSummaryResponse dashboardSummaryResponse = new DashboardSummaryResponse();

            if (role == UserRole.User)
            {
                PatientHistory? patientHistory = await patientHistoryRepository.GetLastPatientHistoryByUserId(userId);
                List<Reminder>? reminders = await reminderRepository.GetUpcomingReminderByUserId(userId);

                dashboardSummaryResponse.LastRecord = patientHistory.Adapt<LastPatientRecord>();
                dashboardSummaryResponse.TotalRecords = await patientHistoryRepository.GetPatientHistoryCountByUserId(userId);
                dashboardSummaryResponse.UpcomingReminders = reminders.Adapt<List<UpcomingReminders>>();
            }

            if (role == UserRole.Doctor)
            {
                DoctorProfile? doctorHospital = await doctorProfileRepositories.GetDoctorHospitalByUserId(userId);

                dashboardSummaryResponse.Hospital = doctorHospital.Adapt<DoctorHospital>();
                dashboardSummaryResponse.TotalCheckups = await patientHistoryRepository.GetTotoalCheckupByUserId(userId);                
            }

            return dashboardSummaryResponse;
        }
    }
}
