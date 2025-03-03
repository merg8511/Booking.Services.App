using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Models.Entities
{
    public class RoleUserApp : IdentityUserRole<string>
    {
        public UserApp UserApp { get; set; }
        public RoleApp RolApp { get; set; }
    }
}
