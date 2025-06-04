using System.ComponentModel.DataAnnotations;

namespace Booking.Services.App.Models.DTO
{
    public class ServiceDto
    {
        public string Id { get; set; }

        public string CategoryId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "El nombre debe ser mínimo {2} máximo {1} caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "El nombre debe ser mínimo {2} máximo {1} caracteres")]
        public string Subtitle { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public sbyte IsActive { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public sbyte IsOptional { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public sbyte IsFeatured { get; set; }

        public decimal? PricePerDay { get; set; }
        public sbyte Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
