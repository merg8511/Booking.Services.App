namespace Booking.Services.App.Errors
{
    public class ApiException : ApiErrorResponse
    {
        public ApiException(int statusCode, string message = null, string detail = null) : base(statusCode, message)
        {
            Detail = detail;
        }

        public string Detail { get; set; }
    }
}
