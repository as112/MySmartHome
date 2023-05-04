using Microsoft.EntityFrameworkCore;
using MySmartHome.DAL.Repositories.Interfaces;
using MySmartHome.DAL.Models;
using System.Linq.Expressions;
using MySmartHome.DAL.Data;

namespace MySmartHome.DAL.Repositories
{
    public class DbHistoryRepository<T> : IHistoryRepository<T> where T : HistoryData, new()
    {
        private readonly HistoryContext _db;
        private DbSet<T> Set { get; }
        protected IQueryable<T> QueryableSet => Set.AsQueryable();
        public DbHistoryRepository(HistoryContext db)
        {
            _db = db;
            Set = _db.Set<T>();
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        private async Task<bool> ExistId(Guid Id, CancellationToken Cancel = default)
        {
            return await QueryableSet.AnyAsync(item => item.Id == Id, Cancel);
        }

        public async Task<T> Add(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            await Set.AddAsync(item, Cancel);
            await _db.SaveChangesAsync(Cancel);
            return item;
        }

        public async Task<T?> DeleteById(Guid id, CancellationToken Cancel = default)
        {
            if (await ExistId(id)) 
                throw new ArgumentNullException(nameof(T));
            
            var item = await QueryableSet
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            _db.Remove(item!);
            await _db.SaveChangesAsync(Cancel);
            return item;
        }

        public async Task<bool> DeleteAllUntilDate(int daysAgo, CancellationToken Cancel = default)
        {
            if (daysAgo < 0) 
                return false;
            var items = await QueryableSet.Where(s => s.DateTimeUpdate < DateTime.Now.AddDays(-1 * daysAgo)).ToArrayAsync(Cancel);
            foreach (var item in items)
                _db.Remove(item);
            await _db.SaveChangesAsync(Cancel);
            return true;
        }

        public async Task<IEnumerable<T>?> GetAllByName(string name, CancellationToken Cancel = default)
        {
            return await QueryableSet.Where(s => s.Name == name).ToArrayAsync(Cancel);
        }

        public async Task<T?> GetLastByName(string name, CancellationToken Cancel = default)
        {
            return await QueryableSet
                .Where(s => s.Name == name)
                .OrderBy(s => s.DateTimeUpdate)
                .LastAsync();
        }

        public async Task<IEnumerable<T>?> GetLastNByName(string name, int take, CancellationToken Cancel = default)
        {
            return await QueryableSet
                .Where(s => s.Name == name)
                .OrderBy(s => s.DateTimeUpdate)
                .Take(take)
                .ToArrayAsync();
        }
        public async Task<IEnumerable<T>?> GetAllByTopic(string topic, CancellationToken Cancel = default)
        {
            return await QueryableSet.Where(s => s.Topic == topic).ToArrayAsync(Cancel);
        }

        public async Task<IEnumerable<T>?> GetAllWithPredicate(Expression<Func<T, bool>> predicate, CancellationToken Cancel = default)
        {
            return await QueryableSet.Where(predicate).ToArrayAsync(Cancel);
        }
    }
}
