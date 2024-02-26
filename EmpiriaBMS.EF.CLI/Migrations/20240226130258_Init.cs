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
                name: "DrawingsEmployees",
                columns: table => new
                {
                    DrawingId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingsEmployees", x => new { x.DrawingId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_DrawingsEmployees_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
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
                name: "OthersEmployees",
                columns: table => new
                {
                    OtherId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OthersEmployees", x => new { x.OtherId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_OthersEmployees_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 156358161, new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2535), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2536), "Draw_8_4" },
                    { 156513222, new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1978), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1979), "Draw_7_5" },
                    { 158330781, new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9138), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9139), "Draw_3_4" },
                    { 165137552, new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2350), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2351), "Draw_8_2" },
                    { 197431915, new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8076), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8078), "Draw_2_0" },
                    { 228848516, new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1337), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1338), "Draw_6_5" },
                    { 283997552, new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3268), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3269), "Draw_9_5" },
                    { 291088854, new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2907), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2908), "Draw_9_1" },
                    { 317265020, new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9240), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9241), "Draw_3_5" },
                    { 322486255, new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9537), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9538), "Draw_4_1" },
                    { 327069138, new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7297), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7299), "Draw_1_0" },
                    { 329050874, new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(333), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(335), "Draw_5_2" },
                    { 337777607, new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(964), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(965), "Draw_6_1" },
                    { 340185562, new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7575), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7576), "Draw_1_2" },
                    { 349718015, new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3779), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3780), "Draw_10_3" },
                    { 383382870, new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9731), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9732), "Draw_4_3" },
                    { 388466296, new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8267), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8268), "Draw_2_2" },
                    { 396868147, new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8855), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8857), "Draw_3_1" },
                    { 400064352, new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3452), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3453), "Draw_10_0" },
                    { 428489928, new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2441), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2442), "Draw_8_3" },
                    { 443328642, new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3175), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3176), "Draw_9_4" },
                    { 443582350, new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3555), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3556), "Draw_10_1" },
                    { 446760304, new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7770), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7771), "Draw_1_4" },
                    { 455391094, new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9635), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9636), "Draw_4_2" },
                    { 476067803, new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1242), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1243), "Draw_6_4" },
                    { 479914673, new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(238), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(239), "Draw_5_1" },
                    { 492025955, new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9936), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9937), "Draw_4_5" },
                    { 505832410, new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2813), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2814), "Draw_9_0" },
                    { 507958028, new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1523), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1524), "Draw_7_0" },
                    { 526866350, new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(535), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(536), "Draw_5_4" },
                    { 533846155, new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3086), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3087), "Draw_9_3" },
                    { 586074219, new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(675), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(677), "Draw_5_5" },
                    { 594071040, new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1888), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1889), "Draw_7_4" },
                    { 598864529, new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8759), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8760), "Draw_3_0" },
                    { 602143732, new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(868), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(869), "Draw_6_0" },
                    { 638306402, new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9838), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9839), "Draw_4_4" },
                    { 654992419, new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8459), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8460), "Draw_2_4" },
                    { 686046141, new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2164), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2165), "Draw_8_0" },
                    { 686680185, new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7413), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7414), "Draw_1_1" },
                    { 687877249, new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9043), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9044), "Draw_3_3" },
                    { 704537716, new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7867), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7868), "Draw_1_5" },
                    { 709536759, new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1056), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1057), "Draw_6_2" }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 721060258, new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2997), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2998), "Draw_9_2" },
                    { 752328010, new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8556), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8557), "Draw_2_5" },
                    { 779867430, new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9438), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9439), "Draw_4_0" },
                    { 797106143, new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3872), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3873), "Draw_10_4" },
                    { 808919924, new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7671), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7672), "Draw_1_3" },
                    { 811972507, new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(428), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(430), "Draw_5_3" },
                    { 820819468, new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3686), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3687), "Draw_10_2" },
                    { 826278067, new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1617), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1618), "Draw_7_1" },
                    { 895490394, new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1798), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1799), "Draw_7_3" },
                    { 907227278, new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(136), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(138), "Draw_5_0" },
                    { 937005375, new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8172), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8173), "Draw_2_1" },
                    { 957701068, new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1150), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1151), "Draw_6_3" },
                    { 960518974, new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2626), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2627), "Draw_8_5" },
                    { 960675509, new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8362), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8364), "Draw_2_3" },
                    { 962528666, new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2261), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2262), "Draw_8_1" },
                    { 972924128, new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8949), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8951), "Draw_3_2" },
                    { 980034778, new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1707), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1709), "Draw_7_2" },
                    { 998935214, new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3964), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3965), "Draw_10_5" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -1529552751, 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6703), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6704), "On-Site" },
                    { -1111487561, 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6688), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6690), "Printing" },
                    { -510769990, 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6670), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6671), "Communications" },
                    { -323786446, 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6731), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6733), "Administration" },
                    { 954573630, 0f, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6717), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6718), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 211300077, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6286), false, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6287), "Customer" },
                    { 275362663, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6279), false, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6280), "Guest" },
                    { 470780533, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6233), true, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6234), "Designer" },
                    { 514135931, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6249), true, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6250), "Project Manager" },
                    { 604503818, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6264), true, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6265), "CTO" },
                    { 770032570, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6271), true, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6272), "CEO" },
                    { 848392967, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6241), true, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6242), "Engineer" },
                    { 873771526, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6256), true, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6258), "COO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 126378359, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3358), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3359), null, "69492777812", null, null, null },
                    { 139022798, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2716), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2717), null, "69492777811", null, null, null },
                    { 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6519), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6520), null, "6949277782", null, null, null },
                    { 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6487), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6488), null, "6949277781", null, null, null },
                    { 195713990, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1428), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1429), null, "6949277789", null, null, null },
                    { 256604669, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7155), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7156), null, "6949277783", null, null, null },
                    { 366445847, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7964), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7965), null, "6949277784", null, null, null },
                    { 373382243, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4061), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4062), null, "6949277783", null, null, null },
                    { 381139128, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2072), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2073), null, "69492777810", null, null, null },
                    { 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6639), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6640), null, "6949277785", null, null, null },
                    { 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6607), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6608), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 666695441, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5090), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5091), null, "6949277784", null, null, null },
                    { 672499195, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8651), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8652), null, "6949277785", null, null, null },
                    { 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6407), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6408), null, "6949277780", null, null, null },
                    { 925888522, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(771), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(772), null, "6949277788", null, null, null },
                    { 953498523, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9336), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9338), null, "6949277786", null, null, null },
                    { 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6577), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6578), null, "6949277783", null, null, null },
                    { 977903596, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(33), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(34), null, "6949277787", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -276149392, 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4226), 373382243, 0f, 1500L, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4227), "ELEC" },
                    { 665408976, 0f, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5119), 666695441, 0f, 1500L, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5120), "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 156358161, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2575), -1188526171, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2576) },
                    { 156358161, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2563), -1774880198, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2564) },
                    { 156358161, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2613), 496059962, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2614) },
                    { 156358161, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2601), 2034052700, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2602) },
                    { 156358161, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2549), 1264204692, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2550) },
                    { 156358161, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2587), 2016897620, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2589) },
                    { 156513222, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2021), -295801060, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2022) },
                    { 156513222, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2008), -558342251, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2009) },
                    { 156513222, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2059), 91928233, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2060) },
                    { 156513222, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2046), 1180996704, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2047) },
                    { 156513222, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1993), 1492045421, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1994) },
                    { 156513222, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2034), 1922620671, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2035) },
                    { 158330781, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9186), -2088817919, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9188) },
                    { 158330781, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9173), -1601152190, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9174) },
                    { 158330781, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9226), 1899674955, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9227) },
                    { 158330781, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9213), 1420327274, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9214) },
                    { 158330781, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9159), 1478095484, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9160) },
                    { 158330781, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9200), 284474395, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9201) },
                    { 165137552, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2391), 1566027626, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2392) },
                    { 165137552, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2378), -1650518860, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2379) },
                    { 165137552, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2428), -564675151, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2429) },
                    { 165137552, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2416), -324298651, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2417) },
                    { 165137552, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2365), -767316208, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2367) },
                    { 165137552, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2404), -1165629730, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2405) },
                    { 197431915, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8120), 1915423484, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8121) },
                    { 197431915, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8107), 1946771640, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8108) },
                    { 197431915, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8159), 239044906, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8160) },
                    { 197431915, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8146), -1470983777, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8147) },
                    { 197431915, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8093), 1729998414, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8094) },
                    { 197431915, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8133), 2139364359, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8134) },
                    { 228848516, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1378), -458762417, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1379) },
                    { 228848516, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1365), 1966402017, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1366) },
                    { 228848516, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1415), -1028001086, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1416) },
                    { 228848516, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1403), -1806345566, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1404) },
                    { 228848516, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1352), 1849025462, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1353) },
                    { 228848516, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1390), -1069009361, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1391) },
                    { 283997552, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3308), -242754182, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3309) },
                    { 283997552, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3295), -799381223, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3297) },
                    { 283997552, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3346), -1099819358, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3347) },
                    { 283997552, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3333), 278792308, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3334) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 283997552, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3282), -1368814004, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3283) },
                    { 283997552, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3321), 1553268276, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3322) },
                    { 291088854, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2947), 9789152, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2948) },
                    { 291088854, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2934), -1415504011, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2935) },
                    { 291088854, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2984), 2115386586, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2985) },
                    { 291088854, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2971), 1919413719, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2972) },
                    { 291088854, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2922), 91064471, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2923) },
                    { 291088854, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2959), -942058201, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2960) },
                    { 317265020, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9283), 1518484766, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9284) },
                    { 317265020, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9269), -1518974356, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9270) },
                    { 317265020, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9323), -1094469871, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9324) },
                    { 317265020, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9310), 284596786, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9311) },
                    { 317265020, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9255), -2072583679, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9257) },
                    { 317265020, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9296), -1252938577, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9298) },
                    { 322486255, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9580), -451573483, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9581) },
                    { 322486255, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9566), 1298968817, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9568) },
                    { 322486255, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9621), 912903440, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9622) },
                    { 322486255, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9608), -1556209106, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9609) },
                    { 322486255, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9553), 745621511, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9554) },
                    { 322486255, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9594), 374885996, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9595) },
                    { 327069138, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7356), -49723694, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7357) },
                    { 327069138, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7342), 106549075, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7343) },
                    { 327069138, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7398), -1305862456, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7399) },
                    { 327069138, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7383), -24412346, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7385) },
                    { 327069138, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7322), -571010422, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7323) },
                    { 327069138, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7370), 1649575098, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7371) },
                    { 329050874, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(376), -1853107073, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(377) },
                    { 329050874, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(362), 1126393434, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(363) },
                    { 329050874, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(415), -240876359, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(416) },
                    { 329050874, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(402), -425080277, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(403) },
                    { 329050874, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(349), -1647382436, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(350) },
                    { 329050874, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(389), -857928586, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(390) },
                    { 337777607, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1004), -2060090923, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1005) },
                    { 337777607, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(991), 250908292, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(992) },
                    { 337777607, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1043), -444438845, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1044) },
                    { 337777607, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1030), -210418685, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1031) },
                    { 337777607, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(978), -1511047354, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(979) },
                    { 337777607, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1017), -963402137, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1018) },
                    { 340185562, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7617), -763421431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7618) },
                    { 340185562, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7604), 1134335394, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7605) },
                    { 340185562, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7657), -491023597, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7659) },
                    { 340185562, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7643), 2022367230, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7644) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 340185562, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7591), 1726415060, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7592) },
                    { 340185562, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7630), -893681045, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7632) },
                    { 349718015, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3820), 611373740, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3821) },
                    { 349718015, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3807), -272484013, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3808) },
                    { 349718015, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3859), 1418170509, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3860) },
                    { 349718015, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3846), -149637505, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3847) },
                    { 349718015, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3794), 1090164659, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3795) },
                    { 349718015, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3833), 1682586149, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3834) },
                    { 383382870, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9777), 968247410, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9778) },
                    { 383382870, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9764), -1178417654, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9765) },
                    { 383382870, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9824), -641473465, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9825) },
                    { 383382870, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9810), -1542253184, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9812) },
                    { 383382870, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9750), 1174340880, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9751) },
                    { 383382870, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9796), 1434406460, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9797) },
                    { 388466296, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8310), 1715075303, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8311) },
                    { 388466296, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8297), -800448848, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8298) },
                    { 388466296, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8349), 1759464941, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8350) },
                    { 388466296, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8336), 1603566050, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8337) },
                    { 388466296, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8284), 1756853397, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8285) },
                    { 388466296, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8323), -1615535486, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8324) },
                    { 396868147, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8897), -260173759, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8899) },
                    { 396868147, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8884), 1664916773, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8886) },
                    { 396868147, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8936), 1476052236, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8937) },
                    { 396868147, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8923), 1283919071, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8925) },
                    { 396868147, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8871), 1475489007, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8872) },
                    { 396868147, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8910), -1957208638, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8912) },
                    { 400064352, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3494), -1308169300, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3495) },
                    { 400064352, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3481), -2011801832, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3482) },
                    { 400064352, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3531), -462774446, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3532) },
                    { 400064352, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3519), -492075656, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3520) },
                    { 400064352, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3468), -1074813097, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3469) },
                    { 400064352, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3506), 1645772634, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3507) },
                    { 428489928, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2482), -802482389, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2483) },
                    { 428489928, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2469), -121529227, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2470) },
                    { 428489928, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2519), -1818576913, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2521) },
                    { 428489928, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2506), 1325813832, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2507) },
                    { 428489928, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2456), 183647728, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2457) },
                    { 428489928, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2494), -986781356, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2495) },
                    { 443328642, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3215), 1617485234, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3216) },
                    { 443328642, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3203), -524853926, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3204) },
                    { 443328642, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3255), 1626393438, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3256) },
                    { 443328642, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3243), -1463904535, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3244) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 443328642, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3190), -1256101694, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3191) },
                    { 443328642, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3231), 1917106187, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3232) },
                    { 443582350, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3594), 482436212, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3595) },
                    { 443582350, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3582), -1394795951, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3583) },
                    { 443582350, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3673), -1868594732, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3674) },
                    { 443582350, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3660), 286057382, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3661) },
                    { 443582350, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3569), -656680760, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3570) },
                    { 443582350, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3643), -442300193, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3645) },
                    { 446760304, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7815), -1696317142, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7816) },
                    { 446760304, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7802), 1070870936, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7803) },
                    { 446760304, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7854), 1693988564, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7855) },
                    { 446760304, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7841), 337655341, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7842) },
                    { 446760304, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7788), 1251103622, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7789) },
                    { 446760304, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7828), -735343901, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7829) },
                    { 455391094, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9677), -2071276375, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9679) },
                    { 455391094, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9664), -437318090, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9665) },
                    { 455391094, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9717), 749265764, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9719) },
                    { 455391094, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9704), -1391092244, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9705) },
                    { 455391094, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9651), -1516798313, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9652) },
                    { 455391094, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9691), 1051277108, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9692) },
                    { 476067803, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1285), 1072392584, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1286) },
                    { 476067803, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1269), -626669635, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1270) },
                    { 476067803, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1324), -345222152, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1325) },
                    { 476067803, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1311), -2042650372, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1312) },
                    { 476067803, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1257), 1329866366, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1258) },
                    { 476067803, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1298), -221963408, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1299) },
                    { 479914673, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(281), -1501859888, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(282) },
                    { 479914673, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(267), -1146674888, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(268) },
                    { 479914673, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(320), 308663920, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(321) },
                    { 479914673, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(307), 56328674, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(308) },
                    { 479914673, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(254), -1964193353, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(255) },
                    { 479914673, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(294), 26493152, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(295) },
                    { 492025955, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9979), -1752316357, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9980) },
                    { 492025955, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9965), -123047077, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9967) },
                    { 492025955, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(19), -959016986, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(21) },
                    { 492025955, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6), 1516745183, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(7) },
                    { 492025955, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9952), 2125187811, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9953) },
                    { 492025955, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9992), -882020902, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9994) },
                    { 505832410, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2857), -1560858016, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2858) },
                    { 505832410, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2845), 148718935, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2846) },
                    { 505832410, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2894), -491808743, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2895) },
                    { 505832410, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2882), 1704099654, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2883) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 505832410, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2829), 126695080, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2830) },
                    { 505832410, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2870), 818591000, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2871) },
                    { 507958028, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1564), 2133227826, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1566) },
                    { 507958028, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1551), -1608015136, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1552) },
                    { 507958028, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1602), 122244917, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1603) },
                    { 507958028, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1590), 1231874483, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1591) },
                    { 507958028, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1538), -1306237900, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1539) },
                    { 507958028, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1577), -2059731508, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1578) },
                    { 526866350, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(620), -758651431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(621) },
                    { 526866350, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(566), -1625062994, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(567) },
                    { 526866350, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(661), -511091563, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(663) },
                    { 526866350, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(648), -1478119126, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(649) },
                    { 526866350, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(550), 1730343141, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(552) },
                    { 526866350, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(634), 681857708, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(636) },
                    { 533846155, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3126), -1317799633, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3127) },
                    { 533846155, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3113), -2093326159, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3115) },
                    { 533846155, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3163), -638610929, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3164) },
                    { 533846155, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3151), 1645384532, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3152) },
                    { 533846155, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3101), -261379948, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3102) },
                    { 533846155, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3138), -1130158138, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3139) },
                    { 586074219, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(718), 1649476395, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(719) },
                    { 586074219, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(705), -1199316149, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(706) },
                    { 586074219, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(757), -1498450760, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(758) },
                    { 586074219, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(744), -930278749, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(745) },
                    { 586074219, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(691), -1481558989, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(693) },
                    { 586074219, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(731), -1496746574, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(732) },
                    { 594071040, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1928), 1749075134, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1929) },
                    { 594071040, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1915), -266463395, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1916) },
                    { 594071040, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1966), -1217506148, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1967) },
                    { 594071040, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1953), 2014589363, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1954) },
                    { 594071040, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1903), -477495854, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1904) },
                    { 594071040, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1941), 2115005531, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1942) },
                    { 598864529, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8803), 1120052331, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8804) },
                    { 598864529, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8789), 171045311, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8791) },
                    { 598864529, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8842), 1206640773, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8843) },
                    { 598864529, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8829), -1213583755, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8830) },
                    { 598864529, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8776), -1108914020, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8777) },
                    { 598864529, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8816), -282241120, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8817) },
                    { 602143732, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(909), -1101516736, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(910) },
                    { 602143732, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(896), -971748976, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(897) },
                    { 602143732, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(951), 1698980918, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(952) },
                    { 602143732, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(937), -1786120105, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(939) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 602143732, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(883), -1141365910, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(884) },
                    { 602143732, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(922), 1223231405, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(923) },
                    { 638306402, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9881), -1430960179, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9883) },
                    { 638306402, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9868), 2010510000, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9869) },
                    { 638306402, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9922), -360432166, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9924) },
                    { 638306402, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9909), -904430978, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9910) },
                    { 638306402, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9854), -726161800, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9855) },
                    { 638306402, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9895), 1821792569, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9896) },
                    { 654992419, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8501), 504433580, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8502) },
                    { 654992419, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8488), 1757173806, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8489) },
                    { 654992419, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8542), -922772299, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8543) },
                    { 654992419, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8527), -1178578295, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8528) },
                    { 654992419, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8475), -1938224038, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8476) },
                    { 654992419, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8514), -919663312, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8515) },
                    { 686046141, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2205), -1786054400, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2206) },
                    { 686046141, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2193), 1171348349, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2194) },
                    { 686046141, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2247), 303273536, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2248) },
                    { 686046141, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2230), 2065225946, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2231) },
                    { 686046141, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2179), 1768994060, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2181) },
                    { 686046141, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2218), -1313967662, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2219) },
                    { 686680185, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7520), -261080392, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7521) },
                    { 686680185, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7506), -1933704647, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7507) },
                    { 686680185, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7562), -2050810060, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7563) },
                    { 686680185, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7549), -1840910683, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7550) },
                    { 686680185, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7489), -2111425361, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7491) },
                    { 686680185, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7535), 1145712969, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7536) },
                    { 687877249, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9085), -938300719, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9086) },
                    { 687877249, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9072), -1613413115, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9073) },
                    { 687877249, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9125), 1799248149, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9126) },
                    { 687877249, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9111), 856918094, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9112) },
                    { 687877249, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9058), -2116712942, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9060) },
                    { 687877249, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9098), -369475514, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9100) },
                    { 704537716, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7909), -944544154, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7911) },
                    { 704537716, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7896), -1962111451, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7897) },
                    { 704537716, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7950), 251085767, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7952) },
                    { 704537716, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7937), -2053653691, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7939) },
                    { 704537716, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7883), -1681877672, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7885) },
                    { 704537716, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7924), -911789981, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7925) },
                    { 709536759, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1099), -754029292, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1100) },
                    { 709536759, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1086), -987660013, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1088) },
                    { 709536759, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1137), 1877115609, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1138) },
                    { 709536759, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1125), -710787743, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1126) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 709536759, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1073), -143786168, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1074) },
                    { 709536759, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1112), 382733965, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1113) },
                    { 721060258, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3036), -800340947, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3037) },
                    { 721060258, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3024), -2146134766, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3025) },
                    { 721060258, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3073), 1414963656, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3074) },
                    { 721060258, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3061), 294839465, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3062) },
                    { 721060258, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3011), -1339889413, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3012) },
                    { 721060258, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3048), 277392502, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3050) },
                    { 752328010, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8597), 1779634103, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8599) },
                    { 752328010, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8584), -1801880540, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8586) },
                    { 752328010, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8637), -1998760958, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8638) },
                    { 752328010, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8624), 1601367093, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8625) },
                    { 752328010, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8571), 2134576467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8573) },
                    { 752328010, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8611), 635825129, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8612) },
                    { 779867430, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9483), -1255453145, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9484) },
                    { 779867430, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9467), -1965214250, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9468) },
                    { 779867430, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9524), -1946582027, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9525) },
                    { 779867430, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9510), 1783627317, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9511) },
                    { 779867430, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9453), 1144607675, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9455) },
                    { 779867430, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9496), 309449579, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9498) },
                    { 797106143, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3912), 1004202914, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3913) },
                    { 797106143, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3899), -968401340, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3901) },
                    { 797106143, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3951), -1239521219, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3952) },
                    { 797106143, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3938), 236939122, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3939) },
                    { 797106143, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3886), 1256547942, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3887) },
                    { 797106143, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3925), -1616548054, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3926) },
                    { 808919924, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7714), 1659247286, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7715) },
                    { 808919924, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7701), -362723732, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7702) },
                    { 808919924, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7757), -1451264197, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7758) },
                    { 808919924, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7744), 2015833563, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7745) },
                    { 808919924, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7688), -2112694096, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7689) },
                    { 808919924, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7730), -126099697, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7732) },
                    { 811972507, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(484), -1191190796, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(485) },
                    { 811972507, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(457), 926805641, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(458) },
                    { 811972507, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(522), -1459887191, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(523) },
                    { 811972507, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(509), 1077916073, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(510) },
                    { 811972507, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(444), -749804701, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(445) },
                    { 811972507, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(497), -1538361818, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(498) },
                    { 820819468, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3728), -239169010, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3729) },
                    { 820819468, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3715), 694522229, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3716) },
                    { 820819468, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3766), 2081820056, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3767) },
                    { 820819468, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3753), -213098066, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3755) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 820819468, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3702), 2049476423, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3703) },
                    { 820819468, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3741), -1632933274, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3742) },
                    { 826278067, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1657), 1611384602, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1659) },
                    { 826278067, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1645), -1553894176, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1646) },
                    { 826278067, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1695), -602411219, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1696) },
                    { 826278067, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1682), -343677037, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1683) },
                    { 826278067, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1633), -1362091864, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1634) },
                    { 826278067, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1670), 1751108427, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1671) },
                    { 895490394, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1838), -1667247214, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1839) },
                    { 895490394, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1825), -1028964892, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1826) },
                    { 895490394, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1875), -1088457704, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1877) },
                    { 895490394, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1863), -1002090752, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1864) },
                    { 895490394, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1813), 256803809, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1814) },
                    { 895490394, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1850), 305071579, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1851) },
                    { 907227278, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(185), -162832405, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(186) },
                    { 907227278, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(171), -366994358, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(173) },
                    { 907227278, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(224), -1483880404, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(226) },
                    { 907227278, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(211), -305135630, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(212) },
                    { 907227278, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(157), -704115877, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(158) },
                    { 907227278, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(198), -205982198, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(199) },
                    { 937005375, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8214), -1550468132, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8215) },
                    { 937005375, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8201), -833450237, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8202) },
                    { 937005375, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8254), 1465642332, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8255) },
                    { 937005375, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8241), -1453587866, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8242) },
                    { 937005375, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8187), -499622485, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8189) },
                    { 937005375, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8227), -1911784261, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8229) },
                    { 957701068, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1191), -250595468, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1192) },
                    { 957701068, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1178), 398489990, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1179) },
                    { 957701068, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1229), -735497626, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1230) },
                    { 957701068, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1216), 2021106929, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1217) },
                    { 957701068, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1165), 1188534924, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1166) },
                    { 957701068, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1204), -1140714994, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1205) },
                    { 960518974, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2666), -452294923, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2667) },
                    { 960518974, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2653), -1840172336, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2654) },
                    { 960518974, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2703), 2122827372, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2704) },
                    { 960518974, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2691), 27672886, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2692) },
                    { 960518974, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2640), -1203977240, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2642) },
                    { 960518974, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2678), 1980150345, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2679) },
                    { 960675509, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8404), 1407931709, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8405) },
                    { 960675509, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8391), 602749, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8392) },
                    { 960675509, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8446), -252668402, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8447) },
                    { 960675509, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8433), -1953608404, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8434) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 960675509, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8378), -277869343, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8379) },
                    { 960675509, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8417), -354628394, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8418) },
                    { 962528666, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2301), 1466790723, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2302) },
                    { 962528666, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2288), 613511825, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2290) },
                    { 962528666, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2338), -1026398956, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2339) },
                    { 962528666, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2325), 897881747, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2327) },
                    { 962528666, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2276), -251394479, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2277) },
                    { 962528666, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2313), 2024549505, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2314) },
                    { 972924128, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8991), -2061032827, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8992) },
                    { 972924128, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8978), -47642989, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8979) },
                    { 972924128, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9030), -1230338128, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9031) },
                    { 972924128, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9017), 1565870976, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9018) },
                    { 972924128, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8965), -947762099, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8966) },
                    { 972924128, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9004), 330459521, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9005) },
                    { 980034778, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1748), -414214663, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1749) },
                    { 980034778, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1735), -258993989, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1736) },
                    { 980034778, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1785), 1546562381, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1786) },
                    { 980034778, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1773), 1268400794, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1774) },
                    { 980034778, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1723), -1550758837, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1724) },
                    { 980034778, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1760), 1819158800, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1761) },
                    { 998935214, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4007), 367481786, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4008) },
                    { 998935214, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3994), 1359367322, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3995) },
                    { 998935214, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4045), -2117405515, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4047) },
                    { 998935214, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4033), 256028918, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4034) },
                    { 998935214, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3981), 2076135399, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3982) },
                    { 998935214, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4020), -1421719573, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4021) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 144324202, -1529552751, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6921), -95089081, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6922) },
                    { 151878431, -1529552751, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6853), -1343998831, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6854) },
                    { 537779780, -1529552751, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7115), -507133552, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7116) },
                    { 585492907, -1529552751, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7050), 970211642, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7052) },
                    { 820747467, -1529552751, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6785), -300873869, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6786) },
                    { 962186318, -1529552751, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6987), 972889817, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6988) },
                    { 144324202, -1111487561, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6908), 2128477500, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6909) },
                    { 151878431, -1111487561, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6840), -172923992, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6842) },
                    { 537779780, -1111487561, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7101), -181869079, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7103) },
                    { 585492907, -1111487561, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7038), -1133322034, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7039) },
                    { 820747467, -1111487561, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6770), 1335093822, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6771) },
                    { 962186318, -1111487561, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6972), -1491239353, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6974) },
                    { 144324202, -510769990, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6895), -333296032, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6896) },
                    { 151878431, -510769990, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6828), -1785396217, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6829) },
                    { 537779780, -510769990, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7089), -1221311519, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7090) },
                    { 585492907, -510769990, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7025), 1700508380, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7026) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 820747467, -510769990, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6751), -2143075067, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6753) },
                    { 962186318, -510769990, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6960), 666689981, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6961) },
                    { 144324202, -323786446, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6947), -1714618097, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6948) },
                    { 151878431, -323786446, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6879), -75147884, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6880) },
                    { 537779780, -323786446, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7140), -87018083, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7141) },
                    { 585492907, -323786446, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7076), -1178364019, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7077) },
                    { 820747467, -323786446, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6813), -770790658, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6814) },
                    { 962186318, -323786446, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7012), -1174731416, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7014) },
                    { 144324202, 954573630, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6934), -9161275, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6935) },
                    { 151878431, 954573630, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6865), -748849553, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6867) },
                    { 537779780, 954573630, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7127), 1016297726, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7128) },
                    { 585492907, 954573630, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7063), -762551824, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7064) },
                    { 820747467, 954573630, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6799), -341201645, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6800) },
                    { 962186318, 954573630, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7000), -1524650098, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7001) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 236139071, "NBG_IBANK", 1, "D-22-169", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 14.0, 81, new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 81, "Test Description Project_18", "KL-9", new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_9", 5.0, new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_45", 9.0, 139022798, new DateTime(2030, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f },
                    { 309027116, "NBG_IBANK", 1, "D-22-165", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 10.0, 25, new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 25, "Test Description Project_15", "KL-5", new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_5", 5.0, new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_15", 5.0, 977903596, new DateTime(2026, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f },
                    { 347494197, "ALPHA", 1, "D-22-168", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 13.0, 64, new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 64, "Test Description Project_40", "KL-8", new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_8", 5.0, new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_8", 8.0, 381139128, new DateTime(2029, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f },
                    { 357189703, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 6.0, 1, new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 1, "Test Description Project_1", "KL-1", new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_1", 5.0, new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_5", 1.0, 256604669, new DateTime(2024, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f },
                    { 702749905, "ALPHA", 1, "D-22-166", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 11.0, 36, new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 36, "Test Description Project_12", "KL-6", new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_6", 5.0, new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_6", 6.0, 925888522, new DateTime(2027, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f },
                    { 713713862, "ALPHA", 1, "D-22-1610", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 15.0, 100, new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 100, "Test Description Project_30", "KL-10", new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_10", 5.0, new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_30", 10.0, 126378359, new DateTime(2032, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f },
                    { 720105897, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 7.0, 4, new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 4, "Test Description Project_8", "KL-2", new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_2", 5.0, new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_2", 2.0, 366445847, new DateTime(2024, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f },
                    { 819674949, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 8.0, 9, new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 9, "Test Description Project_12", "KL-3", new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_3", 5.0, new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_9", 3.0, 672499195, new DateTime(2024, 11, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f },
                    { 826850044, "NBG_IBANK", 1, "D-22-167", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 12.0, 49, new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 49, "Test Description Project_42", "KL-7", new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_7", 5.0, new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_42", 7.0, 195713990, new DateTime(2028, 3, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f },
                    { 986748286, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 9.0, 16, new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 16, "Test Description Project_12", "KL-4", new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f, 100L, 12L, new DateTime(2024, 2, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Project_4", 5.0, new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), "Payment Detailes For Project_24", 4.0, 953498523, new DateTime(2025, 6, 26, 15, 2, 58, 265, DateTimeKind.Local).AddTicks(9991), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 514135931, 126378359, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3374), 801310472, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3376) },
                    { 514135931, 139022798, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2733), 818994549, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2734) },
                    { 470780533, 144324202, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6556), 339486324, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6557) },
                    { 470780533, 151878431, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6506), 894682393, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6507) },
                    { 514135931, 195713990, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1444), 302865843, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1445) },
                    { 514135931, 256604669, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7175), 284107174, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7176) },
                    { 514135931, 366445847, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7983), 889494476, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7984) },
                    { 848392967, 373382243, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4212), 693381132, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4213) },
                    { 514135931, 381139128, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2089), 212055980, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2090) },
                    { 470780533, 537779780, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6656), 890850116, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6657) },
                    { 470780533, 585492907, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6625), 773729058, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6626) },
                    { 848392967, 666695441, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5107), 254428336, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5108) },
                    { 514135931, 672499195, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8667), 417713789, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8669) },
                    { 470780533, 820747467, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6466), 475003218, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6468) },
                    { 514135931, 925888522, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(788), 393447576, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(789) },
                    { 514135931, 953498523, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9353), 208025006, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9355) },
                    { 470780533, 962186318, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6594), 775683687, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(6595) },
                    { 514135931, 977903596, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(50), 895447709, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(51) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -276149392, 156358161, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4916), 164409040, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4917) },
                    { -276149392, 156513222, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4854), 341735386, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4855) },
                    { -276149392, 158330781, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4539), 454438767, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4540) },
                    { -276149392, 165137552, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4891), 446513802, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4892) },
                    { -276149392, 197431915, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4412), 350254519, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4413) },
                    { -276149392, 228848516, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4777), 543413383, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4778) },
                    { -276149392, 283997552, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5003), 808182094, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5004) },
                    { -276149392, 291088854, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4953), 814629906, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4954) },
                    { -276149392, 317265020, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4552), 896611526, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4553) },
                    { -276149392, 322486255, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4578), 881336111, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4579) },
                    { -276149392, 327069138, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4328), 736849734, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4330) },
                    { -276149392, 329050874, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4664), 516319696, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4665) },
                    { -276149392, 337777607, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4726), 709679921, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4727) },
                    { -276149392, 340185562, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4360), 627048290, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4361) },
                    { -276149392, 349718015, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5052), 869343752, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5053) },
                    { -276149392, 383382870, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4602), 156155816, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4603) },
                    { -276149392, 388466296, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4436), 283626427, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4437) },
                    { -276149392, 396868147, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4501), 911438800, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4503) },
                    { -276149392, 400064352, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5015), 366928126, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5016) },
                    { -276149392, 428489928, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4904), 552199986, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4905) },
                    { -276149392, 443328642, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4991), 668630957, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4992) },
                    { -276149392, 443582350, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5028), 713015658, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5029) },
                    { -276149392, 446760304, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4385), 186289148, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4386) },
                    { -276149392, 455391094, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4590), 358486283, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4591) },
                    { -276149392, 476067803, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4765), 337745295, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4766) },
                    { -276149392, 479914673, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4652), 329344940, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4653) },
                    { -276149392, 492025955, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4627), 952662299, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4628) },
                    { -276149392, 505832410, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4941), 231070998, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4942) },
                    { -276149392, 507958028, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4789), 593567981, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4790) },
                    { -276149392, 526866350, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4689), 803282494, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4690) },
                    { -276149392, 533846155, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4978), 381484996, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4979) },
                    { -276149392, 586074219, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4701), 644486836, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4702) },
                    { -276149392, 594071040, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4839), 656989432, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4840) },
                    { -276149392, 598864529, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4487), 907708634, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4488) },
                    { -276149392, 602143732, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4714), 407342183, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4715) },
                    { -276149392, 638306402, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4615), 178164379, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4616) },
                    { -276149392, 654992419, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4462), 376851751, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4463) },
                    { -276149392, 686046141, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4866), 619193866, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4868) },
                    { -276149392, 686680185, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4347), 714627217, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4349) },
                    { -276149392, 687877249, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4527), 131475768, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4528) },
                    { -276149392, 704537716, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4398), 134233245, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4400) },
                    { -276149392, 709536759, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4738), 407994732, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4739) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -276149392, 721060258, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4966), 645332996, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4967) },
                    { -276149392, 752328010, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4475), 926081986, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4476) },
                    { -276149392, 779867430, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4565), 168825774, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4566) },
                    { -276149392, 797106143, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5064), 317921039, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5066) },
                    { -276149392, 808919924, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4373), 557755373, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4374) },
                    { -276149392, 811972507, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4676), 605256384, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4678) },
                    { -276149392, 820819468, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5040), 877638387, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5041) },
                    { -276149392, 826278067, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4802), 591086711, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4803) },
                    { -276149392, 895490394, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4826), 955665020, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4828) },
                    { -276149392, 907227278, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4640), 205365138, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4641) },
                    { -276149392, 937005375, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4424), 495687652, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4425) },
                    { -276149392, 957701068, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4752), 539113839, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4753) },
                    { -276149392, 960518974, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4929), 502173494, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4930) },
                    { -276149392, 960675509, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4450), 901292106, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4451) },
                    { -276149392, 962528666, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4878), 826803545, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4880) },
                    { -276149392, 972924128, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4514), 921433463, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4515) },
                    { -276149392, 980034778, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4814), 364761948, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4815) },
                    { -276149392, 998935214, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5077), 774049259, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5078) },
                    { 665408976, 156358161, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5774), 992722162, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5775) },
                    { 665408976, 156513222, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5712), 534210783, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5713) },
                    { 665408976, 158330781, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5400), 391016415, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5401) },
                    { 665408976, 165137552, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5749), 216785790, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5750) },
                    { 665408976, 197431915, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5276), 191824559, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5277) },
                    { 665408976, 228848516, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5638), 669387344, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5639) },
                    { 665408976, 283997552, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5860), 663514045, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5861) },
                    { 665408976, 291088854, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5811), 353152772, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5812) },
                    { 665408976, 317265020, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5412), 442604844, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5413) },
                    { 665408976, 322486255, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5437), 785255452, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5438) },
                    { 665408976, 327069138, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5196), 344623742, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5197) },
                    { 665408976, 329050874, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5524), 817217155, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5525) },
                    { 665408976, 337777607, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5588), 661336517, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5590) },
                    { 665408976, 340185562, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5225), 376473269, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5226) },
                    { 665408976, 349718015, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5909), 591779108, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5910) },
                    { 665408976, 383382870, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5461), 870364272, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5463) },
                    { 665408976, 388466296, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5301), 590977049, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5302) },
                    { 665408976, 396868147, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5363), 458550223, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5364) },
                    { 665408976, 400064352, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5872), 660399786, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5874) },
                    { 665408976, 428489928, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5761), 727559309, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5762) },
                    { 665408976, 443328642, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5848), 632890842, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5849) },
                    { 665408976, 443582350, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5885), 545376885, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5886) },
                    { 665408976, 446760304, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5250), 543761367, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5251) },
                    { 665408976, 455391094, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5449), 848513690, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5450) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 665408976, 476067803, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5625), 333303174, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5626) },
                    { 665408976, 479914673, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5511), 938837630, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5513) },
                    { 665408976, 492025955, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5486), 486013868, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5488) },
                    { 665408976, 505832410, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5798), 180613312, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5799) },
                    { 665408976, 507958028, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5650), 835104523, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5651) },
                    { 665408976, 526866350, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5551), 956000337, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5552) },
                    { 665408976, 533846155, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5835), 235427619, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5837) },
                    { 665408976, 586074219, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5564), 851694110, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5565) },
                    { 665408976, 594071040, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5700), 302192337, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5701) },
                    { 665408976, 598864529, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5351), 167203326, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5352) },
                    { 665408976, 602143732, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5576), 465511847, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5577) },
                    { 665408976, 638306402, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5474), 443444376, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5475) },
                    { 665408976, 654992419, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5326), 752003483, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5327) },
                    { 665408976, 686046141, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5725), 283413373, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5726) },
                    { 665408976, 686680185, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5212), 846149742, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5213) },
                    { 665408976, 687877249, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5388), 552697015, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5389) },
                    { 665408976, 704537716, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5264), 194241555, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5265) },
                    { 665408976, 709536759, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5601), 311974895, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5602) },
                    { 665408976, 721060258, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5823), 693583360, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5824) },
                    { 665408976, 752328010, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5338), 664374295, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5340) },
                    { 665408976, 779867430, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5425), 212247919, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5426) },
                    { 665408976, 797106143, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5922), 384387839, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5923) },
                    { 665408976, 808919924, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5237), 902754853, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5238) },
                    { 665408976, 811972507, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5536), 945376072, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5537) },
                    { 665408976, 820819468, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5897), 774853818, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5898) },
                    { 665408976, 826278067, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5662), 324902686, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5664) },
                    { 665408976, 895490394, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5687), 738794558, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5688) },
                    { 665408976, 907227278, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5499), 913773640, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5500) },
                    { 665408976, 937005375, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5289), 123700719, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5290) },
                    { 665408976, 957701068, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5613), 410141700, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5614) },
                    { 665408976, 960518974, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5786), 276864145, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5787) },
                    { 665408976, 960675509, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5313), 563954193, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5314) },
                    { 665408976, 962528666, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5737), 979116533, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5738) },
                    { 665408976, 972924128, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5375), 244051664, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5377) },
                    { 665408976, 980034778, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5675), 959088489, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5676) },
                    { 665408976, 998935214, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5937), 642287523, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5938) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -276149392, -1529552751, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4287), 651359319, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4288) },
                    { -276149392, -1111487561, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4273), 923020313, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4274) },
                    { -276149392, -510769990, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4250), 239270307, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4251) },
                    { -276149392, -323786446, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4313), 423559547, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4314) },
                    { -276149392, 954573630, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4300), 772327520, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(4301) },
                    { 665408976, -1529552751, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5157), 595928924, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5158) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 665408976, -1111487561, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5145), 263807330, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5147) },
                    { 665408976, -510769990, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5133), 722401917, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5134) },
                    { 665408976, -323786446, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5184), 345681637, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5185) },
                    { 665408976, 954573630, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5170), 956016445, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5171) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -276149392, 236139071, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6159), 1438426437, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6160) },
                    { -276149392, 309027116, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6059), -1616751797, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6060) },
                    { -276149392, 347494197, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6134), -1489552302, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6135) },
                    { -276149392, 357189703, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5952), -1694313356, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5953) },
                    { -276149392, 702749905, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6085), -247459132, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6086) },
                    { -276149392, 713713862, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6185), 1658298816, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6186) },
                    { -276149392, 720105897, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5983), 1553265508, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5985) },
                    { -276149392, 819674949, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6008), 193220291, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6009) },
                    { -276149392, 826850044, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6110), 406055337, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6111) },
                    { -276149392, 986748286, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6035), 1994236552, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6036) },
                    { 665408976, 236139071, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6172), -1824419648, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6173) },
                    { 665408976, 309027116, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6072), 1020640870, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6074) },
                    { 665408976, 347494197, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6146), 662822397, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6148) },
                    { 665408976, 357189703, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5970), 734882486, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5971) },
                    { 665408976, 702749905, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6097), -320777048, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6098) },
                    { 665408976, 713713862, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6197), 210872976, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6198) },
                    { 665408976, 720105897, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5996), 1572823356, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(5997) },
                    { 665408976, 819674949, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6022), 1995170294, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6023) },
                    { 665408976, 826850044, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6122), 880511998, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6123) },
                    { 665408976, 986748286, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6047), 563081979, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(6048) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 275240908, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7272), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7274), 3010.0, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7273), "Signature 142346", 45940, 357189703, 1.0, 17.0 },
                    { 457916902, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2148), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2150), 100003000.0, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2149), "Signature 142348", 38976, 347494197, 8.0, 24.0 },
                    { 479234707, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8740), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8742), 4000.0, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8741), "Signature 1423412", 69369, 819674949, 3.0, 17.0 },
                    { 500583060, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2796), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2798), 1000003000.0, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2797), "Signature 142349", 23069, 236139071, 9.0, 17.0 },
                    { 501034675, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(117), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(120), 103000.0, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(118), "Signature 1423410", 56105, 309027116, 5.0, 17.0 },
                    { 787494867, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3436), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3438), 10000003000.0, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3437), "Signature 1423430", 17895, 713713862, 10.0, 24.0 },
                    { 808035720, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(851), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(853), 1003000.0, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(852), "Signature 142346", 40483, 702749905, 6.0, 24.0 },
                    { 809647196, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8053), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8056), 3100.0, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8055), "Signature 142348", 61930, 720105897, 2.0, 24.0 },
                    { 933091150, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1506), new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1508), 10003000.0, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1507), "Signature 1423442", 61767, 826850044, 7.0, 17.0 },
                    { 965308719, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9419), new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9422), 13000.0, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9421), "Signature 142348", 82971, 986748286, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 128026500, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7235), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7237), null, "6949277781", null, null, 357189703 },
                    { 143936351, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8020), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8022), null, "6949277782", null, null, 720105897 },
                    { 161708137, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2119), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2120), null, "6949277788", null, null, 347494197 },
                    { 298313707, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2767), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2768), null, "6949277789", null, null, 236139071 },
                    { 507399467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3406), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3407), null, "69492777810", null, null, 713713862 },
                    { 605325279, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1477), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1478), null, "6949277787", null, null, 826850044 },
                    { 694678790, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9389), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9390), null, "6949277784", null, null, 986748286 },
                    { 696045343, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8705), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8707), null, "6949277783", null, null, 819674949 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 921019071, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(87), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(88), null, "6949277785", null, null, 309027116 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 974584657, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(822), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(823), null, "6949277786", null, null, 702749905 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 211300077, 128026500, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7257), 559965278, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(7259) },
                    { 211300077, 143936351, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8040), 157050204, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8041) },
                    { 211300077, 161708137, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2135), 800261297, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2137) },
                    { 211300077, 298313707, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2784), 853803333, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(2785) },
                    { 211300077, 507399467, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3423), 985666199, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(3424) },
                    { 211300077, 605325279, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1493), 502306161, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(1494) },
                    { 211300077, 694678790, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9406), 744221095, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(9407) },
                    { 211300077, 696045343, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8723), 266389021, new DateTime(2024, 2, 26, 15, 2, 58, 273, DateTimeKind.Local).AddTicks(8725) },
                    { 211300077, 921019071, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(104), 675643030, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(105) },
                    { 211300077, 974584657, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(839), 201960940, new DateTime(2024, 2, 26, 15, 2, 58, 274, DateTimeKind.Local).AddTicks(840) }
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
                name: "IX_DisciplinesOthers_OtherId",
                table: "DisciplinesOthers",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesPojects_ProjectId",
                table: "DisciplinesPojects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawingsEmployees_EmployeeId",
                table: "DrawingsEmployees",
                column: "EmployeeId");

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
                name: "IX_OthersEmployees_EmployeeId",
                table: "OthersEmployees",
                column: "EmployeeId");

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
                name: "FK_DisciplinesPojects_Projects_ProjectId",
                table: "DisciplinesPojects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrawingsEmployees_Users_EmployeeId",
                table: "DrawingsEmployees",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OthersEmployees_Users_EmployeeId",
                table: "OthersEmployees",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "DisciplinesOthers");

            migrationBuilder.DropTable(
                name: "DisciplinesPojects");

            migrationBuilder.DropTable(
                name: "DrawingsEmployees");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ManHour");

            migrationBuilder.DropTable(
                name: "OthersEmployees");

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
