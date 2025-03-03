using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Data.Interfaces.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IServiceRepository Service { get; }
        Task SaveAsync();
    }
}
