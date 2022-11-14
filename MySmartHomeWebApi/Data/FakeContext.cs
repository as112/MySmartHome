using Microsoft.EntityFrameworkCore;
using MySmartHomeWebApi.Models;

namespace MySmartHomeWebApi.Data
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
        //public DbSet<Users>? Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
