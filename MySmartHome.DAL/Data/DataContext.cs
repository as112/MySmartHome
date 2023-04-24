using Microsoft.EntityFrameworkCore;
using MySmartHome.DAL.Models;

namespace MySmartHome.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        //public DbSet<Lamps>? Lamps { get; set; }
        public DbSet<Rooms>? Rooms { get; set; }
        //public DbSet<Sensors>? Sensors { get; set; }
        //public DbSet<Users>? Persons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rooms>()
                .HasMany(p => p.Sensors)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Rooms>()
                .HasMany(p => p.Lamps)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
            

            modelBuilder.Entity<HistoryData>().HasData(new HistoryData
            {
                Id = Guid.NewGuid(),
                Name = "test",
                DateTimeUpdate = DateTime.Now.ToUniversalTime(),
                Topic = "/test",
                Value = "112"

            });

            var namesLamp = new Dictionary<int, string>();
            namesLamp[0] = "Свет в туалете";
            namesLamp[1] = "Свет в котельной";
            namesLamp[2] = "Свет в прихожей";
            namesLamp[3] = "Свет на крыльце";
            namesLamp[4] = "Свет 1 на кухне";
            namesLamp[5] = "Свет 2 на кухне";
            namesLamp[6] = "Свет в ванной";
            namesLamp[7] = "Свет в коридоре";
            namesLamp[8] = "Свет 1 в спальне";
            namesLamp[9] = "Свет 2 в спальне";
            namesLamp[10] = "Свет 1 в гостиной";
            namesLamp[11] = "Свет 2 в гостиной";
            namesLamp[12] = "Свет 1 в детской";
            namesLamp[13] = "Свет 2 в детской";
            namesLamp[14] = "Свет 1 в кабинете";
            namesLamp[15] = "Свет 2 в кабинете";

            List<Lamps>? lamps = new();
            int[] x = { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4 };
            int[] y = { 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4 };
            for (int i = 0; i < 16; i++)
            {
                lamps.Add(new Lamps
                {
                    Id = Guid.NewGuid(),
                    DateTimeUpdate = DateTime.Now,
                    Name = namesLamp[i],
                    Status = false,
                    TopicUp = $"/user/as112/ESP0{x[i]}/R{y[i]}/",
                    TopicDown = $"/user/as112/ESP0{x[i]}/R{y[i]}/STATUS/",
                    RoomName = ""
                });
            }

            modelBuilder.Entity<Lamps>().HasData(lamps.ToArray());

            //modelBuilder.Entity<Persons>().HasData(
            //    new Persons[]
            //    {
            //    new Persons { Id = Guid.NewGuid(), Email = "admin", Password = "admin", Role = Roles.Administrators }
            //    });

            modelBuilder.Entity<Sensors>().HasData(new Sensors[]
            {
                new Sensors
                {
                    Id = Guid.NewGuid(),
                    DateTimeUpdate = DateTime.Now,
                    Name = "Подача",
                    TopicUp = "/user/as112/KOTEL/Pod/",
                    TopicDown = null,
                    RoomName = "Котельная",
                    Value = "1.5"
                },
                new Sensors
                {
                    Id = Guid.NewGuid(),
                    DateTimeUpdate = DateTime.Now,
                    Name = "Обратка",
                    TopicUp = "/user/as112/KOTEL/Obr/",
                    TopicDown = null,
                    RoomName = "Котельная",
                    Value = "1.5"
                },
                new Sensors
                {
                    Id = Guid.NewGuid(),
                    DateTimeUpdate = DateTime.Now,
                    Name = "Термопара",
                    TopicUp = "/user/as112/KOTEL/Bunker/",
                    TopicDown = null,
                    RoomName = "Котельная",
                    Value = "1.5"
                },
                new Sensors
                {
                    Id = Guid.NewGuid(),
                    DateTimeUpdate = DateTime.Now,
                    Name = "Мощность",
                    TopicUp = "/user/as112/KOTEL/Power/",
                    TopicDown = null,
                    RoomName = "Котельная",
                    Value = "1.5"
                },
                new Sensors
                {
                    Id = Guid.NewGuid(),
                    DateTimeUpdate = DateTime.Now,
                    Name = "Расход",
                    TopicUp = "/user/as112/KOTEL/Rashod/",
                    TopicDown = null,
                    RoomName = "Котельная",
                    Value = "1.5"
                },
                new Sensors
                {
                    Id = Guid.NewGuid(),
                    DateTimeUpdate = DateTime.Now,
                    Name = "Температура в коридоре",
                    TopicUp = "/user/as112/ESP05/TEMP/",
                    TopicDown = null,
                    RoomName = "Котельная",
                    Value = "1.5"
                }
            });
            modelBuilder.Entity<Rooms>().HasData(
                new Rooms[]
                {
                    new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Коридор",
                        Lamps = null,
                        Sensors = null
                    },
                    new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Прихожая",
                        Lamps = null,
                        Sensors = null
                    },new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Котельная",
                        Lamps = null,
                        Sensors = null
                    },new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Туалет",
                        Lamps = null,
                        Sensors = null
                    },new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ванная",
                        Lamps = null,
                        Sensors = null
                    },new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Кухня",
                        Lamps = null,
                        Sensors = null
                    },new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Гостиная",
                        Lamps = null,
                        Sensors = null
                    },new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Спальня",
                        Lamps = null,
                        Sensors = null
                    },new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Детская",
                        Lamps = null,
                        Sensors = null
                    },new Rooms
                    {
                        Id = Guid.NewGuid(),
                        Name = "Кабинет",
                        Lamps = null,
                        Sensors = null
                    }
                });

        
        }
        
    }
}
