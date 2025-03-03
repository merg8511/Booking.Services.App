using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Data.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly dbContext _context;

        public ServiceRepository(dbContext context) : base(context)
        {
            _context = context;
        }

        public Task Update(Service service)
        {
            throw new NotImplementedException();
        }
    }
}
