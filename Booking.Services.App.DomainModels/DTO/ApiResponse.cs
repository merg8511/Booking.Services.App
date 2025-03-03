﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.App.Models.DTO
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsExitoso { get; set; }
        public string Mensaje { get; set; }
        public object Resultado { get; set; }
    }
}
