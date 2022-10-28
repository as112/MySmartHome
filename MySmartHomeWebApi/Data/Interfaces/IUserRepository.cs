using MySmartHomeWebApi.Models;

namespace MySmartHomeWebApi.Data.Interfaces
{
    public interface IUserRepository<T> : IBaseRepository<T> where T : Persons
    {
        Task<T?> GetByEmail(string name, CancellationToken Cancel = default);
    }
}
