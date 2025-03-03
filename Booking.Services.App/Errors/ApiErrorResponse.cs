namespace Booking.Services.App.Errors
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Se ha realizado una solicitud inválida",
                401 => "No estás autorizado para este recurso",
                404 => "Recurso no encontrado",
                500 => "Error interno del servidor",
                _ => null
            };
        }
    }
}
