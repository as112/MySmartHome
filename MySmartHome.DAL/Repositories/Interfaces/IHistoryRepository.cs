﻿using MySmartHome.DAL.Models;
using System.Linq.Expressions;

namespace MySmartHome.DAL.Repositories.Interfaces
{
    public interface IHistoryRepository<T> where T : HistoryData
    {
        Task<T?> GetLastByName(string name, CancellationToken Cancel = default);
        Task<T> Add(T item, CancellationToken Cancel = default);
        Task<T?> DeleteById(Guid id, CancellationToken Cancel = default);
        Task<bool> DeleteAllUntilDate(int daysAgo, CancellationToken Cancel = default);
        Task<IEnumerable<T>?> GetAllWithPredicate(Expression<Func<T, bool>> predicate, CancellationToken Cancel = default);
        Task<IEnumerable<T>?> GetAllByTopic(string topic, CancellationToken Cancel = default);
        Task<IEnumerable<T>?> GetAllByName(string name, CancellationToken Cancel = default);
        Task<IEnumerable<T>?> GetLastNByName(string name, int take, CancellationToken Cancel = default);
    }
}
