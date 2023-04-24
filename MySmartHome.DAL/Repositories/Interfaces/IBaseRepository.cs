using MySmartHome.DAL.Entities;
using System.Linq.Expressions;

namespace MySmartHome.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<bool> ExistId(Guid Id, CancellationToken Cancel = default);
        Task<bool> Exist(T item, CancellationToken Cancel = default);
        Task<IEnumerable<T>> GetAll(CancellationToken Cancel = default);
        Task<T?> GetById(Guid Id, CancellationToken Cancel = default);
        Task<T> Add(T item, CancellationToken Cancel = default);
        Task<T?> Update(T item, CancellationToken Cancel = default);
        Task<T?> Delete(T item, CancellationToken Cancel = default);
        Task<T?> DeleteById(Guid Id, CancellationToken Cancel = default);
        Task<IEnumerable<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includeProperties);
    }
}
