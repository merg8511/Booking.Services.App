using Booking.Services.App.Models.DTO;

namespace Booking.Services.App.BusinessLogic.Interfaces
{
    public interface IBookingManager
    {
        #region SERVICES CATEGORIES 

        //SERVICES CATEGORIES
        Task<IEnumerable<ServiceCategoryResponse>> GetAllServiceCategoriesAsync();
        Task<ServiceCategoryResponse> GetServiceCategoryByIdAsync(string id);
        Task<ServiceCategoryResponse> AddServiceCategoryAsync(ServiceCategoryRequest serviceCategoryRequest);
        Task UpdateServiceCategoryAsync(ServiceCategoryRequest serviceCategoryRequest);
        Task RemoveServiceCategory(string id);

        #endregion

        #region SERVICES

        //SERVICES
        Task<IEnumerable<ServiceResponse>> GetAllServicesAsync();
        Task<ServiceResponse> GetServiceByIdAsync(string id);
        Task<ServiceResponse> AddServiceAsync(ServiceRequest serviceRequest);
        Task UpdateServiceAsync(ServiceRequest serviceRequest);
        Task RemoveService(string id);

        #endregion
    }
}
