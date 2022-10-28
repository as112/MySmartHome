using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Models;

namespace MySmartHomeWebApi.Data
{
    public class DbUserRepository<T> : DbBaseRepository<T>, IUserRepository<T> where T : Persons, new()
    {
        public DbUserRepository(DataContext db, IConfiguration configuration) : base(db, configuration) { }

        public async Task<T?> GetByEmail(string email, CancellationToken Cancel = default)
        {
            var user = await GetWithInclude(s => s.Email == email, null).ConfigureAwait(false);
            return user.Count() == 0 ? null : user.First();
        }
    }
}
