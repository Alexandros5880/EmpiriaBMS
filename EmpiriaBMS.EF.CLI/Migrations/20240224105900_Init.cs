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
                name: "Draws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenHours = table.Column<double>(type: "float", nullable: false),
                    CompletionEstimation = table.Column<float>(type: "real", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenHours = table.Column<double>(type: "float", nullable: false),
                    CompletionEstimation = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.Id);
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
                name: "Timespan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Days = table.Column<long>(type: "bigint", nullable: false),
                    Hours = table.Column<long>(type: "bigint", nullable: false),
                    Minutes = table.Column<long>(type: "bigint", nullable: false),
                    Seconds = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timespan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSpanId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyHour_Timespan_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "Timespan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: false),
                    MenHours = table.Column<long>(type: "bigint", nullable: false),
                    Completed = table.Column<float>(type: "real", nullable: false),
                    EngineerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesDraws",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    DrawId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesDraws", x => new { x.DisciplineId, x.DrawId });
                    table.ForeignKey(
                        name: "FK_DisciplinesDraws_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinesDraws_Draws_DrawId",
                        column: x => x.DrawId,
                        principalTable: "Draws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesOthers",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    OtherId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesOthers", x => new { x.DisciplineId, x.OtherId });
                    table.ForeignKey(
                        name: "FK_DisciplinesOthers_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinesOthers_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesEmployees",
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
                    table.PrimaryKey("PK_DisciplinesEmployees", x => new { x.DisciplineId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_DisciplinesEmployees_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesPojects",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesPojects", x => new { x.DisciplineId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_DisciplinesPojects_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                });

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
                    EstimatedMandays = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: false),
                    MenHours = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedCompleted = table.Column<float>(type: "real", nullable: false),
                    Completed = table.Column<float>(type: "real", nullable: false),
                    WorkPackegedCompleted = table.Column<float>(type: "real", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkPackege = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    ProjectManagerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
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
                name: "UsersRoles",
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
                    table.PrimaryKey("PK_UsersRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 144641554, new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1811), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1812), 0.0, "Draw_8_0" },
                    { 168288663, new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1053), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1054), 0.0, "Draw_4_1" },
                    { 182416264, new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(564), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(565), 0.0, "Draw_1_5" },
                    { 183177557, new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1233), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1234), 0.0, "Draw_5_1" },
                    { 189384369, new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(873), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(874), 0.0, "Draw_3_1" },
                    { 197156981, new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1516), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1517), 0.0, "Draw_6_4" },
                    { 201450124, new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1081), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1082), 0.0, "Draw_4_3" },
                    { 202519970, new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1246), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1248), 0.0, "Draw_5_2" },
                    { 206425886, new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1335), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1336), 0.0, "Draw_5_4" },
                    { 207681306, new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(680), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(681), 0.0, "Draw_2_0" },
                    { 220344001, new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1853), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1854), 0.0, "Draw_8_3" },
                    { 224842332, new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2003), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2004), 0.0, "Draw_9_1" },
                    { 268783067, new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1635), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1636), 0.0, "Draw_7_0" },
                    { 270023899, new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1067), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1068), 0.0, "Draw_4_2" },
                    { 314663041, new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(549), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(550), 0.0, "Draw_1_4" },
                    { 365851462, new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2197), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2198), 0.0, "Draw_10_2" },
                    { 370542511, new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1039), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1040), 0.0, "Draw_4_0" },
                    { 387236848, new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2224), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2225), 0.0, "Draw_10_4" },
                    { 394628883, new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1470), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1471), 0.0, "Draw_6_1" },
                    { 396859735, new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2184), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2185), 0.0, "Draw_10_1" },
                    { 400786618, new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1676), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1678), 0.0, "Draw_7_3" },
                    { 403341508, new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1530), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1531), 0.0, "Draw_6_5" },
                    { 408773475, new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1881), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1882), 0.0, "Draw_8_5" },
                    { 422204221, new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1484), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1485), 0.0, "Draw_6_2" },
                    { 427098830, new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2169), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2170), 0.0, "Draw_10_0" },
                    { 427686875, new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(695), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(696), 0.0, "Draw_2_1" },
                    { 428967215, new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1094), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1095), 0.0, "Draw_4_4" },
                    { 430585922, new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(932), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(933), 0.0, "Draw_3_5" },
                    { 432279365, new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(886), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(887), 0.0, "Draw_3_2" },
                    { 450806025, new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1825), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1826), 0.0, "Draw_8_1" },
                    { 451270433, new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1989), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1990), 0.0, "Draw_9_0" },
                    { 456965977, new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2211), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2212), 0.0, "Draw_10_3" },
                    { 494283968, new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(535), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(536), 0.0, "Draw_1_3" },
                    { 507864768, new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1690), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1691), 0.0, "Draw_7_4" },
                    { 529493650, new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1663), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1664), 0.0, "Draw_7_2" },
                    { 573216439, new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2061), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2062), 0.0, "Draw_9_5" },
                    { 585981311, new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(709), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(710), 0.0, "Draw_2_2" },
                    { 591635642, new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1318), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1319), 0.0, "Draw_5_3" },
                    { 650000571, new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(752), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(753), 0.0, "Draw_2_5" },
                    { 665078502, new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1108), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1109), 0.0, "Draw_4_5" },
                    { 667689595, new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1218), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1219), 0.0, "Draw_5_0" },
                    { 693159904, new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1502), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1504), 0.0, "Draw_6_3" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 696482948, new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(521), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(522), 0.0, "Draw_1_2" },
                    { 722101297, new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1703), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1705), 0.0, "Draw_7_5" },
                    { 748795610, new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(900), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(901), 0.0, "Draw_3_3" },
                    { 784075972, new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1456), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1458), 0.0, "Draw_6_0" },
                    { 790498617, new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(484), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(485), 0.0, "Draw_1_0" },
                    { 796445014, new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1867), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1868), 0.0, "Draw_8_4" },
                    { 799225847, new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2047), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2048), 0.0, "Draw_9_4" },
                    { 804282243, new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1649), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1651), 0.0, "Draw_7_1" },
                    { 817947839, new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1348), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1349), 0.0, "Draw_5_5" },
                    { 826234484, new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2238), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2239), 0.0, "Draw_10_5" },
                    { 841987139, new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(914), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(915), 0.0, "Draw_3_4" },
                    { 866970759, new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2017), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2018), 0.0, "Draw_9_2" },
                    { 876944981, new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(506), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(507), 0.0, "Draw_1_1" },
                    { 886207183, new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1840), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1841), 0.0, "Draw_8_2" },
                    { 922667020, new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(738), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(739), 0.0, "Draw_2_4" },
                    { 933498532, new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2030), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2031), 0.0, "Draw_9_3" },
                    { 944505323, new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(724), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(725), 0.0, "Draw_2_3" },
                    { 992341611, new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(859), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(860), 0.0, "Draw_3_0" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -2142692738, 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(293), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(294), 0.0, "Printing" },
                    { -1951914933, 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(335), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(336), 0.0, "Administration" },
                    { 47383112, 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(275), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(276), 0.0, "Communications" },
                    { 833021917, 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(321), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(322), 0.0, "Meetings" },
                    { 1474260625, 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(308), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(309), 0.0, "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 148428593, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9900), true, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9901), "Designer" },
                    { 323198473, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9952), false, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9954), "Customer" },
                    { 383895060, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9924), true, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9925), "COO" },
                    { 556293900, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9931), true, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9932), "CTO" },
                    { 589718184, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9945), false, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9946), "Guest" },
                    { 664467564, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9908), true, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9910), "Engineer" },
                    { 862062552, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9938), true, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9939), "CEO" },
                    { 940543325, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9916), true, new DateTime(2024, 2, 24, 12, 58, 59, 787, DateTimeKind.Local).AddTicks(9917), "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 145161433, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3197), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3198), null, "6949277784", null, null, null },
                    { 158766516, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(161), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(162), null, "6949277782", null, null, null },
                    { 200299085, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(578), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(579), null, "6949277784", null, null, null },
                    { 237580711, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(215), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(216), null, "6949277784", null, null, null },
                    { 305535100, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(245), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(246), null, "6949277785", null, null, null },
                    { 342107601, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2253), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2254), null, "6949277783", null, null, null },
                    { 355713677, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(188), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(190), null, "6949277783", null, null, null },
                    { 434074784, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2075), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2076), null, "69492777812", null, null, null },
                    { 446911766, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(61), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(62), null, "6949277780", null, null, null },
                    { 470983385, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1121), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1122), null, "6949277787", null, null, null },
                    { 481100483, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1544), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1545), null, "6949277789", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 674530511, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(947), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(948), null, "6949277786", null, null, null },
                    { 686713114, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1717), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1719), null, "69492777810", null, null, null },
                    { 719894279, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(132), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(133), null, "6949277781", null, null, null },
                    { 884839152, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(767), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(768), null, "6949277785", null, null, null },
                    { 895616734, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(354), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(355), null, "6949277783", null, null, null },
                    { 990169893, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1362), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1364), null, "6949277788", null, null, null },
                    { 996056181, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1894), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1895), null, "69492777811", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -2010469768, 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3226), 145161433, 1500L, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3228), 0L, "HVAC" },
                    { 695079976, 0f, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2285), 342107601, 1500L, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2287), 0L, "ELEC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 146882298, "ALPHA", 1, "D-22-166", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 11.0, 36, new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 36, "Test Description Project_6", "KL-6", new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_6", 5.0, new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_36", 6.0, 990169893, new DateTime(2027, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f },
                    { 331794749, "NBG_IBANK", 1, "D-22-165", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 10.0, 25, new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 25, "Test Description Project_25", "KL-5", new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_5", 5.0, new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_15", 5.0, 470983385, new DateTime(2026, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f },
                    { 470840434, "ALPHA", 1, "D-22-1610", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 15.0, 100, new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 100, "Test Description Project_40", "KL-10", new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_10", 5.0, new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_10", 10.0, 434074784, new DateTime(2032, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f },
                    { 545853012, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 9.0, 16, new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 16, "Test Description Project_24", "KL-4", new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_4", 5.0, new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_20", 4.0, 674530511, new DateTime(2025, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f },
                    { 619198174, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 6.0, 1, new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_1", 5.0, new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_2", 1.0, 895616734, new DateTime(2024, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f },
                    { 799617653, "ALPHA", 1, "D-22-168", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 13.0, 64, new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 64, "Test Description Project_24", "KL-8", new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_8", 5.0, new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_48", 8.0, 686713114, new DateTime(2029, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f },
                    { 875857197, "NBG_IBANK", 1, "D-22-169", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 14.0, 81, new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 81, "Test Description Project_9", "KL-9", new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_9", 5.0, new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_36", 9.0, 996056181, new DateTime(2030, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f },
                    { 880772003, "NBG_IBANK", 1, "D-22-167", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 12.0, 49, new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 49, "Test Description Project_14", "KL-7", new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_7", 5.0, new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_14", 7.0, 481100483, new DateTime(2028, 3, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f },
                    { 901558465, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 7.0, 4, new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 4, "Test Description Project_8", "KL-2", new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_2", 5.0, new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_12", 2.0, 200299085, new DateTime(2024, 6, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f },
                    { 927133587, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 8.0, 9, new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 9, "Test Description Project_3", "KL-3", new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0L, "Project_3", 5.0, new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), "Payment Detailes For Project_9", 3.0, 884839152, new DateTime(2024, 11, 24, 12, 58, 59, 784, DateTimeKind.Local).AddTicks(6181), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 664467564, 145161433, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3214), 828698538, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3215) },
                    { 148428593, 158766516, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(176), 679601876, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(177) },
                    { 940543325, 200299085, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(594), 849865355, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(595) },
                    { 148428593, 237580711, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(231), 635876349, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(232) },
                    { 148428593, 305535100, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(260), 626476190, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(262) },
                    { 664467564, 342107601, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2271), 492034759, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2272) },
                    { 148428593, 355713677, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(203), 378341157, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(204) },
                    { 940543325, 434074784, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2090), 586192912, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2091) },
                    { 148428593, 446911766, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(115), 877322254, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(117) },
                    { 940543325, 470983385, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1136), 915434662, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1137) },
                    { 940543325, 481100483, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1559), 436970685, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1560) },
                    { 940543325, 674530511, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(962), 942407664, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(963) },
                    { 940543325, 686713114, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1733), 155376971, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1734) },
                    { 148428593, 719894279, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(148), 233943362, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(149) },
                    { 940543325, 884839152, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(782), 483060592, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(783) },
                    { 940543325, 895616734, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(373), 559687862, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(374) },
                    { 940543325, 990169893, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1379), 866925573, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1380) },
                    { 940543325, 996056181, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1909), 625206066, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1910) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2010469768, 144641554, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3890), 670094485, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3891) },
                    { -2010469768, 168288663, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3611), 769941090, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3612) },
                    { -2010469768, 182416264, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3442), 630385837, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3443) },
                    { -2010469768, 183177557, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3683), 960916426, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3684) },
                    { -2010469768, 189384369, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3539), 519160610, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3540) },
                    { -2010469768, 197156981, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3794), 416821937, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3795) },
                    { -2010469768, 201450124, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3635), 430608472, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3636) },
                    { -2010469768, 202519970, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3695), 946837654, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3696) },
                    { -2010469768, 206425886, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3719), 247107682, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3720) },
                    { -2010469768, 207681306, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3454), 371813426, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3455) },
                    { -2010469768, 220344001, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3926), 771728670, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3927) },
                    { -2010469768, 224842332, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3974), 863381200, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3975) },
                    { -2010469768, 268783067, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3818), 779094366, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3819) },
                    { -2010469768, 270023899, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3623), 833019908, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3624) },
                    { -2010469768, 314663041, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3429), 259421028, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3430) },
                    { -2010469768, 365851462, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4058), 357661451, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4059) },
                    { -2010469768, 370542511, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3599), 792501275, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3600) },
                    { -2010469768, 387236848, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4081), 639021993, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4083) },
                    { -2010469768, 394628883, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3758), 642723582, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3759) },
                    { -2010469768, 396859735, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4046), 381786022, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4047) },
                    { -2010469768, 400786618, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3854), 465228810, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3855) },
                    { -2010469768, 403341508, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3806), 361531514, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3807) },
                    { -2010469768, 408773475, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3950), 239609497, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3951) },
                    { -2010469768, 422204221, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3770), 879082336, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3771) },
                    { -2010469768, 427098830, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4034), 829697305, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4035) },
                    { -2010469768, 427686875, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3466), 396364844, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3468) },
                    { -2010469768, 428967215, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3647), 668745682, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3648) },
                    { -2010469768, 430585922, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3587), 344953596, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3588) },
                    { -2010469768, 432279365, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3551), 144896708, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3552) },
                    { -2010469768, 450806025, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3902), 301244378, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3903) },
                    { -2010469768, 451270433, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3962), 768988827, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3963) },
                    { -2010469768, 456965977, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4069), 804939349, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4071) },
                    { -2010469768, 494283968, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3417), 633437815, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3418) },
                    { -2010469768, 507864768, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3866), 784724426, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3867) },
                    { -2010469768, 529493650, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3842), 707633877, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3843) },
                    { -2010469768, 573216439, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4022), 303405441, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4023) },
                    { -2010469768, 585981311, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3479), 421990887, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3480) },
                    { -2010469768, 591635642, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3707), 491648453, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3708) },
                    { -2010469768, 650000571, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3515), 985753142, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3516) },
                    { -2010469768, 665078502, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3659), 357046906, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3660) },
                    { -2010469768, 667689595, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3671), 342604736, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3672) },
                    { -2010469768, 693159904, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3782), 216812899, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3783) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2010469768, 696482948, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3405), 384264749, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3406) },
                    { -2010469768, 722101297, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3878), 401693696, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3879) },
                    { -2010469768, 748795610, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3563), 876622960, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3564) },
                    { -2010469768, 784075972, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3746), 144172660, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3747) },
                    { -2010469768, 790498617, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3378), 473249764, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3379) },
                    { -2010469768, 796445014, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3938), 756304929, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3939) },
                    { -2010469768, 799225847, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4010), 498585180, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4011) },
                    { -2010469768, 804282243, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3830), 736302459, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3831) },
                    { -2010469768, 817947839, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3734), 623944240, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3735) },
                    { -2010469768, 826234484, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4093), 997967196, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4095) },
                    { -2010469768, 841987139, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3574), 244904474, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3576) },
                    { -2010469768, 866970759, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3986), 382006066, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3987) },
                    { -2010469768, 876944981, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3390), 661780178, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3391) },
                    { -2010469768, 886207183, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3914), 680844531, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3915) },
                    { -2010469768, 922667020, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3503), 845369065, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3504) },
                    { -2010469768, 933498532, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3998), 846267747, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3999) },
                    { -2010469768, 944505323, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3491), 911476414, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3492) },
                    { -2010469768, 992341611, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3527), 522789456, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3528) },
                    { 695079976, 144641554, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2980), 301325128, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2981) },
                    { 695079976, 168288663, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2704), 677136926, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2705) },
                    { 695079976, 182416264, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2532), 920744316, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2533) },
                    { 695079976, 183177557, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2776), 780407052, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2777) },
                    { 695079976, 189384369, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2628), 389791741, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2629) },
                    { 695079976, 197156981, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2884), 740457239, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2885) },
                    { 695079976, 201450124, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2728), 999116313, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2729) },
                    { 695079976, 202519970, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2787), 604235743, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2789) },
                    { 695079976, 206425886, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2811), 226809763, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2812) },
                    { 695079976, 207681306, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2544), 962714038, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2545) },
                    { 695079976, 220344001, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3016), 240514440, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3017) },
                    { 695079976, 224842332, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3066), 814625440, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3067) },
                    { 695079976, 268783067, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2908), 626484539, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2909) },
                    { 695079976, 270023899, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2716), 982826173, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2717) },
                    { 695079976, 314663041, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2519), 548431386, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2520) },
                    { 695079976, 365851462, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3149), 328622676, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3150) },
                    { 695079976, 370542511, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2689), 143531267, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2690) },
                    { 695079976, 387236848, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3173), 887878889, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3174) },
                    { 695079976, 394628883, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2847), 132649873, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2849) },
                    { 695079976, 396859735, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3137), 555988272, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3138) },
                    { 695079976, 400786618, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2944), 393040441, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2945) },
                    { 695079976, 403341508, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2896), 502212670, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2897) },
                    { 695079976, 408773475, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3039), 435672316, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3040) },
                    { 695079976, 422204221, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2859), 854457618, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2860) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 695079976, 427098830, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3125), 695028972, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3126) },
                    { 695079976, 427686875, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2556), 430279046, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2557) },
                    { 695079976, 428967215, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2740), 291976061, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2741) },
                    { 695079976, 430585922, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2677), 916456223, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2678) },
                    { 695079976, 432279365, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2640), 835874682, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2641) },
                    { 695079976, 450806025, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2992), 207740215, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2993) },
                    { 695079976, 451270433, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3054), 850498423, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3055) },
                    { 695079976, 456965977, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3161), 737926891, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3162) },
                    { 695079976, 494283968, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2507), 173430180, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2508) },
                    { 695079976, 507864768, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2956), 869721896, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2957) },
                    { 695079976, 529493650, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2932), 426425111, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2933) },
                    { 695079976, 573216439, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3113), 402791813, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3114) },
                    { 695079976, 585981311, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2568), 545648634, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2569) },
                    { 695079976, 591635642, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2799), 585905036, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2801) },
                    { 695079976, 650000571, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2604), 364141658, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2606) },
                    { 695079976, 665078502, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2752), 879858948, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2753) },
                    { 695079976, 667689595, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2764), 150144955, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2765) },
                    { 695079976, 693159904, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2872), 144199029, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2873) },
                    { 695079976, 696482948, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2495), 828939107, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2496) },
                    { 695079976, 722101297, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2968), 612248261, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2969) },
                    { 695079976, 748795610, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2652), 224756419, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2653) },
                    { 695079976, 784075972, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2835), 347310354, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2836) },
                    { 695079976, 790498617, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2466), 836646103, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2467) },
                    { 695079976, 796445014, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3027), 158372333, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3028) },
                    { 695079976, 799225847, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3102), 222572030, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3103) },
                    { 695079976, 804282243, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2920), 626515002, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2921) },
                    { 695079976, 817947839, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2823), 856288438, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2824) },
                    { 695079976, 826234484, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3185), 548093820, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3186) },
                    { 695079976, 841987139, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2664), 669537046, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2665) },
                    { 695079976, 866970759, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3078), 447606637, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3079) },
                    { 695079976, 876944981, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2482), 176658733, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2483) },
                    { 695079976, 886207183, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3004), 354593834, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3005) },
                    { 695079976, 922667020, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2593), 351544610, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2594) },
                    { 695079976, 933498532, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3090), 148718022, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3091) },
                    { 695079976, 944505323, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2580), 727937139, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2582) },
                    { 695079976, 992341611, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2616), 847540811, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2617) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2010469768, 158766516, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3327), 1495304676, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3328) },
                    { -2010469768, 237580711, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3353), 649572017, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3354) },
                    { -2010469768, 305535100, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3365), 1924614464, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3366) },
                    { -2010469768, 355713677, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3341), -859905782, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3342) },
                    { -2010469768, 446911766, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3302), -36175094, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3303) },
                    { -2010469768, 719894279, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3315), -2020804037, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3316) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 695079976, 158766516, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2413), 1751757903, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2414) },
                    { 695079976, 237580711, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2437), 1684184679, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2439) },
                    { 695079976, 305535100, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2451), 630593897, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2452) },
                    { 695079976, 355713677, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2425), -44397004, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2426) },
                    { 695079976, 446911766, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2385), 1750742636, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2386) },
                    { 695079976, 719894279, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2400), -374539198, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2401) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2010469768, -2142692738, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3252), 992584044, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3253) },
                    { -2010469768, -1951914933, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3290), 796298244, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3291) },
                    { -2010469768, 47383112, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3239), 963532558, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3240) },
                    { -2010469768, 833021917, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3276), 843325329, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3278) },
                    { -2010469768, 1474260625, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3264), 291092903, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(3265) },
                    { 695079976, -2142692738, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2327), 860985296, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2328) },
                    { 695079976, -1951914933, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2369), 849051003, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2370) },
                    { 695079976, 47383112, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2310), 466638994, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2311) },
                    { 695079976, 833021917, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2356), 761369239, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2357) },
                    { 695079976, 1474260625, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2340), 564662287, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2341) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2010469768, 146882298, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4263), -639081832, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4264) },
                    { -2010469768, 331794749, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4236), 1341355888, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4237) },
                    { -2010469768, 470840434, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4410), 474325849, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4411) },
                    { -2010469768, 545853012, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4210), 1928298818, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4211) },
                    { -2010469768, 619198174, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4131), 1349994610, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4132) },
                    { -2010469768, 799617653, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4314), -2059302970, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4315) },
                    { -2010469768, 875857197, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4384), 365826486, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4385) },
                    { -2010469768, 880772003, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4288), -975839776, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4289) },
                    { -2010469768, 901558465, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4157), -4245586, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4159) },
                    { -2010469768, 927133587, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4184), -1556965010, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4185) },
                    { 695079976, 146882298, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4250), 1607983904, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4251) },
                    { 695079976, 331794749, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4223), 1152703714, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4224) },
                    { 695079976, 470840434, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4397), 563864118, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4398) },
                    { 695079976, 545853012, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4198), -842235656, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4199) },
                    { 695079976, 619198174, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4111), 930506156, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4112) },
                    { 695079976, 799617653, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4301), 1434869653, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4302) },
                    { 695079976, 875857197, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4369), -2127451540, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4370) },
                    { 695079976, 880772003, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4275), 437180154, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4277) },
                    { 695079976, 901558465, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4145), -586130615, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4146) },
                    { 695079976, 927133587, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4171), -1053913911, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(4172) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 162908264, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1620), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1622), 10003000.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1621), "Signature 1423435", 40056, 880772003, 7.0, 17.0 },
                    { 172183438, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1200), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1202), 103000.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1201), "Signature 1423420", 41805, 331794749, 5.0, 17.0 },
                    { 379187970, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1441), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1443), 1003000.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1442), "Signature 1423430", 72073, 146882298, 6.0, 24.0 },
                    { 441271113, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1023), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1025), 13000.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1024), "Signature 1423412", 70189, 545853012, 4.0, 24.0 },
                    { 466709843, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1972), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1974), 1000003000.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1973), "Signature 1423427", 37229, 875857197, 9.0, 17.0 },
                    { 537942985, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1796), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1798), 100003000.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1797), "Signature 142348", 45581, 799617653, 8.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 577728260, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(842), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(844), 4000.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(843), "Signature 142346", 78028, 927133587, 3.0, 17.0 },
                    { 652400275, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(663), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(665), 3100.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(664), "Signature 142348", 87289, 901558465, 2.0, 24.0 },
                    { 901674286, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(464), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(466), 3010.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(465), "Signature 142343", 28604, 619198174, 1.0, 17.0 },
                    { 989497575, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2153), new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2155), 10000003000.0, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2154), "Signature 1423420", 72929, 470840434, 10.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 266964563, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1412), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1414), null, "6949277786", null, null, 146882298 },
                    { 374240543, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(994), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(995), null, "6949277784", null, null, 545853012 },
                    { 377156025, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(630), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(631), null, "6949277782", null, null, 901558465 },
                    { 633860761, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(814), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(815), null, "6949277783", null, null, 927133587 },
                    { 642412096, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1168), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1169), null, "6949277785", null, null, 331794749 },
                    { 697053125, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1768), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1769), null, "6949277788", null, null, 799617653 },
                    { 703309959, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1592), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1593), null, "6949277787", null, null, 880772003 },
                    { 819633637, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(431), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(432), null, "6949277781", null, null, 619198174 },
                    { 871497631, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1943), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1944), null, "6949277789", null, null, 875857197 },
                    { 875446291, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2123), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2125), null, "69492777810", null, null, 470840434 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 323198473, 266964563, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1428), 382571169, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1429) },
                    { 323198473, 374240543, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1010), 980660406, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1011) },
                    { 323198473, 377156025, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(650), 678569666, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(651) },
                    { 323198473, 633860761, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(829), 820176791, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(830) },
                    { 323198473, 642412096, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1184), 709908684, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1185) },
                    { 323198473, 697053125, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1783), 143865263, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1784) },
                    { 323198473, 703309959, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1607), 799619673, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1608) },
                    { 323198473, 819633637, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(449), 977818741, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(450) },
                    { 323198473, 871497631, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1959), 872969890, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(1960) },
                    { 323198473, 875446291, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2140), 826088710, new DateTime(2024, 2, 24, 12, 58, 59, 788, DateTimeKind.Local).AddTicks(2141) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_TimeSpanId",
                table: "DailyHour",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_UserId",
                table: "DailyHour",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_EngineerId",
                table: "Disciplines",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesDraws_DrawId",
                table: "DisciplinesDraws",
                column: "DrawId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesEmployees_EmployeeId",
                table: "DisciplinesEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesOthers_OtherId",
                table: "DisciplinesOthers",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesPojects_ProjectId",
                table: "DisciplinesPojects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectId",
                table: "Users",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RoleId",
                table: "UsersRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyHour_Users_UserId",
                table: "DailyHour",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Users_EngineerId",
                table: "Disciplines",
                column: "EngineerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinesEmployees_Users_EmployeeId",
                table: "DisciplinesEmployees",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinesPojects_Projects_ProjectId",
                table: "DisciplinesPojects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "DailyHour");

            migrationBuilder.DropTable(
                name: "DisciplinesDraws");

            migrationBuilder.DropTable(
                name: "DisciplinesEmployees");

            migrationBuilder.DropTable(
                name: "DisciplinesOthers");

            migrationBuilder.DropTable(
                name: "DisciplinesPojects");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Timespan");

            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
