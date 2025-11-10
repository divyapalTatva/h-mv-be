using Mapster;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.Master;
using MedVault.BE.Data.Entities.Patient;
using MedVault.BE.Data.Entities.User;

namespace MedVault.BE.API.Configuration
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Hospital, DropdownResponse>.NewConfig()
                .Map(dest => dest.Value, src => src.Id)
                .Map(dest => dest.Label, src => src.HospitalName);

            TypeAdapterConfig<PatientHistory, LastPatientRecord>.NewConfig()
                .Map(dest => dest.Date, src => src.CreatedAt)
                .Map(dest => dest.DocumentCount, src => src.MedicalDocumentes.Count());

            TypeAdapterConfig<DoctorProfile, DoctorHospital>.NewConfig()
                .Map(dest => dest.Name, src => src.Hospital.HospitalName)
                .Map(dest => dest.Address, src => src.Hospital.Address)
                .Map(dest => dest.ContactNumber, src => src.Hospital.ContactNumber);

            
        }
    }
}
