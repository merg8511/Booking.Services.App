using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Models.Models;

namespace Booking.Services.App.Data.Repositories
{
    public class ExperienceRepository : Repository<Experience>, IExperienceRepository
    {
        private readonly dbContext _context;
        public ExperienceRepository(dbContext context) : base(context)
        {
            _context = context;
        }
    }
}
