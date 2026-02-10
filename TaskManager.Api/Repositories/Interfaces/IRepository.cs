using System.Linq.Expressions;
using System.Security.Principal;

namespace TaskManager.Api.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task DeleteWhereAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
        Task RollbackTransactionAsync();
        Task<IDisposable> BeginTransactionAsync();
        Task CommitTransactionAsync();
    }
}
