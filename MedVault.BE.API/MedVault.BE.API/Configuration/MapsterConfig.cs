using Mapster;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Entities.Master;

namespace MedVault.BE.API.Configuration
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Hospital, DropdownResponse>.NewConfig()
                .Map(dest => dest.Value, src => src.Id)
                .Map(dest => dest.Label, src => src.HospitalName);
        }
    }
}
