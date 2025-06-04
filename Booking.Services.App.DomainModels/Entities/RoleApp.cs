using Microsoft.AspNetCore.Identity;

namespace Booking.Services.App.Models.Entities
{
    public class RoleApp : IdentityRole
    {
        public ICollection<RoleUserApp> RoleUsers { get; set; }
    }
}
