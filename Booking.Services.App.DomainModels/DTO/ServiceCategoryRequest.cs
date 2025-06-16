using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Models.DTO
{
    public class ServiceCategoryRequest
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Order { get; set; }
        public sbyte IsActive { get; set; }
        public sbyte Deleted { get; set; }
    }
}
