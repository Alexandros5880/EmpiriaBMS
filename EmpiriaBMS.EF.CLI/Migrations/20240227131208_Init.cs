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
                name: "ProjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.Id);
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
                name: "TimeSpans",
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
                    table.PrimaryKey("PK_TimeSpans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyHours",
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
                    table.PrimaryKey("PK_DailyHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyHours_TimeSpans_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "TimeSpans",
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
                    UserId = table.Column<int>(type: "int", nullable: true),
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
                name: "DisciplineEngineer",
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
                    table.PrimaryKey("PK_DisciplineEngineer", x => new { x.DisciplineId, x.EngineerId });
                    table.ForeignKey(
                        name: "FK_DisciplineEngineer_Disciplines_DisciplineId",
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
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProjectType",
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
                name: "ProjectsPmanagers",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsPmanagers", x => new { x.ProjectManagerId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectsPmanagers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsPmanagers_Users_ProjectManagerId",
                        column: x => x.ProjectManagerId,
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
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "Name", "UserId" },
                values: new object[,]
                {
                    { -2099526584, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8229), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8230), "Photovoltaics", null },
                    { -1891781280, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8124), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8126), "Elevators", null },
                    { -1757572280, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8138), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8140), "Natural Gas", null },
                    { -1687254832, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8111), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8112), "Fire Suppression", null },
                    { -1470018136, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8052), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8053), "Sewage", null },
                    { -1105065024, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8067), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8068), "Potable Water", null },
                    { -1083603296, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8152), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8154), "Power Distribution", null },
                    { -411893032, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8095), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8096), "Fire Detection", null },
                    { -182426896, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8242), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8243), "Energy Efficiency", null },
                    { 116260984, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8200), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8201), "CCTV", null },
                    { 489282240, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8035), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8037), "HVAC", null },
                    { 515546432, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8081), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8083), "Drainage", null },
                    { 635214184, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8215), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8216), "BMS", null },
                    { 1464270568, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8182), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8183), "Burglar Alarm", null },
                    { 2036802376, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8168), 0f, 1500L, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8169), "Structured Cabling", null }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 160564257, new DateTime(2024, 3, 9, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7531), 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7528), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7529), "Drawing 1" },
                    { 194138244, new DateTime(2024, 3, 9, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7553), 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7550), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7552), "Drawing 2" },
                    { 519341246, new DateTime(2024, 3, 9, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7584), 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7581), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7583), "Drawing 4" },
                    { 869130124, new DateTime(2024, 3, 9, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7569), 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7566), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7567), "Drawing 3" },
                    { 960860645, new DateTime(2024, 3, 9, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7619), 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7616), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7617), "Drawing 6" },
                    { 969285502, new DateTime(2024, 3, 9, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7600), 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7597), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7598), "Drawing 5" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -1832196877, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7507), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7509), "Administration" },
                    { -626070814, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7447), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7449), "Communications" },
                    { -432983153, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7479), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7480), "On-Site" },
                    { -317698503, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7465), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7466), "Printing" },
                    { 182826163, 0f, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7493), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7494), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 158690234, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7663), "Energy Description", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7664), "Energy" },
                    { 417340077, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7648), "Infrastructure Description", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7649), "Infrastructure" },
                    { 446040937, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7677), "Consulting Description", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7678), "Consulting" },
                    { 550372375, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7631), "Buildings Description", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7634), "Buildings" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 136590201, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6757), true, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6758), "CEO" },
                    { 280048679, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6764), false, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6766), "Guest" },
                    { 287618767, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6744), true, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6745), "COO" },
                    { 597048931, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6737), true, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6738), "Project Manager" },
                    { 599802411, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6721), true, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6722), "Designer" },
                    { 927365787, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6771), false, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6772), "Customer" },
                    { 972629800, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6729), true, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6731), "Engineer" },
                    { 980165525, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6751), true, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6752), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 256610015, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7073), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7074), null, "6949277785", null, null, null },
                    { 259495209, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6956), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6957), null, "6949277781", null, null, null },
                    { 270073649, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7303), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7305), null, "6949277781", null, null, null },
                    { 307906382, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6880), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6881), null, "6949277780", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 366189100, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7335), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7336), null, "6949277782", null, null, null },
                    { 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7275), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7276), null, "6949277785", null, null, null },
                    { 652786432, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7044), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7045), null, "6949277784", null, null, null },
                    { 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7244), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7245), null, "6949277784", null, null, null },
                    { 695121033, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7362), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7363), null, "6949277783", null, null, null },
                    { 748277348, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7017), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7018), null, "6949277783", null, null, null },
                    { 766849831, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7388), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7389), null, "6949277784", null, null, null },
                    { 853740876, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7415), "Test Description PM 5", "pm5@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7416), null, "6949277785", null, null, null },
                    { 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7114), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7115), null, "6949277780", null, null, null },
                    { 861815609, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6985), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6986), null, "6949277782", null, null, null },
                    { 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7146), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7148), null, "6949277781", null, null, null },
                    { 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7216), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7217), null, "6949277783", null, null, null },
                    { 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7175), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7176), null, "6949277782", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2099526584, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(219), 897155207, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(220) },
                    { -2099526584, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(206), 986512819, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(207) },
                    { -2099526584, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(156), 285798278, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(157) },
                    { -2099526584, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(168), 846437555, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(170) },
                    { -2099526584, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(194), 166249926, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(195) },
                    { -2099526584, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(181), 528218627, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(182) },
                    { -1891781280, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9678), 598849322, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9679) },
                    { -1891781280, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9665), 913337859, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9666) },
                    { -1891781280, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9615), 512581132, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9616) },
                    { -1891781280, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9628), 152357739, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9629) },
                    { -1891781280, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9653), 262991713, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9654) },
                    { -1891781280, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9640), 465777438, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9641) },
                    { -1757572280, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9758), 371429517, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9759) },
                    { -1757572280, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9745), 206411520, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9746) },
                    { -1757572280, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9690), 186352992, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9692) },
                    { -1757572280, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9703), 525835431, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9704) },
                    { -1757572280, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9728), 214497903, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9729) },
                    { -1757572280, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9716), 590389498, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9717) },
                    { -1687254832, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9602), 133458117, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9603) },
                    { -1687254832, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9590), 345107437, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9591) },
                    { -1687254832, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9538), 706632860, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9539) },
                    { -1687254832, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9550), 124750547, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9551) },
                    { -1687254832, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9577), 451568837, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9578) },
                    { -1687254832, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9563), 364194414, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9564) },
                    { -1470018136, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9293), 818693403, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9294) },
                    { -1470018136, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9280), 321951016, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9281) },
                    { -1470018136, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9228), 385654186, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9229) },
                    { -1470018136, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9241), 143334525, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9242) },
                    { -1470018136, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9267), 738339465, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9268) },
                    { -1470018136, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9254), 511015260, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9255) },
                    { -1105065024, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9373), 333502357, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9375) },
                    { -1105065024, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9355), 743995197, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9357) },
                    { -1105065024, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9305), 556850782, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9306) },
                    { -1105065024, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9318), 613009446, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9319) },
                    { -1105065024, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9343), 797888132, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9344) },
                    { -1105065024, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9330), 331183287, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9332) },
                    { -1083603296, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9834), 261418823, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9835) },
                    { -1083603296, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9821), 208695198, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9822) },
                    { -1083603296, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9771), 391697023, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9772) },
                    { -1083603296, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9783), 484776497, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9785) },
                    { -1083603296, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9809), 923495756, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9810) },
                    { -1083603296, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9796), 376099976, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9797) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -411893032, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9525), 770672157, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9526) },
                    { -411893032, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9513), 546629967, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9514) },
                    { -411893032, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9463), 865587079, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9464) },
                    { -411893032, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9475), 417821578, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9476) },
                    { -411893032, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9500), 546100453, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9501) },
                    { -411893032, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9488), 169352511, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9489) },
                    { -182426896, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(295), 423037757, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(296) },
                    { -182426896, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(282), 477296883, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(283) },
                    { -182426896, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(231), 701927237, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(232) },
                    { -182426896, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(244), 446094232, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(245) },
                    { -182426896, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(269), 285993944, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(271) },
                    { -182426896, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(257), 813151492, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(258) },
                    { 116260984, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(61), 559557071, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(62) },
                    { 116260984, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(48), 164998126, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(50) },
                    { 116260984, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9998), 507766641, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9999) },
                    { 116260984, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(11), 715938642, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(12) },
                    { 116260984, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(36), 508106198, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(37) },
                    { 116260984, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(23), 371926266, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(24) },
                    { 489282240, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9215), 846319111, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9217) },
                    { 489282240, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9202), 749363005, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9203) },
                    { 489282240, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9146), 958868334, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9147) },
                    { 489282240, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9164), 436065277, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9165) },
                    { 489282240, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9190), 728555833, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9191) },
                    { 489282240, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9177), 449597725, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9178) },
                    { 515546432, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9450), 417178035, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9451) },
                    { 515546432, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9437), 637511056, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9438) },
                    { 515546432, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9387), 605792067, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9388) },
                    { 515546432, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9399), 368000685, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9400) },
                    { 515546432, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9425), 564068771, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9426) },
                    { 515546432, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9412), 502741934, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9413) },
                    { 635214184, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(143), 246315905, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(144) },
                    { 635214184, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(131), 914764372, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(132) },
                    { 635214184, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(73), 917005750, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(74) },
                    { 635214184, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(92), 423114991, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(93) },
                    { 635214184, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(118), 862292136, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(119) },
                    { 635214184, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(105), 272338292, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(106) },
                    { 1464270568, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9985), 327023471, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9987) },
                    { 1464270568, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9972), 854718098, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9973) },
                    { 1464270568, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9922), 837822898, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9923) },
                    { 1464270568, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9934), 377650706, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9936) },
                    { 1464270568, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9960), 332330344, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9961) },
                    { 1464270568, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9947), 563064791, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9948) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 2036802376, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9909), 470581224, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9910) },
                    { 2036802376, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9897), 328202472, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9898) },
                    { 2036802376, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9847), 231879900, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9848) },
                    { 2036802376, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9859), 840767066, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9860) },
                    { 2036802376, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9884), 796992836, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9885) },
                    { 2036802376, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9872), 455077296, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9873) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2099526584, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2258), 805519889, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2259) },
                    { -2099526584, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2271), 316505334, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2272) },
                    { -2099526584, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2296), 450217460, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2297) },
                    { -2099526584, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2283), 387650570, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2285) },
                    { -2099526584, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2322), 297744448, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2323) },
                    { -2099526584, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2309), 584792776, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2310) },
                    { -1891781280, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1715), 775269543, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1716) },
                    { -1891781280, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1728), 208330821, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1729) },
                    { -1891781280, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1753), 241339582, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1754) },
                    { -1891781280, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1741), 416909551, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1742) },
                    { -1891781280, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1779), 731252246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1780) },
                    { -1891781280, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1766), 476031481, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1767) },
                    { -1757572280, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1792), 615331359, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1793) },
                    { -1757572280, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1804), 675895013, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1805) },
                    { -1757572280, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1830), 325472432, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1831) },
                    { -1757572280, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1817), 847997179, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1818) },
                    { -1757572280, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1855), 417503852, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1856) },
                    { -1757572280, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1842), 498093801, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1843) },
                    { -1687254832, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1637), 557898867, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1639) },
                    { -1687254832, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1650), 540071187, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1651) },
                    { -1687254832, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1677), 340576965, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1678) },
                    { -1687254832, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1663), 781971747, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1664) },
                    { -1687254832, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1702), 288615583, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1704) },
                    { -1687254832, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1690), 334920461, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1691) },
                    { -1470018136, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1327), 244591166, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1328) },
                    { -1470018136, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1340), 355996594, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1341) },
                    { -1470018136, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1366), 610143491, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1367) },
                    { -1470018136, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1353), 492353413, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1354) },
                    { -1470018136, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1392), 710988334, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1393) },
                    { -1470018136, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1379), 583190594, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1380) },
                    { -1105065024, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1405), 560182907, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1406) },
                    { -1105065024, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1417), 212656884, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1418) },
                    { -1105065024, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1443), 219062116, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1444) },
                    { -1105065024, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1430), 435398802, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1431) },
                    { -1105065024, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1469), 166173811, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1470) },
                    { -1105065024, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1455), 615532003, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1456) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1083603296, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1868), 438062083, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1869) },
                    { -1083603296, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1880), 948310648, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1882) },
                    { -1083603296, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1910), 688497184, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1911) },
                    { -1083603296, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1896), 432250626, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1898) },
                    { -1083603296, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1935), 472619129, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1936) },
                    { -1083603296, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1922), 415016837, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1923) },
                    { -411893032, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1561), 374140736, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1562) },
                    { -411893032, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1573), 581671593, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1575) },
                    { -411893032, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1599), 907355611, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1600) },
                    { -411893032, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1587), 971880556, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1588) },
                    { -411893032, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1625), 619603666, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1626) },
                    { -411893032, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1612), 149400073, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1613) },
                    { -182426896, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2335), 347986849, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2336) },
                    { -182426896, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2348), 155171873, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2349) },
                    { -182426896, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2373), 588134035, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2374) },
                    { -182426896, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2360), 232587726, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2362) },
                    { -182426896, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2399), 648313608, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2400) },
                    { -182426896, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2386), 962266635, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2387) },
                    { 116260984, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2102), 831607954, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2103) },
                    { 116260984, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2115), 608661257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2116) },
                    { 116260984, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2140), 719745788, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2141) },
                    { 116260984, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2127), 709656630, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2128) },
                    { 116260984, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2165), 741315267, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2166) },
                    { 116260984, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2153), 861041185, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2154) },
                    { 489282240, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1241), 197976578, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1242) },
                    { 489282240, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1261), 564875536, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1262) },
                    { 489282240, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1287), 964576092, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1288) },
                    { 489282240, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1274), 205570493, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1275) },
                    { 489282240, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1314), 345032186, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1315) },
                    { 489282240, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1300), 201633938, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1301) },
                    { 515546432, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1482), 690993234, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1483) },
                    { 515546432, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1495), 302396506, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1496) },
                    { 515546432, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1522), 342352982, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1523) },
                    { 515546432, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1507), 253634971, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1508) },
                    { 515546432, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1548), 555798393, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1549) },
                    { 515546432, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1535), 355501791, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1536) },
                    { 635214184, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2178), 956009376, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2179) },
                    { 635214184, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2191), 224364879, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2192) },
                    { 635214184, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2216), 388990175, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2218) },
                    { 635214184, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2204), 700200994, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2205) },
                    { 635214184, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2245), 914344181, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2246) },
                    { 635214184, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2229), 488640308, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2230) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1464270568, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2024), 210919701, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2025) },
                    { 1464270568, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2037), 337433896, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2038) },
                    { 1464270568, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2062), 183932840, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2064) },
                    { 1464270568, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2050), 349421503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2051) },
                    { 1464270568, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2089), 387056793, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2090) },
                    { 1464270568, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2075), 861438717, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2076) },
                    { 2036802376, 160564257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1948), 572851815, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1949) },
                    { 2036802376, 194138244, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1961), 151887014, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1962) },
                    { 2036802376, 519341246, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1986), 388322398, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1987) },
                    { 2036802376, 869130124, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1973), 150324660, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1974) },
                    { 2036802376, 960860645, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2011), 600821427, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2013) },
                    { 2036802376, 969285502, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1999), 965251833, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2000) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2099526584, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1165), 388781790, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1166) },
                    { -2099526584, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1113), 756045720, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1114) },
                    { -2099526584, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1140), 265825478, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1141) },
                    { -2099526584, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1125), 441100135, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1126) },
                    { -2099526584, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1153), 143571371, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1154) },
                    { -1891781280, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(735), 572362685, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(737) },
                    { -1891781280, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(686), 954174590, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(688) },
                    { -1891781280, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(710), 869560343, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(711) },
                    { -1891781280, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(698), 778254236, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(699) },
                    { -1891781280, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(724), 682024656, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(725) },
                    { -1757572280, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(796), 415645727, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(797) },
                    { -1757572280, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(748), 175002959, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(749) },
                    { -1757572280, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(772), 982151718, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(773) },
                    { -1757572280, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(760), 292497065, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(761) },
                    { -1757572280, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(784), 753407133, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(785) },
                    { -1687254832, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(674), 396811671, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(675) },
                    { -1687254832, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(627), 862344549, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(628) },
                    { -1687254832, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(651), 662021986, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(652) },
                    { -1687254832, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(639), 998196899, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(640) },
                    { -1687254832, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(663), 375254910, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(664) },
                    { -1470018136, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(430), 141882093, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(431) },
                    { -1470018136, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(381), 304190708, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(382) },
                    { -1470018136, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(405), 276102625, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(406) },
                    { -1470018136, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(393), 800471403, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(394) },
                    { -1470018136, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(417), 658978396, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(419) },
                    { -1105065024, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(493), 898385308, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(494) },
                    { -1105065024, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(443), 151608800, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(444) },
                    { -1105065024, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(467), 123631258, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(468) },
                    { -1105065024, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(455), 400087955, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(456) },
                    { -1105065024, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(481), 338877569, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(482) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1083603296, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(859), 738138834, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(860) },
                    { -1083603296, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(811), 335735448, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(812) },
                    { -1083603296, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(835), 907741677, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(837) },
                    { -1083603296, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(823), 647429383, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(824) },
                    { -1083603296, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(847), 260508495, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(848) },
                    { -411893032, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(615), 484678033, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(616) },
                    { -411893032, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(567), 409192866, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(568) },
                    { -411893032, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(590), 819659344, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(591) },
                    { -411893032, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(578), 710085072, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(579) },
                    { -411893032, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(602), 175247437, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(604) },
                    { -182426896, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1225), 631322289, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1226) },
                    { -182426896, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1177), 643273801, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1178) },
                    { -182426896, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1201), 207915095, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1202) },
                    { -182426896, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1189), 239651541, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1190) },
                    { -182426896, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1213), 889643491, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1214) },
                    { 116260984, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1039), 147464928, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1040) },
                    { 116260984, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(991), 317584678, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(992) },
                    { 116260984, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1015), 596036540, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1016) },
                    { 116260984, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1003), 203781027, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1004) },
                    { 116260984, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1027), 572905147, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1028) },
                    { 489282240, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(368), 593017702, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(369) },
                    { 489282240, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(310), 521238879, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(311) },
                    { 489282240, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(344), 307631895, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(345) },
                    { 489282240, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(331), 732131171, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(332) },
                    { 489282240, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(356), 157785363, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(357) },
                    { 515546432, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(554), 296886711, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(555) },
                    { 515546432, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(506), 513978271, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(507) },
                    { 515546432, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(530), 634913257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(531) },
                    { 515546432, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(517), 460836961, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(518) },
                    { 515546432, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(542), 236408753, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(543) },
                    { 635214184, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1099), 642837577, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1100) },
                    { 635214184, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1051), 129973094, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1052) },
                    { 635214184, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1075), 507557397, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1077) },
                    { 635214184, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1063), 438722644, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1064) },
                    { 635214184, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1087), 723521669, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(1088) },
                    { 1464270568, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(979), 358137899, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(980) },
                    { 1464270568, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(931), 497797407, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(932) },
                    { 1464270568, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(955), 149185485, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(956) },
                    { 1464270568, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(943), 680103876, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(944) },
                    { 1464270568, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(967), 863594067, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(968) },
                    { 2036802376, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(919), 999761010, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(920) },
                    { 2036802376, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(872), 543372056, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(873) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 2036802376, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(895), 686145242, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(896) },
                    { 2036802376, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(883), 590564674, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(884) },
                    { 2036802376, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(907), 690146285, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(908) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 160564257, 256610015, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3191), -1174731920, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3192) },
                    { 160564257, 259495209, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2880), 1154717996, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2882) },
                    { 160564257, 307906382, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2798), 1282723142, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2799) },
                    { 160564257, 652786432, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3116), 1307481107, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3117) },
                    { 160564257, 748277348, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3040), -438776207, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3041) },
                    { 160564257, 861815609, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2959), -1234454323, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2960) },
                    { 194138244, 256610015, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3204), -1238101573, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3205) },
                    { 194138244, 259495209, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2894), -1661183023, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2895) },
                    { 194138244, 307906382, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2815), -558030829, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2816) },
                    { 194138244, 652786432, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3128), -865539499, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3129) },
                    { 194138244, 748277348, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3052), -440900081, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3053) },
                    { 194138244, 861815609, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2971), -206876321, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2972) },
                    { 519341246, 256610015, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3230), -1035013193, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3231) },
                    { 519341246, 259495209, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2920), -77761700, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2921) },
                    { 519341246, 307906382, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2840), -1542620155, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2841) },
                    { 519341246, 652786432, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3153), -65474216, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3154) },
                    { 519341246, 748277348, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3078), 736887353, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3079) },
                    { 519341246, 861815609, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3000), 1654366257, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3001) },
                    { 869130124, 256610015, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3216), -2137803421, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3218) },
                    { 869130124, 259495209, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2906), -1104830927, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2907) },
                    { 869130124, 307906382, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2828), 280257107, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2829) },
                    { 869130124, 652786432, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3141), -1723705253, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3142) },
                    { 869130124, 748277348, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3065), -399032581, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3066) },
                    { 869130124, 861815609, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2984), 85574341, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2985) },
                    { 960860645, 256610015, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3255), 1004981846, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3256) },
                    { 960860645, 259495209, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2945), -762206179, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2946) },
                    { 960860645, 307906382, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2867), 1473385892, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2868) },
                    { 960860645, 652786432, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3178), -1268132309, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3180) },
                    { 960860645, 748277348, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3103), 627816263, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3104) },
                    { 960860645, 861815609, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3027), -526256387, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3028) },
                    { 969285502, 256610015, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3243), -1826053190, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3244) },
                    { 969285502, 259495209, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2933), -1389901958, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2934) },
                    { 969285502, 307906382, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2853), 1465232085, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2854) },
                    { 969285502, 652786432, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3166), -2058961603, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3167) },
                    { 969285502, 748277348, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3090), -1418144786, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3091) },
                    { 969285502, 861815609, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3013), 126098978, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(3014) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 256610015, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2784), 1648271223, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2785) },
                    { 259495209, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2535), -1465725338, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2537) },
                    { 307906382, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2471), 1153203161, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2473) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 652786432, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2723), -42022048, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2724) },
                    { 748277348, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2662), 1095804068, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2663) },
                    { 861815609, -1832196877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2597), 1570524687, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2598) },
                    { 256610015, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2735), -510690253, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2737) },
                    { 259495209, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2485), 1458186138, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2486) },
                    { 307906382, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2413), 145680877, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2414) },
                    { 652786432, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2674), -1154660066, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2675) },
                    { 748277348, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2609), -1549432286, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2610) },
                    { 861815609, -626070814, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2548), -867068495, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2549) },
                    { 256610015, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2760), 2026509588, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2761) },
                    { 259495209, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2510), -1275046703, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2511) },
                    { 307906382, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2447), 502194947, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2448) },
                    { 652786432, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2699), 404750206, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2700) },
                    { 748277348, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2637), 1966860302, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2638) },
                    { 861815609, -432983153, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2572), 1738910786, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2573) },
                    { 256610015, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2748), -1063131304, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2749) },
                    { 259495209, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2498), -1506828298, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2499) },
                    { 307906382, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2434), -1282225985, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2435) },
                    { 652786432, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2686), 1948611839, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2687) },
                    { 748277348, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2621), -689516324, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2623) },
                    { 861815609, -317698503, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2560), -609371018, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2561) },
                    { 256610015, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2772), -844405973, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2773) },
                    { 259495209, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2522), -26629559, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2523) },
                    { 307906382, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2459), -1955775248, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2460) },
                    { 652786432, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2711), 1132372778, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2712) },
                    { 748277348, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2650), 1564205180, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2651) },
                    { 861815609, 182826163, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2585), 349272302, new DateTime(2024, 2, 27, 15, 12, 7, 878, DateTimeKind.Local).AddTicks(2586) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 209734422, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 7.0, 4, new DateTime(2024, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), new DateTime(2024, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 0f, 100L, 12L, new DateTime(2024, 2, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), "Project_2", 5.0, new DateTime(2024, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), "Payment Detailes For Project_10", 2.0, null, 417340077, new DateTime(2024, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 0f },
                    { 271596704, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 8.0, 9, new DateTime(2024, 11, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 9, "Test Description Project_6", "KL-3", new DateTime(2024, 11, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), new DateTime(2024, 11, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 0f, 100L, 12L, new DateTime(2024, 2, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), "Project_3", 5.0, new DateTime(2024, 11, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), "Payment Detailes For Project_3", 3.0, null, 158690234, new DateTime(2024, 11, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 0f },
                    { 751724648, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 9.0, 16, new DateTime(2025, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 16, "Test Description Project_8", "KL-4", new DateTime(2025, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), new DateTime(2025, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 0f, 100L, 12L, new DateTime(2024, 2, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), "Project_4", 5.0, new DateTime(2025, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), "Payment Detailes For Project_16", 4.0, null, 446040937, new DateTime(2025, 6, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 0f },
                    { 913113619, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 6.0, 1, new DateTime(2024, 3, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 1, "Test Description Project_3", "KL-1", new DateTime(2024, 3, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), new DateTime(2024, 3, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 0f, 100L, 12L, new DateTime(2024, 2, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), "Project_1", 5.0, new DateTime(2024, 3, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), "Payment Detailes For Project_5", 1.0, null, 550372375, new DateTime(2024, 3, 27, 15, 12, 7, 872, DateTimeKind.Local).AddTicks(9254), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 599802411, 256610015, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7099), 380699098, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7100) },
                    { 599802411, 259495209, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6972), 641955306, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6973) },
                    { 597048931, 270073649, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7321), 397694451, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7322) },
                    { 599802411, 307906382, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6936), 160619349, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(6937) },
                    { 597048931, 366189100, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7350), 788907733, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7351) },
                    { 972629800, 651876630, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7289), 890639806, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7290) },
                    { 599802411, 652786432, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7059), 732031555, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7060) },
                    { 972629800, 654393747, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7262), 367073120, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7263) },
                    { 597048931, 695121033, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7376), 277437300, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7377) },
                    { 599802411, 748277348, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7031), 202599606, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7032) },
                    { 597048931, 766849831, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7402), 786934327, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7404) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 597048931, 853740876, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7431), 905704332, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7432) },
                    { 972629800, 859113082, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7132), 129554005, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7134) },
                    { 599802411, 861815609, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7000), 894701386, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7001) },
                    { 972629800, 896224231, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7162), 212587764, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7163) },
                    { 972629800, 945019835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7231), 849707112, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7233) },
                    { 972629800, 955195122, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7203), 990202775, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7204) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2099526584, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9057), -1564638172, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9058) },
                    { -2099526584, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9070), -1757800714, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9071) },
                    { -2099526584, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9082), -888905714, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9083) },
                    { -2099526584, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9045), -552893385, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9046) },
                    { -1891781280, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8639), 1692069536, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8640) },
                    { -1891781280, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8651), 143764676, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8652) },
                    { -1891781280, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8664), -317655253, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8665) },
                    { -1891781280, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8627), 381063848, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8628) },
                    { -1757572280, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8689), 1072756655, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8690) },
                    { -1757572280, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8701), 1473814824, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8702) },
                    { -1757572280, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8714), 179425109, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8715) },
                    { -1757572280, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8676), -1606754024, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8677) },
                    { -1687254832, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8589), 735275566, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8590) },
                    { -1687254832, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8602), -1636440078, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8603) },
                    { -1687254832, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8614), 2097726074, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8615) },
                    { -1687254832, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8577), 1409591388, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8578) },
                    { -1470018136, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8384), 1513411956, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8385) },
                    { -1470018136, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8397), -1311301330, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8398) },
                    { -1470018136, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8410), -1398863772, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8411) },
                    { -1470018136, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8371), -1371723650, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8372) },
                    { -1105065024, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8435), 289929907, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8436) },
                    { -1105065024, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8448), 1594317904, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8449) },
                    { -1105065024, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8460), -1759840427, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8462) },
                    { -1105065024, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8422), -970926911, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8423) },
                    { -1083603296, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8740), 1617055116, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8741) },
                    { -1083603296, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8752), -383366960, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8753) },
                    { -1083603296, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8764), -1986991742, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8766) },
                    { -1083603296, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8726), 1931877835, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8727) },
                    { -411893032, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8536), 376678688, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8537) },
                    { -411893032, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8548), 1488573825, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8549) },
                    { -411893032, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8563), 422275080, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8564) },
                    { -411893032, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8522), 670507882, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8523) },
                    { -182426896, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9107), 1944923614, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9108) },
                    { -182426896, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9120), -649272847, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9121) },
                    { -182426896, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9132), -912670656, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9133) },
                    { -182426896, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9095), 1041188350, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9096) },
                    { 116260984, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8889), -1174571927, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8890) },
                    { 116260984, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8902), 284115073, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8903) },
                    { 116260984, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8914), -414766636, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8915) },
                    { 116260984, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8877), 356627866, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8878) },
                    { 489282240, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8332), 1416647920, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8334) },
                    { 489282240, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8346), -880610727, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8347) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 489282240, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8358), 462339529, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8359) },
                    { 489282240, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8314), 1053296855, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8315) },
                    { 515546432, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8485), -607882258, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8486) },
                    { 515546432, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8498), 1402151830, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8499) },
                    { 515546432, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8510), -1148202578, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8511) },
                    { 515546432, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8473), 959640904, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8474) },
                    { 635214184, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9006), 1197533633, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9007) },
                    { 635214184, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9019), -418446957, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9020) },
                    { 635214184, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9032), -670020016, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(9033) },
                    { 635214184, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8930), -991337628, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8992) },
                    { 1464270568, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8839), 787974320, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8840) },
                    { 1464270568, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8851), 2012187900, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8853) },
                    { 1464270568, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8864), -639799424, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8865) },
                    { 1464270568, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8827), -1876321720, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8828) },
                    { 2036802376, 209734422, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8789), -1627694672, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8790) },
                    { 2036802376, 271596704, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8802), 1733485051, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8803) },
                    { 2036802376, 751724648, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8814), -413149204, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8815) },
                    { 2036802376, 913113619, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8777), 1397719636, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8778) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 352543845, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7917), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7920), 4000.0, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7919), "Signature 1423412", 14091, 271596704, 3.0, 17.0 },
                    { 414127578, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7777), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7779), 3010.0, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7778), "Signature 142344", 77854, 913113619, 1.0, 17.0 },
                    { 959495175, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7980), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7982), 13000.0, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7981), "Signature 142344", 10849, 751724648, 4.0, 24.0 },
                    { 993043112, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7850), new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7852), 3100.0, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7851), "Signature 142344", 74365, 209734422, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 913113619, 270073649, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8256), 163043834, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8258) },
                    { 209734422, 366189100, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8274), 359443987, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8275) },
                    { 271596704, 695121033, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8287), 765351582, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8288) },
                    { 751724648, 766849831, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8299), 430045202, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(8301) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 180047491, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7952), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7953), null, "6949277784", null, null, 751724648 },
                    { 311600246, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7822), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7823), null, "6949277782", null, null, 209734422 },
                    { 843416792, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7743), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7744), null, "6949277781", null, null, 913113619 },
                    { 951275691, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7889), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7890), null, "6949277783", null, null, 271596704 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 927365787, 180047491, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7967), 805101708, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7968) },
                    { 927365787, 311600246, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7838), 914837978, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7839) },
                    { 927365787, 843416792, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7762), 340020712, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7764) },
                    { 927365787, 951275691, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7905), 515211102, new DateTime(2024, 2, 27, 15, 12, 7, 877, DateTimeKind.Local).AddTicks(7906) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyHours_TimeSpanId",
                table: "DailyHours",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHours_UserId",
                table: "DailyHours",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineEngineer_EngineerId",
                table: "DisciplineEngineer",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_UserId",
                table: "Disciplines",
                column: "UserId");

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
                name: "IX_Projects_SubContractorId",
                table: "Projects",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TypeId",
                table: "Projects",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsPmanagers_ProjectId",
                table: "ProjectsPmanagers",
                column: "ProjectId");

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
                name: "FK_DailyHours_Users_UserId",
                table: "DailyHours",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Users_UserId",
                table: "Disciplines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineEngineer_Users_EngineerId",
                table: "DisciplineEngineer",
                column: "EngineerId",
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
                name: "FK_Projects_Users_SubContractorId",
                table: "Projects",
                column: "SubContractorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_SubContractorId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "DailyHours");

            migrationBuilder.DropTable(
                name: "DisciplineEngineer");

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
                name: "ProjectsPmanagers");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "TimeSpans");

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

            migrationBuilder.DropTable(
                name: "ProjectType");
        }
    }
}
