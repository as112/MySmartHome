using MySmartHome.DAL.Entities;
using System;
using System.Linq.Expressions;

namespace MySmartHome.DAL.Repositories.Interfaces
{
    public interface IEntityRepository<T> : IBaseRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetByName(string name, params Expression<Func<T, object>>[]? includeProperties);
    }
}
