using System.ComponentModel.DataAnnotations;

namespace Booking.Services.App.Models.DTO
{
    public class ServiceResponse
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public sbyte IsActive { get; set; }
        public sbyte IsOptional { get; set; }
        public sbyte IsFeatured { get; set; }
        public decimal? PricePerDay { get; set; }
        public sbyte Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
