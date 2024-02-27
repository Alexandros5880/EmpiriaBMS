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
                    { -1763457872, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9139), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9141), "Sewage", null },
                    { -1316446920, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9235), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9236), "Natural Gas", null },
                    { -1174658624, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9170), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9171), "Drainage", null },
                    { -1051245368, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9341), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9342), "Energy Efficiency", null },
                    { -919055248, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9281), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9283), "Burglar Alarm", null },
                    { -415182728, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9249), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9251), "Power Distribution", null },
                    { 30515224, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9326), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9327), "Photovoltaics", null },
                    { 389298960, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9220), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9221), "Elevators", null },
                    { 546549552, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9185), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9186), "Fire Detection", null },
                    { 1276073128, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9266), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9267), "Structured Cabling", null },
                    { 1424758704, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9122), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9123), "HVAC", null },
                    { 1486355256, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9311), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9312), "BMS", null },
                    { 1761755992, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9205), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9206), "Fire Suppression", null },
                    { 1797640704, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9296), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9298), "CCTV", null },
                    { 1825029464, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9155), 0f, 1500L, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9156), "Potable Water", null }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 136017804, new DateTime(2024, 3, 9, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8682), 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8679), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8680), "Drawing 4" },
                    { 155148503, new DateTime(2024, 3, 9, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8716), 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8713), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8715), "Drawing 6" },
                    { 162680887, new DateTime(2024, 3, 9, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8649), 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8646), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8647), "Drawing 2" },
                    { 174650012, new DateTime(2024, 3, 9, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8697), 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8695), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8696), "Drawing 5" },
                    { 379310845, new DateTime(2024, 3, 9, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8625), 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8620), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8621), "Drawing 1" },
                    { 836682236, new DateTime(2024, 3, 9, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8666), 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8663), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8664), "Drawing 3" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -1707065266, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8573), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8574), "On-Site" },
                    { 489731179, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8538), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8539), "Communications" },
                    { 1159073067, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8588), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8589), "Meetings" },
                    { 1758755073, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8558), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8559), "Printing" },
                    { 1938666997, 0f, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8603), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8604), "Administration" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 132760948, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8747), "Infrastructure Description", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8748), "Infrastructure" },
                    { 500431107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8730), "Buildings Description", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8731), "Buildings" },
                    { 649338093, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8778), "Consulting Description", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8779), "Consulting" },
                    { 883646879, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8763), "Energy Description", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8764), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 125010969, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7658), true, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7659), "COO" },
                    { 161509477, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7650), true, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7651), "Project Manager" },
                    { 625083080, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7673), true, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7674), "CEO" },
                    { 643880297, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7634), true, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7635), "Designer" },
                    { 796488207, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7642), true, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7643), "Engineer" },
                    { 859084689, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7681), false, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7682), "Guest" },
                    { 901622002, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7665), true, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7666), "CTO" },
                    { 989670737, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7689), false, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7690), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 145019872, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8042), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8043), null, "6949277782", null, null, null },
                    { 193000398, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7950), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7951), null, "6949277780", null, null, null },
                    { 203870544, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8071), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8073), null, "6949277783", null, null, null },
                    { 206794153, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8443), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8445), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 208287316, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8377), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8378), null, "6949277781", null, null, null },
                    { 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8284), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8285), null, "6949277783", null, null, null },
                    { 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8240), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8241), null, "6949277782", null, null, null },
                    { 283430767, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8472), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8473), null, "6949277784", null, null, null },
                    { 307539926, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8012), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8013), null, "6949277781", null, null, null },
                    { 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8210), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8211), null, "6949277781", null, null, null },
                    { 333148670, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8101), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8103), null, "6949277784", null, null, null },
                    { 460591233, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8134), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8135), null, "6949277785", null, null, null },
                    { 489475226, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7814), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7815), null, "694927778", null, null, null },
                    { 533072023, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8413), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8414), null, "6949277782", null, null, null },
                    { 676522124, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7855), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7856), null, "694927778", null, null, null },
                    { 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8344), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8345), null, "6949277785", null, null, null },
                    { 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8313), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8314), null, "6949277784", null, null, null },
                    { 871132122, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7916), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7918), null, "694927778", null, null, null },
                    { 962981660, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8501), "Test Description PM 5", "pm5@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8502), null, "6949277785", null, null, null },
                    { 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8176), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8178), null, "6949277780", null, null, null },
                    { 987619902, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7886), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7888), null, "694927778", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1763457872, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(442), 136779757, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(443) },
                    { -1763457872, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(427), 867707565, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(428) },
                    { -1763457872, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(413), 910834385, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(414) },
                    { -1763457872, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(496), 897129249, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(497) },
                    { -1763457872, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(481), 613845945, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(482) },
                    { -1763457872, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(399), 726687075, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(400) },
                    { -1316446920, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(981), 429064311, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(982) },
                    { -1316446920, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(967), 931887479, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(969) },
                    { -1316446920, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(954), 333099699, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(955) },
                    { -1316446920, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1008), 259164506, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1010) },
                    { -1316446920, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(995), 399039348, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(996) },
                    { -1316446920, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(940), 401360292, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(941) },
                    { -1174658624, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(634), 510037617, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(636) },
                    { -1174658624, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(621), 742900939, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(622) },
                    { -1174658624, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(607), 866611189, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(608) },
                    { -1174658624, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(661), 796220157, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(662) },
                    { -1174658624, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(648), 497728519, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(649) },
                    { -1174658624, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(593), 594633624, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(594) },
                    { -1051245368, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1641), 908167927, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1642) },
                    { -1051245368, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1627), 892684691, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1628) },
                    { -1051245368, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1613), 382187904, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1615) },
                    { -1051245368, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1668), 663809794, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1669) },
                    { -1051245368, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1654), 993211974, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1655) },
                    { -1051245368, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1600), 412983978, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1601) },
                    { -919055248, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1228), 725096507, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1229) },
                    { -919055248, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1214), 693403721, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1215) },
                    { -919055248, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1201), 541411142, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1202) },
                    { -919055248, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1338), 253789601, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1340) },
                    { -919055248, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1322), 162878755, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1324) },
                    { -919055248, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1187), 243136170, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1188) },
                    { -415182728, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1063), 526736294, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1064) },
                    { -415182728, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1050), 522471490, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1051) },
                    { -415182728, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1036), 127745430, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1037) },
                    { -415182728, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1091), 596787815, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1092) },
                    { -415182728, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1077), 701062824, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1078) },
                    { -415182728, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1022), 615828325, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1023) },
                    { 30515224, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1559), 130039251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1560) },
                    { 30515224, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1545), 948587863, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1546) },
                    { 30515224, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1531), 610126217, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1533) },
                    { 30515224, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1586), 654741155, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1587) },
                    { 30515224, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1572), 570214671, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1574) },
                    { 30515224, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1518), 967936849, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1519) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 389298960, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(898), 442361569, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(899) },
                    { 389298960, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(884), 808014675, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(885) },
                    { 389298960, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(855), 956989371, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(856) },
                    { 389298960, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(926), 626720129, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(927) },
                    { 389298960, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(912), 955575962, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(913) },
                    { 389298960, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(841), 198615881, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(842) },
                    { 546549552, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(716), 252167507, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(717) },
                    { 546549552, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(703), 123671559, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(704) },
                    { 546549552, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(689), 572752281, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(690) },
                    { 546549552, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(744), 568407421, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(745) },
                    { 546549552, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(730), 896901028, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(731) },
                    { 546549552, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(675), 611086706, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(676) },
                    { 1276073128, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1146), 814965688, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1147) },
                    { 1276073128, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1132), 762928853, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1133) },
                    { 1276073128, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1119), 226648507, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1120) },
                    { 1276073128, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1173), 690649224, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1174) },
                    { 1276073128, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1159), 611673255, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1161) },
                    { 1276073128, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1105), 462689942, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1106) },
                    { 1424758704, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(356), 312973103, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(357) },
                    { 1424758704, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(343), 668632688, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(344) },
                    { 1424758704, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(328), 916104701, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(330) },
                    { 1424758704, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(385), 476225582, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(386) },
                    { 1424758704, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(370), 344274954, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(371) },
                    { 1424758704, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(309), 813435843, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(310) },
                    { 1486355256, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1476), 957235431, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1478) },
                    { 1486355256, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1463), 937789534, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1464) },
                    { 1486355256, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1449), 697011235, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1450) },
                    { 1486355256, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1504), 657911843, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1505) },
                    { 1486355256, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1490), 731907483, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1491) },
                    { 1486355256, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1435), 434477361, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1436) },
                    { 1761755992, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(799), 420533891, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(801) },
                    { 1761755992, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(785), 884971369, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(786) },
                    { 1761755992, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(771), 693583787, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(772) },
                    { 1761755992, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(828), 992531986, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(829) },
                    { 1761755992, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(814), 808239142, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(815) },
                    { 1761755992, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(757), 251012123, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(759) },
                    { 1797640704, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1394), 162071719, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1395) },
                    { 1797640704, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1380), 665314998, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1381) },
                    { 1797640704, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1367), 575299361, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1368) },
                    { 1797640704, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1421), 463404359, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1423) },
                    { 1797640704, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1408), 319181488, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1409) },
                    { 1797640704, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1353), 409893404, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1354) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1825029464, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(551), 900483910, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(552) },
                    { 1825029464, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(537), 208026850, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(538) },
                    { 1825029464, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(524), 632390026, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(525) },
                    { 1825029464, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(579), 180064942, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(580) },
                    { 1825029464, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(564), 536894727, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(566) },
                    { 1825029464, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(510), 973308589, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(511) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1763457872, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2916), 513280442, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2917) },
                    { -1763457872, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2944), 472035156, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2945) },
                    { -1763457872, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2865), 616284874, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2866) },
                    { -1763457872, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2930), 976402269, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2931) },
                    { -1763457872, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2851), 487313805, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2852) },
                    { -1763457872, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2878), 977411826, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2879) },
                    { -1316446920, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3436), 869425551, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3437) },
                    { -1316446920, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3463), 619877254, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3464) },
                    { -1316446920, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3409), 558878371, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3410) },
                    { -1316446920, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3450), 560411442, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3451) },
                    { -1316446920, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3395), 729951856, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3396) },
                    { -1316446920, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3423), 704877522, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3424) },
                    { -1174658624, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3081), 209142185, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3082) },
                    { -1174658624, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3108), 374415258, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3109) },
                    { -1174658624, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3054), 207065864, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3056) },
                    { -1174658624, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3094), 597822553, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3096) },
                    { -1174658624, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3041), 298768962, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3042) },
                    { -1174658624, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3068), 354848325, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3069) },
                    { -1051245368, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4030), 506285142, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4031) },
                    { -1051245368, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4057), 432326287, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4059) },
                    { -1051245368, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4003), 445164401, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4004) },
                    { -1051245368, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4044), 147352184, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4045) },
                    { -1051245368, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3990), 919743069, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3991) },
                    { -1051245368, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4017), 278224117, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4018) },
                    { -919055248, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3680), 403619055, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3681) },
                    { -919055248, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3731), 571470159, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3732) },
                    { -919055248, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3652), 911257956, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3654) },
                    { -919055248, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3693), 840420072, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3694) },
                    { -919055248, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3639), 364791470, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3640) },
                    { -919055248, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3666), 127757758, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3667) },
                    { -415182728, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3517), 302015021, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3518) },
                    { -415182728, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3544), 244863564, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3545) },
                    { -415182728, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3490), 651655110, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3491) },
                    { -415182728, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3531), 246078644, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3532) },
                    { -415182728, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3477), 630448732, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3478) },
                    { -415182728, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3503), 421307643, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3505) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 30515224, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3949), 219776856, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3950) },
                    { 30515224, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3976), 605088289, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3977) },
                    { 30515224, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3922), 477041944, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3923) },
                    { 30515224, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3963), 863206192, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3964) },
                    { 30515224, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3909), 667303365, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3910) },
                    { 30515224, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3936), 853001567, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3937) },
                    { 389298960, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3354), 378953395, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3355) },
                    { 389298960, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3381), 464928529, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3383) },
                    { 389298960, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3326), 338175978, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3327) },
                    { 389298960, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3368), 604946638, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3369) },
                    { 389298960, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3286), 370462388, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3287) },
                    { 389298960, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3340), 866723299, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3342) },
                    { 546549552, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3163), 594457900, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3164) },
                    { 546549552, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3190), 869595793, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3191) },
                    { 546549552, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3135), 196447712, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3137) },
                    { 546549552, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3176), 687022101, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3177) },
                    { 546549552, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3122), 936666014, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3123) },
                    { 546549552, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3149), 653787647, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3150) },
                    { 1276073128, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3599), 604843680, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3600) },
                    { 1276073128, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3625), 286154595, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3627) },
                    { 1276073128, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3572), 191913432, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3573) },
                    { 1276073128, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3612), 188483676, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3613) },
                    { 1276073128, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3558), 999175079, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3559) },
                    { 1276073128, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3585), 708667882, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3586) },
                    { 1424758704, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2808), 253158084, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2809) },
                    { 1424758704, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2836), 270649373, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2838) },
                    { 1424758704, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2780), 281776706, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2781) },
                    { 1424758704, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2822), 157802858, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2823) },
                    { 1424758704, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2764), 439960131, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2765) },
                    { 1424758704, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2793), 507777643, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2795) },
                    { 1486355256, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3868), 835413287, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3869) },
                    { 1486355256, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3895), 764970470, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3896) },
                    { 1486355256, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3841), 992279854, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3842) },
                    { 1486355256, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3882), 505087999, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3883) },
                    { 1486355256, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3828), 656363342, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3829) },
                    { 1486355256, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3854), 803851019, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3856) },
                    { 1761755992, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3245), 562761256, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3246) },
                    { 1761755992, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3273), 315469357, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3274) },
                    { 1761755992, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3217), 574464528, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3218) },
                    { 1761755992, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3259), 382965491, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3260) },
                    { 1761755992, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3203), 680533454, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3204) },
                    { 1761755992, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3230), 996408279, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3231) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1797640704, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3787), 180931986, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3788) },
                    { 1797640704, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3814), 435193302, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3815) },
                    { 1797640704, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3760), 799098725, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3761) },
                    { 1797640704, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3800), 855877667, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3801) },
                    { 1797640704, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3746), 991644426, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3748) },
                    { 1797640704, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3773), 502703698, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3774) },
                    { 1825029464, 136017804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2998), 247741881, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3000) },
                    { 1825029464, 155148503, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3027), 203372464, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3028) },
                    { 1825029464, 162680887, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2971), 778837161, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2972) },
                    { 1825029464, 174650012, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3012), 832580645, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(3013) },
                    { 1825029464, 379310845, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2958), 124694608, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2959) },
                    { 1825029464, 836682236, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2985), 266847972, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2986) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1763457872, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1813), 891810161, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1814) },
                    { -1763457872, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1785), 620939602, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1786) },
                    { -1763457872, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1826), 779378394, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1827) },
                    { -1763457872, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1799), 137453494, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1801) },
                    { -1763457872, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1840), 912478767, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1841) },
                    { -1316446920, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2239), 905576383, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2240) },
                    { -1316446920, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2213), 554493361, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2214) },
                    { -1316446920, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2251), 447274862, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2252) },
                    { -1316446920, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2226), 315425948, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2227) },
                    { -1316446920, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2264), 504110458, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2265) },
                    { -1174658624, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1947), 329856824, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1948) },
                    { -1174658624, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1920), 267957329, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1921) },
                    { -1174658624, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1961), 134537625, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1962) },
                    { -1174658624, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1933), 463842714, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1934) },
                    { -1174658624, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1974), 431001779, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1975) },
                    { -1051245368, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2723), 384426711, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2725) },
                    { -1051245368, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2697), 196762408, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2698) },
                    { -1051245368, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2736), 926718063, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2738) },
                    { -1051245368, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2710), 132180804, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2712) },
                    { -1051245368, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2749), 789450056, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2750) },
                    { -919055248, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2435), 307956289, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2436) },
                    { -919055248, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2408), 129349802, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2410) },
                    { -919055248, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2447), 982597899, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2448) },
                    { -919055248, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2421), 483156612, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2423) },
                    { -919055248, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2460), 131154701, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2462) },
                    { -415182728, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2303), 853023609, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2304) },
                    { -415182728, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2277), 370409994, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2278) },
                    { -415182728, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2316), 245887614, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2317) },
                    { -415182728, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2290), 265924661, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2291) },
                    { -415182728, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2330), 656498200, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2331) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 30515224, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2658), 925827299, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2659) },
                    { 30515224, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2630), 478024087, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2632) },
                    { 30515224, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2671), 211117365, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2672) },
                    { 30515224, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2645), 471732653, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2646) },
                    { 30515224, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2684), 528405555, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2685) },
                    { 389298960, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2171), 957689226, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2172) },
                    { 389298960, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2144), 812575600, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2146) },
                    { 389298960, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2185), 593769635, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2187) },
                    { 389298960, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2158), 457834136, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2159) },
                    { 389298960, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2199), 312818790, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2200) },
                    { 546549552, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2013), 402655884, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2015) },
                    { 546549552, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1987), 399093257, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1988) },
                    { 546549552, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2027), 373711829, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2028) },
                    { 546549552, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2000), 924237261, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2001) },
                    { 546549552, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2040), 983292505, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2041) },
                    { 1276073128, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2369), 419886973, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2370) },
                    { 1276073128, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2343), 319583791, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2344) },
                    { 1276073128, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2382), 476856898, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2383) },
                    { 1276073128, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2356), 337755788, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2357) },
                    { 1276073128, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2395), 487887201, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2396) },
                    { 1424758704, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1744), 771339440, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1745) },
                    { 1424758704, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1683), 195221544, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1685) },
                    { 1424758704, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1757), 182071588, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1758) },
                    { 1424758704, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1729), 563761548, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1730) },
                    { 1424758704, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1770), 600868398, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1772) },
                    { 1486355256, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2590), 802134809, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2591) },
                    { 1486355256, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2564), 854866274, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2565) },
                    { 1486355256, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2603), 808394751, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2604) },
                    { 1486355256, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2576), 902392355, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2578) },
                    { 1486355256, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2616), 245856136, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2617) },
                    { 1761755992, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2079), 286491640, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2080) },
                    { 1761755992, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2053), 401529333, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2054) },
                    { 1761755992, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2092), 708770268, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2093) },
                    { 1761755992, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2066), 466607811, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2067) },
                    { 1761755992, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2129), 606085697, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2130) },
                    { 1797640704, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2499), 794717019, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2501) },
                    { 1797640704, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2474), 276680152, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2475) },
                    { 1797640704, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2535), 645533375, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2537) },
                    { 1797640704, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2487), 452589906, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2488) },
                    { 1797640704, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2550), 373658470, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(2551) },
                    { 1825029464, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1880), 773209144, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1881) },
                    { 1825029464, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1854), 728625008, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1855) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1825029464, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1893), 588528160, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1894) },
                    { 1825029464, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1867), 216172823, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1868) },
                    { 1825029464, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1906), 360015962, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(1907) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 136017804, 145019872, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4849), 1236305867, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4851) },
                    { 136017804, 193000398, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4822), 256335971, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4823) },
                    { 136017804, 203870544, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4863), 125310362, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4864) },
                    { 136017804, 307539926, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4836), 1479057512, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4837) },
                    { 136017804, 333148670, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4877), -1453069448, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4878) },
                    { 136017804, 460591233, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4890), -2092142785, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4892) },
                    { 155148503, 145019872, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5038), -962350487, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5039) },
                    { 155148503, 193000398, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4987), -87064019, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4988) },
                    { 155148503, 203870544, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5054), 1851323607, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5055) },
                    { 155148503, 307539926, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5001), -1436843060, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5002) },
                    { 155148503, 333148670, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5068), -978535219, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5069) },
                    { 155148503, 460591233, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5082), -1571894369, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(5083) },
                    { 162680887, 145019872, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4681), 1396143941, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4682) },
                    { 162680887, 193000398, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4653), 824897354, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4654) },
                    { 162680887, 203870544, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4696), -73717780, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4697) },
                    { 162680887, 307539926, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4667), -2073968594, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4668) },
                    { 162680887, 333148670, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4710), 521604419, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4711) },
                    { 162680887, 460591233, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4724), 1955566292, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4725) },
                    { 174650012, 145019872, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4932), -1739544137, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4933) },
                    { 174650012, 193000398, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4905), -1699465819, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4906) },
                    { 174650012, 203870544, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4945), -2091879152, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4946) },
                    { 174650012, 307539926, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4918), -1531977947, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4920) },
                    { 174650012, 333148670, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4959), 1477302084, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4960) },
                    { 174650012, 460591233, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4974), -1094856592, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4975) },
                    { 379310845, 145019872, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4564), -196035101, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4565) },
                    { 379310845, 193000398, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4530), -1576068529, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4531) },
                    { 379310845, 203870544, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4608), 711706721, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4609) },
                    { 379310845, 307539926, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4550), -1332667840, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4551) },
                    { 379310845, 333148670, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4623), -173325779, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4625) },
                    { 379310845, 460591233, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4639), -221151136, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4640) },
                    { 836682236, 145019872, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4766), 1899309938, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4767) },
                    { 836682236, 193000398, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4738), -1448078089, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4739) },
                    { 836682236, 203870544, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4779), 376840184, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4780) },
                    { 836682236, 307539926, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4752), 569816843, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4753) },
                    { 836682236, 333148670, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4793), 578186015, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4794) },
                    { 836682236, 460591233, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4808), 1130549711, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4809) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 145019872, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4303), 194111420, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4304) },
                    { 193000398, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4275), 1423667016, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4276) },
                    { 203870544, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4317), 1283866484, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4318) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 307539926, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4289), 111624287, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4290) },
                    { 333148670, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4331), -1710236582, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4332) },
                    { 460591233, -1707065266, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4346), 1606649832, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4348) },
                    { 145019872, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4105), -97506260, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4106) },
                    { 193000398, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4072), -1266165301, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4074) },
                    { 203870544, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4119), 1207931819, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4120) },
                    { 307539926, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4091), -1298847658, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4092) },
                    { 333148670, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4156), -1446679399, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4157) },
                    { 460591233, 489731179, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4173), 875597180, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4174) },
                    { 145019872, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4389), -1165123444, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4390) },
                    { 193000398, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4361), -23191118, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4362) },
                    { 203870544, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4403), 1142518001, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4404) },
                    { 307539926, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4375), 2145709782, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4376) },
                    { 333148670, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4417), -1330666829, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4418) },
                    { 460591233, 1159073067, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4431), -1015853291, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4432) },
                    { 145019872, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4217), 1351257773, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4218) },
                    { 193000398, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4189), -1040502446, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4190) },
                    { 203870544, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4232), 2072512589, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4234) },
                    { 307539926, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4203), 1198597500, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4205) },
                    { 333148670, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4247), 2124351095, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4248) },
                    { 460591233, 1758755073, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4261), 296980565, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4262) },
                    { 145019872, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4473), 306580487, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4474) },
                    { 193000398, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4445), -1566792886, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4446) },
                    { 203870544, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4487), 1146821702, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4488) },
                    { 307539926, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4459), -2140778303, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4460) },
                    { 333148670, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4501), 248775274, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4502) },
                    { 460591233, 1938666997, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4515), 308006258, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(4516) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 288856107, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 8.0, 9, new DateTime(2024, 11, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 9, "Test Description Project_18", "KL-3", new DateTime(2024, 11, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), new DateTime(2024, 11, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 0f, 100L, 12L, new DateTime(2024, 2, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), "Project_3", 5.0, new DateTime(2024, 11, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), "Payment Detailes For Project_6", 3.0, null, 883646879, new DateTime(2024, 11, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 0f },
                    { 337753918, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 9.0, 16, new DateTime(2025, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 16, "Test Description Project_12", "KL-4", new DateTime(2025, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), new DateTime(2025, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 0f, 100L, 12L, new DateTime(2024, 2, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), "Project_4", 5.0, new DateTime(2025, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), "Payment Detailes For Project_16", 4.0, null, 649338093, new DateTime(2025, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 0f },
                    { 417917245, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 7.0, 4, new DateTime(2024, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), new DateTime(2024, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 0f, 100L, 12L, new DateTime(2024, 2, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), "Project_2", 5.0, new DateTime(2024, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), "Payment Detailes For Project_8", 2.0, null, 132760948, new DateTime(2024, 6, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 0f },
                    { 692499649, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 6.0, 1, new DateTime(2024, 3, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 3, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), new DateTime(2024, 3, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 0f, 100L, 12L, new DateTime(2024, 2, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), "Project_1", 5.0, new DateTime(2024, 3, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), "Payment Detailes For Project_6", 1.0, null, 500431107, new DateTime(2024, 3, 27, 18, 53, 15, 991, DateTimeKind.Local).AddTicks(1729), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 643880297, 145019872, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8058), 929634469, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8059) },
                    { 643880297, 193000398, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7996), 468643452, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7997) },
                    { 643880297, 203870544, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8088), 890578447, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8089) },
                    { 161509477, 206794153, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8459), 908595477, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8460) },
                    { 161509477, 208287316, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8397), 513894720, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8399) },
                    { 796488207, 240884972, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8300), 872413121, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8301) },
                    { 796488207, 263242074, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8271), 288433257, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8272) },
                    { 161509477, 283430767, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8487), 994435777, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8488) },
                    { 643880297, 307539926, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8029), 533110561, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8030) },
                    { 796488207, 326724432, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8227), 570596861, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8228) },
                    { 643880297, 333148670, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8119), 381296832, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8120) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 643880297, 460591233, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8161), 694884518, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8162) },
                    { 625083080, 489475226, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7835), 866704450, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7836) },
                    { 161509477, 533072023, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8429), 289374572, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8430) },
                    { 901622002, 676522124, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7871), 168566395, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7872) },
                    { 796488207, 692926607, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8359), 222635537, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8360) },
                    { 796488207, 851686251, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8330), 267413679, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8331) },
                    { 859084689, 871132122, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7932), 999465032, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7933) },
                    { 161509477, 962981660, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8522), 404618875, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8523) },
                    { 796488207, 967636983, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8196), 657957462, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8197) },
                    { 125010969, 987619902, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7902), 760983729, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(7903) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1763457872, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9508), 187648674, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9509) },
                    { -1763457872, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9522), -1098168432, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9523) },
                    { -1763457872, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9493), -663480890, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9495) },
                    { -1763457872, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9478), -1996463694, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9480) },
                    { -1316446920, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9841), -1293138195, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9843) },
                    { -1316446920, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9855), 814413521, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9856) },
                    { -1316446920, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9828), 1498837504, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9829) },
                    { -1316446920, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9814), 348477584, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9816) },
                    { -1174658624, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9622), 1203055140, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9623) },
                    { -1174658624, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9635), -350119281, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9637) },
                    { -1174658624, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9608), 550863728, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9609) },
                    { -1174658624, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9594), -2104528048, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9596) },
                    { -1051245368, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(281), -827605772, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(282) },
                    { -1051245368, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(294), 839188022, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(295) },
                    { -1051245368, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(267), 247932587, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(268) },
                    { -1051245368, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(254), -244658762, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(255) },
                    { -919055248, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(63), 938082640, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(64) },
                    { -919055248, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(76), 1469292886, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(77) },
                    { -919055248, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(49), 311481428, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(50) },
                    { -919055248, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(35), 615887733, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(36) },
                    { -415182728, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9898), 537007772, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9899) },
                    { -415182728, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9912), 1815249262, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9913) },
                    { -415182728, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9884), 1319694268, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9885) },
                    { -415182728, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9869), -1444720432, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9870) },
                    { 30515224, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(226), -1491731239, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(227) },
                    { 30515224, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(240), -363021530, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(241) },
                    { 30515224, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(213), -55814418, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(214) },
                    { 30515224, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(199), -1174515368, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(200) },
                    { 389298960, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9787), -340753704, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9788) },
                    { 389298960, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9801), 1632573004, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9802) },
                    { 389298960, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9774), 312383165, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9775) },
                    { 389298960, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9760), 1032924014, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9761) },
                    { 546549552, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9678), 1464339490, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9679) },
                    { 546549552, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9692), -1492474186, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9693) },
                    { 546549552, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9664), 113792052, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9665) },
                    { 546549552, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9649), -578282049, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9650) },
                    { 1276073128, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9952), 695724176, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9953) },
                    { 1276073128, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9966), -428822081, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9967) },
                    { 1276073128, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9939), 1804254530, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9940) },
                    { 1276073128, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9925), -398145896, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9927) },
                    { 1424758704, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9451), -378581299, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9452) },
                    { 1424758704, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9465), -1998345440, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9466) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1424758704, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9437), 800661192, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9438) },
                    { 1424758704, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9419), 831163653, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9420) },
                    { 1486355256, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(172), 483060208, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(173) },
                    { 1486355256, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(185), 898872838, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(187) },
                    { 1486355256, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(158), -1358856672, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(160) },
                    { 1486355256, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(145), -347710075, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(146) },
                    { 1761755992, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9732), 659709706, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9733) },
                    { 1761755992, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9746), -918118662, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9747) },
                    { 1761755992, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9719), -594074942, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9720) },
                    { 1761755992, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9705), 1616544156, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9707) },
                    { 1797640704, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(117), 2055785874, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(119) },
                    { 1797640704, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(131), -157831912, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(132) },
                    { 1797640704, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(104), -534577024, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(105) },
                    { 1797640704, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(90), 2114092276, new DateTime(2024, 2, 27, 18, 53, 15, 996, DateTimeKind.Local).AddTicks(91) },
                    { 1825029464, 288856107, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9564), -1632445531, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9566) },
                    { 1825029464, 337753918, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9578), -63957947, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9579) },
                    { 1825029464, 417917245, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9550), -443000724, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9551) },
                    { 1825029464, 692499649, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9535), -2025344172, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9537) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 263323144, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8963), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8965), 3100.0, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8964), "Signature 142346", 44986, 417917245, 2.0, 24.0 },
                    { 305792772, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9035), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9038), 4000.0, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9037), "Signature 142346", 55997, 288856107, 3.0, 17.0 },
                    { 325489139, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9103), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9105), 13000.0, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9104), "Signature 142348", 89446, 337753918, 4.0, 24.0 },
                    { 338995386, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8882), new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8884), 3010.0, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8883), "Signature 142342", 30776, 692499649, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 288856107, 206794153, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9390), 762383621, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9392) },
                    { 692499649, 208287316, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9357), 684934183, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9358) },
                    { 337753918, 283430767, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9404), 314108653, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9405) },
                    { 417917245, 533072023, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9376), 741531985, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9377) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 329731665, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9073), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9074), null, "6949277784", null, null, 337753918 },
                    { 467557100, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9006), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9007), null, "6949277783", null, null, 288856107 },
                    { 512666985, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8846), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8848), null, "6949277781", null, null, 692499649 },
                    { 712820457, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8932), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8934), null, "6949277782", null, null, 417917245 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 989670737, 329731665, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9089), 289748792, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9090) },
                    { 989670737, 467557100, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9022), 727180450, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(9023) },
                    { 989670737, 512666985, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8866), 355272615, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8867) },
                    { 989670737, 712820457, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8949), 416570962, new DateTime(2024, 2, 27, 18, 53, 15, 995, DateTimeKind.Local).AddTicks(8950) }
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
