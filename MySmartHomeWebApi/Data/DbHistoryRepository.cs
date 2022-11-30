using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Entities;
using MySmartHomeWebApi.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace MySmartHomeWebApi.Data
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

        public async Task<T> Add(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            //await _db.AddAsync(item, Cancel).ConfigureAwait(false);
            await Set.AddAsync(item, Cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public async Task<T?> DeleteById(Guid id, CancellationToken Cancel = default)
        {
            var t = await QueryableSet.Where(s => s.Id == id).ToArrayAsync().ConfigureAwait(false);
            var item = t.FirstOrDefault();
            if (item is null) throw new ArgumentNullException(nameof(item));
            
            _db.Remove(item);
            await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public async Task<bool> DeleteAllUntilDate(int daysAgo, CancellationToken Cancel = default)
        {
            if (daysAgo < 0) 
                return false;
            var items = await QueryableSet.Where(s => s.DateTimeUpdate < DateTime.Now.AddDays(-1 * daysAgo)).ToArrayAsync(Cancel).ConfigureAwait(false);
            //var items = await QueryableSet.Where(s => s.DateTimeUpdate < DateTime.Now.AddMinutes(-1 * daysAgo)).ToArrayAsync().ConfigureAwait(false);
            foreach (var item in items)
                _db.Remove(item);
            await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return true;
        }

        public async Task<IEnumerable<T>?> GetAllByName(string name, CancellationToken Cancel = default)
        {
            return await QueryableSet.Where(s => s.Name == name).ToArrayAsync(Cancel).ConfigureAwait(false);
        }

        public async Task<T?> GetLastByName(string name, CancellationToken Cancel = default)
        {
            var items = await QueryableSet.Where(s => s.Name == name).ToArrayAsync(Cancel).ConfigureAwait(false);
            return items.OrderBy(s => s.DateTimeUpdate).Last();
        }

        public async Task<IEnumerable<T>?> GetAllByTopic(string topic, CancellationToken Cancel = default)
        {
            return await QueryableSet.Where(s => s.Topic == topic).ToArrayAsync(Cancel).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>?> GetAllWithPredicate(Expression<Func<T, bool>> predicate, CancellationToken Cancel = default)
        {
            return await QueryableSet.Where(predicate).ToArrayAsync(Cancel).ConfigureAwait(false);
        }
    }
}
