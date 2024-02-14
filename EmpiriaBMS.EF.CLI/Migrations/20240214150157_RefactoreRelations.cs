using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpiriaBMS.EF.CLI.Migrations
{
    public partial class RefactoreRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "1423410");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142342");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142343");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25460");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25461");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25462");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25463");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25464");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25465");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25466");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25467");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25468");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25469");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142344");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142345");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142346");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142347");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142348");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142349");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Completed",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<double>(type: "float", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_EmployeeId",
                table: "ProjectEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_ProjectId",
                table: "ProjectEmployee",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CustomerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectEmployee");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects");

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

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Invoices");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Completed",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    EmployeesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => new { x.EmployeesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_EmployeeRole_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3" },
                values: new object[,]
                {
                    { "142340", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5949), "Test Description Client 0", "alexpl_0@gmail.com", "Platanios_Customer_0", "Alexandros_0", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5951), null, "6949277780", null, null },
                    { "142341", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6032), "Test Description Client 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6034), null, "6949277781", null, null },
                    { "142342", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6066), "Test Description Client 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6067), null, "6949277782", null, null },
                    { "142343", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6100), "Test Description Client 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6101), null, "6949277783", null, null },
                    { "142344", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6165), "Test Description Client 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6166), null, "6949277784", null, null },
                    { "142345", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6204), "Test Description Client 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6205), null, "6949277785", null, null },
                    { "142346", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6236), "Test Description Client 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6237), null, "6949277786", null, null },
                    { "142347", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6266), "Test Description Client 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6267), null, "6949277787", null, null },
                    { "142348", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6319), "Test Description Client 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6320), null, "6949277788", null, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3" },
                values: new object[,]
                {
                    { "1423410", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6332), "Test Description Employee 10", "alexpl_10@gmail.com", "Platanios_Employee_10", 800000008.0, "Alexandros_10", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6333), null, "69492777810", null, null },
                    { "142342", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5986), "Test Description Employee 2", "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5987), null, "6949277782", null, null },
                    { "142343", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6043), "Test Description Employee 3", "alexpl_3@gmail.com", "Platanios_Employee_3", 11.0, "Alexandros_3", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6045), null, "6949277783", null, null },
                    { "142344", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6075), "Test Description Employee 4", "alexpl_4@gmail.com", "Platanios_Employee_4", 202.0, "Alexandros_4", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6077), null, "6949277784", null, null },
                    { "142345", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6110), "Test Description Employee 5", "alexpl_5@gmail.com", "Platanios_Employee_5", 3003.0, "Alexandros_5", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6111), null, "6949277785", null, null },
                    { "142346", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6179), "Test Description Employee 6", "alexpl_6@gmail.com", "Platanios_Employee_6", 40004.0, "Alexandros_6", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6180), null, "6949277786", null, null },
                    { "142347", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6214), "Test Description Employee 7", "alexpl_7@gmail.com", "Platanios_Employee_7", 500005.0, "Alexandros_7", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6215), null, "6949277787", null, null },
                    { "142348", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6246), "Test Description Employee 8", "alexpl_8@gmail.com", "Platanios_Employee_8", 6000006.0, "Alexandros_8", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6247), null, "6949277788", null, null },
                    { "142349", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6275), "Test Description Employee 9", "alexpl_9@gmail.com", "Platanios_Employee_9", 70000007.0, "Alexandros_9", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6277), null, "6949277789", null, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "Total", "Vat" },
                values: new object[,]
                {
                    { "1423410", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6347), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100003000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6348), "Signature 1423410", 36614, 8.0, 24.0 },
                    { "142342", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3001.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6015), "Signature 142342", 76040, 0.0, 24.0 },
                    { "142343", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6055), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3010.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6056), "Signature 142343", 45166, 1.0, 17.0 },
                    { "142344", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6089), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3100.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6090), "Signature 142344", 49875, 2.0, 24.0 },
                    { "142345", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6154), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6155), "Signature 142345", 31259, 3.0, 17.0 },
                    { "142346", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6193), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6194), "Signature 142346", 55311, 4.0, 24.0 },
                    { "142347", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6226), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6227), "Signature 142347", 89217, 5.0, 17.0 },
                    { "142348", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6256), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1003000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6257), "Signature 142348", 67400, 6.0, 24.0 },
                    { "142349", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6286), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10003000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6288), "Signature 142349", 48507, 7.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { "1", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5768), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5810), "Draftsmen" },
                    { "2", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5815), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5817), "Engineers" },
                    { "3", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5819), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5820), "Project Managers" },
                    { "4", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5822), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5823), "COO" },
                    { "5", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5825), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5826), "CTO" },
                    { "6", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5827), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5828), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "CustomerId", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "InvoiceId", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "PlanType", "WorkingDays" },
                values: new object[,]
                {
                    { "25460", "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), "142347", 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 2, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), new DateTime(2024, 4, 2, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), null, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), 0, "Project_0", 5.0, new DateTime(2024, 4, 3, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), "Payment Detailes For Project_0", 0.0, 1, 200 },
                    { "25461", "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), "142343", 6.0, -54, 8, "Test Description Project_1", "KL-1", new DateTime(2024, 4, 5, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), new DateTime(2024, 4, 4, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), null, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), 8, "Project_1", 5.0, new DateTime(2024, 4, 6, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), "Payment Detailes For Project_1", 1.0, 0, 203 },
                    { "25462", "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), "142341", 7.0, -57, 13, "Test Description Project_2", "KL-2", new DateTime(2024, 4, 8, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), new DateTime(2024, 4, 6, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), "142344", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), 32, "Project_2", 5.0, new DateTime(2024, 4, 9, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), "Payment Detailes For Project_2", 2.0, 1, 206 },
                    { "25463", "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), "142347", 8.0, -60, 18, "Test Description Project_3", "KL-3", new DateTime(2024, 4, 11, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), new DateTime(2024, 4, 8, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), "142345", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), 72, "Project_3", 5.0, new DateTime(2024, 4, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), "Payment Detailes For Project_3", 3.0, 0, 209 },
                    { "25464", "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), "142341", 9.0, -63, 23, "Test Description Project_4", "KL-4", new DateTime(2024, 4, 14, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), new DateTime(2024, 4, 10, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), null, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), 128, "Project_4", 5.0, new DateTime(2024, 4, 15, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), "Payment Detailes For Project_4", 4.0, 1, 212 },
                    { "25465", "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), "142343", 10.0, -66, 28, "Test Description Project_5", "KL-5", new DateTime(2024, 4, 17, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), new DateTime(2024, 4, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), "142346", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), 200, "Project_5", 5.0, new DateTime(2024, 4, 18, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), "Payment Detailes For Project_5", 5.0, 0, 215 },
                    { "25466", "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), "142343", 11.0, -69, 33, "Test Description Project_6", "KL-6", new DateTime(2024, 4, 20, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), new DateTime(2024, 4, 14, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), null, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), 288, "Project_6", 5.0, new DateTime(2024, 4, 21, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), "Payment Detailes For Project_6", 6.0, 1, 218 },
                    { "25467", "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), "142345", 12.0, -72, 38, "Test Description Project_7", "KL-7", new DateTime(2024, 4, 23, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), new DateTime(2024, 4, 16, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), "142349", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), 392, "Project_7", 5.0, new DateTime(2024, 4, 24, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), "Payment Detailes For Project_7", 7.0, 0, 221 },
                    { "25468", "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), "142345", 13.0, -75, 43, "Test Description Project_8", "KL-8", new DateTime(2024, 4, 26, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), new DateTime(2024, 4, 18, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), "142347", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), 512, "Project_8", 5.0, new DateTime(2024, 4, 27, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), "Payment Detailes For Project_8", 8.0, 1, 224 },
                    { "25469", "NBG_IBANK", 1, "D-22-169", 90, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), "142341", 14.0, -78, 48, "Test Description Project_9", "KL-9", new DateTime(2024, 4, 29, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), new DateTime(2024, 4, 20, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), "142348", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), 648, "Project_9", 5.0, new DateTime(2024, 4, 30, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), "Payment Detailes For Project_9", 9.0, 0, 227 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsId",
                table: "EmployeeProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_RolesId",
                table: "EmployeeRole",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
