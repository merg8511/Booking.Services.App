using Booking.Services.App.Models.Entities;

namespace Booking.Services.App.Data.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserApp user);
    }
}
