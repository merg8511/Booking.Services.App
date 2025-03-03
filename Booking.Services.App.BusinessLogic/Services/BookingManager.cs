using Booking.Services.App.BusinessLogic.Interfaces;
using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Models.DTO;
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
    }
}
