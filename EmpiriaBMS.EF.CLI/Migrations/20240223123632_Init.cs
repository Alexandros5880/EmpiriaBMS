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
                    { 124438826, new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9237), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9238), 0.0, "Draw_10_3" },
                    { 140620643, new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8627), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8628), 0.0, "Draw_7_0" },
                    { 142226525, new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8511), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8512), 0.0, "Draw_6_5" },
                    { 161684017, new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8277), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8278), 0.0, "Draw_5_2" },
                    { 169785045, new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8858), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8860), 0.0, "Draw_8_3" },
                    { 184621553, new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8466), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8467), 0.0, "Draw_6_2" },
                    { 195506554, new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9193), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9194), 0.0, "Draw_10_0" },
                    { 241480047, new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9251), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9252), 0.0, "Draw_10_4" },
                    { 249985212, new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8497), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8498), 0.0, "Draw_6_4" },
                    { 253710354, new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7946), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7948), 0.0, "Draw_3_5" },
                    { 261462996, new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7930), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7931), 0.0, "Draw_3_4" },
                    { 301625919, new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7514), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7516), 0.0, "Draw_1_2" },
                    { 309390381, new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7711), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7712), 0.0, "Draw_2_2" },
                    { 310737189, new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9265), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9266), 0.0, "Draw_10_5" },
                    { 331103161, new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7873), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7874), 0.0, "Draw_3_0" },
                    { 331288974, new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9062), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9064), 0.0, "Draw_9_4" },
                    { 334638194, new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8684), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8685), 0.0, "Draw_7_4" },
                    { 349463811, new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9077), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9078), 0.0, "Draw_9_5" },
                    { 365262434, new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9208), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9209), 0.0, "Draw_10_1" },
                    { 414479897, new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8061), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8062), 0.0, "Draw_4_0" },
                    { 423624012, new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8120), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8121), 0.0, "Draw_4_4" },
                    { 489940958, new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7476), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7478), 0.0, "Draw_1_0" },
                    { 491977247, new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7759), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7760), 0.0, "Draw_2_5" },
                    { 499183759, new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7681), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7682), 0.0, "Draw_2_0" },
                    { 515283988, new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7499), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7500), 0.0, "Draw_1_1" },
                    { 535467823, new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8134), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8135), 0.0, "Draw_4_5" },
                    { 537338818, new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8887), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8888), 0.0, "Draw_8_5" },
                    { 542481986, new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8872), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8874), 0.0, "Draw_8_4" },
                    { 551075321, new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7696), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7698), 0.0, "Draw_2_1" },
                    { 566938456, new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8451), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8452), 0.0, "Draw_6_1" },
                    { 569587658, new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9034), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9036), 0.0, "Draw_9_2" },
                    { 572627513, new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8829), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8830), 0.0, "Draw_8_1" },
                    { 610208912, new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8106), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8107), 0.0, "Draw_4_3" },
                    { 611412942, new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8670), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8671), 0.0, "Draw_7_3" },
                    { 629755627, new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8656), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8657), 0.0, "Draw_7_2" },
                    { 631391090, new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8323), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8324), 0.0, "Draw_5_5" },
                    { 634847495, new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7902), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7903), 0.0, "Draw_3_2" },
                    { 663974904, new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8483), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8484), 0.0, "Draw_6_3" },
                    { 702738746, new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9005), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9006), 0.0, "Draw_9_0" },
                    { 762472879, new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8698), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8699), 0.0, "Draw_7_5" },
                    { 793158751, new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8436), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8437), 0.0, "Draw_6_0" },
                    { 827117567, new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8309), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8310), 0.0, "Draw_5_4" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 832442228, new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8844), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8845), 0.0, "Draw_8_2" },
                    { 840990636, new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7745), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7746), 0.0, "Draw_2_4" },
                    { 849954170, new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7559), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7560), 0.0, "Draw_1_5" },
                    { 860744340, new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7543), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7545), 0.0, "Draw_1_4" },
                    { 864835858, new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8263), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8264), 0.0, "Draw_5_1" },
                    { 919770530, new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8076), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8078), 0.0, "Draw_4_1" },
                    { 932347068, new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9048), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9050), 0.0, "Draw_9_3" },
                    { 938440492, new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9223), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9224), 0.0, "Draw_10_2" },
                    { 964621561, new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8294), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8295), 0.0, "Draw_5_3" },
                    { 964662840, new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7888), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7889), 0.0, "Draw_3_1" },
                    { 964948190, new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7730), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7732), 0.0, "Draw_2_3" },
                    { 966984384, new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8091), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8092), 0.0, "Draw_4_2" },
                    { 970795916, new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8641), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8643), 0.0, "Draw_7_1" },
                    { 979932206, new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9020), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9021), 0.0, "Draw_9_1" },
                    { 980807660, new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7529), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7530), 0.0, "Draw_1_3" },
                    { 982752628, new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8811), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8813), 0.0, "Draw_8_0" },
                    { 991260930, new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7916), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7917), 0.0, "Draw_3_3" },
                    { 998702191, new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8248), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8249), 0.0, "Draw_5_0" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1954759124, 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7298), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7299), 0.0, "Meetings" },
                    { -1218423025, 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7269), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7270), 0.0, "Printing" },
                    { 105468846, 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7284), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7285), 0.0, "On-Site" },
                    { 871071610, 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7251), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7252), 0.0, "Communications" },
                    { 2064465786, 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7312), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7313), 0.0, "Administration" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 174269519, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6803), true, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6804), "CEO" },
                    { 272642431, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6770), true, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6771), "Engineer" },
                    { 392483438, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6811), false, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6812), "Guest" },
                    { 496330118, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6778), true, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6779), "Project Manager" },
                    { 502908370, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6794), true, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6796), "CTO" },
                    { 816890058, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6761), true, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6762), "Draftsmen" },
                    { 851769864, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6786), true, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6788), "COO" },
                    { 893914976, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6819), false, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6820), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 166603010, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9282), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9283), null, "6949277783", null, null, null },
                    { 226159902, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(274), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(275), null, "6949277784", null, null, null },
                    { 314810828, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7216), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7217), null, "6949277785", null, null, null },
                    { 420993340, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7183), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7184), null, "6949277784", null, null, null },
                    { 421933669, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7089), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7090), null, "6949277781", null, null, null },
                    { 462211717, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7121), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7123), null, "6949277782", null, null, null },
                    { 508538284, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9091), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9093), null, "69492777812", null, null, null },
                    { 550868986, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8901), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8902), null, "69492777811", null, null, null },
                    { 572158192, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7774), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7775), null, "6949277785", null, null, null },
                    { 620466235, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8337), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8339), null, "6949277788", null, null, null },
                    { 691454199, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7153), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7154), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 704515051, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8712), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8714), null, "69492777810", null, null, null },
                    { 800787149, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7331), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7332), null, "6949277783", null, null, null },
                    { 853755377, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6937), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(6938), null, "6949277780", null, null, null },
                    { 864717325, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8148), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8149), null, "6949277787", null, null, null },
                    { 901616193, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7574), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7575), null, "6949277784", null, null, null },
                    { 934714479, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7961), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7962), null, "6949277786", null, null, null },
                    { 967950352, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8526), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8527), null, "6949277789", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -2116249744, 0, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(305), 226159902, 2345L, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(306), 3425L, "HVAC" },
                    { 1080007040, 0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9316), 166603010, 2345L, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9317), 3425L, "ELEC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 224789129, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 14.0, 81, new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 81, "Test Description Project_36", "KL-9", new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 91L, 729L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_9", 5.0, new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_27", 9.0, 550868986, new DateTime(2030, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 },
                    { 252459518, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 15.0, 100, new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 100, "Test Description Project_60", "KL-10", new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 125L, 1000L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_10", 5.0, new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_40", 10.0, 508538284, new DateTime(2032, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 },
                    { 442640154, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 8.0, 9, new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 9, "Test Description Project_6", "KL-3", new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 3L, 27L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_3", 5.0, new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_18", 3.0, 572158192, new DateTime(2024, 11, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 },
                    { 493988931, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 10.0, 25, new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 25, "Test Description Project_25", "KL-5", new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 16L, 125L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_5", 5.0, new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_10", 5.0, 864717325, new DateTime(2026, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 },
                    { 558595781, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 7.0, 4, new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 4, "Test Description Project_12", "KL-2", new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 1L, 8L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_2", 5.0, new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_10", 2.0, 901616193, new DateTime(2024, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 },
                    { 592295030, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 9.0, 16, new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 16, "Test Description Project_24", "KL-4", new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 8L, 64L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_4", 5.0, new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_24", 4.0, 934714479, new DateTime(2025, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 },
                    { 788939679, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 11.0, 36, new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 36, "Test Description Project_30", "KL-6", new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 27L, 216L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_6", 5.0, new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_30", 6.0, 620466235, new DateTime(2027, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 },
                    { 810288401, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 13.0, 64, new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 64, "Test Description Project_32", "KL-8", new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 64L, 512L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_8", 5.0, new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_24", 8.0, 704515051, new DateTime(2029, 6, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 },
                    { 845407863, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 12.0, 49, new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 49, "Test Description Project_28", "KL-7", new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 43L, 343L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_7", 5.0, new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_42", 7.0, 967950352, new DateTime(2028, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 },
                    { 920520199, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 6.0, 1, new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 1, "Test Description Project_5", "KL-1", new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, 1L, new DateTime(2024, 2, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0L, "Project_1", 5.0, new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), "Payment Detailes For Project_1", 1.0, 800787149, new DateTime(2024, 3, 23, 14, 36, 32, 487, DateTimeKind.Local).AddTicks(8847), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 272642431, 166603010, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9300), 337310306, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9302) },
                    { 272642431, 226159902, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(292), 424688988, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(293) },
                    { 816890058, 314810828, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7232), 749832084, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7234) },
                    { 816890058, 420993340, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7201), 313532964, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7202) },
                    { 816890058, 421933669, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7107), 545639208, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7109) },
                    { 816890058, 462211717, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7138), 793985138, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7139) },
                    { 496330118, 508538284, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9108), 150402879, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9109) },
                    { 496330118, 550868986, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8921), 824567038, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8922) },
                    { 496330118, 572158192, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7791), 945462077, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7792) },
                    { 496330118, 620466235, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8355), 798115700, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8356) },
                    { 816890058, 691454199, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7169), 756840547, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7170) },
                    { 496330118, 704515051, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8730), 349095282, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8731) },
                    { 496330118, 800787149, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7352), 236650403, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7353) },
                    { 816890058, 853755377, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7065), 727601250, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7066) },
                    { 496330118, 864717325, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8165), 457303955, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8167) },
                    { 496330118, 901616193, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7592), 460518751, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7594) },
                    { 496330118, 934714479, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7977), 736486509, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7979) },
                    { 496330118, 967950352, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8547), 960856877, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8548) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2116249744, 124438826, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1187), 449850156, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1188) },
                    { -2116249744, 140620643, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(925), 261995373, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(926) },
                    { -2116249744, 142226525, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(912), 629400670, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(913) },
                    { -2116249744, 161684017, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(798), 327652062, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(799) },
                    { -2116249744, 169785045, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1037), 157785035, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1038) },
                    { -2116249744, 184621553, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(872), 861575165, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(873) },
                    { -2116249744, 195506554, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1149), 385233395, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1150) },
                    { -2116249744, 241480047, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1199), 282159596, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1200) },
                    { -2116249744, 249985212, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(897), 550934633, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(898) },
                    { -2116249744, 253710354, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(684), 686195627, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(686) },
                    { -2116249744, 261462996, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(672), 216280532, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(673) },
                    { -2116249744, 301625919, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(494), 589012569, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(495) },
                    { -2116249744, 309390381, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(573), 387374903, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(574) },
                    { -2116249744, 310737189, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1212), 761060770, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1213) },
                    { -2116249744, 331103161, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(623), 337358348, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(624) },
                    { -2116249744, 331288974, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1125), 376293413, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1126) },
                    { -2116249744, 334638194, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(974), 747625867, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(975) },
                    { -2116249744, 349463811, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1137), 390723448, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1138) },
                    { -2116249744, 365262434, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1162), 668825455, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1163) },
                    { -2116249744, 414479897, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(697), 540484715, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(698) },
                    { -2116249744, 423624012, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(747), 831658404, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(749) },
                    { -2116249744, 489940958, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(468), 587611975, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(469) },
                    { -2116249744, 491977247, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(610), 856096739, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(611) },
                    { -2116249744, 499183759, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(547), 283481083, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(549) },
                    { -2116249744, 515283988, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(481), 635300039, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(482) },
                    { -2116249744, 535467823, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(760), 566961202, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(761) },
                    { -2116249744, 537338818, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1062), 382353059, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1063) },
                    { -2116249744, 542481986, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1050), 967045107, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1051) },
                    { -2116249744, 551075321, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(560), 281196953, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(561) },
                    { -2116249744, 566938456, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(860), 466740721, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(861) },
                    { -2116249744, 569587658, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1100), 731310047, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1101) },
                    { -2116249744, 572627513, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1012), 302866543, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1014) },
                    { -2116249744, 610208912, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(734), 812582764, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(736) },
                    { -2116249744, 611412942, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(962), 580353517, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(963) },
                    { -2116249744, 629755627, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(949), 474826848, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(951) },
                    { -2116249744, 631391090, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(835), 800818840, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(836) },
                    { -2116249744, 634847495, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(647), 548093431, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(649) },
                    { -2116249744, 663974904, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(885), 214303019, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(886) },
                    { -2116249744, 702738746, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1074), 313016716, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1075) },
                    { -2116249744, 762472879, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(987), 372498183, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(988) },
                    { -2116249744, 793158751, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(847), 125905798, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(849) },
                    { -2116249744, 827117567, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(823), 647230068, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(824) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2116249744, 832442228, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1025), 838282025, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1026) },
                    { -2116249744, 840990636, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(598), 654213302, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(599) },
                    { -2116249744, 849954170, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(535), 389185310, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(536) },
                    { -2116249744, 860744340, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(519), 162729332, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(520) },
                    { -2116249744, 864835858, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(785), 372395912, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(786) },
                    { -2116249744, 919770530, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(709), 306402799, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(710) },
                    { -2116249744, 932347068, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1112), 766747002, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1113) },
                    { -2116249744, 938440492, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1174), 587233984, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1175) },
                    { -2116249744, 964621561, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(810), 207260467, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(811) },
                    { -2116249744, 964662840, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(635), 426211330, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(636) },
                    { -2116249744, 964948190, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(585), 998096667, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(587) },
                    { -2116249744, 966984384, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(721), 344806839, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(722) },
                    { -2116249744, 970795916, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(937), 704254269, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(938) },
                    { -2116249744, 979932206, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1087), 128650951, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1088) },
                    { -2116249744, 980807660, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(506), 296352154, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(508) },
                    { -2116249744, 982752628, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1000), 685293613, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1001) },
                    { -2116249744, 991260930, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(660), 174210314, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(661) },
                    { -2116249744, 998702191, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(773), 696088555, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(774) },
                    { 1080007040, 124438826, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(236), 467572861, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(237) },
                    { 1080007040, 140620643, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9973), 458946811, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9974) },
                    { 1080007040, 142226525, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9961), 578051349, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9962) },
                    { 1080007040, 161684017, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9849), 851906693, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9850) },
                    { 1080007040, 169785045, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(83), 272063099, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(85) },
                    { 1080007040, 184621553, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9922), 626102112, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9924) },
                    { 1080007040, 195506554, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(199), 854843589, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(200) },
                    { 1080007040, 241480047, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(249), 522583481, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(250) },
                    { 1080007040, 249985212, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9948), 863943062, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9949) },
                    { 1080007040, 253710354, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9734), 922255875, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9735) },
                    { 1080007040, 261462996, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9720), 541761859, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9721) },
                    { 1080007040, 301625919, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9541), 678634418, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9542) },
                    { 1080007040, 309390381, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9618), 822237167, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9619) },
                    { 1080007040, 310737189, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(261), 872736137, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(262) },
                    { 1080007040, 331103161, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9669), 245447462, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9671) },
                    { 1080007040, 331288974, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(171), 256740360, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(172) },
                    { 1080007040, 334638194, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(22), 764833122, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(23) },
                    { 1080007040, 349463811, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(183), 284643023, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(184) },
                    { 1080007040, 365262434, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(211), 494276200, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(212) },
                    { 1080007040, 414479897, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9747), 781347803, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9748) },
                    { 1080007040, 423624012, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9796), 137873550, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9797) },
                    { 1080007040, 489940958, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9507), 909413679, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9508) },
                    { 1080007040, 491977247, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9657), 412019056, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9658) },
                    { 1080007040, 499183759, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9593), 249820575, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9594) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1080007040, 515283988, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9528), 484221222, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9530) },
                    { 1080007040, 535467823, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9809), 260121561, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9810) },
                    { 1080007040, 537338818, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(109), 819348117, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(110) },
                    { 1080007040, 542481986, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(96), 486067970, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(97) },
                    { 1080007040, 551075321, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9605), 792874284, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9607) },
                    { 1080007040, 566938456, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9910), 385739362, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9911) },
                    { 1080007040, 569587658, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(146), 783779156, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(147) },
                    { 1080007040, 572627513, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(58), 291695318, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(60) },
                    { 1080007040, 610208912, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9784), 173154783, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9785) },
                    { 1080007040, 611412942, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(10), 930123057, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(11) },
                    { 1080007040, 629755627, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9998), 801910324, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9999) },
                    { 1080007040, 631391090, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9886), 293596169, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9887) },
                    { 1080007040, 634847495, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9695), 192501201, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9696) },
                    { 1080007040, 663974904, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9936), 996782875, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9937) },
                    { 1080007040, 702738746, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(121), 252538790, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(122) },
                    { 1080007040, 762472879, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(34), 614234323, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(35) },
                    { 1080007040, 793158751, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9898), 264149960, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9899) },
                    { 1080007040, 827117567, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9874), 544620164, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9875) },
                    { 1080007040, 832442228, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(71), 170651473, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(72) },
                    { 1080007040, 840990636, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9644), 186000052, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9645) },
                    { 1080007040, 849954170, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9580), 442613305, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9581) },
                    { 1080007040, 860744340, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9567), 707570179, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9568) },
                    { 1080007040, 864835858, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9837), 548374362, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9838) },
                    { 1080007040, 919770530, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9759), 632002567, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9760) },
                    { 1080007040, 932347068, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(158), 373191529, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(160) },
                    { 1080007040, 938440492, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(224), 142448340, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(225) },
                    { 1080007040, 964621561, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9861), 951328281, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9862) },
                    { 1080007040, 964662840, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9682), 553472186, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9683) },
                    { 1080007040, 964948190, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9631), 492945806, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9633) },
                    { 1080007040, 966984384, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9772), 279047376, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9773) },
                    { 1080007040, 970795916, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9986), 414417449, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9987) },
                    { 1080007040, 979932206, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(134), 948931030, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(135) },
                    { 1080007040, 980807660, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9554), 799621466, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9555) },
                    { 1080007040, 982752628, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(46), 440766253, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(47) },
                    { 1080007040, 991260930, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9707), 447230417, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9708) },
                    { 1080007040, 998702191, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9821), 638655390, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9822) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2116249744, 314810828, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(454), -2443607, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(455) },
                    { -2116249744, 420993340, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(441), -171449149, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(442) },
                    { -2116249744, 421933669, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(400), 1745681225, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(401) },
                    { -2116249744, 462211717, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(413), 121338010, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(414) },
                    { -2116249744, 691454199, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(428), 1722661799, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(429) },
                    { -2116249744, 853755377, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(386), -1898662216, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(387) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1080007040, 314810828, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9492), 230951732, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9493) },
                    { 1080007040, 420993340, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9477), -14311520, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9478) },
                    { 1080007040, 421933669, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9434), 2099282022, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9435) },
                    { 1080007040, 462211717, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9450), -702745771, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9452) },
                    { 1080007040, 691454199, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9464), -1247751373, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9465) },
                    { 1080007040, 853755377, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9415), -1436567035, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9416) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2116249744, -1954759124, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(358), 569491537, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(359) },
                    { -2116249744, -1218423025, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(333), 303533130, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(334) },
                    { -2116249744, 105468846, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(345), 215098868, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(346) },
                    { -2116249744, 871071610, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(319), 688199231, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(320) },
                    { -2116249744, 2064465786, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(372), 534138633, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(373) },
                    { 1080007040, -1954759124, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9384), 248828002, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9385) },
                    { 1080007040, -1218423025, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9356), 532293211, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9357) },
                    { 1080007040, 105468846, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9370), 814256400, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9371) },
                    { 1080007040, 871071610, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9338), 151595346, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9339) },
                    { 1080007040, 2064465786, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9398), 204274439, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9399) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2116249744, 224789129, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1470), -340714246, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1471) },
                    { -2116249744, 252459518, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1496), -45013332, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1498) },
                    { -2116249744, 442640154, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1305), -1624904347, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1307) },
                    { -2116249744, 493988931, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1361), -2009281208, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1362) },
                    { -2116249744, 558595781, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1275), 219793592, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1276) },
                    { -2116249744, 592295030, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1333), -342631815, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1334) },
                    { -2116249744, 788939679, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1388), 276749961, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1389) },
                    { -2116249744, 810288401, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1442), 274926656, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1443) },
                    { -2116249744, 845407863, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1414), -767075756, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1415) },
                    { -2116249744, 920520199, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1246), -144204804, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1248) },
                    { 1080007040, 224789129, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1455), -1832256732, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1456) },
                    { 1080007040, 252459518, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1483), 1182221184, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1484) },
                    { 1080007040, 442640154, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1289), 1109173672, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1290) },
                    { 1080007040, 493988931, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1346), -458078427, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1347) },
                    { 1080007040, 558595781, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1262), 1431953344, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1263) },
                    { 1080007040, 592295030, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1319), -1627930073, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1320) },
                    { 1080007040, 788939679, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1374), 1381034678, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1376) },
                    { 1080007040, 810288401, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1428), 1474703776, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1429) },
                    { 1080007040, 845407863, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1401), -1827769381, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1402) },
                    { 1080007040, 920520199, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1227), -1849590175, new DateTime(2024, 2, 23, 14, 36, 32, 492, DateTimeKind.Local).AddTicks(1228) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 186675931, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8419), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8422), 1003000.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8420), "Signature 1423436", 85927, 788939679, 6.0, 24.0 },
                    { 314420732, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8610), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8613), 10003000.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8611), "Signature 142347", 30585, 845407863, 7.0, 17.0 },
                    { 597072463, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7856), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7858), 4000.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7857), "Signature 142346", 63583, 442640154, 3.0, 17.0 },
                    { 603982480, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8987), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8990), 1000003000.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8989), "Signature 1423427", 65931, 224789129, 9.0, 17.0 },
                    { 634024160, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8044), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8047), 13000.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8046), "Signature 142348", 16786, 592295030, 4.0, 24.0 },
                    { 754905987, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7664), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7666), 3100.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7665), "Signature 142342", 40451, 558595781, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 803926369, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9177), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9179), 10000003000.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9178), "Signature 1423440", 50508, 252459518, 10.0, 24.0 },
                    { 824772910, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7454), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7456), 3010.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7455), "Signature 142346", 63480, 920520199, 1.0, 17.0 },
                    { 863130956, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8230), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8233), 103000.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8232), "Signature 1423430", 48430, 493988931, 5.0, 17.0 },
                    { 937618190, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8795), new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8797), 100003000.0, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8796), "Signature 142348", 83271, 810288401, 8.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 161753262, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8200), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8202), null, "6949277785", null, null, 493988931 },
                    { 219371080, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7633), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7634), null, "6949277782", null, null, 558595781 },
                    { 250528550, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8581), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8582), null, "6949277787", null, null, 845407863 },
                    { 282666477, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8015), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8016), null, "6949277784", null, null, 592295030 },
                    { 303402163, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8765), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8766), null, "6949277788", null, null, 810288401 },
                    { 618349401, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7827), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7828), null, "6949277783", null, null, 442640154 },
                    { 756666349, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9146), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9148), null, "69492777810", null, null, 252459518 },
                    { 765206369, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8390), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8391), null, "6949277786", null, null, 788939679 },
                    { 887385596, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7418), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7419), null, "6949277781", null, null, 920520199 },
                    { 908629558, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8957), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8959), null, "6949277789", null, null, 224789129 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 893914976, 161753262, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8217), 842656268, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8218) },
                    { 893914976, 219371080, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7650), 186597497, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7651) },
                    { 893914976, 250528550, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8597), 956327234, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8598) },
                    { 893914976, 282666477, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8031), 650590555, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8032) },
                    { 893914976, 303402163, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8781), 481991724, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8783) },
                    { 893914976, 618349401, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7843), 963136902, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7844) },
                    { 893914976, 756666349, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9164), 453041002, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(9165) },
                    { 893914976, 765206369, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8406), 527548462, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8407) },
                    { 893914976, 887385596, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7438), 527961488, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(7440) },
                    { 893914976, 908629558, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8974), 982232969, new DateTime(2024, 2, 23, 14, 36, 32, 491, DateTimeKind.Local).AddTicks(8975) }
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
