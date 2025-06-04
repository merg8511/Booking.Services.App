using Booking.Services.App.Models.Models;

namespace Booking.Services.App.Data.Interfaces.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task Update(Service service);
        Task SoftDelete(Service service);
    }
}
