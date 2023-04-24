using Microsoft.EntityFrameworkCore;
using MySmartHome.DAL.Models;

namespace MySmartHome.DAL.Data
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {
        }
        

        public DbSet<HistoryData>? HistoryData { get; set; }

    }
}
