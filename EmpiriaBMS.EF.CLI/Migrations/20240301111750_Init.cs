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
                    { 131182522, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2806), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2807), "HVAC" },
                    { 156387319, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2897), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2898), "Natural Gas" },
                    { 291566799, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2823), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2824), "Sewage" },
                    { 309960519, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2871), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2872), "Fire Suppression" },
                    { 343890667, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3012), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3013), "Construction Supervision" },
                    { 422462724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2954), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2955), "BMS" },
                    { 440558130, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2885), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2887), "Elevators" },
                    { 446961184, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2977), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2978), "Energy Efficiency" },
                    { 500269530, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2966), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2967), "Photovoltaics" },
                    { 503804824, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2988), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2989), "Outsource" },
                    { 507543947, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2921), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2922), "Structured Cabling" },
                    { 565702697, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2943), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2944), "CCTV" },
                    { 614356470, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2846), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2848), "Drainage" },
                    { 817814325, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2999), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3000), "TenderDocument" },
                    { 824195011, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2858), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2859), "Fire Detection" },
                    { 875389553, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2908), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2909), "Power Distribution" },
                    { 911183598, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2835), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2836), "Potable Water" },
                    { 943669407, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2932), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2933), "Burglar Alarm" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 441749356, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3196), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3197), "Documents" },
                    { 889882401, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3230), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3231), "Drawings" },
                    { 966491586, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3218), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3220), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 143872037, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3762), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3763), "On-Site" },
                    { 454118585, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3786), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3787), "Administration" },
                    { 590389564, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3731), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3732), "Communications" },
                    { 908767037, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3774), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3775), "Meetings" },
                    { 935302452, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3750), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3751), "Printing" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 181048651, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2330), "Buildings Description", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2332), "Buildings" },
                    { 433055855, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2364), "Energy Description", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2366), "Energy" },
                    { 647545287, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2350), "Infrastructure Description", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2352), "Infrastructure" },
                    { 976895239, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2377), "Consulting Description", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2378), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 133411095, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1657), true, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1658), "Engineer" },
                    { 166175020, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1679), true, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1680), "CTO" },
                    { 192754539, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1694), false, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1695), "Guest" },
                    { 244511701, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1672), true, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1673), "COO" },
                    { 352125526, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1649), true, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1650), "Designer" },
                    { 760031217, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1686), true, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1687), "CEO" },
                    { 894769190, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1701), false, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1702), "Customer" },
                    { 958430942, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1665), true, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1666), "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 139864914, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2463), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2464), null, "6949277783", null, null, null },
                    { 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2198), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2199), null, "6949277781", null, null, null },
                    { 213200345, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2141), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2142), null, "6949277785", null, null, null },
                    { 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2251), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2252), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 423211724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2400), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2401), null, "6949277781", null, null, null },
                    { 437684906, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1977), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1978), null, "6949277780", null, null, null },
                    { 459288229, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2029), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2030), null, "6949277781", null, null, null },
                    { 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2277), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2278), null, "6949277784", null, null, null },
                    { 696973815, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1947), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1948), null, "694927778", null, null, null },
                    { 708219481, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2108), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2109), null, "6949277784", null, null, null },
                    { 722150691, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2056), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2057), null, "6949277782", null, null, null },
                    { 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2225), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2226), null, "6949277782", null, null, null },
                    { 836085508, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1919), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1921), null, "694927778", null, null, null },
                    { 881591317, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2491), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2492), null, "6949277784", null, null, null },
                    { 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2304), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2305), null, "6949277785", null, null, null },
                    { 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2168), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2169), null, "6949277780", null, null, null },
                    { 948169155, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1891), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1892), null, "694927778", null, null, null },
                    { 969792370, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1849), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1851), null, "694927778", null, null, null },
                    { 972641767, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2434), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2436), null, "6949277782", null, null, null },
                    { 980894295, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2083), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2084), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 495845210, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 9.0, 16, new DateTime(2025, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 16, "Test Description Project_12", "KL-4", new DateTime(2025, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), new DateTime(2025, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 0f, 100L, 12L, new DateTime(2024, 3, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), "Project_4", 5.0, new DateTime(2025, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), "Payment Detailes For Project_8", 4.0, null, 976895239, new DateTime(2025, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 0f },
                    { 834945847, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 7.0, 4, new DateTime(2024, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 4, "Test Description Project_12", "KL-2", new DateTime(2024, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), new DateTime(2024, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 0f, 100L, 12L, new DateTime(2024, 3, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), "Project_2", 5.0, new DateTime(2024, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), "Payment Detailes For Project_12", 2.0, null, 647545287, new DateTime(2024, 7, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 0f },
                    { 838875609, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 6.0, 1, new DateTime(2024, 4, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 1, "Test Description Project_1", "KL-1", new DateTime(2024, 4, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), new DateTime(2024, 4, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 0f, 100L, 12L, new DateTime(2024, 3, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), "Project_1", 5.0, new DateTime(2024, 4, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), "Payment Detailes For Project_5", 1.0, null, 181048651, new DateTime(2024, 4, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 0f },
                    { 963844955, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 8.0, 9, new DateTime(2024, 12, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 9, "Test Description Project_12", "KL-3", new DateTime(2024, 12, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), new DateTime(2024, 12, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 0f, 100L, 12L, new DateTime(2024, 3, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), "Project_3", 5.0, new DateTime(2024, 12, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), "Payment Detailes For Project_6", 3.0, null, 433055855, new DateTime(2024, 12, 1, 13, 17, 49, 875, DateTimeKind.Local).AddTicks(3776), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 958430942, 139864914, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2478), 376059393, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2479) },
                    { 133411095, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2212), 598792122, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2214) },
                    { 352125526, 213200345, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2155), 850933447, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2156) },
                    { 133411095, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2265), 230826644, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2266) },
                    { 958430942, 423211724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2419), 824676687, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2420) },
                    { 352125526, 437684906, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2015), 483473874, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2016) },
                    { 352125526, 459288229, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2044), 695120047, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2045) },
                    { 133411095, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2291), 596218331, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2293) },
                    { 192754539, 696973815, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1960), 954940590, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1962) },
                    { 352125526, 708219481, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2128), 798051610, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2129) },
                    { 352125526, 722150691, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2070), 949649973, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2072) },
                    { 133411095, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2239), 314794615, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2241) },
                    { 244511701, 836085508, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1933), 563210841, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1934) },
                    { 958430942, 881591317, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2506), 996362702, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2507) },
                    { 133411095, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2317), 698179132, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2318) },
                    { 133411095, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2185), 494903403, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2187) },
                    { 166175020, 948169155, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1905), 136107823, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1906) },
                    { 760031217, 969792370, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1871), 428061344, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(1872) },
                    { 958430942, 972641767, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2451), 766624861, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2452) },
                    { 352125526, 980894295, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2096), 933806448, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2097) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1630779528, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3102), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3103), 834945847, 131182522, null },
                    { -1549676416, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3116), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3117), 963844955, 507543947, null },
                    { -1394926120, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3089), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3090), 834945847, 291566799, null },
                    { -1145310472, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3076), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3077), 834945847, 614356470, null },
                    { -1014922568, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3154), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3155), 495845210, 500269530, null },
                    { -919671840, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3140), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3141), 963844955, 911183598, null },
                    { -513011872, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3029), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3031), 838875609, 291566799, null },
                    { -397397728, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3128), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3129), 963844955, 422462724, null },
                    { 438040376, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3170), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3171), 495845210, 291566799, null },
                    { 686713632, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3063), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3064), 838875609, 875389553, null },
                    { 846686440, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3050), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3051), 838875609, 440558130, null },
                    { 1035029272, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3183), 0f, 1500L, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3184), 495845210, 824195011, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 148963409, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2594), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2596), 3010.0, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2595), "Signature 142342", 20188, 838875609, 1.0, 17.0 },
                    { 406579886, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2728), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2730), 4000.0, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2729), "Signature 142343", 89804, 963844955, 3.0, 17.0 },
                    { 604463102, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2788), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2790), 13000.0, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2789), "Signature 1423420", 63400, 495845210, 4.0, 24.0 },
                    { 728050805, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2666), new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2668), 3100.0, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2667), "Signature 142342", 49273, 834945847, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 963844955, 139864914, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4550), 617980568, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4552) },
                    { 838875609, 423211724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4521), 383108465, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4523) },
                    { 495845210, 881591317, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4562), 938079031, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4563) },
                    { 834945847, 972641767, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4538), 126439472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4539) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 215774450, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2638), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2639), null, "6949277782", null, null, 834945847 },
                    { 355968865, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2701), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2703), null, "6949277783", null, null, 963844955 },
                    { 560524994, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2761), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2762), null, "6949277784", null, null, 495845210 },
                    { 736624189, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2562), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2563), null, "6949277781", null, null, 838875609 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1630779528, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4953), 247586357, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4954) },
                    { -1630779528, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4978), 125619881, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4979) },
                    { -1630779528, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4998), 885168581, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5000) },
                    { -1630779528, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4965), 605897688, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4966) },
                    { -1630779528, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5020), 320081857, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5022) },
                    { -1630779528, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4942), 135451098, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4943) },
                    { -1549676416, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5063), 601116873, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5065) },
                    { -1549676416, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5106), 853301550, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5108) },
                    { -1549676416, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5131), 773170696, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5133) },
                    { -1549676416, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5084), 246327908, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5086) },
                    { -1549676416, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5153), 397530608, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5155) },
                    { -1549676416, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5040), 696800349, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5042) },
                    { -1394926120, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4883), 191368326, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4884) },
                    { -1394926120, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4907), 165008098, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4908) },
                    { -1394926120, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4918), 238888368, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4920) },
                    { -1394926120, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4895), 515042921, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4896) },
                    { -1394926120, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4930), 584318415, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4931) },
                    { -1394926120, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4871), 336178884, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4872) },
                    { -1145310472, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4813), 470864283, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4814) },
                    { -1145310472, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4836), 414646554, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4837) },
                    { -1145310472, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4847), 799178317, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4849) },
                    { -1145310472, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4824), 821253739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4825) },
                    { -1145310472, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4859), 224769924, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4860) },
                    { -1145310472, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4801), 342147206, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4802) },
                    { -1014922568, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5337), 691447922, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5338) },
                    { -1014922568, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5360), 713127215, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5361) },
                    { -1014922568, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5371), 188736972, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5373) },
                    { -1014922568, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5348), 525829243, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5349) },
                    { -1014922568, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5383), 243595281, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5384) },
                    { -1014922568, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5325), 457464769, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5326) },
                    { -919671840, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5266), 362705707, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5267) },
                    { -919671840, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5290), 165119960, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5291) },
                    { -919671840, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5302), 498052780, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5303) },
                    { -919671840, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5278), 478187017, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5279) },
                    { -919671840, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5313), 338172429, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5314) },
                    { -919671840, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5254), 745862227, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5255) },
                    { -513011872, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4590), 724474436, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4591) },
                    { -513011872, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4614), 398268777, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4615) },
                    { -513011872, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4626), 339754355, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4627) },
                    { -513011872, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4602), 890045069, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4603) },
                    { -513011872, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4639), 965970784, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4640) },
                    { -513011872, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4575), 212945432, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4576) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -397397728, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5194), 278668630, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5195) },
                    { -397397728, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5218), 553938580, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5219) },
                    { -397397728, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5230), 756839578, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5231) },
                    { -397397728, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5206), 564701952, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5207) },
                    { -397397728, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5242), 398744996, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5243) },
                    { -397397728, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5175), 267998717, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5177) },
                    { 438040376, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5407), 421955380, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5408) },
                    { 438040376, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5430), 807166519, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5431) },
                    { 438040376, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5442), 185416130, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5443) },
                    { 438040376, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5418), 630713658, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5419) },
                    { 438040376, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5455), 450857937, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5457) },
                    { 438040376, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5395), 342138582, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5396) },
                    { 686713632, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4741), 596420437, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4742) },
                    { 686713632, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4764), 976639573, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4765) },
                    { 686713632, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4776), 924163279, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4777) },
                    { 686713632, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4753), 576168187, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4754) },
                    { 686713632, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4789), 503692029, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4790) },
                    { 686713632, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4725), 617839083, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4726) },
                    { 846686440, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4664), 766341781, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4665) },
                    { 846686440, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4689), 701669783, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4690) },
                    { 846686440, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4701), 839600919, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4702) },
                    { 846686440, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4676), 530166358, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4677) },
                    { 846686440, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4713), 535848899, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4714) },
                    { 846686440, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4652), 928079504, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4653) },
                    { 1035029272, 152734889, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5483), 791365483, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5484) },
                    { 1035029272, 245485304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5508), 132403621, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5509) },
                    { 1035029272, 665359622, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5519), 247105764, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5520) },
                    { 1035029272, 803930739, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5495), 455517591, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5496) },
                    { 1035029272, 908755791, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5531), 525835322, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5532) },
                    { 1035029272, 945767306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5468), 887836642, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5469) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 131029611, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3357), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3354), 686713632, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3356), 889882401 },
                    { 171860335, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3344), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3342), 686713632, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3343), 966491586 },
                    { 193657824, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3398), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3395), -1145310472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3396), 889882401 },
                    { 197638366, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3451), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3449), -1630779528, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3450), 441749356 },
                    { 208201219, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3372), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3369), -1145310472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3370), 441749356 },
                    { 210016444, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3560), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3558), -397397728, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3559), 889882401 },
                    { 237576788, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3385), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3382), -1145310472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3384), 966491586 },
                    { 243341276, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3318), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3315), 846686440, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3316), 889882401 },
                    { 272937053, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3599), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3597), -919671840, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3598), 889882401 },
                    { 351054883, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3411), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3408), -1394926120, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3409), 441749356 },
                    { 389677599, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3290), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3288), 846686440, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3289), 441749356 },
                    { 429204492, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3547), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3545), -397397728, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3546), 966491586 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 448915576, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3495), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3493), -1549676416, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3494), 441749356 },
                    { 471609059, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3625), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3623), -1014922568, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3624), 966491586 },
                    { 490984597, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3638), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3636), -1014922568, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3637), 889882401 },
                    { 492897345, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3651), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3649), 438040376, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3650), 441749356 },
                    { 514093781, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3521), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3519), -1549676416, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3520), 889882401 },
                    { 540659231, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3303), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3301), 846686440, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3302), 966491586 },
                    { 545517917, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3677), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3675), 438040376, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3676), 889882401 },
                    { 569902311, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3246), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3243), -513011872, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3244), 441749356 },
                    { 580535089, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3331), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3329), 686713632, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3330), 441749356 },
                    { 587290656, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3263), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3261), -513011872, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3262), 966491586 },
                    { 594895429, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3465), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3462), -1630779528, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3464), 966491586 },
                    { 603096665, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3437), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3435), -1394926120, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3436), 889882401 },
                    { 631155109, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3705), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3703), 1035029272, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3704), 966491586 },
                    { 632245896, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3424), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3422), -1394926120, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3423), 966491586 },
                    { 682688685, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3277), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3274), -513011872, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3276), 889882401 },
                    { 704019617, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3692), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3690), 1035029272, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3691), 441749356 },
                    { 744070461, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3573), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3571), -919671840, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3572), 441749356 },
                    { 752888624, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3586), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3584), -919671840, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3585), 966491586 },
                    { 787291552, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3612), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3610), -1014922568, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3611), 441749356 },
                    { 855463022, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3479), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3477), -1630779528, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3478), 889882401 },
                    { 966069243, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3718), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3716), 1035029272, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3717), 889882401 },
                    { 976398161, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3665), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3662), 438040376, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3663), 966491586 },
                    { 983795151, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3535), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3532), -397397728, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3533), 441749356 },
                    { 986176323, new DateTime(2024, 3, 12, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3509), 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3506), -1549676416, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3507), 966491586 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 126541284, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4367), -1014922568, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4368), 143872037 },
                    { 136577526, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3966), 686713632, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3967), 908767037 },
                    { 148389613, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4014), -1145310472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4015), 143872037 },
                    { 163995273, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4084), -1394926120, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4085), 908767037 },
                    { 179811107, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4061), -1394926120, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4062), 935302452 },
                    { 185176793, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4122), -1630779528, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4124), 935302452 },
                    { 198850724, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3931), 686713632, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3932), 590389564 },
                    { 217579447, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4145), -1630779528, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4146), 908767037 },
                    { 225640140, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3919), 846686440, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3920), 454118585 },
                    { 227224539, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4168), -1549676416, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4170), 590389564 },
                    { 283053588, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4344), -1014922568, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4345), 590389564 },
                    { 294268615, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4216), -1549676416, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4217), 454118585 },
                    { 298159446, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4497), 1035029272, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4498), 908767037 },
                    { 299142529, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4191), -1549676416, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4192), 143872037 },
                    { 308551741, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4486), 1035029272, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4487), 143872037 },
                    { 317598094, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3820), -513011872, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3821), 935302452 },
                    { 352214041, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4228), -397397728, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4229), 590389564 },
                    { 360804665, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4239), -397397728, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4240), 935302452 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 374548848, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3894), 846686440, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3895), 143872037 },
                    { 428519788, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3989), -1145310472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3990), 590389564 },
                    { 430092932, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4474), 1035029272, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4475), 935302452 },
                    { 441694434, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4286), -919671840, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4287), 590389564 },
                    { 449651971, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4332), -919671840, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4333), 454118585 },
                    { 504182640, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4205), -1549676416, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4206), 908767037 },
                    { 532678582, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4381), -1014922568, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4382), 908767037 },
                    { 574362352, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3977), 686713632, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3979), 454118585 },
                    { 590860723, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4157), -1630779528, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4158), 454118585 },
                    { 593084567, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4134), -1630779528, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4135), 143872037 },
                    { 617947323, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4111), -1630779528, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4112), 590389564 },
                    { 627978397, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3844), -513011872, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3845), 908767037 },
                    { 645710464, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3943), 686713632, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3944), 935302452 },
                    { 684163488, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4393), -1014922568, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4394), 454118585 },
                    { 724669425, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4072), -1394926120, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4073), 143872037 },
                    { 726076887, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4321), -919671840, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4322), 908767037 },
                    { 730593669, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4001), -1145310472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4002), 935302452 },
                    { 744822954, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4099), -1394926120, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4100), 454118585 },
                    { 752976204, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3832), -513011872, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3833), 143872037 },
                    { 778795009, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4417), 438040376, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4418), 935302452 },
                    { 786646099, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4049), -1394926120, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4050), 590389564 },
                    { 787474029, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4037), -1145310472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4039), 454118585 },
                    { 798809876, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4251), -397397728, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4252), 143872037 },
                    { 810994058, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4508), 1035029272, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4509), 454118585 },
                    { 816042642, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3954), 686713632, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3955), 143872037 },
                    { 819385081, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3870), 846686440, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3871), 590389564 },
                    { 844731621, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4298), -919671840, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4299), 935302452 },
                    { 849374866, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4463), 1035029272, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4464), 590389564 },
                    { 883550348, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4405), 438040376, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4406), 590389564 },
                    { 891389807, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4309), -919671840, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4310), 143872037 },
                    { 892995068, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3856), -513011872, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3857), 454118585 },
                    { 893433997, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4355), -1014922568, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4357), 935302452 },
                    { 893687813, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3804), -513011872, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3805), 590389564 },
                    { 895278567, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4440), 438040376, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4441), 908767037 },
                    { 896645715, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4428), 438040376, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4429), 143872037 },
                    { 907290676, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4180), -1549676416, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4181), 935302452 },
                    { 919686764, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4274), -397397728, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4275), 454118585 },
                    { 936760593, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3882), 846686440, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3884), 935302452 },
                    { 939464914, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4262), -397397728, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4263), 908767037 },
                    { 941433656, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3906), 846686440, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(3907), 908767037 },
                    { 943554268, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4451), 438040376, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4452), 454118585 },
                    { 972200858, 0f, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4026), -1145310472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(4027), 908767037 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 894769190, 215774450, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2653), 760706413, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2655) },
                    { 894769190, 355968865, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2716), 824652055, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2717) },
                    { 894769190, 560524994, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2775), 860361683, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2776) },
                    { 894769190, 736624189, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2579), 427090509, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(2581) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 213200345, 126541284, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8980), -482585782, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8981) },
                    { 437684906, 126541284, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8921), -848150000, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8922) },
                    { 459288229, 126541284, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8933), -2109491630, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8934) },
                    { 708219481, 126541284, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8968), 12297029, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8969) },
                    { 722150691, 126541284, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8945), -2073189653, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8946) },
                    { 980894295, 126541284, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8957), 1176201099, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8958) },
                    { 213200345, 136577526, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6550), 1899160569, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6551) },
                    { 437684906, 136577526, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6488), 2077561193, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6489) },
                    { 459288229, 136577526, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6500), -206823388, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6501) },
                    { 708219481, 136577526, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6538), 113204845, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6539) },
                    { 722150691, 136577526, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6514), 123289907, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6515) },
                    { 980894295, 136577526, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6526), -1268084902, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6527) },
                    { 213200345, 148389613, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6832), 2022374970, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6833) },
                    { 437684906, 148389613, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6773), 942487340, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6774) },
                    { 459288229, 148389613, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6785), -1081151756, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6786) },
                    { 708219481, 148389613, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6820), -334026485, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6821) },
                    { 722150691, 148389613, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6797), -1028375329, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6798) },
                    { 980894295, 148389613, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6808), 251267144, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6810) },
                    { 213200345, 163995273, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7264), 1140777230, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7265) },
                    { 437684906, 163995273, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7206), -1081984990, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7207) },
                    { 459288229, 163995273, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7217), 1096168676, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7218) },
                    { 708219481, 163995273, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7252), -610189037, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7253) },
                    { 722150691, 163995273, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7229), -1308471227, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7230) },
                    { 980894295, 163995273, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7241), -1830324523, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7242) },
                    { 213200345, 179811107, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7121), 1285186172, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7122) },
                    { 437684906, 179811107, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7060), 550915898, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7061) },
                    { 459288229, 179811107, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7072), 161174840, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7073) },
                    { 708219481, 179811107, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7109), -754972717, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7110) },
                    { 722150691, 179811107, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7084), 1838707578, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7085) },
                    { 980894295, 179811107, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7097), -285156940, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7098) },
                    { 213200345, 185176793, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7476), 1948565624, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7478) },
                    { 437684906, 185176793, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7417), -868236709, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7418) },
                    { 459288229, 185176793, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7429), -1356674660, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7430) },
                    { 708219481, 185176793, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7464), 955752539, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7465) },
                    { 722150691, 185176793, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7441), 1141148511, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7442) },
                    { 980894295, 185176793, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7453), -151194892, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7454) },
                    { 213200345, 198850724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6334), -428544098, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6335) },
                    { 437684906, 198850724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6274), -1262574922, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6275) },
                    { 459288229, 198850724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6286), -1421135734, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6287) },
                    { 708219481, 198850724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6321), -76682236, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6323) },
                    { 722150691, 198850724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6298), 548007107, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6299) },
                    { 980894295, 198850724, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6310), -339330365, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6311) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 213200345, 217579447, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7621), -842979833, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7622) },
                    { 437684906, 217579447, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7562), -1687722988, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7563) },
                    { 459288229, 217579447, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7574), 1886172993, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7575) },
                    { 708219481, 217579447, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7609), 308156446, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7610) },
                    { 722150691, 217579447, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7586), 110791000, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7587) },
                    { 980894295, 217579447, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7597), -528393559, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7598) },
                    { 213200345, 225640140, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6262), -1174031383, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6263) },
                    { 437684906, 225640140, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6204), 1519226519, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6205) },
                    { 459288229, 225640140, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6216), 1810218434, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6217) },
                    { 708219481, 225640140, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6250), -892306187, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6252) },
                    { 722150691, 225640140, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6227), -55996721, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6228) },
                    { 980894295, 225640140, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6239), -1421148793, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6240) },
                    { 213200345, 227224539, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7762), 951733508, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7763) },
                    { 437684906, 227224539, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7704), -275053967, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7705) },
                    { 459288229, 227224539, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7715), -1766894885, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7716) },
                    { 708219481, 227224539, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7751), -665583344, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7752) },
                    { 722150691, 227224539, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7727), 362433245, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7728) },
                    { 980894295, 227224539, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7739), -877136210, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7740) },
                    { 213200345, 283053588, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8839), 1503890856, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8840) },
                    { 437684906, 283053588, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8777), -1971311255, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8778) },
                    { 459288229, 283053588, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8788), 32719366, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8789) },
                    { 708219481, 283053588, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8827), 937628591, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8828) },
                    { 722150691, 283053588, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8800), -139681237, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8801) },
                    { 980894295, 283053588, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8816), 1332518391, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8817) },
                    { 213200345, 294268615, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8049), -1265258132, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8050) },
                    { 437684906, 294268615, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7990), 1044670073, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7991) },
                    { 459288229, 294268615, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8002), -72476360, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8003) },
                    { 708219481, 294268615, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8037), 1867666379, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8038) },
                    { 722150691, 294268615, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8014), -488944507, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8015) },
                    { 980894295, 294268615, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8026), 2002851806, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8027) },
                    { 213200345, 298159446, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9764), -1165905647, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9765) },
                    { 437684906, 298159446, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9705), -1232810459, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9706) },
                    { 459288229, 298159446, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9717), 185624974, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9718) },
                    { 708219481, 298159446, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9752), -1821181900, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9753) },
                    { 722150691, 298159446, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9729), 1461265745, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9730) },
                    { 980894295, 298159446, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9740), 1551211268, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9741) },
                    { 213200345, 299142529, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7907), 876996932, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7909) },
                    { 437684906, 299142529, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7845), -361761331, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7846) },
                    { 459288229, 299142529, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7857), 1969175894, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7858) },
                    { 708219481, 299142529, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7896), -501112115, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7897) },
                    { 722150691, 299142529, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7869), -2008415686, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7870) },
                    { 980894295, 299142529, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7881), -1335025390, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7882) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 213200345, 308551741, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9693), -219539249, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9694) },
                    { 437684906, 308551741, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9634), -701865220, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9635) },
                    { 459288229, 308551741, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9646), -475742591, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9647) },
                    { 708219481, 308551741, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9681), -265740065, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9682) },
                    { 722150691, 308551741, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9658), -1278855247, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9659) },
                    { 980894295, 308551741, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9669), -1556039767, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9671) },
                    { 213200345, 317598094, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5685), 166827097, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5686) },
                    { 437684906, 317598094, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5624), 1825485408, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5625) },
                    { 459288229, 317598094, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5636), -357146086, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5637) },
                    { 708219481, 317598094, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5673), 276031657, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5674) },
                    { 722150691, 317598094, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5647), 220426597, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5649) },
                    { 980894295, 317598094, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5660), -950436040, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5661) },
                    { 213200345, 352214041, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8120), -89557879, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8121) },
                    { 437684906, 352214041, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8061), -2080035656, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8062) },
                    { 459288229, 352214041, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8073), -1778772775, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8074) },
                    { 708219481, 352214041, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8108), -1749239491, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8109) },
                    { 722150691, 352214041, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8084), -157752409, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8086) },
                    { 980894295, 352214041, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8096), -1193103409, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8097) },
                    { 213200345, 360804665, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8191), 1803525665, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8192) },
                    { 437684906, 360804665, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8131), -1800943505, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8133) },
                    { 459288229, 360804665, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8143), -1119825062, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8144) },
                    { 708219481, 360804665, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8179), 659025752, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8180) },
                    { 722150691, 360804665, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8155), 760156124, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8157) },
                    { 980894295, 360804665, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8167), -1478947054, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8168) },
                    { 213200345, 374548848, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6118), 714171533, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6119) },
                    { 437684906, 374548848, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6059), 107045506, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6060) },
                    { 459288229, 374548848, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6071), -183896311, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6072) },
                    { 708219481, 374548848, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6106), -414943033, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6107) },
                    { 722150691, 374548848, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6082), 1305731984, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6083) },
                    { 980894295, 374548848, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6094), 1381482779, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6095) },
                    { 213200345, 428519788, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6691), 7914529, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6692) },
                    { 437684906, 428519788, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6632), 282653717, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6634) },
                    { 459288229, 428519788, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6644), 239504743, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6645) },
                    { 708219481, 428519788, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6679), -1750607293, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6680) },
                    { 722150691, 428519788, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6656), -564317995, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6657) },
                    { 980894295, 428519788, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6667), 180973315, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6669) },
                    { 213200345, 430092932, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9623), -622415920, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9624) },
                    { 437684906, 430092932, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9564), -74267941, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9565) },
                    { 459288229, 430092932, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9575), 191225705, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9576) },
                    { 708219481, 430092932, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9611), 711015080, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9612) },
                    { 722150691, 430092932, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9587), -892693628, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9588) },
                    { 980894295, 430092932, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9599), -1520879399, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9600) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 213200345, 441694434, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8477), -1735072870, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8478) },
                    { 437684906, 441694434, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8418), -17232506, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8419) },
                    { 459288229, 441694434, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8430), 1721051595, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8431) },
                    { 708219481, 441694434, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8465), -449834102, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8466) },
                    { 722150691, 441694434, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8442), 613425263, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8443) },
                    { 980894295, 441694434, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8453), 1165525182, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8454) },
                    { 213200345, 449651971, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8764), -81796238, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8766) },
                    { 437684906, 449651971, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8705), 1958570906, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8706) },
                    { 459288229, 449651971, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8717), -1037276684, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8718) },
                    { 708219481, 449651971, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8752), 600681803, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8753) },
                    { 722150691, 449651971, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8729), 1783749582, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8730) },
                    { 980894295, 449651971, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8741), -1683179972, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8742) },
                    { 213200345, 504182640, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7978), 1889167136, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7979) },
                    { 437684906, 504182640, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7919), 593377718, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7921) },
                    { 459288229, 504182640, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7931), 1528133711, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7932) },
                    { 708219481, 504182640, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7967), 2064286157, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7968) },
                    { 722150691, 504182640, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7943), 24641470, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7944) },
                    { 980894295, 504182640, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7955), -887699776, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7956) },
                    { 213200345, 532678582, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9050), 1929896699, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9051) },
                    { 437684906, 532678582, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8992), 63013289, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8993) },
                    { 459288229, 532678582, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9003), -116302378, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9005) },
                    { 708219481, 532678582, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9039), 1969082253, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9040) },
                    { 722150691, 532678582, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9015), 353152585, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9016) },
                    { 980894295, 532678582, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9027), -1501251403, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9028) },
                    { 213200345, 574362352, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6621), -766757150, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6622) },
                    { 437684906, 574362352, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6562), -1795719316, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6563) },
                    { 459288229, 574362352, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6574), -2064677300, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6575) },
                    { 708219481, 574362352, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6609), -1820516566, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6610) },
                    { 722150691, 574362352, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6586), 2094581700, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6587) },
                    { 980894295, 574362352, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6597), -625925231, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6598) },
                    { 213200345, 590860723, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7692), -2101305127, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7693) },
                    { 437684906, 590860723, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7633), 1825929977, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7634) },
                    { 459288229, 590860723, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7645), 1731434387, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7646) },
                    { 708219481, 590860723, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7680), -1744153406, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7681) },
                    { 722150691, 590860723, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7656), -1513291450, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7658) },
                    { 980894295, 590860723, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7668), -925465882, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7669) },
                    { 213200345, 593084567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7550), 1335254216, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7551) },
                    { 437684906, 593084567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7489), -1912006817, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7490) },
                    { 459288229, 593084567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7500), -855204655, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7501) },
                    { 708219481, 593084567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7538), 519083645, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7539) },
                    { 722150691, 593084567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7512), -1612989445, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7513) },
                    { 980894295, 593084567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7526), -1274854211, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7528) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 213200345, 617947323, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7406), -976693337, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7407) },
                    { 437684906, 617947323, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7347), -1064127883, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7348) },
                    { 459288229, 617947323, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7359), -1099890089, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7360) },
                    { 708219481, 617947323, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7394), 574643336, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7395) },
                    { 722150691, 617947323, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7370), 1529882663, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7372) },
                    { 980894295, 617947323, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7383), 1810201329, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7384) },
                    { 213200345, 627978397, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5829), 1053800447, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5830) },
                    { 437684906, 627978397, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5770), 2015329379, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5771) },
                    { 459288229, 627978397, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5782), -1777232308, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5783) },
                    { 708219481, 627978397, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5817), 627221768, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5818) },
                    { 722150691, 627978397, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5794), -831235243, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5795) },
                    { 980894295, 627978397, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5806), -1286426213, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5807) },
                    { 213200345, 645710464, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6406), -21229289, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6407) },
                    { 437684906, 645710464, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6347), -117474146, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6348) },
                    { 459288229, 645710464, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6359), 701765636, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6360) },
                    { 708219481, 645710464, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6394), 1297536912, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6395) },
                    { 722150691, 645710464, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6370), -35095904, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6372) },
                    { 980894295, 645710464, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6382), -607045463, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6383) },
                    { 213200345, 684163488, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9121), -1558904453, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9123) },
                    { 437684906, 684163488, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9062), -241332443, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9064) },
                    { 459288229, 684163488, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9074), 557356163, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9075) },
                    { 708219481, 684163488, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9110), -742551659, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9111) },
                    { 722150691, 684163488, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9086), -549129185, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9087) },
                    { 980894295, 684163488, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9098), -871106314, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9099) },
                    { 213200345, 724669425, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7194), -1498923269, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7195) },
                    { 437684906, 724669425, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7133), -2011524646, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7134) },
                    { 459288229, 724669425, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7144), -502416796, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7145) },
                    { 708219481, 724669425, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7182), 1635388961, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7183) },
                    { 722150691, 724669425, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7159), -811362995, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7160) },
                    { 980894295, 724669425, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7171), 47457001, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7172) },
                    { 213200345, 726076887, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8694), -1141673017, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8695) },
                    { 437684906, 726076887, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8635), 166695233, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8636) },
                    { 459288229, 726076887, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8646), 261201142, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8647) },
                    { 708219481, 726076887, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8682), 1465776572, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8683) },
                    { 722150691, 726076887, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8658), -1462711733, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8659) },
                    { 980894295, 726076887, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8670), 2079147528, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8671) },
                    { 213200345, 730593669, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6761), 349106212, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6762) },
                    { 437684906, 730593669, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6703), -1890378301, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6704) },
                    { 459288229, 730593669, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6715), -294456941, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6716) },
                    { 708219481, 730593669, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6749), 1234331789, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6750) },
                    { 722150691, 730593669, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6726), -1387119608, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6727) },
                    { 980894295, 730593669, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6738), 4251826, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6739) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 213200345, 744822954, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7335), -629737168, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7336) },
                    { 437684906, 744822954, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7277), -609444751, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7278) },
                    { 459288229, 744822954, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7288), 930878087, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7289) },
                    { 708219481, 744822954, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7323), 1556153330, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7324) },
                    { 722150691, 744822954, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7300), -1394815472, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7301) },
                    { 980894295, 744822954, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7311), 1662359477, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7312) },
                    { 213200345, 752976204, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5758), -1399832378, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5759) },
                    { 437684906, 752976204, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5697), -727829752, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5698) },
                    { 459288229, 752976204, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5709), -1805027921, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5710) },
                    { 708219481, 752976204, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5745), -676581619, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5746) },
                    { 722150691, 752976204, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5721), 1400859054, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5722) },
                    { 980894295, 752976204, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5733), 2124154913, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5734) },
                    { 213200345, 778795009, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9265), -596091154, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9267) },
                    { 437684906, 778795009, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9206), -2100329711, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9208) },
                    { 459288229, 778795009, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9218), -1667988157, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9220) },
                    { 708219481, 778795009, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9254), 412681019, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9255) },
                    { 722150691, 778795009, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9230), -36123677, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9231) },
                    { 980894295, 778795009, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9242), 70863625, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9243) },
                    { 213200345, 786646099, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7048), -1095453310, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7049) },
                    { 437684906, 786646099, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6989), -750690805, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6990) },
                    { 459288229, 786646099, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7001), 713895863, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7002) },
                    { 708219481, 786646099, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7036), -2105450153, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7037) },
                    { 722150691, 786646099, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7012), -188763434, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7014) },
                    { 980894295, 786646099, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7025), -1857008146, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7026) },
                    { 213200345, 787474029, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6977), 316830173, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6979) },
                    { 437684906, 787474029, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6919), 1147383221, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6920) },
                    { 459288229, 787474029, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6931), 2036802141, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6932) },
                    { 708219481, 787474029, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6966), -1617678053, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6967) },
                    { 722150691, 787474029, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6942), 1480850451, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6943) },
                    { 980894295, 787474029, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6954), 95636192, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6955) },
                    { 213200345, 798809876, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8265), -321488077, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8266) },
                    { 437684906, 798809876, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8203), -296903861, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8204) },
                    { 459288229, 798809876, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8215), 1314342266, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8216) },
                    { 708219481, 798809876, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8250), -1777387022, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8251) },
                    { 722150691, 798809876, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8226), -1329105977, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8227) },
                    { 980894295, 798809876, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8238), -736370626, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8239) },
                    { 213200345, 810994058, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9835), -1904409656, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9836) },
                    { 437684906, 810994058, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9776), 1300314339, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9777) },
                    { 459288229, 810994058, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9788), -1546017164, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9789) },
                    { 708219481, 810994058, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9823), 811284467, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9824) },
                    { 722150691, 810994058, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9799), -1305772285, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9801) },
                    { 980894295, 810994058, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9811), 1810473899, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9812) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 213200345, 816042642, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6476), -1652565077, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6477) },
                    { 437684906, 816042642, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6418), 126758462, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6419) },
                    { 459288229, 816042642, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6429), -842941232, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6430) },
                    { 708219481, 816042642, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6465), -137146220, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6466) },
                    { 722150691, 816042642, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6441), 2097784562, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6442) },
                    { 980894295, 816042642, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6453), -1057623205, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6454) },
                    { 213200345, 819385081, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5976), -118584539, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5977) },
                    { 437684906, 819385081, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5915), -454931729, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5916) },
                    { 459288229, 819385081, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5927), 339575288, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5928) },
                    { 708219481, 819385081, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5964), 128734264, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5965) },
                    { 722150691, 819385081, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5939), -1068356114, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5940) },
                    { 980894295, 819385081, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5952), 1814643576, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5953) },
                    { 213200345, 844731621, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8547), 474549737, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8549) },
                    { 437684906, 844731621, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8489), -1541121286, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8490) },
                    { 459288229, 844731621, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8500), 1503811931, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8502) },
                    { 708219481, 844731621, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8536), -405261094, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8537) },
                    { 722150691, 844731621, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8512), -1736786312, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8513) },
                    { 980894295, 844731621, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8524), 1131414836, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8525) },
                    { 213200345, 849374866, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9552), -330178121, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9553) },
                    { 437684906, 849374866, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9490), 1325922107, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9491) },
                    { 459288229, 849374866, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9502), 1592555373, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9503) },
                    { 708219481, 849374866, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9537), -647739004, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9538) },
                    { 722150691, 849374866, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9514), 624465608, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9515) },
                    { 980894295, 849374866, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9525), -1800599278, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9527) },
                    { 213200345, 883550348, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9194), 2076575985, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9196) },
                    { 437684906, 883550348, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9133), 1222840260, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9134) },
                    { 459288229, 883550348, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9145), -158601559, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9146) },
                    { 708219481, 883550348, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9183), -1051077851, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9184) },
                    { 722150691, 883550348, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9157), 2069632481, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9158) },
                    { 980894295, 883550348, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9169), 1731291606, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9170) },
                    { 213200345, 891389807, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8622), -168079999, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8623) },
                    { 437684906, 891389807, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8559), 190289341, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8561) },
                    { 459288229, 891389807, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8571), 1221755517, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8572) },
                    { 708219481, 891389807, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8606), -2091117766, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8608) },
                    { 722150691, 891389807, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8583), -2130697705, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8584) },
                    { 980894295, 891389807, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8595), -104087861, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8596) },
                    { 213200345, 892995068, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5903), 1226017031, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5904) },
                    { 437684906, 892995068, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5844), -282374248, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5845) },
                    { 459288229, 892995068, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5856), -2133520217, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5857) },
                    { 708219481, 892995068, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5891), -2080920766, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5892) },
                    { 722150691, 892995068, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5868), -2046417754, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5869) },
                    { 980894295, 892995068, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5879), 1370852897, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5881) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 213200345, 893433997, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8909), -2042980820, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8911) },
                    { 437684906, 893433997, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8851), -1836723010, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8852) },
                    { 459288229, 893433997, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8863), -1179698273, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8864) },
                    { 708219481, 893433997, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8898), -1108391849, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8899) },
                    { 722150691, 893433997, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8874), -1990672262, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8875) },
                    { 980894295, 893433997, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8886), -746305339, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8887) },
                    { 213200345, 893687813, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5611), -1914508669, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5612) },
                    { 437684906, 893687813, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5544), 1852416918, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5545) },
                    { 459288229, 893687813, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5562), 1321357581, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5563) },
                    { 708219481, 893687813, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5598), -97620799, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5599) },
                    { 722150691, 893687813, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5574), -1181092868, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5575) },
                    { 980894295, 893687813, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5586), 1852057409, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5587) },
                    { 213200345, 895278567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9407), 245680250, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9408) },
                    { 437684906, 895278567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9349), -2010256591, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9350) },
                    { 459288229, 895278567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9360), -539903524, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9361) },
                    { 708219481, 895278567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9396), 682259945, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9397) },
                    { 722150691, 895278567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9372), -653944441, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9373) },
                    { 980894295, 895278567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9384), -347896907, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9385) },
                    { 213200345, 896645715, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9337), 2028357896, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9338) },
                    { 437684906, 896645715, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9277), 1823382792, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9279) },
                    { 459288229, 896645715, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9289), -129673903, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9290) },
                    { 708219481, 896645715, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9325), 1417730868, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9326) },
                    { 722150691, 896645715, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9301), -1062222560, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9302) },
                    { 980894295, 896645715, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9313), -720254168, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9314) },
                    { 213200345, 907290676, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7833), 253216373, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7834) },
                    { 437684906, 907290676, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7774), 1035224843, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7775) },
                    { 459288229, 907290676, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7786), 1750968306, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7787) },
                    { 708219481, 907290676, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7821), 1951953732, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7823) },
                    { 722150691, 907290676, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7798), -193858658, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7799) },
                    { 980894295, 907290676, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7810), -1313304862, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(7811) },
                    { 213200345, 919686764, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8406), 565000367, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8407) },
                    { 437684906, 919686764, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8347), 1407786827, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8349) },
                    { 459288229, 919686764, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8359), -994651721, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8360) },
                    { 708219481, 919686764, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8395), -959188063, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8396) },
                    { 722150691, 919686764, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8371), -719547443, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8372) },
                    { 980894295, 919686764, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8383), -712988779, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8384) },
                    { 213200345, 936760593, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6047), -1464524122, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6048) },
                    { 437684906, 936760593, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5988), -2099274983, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(5989) },
                    { 459288229, 936760593, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6000), 1545872711, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6001) },
                    { 708219481, 936760593, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6035), 1003189037, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6036) },
                    { 722150691, 936760593, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6011), 148642741, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6013) },
                    { 980894295, 936760593, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6024), 285411488, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6025) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 213200345, 939464914, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8335), -1303994137, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8336) },
                    { 437684906, 939464914, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8277), -899730683, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8278) },
                    { 459288229, 939464914, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8288), -601870990, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8290) },
                    { 708219481, 939464914, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8324), 1557143136, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8325) },
                    { 722150691, 939464914, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8300), -1167305615, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8301) },
                    { 980894295, 939464914, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8312), 40553857, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(8313) },
                    { 213200345, 941433656, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6192), -1617005875, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6193) },
                    { 437684906, 941433656, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6130), 323990704, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6131) },
                    { 459288229, 941433656, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6142), 1907122635, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6143) },
                    { 708219481, 941433656, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6177), -549600142, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6178) },
                    { 722150691, 941433656, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6154), -180475357, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6155) },
                    { 980894295, 941433656, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6166), -294592013, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6167) },
                    { 213200345, 943554268, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9478), 1570324545, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9479) },
                    { 437684906, 943554268, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9419), -1515426191, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9421) },
                    { 459288229, 943554268, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9431), 959659700, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9432) },
                    { 708219481, 943554268, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9467), 2070492759, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9468) },
                    { 722150691, 943554268, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9443), -817230379, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9444) },
                    { 980894295, 943554268, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9455), 1813826304, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(9456) },
                    { 213200345, 972200858, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6907), 699152423, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6908) },
                    { 437684906, 972200858, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6844), 1193708507, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6845) },
                    { 459288229, 972200858, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6856), -1186134232, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6857) },
                    { 708219481, 972200858, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6895), 1632681275, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6896) },
                    { 722150691, 972200858, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6867), -1061799358, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6868) },
                    { 980894295, 972200858, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6883), 44245567, new DateTime(2024, 3, 1, 13, 17, 49, 881, DateTimeKind.Local).AddTicks(6884) }
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
