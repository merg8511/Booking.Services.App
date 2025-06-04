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
        public async Task<IEnumerable<ServiceCategoryDto>> GetAllServiceCategoriesAsync()
        {
            try
            {
                var serviceCategories = await _unitOfWork.ServiceCategory.GetAllAsync(
                    orderBy: x => x.OrderBy(x => x.Name));

                var serviceCategoriesDto = serviceCategories.Adapt<IEnumerable<ServiceCategoryDto>>();

                return serviceCategoriesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceCategoryDto> GetFirstServiceCategoryAsync(string id)
        {
            try
            {
                var serviceCategory = await _unitOfWork.ServiceCategory.FindAsync(x => x.Id == id);
                var serviceCategoryDto = serviceCategory.Adapt<ServiceCategoryDto>();
                return serviceCategoryDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceCategoryDto> AddServiceCategoryAsync(ServiceCategoryDto serviceCategoryDto)
        {
            try
            {
                var serviceCategory = serviceCategoryDto.Adapt<ServiceCategory>();

                serviceCategory.Id = NUlid.Ulid.NewUlid().ToString();
                serviceCategory.IsActive = 1;
                serviceCategory.CreatedAt = DateTime.Now;

                await _unitOfWork.ServiceCategory.Add(serviceCategory);
                await _unitOfWork.SaveAsync();

                return serviceCategory.Adapt<ServiceCategoryDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateServiceCategoryAsync(ServiceCategoryDto serviceCategoryDto)
        {
            try
            {
                var serviceCategory = await _unitOfWork.ServiceCategory.FindAsync(x => x.Id == serviceCategoryDto.Id);

                if (serviceCategory is null) throw new TaskCanceledException("Category not found.");

                await _unitOfWork.ServiceCategory.Update(serviceCategoryDto.Adapt(serviceCategory));
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
        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            try
            {
                var services = await _unitOfWork.Service.GetAllAsync(
                    orderBy: x => x.OrderBy(x => x.Title));
                var servicesDto = services.Adapt<IEnumerable<ServiceDto>>();

                return servicesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ServiceDto> GetFirstServiceAsync(string id)
        {
            try
            {
                var service = await _unitOfWork.Service.FindAsync(x => x.Id == id);
                var serviceDto = service.Adapt<ServiceDto>();
                return serviceDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceDto> AddServiceAsync(ServiceDto serviceDto)
        {
            try
            {
                var service = serviceDto.Adapt<Service>();

                service.Id = NUlid.Ulid.NewUlid().ToString();
                service.IsActive = 1;
                service.CreatedAt = DateTime.Now;

                await _unitOfWork.Service.Add(service);
                await _unitOfWork.SaveAsync();

                return service.Adapt<ServiceDto>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateServiceAsync(ServiceDto serviceDto)
        {
            try
            {
                var service = await _unitOfWork.Service.FindAsync(x => x.Id == serviceDto.Id);

                if (service == null) throw new TaskCanceledException("El servicio no existe");

                await _unitOfWork.Service.Update(serviceDto.Adapt(service));
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
