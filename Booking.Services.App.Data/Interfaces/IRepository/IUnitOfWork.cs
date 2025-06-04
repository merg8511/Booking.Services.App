namespace Booking.Services.App.Data.Interfaces.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IServiceRepository Service { get; }
        IServiceCategoryRepository ServiceCategory { get; }
        Task SaveAsync();
    }
}
