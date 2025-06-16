using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Booking.Services.App.Models.DTO
{
    public class ServiceCategoryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
        public sbyte IsActive { get; set; }
        public sbyte Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
