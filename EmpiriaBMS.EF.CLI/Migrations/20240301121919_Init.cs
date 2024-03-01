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
                name: "DrawingTypes",
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
                    table.PrimaryKey("PK_DrawingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherTypes",
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
                    table.PrimaryKey("PK_OtherTypes", x => x.Id);
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
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    CompletionEstimation = table.Column<float>(type: "real", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drawings_DrawingTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DrawingTypes",
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
                name: "Others",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    CompletionEstimation = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Others_OtherTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "OtherTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 186667361, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(974), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(975), "Fire Detection" },
                    { 361156141, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1112), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1113), "Outsource" },
                    { 389222022, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1124), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1126), "TenderDocument" },
                    { 446095733, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(987), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(989), "Fire Suppression" },
                    { 455437453, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1000), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1001), "Elevators" },
                    { 536293867, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(950), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(951), "Potable Water" },
                    { 553109498, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1075), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1077), "BMS" },
                    { 592863199, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1025), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1026), "Power Distribution" },
                    { 613152028, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(918), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(919), "HVAC" },
                    { 642107487, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1039), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1040), "Structured Cabling" },
                    { 646485432, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(962), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(963), "Drainage" },
                    { 718156643, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1013), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1014), "Natural Gas" },
                    { 747124958, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1138), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1139), "Construction Supervision" },
                    { 749543682, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1051), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1052), "Burglar Alarm" },
                    { 848330097, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1100), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1101), "Energy Efficiency" },
                    { 861329119, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(937), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(938), "Sewage" },
                    { 917322608, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1063), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1065), "CCTV" },
                    { 999972013, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1088), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1089), "Photovoltaics" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 244816099, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1416), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1417), "Calculations" },
                    { 859992391, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1429), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1431), "Drawings" },
                    { 959033346, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1396), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1398), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 267231521, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2026), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2027), "Meetings" },
                    { 323849464, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1999), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2000), "Printing" },
                    { 390513993, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1978), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1980), "Communications" },
                    { 424095664, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2013), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2014), "On-Site" },
                    { 690331674, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2039), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2040), "Administration" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 162735579, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(413), "Buildings Description", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(415), "Buildings" },
                    { 528655345, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(460), "Consulting Description", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(461), "Consulting" },
                    { 530970353, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(446), "Energy Description", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(447), "Energy" },
                    { 680381536, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(431), "Infrastructure Description", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(432), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 346304936, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9629), true, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9630), "Project Manager" },
                    { 360698884, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9622), true, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9623), "Engineer" },
                    { 463445481, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9651), true, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9652), "CEO" },
                    { 537251008, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9658), false, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9659), "Guest" },
                    { 556208008, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9665), false, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9666), "Customer" },
                    { 564228846, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9611), true, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9612), "Designer" },
                    { 695584018, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9644), true, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9645), "CTO" },
                    { 753285199, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9672), false, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9673), "Admin" },
                    { 989646361, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9636), true, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9638), "COO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 138741957, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(583), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(584), null, "6949277784", null, null, null },
                    { 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(381), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(382), null, "6949277785", null, null, null },
                    { 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(277), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(278), null, "6949277782", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(208), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(209), null, "6949277780", null, null, null },
                    { 403290928, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(521), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(522), null, "6949277782", null, null, null },
                    { 432782388, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9817), "Admin", "admin@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9818), null, "694927778", null, null, null },
                    { 448590144, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9857), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9859), null, "694927778", null, null, null },
                    { 525624917, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(87), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(89), null, "6949277782", null, null, null },
                    { 554909152, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9917), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9918), null, "694927778", null, null, null },
                    { 562043884, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(116), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(118), null, "6949277783", null, null, null },
                    { 588929402, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9982), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9983), null, "6949277780", null, null, null },
                    { 600588473, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(550), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(551), null, "6949277783", null, null, null },
                    { 687975603, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9946), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9947), null, "694927778", null, null, null },
                    { 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(247), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(248), null, "6949277781", null, null, null },
                    { 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(351), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(352), null, "6949277784", null, null, null },
                    { 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(310), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(311), null, "6949277783", null, null, null },
                    { 957369114, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(57), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(58), null, "6949277781", null, null, null },
                    { 960215934, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(486), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(487), null, "6949277781", null, null, null },
                    { 970228299, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9887), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9889), null, "694927778", null, null, null },
                    { 975676379, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(178), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(179), null, "6949277785", null, null, null },
                    { 983556871, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(147), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(148), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 167591212, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 7.0, 4, new DateTime(2024, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 4, "Test Description Project_6", "KL-2", new DateTime(2024, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), new DateTime(2024, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 0f, 100L, 12L, new DateTime(2024, 3, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), "Project_2", 5.0, new DateTime(2024, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), "Payment Detailes For Project_2", 2.0, null, 680381536, new DateTime(2024, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 0f },
                    { 552662044, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 8.0, 9, new DateTime(2024, 12, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 9, "Test Description Project_12", "KL-3", new DateTime(2024, 12, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), new DateTime(2024, 12, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 0f, 100L, 12L, new DateTime(2024, 3, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), "Project_3", 5.0, new DateTime(2024, 12, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), "Payment Detailes For Project_12", 3.0, null, 530970353, new DateTime(2024, 12, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 0f },
                    { 567573612, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 6.0, 1, new DateTime(2024, 4, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 1, "Test Description Project_2", "KL-1", new DateTime(2024, 4, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), new DateTime(2024, 4, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 0f, 100L, 12L, new DateTime(2024, 3, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), "Project_1", 5.0, new DateTime(2024, 4, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), "Payment Detailes For Project_4", 1.0, null, 162735579, new DateTime(2024, 4, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 0f },
                    { 574562195, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 9.0, 16, new DateTime(2025, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 16, "Test Description Project_12", "KL-4", new DateTime(2025, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), new DateTime(2025, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 0f, 100L, 12L, new DateTime(2024, 3, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), "Project_4", 5.0, new DateTime(2025, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), "Payment Detailes For Project_8", 4.0, null, 528655345, new DateTime(2025, 7, 1, 14, 19, 19, 540, DateTimeKind.Local).AddTicks(1576), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 346304936, 138741957, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(598), 643304990, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(599) },
                    { 360698884, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(398), 175034495, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(399) },
                    { 360698884, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(296), 558311319, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(298) },
                    { 360698884, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(233), 256583738, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(234) },
                    { 346304936, 403290928, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(536), 912955535, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(538) },
                    { 753285199, 432782388, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9837), 587937194, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9839) },
                    { 463445481, 448590144, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9873), 688030339, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9874) },
                    { 564228846, 525624917, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(104), 328220741, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(105) },
                    { 989646361, 554909152, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9932), 396690573, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9933) },
                    { 564228846, 562043884, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(133), 661273714, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(134) },
                    { 564228846, 588929402, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(42), 457794417, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(44) },
                    { 346304936, 600588473, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(565), 788125750, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(567) },
                    { 537251008, 687975603, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9963), 533081456, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9964) },
                    { 360698884, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(264), 943303608, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(265) },
                    { 360698884, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(367), 859993800, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(369) },
                    { 360698884, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(338), 202073325, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(339) },
                    { 564228846, 957369114, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(74), 177606010, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(76) },
                    { 346304936, 960215934, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(506), 386250824, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(507) },
                    { 695584018, 970228299, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9902), 216454918, new DateTime(2024, 3, 1, 14, 19, 19, 544, DateTimeKind.Local).AddTicks(9903) },
                    { 564228846, 975676379, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(193), 409505275, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(194) },
                    { 564228846, 983556871, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(164), 927326722, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(165) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1565866488, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1380), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1382), 574562195, 848330097, null },
                    { -1464136896, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1279), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1280), 552662044, 646485432, null },
                    { -1462256120, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1158), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1159), 567573612, 455437453, null },
                    { -1106609296, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1237), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1239), 167591212, 613152028, null },
                    { -1094857336, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1222), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1223), 167591212, 446095733, null },
                    { -804419736, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1308), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1309), 574562195, 455437453, null },
                    { -698618344, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1252), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1253), 552662044, 186667361, null },
                    { -681530808, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1194), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1195), 567573612, 446095733, null },
                    { -10931392, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1265), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1267), 552662044, 592863199, null },
                    { 1186146960, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1208), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1209), 167591212, 455437453, null },
                    { 1195791352, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1180), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1181), 567573612, 389222022, null },
                    { 1197324392, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1294), 0f, 1500L, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1296), 574562195, 646485432, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 300134032, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(897), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(899), 13000.0, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(898), "Signature 142348", 52015, 574562195, 4.0, 24.0 },
                    { 419030469, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(767), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(769), 3100.0, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(768), "Signature 1423412", 89101, 167591212, 2.0, 24.0 },
                    { 640605199, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(832), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(834), 4000.0, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(833), "Signature 142346", 44544, 552662044, 3.0, 17.0 },
                    { 922867391, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(690), new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(693), 3010.0, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(691), "Signature 142345", 53494, 567573612, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 574562195, 138741957, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2924), 506079290, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2925) },
                    { 167591212, 403290928, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2894), 655225368, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2895) },
                    { 552662044, 600588473, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2908), 584243034, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2909) },
                    { 567573612, 960215934, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2876), 424614113, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2877) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 520984312, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(869), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(870), null, "6949277784", null, null, 574562195 },
                    { 762989201, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(737), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(738), null, "6949277782", null, null, 167591212 },
                    { 847096216, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(803), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(805), null, "6949277783", null, null, 552662044 },
                    { 898284259, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(657), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(658), null, "6949277781", null, null, 567573612 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1565866488, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3874), 431023329, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3875) },
                    { -1565866488, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3835), 939571855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3837) },
                    { -1565866488, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3810), 738558832, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3811) },
                    { -1565866488, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3822), 995592579, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3824) },
                    { -1565866488, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3861), 837474725, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3862) },
                    { -1565866488, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3849), 707882133, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3850) },
                    { -1464136896, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3637), 628534401, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3638) },
                    { -1464136896, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3598), 277226670, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3599) },
                    { -1464136896, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3572), 860611017, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3574) },
                    { -1464136896, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3585), 699557764, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3586) },
                    { -1464136896, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3624), 953406022, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3625) },
                    { -1464136896, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3611), 282262842, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3612) },
                    { -1462256120, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3011), 590591835, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3012) },
                    { -1462256120, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2971), 803009877, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2972) },
                    { -1462256120, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2939), 963431395, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2940) },
                    { -1462256120, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2957), 680072482, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2958) },
                    { -1462256120, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2997), 588144964, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2998) },
                    { -1462256120, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2984), 595211527, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2985) },
                    { -1106609296, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3405), 154397446, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3407) },
                    { -1106609296, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3365), 487278394, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3366) },
                    { -1106609296, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3339), 858824960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3340) },
                    { -1106609296, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3352), 964664964, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3354) },
                    { -1106609296, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3393), 393847858, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3394) },
                    { -1106609296, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3379), 222220672, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3381) },
                    { -1094857336, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3326), 314252275, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3327) },
                    { -1094857336, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3284), 959227769, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3285) },
                    { -1094857336, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3259), 221420940, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3260) },
                    { -1094857336, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3271), 217502489, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3273) },
                    { -1094857336, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3313), 479553459, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3314) },
                    { -1094857336, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3297), 475000291, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3298) },
                    { -804419736, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3796), 808018824, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3798) },
                    { -804419736, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3757), 441788065, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3758) },
                    { -804419736, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3732), 971791046, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3733) },
                    { -804419736, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3744), 916020166, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3745) },
                    { -804419736, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3783), 262949853, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3784) },
                    { -804419736, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3770), 478531239, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3771) },
                    { -698618344, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3482), 441443341, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3483) },
                    { -698618344, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3444), 405286833, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3445) },
                    { -698618344, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3418), 240913298, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3419) },
                    { -698618344, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3431), 550257020, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3432) },
                    { -698618344, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3469), 357686342, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3470) },
                    { -698618344, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3456), 633874160, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3458) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -681530808, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3168), 412051025, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3170) },
                    { -681530808, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3129), 284344516, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3130) },
                    { -681530808, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3103), 624735846, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3104) },
                    { -681530808, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3116), 759868187, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3117) },
                    { -681530808, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3154), 306719899, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3156) },
                    { -681530808, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3142), 514682327, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3143) },
                    { -10931392, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3559), 585522520, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3560) },
                    { -10931392, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3521), 978361346, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3522) },
                    { -10931392, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3495), 819879817, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3497) },
                    { -10931392, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3508), 817700184, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3509) },
                    { -10931392, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3546), 311673180, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3548) },
                    { -10931392, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3534), 290230048, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3535) },
                    { 1186146960, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3246), 461803210, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3247) },
                    { 1186146960, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3207), 461884092, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3208) },
                    { 1186146960, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3182), 153625537, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3183) },
                    { 1186146960, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3194), 468319647, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3195) },
                    { 1186146960, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3233), 344533452, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3234) },
                    { 1186146960, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3220), 509735805, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3221) },
                    { 1195791352, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3090), 571540151, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3091) },
                    { 1195791352, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3050), 904212130, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3052) },
                    { 1195791352, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3024), 304122532, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3025) },
                    { 1195791352, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3037), 351116125, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3039) },
                    { 1195791352, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3077), 889403190, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3079) },
                    { 1195791352, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3064), 172085394, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3066) },
                    { 1197324392, 165372082, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3718), 963267147, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3720) },
                    { 1197324392, 226143003, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3675), 486954405, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3677) },
                    { 1197324392, 360545991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3649), 317269715, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3651) },
                    { 1197324392, 808298992, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3662), 232772693, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3664) },
                    { 1197324392, 848204863, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3706), 785552974, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3707) },
                    { 1197324392, 936876855, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3692), 896674935, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3694) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 155749566, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1603), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1601), 1186146960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1602), 244816099 },
                    { 184412123, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1646), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1643), -1094857336, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1645), 244816099 },
                    { 238392906, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1704), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1702), -1106609296, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1703), 859992391 },
                    { 310156287, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1903), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1900), -804419736, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1901), 244816099 },
                    { 320754046, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1660), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1658), -1094857336, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1659), 859992391 },
                    { 339556310, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1617), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1615), 1186146960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1616), 859992391 },
                    { 356730317, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1589), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1587), 1186146960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1588), 959033346 },
                    { 405035081, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1632), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1629), -1094857336, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1630), 959033346 },
                    { 413455916, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1733), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1730), -698618344, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1731), 244816099 },
                    { 419616056, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1803), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1801), -1464136896, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1802), 959033346 },
                    { 421987062, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1832), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1829), -1464136896, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1830), 859992391 },
                    { 463863617, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1818), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1815), -1464136896, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1816), 244816099 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 473303231, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1965), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1962), -1565866488, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1963), 859992391 },
                    { 475738528, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1937), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1934), -1565866488, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1935), 959033346 },
                    { 542338214, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1509), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1507), 1195791352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1508), 244816099 },
                    { 551960311, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1761), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1758), -10931392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1760), 959033346 },
                    { 598429173, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1465), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1463), -1462256120, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1464), 244816099 },
                    { 605269459, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1775), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1773), -10931392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1774), 244816099 },
                    { 612164694, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1447), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1444), -1462256120, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1445), 959033346 },
                    { 617511160, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1555), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1552), -681530808, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1553), 244816099 },
                    { 618219219, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1494), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1492), 1195791352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1493), 959033346 },
                    { 649282048, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1789), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1787), -10931392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1788), 859992391 },
                    { 652185779, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1951), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1948), -1565866488, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1949), 244816099 },
                    { 653103592, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1846), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1843), 1197324392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1845), 959033346 },
                    { 656227718, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1674), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1672), -1106609296, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1673), 959033346 },
                    { 682259134, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1541), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1538), -681530808, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1539), 959033346 },
                    { 684189049, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1747), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1744), -698618344, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1745), 859992391 },
                    { 788776298, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1719), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1716), -698618344, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1717), 959033346 },
                    { 842764899, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1874), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1872), 1197324392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1873), 859992391 },
                    { 860539794, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1573), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1570), -681530808, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1571), 859992391 },
                    { 882538694, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1920), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1918), -804419736, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1919), 859992391 },
                    { 915445572, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1888), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1886), -804419736, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1887), 959033346 },
                    { 938105005, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1526), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1523), 1195791352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1525), 859992391 },
                    { 961877452, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1689), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1686), -1106609296, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1687), 244816099 },
                    { 977283471, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1480), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1478), -1462256120, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1479), 859992391 },
                    { 997188438, new DateTime(2024, 3, 12, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1860), 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1857), 1197324392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(1859), 244816099 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 152198352, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2300), 1186146960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2301), 424095664 },
                    { 161005126, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2405), -1106609296, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2407), 390513993 },
                    { 164336903, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2392), -1094857336, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2393), 690331674 },
                    { 251470814, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2285), 1186146960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2286), 323849464 },
                    { 257234094, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2258), -681530808, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2259), 690331674 },
                    { 285226673, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2215), -681530808, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2216), 323849464 },
                    { 289913369, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2569), -10931392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2570), 424095664 },
                    { 299454999, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2512), -698618344, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2513), 267231521 },
                    { 334994852, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2582), -10931392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2584), 267231521 },
                    { 346087171, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2326), 1186146960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2328), 690331674 },
                    { 350442114, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2116), -1462256120, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2117), 690331674 },
                    { 360872352, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2741), -804419736, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2743), 390513993 },
                    { 361312921, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2795), -804419736, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2796), 690331674 },
                    { 378896045, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2728), 1197324392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2729), 690331674 },
                    { 417929113, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2145), 1195791352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2146), 323849464 },
                    { 425090452, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2074), -1462256120, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2075), 323849464 },
                    { 425280838, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2635), -1464136896, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2636), 424095664 },
                    { 442441569, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2159), 1195791352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2160), 424095664 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 445938406, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2458), -1106609296, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2459), 690331674 },
                    { 464923261, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2353), -1094857336, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2354), 323849464 },
                    { 472208031, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2272), 1186146960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2273), 390513993 },
                    { 479330834, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2340), -1094857336, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2341), 390513993 },
                    { 502473476, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2231), -681530808, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2232), 424095664 },
                    { 506457823, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2755), -804419736, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2756), 323849464 },
                    { 507368471, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2835), -1565866488, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2836), 424095664 },
                    { 508679199, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2648), -1464136896, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2650), 267231521 },
                    { 527886942, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2131), 1195791352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2132), 390513993 },
                    { 534555419, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2556), -10931392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2557), 323849464 },
                    { 545862411, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2702), 1197324392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2703), 424095664 },
                    { 553815010, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2172), 1195791352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2173), 267231521 },
                    { 597207155, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2848), -1565866488, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2849), 267231521 },
                    { 599979897, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2484), -698618344, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2485), 323849464 },
                    { 614939807, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2525), -698618344, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2526), 690331674 },
                    { 624400852, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2861), -1565866488, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2862), 690331674 },
                    { 634475093, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2366), -1094857336, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2367), 424095664 },
                    { 663597619, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2444), -1106609296, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2446), 267231521 },
                    { 664777008, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2379), -1094857336, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2380), 267231521 },
                    { 668318054, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2821), -1565866488, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2822), 323849464 },
                    { 687749137, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2622), -1464136896, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2623), 323849464 },
                    { 697463073, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2595), -10931392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2597), 690331674 },
                    { 724754269, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2808), -1565866488, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2809), 390513993 },
                    { 735691866, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2089), -1462256120, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2090), 424095664 },
                    { 741083827, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2055), -1462256120, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2056), 390513993 },
                    { 746606342, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2497), -698618344, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2498), 424095664 },
                    { 748388558, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2201), -681530808, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2202), 390513993 },
                    { 798428292, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2102), -1462256120, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2103), 267231521 },
                    { 805106422, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2675), 1197324392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2676), 390513993 },
                    { 813109363, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2662), -1464136896, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2663), 690331674 },
                    { 815691334, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2188), 1195791352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2189), 690331674 },
                    { 894959377, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2768), -804419736, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2769), 424095664 },
                    { 898713298, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2245), -681530808, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2246), 267231521 },
                    { 906115823, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2608), -1464136896, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2610), 390513993 },
                    { 908288918, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2471), -698618344, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2472), 390513993 },
                    { 909571258, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2781), -804419736, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2782), 267231521 },
                    { 918918207, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2543), -10931392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2544), 390513993 },
                    { 930717267, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2431), -1106609296, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2433), 424095664 },
                    { 933655355, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2688), 1197324392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2689), 323849464 },
                    { 964015583, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2313), 1186146960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2314), 267231521 },
                    { 989154771, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2418), -1106609296, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2420), 323849464 },
                    { 999877527, 0f, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2715), 1197324392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(2716), 267231521 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 556208008, 520984312, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(884), 528545524, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(885) },
                    { 556208008, 762989201, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(754), 679759325, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(755) },
                    { 556208008, 847096216, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(819), 281760112, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(820) },
                    { 556208008, 898284259, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(675), 159242257, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(677) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 525624917, 152198352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5260), -890278600, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5261) },
                    { 562043884, 152198352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5272), -1665612521, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5273) },
                    { 588929402, 152198352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5235), -917593753, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5236) },
                    { 957369114, 152198352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5247), 2086975868, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5248) },
                    { 975676379, 152198352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5297), -1452554909, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5298) },
                    { 983556871, 152198352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5285), 1347726033, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5286) },
                    { 525624917, 161005126, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5869), 1902113708, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5871) },
                    { 562043884, 161005126, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5882), -1002789980, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5883) },
                    { 588929402, 161005126, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5844), 1756550412, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5845) },
                    { 957369114, 161005126, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5857), -1249001675, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5858) },
                    { 975676379, 161005126, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5907), -1846190857, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5908) },
                    { 983556871, 161005126, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5894), -208035553, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5896) },
                    { 525624917, 164336903, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5792), -799721959, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5793) },
                    { 562043884, 164336903, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5804), 1719047984, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5805) },
                    { 588929402, 164336903, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5767), -471687007, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5768) },
                    { 957369114, 164336903, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5779), -1850367500, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5780) },
                    { 975676379, 164336903, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5829), 152547463, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5830) },
                    { 983556871, 164336903, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5817), -43049668, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5818) },
                    { 525624917, 251470814, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5184), -1802426449, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5185) },
                    { 562043884, 251470814, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5197), 221232164, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5198) },
                    { 588929402, 251470814, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5159), -993671905, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5160) },
                    { 957369114, 251470814, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5171), -930782123, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5173) },
                    { 975676379, 251470814, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5222), -1139498252, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5223) },
                    { 983556871, 251470814, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5209), 409088980, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5211) },
                    { 525624917, 257234094, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5030), -1089201424, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5031) },
                    { 562043884, 257234094, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5042), -1597296527, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5044) },
                    { 588929402, 257234094, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5005), -1446007517, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5006) },
                    { 957369114, 257234094, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5017), 1416506900, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5018) },
                    { 975676379, 257234094, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5067), -434955464, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5069) },
                    { 983556871, 257234094, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5055), 297694702, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5056) },
                    { 525624917, 285226673, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4803), 204157076, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4804) },
                    { 562043884, 285226673, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4816), -2126080228, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4817) },
                    { 588929402, 285226673, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4778), -221726537, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4779) },
                    { 957369114, 285226673, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4791), -1088834606, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4792) },
                    { 975676379, 285226673, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4841), -454639423, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4842) },
                    { 983556871, 285226673, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4828), 112562222, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4830) },
                    { 525624917, 289913369, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6781), -1396531201, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6782) },
                    { 562043884, 289913369, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6794), -1010157727, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6795) },
                    { 588929402, 289913369, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6756), -1930967383, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6757) },
                    { 957369114, 289913369, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6769), -291869648, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6770) },
                    { 975676379, 289913369, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6819), -1903768487, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6820) },
                    { 983556871, 289913369, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6806), -1421330102, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6807) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 525624917, 299454999, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6477), 431952728, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6478) },
                    { 562043884, 299454999, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6489), -1369512125, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6491) },
                    { 588929402, 299454999, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6451), -189200672, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6452) },
                    { 957369114, 299454999, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6464), -1152193531, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6465) },
                    { 975676379, 299454999, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6515), 2114502768, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6516) },
                    { 983556871, 299454999, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6502), -64780163, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6503) },
                    { 525624917, 334994852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6856), -196722935, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6857) },
                    { 562043884, 334994852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6868), 1291157618, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6869) },
                    { 588929402, 334994852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6831), 1566327798, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6832) },
                    { 957369114, 334994852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6844), -77167547, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6845) },
                    { 975676379, 334994852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6893), 1305800118, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6894) },
                    { 983556871, 334994852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6881), 1787285628, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6882) },
                    { 525624917, 346087171, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5410), -362324168, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5412) },
                    { 562043884, 346087171, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5423), 571910765, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5424) },
                    { 588929402, 346087171, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5385), -451919996, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5387) },
                    { 957369114, 346087171, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5398), -2064354088, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5399) },
                    { 975676379, 346087171, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5448), 1068782486, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5450) },
                    { 983556871, 346087171, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5436), -1175030023, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5437) },
                    { 525624917, 350442114, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4227), -1954288106, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4228) },
                    { 562043884, 350442114, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4239), -595928375, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4240) },
                    { 588929402, 350442114, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4202), 1880243726, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4203) },
                    { 957369114, 350442114, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4214), 425414534, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4216) },
                    { 975676379, 350442114, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4264), 1254733736, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4265) },
                    { 983556871, 350442114, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4252), -263052058, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4253) },
                    { 525624917, 360872352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7796), -1625713159, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7798) },
                    { 562043884, 360872352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7809), 1134009243, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7810) },
                    { 588929402, 360872352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7772), 2085982623, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7773) },
                    { 957369114, 360872352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7784), -1439791415, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7785) },
                    { 975676379, 360872352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7834), -1578354637, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7835) },
                    { 983556871, 360872352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7821), -787507402, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7823) },
                    { 525624917, 361312921, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8096), -823866227, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8097) },
                    { 562043884, 361312921, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8108), -1891511459, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8109) },
                    { 588929402, 361312921, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8071), 2128204215, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8072) },
                    { 957369114, 361312921, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8084), -1834918312, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8085) },
                    { 975676379, 361312921, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8133), -1323681898, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8134) },
                    { 983556871, 361312921, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8120), 694420727, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8121) },
                    { 525624917, 378896045, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7723), 1560557637, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7724) },
                    { 562043884, 378896045, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7735), -1382340023, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7736) },
                    { 588929402, 378896045, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7698), 251831242, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7699) },
                    { 957369114, 378896045, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7710), -1958986507, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7711) },
                    { 975676379, 378896045, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7759), -1413326245, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7761) },
                    { 983556871, 378896045, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7747), -986295806, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7748) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 525624917, 417929113, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4420), -778375457, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4421) },
                    { 562043884, 417929113, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4434), -835799584, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4435) },
                    { 588929402, 417929113, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4353), 1890375282, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4354) },
                    { 957369114, 417929113, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4366), 2005399940, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4367) },
                    { 975676379, 417929113, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4459), -1353884012, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4460) },
                    { 983556871, 417929113, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4447), 1916537306, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4448) },
                    { 525624917, 425090452, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3995), -2080312703, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3996) },
                    { 562043884, 425090452, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4008), 445728056, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4009) },
                    { 588929402, 425090452, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3969), -1673240696, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3970) },
                    { 957369114, 425090452, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3982), -19682635, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3983) },
                    { 975676379, 425090452, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4038), 1497004691, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4039) },
                    { 983556871, 425090452, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4025), 1870539620, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4026) },
                    { 525624917, 425280838, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7156), 1590385217, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7157) },
                    { 562043884, 425280838, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7169), 372139480, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7170) },
                    { 588929402, 425280838, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7132), -849431465, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7133) },
                    { 957369114, 425280838, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7144), -1182186494, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7145) },
                    { 975676379, 425280838, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7195), -2100023486, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7196) },
                    { 983556871, 425280838, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7181), -525786106, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7182) },
                    { 525624917, 442441569, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4497), -1233030401, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4498) },
                    { 562043884, 442441569, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4510), 1928160842, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4511) },
                    { 588929402, 442441569, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4472), -1033021313, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4473) },
                    { 957369114, 442441569, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4485), 1793000912, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4486) },
                    { 975676379, 442441569, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4535), -1231272121, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4536) },
                    { 983556871, 442441569, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4522), -1741717295, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4523) },
                    { 525624917, 445938406, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6172), -39339706, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6173) },
                    { 562043884, 445938406, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6184), -1860088283, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6185) },
                    { 588929402, 445938406, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6146), 1247711765, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6148) },
                    { 957369114, 445938406, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6159), 34283084, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6160) },
                    { 975676379, 445938406, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6209), -1574664547, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6210) },
                    { 983556871, 445938406, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6196), -1386834385, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6198) },
                    { 525624917, 464923261, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5564), 238600657, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5565) },
                    { 562043884, 464923261, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5578), -1387544206, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5579) },
                    { 588929402, 464923261, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5536), 753496691, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5537) },
                    { 957369114, 464923261, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5551), 597449903, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5552) },
                    { 975676379, 464923261, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5604), 2042286606, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5605) },
                    { 983556871, 464923261, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5591), 1887780915, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5592) },
                    { 525624917, 472208031, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5105), -840716225, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5107) },
                    { 562043884, 472208031, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5118), -281920841, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5119) },
                    { 588929402, 472208031, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5080), 2023678688, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5082) },
                    { 957369114, 472208031, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5093), -427671868, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5094) },
                    { 975676379, 472208031, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5143), 1655343495, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5144) },
                    { 983556871, 472208031, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5131), -1864296697, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5132) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 525624917, 479330834, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5486), 1794989817, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5487) },
                    { 562043884, 479330834, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5498), -1720018894, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5499) },
                    { 588929402, 479330834, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5461), 1755760649, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5462) },
                    { 957369114, 479330834, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5473), -2032774793, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5474) },
                    { 975676379, 479330834, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5524), 1795478166, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5525) },
                    { 983556871, 479330834, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5511), -728128844, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5512) },
                    { 525624917, 502473476, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4879), -743693701, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4880) },
                    { 562043884, 502473476, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4892), -320153165, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4893) },
                    { 588929402, 502473476, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4854), -1713090730, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4855) },
                    { 957369114, 502473476, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4867), 2106216486, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4868) },
                    { 975676379, 502473476, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4917), 1284546578, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4918) },
                    { 983556871, 502473476, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4904), -1020461579, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4905) },
                    { 525624917, 506457823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7871), 286759243, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7872) },
                    { 562043884, 506457823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7883), -115742060, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7884) },
                    { 588929402, 506457823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7846), 1749785243, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7847) },
                    { 957369114, 506457823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7859), 248936023, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7860) },
                    { 975676379, 506457823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7908), -571684436, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7909) },
                    { 983556871, 506457823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7895), 910684868, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7897) },
                    { 525624917, 507368471, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8317), 1333736406, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8318) },
                    { 562043884, 507368471, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8329), -1268205502, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8330) },
                    { 588929402, 507368471, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8292), 471690392, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8294) },
                    { 957369114, 507368471, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8305), 824398052, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8306) },
                    { 975676379, 507368471, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8354), -234993032, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8355) },
                    { 983556871, 507368471, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8341), 1550907005, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8342) },
                    { 525624917, 508679199, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7235), -527332490, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7237) },
                    { 562043884, 508679199, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7248), -1275619171, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7249) },
                    { 588929402, 508679199, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7211), -1823350918, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7212) },
                    { 957369114, 508679199, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7223), -218179417, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7224) },
                    { 975676379, 508679199, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7272), 1461296592, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7273) },
                    { 983556871, 508679199, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7260), 421909268, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7261) },
                    { 525624917, 527886942, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4302), -1135308127, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4303) },
                    { 562043884, 527886942, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4316), -1975994140, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4317) },
                    { 588929402, 527886942, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4277), -984610439, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4278) },
                    { 957369114, 527886942, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4290), -1776777128, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4291) },
                    { 975676379, 527886942, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4341), 1458293247, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4342) },
                    { 983556871, 527886942, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4328), 692614616, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4329) },
                    { 525624917, 534555419, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6707), 37759429, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6708) },
                    { 562043884, 534555419, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6719), -1312371148, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6720) },
                    { 588929402, 534555419, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6682), -744050960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6683) },
                    { 957369114, 534555419, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6694), -1316407148, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6696) },
                    { 975676379, 534555419, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6744), -24237607, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6745) },
                    { 983556871, 534555419, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6731), -1839161488, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6732) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 525624917, 545862411, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7571), 796245719, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7573) },
                    { 562043884, 545862411, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7584), -1129307597, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7585) },
                    { 588929402, 545862411, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7547), -623840494, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7548) },
                    { 957369114, 545862411, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7559), -679891157, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7560) },
                    { 975676379, 545862411, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7608), 1175452956, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7610) },
                    { 983556871, 545862411, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7596), -394982612, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7597) },
                    { 525624917, 553815010, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4573), 1975900050, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4574) },
                    { 562043884, 553815010, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4585), -1554167704, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4586) },
                    { 588929402, 553815010, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4548), -1238690780, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4549) },
                    { 957369114, 553815010, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4560), -1232283298, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4561) },
                    { 975676379, 553815010, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4611), 1795531797, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4612) },
                    { 983556871, 553815010, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4598), -1458736478, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4599) },
                    { 525624917, 597207155, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8391), -1346149511, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8392) },
                    { 562043884, 597207155, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8405), 907604627, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8406) },
                    { 588929402, 597207155, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8366), 526983368, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8367) },
                    { 957369114, 597207155, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8378), -729161702, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8380) },
                    { 975676379, 597207155, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8430), -1409298929, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8431) },
                    { 983556871, 597207155, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8418), -1748874352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8419) },
                    { 525624917, 599979897, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6325), -1785438859, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6326) },
                    { 562043884, 599979897, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6337), 81696299, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6338) },
                    { 588929402, 599979897, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6300), -1996833068, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6301) },
                    { 957369114, 599979897, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6312), 1431672516, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6313) },
                    { 975676379, 599979897, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6363), 34070293, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6364) },
                    { 983556871, 599979897, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6350), 1834451496, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6351) },
                    { 525624917, 614939807, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6553), 2118107372, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6554) },
                    { 562043884, 614939807, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6565), -572986777, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6566) },
                    { 588929402, 614939807, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6527), 1868700965, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6528) },
                    { 957369114, 614939807, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6540), -1670465263, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6541) },
                    { 975676379, 614939807, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6590), -1253095559, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6591) },
                    { 983556871, 614939807, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6578), -55893811, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6579) },
                    { 525624917, 624400852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8468), 1271688984, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8469) },
                    { 562043884, 624400852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8480), -1244169949, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8481) },
                    { 588929402, 624400852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8443), 1927951268, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8444) },
                    { 957369114, 624400852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8455), 1836844110, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8456) },
                    { 975676379, 624400852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8505), 1347720899, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8506) },
                    { 983556871, 624400852, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8492), -754677701, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8493) },
                    { 525624917, 634475093, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5641), 166080209, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5642) },
                    { 562043884, 634475093, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5654), 474178919, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5655) },
                    { 588929402, 634475093, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5616), -572377927, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5617) },
                    { 957369114, 634475093, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5629), 367576174, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5630) },
                    { 975676379, 634475093, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5679), 239599351, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5680) },
                    { 983556871, 634475093, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5666), 1249429991, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5668) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 525624917, 663597619, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6096), -578092234, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6097) },
                    { 562043884, 663597619, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6108), -1395161698, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6110) },
                    { 588929402, 663597619, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6071), -1660680625, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6072) },
                    { 957369114, 663597619, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6084), -430528234, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6085) },
                    { 975676379, 663597619, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6134), -1251255523, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6135) },
                    { 983556871, 663597619, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6121), 1406393586, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6122) },
                    { 525624917, 664777008, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5717), 91989775, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5718) },
                    { 562043884, 664777008, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5729), 264306403, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5730) },
                    { 588929402, 664777008, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5692), 360549919, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5693) },
                    { 957369114, 664777008, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5704), -1218245755, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5705) },
                    { 975676379, 664777008, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5754), 126652303, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5755) },
                    { 983556871, 664777008, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5742), -1834261973, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5743) },
                    { 525624917, 668318054, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8243), -1167657646, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8244) },
                    { 562043884, 668318054, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8255), -1848002071, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8257) },
                    { 588929402, 668318054, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8219), -157548100, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8220) },
                    { 957369114, 668318054, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8231), 372945398, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8232) },
                    { 975676379, 668318054, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8280), -1690635100, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8281) },
                    { 983556871, 668318054, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8268), -567935563, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8269) },
                    { 525624917, 687749137, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7083), -142092346, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7084) },
                    { 562043884, 687749137, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7095), -1353200192, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7097) },
                    { 588929402, 687749137, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7059), -512378068, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7060) },
                    { 957369114, 687749137, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7071), 1382792603, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7072) },
                    { 975676379, 687749137, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7119), 1194309761, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7121) },
                    { 983556871, 687749137, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7107), 1484379369, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7109) },
                    { 525624917, 697463073, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6931), 1520227175, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6932) },
                    { 562043884, 697463073, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6943), 773211524, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6944) },
                    { 588929402, 697463073, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6906), -99776420, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6907) },
                    { 957369114, 697463073, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6918), -555986312, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6919) },
                    { 975676379, 697463073, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6968), 2087419388, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6969) },
                    { 983556871, 697463073, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6955), 242482127, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6956) },
                    { 525624917, 724754269, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8170), 985659233, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8171) },
                    { 562043884, 724754269, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8182), 1595903733, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8183) },
                    { 588929402, 724754269, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8145), -1070502916, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8146) },
                    { 957369114, 724754269, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8157), 2136827210, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8159) },
                    { 975676379, 724754269, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8206), 1095273581, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8207) },
                    { 983556871, 724754269, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8194), 1665834521, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8195) },
                    { 525624917, 735691866, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4075), -594483227, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4076) },
                    { 562043884, 735691866, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4088), 1087149029, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4089) },
                    { 588929402, 735691866, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4051), 1599279116, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4052) },
                    { 957369114, 735691866, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4063), -635870897, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4064) },
                    { 975676379, 735691866, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4114), -132600253, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4115) },
                    { 983556871, 735691866, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4101), -1456990240, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4102) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 525624917, 741083827, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3918), -1670469475, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3919) },
                    { 562043884, 741083827, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3931), 1466388927, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3932) },
                    { 588929402, 741083827, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3888), -723555665, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3889) },
                    { 957369114, 741083827, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3905), -1176671321, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3906) },
                    { 975676379, 741083827, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3956), -1215826501, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3957) },
                    { 983556871, 741083827, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3943), -1853983525, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(3944) },
                    { 525624917, 746606342, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6401), 123074339, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6402) },
                    { 562043884, 746606342, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6413), 1055528960, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6414) },
                    { 588929402, 746606342, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6376), 178531061, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6377) },
                    { 957369114, 746606342, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6388), -1414632338, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6389) },
                    { 975676379, 746606342, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6439), 187223689, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6440) },
                    { 983556871, 746606342, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6426), 1206378671, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6427) },
                    { 525624917, 748388558, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4724), -261836914, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4725) },
                    { 562043884, 748388558, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4736), 1765912586, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4737) },
                    { 588929402, 748388558, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4698), 1824052095, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4699) },
                    { 957369114, 748388558, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4711), 109536049, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4712) },
                    { 975676379, 748388558, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4765), 948995330, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4766) },
                    { 983556871, 748388558, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4748), -771725650, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4750) },
                    { 525624917, 798428292, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4152), 1373262044, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4153) },
                    { 562043884, 798428292, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4164), 1392905831, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4165) },
                    { 588929402, 798428292, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4127), 1126917315, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4128) },
                    { 957369114, 798428292, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4139), 299088869, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4140) },
                    { 975676379, 798428292, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4189), 2059771131, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4190) },
                    { 983556871, 798428292, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4177), 1842902622, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4178) },
                    { 525624917, 805106422, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7382), 1967767065, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7383) },
                    { 562043884, 805106422, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7394), -667179283, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7395) },
                    { 588929402, 805106422, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7358), 1116244908, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7359) },
                    { 957369114, 805106422, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7370), -1794642650, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7371) },
                    { 975676379, 805106422, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7457), -623351227, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7459) },
                    { 983556871, 805106422, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7443), 373050352, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7444) },
                    { 525624917, 813109363, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7309), 1666698633, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7310) },
                    { 562043884, 813109363, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7321), 190080968, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7322) },
                    { 588929402, 813109363, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7284), -1047307490, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7285) },
                    { 957369114, 813109363, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7297), -2075514898, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7298) },
                    { 975676379, 813109363, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7345), -1191102731, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7346) },
                    { 983556871, 813109363, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7333), -1108138877, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7334) },
                    { 525624917, 815691334, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4648), -1094070302, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4650) },
                    { 562043884, 815691334, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4661), 1851500178, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4662) },
                    { 588929402, 815691334, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4623), 2121153327, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4625) },
                    { 957369114, 815691334, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4636), 301097404, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4637) },
                    { 975676379, 815691334, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4686), -1193424403, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4687) },
                    { 983556871, 815691334, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4673), -859975951, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4674) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 525624917, 894959377, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7944), 1199844203, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7946) },
                    { 562043884, 894959377, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7957), 200063827, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7958) },
                    { 588929402, 894959377, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7920), -1832482763, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7921) },
                    { 957369114, 894959377, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7932), 1244314256, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7933) },
                    { 975676379, 894959377, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7981), -1833341579, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7982) },
                    { 983556871, 894959377, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7969), 1985478903, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7970) },
                    { 525624917, 898713298, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4955), -292477391, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4956) },
                    { 562043884, 898713298, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4967), 903067817, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4968) },
                    { 588929402, 898713298, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4929), 1780145955, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4931) },
                    { 957369114, 898713298, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4942), 1393613771, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4943) },
                    { 975676379, 898713298, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4992), -612076076, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4993) },
                    { 983556871, 898713298, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4980), -1464060086, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(4981) },
                    { 525624917, 906115823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7006), -1297977425, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7007) },
                    { 562043884, 906115823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7022), 1420390787, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7023) },
                    { 588929402, 906115823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6981), -484338455, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6982) },
                    { 957369114, 906115823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6994), -2043648422, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6995) },
                    { 975676379, 906115823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7046), 1250105526, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7048) },
                    { 983556871, 906115823, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7034), 949111475, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7035) },
                    { 525624917, 908288918, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6249), -883128698, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6250) },
                    { 562043884, 908288918, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6262), -908478958, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6263) },
                    { 588929402, 908288918, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6222), 1114263495, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6223) },
                    { 957369114, 908288918, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6236), -1739616808, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6238) },
                    { 975676379, 908288918, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6287), -596409799, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6288) },
                    { 983556871, 908288918, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6274), -1782837152, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6276) },
                    { 525624917, 909571258, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8021), 418542233, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8022) },
                    { 562043884, 909571258, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8034), 377193704, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8035) },
                    { 588929402, 909571258, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7994), 713141636, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7995) },
                    { 957369114, 909571258, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8006), -858816818, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8007) },
                    { 975676379, 909571258, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8059), 249764824, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8060) },
                    { 983556871, 909571258, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8046), 700855286, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(8047) },
                    { 525624917, 918918207, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6632), 98867611, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6633) },
                    { 562043884, 918918207, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6644), 269367035, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6645) },
                    { 588929402, 918918207, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6603), -1532951896, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6604) },
                    { 957369114, 918918207, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6615), -898454555, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6617) },
                    { 975676379, 918918207, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6669), -674581261, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6670) },
                    { 983556871, 918918207, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6657), 202873717, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6658) },
                    { 525624917, 930717267, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6021), -388092059, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6022) },
                    { 562043884, 930717267, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6033), 126803300, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6034) },
                    { 588929402, 930717267, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5995), -1175610586, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5996) },
                    { 957369114, 930717267, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6008), -1290742595, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6009) },
                    { 975676379, 930717267, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6058), 1575314618, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6059) },
                    { 983556871, 930717267, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6046), -816276086, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(6047) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 525624917, 933655355, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7497), -1500579854, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7498) },
                    { 562043884, 933655355, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7510), -1250617274, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7511) },
                    { 588929402, 933655355, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7471), 1297022544, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7472) },
                    { 957369114, 933655355, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7484), -729121706, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7486) },
                    { 975676379, 933655355, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7534), 1642373807, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7535) },
                    { 983556871, 933655355, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7522), -730278751, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7523) },
                    { 525624917, 964015583, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5335), 1298977128, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5336) },
                    { 562043884, 964015583, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5348), 1686776270, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5349) },
                    { 588929402, 964015583, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5310), -1436891386, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5311) },
                    { 957369114, 964015583, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5323), 202205755, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5324) },
                    { 975676379, 964015583, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5373), 477700295, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5374) },
                    { 983556871, 964015583, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5360), 1218069014, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5362) },
                    { 525624917, 989154771, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5945), -798445502, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5946) },
                    { 562043884, 989154771, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5957), 314357284, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5958) },
                    { 588929402, 989154771, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5920), -2003105443, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5921) },
                    { 957369114, 989154771, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5932), 464076185, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5933) },
                    { 975676379, 989154771, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5982), 170158208, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5984) },
                    { 983556871, 989154771, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5970), -646109873, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(5971) },
                    { 525624917, 999877527, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7649), 474033776, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7650) },
                    { 562043884, 999877527, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7661), -147692240, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7662) },
                    { 588929402, 999877527, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7621), -1224786937, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7622) },
                    { 957369114, 999877527, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7636), -539568800, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7637) },
                    { 975676379, 999877527, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7686), -1069362746, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7687) },
                    { 983556871, 999877527, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7673), -1185081452, new DateTime(2024, 3, 1, 14, 19, 19, 545, DateTimeKind.Local).AddTicks(7674) }
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
                name: "IX_Drawings_DisciplineId",
                table: "Drawings",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Drawings_TypeId",
                table: "Drawings",
                column: "TypeId");

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
                name: "IX_Others_DisciplineId",
                table: "Others",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Others_TypeId",
                table: "Others",
                column: "TypeId");

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
                name: "FK_Drawings_Disciplines_DisciplineId",
                table: "Drawings",
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
                name: "FK_Others_Disciplines_DisciplineId",
                table: "Others",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "Drawings");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "TimeSpans");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "DrawingTypes");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "OtherTypes");

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
