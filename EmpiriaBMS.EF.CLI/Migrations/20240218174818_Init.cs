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
                    { 124698149, "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7137), 10.0, -66, 28, "Test Description Project_10", "KL-5", new DateTime(2024, 4, 23, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7137), new DateTime(2024, 4, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7137), 1720, 215, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7137), 20, "Project_5", 5.0, new DateTime(2024, 4, 24, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7137), "Payment Detailes For Project_20", 5.0 },
                    { 273772933, "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6786), 8.0, -60, 18, "Test Description Project_9", "KL-3", new DateTime(2024, 4, 17, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6786), new DateTime(2024, 4, 14, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6786), 1672, 209, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6786), 12, "Project_3", 5.0, new DateTime(2024, 4, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6786), "Payment Detailes For Project_12", 3.0 },
                    { 447388674, "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7654), 13.0, -75, 43, "Test Description Project_24", "KL-8", new DateTime(2024, 5, 2, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7654), new DateTime(2024, 4, 24, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7654), 1792, 224, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7654), 32, "Project_8", 5.0, new DateTime(2024, 5, 3, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7654), "Payment Detailes For Project_40", 8.0 },
                    { 522535984, "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6152), 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 8, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6152), new DateTime(2024, 4, 8, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6152), 1600, 200, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6152), 0, "Project_0", 5.0, new DateTime(2024, 4, 9, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6152), "Payment Detailes For Project_0", 0.0 },
                    { 560303486, "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6958), 9.0, -63, 23, "Test Description Project_4", "KL-4", new DateTime(2024, 4, 20, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6958), new DateTime(2024, 4, 16, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6958), 1696, 212, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6958), 16, "Project_4", 5.0, new DateTime(2024, 4, 21, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6958), "Payment Detailes For Project_16", 4.0 },
                    { 683074636, "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7315), 11.0, -69, 33, "Test Description Project_24", "KL-6", new DateTime(2024, 4, 26, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7315), new DateTime(2024, 4, 20, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7315), 1744, 218, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7315), 24, "Project_6", 5.0, new DateTime(2024, 4, 27, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7315), "Payment Detailes For Project_6", 6.0 },
                    { 695993006, "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6427), 6.0, -54, 8, "Test Description Project_3", "KL-1", new DateTime(2024, 4, 11, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6427), new DateTime(2024, 4, 10, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6427), 1624, 203, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6427), 4, "Project_1", 5.0, new DateTime(2024, 4, 12, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6427), "Payment Detailes For Project_6", 1.0 },
                    { 799278748, "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7483), 12.0, -72, 38, "Test Description Project_28", "KL-7", new DateTime(2024, 4, 29, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7483), new DateTime(2024, 4, 22, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7483), 1768, 221, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7483), 28, "Project_7", 5.0, new DateTime(2024, 4, 30, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7483), "Payment Detailes For Project_28", 7.0 },
                    { 829850866, "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6608), 7.0, -57, 13, "Test Description Project_4", "KL-2", new DateTime(2024, 4, 14, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6608), new DateTime(2024, 4, 12, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6608), 1648, 206, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6608), 8, "Project_2", 5.0, new DateTime(2024, 4, 15, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6608), "Payment Detailes For Project_8", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 181276801, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6031), true, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6032), "CTO" },
                    { 204393519, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6008), true, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6009), "Engineers" },
                    { 257655656, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6053), false, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6054), "Customer" },
                    { 362654803, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(5999), true, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6000), "Draftsmen" },
                    { 600296355, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6046), false, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6047), "Guest" },
                    { 766624469, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6023), true, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6025), "COO" },
                    { 771327992, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6038), true, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6040), "CEO" },
                    { 870832000, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6015), true, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6017), "Project Managers" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 146113682, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7234), "Test Description Employee 7", null, "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7236), null, "6949277787", null, null, null },
                    { 192297473, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7056), "Test Description Employee 6", null, "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7057), null, "6949277786", null, null, null },
                    { 268051384, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7752), "Test Description Employee 10", null, "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7753), null, "69492777810", null, null, null },
                    { 270445818, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7379), "Test Description Employee 8", null, "alexpl_27@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7380), null, "6949277788", null, null, null },
                    { 460295794, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6880), "Test Description Employee 5", null, "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6881), null, "6949277785", null, null, null },
                    { 467309485, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6675), "Test Description Employee 4", null, "alexpl_23@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6676), null, "6949277784", null, null, null },
                    { 481421938, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7204), "Test Description Employee 7", null, "alexpl_26@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7205), null, "6949277787", null, null, null },
                    { 556211648, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6281), "Test Description Employee 2", null, "alexpl_21@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6283), null, "6949277782", null, null, null },
                    { 558356795, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7579), "Test Description Employee 9", null, "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7580), null, "6949277789", null, null, null },
                    { 586583329, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6703), "Test Description Employee 4", null, "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6704), null, "6949277784", null, null, null },
                    { 620955596, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6318), "Test Description Employee 2", null, "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6320), null, "6949277782", null, null, null },
                    { 681548587, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6851), "Test Description Employee 5", null, "alexpl_24@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6853), null, "6949277785", null, null, null },
                    { 705634519, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7407), "Test Description Employee 8", null, "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7408), null, "6949277788", null, null, null },
                    { 751382050, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6499), "Test Description Employee 3", null, "alexpl_22@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6500), null, "6949277783", null, null, null },
                    { 797964760, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7722), "Test Description Employee 10", null, "alexpl_29@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7724), null, "69492777810", null, null, null },
                    { 813205363, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6531), "Test Description Employee 3", null, "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6532), null, "6949277783", null, null, null },
                    { 837180800, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7028), "Test Description Employee 6", null, "alexpl_25@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7029), null, "6949277786", null, null, null },
                    { 989276229, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7550), "Test Description Employee 9", null, "alexpl_28@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7551), null, "6949277789", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "ProjectId", "ProjectManagerId" },
                values: new object[,]
                {
                    { 165516431, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6560), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6561), "ELEC", 695993006, 751382050 },
                    { 183607922, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6909), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6910), "ELEC", 273772933, 681548587 },
                    { 262062022, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6737), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6738), "HVAC", 829850866, 467309485 },
                    { 279118472, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7785), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7786), "HVAC", 447388674, 797964760 },
                    { 300330358, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7266), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7267), "ELEC", 124698149, 481421938 },
                    { 389573141, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7607), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7608), "ELEC", 799278748, 989276229 },
                    { 547727840, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7436), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7437), "HVAC", 683074636, 270445818 },
                    { 693389779, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7085), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7086), "HVAC", 560303486, 837180800 },
                    { 805908636, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6351), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6353), "HVAC", 522535984, 556211648 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 196171097, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7364), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7366), 1003000.0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7365), "Signature 1423418", 14055, 683074636, 6.0, 24.0 },
                    { 240090264, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6835), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6837), 4000.0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6836), "Signature 142346", 26601, 273772933, 3.0, 17.0 },
                    { 461656173, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6657), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6659), 3100.0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6658), "Signature 142342", 21966, 829850866, 2.0, 24.0 },
                    { 672529745, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7535), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7537), 10003000.0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7536), "Signature 142347", 23298, 799278748, 7.0, 17.0 },
                    { 707294420, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6482), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6484), 3010.0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6483), "Signature 142345", 30265, 695993006, 1.0, 17.0 },
                    { 731562326, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6251), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6253), 3001.0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6252), "Signature 142340", 55752, 522535984, 0.0, 24.0 },
                    { 879877661, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7010), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7012), 13000.0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7011), "Signature 1423412", 13668, 560303486, 4.0, 24.0 },
                    { 920398855, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7705), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7708), 100003000.0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7706), "Signature 1423448", 44361, 447388674, 8.0, 24.0 },
                    { 986194656, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7187), new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7189), 103000.0, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7188), "Signature 1423425", 74915, 124698149, 5.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 204393519, 146113682, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7253), 876352492, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7255) },
                    { 204393519, 192297473, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7072), 642015108, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7073) },
                    { 204393519, 268051384, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7772), 277236169, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7773) },
                    { 870832000, 270445818, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7395), 695153122, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7396) },
                    { 204393519, 460295794, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6896), 322482982, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6897) },
                    { 870832000, 467309485, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6691), 395889510, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6692) },
                    { 870832000, 481421938, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7221), 776913880, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7222) },
                    { 870832000, 556211648, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6304), 506806685, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6305) },
                    { 204393519, 558356795, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7594), 512347298, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7595) },
                    { 204393519, 586583329, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6722), 916104685, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6723) },
                    { 204393519, 620955596, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6337), 498498133, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6338) },
                    { 870832000, 681548587, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6867), 641873041, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6868) },
                    { 204393519, 705634519, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7423), 737252161, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7424) },
                    { 870832000, 751382050, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6517), 144971948, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6518) },
                    { 870832000, 797964760, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7739), 772586795, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7741) },
                    { 204393519, 813205363, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6547), 955405935, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6548) },
                    { 870832000, 837180800, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7044), 987389682, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7045) },
                    { 870832000, 989276229, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7566), 228912705, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7567) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 245061869, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6448), "Test Description Client 1", null, "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6449), null, "6949277781", null, null, 695993006 },
                    { 270410465, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7335), "Test Description Client 6", null, "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7336), null, "6949277786", null, null, 683074636 },
                    { 391781831, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7502), "Test Description Client 7", null, "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7504), null, "6949277787", null, null, 799278748 },
                    { 446744997, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6628), "Test Description Client 2", null, "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6629), null, "6949277782", null, null, 829850866 },
                    { 585780818, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6195), "Test Description Client 0", null, "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6196), null, "6949277780", null, null, 522535984 },
                    { 649319854, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7675), "Test Description Client 8", null, "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7677), null, "6949277788", null, null, 447388674 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 701875404, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6978), "Test Description Client 4", null, "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6980), null, "6949277784", null, null, 560303486 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 921996732, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7158), "Test Description Client 5", null, "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7159), null, "6949277785", null, null, 124698149 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 931170362, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6806), "Test Description Client 3", null, "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6807), null, "6949277783", null, null, 273772933 });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 165516431, 813205363, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6573), 259099175, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6574) },
                    { 183607922, 460295794, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6922), 911470150, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6923) },
                    { 262062022, 586583329, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6750), 567422032, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6751) },
                    { 279118472, 268051384, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7798), 366441900, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7799) },
                    { 300330358, 146113682, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7280), 495259285, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7281) },
                    { 389573141, 558356795, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7620), 537157868, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7621) },
                    { 547727840, 705634519, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7449), 645375798, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7450) },
                    { 693389779, 192297473, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7099), 708622002, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7100) },
                    { 805908636, 620955596, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6372), 656650266, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6373) }
                });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "Id", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 327750315, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7827), 279118472, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7828), 8.0, "Draw_1" },
                    { 414183201, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7475), 547727840, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7476), 6.0, "Draw_1" },
                    { 548483930, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7306), 300330358, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7307), 20.0, "Draw_1" },
                    { 618167815, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7127), 693389779, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7128), 12.0, "Draw_1" },
                    { 640012990, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6412), 805908636, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6413), 0.0, "Draw_1" },
                    { 669579268, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7645), 389573141, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7646), 28.0, "Draw_1" },
                    { 810483247, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6948), 183607922, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6950), 12.0, "Draw_1" },
                    { 821560169, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6776), 262062022, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6777), 4.0, "Draw_1" },
                    { 924096029, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6599), 165516431, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6600), 2.0, "Draw_1" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 194125918, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7293), 300330358, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7294), 15.0, "Draw_1" },
                    { 204566925, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7113), 693389779, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7114), 4.0, "Draw_1" },
                    { 216287705, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7812), 279118472, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7813), 32.0, "Draw_1" },
                    { 227897631, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7461), 547727840, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7462), 6.0, "Draw_1" },
                    { 262209434, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6935), 183607922, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6936), 3.0, "Draw_1" },
                    { 275861192, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6585), 165516431, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6586), 3.0, "Draw_1" },
                    { 379966064, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6391), 805908636, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6392), 0.0, "Draw_1" },
                    { 634763837, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6762), 262062022, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6764), 6.0, "Draw_1" },
                    { 946357975, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7632), 389573141, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7633), 21.0, "Draw_1" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 257655656, 245061869, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6469), 462640909, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6471) },
                    { 257655656, 270410465, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7351), 139896504, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7352) },
                    { 257655656, 391781831, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7522), 438986804, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7523) },
                    { 257655656, 446744997, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6644), 907326636, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6645) },
                    { 257655656, 585780818, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6233), 417287747, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6235) },
                    { 257655656, 649319854, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7693), 510549259, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7694) },
                    { 257655656, 701875404, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6997), 145384392, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6998) },
                    { 257655656, 921996732, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7174), 878182170, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(7175) },
                    { 257655656, 931170362, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6822), 542045398, new DateTime(2024, 2, 18, 19, 48, 18, 46, DateTimeKind.Local).AddTicks(6823) }
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
