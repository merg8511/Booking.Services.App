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

        #region SERVICES
        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            try
            {
                var services = await _unitOfWork.Service.GetAllAsync(
                    orderBy: x => x.OrderBy(x => x.Name));
                var servicesDto = services.Adapt<IEnumerable<ServiceDto>>();

                return servicesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ServiceDto> GetFirstAsync(string id)
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

        public async Task<ServiceDto> AddAsync(ServiceDto serviceDto)
        {
            try
            {
                var service = serviceDto.Adapt<Service>();

                service.Id = NUlid.Ulid.NewUlid().ToString();
                service.CreationDate = DateTime.Now;
                service.CreatedBy = "admin";

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

        public async Task Remove(string id)
        {
            try
            {
                var service = await _unitOfWork.Service.FindAsync(x => x.Id == id);

                if (service == null) throw new TaskCanceledException("El servicio no existe");

                _unitOfWork.Service.Remove(service);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        #region EXPERIENCES
        //EXPERIENCES
        public async Task<IEnumerable<ExperienceDto>> GetAllExperiencesAsync()
        {
            try
            {
                var experiences = await _unitOfWork.Experience.GetAllAsync(
                    orderBy: x => x.OrderBy(x => x.CreatedAt));

                var experiencesDto = experiences.Adapt<IEnumerable<ExperienceDto>>();

                return experiencesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
