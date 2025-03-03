using Booking.Services.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Data.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserApp user);
    }
}
