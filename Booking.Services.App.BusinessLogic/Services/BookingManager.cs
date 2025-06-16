using Booking.Services.App.BusinessLogic.Interfaces;
using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Models.DTO;
using Booking.Services.App.Models.Models;
using Mapster;

namespace Booking.Services.App.BusinessLogic.Services
{
    public class BookingManager : IBookingManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region SERVICES CATEGORIES
        public async Task<IEnumerable<ServiceCategoryResponse>> GetAllServiceCategoriesAsync()
        {
            try
            {
                var serviceCategories = await _unitOfWork.ServiceCategory.GetAllAsync(
                    orderBy: x => x.OrderBy(x => x.Name));

                var serviceCategoriesDto = serviceCategories.Adapt<IEnumerable<ServiceCategoryResponse>>();

                return serviceCategoriesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceCategoryResponse> GetServiceCategoryByIdAsync(string id)
        {
            try
            {
                var serviceCategory = await _unitOfWork.ServiceCategory.FindAsync(x => x.Id == id);
                var serviceCategoryDto = serviceCategory.Adapt<ServiceCategoryResponse>();
                return serviceCategoryDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceCategoryResponse> AddServiceCategoryAsync(ServiceCategoryRequest serviceCategoryRequest)
        {
            try
            {
                var serviceCategory = serviceCategoryRequest.Adapt<ServiceCategory>();

                serviceCategory.Id = NUlid.Ulid.NewUlid().ToString();
                serviceCategory.IsActive = 1;
                serviceCategory.CreatedAt = DateTime.Now;

                await _unitOfWork.ServiceCategory.Add(serviceCategory);
                await _unitOfWork.SaveAsync();

                return serviceCategory.Adapt<ServiceCategoryResponse>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateServiceCategoryAsync(ServiceCategoryRequest serviceCategoryRequest)
        {
            try
            {
                var serviceCategory = await _unitOfWork.ServiceCategory.FindAsync(x => x.Id == serviceCategoryRequest.Id);

                if (serviceCategory is null) throw new TaskCanceledException("Category not found.");

                serviceCategoryRequest.Adapt(serviceCategory);

                await _unitOfWork.ServiceCategory.Update(serviceCategory);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoveServiceCategory(string id)
        {
            try
            {
                var serviceCategory = await _unitOfWork.ServiceCategory.FindAsync(x => x.Id == id);

                if (serviceCategory is null) throw new TaskCanceledException("Category not found");

                await _unitOfWork.ServiceCategory.SoftDelete(serviceCategory);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region SERVICES
        public async Task<IEnumerable<ServiceResponse>> GetAllServicesAsync()
        {
            try
            {
                var services = await _unitOfWork.Service.GetAllAsync(
                    orderBy: x => x.OrderBy(x => x.Title));
                var servicesDto = services.Adapt<IEnumerable<ServiceResponse>>();

                return servicesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ServiceResponse> GetServiceByIdAsync(string id)
        {
            try
            {
                var service = await _unitOfWork.Service.FindAsync(x => x.Id == id);
                var serviceDto = service.Adapt<ServiceResponse>();
                return serviceDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceResponse> AddServiceAsync(ServiceRequest serviceRequest)
        {
            try
            {
                var service = serviceRequest.Adapt<Service>();

                service.Id = NUlid.Ulid.NewUlid().ToString();
                service.IsActive = 1;
                service.CreatedAt = DateTime.Now;

                await _unitOfWork.Service.Add(service);
                await _unitOfWork.SaveAsync();

                return service.Adapt<ServiceResponse>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateServiceAsync(ServiceRequest serviceRequest)
        {
            try
            {
                var service = await _unitOfWork.Service.FindAsync(x => x.Id == serviceRequest.Id);

                if (service == null) throw new TaskCanceledException("Service not found");

                serviceRequest.Adapt(service);

                await _unitOfWork.Service.Update(service);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoveService(string id)
        {
            try
            {
                var service = await _unitOfWork.Service.FindAsync(x => x.Id == id);

                if (service is null) throw new TaskCanceledException("Seervice not found");

                await _unitOfWork.Service.SoftDelete(service);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
