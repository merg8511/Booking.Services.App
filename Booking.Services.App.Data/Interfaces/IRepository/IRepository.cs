using System.Linq.Expressions;

namespace Booking.Services.App.Data.Interfaces.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);

        Task<T> FindAsync(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null);

        Task Add(T entity);

        void Remove(T entity);
    }
}
