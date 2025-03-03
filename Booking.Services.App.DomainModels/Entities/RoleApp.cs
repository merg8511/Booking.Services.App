using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Models.Entities
{
    public class RoleApp : IdentityRole
    {
        public ICollection<RoleUserApp> RoleUsuarios { get; set; }
    }
}
