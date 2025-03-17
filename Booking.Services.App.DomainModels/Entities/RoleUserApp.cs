using Microsoft.AspNetCore.Identity;

namespace Booking.Services.App.Models.Entities
{
    public class RoleUserApp : IdentityUserRole<string>
    {
        public UserApp UserApp { get; set; }
        public RoleApp RolApp { get; set; }
    }
}
