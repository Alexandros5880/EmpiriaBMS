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
                    EstimatedCompleted = table.Column<long>(type: "bigint", nullable: false),
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
                    { 124176823, new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(844), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(845), 0.0, "Draw_4_4" },
                    { 133609371, new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(969), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(970), 0.0, "Draw_5_0" },
                    { 136343595, new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1026), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1027), 0.0, "Draw_5_4" },
                    { 168787917, new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1336), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1337), 0.0, "Draw_7_0" },
                    { 168922362, new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(802), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(804), 0.0, "Draw_4_1" },
                    { 223089178, new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2003), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2004), 0.0, "Draw_10_4" },
                    { 234201071, new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1378), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1379), 0.0, "Draw_7_3" },
                    { 241257588, new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(998), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(999), 0.0, "Draw_5_2" },
                    { 272583197, new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1392), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1393), 0.0, "Draw_7_4" },
                    { 314369992, new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1791), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1792), 0.0, "Draw_9_2" },
                    { 328385141, new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1588), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1589), 0.0, "Draw_8_5" },
                    { 338435714, new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1364), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1365), 0.0, "Draw_7_2" },
                    { 344900398, new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(616), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(618), 0.0, "Draw_3_1" },
                    { 376256086, new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1166), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1167), 0.0, "Draw_6_1" },
                    { 379410358, new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1532), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1533), 0.0, "Draw_8_1" },
                    { 410131970, new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(664), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(665), 0.0, "Draw_3_4" },
                    { 415555661, new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(635), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(636), 0.0, "Draw_3_2" },
                    { 428593645, new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(649), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(651), 0.0, "Draw_3_3" },
                    { 436516837, new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(266), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(268), 0.0, "Draw_1_3" },
                    { 452014604, new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(478), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(479), 0.0, "Draw_2_4" },
                    { 491773382, new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1406), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1407), 0.0, "Draw_7_5" },
                    { 522418224, new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(448), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(449), 0.0, "Draw_2_2" },
                    { 523826040, new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(213), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(215), 0.0, "Draw_1_0" },
                    { 534507739, new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1546), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1547), 0.0, "Draw_8_2" },
                    { 572632763, new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1517), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1518), 0.0, "Draw_8_0" },
                    { 577646619, new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(492), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(494), 0.0, "Draw_2_5" },
                    { 601501929, new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1012), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1013), 0.0, "Draw_5_3" },
                    { 634095797, new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(984), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(985), 0.0, "Draw_5_1" },
                    { 652401438, new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(787), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(788), 0.0, "Draw_4_0" },
                    { 652403158, new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(816), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(817), 0.0, "Draw_4_2" },
                    { 665670108, new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1350), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1352), 0.0, "Draw_7_1" },
                    { 665846004, new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1213), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1214), 0.0, "Draw_6_4" },
                    { 681058239, new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1715), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1717), 0.0, "Draw_9_1" },
                    { 684935433, new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1701), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1702), 0.0, "Draw_9_0" },
                    { 702735771, new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1181), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1182), 0.0, "Draw_6_2" },
                    { 723864420, new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1822), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1823), 0.0, "Draw_9_4" },
                    { 734580821, new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(830), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(831), 0.0, "Draw_4_3" },
                    { 735420430, new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(297), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(298), 0.0, "Draw_1_5" },
                    { 753479836, new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1962), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1963), 0.0, "Draw_10_1" },
                    { 770257618, new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(418), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(419), 0.0, "Draw_2_0" },
                    { 782418057, new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1148), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1149), 0.0, "Draw_6_0" },
                    { 782487613, new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(464), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(465), 0.0, "Draw_2_3" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 797925724, new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1947), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1948), 0.0, "Draw_10_0" },
                    { 803528744, new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1199), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1200), 0.0, "Draw_6_3" },
                    { 817370030, new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2017), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2018), 0.0, "Draw_10_5" },
                    { 831069071, new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(680), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(681), 0.0, "Draw_3_5" },
                    { 835369712, new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1808), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1809), 0.0, "Draw_9_3" },
                    { 838041678, new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1227), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1228), 0.0, "Draw_6_5" },
                    { 845674121, new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(252), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(253), 0.0, "Draw_1_2" },
                    { 853294826, new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(237), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(238), 0.0, "Draw_1_1" },
                    { 865558280, new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(601), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(602), 0.0, "Draw_3_0" },
                    { 871616871, new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(433), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(435), 0.0, "Draw_2_1" },
                    { 908198639, new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1836), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1837), 0.0, "Draw_9_5" },
                    { 913274518, new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(858), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(859), 0.0, "Draw_4_5" },
                    { 921785138, new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1040), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1041), 0.0, "Draw_5_5" },
                    { 937265338, new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1990), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1991), 0.0, "Draw_10_3" },
                    { 942010622, new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1574), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1575), 0.0, "Draw_8_4" },
                    { 948309195, new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1976), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1977), 0.0, "Draw_10_2" },
                    { 958808466, new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(281), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(282), 0.0, "Draw_1_4" },
                    { 971796450, new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1560), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1561), 0.0, "Draw_8_3" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1779299774, 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(20), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(21), 0.0, "Printing" },
                    { -1005209089, 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(48), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(49), 0.0, "Meetings" },
                    { -553234328, 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(34), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(35), 0.0, "On-Site" },
                    { -462283816, 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(62), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(64), 0.0, "Administration" },
                    { 1527253679, 0, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9998), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local), 0.0, "Communications" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 153323105, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9663), false, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9664), "Guest" },
                    { 207447026, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9631), true, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9632), "Project Manager" },
                    { 315049085, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9623), true, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9625), "Engineer" },
                    { 708488097, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9670), false, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9671), "Customer" },
                    { 803603425, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9656), true, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9657), "CEO" },
                    { 838604457, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9641), true, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9643), "COO" },
                    { 952968118, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9649), true, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9650), "CTO" },
                    { 988119514, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9615), true, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9616), "Designer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 128422942, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1602), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1603), null, "69492777811", null, null, null },
                    { 195258968, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(312), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(313), null, "6949277784", null, null, null },
                    { 198722264, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(872), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(873), null, "6949277787", null, null, null },
                    { 264550643, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9879), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9880), null, "6949277782", null, null, null },
                    { 271333890, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1241), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1242), null, "6949277789", null, null, null },
                    { 278785232, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9778), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9779), null, "6949277780", null, null, null },
                    { 290886085, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(81), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(82), null, "6949277783", null, null, null },
                    { 462314854, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1420), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1421), null, "69492777810", null, null, null },
                    { 505367207, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9936), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9937), null, "6949277784", null, null, null },
                    { 532470903, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3025), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3026), null, "6949277784", null, null, null },
                    { 577289925, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(506), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(507), null, "6949277785", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 752198867, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9848), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9849), null, "6949277781", null, null, null },
                    { 782933563, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(694), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(695), null, "6949277786", null, null, null },
                    { 785404154, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2034), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2036), null, "6949277783", null, null, null },
                    { 838460712, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1850), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1851), null, "69492777812", null, null, null },
                    { 863912215, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9968), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9969), null, "6949277785", null, null, null },
                    { 885372369, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9908), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9909), null, "6949277783", null, null, null },
                    { 948320605, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1054), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1055), null, "6949277788", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1923649624, 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2071), 785404154, 1500L, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2073), 0L, "ELEC" },
                    { 1047296336, 0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3055), 532470903, 1500L, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3057), 0L, "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 209801539, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 13.0, 64, new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 64, "Test Description Project_24", "KL-8", new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_8", 5.0, new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_8", 8.0, 462314854, new DateTime(2029, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 },
                    { 263660694, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 11.0, 36, new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 36, "Test Description Project_18", "KL-6", new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_6", 5.0, new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_30", 6.0, 948320605, new DateTime(2027, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 },
                    { 405550310, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 10.0, 25, new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 25, "Test Description Project_5", "KL-5", new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_5", 5.0, new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_30", 5.0, 198722264, new DateTime(2026, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 },
                    { 442217769, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 9.0, 16, new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 16, "Test Description Project_8", "KL-4", new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_4", 5.0, new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_20", 4.0, 782933563, new DateTime(2025, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 },
                    { 571417976, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 8.0, 9, new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 9, "Test Description Project_9", "KL-3", new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_3", 5.0, new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_18", 3.0, 577289925, new DateTime(2024, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 },
                    { 590575746, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 6.0, 1, new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 1, "Test Description Project_5", "KL-1", new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_1", 5.0, new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_4", 1.0, 290886085, new DateTime(2024, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 },
                    { 591326242, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 15.0, 100, new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 100, "Test Description Project_30", "KL-10", new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_10", 5.0, new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_20", 10.0, 838460712, new DateTime(2032, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 },
                    { 609744202, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 7.0, 4, new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 4, "Test Description Project_10", "KL-2", new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_2", 5.0, new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_12", 2.0, 195258968, new DateTime(2024, 6, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 },
                    { 694991909, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 12.0, 49, new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 49, "Test Description Project_35", "KL-7", new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_7", 5.0, new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_35", 7.0, 271333890, new DateTime(2028, 3, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 },
                    { 841655980, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 14.0, 81, new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 81, "Test Description Project_45", "KL-9", new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, 3000L, 375L, new DateTime(2024, 2, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0L, "Project_9", 5.0, new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), "Payment Detailes For Project_36", 9.0, 128422942, new DateTime(2030, 11, 24, 11, 18, 41, 491, DateTimeKind.Local).AddTicks(7020), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 207447026, 128422942, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1617), 613607998, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1619) },
                    { 207447026, 195258968, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(329), 335287181, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(330) },
                    { 207447026, 198722264, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(887), 899442531, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(888) },
                    { 988119514, 264550643, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9895), 818273760, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9896) },
                    { 207447026, 271333890, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1256), 743103842, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1258) },
                    { 988119514, 278785232, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9830), 469194695, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9831) },
                    { 207447026, 290886085, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(100), 788773695, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(101) },
                    { 207447026, 462314854, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1440), 339719609, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1441) },
                    { 988119514, 505367207, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9954), 750876019, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9955) },
                    { 315049085, 532470903, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3042), 943961194, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3043) },
                    { 207447026, 577289925, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(522), 793669561, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(523) },
                    { 988119514, 752198867, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9865), 238540530, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9867) },
                    { 207447026, 782933563, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(709), 675615113, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(710) },
                    { 315049085, 785404154, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2057), 942888514, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2058) },
                    { 207447026, 838460712, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1867), 525182879, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1868) },
                    { 988119514, 863912215, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9984), 330092794, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9985) },
                    { 988119514, 885372369, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9923), 682595608, new DateTime(2024, 2, 24, 11, 18, 41, 494, DateTimeKind.Local).AddTicks(9924) },
                    { 207447026, 948320605, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1070), 618000571, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1071) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1923649624, 124176823, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2544), 744349732, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2545) },
                    { -1923649624, 133609371, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2569), 306516976, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2570) },
                    { -1923649624, 136343595, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2619), 228287672, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2620) },
                    { -1923649624, 168787917, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2720), 288459271, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2721) },
                    { -1923649624, 168922362, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2506), 266474832, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2507) },
                    { -1923649624, 223089178, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3000), 256284988, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3001) },
                    { -1923649624, 234201071, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2757), 151055992, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2758) },
                    { -1923649624, 241257588, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2593), 980884819, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2595) },
                    { -1923649624, 272583197, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2770), 329145514, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2771) },
                    { -1923649624, 314369992, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2900), 304677646, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2901) },
                    { -1923649624, 328385141, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2862), 467542844, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2863) },
                    { -1923649624, 338435714, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2745), 495257134, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2746) },
                    { -1923649624, 344900398, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2424), 360141392, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2425) },
                    { -1923649624, 376256086, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2656), 651972823, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2657) },
                    { -1923649624, 379410358, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2812), 463951252, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2813) },
                    { -1923649624, 410131970, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2467), 311340906, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2468) },
                    { -1923649624, 415555661, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2440), 271729402, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2442) },
                    { -1923649624, 428593645, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2454), 737661323, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2455) },
                    { -1923649624, 436516837, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2297), 680659726, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2298) },
                    { -1923649624, 452014604, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2386), 663654312, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2387) },
                    { -1923649624, 491773382, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2782), 571647694, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2783) },
                    { -1923649624, 522418224, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2361), 208747787, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2362) },
                    { -1923649624, 523826040, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2254), 554388023, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2255) },
                    { -1923649624, 534507739, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2825), 359106573, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2826) },
                    { -1923649624, 572632763, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2799), 637948793, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2800) },
                    { -1923649624, 577646619, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2399), 495205010, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2400) },
                    { -1923649624, 601501929, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2606), 555823635, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2607) },
                    { -1923649624, 634095797, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2581), 592424995, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2582) },
                    { -1923649624, 652401438, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2493), 169799286, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2494) },
                    { -1923649624, 652403158, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2518), 961153191, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2520) },
                    { -1923649624, 665670108, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2732), 292994694, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2733) },
                    { -1923649624, 665846004, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2695), 757010837, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2696) },
                    { -1923649624, 681058239, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2887), 309140774, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2888) },
                    { -1923649624, 684935433, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2875), 911195026, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2876) },
                    { -1923649624, 702735771, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2669), 507427995, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2670) },
                    { -1923649624, 723864420, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2925), 830999347, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2926) },
                    { -1923649624, 734580821, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2531), 835010689, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2532) },
                    { -1923649624, 735420430, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2323), 519752615, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2324) },
                    { -1923649624, 753479836, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2962), 257167257, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2963) },
                    { -1923649624, 770257618, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2335), 800631879, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2337) },
                    { -1923649624, 782418057, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2644), 750840563, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2645) },
                    { -1923649624, 782487613, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2374), 578506280, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2375) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1923649624, 797925724, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2950), 721334822, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2951) },
                    { -1923649624, 803528744, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2682), 357419763, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2683) },
                    { -1923649624, 817370030, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3012), 923134291, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3013) },
                    { -1923649624, 831069071, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2481), 842413955, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2482) },
                    { -1923649624, 835369712, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2912), 280377057, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2913) },
                    { -1923649624, 838041678, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2707), 140821797, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2708) },
                    { -1923649624, 845674121, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2284), 218302663, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2285) },
                    { -1923649624, 853294826, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2271), 536361330, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2272) },
                    { -1923649624, 865558280, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2411), 916167441, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2413) },
                    { -1923649624, 871616871, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2348), 231742840, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2349) },
                    { -1923649624, 908198639, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2937), 499025733, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2938) },
                    { -1923649624, 913274518, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2556), 409383424, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2557) },
                    { -1923649624, 921785138, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2631), 157695894, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2632) },
                    { -1923649624, 937265338, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2987), 412021197, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2988) },
                    { -1923649624, 942010622, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2850), 227100970, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2851) },
                    { -1923649624, 948309195, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2975), 559265705, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2976) },
                    { -1923649624, 958808466, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2310), 946906355, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2311) },
                    { -1923649624, 971796450, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2837), 629287025, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2838) },
                    { 1047296336, 124176823, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3494), 984439149, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3495) },
                    { 1047296336, 133609371, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3522), 833081838, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3524) },
                    { 1047296336, 136343595, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3573), 559857831, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3574) },
                    { 1047296336, 168787917, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3672), 869083446, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3673) },
                    { 1047296336, 168922362, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3456), 375441830, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3457) },
                    { 1047296336, 223089178, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3950), 328848419, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3951) },
                    { 1047296336, 234201071, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3709), 416757656, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3710) },
                    { 1047296336, 241257588, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3548), 528837649, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3549) },
                    { 1047296336, 272583197, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3721), 418989781, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3722) },
                    { 1047296336, 314369992, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3845), 891498132, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3846) },
                    { 1047296336, 328385141, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3808), 715511226, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3809) },
                    { 1047296336, 338435714, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3696), 774357937, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3698) },
                    { 1047296336, 344900398, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3382), 614350999, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3383) },
                    { 1047296336, 376256086, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3610), 598156869, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3611) },
                    { 1047296336, 379410358, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3758), 456925218, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3759) },
                    { 1047296336, 410131970, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3419), 905440821, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3420) },
                    { 1047296336, 415555661, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3394), 971004099, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3395) },
                    { 1047296336, 428593645, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3406), 895402521, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3407) },
                    { 1047296336, 436516837, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3255), 137787575, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3256) },
                    { 1047296336, 452014604, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3344), 231235849, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3345) },
                    { 1047296336, 491773382, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3733), 867707702, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3734) },
                    { 1047296336, 522418224, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3319), 848555119, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3320) },
                    { 1047296336, 523826040, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3217), 742258146, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3218) },
                    { 1047296336, 534507739, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3770), 681572001, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3772) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1047296336, 572632763, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3746), 827759129, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3747) },
                    { 1047296336, 577646619, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3356), 996397114, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3358) },
                    { 1047296336, 601501929, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3560), 951032591, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3561) },
                    { 1047296336, 634095797, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3535), 545466387, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3536) },
                    { 1047296336, 652401438, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3444), 158686090, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3445) },
                    { 1047296336, 652403158, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3469), 840374690, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3470) },
                    { 1047296336, 665670108, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3684), 500895247, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3685) },
                    { 1047296336, 665846004, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3647), 733871023, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3648) },
                    { 1047296336, 681058239, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3832), 960646408, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3833) },
                    { 1047296336, 684935433, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3820), 293261154, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3821) },
                    { 1047296336, 702735771, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3622), 858888919, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3623) },
                    { 1047296336, 723864420, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3870), 247949078, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3871) },
                    { 1047296336, 734580821, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3481), 297580958, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3483) },
                    { 1047296336, 735420430, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3281), 792003176, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3283) },
                    { 1047296336, 753479836, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3913), 292930276, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3914) },
                    { 1047296336, 770257618, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3295), 340677793, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3296) },
                    { 1047296336, 782418057, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3597), 581568748, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3598) },
                    { 1047296336, 782487613, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3332), 639580390, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3333) },
                    { 1047296336, 797925724, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3899), 136005440, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3901) },
                    { 1047296336, 803528744, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3634), 914490828, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3635) },
                    { 1047296336, 817370030, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3963), 676115369, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3964) },
                    { 1047296336, 831069071, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3431), 913369682, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3432) },
                    { 1047296336, 835369712, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3857), 139538520, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3859) },
                    { 1047296336, 838041678, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3659), 574780739, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3660) },
                    { 1047296336, 845674121, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3243), 958245047, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3244) },
                    { 1047296336, 853294826, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3230), 218058958, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3231) },
                    { 1047296336, 865558280, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3369), 773176718, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3370) },
                    { 1047296336, 871616871, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3307), 387300363, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3308) },
                    { 1047296336, 908198639, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3882), 316979372, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3883) },
                    { 1047296336, 913274518, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3510), 879889419, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3511) },
                    { 1047296336, 921785138, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3585), 803056536, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3586) },
                    { 1047296336, 937265338, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3938), 430252874, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3939) },
                    { 1047296336, 942010622, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3795), 397546129, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3796) },
                    { 1047296336, 948309195, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3925), 747372556, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3926) },
                    { 1047296336, 958808466, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3267), 514364606, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3269) },
                    { 1047296336, 971796450, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3783), 295482296, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3784) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1923649624, 264550643, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2198), 326769157, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2199) },
                    { -1923649624, 278785232, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2169), -1862950162, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2170) },
                    { -1923649624, 505367207, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2224), -1667793194, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2225) },
                    { -1923649624, 752198867, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2185), -874417486, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2186) },
                    { -1923649624, 863912215, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2238), 1320090597, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2239) },
                    { -1923649624, 885372369, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2211), -1820603141, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2212) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1047296336, 264550643, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3164), -1132886843, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3165) },
                    { 1047296336, 278785232, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3134), -964952549, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3135) },
                    { 1047296336, 505367207, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3191), 1843079976, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3192) },
                    { 1047296336, 752198867, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3148), -259175069, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3149) },
                    { 1047296336, 863912215, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3204), -852568865, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3205) },
                    { 1047296336, 885372369, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3178), 2097215694, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3179) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1923649624, -1779299774, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2112), 420210660, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2113) },
                    { -1923649624, -1005209089, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2138), 607430967, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2140) },
                    { -1923649624, -553234328, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2125), 274917390, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2126) },
                    { -1923649624, -462283816, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2152), 529922366, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2153) },
                    { -1923649624, 1527253679, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2094), 843098731, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(2095) },
                    { 1047296336, -1779299774, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3083), 323301825, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3084) },
                    { 1047296336, -1005209089, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3108), 379389306, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3109) },
                    { 1047296336, -553234328, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3096), 594671670, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3097) },
                    { 1047296336, -462283816, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3121), 345083586, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3122) },
                    { 1047296336, 1527253679, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3070), 934015975, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3071) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1923649624, 209801539, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4165), 116642047, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4166) },
                    { -1923649624, 263660694, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4114), 1441429476, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4115) },
                    { -1923649624, 405550310, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4087), 1019519820, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4088) },
                    { -1923649624, 442217769, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4062), -559475420, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4063) },
                    { -1923649624, 571417976, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4034), 630763172, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4036) },
                    { -1923649624, 590575746, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3977), 1399837536, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3978) },
                    { -1923649624, 591326242, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4218), 65017645, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4219) },
                    { -1923649624, 609744202, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4008), -656631876, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4009) },
                    { -1923649624, 694991909, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4140), 1095902984, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4141) },
                    { -1923649624, 841655980, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4191), 969261570, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4192) },
                    { 1047296336, 209801539, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4178), 905711846, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4179) },
                    { 1047296336, 263660694, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4127), 1995923715, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4128) },
                    { 1047296336, 405550310, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4101), 939452384, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4102) },
                    { 1047296336, 442217769, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4074), -527432966, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4076) },
                    { 1047296336, 571417976, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4048), -2072466326, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4049) },
                    { 1047296336, 590575746, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3994), 2139752232, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(3995) },
                    { 1047296336, 591326242, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4231), 1142866016, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4232) },
                    { 1047296336, 609744202, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4021), 198566861, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4023) },
                    { 1047296336, 694991909, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4153), 346937644, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4154) },
                    { 1047296336, 841655980, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4205), -577678996, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(4206) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 146493852, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(400), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(402), 3100.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(401), "Signature 1423410", 88710, 609744202, 2.0, 24.0 },
                    { 355577137, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(583), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(586), 4000.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(585), "Signature 142349", 45074, 571417976, 3.0, 17.0 },
                    { 375221302, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1931), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1933), 10000003000.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1932), "Signature 1423420", 52204, 591326242, 10.0, 24.0 },
                    { 468381339, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1681), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1683), 1000003000.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1682), "Signature 142349", 17447, 841655980, 9.0, 17.0 },
                    { 532195822, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1501), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1503), 100003000.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1502), "Signature 1423424", 16953, 209801539, 8.0, 24.0 },
                    { 638656990, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(770), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(773), 13000.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(772), "Signature 1423412", 58211, 442217769, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 640441732, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(191), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(193), 3010.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(192), "Signature 142341", 83971, 590575746, 1.0, 17.0 },
                    { 665759226, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(952), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(954), 103000.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(953), "Signature 142345", 49062, 405550310, 5.0, 17.0 },
                    { 757203163, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1132), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1134), 1003000.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1133), "Signature 142346", 54438, 263660694, 6.0, 24.0 },
                    { 872232817, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1320), new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1322), 10003000.0, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1321), "Signature 1423421", 53044, 694991909, 7.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 243826556, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(923), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(924), null, "6949277785", null, null, 405550310 },
                    { 368931642, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1901), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1902), null, "69492777810", null, null, 591326242 },
                    { 416957597, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1104), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1105), null, "6949277786", null, null, 263660694 },
                    { 475976951, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(555), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(556), null, "6949277783", null, null, 571417976 },
                    { 529052386, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(370), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(371), null, "6949277782", null, null, 609744202 },
                    { 888652878, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(742), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(743), null, "6949277784", null, null, 442217769 },
                    { 903757874, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(156), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(158), null, "6949277781", null, null, 590575746 },
                    { 903862981, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1652), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1653), null, "6949277789", null, null, 841655980 },
                    { 920569780, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1291), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1293), null, "6949277787", null, null, 694991909 },
                    { 992331453, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1471), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1473), null, "6949277788", null, null, 209801539 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 708488097, 243826556, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(939), 701898167, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(940) },
                    { 708488097, 368931642, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1918), 827042441, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1919) },
                    { 708488097, 416957597, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1119), 258807224, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1120) },
                    { 708488097, 475976951, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(570), 459963943, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(571) },
                    { 708488097, 529052386, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(387), 683286338, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(388) },
                    { 708488097, 888652878, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(758), 756308271, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(759) },
                    { 708488097, 903757874, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(176), 489053719, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(177) },
                    { 708488097, 903862981, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1668), 280235507, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1669) },
                    { 708488097, 920569780, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1307), 529475017, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1308) },
                    { 708488097, 992331453, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1488), 358011483, new DateTime(2024, 2, 24, 11, 18, 41, 495, DateTimeKind.Local).AddTicks(1489) }
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
