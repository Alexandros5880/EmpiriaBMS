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
                    { 244377174, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(144), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(145), "Power Distribution" },
                    { 261519847, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(46), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(47), "Sewage" },
                    { 367492456, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(265), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(266), "Construction Supervision" },
                    { 373822031, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(60), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(61), "Potable Water" },
                    { 378046377, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(74), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(75), "Drainage" },
                    { 414064421, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(159), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(160), "Structured Cabling" },
                    { 469382625, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(224), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(225), "Energy Efficiency" },
                    { 689332475, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(185), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(186), "CCTV" },
                    { 739083400, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(87), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(88), "Fire Detection" },
                    { 741136401, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(211), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(212), "Photovoltaics" },
                    { 775036926, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(27), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(28), "HVAC" },
                    { 775332951, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(198), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(199), "BMS" },
                    { 800762001, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(103), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(104), "Fire Suppression" },
                    { 843196438, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(237), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(238), "Outsource" },
                    { 864777433, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(130), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(131), "Natural Gas" },
                    { 901291257, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(250), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(251), "TenderDocument" },
                    { 901492508, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(117), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(118), "Elevators" },
                    { 927352238, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(172), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(173), "Burglar Alarm" }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 227313937, new DateTime(2024, 3, 11, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9696), 0f, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9693), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9695), "Drawings" },
                    { 519360793, new DateTime(2024, 3, 11, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9678), 0f, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9675), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9676), "Calculations" },
                    { 737541657, new DateTime(2024, 3, 11, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9653), 0f, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9649), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9651), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -1666998196, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9601), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9602), "On-Site" },
                    { -683639215, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9585), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9586), "Printing" },
                    { 102630714, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9616), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9617), "Meetings" },
                    { 771178985, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9631), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9632), "Administration" },
                    { 934193577, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9566), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9567), "Communications" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 158281522, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9397), "Energy Description", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9398), "Energy" },
                    { 432262338, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9412), "Consulting Description", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9413), "Consulting" },
                    { 840907952, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9382), "Infrastructure Description", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9383), "Infrastructure" },
                    { 879717126, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9364), "Buildings Description", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9365), "Buildings" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 354017745, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8633), true, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8634), "Engineer" },
                    { 415135942, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8676), false, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8677), "Customer" },
                    { 433557818, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8669), false, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8670), "Guest" },
                    { 738584782, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8647), true, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8649), "COO" },
                    { 801970562, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8655), true, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8656), "CTO" },
                    { 804758337, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8662), true, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8663), "CEO" },
                    { 872590420, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8624), true, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8625), "Designer" },
                    { 961326981, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8640), true, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8641), "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 154087780, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9533), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9534), null, "6949277784", null, null, null },
                    { 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9331), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9333), null, "6949277785", null, null, null },
                    { 191579401, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9433), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9434), null, "6949277781", null, null, null },
                    { 284369475, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9502), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9504), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 330746556, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8850), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8851), null, "694927778", null, null, null },
                    { 429623152, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8782), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8783), null, "694927778", null, null, null },
                    { 450183853, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8882), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8883), null, "694927778", null, null, null },
                    { 484049106, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9093), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9094), null, "6949277784", null, null, null },
                    { 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9229), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9231), null, "6949277782", null, null, null },
                    { 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9260), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9261), null, "6949277783", null, null, null },
                    { 574031915, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9471), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9472), null, "6949277782", null, null, null },
                    { 585077628, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9029), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9030), null, "6949277782", null, null, null },
                    { 627072405, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8820), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8821), null, "694927778", null, null, null },
                    { 672918166, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8997), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8998), null, "6949277781", null, null, null },
                    { 751914046, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8913), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8914), null, "6949277780", null, null, null },
                    { 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9300), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9301), null, "6949277784", null, null, null },
                    { 847115426, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9059), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9060), null, "6949277783", null, null, null },
                    { 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9157), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9159), null, "6949277780", null, null, null },
                    { 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9198), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9200), null, "6949277781", null, null, null },
                    { 927305352, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9126), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9127), null, "6949277785", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 484049106, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3113), 1762511126, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3114) },
                    { 585077628, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3085), -2003475037, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3086) },
                    { 672918166, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3071), -1230343460, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3072) },
                    { 751914046, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3057), 355679749, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3059) },
                    { 847115426, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3099), 728499092, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3100) },
                    { 927305352, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3128), 890076722, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3129) },
                    { 484049106, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3026), -307832417, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3027) },
                    { 585077628, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2996), 1944570713, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2997) },
                    { 672918166, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2982), -555479698, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2983) },
                    { 751914046, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2968), -1198448, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2969) },
                    { 847115426, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3011), -1988092988, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3012) },
                    { 927305352, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3043), 1714455437, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3044) },
                    { 484049106, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3198), 105914507, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3199) },
                    { 585077628, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3170), -1566937165, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3171) },
                    { 672918166, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3156), -680882026, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3158) },
                    { 751914046, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3142), -248389280, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3144) },
                    { 847115426, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3184), -2095088206, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3185) },
                    { 927305352, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3211), -1068759715, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3213) },
                    { 484049106, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3282), -16252033, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3283) },
                    { 585077628, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3253), -705447233, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3254) },
                    { 672918166, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3239), 156445237, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3240) },
                    { 751914046, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3225), -1311252164, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3227) },
                    { 847115426, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3267), -459458293, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3268) },
                    { 927305352, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3296), 1240424546, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(3297) },
                    { 484049106, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2938), 629474315, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2939) },
                    { 585077628, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2910), -914862176, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2911) },
                    { 672918166, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2896), 1927100520, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2897) },
                    { 751914046, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2875), 1474085363, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2876) },
                    { 847115426, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2924), -403175560, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2925) },
                    { 927305352, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2953), 1540446696, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2954) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 150656904, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 7.0, 4, new DateTime(2024, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 4, "Test Description Project_12", "KL-2", new DateTime(2024, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), new DateTime(2024, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 0f, 100L, 12L, new DateTime(2024, 2, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), "Project_2", 5.0, new DateTime(2024, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), "Payment Detailes For Project_12", 2.0, null, 840907952, new DateTime(2024, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 0f },
                    { 295175537, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 8.0, 9, new DateTime(2024, 11, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 9, "Test Description Project_12", "KL-3", new DateTime(2024, 11, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), new DateTime(2024, 11, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 0f, 100L, 12L, new DateTime(2024, 2, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), "Project_3", 5.0, new DateTime(2024, 11, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), "Payment Detailes For Project_6", 3.0, null, 158281522, new DateTime(2024, 11, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 0f },
                    { 434025721, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 6.0, 1, new DateTime(2024, 3, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 1, "Test Description Project_5", "KL-1", new DateTime(2024, 3, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), new DateTime(2024, 3, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 0f, 100L, 12L, new DateTime(2024, 2, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), "Project_1", 5.0, new DateTime(2024, 3, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), "Payment Detailes For Project_5", 1.0, null, 879717126, new DateTime(2024, 3, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 0f },
                    { 602185801, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 9.0, 16, new DateTime(2025, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 16, "Test Description Project_20", "KL-4", new DateTime(2025, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), new DateTime(2025, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 0f, 100L, 12L, new DateTime(2024, 2, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), "Project_4", 5.0, new DateTime(2025, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), "Payment Detailes For Project_16", 4.0, null, 432262338, new DateTime(2025, 6, 29, 21, 32, 46, 539, DateTimeKind.Local).AddTicks(844), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 961326981, 154087780, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9550), 474782809, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9551) },
                    { 354017745, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9350), 392110821, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9351) },
                    { 961326981, 191579401, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9455), 543863554, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9456) },
                    { 961326981, 284369475, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9519), 369674975, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9520) },
                    { 738584782, 330746556, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8866), 203151106, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8868) },
                    { 804758337, 429623152, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8802), 362664219, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8804) },
                    { 433557818, 450183853, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8896), 501740256, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8897) },
                    { 872590420, 484049106, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9111), 746774914, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9112) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 354017745, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9245), 134538411, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9247) },
                    { 354017745, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9286), 639091964, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9287) },
                    { 961326981, 574031915, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9488), 278505451, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9489) },
                    { 872590420, 585077628, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9045), 868086974, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9046) },
                    { 801970562, 627072405, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8835), 234613504, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8836) },
                    { 872590420, 672918166, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9015), 970591891, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9016) },
                    { 872590420, 751914046, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8981), 523172478, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(8982) },
                    { 354017745, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9317), 791020392, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9318) },
                    { 872590420, 847115426, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9075), 509251077, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9076) },
                    { 354017745, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9184), 989665596, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9185) },
                    { 354017745, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9216), 131824113, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9217) },
                    { 872590420, 927305352, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9142), 197007374, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9143) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2111547880, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(325), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(326), 434025721, 775332951, null },
                    { -1946269864, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(353), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(354), 150656904, 800762001, null },
                    { -1594603592, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(368), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(369), 150656904, 378046377, null },
                    { -1551884944, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(410), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(411), 295175537, 843196438, null },
                    { -824097728, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(426), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(427), 602185801, 689332475, null },
                    { -730239184, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(440), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(441), 602185801, 775332951, null },
                    { -647278344, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(283), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(284), 434025721, 739083400, null },
                    { -449126880, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(310), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(311), 434025721, 689332475, null },
                    { -286316648, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(454), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(455), 602185801, 927352238, null },
                    { 1392723784, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(382), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(384), 295175537, 244377174, null },
                    { 1496904720, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(339), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(340), 150656904, 373822031, null },
                    { 1525710400, 0f, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(397), 0f, 1500L, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(398), 295175537, 864777433, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 475450377, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9934), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9936), 4000.0, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9935), "Signature 142349", 77341, 295175537, 3.0, 17.0 },
                    { 569730972, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9867), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9869), 3100.0, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9868), "Signature 1423412", 30731, 150656904, 2.0, 24.0 },
                    { 916273192, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9791), new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9793), 3010.0, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9792), "Signature 142341", 24565, 434025721, 1.0, 17.0 },
                    { 974027221, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(6), new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(8), 13000.0, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(7), "Signature 1423424", 32866, 602185801, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 602185801, 154087780, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(514), 447601444, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(516) },
                    { 434025721, 191579401, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(469), 748720383, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(470) },
                    { 295175537, 284369475, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(501), 337488628, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(502) },
                    { 150656904, 574031915, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(487), 840093031, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(488) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 141162664, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9975), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9977), null, "6949277784", null, null, 602185801 },
                    { 186646036, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9905), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9906), null, "6949277783", null, null, 295175537 },
                    { 307731579, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9837), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9838), null, "6949277782", null, null, 150656904 },
                    { 726393777, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9755), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9756), null, "6949277781", null, null, 434025721 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2111547880, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(767), 283365482, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(768) },
                    { -2111547880, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(725), 658513997, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(726) },
                    { -2111547880, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(738), 208980191, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(739) },
                    { -2111547880, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(752), 845937057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(753) },
                    { -2111547880, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(698), 947410295, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(700) },
                    { -2111547880, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(712), 516065038, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(713) },
                    { -1946269864, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(925), 882314720, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(926) },
                    { -1946269864, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(886), 478151467, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(887) },
                    { -1946269864, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(899), 272307941, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(900) },
                    { -1946269864, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(912), 191323042, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(913) },
                    { -1946269864, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(859), 386157680, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(861) },
                    { -1946269864, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(873), 637655801, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(874) },
                    { -1594603592, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1006), 404818609, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1007) },
                    { -1594603592, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(965), 915101643, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(966) },
                    { -1594603592, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(979), 556457322, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(980) },
                    { -1594603592, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(993), 761045605, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(994) },
                    { -1594603592, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(938), 748996025, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(940) },
                    { -1594603592, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(952), 792721490, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(953) },
                    { -1551884944, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1247), 560951682, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1248) },
                    { -1551884944, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1208), 538916852, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1209) },
                    { -1551884944, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1221), 453753329, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1222) },
                    { -1551884944, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1234), 402966060, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1235) },
                    { -1551884944, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1182), 189713996, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1183) },
                    { -1551884944, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1195), 302653455, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1196) },
                    { -824097728, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1326), 559808761, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1327) },
                    { -824097728, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1286), 349387759, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1288) },
                    { -824097728, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1300), 850436480, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1301) },
                    { -824097728, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1313), 454735161, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1314) },
                    { -824097728, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1260), 561121170, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1261) },
                    { -824097728, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1273), 973856468, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1274) },
                    { -730239184, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1410), 389769653, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1411) },
                    { -730239184, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1366), 269102570, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1368) },
                    { -730239184, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1380), 510273157, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1381) },
                    { -730239184, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1393), 737861312, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1394) },
                    { -730239184, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1340), 366512089, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1341) },
                    { -730239184, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1353), 381753726, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1354) },
                    { -647278344, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(600), 875911364, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(601) },
                    { -647278344, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(559), 378041980, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(560) },
                    { -647278344, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(572), 560685236, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(574) },
                    { -647278344, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(586), 550563642, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(587) },
                    { -647278344, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(529), 306230075, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(530) },
                    { -647278344, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(546), 881161794, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(547) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -449126880, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(685), 662337930, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(686) },
                    { -449126880, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(641), 751592616, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(642) },
                    { -449126880, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(655), 398314133, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(656) },
                    { -449126880, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(672), 847884367, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(673) },
                    { -449126880, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(614), 306263195, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(615) },
                    { -449126880, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(627), 148240164, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(629) },
                    { -286316648, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1507), 200767672, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1508) },
                    { -286316648, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1465), 325666960, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1466) },
                    { -286316648, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1479), 440436059, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1480) },
                    { -286316648, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1493), 316229176, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1494) },
                    { -286316648, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1424), 293203581, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1425) },
                    { -286316648, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1451), 823073037, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1452) },
                    { 1392723784, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1088), 146743176, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1089) },
                    { 1392723784, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1049), 349696063, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1050) },
                    { 1392723784, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1062), 662898609, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1063) },
                    { 1392723784, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1075), 613342249, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1076) },
                    { 1392723784, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1019), 265481451, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1020) },
                    { 1392723784, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1032), 930721725, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1033) },
                    { 1496904720, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(846), 534008135, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(847) },
                    { 1496904720, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(807), 483867384, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(808) },
                    { 1496904720, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(820), 322377727, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(821) },
                    { 1496904720, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(833), 507387977, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(834) },
                    { 1496904720, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(780), 941012016, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(782) },
                    { 1496904720, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(794), 462089121, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(795) },
                    { 1525710400, 175075782, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1168), 481030183, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1169) },
                    { 1525710400, 563246283, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1128), 247957808, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1130) },
                    { 1525710400, 564703057, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1142), 555805565, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1143) },
                    { 1525710400, 759297008, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1155), 675020302, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1156) },
                    { 1525710400, 869181688, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1102), 462338587, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1103) },
                    { 1525710400, 910436380, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1115), 438459300, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1116) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2111547880, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2487), 612093546, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2489) },
                    { -2111547880, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2474), 919355769, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2475) },
                    { -2111547880, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2461), 664781122, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2462) },
                    { -1946269864, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2570), 849988055, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2571) },
                    { -1946269864, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2557), 511673642, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2558) },
                    { -1946269864, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2544), 630138544, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2545) },
                    { -1594603592, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2612), 153692750, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2613) },
                    { -1594603592, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2597), 655244130, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2598) },
                    { -1594603592, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2584), 808244646, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2585) },
                    { -1551884944, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2738), 818624390, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2739) },
                    { -1551884944, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2724), 345898512, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2726) },
                    { -1551884944, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2711), 206598654, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2712) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -824097728, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2778), 470368303, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2779) },
                    { -824097728, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2764), 485148443, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2766) },
                    { -824097728, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2751), 234024011, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2752) },
                    { -730239184, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2818), 542677695, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2819) },
                    { -730239184, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2804), 559782223, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2806) },
                    { -730239184, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2791), 587017953, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2792) },
                    { -647278344, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2404), 456674989, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2405) },
                    { -647278344, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2389), 838556583, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2390) },
                    { -647278344, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2370), 549194167, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2371) },
                    { -449126880, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2446), 833673461, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2448) },
                    { -449126880, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2431), 425930077, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2433) },
                    { -449126880, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2418), 191734128, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2419) },
                    { -286316648, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2860), 184429270, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2861) },
                    { -286316648, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2847), 886453801, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2848) },
                    { -286316648, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2833), 757451552, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2834) },
                    { 1392723784, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2657), 320945378, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2658) },
                    { 1392723784, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2643), 330765011, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2644) },
                    { 1392723784, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2626), 188264219, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2627) },
                    { 1496904720, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2530), 813409246, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2531) },
                    { 1496904720, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2517), 750220092, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2518) },
                    { 1496904720, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2503), 239787403, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2504) },
                    { 1525710400, 227313937, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2697), 393209891, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2699) },
                    { 1525710400, 519360793, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2684), 636642012, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2685) },
                    { 1525710400, 737541657, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2671), 546191189, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2672) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2111547880, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1702), 252564329, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1703) },
                    { -2111547880, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1687), 362123609, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1689) },
                    { -2111547880, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1716), 854189415, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1717) },
                    { -2111547880, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1730), 679119360, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1731) },
                    { -2111547880, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1674), 263827755, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1675) },
                    { -1946269864, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1845), 585944099, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1846) },
                    { -1946269864, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1831), 794194358, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1832) },
                    { -1946269864, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1859), 470614354, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1860) },
                    { -1946269864, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1872), 844823217, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1873) },
                    { -1946269864, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1814), 697899438, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1815) },
                    { -1594603592, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1914), 594774611, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1915) },
                    { -1594603592, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1900), 637481711, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1901) },
                    { -1594603592, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1928), 374477333, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1929) },
                    { -1594603592, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1941), 778437081, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1942) },
                    { -1594603592, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1887), 406786284, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1888) },
                    { -1551884944, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2119), 952401735, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2121) },
                    { -1551884944, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2106), 943925694, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2107) },
                    { -1551884944, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2133), 405440170, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2134) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1551884944, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2146), 580984475, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2148) },
                    { -1551884944, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2092), 716659071, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2093) },
                    { -824097728, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2187), 832412962, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2189) },
                    { -824097728, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2174), 878549811, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2175) },
                    { -824097728, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2201), 303389656, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2202) },
                    { -824097728, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2215), 548623024, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2216) },
                    { -824097728, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2160), 254856610, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2161) },
                    { -730239184, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2259), 535384231, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2260) },
                    { -730239184, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2245), 600373465, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2246) },
                    { -730239184, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2273), 307180876, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2274) },
                    { -730239184, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2287), 399717584, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2288) },
                    { -730239184, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2232), 361893760, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2233) },
                    { -647278344, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1559), 691215568, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1560) },
                    { -647278344, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1544), 436999023, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1545) },
                    { -647278344, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1573), 453304576, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1574) },
                    { -647278344, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1587), 908921338, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1588) },
                    { -647278344, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1523), 684546603, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1524) },
                    { -449126880, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1631), 221713074, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1632) },
                    { -449126880, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1617), 201864104, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1618) },
                    { -449126880, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1645), 203291854, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1646) },
                    { -449126880, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1660), 309680158, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1661) },
                    { -449126880, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1602), 789288256, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1604) },
                    { -286316648, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2328), 504873279, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2329) },
                    { -286316648, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2314), 877070204, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2315) },
                    { -286316648, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2341), 963215311, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2343) },
                    { -286316648, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2355), 673768538, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2356) },
                    { -286316648, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2301), 287644575, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2302) },
                    { 1392723784, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1982), 723703181, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1983) },
                    { 1392723784, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1968), 236717981, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1970) },
                    { 1392723784, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1997), 272101997, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1998) },
                    { 1392723784, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2011), 263995762, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2012) },
                    { 1392723784, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1955), 491243888, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1956) },
                    { 1496904720, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1772), 976206215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1774) },
                    { 1496904720, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1757), 795325390, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1758) },
                    { 1496904720, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1786), 608004419, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1787) },
                    { 1496904720, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1800), 947930169, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1802) },
                    { 1496904720, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1743), 987688912, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(1745) },
                    { 1525710400, -1666998196, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2051), 821671678, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2053) },
                    { 1525710400, -683639215, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2038), 785757204, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2039) },
                    { 1525710400, 102630714, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2065), 605701573, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2066) },
                    { 1525710400, 771178985, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2078), 275953635, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2080) },
                    { 1525710400, 934193577, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2025), 677042157, new DateTime(2024, 2, 29, 21, 32, 46, 545, DateTimeKind.Local).AddTicks(2026) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 415135942, 141162664, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9992), 353909627, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9994) },
                    { 415135942, 186646036, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9921), 352417125, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9922) },
                    { 415135942, 307731579, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9854), 274846875, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9855) },
                    { 415135942, 726393777, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9776), 292679809, new DateTime(2024, 2, 29, 21, 32, 46, 544, DateTimeKind.Local).AddTicks(9777) }
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
