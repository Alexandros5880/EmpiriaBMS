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
                    EstimatedMandays = table.Column<int>(type: "int", nullable: true),
                    EstimatedHours = table.Column<int>(type: "int", nullable: true),
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
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManHours = table.Column<double>(type: "float", nullable: false),
                    Completed = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docs_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Draws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManHours = table.Column<double>(type: "float", nullable: false),
                    Completed = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Draws_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    DisciplineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesEngineer",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesEngineer", x => new { x.DisciplineId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_DisciplinesEngineer_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinesEngineer_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
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
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments" },
                values: new object[,]
                {
                    { 227852009, "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8209), 12.0, -72, 38, "Test Description Project_7", "KL-7", new DateTime(2024, 4, 30, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8209), new DateTime(2024, 4, 23, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8209), 1768, 221, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8209), 28, "Project_7", 5.0, new DateTime(2024, 5, 1, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8209), "Payment Detailes For Project_7", 7.0 },
                    { 304832682, "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6668), 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 9, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6668), new DateTime(2024, 4, 9, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6668), 1600, 200, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6668), 0, "Project_0", 5.0, new DateTime(2024, 4, 10, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6668), "Payment Detailes For Project_0", 0.0 },
                    { 343707825, "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7388), 8.0, -60, 18, "Test Description Project_6", "KL-3", new DateTime(2024, 4, 18, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7388), new DateTime(2024, 4, 15, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7388), 1672, 209, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7388), 12, "Project_3", 5.0, new DateTime(2024, 4, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7388), "Payment Detailes For Project_15", 3.0 },
                    { 477378683, "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8006), 11.0, -69, 33, "Test Description Project_24", "KL-6", new DateTime(2024, 4, 27, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8006), new DateTime(2024, 4, 21, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8006), 1744, 218, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8006), 24, "Project_6", 5.0, new DateTime(2024, 4, 28, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8006), "Payment Detailes For Project_36", 6.0 },
                    { 521435713, "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6969), 6.0, -54, 8, "Test Description Project_2", "KL-1", new DateTime(2024, 4, 12, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6969), new DateTime(2024, 4, 11, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6969), 1624, 203, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6969), 4, "Project_1", 5.0, new DateTime(2024, 4, 13, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6969), "Payment Detailes For Project_4", 1.0 },
                    { 555213287, "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8413), 13.0, -75, 43, "Test Description Project_24", "KL-8", new DateTime(2024, 5, 3, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8413), new DateTime(2024, 4, 25, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8413), 1792, 224, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8413), 32, "Project_8", 5.0, new DateTime(2024, 5, 4, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8413), "Payment Detailes For Project_16", 8.0 },
                    { 601456398, "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7801), 10.0, -66, 28, "Test Description Project_10", "KL-5", new DateTime(2024, 4, 24, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7801), new DateTime(2024, 4, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7801), 1720, 215, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7801), 20, "Project_5", 5.0, new DateTime(2024, 4, 25, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7801), "Payment Detailes For Project_20", 5.0 },
                    { 924376174, "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7591), 9.0, -63, 23, "Test Description Project_16", "KL-4", new DateTime(2024, 4, 21, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7591), new DateTime(2024, 4, 17, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7591), 1696, 212, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7591), 16, "Project_4", 5.0, new DateTime(2024, 4, 22, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7591), "Payment Detailes For Project_8", 4.0 },
                    { 940872570, "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7178), 7.0, -57, 13, "Test Description Project_4", "KL-2", new DateTime(2024, 4, 15, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7178), new DateTime(2024, 4, 13, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7178), 1648, 206, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7178), 8, "Project_2", 5.0, new DateTime(2024, 4, 16, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7178), "Payment Detailes For Project_12", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 230219347, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6559), true, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6560), "CEO" },
                    { 249354565, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6566), false, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6567), "Guest" },
                    { 487880360, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6522), true, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6523), "Draftsmen" },
                    { 553806718, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6545), true, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6546), "COO" },
                    { 554116429, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6530), true, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6531), "Engineer" },
                    { 858018899, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6552), true, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6553), "CTO" },
                    { 858704225, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6572), false, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6574), "Customer" },
                    { 895118024, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6538), true, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6539), "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 183016462, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7036), "Test Description PM 3", null, "alexpl_22@gmail.com", "Platanios_PM_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7037), null, "6949277783", null, null, null },
                    { 195436813, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8271), "Test Description PM 9", null, "alexpl_28@gmail.com", "Platanios_PM_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8272), null, "6949277789", null, null, null },
                    { 201499321, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6859), "Test Description Draftsman 2", null, "alexpl_2@gmail.com", "Platanios_Draftsman_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6860), null, "6949277782", null, null, null },
                    { 208892910, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7921), "Test Description Draftsman 7", null, "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7922), null, "6949277787", null, null, null },
                    { 228689291, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7297), "Test Description Draftsman 4", null, "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7298), null, "6949277784", null, null, null },
                    { 343581556, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8481), "Test Description PM 10", null, "alexpl_29@gmail.com", "Platanios_PM_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8482), null, "69492777810", null, null, null },
                    { 349954837, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7066), "Test Description Engineer 3", null, "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7067), null, "6949277783", null, null, null },
                    { 358097739, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7658), "Test Description PM 6", null, "alexpl_25@gmail.com", "Platanios_PM_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7659), null, "6949277786", null, null, null },
                    { 365809547, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7092), "Test Description Draftsman 3", null, "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7093), null, "6949277783", null, null, null },
                    { 374408900, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6796), "Test Description PM 2", null, "alexpl_21@gmail.com", "Platanios_PM_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6797), null, "6949277782", null, null, null },
                    { 410587364, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7244), "Test Description PM 4", null, "alexpl_23@gmail.com", "Platanios_PM_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7245), null, "6949277784", null, null, null },
                    { 416956910, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7476), "Test Description Engineer 5", null, "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7477), null, "6949277785", null, null, null },
                    { 420363606, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7685), "Test Description Engineer 6", null, "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7686), null, "6949277786", null, null, null },
                    { 429428258, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7895), "Test Description Engineer 7", null, "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7896), null, "6949277787", null, null, null },
                    { 445528109, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7450), "Test Description PM 5", null, "alexpl_24@gmail.com", "Platanios_PM_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7451), null, "6949277785", null, null, null },
                    { 450204413, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8125), "Test Description Draftsman 8", null, "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8126), null, "6949277788", null, null, null },
                    { 469754135, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8327), "Test Description Draftsman 9", null, "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8328), null, "6949277789", null, null, null },
                    { 509794764, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7868), "Test Description PM 7", null, "alexpl_26@gmail.com", "Platanios_PM_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7869), null, "6949277787", null, null, null },
                    { 605662202, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8297), "Test Description Engineer 9", null, "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8298), null, "6949277789", null, null, null },
                    { 636165817, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8508), "Test Description Engineer 10", null, "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8509), null, "69492777810", null, null, null },
                    { 661570500, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6829), "Test Description Engineer 2", null, "alexpl_2@gmail.com", "Platanios_Engineer_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6830), null, "6949277782", null, null, null },
                    { 702952602, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7502), "Test Description Draftsman 5", null, "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7504), null, "6949277785", null, null, null },
                    { 749244331, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7712), "Test Description Draftsman 6", null, "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7713), null, "6949277786", null, null, null },
                    { 820193569, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8099), "Test Description Engineer 8", null, "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8100), null, "6949277788", null, null, null },
                    { 898647891, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8072), "Test Description PM 8", null, "alexpl_27@gmail.com", "Platanios_PM_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8073), null, "6949277788", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 939393887, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7271), "Test Description Engineer 4", null, "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7272), null, "6949277784", null, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 982068691, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8538), "Test Description Draftsman 10", null, "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8539), null, "69492777810", null, null, null });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "ProjectId", "ProjectManagerId" },
                values: new object[,]
                {
                    { 157935044, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7119), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7120), "ELEC", 521435713, 183016462 },
                    { 310706355, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8152), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8153), "HVAC", 477378683, 898647891 },
                    { 463032774, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7739), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7740), "HVAC", 924376174, 358097739 },
                    { 503246609, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8355), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8356), "ELEC", 227852009, 195436813 },
                    { 522992265, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7947), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7948), "ELEC", 601456398, 509794764 },
                    { 596272544, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7328), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7329), "HVAC", 940872570, 410587364 },
                    { 772260976, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8565), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8566), "HVAC", 555213287, 343581556 },
                    { 857316241, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6891), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6892), "HVAC", 304832682, 374408900 },
                    { 866908821, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7529), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7531), "ELEC", 343707825, 445528109 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 256826287, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7434), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7436), 4000.0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7435), "Signature 142346", 13478, 343707825, 3.0, 17.0 },
                    { 301809620, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7851), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7853), 103000.0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7852), "Signature 1423420", 64536, 601456398, 5.0, 17.0 },
                    { 568280592, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8464), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8466), 100003000.0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8465), "Signature 1423440", 40245, 555213287, 8.0, 24.0 },
                    { 654373570, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8255), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8257), 10003000.0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8256), "Signature 1423442", 44791, 227852009, 7.0, 17.0 },
                    { 735141994, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8054), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8056), 1003000.0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8055), "Signature 1423412", 44797, 477378683, 6.0, 24.0 },
                    { 823048909, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6765), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6768), 3001.0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6767), "Signature 142340", 70737, 304832682, 0.0, 24.0 },
                    { 854088928, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7226), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7228), 3100.0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7227), "Signature 142342", 11007, 940872570, 2.0, 24.0 },
                    { 874769225, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7022), 3010.0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7021), "Signature 142345", 19362, 521435713, 1.0, 17.0 },
                    { 875603234, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7641), new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7643), 13000.0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7642), "Signature 142344", 32170, 924376174, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 895118024, 183016462, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7053), 919687347, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7054) },
                    { 895118024, 195436813, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8286), 587428959, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8287) },
                    { 487880360, 201499321, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6877), 873335414, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6878) },
                    { 487880360, 208892910, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7936), 373801437, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7937) },
                    { 487880360, 228689291, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7316), 524051452, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7317) },
                    { 895118024, 343581556, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8496), 444808903, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8498) },
                    { 554116429, 349954837, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7081), 736787271, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7082) },
                    { 895118024, 358097739, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7674), 348513837, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7675) },
                    { 487880360, 365809547, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7107), 512250650, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7108) },
                    { 895118024, 374408900, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6815), 485833983, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6816) },
                    { 895118024, 410587364, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7259), 662957470, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7260) },
                    { 554116429, 416956910, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7491), 560913532, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7492) },
                    { 554116429, 420363606, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7700), 296429646, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7701) },
                    { 554116429, 429428258, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7909), 500005426, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7910) },
                    { 895118024, 445528109, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7465), 487419111, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7466) },
                    { 487880360, 450204413, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8140), 236972625, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8141) },
                    { 487880360, 469754135, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8342), 688588667, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8344) },
                    { 895118024, 509794764, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7883), 191607710, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7884) },
                    { 554116429, 605662202, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8312), 992142136, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8313) },
                    { 554116429, 636165817, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8523), 992044022, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8525) },
                    { 554116429, 661570500, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6846), 156113858, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6847) },
                    { 487880360, 702952602, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7517), 372441238, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7518) },
                    { 487880360, 749244331, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7727), 776373245, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7728) },
                    { 554116429, 820193569, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8113), 285201411, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8114) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 895118024, 898647891, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8087), 470854700, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8089) },
                    { 554116429, 939393887, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7286), 667990012, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7287) },
                    { 487880360, 982068691, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8553), 131281557, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8555) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 172686246, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8228), "Test Description Customer 7", null, "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8229), null, "6949277787", null, null, 227852009 },
                    { 281285326, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8027), "Test Description Customer 6", null, "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8028), null, "6949277786", null, null, 477378683 },
                    { 531937006, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7611), "Test Description Customer 4", null, "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7612), null, "6949277784", null, null, 924376174 },
                    { 653520971, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6711), "Test Description Customer 0", null, "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6713), null, "6949277780", null, null, 304832682 },
                    { 708896764, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6990), "Test Description Customer 1", null, "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6991), null, "6949277781", null, null, 521435713 },
                    { 764399353, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8434), "Test Description Customer 8", null, "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8435), null, "6949277788", null, null, 555213287 },
                    { 909975793, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7197), "Test Description Customer 2", null, "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7198), null, "6949277782", null, null, 940872570 },
                    { 950682111, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7407), "Test Description Customer 3", null, "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7408), null, "6949277783", null, null, 343707825 },
                    { 999042123, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7823), "Test Description Customer 5", null, "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7824), null, "6949277785", null, null, 601456398 }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 157935044, 349954837, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7132), 945257752, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7133) },
                    { 157935044, 365809547, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7144), 961798692, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7145) },
                    { 310706355, 450204413, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8176), 204474536, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8177) },
                    { 310706355, 820193569, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8164), 205651747, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8166) },
                    { 463032774, 420363606, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7752), 700212697, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7754) },
                    { 463032774, 749244331, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7765), 812386854, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7766) },
                    { 503246609, 469754135, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8379), 924292465, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8380) },
                    { 503246609, 605662202, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8368), 161802909, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8369) },
                    { 522992265, 208892910, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7972), 389528274, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7973) },
                    { 522992265, 429428258, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7960), 954240893, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7961) },
                    { 596272544, 228689291, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7353), 611158146, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7354) },
                    { 596272544, 939393887, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7340), 423010309, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7341) },
                    { 772260976, 636165817, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8578), 824497183, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8579) },
                    { 772260976, 982068691, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8591), 414435660, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8593) },
                    { 857316241, 201499321, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6924), 783926841, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6925) },
                    { 857316241, 661570500, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6908), 547271351, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6909) },
                    { 866908821, 416956910, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7542), 982412723, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7543) },
                    { 866908821, 702952602, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7554), 191437786, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7555) }
                });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "Id", "Completed", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 152173587, 20, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7792), 463032774, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7793), 12.0, "Doc_4" },
                    { 193710907, 15, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7582), 866908821, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7583), 12.0, "Doc_3" },
                    { 338309581, 10, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7379), 596272544, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7380), 2.0, "Doc_2" },
                    { 664285773, 40, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8618), 772260976, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8619), 8.0, "Doc_8" },
                    { 741965977, 30, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8201), 310706355, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8203), 18.0, "Doc_6" },
                    { 772179093, 0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6956), 857316241, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6957), 0.0, "Doc_0" },
                    { 789516187, 5, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7170), 157935044, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7171), 4.0, "Doc_1" },
                    { 826814220, 35, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8405), 503246609, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8406), 28.0, "Doc_7" },
                    { 972114853, 25, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7998), 522992265, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7999), 10.0, "Doc_5" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "Completed", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 202824762, 0, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6937), 857316241, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6939), 0.0, "Draw_0" },
                    { 215352521, 25, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7984), 522992265, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7985), 20.0, "Draw_5" },
                    { 260040921, 35, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8391), 503246609, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8393), 21.0, "Draw_7" },
                    { 378426874, 5, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7156), 157935044, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7157), 1.0, "Draw_1" },
                    { 410156347, 15, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7566), 866908821, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7567), 12.0, "Draw_3" },
                    { 484902815, 40, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8603), 772260976, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8604), 24.0, "Draw_8" },
                    { 560838848, 30, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8188), 310706355, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8189), 24.0, "Draw_6" },
                    { 909504311, 10, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7366), 596272544, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7367), 2.0, "Draw_2" },
                    { 911342916, 20, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7777), 463032774, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7778), 16.0, "Draw_4" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 858704225, 172686246, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8243), 687878016, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8244) },
                    { 858704225, 281285326, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8041), 768900360, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8042) },
                    { 858704225, 531937006, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7628), 339718495, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7629) },
                    { 858704225, 653520971, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6749), 918154668, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(6750) },
                    { 858704225, 708896764, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7006), 721222669, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7007) },
                    { 858704225, 764399353, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8450), 778241525, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(8451) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 858704225, 909975793, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7213), 433741895, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7214) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 858704225, 950682111, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7422), 974008875, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7423) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 858704225, 999042123, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7839), 990775658, new DateTime(2024, 2, 19, 13, 47, 31, 934, DateTimeKind.Local).AddTicks(7840) });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_ProjectId",
                table: "Disciplines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_ProjectManagerId",
                table: "Disciplines",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesEngineer_EmployeeId",
                table: "DisciplinesEngineer",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_DisciplineId",
                table: "Docs",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Draws_DisciplineId",
                table: "Draws",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DisciplineId",
                table: "Users",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectId",
                table: "Users",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Users_ProjectManagerId",
                table: "Disciplines",
                column: "ProjectManagerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Users_ProjectManagerId",
                table: "Disciplines");

            migrationBuilder.DropTable(
                name: "DisciplinesEngineer");

            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
