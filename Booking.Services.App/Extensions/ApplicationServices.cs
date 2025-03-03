using Booking.Services.App.BusinessLogic.Interfaces;
using Booking.Services.App.BusinessLogic.Services;
using Booking.Services.App.Data;
using Booking.Services.App.Data.Interfaces;
using Booking.Services.App.Data.Interfaces.IRepository;
using Booking.Services.App.Data.Repositories;
//using Booking.Services.App.Data.Services;
using Booking.Services.App.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services.App.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<dbContext>(options =>
                options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString),
                options => options.EnableRetryOnFailure())
                );

            services.AddCors();
            //services.AddScoped<ITokenService, TokenService>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                  .Where(e => e.Value.Errors.Count() > 0)
                                  .SelectMany(x => x.Value.Errors)
                                  .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
          
            return services;
        }
    }
}
