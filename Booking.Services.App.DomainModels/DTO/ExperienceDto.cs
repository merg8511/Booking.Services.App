namespace Booking.Services.App.Models.DTO
{
    public class ExperienceDto
    {
        public string UserId { get; set; }

        public int? Rating { get; set; }

        public string Comment { get; set; }

        public bool? Approved { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
