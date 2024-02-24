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
                    { 141122281, new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4009), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4011), 0.0, "Draw_5_0" },
                    { 143075625, new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3682), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3683), 0.0, "Draw_3_1" },
                    { 152374715, new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3894), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3895), 0.0, "Draw_4_4" },
                    { 191212356, new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4541), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4542), 0.0, "Draw_8_2" },
                    { 213083753, new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4074), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4075), 0.0, "Draw_5_5" },
                    { 226102171, new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4869), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4871), 0.0, "Draw_10_1" },
                    { 237626698, new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3864), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3865), 0.0, "Draw_4_2" },
                    { 250676009, new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4023), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4024), 0.0, "Draw_5_1" },
                    { 258132238, new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3491), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3492), 0.0, "Draw_2_0" },
                    { 272107099, new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4712), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4713), 0.0, "Draw_9_2" },
                    { 275452119, new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3708), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3709), 0.0, "Draw_3_3" },
                    { 330666420, new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3735), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3736), 0.0, "Draw_3_5" },
                    { 351535330, new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3518), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3519), 0.0, "Draw_2_2" },
                    { 353177836, new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4567), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4568), 0.0, "Draw_8_4" },
                    { 358980886, new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4414), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4415), 0.0, "Draw_7_5" },
                    { 365425290, new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4246), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4247), 0.0, "Draw_6_5" },
                    { 388211026, new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4737), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4738), 0.0, "Draw_9_4" },
                    { 394327010, new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4882), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4883), 0.0, "Draw_10_2" },
                    { 411561277, new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4921), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4922), 0.0, "Draw_10_5" },
                    { 425665405, new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4389), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4390), 0.0, "Draw_7_3" },
                    { 429347325, new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3332), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3333), 0.0, "Draw_1_2" },
                    { 439266505, new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4376), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4377), 0.0, "Draw_7_2" },
                    { 446132977, new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3668), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3669), 0.0, "Draw_3_0" },
                    { 459402647, new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3720), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3721), 0.0, "Draw_3_4" },
                    { 460960914, new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4895), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4896), 0.0, "Draw_10_3" },
                    { 475508232, new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3376), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3378), 0.0, "Draw_1_5" },
                    { 486338416, new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4363), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4364), 0.0, "Draw_7_1" },
                    { 487759065, new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4686), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4687), 0.0, "Draw_9_0" },
                    { 491385861, new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4725), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4726), 0.0, "Draw_9_3" },
                    { 507105600, new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3877), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3878), 0.0, "Draw_4_3" },
                    { 508033446, new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4206), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4207), 0.0, "Draw_6_2" },
                    { 523217291, new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3258), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3259), 0.0, "Draw_1_0" },
                    { 550949431, new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4234), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4235), 0.0, "Draw_6_4" },
                    { 598971655, new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3345), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3346), 0.0, "Draw_1_3" },
                    { 616300800, new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4852), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4853), 0.0, "Draw_10_0" },
                    { 639422564, new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4515), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4516), 0.0, "Draw_8_0" },
                    { 664227332, new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3850), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3851), 0.0, "Draw_4_1" },
                    { 666999091, new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4579), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4580), 0.0, "Draw_8_5" },
                    { 702047656, new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3546), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3548), 0.0, "Draw_2_4" },
                    { 713813986, new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3695), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3696), 0.0, "Draw_3_2" },
                    { 741145365, new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4062), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4063), 0.0, "Draw_5_4" },
                    { 746273735, new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3362), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3363), 0.0, "Draw_1_4" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 759267122, new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4221), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4222), 0.0, "Draw_6_3" },
                    { 760297266, new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4908), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4909), 0.0, "Draw_10_4" },
                    { 777355162, new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3533), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3534), 0.0, "Draw_2_3" },
                    { 788999215, new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4036), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4037), 0.0, "Draw_5_2" },
                    { 830985222, new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3907), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3908), 0.0, "Draw_4_5" },
                    { 840500023, new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4528), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4529), 0.0, "Draw_8_1" },
                    { 851037777, new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4750), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4751), 0.0, "Draw_9_5" },
                    { 872338115, new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4193), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4195), 0.0, "Draw_6_1" },
                    { 877109179, new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4402), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4403), 0.0, "Draw_7_4" },
                    { 887886734, new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4048), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4050), 0.0, "Draw_5_3" },
                    { 888917213, new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3318), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3320), 0.0, "Draw_1_1" },
                    { 889330128, new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4700), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4701), 0.0, "Draw_9_1" },
                    { 921501097, new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3559), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3561), 0.0, "Draw_2_5" },
                    { 935437810, new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3504), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3506), 0.0, "Draw_2_1" },
                    { 937783057, new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4180), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4182), 0.0, "Draw_6_0" },
                    { 945028705, new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3836), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3838), 0.0, "Draw_4_0" },
                    { 973083865, new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4554), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4555), 0.0, "Draw_8_3" },
                    { 987571691, new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4347), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4348), 0.0, "Draw_7_0" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1171076061, 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3084), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3085), 0.0, "On-Site" },
                    { -375036197, 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3053), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3054), 0.0, "Communications" },
                    { -372751083, 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3070), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3071), 0.0, "Printing" },
                    { 954622206, 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3097), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3099), 0.0, "Meetings" },
                    { 1098795778, 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3111), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3112), 0.0, "Administration" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 253716946, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2743), false, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2744), "Customer" },
                    { 282764707, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2722), true, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2723), "CTO" },
                    { 398466892, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2708), true, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2709), "Project Manager" },
                    { 440609131, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2729), true, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2730), "CEO" },
                    { 446040488, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2700), true, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2701), "Engineer" },
                    { 543151042, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2715), true, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2716), "COO" },
                    { 781548162, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2692), true, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2693), "Designer" },
                    { 922876213, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2736), false, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2737), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 165410462, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2841), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2843), null, "6949277780", null, null, null },
                    { 189054578, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4935), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4937), null, "6949277783", null, null, null },
                    { 205639117, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2934), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2935), null, "6949277782", null, null, null },
                    { 286998164, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3128), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3129), null, "6949277783", null, null, null },
                    { 334824409, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2906), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2907), null, "6949277781", null, null, null },
                    { 371130914, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3573), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3574), null, "6949277785", null, null, null },
                    { 389648370, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4259), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4260), null, "6949277789", null, null, null },
                    { 446953872, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4087), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4088), null, "6949277788", null, null, null },
                    { 497536776, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5857), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5858), null, "6949277784", null, null, null },
                    { 540380077, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2992), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2994), null, "6949277784", null, null, null },
                    { 593660069, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3024), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3025), null, "6949277785", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 613223494, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4592), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4593), null, "69492777811", null, null, null },
                    { 633274062, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3390), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3391), null, "6949277784", null, null, null },
                    { 656822544, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2962), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2964), null, "6949277783", null, null, null },
                    { 684420030, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3920), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3921), null, "6949277787", null, null, null },
                    { 737054780, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3749), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3750), null, "6949277786", null, null, null },
                    { 845359814, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4427), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4428), null, "69492777810", null, null, null },
                    { 878916299, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4763), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4764), null, "69492777812", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1529570272, 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5884), 497536776, 1500L, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5885), 0L, "HVAC" },
                    { 489771704, 0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4966), 189054578, 1500L, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4967), 0L, "ELEC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 185561791, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 13.0, 64, new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 64, "Test Description Project_48", "KL-8", new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_8", 5.0, new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_16", 8.0, 845359814, new DateTime(2029, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 },
                    { 225579770, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 8.0, 9, new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 9, "Test Description Project_6", "KL-3", new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_3", 5.0, new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_12", 3.0, 371130914, new DateTime(2024, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 },
                    { 305473628, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 11.0, 36, new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 36, "Test Description Project_18", "KL-6", new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_6", 5.0, new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_24", 6.0, 446953872, new DateTime(2027, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 },
                    { 381211250, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 12.0, 49, new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 49, "Test Description Project_35", "KL-7", new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_7", 5.0, new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_42", 7.0, 389648370, new DateTime(2028, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 },
                    { 394695599, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 15.0, 100, new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 100, "Test Description Project_20", "KL-10", new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_10", 5.0, new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_60", 10.0, 878916299, new DateTime(2032, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 },
                    { 615794817, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 7.0, 4, new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 4, "Test Description Project_8", "KL-2", new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_2", 5.0, new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_10", 2.0, 633274062, new DateTime(2024, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 },
                    { 671434784, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 10.0, 25, new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 25, "Test Description Project_20", "KL-5", new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_5", 5.0, new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_20", 5.0, 684420030, new DateTime(2026, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 },
                    { 706411266, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 6.0, 1, new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 1, "Test Description Project_2", "KL-1", new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_1", 5.0, new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_5", 1.0, 286998164, new DateTime(2024, 3, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 },
                    { 746800245, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 14.0, 81, new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 81, "Test Description Project_54", "KL-9", new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_9", 5.0, new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_9", 9.0, 613223494, new DateTime(2030, 11, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 },
                    { 857128667, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 9.0, 16, new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 16, "Test Description Project_4", "KL-4", new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, 1000L, 125L, new DateTime(2024, 2, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0L, "Project_4", 5.0, new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), "Payment Detailes For Project_20", 4.0, 737054780, new DateTime(2025, 6, 24, 11, 52, 9, 229, DateTimeKind.Local).AddTicks(2202), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 781548162, 165410462, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2886), 521039492, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2887) },
                    { 446040488, 189054578, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4953), 184302710, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4954) },
                    { 781548162, 205639117, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2949), 907419887, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2950) },
                    { 398466892, 286998164, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3146), 828661701, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3147) },
                    { 781548162, 334824409, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2921), 704783298, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2922) },
                    { 398466892, 371130914, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3586), 585941474, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3588) },
                    { 398466892, 389648370, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4273), 891023010, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4274) },
                    { 398466892, 446953872, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4102), 128417250, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4103) },
                    { 446040488, 497536776, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5872), 653018987, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5873) },
                    { 781548162, 540380077, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3010), 326372704, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3011) },
                    { 781548162, 593660069, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3040), 389533253, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3041) },
                    { 398466892, 613223494, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4606), 413284037, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4607) },
                    { 398466892, 633274062, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3405), 981724995, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3406) },
                    { 781548162, 656822544, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2977), 421667243, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(2978) },
                    { 398466892, 684420030, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3934), 347064341, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3935) },
                    { 398466892, 737054780, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3763), 869843773, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3764) },
                    { 398466892, 845359814, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4442), 801080316, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4443) },
                    { 398466892, 878916299, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4777), 655817179, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4778) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1529570272, 141122281, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6324), 203817573, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6325) },
                    { -1529570272, 143075625, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6192), 479685690, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6193) },
                    { -1529570272, 152374715, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6300), 562378179, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6301) },
                    { -1529570272, 191212356, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6560), 238969064, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6561) },
                    { -1529570272, 213083753, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6383), 938651148, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6384) },
                    { -1529570272, 226102171, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6693), 209064706, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6695) },
                    { -1529570272, 237626698, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6277), 990189017, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6278) },
                    { -1529570272, 250676009, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6336), 482433848, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6337) },
                    { -1529570272, 258132238, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6110), 319629311, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6111) },
                    { -1529570272, 272107099, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6635), 982227195, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6636) },
                    { -1529570272, 275452119, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6219), 192469344, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6220) },
                    { -1529570272, 330666420, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6242), 128448374, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6243) },
                    { -1529570272, 351535330, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6133), 704260285, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6134) },
                    { -1529570272, 353177836, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6588), 890943580, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6589) },
                    { -1529570272, 358980886, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6524), 666729172, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6525) },
                    { -1529570272, 365425290, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6453), 523525687, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6454) },
                    { -1529570272, 388211026, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6659), 453256832, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6660) },
                    { -1529570272, 394327010, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6706), 311499749, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6707) },
                    { -1529570272, 411561277, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6740), 828710354, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6741) },
                    { -1529570272, 425665405, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6500), 946766967, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6501) },
                    { -1529570272, 429347325, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6060), 559004010, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6061) },
                    { -1529570272, 439266505, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6488), 444194403, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6489) },
                    { -1529570272, 446132977, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6180), 900827101, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6181) },
                    { -1529570272, 459402647, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6230), 837180531, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6231) },
                    { -1529570272, 460960914, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6717), 167308982, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6718) },
                    { -1529570272, 475508232, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6098), 895193619, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6099) },
                    { -1529570272, 486338416, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6477), 631913073, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6478) },
                    { -1529570272, 487759065, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6612), 356573011, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6613) },
                    { -1529570272, 491385861, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6647), 441229570, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6648) },
                    { -1529570272, 507105600, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6289), 397204468, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6290) },
                    { -1529570272, 508033446, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6418), 554399284, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6419) },
                    { -1529570272, 523217291, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6034), 652746583, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6035) },
                    { -1529570272, 550949431, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6441), 969784212, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6442) },
                    { -1529570272, 598971655, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6072), 606855176, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6073) },
                    { -1529570272, 616300800, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6682), 819709200, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6683) },
                    { -1529570272, 639422564, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6535), 719753327, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6537) },
                    { -1529570272, 664227332, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6265), 661188680, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6266) },
                    { -1529570272, 666999091, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6600), 813906747, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6601) },
                    { -1529570272, 702047656, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6156), 325378523, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6158) },
                    { -1529570272, 713813986, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6203), 259920804, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6205) },
                    { -1529570272, 741145365, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6371), 991360255, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6372) },
                    { -1529570272, 746273735, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6084), 140130461, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6085) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1529570272, 759267122, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6429), 735127444, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6431) },
                    { -1529570272, 760297266, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6729), 737751374, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6730) },
                    { -1529570272, 777355162, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6145), 403170945, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6146) },
                    { -1529570272, 788999215, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6347), 212937084, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6349) },
                    { -1529570272, 830985222, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6312), 694661364, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6313) },
                    { -1529570272, 840500023, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6548), 763120389, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6549) },
                    { -1529570272, 851037777, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6670), 981276975, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6671) },
                    { -1529570272, 872338115, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6406), 580032699, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6407) },
                    { -1529570272, 877109179, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6512), 550874866, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6513) },
                    { -1529570272, 887886734, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6359), 128144556, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6360) },
                    { -1529570272, 888917213, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6048), 908374630, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6049) },
                    { -1529570272, 889330128, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6624), 725976222, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6625) },
                    { -1529570272, 921501097, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6168), 165120613, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6169) },
                    { -1529570272, 935437810, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6122), 808157691, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6123) },
                    { -1529570272, 937783057, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6395), 763010242, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6396) },
                    { -1529570272, 945028705, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6254), 491997361, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6255) },
                    { -1529570272, 973083865, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6571), 970090946, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6572) },
                    { -1529570272, 987571691, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6465), 583325882, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6466) },
                    { 489771704, 141122281, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5432), 209611389, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5433) },
                    { 489771704, 143075625, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5304), 824866793, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5305) },
                    { 489771704, 152374715, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5409), 308696655, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5410) },
                    { 489771704, 191212356, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5672), 809855109, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5673) },
                    { 489771704, 213083753, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5490), 352176857, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5491) },
                    { 489771704, 226102171, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5798), 460148716, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5799) },
                    { 489771704, 237626698, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5386), 657079951, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5387) },
                    { 489771704, 250676009, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5444), 865971282, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5445) },
                    { 489771704, 258132238, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5220), 947509579, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5221) },
                    { 489771704, 272107099, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5741), 296075770, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5742) },
                    { 489771704, 275452119, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5327), 672819616, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5328) },
                    { 489771704, 330666420, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5351), 345146822, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5353) },
                    { 489771704, 351535330, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5244), 434904476, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5245) },
                    { 489771704, 353177836, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5694), 614280276, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5696) },
                    { 489771704, 358980886, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5636), 126337782, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5637) },
                    { 489771704, 365425290, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5566), 215423154, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5567) },
                    { 489771704, 388211026, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5764), 766438175, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5765) },
                    { 489771704, 394327010, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5810), 363840272, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5811) },
                    { 489771704, 411561277, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5845), 914474205, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5846) },
                    { 489771704, 425665405, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5613), 653218487, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5614) },
                    { 489771704, 429347325, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5168), 400217935, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5170) },
                    { 489771704, 439266505, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5601), 156829906, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5602) },
                    { 489771704, 446132977, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5292), 999554917, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5293) },
                    { 489771704, 459402647, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5339), 430041638, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5340) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 489771704, 460960914, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5822), 354224204, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5823) },
                    { 489771704, 475508232, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5205), 170203117, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5206) },
                    { 489771704, 486338416, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5589), 729722234, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5591) },
                    { 489771704, 487759065, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5718), 367936764, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5719) },
                    { 489771704, 491385861, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5752), 610443805, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5753) },
                    { 489771704, 507105600, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5398), 485793424, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5399) },
                    { 489771704, 508033446, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5525), 944485008, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5527) },
                    { 489771704, 523217291, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5139), 250034047, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5140) },
                    { 489771704, 550949431, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5554), 966767476, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5555) },
                    { 489771704, 598971655, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5181), 739559295, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5182) },
                    { 489771704, 616300800, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5787), 809136745, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5788) },
                    { 489771704, 639422564, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5648), 193114842, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5649) },
                    { 489771704, 664227332, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5375), 937973436, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5376) },
                    { 489771704, 666999091, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5706), 246870310, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5707) },
                    { 489771704, 702047656, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5268), 423151235, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5269) },
                    { 489771704, 713813986, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5315), 572671691, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5317) },
                    { 489771704, 741145365, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5479), 279842993, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5480) },
                    { 489771704, 746273735, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5192), 998278957, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5193) },
                    { 489771704, 759267122, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5538), 791653695, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5539) },
                    { 489771704, 760297266, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5833), 908817705, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5834) },
                    { 489771704, 777355162, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5257), 974133255, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5258) },
                    { 489771704, 788999215, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5456), 298109958, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5457) },
                    { 489771704, 830985222, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5421), 143766835, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5422) },
                    { 489771704, 840500023, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5660), 865704915, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5661) },
                    { 489771704, 851037777, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5775), 334838392, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5776) },
                    { 489771704, 872338115, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5513), 331036335, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5515) },
                    { 489771704, 877109179, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5625), 912896961, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5626) },
                    { 489771704, 887886734, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5467), 668139222, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5468) },
                    { 489771704, 888917213, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5157), 468373176, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5158) },
                    { 489771704, 889330128, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5729), 734435634, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5730) },
                    { 489771704, 921501097, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5281), 754850325, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5282) },
                    { 489771704, 935437810, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5232), 990127140, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5233) },
                    { 489771704, 937783057, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5502), 876139289, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5503) },
                    { 489771704, 945028705, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5363), 827534798, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5364) },
                    { 489771704, 973083865, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5683), 252631613, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5684) },
                    { 489771704, 987571691, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5578), 642296446, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5579) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1529570272, 165410462, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5962), -1889872856, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5963) },
                    { -1529570272, 205639117, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5986), 2015347370, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5987) },
                    { -1529570272, 334824409, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5974), 1936290290, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5975) },
                    { -1529570272, 540380077, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6010), 2146076361, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6012) },
                    { -1529570272, 593660069, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6022), -1209520048, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6023) },
                    { -1529570272, 656822544, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5999), -1340165168, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6000) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 489771704, 165410462, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5058), -177337070, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5059) },
                    { 489771704, 205639117, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5089), -2064339836, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5090) },
                    { 489771704, 334824409, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5076), -1132023680, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5077) },
                    { 489771704, 540380077, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5112), -364951723, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5113) },
                    { 489771704, 593660069, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5125), 1620510579, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5126) },
                    { 489771704, 656822544, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5100), -359863015, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5102) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1529570272, -1171076061, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5926), 465203526, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5927) },
                    { -1529570272, -375036197, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5901), 501134692, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5903) },
                    { -1529570272, -372751083, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5914), 966804501, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5915) },
                    { -1529570272, 954622206, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5937), 321843681, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5938) },
                    { -1529570272, 1098795778, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5950), 780179104, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5951) },
                    { 489771704, -1171076061, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5017), 256289307, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5018) },
                    { 489771704, -375036197, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4987), 767046241, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4988) },
                    { 489771704, -372751083, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5004), 459411031, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5005) },
                    { 489771704, 954622206, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5030), 446947333, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5031) },
                    { 489771704, 1098795778, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5044), 592927177, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(5045) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1529570272, 185561791, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6949), 301530355, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6950) },
                    { -1529570272, 225579770, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6821), -2113541556, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6822) },
                    { -1529570272, 305473628, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6897), -1063505922, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6898) },
                    { -1529570272, 381211250, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6921), -181908660, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6922) },
                    { -1529570272, 394695599, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(7000), -1273865163, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(7001) },
                    { -1529570272, 615794817, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6795), -984174835, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6797) },
                    { -1529570272, 671434784, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6872), 2071894404, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6873) },
                    { -1529570272, 706411266, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6770), -1900961927, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6771) },
                    { -1529570272, 746800245, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6975), -1864544574, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6976) },
                    { -1529570272, 857128667, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6846), 1393312561, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6848) },
                    { 489771704, 185561791, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6934), -2114024942, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6935) },
                    { 489771704, 225579770, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6808), -753441840, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6809) },
                    { 489771704, 305473628, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6884), 135205888, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6885) },
                    { 489771704, 381211250, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6909), 942092579, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6910) },
                    { 489771704, 394695599, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6988), 482682256, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6989) },
                    { 489771704, 615794817, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6783), -1770670649, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6784) },
                    { 489771704, 671434784, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6859), 704799134, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6860) },
                    { 489771704, 706411266, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6753), 1913360484, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6755) },
                    { 489771704, 746800245, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6962), 1767622782, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6963) },
                    { 489771704, 857128667, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6834), 1308164284, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(6835) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 127283060, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3473), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3475), 3100.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3474), "Signature 142342", 70019, 615794817, 2.0, 24.0 },
                    { 221076608, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4669), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4671), 1000003000.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4670), "Signature 1423418", 29960, 746800245, 9.0, 17.0 },
                    { 452897637, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4331), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4333), 10003000.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4332), "Signature 1423421", 16004, 381211250, 7.0, 17.0 },
                    { 523330114, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3651), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3653), 4000.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3652), "Signature 142343", 58844, 225579770, 3.0, 17.0 },
                    { 650162086, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3237), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3239), 3010.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3238), "Signature 142345", 40807, 706411266, 1.0, 17.0 },
                    { 665304239, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3993), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3995), 103000.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3994), "Signature 1423425", 32928, 671434784, 5.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 924449871, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3820), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3823), 13000.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3822), "Signature 1423412", 84481, 857128667, 4.0, 24.0 },
                    { 932095959, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4500), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4502), 100003000.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4501), "Signature 1423440", 54589, 185561791, 8.0, 24.0 },
                    { 939904407, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4165), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4167), 1003000.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4166), "Signature 1423412", 63425, 305473628, 6.0, 24.0 },
                    { 977951872, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4837), new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4839), 10000003000.0, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4838), "Signature 1423410", 22820, 394695599, 10.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 425852924, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4809), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4810), null, "69492777810", null, null, 394695599 },
                    { 455544721, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4138), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4140), null, "6949277786", null, null, 305473628 },
                    { 460901139, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3624), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3625), null, "6949277783", null, null, 225579770 },
                    { 469532094, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4306), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4307), null, "6949277787", null, null, 381211250 },
                    { 787392622, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4474), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4475), null, "6949277788", null, null, 185561791 },
                    { 835085787, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3443), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3444), null, "6949277782", null, null, 615794817 },
                    { 845677643, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3205), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3206), null, "6949277781", null, null, 706411266 },
                    { 849639170, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3793), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3795), null, "6949277784", null, null, 857128667 },
                    { 914265945, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3966), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3967), null, "6949277785", null, null, 671434784 },
                    { 915526325, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4643), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4645), null, "6949277789", null, null, 746800245 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 253716946, 425852924, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4825), 853642922, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4826) },
                    { 253716946, 455544721, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4153), 449751695, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4154) },
                    { 253716946, 460901139, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3639), 474831638, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3640) },
                    { 253716946, 469532094, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4319), 159086462, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4320) },
                    { 253716946, 787392622, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4488), 240853123, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4489) },
                    { 253716946, 835085787, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3460), 286330992, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3461) },
                    { 253716946, 845677643, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3223), 982676540, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3224) },
                    { 253716946, 849639170, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3808), 560739652, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3810) },
                    { 253716946, 914265945, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3980), 504974101, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(3981) },
                    { 253716946, 915526325, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4657), 132128117, new DateTime(2024, 2, 24, 11, 52, 9, 232, DateTimeKind.Local).AddTicks(4658) }
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
