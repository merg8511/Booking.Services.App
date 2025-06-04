using Microsoft.AspNetCore.Identity;

namespace Booking.Services.App.Models.Entities
{
    public class UserApp : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<RoleUserApp> RoleUsers { get; set; }
    }
}
