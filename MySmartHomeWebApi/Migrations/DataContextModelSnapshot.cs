﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySmartHomeWebApi.Data;

#nullable disable

namespace MySmartHomeWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MySmartHomeWebApi.Models.HistoryData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HistoryData");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1e113c70-20cd-4e26-8941-c3ea13d44fa5"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3472),
                            Name = "test",
                            Topic = "/test",
                            Value = "112"
                        });
                });

            modelBuilder.Entity("MySmartHomeWebApi.Models.Lamps", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoomsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TopicDown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicUp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoomsId");

                    b.ToTable("Lamps");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce66254d-47a6-4cef-ae3d-da9082fd7c2a"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3599),
                            Name = "Свет в туалете",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP01/R1/STATUS/",
                            TopicUp = "/user/as112/ESP01/R1/"
                        },
                        new
                        {
                            Id = new Guid("52751656-9349-4e9b-a782-6595d412e542"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3626),
                            Name = "Свет в котельной",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP01/R2/STATUS/",
                            TopicUp = "/user/as112/ESP01/R2/"
                        },
                        new
                        {
                            Id = new Guid("07de69c8-9365-4ab5-bbf6-335962f38f9c"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3629),
                            Name = "Свет в прихожей",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP01/R3/STATUS/",
                            TopicUp = "/user/as112/ESP01/R3/"
                        },
                        new
                        {
                            Id = new Guid("ff9534cf-ec54-49be-8e54-20bfa2f0017c"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3632),
                            Name = "Свет на крыльце",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP01/R4/STATUS/",
                            TopicUp = "/user/as112/ESP01/R4/"
                        },
                        new
                        {
                            Id = new Guid("0312afdd-38d2-483c-8e31-0af0d2f422da"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3634),
                            Name = "Свет 1 на кухне",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP02/R1/STATUS/",
                            TopicUp = "/user/as112/ESP02/R1/"
                        },
                        new
                        {
                            Id = new Guid("8e9138b7-471d-466c-950e-10a0291374c5"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3638),
                            Name = "Свет 2 на кухне",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP02/R2/STATUS/",
                            TopicUp = "/user/as112/ESP02/R2/"
                        },
                        new
                        {
                            Id = new Guid("47ec481d-e2e2-43df-869d-88b91bc48201"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3641),
                            Name = "Свет в ванной",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP02/R3/STATUS/",
                            TopicUp = "/user/as112/ESP02/R3/"
                        },
                        new
                        {
                            Id = new Guid("44ed4d7e-1f36-4b45-a498-210f6587268c"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3646),
                            Name = "Свет в коридоре",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP02/R4/STATUS/",
                            TopicUp = "/user/as112/ESP02/R4/"
                        },
                        new
                        {
                            Id = new Guid("b620a13f-e845-49eb-8ea7-8f5a296125a7"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3649),
                            Name = "Свет 1 в спальне",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP03/R1/STATUS/",
                            TopicUp = "/user/as112/ESP03/R1/"
                        },
                        new
                        {
                            Id = new Guid("e1496146-9d5a-40b9-9e47-ae8f7c8e933f"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3677),
                            Name = "Свет 2 в спальне",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP03/R2/STATUS/",
                            TopicUp = "/user/as112/ESP03/R2/"
                        },
                        new
                        {
                            Id = new Guid("828d5e54-b639-4374-a632-a95051f916ab"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3680),
                            Name = "Свет 1 в гостиной",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP03/R3/STATUS/",
                            TopicUp = "/user/as112/ESP03/R3/"
                        },
                        new
                        {
                            Id = new Guid("d79305f0-5069-4a81-bfc8-e204958d40f2"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3683),
                            Name = "Свет 2 в гостиной",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP03/R4/STATUS/",
                            TopicUp = "/user/as112/ESP03/R4/"
                        },
                        new
                        {
                            Id = new Guid("a5703e28-05b7-4187-ae28-ab562f1543eb"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3685),
                            Name = "Свет 1 в детской",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP04/R1/STATUS/",
                            TopicUp = "/user/as112/ESP04/R1/"
                        },
                        new
                        {
                            Id = new Guid("cad18d7d-0760-400f-8ad6-0148f7e2097e"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3688),
                            Name = "Свет 2 в детской",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP04/R2/STATUS/",
                            TopicUp = "/user/as112/ESP04/R2/"
                        },
                        new
                        {
                            Id = new Guid("fb063949-8127-4c42-9bd0-9b5928cfd168"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3690),
                            Name = "Свет 1 в кабинете",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP04/R3/STATUS/",
                            TopicUp = "/user/as112/ESP04/R3/"
                        },
                        new
                        {
                            Id = new Guid("2f2bd263-af63-4556-94d6-3ba0aab5b9a7"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3695),
                            Name = "Свет 2 в кабинете",
                            RoomName = "",
                            Status = false,
                            TopicDown = "/user/as112/ESP04/R4/STATUS/",
                            TopicUp = "/user/as112/ESP04/R4/"
                        });
                });

            modelBuilder.Entity("MySmartHomeWebApi.Models.Persons", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("57ac60d5-533a-4ba6-ae8c-7ca7f3cf6fe3"),
                            Email = "admin",
                            Password = "admin",
                            Role = 0
                        });
                });

            modelBuilder.Entity("MySmartHomeWebApi.Models.Rooms", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("73327072-dc5c-425a-bc7f-6d5dbb60eda9"),
                            Name = "Коридор"
                        },
                        new
                        {
                            Id = new Guid("0cbb3556-347d-4d34-847c-ccb197629531"),
                            Name = "Прихожая"
                        },
                        new
                        {
                            Id = new Guid("90671eb7-d72c-40e4-bc8f-fa6dca527b4e"),
                            Name = "Котельная"
                        },
                        new
                        {
                            Id = new Guid("4e3eff80-5b8d-45dc-b413-c961590a2e2a"),
                            Name = "Туалет"
                        },
                        new
                        {
                            Id = new Guid("cc817cb4-c27c-4a3c-987b-3aec7df8d3a0"),
                            Name = "Ванная"
                        },
                        new
                        {
                            Id = new Guid("8ff20b7c-794a-45e5-92d1-35748b9f36ce"),
                            Name = "Кухня"
                        },
                        new
                        {
                            Id = new Guid("57d26882-21da-42f2-b6d3-b6c5a20e966b"),
                            Name = "Гостиная"
                        },
                        new
                        {
                            Id = new Guid("fac020eb-42eb-437e-b743-e130eacdcd37"),
                            Name = "Спальня"
                        },
                        new
                        {
                            Id = new Guid("a6f30ccf-296f-4650-b68b-7d4b3c21dba0"),
                            Name = "Детская"
                        },
                        new
                        {
                            Id = new Guid("8acce9f7-6488-4dcc-95b1-28ffec7fce77"),
                            Name = "Кабинет"
                        });
                });

            modelBuilder.Entity("MySmartHomeWebApi.Models.Sensors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoomsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TopicDown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicUp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DateTimeUpdate");

                    b.HasIndex("Name");

                    b.HasIndex("RoomsId");

                    b.ToTable("Sensors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b9d0b5fc-e0c3-4279-b4d5-7179c033c1da"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3752),
                            Name = "Подача",
                            RoomName = "Котельная",
                            TopicUp = "/user/as112/KOTEL/Pod/",
                            Value = 0.0
                        },
                        new
                        {
                            Id = new Guid("fad0dd18-a084-4bf8-a056-d1c7bc751c1a"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3754),
                            Name = "Обратка",
                            RoomName = "Котельная",
                            TopicUp = "/user/as112/KOTEL/Obr/",
                            Value = 0.0
                        },
                        new
                        {
                            Id = new Guid("39ff569a-9514-4c9e-9557-e83985d7c2fa"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3755),
                            Name = "Термопара",
                            RoomName = "Котельная",
                            TopicUp = "/user/as112/KOTEL/Bunker/",
                            Value = 0.0
                        },
                        new
                        {
                            Id = new Guid("f94c9e16-0528-41e9-afbf-7ff1d523bac3"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3757),
                            Name = "Мощность",
                            RoomName = "Котельная",
                            TopicUp = "/user/as112/KOTEL/Power/",
                            Value = 0.0
                        },
                        new
                        {
                            Id = new Guid("a67a06d6-2532-4202-9b63-676249bed1af"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3758),
                            Name = "Расход",
                            RoomName = "Котельная",
                            TopicUp = "/user/as112/KOTEL/Rashod/",
                            Value = 0.0
                        },
                        new
                        {
                            Id = new Guid("64f928c5-8911-45cf-baef-ea9b2612c17e"),
                            DateTimeUpdate = new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3759),
                            Name = "Температура в коридоре",
                            RoomName = "Котельная",
                            TopicUp = "/user/as112/ESP05/TEMP/",
                            Value = 0.0
                        });
                });

            modelBuilder.Entity("MySmartHomeWebApi.Models.Lamps", b =>
                {
                    b.HasOne("MySmartHomeWebApi.Models.Rooms", null)
                        .WithMany("Lamps")
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MySmartHomeWebApi.Models.Sensors", b =>
                {
                    b.HasOne("MySmartHomeWebApi.Models.Rooms", null)
                        .WithMany("Sensors")
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MySmartHomeWebApi.Models.Rooms", b =>
                {
                    b.Navigation("Lamps");

                    b.Navigation("Sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
