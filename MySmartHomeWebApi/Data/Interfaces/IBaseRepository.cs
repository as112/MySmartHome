using MySmartHomeWebApi.Entities;

namespace MySmartHomeWebApi.Data.Interfaces
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
    }
}
