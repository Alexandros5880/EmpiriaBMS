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
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionEstimation = table.Column<float>(type: "real", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    EstimatedCompleted = table.Column<float>(type: "real", nullable: false),
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
                        name: "FK_DisciplinesDraws_Drawings_DrawId",
                        column: x => x.DrawId,
                        principalTable: "Drawings",
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
                name: "ManHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawingId = table.Column<int>(type: "int", nullable: true),
                    OtherId = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManHour_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHour_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHour_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHour_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHour_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 163230434, new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2586), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2587), "Draw_10_3" },
                    { 212044491, new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1723), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1725), "Draw_5_5" },
                    { 215820310, new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2404), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2405), "Draw_9_3" },
                    { 220810642, new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1709), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1711), "Draw_5_4" },
                    { 248848305, new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1543), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1544), "Draw_4_5" },
                    { 250256215, new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2011), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2013), "Draw_7_0" },
                    { 250481418, new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1516), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1517), "Draw_4_3" },
                    { 253218257, new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1858), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1859), "Draw_6_2" },
                    { 267111527, new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1367), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1368), "Draw_3_5" },
                    { 289719781, new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2543), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2544), "Draw_10_0" },
                    { 296738623, new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1888), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1889), "Draw_6_4" },
                    { 307198806, new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2614), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2615), "Draw_10_5" },
                    { 313891409, new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2215), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2216), "Draw_8_2" },
                    { 329316690, new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1113), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1114), "Draw_2_0" },
                    { 369280188, new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2039), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2040), "Draw_7_2" },
                    { 402057129, new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1475), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1476), "Draw_4_0" },
                    { 414035878, new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1503), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1504), "Draw_4_2" },
                    { 421829231, new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(922), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(923), "Draw_1_0" },
                    { 422240299, new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1351), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1352), "Draw_3_4" },
                    { 454231695, new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2431), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2432), "Draw_9_5" },
                    { 461960386, new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2229), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2230), "Draw_8_3" },
                    { 468648646, new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1323), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1324), "Draw_3_2" },
                    { 499508672, new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2184), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2186), "Draw_8_0" },
                    { 506516222, new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2363), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2364), "Draw_9_0" },
                    { 544846378, new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1874), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1875), "Draw_6_3" },
                    { 551837434, new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1141), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1142), "Draw_2_2" },
                    { 554964432, new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1188), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1189), "Draw_2_5" },
                    { 570840320, new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2066), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2067), "Draw_7_4" },
                    { 571376010, new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2255), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2256), "Draw_8_5" },
                    { 572117586, new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1680), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1681), "Draw_5_2" },
                    { 593105774, new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1000), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1001), "Draw_1_5" },
                    { 639037134, new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2600), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2601), "Draw_10_4" },
                    { 644109954, new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1666), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1667), "Draw_5_1" },
                    { 647275773, new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2572), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2573), "Draw_10_2" },
                    { 689221224, new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2377), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2378), "Draw_9_1" },
                    { 702467040, new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(942), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(943), "Draw_1_1" },
                    { 712195056, new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2242), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2243), "Draw_8_4" },
                    { 745154514, new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1901), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1902), "Draw_6_5" },
                    { 750368354, new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1337), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1338), "Draw_3_3" },
                    { 790136529, new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1530), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1531), "Draw_4_4" },
                    { 793226616, new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2391), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2392), "Draw_9_2" },
                    { 815832825, new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2053), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2054), "Draw_7_3" }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 848128585, new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(956), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(957), "Draw_1_2" },
                    { 849829804, new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(970), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(971), "Draw_1_3" },
                    { 850511862, new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1489), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1490), "Draw_4_1" },
                    { 858182002, new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1174), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1175), "Draw_2_4" },
                    { 862246184, new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1652), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1653), "Draw_5_0" },
                    { 862843836, new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1845), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1846), "Draw_6_1" },
                    { 869991172, new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1127), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1128), "Draw_2_1" },
                    { 870353226, new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1831), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1832), "Draw_6_0" },
                    { 870753958, new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2418), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2419), "Draw_9_4" },
                    { 887504525, new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1157), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1158), "Draw_2_3" },
                    { 891587753, new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(984), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(985), "Draw_1_4" },
                    { 921356499, new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1295), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1297), "Draw_3_0" },
                    { 930885497, new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2080), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2081), "Draw_7_5" },
                    { 931525237, new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2558), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2559), "Draw_10_1" },
                    { 936064650, new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2025), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2026), "Draw_7_1" },
                    { 967761949, new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2198), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2199), "Draw_8_1" },
                    { 971411976, new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1693), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1694), "Draw_5_3" },
                    { 989888257, new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1310), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1311), "Draw_3_1" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -1341712436, 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(755), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(756), "Meetings" },
                    { 183804708, 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(728), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(729), "Printing" },
                    { 689113042, 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(713), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(714), "Communications" },
                    { 720489640, 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(769), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(771), "Administration" },
                    { 1098015947, 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(742), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(743), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 327196754, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(317), true, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(318), "Project Manager" },
                    { 455948026, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(346), false, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(348), "Guest" },
                    { 517685735, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(324), true, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(325), "COO" },
                    { 550015887, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(339), true, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(341), "CEO" },
                    { 557318127, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(353), false, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(355), "Customer" },
                    { 704292603, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(309), true, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(311), "Engineer" },
                    { 802982415, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(301), true, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(303), "Designer" },
                    { 846645239, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(332), true, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(334), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 133201441, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2631), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2632), null, "6949277783", null, null, null },
                    { 154534271, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2093), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2094), null, "69492777810", null, null, null },
                    { 249489905, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2269), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2270), null, "69492777811", null, null, null },
                    { 306201594, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(683), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(684), null, "6949277785", null, null, null },
                    { 335328045, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(652), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(653), null, "6949277784", null, null, null },
                    { 339610050, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(625), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(626), null, "6949277783", null, null, null },
                    { 352442796, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1381), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1382), null, "6949277786", null, null, null },
                    { 357021687, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(477), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(479), null, "6949277780", null, null, null },
                    { 377481449, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2445), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2446), null, "69492777812", null, null, null },
                    { 631147463, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(563), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(564), null, "6949277781", null, null, null },
                    { 644685397, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1915), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1916), null, "6949277789", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 708245259, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1737), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1738), null, "6949277788", null, null, null },
                    { 794023644, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1202), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1203), null, "6949277785", null, null, null },
                    { 876029121, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(597), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(598), null, "6949277782", null, null, null },
                    { 881494013, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(787), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(788), null, "6949277783", null, null, null },
                    { 902251837, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1556), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1557), null, "6949277787", null, null, null },
                    { 944379020, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3699), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3700), null, "6949277784", null, null, null },
                    { 993944959, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1014), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1015), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -1978396392, 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3729), 944379020, 0f, 1500L, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3730), "HVAC" },
                    { 619843216, 0f, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2664), 133201441, 0f, 1500L, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2665), "ELEC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 123794959, "NBG_IBANK", 1, "D-22-167", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 12.0, 49, new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 49, "Test Description Project_28", "KL-7", new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_7", 5.0, new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_28", 7.0, 644685397, new DateTime(2028, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f },
                    { 244641194, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 9.0, 16, new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 16, "Test Description Project_8", "KL-4", new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_4", 5.0, new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_24", 4.0, 352442796, new DateTime(2025, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f },
                    { 271875684, "NBG_IBANK", 1, "D-22-165", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 10.0, 25, new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 25, "Test Description Project_20", "KL-5", new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_5", 5.0, new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_20", 5.0, 902251837, new DateTime(2026, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f },
                    { 274166805, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 6.0, 1, new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_1", 5.0, new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_5", 1.0, 881494013, new DateTime(2024, 3, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f },
                    { 470609781, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 7.0, 4, new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 4, "Test Description Project_8", "KL-2", new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_2", 5.0, new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_2", 2.0, 993944959, new DateTime(2024, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f },
                    { 544364126, "ALPHA", 1, "D-22-166", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 11.0, 36, new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 36, "Test Description Project_24", "KL-6", new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_6", 5.0, new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_6", 6.0, 708245259, new DateTime(2027, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f },
                    { 630419543, "NBG_IBANK", 1, "D-22-169", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 14.0, 81, new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 81, "Test Description Project_27", "KL-9", new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_9", 5.0, new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_9", 9.0, 249489905, new DateTime(2030, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f },
                    { 884976049, "ALPHA", 1, "D-22-1610", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 15.0, 100, new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 100, "Test Description Project_40", "KL-10", new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_10", 5.0, new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_30", 10.0, 377481449, new DateTime(2032, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f },
                    { 904322234, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 8.0, 9, new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 9, "Test Description Project_9", "KL-3", new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_3", 5.0, new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_18", 3.0, 794023644, new DateTime(2024, 11, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f },
                    { 985814513, "ALPHA", 1, "D-22-168", 0f, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 13.0, 64, new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 64, "Test Description Project_32", "KL-8", new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f, 100L, 12L, new DateTime(2024, 2, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Project_8", 5.0, new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), "Payment Detailes For Project_40", 8.0, 154534271, new DateTime(2029, 6, 26, 12, 51, 29, 902, DateTimeKind.Local).AddTicks(9973), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 704292603, 133201441, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2650), 724214032, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2651) },
                    { 327196754, 154534271, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2109), 163394871, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2110) },
                    { 327196754, 249489905, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2284), 862223979, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2285) },
                    { 802982415, 306201594, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(699), 743861486, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(701) },
                    { 802982415, 335328045, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(669), 352701797, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(670) },
                    { 802982415, 339610050, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(639), 735602414, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(641) },
                    { 327196754, 352442796, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1396), 623602194, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1397) },
                    { 802982415, 357021687, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(539), 647698131, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(541) },
                    { 327196754, 377481449, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2460), 525168243, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2461) },
                    { 802982415, 631147463, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(584), 990802376, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(585) },
                    { 327196754, 644685397, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1930), 516528198, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1931) },
                    { 327196754, 708245259, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1754), 183571969, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1755) },
                    { 327196754, 794023644, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1217), 823895576, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1219) },
                    { 802982415, 876029121, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(612), 696514119, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(613) },
                    { 327196754, 881494013, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(806), 872285002, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(807) },
                    { 327196754, 902251837, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1571), 134715814, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1572) },
                    { 704292603, 944379020, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3716), 940562823, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3717) },
                    { 327196754, 993944959, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1031), 207838572, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1032) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1978396392, 163230434, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4613), 275634683, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4614) },
                    { -1978396392, 212044491, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4261), 899001958, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4262) },
                    { -1978396392, 215820310, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4539), 823011654, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4540) },
                    { -1978396392, 220810642, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4248), 150589403, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4250) },
                    { -1978396392, 248848305, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4185), 739613412, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4186) },
                    { -1978396392, 250256215, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4355), 553281665, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4356) },
                    { -1978396392, 250481418, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4159), 998369469, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4160) },
                    { -1978396392, 253218257, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4302), 939949311, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4304) },
                    { -1978396392, 267111527, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4108), 148183905, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4109) },
                    { -1978396392, 289719781, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4576), 496390051, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4577) },
                    { -1978396392, 296738623, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4327), 503911974, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4329) },
                    { -1978396392, 307198806, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4637), 976013169, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4638) },
                    { -1978396392, 313891409, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4453), 344827396, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4454) },
                    { -1978396392, 329316690, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3967), 787532819, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3968) },
                    { -1978396392, 369280188, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4380), 186063548, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4381) },
                    { -1978396392, 402057129, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4121), 990281357, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4122) },
                    { -1978396392, 414035878, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4146), 845634646, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4147) },
                    { -1978396392, 421829231, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3886), 807952225, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3887) },
                    { -1978396392, 422240299, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4095), 169204183, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4096) },
                    { -1978396392, 454231695, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4563), 271776924, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4565) },
                    { -1978396392, 461960386, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4465), 909552197, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4467) },
                    { -1978396392, 468648646, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4069), 941170756, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4071) },
                    { -1978396392, 499508672, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4429), 700872275, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4430) },
                    { -1978396392, 506516222, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4502), 158288386, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4504) },
                    { -1978396392, 544846378, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4315), 131763447, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4316) },
                    { -1978396392, 551837434, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3993), 583321990, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3994) },
                    { -1978396392, 554964432, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4031), 805598398, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4033) },
                    { -1978396392, 570840320, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4404), 503365487, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4405) },
                    { -1978396392, 571376010, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4490), 291311341, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4491) },
                    { -1978396392, 572117586, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4223), 313765707, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4224) },
                    { -1978396392, 593105774, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3954), 927772055, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3955) },
                    { -1978396392, 639037134, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4625), 411182736, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4626) },
                    { -1978396392, 644109954, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4210), 330244798, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4211) },
                    { -1978396392, 647275773, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4600), 644427872, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4601) },
                    { -1978396392, 689221224, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4515), 212274939, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4516) },
                    { -1978396392, 702467040, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3899), 719939707, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3900) },
                    { -1978396392, 712195056, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4478), 810688126, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4479) },
                    { -1978396392, 745154514, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4340), 757703767, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4341) },
                    { -1978396392, 750368354, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4082), 274583994, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4083) },
                    { -1978396392, 790136529, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4172), 707198641, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4173) },
                    { -1978396392, 793226616, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4527), 125146699, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4528) },
                    { -1978396392, 815832825, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4392), 918117243, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4393) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1978396392, 848128585, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3911), 474973853, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3913) },
                    { -1978396392, 849829804, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3924), 499480783, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3925) },
                    { -1978396392, 850511862, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4133), 235976049, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4135) },
                    { -1978396392, 858182002, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4019), 308409497, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4020) },
                    { -1978396392, 862246184, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4197), 695322693, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4199) },
                    { -1978396392, 862843836, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4290), 508922672, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4291) },
                    { -1978396392, 869991172, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3980), 850412142, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3982) },
                    { -1978396392, 870353226, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4277), 601669386, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4278) },
                    { -1978396392, 870753958, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4551), 265335668, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4553) },
                    { -1978396392, 887504525, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4006), 436537584, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4007) },
                    { -1978396392, 891587753, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3937), 542561637, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3938) },
                    { -1978396392, 921356499, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4044), 301086176, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4045) },
                    { -1978396392, 930885497, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4416), 270557089, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4418) },
                    { -1978396392, 931525237, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4588), 667572108, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4589) },
                    { -1978396392, 936064650, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4367), 309976477, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4368) },
                    { -1978396392, 967761949, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4441), 644649655, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4442) },
                    { -1978396392, 971411976, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4236), 207315737, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4237) },
                    { -1978396392, 989888257, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4057), 641222615, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4058) },
                    { 619843216, 163230434, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3661), 276709502, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3662) },
                    { 619843216, 212044491, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3295), 897055475, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3296) },
                    { 619843216, 215820310, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3580), 369297914, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3581) },
                    { 619843216, 220810642, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3282), 688484209, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3284) },
                    { 619843216, 248848305, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3213), 919633487, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3215) },
                    { 619843216, 250256215, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3387), 209913699, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3388) },
                    { 619843216, 250481418, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3188), 746237056, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3189) },
                    { 619843216, 253218257, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3333), 574595869, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3335) },
                    { 619843216, 267111527, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3136), 265534845, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3137) },
                    { 619843216, 289719781, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3618), 361363791, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3620) },
                    { 619843216, 296738623, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3361), 416943875, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3362) },
                    { 619843216, 307198806, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3686), 380514012, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3687) },
                    { 619843216, 313891409, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3490), 489554355, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3491) },
                    { 619843216, 329316690, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2991), 996822966, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2992) },
                    { 619843216, 369280188, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3413), 463607359, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3414) },
                    { 619843216, 402057129, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3149), 944036539, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3150) },
                    { 619843216, 414035878, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3175), 771733051, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3176) },
                    { 619843216, 421829231, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2903), 821898536, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2905) },
                    { 619843216, 422240299, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3122), 369676320, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3123) },
                    { 619843216, 454231695, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3605), 137978649, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3607) },
                    { 619843216, 461960386, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3503), 450066162, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3504) },
                    { 619843216, 468648646, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3096), 795311896, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3097) },
                    { 619843216, 499508672, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3464), 659454191, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3465) },
                    { 619843216, 506516222, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3541), 485528278, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3542) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 619843216, 544846378, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3348), 502694541, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3349) },
                    { 619843216, 551837434, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3017), 687045697, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3018) },
                    { 619843216, 554964432, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3057), 678724652, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3058) },
                    { 619843216, 570840320, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3439), 301625027, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3440) },
                    { 619843216, 571376010, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3529), 562042934, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3530) },
                    { 619843216, 572117586, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3256), 195943406, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3257) },
                    { 619843216, 593105774, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2978), 424241988, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2979) },
                    { 619843216, 639037134, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3673), 961382071, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3675) },
                    { 619843216, 644109954, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3239), 175340735, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3241) },
                    { 619843216, 647275773, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3648), 235355487, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3649) },
                    { 619843216, 689221224, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3554), 344337271, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3555) },
                    { 619843216, 702467040, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2924), 158848192, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2925) },
                    { 619843216, 712195056, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3516), 471241383, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3517) },
                    { 619843216, 745154514, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3374), 128573678, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3375) },
                    { 619843216, 750368354, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3109), 216086313, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3110) },
                    { 619843216, 790136529, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3200), 840447073, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3202) },
                    { 619843216, 793226616, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3567), 235647153, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3568) },
                    { 619843216, 815832825, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3426), 733273855, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3427) },
                    { 619843216, 848128585, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2938), 379977904, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2939) },
                    { 619843216, 849829804, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2951), 156108543, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2952) },
                    { 619843216, 850511862, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3162), 316400369, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3163) },
                    { 619843216, 858182002, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3044), 685877089, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3045) },
                    { 619843216, 862246184, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3226), 637107198, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3227) },
                    { 619843216, 862843836, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3321), 411894313, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3322) },
                    { 619843216, 869991172, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3004), 673369701, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3005) },
                    { 619843216, 870353226, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3308), 867290171, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3309) },
                    { 619843216, 870753958, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3592), 133747166, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3594) },
                    { 619843216, 887504525, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3031), 828718963, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3032) },
                    { 619843216, 891587753, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2964), 927952544, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2965) },
                    { 619843216, 921356499, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3070), 902154024, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3071) },
                    { 619843216, 930885497, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3451), 307106900, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3452) },
                    { 619843216, 931525237, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3635), 950969107, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3636) },
                    { 619843216, 936064650, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3400), 426075369, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3401) },
                    { 619843216, 967761949, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3477), 241595276, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3478) },
                    { 619843216, 971411976, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3269), 774170482, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3271) },
                    { 619843216, 989888257, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3083), 567081254, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3084) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1978396392, 306201594, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3873), 108533386, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3874) },
                    { -1978396392, 335328045, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3861), -1502048546, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3862) },
                    { -1978396392, 339610050, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3848), 1826186504, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3849) },
                    { -1978396392, 357021687, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3807), 445334549, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3808) },
                    { -1978396392, 631147463, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3821), 1696753683, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3822) },
                    { -1978396392, 876029121, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3834), -100774579, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3835) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 619843216, 306201594, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2889), 1849196115, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2890) },
                    { 619843216, 335328045, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2874), 1658635398, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2875) },
                    { 619843216, 339610050, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2858), -335789482, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2859) },
                    { 619843216, 357021687, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2758), -927360584, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2759) },
                    { 619843216, 631147463, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2777), 1377083030, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2778) },
                    { 619843216, 876029121, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2842), -2009720654, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2843) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1978396392, -1341712436, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3780), 966995005, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3781) },
                    { -1978396392, 183804708, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3755), 449414749, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3756) },
                    { -1978396392, 689113042, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3743), 246913992, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3744) },
                    { -1978396392, 720489640, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3794), 421506818, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3795) },
                    { -1978396392, 1098015947, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3767), 517215224, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(3769) },
                    { 619843216, -1341712436, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2729), 567102219, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2730) },
                    { 619843216, 183804708, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2701), 925752839, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2702) },
                    { 619843216, 689113042, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2684), 925318924, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2685) },
                    { 619843216, 720489640, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2742), 563872999, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2743) },
                    { 619843216, 1098015947, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2715), 203302799, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2716) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1978396392, 123794959, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4840), -397595559, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4841) },
                    { -1978396392, 244641194, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4758), 1783058071, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4759) },
                    { -1978396392, 271875684, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4786), 508686148, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4787) },
                    { -1978396392, 274166805, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4671), 347318340, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4672) },
                    { -1978396392, 470609781, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4699), -2050410400, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4700) },
                    { -1978396392, 544364126, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4813), 711029248, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4815) },
                    { -1978396392, 630419543, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4896), -1179296515, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4897) },
                    { -1978396392, 884976049, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4924), 600811964, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4925) },
                    { -1978396392, 904322234, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4727), 1052259546, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4728) },
                    { -1978396392, 985814513, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4867), -1547825214, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4869) },
                    { 619843216, 123794959, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4827), -377818105, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4828) },
                    { 619843216, 244641194, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4744), -200487230, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4745) },
                    { 619843216, 271875684, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4772), 516046802, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4773) },
                    { 619843216, 274166805, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4652), -1768167888, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4653) },
                    { 619843216, 470609781, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4685), 438205894, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4686) },
                    { 619843216, 544364126, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4800), 2031925144, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4801) },
                    { 619843216, 630419543, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4881), -1252417758, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4882) },
                    { 619843216, 884976049, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4910), 2138855074, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4911) },
                    { 619843216, 904322234, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4713), 992768441, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4714) },
                    { 619843216, 985814513, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4854), -1078612601, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(4855) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 143656764, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1633), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1636), 103000.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1635), "Signature 1423415", 77358, 271875684, 5.0, 17.0 },
                    { 278781933, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1996), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1998), 10003000.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1997), "Signature 1423442", 37748, 123794959, 7.0, 17.0 },
                    { 368520116, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1096), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1098), 3100.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1097), "Signature 142342", 21602, 470609781, 2.0, 24.0 },
                    { 412300068, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1459), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1462), 13000.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1461), "Signature 1423412", 11164, 244641194, 4.0, 24.0 },
                    { 493492296, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1816), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1818), 1003000.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1817), "Signature 142346", 88801, 544364126, 6.0, 24.0 },
                    { 685048829, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1279), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1281), 4000.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1280), "Signature 1423415", 43437, 904322234, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 700716727, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(899), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(902), 3010.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(901), "Signature 142344", 14686, 274166805, 1.0, 17.0 },
                    { 840857238, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2169), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2171), 100003000.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2170), "Signature 1423440", 63732, 985814513, 8.0, 24.0 },
                    { 946880105, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2346), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2348), 1000003000.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2347), "Signature 1423454", 20073, 630419543, 9.0, 17.0 },
                    { 952397586, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2527), new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2529), 10000003000.0, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2528), "Signature 1423450", 84892, 884976049, 10.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 286732461, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1431), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1433), null, "6949277784", null, null, 244641194 },
                    { 295259004, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1787), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1788), null, "6949277786", null, null, 544364126 },
                    { 314019566, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1251), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1252), null, "6949277783", null, null, 904322234 },
                    { 335916982, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1605), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1606), null, "6949277785", null, null, 271875684 },
                    { 553381160, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1967), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1968), null, "6949277787", null, null, 123794959 },
                    { 595217069, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2141), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2142), null, "6949277788", null, null, 985814513 },
                    { 695174438, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2496), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2498), null, "69492777810", null, null, 884976049 },
                    { 750640000, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2318), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2319), null, "6949277789", null, null, 630419543 },
                    { 757936742, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(864), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(865), null, "6949277781", null, null, 274166805 },
                    { 988097229, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1068), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1069), null, "6949277782", null, null, 470609781 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 557318127, 286732461, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1447), 144200091, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1448) },
                    { 557318127, 295259004, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1803), 619167984, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1804) },
                    { 557318127, 314019566, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1266), 127303509, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1267) },
                    { 557318127, 335916982, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1621), 762381677, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1622) },
                    { 557318127, 553381160, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1983), 857390696, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1984) },
                    { 557318127, 595217069, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2157), 978215741, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2158) },
                    { 557318127, 695174438, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2513), 332111717, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2515) },
                    { 557318127, 750640000, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2334), 392282248, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(2335) },
                    { 557318127, 757936742, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(885), 541542020, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(886) },
                    { 557318127, 988097229, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1084), 791829370, new DateTime(2024, 2, 26, 12, 51, 29, 907, DateTimeKind.Local).AddTicks(1085) }
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
                name: "IX_ManHour_DisciplineId",
                table: "ManHour",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHour_DrawingId",
                table: "ManHour",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHour_OtherId",
                table: "ManHour",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHour_ProjectId",
                table: "ManHour",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHour_UserId",
                table: "ManHour",
                column: "UserId");

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
                name: "ManHour");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Timespan");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Drawings");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
