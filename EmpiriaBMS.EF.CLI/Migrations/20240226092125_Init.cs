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
                    MenHours = table.Column<long>(type: "bigint", nullable: false),
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
                    MenHours = table.Column<long>(type: "bigint", nullable: false),
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
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 125879474, new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9259), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9260), 0L, "Draw_10_1" },
                    { 127938280, new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8389), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8390), 0L, "Draw_5_3" },
                    { 131367859, new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7956), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7957), 0L, "Draw_3_4" },
                    { 131479990, new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7942), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7943), 0L, "Draw_3_3" },
                    { 140461505, new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9245), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9246), 0L, "Draw_10_0" },
                    { 147535684, new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7779), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7780), 0L, "Draw_2_5" },
                    { 157966500, new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7566), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7568), 0L, "Draw_1_4" },
                    { 166966198, new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8162), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8164), 0L, "Draw_4_0" },
                    { 258811621, new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7585), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7587), 0L, "Draw_1_5" },
                    { 290821502, new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9082), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9083), 0L, "Draw_9_1" },
                    { 304762152, new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7913), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7914), 0L, "Draw_3_1" },
                    { 319056221, new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8928), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8929), 0L, "Draw_8_3" },
                    { 334282343, new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8942), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8943), 0L, "Draw_8_4" },
                    { 340838561, new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8586), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8587), 0L, "Draw_6_4" },
                    { 340870878, new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8361), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8362), 0L, "Draw_5_1" },
                    { 362641087, new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8914), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8915), 0L, "Draw_8_2" },
                    { 377186525, new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8403), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8404), 0L, "Draw_5_4" },
                    { 433172385, new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8178), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8179), 0L, "Draw_4_1" },
                    { 454902126, new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7927), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7928), 0L, "Draw_3_2" },
                    { 455780562, new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7704), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7706), 0L, "Draw_2_0" },
                    { 487077607, new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7552), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7553), 0L, "Draw_1_3" },
                    { 512935874, new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8753), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8754), 0L, "Draw_7_3" },
                    { 513430015, new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8346), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8347), 0L, "Draw_5_0" },
                    { 516372062, new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7522), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7524), 0L, "Draw_1_1" },
                    { 532136763, new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9290), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9291), 0L, "Draw_10_3" },
                    { 540545322, new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9139), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9140), 0L, "Draw_9_5" },
                    { 567582539, new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8205), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8206), 0L, "Draw_4_3" },
                    { 569690483, new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9097), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9098), 0L, "Draw_9_2" },
                    { 600420907, new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9111), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9112), 0L, "Draw_9_3" },
                    { 632691606, new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7538), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7539), 0L, "Draw_1_2" },
                    { 643973988, new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8956), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8957), 0L, "Draw_8_5" },
                    { 660166008, new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8600), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8601), 0L, "Draw_6_5" },
                    { 671143164, new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8542), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8543), 0L, "Draw_6_1" },
                    { 689418230, new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7765), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7766), 0L, "Draw_2_4" },
                    { 711874761, new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8886), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8887), 0L, "Draw_8_0" },
                    { 725636312, new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8375), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8376), 0L, "Draw_5_2" },
                    { 730293518, new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9068), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9069), 0L, "Draw_9_0" },
                    { 738613605, new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9125), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9126), 0L, "Draw_9_4" },
                    { 746044350, new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8781), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8782), 0L, "Draw_7_5" },
                    { 752147079, new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9304), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9305), 0L, "Draw_10_4" },
                    { 757479801, new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7898), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7899), 0L, "Draw_3_0" },
                    { 761757356, new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8572), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8573), 0L, "Draw_6_3" }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 761813513, new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8722), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8723), 0L, "Draw_7_1" },
                    { 775221324, new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8192), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8193), 0L, "Draw_4_2" },
                    { 799979184, new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8767), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8768), 0L, "Draw_7_4" },
                    { 812864457, new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8236), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8237), 0L, "Draw_4_5" },
                    { 822747894, new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9317), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9319), 0L, "Draw_10_5" },
                    { 826029841, new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7734), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7735), 0L, "Draw_2_2" },
                    { 831530356, new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8900), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8901), 0L, "Draw_8_1" },
                    { 832713111, new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8528), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8529), 0L, "Draw_6_0" },
                    { 832926593, new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8556), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8557), 0L, "Draw_6_2" },
                    { 839695711, new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7972), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7973), 0L, "Draw_3_5" },
                    { 842849818, new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8417), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8418), 0L, "Draw_5_5" },
                    { 859375122, new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8219), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8221), 0L, "Draw_4_4" },
                    { 865460351, new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9273), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9274), 0L, "Draw_10_2" },
                    { 871361085, new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7750), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7751), 0L, "Draw_2_3" },
                    { 895586773, new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8708), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8709), 0L, "Draw_7_0" },
                    { 920123614, new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7719), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7721), 0L, "Draw_2_1" },
                    { 935378078, new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7501), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7502), 0L, "Draw_1_0" },
                    { 996603524, new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8736), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8737), 0L, "Draw_7_2" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -997964512, 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7285), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7286), 0L, "Communications" },
                    { -242466819, 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7349), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7351), 0L, "Administration" },
                    { 497150466, 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7335), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7336), 0L, "Meetings" },
                    { 1234381529, 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7305), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7306), 0L, "Printing" },
                    { 1863107376, 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7320), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7321), 0L, "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 185809009, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6872), true, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6873), "Project Manager" },
                    { 388752213, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6880), true, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6882), "COO" },
                    { 707730167, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6897), true, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6898), "CEO" },
                    { 730722627, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6913), false, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6914), "Customer" },
                    { 762465768, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6865), true, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6866), "Engineer" },
                    { 829952700, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6888), true, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6889), "CTO" },
                    { 850448122, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6905), false, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6906), "Guest" },
                    { 888570029, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6856), true, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(6857), "Designer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 136858819, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9153), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9154), null, "69492777812", null, null, null },
                    { 158827717, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7161), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7162), null, "6949277782", null, null, null },
                    { 205097674, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7129), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7130), null, "6949277781", null, null, null },
                    { 263287917, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8431), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8432), null, "6949277788", null, null, null },
                    { 271238375, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8613), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8614), null, "6949277789", null, null, null },
                    { 279579421, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9334), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9335), null, "6949277783", null, null, null },
                    { 384597940, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7218), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7220), null, "6949277784", null, null, null },
                    { 467513715, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7367), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7368), null, "6949277783", null, null, null },
                    { 470977304, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7794), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7795), null, "6949277785", null, null, null },
                    { 548301391, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7189), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7191), null, "6949277783", null, null, null },
                    { 712262960, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7601), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7602), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 750258059, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8796), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8797), null, "69492777810", null, null, null },
                    { 790140303, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7254), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7255), null, "6949277785", null, null, null },
                    { 793337924, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8251), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8252), null, "6949277787", null, null, null },
                    { 838705173, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8970), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8971), null, "69492777811", null, null, null },
                    { 897300122, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7987), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7988), null, "6949277786", null, null, null },
                    { 911041788, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7053), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7054), null, "6949277780", null, null, null },
                    { 919967553, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(306), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(307), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -8835088, 0f, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(335), 919967553, 1500L, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(337), 0L, "HVAC" },
                    { 1036286664, 0f, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9365), 279579421, 1500L, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9367), 0L, "ELEC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 198023053, "ALPHA", 1, "D-22-168", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 13.0, 64, new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 64, "Test Description Project_24", "KL-8", new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_8", 5.0, new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_8", 8.0, 750258059, new DateTime(2029, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f },
                    { 220476947, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 7.0, 4, new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_2", 5.0, new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_4", 2.0, 712262960, new DateTime(2024, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f },
                    { 314096580, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 8.0, 9, new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 9, "Test Description Project_3", "KL-3", new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_3", 5.0, new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_15", 3.0, 470977304, new DateTime(2024, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f },
                    { 332577421, "ALPHA", 1, "D-22-166", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 11.0, 36, new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 36, "Test Description Project_6", "KL-6", new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_6", 5.0, new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_12", 6.0, 263287917, new DateTime(2027, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f },
                    { 342851718, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 6.0, 1, new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 1, "Test Description Project_3", "KL-1", new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_1", 5.0, new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_1", 1.0, 467513715, new DateTime(2024, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f },
                    { 480670787, "NBG_IBANK", 1, "D-22-167", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 12.0, 49, new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 49, "Test Description Project_42", "KL-7", new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_7", 5.0, new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_14", 7.0, 271238375, new DateTime(2028, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f },
                    { 559431202, "NBG_IBANK", 1, "D-22-165", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 10.0, 25, new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 25, "Test Description Project_15", "KL-5", new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_5", 5.0, new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_5", 5.0, 793337924, new DateTime(2026, 3, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f },
                    { 591108538, "ALPHA", 1, "D-22-1610", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 15.0, 100, new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 100, "Test Description Project_60", "KL-10", new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_10", 5.0, new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_10", 10.0, 136858819, new DateTime(2032, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f },
                    { 799855374, "NBG_IBANK", 1, "D-22-169", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 14.0, 81, new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 81, "Test Description Project_27", "KL-9", new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_9", 5.0, new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_27", 9.0, 838705173, new DateTime(2030, 11, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f },
                    { 819087620, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 9.0, 16, new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 16, "Test Description Project_24", "KL-4", new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f, 100L, 12L, new DateTime(2024, 2, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0L, "Project_4", 5.0, new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), "Payment Detailes For Project_8", 4.0, 897300122, new DateTime(2025, 6, 26, 11, 21, 24, 840, DateTimeKind.Local).AddTicks(1113), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 185809009, 136858819, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9168), 926573316, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9169) },
                    { 888570029, 158827717, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7176), 726185947, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7178) },
                    { 888570029, 205097674, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7147), 701263450, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7148) },
                    { 185809009, 263287917, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8447), 539567343, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8448) },
                    { 185809009, 271238375, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8628), 291615419, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8629) },
                    { 762465768, 279579421, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9351), 974176292, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9352) },
                    { 888570029, 384597940, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7239), 227607655, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7241) },
                    { 185809009, 467513715, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7387), 953732359, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7389) },
                    { 185809009, 470977304, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7809), 467058466, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7810) },
                    { 888570029, 548301391, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7205), 739546501, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7206) },
                    { 185809009, 712262960, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7619), 863332933, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7620) },
                    { 185809009, 750258059, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8812), 374696335, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8813) },
                    { 888570029, 790140303, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7270), 209011203, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7271) },
                    { 185809009, 793337924, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8266), 651362631, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8267) },
                    { 185809009, 838705173, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8985), 753239034, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8986) },
                    { 185809009, 897300122, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8002), 181424845, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8004) },
                    { 888570029, 911041788, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7110), 400146319, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7112) },
                    { 762465768, 919967553, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(322), 871880893, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(323) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -8835088, 125879474, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1228), 242927069, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1229) },
                    { -8835088, 127938280, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(835), 814664396, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(836) },
                    { -8835088, 131367859, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(695), 685508697, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(697) },
                    { -8835088, 131479990, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(683), 735148097, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(684) },
                    { -8835088, 140461505, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1216), 411713678, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1217) },
                    { -8835088, 147535684, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(634), 287496635, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(635) },
                    { -8835088, 157966500, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(546), 884035196, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(547) },
                    { -8835088, 166966198, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(723), 721253737, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(724) },
                    { -8835088, 258811621, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(559), 216647613, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(560) },
                    { -8835088, 290821502, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1109), 159400006, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1111) },
                    { -8835088, 304762152, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(658), 946739423, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(660) },
                    { -8835088, 319056221, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1057), 888287231, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1058) },
                    { -8835088, 334282343, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1070), 466176439, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1071) },
                    { -8835088, 340838561, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(921), 382261469, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(922) },
                    { -8835088, 340870878, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(810), 973506217, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(811) },
                    { -8835088, 362641087, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1045), 404042284, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1046) },
                    { -8835088, 377186525, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(847), 918362691, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(848) },
                    { -8835088, 433172385, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(735), 570473559, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(737) },
                    { -8835088, 454902126, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(671), 705131809, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(672) },
                    { -8835088, 455780562, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(572), 422536802, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(573) },
                    { -8835088, 487077607, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(533), 268134860, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(535) },
                    { -8835088, 512935874, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(983), 455759483, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(984) },
                    { -8835088, 513430015, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(798), 481161098, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(799) },
                    { -8835088, 516372062, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(508), 182179562, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(509) },
                    { -8835088, 532136763, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1253), 733195481, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1254) },
                    { -8835088, 540545322, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1203), 194591473, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1204) },
                    { -8835088, 567582539, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(761), 937200247, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(762) },
                    { -8835088, 569690483, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1161), 365303058, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1163) },
                    { -8835088, 600420907, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1177), 245929267, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1178) },
                    { -8835088, 632691606, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(521), 721476837, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(522) },
                    { -8835088, 643973988, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1082), 585258900, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1083) },
                    { -8835088, 660166008, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(933), 559505343, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(935) },
                    { -8835088, 671143164, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(884), 147231346, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(885) },
                    { -8835088, 689418230, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(621), 959527595, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(622) },
                    { -8835088, 711874761, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1020), 605168655, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1021) },
                    { -8835088, 725636312, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(822), 674370210, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(823) },
                    { -8835088, 730293518, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1097), 646408366, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1098) },
                    { -8835088, 738613605, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1190), 471596699, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1191) },
                    { -8835088, 746044350, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1008), 257468293, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1009) },
                    { -8835088, 752147079, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1265), 608682009, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1266) },
                    { -8835088, 757479801, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(646), 709698051, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(647) },
                    { -8835088, 761757356, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(909), 746263236, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(910) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -8835088, 761813513, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(958), 836096272, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(959) },
                    { -8835088, 775221324, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(748), 240309265, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(749) },
                    { -8835088, 799979184, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(995), 165979838, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(997) },
                    { -8835088, 812864457, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(785), 824528582, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(786) },
                    { -8835088, 822747894, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1278), 711463057, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1279) },
                    { -8835088, 826029841, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(597), 185938648, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(598) },
                    { -8835088, 831530356, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1033), 964645059, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1034) },
                    { -8835088, 832713111, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(872), 306602201, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(873) },
                    { -8835088, 832926593, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(897), 796835600, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(898) },
                    { -8835088, 839695711, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(711), 932125391, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(712) },
                    { -8835088, 842849818, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(860), 980127169, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(861) },
                    { -8835088, 859375122, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(773), 607973083, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(774) },
                    { -8835088, 865460351, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1240), 838400076, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1241) },
                    { -8835088, 871361085, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(609), 160924133, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(610) },
                    { -8835088, 895586773, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(946), 275896808, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(947) },
                    { -8835088, 920123614, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(584), 487200665, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(585) },
                    { -8835088, 935378078, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(495), 369662090, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(496) },
                    { -8835088, 996603524, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(970), 590605119, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(972) },
                    { 1036286664, 125879474, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(244), 250214474, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(245) },
                    { 1036286664, 127938280, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9890), 525311727, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9891) },
                    { 1036286664, 131367859, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9753), 848909084, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9754) },
                    { 1036286664, 131479990, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9741), 259428557, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9742) },
                    { 1036286664, 140461505, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(232), 849201463, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(233) },
                    { 1036286664, 147535684, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9690), 458853537, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9692) },
                    { 1036286664, 157966500, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9599), 196567153, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9600) },
                    { 1036286664, 166966198, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9779), 892013767, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9780) },
                    { 1036286664, 258811621, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9612), 399226639, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9613) },
                    { 1036286664, 290821502, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(169), 744604665, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(170) },
                    { 1036286664, 304762152, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9716), 236086115, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9717) },
                    { 1036286664, 319056221, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(120), 823534608, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(121) },
                    { 1036286664, 334282343, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(132), 285200636, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(133) },
                    { 1036286664, 340838561, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9978), 813453824, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9979) },
                    { 1036286664, 340870878, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9865), 796104215, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9866) },
                    { 1036286664, 362641087, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(107), 543241279, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(108) },
                    { 1036286664, 377186525, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9902), 296110910, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9903) },
                    { 1036286664, 433172385, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9791), 416599139, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9792) },
                    { 1036286664, 454902126, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9728), 296148268, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9730) },
                    { 1036286664, 455780562, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9624), 519003320, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9626) },
                    { 1036286664, 487077607, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9587), 473428359, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9588) },
                    { 1036286664, 512935874, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(45), 653134720, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(47) },
                    { 1036286664, 513430015, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9852), 417056025, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9854) },
                    { 1036286664, 516372062, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9562), 348331523, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9563) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1036286664, 532136763, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(269), 528877741, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(270) },
                    { 1036286664, 540545322, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(219), 229019005, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(221) },
                    { 1036286664, 567582539, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9816), 397302003, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9817) },
                    { 1036286664, 569690483, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(182), 732147401, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(183) },
                    { 1036286664, 600420907, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(194), 477576926, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(195) },
                    { 1036286664, 632691606, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9574), 558620427, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9575) },
                    { 1036286664, 643973988, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(145), 518163737, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(146) },
                    { 1036286664, 660166008, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9990), 778706695, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9992) },
                    { 1036286664, 671143164, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9939), 501682481, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9940) },
                    { 1036286664, 689418230, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9678), 856991953, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9679) },
                    { 1036286664, 711874761, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(83), 829375390, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(84) },
                    { 1036286664, 725636312, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9877), 375446582, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9878) },
                    { 1036286664, 730293518, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(157), 564059093, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(158) },
                    { 1036286664, 738613605, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(207), 706946760, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(208) },
                    { 1036286664, 746044350, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(70), 558761403, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(71) },
                    { 1036286664, 752147079, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(281), 128142130, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(282) },
                    { 1036286664, 757479801, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9703), 809691442, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9704) },
                    { 1036286664, 761757356, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9965), 281160379, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9966) },
                    { 1036286664, 761813513, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(21), 935289362, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(22) },
                    { 1036286664, 775221324, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9803), 634523779, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9805) },
                    { 1036286664, 799979184, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(58), 668148138, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(59) },
                    { 1036286664, 812864457, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9840), 299363049, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9841) },
                    { 1036286664, 822747894, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(293), 776589003, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(294) },
                    { 1036286664, 826029841, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9649), 571697377, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9650) },
                    { 1036286664, 831530356, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(95), 824863730, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(96) },
                    { 1036286664, 832713111, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9927), 886583884, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9928) },
                    { 1036286664, 832926593, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9952), 701637728, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9953) },
                    { 1036286664, 839695711, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9766), 152812555, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9767) },
                    { 1036286664, 842849818, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9915), 820471571, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9916) },
                    { 1036286664, 859375122, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9828), 383965603, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9829) },
                    { 1036286664, 865460351, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(256), 523570102, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(258) },
                    { 1036286664, 871361085, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9665), 183119104, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9666) },
                    { 1036286664, 895586773, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(7), 321970814, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(9) },
                    { 1036286664, 920123614, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9637), 237452632, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9638) },
                    { 1036286664, 935378078, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9543), 434649424, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9545) },
                    { 1036286664, 996603524, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(33), 749554162, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(34) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -8835088, 158827717, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(442), 1573901051, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(444) },
                    { -8835088, 205097674, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(429), -183187124, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(430) },
                    { -8835088, 384597940, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(469), -2089722266, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(470) },
                    { -8835088, 548301391, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(456), -671773616, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(457) },
                    { -8835088, 790140303, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(482), 787547750, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(483) },
                    { -8835088, 911041788, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(416), 62093638, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(417) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1036286664, 158827717, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9490), -1274171701, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9491) },
                    { 1036286664, 205097674, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9477), -825755804, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9478) },
                    { 1036286664, 384597940, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9515), -1833148412, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9516) },
                    { 1036286664, 548301391, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9503), -575241781, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9504) },
                    { 1036286664, 790140303, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9528), -27857213, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9529) },
                    { 1036286664, 911041788, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9459), -272745368, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9461) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -8835088, -997964512, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(349), 984557632, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(350) },
                    { -8835088, -242466819, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(403), 564275939, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(404) },
                    { -8835088, 497150466, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(390), 788419687, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(391) },
                    { -8835088, 1234381529, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(362), 292933908, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(363) },
                    { -8835088, 1863107376, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(377), 372591377, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(378) },
                    { 1036286664, -997964512, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9386), 416781987, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9387) },
                    { 1036286664, -242466819, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9444), 296324396, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9445) },
                    { 1036286664, 497150466, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9431), 591582856, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9432) },
                    { 1036286664, 1234381529, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9404), 420786524, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9405) },
                    { 1036286664, 1863107376, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9417), 390214145, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9419) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -8835088, 198023053, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1494), 929148262, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1495) },
                    { -8835088, 220476947, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1337), 2005311744, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1338) },
                    { -8835088, 314096580, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1363), -124494680, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1364) },
                    { -8835088, 332577421, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1443), -2140098026, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1444) },
                    { -8835088, 342851718, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1310), -1369747141, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1311) },
                    { -8835088, 480670787, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1468), 2075214468, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1470) },
                    { -8835088, 559431202, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1416), 1702579744, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1417) },
                    { -8835088, 591108538, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1550), -2095061606, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1552) },
                    { -8835088, 799855374, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1524), -1786284757, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1525) },
                    { -8835088, 819087620, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1390), -597253036, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1391) },
                    { 1036286664, 198023053, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1481), -759596176, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1482) },
                    { 1036286664, 220476947, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1324), -1892276311, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1325) },
                    { 1036286664, 314096580, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1350), 1103336872, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1351) },
                    { 1036286664, 332577421, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1430), 773088586, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1431) },
                    { 1036286664, 342851718, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1293), -308331636, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1294) },
                    { 1036286664, 480670787, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1455), 1057599628, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1457) },
                    { 1036286664, 559431202, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1403), 1956353054, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1404) },
                    { 1036286664, 591108538, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1537), 1101217020, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1538) },
                    { 1036286664, 799855374, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1507), 1442765808, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1508) },
                    { 1036286664, 819087620, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1377), -646159632, new DateTime(2024, 2, 26, 11, 21, 24, 844, DateTimeKind.Local).AddTicks(1378) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 136381523, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7881), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7883), 4000.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7882), "Signature 1423415", 17341, 314096580, 3.0, 17.0 },
                    { 269348886, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8870), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8872), 100003000.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8871), "Signature 142348", 28726, 198023053, 8.0, 24.0 },
                    { 281865379, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9051), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9053), 1000003000.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9052), "Signature 1423418", 33009, 799855374, 9.0, 17.0 },
                    { 305624547, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8146), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8148), 13000.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8147), "Signature 142348", 55482, 819087620, 4.0, 24.0 },
                    { 510505180, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8692), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8694), 10003000.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8693), "Signature 1423414", 68714, 480670787, 7.0, 17.0 },
                    { 574075510, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7480), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7483), 3010.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7482), "Signature 142343", 38334, 342851718, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 805413512, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8512), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8514), 1003000.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8513), "Signature 1423430", 80499, 332577421, 6.0, 24.0 },
                    { 894869886, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8329), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8331), 103000.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8330), "Signature 1423420", 21539, 559431202, 5.0, 17.0 },
                    { 908819663, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9229), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9231), 10000003000.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9230), "Signature 1423460", 65868, 591108538, 10.0, 24.0 },
                    { 945039410, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7686), new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7689), 3100.0, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7687), "Signature 142348", 15317, 220476947, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 165417124, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7446), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7448), null, "6949277781", null, null, 342851718 },
                    { 267880991, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8035), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8036), null, "6949277784", null, null, 819087620 },
                    { 272955532, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7655), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7656), null, "6949277782", null, null, 220476947 },
                    { 371274355, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9199), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9201), null, "69492777810", null, null, 591108538 },
                    { 535120965, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8663), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8664), null, "6949277787", null, null, 480670787 },
                    { 715542989, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8479), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8480), null, "6949277786", null, null, 332577421 },
                    { 785651381, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7843), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7844), null, "6949277783", null, null, 314096580 },
                    { 899671984, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9021), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9022), null, "6949277789", null, null, 799855374 },
                    { 915651128, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8842), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8843), null, "6949277788", null, null, 198023053 },
                    { 918449779, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8299), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8300), null, "6949277785", null, null, 559431202 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 730722627, 165417124, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7465), 690967402, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7467) },
                    { 730722627, 267880991, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8132), 623505615, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8133) },
                    { 730722627, 272955532, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7672), 172525740, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7674) },
                    { 730722627, 371274355, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9216), 820203364, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9217) },
                    { 730722627, 535120965, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8679), 824684505, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8680) },
                    { 730722627, 715542989, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8499), 302604314, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8500) },
                    { 730722627, 785651381, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7867), 491107516, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(7869) },
                    { 730722627, 899671984, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9038), 702536431, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(9039) },
                    { 730722627, 915651128, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8857), 415570675, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8858) },
                    { 730722627, 918449779, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8316), 836034064, new DateTime(2024, 2, 26, 11, 21, 24, 843, DateTimeKind.Local).AddTicks(8317) }
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
                name: "Drawings");

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
