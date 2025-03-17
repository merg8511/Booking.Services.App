
using MiniValidation;

namespace Booking.Services.App.Filters
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var dto = context.Arguments.OfType<T>().FirstOrDefault();

            if (dto == null)
            {
                return Results.BadRequest(new { Error = "El cuerpo de la solicitud está vacío." });
            }

            if (!MiniValidator.TryValidate(dto, out var errors))
            {
                return Results.BadRequest(errors);
            }

            return await next(context);
        }
    }
}
