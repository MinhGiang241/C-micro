using System.Linq.Expressions;

namespace Play.Common
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task RemoveAync(Guid id);
        Task updateAsync(T entity);
    }

}

