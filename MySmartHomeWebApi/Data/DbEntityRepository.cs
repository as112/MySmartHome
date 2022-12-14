using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Entities;
using System.Linq.Expressions;

namespace MySmartHomeWebApi.Data
{
    public class DbEntityRepository<T> : DbBaseRepository<T>, IEntityRepository<T> where T : Entity, new()
    {
        public DbEntityRepository(DataContext db, IConfiguration configuration) : base(db, configuration) { }

        public async Task<IEnumerable<T>> GetByName(string name, params Expression<Func<T, object>>[]? includeProperties)
        {
            return await GetWithInclude(s => s.Name == name, includeProperties).ConfigureAwait(false);
        }

    }
}
