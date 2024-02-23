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
                    CompletionEstimation = table.Column<int>(type: "int", nullable: false),
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
                    CompletionEstimation = table.Column<int>(type: "int", nullable: false),
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
                    Completed = table.Column<int>(type: "int", nullable: false),
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
                    Completed = table.Column<int>(type: "int", nullable: true),
                    WorkPackegedCompleted = table.Column<int>(type: "int", nullable: true),
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
                    { 150755613, new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6619), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6620), 0.0, "Draw_5_5" },
                    { 186830589, new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7453), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7454), 0.0, "Draw_10_4" },
                    { 208106659, new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6382), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6383), 0.0, "Draw_4_0" },
                    { 213426481, new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6956), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6957), 0.0, "Draw_7_5" },
                    { 231836868, new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6890), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6891), 0.0, "Draw_7_0" },
                    { 231913565, new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5928), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5929), 0.0, "Draw_1_5" },
                    { 237841396, new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6930), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6931), 0.0, "Draw_7_3" },
                    { 281272530, new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5873), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5874), 0.0, "Draw_1_1" },
                    { 285156700, new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7116), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7117), 0.0, "Draw_8_4" },
                    { 313147476, new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7427), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7428), 0.0, "Draw_10_2" },
                    { 331521815, new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6592), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6593), 0.0, "Draw_5_3" },
                    { 380278895, new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6774), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6775), 0.0, "Draw_6_4" },
                    { 392237839, new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7258), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7259), 0.0, "Draw_9_2" },
                    { 397748436, new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6260), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6261), 0.0, "Draw_3_4" },
                    { 404455528, new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6094), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6095), 0.0, "Draw_2_4" },
                    { 430845975, new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6733), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6734), 0.0, "Draw_6_1" },
                    { 436380881, new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7465), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7466), 0.0, "Draw_10_5" },
                    { 445577906, new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5855), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5856), 0.0, "Draw_1_0" },
                    { 452680197, new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6081), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6082), 0.0, "Draw_2_3" },
                    { 457432057, new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7414), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7415), 0.0, "Draw_10_1" },
                    { 459202197, new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5913), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5915), 0.0, "Draw_1_4" },
                    { 462334257, new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7103), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7104), 0.0, "Draw_8_3" },
                    { 467894746, new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6904), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6905), 0.0, "Draw_7_1" },
                    { 471229362, new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7128), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7129), 0.0, "Draw_8_5" },
                    { 497051524, new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6421), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6422), 0.0, "Draw_4_3" },
                    { 515572850, new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7245), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7246), 0.0, "Draw_9_1" },
                    { 520558302, new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6063), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6064), 0.0, "Draw_2_2" },
                    { 530456690, new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6209), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6210), 0.0, "Draw_3_0" },
                    { 562151861, new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7284), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7285), 0.0, "Draw_9_4" },
                    { 598703319, new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6720), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6721), 0.0, "Draw_6_0" },
                    { 609987285, new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7232), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7233), 0.0, "Draw_9_0" },
                    { 624771957, new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7271), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7272), 0.0, "Draw_9_3" },
                    { 625352232, new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7070), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7071), 0.0, "Draw_8_1" },
                    { 653667396, new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6576), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6577), 0.0, "Draw_5_2" },
                    { 659638679, new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6550), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6551), 0.0, "Draw_5_0" },
                    { 672919326, new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6408), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6409), 0.0, "Draw_4_2" },
                    { 688690399, new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6222), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6223), 0.0, "Draw_3_1" },
                    { 724409980, new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6107), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6108), 0.0, "Draw_2_5" },
                    { 732056811, new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6761), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6762), 0.0, "Draw_6_3" },
                    { 736932286, new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6917), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6918), 0.0, "Draw_7_2" },
                    { 752019201, new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7296), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7298), 0.0, "Draw_9_5" },
                    { 756649682, new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6787), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6788), 0.0, "Draw_6_5" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 793308943, new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6274), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6275), 0.0, "Draw_3_5" },
                    { 797870000, new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6050), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6051), 0.0, "Draw_2_1" },
                    { 850127312, new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6037), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6038), 0.0, "Draw_2_0" },
                    { 857927244, new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7401), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7402), 0.0, "Draw_10_0" },
                    { 895330262, new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6395), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6397), 0.0, "Draw_4_1" },
                    { 903363272, new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6943), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6944), 0.0, "Draw_7_4" },
                    { 903512458, new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6563), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6564), 0.0, "Draw_5_1" },
                    { 908882419, new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7057), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7058), 0.0, "Draw_8_0" },
                    { 913623926, new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6746), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6747), 0.0, "Draw_6_2" },
                    { 927727373, new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6247), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6248), 0.0, "Draw_3_3" },
                    { 935107194, new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6606), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6607), 0.0, "Draw_5_4" },
                    { 937649056, new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6434), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6435), 0.0, "Draw_4_4" },
                    { 939781834, new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6234), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6235), 0.0, "Draw_3_2" },
                    { 950769661, new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6446), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6448), 0.0, "Draw_4_5" },
                    { 972354661, new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7090), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7091), 0.0, "Draw_8_2" },
                    { 973394463, new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5887), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5888), 0.0, "Draw_1_2" },
                    { 978431650, new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7440), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7441), 0.0, "Draw_10_3" },
                    { 993076954, new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5900), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5901), 0.0, "Draw_1_3" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -2005940454, 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5667), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5668), 0.0, "Printing" },
                    { 254065322, 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5694), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5695), 0.0, "Meetings" },
                    { 531418396, 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5647), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5648), 0.0, "Communications" },
                    { 1754013534, 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5708), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5709), 0.0, "Administration" },
                    { 1894985537, 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5681), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5682), 0.0, "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 199303708, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5292), true, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5294), "COO" },
                    { 408195430, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5285), true, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5286), "Project Manager" },
                    { 416566847, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5308), true, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5309), "CEO" },
                    { 444315374, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5322), false, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5325), "Customer" },
                    { 733152848, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5300), true, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5301), "CTO" },
                    { 762241358, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5315), false, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5316), "Guest" },
                    { 881630960, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5278), true, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5279), "Engineer" },
                    { 927691432, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5270), true, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5271), "Designer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 123747015, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5432), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5433), null, "6949277780", null, null, null },
                    { 142699358, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5537), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5538), null, "6949277782", null, null, null },
                    { 147235949, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6459), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6461), null, "6949277787", null, null, null },
                    { 162410565, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6120), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6121), null, "6949277785", null, null, null },
                    { 229885400, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6800), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6801), null, "6949277789", null, null, null },
                    { 272235757, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5589), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5590), null, "6949277784", null, null, null },
                    { 296896845, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7309), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7310), null, "69492777812", null, null, null },
                    { 380776383, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6632), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6633), null, "6949277788", null, null, null },
                    { 381691402, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5508), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5509), null, "6949277781", null, null, null },
                    { 415290755, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5941), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5942), null, "6949277784", null, null, null },
                    { 522255166, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5724), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5726), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 529411519, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7480), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7481), null, "6949277783", null, null, null },
                    { 531506058, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5619), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5620), null, "6949277785", null, null, null },
                    { 563373935, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7141), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7142), null, "69492777811", null, null, null },
                    { 607041681, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8428), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8430), null, "6949277784", null, null, null },
                    { 806186194, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6969), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6970), null, "69492777810", null, null, null },
                    { 869409950, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6288), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6289), null, "6949277786", null, null, null },
                    { 961283697, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5563), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5564), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1614471712, 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7511), 529411519, 2345L, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7512), 3425L, "ELEC" },
                    { 338390816, 0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8456), 607041681, 2345L, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8458), 3425L, "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 154322207, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 9.0, 16, new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 16, "Test Description Project_16", "KL-4", new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 64L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_4", 5.0, new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_24", 4.0, 869409950, new DateTime(2025, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 },
                    { 300978413, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 7.0, 4, new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 4, "Test Description Project_8", "KL-2", new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 8L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_2", 5.0, new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_6", 2.0, 415290755, new DateTime(2024, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 },
                    { 353435541, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 10.0, 25, new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 25, "Test Description Project_20", "KL-5", new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 125L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_5", 5.0, new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_5", 5.0, 147235949, new DateTime(2026, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 },
                    { 399687783, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 14.0, 81, new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 81, "Test Description Project_54", "KL-9", new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 729L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_9", 5.0, new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_27", 9.0, 563373935, new DateTime(2030, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 },
                    { 416517696, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 15.0, 100, new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 100, "Test Description Project_50", "KL-10", new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 1000L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_10", 5.0, new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_40", 10.0, 296896845, new DateTime(2032, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 },
                    { 426664564, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 8.0, 9, new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 9, "Test Description Project_9", "KL-3", new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 27L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_3", 5.0, new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_3", 3.0, 162410565, new DateTime(2024, 11, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 },
                    { 459317842, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 11.0, 36, new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 36, "Test Description Project_18", "KL-6", new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 216L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_6", 5.0, new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_6", 6.0, 380776383, new DateTime(2027, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 },
                    { 498207896, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 6.0, 1, new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 1, "Test Description Project_4", "KL-1", new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 1L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_1", 5.0, new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_1", 1.0, 522255166, new DateTime(2024, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 },
                    { 503441939, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 13.0, 64, new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 64, "Test Description Project_32", "KL-8", new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 512L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_8", 5.0, new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_40", 8.0, 806186194, new DateTime(2029, 6, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 },
                    { 683720207, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 12.0, 49, new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 49, "Test Description Project_35", "KL-7", new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 3000L, 343L, new DateTime(2024, 2, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0L, "Project_7", 5.0, new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), "Payment Detailes For Project_21", 7.0, 229885400, new DateTime(2028, 3, 23, 21, 29, 10, 289, DateTimeKind.Local).AddTicks(4260), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 927691432, 123747015, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5483), 920602376, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5485) },
                    { 927691432, 142699358, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5551), 387581139, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5552) },
                    { 408195430, 147235949, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6474), 144863073, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6475) },
                    { 408195430, 162410565, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6135), 272159048, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6136) },
                    { 408195430, 229885400, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6817), 740467883, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6818) },
                    { 927691432, 272235757, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5605), 312313373, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5607) },
                    { 408195430, 296896845, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7324), 160845220, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7325) },
                    { 408195430, 380776383, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6647), 689184753, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6648) },
                    { 927691432, 381691402, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5523), 591487765, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5525) },
                    { 408195430, 415290755, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5957), 262288392, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5958) },
                    { 408195430, 522255166, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5741), 496711500, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5742) },
                    { 881630960, 529411519, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7496), 881130931, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7498) },
                    { 927691432, 531506058, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5633), 651857243, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5634) },
                    { 408195430, 563373935, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7155), 251332670, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7157) },
                    { 881630960, 607041681, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8444), 198138437, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8445) },
                    { 408195430, 806186194, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6984), 690987177, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6985) },
                    { 408195430, 869409950, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6302), 363431276, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6303) },
                    { 927691432, 961283697, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5577), 503883853, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5578) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1614471712, 150755613, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8051), 161037564, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8052) },
                    { -1614471712, 186830589, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8404), 954805139, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8405) },
                    { -1614471712, 208106659, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7916), 637478886, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7917) },
                    { -1614471712, 213426481, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8197), 520546643, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8198) },
                    { -1614471712, 231836868, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8136), 291376287, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8137) },
                    { -1614471712, 231913565, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7758), 793195404, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7759) },
                    { -1614471712, 237841396, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8173), 604243452, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8174) },
                    { -1614471712, 281272530, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7708), 693439495, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7709) },
                    { -1614471712, 285156700, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8257), 246770816, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8258) },
                    { -1614471712, 313147476, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8380), 992889509, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8381) },
                    { -1614471712, 331521815, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8027), 187759085, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8028) },
                    { -1614471712, 380278895, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8112), 991785766, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8113) },
                    { -1614471712, 392237839, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8304), 791030807, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8305) },
                    { -1614471712, 397748436, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7891), 993098026, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7892) },
                    { -1614471712, 404455528, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7819), 655087187, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7820) },
                    { -1614471712, 430845975, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8075), 845983300, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8076) },
                    { -1614471712, 436380881, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8416), 812650106, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8417) },
                    { -1614471712, 445577906, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7688), 979761911, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7689) },
                    { -1614471712, 452680197, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7807), 411376178, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7808) },
                    { -1614471712, 457432057, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8368), 822714467, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8369) },
                    { -1614471712, 459202197, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7745), 547596699, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7746) },
                    { -1614471712, 462334257, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8245), 925279543, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8246) },
                    { -1614471712, 467894746, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8149), 293147144, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8150) },
                    { -1614471712, 471229362, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8268), 262064514, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8269) },
                    { -1614471712, 497051524, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7952), 825556748, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7953) },
                    { -1614471712, 515572850, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8292), 753573971, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8293) },
                    { -1614471712, 520558302, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7794), 965636124, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7795) },
                    { -1614471712, 530456690, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7843), 443762542, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7844) },
                    { -1614471712, 562151861, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8328), 910351886, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8329) },
                    { -1614471712, 598703319, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8063), 505801870, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8064) },
                    { -1614471712, 609987285, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8280), 963228546, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8281) },
                    { -1614471712, 624771957, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8316), 782542982, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8317) },
                    { -1614471712, 625352232, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8221), 256248447, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8222) },
                    { -1614471712, 653667396, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8015), 290120459, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8016) },
                    { -1614471712, 659638679, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7987), 669605883, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7988) },
                    { -1614471712, 672919326, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7940), 167644736, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7941) },
                    { -1614471712, 688690399, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7855), 196527162, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7856) },
                    { -1614471712, 724409980, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7831), 235509360, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7832) },
                    { -1614471712, 732056811, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8100), 875077300, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8101) },
                    { -1614471712, 736932286, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8160), 801191237, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8161) },
                    { -1614471712, 752019201, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8340), 463517454, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8341) },
                    { -1614471712, 756649682, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8124), 755374494, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8125) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1614471712, 793308943, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7904), 674678200, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7905) },
                    { -1614471712, 797870000, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7782), 779292937, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7783) },
                    { -1614471712, 850127312, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7770), 400883255, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7771) },
                    { -1614471712, 857927244, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8355), 836657054, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8357) },
                    { -1614471712, 895330262, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7928), 855087826, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7929) },
                    { -1614471712, 903363272, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8185), 256781929, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8186) },
                    { -1614471712, 903512458, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8003), 598001030, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8004) },
                    { -1614471712, 908882419, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8208), 163471661, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8210) },
                    { -1614471712, 913623926, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8087), 579538610, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8088) },
                    { -1614471712, 927727373, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7879), 212674735, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7880) },
                    { -1614471712, 935107194, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8039), 920510602, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8040) },
                    { -1614471712, 937649056, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7964), 243199715, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7965) },
                    { -1614471712, 939781834, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7867), 763848176, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7868) },
                    { -1614471712, 950769661, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7975), 620578596, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7977) },
                    { -1614471712, 972354661, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8233), 697735338, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8234) },
                    { -1614471712, 973394463, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7720), 844186654, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7721) },
                    { -1614471712, 978431650, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8392), 331294486, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8393) },
                    { -1614471712, 993076954, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7733), 165951388, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7734) },
                    { 338390816, 150755613, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8948), 464861250, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8949) },
                    { 338390816, 186830589, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9291), 753290524, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9292) },
                    { 338390816, 208106659, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8820), 751405480, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8821) },
                    { 338390816, 213426481, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9091), 321902314, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9092) },
                    { 338390816, 231836868, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9033), 869054337, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9034) },
                    { 338390816, 231913565, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8666), 819687053, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8667) },
                    { 338390816, 237841396, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9068), 563139879, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9069) },
                    { 338390816, 281272530, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8615), 424270865, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8617) },
                    { 338390816, 285156700, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9151), 758500208, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9152) },
                    { 338390816, 313147476, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9268), 167523511, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9269) },
                    { 338390816, 331521815, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8925), 825376049, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8926) },
                    { 338390816, 380278895, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9006), 416732963, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9007) },
                    { 338390816, 392237839, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9198), 964094888, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9199) },
                    { 338390816, 397748436, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8797), 358937167, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8798) },
                    { 338390816, 404455528, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8726), 454846142, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8727) },
                    { 338390816, 430845975, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8971), 933231964, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8972) },
                    { 338390816, 436380881, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9303), 754986068, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9304) },
                    { 338390816, 445577906, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8603), 669549231, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8605) },
                    { 338390816, 452680197, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8715), 731880216, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8716) },
                    { 338390816, 457432057, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9255), 312178885, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9256) },
                    { 338390816, 459202197, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8650), 351006859, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8651) },
                    { 338390816, 462334257, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9139), 296505877, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9140) },
                    { 338390816, 467894746, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9045), 980256961, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9046) },
                    { 338390816, 471229362, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9163), 539004183, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9164) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 338390816, 497051524, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8856), 318680075, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8857) },
                    { 338390816, 515572850, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9185), 343192557, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9186) },
                    { 338390816, 520558302, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8702), 360873719, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8704) },
                    { 338390816, 530456690, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8750), 330095896, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8751) },
                    { 338390816, 562151861, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9220), 501532588, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9222) },
                    { 338390816, 598703319, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8960), 705765794, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8961) },
                    { 338390816, 609987285, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9174), 939599079, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9175) },
                    { 338390816, 624771957, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9209), 864568637, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9210) },
                    { 338390816, 625352232, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9115), 784417357, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9116) },
                    { 338390816, 653667396, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8914), 970379239, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8915) },
                    { 338390816, 659638679, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8890), 436227325, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8891) },
                    { 338390816, 672919326, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8844), 266877888, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8845) },
                    { 338390816, 688690399, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8762), 213945207, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8763) },
                    { 338390816, 724409980, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8738), 204394271, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8739) },
                    { 338390816, 732056811, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8994), 967580482, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8995) },
                    { 338390816, 736932286, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9057), 317638458, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9058) },
                    { 338390816, 752019201, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9232), 230019138, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9233) },
                    { 338390816, 756649682, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9021), 582860823, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9022) },
                    { 338390816, 793308943, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8809), 691701727, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8810) },
                    { 338390816, 797870000, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8691), 151075959, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8692) },
                    { 338390816, 850127312, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8679), 986387993, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8680) },
                    { 338390816, 857927244, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9244), 157354127, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9245) },
                    { 338390816, 895330262, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8832), 686827604, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8833) },
                    { 338390816, 903363272, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9079), 277812175, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9081) },
                    { 338390816, 903512458, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8902), 840954791, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8903) },
                    { 338390816, 908882419, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9103), 969353298, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9104) },
                    { 338390816, 913623926, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8983), 716517632, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8984) },
                    { 338390816, 927727373, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8786), 312059788, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8787) },
                    { 338390816, 935107194, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8937), 530013864, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8938) },
                    { 338390816, 937649056, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8867), 936633025, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8868) },
                    { 338390816, 939781834, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8774), 410572857, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8775) },
                    { 338390816, 950769661, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8879), 606801282, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8880) },
                    { 338390816, 972354661, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9127), 876859459, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9128) },
                    { 338390816, 973394463, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8627), 349527663, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8628) },
                    { 338390816, 978431650, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9279), 289113050, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9280) },
                    { 338390816, 993076954, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8639), 874049302, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8640) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1614471712, 123747015, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7603), 518731772, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7604) },
                    { -1614471712, 142699358, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7632), 1137348972, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7633) },
                    { -1614471712, 272235757, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7661), 273103093, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7662) },
                    { -1614471712, 381691402, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7620), -1586827916, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7621) },
                    { -1614471712, 531506058, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7674), -639650663, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7675) },
                    { -1614471712, 961283697, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7648), -337316206, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7650) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 338390816, 123747015, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8530), -2058783929, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8531) },
                    { 338390816, 142699358, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8554), 368424181, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8555) },
                    { 338390816, 272235757, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8580), 865435721, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8581) },
                    { 338390816, 381691402, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8542), -616270495, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8544) },
                    { 338390816, 531506058, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8591), 1022042012, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8592) },
                    { 338390816, 961283697, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8567), -1016928103, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8568) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1614471712, -2005940454, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7549), 316876188, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7551) },
                    { -1614471712, 254065322, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7576), 745591686, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7577) },
                    { -1614471712, 531418396, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7533), 520632382, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7535) },
                    { -1614471712, 1754013534, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7588), 845963930, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7589) },
                    { -1614471712, 1894985537, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7563), 879910028, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7564) },
                    { 338390816, -2005940454, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8482), 304149337, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8483) },
                    { 338390816, 254065322, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8505), 838429147, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8506) },
                    { 338390816, 531418396, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8470), 958488363, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8471) },
                    { 338390816, 1754013534, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8517), 283458198, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8518) },
                    { 338390816, 1894985537, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8493), 150373743, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(8494) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1614471712, 154322207, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9406), 126017776, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9407) },
                    { -1614471712, 300978413, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9350), 1782245998, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9351) },
                    { -1614471712, 353435541, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9433), -316056250, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9434) },
                    { -1614471712, 399687783, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9534), 493107520, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9535) },
                    { -1614471712, 416517696, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9560), 619023888, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9561) },
                    { -1614471712, 426664564, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9375), 877970840, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9377) },
                    { -1614471712, 459317842, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9459), 462786009, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9460) },
                    { -1614471712, 498207896, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9316), -2040478493, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9317) },
                    { -1614471712, 503441939, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9509), -105707896, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9510) },
                    { -1614471712, 683720207, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9484), -654626190, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9485) },
                    { 338390816, 154322207, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9420), -1112366364, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9421) },
                    { 338390816, 300978413, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9362), 283489760, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9363) },
                    { 338390816, 353435541, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9446), 1012239206, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9448) },
                    { 338390816, 399687783, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9547), 1422305555, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9548) },
                    { 338390816, 416517696, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9572), 837144458, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9573) },
                    { 338390816, 426664564, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9392), -479220726, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9394) },
                    { 338390816, 459317842, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9471), 1287819063, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9472) },
                    { 338390816, 498207896, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9336), 1274746568, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9337) },
                    { 338390816, 503441939, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9522), -329396336, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9523) },
                    { 338390816, 683720207, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9497), -502903828, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(9498) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 157669614, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6020), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6022), 3100.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6021), "Signature 1423410", 61704, 300978413, 2.0, 24.0 },
                    { 169441782, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6534), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6536), 103000.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6535), "Signature 1423410", 85870, 353435541, 5.0, 17.0 },
                    { 436723249, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5835), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5837), 3010.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5836), "Signature 142341", 37225, 498207896, 1.0, 17.0 },
                    { 585680331, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7216), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7218), 1000003000.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7217), "Signature 142349", 89427, 399687783, 9.0, 17.0 },
                    { 599726980, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7386), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7388), 10000003000.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7387), "Signature 1423410", 55330, 416517696, 10.0, 24.0 },
                    { 692496370, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6193), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6195), 4000.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6194), "Signature 142343", 17080, 426664564, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 730264885, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6875), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6878), 10003000.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6876), "Signature 1423435", 45427, 683720207, 7.0, 17.0 },
                    { 778878520, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7042), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7044), 100003000.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7043), "Signature 1423448", 39650, 503441939, 8.0, 24.0 },
                    { 863351449, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6706), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6708), 1003000.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6707), "Signature 1423430", 70968, 459317842, 6.0, 24.0 },
                    { 987722966, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6367), new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6369), 13000.0, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6368), "Signature 142348", 46759, 154322207, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 133876727, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6679), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6680), null, "6949277786", null, null, 459317842 },
                    { 199774253, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7015), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7016), null, "6949277788", null, null, 503441939 },
                    { 306360331, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6506), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6508), null, "6949277785", null, null, 353435541 },
                    { 331093356, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7358), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7359), null, "69492777810", null, null, 416517696 },
                    { 369201695, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7190), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7191), null, "6949277789", null, null, 399687783 },
                    { 425451056, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5992), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5993), null, "6949277782", null, null, 300978413 },
                    { 439736573, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5804), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5805), null, "6949277781", null, null, 498207896 },
                    { 446252692, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6339), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6340), null, "6949277784", null, null, 154322207 },
                    { 724738467, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6166), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6167), null, "6949277783", null, null, 426664564 },
                    { 958756226, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6848), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6850), null, "6949277787", null, null, 683720207 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 444315374, 133876727, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6693), 682160128, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6694) },
                    { 444315374, 199774253, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7030), 579153977, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7031) },
                    { 444315374, 306360331, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6522), 492136612, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6523) },
                    { 444315374, 331093356, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7374), 747336445, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7375) },
                    { 444315374, 369201695, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7204), 755801924, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(7205) },
                    { 444315374, 425451056, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6007), 973034051, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6008) },
                    { 444315374, 439736573, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5820), 296755972, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(5822) },
                    { 444315374, 446252692, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6354), 328664675, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6355) },
                    { 444315374, 724738467, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6180), 925405783, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6181) },
                    { 444315374, 958756226, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6863), 162368382, new DateTime(2024, 2, 23, 21, 29, 10, 292, DateTimeKind.Local).AddTicks(6864) }
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
