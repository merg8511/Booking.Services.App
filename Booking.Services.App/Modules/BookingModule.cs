using Booking.Services.App.BusinessLogic.Interfaces;
using Booking.Services.App.BusinessLogic.Services;
using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Data.Repositories;
using Booking.Services.App.Filters;
using Booking.Services.App.Models.DTO;
using Booking.Services.App.Modules.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            #region SERVICES CATEGORY

            endpoints.MapGet("/api/serviceCategories", async (IBookingManager _bookingManager) =>
            {
                try
                {
                    var response = await _bookingManager.GetAllServiceCategoriesAsync();

                    // RESTful: lista vacía sigue siendo un 200 OK
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .WithName("GetServiceCategories")
                .WithOpenApi();

            endpoints.MapGet("/api/serviceCategories/{id}", async (IBookingManager _bookingManager, string id) =>
            {
                try
                {
                    var response = await _bookingManager.GetServiceCategoryByIdAsync(id);

                    if (response == null)
                        return Results.NotFound();

                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
               //.RequireAuthorization("AdminAgendaRol")              
               .WithName("GetServiceCategory")
               .WithOpenApi();

            endpoints.MapPost("/api/serviceCategories", async (IBookingManager _bookingManager, ServiceCategoryRequest serviceCategoryRequest) =>
            {
                try
                {
                    var response = await _bookingManager.AddServiceCategoryAsync(serviceCategoryRequest);

                    if (response == null)
                        return Results.Problem("No se pudo crear el recurso", statusCode: (int)HttpStatusCode.InternalServerError);

                    // RESTful: 201 Created + Location header
                    return Results.Created($"/api/serviceCategories/{response.Id}", response);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .AddEndpointFilter<ValidationFilter<ServiceCategoryRequest>>()
                .WithName("AddServiceCategory")
                .WithOpenApi();

            endpoints.MapPut("/api/serviceCategories", async (IBookingManager _bookingManager, ServiceCategoryRequest serviceCategoryRequest) =>
            {
                try
                {
                    await _bookingManager.UpdateServiceCategoryAsync(serviceCategoryRequest);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .AddEndpointFilter<ValidationFilter<ServiceCategoryRequest>>()
                .WithName("UpdateServiceCategory")
                .WithOpenApi();

            endpoints.MapDelete("/api/serviceCategories/{id}", async (IBookingManager _bookingManager, string id) =>
            {
                try
                {
                    await _bookingManager.RemoveServiceCategory(id);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .WithName("DeleteServiceCategory")
                .WithOpenApi();

            #endregion

            #region SERVICES
            endpoints.MapGet("/api/services", async (IBookingManager _bookingManager) =>
            {
                try
                {
                    var response = await _bookingManager.GetAllServicesAsync();

                    // RESTful: lista vacía sigue siendo un 200 OK
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .WithName("GetServices")
                .WithOpenApi();

            endpoints.MapGet("/api/services/{id}", async (IBookingManager _bookingManager, string id) =>
            {
                try
                {
                    var response = await _bookingManager.GetServiceByIdAsync(id);

                    if (response == null)
                        return Results.NotFound();

                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
               //.RequireAuthorization("AdminAgendaRol")              
               .WithName("GetService")
               .WithOpenApi();

            endpoints.MapPost("/api/services", async (IBookingManager _bookingManager, ServiceRequest serviceRequest) =>
            {
                try
                {
                    var response = await _bookingManager.AddServiceAsync(serviceRequest);

                    if (response == null)
                        return Results.Problem("No se pudo crear el recurso", statusCode: (int)HttpStatusCode.InternalServerError);

                    // RESTful: 201 Created + Location header
                    return Results.Created($"/api/services/{response.Id}", response);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .AddEndpointFilter<ValidationFilter<ServiceRequest>>()
                .WithName("AddService")
                .WithOpenApi();

            endpoints.MapPut("/api/services", async (IBookingManager _bookingManager, ServiceRequest serviceRequest) =>
            {
                try
                {
                    await _bookingManager.UpdateServiceAsync(serviceRequest);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
                }
            })
                //.RequireAuthorization("AdminAgendaRol")
                .AddEndpointFilter<ValidationFilter<ServiceRequest>>()
                .WithName("UpdateService")
                .WithOpenApi();

            endpoints.MapDelete("/api/services/{id}", async (IBookingManager _bookingManager, string id) =>
            {
                try
                {
                    await _bookingManager.RemoveService(id);
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

            return endpoints;
        }
    }
}
