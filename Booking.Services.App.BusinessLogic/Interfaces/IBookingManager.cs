using Booking.Services.App.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.BusinessLogic.Interfaces
{
    public interface IBookingManager
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
    }
}
