using MedVault.BE.Common.Models.Request;

namespace MedVault.BE.Services.IServices
{
    public interface IPatientProfileService
    {
        Task<int> AddPatientProfile(PatientProfileRequest patientProfileRequest);

        Task<int> UpdatePatientProfile(PatientProfileRequest patientProfileRequest);
    }
}
