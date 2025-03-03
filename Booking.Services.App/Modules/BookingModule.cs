using Booking.Services.App.BusinessLogic.Interfaces;
using Booking.Services.App.BusinessLogic.Services;
using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Data.Repositories;
using Booking.Services.App.Models.DTO;
using Booking.Services.App.Models.Models;
using Booking.Services.App.Modules.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Booking.Services.App.Modules
{
    public class BookingModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection builder)
        {
            builder.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.AddScoped<IBookingManager, BookingManager>();

            return builder;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/services", async (IBookingManager _bookingManager) =>
            {
                try
                {
                    var response = await _bookingManager.GetAllServicesAsync();

                    if (response == null || !response.Any())
                        return Results.NoContent();

                    return Results.Ok(new ApiResponse
                    {
                        Resultado = response,
                        IsExitoso = true,
                        StatusCode = HttpStatusCode.OK
                    });
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .WithName("GetServices")
                .WithOpenApi();

            return endpoints;
        }
    }
}
