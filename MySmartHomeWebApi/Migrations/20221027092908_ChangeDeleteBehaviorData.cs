using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySmartHomeWebApi.Migrations
{
    public partial class ChangeDeleteBehaviorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lamps_Rooms_RoomsId",
                table: "Lamps");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Rooms_RoomsId",
                table: "Sensors");

            migrationBuilder.DeleteData(
                table: "HistoryData",
                keyColumn: "Id",
                keyValue: new Guid("bffd3f72-471b-4a3d-b5a2-9732a50e7a5e"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("0a614a62-534c-4394-b75d-ebe47a23a243"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("21ec210d-fc82-4ae2-8665-1cf6c77c153e"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("2cd505f1-a601-4b60-bd2a-f640c2081f1f"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("4706e4bb-d503-49ae-a943-dffed0546322"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("5b4fe4f4-e389-46d0-9c5b-405c0dfafe5c"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("7f1b0ad1-cb14-4cc9-b256-8f404c6a3251"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("875c24fd-d193-4c90-9ba6-8fe60eb681d6"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("89b7959d-524b-42fc-9876-7b5fba553602"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("8c85344a-c159-4ccc-9b5c-c45abdd5ec7c"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("aed904d1-ebd2-43b7-a941-1504f8ddddb3"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("d577fca9-16ff-4719-9721-7967ce56acd6"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("e09c26c1-229e-4755-b4fd-863c61c24d4d"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("e200377b-bf0f-47e6-bf49-de19bd68ac01"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("f1a88b94-9c85-41b6-9de5-68b189ce8f7d"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("faea55b0-5111-45a5-b605-cb8cd91ae901"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("ffbfd045-9327-4fee-8496-a0bd78cd30b0"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("ad241f05-e46a-44c9-b485-38c9ff26f93f"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1195d579-778c-4f2a-baff-2926bd63ef0e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1e48de83-3dff-4bc5-9b3c-51c626c6d169"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("32a2e07d-e94d-4e3b-ada1-dd024b7ed1ee"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3704f75d-f19d-4665-b31f-7d87673c78be"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("75980ba9-5a55-444d-b9e4-7f1bfe6d92a0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7a4ed13d-febb-4ce9-8c2c-b603270f8f11"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8832408c-bcaa-4f6a-aff8-8cf58560789e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("90485713-fcb3-461c-9ae3-cb3bc8ca295e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("9d3961e7-7b4f-4cce-a1b0-febb92a40e38"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a4fb6c83-8f5c-4b18-a8be-f01615319b33"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("01a310d3-771e-4f14-8278-48aaa661ff40"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("0d648305-e34f-47ab-b414-2d131067ce78"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("11201e98-9398-46a2-a634-c9326dd2afb4"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("5d06495a-4fc1-4080-9d75-50b82b650f8a"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("5f86d838-5801-4481-8b7c-5abd17e0a71a"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("b1b55848-3bbe-4c5f-8efd-1925e37a0cdc"));

            migrationBuilder.InsertData(
                table: "HistoryData",
                columns: new[] { "Id", "DateTimeUpdate", "Name", "Topic", "Value" },
                values: new object[] { new Guid("1e113c70-20cd-4e26-8941-c3ea13d44fa5"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3472), "test", "/test", "112" });

            migrationBuilder.InsertData(
                table: "Lamps",
                columns: new[] { "Id", "DateTimeUpdate", "Name", "RoomName", "RoomsId", "Status", "TopicDown", "TopicUp" },
                values: new object[,]
                {
                    { new Guid("0312afdd-38d2-483c-8e31-0af0d2f422da"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3634), "Свет 1 на кухне", "", null, false, "/user/as112/ESP02/R1/STATUS/", "/user/as112/ESP02/R1/" },
                    { new Guid("07de69c8-9365-4ab5-bbf6-335962f38f9c"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3629), "Свет в прихожей", "", null, false, "/user/as112/ESP01/R3/STATUS/", "/user/as112/ESP01/R3/" },
                    { new Guid("2f2bd263-af63-4556-94d6-3ba0aab5b9a7"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3695), "Свет 2 в кабинете", "", null, false, "/user/as112/ESP04/R4/STATUS/", "/user/as112/ESP04/R4/" },
                    { new Guid("44ed4d7e-1f36-4b45-a498-210f6587268c"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3646), "Свет в коридоре", "", null, false, "/user/as112/ESP02/R4/STATUS/", "/user/as112/ESP02/R4/" },
                    { new Guid("47ec481d-e2e2-43df-869d-88b91bc48201"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3641), "Свет в ванной", "", null, false, "/user/as112/ESP02/R3/STATUS/", "/user/as112/ESP02/R3/" },
                    { new Guid("52751656-9349-4e9b-a782-6595d412e542"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3626), "Свет в котельной", "", null, false, "/user/as112/ESP01/R2/STATUS/", "/user/as112/ESP01/R2/" },
                    { new Guid("828d5e54-b639-4374-a632-a95051f916ab"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3680), "Свет 1 в гостиной", "", null, false, "/user/as112/ESP03/R3/STATUS/", "/user/as112/ESP03/R3/" },
                    { new Guid("8e9138b7-471d-466c-950e-10a0291374c5"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3638), "Свет 2 на кухне", "", null, false, "/user/as112/ESP02/R2/STATUS/", "/user/as112/ESP02/R2/" },
                    { new Guid("a5703e28-05b7-4187-ae28-ab562f1543eb"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3685), "Свет 1 в детской", "", null, false, "/user/as112/ESP04/R1/STATUS/", "/user/as112/ESP04/R1/" },
                    { new Guid("b620a13f-e845-49eb-8ea7-8f5a296125a7"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3649), "Свет 1 в спальне", "", null, false, "/user/as112/ESP03/R1/STATUS/", "/user/as112/ESP03/R1/" },
                    { new Guid("cad18d7d-0760-400f-8ad6-0148f7e2097e"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3688), "Свет 2 в детской", "", null, false, "/user/as112/ESP04/R2/STATUS/", "/user/as112/ESP04/R2/" },
                    { new Guid("ce66254d-47a6-4cef-ae3d-da9082fd7c2a"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3599), "Свет в туалете", "", null, false, "/user/as112/ESP01/R1/STATUS/", "/user/as112/ESP01/R1/" },
                    { new Guid("d79305f0-5069-4a81-bfc8-e204958d40f2"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3683), "Свет 2 в гостиной", "", null, false, "/user/as112/ESP03/R4/STATUS/", "/user/as112/ESP03/R4/" },
                    { new Guid("e1496146-9d5a-40b9-9e47-ae8f7c8e933f"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3677), "Свет 2 в спальне", "", null, false, "/user/as112/ESP03/R2/STATUS/", "/user/as112/ESP03/R2/" },
                    { new Guid("fb063949-8127-4c42-9bd0-9b5928cfd168"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3690), "Свет 1 в кабинете", "", null, false, "/user/as112/ESP04/R3/STATUS/", "/user/as112/ESP04/R3/" },
                    { new Guid("ff9534cf-ec54-49be-8e54-20bfa2f0017c"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3632), "Свет на крыльце", "", null, false, "/user/as112/ESP01/R4/STATUS/", "/user/as112/ESP01/R4/" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[] { new Guid("57ac60d5-533a-4ba6-ae8c-7ca7f3cf6fe3"), "admin", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0cbb3556-347d-4d34-847c-ccb197629531"), "Прихожая" },
                    { new Guid("4e3eff80-5b8d-45dc-b413-c961590a2e2a"), "Туалет" },
                    { new Guid("57d26882-21da-42f2-b6d3-b6c5a20e966b"), "Гостиная" },
                    { new Guid("73327072-dc5c-425a-bc7f-6d5dbb60eda9"), "Коридор" },
                    { new Guid("8acce9f7-6488-4dcc-95b1-28ffec7fce77"), "Кабинет" },
                    { new Guid("8ff20b7c-794a-45e5-92d1-35748b9f36ce"), "Кухня" },
                    { new Guid("90671eb7-d72c-40e4-bc8f-fa6dca527b4e"), "Котельная" },
                    { new Guid("a6f30ccf-296f-4650-b68b-7d4b3c21dba0"), "Детская" },
                    { new Guid("cc817cb4-c27c-4a3c-987b-3aec7df8d3a0"), "Ванная" },
                    { new Guid("fac020eb-42eb-437e-b743-e130eacdcd37"), "Спальня" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "DateTimeUpdate", "Name", "RoomName", "RoomsId", "TopicDown", "TopicUp", "Value" },
                values: new object[,]
                {
                    { new Guid("39ff569a-9514-4c9e-9557-e83985d7c2fa"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3755), "Термопара", "Котельная", null, null, "/user/as112/KOTEL/Bunker/", 0.0 },
                    { new Guid("64f928c5-8911-45cf-baef-ea9b2612c17e"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3759), "Температура в коридоре", "Котельная", null, null, "/user/as112/ESP05/TEMP/", 0.0 },
                    { new Guid("a67a06d6-2532-4202-9b63-676249bed1af"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3758), "Расход", "Котельная", null, null, "/user/as112/KOTEL/Rashod/", 0.0 },
                    { new Guid("b9d0b5fc-e0c3-4279-b4d5-7179c033c1da"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3752), "Подача", "Котельная", null, null, "/user/as112/KOTEL/Pod/", 0.0 },
                    { new Guid("f94c9e16-0528-41e9-afbf-7ff1d523bac3"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3757), "Мощность", "Котельная", null, null, "/user/as112/KOTEL/Power/", 0.0 },
                    { new Guid("fad0dd18-a084-4bf8-a056-d1c7bc751c1a"), new DateTime(2022, 10, 27, 12, 29, 8, 516, DateTimeKind.Local).AddTicks(3754), "Обратка", "Котельная", null, null, "/user/as112/KOTEL/Obr/", 0.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lamps_Rooms_RoomsId",
                table: "Lamps",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Rooms_RoomsId",
                table: "Sensors",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lamps_Rooms_RoomsId",
                table: "Lamps");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Rooms_RoomsId",
                table: "Sensors");

            migrationBuilder.DeleteData(
                table: "HistoryData",
                keyColumn: "Id",
                keyValue: new Guid("1e113c70-20cd-4e26-8941-c3ea13d44fa5"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("0312afdd-38d2-483c-8e31-0af0d2f422da"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("07de69c8-9365-4ab5-bbf6-335962f38f9c"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("2f2bd263-af63-4556-94d6-3ba0aab5b9a7"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("44ed4d7e-1f36-4b45-a498-210f6587268c"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("47ec481d-e2e2-43df-869d-88b91bc48201"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("52751656-9349-4e9b-a782-6595d412e542"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("828d5e54-b639-4374-a632-a95051f916ab"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("8e9138b7-471d-466c-950e-10a0291374c5"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("a5703e28-05b7-4187-ae28-ab562f1543eb"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("b620a13f-e845-49eb-8ea7-8f5a296125a7"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("cad18d7d-0760-400f-8ad6-0148f7e2097e"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("ce66254d-47a6-4cef-ae3d-da9082fd7c2a"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("d79305f0-5069-4a81-bfc8-e204958d40f2"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("e1496146-9d5a-40b9-9e47-ae8f7c8e933f"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("fb063949-8127-4c42-9bd0-9b5928cfd168"));

            migrationBuilder.DeleteData(
                table: "Lamps",
                keyColumn: "Id",
                keyValue: new Guid("ff9534cf-ec54-49be-8e54-20bfa2f0017c"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("57ac60d5-533a-4ba6-ae8c-7ca7f3cf6fe3"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("0cbb3556-347d-4d34-847c-ccb197629531"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4e3eff80-5b8d-45dc-b413-c961590a2e2a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("57d26882-21da-42f2-b6d3-b6c5a20e966b"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("73327072-dc5c-425a-bc7f-6d5dbb60eda9"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8acce9f7-6488-4dcc-95b1-28ffec7fce77"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8ff20b7c-794a-45e5-92d1-35748b9f36ce"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("90671eb7-d72c-40e4-bc8f-fa6dca527b4e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a6f30ccf-296f-4650-b68b-7d4b3c21dba0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("cc817cb4-c27c-4a3c-987b-3aec7df8d3a0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fac020eb-42eb-437e-b743-e130eacdcd37"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("39ff569a-9514-4c9e-9557-e83985d7c2fa"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("64f928c5-8911-45cf-baef-ea9b2612c17e"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("a67a06d6-2532-4202-9b63-676249bed1af"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("b9d0b5fc-e0c3-4279-b4d5-7179c033c1da"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("f94c9e16-0528-41e9-afbf-7ff1d523bac3"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("fad0dd18-a084-4bf8-a056-d1c7bc751c1a"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lamps_Rooms_RoomsId",
                table: "Lamps",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Rooms_RoomsId",
                table: "Sensors",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
