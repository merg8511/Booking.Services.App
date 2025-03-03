using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Models.Entities
{
    public class UserApp : IdentityUser
    {
        public string Name { get; set; }
        public string LasName { get; set; }
        public ICollection<RoleUserApp> RolUsuarios { get; set; }
    }
}
