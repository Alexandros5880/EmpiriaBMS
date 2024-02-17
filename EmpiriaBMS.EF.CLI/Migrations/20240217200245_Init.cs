using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpiriaBMS.EF.CLI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drawing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanType = table.Column<int>(type: "int", nullable: false),
                    WorkingDays = table.Column<int>(type: "int", nullable: true),
                    DurationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DelayInPayment = table.Column<int>(type: "int", nullable: true),
                    PaymentDetailes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayCost = table.Column<double>(type: "float", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidFee = table.Column<double>(type: "float", nullable: true),
                    DaysUntilPayment = table.Column<int>(type: "int", nullable: true),
                    PendingPayments = table.Column<double>(type: "float", nullable: true),
                    CalculationDaly = table.Column<int>(type: "int", nullable: true),
                    Completed = table.Column<int>(type: "int", nullable: true),
                    ManHours = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: true),
                    Vat = table.Column<double>(type: "float", nullable: true),
                    Fee = table.Column<double>(type: "float", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<double>(type: "float", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployee",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployee", x => new { x.ProjectId, x.EmployeeId });
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
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
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "PlanType", "WorkingDays" },
                values: new object[,]
                {
                    { 183486314, "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(343), 7.0, -57, 13, "Test Description Project_8", "KL-2", new DateTime(2024, 4, 13, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(343), new DateTime(2024, 4, 11, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(343), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(343), 8, "Project_2", 5.0, new DateTime(2024, 4, 14, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(343), "Payment Detailes For Project_8", 2.0, 1, 206 },
                    { 214971534, "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9895), 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 7, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9895), new DateTime(2024, 4, 7, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9895), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9895), 0, "Project_0", 5.0, new DateTime(2024, 4, 8, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9895), "Payment Detailes For Project_0", 0.0, 1, 200 },
                    { 245740554, "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(203), 6.0, -54, 8, "Test Description Project_4", "KL-1", new DateTime(2024, 4, 10, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(203), new DateTime(2024, 4, 9, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(203), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(203), 4, "Project_1", 5.0, new DateTime(2024, 4, 11, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(203), "Payment Detailes For Project_1", 1.0, 0, 203 },
                    { 539171849, "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1056), 12.0, -72, 38, "Test Description Project_21", "KL-7", new DateTime(2024, 4, 28, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1056), new DateTime(2024, 4, 21, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1056), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1056), 28, "Project_7", 5.0, new DateTime(2024, 4, 29, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1056), "Payment Detailes For Project_35", 7.0, 0, 221 },
                    { 591804363, "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(523), 8.0, -60, 18, "Test Description Project_18", "KL-3", new DateTime(2024, 4, 16, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(523), new DateTime(2024, 4, 13, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(523), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(523), 12, "Project_3", 5.0, new DateTime(2024, 4, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(523), "Payment Detailes For Project_3", 3.0, 0, 209 },
                    { 622816112, "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1190), 13.0, -75, 43, "Test Description Project_40", "KL-8", new DateTime(2024, 5, 1, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1190), new DateTime(2024, 4, 23, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1190), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1190), 32, "Project_8", 5.0, new DateTime(2024, 5, 2, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1190), "Payment Detailes For Project_16", 8.0, 1, 224 },
                    { 782371811, "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(948), 11.0, -69, 33, "Test Description Project_24", "KL-6", new DateTime(2024, 4, 25, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(948), new DateTime(2024, 4, 19, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(948), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(948), 24, "Project_6", 5.0, new DateTime(2024, 4, 26, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(948), "Payment Detailes For Project_12", 6.0, 1, 218 },
                    { 899861806, "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(713), 9.0, -63, 23, "Test Description Project_16", "KL-4", new DateTime(2024, 4, 19, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(713), new DateTime(2024, 4, 15, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(713), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(713), 16, "Project_4", 5.0, new DateTime(2024, 4, 20, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(713), "Payment Detailes For Project_20", 4.0, 1, 212 },
                    { 981541842, "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(806), 10.0, -66, 28, "Test Description Project_30", "KL-5", new DateTime(2024, 4, 22, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(806), new DateTime(2024, 4, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(806), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(806), 20, "Project_5", 5.0, new DateTime(2024, 4, 23, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(806), "Payment Detailes For Project_10", 5.0, 0, 215 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 126868892, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9549), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9550), "Project Managers" },
                    { 149098697, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9556), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9557), "COO" },
                    { 530867923, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9584), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9585), "Customer" },
                    { 659989378, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9577), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9579), "Guest" },
                    { 846898163, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9541), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9542), "Engineers" },
                    { 860689953, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9570), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9571), "CEO" },
                    { 943765270, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9563), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9564), "CTO" },
                    { 993533882, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9532), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9533), "Draftsmen" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 162535765, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(655), "Test Description Employee 6", "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(657), null, "6949277786", null, null, null },
                    { 209685584, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(178), "Test Description Employee 3", "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(179), null, "6949277783", null, null, null },
                    { 216536264, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(782), "Test Description Employee 7", "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(783), null, "6949277787", null, null, null },
                    { 422057560, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(926), "Test Description Employee 8", "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(927), null, "6949277788", null, null, null },
                    { 545463596, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9812), "Test Description Employee 2", "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9813), null, "6949277782", null, null, null },
                    { 581388523, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(294), "Test Description Employee 4", "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(296), null, "6949277784", null, null, null },
                    { 774871803, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1162), "Test Description Employee 10", "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1163), null, "69492777810", null, null, null },
                    { 810188773, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(483), "Test Description Employee 5", "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(485), null, "6949277785", null, null, null },
                    { 871907095, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1033), "Test Description Employee 9", "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1034), null, "6949277789", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 406827934, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1239), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1241), 100003000.0, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1240), "Signature 142348", 20621, 622816112, 8.0, 24.0 },
                    { 567260722, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1017), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1019), 1003000.0, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1018), "Signature 142346", 40086, 782371811, 6.0, 24.0 },
                    { 571354772, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(909), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(911), 103000.0, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(910), "Signature 1423430", 62926, 981541842, 5.0, 17.0 },
                    { 589933358, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(765), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(767), 13000.0, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(766), "Signature 1423420", 51714, 899861806, 4.0, 24.0 },
                    { 689629364, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(425), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(428), 3100.0, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(426), "Signature 1423412", 86488, 183486314, 2.0, 24.0 },
                    { 773848234, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(628), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(632), 4000.0, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(630), "Signature 1423412", 51338, 591804363, 3.0, 17.0 },
                    { 937602094, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9993), new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9995), 3001.0, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9994), "Signature 142340", 28356, 214971534, 0.0, 24.0 },
                    { 938775746, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(269), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(271), 3010.0, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(270), "Signature 142346", 89337, 245740554, 1.0, 17.0 },
                    { 943764857, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1146), new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1149), 10003000.0, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1147), "Signature 1423421", 45778, 539171849, 7.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployee",
                columns: new[] { "EmployeeId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 209685584, 245740554, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(224), 713577259, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(225) },
                    { 871907095, 539171849, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1077), 650076392, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1078) },
                    { 810188773, 591804363, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(554), 200938569, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(555) },
                    { 216536264, 981541842, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(856), 742539684, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(857) }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 126868892, 162535765, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(704), 663874279, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(705) },
                    { 126868892, 209685584, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(195), 829346634, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(196) },
                    { 126868892, 216536264, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(798), 609774229, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(799) },
                    { 126868892, 422057560, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(941), 160835749, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(942) },
                    { 126868892, 545463596, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9882), 231522843, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9884) },
                    { 126868892, 581388523, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(324), 949783269, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(326) },
                    { 126868892, 774871803, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1181), 304941550, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1182) },
                    { 126868892, 810188773, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(509), 865640892, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(511) },
                    { 126868892, 871907095, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1049), 540735491, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1050) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 174641641, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(735), "Test Description Client 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(736), null, "6949277784", null, null, 899861806 },
                    { 212523897, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1089), "Test Description Client 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1090), null, "6949277787", null, null, 539171849 },
                    { 370977225, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(239), "Test Description Client 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(240), null, "6949277781", null, null, 245740554 },
                    { 626186467, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(376), "Test Description Client 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(378), null, "6949277782", null, null, 183486314 },
                    { 632786163, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(577), "Test Description Client 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(579), null, "6949277783", null, null, 591804363 },
                    { 635611476, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9957), "Test Description Client 0", "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9958), null, "6949277780", null, null, 214971534 },
                    { 706495715, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(969), "Test Description Client 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(970), null, "6949277786", null, null, 782371811 },
                    { 796396219, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(869), "Test Description Client 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(870), null, "6949277785", null, null, 981541842 },
                    { 975062454, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1210), "Test Description Client 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1211), null, "6949277788", null, null, 622816112 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 530867923, 174641641, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(752), 684680620, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(753) },
                    { 530867923, 212523897, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1104), 416040976, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1105) },
                    { 530867923, 370977225, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(256), 308993223, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(257) },
                    { 530867923, 626186467, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(403), 671797344, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(404) },
                    { 530867923, 632786163, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(604), 634584128, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(606) },
                    { 530867923, 635611476, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9978), 178055352, new DateTime(2024, 2, 17, 22, 2, 44, 782, DateTimeKind.Local).AddTicks(9979) },
                    { 530867923, 706495715, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1004), 609291683, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1005) },
                    { 530867923, 796396219, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(896), 617222020, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(897) },
                    { 530867923, 975062454, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1226), 773212170, new DateTime(2024, 2, 17, 22, 2, 44, 783, DateTimeKind.Local).AddTicks(1227) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_EmployeeId",
                table: "ProjectEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectId",
                table: "Users",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ProjectEmployee");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
