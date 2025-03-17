using Booking.Services.App.BusinessLogic.Interfaces;
using Booking.Services.App.BusinessLogic.Services;
using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Data.Repositories;
using Booking.Services.App.Filters;
using Booking.Services.App.Models.DTO;
using Booking.Services.App.Modules.Interfaces;
using MiniValidation;
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
            #region SERVICES
            endpoints.MapGet("/api/services", async (IBookingManager _bookingManager) =>
            {
                try
                {
                    var response = await _bookingManager.GetAllServicesAsync();

                    // RESTful: lista vacía sigue siendo un 200 OK
                    return Results.Ok(new ApiResponse
                    {
                        Resultado = response,
                        IsExitoso = true
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

            endpoints.MapGet("/api/service/{id}", async (IBookingManager _bookingManager, string id) =>
            {
                try
                {
                    var response = await _bookingManager.GetFirstAsync(id);

                    if (response == null)
                        return Results.NotFound();

                    return Results.Ok(new ApiResponse
                    {
                        Resultado = response,
                        IsExitoso = true
                    });
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
               //.RequireAuthorization("AdminAgendaRol")              
               .WithName("GetService")
               .WithOpenApi();

            endpoints.MapPost("/api/service", async (IBookingManager _bookingManager, ServiceDto serviceDto) =>
            {
                try
                {
                    var response = await _bookingManager.AddAsync(serviceDto);

                    if (response == null)
                        return Results.Problem("No se pudo crear el recurso", statusCode: (int)HttpStatusCode.InternalServerError);

                    // RESTful: 201 Created + Location header
                    return Results.Created($"/api/service/{response.Id}", new ApiResponse
                    {
                        Resultado = response,
                        IsExitoso = true,
                        Mensaje = "Servicio creado exitosamente"
                    });
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .AddEndpointFilter<ValidationFilter<ServiceDto>>()
                .WithName("AddService")
                .WithOpenApi();

            endpoints.MapPut("/api/service", async (IBookingManager _bookingManager, ServiceDto serviceDto) =>
            {
                try
                {
                    await _bookingManager.UpdateServiceAsync(serviceDto);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .WithName("UpdateService")
                .WithOpenApi();

            endpoints.MapDelete("/api/service/{id}", async (IBookingManager _bookingManager, string id) =>
            {
                try
                {
                    await _bookingManager.Remove(id);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .WithName("DeleteService")
                .WithOpenApi();

            #endregion

            #region EXPERIENCES
            endpoints.MapGet("/api/experiences", async (IBookingManager _bookingManager) =>
            {
                try
                {
                    var response = await _bookingManager.GetAllExperiencesAsync();

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
                .WithName("GetExperiences")
                .WithOpenApi();

            #endregion

            return endpoints;
        }
    }
}
