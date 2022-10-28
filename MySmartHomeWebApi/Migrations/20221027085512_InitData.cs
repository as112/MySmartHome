using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySmartHomeWebApi.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoryData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lamps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicDown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lamps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lamps_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicDown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "HistoryData",
                columns: new[] { "Id", "DateTimeUpdate", "Name", "Topic", "Value" },
                values: new object[] { new Guid("bffd3f72-471b-4a3d-b5a2-9732a50e7a5e"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4470), "test", "/test", "112" });

            migrationBuilder.InsertData(
                table: "Lamps",
                columns: new[] { "Id", "DateTimeUpdate", "Name", "RoomName", "RoomsId", "Status", "TopicDown", "TopicUp" },
                values: new object[,]
                {
                    { new Guid("0a614a62-534c-4394-b75d-ebe47a23a243"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4650), "Свет в прихожей", "", null, false, "/user/as112/ESP01/R3/STATUS/", "/user/as112/ESP01/R3/" },
                    { new Guid("21ec210d-fc82-4ae2-8665-1cf6c77c153e"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4659), "Свет 2 на кухне", "", null, false, "/user/as112/ESP02/R2/STATUS/", "/user/as112/ESP02/R2/" },
                    { new Guid("2cd505f1-a601-4b60-bd2a-f640c2081f1f"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4685), "Свет 2 в гостиной", "", null, false, "/user/as112/ESP03/R4/STATUS/", "/user/as112/ESP03/R4/" },
                    { new Guid("4706e4bb-d503-49ae-a943-dffed0546322"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4730), "Свет 2 в кабинете", "", null, false, "/user/as112/ESP04/R4/STATUS/", "/user/as112/ESP04/R4/" },
                    { new Guid("5b4fe4f4-e389-46d0-9c5b-405c0dfafe5c"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4653), "Свет на крыльце", "", null, false, "/user/as112/ESP01/R4/STATUS/", "/user/as112/ESP01/R4/" },
                    { new Guid("7f1b0ad1-cb14-4cc9-b256-8f404c6a3251"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4691), "Свет 2 в детской", "", null, false, "/user/as112/ESP04/R2/STATUS/", "/user/as112/ESP04/R2/" },
                    { new Guid("875c24fd-d193-4c90-9ba6-8fe60eb681d6"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4655), "Свет 1 на кухне", "", null, false, "/user/as112/ESP02/R1/STATUS/", "/user/as112/ESP02/R1/" },
                    { new Guid("89b7959d-524b-42fc-9876-7b5fba553602"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4683), "Свет 1 в гостиной", "", null, false, "/user/as112/ESP03/R3/STATUS/", "/user/as112/ESP03/R3/" },
                    { new Guid("8c85344a-c159-4ccc-9b5c-c45abdd5ec7c"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4688), "Свет 1 в детской", "", null, false, "/user/as112/ESP04/R1/STATUS/", "/user/as112/ESP04/R1/" },
                    { new Guid("aed904d1-ebd2-43b7-a941-1504f8ddddb3"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4677), "Свет 1 в спальне", "", null, false, "/user/as112/ESP03/R1/STATUS/", "/user/as112/ESP03/R1/" },
                    { new Guid("d577fca9-16ff-4719-9721-7967ce56acd6"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4674), "Свет в коридоре", "", null, false, "/user/as112/ESP02/R4/STATUS/", "/user/as112/ESP02/R4/" },
                    { new Guid("e09c26c1-229e-4755-b4fd-863c61c24d4d"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4610), "Свет в туалете", "", null, false, "/user/as112/ESP01/R1/STATUS/", "/user/as112/ESP01/R1/" },
                    { new Guid("e200377b-bf0f-47e6-bf49-de19bd68ac01"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4671), "Свет в ванной", "", null, false, "/user/as112/ESP02/R3/STATUS/", "/user/as112/ESP02/R3/" },
                    { new Guid("f1a88b94-9c85-41b6-9de5-68b189ce8f7d"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4680), "Свет 2 в спальне", "", null, false, "/user/as112/ESP03/R2/STATUS/", "/user/as112/ESP03/R2/" },
                    { new Guid("faea55b0-5111-45a5-b605-cb8cd91ae901"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4726), "Свет 1 в кабинете", "", null, false, "/user/as112/ESP04/R3/STATUS/", "/user/as112/ESP04/R3/" },
                    { new Guid("ffbfd045-9327-4fee-8496-a0bd78cd30b0"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4646), "Свет в котельной", "", null, false, "/user/as112/ESP01/R2/STATUS/", "/user/as112/ESP01/R2/" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[] { new Guid("ad241f05-e46a-44c9-b485-38c9ff26f93f"), "admin", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1195d579-778c-4f2a-baff-2926bd63ef0e"), "Детская" },
                    { new Guid("1e48de83-3dff-4bc5-9b3c-51c626c6d169"), "Гостиная" },
                    { new Guid("32a2e07d-e94d-4e3b-ada1-dd024b7ed1ee"), "Кабинет" },
                    { new Guid("3704f75d-f19d-4665-b31f-7d87673c78be"), "Туалет" },
                    { new Guid("75980ba9-5a55-444d-b9e4-7f1bfe6d92a0"), "Кухня" },
                    { new Guid("7a4ed13d-febb-4ce9-8c2c-b603270f8f11"), "Коридор" },
                    { new Guid("8832408c-bcaa-4f6a-aff8-8cf58560789e"), "Прихожая" },
                    { new Guid("90485713-fcb3-461c-9ae3-cb3bc8ca295e"), "Ванная" },
                    { new Guid("9d3961e7-7b4f-4cce-a1b0-febb92a40e38"), "Котельная" },
                    { new Guid("a4fb6c83-8f5c-4b18-a8be-f01615319b33"), "Спальня" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "DateTimeUpdate", "Name", "RoomName", "RoomsId", "TopicDown", "TopicUp", "Value" },
                values: new object[,]
                {
                    { new Guid("01a310d3-771e-4f14-8278-48aaa661ff40"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4901), "Обратка", "Котельная", null, null, "/user/as112/KOTEL/Obr/", 0.0 },
                    { new Guid("0d648305-e34f-47ab-b414-2d131067ce78"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4898), "Подача", "Котельная", null, null, "/user/as112/KOTEL/Pod/", 0.0 },
                    { new Guid("11201e98-9398-46a2-a634-c9326dd2afb4"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4909), "Температура в коридоре", "Котельная", null, null, "/user/as112/ESP05/TEMP/", 0.0 },
                    { new Guid("5d06495a-4fc1-4080-9d75-50b82b650f8a"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4903), "Термопара", "Котельная", null, null, "/user/as112/KOTEL/Bunker/", 0.0 },
                    { new Guid("5f86d838-5801-4481-8b7c-5abd17e0a71a"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4905), "Расход", "Котельная", null, null, "/user/as112/KOTEL/Rashod/", 0.0 },
                    { new Guid("b1b55848-3bbe-4c5f-8efd-1925e37a0cdc"), new DateTime(2022, 10, 27, 11, 55, 12, 670, DateTimeKind.Local).AddTicks(4904), "Мощность", "Котельная", null, null, "/user/as112/KOTEL/Power/", 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lamps_RoomsId",
                table: "Lamps",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_DateTimeUpdate",
                table: "Sensors",
                column: "DateTimeUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_Name",
                table: "Sensors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_RoomsId",
                table: "Sensors",
                column: "RoomsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryData");

            migrationBuilder.DropTable(
                name: "Lamps");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
