﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Booking.Services.App.Models.Models;

public partial class Service
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal? Price { get; set; }

    public sbyte? IsIncluded { get; set; }

    public sbyte? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public string CreatedBy { get; set; }

    public virtual ICollection<ReservationService> ReservationServices { get; set; } = new List<ReservationService>();
}