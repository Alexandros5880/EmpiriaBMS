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
                    EngineerId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesEngineer", x => new { x.DisciplineId, x.EngineerId });
                    table.ForeignKey(
                        name: "FK_DisciplinesEngineer_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinesEngineer_Users_EngineerId",
                        column: x => x.EngineerId,
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
                    { 130981148, "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6070), 7.0, -57, 13, "Test Description Project_12", "KL-2", new DateTime(2024, 4, 14, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6070), new DateTime(2024, 4, 12, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6070), 1648, 206, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6070), 8, "Project_2", 5.0, new DateTime(2024, 4, 15, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6070), "Payment Detailes For Project_12", 2.0 },
                    { 175719262, "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6257), 8.0, -60, 18, "Test Description Project_9", "KL-3", new DateTime(2024, 4, 17, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6257), new DateTime(2024, 4, 14, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6257), 1672, 209, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6257), 12, "Project_3", 5.0, new DateTime(2024, 4, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6257), "Payment Detailes For Project_6", 3.0 },
                    { 272596507, "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6509), 9.0, -63, 23, "Test Description Project_12", "KL-4", new DateTime(2024, 4, 20, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6509), new DateTime(2024, 4, 16, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6509), 1696, 212, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6509), 16, "Project_4", 5.0, new DateTime(2024, 4, 21, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6509), "Payment Detailes For Project_12", 4.0 },
                    { 286606987, "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7245), 13.0, -75, 43, "Test Description Project_8", "KL-8", new DateTime(2024, 5, 2, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7245), new DateTime(2024, 4, 24, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7245), 1792, 224, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7245), 32, "Project_8", 5.0, new DateTime(2024, 5, 3, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7245), "Payment Detailes For Project_16", 8.0 },
                    { 440103497, "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5882), 6.0, -54, 8, "Test Description Project_6", "KL-1", new DateTime(2024, 4, 11, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5882), new DateTime(2024, 4, 10, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5882), 1624, 203, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5882), 4, "Project_1", 5.0, new DateTime(2024, 4, 12, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5882), "Payment Detailes For Project_3", 1.0 },
                    { 676038212, "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7070), 12.0, -72, 38, "Test Description Project_42", "KL-7", new DateTime(2024, 4, 29, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7070), new DateTime(2024, 4, 22, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7070), 1768, 221, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7070), 28, "Project_7", 5.0, new DateTime(2024, 4, 30, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7070), "Payment Detailes For Project_21", 7.0 },
                    { 704665655, "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5596), 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 8, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5596), new DateTime(2024, 4, 8, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5596), 1600, 200, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5596), 0, "Project_0", 5.0, new DateTime(2024, 4, 9, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5596), "Payment Detailes For Project_0", 0.0 },
                    { 718937331, "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6898), 11.0, -69, 33, "Test Description Project_12", "KL-6", new DateTime(2024, 4, 26, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6898), new DateTime(2024, 4, 20, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6898), 1744, 218, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6898), 24, "Project_6", 5.0, new DateTime(2024, 4, 27, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6898), "Payment Detailes For Project_30", 6.0 },
                    { 848912571, "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6700), 10.0, -66, 28, "Test Description Project_15", "KL-5", new DateTime(2024, 4, 23, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6700), new DateTime(2024, 4, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6700), 1720, 215, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6700), 20, "Project_5", 5.0, new DateTime(2024, 4, 24, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6700), "Payment Detailes For Project_20", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 286999615, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5484), false, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5485), "Guest" },
                    { 291142081, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5477), true, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5478), "CEO" },
                    { 391388519, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5462), true, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5464), "COO" },
                    { 444575279, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5438), true, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5440), "Draftsmen" },
                    { 535540316, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5470), true, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5471), "CTO" },
                    { 838195659, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5447), true, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5449), "Engineer" },
                    { 947454118, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5491), false, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5493), "Customer" },
                    { 963612145, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5455), true, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5457), "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 145630019, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6615), "Test Description Employee 6", null, "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6616), null, "6949277786", null, null, null },
                    { 248682745, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6426), "Test Description Employee 5", null, "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6427), null, "6949277785", null, null, null },
                    { 277217330, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6396), "Test Description Employee 5", null, "alexpl_24@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6397), null, "6949277785", null, null, null },
                    { 312709198, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7167), "Test Description Employee 9", null, "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7168), null, "6949277789", null, null, null },
                    { 316922673, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6770), "Test Description Employee 7", null, "alexpl_26@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6772), null, "6949277787", null, null, null },
                    { 377420325, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5988), "Test Description Employee 3", null, "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5989), null, "6949277783", null, null, null },
                    { 455276782, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7343), "Test Description Employee 10", null, "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7344), null, "69492777810", null, null, null },
                    { 457383956, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7138), "Test Description Employee 9", null, "alexpl_28@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7139), null, "6949277789", null, null, null },
                    { 510369564, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5768), "Test Description Employee 2", null, "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5769), null, "6949277782", null, null, null },
                    { 559658536, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5733), "Test Description Employee 2", null, "alexpl_21@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5734), null, "6949277782", null, null, null },
                    { 587549065, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6963), "Test Description Employee 8", null, "alexpl_27@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6964), null, "6949277788", null, null, null },
                    { 588761421, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5956), "Test Description Employee 3", null, "alexpl_22@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5957), null, "6949277783", null, null, null },
                    { 694801660, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6814), "Test Description Employee 7", null, "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6815), null, "6949277787", null, null, null },
                    { 848809943, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6141), "Test Description Employee 4", null, "alexpl_23@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6142), null, "6949277784", null, null, null },
                    { 863769140, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6585), "Test Description Employee 6", null, "alexpl_25@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6586), null, "6949277786", null, null, null },
                    { 913872049, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7313), "Test Description Employee 10", null, "alexpl_29@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7314), null, "69492777810", null, null, null },
                    { 934693446, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6992), "Test Description Employee 8", null, "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6993), null, "6949277788", null, null, null },
                    { 977996809, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6171), "Test Description Employee 4", null, "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6172), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "ProjectId", "ProjectManagerId" },
                values: new object[,]
                {
                    { 243450598, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6645), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6646), "HVAC", 272596507, 863769140 },
                    { 263555367, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6206), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6207), "HVAC", 130981148, 848809943 },
                    { 341000098, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7377), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7378), "HVAC", 286606987, 913872049 },
                    { 592036438, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5802), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5804), "HVAC", 704665655, 559658536 },
                    { 637460308, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6847), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6848), "ELEC", 848912571, 316922673 },
                    { 848670715, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6018), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6019), "ELEC", 440103497, 588761421 },
                    { 863599244, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7196), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7197), "ELEC", 676038212, 457383956 },
                    { 914886991, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7021), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7022), "HVAC", 718937331, 587549065 },
                    { 950868618, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6457), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6458), "ELEC", 175719262, 277217330 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 148543964, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5697), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5699), 3001.0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5698), "Signature 142340", 75017, 704665655, 0.0, 24.0 },
                    { 215347548, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6377), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6380), 4000.0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6378), "Signature 1423415", 65739, 175719262, 3.0, 17.0 },
                    { 398850153, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6753), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6755), 103000.0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6754), "Signature 142345", 84476, 848912571, 5.0, 17.0 },
                    { 589602663, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7122), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7125), 10003000.0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7123), "Signature 1423442", 63429, 676038212, 7.0, 17.0 },
                    { 622529551, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6121), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6124), 3100.0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6123), "Signature 142346", 37521, 130981148, 2.0, 24.0 },
                    { 724907431, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6947), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6949), 1003000.0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6948), "Signature 142346", 55772, 718937331, 6.0, 24.0 },
                    { 735605737, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7296), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7298), 100003000.0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7297), "Signature 1423440", 38738, 286606987, 8.0, 24.0 },
                    { 869665060, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6566), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6568), 13000.0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6567), "Signature 1423416", 64039, 272596507, 4.0, 24.0 },
                    { 893702000, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5939), new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5942), 3010.0, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5940), "Signature 142341", 52656, 440103497, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 838195659, 145630019, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6632), 363133009, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6633) },
                    { 838195659, 248682745, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6444), 478720612, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6445) },
                    { 963612145, 277217330, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6413), 773446368, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6414) },
                    { 838195659, 312709198, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7183), 385701864, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7184) },
                    { 963612145, 316922673, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6800), 889803303, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6801) },
                    { 838195659, 377420325, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6005), 732415490, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6006) },
                    { 838195659, 455276782, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7363), 481898934, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7364) },
                    { 963612145, 457383956, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7154), 717084275, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7155) },
                    { 838195659, 510369564, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5788), 593296803, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5789) },
                    { 963612145, 559658536, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5754), 562787062, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5755) },
                    { 963612145, 587549065, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6979), 390467858, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6980) },
                    { 963612145, 588761421, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5974), 985526922, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5976) },
                    { 838195659, 694801660, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6834), 688303143, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6835) },
                    { 963612145, 848809943, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6157), 125014486, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6159) },
                    { 963612145, 863769140, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6602), 728325278, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6603) },
                    { 963612145, 913872049, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7330), 639473397, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7332) },
                    { 838195659, 934693446, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7008), 701192224, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7009) },
                    { 838195659, 977996809, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6191), 167064140, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6192) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 152373314, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5904), "Test Description Client 1", null, "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5905), null, "6949277781", null, null, 440103497 },
                    { 164910680, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6278), "Test Description Client 3", null, "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6279), null, "6949277783", null, null, 175719262 },
                    { 195508779, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7267), "Test Description Client 8", null, "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7268), null, "6949277788", null, null, 286606987 },
                    { 310374787, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5637), "Test Description Client 0", null, "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5638), null, "6949277780", null, null, 704665655 },
                    { 346166302, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6091), "Test Description Client 2", null, "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6093), null, "6949277782", null, null, 130981148 },
                    { 448417354, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6723), "Test Description Client 5", null, "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6724), null, "6949277785", null, null, 848912571 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 522889222, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6918), "Test Description Client 6", null, "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6920), null, "6949277786", null, null, 718937331 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 690664695, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7091), "Test Description Client 7", null, "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7092), null, "6949277787", null, null, 676038212 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 761895152, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6532), "Test Description Client 4", null, "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6533), null, "6949277784", null, null, 272596507 });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 243450598, 145630019, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6660), 843864770, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6661) },
                    { 263555367, 977996809, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6220), 667805152, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6221) },
                    { 341000098, 455276782, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7391), 497552600, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7392) },
                    { 592036438, 510369564, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5825), 326444502, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5827) },
                    { 637460308, 694801660, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6860), 439888476, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6861) },
                    { 848670715, 377420325, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6032), 559856085, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6033) },
                    { 863599244, 312709198, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7209), 673715261, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7210) },
                    { 914886991, 934693446, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7034), 723369326, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7035) },
                    { 950868618, 248682745, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6471), 907587097, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6472) }
                });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "Id", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 140806223, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6247), 263555367, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6249), 2.0, "Draw_1" },
                    { 382542499, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7236), 863599244, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7237), 21.0, "Draw_1" },
                    { 477220371, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7420), 341000098, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7421), 32.0, "Draw_1" },
                    { 550160926, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6060), 848670715, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6062), 3.0, "Draw_1" },
                    { 609794752, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6690), 243450598, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6691), 8.0, "Draw_1" },
                    { 703937989, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6499), 950868618, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6500), 6.0, "Draw_1" },
                    { 893438739, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5868), 592036438, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5869), 0.0, "Draw_1" },
                    { 913654282, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7061), 914886991, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7062), 24.0, "Draw_1" },
                    { 978528291, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6888), 637460308, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6889), 15.0, "Draw_1" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 143802730, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5843), 592036438, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5844), 0.0, "Draw_1" },
                    { 199171477, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7047), 914886991, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7048), 24.0, "Draw_1" },
                    { 248929858, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6674), 243450598, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6675), 12.0, "Draw_1" },
                    { 314173876, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6873), 637460308, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6874), 10.0, "Draw_1" },
                    { 338246658, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6233), 263555367, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6234), 8.0, "Draw_1" },
                    { 427887169, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7222), 863599244, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7223), 28.0, "Draw_1" },
                    { 445870229, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6045), 848670715, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6046), 2.0, "Draw_1" },
                    { 584558483, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6484), 950868618, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6485), 3.0, "Draw_1" },
                    { 702839493, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7405), 341000098, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7406), 8.0, "Draw_1" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 947454118, 152373314, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5926), 649555044, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5927) },
                    { 947454118, 164910680, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6362), 615134434, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6363) },
                    { 947454118, 195508779, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7283), 644062091, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7284) },
                    { 947454118, 310374787, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5679), 928223811, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(5680) },
                    { 947454118, 346166302, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6108), 994318441, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6109) },
                    { 947454118, 448417354, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6740), 293718938, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6741) },
                    { 947454118, 522889222, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6934), 892522784, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6936) },
                    { 947454118, 690664695, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7109), 535895516, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(7111) },
                    { 947454118, 761895152, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6552), 323661856, new DateTime(2024, 2, 18, 21, 39, 16, 395, DateTimeKind.Local).AddTicks(6554) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_ProjectId",
                table: "Disciplines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_ProjectManagerId",
                table: "Disciplines",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesEngineer_EngineerId",
                table: "DisciplinesEngineer",
                column: "EngineerId");

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
