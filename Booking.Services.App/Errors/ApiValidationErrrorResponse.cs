namespace Booking.Services.App.Errors
{
    public class ApiValidationErrrorResponse : ApiErrorResponse
    {
        public ApiValidationErrrorResponse() : base(400)
        {

        }

        public IEnumerable<string> Errors { get; set; }
    }
}
