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
                    { -1532736872, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8419), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8420), "Photovoltaics", null },
                    { -1484073856, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8218), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8220), "HVAC", null },
                    { -1476634856, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8312), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8314), "Elevators", null },
                    { -1440671592, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8236), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8238), "Sewage", null },
                    { -1287980928, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8390), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8391), "CCTV", null },
                    { -1040150112, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8360), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8362), "Structured Cabling", null },
                    { -901724600, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8298), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8299), "Fire Suppression", null },
                    { -797215376, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8341), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8342), "Power Distribution", null },
                    { -708464664, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8266), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8268), "Drainage", null },
                    { -680766992, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8461), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8463), "TenderDocument", null },
                    { -214055944, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8281), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8283), "Fire Detection", null },
                    { 198861184, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8327), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8328), "Natural Gas", null },
                    { 307442120, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8376), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8377), "Burglar Alarm", null },
                    { 1043046032, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8404), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8406), "BMS", null },
                    { 1050839848, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8251), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8253), "Potable Water", null },
                    { 1501087304, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8478), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8479), "Construction Supervision", null },
                    { 1858583952, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8433), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8434), "Energy Efficiency", null },
                    { 1886077304, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8447), 0f, 1500L, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8448), "Outsource", null }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 131570834, new DateTime(2024, 3, 10, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7861), 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7857), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7859), "Documents" },
                    { 413963833, new DateTime(2024, 3, 10, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7899), 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7896), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7898), "Drawings" },
                    { 776810707, new DateTime(2024, 3, 10, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7883), 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7880), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7881), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -2017624083, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7810), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7811), "On-Site" },
                    { -1778730685, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7776), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7778), "Communications" },
                    { 399113761, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7795), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7796), "Printing" },
                    { 1382424739, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7840), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7841), "Administration" },
                    { 1951200793, 0f, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7825), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7826), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 579497657, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7573), "Buildings Description", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7574), "Buildings" },
                    { 903198473, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7622), "Consulting Description", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7623), "Consulting" },
                    { 959436390, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7592), "Infrastructure Description", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7593), "Infrastructure" },
                    { 989940738, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7606), "Energy Description", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7608), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 214909563, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6909), true, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6911), "Engineer" },
                    { 220975520, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6925), true, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6926), "COO" },
                    { 230217510, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6901), true, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6902), "Designer" },
                    { 360836743, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6917), true, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6918), "Project Manager" },
                    { 456628691, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6940), true, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6941), "CEO" },
                    { 715369092, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6932), true, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6933), "CTO" },
                    { 715804385, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6954), false, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6956), "Customer" },
                    { 753632669, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6947), false, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(6948), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 150397571, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7743), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7744), null, "6949277784", null, null, null },
                    { 177605257, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7277), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7278), null, "6949277782", null, null, null },
                    { 202755381, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7183), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7184), null, "6949277780", null, null, null },
                    { 279669735, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7052), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7053), null, "694927778", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7544), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7545), null, "6949277785", null, null, null },
                    { 380346855, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7365), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7367), null, "6949277785", null, null, null },
                    { 411349005, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7123), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7124), null, "694927778", null, null, null },
                    { 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7488), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7489), null, "6949277783", null, null, null },
                    { 430705524, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7643), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7645), null, "6949277781", null, null, null },
                    { 461936334, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7248), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7249), null, "6949277781", null, null, null },
                    { 476763101, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7092), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7093), null, "694927778", null, null, null },
                    { 485414260, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7152), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7154), null, "694927778", null, null, null },
                    { 543096406, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7711), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7712), null, "6949277783", null, null, null },
                    { 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7429), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7430), null, "6949277781", null, null, null },
                    { 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7515), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7517), null, "6949277784", null, null, null },
                    { 752718727, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7305), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7307), null, "6949277783", null, null, null },
                    { 888205376, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7681), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7682), null, "6949277782", null, null, null },
                    { 896408823, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7334), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7335), null, "6949277784", null, null, null },
                    { 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7456), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7458), null, "6949277782", null, null, null },
                    { 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7395), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7397), null, "6949277780", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1532736872, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(656), 869779432, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(657) },
                    { -1532736872, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(629), 685353574, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(630) },
                    { -1532736872, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(599), 795954476, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(601) },
                    { -1532736872, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(643), 952100280, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(644) },
                    { -1532736872, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(613), 746955380, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(614) },
                    { -1532736872, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(586), 331939610, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(587) },
                    { -1484073856, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9589), 503325395, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9591) },
                    { -1484073856, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9561), 528692929, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9562) },
                    { -1484073856, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9532), 420380258, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9534) },
                    { -1484073856, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9574), 515134802, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9576) },
                    { -1484073856, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9547), 821960447, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9549) },
                    { -1484073856, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9515), 304159123, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9517) },
                    { -1476634856, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(83), 981862550, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(85) },
                    { -1476634856, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(56), 362543268, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(58) },
                    { -1476634856, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(29), 837342971, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(31) },
                    { -1476634856, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(70), 393652142, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(71) },
                    { -1476634856, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(43), 983616213, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(44) },
                    { -1476634856, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(16), 369015966, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(17) },
                    { -1440671592, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9673), 206808457, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9674) },
                    { -1440671592, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9646), 520657446, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9647) },
                    { -1440671592, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9617), 283827573, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9619) },
                    { -1440671592, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9659), 715328875, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9660) },
                    { -1440671592, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9631), 403095826, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9632) },
                    { -1440671592, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9603), 696003123, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9605) },
                    { -1287980928, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(492), 804553929, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(493) },
                    { -1287980928, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(465), 729469961, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(466) },
                    { -1287980928, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(438), 243368568, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(439) },
                    { -1287980928, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(478), 756790556, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(480) },
                    { -1287980928, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(451), 523213574, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(453) },
                    { -1287980928, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(424), 210082979, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(426) },
                    { -1040150112, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(328), 910737030, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(330) },
                    { -1040150112, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(301), 814161445, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(303) },
                    { -1040150112, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(274), 207887593, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(276) },
                    { -1040150112, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(315), 561090212, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(316) },
                    { -1040150112, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(288), 532230588, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(289) },
                    { -1040150112, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(261), 465539936, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(262) },
                    { -901724600, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2), 489354429, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(4) },
                    { -901724600, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9975), 647265205, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9976) },
                    { -901724600, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9947), 351107368, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9948) },
                    { -901724600, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9989), 397538470, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9990) },
                    { -901724600, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9960), 852682070, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9962) },
                    { -901724600, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9933), 156601581, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9935) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -797215376, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(244), 935877876, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(246) },
                    { -797215376, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(218), 587738488, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(219) },
                    { -797215376, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(191), 124926340, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(192) },
                    { -797215376, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(231), 563747130, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(233) },
                    { -797215376, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(204), 146842253, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(206) },
                    { -797215376, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(178), 327852537, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(179) },
                    { -708464664, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9836), 836478445, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9837) },
                    { -708464664, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9809), 287846996, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9810) },
                    { -708464664, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9782), 982177330, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9783) },
                    { -708464664, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9822), 709923907, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9823) },
                    { -708464664, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9795), 778817151, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9797) },
                    { -708464664, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9768), 154524831, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9770) },
                    { -680766992, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(898), 340287043, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(899) },
                    { -680766992, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(871), 640625493, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(872) },
                    { -680766992, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(844), 689320655, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(845) },
                    { -680766992, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(885), 624736259, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(886) },
                    { -680766992, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(858), 185485213, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(859) },
                    { -680766992, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(831), 935054720, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(832) },
                    { -214055944, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9920), 600121264, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9921) },
                    { -214055944, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9893), 518527321, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9894) },
                    { -214055944, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9865), 297730436, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9867) },
                    { -214055944, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9906), 864512072, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9908) },
                    { -214055944, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9879), 695216364, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9881) },
                    { -214055944, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9849), 408359473, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9851) },
                    { 198861184, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(164), 302458711, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(165) },
                    { 198861184, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(137), 398462886, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(138) },
                    { 198861184, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(110), 914069471, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(111) },
                    { 198861184, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(150), 818658970, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(152) },
                    { 198861184, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(124), 691030784, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(125) },
                    { 198861184, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(97), 887429898, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(98) },
                    { 307442120, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(411), 702050925, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(412) },
                    { 307442120, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(382), 627364668, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(383) },
                    { 307442120, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(355), 124070184, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(357) },
                    { 307442120, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(396), 206998517, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(397) },
                    { 307442120, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(369), 559057155, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(370) },
                    { 307442120, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(342), 895270291, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(343) },
                    { 1043046032, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(572), 621822998, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(574) },
                    { 1043046032, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(545), 770726601, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(547) },
                    { 1043046032, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(518), 552365911, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(520) },
                    { 1043046032, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(559), 572137261, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(560) },
                    { 1043046032, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(532), 531597672, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(533) },
                    { 1043046032, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(505), 395370768, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(507) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1050839848, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9755), 644461921, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9756) },
                    { 1050839848, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9727), 195253096, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9728) },
                    { 1050839848, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9700), 750565316, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9701) },
                    { 1050839848, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9740), 954254671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9742) },
                    { 1050839848, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9714), 414780146, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9715) },
                    { 1050839848, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9686), 148433824, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9687) },
                    { 1501087304, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(979), 427234708, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(980) },
                    { 1501087304, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(952), 909708499, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(953) },
                    { 1501087304, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(925), 200337809, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(926) },
                    { 1501087304, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(965), 870340418, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(967) },
                    { 1501087304, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(938), 710850055, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(940) },
                    { 1501087304, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(912), 231092617, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(913) },
                    { 1858583952, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(737), 714631312, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(738) },
                    { 1858583952, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(709), 749170566, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(711) },
                    { 1858583952, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(683), 395035318, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(684) },
                    { 1858583952, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(723), 703342090, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(724) },
                    { 1858583952, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(696), 657044781, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(697) },
                    { 1858583952, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(669), 941738161, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(671) },
                    { 1886077304, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(817), 356392421, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(819) },
                    { 1886077304, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(790), 630418519, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(792) },
                    { 1886077304, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(763), 205016543, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(765) },
                    { 1886077304, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(804), 729391997, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(805) },
                    { 1886077304, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(777), 937769403, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(778) },
                    { 1886077304, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(750), 710928543, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(752) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1532736872, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2690), 529830253, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2692) },
                    { -1532736872, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2716), 425879863, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2717) },
                    { -1532736872, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2703), 872956220, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2704) },
                    { -1484073856, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2174), 499294113, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2175) },
                    { -1484073856, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2204), 876162104, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2206) },
                    { -1484073856, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2191), 224721133, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2192) },
                    { -1476634856, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2415), 526426692, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2416) },
                    { -1476634856, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2440), 282022619, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2441) },
                    { -1476634856, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2427), 860900986, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2429) },
                    { -1440671592, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2218), 732515178, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2219) },
                    { -1440671592, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2245), 837513654, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2246) },
                    { -1440671592, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2231), 452824641, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2232) },
                    { -1287980928, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2613), 932188088, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2614) },
                    { -1287980928, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2639), 799856753, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2640) },
                    { -1287980928, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2626), 861881109, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2627) },
                    { -1040150112, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2534), 406788783, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2536) },
                    { -1040150112, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2560), 390291931, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2561) },
                    { -1040150112, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2547), 776006104, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2548) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -901724600, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2375), 499364554, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2376) },
                    { -901724600, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2402), 172109118, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2403) },
                    { -901724600, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2387), 653738364, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2388) },
                    { -797215376, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2491), 542573266, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2492) },
                    { -797215376, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2517), 289137107, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2519) },
                    { -797215376, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2504), 603113325, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2506) },
                    { -708464664, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2298), 685058392, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2299) },
                    { -708464664, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2324), 283879308, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2325) },
                    { -708464664, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2311), 666911472, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2312) },
                    { -680766992, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2806), 374234582, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2807) },
                    { -680766992, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2832), 233414096, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2833) },
                    { -680766992, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2819), 888396624, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2821) },
                    { -214055944, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2336), 977430866, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2338) },
                    { -214055944, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2362), 833792691, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2363) },
                    { -214055944, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2349), 938878495, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2350) },
                    { 198861184, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2453), 413466034, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2454) },
                    { 198861184, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2478), 425100285, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2480) },
                    { 198861184, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2466), 223759545, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2467) },
                    { 307442120, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2573), 782714301, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2574) },
                    { 307442120, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2599), 183536045, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2600) },
                    { 307442120, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2586), 815477322, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2587) },
                    { 1043046032, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2652), 536706789, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2653) },
                    { 1043046032, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2677), 193137625, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2679) },
                    { 1043046032, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2665), 467648984, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2666) },
                    { 1050839848, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2258), 328421572, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2259) },
                    { 1050839848, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2284), 300958997, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2285) },
                    { 1050839848, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2271), 276951746, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2272) },
                    { 1501087304, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2845), 760217929, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2846) },
                    { 1501087304, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2870), 767951565, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2872) },
                    { 1501087304, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2858), 466092358, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2859) },
                    { 1858583952, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2729), 706547098, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2730) },
                    { 1858583952, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2755), 878259671, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2756) },
                    { 1858583952, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2742), 303730103, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2743) },
                    { 1886077304, 131570834, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2768), 155757919, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2769) },
                    { 1886077304, 413963833, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2794), 407143754, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2795) },
                    { 1886077304, 776810707, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2781), 977927930, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2782) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1532736872, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1879), 538471690, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1881) },
                    { -1532736872, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1854), 969887688, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1856) },
                    { -1532736872, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1867), 990516712, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1868) },
                    { -1532736872, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1905), 957864001, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1906) },
                    { -1532736872, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1892), 903676137, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1893) },
                    { -1484073856, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1024), 148660569, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1026) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1484073856, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(994), 385682823, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(996) },
                    { -1484073856, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1011), 625926231, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1012) },
                    { -1484073856, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1054), 458983266, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1056) },
                    { -1484073856, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1041), 865628290, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1042) },
                    { -1476634856, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1428), 620673493, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1429) },
                    { -1476634856, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1398), 951734950, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1399) },
                    { -1476634856, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1410), 617973934, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1412) },
                    { -1476634856, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1455), 221325438, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1456) },
                    { -1476634856, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1442), 560375913, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1444) },
                    { -1440671592, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1096), 700958468, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1097) },
                    { -1440671592, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1069), 862306692, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1070) },
                    { -1440671592, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1082), 687999609, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1084) },
                    { -1440671592, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1124), 857413983, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1125) },
                    { -1440671592, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1109), 556505511, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1111) },
                    { -1287980928, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1748), 236967762, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1750) },
                    { -1287980928, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1723), 782335491, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1724) },
                    { -1287980928, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1735), 925577018, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1737) },
                    { -1287980928, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1774), 764152579, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1775) },
                    { -1287980928, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1761), 959691758, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1762) },
                    { -1040150112, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1621), 269104423, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1622) },
                    { -1040150112, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1595), 611347952, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1597) },
                    { -1040150112, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1608), 436853310, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1609) },
                    { -1040150112, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1646), 660014490, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1647) },
                    { -1040150112, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1633), 790194738, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1635) },
                    { -901724600, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1360), 344001607, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1361) },
                    { -901724600, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1334), 855383901, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1335) },
                    { -901724600, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1346), 783469845, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1348) },
                    { -901724600, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1385), 290470928, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1386) },
                    { -901724600, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1372), 360259677, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1373) },
                    { -797215376, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1557), 549817235, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1558) },
                    { -797215376, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1532), 467333096, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1533) },
                    { -797215376, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1545), 306715938, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1546) },
                    { -797215376, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1583), 670864555, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1584) },
                    { -797215376, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1570), 750454328, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1571) },
                    { -708464664, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1229), 158871258, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1231) },
                    { -708464664, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1202), 766536767, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1203) },
                    { -708464664, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1215), 230783664, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1216) },
                    { -708464664, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1255), 578038307, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1257) },
                    { -708464664, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1242), 811281103, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1244) },
                    { -680766992, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2067), 675797929, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2068) },
                    { -680766992, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2042), 663395022, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2043) },
                    { -680766992, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2055), 362987173, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2056) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -680766992, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2092), 677991848, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2093) },
                    { -680766992, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2080), 372327928, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2081) },
                    { -214055944, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1294), 266872783, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1296) },
                    { -214055944, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1269), 220403298, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1270) },
                    { -214055944, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1282), 937779653, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1283) },
                    { -214055944, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1320), 349328002, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1322) },
                    { -214055944, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1308), 306888338, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1309) },
                    { 198861184, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1494), 837249661, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1495) },
                    { 198861184, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1468), 938804736, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1470) },
                    { 198861184, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1481), 215780121, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1482) },
                    { 198861184, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1519), 349517464, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1521) },
                    { 198861184, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1506), 384635780, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1508) },
                    { 307442120, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1684), 272344645, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1685) },
                    { 307442120, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1659), 902086216, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1660) },
                    { 307442120, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1672), 616943614, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1673) },
                    { 307442120, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1710), 260439295, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1711) },
                    { 307442120, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1697), 486594783, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1698) },
                    { 1043046032, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1815), 434049382, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1816) },
                    { 1043046032, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1786), 671820511, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1788) },
                    { 1043046032, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1802), 779943773, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1804) },
                    { 1043046032, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1840), 808287094, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1842) },
                    { 1043046032, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1828), 770331856, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1829) },
                    { 1050839848, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1163), 380125282, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1164) },
                    { 1050839848, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1137), 464379922, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1138) },
                    { 1050839848, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1150), 280989340, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1151) },
                    { 1050839848, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1189), 414275614, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1190) },
                    { 1050839848, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1176), 858593568, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1177) },
                    { 1501087304, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2130), 442595170, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2131) },
                    { 1501087304, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2105), 240796144, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2106) },
                    { 1501087304, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2117), 427061195, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2119) },
                    { 1501087304, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2160), 524769203, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2161) },
                    { 1501087304, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2147), 715086428, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2149) },
                    { 1858583952, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1942), 680412097, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1943) },
                    { 1858583952, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1917), 972599191, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1918) },
                    { 1858583952, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1930), 127669081, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1931) },
                    { 1858583952, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1967), 720871493, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1968) },
                    { 1858583952, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1955), 449274084, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1956) },
                    { 1886077304, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2005), 234398746, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2006) },
                    { 1886077304, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1980), 150882610, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1981) },
                    { 1886077304, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1992), 988881341, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(1993) },
                    { 1886077304, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2029), 985756388, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2031) },
                    { 1886077304, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2017), 530397811, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2018) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 131570834, 177605257, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3397), 1637836646, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3398) },
                    { 131570834, 202755381, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3362), -1645682561, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3363) },
                    { 131570834, 380346855, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3437), -1360798024, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3438) },
                    { 131570834, 461936334, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3382), -2112197728, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3383) },
                    { 131570834, 752718727, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3410), -368171270, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3411) },
                    { 131570834, 896408823, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3423), 134316919, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3424) },
                    { 413963833, 177605257, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3557), 200605505, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3558) },
                    { 413963833, 202755381, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3531), 105671782, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3532) },
                    { 413963833, 380346855, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3597), 404406757, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3598) },
                    { 413963833, 461936334, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3544), 1372487652, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3545) },
                    { 413963833, 752718727, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3570), -1504008319, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3571) },
                    { 413963833, 896408823, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3583), 1843985853, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3585) },
                    { 776810707, 177605257, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3477), -190789420, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3478) },
                    { 776810707, 202755381, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3450), -644391881, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3452) },
                    { 776810707, 380346855, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3517), -681952405, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3519) },
                    { 776810707, 461936334, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3464), 28513054, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3465) },
                    { 776810707, 752718727, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3492), -536378620, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3493) },
                    { 776810707, 896408823, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3504), 1059090521, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3506) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 177605257, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3134), -1832057441, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3136) },
                    { 202755381, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3110), 1473248327, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3111) },
                    { 380346855, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3174), -669779999, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3175) },
                    { 461936334, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3122), -493453390, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3123) },
                    { 752718727, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3147), -333731830, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3149) },
                    { 896408823, -2017624083, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3160), 127377221, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3161) },
                    { 177605257, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2977), -1224495211, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2978) },
                    { 202755381, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2884), 1740954686, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2886) },
                    { 380346855, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3018), -1556433818, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3019) },
                    { 461936334, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2962), -451410241, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2964) },
                    { 752718727, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2990), 28440253, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(2991) },
                    { 896408823, -1778730685, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3004), 1296644445, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3005) },
                    { 177605257, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3057), 1404919881, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3059) },
                    { 202755381, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3032), 1135130648, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3033) },
                    { 380346855, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3097), 1796919039, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3098) },
                    { 461936334, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3044), 1370556302, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3046) },
                    { 752718727, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3071), -1050846911, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3073) },
                    { 896408823, 399113761, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3084), -105893279, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3086) },
                    { 177605257, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3287), -1207662376, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3288) },
                    { 202755381, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3262), -224741699, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3263) },
                    { 380346855, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3325), -453465310, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3326) },
                    { 461936334, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3274), -741292982, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3276) },
                    { 752718727, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3299), 154858573, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3301) },
                    { 896408823, 1382424739, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3312), 230322313, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3313) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 177605257, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3211), 1160343747, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3213) },
                    { 202755381, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3186), -489605035, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3188) },
                    { 380346855, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3249), -1271333929, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3250) },
                    { 461936334, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3199), -41001547, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3200) },
                    { 752718727, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3224), -656729950, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3225) },
                    { 896408823, 1951200793, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3236), 1468921064, new DateTime(2024, 2, 28, 19, 59, 30, 938, DateTimeKind.Local).AddTicks(3238) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 185803671, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 9.0, 16, new DateTime(2025, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 16, "Test Description Project_4", "KL-4", new DateTime(2025, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), new DateTime(2025, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 0f, 100L, 12L, new DateTime(2024, 2, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), "Project_4", 5.0, new DateTime(2025, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), "Payment Detailes For Project_12", 4.0, null, 903198473, new DateTime(2025, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 0f },
                    { 787886530, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 8.0, 9, new DateTime(2024, 11, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 9, "Test Description Project_9", "KL-3", new DateTime(2024, 11, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), new DateTime(2024, 11, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 0f, 100L, 12L, new DateTime(2024, 2, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), "Project_3", 5.0, new DateTime(2024, 11, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), "Payment Detailes For Project_15", 3.0, null, 989940738, new DateTime(2024, 11, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 0f },
                    { 885760938, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 7.0, 4, new DateTime(2024, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), new DateTime(2024, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 0f, 100L, 12L, new DateTime(2024, 2, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), "Project_2", 5.0, new DateTime(2024, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), "Payment Detailes For Project_4", 2.0, null, 959436390, new DateTime(2024, 6, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 0f },
                    { 911809654, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 6.0, 1, new DateTime(2024, 3, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 1, "Test Description Project_3", "KL-1", new DateTime(2024, 3, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), new DateTime(2024, 3, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 0f, 100L, 12L, new DateTime(2024, 2, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), "Project_1", 5.0, new DateTime(2024, 3, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), "Payment Detailes For Project_3", 1.0, null, 579497657, new DateTime(2024, 3, 28, 19, 59, 30, 933, DateTimeKind.Local).AddTicks(1701), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 360836743, 150397571, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7759), 353028224, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7760) },
                    { 230217510, 177605257, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7292), 370406460, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7293) },
                    { 230217510, 202755381, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7232), 252040342, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7234) },
                    { 456628691, 279669735, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7073), 957835118, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7074) },
                    { 214909563, 354742180, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7559), 211151050, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7560) },
                    { 230217510, 380346855, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7380), 472876196, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7382) },
                    { 220975520, 411349005, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7138), 917512593, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7139) },
                    { 214909563, 412602791, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7502), 512001982, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7503) },
                    { 360836743, 430705524, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7664), 251592725, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7665) },
                    { 230217510, 461936334, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7264), 997189208, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7265) },
                    { 715369092, 476763101, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7108), 765894151, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7109) },
                    { 753632669, 485414260, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7167), 456378191, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7168) },
                    { 360836743, 543096406, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7726), 861273299, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7728) },
                    { 214909563, 612949905, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7443), 841642875, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7445) },
                    { 214909563, 629345611, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7531), 228077293, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7532) },
                    { 230217510, 752718727, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7320), 518077148, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7322) },
                    { 360836743, 888205376, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7697), 373481755, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7698) },
                    { 230217510, 896408823, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7351), 321494747, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7352) },
                    { 214909563, 929696039, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7474), 564338460, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7476) },
                    { 214909563, 971444792, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7415), 692998749, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7416) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1532736872, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9288), 1367168137, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9289) },
                    { -1532736872, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9275), 808913928, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9276) },
                    { -1532736872, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9262), -1134061737, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9263) },
                    { -1532736872, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9249), -644698980, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9250) },
                    { -1484073856, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8600), -1556064652, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8601) },
                    { -1484073856, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8586), -1012755404, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8588) },
                    { -1484073856, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8573), -1555384487, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8574) },
                    { -1484073856, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8553), 777946586, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8554) },
                    { -1476634856, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8920), 1270753064, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8921) },
                    { -1476634856, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8907), 1948873296, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8908) },
                    { -1476634856, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8894), 378034587, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8895) },
                    { -1476634856, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8881), 1665717805, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8882) },
                    { -1440671592, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8653), 1642249441, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8655) },
                    { -1440671592, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8640), 2094515299, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8641) },
                    { -1440671592, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8627), 272288360, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8628) },
                    { -1440671592, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8613), 1455266689, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8614) },
                    { -1287980928, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9184), -120993451, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9185) },
                    { -1287980928, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9171), 696939123, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9172) },
                    { -1287980928, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9158), 1757021724, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9159) },
                    { -1287980928, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9145), 815231419, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9146) },
                    { -1040150112, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9077), 1748123273, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9078) },
                    { -1040150112, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9064), 1295907460, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9065) },
                    { -1040150112, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9051), -131663456, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9052) },
                    { -1040150112, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9038), 617683142, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9039) },
                    { -901724600, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8868), 89526026, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8869) },
                    { -901724600, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8855), -32255170, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8856) },
                    { -901724600, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8842), -1111663309, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8843) },
                    { -901724600, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8829), -545727972, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8830) },
                    { -797215376, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9025), 418227955, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9026) },
                    { -797215376, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9012), 1893241454, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9013) },
                    { -797215376, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8999), -1283429779, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9000) },
                    { -797215376, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8985), 1343673460, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8986) },
                    { -708464664, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8762), -296249764, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8763) },
                    { -708464664, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8748), 663336412, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8750) },
                    { -708464664, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8736), 726411234, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8737) },
                    { -708464664, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8720), 1364620862, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8721) },
                    { -680766992, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9446), -226083516, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9447) },
                    { -680766992, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9433), 1576513030, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9434) },
                    { -680766992, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9420), 1769035390, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9421) },
                    { -680766992, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9405), 1007044080, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9407) },
                    { -214055944, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8816), 431814088, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8817) },
                    { -214055944, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8802), -117440128, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8804) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -214055944, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8789), -884650848, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8790) },
                    { -214055944, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8775), -1803287446, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8776) },
                    { 198861184, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8971), 2065714504, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8973) },
                    { 198861184, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8959), 569006580, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8960) },
                    { 198861184, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8946), -1662851672, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8947) },
                    { 198861184, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8933), 680063154, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8934) },
                    { 307442120, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9132), -787040790, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9133) },
                    { 307442120, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9119), 2060219445, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9120) },
                    { 307442120, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9106), 1335341961, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9107) },
                    { 307442120, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9090), -1674168279, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9091) },
                    { 1043046032, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9236), -1375318712, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9237) },
                    { 1043046032, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9223), -1740960998, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9224) },
                    { 1043046032, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9210), -56192262, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9211) },
                    { 1043046032, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9197), 2131918496, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9198) },
                    { 1050839848, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8707), -762038378, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8708) },
                    { 1050839848, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8694), 1013215492, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8695) },
                    { 1050839848, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8681), 1005445437, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8682) },
                    { 1050839848, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8666), 113794299, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8668) },
                    { 1501087304, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9501), -1641474183, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9502) },
                    { 1501087304, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9488), -285179578, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9489) },
                    { 1501087304, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9475), 279863555, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9476) },
                    { 1501087304, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9462), 1314984284, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9463) },
                    { 1858583952, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9340), 169280816, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9341) },
                    { 1858583952, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9327), -230929339, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9328) },
                    { 1858583952, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9314), -1252603958, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9315) },
                    { 1858583952, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9301), -1325566415, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9303) },
                    { 1886077304, 185803671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9392), 388175023, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9393) },
                    { 1886077304, 787886530, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9379), 364582440, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9380) },
                    { 1886077304, 885760938, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9366), -270050671, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9367) },
                    { 1886077304, 911809654, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9353), -822838948, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(9355) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 190539460, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8201), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8203), 13000.0, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8202), "Signature 1423412", 72841, 185803671, 4.0, 24.0 },
                    { 293640237, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8069), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8072), 3100.0, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8070), "Signature 142344", 63080, 885760938, 2.0, 24.0 },
                    { 519765551, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8137), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8139), 4000.0, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8138), "Signature 1423415", 66187, 787886530, 3.0, 17.0 },
                    { 525116779, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7991), new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7994), 3010.0, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7992), "Signature 142344", 18561, 911809654, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 185803671, 150397571, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8538), 501582455, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8540) },
                    { 911809654, 430705524, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8493), 327342828, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8495) },
                    { 787886530, 543096406, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8526), 408556142, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8527) },
                    { 885760938, 888205376, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8512), 137452189, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8513) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 336041070, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7956), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7958), null, "6949277781", null, null, 911809654 },
                    { 631262705, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8107), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8109), null, "6949277783", null, null, 787886530 },
                    { 701069672, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8036), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8037), null, "6949277782", null, null, 885760938 },
                    { 765427071, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8172), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8173), null, "6949277784", null, null, 185803671 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 715804385, 336041070, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7976), 889922854, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(7977) },
                    { 715804385, 631262705, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8124), 908657520, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8125) },
                    { 715804385, 701069672, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8053), 928957947, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8054) },
                    { 715804385, 765427071, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8187), 392467576, new DateTime(2024, 2, 28, 19, 59, 30, 937, DateTimeKind.Local).AddTicks(8189) }
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
