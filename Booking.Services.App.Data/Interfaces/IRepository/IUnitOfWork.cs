namespace Booking.Services.App.Data.Interfaces.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IServiceRepository Service { get; }
        IExperienceRepository Experience { get; }
        Task SaveAsync();
    }
}
