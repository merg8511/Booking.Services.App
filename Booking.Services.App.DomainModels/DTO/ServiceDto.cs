using System.ComponentModel.DataAnnotations;

namespace Booking.Services.App.Models.DTO
{
    public class ServiceDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "El nombre debe ser mínimo {2} máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "El nombre debe ser mínimo {2} máximo {1} caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool? IsIncluded { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool? IsActive { get; set; }
    }
}
