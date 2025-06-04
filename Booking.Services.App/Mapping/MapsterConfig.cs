using Booking.Services.App.Models.DTO;
using Booking.Services.App.Models.Models;
using Mapster;

namespace Booking.Services.App.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<ServiceCategoryDto, ServiceCategory>
                .NewConfig()
                .Ignore(dest => dest.CreatedAt);

            TypeAdapterConfig<ServiceDto, Service>
                .NewConfig()
                .Ignore(dest => dest.CreatedAt);

            // Agrega aqu� m�s configuraciones si lo necesitas
        }
    }
}