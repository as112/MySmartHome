using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Models;

namespace MySmartHomeWebApi.Data
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {
        }
        

        public DbSet<HistoryData>? HistoryData { get; set; }

    }
}
