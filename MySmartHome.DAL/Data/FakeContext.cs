using Microsoft.EntityFrameworkCore;
using MySmartHome.DAL.Models;

namespace MySmartHome.DAL.Data
{
    public class FakeContext : DbContext
    {
        private readonly string connectionString;

        public FakeContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Lamps>? Lamps { get; set; }
        public DbSet<Rooms>? Rooms { get; set; }
        public DbSet<Sensors>? Sensors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
