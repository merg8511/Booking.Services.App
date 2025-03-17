using Booking.Services.App.Models.DTO;

namespace Booking.Services.App.BusinessLogic.Interfaces
{
    public interface IBookingManager
    {
        //SERVICES
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetFirstAsync(string id);
        Task<ServiceDto> AddAsync(ServiceDto serviceDto);
        Task UpdateServiceAsync(ServiceDto serviceDto);
        Task Remove(string id);

        //EXPERIENCES
        Task<IEnumerable<ExperienceDto>> GetAllExperiencesAsync();
    }
}
