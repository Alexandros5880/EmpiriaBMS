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
                name: "DisciplineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineTypes", x => x.Id);
                });

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
                        name: "FK_DisciplinesOthers_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
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
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedCompleted = table.Column<float>(type: "real", nullable: false),
                    Completed = table.Column<float>(type: "real", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_DisciplineTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DisciplineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplines_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplines_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_DisciplineEngineer_Users_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "DisciplineTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 155468684, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7727), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7729), "Photovoltaics" },
                    { 195288324, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7630), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7631), "Elevators" },
                    { 273054888, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7557), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7558), "Sewage" },
                    { 280354141, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7687), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7688), "Burglar Alarm" },
                    { 359350819, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7572), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7573), "Potable Water" },
                    { 365315881, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7600), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7601), "Fire Detection" },
                    { 386689022, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7616), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7617), "Fire Suppression" },
                    { 405241881, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7714), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7715), "BMS" },
                    { 590351940, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7741), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7742), "Energy Efficiency" },
                    { 602869540, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7784), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7785), "Construction Supervision" },
                    { 651506952, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7672), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7674), "Structured Cabling" },
                    { 652640203, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7657), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7659), "Power Distribution" },
                    { 676186008, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7644), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7645), "Natural Gas" },
                    { 829570467, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7700), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7701), "CCTV" },
                    { 858561653, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7535), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7536), "HVAC" },
                    { 886024022, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7755), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7756), "Outsource" },
                    { 975473408, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7768), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7770), "TenderDocument" },
                    { 994952768, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7586), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7587), "Drainage" }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 573899391, new DateTime(2024, 3, 11, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7187), 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7183), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7184), "Drawings" },
                    { 703624635, new DateTime(2024, 3, 11, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7168), 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7164), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7166), "Calculations" },
                    { 915047829, new DateTime(2024, 3, 11, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7144), 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7140), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7141), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -2071538534, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7084), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7085), "Administration" },
                    { -1543726325, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7017), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7018), "Communications" },
                    { -981144726, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7068), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7070), "Meetings" },
                    { 1772850218, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7038), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7039), "Printing" },
                    { 1842744462, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7053), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7055), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 250376810, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6848), "Consulting Description", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6849), "Consulting" },
                    { 651470113, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6799), "Buildings Description", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6800), "Buildings" },
                    { 932074091, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6832), "Energy Description", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6834), "Energy" },
                    { 974752647, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6816), "Infrastructure Description", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6818), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 186612725, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5806), true, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5807), "CEO" },
                    { 219135392, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5774), true, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5776), "Engineer" },
                    { 250018947, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5820), false, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5821), "Customer" },
                    { 266993409, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5790), true, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5791), "COO" },
                    { 373364343, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5813), false, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5814), "Guest" },
                    { 482625167, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5766), true, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5767), "Designer" },
                    { 570449865, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5797), true, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5799), "CTO" },
                    { 969745641, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5782), true, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(5783), "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6586), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6587), null, "6949277780", null, null, null },
                    { 228289153, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6411), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6412), null, "6949277784", null, null, null },
                    { 334060210, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6380), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6382), null, "6949277783", null, null, null },
                    { 382062350, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6316), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6317), null, "6949277781", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 454024612, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6875), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6876), null, "6949277781", null, null, null },
                    { 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6767), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6768), null, "6949277785", null, null, null },
                    { 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6632), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6633), null, "6949277781", null, null, null },
                    { 574553646, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6350), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6351), null, "6949277782", null, null, null },
                    { 576298976, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6065), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6067), null, "694927778", null, null, null },
                    { 586311076, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6112), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6113), null, "694927778", null, null, null },
                    { 616502958, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6950), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6951), null, "6949277783", null, null, null },
                    { 629519661, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6553), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6555), null, "6949277785", null, null, null },
                    { 675040197, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6916), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6917), null, "6949277782", null, null, null },
                    { 695056594, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6234), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6235), null, "6949277780", null, null, null },
                    { 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6695), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6696), null, "6949277783", null, null, null },
                    { 786538890, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6174), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6175), null, "694927778", null, null, null },
                    { 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6735), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6736), null, "6949277784", null, null, null },
                    { 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6664), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6665), null, "6949277782", null, null, null },
                    { 980378787, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6982), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6983), null, "6949277784", null, null, null },
                    { 986356914, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6143), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6145), null, "694927778", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 573899391, 228289153, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1172), -450079262, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1174) },
                    { 573899391, 334060210, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1154), -1678510853, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1155) },
                    { 573899391, 382062350, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1128), 1837328670, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1129) },
                    { 573899391, 574553646, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1141), -2018372251, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1142) },
                    { 573899391, 629519661, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1187), -1537738969, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1188) },
                    { 573899391, 695056594, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1114), -163782994, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1116) },
                    { 703624635, 228289153, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1088), 1340886587, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1089) },
                    { 703624635, 334060210, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1074), -1036627829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1075) },
                    { 703624635, 382062350, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1046), -1518918907, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1047) },
                    { 703624635, 574553646, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1059), -1788286823, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1061) },
                    { 703624635, 629519661, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1101), -1440194129, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1102) },
                    { 703624635, 695056594, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1033), -1133516735, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1034) },
                    { 915047829, 228289153, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1005), -1812502570, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1006) },
                    { 915047829, 334060210, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(992), 1199697233, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(993) },
                    { 915047829, 382062350, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(964), 146533303, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(966) },
                    { 915047829, 574553646, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(978), -732436501, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(979) },
                    { 915047829, 629519661, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1019), -1519001225, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(1020) },
                    { 915047829, 695056594, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(945), 1658255108, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(947) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 228289153, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(917), 724691606, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(918) },
                    { 334060210, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(904), -728482108, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(905) },
                    { 382062350, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(876), 1447336431, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(878) },
                    { 574553646, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(890), 919365746, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(891) },
                    { 629519661, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(931), 1721382687, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(932) },
                    { 695056594, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(863), 183097571, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(864) },
                    { 228289153, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(582), -1382813626, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(584) },
                    { 334060210, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(569), -558551384, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(570) },
                    { 382062350, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(540), -1646560142, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(542) },
                    { 574553646, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(555), -353901968, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(556) },
                    { 629519661, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(597), -1018173226, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(598) },
                    { 695056594, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(519), 314172608, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(520) },
                    { 228289153, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(836), -1193557616, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(837) },
                    { 334060210, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(822), 1565887176, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(823) },
                    { 382062350, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(795), 207146431, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(796) },
                    { 574553646, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(809), -415666538, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(810) },
                    { 629519661, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(849), -889913623, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(851) },
                    { 695056594, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(781), -754729681, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(783) },
                    { 228289153, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(666), -1019651071, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(668) },
                    { 334060210, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(653), 2061763065, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(654) },
                    { 382062350, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(625), -629764028, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(626) },
                    { 574553646, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(638), -116584955, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(640) },
                    { 629519661, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(680), 1673064333, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(681) },
                    { 695056594, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(611), 1582930886, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(612) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 228289153, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(748), 873171689, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(750) },
                    { 334060210, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(735), -1011617086, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(736) },
                    { 382062350, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(707), -1536711340, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(709) },
                    { 574553646, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(721), 1210537854, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(722) },
                    { 629519661, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(767), 1686335810, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(769) },
                    { 695056594, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(694), -826614895, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(695) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 189047666, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 9.0, 16, new DateTime(2025, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 16, "Test Description Project_4", "KL-4", new DateTime(2025, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), new DateTime(2025, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 0f, 100L, 12L, new DateTime(2024, 2, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), "Project_4", 5.0, new DateTime(2025, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), "Payment Detailes For Project_12", 4.0, null, 250376810, new DateTime(2025, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 0f },
                    { 250317816, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 7.0, 4, new DateTime(2024, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), new DateTime(2024, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 0f, 100L, 12L, new DateTime(2024, 2, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), "Project_2", 5.0, new DateTime(2024, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), "Payment Detailes For Project_10", 2.0, null, 974752647, new DateTime(2024, 6, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 0f },
                    { 423734525, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 6.0, 1, new DateTime(2024, 3, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 1, "Test Description Project_2", "KL-1", new DateTime(2024, 3, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), new DateTime(2024, 3, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 0f, 100L, 12L, new DateTime(2024, 2, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), "Project_1", 5.0, new DateTime(2024, 3, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), "Payment Detailes For Project_2", 1.0, null, 651470113, new DateTime(2024, 3, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 0f },
                    { 675366496, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 8.0, 9, new DateTime(2024, 11, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 9, "Test Description Project_18", "KL-3", new DateTime(2024, 11, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), new DateTime(2024, 11, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 0f, 100L, 12L, new DateTime(2024, 2, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), "Project_3", 5.0, new DateTime(2024, 11, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), "Payment Detailes For Project_18", 3.0, null, 932074091, new DateTime(2024, 11, 29, 21, 10, 18, 352, DateTimeKind.Local).AddTicks(2829), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 219135392, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6616), 683800698, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6617) },
                    { 482625167, 228289153, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6430), 648940909, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6431) },
                    { 482625167, 334060210, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6397), 460347122, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6398) },
                    { 482625167, 382062350, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6335), 979605807, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6337) },
                    { 969745641, 454024612, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6897), 911533915, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6899) },
                    { 219135392, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6784), 694645837, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6785) },
                    { 219135392, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6650), 172264150, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6651) },
                    { 482625167, 574553646, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6367), 285390870, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6368) },
                    { 186612725, 576298976, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6091), 876306529, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6092) },
                    { 570449865, 586311076, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6128), 473252862, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6130) },
                    { 969745641, 616502958, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6967), 357148790, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6968) },
                    { 482625167, 629519661, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6570), 296814480, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6571) },
                    { 969745641, 675040197, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6934), 897604099, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6936) },
                    { 482625167, 695056594, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6300), 526822943, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6302) },
                    { 219135392, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6720), 372146426, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6722) },
                    { 373364343, 786538890, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6189), 488770512, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6190) },
                    { 219135392, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6753), 250795415, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6754) },
                    { 219135392, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6681), 907921144, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6682) },
                    { 969745641, 980378787, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7000), 660509825, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7001) },
                    { 266993409, 986356914, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6158), 816412864, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(6161) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1881449112, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7941), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7942), 675366496, 651506952, null },
                    { -1719136536, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7802), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7803), 423734525, 273054888, null },
                    { -1615796424, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7827), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7828), 423734525, 829570467, null },
                    { -1375386896, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7926), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7928), 675366496, 155468684, null },
                    { -1165857352, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7973), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7974), 189047666, 829570467, null },
                    { -826940608, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7859), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7860), 250317816, 590351940, null },
                    { 1193466272, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7891), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7892), 250317816, 273054888, null },
                    { 1363663864, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7843), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7845), 423734525, 590351940, null },
                    { 1451226088, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7911), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7913), 675366496, 386689022, null },
                    { 1550246504, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7958), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7959), 189047666, 651506952, null },
                    { 1610645656, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7874), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7875), 250317816, 652640203, null },
                    { 2082598808, 0f, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7987), 0f, 1500L, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7989), 189047666, 590351940, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 221882551, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7289), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7292), 3010.0, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7290), "Signature 142343", 76595, 423734525, 1.0, 17.0 },
                    { 436767101, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7439), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7442), 4000.0, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7441), "Signature 1423415", 52236, 675366496, 3.0, 17.0 },
                    { 453483888, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7509), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7511), 13000.0, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7510), "Signature 1423416", 38770, 189047666, 4.0, 24.0 },
                    { 689059739, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7368), new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7371), 3100.0, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7369), "Signature 142342", 40380, 250317816, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 423734525, 454024612, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8004), 668941922, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8005) },
                    { 675366496, 616502958, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8039), 173729736, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8041) },
                    { 250317816, 675040197, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8025), 414759271, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8026) },
                    { 189047666, 980378787, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8054), 690944730, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8055) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 222092076, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7336), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7337), null, "6949277782", null, null, 250317816 },
                    { 458071166, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7477), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7478), null, "6949277784", null, null, 189047666 },
                    { 501264930, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7251), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7252), null, "6949277781", null, null, 423734525 },
                    { 594547212, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7408), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7409), null, "6949277783", null, null, 675366496 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1881449112, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8807), 825029418, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8808) },
                    { -1881449112, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8879), 839046995, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8880) },
                    { -1881449112, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8821), 691029776, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8822) },
                    { -1881449112, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8850), 691731098, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8851) },
                    { -1881449112, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8865), 154197836, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8866) },
                    { -1881449112, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8836), 438816866, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8837) },
                    { -1719136536, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8069), 861087140, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8071) },
                    { -1719136536, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8152), 918530270, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8153) },
                    { -1719136536, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8089), 535327193, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8090) },
                    { -1719136536, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8120), 931671049, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8122) },
                    { -1719136536, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8136), 584214731, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8137) },
                    { -1719136536, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8104), 433406678, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8106) },
                    { -1615796424, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8168), 194815472, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8169) },
                    { -1615796424, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8245), 673299399, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8246) },
                    { -1615796424, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8183), 507356575, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8184) },
                    { -1615796424, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8214), 234876394, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8215) },
                    { -1615796424, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8230), 493559628, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8231) },
                    { -1615796424, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8198), 156328776, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8199) },
                    { -1375386896, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8715), 265257991, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8716) },
                    { -1375386896, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8791), 518240849, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8792) },
                    { -1375386896, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8729), 909847729, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8730) },
                    { -1375386896, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8762), 198645418, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8763) },
                    { -1375386896, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8777), 825757474, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8778) },
                    { -1375386896, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8748), 289316692, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8749) },
                    { -1165857352, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8981), 315937929, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8983) },
                    { -1165857352, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9056), 176071483, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9058) },
                    { -1165857352, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8996), 163582499, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8998) },
                    { -1165857352, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9026), 185552095, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9027) },
                    { -1165857352, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9040), 186079423, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9041) },
                    { -1165857352, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9011), 233584242, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9012) },
                    { -826940608, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8357), 447642907, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8358) },
                    { -826940608, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8435), 699158734, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8436) },
                    { -826940608, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8372), 291385151, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8373) },
                    { -826940608, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8401), 336753708, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8402) },
                    { -826940608, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8420), 362079514, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8421) },
                    { -826940608, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8386), 598914789, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8388) },
                    { 1193466272, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8538), 949771312, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8539) },
                    { 1193466272, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8612), 521760377, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8614) },
                    { 1193466272, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8552), 123618479, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8553) },
                    { 1193466272, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8583), 132696857, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8584) },
                    { 1193466272, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8598), 601203847, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8599) },
                    { 1193466272, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8567), 336758498, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8568) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1363663864, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8261), 838050389, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8262) },
                    { 1363663864, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8341), 235583386, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8343) },
                    { 1363663864, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8276), 195359430, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8277) },
                    { 1363663864, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8306), 987804638, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8308) },
                    { 1363663864, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8325), 961941474, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8326) },
                    { 1363663864, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8291), 161807948, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8292) },
                    { 1451226088, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8627), 986330279, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8629) },
                    { 1451226088, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8700), 435731071, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8701) },
                    { 1451226088, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8642), 833889023, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8643) },
                    { 1451226088, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8671), 724297442, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8672) },
                    { 1451226088, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8685), 271082747, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8687) },
                    { 1451226088, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8656), 729889365, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8658) },
                    { 1550246504, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8894), 530223936, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8895) },
                    { 1550246504, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8967), 981430239, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8968) },
                    { 1550246504, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8909), 265564254, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8910) },
                    { 1550246504, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8938), 575051290, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8939) },
                    { 1550246504, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8952), 246017572, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8953) },
                    { 1550246504, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8923), 202524206, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8924) },
                    { 1610645656, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8450), 127126658, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8451) },
                    { 1610645656, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8523), 192221762, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8524) },
                    { 1610645656, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8465), 504373757, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8466) },
                    { 1610645656, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8494), 369433678, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8495) },
                    { 1610645656, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8508), 625927095, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8510) },
                    { 1610645656, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8479), 130947942, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(8481) },
                    { 2082598808, 183123231, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9072), 422295825, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9073) },
                    { 2082598808, 553152898, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9149), 381927105, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9150) },
                    { 2082598808, 565841375, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9087), 549478655, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9088) },
                    { 2082598808, 707565524, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9116), 581128199, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9117) },
                    { 2082598808, 808732077, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9131), 998705767, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9132) },
                    { 2082598808, 895451020, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9102), 688799344, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9103) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1881449112, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(383), 982406088, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(384) },
                    { -1881449112, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(369), 952494750, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(371) },
                    { -1881449112, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(353), 679097920, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(355) },
                    { -1719136536, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(54), 568525345, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(55) },
                    { -1719136536, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(40), 148413181, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(41) },
                    { -1719136536, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(21), 880894199, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(22) },
                    { -1615796424, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(95), 340509663, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(97) },
                    { -1615796424, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(81), 545940185, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(82) },
                    { -1615796424, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(68), 316714330, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(69) },
                    { -1375386896, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(340), 152589854, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(341) },
                    { -1375386896, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(327), 942713510, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(328) },
                    { -1375386896, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(313), 926753596, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(315) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1165857352, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(463), 226200229, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(464) },
                    { -1165857352, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(450), 481162360, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(451) },
                    { -1165857352, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(437), 763757149, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(438) },
                    { -826940608, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(178), 777971193, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(179) },
                    { -826940608, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(165), 884892177, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(166) },
                    { -826940608, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(151), 293243828, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(152) },
                    { 1193466272, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(259), 314709463, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(261) },
                    { 1193466272, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(245), 923837394, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(246) },
                    { 1193466272, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(232), 550495284, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(233) },
                    { 1363663864, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(137), 445420317, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(138) },
                    { 1363663864, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(124), 332875267, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(125) },
                    { 1363663864, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(110), 846502118, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(111) },
                    { 1451226088, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(300), 941908750, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(301) },
                    { 1451226088, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(286), 367661668, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(287) },
                    { 1451226088, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(273), 830072562, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(274) },
                    { 1550246504, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(423), 829091743, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(424) },
                    { 1550246504, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(410), 160816726, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(411) },
                    { 1550246504, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(396), 293019894, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(398) },
                    { 1610645656, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(218), 606584895, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(219) },
                    { 1610645656, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(205), 961863118, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(206) },
                    { 1610645656, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(192), 277042952, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(193) },
                    { 2082598808, 573899391, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(504), 389854309, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(505) },
                    { 2082598808, 703624635, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(491), 177166580, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(492) },
                    { 2082598808, 915047829, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(478), 647841564, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(479) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1881449112, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9792), 555590102, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9793) },
                    { -1881449112, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9737), 442608702, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9739) },
                    { -1881449112, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9778), 984488031, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9780) },
                    { -1881449112, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9751), 940416022, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9752) },
                    { -1881449112, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9765), 293422713, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9766) },
                    { -1719136536, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9227), 850144125, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9228) },
                    { -1719136536, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9166), 778286053, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9167) },
                    { -1719136536, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9213), 956842676, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9214) },
                    { -1719136536, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9184), 159018940, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9185) },
                    { -1719136536, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9199), 671772739, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9200) },
                    { -1615796424, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9299), 837216588, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9300) },
                    { -1615796424, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9242), 594219720, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9243) },
                    { -1615796424, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9284), 662600090, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9285) },
                    { -1615796424, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9256), 814475781, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9257) },
                    { -1615796424, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9270), 866681324, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9271) },
                    { -1375386896, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9723), 470854861, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9725) },
                    { -1375386896, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9668), 609654047, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9669) },
                    { -1375386896, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9710), 134140271, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9711) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1375386896, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9682), 153063562, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9683) },
                    { -1375386896, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9696), 198100509, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9697) },
                    { -1165857352, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9930), 665305188, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9932) },
                    { -1165857352, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9875), 234862054, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9877) },
                    { -1165857352, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9917), 473456875, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9918) },
                    { -1165857352, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9889), 795604697, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9890) },
                    { -1165857352, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9903), 328252128, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9904) },
                    { -826940608, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9440), 170802307, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9441) },
                    { -826940608, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9383), 129129309, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9385) },
                    { -826940608, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9426), 403865294, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9427) },
                    { -826940608, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9397), 797264602, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9399) },
                    { -826940608, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9412), 876036328, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9413) },
                    { 1193466272, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9583), 514840435, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9585) },
                    { 1193466272, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9524), 605145833, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9525) },
                    { 1193466272, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9570), 477970956, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9571) },
                    { 1193466272, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9538), 527666920, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9539) },
                    { 1193466272, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9551), 332484292, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9553) },
                    { 1363663864, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9369), 225285838, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9371) },
                    { 1363663864, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9313), 317078473, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9315) },
                    { 1363663864, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9355), 852474911, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9357) },
                    { 1363663864, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9328), 410357673, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9329) },
                    { 1363663864, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9341), 830287393, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9343) },
                    { 1451226088, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9654), 275544989, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9655) },
                    { 1451226088, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9598), 898108194, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9599) },
                    { 1451226088, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9640), 720118393, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9641) },
                    { 1451226088, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9612), 231312141, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9613) },
                    { 1451226088, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9625), 594244071, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9626) },
                    { 1550246504, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9861), 282543630, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9862) },
                    { 1550246504, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9806), 176813196, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9807) },
                    { 1550246504, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9848), 661797251, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9849) },
                    { 1550246504, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9820), 872314728, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9821) },
                    { 1550246504, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9834), 843948771, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9835) },
                    { 1610645656, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9510), 439984440, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9511) },
                    { 1610645656, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9454), 188693288, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9456) },
                    { 1610645656, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9496), 605601917, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9497) },
                    { 1610645656, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9468), 803053199, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9469) },
                    { 1610645656, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9482), 269431313, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9483) },
                    { 2082598808, -2071538534, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(4), 513098819, new DateTime(2024, 2, 29, 21, 10, 18, 359, DateTimeKind.Local).AddTicks(5) },
                    { 2082598808, -1543726325, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9944), 407610529, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9945) },
                    { 2082598808, -981144726, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9990), 378957248, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9991) },
                    { 2082598808, 1772850218, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9958), 711795851, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9959) },
                    { 2082598808, 1842744462, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9976), 844267976, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(9977) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 250018947, 222092076, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7353), 664181448, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7355) },
                    { 250018947, 458071166, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7494), 483529508, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7495) },
                    { 250018947, 501264930, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7273), 619792521, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7274) },
                    { 250018947, 594547212, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7425), 642672092, new DateTime(2024, 2, 29, 21, 10, 18, 358, DateTimeKind.Local).AddTicks(7426) }
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
                name: "IX_Disciplines_ProjectId",
                table: "Disciplines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TypeId",
                table: "Disciplines",
                column: "TypeId");

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
                name: "FK_DisciplinesDraws_Disciplines_DisciplineId",
                table: "DisciplinesDraws",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinesOthers_Disciplines_DisciplineId",
                table: "DisciplinesOthers",
                column: "DisciplineId",
                principalTable: "Disciplines",
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
                name: "DisciplineTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectType");
        }
    }
}
