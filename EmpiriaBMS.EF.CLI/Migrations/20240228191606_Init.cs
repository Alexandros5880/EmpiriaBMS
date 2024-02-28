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
                name: "CorporateEventTime",
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
                    table.PrimaryKey("PK_CorporateEventTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateEventTime_TimeSpans_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "TimeSpans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ParsonalTime",
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
                    table.PrimaryKey("PK_ParsonalTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParsonalTime_TimeSpans_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "TimeSpans",
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
                name: "TrainingTime",
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
                    table.PrimaryKey("PK_TrainingTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingTime_TimeSpans_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "TimeSpans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingTime_Users_UserId",
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
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "Name", "UserId" },
                values: new object[,]
                {
                    { -2007990576, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2936), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2937), "Outsource", null },
                    { -1999036440, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2847), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2848), "Structured Cabling", null },
                    { -1898516064, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2783), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2785), "Fire Suppression", null },
                    { -1870963320, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2829), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2830), "Power Distribution", null },
                    { -1570489856, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2814), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2815), "Natural Gas", null },
                    { -1513982720, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2907), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2908), "Photovoltaics", null },
                    { -1405060984, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2735), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2737), "Potable Water", null },
                    { -620807336, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2799), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2801), "Elevators", null },
                    { -86792240, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2720), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2721), "Sewage", null },
                    { 111912448, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2701), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2702), "HVAC", null },
                    { 523562088, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2863), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2864), "Burglar Alarm", null },
                    { 900049480, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2751), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2752), "Drainage", null },
                    { 1480018968, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2892), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2893), "BMS", null },
                    { 1689702888, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2950), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2952), "TenderDocument", null },
                    { 1693393824, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2877), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2879), "CCTV", null },
                    { 1726809992, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2921), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2923), "Energy Efficiency", null },
                    { 2052311248, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2765), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2767), "Fire Detection", null },
                    { 2140099392, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2970), 0f, 1500L, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2972), "Construction Supervision", null }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 331914977, new DateTime(2024, 3, 10, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2367), 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2365), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2366), "Drawings" },
                    { 659753684, new DateTime(2024, 3, 10, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2352), 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2349), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2350), "Calculations" },
                    { 762764451, new DateTime(2024, 3, 10, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2329), 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2325), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2327), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 631153504, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2259), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2260), "Printing" },
                    { 768075970, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2239), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2240), "Communications" },
                    { 781873963, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2307), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2308), "Administration" },
                    { 842898825, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2273), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2274), "On-Site" },
                    { 1752660596, 0f, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2287), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2289), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 702323899, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2076), "Energy Description", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2077), "Energy" },
                    { 706478843, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2044), "Buildings Description", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2045), "Buildings" },
                    { 937926883, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2061), "Infrastructure Description", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2062), "Infrastructure" },
                    { 966487542, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2090), "Consulting Description", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2091), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 243956137, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1337), false, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1338), "Guest" },
                    { 297409211, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1302), true, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1303), "Project Manager" },
                    { 306817322, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1317), true, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1319), "CTO" },
                    { 462428423, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1310), true, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1311), "COO" },
                    { 554320542, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1344), false, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1345), "Customer" },
                    { 588767442, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1324), true, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1326), "CEO" },
                    { 690897887, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1286), true, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1288), "Designer" },
                    { 730524324, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1295), true, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1296), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1910), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1911), null, "6949277782", null, null, null },
                    { 274175377, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1773), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1774), null, "6949277784", null, null, null },
                    { 339462383, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2208), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2209), null, "6949277784", null, null, null },
                    { 376449392, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1680), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1681), null, "6949277781", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 383750931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1582), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1584), null, "694927778", null, null, null },
                    { 403215309, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1612), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1614), null, "6949277780", null, null, null },
                    { 438234797, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2110), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2111), null, "6949277781", null, null, null },
                    { 488770571, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1521), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1522), null, "694927778", null, null, null },
                    { 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2014), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2015), null, "6949277785", null, null, null },
                    { 539854723, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1711), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1712), null, "6949277782", null, null, null },
                    { 556837039, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2178), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2179), null, "6949277783", null, null, null },
                    { 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1838), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1840), null, "6949277780", null, null, null },
                    { 704855736, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1744), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1745), null, "6949277783", null, null, null },
                    { 773579979, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1807), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1808), null, "6949277785", null, null, null },
                    { 793099032, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1553), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1554), null, "694927778", null, null, null },
                    { 888610387, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1476), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1477), null, "694927778", null, null, null },
                    { 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1879), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1881), null, "6949277781", null, null, null },
                    { 942329530, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2148), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2149), null, "6949277782", null, null, null },
                    { 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1940), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1941), null, "6949277783", null, null, null },
                    { 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1980), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1981), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2007990576, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5193), 650250744, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5194) },
                    { -2007990576, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5231), 419899213, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5232) },
                    { -2007990576, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5167), 751247425, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5168) },
                    { -2007990576, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5180), 768301190, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5182) },
                    { -2007990576, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5206), 512578090, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5207) },
                    { -2007990576, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5218), 474454356, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5219) },
                    { -1999036440, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4725), 780655137, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4726) },
                    { -1999036440, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4763), 130996638, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4764) },
                    { -1999036440, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4699), 745074445, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4700) },
                    { -1999036440, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4712), 959571104, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4713) },
                    { -1999036440, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4738), 321683805, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4739) },
                    { -1999036440, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4750), 432559873, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4751) },
                    { -1898516064, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4409), 935104282, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4410) },
                    { -1898516064, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4452), 230442499, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4454) },
                    { -1898516064, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4384), 274122946, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4385) },
                    { -1898516064, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4396), 733395207, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4398) },
                    { -1898516064, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4426), 590573342, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4427) },
                    { -1898516064, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4439), 153882847, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4440) },
                    { -1870963320, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4647), 792727559, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4648) },
                    { -1870963320, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4686), 217700414, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4687) },
                    { -1870963320, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4622), 331397770, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4623) },
                    { -1870963320, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4634), 886516331, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4635) },
                    { -1870963320, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4660), 859794272, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4661) },
                    { -1870963320, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4673), 892634568, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4675) },
                    { -1570489856, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4570), 741100246, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4571) },
                    { -1570489856, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4608), 875960765, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4610) },
                    { -1570489856, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4544), 850746484, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4545) },
                    { -1570489856, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4557), 539121350, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4558) },
                    { -1570489856, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4583), 916760587, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4584) },
                    { -1570489856, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4595), 219493224, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4597) },
                    { -1513982720, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5037), 790760164, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5038) },
                    { -1513982720, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5076), 313843288, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5077) },
                    { -1513982720, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5011), 585699172, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5013) },
                    { -1513982720, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5025), 175270362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5026) },
                    { -1513982720, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5050), 809529003, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5051) },
                    { -1513982720, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5063), 845183170, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5064) },
                    { -1405060984, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4177), 154917655, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4178) },
                    { -1405060984, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4217), 255210068, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4218) },
                    { -1405060984, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4152), 362617418, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4153) },
                    { -1405060984, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4165), 257811817, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4166) },
                    { -1405060984, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4190), 510613116, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4192) },
                    { -1405060984, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4203), 664035029, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4204) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -620807336, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4492), 816286032, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4493) },
                    { -620807336, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4531), 754010625, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4533) },
                    { -620807336, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4466), 840125827, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4467) },
                    { -620807336, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4479), 747691113, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4480) },
                    { -620807336, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4505), 389489990, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4506) },
                    { -620807336, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4518), 253077697, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4519) },
                    { -86792240, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4100), 127500290, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4101) },
                    { -86792240, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4140), 144998437, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4141) },
                    { -86792240, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4073), 888808747, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4074) },
                    { -86792240, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4087), 754712287, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4088) },
                    { -86792240, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4114), 562510897, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4115) },
                    { -86792240, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4127), 171856047, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4128) },
                    { 111912448, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4017), 798907519, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4018) },
                    { 111912448, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4059), 133983823, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4061) },
                    { 111912448, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3986), 857287174, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3987) },
                    { 111912448, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4004), 507169031, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4005) },
                    { 111912448, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4029), 156117634, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4030) },
                    { 111912448, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4045), 348004383, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4046) },
                    { 523562088, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4804), 681109786, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4805) },
                    { 523562088, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4845), 748305336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4846) },
                    { 523562088, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4776), 933228138, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4777) },
                    { 523562088, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4788), 426383092, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4789) },
                    { 523562088, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4818), 461380151, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4819) },
                    { 523562088, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4831), 323584666, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4832) },
                    { 900049480, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4255), 774389202, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4256) },
                    { 900049480, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4293), 505090728, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4294) },
                    { 900049480, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4230), 525536908, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4231) },
                    { 900049480, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4242), 357687386, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4244) },
                    { 900049480, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4268), 483453577, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4269) },
                    { 900049480, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4280), 793906966, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4281) },
                    { 1480018968, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4960), 599084899, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4961) },
                    { 1480018968, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4998), 542656774, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4999) },
                    { 1480018968, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4934), 512554473, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4936) },
                    { 1480018968, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4947), 839602202, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4948) },
                    { 1480018968, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4973), 555279754, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4974) },
                    { 1480018968, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4986), 528088304, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4987) },
                    { 1689702888, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5270), 334003605, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5271) },
                    { 1689702888, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5308), 423809741, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5309) },
                    { 1689702888, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5244), 503508150, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5245) },
                    { 1689702888, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5257), 342797641, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5258) },
                    { 1689702888, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5283), 505415438, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5284) },
                    { 1689702888, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5296), 608271114, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5297) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1693393824, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4884), 640342954, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4885) },
                    { 1693393824, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4922), 493094776, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4923) },
                    { 1693393824, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4858), 851424344, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4860) },
                    { 1693393824, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4871), 366464091, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4872) },
                    { 1693393824, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4896), 822448380, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4898) },
                    { 1693393824, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4909), 227544243, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4910) },
                    { 1726809992, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5114), 211213547, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5115) },
                    { 1726809992, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5155), 379560492, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5156) },
                    { 1726809992, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5089), 746272773, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5090) },
                    { 1726809992, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5101), 905628242, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5102) },
                    { 1726809992, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5127), 266157786, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5128) },
                    { 1726809992, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5139), 153077455, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5140) },
                    { 2052311248, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4332), 897535138, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4333) },
                    { 2052311248, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4371), 193519458, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4372) },
                    { 2052311248, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4305), 199127393, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4306) },
                    { 2052311248, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4318), 243308541, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4320) },
                    { 2052311248, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4344), 420086100, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4345) },
                    { 2052311248, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4358), 704604489, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(4359) },
                    { 2140099392, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5347), 839114042, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5348) },
                    { 2140099392, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5385), 332971877, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5386) },
                    { 2140099392, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5321), 772745645, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5323) },
                    { 2140099392, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5334), 215626181, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5335) },
                    { 2140099392, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5360), 443196817, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5361) },
                    { 2140099392, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5372), 434462295, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5374) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2007990576, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7144), 256803969, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7146) },
                    { -2007990576, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7132), 933422585, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7133) },
                    { -2007990576, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7120), 363754746, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7121) },
                    { -1999036440, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6919), 967330094, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6920) },
                    { -1999036440, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6907), 709169989, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6908) },
                    { -1999036440, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6895), 231307393, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6896) },
                    { -1898516064, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6771), 890713568, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6772) },
                    { -1898516064, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6758), 779598736, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6759) },
                    { -1898516064, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6746), 828323804, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6747) },
                    { -1870963320, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6882), 719417790, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6883) },
                    { -1870963320, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6870), 984747582, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6871) },
                    { -1870963320, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6858), 481867069, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6859) },
                    { -1570489856, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6846), 994928396, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6847) },
                    { -1570489856, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6833), 554765838, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6835) },
                    { -1570489856, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6821), 680845148, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6822) },
                    { -1513982720, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7071), 598296176, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7072) },
                    { -1513982720, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7059), 536736988, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7060) },
                    { -1513982720, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7046), 995752490, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7048) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1405060984, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6658), 903394418, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6659) },
                    { -1405060984, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6646), 610633675, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6647) },
                    { -1405060984, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6633), 745519474, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6634) },
                    { -620807336, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6809), 816454382, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6810) },
                    { -620807336, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6797), 594554001, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6798) },
                    { -620807336, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6784), 129727033, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6785) },
                    { -86792240, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6617), 959015902, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6618) },
                    { -86792240, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6603), 147730933, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6604) },
                    { -86792240, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6591), 276782293, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6592) },
                    { 111912448, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6578), 780492676, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6579) },
                    { 111912448, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6565), 981443597, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6566) },
                    { 111912448, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6545), 703646603, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6546) },
                    { 523562088, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6956), 804103026, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6957) },
                    { 523562088, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6944), 128823957, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6945) },
                    { 523562088, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6932), 646888920, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6933) },
                    { 900049480, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6696), 703416060, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6697) },
                    { 900049480, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6684), 296535474, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6685) },
                    { 900049480, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6671), 152529691, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6672) },
                    { 1480018968, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7034), 611854677, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7035) },
                    { 1480018968, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7022), 678595669, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7023) },
                    { 1480018968, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7009), 305503729, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7011) },
                    { 1689702888, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7181), 919912064, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7182) },
                    { 1689702888, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7169), 653256986, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7170) },
                    { 1689702888, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7157), 386332024, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7158) },
                    { 1693393824, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6997), 318636227, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6998) },
                    { 1693393824, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6984), 559460338, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6986) },
                    { 1693393824, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6972), 174227589, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6973) },
                    { 1726809992, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7108), 362712103, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7109) },
                    { 1726809992, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7095), 379500859, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7097) },
                    { 1726809992, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7083), 589733504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7084) },
                    { 2052311248, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6733), 555880732, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6734) },
                    { 2052311248, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6721), 630679772, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6722) },
                    { 2052311248, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6709), 621673869, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6710) },
                    { 2140099392, 331914977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7217), 818555349, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7218) },
                    { 2140099392, 659753684, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7205), 430732795, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7206) },
                    { 2140099392, 762764451, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7193), 400942659, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7194) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2007990576, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6369), 841296199, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6371) },
                    { -2007990576, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6357), 826045168, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6358) },
                    { -2007990576, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6407), 901378729, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6408) },
                    { -2007990576, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6382), 370230707, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6383) },
                    { -2007990576, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6394), 988200977, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6395) },
                    { -1999036440, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5992), 374740759, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5993) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1999036440, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5980), 870877417, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5981) },
                    { -1999036440, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6029), 514975970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6030) },
                    { -1999036440, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6005), 501773706, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6006) },
                    { -1999036440, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6017), 701299598, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6018) },
                    { -1898516064, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5741), 652848435, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5742) },
                    { -1898516064, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5728), 777182469, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5729) },
                    { -1898516064, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5778), 675698856, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5779) },
                    { -1898516064, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5753), 679305216, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5754) },
                    { -1898516064, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5765), 973090646, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5766) },
                    { -1870963320, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5931), 468814130, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5932) },
                    { -1870963320, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5918), 286891260, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5920) },
                    { -1870963320, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5967), 678412204, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5968) },
                    { -1870963320, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5943), 224444736, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5944) },
                    { -1870963320, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5955), 253546009, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5956) },
                    { -1570489856, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5865), 715979534, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5866) },
                    { -1570489856, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5853), 593721892, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5854) },
                    { -1570489856, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5905), 395705041, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5906) },
                    { -1570489856, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5877), 678529470, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5879) },
                    { -1570489856, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5890), 700089968, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5891) },
                    { -1513982720, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6244), 510445316, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6245) },
                    { -1513982720, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6228), 777012514, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6229) },
                    { -1513982720, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6282), 428744529, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6284) },
                    { -1513982720, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6257), 754477779, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6258) },
                    { -1513982720, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6270), 778215185, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6271) },
                    { -1405060984, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5554), 342510819, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5555) },
                    { -1405060984, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5538), 583107199, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5539) },
                    { -1405060984, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5592), 343861484, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5593) },
                    { -1405060984, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5567), 900042892, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5568) },
                    { -1405060984, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5579), 713504843, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5580) },
                    { -620807336, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5802), 250318034, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5803) },
                    { -620807336, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5790), 426236608, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5791) },
                    { -620807336, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5840), 860403903, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5842) },
                    { -620807336, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5815), 274685634, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5816) },
                    { -620807336, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5828), 654937472, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5829) },
                    { -86792240, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5487), 301583632, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5488) },
                    { -86792240, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5474), 624158094, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5475) },
                    { -86792240, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5525), 267733276, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5526) },
                    { -86792240, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5499), 416345133, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5501) },
                    { -86792240, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5512), 541196033, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5513) },
                    { 111912448, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5421), 508796499, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5422) },
                    { 111912448, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5404), 223198611, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5405) },
                    { 111912448, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5460), 611377260, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5461) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 111912448, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5435), 253357412, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5436) },
                    { 111912448, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5447), 650662660, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5449) },
                    { 523562088, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6054), 674913960, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6055) },
                    { 523562088, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6041), 128694195, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6043) },
                    { 523562088, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6091), 234726705, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6092) },
                    { 523562088, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6066), 399423718, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6067) },
                    { 523562088, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6079), 677202067, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6080) },
                    { 900049480, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5616), 395089081, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5618) },
                    { 900049480, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5604), 933069463, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5605) },
                    { 900049480, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5655), 693119405, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5656) },
                    { 900049480, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5630), 259824616, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5631) },
                    { 900049480, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5642), 418076407, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5644) },
                    { 1480018968, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6177), 681530638, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6178) },
                    { 1480018968, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6165), 456233383, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6166) },
                    { 1480018968, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6214), 974846596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6215) },
                    { 1480018968, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6189), 646946622, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6190) },
                    { 1480018968, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6202), 942572519, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6203) },
                    { 1689702888, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6431), 191400496, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6432) },
                    { 1689702888, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6419), 337685390, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6420) },
                    { 1689702888, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6469), 489269086, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6470) },
                    { 1689702888, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6444), 507034729, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6445) },
                    { 1689702888, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6456), 794940485, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6457) },
                    { 1693393824, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6116), 781075270, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6117) },
                    { 1693393824, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6103), 249246446, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6104) },
                    { 1693393824, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6152), 207470285, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6154) },
                    { 1693393824, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6128), 703100144, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6129) },
                    { 1693393824, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6140), 294217140, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6141) },
                    { 1726809992, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6307), 610816737, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6308) },
                    { 1726809992, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6295), 595971849, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6296) },
                    { 1726809992, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6345), 543209293, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6346) },
                    { 1726809992, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6320), 935929102, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6321) },
                    { 1726809992, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6332), 741331584, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6333) },
                    { 2052311248, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5679), 938320103, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5680) },
                    { 2052311248, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5667), 339335666, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5668) },
                    { 2052311248, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5716), 573596819, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5717) },
                    { 2052311248, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5691), 467465509, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5693) },
                    { 2052311248, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5704), 578439326, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(5705) },
                    { 2140099392, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6493), 555674997, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6495) },
                    { 2140099392, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6481), 211307295, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6482) },
                    { 2140099392, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6530), 499750198, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6532) },
                    { 2140099392, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6506), 408502454, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6507) },
                    { 2140099392, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6518), 644174268, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(6519) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 331914977, 274175377, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7823), -1244072051, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7824) },
                    { 331914977, 376449392, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7788), -1681951477, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7789) },
                    { 331914977, 403215309, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7776), -577941844, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7777) },
                    { 331914977, 539854723, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7799), 2021872307, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7801) },
                    { 331914977, 704855736, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7811), -1175282675, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7812) },
                    { 331914977, 773579979, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7836), 1926592601, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7837) },
                    { 659753684, 274175377, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7751), -1540041313, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7753) },
                    { 659753684, 376449392, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7712), -593894375, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7713) },
                    { 659753684, 403215309, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7700), 865153157, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7701) },
                    { 659753684, 539854723, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7726), 1149613241, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7728) },
                    { 659753684, 704855736, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7739), 1897340333, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7740) },
                    { 659753684, 773579979, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7764), -932714590, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7765) },
                    { 762764451, 274175377, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7674), 1194482345, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7676) },
                    { 762764451, 376449392, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7639), -1957420781, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7640) },
                    { 762764451, 403215309, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7623), 490605962, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7625) },
                    { 762764451, 539854723, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7651), -620586427, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7652) },
                    { 762764451, 704855736, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7663), -1189307195, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7664) },
                    { 762764451, 773579979, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7687), 1687401851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7689) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 274175377, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7369), 2002803786, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7370) },
                    { 376449392, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7328), -1432206373, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7329) },
                    { 403215309, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7315), -442515302, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7316) },
                    { 539854723, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7341), 1362078909, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7342) },
                    { 704855736, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7357), 37340632, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7358) },
                    { 773579979, 631153504, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7382), 2069950293, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7383) },
                    { 274175377, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7288), -1142996134, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7289) },
                    { 376449392, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7249), -212558336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7251) },
                    { 403215309, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7231), 1136099043, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7232) },
                    { 539854723, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7263), -222792209, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7264) },
                    { 704855736, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7275), 1223276594, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7277) },
                    { 773579979, 768075970, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7302), -1395275791, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7303) },
                    { 274175377, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7597), -360457811, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7599) },
                    { 376449392, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7559), -84543830, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7560) },
                    { 403215309, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7546), -2045180002, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7547) },
                    { 539854723, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7571), -686780851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7572) },
                    { 704855736, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7585), -652709753, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7586) },
                    { 773579979, 781873963, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7610), 3813440, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7611) },
                    { 274175377, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7444), -545725336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7446) },
                    { 376449392, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7407), 1272136986, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7408) },
                    { 403215309, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7394), 1101917174, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7396) },
                    { 539854723, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7419), -1253050208, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7420) },
                    { 704855736, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7432), -1819804994, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7433) },
                    { 773579979, 842898825, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7458), 294497461, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7459) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 274175377, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7521), -965117771, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7522) },
                    { 376449392, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7483), 223048576, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7485) },
                    { 403215309, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7471), 1420239236, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7472) },
                    { 539854723, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7496), -268121024, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7498) },
                    { 704855736, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7509), -1924414834, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7510) },
                    { 773579979, 1752660596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7534), 23781781, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(7535) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 123968127, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 7.0, 4, new DateTime(2024, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 4, "Test Description Project_6", "KL-2", new DateTime(2024, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), new DateTime(2024, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 0f, 100L, 12L, new DateTime(2024, 2, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), "Project_2", 5.0, new DateTime(2024, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), "Payment Detailes For Project_2", 2.0, null, 937926883, new DateTime(2024, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 0f },
                    { 530666336, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 8.0, 9, new DateTime(2024, 11, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 9, "Test Description Project_3", "KL-3", new DateTime(2024, 11, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), new DateTime(2024, 11, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 0f, 100L, 12L, new DateTime(2024, 2, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), "Project_3", 5.0, new DateTime(2024, 11, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), "Payment Detailes For Project_6", 3.0, null, 702323899, new DateTime(2024, 11, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 0f },
                    { 612011868, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 6.0, 1, new DateTime(2024, 3, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 1, "Test Description Project_5", "KL-1", new DateTime(2024, 3, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), new DateTime(2024, 3, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 0f, 100L, 12L, new DateTime(2024, 2, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), "Project_1", 5.0, new DateTime(2024, 3, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), "Payment Detailes For Project_5", 1.0, null, 706478843, new DateTime(2024, 3, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 0f },
                    { 932706931, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 9.0, 16, new DateTime(2025, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 16, "Test Description Project_4", "KL-4", new DateTime(2025, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), new DateTime(2025, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 0f, 100L, 12L, new DateTime(2024, 2, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), "Project_4", 5.0, new DateTime(2025, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), "Payment Detailes For Project_12", 4.0, null, 966487542, new DateTime(2025, 6, 28, 21, 16, 5, 814, DateTimeKind.Local).AddTicks(7143), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 730524324, 253038054, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1927), 979375388, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1928) },
                    { 690897887, 274175377, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1792), 569244607, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1793) },
                    { 297409211, 339462383, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2224), 597243400, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2225) },
                    { 690897887, 376449392, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1697), 590345365, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1698) },
                    { 243956137, 383750931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1597), 946714169, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1598) },
                    { 690897887, 403215309, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1665), 189048770, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1666) },
                    { 297409211, 438234797, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2132), 849016936, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2133) },
                    { 306817322, 488770571, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1538), 724639789, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1539) },
                    { 730524324, 522508851, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2030), 777597804, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2031) },
                    { 690897887, 539854723, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1731), 973889596, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1732) },
                    { 297409211, 556837039, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2194), 319463753, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2195) },
                    { 730524324, 693104787, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1865), 765379213, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1866) },
                    { 690897887, 704855736, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1760), 158474852, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1761) },
                    { 690897887, 773579979, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1824), 392050949, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1825) },
                    { 462428423, 793099032, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1568), 708431324, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1569) },
                    { 588767442, 888610387, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1499), 989445452, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1500) },
                    { 730524324, 926689839, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1896), 368863824, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1897) },
                    { 297409211, 942329530, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2164), 882207483, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2165) },
                    { 730524324, 966256649, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1967), 855950094, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(1968) },
                    { 730524324, 993374362, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2000), 604819259, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2001) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2007990576, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3845), 593565622, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3846) },
                    { -2007990576, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3857), -909904188, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3858) },
                    { -2007990576, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3832), -939395708, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3833) },
                    { -2007990576, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3870), -1239107608, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3871) },
                    { -1999036440, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3540), -1439721799, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3541) },
                    { -1999036440, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3552), -1385677328, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3553) },
                    { -1999036440, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3527), 1302272129, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3529) },
                    { -1999036440, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3565), 2113644164, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3566) },
                    { -1898516064, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3335), 1253947832, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3336) },
                    { -1898516064, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3348), 2035745689, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3350) },
                    { -1898516064, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3319), -1707435212, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3320) },
                    { -1898516064, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3361), -1558913748, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3362) },
                    { -1870963320, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3490), 695773287, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3491) },
                    { -1870963320, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3502), 198987256, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3503) },
                    { -1870963320, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3476), 2003204302, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3477) },
                    { -1870963320, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3515), 2092254088, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3516) },
                    { -1570489856, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3438), 1693516636, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3439) },
                    { -1570489856, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3451), -960463408, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3452) },
                    { -1570489856, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3425), -366287068, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3426) },
                    { -1570489856, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3463), -1026190777, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3464) },
                    { -1513982720, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3745), -484964366, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3746) },
                    { -1513982720, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3758), -768581204, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3759) },
                    { -1513982720, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3733), -1721629672, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3734) },
                    { -1513982720, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3770), 33864292, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3771) },
                    { -1405060984, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3174), 1697366685, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3175) },
                    { -1405060984, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3188), 1635085539, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3189) },
                    { -1405060984, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3160), 42416176, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3161) },
                    { -1405060984, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3200), -243587954, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3202) },
                    { -620807336, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3387), 1526847531, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3388) },
                    { -620807336, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3400), 1106116188, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3401) },
                    { -620807336, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3374), 1466400848, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3375) },
                    { -620807336, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3412), -1129739621, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3413) },
                    { -86792240, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3121), 2027908221, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3122) },
                    { -86792240, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3134), 1550453574, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3135) },
                    { -86792240, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3107), 1065515640, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3108) },
                    { -86792240, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3147), -1305833592, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3148) },
                    { 111912448, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3068), 1785541691, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3069) },
                    { 111912448, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3081), 2049764802, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3082) },
                    { 111912448, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3050), -1167147304, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3051) },
                    { 111912448, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3094), 1389138016, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3095) },
                    { 523562088, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3590), -1729259106, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3591) },
                    { 523562088, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3602), 398247841, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3603) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 523562088, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3577), 870342274, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3578) },
                    { 523562088, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3614), -312307508, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3615) },
                    { 900049480, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3227), 341939978, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3228) },
                    { 900049480, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3239), 977195188, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3241) },
                    { 900049480, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3214), 348006702, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3215) },
                    { 900049480, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3252), -11428245, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3254) },
                    { 1480018968, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3691), -172491866, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3692) },
                    { 1480018968, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3707), -350165184, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3709) },
                    { 1480018968, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3679), -1041094608, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3680) },
                    { 1480018968, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3720), -267775912, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3721) },
                    { 1689702888, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3896), 1830067638, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3897) },
                    { 1689702888, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3908), -346602212, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3910) },
                    { 1689702888, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3882), -1760611648, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3883) },
                    { 1689702888, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3921), 2060162381, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3923) },
                    { 1693393824, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3640), -229089418, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3641) },
                    { 1693393824, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3653), 1017748544, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3654) },
                    { 1693393824, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3627), -1927874446, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3628) },
                    { 1693393824, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3666), 1178830208, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3667) },
                    { 1726809992, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3795), -265792181, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3796) },
                    { 1726809992, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3807), 1068202566, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3808) },
                    { 1726809992, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3783), -1696482462, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3784) },
                    { 1726809992, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3820), 1740588731, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3821) },
                    { 2052311248, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3280), -603874048, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3281) },
                    { 2052311248, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3293), -606387260, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3294) },
                    { 2052311248, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3265), -1299428992, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3267) },
                    { 2052311248, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3306), 777008412, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3307) },
                    { 2140099392, 123968127, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3947), -62010968, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3948) },
                    { 2140099392, 530666336, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3959), 927819024, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3961) },
                    { 2140099392, 612011868, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3934), -1926862952, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3935) },
                    { 2140099392, 932706931, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3972), 578687988, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3973) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 505719332, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2460), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2464), 3010.0, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2462), "Signature 142344", 26117, 612011868, 1.0, 17.0 },
                    { 700067841, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2539), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2542), 3100.0, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2540), "Signature 1423410", 44915, 123968127, 2.0, 24.0 },
                    { 834596481, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2682), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2684), 13000.0, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2683), "Signature 142348", 39650, 932706931, 4.0, 24.0 },
                    { 948454677, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2613), new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2615), 4000.0, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2614), "Signature 142343", 35265, 530666336, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 932706931, 339462383, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3034), 988301515, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3036) },
                    { 612011868, 438234797, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2987), 543949071, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2988) },
                    { 530666336, 556837039, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3021), 275227075, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3023) },
                    { 123968127, 942329530, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3008), 293815719, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(3009) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 472704000, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2651), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2652), null, "6949277784", null, null, 932706931 },
                    { 659313049, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2425), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2426), null, "6949277781", null, null, 612011868 },
                    { 711228106, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2579), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2580), null, "6949277783", null, null, 530666336 },
                    { 752310351, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2508), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2509), null, "6949277782", null, null, 123968127 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 554320542, 472704000, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2668), 615295221, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2669) },
                    { 554320542, 659313049, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2445), 343562484, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2447) },
                    { 554320542, 711228106, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2596), 843699081, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2597) },
                    { 554320542, 752310351, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2525), 230150628, new DateTime(2024, 2, 28, 21, 16, 5, 820, DateTimeKind.Local).AddTicks(2527) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorporateEventTime_TimeSpanId",
                table: "CorporateEventTime",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateEventTime_UserId",
                table: "CorporateEventTime",
                column: "UserId");

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
                name: "IX_ParsonalTime_TimeSpanId",
                table: "ParsonalTime",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_ParsonalTime_UserId",
                table: "ParsonalTime",
                column: "UserId");

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
                name: "IX_TrainingTime_TimeSpanId",
                table: "TrainingTime",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTime_UserId",
                table: "TrainingTime",
                column: "UserId");

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
                name: "FK_CorporateEventTime_Users_UserId",
                table: "CorporateEventTime",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ParsonalTime_Users_UserId",
                table: "ParsonalTime",
                column: "UserId",
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
                name: "CorporateEventTime");

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
                name: "ParsonalTime");

            migrationBuilder.DropTable(
                name: "ProjectsPmanagers");

            migrationBuilder.DropTable(
                name: "TrainingTime");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Drawings");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "TimeSpans");

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
