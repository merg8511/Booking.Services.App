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

        public Task SoftDelete(Service service)
        {
            service.Deleted = 1;
            return Task.CompletedTask;
        }

        public async Task Update(Service service)
        {
            var serviceToUpdate = await _context.Services.FirstOrDefaultAsync(s => s.Id == service.Id);

            if (serviceToUpdate is not null)
            {
                serviceToUpdate.Title = service.Title;
                serviceToUpdate.Subtitle = service.Subtitle;
                serviceToUpdate.Description = service.Description;
                serviceToUpdate.ImageUrl = service.ImageUrl;
                serviceToUpdate.IsActive = service.IsActive;
                serviceToUpdate.IsOptional = service.IsOptional;
                serviceToUpdate.IsFeatured = service.IsFeatured;
                serviceToUpdate.PricePerDay = service.PricePerDay;
                serviceToUpdate.CategoryId = service.CategoryId;
            }

            await _context.SaveChangesAsync();
        }
    }
}
