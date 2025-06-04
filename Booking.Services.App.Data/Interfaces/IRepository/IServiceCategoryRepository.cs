using Booking.Services.App.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Data.Interfaces.IRepository
{
    public interface IServiceCategoryRepository : IRepository<ServiceCategory>
    {
        Task Update(ServiceCategory serviceCategory);
        Task SoftDelete(ServiceCategory serviceCategory);
    }
}
