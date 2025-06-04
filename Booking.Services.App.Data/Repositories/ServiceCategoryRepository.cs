using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services.App.Data.Repositories
{
    public class ServiceCategoryRepository : Repository<ServiceCategory>, IServiceCategoryRepository
    {
        private readonly dbContext _context;

        public ServiceCategoryRepository(dbContext context) : base(context)
        {
            _context = context;
        }

        public Task SoftDelete(ServiceCategory serviceCategory)
        {
            serviceCategory.Deleted = 1;
            return Task.CompletedTask;
        }

        public async Task Update(ServiceCategory serviceCategory)
        {
            var serviceCategoryToUpdate = await _context.ServiceCategories.FirstOrDefaultAsync(sc => sc.Id == serviceCategory.Id);

            if (serviceCategory is not null)
            {
                serviceCategoryToUpdate.Name = serviceCategory.Name;
                serviceCategoryToUpdate.Icon = serviceCategory.Icon;
                serviceCategoryToUpdate.Order = serviceCategory.Order;
                serviceCategoryToUpdate.IsActive = serviceCategory.IsActive;
            }

            await _context.SaveChangesAsync();
        }
    }
}
