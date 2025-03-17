using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services.App.Data.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly dbContext _context;

        public ServiceRepository(dbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Service service)
        {
            var serviceToUpdate = await _context.Services.FirstOrDefaultAsync(s => s.Id == service.Id);

            if (serviceToUpdate != null)
            {
                serviceToUpdate.Name = service.Name;
                serviceToUpdate.Description = service.Description;
                serviceToUpdate.Price = service.Price;
                serviceToUpdate.IsIncluded = service.IsIncluded;
                serviceToUpdate.IsActive = service.IsActive;
            }

            await _context.SaveChangesAsync();
        }
    }
}
