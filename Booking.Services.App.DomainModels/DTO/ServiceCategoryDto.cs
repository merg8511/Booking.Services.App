using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Booking.Services.App.Models.DTO
{
    public class ServiceCategoryDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Order { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public sbyte IsActive { get; set; }
        public sbyte Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
