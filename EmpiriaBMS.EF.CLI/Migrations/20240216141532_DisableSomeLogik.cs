using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpiriaBMS.EF.CLI.Migrations
{
    public partial class DisableSomeLogik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectEmployee",
                keyColumn: "Id",
                keyValue: "0570df552f424cacbf5bd3c6bc1837cb2");

            migrationBuilder.DeleteData(
                table: "ProjectEmployee",
                keyColumn: "Id",
                keyValue: "743722ad5a2643cabb9ac83d0a3e56ad25");

            migrationBuilder.DeleteData(
                table: "ProjectEmployee",
                keyColumn: "Id",
                keyValue: "8d07aa4fe6474ea893964d2127ec12e814");

            migrationBuilder.DeleteData(
                table: "ProjectEmployee",
                keyColumn: "Id",
                keyValue: "c671262517da41ec94bf7792399b66bd3");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "59d8d6ca953949579831c4abd7e200588");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "6a8323232feb4cb38a8afae729e6efc320");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "b2f2e031026e404e94c786c3caf7690430");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "d07f6517e84c4b03bae7c52c5f43d0282");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "dcb24617c90f4dea87b64a9e9d4d4b280");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "34c451ab47e84ea7829898620e3311cd7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8797d29f91074dc18807d2021332a0d31");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "0a45946825554831852575be65105dad");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "28c5e934b1f64622a94c4ec3238364ae");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "28c5ed9bfa4742d6b5b5b1bd680a36fa");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "4b37f04337ce474fad761d9b2a55d56a");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "666e54b5de5b4cda9e11e6f8d6dde8ed");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "7613f30ec6dc49d9838e1d03685eaa25");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "8ac8b50f4db34944bc238f92a1882124");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "8e54827ee84f441a88e015afcf33912c");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "9257216f45b34eac83f60778d7e628ee");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "9f1475cb25034420a1e38196b4854389");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "c24237847fb848ba815484870b7b62be");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "c3570a681cad4213a016d6647ba8efb0");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "c445380836bd4708ba5f4ea2504c47e2");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "c9624166dbaa491595ab55a4046b0c97");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "cf044f966b9a4632be0d042dee485bd0");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "d872bd6540114461b8b308e958fea9ef");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "ea75e7f611544ab5b4b256d2a79f318b");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "fa2a0b9350c24af692d4e6d7245a601e");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "5498e196998a4be78abc67b09f1560bc16");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "93416e719808414a9e07f8a1ab7609686");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "c0188ac33b4242bc9583d4e5057fe4ac0");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "eaec53673e4a42338d204b25e19571af2");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "f45eb3e03ac941c1acdf5f03e1b1972b16");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "0586586a5e334df198c7df759897c0a16");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "18c421622fb149a08e9932f6c5b20ee420");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "51564267688a4dacad0946efda85efbf42");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "c651ede0301f47e7b604093deb79806412");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "044504834bc84990952a504492137dad4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "199cff7579c441759e9d5f302e7653982");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1f0214cc3aa24defb53943da5ebae1ca5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "51eaf6c4be074d20ae35a2a0c649042c8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "67914ad2d834457db47aa56110ed40736");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e08a94595b9741febc3d7698225f45833");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0531045becd74b80aceae99f39a7e3a818");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "062f3450d21e44b6b19eebb3c4b9cd3120");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1fb3db35af094a4ab20dff2b358b48da4");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3e56537ac23a47c5af18886e77be13b510");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "409953d966714a61a00a1e3cfaaead388");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "42a2ac582a19415489879364f0b027f316");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "472c8df2ec964fa8b5f0767373f1b1f52");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "57a76c4e892e47fe83ea629bb25db7b140");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "580ae02d42294dab809cc7a937986d467");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7b346e68b33f4556a8da5a2ceb9e1eba6");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "83fb1a217d174f1bad3496b382bf6d9d0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8ade01f19db74764b2447ac0e66eaee730");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "909b76febf0c4abe9a9e62522737769635");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a530fa25ea7547d8b869f43bc0de87718");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "ad943df8ec214497844658f517dc1de40");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "bfa82f3c9a42476c9d5c73a7c18168e312");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e0e4b13e78b745039fd54cab988f5f2a6");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e439e5c9aae64cdfb58e834370f2e1fb8");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "0183f142f9394ceeaff3682507fbbc1225");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "1f9dbdb56c8e42dbbcf7d071c012f8d718");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "75319d6811f74e3a8eb663e5685538ab6");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "c86130e1dceb487aa349b1897972949642");

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { "16af4f820c8641ea9d8b0db63dc735988", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7380), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7382), 100003000.0, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7381), "Signature 1423432", 40145, null, 8.0, 24.0 },
                    { "246095b27d024b4aaa1437f6f2373c896", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6025), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6028), 3100.0, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6027), "Signature 142348", 32590, null, 2.0, 24.0 },
                    { "39ccbb514a3949b08b48b74ae5b27b019", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6248), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6251), 4000.0, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6250), "Signature 1423412", 13463, null, 3.0, 17.0 },
                    { "86c24b4a2db6406f9f49cb3b70fc458f5", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9762), new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9765), 3010.0, new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9763), "Signature 142346", 41950, null, 1.0, 17.0 },
                    { "a0f4571106f54ebbb80306d028f1dfbe24", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7019), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7021), 1003000.0, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7020), "Signature 1423412", 87747, null, 6.0, 24.0 },
                    { "adbb386e991145738107440f198a33497", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7171), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7174), 10003000.0, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7173), "Signature 1423414", 60263, null, 7.0, 17.0 },
                    { "cd381961d4414dd689ed26064f6174320", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9282), new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9285), 3001.0, new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9284), "Signature 142340", 62656, null, 0.0, 24.0 },
                    { "d978af407a6e4a7d8775d109c2b36efe24", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6460), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6463), 13000.0, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6462), "Signature 1423416", 44948, null, 4.0, 24.0 },
                    { "f02773df93b04b5f9fdbb7d48e5325ce15", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6631), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6634), 103000.0, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6632), "Signature 1423430", 48350, null, 5.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { "6ef759a8c2534fe1a7a74f82f6bb43b51", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1239), new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1241), "Draftsmen" },
                    { "7a45b1fd0b594822bc35411234807b072", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1258), new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1260), "Engineers" },
                    { "8c1e3d5544cd4d26b759350d0df433425", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1311), new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1314), "CTO" },
                    { "8fedba7fdc124e2780ae994b302d9a966", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1330), new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1332), "CEO" },
                    { "aa667da11b514452b6e9942763da0d074", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1292), new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1294), "COO" },
                    { "ae5a22419c3d486cb713f22e9685320d8", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1368), new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1370), "Customer" },
                    { "d69bd6b40d7343eca44dc6cf3b5095f63", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1274), new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1276), "Project Managers" },
                    { "eba98ffc9950444dbcde9283f74386597", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1350), new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1353), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { "0b758c30b39b428f84deb20303103e5b48", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7329), "Test Description Employee 10", "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7331), "", "69492777810", "", "", null },
                    { "0bcfa7ce9eec4a669a8f63d6e42752126", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6896), "Test Description Employee 8", "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6899), "", "6949277788", "", "", null },
                    { "250e21d5b7514e99badd0b75efd52e4f4", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6331), "Test Description Client 4", "alexpl_4@gmail.com", "Platanios_Customer_4", 0.0, "Alexandros_4", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6333), "", "6949277784", "", "", null },
                    { "4265411c156049a0af887992143f215f2", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9371), "Test Description Client 1", "alexpl_1@gmail.com", "Platanios_Customer_1", 0.0, "Alexandros_1", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9373), "", "6949277781", "", "", null },
                    { "469f1aca44a74c8cb084fb9f3dbd9e127", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7078), "Test Description Client 7", "alexpl_7@gmail.com", "Platanios_Customer_7", 0.0, "Alexandros_7", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7080), "", "6949277787", "", "", null },
                    { "5d41925d76ee4b26a1d9c0038a208f9830", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6569), "Test Description Employee 7", "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6570), "", "6949277787", "", "", null },
                    { "5fe90d67d062443b8da1dc01b1b769bb7", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7126), "Test Description Employee 9", "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7128), "", "6949277789", "", "", null },
                    { "6954ce88536a4099bfa948c908e94cf00", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1579), "Test Description Client 0", "alexpl_0@gmail.com", "Platanios_Customer_0", 0.0, "Alexandros_0", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1580), "", "6949277780", "", "", null },
                    { "6f774794eea440c7acd5f76095736b2224", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6383), "Test Description Employee 6", "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6385), "", "6949277786", "", "", null },
                    { "77fdc61739bc40a796ca6d5c5d5118fc4", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(5969), "Test Description Employee 4", "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(5971), "", "6949277784", "", "", null },
                    { "8290a668526045afb2035f9c265c9fab5", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6523), "Test Description Client 5", "alexpl_5@gmail.com", "Platanios_Customer_5", 0.0, "Alexandros_5", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6524), "", "6949277785", "", "", null },
                    { "846f59b1a8664de5bcbdc98bfab24b2f10", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(5825), "Test Description Client 2", "alexpl_2@gmail.com", "Platanios_Customer_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(5827), "", "6949277782", "", "", null },
                    { "a52e403472ae4d7097e9b4e9d19ad94b6", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6200), "Test Description Employee 5", "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6202), "", "6949277785", "", "", null },
                    { "b180dee3c7fa4d798730e7a49dfc192c6", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9417), "Test Description Employee 3", "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9418), "", "6949277783", "", "", null },
                    { "cfef668022ed4bc8a874cc0992fe83ab0", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9129), "Test Description Employee 2", "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9130), "", "6949277782", "", "", null },
                    { "db8ff30ad9664722b0ff2c11b9dfe77030", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6759), "Test Description Client 6", "alexpl_6@gmail.com", "Platanios_Customer_6", 0.0, "Alexandros_6", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6761), "", "6949277786", "", "", null },
                    { "e0777d0b7a84470298806745537ee6a83", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6155), "Test Description Client 3", "alexpl_3@gmail.com", "Platanios_Customer_3", 0.0, "Alexandros_3", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6156), "", "6949277783", "", "", null },
                    { "ea19ea732058451b99328ae26169d4fa48", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7279), "Test Description Client 8", "alexpl_8@gmail.com", "Platanios_Customer_8", 0.0, "Alexandros_8", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7281), "", "6949277788", "", "", null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "CustomerId", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "InvoiceId", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "PlanType", "WorkingDays" },
                values: new object[,]
                {
                    { "25f03947ca1642638fe21c0ac672f20a4", "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9776), null, 6.0, -54, 8, "Test Description Project_4", "KL-1", new DateTime(2024, 4, 9, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9776), new DateTime(2024, 4, 8, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9776), "86c24b4a2db6406f9f49cb3b70fc458f5", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9776), 4, "Project_1", 5.0, new DateTime(2024, 4, 10, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9776), "Payment Detailes For Project_6", 1.0, 0, 203 },
                    { "71d650d6dbeb424ea9a62de38dfe8ebe8", "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6058), "846f59b1a8664de5bcbdc98bfab24b2f10", 7.0, -57, 13, "Test Description Project_2", "KL-2", new DateTime(2024, 4, 12, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6058), new DateTime(2024, 4, 10, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6058), "246095b27d024b4aaa1437f6f2373c896", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6058), 8, "Project_2", 5.0, new DateTime(2024, 4, 13, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6058), "Payment Detailes For Project_8", 2.0, 1, 206 },
                    { "8e6d8a06a6c74e9f86da4cb3b480d83b18", "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6265), null, 8.0, -60, 18, "Test Description Project_18", "KL-3", new DateTime(2024, 4, 15, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6265), new DateTime(2024, 4, 12, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6265), "39ccbb514a3949b08b48b74ae5b27b019", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6265), 12, "Project_3", 5.0, new DateTime(2024, 4, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6265), "Payment Detailes For Project_9", 3.0, 0, 209 },
                    { "95ac63b1756a4da59c0796f6cb5337c924", "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6479), "250e21d5b7514e99badd0b75efd52e4f4", 9.0, -63, 23, "Test Description Project_24", "KL-4", new DateTime(2024, 4, 18, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6479), new DateTime(2024, 4, 14, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6479), "d978af407a6e4a7d8775d109c2b36efe24", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6479), 16, "Project_4", 5.0, new DateTime(2024, 4, 19, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6479), "Payment Detailes For Project_12", 4.0, 1, 212 },
                    { "b4a01ee468214a9ba7f279ea48188c6924", "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7037), "db8ff30ad9664722b0ff2c11b9dfe77030", 11.0, -69, 33, "Test Description Project_24", "KL-6", new DateTime(2024, 4, 24, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7037), new DateTime(2024, 4, 18, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7037), "a0f4571106f54ebbb80306d028f1dfbe24", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7037), 24, "Project_6", 5.0, new DateTime(2024, 4, 25, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7037), "Payment Detailes For Project_12", 6.0, 1, 218 },
                    { "bdd732004bd147838166eb96b9ac4da614", "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7187), null, 12.0, -72, 38, "Test Description Project_7", "KL-7", new DateTime(2024, 4, 27, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7187), new DateTime(2024, 4, 20, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7187), "adbb386e991145738107440f198a33497", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7187), 28, "Project_7", 5.0, new DateTime(2024, 4, 28, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7187), "Payment Detailes For Project_7", 7.0, 0, 221 },
                    { "d3625be49a4b45838c90eb52f163610520", "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6657), null, 10.0, -66, 28, "Test Description Project_5", "KL-5", new DateTime(2024, 4, 21, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6657), new DateTime(2024, 4, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6657), "f02773df93b04b5f9fdbb7d48e5325ce15", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6657), 20, "Project_5", 5.0, new DateTime(2024, 4, 22, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6657), "Payment Detailes For Project_25", 5.0, 0, 215 },
                    { "d46ec5d3b5c84f759b0660c14f48125024", "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7396), "ea19ea732058451b99328ae26169d4fa48", 13.0, -75, 43, "Test Description Project_40", "KL-8", new DateTime(2024, 4, 30, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7396), new DateTime(2024, 4, 22, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7396), "16af4f820c8641ea9d8b0db63dc735988", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7396), 32, "Project_8", 5.0, new DateTime(2024, 5, 1, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7396), "Payment Detailes For Project_40", 8.0, 1, 224 },
                    { "f008454064df440ca661fe07d268b9cc0", "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9314), "6954ce88536a4099bfa948c908e94cf00", 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 6, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9314), new DateTime(2024, 4, 6, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9314), "cd381961d4414dd689ed26064f6174320", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9314), 0, "Project_0", 5.0, new DateTime(2024, 4, 7, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9314), "Payment Detailes For Project_0", 0.0, 1, 200 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "134606fb661d450e9a3ed03982cc566c", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7307), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7309), "ae5a22419c3d486cb713f22e9685320d8", "ea19ea732058451b99328ae26169d4fa48" },
                    { "1e9a0590f0d0468285e429d12d232d10", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9395), new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9397), "ae5a22419c3d486cb713f22e9685320d8", "4265411c156049a0af887992143f215f2" },
                    { "3660633bd7db4b9b87e4223aa8dda726", new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1657), new DateTime(2024, 2, 16, 16, 15, 31, 599, DateTimeKind.Local).AddTicks(1659), "ae5a22419c3d486cb713f22e9685320d8", "6954ce88536a4099bfa948c908e94cf00" },
                    { "455abc2607204eb9947d4a63d5315379", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(5997), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(5999), "d69bd6b40d7343eca44dc6cf3b5095f63", "77fdc61739bc40a796ca6d5c5d5118fc4" },
                    { "5169b912f6634693af583c0c5649ed44", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7149), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7150), "d69bd6b40d7343eca44dc6cf3b5095f63", "5fe90d67d062443b8da1dc01b1b769bb7" },
                    { "5a1785acdc124b74a68d90c50a16236e", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9740), new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9742), "d69bd6b40d7343eca44dc6cf3b5095f63", "b180dee3c7fa4d798730e7a49dfc192c6" },
                    { "602add4077d54c44933ba3929959bbcf", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6547), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6549), "ae5a22419c3d486cb713f22e9685320d8", "8290a668526045afb2035f9c265c9fab5" },
                    { "888f3db2e8ef4d098923a16f254d90fe", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6359), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6361), "ae5a22419c3d486cb713f22e9685320d8", "250e21d5b7514e99badd0b75efd52e4f4" },
                    { "aba2c272fcfd4f6781644309ddca0604", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6179), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6180), "ae5a22419c3d486cb713f22e9685320d8", "e0777d0b7a84470298806745537ee6a83" },
                    { "aff445667d264457842562d3d3799bf1", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(5928), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(5929), "ae5a22419c3d486cb713f22e9685320d8", "846f59b1a8664de5bcbdc98bfab24b2f10" },
                    { "b88eddd761a24b959955b6f8949775e9", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9236), new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9238), "d69bd6b40d7343eca44dc6cf3b5095f63", "cfef668022ed4bc8a874cc0992fe83ab0" },
                    { "bd4aeb9d1e624258a0246ab360620fcc", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6223), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6225), "d69bd6b40d7343eca44dc6cf3b5095f63", "a52e403472ae4d7097e9b4e9d19ad94b6" },
                    { "d03f37ce2a614d1da542afb7fd041dd4", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7357), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7358), "d69bd6b40d7343eca44dc6cf3b5095f63", "0b758c30b39b428f84deb20303103e5b48" },
                    { "d451dd6990e74043b4fccc0f5d0e0472", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7103), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7104), "ae5a22419c3d486cb713f22e9685320d8", "469f1aca44a74c8cb084fb9f3dbd9e127" },
                    { "ddefa22fa8c040bd85ad6107fb154939", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6434), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6436), "d69bd6b40d7343eca44dc6cf3b5095f63", "6f774794eea440c7acd5f76095736b2224" },
                    { "f02ea41ec36247768e9d2b90cd8cf204", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6860), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6862), "ae5a22419c3d486cb713f22e9685320d8", "db8ff30ad9664722b0ff2c11b9dfe77030" },
                    { "f243abe2fc77400d88c918e59a94be46", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6940), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6942), "d69bd6b40d7343eca44dc6cf3b5095f63", "0bcfa7ce9eec4a669a8f63d6e42752126" },
                    { "f350625118d04d339451b5c27e8fa0d0", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6594), new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6596), "d69bd6b40d7343eca44dc6cf3b5095f63", "5d41925d76ee4b26a1d9c0038a208f9830" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployee",
                columns: new[] { "Id", "CreatedDate", "EmployeeId", "LastUpdatedDate", "ProjectId" },
                values: new object[,]
                {
                    { "098538174bba408398bf748795c0a6c818", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6305), "a52e403472ae4d7097e9b4e9d19ad94b6", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6307), "8e6d8a06a6c74e9f86da4cb3b480d83b18" },
                    { "7789d8fd6fd54d2092e0f04294dfe49a35", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7257), "5fe90d67d062443b8da1dc01b1b769bb7", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(7258), "bdd732004bd147838166eb96b9ac4da614" },
                    { "9310f3e26fa84881b34e52a2359160282", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9816), "b180dee3c7fa4d798730e7a49dfc192c6", new DateTime(2024, 2, 16, 16, 15, 31, 600, DateTimeKind.Local).AddTicks(9818), "25f03947ca1642638fe21c0ac672f20a4" },
                    { "ed1833c8bea34a5a81fe7b0146e9f61330", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6718), "5d41925d76ee4b26a1d9c0038a208f9830", new DateTime(2024, 2, 16, 16, 15, 31, 602, DateTimeKind.Local).AddTicks(6721), "d3625be49a4b45838c90eb52f163610520" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectEmployee",
                keyColumn: "Id",
                keyValue: "098538174bba408398bf748795c0a6c818");

            migrationBuilder.DeleteData(
                table: "ProjectEmployee",
                keyColumn: "Id",
                keyValue: "7789d8fd6fd54d2092e0f04294dfe49a35");

            migrationBuilder.DeleteData(
                table: "ProjectEmployee",
                keyColumn: "Id",
                keyValue: "9310f3e26fa84881b34e52a2359160282");

            migrationBuilder.DeleteData(
                table: "ProjectEmployee",
                keyColumn: "Id",
                keyValue: "ed1833c8bea34a5a81fe7b0146e9f61330");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "71d650d6dbeb424ea9a62de38dfe8ebe8");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "95ac63b1756a4da59c0796f6cb5337c924");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "b4a01ee468214a9ba7f279ea48188c6924");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "d46ec5d3b5c84f759b0660c14f48125024");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "f008454064df440ca661fe07d268b9cc0");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6ef759a8c2534fe1a7a74f82f6bb43b51");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7a45b1fd0b594822bc35411234807b072");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8c1e3d5544cd4d26b759350d0df433425");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8fedba7fdc124e2780ae994b302d9a966");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "aa667da11b514452b6e9942763da0d074");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "eba98ffc9950444dbcde9283f74386597");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "134606fb661d450e9a3ed03982cc566c");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "1e9a0590f0d0468285e429d12d232d10");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "3660633bd7db4b9b87e4223aa8dda726");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "455abc2607204eb9947d4a63d5315379");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "5169b912f6634693af583c0c5649ed44");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "5a1785acdc124b74a68d90c50a16236e");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "602add4077d54c44933ba3929959bbcf");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "888f3db2e8ef4d098923a16f254d90fe");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "aba2c272fcfd4f6781644309ddca0604");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "aff445667d264457842562d3d3799bf1");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "b88eddd761a24b959955b6f8949775e9");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "bd4aeb9d1e624258a0246ab360620fcc");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "d03f37ce2a614d1da542afb7fd041dd4");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "d451dd6990e74043b4fccc0f5d0e0472");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "ddefa22fa8c040bd85ad6107fb154939");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "f02ea41ec36247768e9d2b90cd8cf204");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "f243abe2fc77400d88c918e59a94be46");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: "f350625118d04d339451b5c27e8fa0d0");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "16af4f820c8641ea9d8b0db63dc735988");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "246095b27d024b4aaa1437f6f2373c896");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "a0f4571106f54ebbb80306d028f1dfbe24");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "cd381961d4414dd689ed26064f6174320");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "d978af407a6e4a7d8775d109c2b36efe24");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25f03947ca1642638fe21c0ac672f20a4");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "8e6d8a06a6c74e9f86da4cb3b480d83b18");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "bdd732004bd147838166eb96b9ac4da614");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "d3625be49a4b45838c90eb52f163610520");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ae5a22419c3d486cb713f22e9685320d8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d69bd6b40d7343eca44dc6cf3b5095f63");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0b758c30b39b428f84deb20303103e5b48");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "0bcfa7ce9eec4a669a8f63d6e42752126");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "250e21d5b7514e99badd0b75efd52e4f4");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4265411c156049a0af887992143f215f2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "469f1aca44a74c8cb084fb9f3dbd9e127");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5d41925d76ee4b26a1d9c0038a208f9830");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5fe90d67d062443b8da1dc01b1b769bb7");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6954ce88536a4099bfa948c908e94cf00");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6f774794eea440c7acd5f76095736b2224");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "77fdc61739bc40a796ca6d5c5d5118fc4");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8290a668526045afb2035f9c265c9fab5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "846f59b1a8664de5bcbdc98bfab24b2f10");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a52e403472ae4d7097e9b4e9d19ad94b6");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b180dee3c7fa4d798730e7a49dfc192c6");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cfef668022ed4bc8a874cc0992fe83ab0");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "db8ff30ad9664722b0ff2c11b9dfe77030");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e0777d0b7a84470298806745537ee6a83");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "ea19ea732058451b99328ae26169d4fa48");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "39ccbb514a3949b08b48b74ae5b27b019");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "86c24b4a2db6406f9f49cb3b70fc458f5");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "adbb386e991145738107440f198a33497");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "f02773df93b04b5f9fdbb7d48e5325ce15");

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { "0183f142f9394ceeaff3682507fbbc1225", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7557), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7560), 103000.0, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7559), "Signature 142345", 78418, null, 5.0, 17.0 },
                    { "1f9dbdb56c8e42dbbcf7d071c012f8d718", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7339), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7341), 4000.0, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7340), "Signature 1423412", 58489, null, 3.0, 17.0 },
                    { "5498e196998a4be78abc67b09f1560bc16", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7904), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7906), 100003000.0, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7905), "Signature 1423416", 20940, null, 8.0, 24.0 },
                    { "75319d6811f74e3a8eb663e5685538ab6", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1530), new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1533), 3010.0, new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1532), "Signature 142345", 26717, null, 1.0, 17.0 },
                    { "93416e719808414a9e07f8a1ab7609686", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7694), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7697), 1003000.0, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7696), "Signature 1423424", 66598, null, 6.0, 24.0 },
                    { "c0188ac33b4242bc9583d4e5057fe4ac0", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1366), new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1371), 3001.0, new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1369), "Signature 142340", 54623, null, 0.0, 24.0 },
                    { "c86130e1dceb487aa349b1897972949642", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7774), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7776), 10003000.0, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7775), "Signature 1423421", 76739, null, 7.0, 17.0 },
                    { "eaec53673e4a42338d204b25e19571af2", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7192), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7195), 3100.0, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7194), "Signature 142348", 70554, null, 2.0, 24.0 },
                    { "f45eb3e03ac941c1acdf5f03e1b1972b16", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7461), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7464), 13000.0, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7463), "Signature 142344", 70511, null, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { "044504834bc84990952a504492137dad4", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6340), new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6342), "COO" },
                    { "199cff7579c441759e9d5f302e7653982", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6331), new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6333), "Engineers" },
                    { "1f0214cc3aa24defb53943da5ebae1ca5", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6344), new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6346), "CTO" },
                    { "34c451ab47e84ea7829898620e3311cd7", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6353), new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6355), "Guest" },
                    { "51eaf6c4be074d20ae35a2a0c649042c8", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6357), new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6359), "Customer" },
                    { "67914ad2d834457db47aa56110ed40736", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6349), new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6350), "CEO" },
                    { "8797d29f91074dc18807d2021332a0d31", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6280), new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6327), "Draftsmen" },
                    { "e08a94595b9741febc3d7698225f45833", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6336), new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6338), "Project Managers" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { "0531045becd74b80aceae99f39a7e3a818", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7252), "Test Description Client 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7253), null, "6949277783", null, null, null },
                    { "062f3450d21e44b6b19eebb3c4b9cd3120", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7519), "Test Description Employee 7", "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7520), null, "6949277787", null, null, null },
                    { "1fb3db35af094a4ab20dff2b358b48da4", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1503), "Test Description Employee 3", "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1505), null, "6949277783", null, null, null },
                    { "3e56537ac23a47c5af18886e77be13b510", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7492), "Test Description Client 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7494), null, "6949277785", null, null, null },
                    { "409953d966714a61a00a1e3cfaaead388", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7132), "Test Description Employee 4", "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7134), null, "6949277784", null, null, null },
                    { "42a2ac582a19415489879364f0b027f316", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7382), "Test Description Client 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7384), null, "6949277784", null, null, null },
                    { "472c8df2ec964fa8b5f0767373f1b1f52", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7013), "Test Description Client 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7039), null, "6949277782", null, null, null },
                    { "57a76c4e892e47fe83ea629bb25db7b140", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7878), "Test Description Employee 10", "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7879), null, "69492777810", null, null, null },
                    { "580ae02d42294dab809cc7a937986d467", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7726), "Test Description Client 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7727), null, "6949277787", null, null, null },
                    { "7b346e68b33f4556a8da5a2ceb9e1eba6", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1469), "Test Description Client 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1471), null, "6949277781", null, null, null },
                    { "83fb1a217d174f1bad3496b382bf6d9d0", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1129), "Test Description Employee 2", "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1173), null, "6949277782", null, null, null },
                    { "8ade01f19db74764b2447ac0e66eaee730", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7647), "Test Description Employee 8", "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7648), null, "6949277788", null, null, null },
                    { "909b76febf0c4abe9a9e62522737769635", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7750), "Test Description Employee 9", "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7751), null, "6949277789", null, null, null },
                    { "a530fa25ea7547d8b869f43bc0de87718", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7411), "Test Description Employee 6", "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7413), null, "6949277786", null, null, null },
                    { "ad943df8ec214497844658f517dc1de40", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6487), "Test Description Client 0", "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6489), null, "6949277780", null, null, null },
                    { "bfa82f3c9a42476c9d5c73a7c18168e312", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7289), "Test Description Employee 5", "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7290), null, "6949277785", null, null, null },
                    { "e0e4b13e78b745039fd54cab988f5f2a6", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7597), "Test Description Client 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7598), null, "6949277786", null, null, null },
                    { "e439e5c9aae64cdfb58e834370f2e1fb8", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7813), "Test Description Client 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7815), null, "6949277788", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "CustomerId", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "InvoiceId", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "PlanType", "WorkingDays" },
                values: new object[,]
                {
                    { "0586586a5e334df198c7df759897c0a16", "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1576), null, 6.0, -54, 8, "Test Description Project_1", "KL-1", new DateTime(2024, 4, 7, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1576), new DateTime(2024, 4, 6, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1576), "75319d6811f74e3a8eb663e5685538ab6", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1576), 4, "Project_1", 5.0, new DateTime(2024, 4, 8, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1576), "Payment Detailes For Project_5", 1.0, 0, 203 },
                    { "18c421622fb149a08e9932f6c5b20ee420", "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7572), null, 10.0, -66, 28, "Test Description Project_25", "KL-5", new DateTime(2024, 4, 19, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7572), new DateTime(2024, 4, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7572), "0183f142f9394ceeaff3682507fbbc1225", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7572), 20, "Project_5", 5.0, new DateTime(2024, 4, 20, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7572), "Payment Detailes For Project_20", 5.0, 0, 215 },
                    { "51564267688a4dacad0946efda85efbf42", "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7787), null, 12.0, -72, 38, "Test Description Project_28", "KL-7", new DateTime(2024, 4, 25, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7787), new DateTime(2024, 4, 18, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7787), "c86130e1dceb487aa349b1897972949642", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7787), 28, "Project_7", 5.0, new DateTime(2024, 4, 26, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7787), "Payment Detailes For Project_35", 7.0, 0, 221 },
                    { "59d8d6ca953949579831c4abd7e200588", "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7918), "e439e5c9aae64cdfb58e834370f2e1fb8", 13.0, -75, 43, "Test Description Project_32", "KL-8", new DateTime(2024, 4, 28, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7918), new DateTime(2024, 4, 20, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7918), "5498e196998a4be78abc67b09f1560bc16", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7918), 32, "Project_8", 5.0, new DateTime(2024, 4, 29, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7918), "Payment Detailes For Project_48", 8.0, 1, 224 },
                    { "6a8323232feb4cb38a8afae729e6efc320", "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7477), "42a2ac582a19415489879364f0b027f316", 9.0, -63, 23, "Test Description Project_12", "KL-4", new DateTime(2024, 4, 16, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7477), new DateTime(2024, 4, 12, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7477), "f45eb3e03ac941c1acdf5f03e1b1972b16", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7477), 16, "Project_4", 5.0, new DateTime(2024, 4, 17, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7477), "Payment Detailes For Project_8", 4.0, 1, 212 },
                    { "b2f2e031026e404e94c786c3caf7690430", "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7711), "e0e4b13e78b745039fd54cab988f5f2a6", 11.0, -69, 33, "Test Description Project_30", "KL-6", new DateTime(2024, 4, 22, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7711), new DateTime(2024, 4, 16, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7711), "93416e719808414a9e07f8a1ab7609686", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7711), 24, "Project_6", 5.0, new DateTime(2024, 4, 23, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7711), "Payment Detailes For Project_36", 6.0, 1, 218 },
                    { "c651ede0301f47e7b604093deb79806412", "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7354), null, 8.0, -60, 18, "Test Description Project_3", "KL-3", new DateTime(2024, 4, 13, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7354), new DateTime(2024, 4, 10, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7354), "1f9dbdb56c8e42dbbcf7d071c012f8d718", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7354), 12, "Project_3", 5.0, new DateTime(2024, 4, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7354), "Payment Detailes For Project_6", 3.0, 0, 209 },
                    { "d07f6517e84c4b03bae7c52c5f43d0282", "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7228), "472c8df2ec964fa8b5f0767373f1b1f52", 7.0, -57, 13, "Test Description Project_12", "KL-2", new DateTime(2024, 4, 10, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7228), new DateTime(2024, 4, 8, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7228), "eaec53673e4a42338d204b25e19571af2", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7228), 8, "Project_2", 5.0, new DateTime(2024, 4, 11, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7228), "Payment Detailes For Project_2", 2.0, 1, 206 },
                    { "dcb24617c90f4dea87b64a9e9d4d4b280", "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1429), "ad943df8ec214497844658f517dc1de40", 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 4, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1429), new DateTime(2024, 4, 4, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1429), "c0188ac33b4242bc9583d4e5057fe4ac0", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1429), 0, "Project_0", 5.0, new DateTime(2024, 4, 5, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1429), "Payment Detailes For Project_0", 0.0, 1, 200 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0a45946825554831852575be65105dad", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7865), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7867), "51eaf6c4be074d20ae35a2a0c649042c8", "e439e5c9aae64cdfb58e834370f2e1fb8" },
                    { "28c5e934b1f64622a94c4ec3238364ae", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7177), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7179), "67914ad2d834457db47aa56110ed40736", "409953d966714a61a00a1e3cfaaead388" },
                    { "28c5ed9bfa4742d6b5b5b1bd680a36fa", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7327), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7328), "67914ad2d834457db47aa56110ed40736", "bfa82f3c9a42476c9d5c73a7c18168e312" },
                    { "4b37f04337ce474fad761d9b2a55d56a", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7450), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7451), "1f0214cc3aa24defb53943da5ebae1ca5", "a530fa25ea7547d8b869f43bc0de87718" },
                    { "666e54b5de5b4cda9e11e6f8d6dde8ed", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7545), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7546), "044504834bc84990952a504492137dad4", "062f3450d21e44b6b19eebb3c4b9cd3120" },
                    { "7613f30ec6dc49d9838e1d03685eaa25", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1316), new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1320), "199cff7579c441759e9d5f302e7653982", "83fb1a217d174f1bad3496b382bf6d9d0" },
                    { "8ac8b50f4db34944bc238f92a1882124", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7610), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7612), "51eaf6c4be074d20ae35a2a0c649042c8", "e0e4b13e78b745039fd54cab988f5f2a6" },
                    { "8e54827ee84f441a88e015afcf33912c", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7114), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7116), "51eaf6c4be074d20ae35a2a0c649042c8", "472c8df2ec964fa8b5f0767373f1b1f52" },
                    { "9257216f45b34eac83f60778d7e628ee", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7661), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7662), "e08a94595b9741febc3d7698225f45833", "8ade01f19db74764b2447ac0e66eaee730" },
                    { "9f1475cb25034420a1e38196b4854389", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1489), new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1491), "51eaf6c4be074d20ae35a2a0c649042c8", "7b346e68b33f4556a8da5a2ceb9e1eba6" },
                    { "c24237847fb848ba815484870b7b62be", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7763), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7765), "199cff7579c441759e9d5f302e7653982", "909b76febf0c4abe9a9e62522737769635" },
                    { "c3570a681cad4213a016d6647ba8efb0", new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6565), new DateTime(2024, 2, 14, 17, 1, 56, 747, DateTimeKind.Local).AddTicks(6567), "51eaf6c4be074d20ae35a2a0c649042c8", "ad943df8ec214497844658f517dc1de40" },
                    { "c445380836bd4708ba5f4ea2504c47e2", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7397), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7398), "51eaf6c4be074d20ae35a2a0c649042c8", "42a2ac582a19415489879364f0b027f316" },
                    { "c9624166dbaa491595ab55a4046b0c97", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7739), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7740), "51eaf6c4be074d20ae35a2a0c649042c8", "580ae02d42294dab809cc7a937986d467" },
                    { "cf044f966b9a4632be0d042dee485bd0", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7506), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7508), "51eaf6c4be074d20ae35a2a0c649042c8", "3e56537ac23a47c5af18886e77be13b510" },
                    { "d872bd6540114461b8b308e958fea9ef", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1518), new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1520), "e08a94595b9741febc3d7698225f45833", "1fb3db35af094a4ab20dff2b358b48da4" },
                    { "ea75e7f611544ab5b4b256d2a79f318b", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7277), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7278), "51eaf6c4be074d20ae35a2a0c649042c8", "0531045becd74b80aceae99f39a7e3a818" },
                    { "fa2a0b9350c24af692d4e6d7245a601e", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7893), new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7895), "044504834bc84990952a504492137dad4", "57a76c4e892e47fe83ea629bb25db7b140" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployee",
                columns: new[] { "Id", "CreatedDate", "EmployeeId", "LastUpdatedDate", "ProjectId" },
                values: new object[,]
                {
                    { "0570df552f424cacbf5bd3c6bc1837cb2", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1596), "1fb3db35af094a4ab20dff2b358b48da4", new DateTime(2024, 2, 14, 17, 1, 56, 750, DateTimeKind.Local).AddTicks(1598), "0586586a5e334df198c7df759897c0a16" },
                    { "743722ad5a2643cabb9ac83d0a3e56ad25", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7586), "062f3450d21e44b6b19eebb3c4b9cd3120", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7587), "18c421622fb149a08e9932f6c5b20ee420" },
                    { "8d07aa4fe6474ea893964d2127ec12e814", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7800), "909b76febf0c4abe9a9e62522737769635", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7802), "51564267688a4dacad0946efda85efbf42" },
                    { "c671262517da41ec94bf7792399b66bd3", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7370), "bfa82f3c9a42476c9d5c73a7c18168e312", new DateTime(2024, 2, 14, 17, 1, 56, 751, DateTimeKind.Local).AddTicks(7371), "c651ede0301f47e7b604093deb79806412" }
                });
        }
    }
}
