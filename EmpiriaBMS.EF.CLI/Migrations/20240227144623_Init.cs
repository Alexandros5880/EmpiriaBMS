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
                    { -1981155536, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(409), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(411), "CCTV", null },
                    { -1714114600, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(282), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(283), "Potable Water", null },
                    { -1531340552, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(382), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(383), "Structured Cabling", null },
                    { -1248274128, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(296), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(297), "Drainage", null },
                    { -886261776, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(353), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(354), "Natural Gas", null },
                    { -381151824, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(325), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(326), "Fire Suppression", null },
                    { -335832232, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(309), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(310), "Fire Detection", null },
                    { 123023200, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(451), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(453), "Energy Efficiency", null },
                    { 1105466696, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(339), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(340), "Elevators", null },
                    { 1144064408, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(246), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(247), "HVAC", null },
                    { 1539858576, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(424), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(426), "BMS", null },
                    { 1791336448, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(268), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(269), "Sewage", null },
                    { 1847553840, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(367), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(368), "Power Distribution", null },
                    { 1959818176, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(396), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(397), "Burglar Alarm", null },
                    { 2001318432, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(438), 0f, 1500L, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(439), "Photovoltaics", null }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 168660241, new DateTime(2024, 3, 9, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9856), 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9853), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9854), "Drawing 6" },
                    { 218234740, new DateTime(2024, 3, 9, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9807), 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9804), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9805), "Drawing 3" },
                    { 667256909, new DateTime(2024, 3, 9, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9822), 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9819), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9820), "Drawing 4" },
                    { 838370319, new DateTime(2024, 3, 9, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9791), 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9788), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9790), "Drawing 2" },
                    { 927497449, new DateTime(2024, 3, 9, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9837), 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9835), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9836), "Drawing 5" },
                    { 931917651, new DateTime(2024, 3, 9, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9770), 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9766), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9768), "Drawing 1" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -1069284228, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9720), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9722), "On-Site" },
                    { -1061517686, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9736), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9737), "Meetings" },
                    { -832913478, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9706), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9708), "Printing" },
                    { -298247977, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9750), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9751), "Administration" },
                    { 207326621, 0f, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9689), new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9690), "Communications" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 166724917, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9872), "Buildings Description", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9873), "Buildings" },
                    { 366087140, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9917), "Consulting Description", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9918), "Consulting" },
                    { 406284144, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9902), "Energy Description", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9904), "Energy" },
                    { 789679671, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9888), "Infrastructure Description", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9889), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 289984004, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(8999), true, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9000), "CTO" },
                    { 402450096, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(8992), true, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(8993), "COO" },
                    { 409740047, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9013), false, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9014), "Guest" },
                    { 511046484, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(8985), true, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(8986), "Project Manager" },
                    { 599921922, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(8978), true, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(8979), "Engineer" },
                    { 620294259, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9006), true, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9007), "CEO" },
                    { 700391396, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(8970), true, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(8971), "Designer" },
                    { 760497515, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9019), false, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9021), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 159500212, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9215), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9216), null, "6949277782", null, null, null },
                    { 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9507), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9508), null, "6949277785", null, null, null },
                    { 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9478), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9479), null, "6949277784", null, null, null },
                    { 215069513, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9186), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9187), null, "6949277781", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 315039924, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9271), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9272), null, "6949277784", null, null, null },
                    { 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9407), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9408), null, "6949277782", null, null, null },
                    { 458085035, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9243), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9244), null, "6949277783", null, null, null },
                    { 475376675, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9123), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9124), null, "6949277780", null, null, null },
                    { 476584981, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9599), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9600), null, "6949277783", null, null, null },
                    { 521646106, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9627), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9629), null, "6949277784", null, null, null },
                    { 555478286, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9537), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9538), null, "6949277781", null, null, null },
                    { 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9346), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9347), null, "6949277780", null, null, null },
                    { 838055945, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9572), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9573), null, "6949277782", null, null, null },
                    { 868149393, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9305), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9306), null, "6949277785", null, null, null },
                    { 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9449), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9450), null, "6949277783", null, null, null },
                    { 927667410, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9656), "Test Description PM 5", "pm5@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9657), null, "6949277785", null, null, null },
                    { 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9379), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9380), null, "6949277781", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1981155536, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2203), 434081207, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2204) },
                    { -1981155536, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2191), 858281863, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2192) },
                    { -1981155536, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2165), 750196186, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2166) },
                    { -1981155536, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2137), 383325864, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2138) },
                    { -1981155536, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2178), 365575980, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2179) },
                    { -1981155536, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2150), 422365549, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2151) },
                    { -1714114600, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1514), 230099007, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1515) },
                    { -1714114600, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1501), 332289618, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1502) },
                    { -1714114600, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1475), 540070909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1477) },
                    { -1714114600, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1451), 840777403, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1452) },
                    { -1714114600, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1488), 224947805, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1489) },
                    { -1714114600, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1463), 176503746, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1464) },
                    { -1531340552, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2048), 274783155, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2050) },
                    { -1531340552, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2036), 182123634, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2037) },
                    { -1531340552, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2011), 216196150, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2012) },
                    { -1531340552, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1986), 744561355, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1987) },
                    { -1531340552, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2024), 221366051, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2025) },
                    { -1531340552, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1998), 572271335, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1999) },
                    { -1248274128, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1589), 883188304, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1590) },
                    { -1248274128, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1576), 636961807, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1577) },
                    { -1248274128, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1551), 193238830, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1553) },
                    { -1248274128, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1527), 740178066, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1528) },
                    { -1248274128, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1564), 423066813, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1565) },
                    { -1248274128, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1539), 639803545, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1540) },
                    { -886261776, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1894), 811114826, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1896) },
                    { -886261776, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1882), 622433568, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1883) },
                    { -886261776, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1857), 814123133, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1858) },
                    { -886261776, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1832), 272091228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1833) },
                    { -886261776, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1869), 256441089, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1870) },
                    { -886261776, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1844), 688902855, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1845) },
                    { -381151824, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1744), 328202728, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1745) },
                    { -381151824, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1731), 804654138, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1732) },
                    { -381151824, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1706), 443031046, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1707) },
                    { -381151824, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1681), 665692058, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1682) },
                    { -381151824, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1719), 590123690, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1720) },
                    { -381151824, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1693), 809429600, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1694) },
                    { -335832232, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1668), 448545227, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1669) },
                    { -335832232, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1655), 850885713, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1657) },
                    { -335832232, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1630), 685281698, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1632) },
                    { -335832232, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1605), 722561443, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1606) },
                    { -335832232, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1643), 693183489, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1644) },
                    { -335832232, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1617), 129908296, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1618) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 123023200, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2433), 898320457, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2434) },
                    { 123023200, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2420), 825763456, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2421) },
                    { 123023200, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2395), 954327273, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2396) },
                    { 123023200, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2370), 494007757, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2371) },
                    { 123023200, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2408), 503013749, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2409) },
                    { 123023200, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2383), 898097537, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2384) },
                    { 1105466696, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1819), 138320885, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1820) },
                    { 1105466696, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1806), 877853759, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1807) },
                    { 1105466696, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1781), 796385960, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1782) },
                    { 1105466696, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1756), 640666656, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1758) },
                    { 1105466696, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1793), 554637203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1795) },
                    { 1105466696, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1769), 204176060, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1770) },
                    { 1144064408, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1361), 703564973, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1362) },
                    { 1144064408, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1347), 220208322, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1348) },
                    { 1144064408, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1322), 875411502, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1323) },
                    { 1144064408, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1293), 448548984, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1295) },
                    { 1144064408, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1335), 296423479, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1336) },
                    { 1144064408, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1309), 188086541, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1310) },
                    { 1539858576, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2278), 379287885, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2279) },
                    { 1539858576, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2266), 372751229, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2267) },
                    { 1539858576, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2241), 707533528, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2242) },
                    { 1539858576, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2216), 418274562, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2217) },
                    { 1539858576, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2254), 168361141, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2255) },
                    { 1539858576, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2228), 367762277, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2229) },
                    { 1791336448, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1438), 857786130, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1439) },
                    { 1791336448, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1425), 840745545, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1426) },
                    { 1791336448, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1399), 927517230, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1400) },
                    { 1791336448, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1374), 987564183, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1375) },
                    { 1791336448, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1413), 248937804, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1414) },
                    { 1791336448, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1387), 488791494, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1388) },
                    { 1847553840, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1972), 849800141, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1973) },
                    { 1847553840, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1957), 405359450, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1958) },
                    { 1847553840, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1932), 357008741, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1933) },
                    { 1847553840, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1907), 168871505, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1908) },
                    { 1847553840, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1945), 372846315, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1946) },
                    { 1847553840, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1920), 985287758, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1921) },
                    { 1959818176, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2125), 695643062, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2126) },
                    { 1959818176, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2111), 932896737, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2112) },
                    { 1959818176, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2086), 653630663, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2087) },
                    { 1959818176, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2061), 731252791, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2062) },
                    { 1959818176, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2099), 784863667, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2100) },
                    { 1959818176, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2074), 730442203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2075) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 2001318432, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2357), 596646718, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2358) },
                    { 2001318432, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2345), 214536560, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2346) },
                    { 2001318432, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2320), 573794710, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2321) },
                    { 2001318432, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2291), 759270183, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2292) },
                    { 2001318432, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2332), 991396276, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2333) },
                    { 2001318432, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2304), 481167921, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2305) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1981155536, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4271), 185747918, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4272) },
                    { -1981155536, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4234), 993255398, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4235) },
                    { -1981155536, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4247), 623112279, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4248) },
                    { -1981155536, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4222), 344337887, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4223) },
                    { -1981155536, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4259), 624619888, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4260) },
                    { -1981155536, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4210), 394709455, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4211) },
                    { -1714114600, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3600), 672311525, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3601) },
                    { -1714114600, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3563), 607323671, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3564) },
                    { -1714114600, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3575), 987363459, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3576) },
                    { -1714114600, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3551), 677236559, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3552) },
                    { -1714114600, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3587), 912285992, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3588) },
                    { -1714114600, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3538), 139338891, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3539) },
                    { -1531340552, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4122), 222930234, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4123) },
                    { -1531340552, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4081), 124440873, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4083) },
                    { -1531340552, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4097), 333639533, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4098) },
                    { -1531340552, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4069), 800344982, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4070) },
                    { -1531340552, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4110), 305575437, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4111) },
                    { -1531340552, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4057), 528836926, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4058) },
                    { -1248274128, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3673), 399917398, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3675) },
                    { -1248274128, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3637), 251320359, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3638) },
                    { -1248274128, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3649), 332312557, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3650) },
                    { -1248274128, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3625), 333137503, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3626) },
                    { -1248274128, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3661), 517589063, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3662) },
                    { -1248274128, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3612), 845588783, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3614) },
                    { -886261776, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3971), 779956240, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3972) },
                    { -886261776, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3935), 675383149, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3936) },
                    { -886261776, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3947), 570583381, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3948) },
                    { -886261776, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3922), 304359053, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3923) },
                    { -886261776, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3959), 286687890, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3960) },
                    { -886261776, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3910), 983855324, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3911) },
                    { -381151824, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3824), 380403910, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3825) },
                    { -381151824, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3787), 733285114, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3788) },
                    { -381151824, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3800), 791416064, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3801) },
                    { -381151824, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3774), 852529562, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3776) },
                    { -381151824, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3812), 224840596, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3813) },
                    { -381151824, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3762), 659284926, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3763) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -335832232, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3750), 506052370, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3751) },
                    { -335832232, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3710), 905491104, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3711) },
                    { -335832232, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3722), 202076186, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3724) },
                    { -335832232, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3698), 593212930, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3699) },
                    { -335832232, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3737), 837914502, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3738) },
                    { -335832232, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3686), 847775635, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3687) },
                    { 123023200, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4495), 129255815, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4496) },
                    { 123023200, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4458), 160795795, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4459) },
                    { 123023200, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4470), 201027625, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4471) },
                    { 123023200, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4446), 714634318, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4447) },
                    { 123023200, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4482), 946747494, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4483) },
                    { 123023200, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4434), 961927087, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4435) },
                    { 1105466696, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3898), 263228745, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3899) },
                    { 1105466696, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3861), 835276465, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3862) },
                    { 1105466696, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3873), 765575855, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3874) },
                    { 1105466696, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3849), 614449353, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3850) },
                    { 1105466696, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3886), 687876835, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3887) },
                    { 1105466696, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3836), 496402357, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3837) },
                    { 1144064408, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3451), 615932976, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3452) },
                    { 1144064408, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3413), 711516556, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3414) },
                    { 1144064408, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3425), 937533068, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3426) },
                    { 1144064408, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3400), 809939346, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3401) },
                    { 1144064408, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3437), 856774235, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3439) },
                    { 1144064408, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3383), 527463095, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3385) },
                    { 1539858576, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4345), 943497565, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4346) },
                    { 1539858576, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4308), 819247021, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4309) },
                    { 1539858576, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4320), 952699046, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4321) },
                    { 1539858576, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4296), 229900375, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4297) },
                    { 1539858576, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4333), 392088107, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4334) },
                    { 1539858576, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4284), 753164826, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4285) },
                    { 1791336448, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3525), 362757405, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3527) },
                    { 1791336448, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3488), 388526224, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3489) },
                    { 1791336448, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3501), 144931771, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3502) },
                    { 1791336448, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3476), 695617395, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3477) },
                    { 1791336448, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3513), 685152388, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3514) },
                    { 1791336448, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3463), 594090199, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3464) },
                    { 1847553840, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4045), 205614155, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4046) },
                    { 1847553840, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4008), 139772985, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4009) },
                    { 1847553840, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4020), 198953674, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4021) },
                    { 1847553840, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3996), 398063162, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3997) },
                    { 1847553840, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4033), 328217836, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4034) },
                    { 1847553840, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3983), 425040531, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3985) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1959818176, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4197), 644965068, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4198) },
                    { 1959818176, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4160), 555980366, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4161) },
                    { 1959818176, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4172), 167451865, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4173) },
                    { 1959818176, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4147), 319498148, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4149) },
                    { 1959818176, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4184), 541602723, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4185) },
                    { 1959818176, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4135), 721969514, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4136) },
                    { 2001318432, 168660241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4418), 326403016, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4419) },
                    { 2001318432, 218234740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4381), 213427654, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4383) },
                    { 2001318432, 667256909, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4394), 156432169, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4395) },
                    { 2001318432, 838370319, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4369), 536623311, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4370) },
                    { 2001318432, 927497449, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4406), 722096676, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4407) },
                    { 2001318432, 931917651, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4357), 878454056, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4358) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1981155536, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3157), 242556230, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3158) },
                    { -1981155536, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3169), 705019307, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3171) },
                    { -1981155536, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3145), 249940862, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3146) },
                    { -1981155536, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3182), 942021287, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3183) },
                    { -1981155536, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3133), 362592176, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3134) },
                    { -1714114600, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2602), 577412971, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2603) },
                    { -1714114600, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2614), 283399138, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2615) },
                    { -1714114600, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2590), 441628903, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2591) },
                    { -1714114600, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2626), 145066956, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2627) },
                    { -1714114600, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2577), 915105626, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2578) },
                    { -1531340552, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3036), 337877918, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3037) },
                    { -1531340552, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3048), 720808996, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3049) },
                    { -1531340552, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3021), 784783191, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3022) },
                    { -1531340552, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3060), 708338258, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3061) },
                    { -1531340552, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3009), 777718545, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3010) },
                    { -1248274128, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2664), 186006944, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2665) },
                    { -1248274128, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2679), 528211824, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2680) },
                    { -1248274128, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2651), 326246410, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2652) },
                    { -1248274128, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2691), 481751430, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2692) },
                    { -1248274128, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2639), 665846732, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2640) },
                    { -886261776, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2911), 940912088, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2912) },
                    { -886261776, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2923), 277041220, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2924) },
                    { -886261776, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2899), 627754264, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2900) },
                    { -886261776, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2935), 287566148, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2936) },
                    { -886261776, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2887), 696895126, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2888) },
                    { -381151824, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2789), 978244596, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2790) },
                    { -381151824, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2801), 130398144, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2802) },
                    { -381151824, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2776), 525302448, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2778) },
                    { -381151824, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2813), 130944604, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2814) },
                    { -381151824, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2764), 444305394, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2765) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -335832232, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2728), 621992207, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2729) },
                    { -335832232, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2740), 279142053, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2741) },
                    { -335832232, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2716), 799317080, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2717) },
                    { -335832232, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2752), 882672491, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2753) },
                    { -335832232, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2703), 852928921, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2705) },
                    { 123023200, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3342), 522035406, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3343) },
                    { 123023200, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3354), 661285579, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3355) },
                    { 123023200, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3329), 192483248, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3331) },
                    { 123023200, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3369), 483574895, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3370) },
                    { 123023200, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3317), 596170845, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3319) },
                    { 1105466696, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2849), 896768522, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2850) },
                    { 1105466696, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2863), 155986057, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2864) },
                    { 1105466696, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2837), 645081649, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2838) },
                    { 1105466696, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2875), 243834958, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2876) },
                    { 1105466696, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2825), 453617037, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2826) },
                    { 1144064408, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2477), 541415138, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2478) },
                    { 1144064408, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2489), 465867870, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2490) },
                    { 1144064408, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2464), 195078998, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2465) },
                    { 1144064408, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2501), 605708682, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2502) },
                    { 1144064408, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2447), 898803727, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2449) },
                    { 1539858576, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3219), 678415562, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3220) },
                    { 1539858576, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3231), 593043103, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3232) },
                    { 1539858576, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3207), 609868506, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3208) },
                    { 1539858576, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3243), 542458820, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3244) },
                    { 1539858576, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3194), 203995713, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3196) },
                    { 1791336448, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2540), 286946324, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2541) },
                    { 1791336448, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2552), 500862462, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2553) },
                    { 1791336448, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2527), 130959852, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2529) },
                    { 1791336448, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2565), 548803241, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2566) },
                    { 1791336448, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2515), 837494797, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2516) },
                    { 1847553840, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2972), 233878427, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2973) },
                    { 1847553840, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2984), 343506880, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2985) },
                    { 1847553840, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2960), 676509646, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2961) },
                    { 1847553840, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2996), 161494059, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2997) },
                    { 1847553840, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2948), 898565271, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(2949) },
                    { 1959818176, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3097), 560086456, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3098) },
                    { 1959818176, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3109), 759926677, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3110) },
                    { 1959818176, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3085), 617862418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3086) },
                    { 1959818176, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3121), 249456303, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3122) },
                    { 1959818176, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3072), 353343662, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3074) },
                    { 2001318432, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3281), 412168259, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3282) },
                    { 2001318432, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3293), 570424320, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3294) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 2001318432, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3269), 899256080, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3270) },
                    { 2001318432, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3305), 328512633, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3306) },
                    { 2001318432, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3257), 912640033, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(3258) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 168660241, 159500212, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5300), -1654903097, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5301) },
                    { 168660241, 215069513, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5288), 1637515463, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5289) },
                    { 168660241, 315039924, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5326), 171289324, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5327) },
                    { 168660241, 458085035, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5313), 692624570, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5314) },
                    { 168660241, 475376675, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5276), 787776539, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5277) },
                    { 168660241, 868149393, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5339), -663290612, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5340) },
                    { 218234740, 159500212, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5074), -742514084, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5075) },
                    { 218234740, 215069513, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5061), -1804470065, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5063) },
                    { 218234740, 315039924, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5099), -1256033330, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5100) },
                    { 218234740, 458085035, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5086), 2032984886, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5087) },
                    { 218234740, 475376675, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5049), -821772085, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5050) },
                    { 218234740, 868149393, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5112), 905863838, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5113) },
                    { 667256909, 159500212, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5149), -1353261185, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5150) },
                    { 667256909, 215069513, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5137), -357813913, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5138) },
                    { 667256909, 315039924, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5177), 1199406569, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5178) },
                    { 667256909, 458085035, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5164), 506663006, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5165) },
                    { 667256909, 475376675, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5125), -1745902885, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5126) },
                    { 667256909, 868149393, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5190), 1626939180, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5191) },
                    { 838370319, 159500212, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4998), 817682405, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5000) },
                    { 838370319, 215069513, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4986), -319954337, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4987) },
                    { 838370319, 315039924, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5025), -635370020, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5026) },
                    { 838370319, 458085035, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5012), -1839160399, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5013) },
                    { 838370319, 475376675, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4974), 2076437192, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4975) },
                    { 838370319, 868149393, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5037), -313095284, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5038) },
                    { 927497449, 159500212, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5226), -1434379945, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5227) },
                    { 927497449, 215069513, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5214), -58554557, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5215) },
                    { 927497449, 315039924, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5251), 1130216360, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5252) },
                    { 927497449, 458085035, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5239), 69439955, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5240) },
                    { 927497449, 475376675, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5202), -1801768810, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5203) },
                    { 927497449, 868149393, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5263), -1685580421, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(5264) },
                    { 931917651, 159500212, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4922), 1086274607, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4923) },
                    { 931917651, 215069513, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4910), -1942165210, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4911) },
                    { 931917651, 315039924, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4947), 1433530107, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4948) },
                    { 931917651, 458085035, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4935), 686941358, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4936) },
                    { 931917651, 475376675, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4894), 90144478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4896) },
                    { 931917651, 868149393, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4961), -666643643, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4962) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 159500212, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4691), -1470328568, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4692) },
                    { 215069513, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4679), -1261621183, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4680) },
                    { 315039924, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4715), -257124415, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4717) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458085035, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4703), 91210469, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4704) },
                    { 475376675, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4666), -444395384, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4667) },
                    { 868149393, -1069284228, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4729), -765873859, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4730) },
                    { 159500212, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4766), -1043233604, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4767) },
                    { 215069513, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4754), -1772980753, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4755) },
                    { 315039924, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4794), -43468181, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4795) },
                    { 458085035, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4778), 1822961484, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4779) },
                    { 475376675, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4741), -496481629, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4742) },
                    { 868149393, -1061517686, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4806), 713020973, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4808) },
                    { 159500212, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4616), 1460600064, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4617) },
                    { 215069513, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4604), -801325646, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4605) },
                    { 315039924, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4641), -534709322, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4642) },
                    { 458085035, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4629), 1226599245, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4630) },
                    { 475376675, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4591), -2034921734, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4593) },
                    { 868149393, -832913478, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4654), -1570257467, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4655) },
                    { 159500212, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4844), 1113272154, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4845) },
                    { 215069513, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4832), 1459571837, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4833) },
                    { 315039924, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4868), 333029237, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4869) },
                    { 458085035, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4856), -290007004, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4857) },
                    { 475376675, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4819), 1252216890, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4820) },
                    { 868149393, -298247977, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4881), 478081112, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4882) },
                    { 159500212, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4540), -964979608, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4541) },
                    { 215069513, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4527), 1562076486, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4528) },
                    { 315039924, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4565), 225457381, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4566) },
                    { 458085035, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4553), 994331021, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4554) },
                    { 475376675, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4508), 1840324973, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4510) },
                    { 868149393, 207326621, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4579), -2007878701, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(4580) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 352097613, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 7.0, 4, new DateTime(2024, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 4, "Test Description Project_10", "KL-2", new DateTime(2024, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), new DateTime(2024, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 0f, 100L, 12L, new DateTime(2024, 2, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), "Project_2", 5.0, new DateTime(2024, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), "Payment Detailes For Project_10", 2.0, null, 789679671, new DateTime(2024, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 0f },
                    { 606524418, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 9.0, 16, new DateTime(2025, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 16, "Test Description Project_8", "KL-4", new DateTime(2025, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), new DateTime(2025, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 0f, 100L, 12L, new DateTime(2024, 2, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), "Project_4", 5.0, new DateTime(2025, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), "Payment Detailes For Project_4", 4.0, null, 366087140, new DateTime(2025, 6, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 0f },
                    { 626069274, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 8.0, 9, new DateTime(2024, 11, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 9, "Test Description Project_9", "KL-3", new DateTime(2024, 11, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), new DateTime(2024, 11, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 0f, 100L, 12L, new DateTime(2024, 2, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), "Project_3", 5.0, new DateTime(2024, 11, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), "Payment Detailes For Project_3", 3.0, null, 406284144, new DateTime(2024, 11, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 0f },
                    { 658303236, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 6.0, 1, new DateTime(2024, 3, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 3, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), new DateTime(2024, 3, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 0f, 100L, 12L, new DateTime(2024, 2, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), "Project_1", 5.0, new DateTime(2024, 3, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), "Payment Detailes For Project_2", 1.0, null, 166724917, new DateTime(2024, 3, 27, 16, 46, 23, 56, DateTimeKind.Local).AddTicks(9675), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 700391396, 159500212, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9230), 545974885, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9231) },
                    { 599921922, 190269878, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9522), 256553943, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9523) },
                    { 599921922, 195882485, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9494), 706030300, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9496) },
                    { 700391396, 215069513, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9202), 157171161, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9203) },
                    { 700391396, 315039924, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9291), 890595140, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9292) },
                    { 599921922, 371507845, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9436), 521118986, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9437) },
                    { 700391396, 458085035, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9258), 427544374, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9259) },
                    { 700391396, 475376675, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9168), 562888501, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9169) },
                    { 511046484, 476584981, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9614), 854232231, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9615) },
                    { 511046484, 521646106, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9643), 383666030, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9644) },
                    { 511046484, 555478286, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9558), 606185296, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9559) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 599921922, 619922029, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9365), 326463045, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9366) },
                    { 511046484, 838055945, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9587), 489152932, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9588) },
                    { 700391396, 868149393, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9331), 231147667, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9332) },
                    { 599921922, 875168203, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9465), 933473456, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9466) },
                    { 511046484, 927667410, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9672), 649528714, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9673) },
                    { 599921922, 945172399, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9395), 543107901, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9396) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1981155536, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1103), -1288306317, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1104) },
                    { -1981155536, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1127), -1384748876, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1128) },
                    { -1981155536, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1115), 372264008, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1116) },
                    { -1981155536, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1090), 790878456, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1091) },
                    { -1714114600, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(650), 1333556370, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(651) },
                    { -1714114600, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(675), 898502584, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(676) },
                    { -1714114600, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(662), 1446714172, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(663) },
                    { -1714114600, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(636), -742290735, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(637) },
                    { -1531340552, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1003), 1913199327, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1004) },
                    { -1531340552, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1028), -1073132976, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1029) },
                    { -1531340552, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1015), 1392036831, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1016) },
                    { -1531340552, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(990), 646796816, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(992) },
                    { -1248274128, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(700), 211323208, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(701) },
                    { -1248274128, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(724), 1901117483, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(725) },
                    { -1248274128, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(712), 1263656764, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(713) },
                    { -1248274128, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(687), -1432959055, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(688) },
                    { -886261776, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(902), -1422583362, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(903) },
                    { -886261776, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(927), 1268068256, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(928) },
                    { -886261776, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(914), -1317503740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(915) },
                    { -886261776, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(890), -713550646, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(891) },
                    { -381151824, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(800), 865254572, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(801) },
                    { -381151824, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(824), -1415926316, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(825) },
                    { -381151824, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(812), -1036536258, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(813) },
                    { -381151824, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(787), 1532771868, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(788) },
                    { -335832232, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(750), 1719253136, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(751) },
                    { -335832232, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(775), 2087208722, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(776) },
                    { -335832232, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(763), -106764912, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(764) },
                    { -335832232, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(737), 401625389, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(738) },
                    { 123023200, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1255), -2111598752, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1256) },
                    { 123023200, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1280), -650922388, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1281) },
                    { 123023200, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1268), 238516811, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1269) },
                    { 123023200, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1243), 1263366756, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1244) },
                    { 1105466696, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(849), 525130703, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(850) },
                    { 1105466696, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(877), 270676591, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(878) },
                    { 1105466696, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(864), -1912259857, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(865) },
                    { 1105466696, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(837), -2067242226, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(838) },
                    { 1144064408, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(547), 345502246, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(548) },
                    { 1144064408, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(573), -1696996368, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(574) },
                    { 1144064408, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(560), -84926560, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(561) },
                    { 1144064408, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(530), -105490368, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(531) },
                    { 1539858576, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1152), -1291174585, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1154) },
                    { 1539858576, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1177), -523792790, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1178) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1539858576, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1165), -1464020078, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1166) },
                    { 1539858576, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1140), -252041601, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1141) },
                    { 1791336448, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(598), 611849552, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(600) },
                    { 1791336448, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(624), -1152615116, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(625) },
                    { 1791336448, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(611), 176109824, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(612) },
                    { 1791336448, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(585), 792735892, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(586) },
                    { 1847553840, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(953), 2083773496, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(954) },
                    { 1847553840, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(978), -1662173452, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(979) },
                    { 1847553840, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(966), -1564744085, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(967) },
                    { 1847553840, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(939), -1984569320, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(941) },
                    { 1959818176, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1053), 281075642, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1054) },
                    { 1959818176, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1078), -1830550524, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1079) },
                    { 1959818176, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1065), 1920261768, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1066) },
                    { 1959818176, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1040), 1604466916, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1041) },
                    { 2001318432, 352097613, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1202), -1982379551, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1203) },
                    { 2001318432, 606524418, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1230), 809435232, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1231) },
                    { 2001318432, 626069274, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1214), -1092028894, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1215) },
                    { 2001318432, 658303236, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1190), -199489754, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(1191) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 140729381, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(95), new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(97), 3100.0, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(96), "Signature 1423412", 38975, 352097613, 2.0, 24.0 },
                    { 186806490, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(228), new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(230), 13000.0, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(229), "Signature 142348", 83911, 606524418, 4.0, 24.0 },
                    { 871216771, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(163), new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(165), 4000.0, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(164), "Signature 142343", 56314, 626069274, 3.0, 17.0 },
                    { 926178407, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(20), new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(23), 3010.0, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(21), "Signature 142343", 28708, 658303236, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 626069274, 476584981, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(502), 795128681, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(504) },
                    { 606524418, 521646106, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(515), 137172679, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(517) },
                    { 658303236, 555478286, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(466), 837743549, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(468) },
                    { 352097613, 838055945, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(485), 429033678, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(486) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 210821123, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(132), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(133), null, "6949277783", null, null, 626069274 },
                    { 320205539, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(200), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(201), null, "6949277784", null, null, 606524418 },
                    { 619621571, new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9988), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 27, 16, 46, 23, 61, DateTimeKind.Local).AddTicks(9989), null, "6949277781", null, null, 658303236 },
                    { 899676510, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(67), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(68), null, "6949277782", null, null, 352097613 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 760497515, 210821123, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(147), 652287740, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(148) },
                    { 760497515, 320205539, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(215), 239384700, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(216) },
                    { 760497515, 619621571, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(6), 963113785, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(7) },
                    { 760497515, 899676510, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(82), 217484985, new DateTime(2024, 2, 27, 16, 46, 23, 62, DateTimeKind.Local).AddTicks(83) }
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
