using Booking.Services.App.Models.DTO;

namespace Booking.Services.App.BusinessLogic.Interfaces
{
    public interface IBookingManager
    {
        #region SERVICES CATEGORIES 

        //SERVICES CATEGORIES
        Task<IEnumerable<ServiceCategoryDto>> GetAllServiceCategoriesAsync();
        Task<ServiceCategoryDto> GetFirstServiceCategoryAsync(string id);
        Task<ServiceCategoryDto> AddServiceCategoryAsync(ServiceCategoryDto serviceCategoryDto);
        Task UpdateServiceCategoryAsync(ServiceCategoryDto serviceCategoryDto);
        Task RemoveServiceCategory(string id);

        #endregion

        #region SERVICES

        //SERVICES
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetFirstServiceAsync(string id);
        Task<ServiceDto> AddServiceAsync(ServiceDto serviceDto);
        Task UpdateServiceAsync(ServiceDto serviceDto);
        Task RemoveService(string id);

        #endregion
    }
}
