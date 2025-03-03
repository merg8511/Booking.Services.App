using Booking.Services.App.Data.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly dbContext _context;

        public IServiceRepository Service { get; private set; }

        public UnitOfWork(dbContext context)
        {
            _context = context;
            Service = new ServiceRepository(_context);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
