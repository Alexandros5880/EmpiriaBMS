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
                    MenHours = table.Column<long>(type: "bigint", nullable: false),
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
                    { 163488789, new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6523), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6524), 0L, "Draw_5_1" },
                    { 173522618, new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6768), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6769), 0L, "Draw_6_5" },
                    { 201916572, new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6540), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6541), 0L, "Draw_5_2" },
                    { 216339294, new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7136), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7137), 0L, "Draw_8_5" },
                    { 220130723, new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6881), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6883), 0L, "Draw_7_0" },
                    { 248597155, new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7263), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7265), 0L, "Draw_9_1" },
                    { 253103715, new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6695), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6696), 0L, "Draw_6_0" },
                    { 259100973, new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6353), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6354), 0L, "Draw_4_2" },
                    { 260545686, new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7066), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7067), 0L, "Draw_8_0" },
                    { 267820526, new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7477), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7478), 0L, "Draw_10_3" },
                    { 285297223, new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6212), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6213), 0L, "Draw_3_5" },
                    { 290339001, new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7122), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7124), 0L, "Draw_8_4" },
                    { 298665861, new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6339), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6340), 0L, "Draw_4_1" },
                    { 315095857, new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7278), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7279), 0L, "Draw_9_2" },
                    { 315587293, new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5982), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5984), 0L, "Draw_2_2" },
                    { 332832928, new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5949), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5950), 0L, "Draw_2_0" },
                    { 349858293, new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6925), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6926), 0L, "Draw_7_3" },
                    { 356292441, new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6182), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6183), 0L, "Draw_3_3" },
                    { 357268926, new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6911), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6912), 0L, "Draw_7_2" },
                    { 365379104, new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6154), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6155), 0L, "Draw_3_1" },
                    { 385660665, new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5965), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5966), 0L, "Draw_2_1" },
                    { 390492025, new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5830), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5832), 0L, "Draw_1_5" },
                    { 391782863, new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6168), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6169), 0L, "Draw_3_2" },
                    { 397233544, new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7109), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7110), 0L, "Draw_8_3" },
                    { 398647758, new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6953), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6954), 0L, "Draw_7_5" },
                    { 466937752, new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6568), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6569), 0L, "Draw_5_4" },
                    { 482358236, new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6028), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6029), 0L, "Draw_2_5" },
                    { 495871113, new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7081), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7082), 0L, "Draw_8_1" },
                    { 497223782, new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6724), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6725), 0L, "Draw_6_2" },
                    { 502916826, new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6395), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6396), 0L, "Draw_4_5" },
                    { 509360925, new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6582), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6583), 0L, "Draw_5_5" },
                    { 535297491, new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6381), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6382), 0L, "Draw_4_4" },
                    { 584439907, new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7505), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7506), 0L, "Draw_10_5" },
                    { 591334980, new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7305), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7306), 0L, "Draw_9_4" },
                    { 613474190, new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6939), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6940), 0L, "Draw_7_4" },
                    { 619328135, new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6013), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6014), 0L, "Draw_2_4" },
                    { 640912585, new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6739), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6741), 0L, "Draw_6_3" },
                    { 641796923, new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5747), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5748), 0L, "Draw_1_0" },
                    { 670285544, new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5770), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5772), 0L, "Draw_1_1" },
                    { 673969694, new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6139), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6140), 0L, "Draw_3_0" },
                    { 675135939, new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6508), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6509), 0L, "Draw_5_0" },
                    { 683658863, new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6554), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6555), 0L, "Draw_5_3" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 713876644, new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6897), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6898), 0L, "Draw_7_1" },
                    { 728417849, new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6753), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6755), 0L, "Draw_6_4" },
                    { 764598467, new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6196), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6197), 0L, "Draw_3_4" },
                    { 790250126, new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5801), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5802), 0L, "Draw_1_3" },
                    { 791020889, new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7449), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7450), 0L, "Draw_10_1" },
                    { 795903198, new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5998), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6000), 0L, "Draw_2_3" },
                    { 803486611, new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7434), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7435), 0L, "Draw_10_0" },
                    { 834997259, new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6709), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6711), 0L, "Draw_6_1" },
                    { 837730275, new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5786), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5787), 0L, "Draw_1_2" },
                    { 850653980, new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7319), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7321), 0L, "Draw_9_5" },
                    { 852702658, new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7291), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7292), 0L, "Draw_9_3" },
                    { 857117110, new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7463), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7465), 0L, "Draw_10_2" },
                    { 889839931, new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6367), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6368), 0L, "Draw_4_3" },
                    { 903102655, new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7095), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7096), 0L, "Draw_8_2" },
                    { 905329363, new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5815), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5816), 0L, "Draw_1_4" },
                    { 944093569, new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7491), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7492), 0L, "Draw_10_4" },
                    { 944627744, new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7249), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7250), 0L, "Draw_9_0" },
                    { 946727639, new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6324), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6325), 0L, "Draw_4_0" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1765733161, 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5549), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5550), 0L, "Printing" },
                    { -61168375, 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5592), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5594), 0L, "Administration" },
                    { 384298411, 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5564), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5565), 0L, "On-Site" },
                    { 789630774, 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5578), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5579), 0L, "Meetings" },
                    { 2115855164, 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5531), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5533), 0L, "Communications" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 148639154, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5140), true, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5141), "Engineer" },
                    { 294673773, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5164), true, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5165), "CTO" },
                    { 558586653, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5172), true, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5173), "CEO" },
                    { 675766919, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5156), true, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5158), "COO" },
                    { 692456047, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5187), false, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5189), "Customer" },
                    { 954740882, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5180), false, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5181), "Guest" },
                    { 957839104, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5148), true, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5149), "Project Manager" },
                    { 962897659, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5131), true, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5132), "Designer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 159619131, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6967), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6968), null, "69492777810", null, null, null },
                    { 222070846, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6226), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6228), null, "6949277786", null, null, null },
                    { 223181562, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5408), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5410), null, "6949277782", null, null, null },
                    { 287731658, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7150), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7151), null, "69492777811", null, null, null },
                    { 339112886, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5377), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5379), null, "6949277781", null, null, null },
                    { 397140280, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5295), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5296), null, "6949277780", null, null, null },
                    { 443972981, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6785), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6787), null, "6949277789", null, null, null },
                    { 510107792, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6597), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6598), null, "6949277788", null, null, null },
                    { 522803704, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7334), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7335), null, "69492777812", null, null, null },
                    { 531155216, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7524), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7526), null, "6949277783", null, null, null },
                    { 538193863, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8508), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8509), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 539489165, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6409), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6410), null, "6949277787", null, null, null },
                    { 584554988, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5468), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5469), null, "6949277784", null, null, null },
                    { 626685658, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5610), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5612), null, "6949277783", null, null, null },
                    { 718616088, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5845), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5846), null, "6949277784", null, null, null },
                    { 892818978, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6042), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6044), null, "6949277785", null, null, null },
                    { 932126884, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5500), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5501), null, "6949277785", null, null, null },
                    { 938032411, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5438), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5440), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 613792032, 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8538), 538193863, 1500L, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8540), 0L, "HVAC" },
                    { 2133042312, 0f, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7558), 531155216, 1500L, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7559), 0L, "ELEC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 181370301, "NBG_IBANK", 1, "D-22-165", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 10.0, 25, new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 25, "Test Description Project_20", "KL-5", new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_5", 5.0, new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_20", 5.0, 539489165, new DateTime(2026, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f },
                    { 203269245, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 9.0, 16, new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 16, "Test Description Project_24", "KL-4", new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_4", 5.0, new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_20", 4.0, 222070846, new DateTime(2025, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f },
                    { 329905144, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 6.0, 1, new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 1, "Test Description Project_4", "KL-1", new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_1", 5.0, new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_1", 1.0, 626685658, new DateTime(2024, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f },
                    { 530748559, "ALPHA", 1, "D-22-1610", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 15.0, 100, new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 100, "Test Description Project_20", "KL-10", new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_10", 5.0, new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_50", 10.0, 522803704, new DateTime(2032, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f },
                    { 614204805, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 7.0, 4, new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_2", 5.0, new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_10", 2.0, 718616088, new DateTime(2024, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f },
                    { 666499088, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 8.0, 9, new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 9, "Test Description Project_3", "KL-3", new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_3", 5.0, new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_3", 3.0, 892818978, new DateTime(2024, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f },
                    { 713467134, "ALPHA", 1, "D-22-168", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 13.0, 64, new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 64, "Test Description Project_16", "KL-8", new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_8", 5.0, new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_32", 8.0, 159619131, new DateTime(2029, 6, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f },
                    { 884318204, "NBG_IBANK", 1, "D-22-167", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 12.0, 49, new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 49, "Test Description Project_7", "KL-7", new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_7", 5.0, new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_35", 7.0, 443972981, new DateTime(2028, 3, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f },
                    { 931180126, "NBG_IBANK", 1, "D-22-169", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 14.0, 81, new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 81, "Test Description Project_45", "KL-9", new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_9", 5.0, new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_18", 9.0, 287731658, new DateTime(2030, 11, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f },
                    { 938737509, "ALPHA", 1, "D-22-166", 0f, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 11.0, 36, new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 36, "Test Description Project_12", "KL-6", new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f, 1000L, 125L, new DateTime(2024, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0L, "Project_6", 5.0, new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), "Payment Detailes For Project_24", 6.0, 510107792, new DateTime(2027, 2, 24, 13, 10, 12, 757, DateTimeKind.Local).AddTicks(2465), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 957839104, 159619131, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6984), 293629925, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6985) },
                    { 957839104, 222070846, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6242), 494197147, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6243) },
                    { 962897659, 223181562, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5425), 433650114, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5426) },
                    { 957839104, 287731658, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7166), 526349874, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7168) },
                    { 962897659, 339112886, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5395), 201255561, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5396) },
                    { 962897659, 397140280, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5355), 883454798, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5357) },
                    { 957839104, 443972981, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6802), 877616920, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6803) },
                    { 957839104, 510107792, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6614), 727579134, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6615) },
                    { 957839104, 522803704, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7353), 594201913, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7355) },
                    { 148639154, 531155216, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7543), 350480209, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7544) },
                    { 148639154, 538193863, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8525), 772685341, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8526) },
                    { 957839104, 539489165, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6425), 961221224, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6426) },
                    { 962897659, 584554988, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5485), 201016537, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5486) },
                    { 957839104, 626685658, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5630), 145379598, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5631) },
                    { 957839104, 718616088, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5862), 355406219, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5863) },
                    { 957839104, 892818978, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6059), 711768351, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6060) },
                    { 962897659, 932126884, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5516), 388562275, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5518) },
                    { 962897659, 938032411, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5454), 942535316, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5456) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 613792032, 163488789, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9015), 966988515, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9016) },
                    { 613792032, 173522618, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9142), 419604258, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9143) },
                    { 613792032, 201916572, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9027), 846648493, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9028) },
                    { 613792032, 216339294, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9291), 597527241, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9292) },
                    { 613792032, 220130723, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9155), 567755049, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9156) },
                    { 613792032, 248597155, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9316), 204438293, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9317) },
                    { 613792032, 253103715, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9077), 809010954, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9078) },
                    { 613792032, 259100973, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8952), 203979935, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8954) },
                    { 613792032, 260545686, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9229), 736197520, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9230) },
                    { 613792032, 267820526, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9415), 697296585, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9416) },
                    { 613792032, 285297223, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8915), 733171293, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8917) },
                    { 613792032, 290339001, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9279), 830703149, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9280) },
                    { 613792032, 298665861, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8940), 519405493, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8941) },
                    { 613792032, 315095857, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9328), 722151747, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9329) },
                    { 613792032, 315587293, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8803), 744776522, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8805) },
                    { 613792032, 332832928, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8778), 526816059, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8780) },
                    { 613792032, 349858293, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9192), 682945555, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9193) },
                    { 613792032, 356292441, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8891), 282532918, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8892) },
                    { 613792032, 357268926, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9180), 528932020, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9181) },
                    { 613792032, 365379104, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8865), 489999659, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8867) },
                    { 613792032, 385660665, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8791), 709519110, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8792) },
                    { 613792032, 390492025, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8765), 524672799, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8767) },
                    { 613792032, 391782863, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8878), 631271477, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8879) },
                    { 613792032, 397233544, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9266), 163267352, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9267) },
                    { 613792032, 398647758, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9216), 964781336, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9218) },
                    { 613792032, 466937752, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9052), 656384139, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9053) },
                    { 613792032, 482358236, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8841), 518726050, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8842) },
                    { 613792032, 495871113, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9241), 817148710, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9242) },
                    { 613792032, 497223782, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9102), 651326798, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9103) },
                    { 613792032, 502916826, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8990), 563065442, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8991) },
                    { 613792032, 509360925, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9064), 767521812, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9066) },
                    { 613792032, 535297491, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8977), 272499347, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8979) },
                    { 613792032, 584439907, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9440), 356350151, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9441) },
                    { 613792032, 591334980, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9353), 272783068, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9354) },
                    { 613792032, 613474190, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9204), 999688448, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9205) },
                    { 613792032, 619328135, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8828), 636977483, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8830) },
                    { 613792032, 640912585, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9114), 916701120, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9115) },
                    { 613792032, 641796923, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8699), 752564509, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8700) },
                    { 613792032, 670285544, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8712), 392193422, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8713) },
                    { 613792032, 673969694, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8853), 319163685, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8854) },
                    { 613792032, 675135939, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9002), 177162248, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9004) },
                    { 613792032, 683658863, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9040), 466080729, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9041) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 613792032, 713876644, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9167), 898974456, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9168) },
                    { 613792032, 728417849, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9130), 875313587, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9131) },
                    { 613792032, 764598467, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8903), 530132404, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8904) },
                    { 613792032, 790250126, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8737), 917387410, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8738) },
                    { 613792032, 791020889, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9390), 657164607, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9391) },
                    { 613792032, 795903198, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8816), 576244357, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8817) },
                    { 613792032, 803486611, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9378), 228700328, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9379) },
                    { 613792032, 834997259, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9089), 316231554, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9091) },
                    { 613792032, 837730275, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8724), 207719732, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8725) },
                    { 613792032, 850653980, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9365), 508458607, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9367) },
                    { 613792032, 852702658, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9341), 262793783, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9342) },
                    { 613792032, 857117110, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9403), 474030639, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9404) },
                    { 613792032, 889839931, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8965), 175813389, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8966) },
                    { 613792032, 903102655, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9254), 514907259, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9255) },
                    { 613792032, 905329363, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8749), 583170810, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8751) },
                    { 613792032, 944093569, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9428), 960469846, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9429) },
                    { 613792032, 944627744, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9304), 306955215, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9305) },
                    { 613792032, 946727639, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8928), 787257065, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8929) },
                    { 2133042312, 163488789, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8069), 711343307, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8070) },
                    { 2133042312, 173522618, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8194), 311865489, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8195) },
                    { 2133042312, 201916572, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8081), 393578911, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8083) },
                    { 2133042312, 216339294, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8342), 517065786, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8343) },
                    { 2133042312, 220130723, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8206), 437754764, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8207) },
                    { 2133042312, 248597155, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8367), 880142832, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8368) },
                    { 2133042312, 253103715, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8131), 407002084, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8132) },
                    { 2133042312, 259100973, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8004), 668937458, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8005) },
                    { 2133042312, 260545686, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8280), 278338722, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8281) },
                    { 2133042312, 267820526, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8470), 728939667, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8471) },
                    { 2133042312, 285297223, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7967), 581343210, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7968) },
                    { 2133042312, 290339001, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8330), 684200955, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8331) },
                    { 2133042312, 298665861, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7991), 498129165, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7993) },
                    { 2133042312, 315095857, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8380), 190983647, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8381) },
                    { 2133042312, 315587293, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7854), 207229162, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7855) },
                    { 2133042312, 332832928, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7828), 131767991, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7830) },
                    { 2133042312, 349858293, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8243), 237192522, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8244) },
                    { 2133042312, 356292441, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7941), 433806586, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7942) },
                    { 2133042312, 357268926, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8230), 926339706, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8232) },
                    { 2133042312, 365379104, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7916), 924343775, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7917) },
                    { 2133042312, 385660665, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7841), 740942509, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7842) },
                    { 2133042312, 390492025, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7815), 644487818, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7817) },
                    { 2133042312, 391782863, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7928), 911907937, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7930) },
                    { 2133042312, 397233544, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8317), 192249139, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8319) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 2133042312, 398647758, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8268), 974689573, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8269) },
                    { 2133042312, 466937752, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8106), 223344200, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8107) },
                    { 2133042312, 482358236, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7892), 254547594, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7893) },
                    { 2133042312, 495871113, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8292), 200828477, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8294) },
                    { 2133042312, 497223782, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8156), 487511923, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8157) },
                    { 2133042312, 502916826, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8041), 849525451, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8042) },
                    { 2133042312, 509360925, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8118), 680832804, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8120) },
                    { 2133042312, 535297491, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8028), 666679174, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8030) },
                    { 2133042312, 584439907, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8495), 298038013, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8496) },
                    { 2133042312, 591334980, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8405), 956665074, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8406) },
                    { 2133042312, 613474190, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8255), 684015827, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8257) },
                    { 2133042312, 619328135, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7879), 773177298, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7881) },
                    { 2133042312, 640912585, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8169), 657530560, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8170) },
                    { 2133042312, 641796923, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7746), 437779758, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7747) },
                    { 2133042312, 670285544, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7763), 456518905, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7764) },
                    { 2133042312, 673969694, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7904), 948128163, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7905) },
                    { 2133042312, 675135939, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8056), 788458069, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8058) },
                    { 2133042312, 683658863, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8094), 311665389, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8095) },
                    { 2133042312, 713876644, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8218), 289242110, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8219) },
                    { 2133042312, 728417849, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8181), 654565319, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8182) },
                    { 2133042312, 764598467, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7953), 537317551, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7954) },
                    { 2133042312, 790250126, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7789), 559329619, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7790) },
                    { 2133042312, 791020889, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8445), 360718416, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8447) },
                    { 2133042312, 795903198, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7867), 382543572, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7868) },
                    { 2133042312, 803486611, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8433), 417540478, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8434) },
                    { 2133042312, 834997259, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8143), 298196540, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8144) },
                    { 2133042312, 837730275, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7776), 132191153, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7777) },
                    { 2133042312, 850653980, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8420), 407187238, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8421) },
                    { 2133042312, 852702658, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8392), 901306676, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8394) },
                    { 2133042312, 857117110, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8458), 345523462, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8459) },
                    { 2133042312, 889839931, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8016), 921893521, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8017) },
                    { 2133042312, 903102655, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8305), 623195326, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8306) },
                    { 2133042312, 905329363, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7802), 958080399, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7803) },
                    { 2133042312, 944093569, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8482), 409682751, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8484) },
                    { 2133042312, 944627744, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8354), 467108052, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8356) },
                    { 2133042312, 946727639, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7979), 846457981, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7980) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 613792032, 223181562, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8645), 1900372325, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8646) },
                    { 613792032, 339112886, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8632), -1065098285, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8633) },
                    { 613792032, 397140280, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8619), 1559136204, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8620) },
                    { 613792032, 584554988, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8673), -1453886374, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8674) },
                    { 613792032, 932126884, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8686), 1799800902, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8687) },
                    { 613792032, 938032411, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8659), 2062054301, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8661) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 2133042312, 223181562, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7690), -799176788, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7692) },
                    { 2133042312, 339112886, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7677), 1906146041, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7678) },
                    { 2133042312, 397140280, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7654), 1618077996, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7656) },
                    { 2133042312, 584554988, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7717), -861365051, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7718) },
                    { 2133042312, 932126884, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7731), 1744722923, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7732) },
                    { 2133042312, 938032411, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7704), 1338113768, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7705) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 613792032, -1765733161, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8565), 539079936, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8567) },
                    { 613792032, -61168375, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8604), 285926969, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8605) },
                    { 613792032, 384298411, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8578), 792752673, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8579) },
                    { 613792032, 789630774, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8590), 480844582, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8591) },
                    { 613792032, 2115855164, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8552), 578767792, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(8554) },
                    { 2133042312, -1765733161, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7597), 184310634, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7599) },
                    { 2133042312, -61168375, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7638), 324788381, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7639) },
                    { 2133042312, 384298411, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7611), 757755796, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7612) },
                    { 2133042312, 789630774, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7624), 154131494, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7626) },
                    { 2133042312, 2115855164, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7577), 160445517, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7578) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 613792032, 181370301, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9586), -954652717, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9587) },
                    { 613792032, 203269245, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9558), 1115871116, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9560) },
                    { 613792032, 329905144, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9472), -934322665, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9473) },
                    { 613792032, 530748559, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9722), 1110614280, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9723) },
                    { 613792032, 614204805, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9500), 1649291220, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9501) },
                    { 613792032, 666499088, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9531), 1973469486, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9532) },
                    { 613792032, 713467134, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9667), 728256682, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9668) },
                    { 613792032, 884318204, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9640), -13827856, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9641) },
                    { 613792032, 931180126, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9695), 1508668684, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9696) },
                    { 613792032, 938737509, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9613), -153531299, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9614) },
                    { 2133042312, 181370301, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9572), 144902258, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9574) },
                    { 2133042312, 203269245, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9545), -2128068482, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9546) },
                    { 2133042312, 329905144, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9455), 1943098570, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9456) },
                    { 2133042312, 530748559, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9708), 1785880856, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9710) },
                    { 2133042312, 614204805, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9486), -1797499448, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9487) },
                    { 2133042312, 666499088, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9516), -1040497000, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9518) },
                    { 2133042312, 713467134, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9654), 844386112, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9655) },
                    { 2133042312, 884318204, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9627), 1649232904, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9628) },
                    { 2133042312, 931180126, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9681), 786535344, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9682) },
                    { 2133042312, 938737509, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9600), 524829459, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(9601) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 126568142, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6489), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6492), 103000.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6491), "Signature 1423425", 62855, 181370301, 5.0, 17.0 },
                    { 218763543, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6307), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6310), 13000.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6309), "Signature 1423412", 69187, 203269245, 4.0, 24.0 },
                    { 237226528, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7046), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7049), 100003000.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7047), "Signature 1423416", 13954, 713467134, 8.0, 24.0 },
                    { 404894539, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6865), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6867), 10003000.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6866), "Signature 1423435", 69450, 884318204, 7.0, 17.0 },
                    { 613739562, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6121), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6123), 4000.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6122), "Signature 1423412", 81609, 666499088, 3.0, 17.0 },
                    { 656532437, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7417), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7419), 10000003000.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7418), "Signature 1423440", 31860, 530748559, 10.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 832910297, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5724), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5726), 3010.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5725), "Signature 142346", 63039, 329905144, 1.0, 17.0 },
                    { 842893456, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7231), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7234), 1000003000.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7232), "Signature 142349", 80041, 931180126, 9.0, 17.0 },
                    { 848728399, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5931), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5933), 3100.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5932), "Signature 1423410", 10838, 614204805, 2.0, 24.0 },
                    { 849481535, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6678), new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6680), 1003000.0, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6679), "Signature 1423412", 49610, 938737509, 6.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 181995637, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7016), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7017), null, "6949277788", null, null, 713467134 },
                    { 188959533, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6460), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6461), null, "6949277785", null, null, 181370301 },
                    { 306779003, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5901), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5902), null, "6949277782", null, null, 614204805 },
                    { 345433288, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6092), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6093), null, "6949277783", null, null, 666499088 },
                    { 463264775, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7387), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7388), null, "69492777810", null, null, 530748559 },
                    { 478625946, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6648), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6649), null, "6949277786", null, null, 938737509 },
                    { 722854192, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6278), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6279), null, "6949277784", null, null, 203269245 },
                    { 775761092, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7201), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7202), null, "6949277789", null, null, 931180126 },
                    { 791745701, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6835), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6836), null, "6949277787", null, null, 884318204 },
                    { 796449156, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5690), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5691), null, "6949277781", null, null, 329905144 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 692456047, 181995637, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7032), 478327613, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7034) },
                    { 692456047, 188959533, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6476), 643405689, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6477) },
                    { 692456047, 306779003, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5917), 838673788, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5919) },
                    { 692456047, 345433288, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6107), 150648415, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6109) },
                    { 692456047, 463264775, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7404), 815078408, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7405) },
                    { 692456047, 478625946, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6664), 251931336, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6665) },
                    { 692456047, 722854192, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6294), 620837447, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6295) },
                    { 692456047, 775761092, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7218), 791750751, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(7219) },
                    { 692456047, 791745701, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6851), 600917345, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(6852) },
                    { 692456047, 796449156, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5709), 942180633, new DateTime(2024, 2, 24, 13, 10, 12, 760, DateTimeKind.Local).AddTicks(5710) }
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
