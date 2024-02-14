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
                    { "15dd7f1d03644ef6b360988f1af57b0e0", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4731), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3001.0, new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4733), "Signature 142340", 66944, null, 0.0, 24.0 },
                    { "5137cd724f344bde9f5c64c02f799bcb12", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8814), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4000.0, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8815), "Signature 1423415", 36030, null, 3.0, 17.0 },
                    { "517f07b05efd4bc99be8e357dd3602b815", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9025), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103000.0, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9027), "Signature 1423420", 42760, null, 5.0, 17.0 },
                    { "5774428bb08340b69fd0986b4aaa88574", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8660), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3100.0, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8662), "Signature 1423410", 11741, null, 2.0, 24.0 },
                    { "9fc86101f26d4da3b67a18ddcac9632d21", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9241), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10003000.0, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9242), "Signature 1423435", 54343, null, 7.0, 17.0 },
                    { "ad90f2110a2640aaa2665e2736f63d794", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4861), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3010.0, new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4862), "Signature 142343", 12306, null, 1.0, 17.0 },
                    { "b832c99d26bb46c6a55e8e2ab63f711218", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9139), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1003000.0, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9141), "Signature 1423436", 28154, null, 6.0, 24.0 },
                    { "c0e18213870843b2997c84c71582b36024", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8909), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13000.0, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8910), "Signature 1423420", 68872, null, 4.0, 24.0 },
                    { "f69de571cc2f45e6aeb3af326af7ac3e8", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9356), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100003000.0, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9358), "Signature 1423440", 68175, null, 8.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { "25454319af094a1789c5cba7b941eff52", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8532), new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8533), "Engineers" },
                    { "405967561a5b4f69b1b2081197d440978", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8551), new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8552), "Customer" },
                    { "5f6436bcd1a04d7a9396a357de46ede44", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8538), new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8539), "COO" },
                    { "6986138359c844e18784e8d50af63f095", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8541), new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8543), "CTO" },
                    { "75b56dab6c684255adc042bd3fbf9ddc6", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8544), new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8546), "CEO" },
                    { "86f906d6397c4316bdc4bf86618034071", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8490), new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8529), "Draftsmen" },
                    { "9759edecf3ba410a91fc51006b7c96d97", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8548), new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8549), "Guest" },
                    { "f8fc14df442a40e2939220c33753a2173", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8535), new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8536), "Project Managers" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { "02dd7b18c61c4054bca678b0a5d99d1e2", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8630), "Test Description Employee 4", "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8631), null, "6949277784", null, null, null },
                    { "05725b0ca22b41b7b5c6c41b60180cdd6", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4806), "Test Description Client 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4807), null, "6949277781", null, null, null },
                    { "15cb24f7122845638a9a5bc3989d827d35", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9217), "Test Description Employee 9", "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9218), null, "6949277789", null, null, null },
                    { "1976b05bf1b4419c97b589185f402a3f9", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8714), "Test Description Client 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8716), null, "6949277783", null, null, null },
                    { "2a1c5437a0d8465fa7359c97c1bf0ee348", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9278), "Test Description Client 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9280), null, "6949277788", null, null, null },
                    { "43fd666581044b659918e6a7b3bd2b6925", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8987), "Test Description Employee 7", "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8989), null, "6949277787", null, null, null },
                    { "4c15ffc0aefb4030943de3c8535e063e10", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8526), "Test Description Client 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8540), null, "6949277782", null, null, null },
                    { "528a782cc2f94bf1ad316d3d74de26ac4", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8856), "Test Description Client 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8858), null, "6949277784", null, null, null },
                    { "6f15941d4cea48c5a085edc24bd03f5615", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8767), "Test Description Employee 5", "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8768), null, "6949277785", null, null, null },
                    { "7e17222e86ce488d9c9ce6983d147bf624", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9067), "Test Description Client 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9069), null, "6949277786", null, null, null },
                    { "9b877c06d0554980ae4e0a814ad57ba76", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4836), "Test Description Employee 3", "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4837), null, "6949277783", null, null, null },
                    { "abb138184fc147a8893a4a5bb22b3cbc0", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4591), "Test Description Employee 2", "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4622), null, "6949277782", null, null, null },
                    { "b2a9ac6a4c2a4d41811cf3989f674d5210", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8961), "Test Description Client 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8963), null, "6949277785", null, null, null },
                    { "b7316bd5c98f41c9beba92409130faaa16", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8882), "Test Description Employee 6", "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8884), null, "6949277786", null, null, null },
                    { "bd227fed9fe24c6b9c77444dc2451ac542", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9190), "Test Description Client 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9191), null, "6949277787", null, null, null },
                    { "cc2c38b5d8844cf695519dd51f0fb0b724", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9305), "Test Description Employee 10", "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9307), null, "69492777810", null, null, null },
                    { "cc71da774225492093e3cc418569f1a524", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9090), "Test Description Employee 8", "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9092), null, "6949277788", null, null, null },
                    { "de89925234214a54a36f510dd7720c9c0", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8663), "Test Description Client 0", "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8665), null, "6949277780", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "CustomerId", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "InvoiceId", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "PlanType", "WorkingDays" },
                values: new object[,]
                {
                    { "1b54dcbe96c64361a718956eccef080a1", "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4874), null, 6.0, -54, 8, "Test Description Project_4", "KL-1", new DateTime(2024, 4, 7, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4874), new DateTime(2024, 4, 6, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4874), "ad90f2110a2640aaa2665e2736f63d794", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4874), 4, "Project_1", 5.0, new DateTime(2024, 4, 8, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4874), "Payment Detailes For Project_4", 1.0, 0, 203 },
                    { "4bb547b87ba842f18602ad0b8e6d7f986", "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8827), null, 8.0, -60, 18, "Test Description Project_6", "KL-3", new DateTime(2024, 4, 13, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8827), new DateTime(2024, 4, 10, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8827), "5137cd724f344bde9f5c64c02f799bcb12", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8827), 12, "Project_3", 5.0, new DateTime(2024, 4, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8827), "Payment Detailes For Project_18", 3.0, 0, 209 },
                    { "561e9a21b8744191b4a1233251c54a410", "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4765), "de89925234214a54a36f510dd7720c9c0", 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 4, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4765), new DateTime(2024, 4, 4, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4765), "15dd7f1d03644ef6b360988f1af57b0e0", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4765), 0, "Project_0", 5.0, new DateTime(2024, 4, 5, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4765), "Payment Detailes For Project_0", 0.0, 1, 200 },
                    { "61b9b2df246249d5b2b3aee91b1e20c424", "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9174), "7e17222e86ce488d9c9ce6983d147bf624", 11.0, -69, 33, "Test Description Project_24", "KL-6", new DateTime(2024, 4, 22, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9174), new DateTime(2024, 4, 16, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9174), "b832c99d26bb46c6a55e8e2ab63f711218", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9174), 24, "Project_6", 5.0, new DateTime(2024, 4, 23, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9174), "Payment Detailes For Project_12", 6.0, 1, 218 },
                    { "88762e4f800c469bb1358456d17031f830", "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9039), null, 10.0, -66, 28, "Test Description Project_5", "KL-5", new DateTime(2024, 4, 19, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9039), new DateTime(2024, 4, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9039), "517f07b05efd4bc99be8e357dd3602b815", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9039), 20, "Project_5", 5.0, new DateTime(2024, 4, 20, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9039), "Payment Detailes For Project_30", 5.0, 0, 215 },
                    { "aa2a3ea203ba45739f63cf507baf4ac720", "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8924), "528a782cc2f94bf1ad316d3d74de26ac4", 9.0, -63, 23, "Test Description Project_24", "KL-4", new DateTime(2024, 4, 16, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8924), new DateTime(2024, 4, 12, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8924), "c0e18213870843b2997c84c71582b36024", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8924), 16, "Project_4", 5.0, new DateTime(2024, 4, 17, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8924), "Payment Detailes For Project_20", 4.0, 1, 212 },
                    { "ae34fef437944246aa0ea1ea00ce14ac28", "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9253), null, 12.0, -72, 38, "Test Description Project_28", "KL-7", new DateTime(2024, 4, 25, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9253), new DateTime(2024, 4, 18, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9253), "9fc86101f26d4da3b67a18ddcac9632d21", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9253), 28, "Project_7", 5.0, new DateTime(2024, 4, 26, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9253), "Payment Detailes For Project_35", 7.0, 0, 221 },
                    { "bb896a1d6d3f48e8821115afdca806604", "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8686), "4c15ffc0aefb4030943de3c8535e063e10", 7.0, -57, 13, "Test Description Project_6", "KL-2", new DateTime(2024, 4, 10, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8686), new DateTime(2024, 4, 8, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8686), "5774428bb08340b69fd0986b4aaa88574", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8686), 8, "Project_2", 5.0, new DateTime(2024, 4, 11, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8686), "Payment Detailes For Project_10", 2.0, 1, 206 },
                    { "cb1453d8cef64f41be885f6b1aff39b240", "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9370), "2a1c5437a0d8465fa7359c97c1bf0ee348", 13.0, -75, 43, "Test Description Project_8", "KL-8", new DateTime(2024, 4, 28, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9370), new DateTime(2024, 4, 20, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9370), "f69de571cc2f45e6aeb3af326af7ac3e8", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9370), 32, "Project_8", 5.0, new DateTime(2024, 4, 29, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9370), "Payment Detailes For Project_48", 8.0, 1, 224 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0a31dc2ca9c54eafbb7cd283923c2175", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8755), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8757), "405967561a5b4f69b1b2081197d440978", "1976b05bf1b4419c97b589185f402a3f9" },
                    { "2f72054d8645432885a2951ad741ab8f", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8871), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8872), "405967561a5b4f69b1b2081197d440978", "528a782cc2f94bf1ad316d3d74de26ac4" },
                    { "42449c252d594868a73ba0332165778d", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9230), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9231), "6986138359c844e18784e8d50af63f095", "15cb24f7122845638a9a5bc3989d827d35" },
                    { "47b57f67ae8e44bfaa4cee78547d9d53", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9292), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9294), "405967561a5b4f69b1b2081197d440978", "2a1c5437a0d8465fa7359c97c1bf0ee348" },
                    { "5316ee87520f4fbfbad7e1ef123007b3", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4714), new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4716), "25454319af094a1789c5cba7b941eff52", "abb138184fc147a8893a4a5bb22b3cbc0" },
                    { "577ce51086c84b99a455d0d1a68d576a", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9206), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9207), "405967561a5b4f69b1b2081197d440978", "bd227fed9fe24c6b9c77444dc2451ac542" },
                    { "61964f8170504e8096dcb3d0bb7ca7cc", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4849), new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4851), "25454319af094a1789c5cba7b941eff52", "9b877c06d0554980ae4e0a814ad57ba76" },
                    { "6dfb4699bd78429aa20c943255afe0be", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9080), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9082), "405967561a5b4f69b1b2081197d440978", "7e17222e86ce488d9c9ce6983d147bf624" },
                    { "98778000406a4fc79a3c1ffcbbf1d58b", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9103), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9105), "f8fc14df442a40e2939220c33753a2173", "cc71da774225492093e3cc418569f1a524" },
                    { "9927ca4774c846e6bbec683bf4554907", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4824), new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4825), "405967561a5b4f69b1b2081197d440978", "05725b0ca22b41b7b5c6c41b60180cdd6" },
                    { "a15c84eae92f4086b6066a831e0afda1", new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8722), new DateTime(2024, 2, 14, 15, 48, 45, 990, DateTimeKind.Local).AddTicks(8724), "405967561a5b4f69b1b2081197d440978", "de89925234214a54a36f510dd7720c9c0" },
                    { "abe5f54cf25848f8a546dcaecbacceac", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8976), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8977), "405967561a5b4f69b1b2081197d440978", "b2a9ac6a4c2a4d41811cf3989f674d5210" },
                    { "b285fe59e3ac40bab29d5d8db0111559", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8647), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8649), "6986138359c844e18784e8d50af63f095", "02dd7b18c61c4054bca678b0a5d99d1e2" },
                    { "c61d61b9adb94f17b11720e519b7abff", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8803), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8804), "6986138359c844e18784e8d50af63f095", "6f15941d4cea48c5a085edc24bd03f5615" },
                    { "d01f1c1805c74762852e619618b4dc5c", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9015), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9016), "5f6436bcd1a04d7a9396a357de46ede44", "43fd666581044b659918e6a7b3bd2b6925" },
                    { "eb1cb229248a4baba93a32206696b2f1", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9343), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9345), "5f6436bcd1a04d7a9396a357de46ede44", "cc2c38b5d8844cf695519dd51f0fb0b724" },
                    { "fcf840375af8420cb780c814fb9a8084", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8896), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8897), "6986138359c844e18784e8d50af63f095", "b7316bd5c98f41c9beba92409130faaa16" },
                    { "fe4fdcfcba964e7391488f2ec301c973", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8612), new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8613), "405967561a5b4f69b1b2081197d440978", "4c15ffc0aefb4030943de3c8535e063e10" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployee",
                columns: new[] { "Id", "CreatedDate", "EmployeeId", "LastUpdatedDate", "ProjectId" },
                values: new object[,]
                {
                    { "126d2e1f4b354eafac528948b7b27aeb42", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9267), "15cb24f7122845638a9a5bc3989d827d35", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9268), "ae34fef437944246aa0ea1ea00ce14ac28" },
                    { "1d594772bf38497e8526e2542eb5dce69", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8841), "6f15941d4cea48c5a085edc24bd03f5615", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(8843), "4bb547b87ba842f18602ad0b8e6d7f986" },
                    { "b108e29a782a4dddaa1a6fa7a160867c6", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4888), "9b877c06d0554980ae4e0a814ad57ba76", new DateTime(2024, 2, 14, 15, 48, 45, 992, DateTimeKind.Local).AddTicks(4890), "1b54dcbe96c64361a718956eccef080a1" },
                    { "ec51ad5865664e20bd60bd34671161c325", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9056), "43fd666581044b659918e6a7b3bd2b6925", new DateTime(2024, 2, 14, 15, 48, 45, 993, DateTimeKind.Local).AddTicks(9057), "88762e4f800c469bb1358456d17031f830" }
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
                keyValue: "561e9a21b8744191b4a1233251c54a410");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "61b9b2df246249d5b2b3aee91b1e20c424");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "aa2a3ea203ba45739f63cf507baf4ac720");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "bb896a1d6d3f48e8821115afdca806604");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "cb1453d8cef64f41be885f6b1aff39b240");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "75b56dab6c684255adc042bd3fbf9ddc6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "86f906d6397c4316bdc4bf86618034071");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9759edecf3ba410a91fc51006b7c96d97");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "15dd7f1d03644ef6b360988f1af57b0e0");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "5774428bb08340b69fd0986b4aaa88574");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "b832c99d26bb46c6a55e8e2ab63f711218");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "c0e18213870843b2997c84c71582b36024");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "f69de571cc2f45e6aeb3af326af7ac3e8");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "1b54dcbe96c64361a718956eccef080a1");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "4bb547b87ba842f18602ad0b8e6d7f986");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "88762e4f800c469bb1358456d17031f830");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "ae34fef437944246aa0ea1ea00ce14ac28");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "25454319af094a1789c5cba7b941eff52");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "405967561a5b4f69b1b2081197d440978");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5f6436bcd1a04d7a9396a357de46ede44");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6986138359c844e18784e8d50af63f095");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f8fc14df442a40e2939220c33753a2173");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "5137cd724f344bde9f5c64c02f799bcb12");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "517f07b05efd4bc99be8e357dd3602b815");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "9fc86101f26d4da3b67a18ddcac9632d21");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "ad90f2110a2640aaa2665e2736f63d794");

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
