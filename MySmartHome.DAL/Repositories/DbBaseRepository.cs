using Microsoft.EntityFrameworkCore;
using MySmartHome.DAL.Entities;
using System.Linq.Expressions;
using MySmartHome.DAL.Repositories.Interfaces;
using MySmartHome.DAL.Data;
using Microsoft.Extensions.Configuration;

namespace MySmartHome.DAL.Repositories
{
    public class DbBaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly DataContext _db;
        private readonly string _connectionString;

        private DbSet<T> Set { get; }
        protected IQueryable<T> QueryableSet => Set.AsQueryable();
        public DbBaseRepository(DataContext db, IConfiguration configuration)
        {
            _db = db;
            _connectionString = configuration.GetConnectionString("MySmartHomeWebApiContext");
            Set = _db.Set<T>();
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public async Task<T> Add(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            await _db.AddAsync(item, Cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public async Task<T?> Delete(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (!await Exist(item, Cancel).ConfigureAwait(false))
                return null;
            //_db.Remove(item);
            //await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            using var context = new FakeContext(_connectionString);
            context.Attach(item);
            context.Remove(item);
            await context.SaveChangesAsync(Cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public async Task<T?> DeleteById(Guid Id, CancellationToken Cancel = default)
        {
            var item = await GetById(Id).ConfigureAwait(false);
            return await Delete(item!, Cancel).ConfigureAwait(false);
        }
        public async Task<T?> Update(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (!await ExistId(item.Id, Cancel).ConfigureAwait(false))
                return null;
            //_db.Update(item);
            //await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);

            using var context = new FakeContext(_connectionString);
            context.Attach(item);
            context.Update(item);
            await context.SaveChangesAsync(Cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public async Task<bool> Exist(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            return await QueryableSet.AnyAsync(i => i.Id == item.Id, Cancel).ConfigureAwait(false);
        }

        public async Task<bool> ExistId(Guid Id, CancellationToken Cancel = default)
        {
            return await QueryableSet.AnyAsync(item => item.Id == Id, Cancel).ConfigureAwait(false);
        }


        public async Task<IEnumerable<T>> GetAll(CancellationToken Cancel = default)
        {
            return await QueryableSet.ToArrayAsync(Cancel).ConfigureAwait(false);
        }

        public async Task<T?> GetById(Guid Id, CancellationToken Cancel = default)
        { 
            var t = await QueryableSet.Where(s => s.Id == Id).ToArrayAsync().ConfigureAwait(false);
            return t.First();
            //return await Set.FindAsync( new object[] { Id }, Cancel).ConfigureAwait(false);
        }
        
        public async Task<IEnumerable<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return await Include(includeProperties).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includeProperties)
        {
            if (includeProperties is null)
                return await QueryableSet.Where(predicate).ToArrayAsync().ConfigureAwait(false);

            var query = Include(includeProperties);
            return await query.Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = QueryableSet;
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

    }
}
