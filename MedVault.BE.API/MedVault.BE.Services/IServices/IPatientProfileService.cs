using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;

namespace MedVault.BE.Services.IServices
{
    public interface IPatientProfileService
    {
        Task<int> AddPatientProfile(PatientProfileRequest patientProfileRequest);

        Task<int> UpdatePatientProfile(PatientProfileRequest patientProfileRequest);

        Task<EmergencyResponse> GetEmergencyDetails();
    }
}
