using MySmartHomeWebApi.Entities;
using System;
using System.Linq.Expressions;

namespace MySmartHomeWebApi.Data.Interfaces
{
    public interface IEntityRepository<T> : IBaseRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetByName(string name, params Expression<Func<T, object>>[]? includeProperties);
    }
}
