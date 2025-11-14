using Mapster;
using MedVault.BE.Common.Models.Request;
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

            TypeAdapterConfig<PatientHistory, PatientHistoryListResponse>.NewConfig()
                .Map(dest => dest.DoctorName, src => src.DoctorProfile.User.FirstName + " " + src.DoctorProfile.User.LastName)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.PatientHistoryDocuments, src => src.MedicalDocumentes.Adapt<List<PatientHistoryDocuments>>());

            TypeAdapterConfig<MedicalDocument, PatientHistoryDocuments>.NewConfig()
                .Map(dest => dest.DocumentCategoryName, src => src.DocumentCategory.DocumentCategoryName)
                .Map(dest => dest.DateOfDocument, src => src.DateOfDocument)
                .Map(dest => dest.FilePath, src => src.FilePath);

            TypeAdapterConfig<DoctorProfile, DropdownResponse>.NewConfig()
                .Map(dest => dest.Value, src => src.Id)
                .Map(dest => dest.Label, src => src.User.FirstName + " " + src.User.LastName);

            TypeAdapterConfig<DocumentCategory, DropdownResponse>.NewConfig()
                .Map(dest => dest.Value, src => src.Id)
                .Map(dest => dest.Label, src => src.DocumentCategoryName);

            TypeAdapterConfig<PatientHistory, PatientHistoryResponse>.NewConfig()
                .Map(dest => dest.PatientHistoryDocuments, src => src.MedicalDocumentes.OrderBy(o => o.Id).Adapt<List<PatientHistoryDocumentsResponse>>());

            TypeAdapterConfig<PatientHistoryRequest, PatientHistory>.NewConfig()
                .Ignore(dest => dest.MedicalDocumentes);
        }
    }
}
