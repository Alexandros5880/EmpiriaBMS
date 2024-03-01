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
                name: "DailyHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSpanId = table.Column<int>(type: "int", nullable: false),
                    DailyUserId = table.Column<int>(type: "int", nullable: true),
                    PersonalUserId = table.Column<int>(type: "int", nullable: true),
                    TrainingUserId = table.Column<int>(type: "int", nullable: true),
                    CorporateUserId = table.Column<int>(type: "int", nullable: true),
                    DrawingId = table.Column<int>(type: "int", nullable: true),
                    OtherId = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyHour_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyHour_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyHour_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyHour_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyHour_TimeSpans_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "TimeSpans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyHour_Users_CorporateUserId",
                        column: x => x.CorporateUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyHour_Users_DailyUserId",
                        column: x => x.DailyUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyHour_Users_PersonalUserId",
                        column: x => x.PersonalUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyHour_Users_TrainingUserId",
                        column: x => x.TrainingUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "DisciplineTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 145799067, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1781), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1782), "Fire Detection" },
                    { 148919723, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1819), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1820), "Natural Gas" },
                    { 149802773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1916), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1917), "Outsource" },
                    { 150100017, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1770), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1771), "Drainage" },
                    { 222522618, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1869), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1870), "CCTV" },
                    { 276779346, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1904), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1905), "Energy Efficiency" },
                    { 326457214, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1845), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1846), "Structured Cabling" },
                    { 435640041, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1729), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1730), "HVAC" },
                    { 460571976, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1943), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1944), "Construction Supervision" },
                    { 528636113, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1758), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1759), "Potable Water" },
                    { 625874009, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1857), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1858), "Burglar Alarm" },
                    { 641496663, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1745), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1746), "Sewage" },
                    { 717510611, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1831), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1832), "Power Distribution" },
                    { 721339991, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1880), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1881), "BMS" },
                    { 743053959, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1795), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1796), "Fire Suppression" },
                    { 846171459, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1892), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1893), "Photovoltaics" },
                    { 936487204, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1927), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1928), "TenderDocument" },
                    { 979889409, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1807), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1808), "Elevators" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 267398978, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2143), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2144), "Calculations" },
                    { 467297384, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2155), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2156), "Drawings" },
                    { 505799953, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2121), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2123), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 230793311, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2712), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2713), "Administration" },
                    { 632644119, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2699), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2700), "Meetings" },
                    { 738373267, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2687), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2688), "On-Site" },
                    { 908031880, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2653), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2654), "Communications" },
                    { 953318864, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2674), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2675), "Printing" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 300717260, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1283), "Consulting Description", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1284), "Consulting" },
                    { 368110484, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1237), "Buildings Description", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1238), "Buildings" },
                    { 454520096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1269), "Energy Description", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1271), "Energy" },
                    { 754036640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1256), "Infrastructure Description", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1257), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 322192554, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(522), true, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(523), "Project Manager" },
                    { 395435265, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(536), true, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(537), "CTO" },
                    { 625779377, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(529), true, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(530), "COO" },
                    { 632473258, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(557), false, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(558), "Customer" },
                    { 663249238, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(550), false, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(551), "Guest" },
                    { 689856728, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(506), true, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(508), "Designer" },
                    { 695021385, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(543), true, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(544), "CEO" },
                    { 757590194, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(564), false, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(565), "Admin" },
                    { 865538566, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(514), true, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(515), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1140), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1142), null, "6949277783", null, null, null },
                    { 205955242, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(981), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(982), null, "6949277784", null, null, null },
                    { 257722673, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(925), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(926), null, "6949277782", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1178), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1179), null, "6949277784", null, null, null },
                    { 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1113), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1114), null, "6949277782", null, null, null },
                    { 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1081), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1082), null, "6949277781", null, null, null },
                    { 443116634, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1404), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1405), null, "6949277784", null, null, null },
                    { 480549114, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1010), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1011), null, "6949277785", null, null, null },
                    { 494909280, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(718), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(719), null, "694927778", null, null, null },
                    { 515473689, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(777), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(778), null, "694927778", null, null, null },
                    { 639012475, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(678), "Admin", "admin@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(679), null, "694927778", null, null, null },
                    { 672873709, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(805), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(806), null, "694927778", null, null, null },
                    { 736254711, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(748), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(749), null, "694927778", null, null, null },
                    { 768246004, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(840), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(841), null, "6949277780", null, null, null },
                    { 774378471, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1345), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1346), null, "6949277782", null, null, null },
                    { 815253399, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1310), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1311), null, "6949277781", null, null, null },
                    { 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1206), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1207), null, "6949277785", null, null, null },
                    { 857612890, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1377), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1378), null, "6949277783", null, null, null },
                    { 878634595, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(896), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(897), null, "6949277781", null, null, null },
                    { 936934266, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(952), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(953), null, "6949277783", null, null, null },
                    { 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1038), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1040), null, "6949277780", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 382212420, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 8.0, 9, new DateTime(2024, 12, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 9, "Test Description Project_18", "KL-3", new DateTime(2024, 12, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), new DateTime(2024, 12, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 0f, 100L, 12L, new DateTime(2024, 3, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), "Project_3", 5.0, new DateTime(2024, 12, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), "Payment Detailes For Project_3", 3.0, null, 454520096, new DateTime(2024, 12, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 0f },
                    { 630164305, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 7.0, 4, new DateTime(2024, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 4, "Test Description Project_12", "KL-2", new DateTime(2024, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), new DateTime(2024, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 0f, 100L, 12L, new DateTime(2024, 3, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), "Project_2", 5.0, new DateTime(2024, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), "Payment Detailes For Project_4", 2.0, null, 754036640, new DateTime(2024, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 0f },
                    { 652718136, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 6.0, 1, new DateTime(2024, 4, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 4, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), new DateTime(2024, 4, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 0f, 100L, 12L, new DateTime(2024, 3, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), "Project_1", 5.0, new DateTime(2024, 4, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), "Payment Detailes For Project_2", 1.0, null, 368110484, new DateTime(2024, 4, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 0f },
                    { 844414514, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 9.0, 16, new DateTime(2025, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 16, "Test Description Project_4", "KL-4", new DateTime(2025, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), new DateTime(2025, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 0f, 100L, 12L, new DateTime(2024, 3, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), "Project_4", 5.0, new DateTime(2025, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), "Payment Detailes For Project_4", 4.0, null, 300717260, new DateTime(2025, 7, 1, 16, 57, 28, 413, DateTimeKind.Local).AddTicks(873), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 865538566, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1166), 454490035, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1167) },
                    { 689856728, 205955242, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(997), 301537086, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(998) },
                    { 689856728, 257722673, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(940), 185949847, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(941) },
                    { 865538566, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1193), 857233565, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1194) },
                    { 865538566, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1128), 823761164, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1129) },
                    { 865538566, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1100), 313688171, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1101) },
                    { 322192554, 443116634, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1419), 445387611, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1420) },
                    { 689856728, 480549114, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1024), 315840087, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1025) },
                    { 695021385, 494909280, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(734), 876085982, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(735) },
                    { 625779377, 515473689, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(791), 913123599, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(792) },
                    { 757590194, 639012475, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(698), 934583712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(699) },
                    { 663249238, 672873709, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(819), 447080666, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(820) },
                    { 395435265, 736254711, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(762), 986826310, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(763) },
                    { 689856728, 768246004, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(883), 388762242, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(884) },
                    { 322192554, 774378471, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1360), 490307039, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1361) },
                    { 322192554, 815253399, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1329), 867244910, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1331) },
                    { 865538566, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1222), 193929923, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1223) },
                    { 322192554, 857612890, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1391), 653740816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1392) },
                    { 689856728, 878634595, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(912), 878225217, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(913) },
                    { 689856728, 936934266, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(967), 753753577, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(968) },
                    { 865538566, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1067), 156688324, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1069) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1621363832, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2031), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2032), 630164305, 149802773, null },
                    { -1445404320, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2017), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2018), 630164305, 641496663, null },
                    { -1236842592, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2044), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2045), 382212420, 625874009, null },
                    { -1122907096, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2068), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2069), 382212420, 149802773, null },
                    { -795609552, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2083), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2084), 844414514, 326457214, null },
                    { -533922000, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1978), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1979), 652718136, 276779346, null },
                    { 69599816, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1992), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1993), 652718136, 641496663, null },
                    { 245930352, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1959), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1960), 652718136, 148919723, null },
                    { 567842416, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2095), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2096), 844414514, 936487204, null },
                    { 1179129592, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2056), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2057), 382212420, 846171459, null },
                    { 1377294872, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2107), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2108), 844414514, 149802773, null },
                    { 2044310840, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2004), 0f, 1500L, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2005), 630164305, 276779346, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 250786918, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1581), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1583), 3100.0, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1582), "Signature 142346", 54032, 630164305, 2.0, 24.0 },
                    { 711907088, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1709), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1711), 13000.0, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1710), "Signature 142344", 45069, 844414514, 4.0, 24.0 },
                    { 733328362, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1648), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1650), 4000.0, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1649), "Signature 142349", 78175, 382212420, 3.0, 17.0 },
                    { 916306459, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1511), new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1513), 3010.0, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1512), "Signature 142341", 54898, 652718136, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 844414514, 443116634, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3518), 660105700, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3519) },
                    { 630164305, 774378471, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3493), 496945244, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3494) },
                    { 652718136, 815253399, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3473), 474976538, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3475) },
                    { 382212420, 857612890, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3506), 664721268, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3507) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 204390127, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1681), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1682), null, "6949277784", null, null, 844414514 },
                    { 215915963, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1554), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1555), null, "6949277782", null, null, 630164305 },
                    { 772669075, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1480), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1481), null, "6949277781", null, null, 652718136 },
                    { 819671418, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1617), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1618), null, "6949277783", null, null, 382212420 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1621363832, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3942), 743578637, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3943) },
                    { -1621363832, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3954), 551313324, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3955) },
                    { -1621363832, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3928), 366925690, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3929) },
                    { -1621363832, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3916), 900264588, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3917) },
                    { -1621363832, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3966), 511089938, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3967) },
                    { -1621363832, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3904), 893494288, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3905) },
                    { -1445404320, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3868), 282944940, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3869) },
                    { -1445404320, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3880), 947167480, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3881) },
                    { -1445404320, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3856), 999525873, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3857) },
                    { -1445404320, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3844), 663888247, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3845) },
                    { -1445404320, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3892), 908891284, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3893) },
                    { -1445404320, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3829), 178930129, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3830) },
                    { -1236842592, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4015), 687474086, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4016) },
                    { -1236842592, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4027), 979227289, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4028) },
                    { -1236842592, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4003), 733192330, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4004) },
                    { -1236842592, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3991), 387419559, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3992) },
                    { -1236842592, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4039), 185149459, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4040) },
                    { -1236842592, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3978), 268199482, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3979) },
                    { -1122907096, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4159), 139320843, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4160) },
                    { -1122907096, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4171), 862944478, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4172) },
                    { -1122907096, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4147), 433486608, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4148) },
                    { -1122907096, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4135), 687965281, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4136) },
                    { -1122907096, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4183), 495152167, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4184) },
                    { -1122907096, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4123), 289084106, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4124) },
                    { -795609552, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4234), 972939548, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4235) },
                    { -795609552, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4246), 969549943, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4247) },
                    { -795609552, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4222), 389784412, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4223) },
                    { -795609552, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4210), 273361515, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4211) },
                    { -795609552, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4257), 854180837, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4258) },
                    { -795609552, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4198), 910652089, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4199) },
                    { -533922000, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3647), 853755378, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3648) },
                    { -533922000, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3660), 607863853, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3661) },
                    { -533922000, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3634), 681930261, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3635) },
                    { -533922000, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3622), 738526862, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3623) },
                    { -533922000, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3672), 781067443, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3673) },
                    { -533922000, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3610), 730169352, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3611) },
                    { 69599816, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3720), 694412713, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3721) },
                    { 69599816, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3732), 397917479, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3733) },
                    { 69599816, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3708), 720905799, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3709) },
                    { 69599816, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3696), 643167349, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3697) },
                    { 69599816, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3745), 603127014, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3746) },
                    { 69599816, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3684), 178001046, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3685) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 245930352, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3572), 235782837, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3573) },
                    { 245930352, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3584), 173463798, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3585) },
                    { 245930352, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3560), 572644360, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3561) },
                    { 245930352, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3548), 738878246, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3549) },
                    { 245930352, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3597), 306319442, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3598) },
                    { 245930352, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3531), 457932940, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3532) },
                    { 567842416, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4305), 543148453, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4306) },
                    { 567842416, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4317), 444780436, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4318) },
                    { 567842416, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4293), 374718909, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4294) },
                    { 567842416, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4281), 790625655, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4282) },
                    { 567842416, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4330), 779814649, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4331) },
                    { 567842416, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4270), 524998990, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4271) },
                    { 1179129592, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4087), 746331756, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4088) },
                    { 1179129592, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4099), 243144849, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4100) },
                    { 1179129592, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4075), 669956847, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4076) },
                    { 1179129592, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4063), 805150346, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4064) },
                    { 1179129592, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4111), 464252543, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4112) },
                    { 1179129592, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4051), 676912058, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4052) },
                    { 1377294872, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4379), 710394982, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4380) },
                    { 1377294872, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4391), 153089864, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4392) },
                    { 1377294872, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4367), 632882864, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4368) },
                    { 1377294872, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4355), 667355131, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4356) },
                    { 1377294872, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4403), 861912395, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4404) },
                    { 1377294872, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4343), 252833738, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4344) },
                    { 2044310840, 189571935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3793), 691202182, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3794) },
                    { 2044310840, 273724306, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3805), 319039763, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3806) },
                    { 2044310840, 313388722, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3781), 192113038, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3782) },
                    { 2044310840, 345100712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3769), 566009707, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3770) },
                    { 2044310840, 829141640, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3817), 373319198, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3818) },
                    { 2044310840, 953436773, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3757), 615561356, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3758) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 126537400, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2261), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2259), 69599816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2260), 505799953 },
                    { 141338417, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2190), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2188), 245930352, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2189), 267398978 },
                    { 142900817, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2615), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2613), 1377294872, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2614), 505799953 },
                    { 241373589, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2301), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2299), 2044310840, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2300), 505799953 },
                    { 260707420, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2481), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2479), 1179129592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2480), 467297384 },
                    { 319683342, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2340), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2337), -1445404320, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2338), 505799953 },
                    { 358721580, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2641), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2638), 1377294872, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2640), 467297384 },
                    { 369342729, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2544), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2542), -795609552, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2543), 267398978 },
                    { 390425222, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2377), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2375), -1621363832, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2376), 505799953 },
                    { 390572297, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2365), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2362), -1445404320, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2363), 467297384 },
                    { 392918300, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2244), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2242), -533922000, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2243), 467297384 },
                    { 473916047, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2456), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2453), 1179129592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2454), 505799953 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 477575753, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2587), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2585), 567842416, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2586), 267398978 },
                    { 523112796, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2352), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2350), -1445404320, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2351), 267398978 },
                    { 526304244, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2443), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2440), -1236842592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2441), 467297384 },
                    { 526784061, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2173), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2170), 245930352, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2171), 505799953 },
                    { 541893950, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2519), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2517), -1122907096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2518), 467297384 },
                    { 551963426, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2390), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2388), -1621363832, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2389), 267398978 },
                    { 631647610, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2600), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2598), 567842416, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2599), 467297384 },
                    { 649619658, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2558), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2555), -795609552, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2556), 467297384 },
                    { 678492567, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2204), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2201), 245930352, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2203), 467297384 },
                    { 690325385, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2628), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2626), 1377294872, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2627), 267398978 },
                    { 700825306, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2494), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2492), -1122907096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2493), 505799953 },
                    { 771823816, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2417), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2415), -1236842592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2416), 505799953 },
                    { 788253392, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2230), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2228), -533922000, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2229), 267398978 },
                    { 789644409, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2327), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2325), 2044310840, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2326), 467297384 },
                    { 799814768, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2274), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2272), 69599816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2273), 267398978 },
                    { 813911718, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2314), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2312), 2044310840, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2313), 267398978 },
                    { 832536220, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2404), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2402), -1621363832, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2403), 467297384 },
                    { 837414158, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2468), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2466), 1179129592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2467), 267398978 },
                    { 841560857, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2217), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2215), -533922000, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2216), 505799953 },
                    { 885423870, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2430), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2428), -1236842592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2429), 267398978 },
                    { 891773666, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2532), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2530), -795609552, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2531), 505799953 },
                    { 911489904, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2287), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2285), 69599816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2286), 467297384 },
                    { 941891325, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2574), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2572), 567842416, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2573), 505799953 },
                    { 945766649, new DateTime(2024, 3, 12, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2507), 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2504), -1122907096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2505), 267398978 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 148698682, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3340), -795609552, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3341), 230793311 },
                    { 167586277, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2898), 69599816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2899), 632644119 },
                    { 174793283, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2795), -533922000, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2796), 908031880 },
                    { 210132673, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2727), 245930352, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2729), 908031880 },
                    { 220881096, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2820), -533922000, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2821), 738373267 },
                    { 229593208, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3267), -1122907096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3268), 632644119 },
                    { 236005032, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2808), -533922000, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2809), 953318864 },
                    { 238121462, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3231), -1122907096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3232), 908031880 },
                    { 243320782, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2846), -533922000, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2847), 230793311 },
                    { 264096188, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2745), 245930352, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2746), 953318864 },
                    { 283842088, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3159), -1236842592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3160), 230793311 },
                    { 304448316, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3093), -1621363832, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3094), 230793311 },
                    { 322144972, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3255), -1122907096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3256), 738373267 },
                    { 322351553, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3292), -795609552, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3293), 908031880 },
                    { 352805630, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3304), -795609552, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3305), 953318864 },
                    { 366847410, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3105), -1236842592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3106), 908031880 },
                    { 369292213, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2832), -533922000, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2833), 632644119 },
                    { 383371077, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3436), 1377294872, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3437), 738373267 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 393535092, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3316), -795609552, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3317), 738373267 },
                    { 398260776, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3412), 1377294872, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3413), 908031880 },
                    { 454784886, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3117), -1236842592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3118), 953318864 },
                    { 514608465, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3279), -1122907096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3281), 230793311 },
                    { 537243946, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2934), 2044310840, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2935), 953318864 },
                    { 572024208, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2922), 2044310840, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2923), 908031880 },
                    { 575172350, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3364), 567842416, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3365), 953318864 },
                    { 594024236, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3057), -1621363832, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3058), 953318864 },
                    { 610999686, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2757), 245930352, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2759), 738373267 },
                    { 613980327, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2861), 69599816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2863), 908031880 },
                    { 614456070, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3376), 567842416, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3377), 738373267 },
                    { 634394003, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3129), -1236842592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3130), 738373267 },
                    { 650311940, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3069), -1621363832, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3070), 738373267 },
                    { 650612545, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3146), -1236842592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3148), 632644119 },
                    { 654069497, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3171), 1179129592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3172), 908031880 },
                    { 669349671, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3033), -1445404320, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3034), 230793311 },
                    { 673270737, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3328), -795609552, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3329), 632644119 },
                    { 691866751, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3081), -1621363832, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3082), 632644119 },
                    { 704155633, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2960), 2044310840, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2961), 632644119 },
                    { 711020803, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3400), 567842416, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3401), 230793311 },
                    { 742243511, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2972), 2044310840, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2973), 230793311 },
                    { 744779174, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2886), 69599816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2887), 738373267 },
                    { 750813958, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3352), 567842416, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3353), 908031880 },
                    { 756399385, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3388), 567842416, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3389), 632644119 },
                    { 767851674, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3219), 1179129592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3220), 230793311 },
                    { 793869023, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3207), 1179129592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3208), 632644119 },
                    { 797878368, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3448), 1377294872, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3449), 632644119 },
                    { 803943424, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3460), 1377294872, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3461), 230793311 },
                    { 826814846, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3008), -1445404320, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3009), 738373267 },
                    { 828848701, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2948), 2044310840, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2949), 738373267 },
                    { 829886609, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2770), 245930352, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2771), 632644119 },
                    { 838287030, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2910), 69599816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2911), 230793311 },
                    { 843766787, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3045), -1621363832, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3046), 908031880 },
                    { 855318452, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2874), 69599816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2875), 953318864 },
                    { 855509733, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3183), 1179129592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3184), 953318864 },
                    { 861591214, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2996), -1445404320, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2997), 953318864 },
                    { 872201290, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3021), -1445404320, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3022), 632644119 },
                    { 890101101, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3424), 1377294872, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3425), 953318864 },
                    { 899828445, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3195), 1179129592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3196), 738373267 },
                    { 936013631, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2984), -1445404320, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2985), 908031880 },
                    { 974249981, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2782), 245930352, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(2783), 230793311 },
                    { 986147304, 0f, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3243), -1122907096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(3244), 953318864 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 632473258, 204390127, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1696), 760640170, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1697) },
                    { 632473258, 215915963, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1569), 604963541, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1570) },
                    { 632473258, 772669075, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1497), 826575517, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1498) },
                    { 632473258, 819671418, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1632), 883865163, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(1633) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 205955242, 148698682, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8232), -1869372760, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8233) },
                    { 257722673, 148698682, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8208), 1147030376, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8209) },
                    { 480549114, 148698682, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8244), -95765102, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8245) },
                    { 768246004, 148698682, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8184), 219692044, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8185) },
                    { 878634595, 148698682, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8196), -2142071185, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8197) },
                    { 936934266, 148698682, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8220), -1929321724, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8221) },
                    { 205955242, 167586277, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5406), 392184230, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5407) },
                    { 257722673, 167586277, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5382), -1391970788, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5383) },
                    { 480549114, 167586277, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5417), 492633833, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5418) },
                    { 768246004, 167586277, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5358), 149579069, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5360) },
                    { 878634595, 167586277, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5370), -1342744816, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5371) },
                    { 936934266, 167586277, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5394), -85338827, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5395) },
                    { 205955242, 174793283, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4830), 1053047876, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4831) },
                    { 257722673, 174793283, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4805), 1341420602, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4806) },
                    { 480549114, 174793283, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4842), 1178290683, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4843) },
                    { 768246004, 174793283, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4782), -847066711, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4783) },
                    { 878634595, 174793283, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4794), 1381745381, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4795) },
                    { 936934266, 174793283, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4818), -2056471757, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4819) },
                    { 205955242, 210132673, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4468), 1398431583, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4469) },
                    { 257722673, 210132673, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4444), 2109184884, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4445) },
                    { 480549114, 210132673, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4481), 1292555489, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4482) },
                    { 768246004, 210132673, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4416), 1489855316, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4417) },
                    { 878634595, 210132673, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4432), -1471372465, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4433) },
                    { 936934266, 210132673, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4456), -1347495952, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4457) },
                    { 205955242, 220881096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4976), -1775269291, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4977) },
                    { 257722673, 220881096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4952), -1491783866, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4953) },
                    { 480549114, 220881096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4987), -1176646747, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4988) },
                    { 768246004, 220881096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4928), -1572783020, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4929) },
                    { 878634595, 220881096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4939), -1756933712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4940) },
                    { 936934266, 220881096, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4964), 1467837230, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4965) },
                    { 205955242, 229593208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7792), -367423478, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7793) },
                    { 257722673, 229593208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7768), -516998078, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7769) },
                    { 480549114, 229593208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7804), 1552033697, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7805) },
                    { 768246004, 229593208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7744), -1698085871, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7745) },
                    { 878634595, 229593208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7756), 1774389704, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7757) },
                    { 936934266, 229593208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7780), 1400259951, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7781) },
                    { 205955242, 236005032, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4904), 1871686580, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4905) },
                    { 257722673, 236005032, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4881), 1430203937, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4882) },
                    { 480549114, 236005032, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4916), 1417522878, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4917) },
                    { 768246004, 236005032, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4857), 948366635, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4858) },
                    { 878634595, 236005032, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4869), 1096091024, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4870) },
                    { 936934266, 236005032, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4892), -1579128119, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4893) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 205955242, 238121462, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7570), -771398437, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7571) },
                    { 257722673, 238121462, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7545), 166765010, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7546) },
                    { 480549114, 238121462, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7582), -964939238, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7583) },
                    { 768246004, 238121462, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7518), 346886857, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7519) },
                    { 878634595, 238121462, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7532), -1916623736, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7533) },
                    { 936934266, 238121462, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7557), -513654115, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7559) },
                    { 205955242, 243320782, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5117), -1773213857, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5118) },
                    { 257722673, 243320782, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5094), 1359176963, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5095) },
                    { 480549114, 243320782, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5129), -1145028671, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5130) },
                    { 768246004, 243320782, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5070), -1248205229, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5071) },
                    { 878634595, 243320782, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5082), -728027108, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5083) },
                    { 936934266, 243320782, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5105), -527622610, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5106) },
                    { 205955242, 264096188, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4545), -364663979, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4547) },
                    { 257722673, 264096188, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4517), 548027708, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4518) },
                    { 480549114, 264096188, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4557), 1292979911, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4558) },
                    { 768246004, 264096188, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4494), -1925784148, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4495) },
                    { 878634595, 264096188, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4506), -1410868043, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4507) },
                    { 936934266, 264096188, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4534), 680652077, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4535) },
                    { 205955242, 283842088, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7129), -1928872673, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7130) },
                    { 257722673, 283842088, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7105), 53069266, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7106) },
                    { 480549114, 283842088, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7141), 2122253937, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7142) },
                    { 768246004, 283842088, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7081), 2130458202, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7082) },
                    { 878634595, 283842088, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7093), -662785199, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7094) },
                    { 936934266, 283842088, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7117), -1310757106, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7118) },
                    { 205955242, 304448316, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6748), -1831786190, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6749) },
                    { 257722673, 304448316, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6724), -1341605357, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6725) },
                    { 480549114, 304448316, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6763), 1142791020, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6764) },
                    { 768246004, 304448316, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6700), -1494962765, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6701) },
                    { 878634595, 304448316, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6712), 262507249, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6713) },
                    { 936934266, 304448316, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6736), -1130066752, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6737) },
                    { 205955242, 322144972, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7715), -1351500952, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7716) },
                    { 257722673, 322144972, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7691), -52599685, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7692) },
                    { 480549114, 322144972, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7731), -1601284256, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7733) },
                    { 768246004, 322144972, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7667), 385494953, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7668) },
                    { 878634595, 322144972, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7678), 513556106, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7680) },
                    { 936934266, 322144972, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7703), -1266291647, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7704) },
                    { 205955242, 322351553, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7936), 159057910, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7937) },
                    { 257722673, 322351553, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7912), 1715647275, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7913) },
                    { 480549114, 322351553, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7948), 180762481, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7949) },
                    { 768246004, 322351553, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7888), -1070362075, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7890) },
                    { 878634595, 322351553, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7900), 1679981531, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7901) },
                    { 936934266, 322351553, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7924), -20775806, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7925) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 205955242, 352805630, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8009), -276668423, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8010) },
                    { 257722673, 352805630, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7985), -1040700698, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7986) },
                    { 480549114, 352805630, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8021), 1482956123, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8022) },
                    { 768246004, 352805630, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7960), 1616819972, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7961) },
                    { 878634595, 352805630, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7973), -523754968, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7974) },
                    { 936934266, 352805630, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7997), -1972390058, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7998) },
                    { 205955242, 366847410, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6837), -1558379987, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6838) },
                    { 257722673, 366847410, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6799), 1457305268, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6800) },
                    { 480549114, 366847410, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6849), -1745756086, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6850) },
                    { 768246004, 366847410, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6775), -1735853854, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6776) },
                    { 878634595, 366847410, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6787), 1763449970, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6788) },
                    { 936934266, 366847410, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6825), 1119997562, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6826) },
                    { 205955242, 369292213, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5046), -1593220063, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5048) },
                    { 257722673, 369292213, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5023), -1051652717, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5024) },
                    { 480549114, 369292213, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5058), 1404027671, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5059) },
                    { 768246004, 369292213, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4999), 2140989953, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5000) },
                    { 878634595, 369292213, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5011), -2054751412, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5012) },
                    { 936934266, 369292213, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5035), -1479540365, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5036) },
                    { 205955242, 383371077, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8820), -548625271, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8821) },
                    { 257722673, 383371077, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8795), -1673887364, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8796) },
                    { 480549114, 383371077, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8832), 2121447425, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8833) },
                    { 768246004, 383371077, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8771), -552093178, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8772) },
                    { 878634595, 383371077, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8783), -851311435, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8784) },
                    { 936934266, 383371077, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8808), -1661906776, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8809) },
                    { 205955242, 393535092, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8081), 441747860, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8082) },
                    { 257722673, 393535092, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8057), -1560953794, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8058) },
                    { 480549114, 393535092, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8100), -8637394, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8101) },
                    { 768246004, 393535092, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8033), -1824848779, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8034) },
                    { 878634595, 393535092, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8045), 1286804075, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8046) },
                    { 936934266, 393535092, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8069), 534320483, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8071) },
                    { 205955242, 398260776, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8673), 1962850739, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8674) },
                    { 257722673, 398260776, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8648), -933430180, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8649) },
                    { 480549114, 398260776, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8685), 182858936, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8686) },
                    { 768246004, 398260776, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8624), -1369543373, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8625) },
                    { 878634595, 398260776, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8636), 1484512668, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8637) },
                    { 936934266, 398260776, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8661), 419831573, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8662) },
                    { 205955242, 454784886, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6911), -1054516751, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6912) },
                    { 257722673, 454784886, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6886), -1518390791, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6887) },
                    { 480549114, 454784886, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6923), -1427309801, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6924) },
                    { 768246004, 454784886, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6862), 1304900438, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6863) },
                    { 878634595, 454784886, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6874), 1113217542, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6875) },
                    { 936934266, 454784886, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6898), 1401021900, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6899) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 205955242, 514608465, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7864), 92845504, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7865) },
                    { 257722673, 514608465, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7840), 2018114829, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7842) },
                    { 480549114, 514608465, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7876), 20765921, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7877) },
                    { 768246004, 514608465, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7816), 567261806, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7817) },
                    { 878634595, 514608465, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7828), -68495381, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7830) },
                    { 936934266, 514608465, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7852), 1755205187, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7854) },
                    { 205955242, 537243946, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5622), -830335972, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5623) },
                    { 257722673, 537243946, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5599), -813629425, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5600) },
                    { 480549114, 537243946, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5634), 252561029, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5635) },
                    { 768246004, 537243946, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5575), -1929180212, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5576) },
                    { 878634595, 537243946, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5587), 243518549, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5588) },
                    { 936934266, 537243946, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5610), 650074676, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5612) },
                    { 205955242, 572024208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5551), -638610124, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5552) },
                    { 257722673, 572024208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5524), -910544291, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5525) },
                    { 480549114, 572024208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5563), -990038479, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5564) },
                    { 768246004, 572024208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5501), 316403839, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5502) },
                    { 878634595, 572024208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5512), 2034513518, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5513) },
                    { 936934266, 572024208, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5536), -1594084783, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5537) },
                    { 205955242, 575172350, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8376), 1670578731, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8377) },
                    { 257722673, 575172350, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8352), 1179477720, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8353) },
                    { 480549114, 575172350, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8389), 1308558362, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8390) },
                    { 768246004, 575172350, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8328), 1553427887, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8329) },
                    { 878634595, 575172350, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8340), -1514543818, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8341) },
                    { 936934266, 575172350, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8364), 1714918946, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8366) },
                    { 205955242, 594024236, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6532), 25945858, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6533) },
                    { 257722673, 594024236, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6508), 81495136, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6509) },
                    { 480549114, 594024236, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6544), -1167824704, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6545) },
                    { 768246004, 594024236, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6484), 1481224433, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6485) },
                    { 878634595, 594024236, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6496), -1622370761, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6497) },
                    { 936934266, 594024236, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6520), 1385997980, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6521) },
                    { 205955242, 610999686, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4616), 40978783, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4617) },
                    { 257722673, 610999686, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4592), 57155090, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4594) },
                    { 480549114, 610999686, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4629), -509292643, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4630) },
                    { 768246004, 610999686, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4569), 509658557, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4570) },
                    { 878634595, 610999686, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4581), 24954647, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4582) },
                    { 936934266, 610999686, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4604), 1478988572, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4605) },
                    { 205955242, 613980327, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5188), 1321209563, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5189) },
                    { 257722673, 613980327, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5165), 436111034, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5166) },
                    { 480549114, 613980327, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5204), 1840104270, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5205) },
                    { 768246004, 613980327, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5141), -548880758, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5142) },
                    { 878634595, 613980327, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5153), -1296928102, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5154) },
                    { 936934266, 613980327, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5176), -975060602, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5177) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 205955242, 614456070, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8448), 2118574728, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8449) },
                    { 257722673, 614456070, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8424), 229573202, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8426) },
                    { 480549114, 614456070, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8460), -2085721933, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8461) },
                    { 768246004, 614456070, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8401), -1169256734, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8402) },
                    { 878634595, 614456070, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8413), -169066750, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8414) },
                    { 936934266, 614456070, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8437), 11991749, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8438) },
                    { 205955242, 634394003, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6984), -1491715849, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6985) },
                    { 257722673, 634394003, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6960), 1242921195, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6961) },
                    { 480549114, 634394003, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6996), 1073394392, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6997) },
                    { 768246004, 634394003, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6936), -1375538215, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6937) },
                    { 878634595, 634394003, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6948), 194359892, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6949) },
                    { 936934266, 634394003, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6972), -273938336, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6973) },
                    { 205955242, 650311940, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6604), 1176350783, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6605) },
                    { 257722673, 650311940, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6580), -1462716733, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6581) },
                    { 480549114, 650311940, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6616), -199330307, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6617) },
                    { 768246004, 650311940, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6556), 530951711, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6557) },
                    { 878634595, 650311940, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6568), -676482236, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6569) },
                    { 936934266, 650311940, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6592), 1072231754, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6593) },
                    { 205955242, 650612545, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7057), -1907991638, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7058) },
                    { 257722673, 650612545, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7032), -1448481037, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7033) },
                    { 480549114, 650612545, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7069), 1995286599, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7070) },
                    { 768246004, 650612545, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7008), 46067738, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7009) },
                    { 878634595, 650612545, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7020), -1440881495, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7021) },
                    { 936934266, 650612545, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7044), -2031318638, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7045) },
                    { 205955242, 654069497, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7205), 1756781861, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7206) },
                    { 257722673, 654069497, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7181), 1919656031, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7182) },
                    { 480549114, 654069497, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7217), 692983697, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7218) },
                    { 768246004, 654069497, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7156), -249745472, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7158) },
                    { 878634595, 654069497, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7169), -1398934592, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7170) },
                    { 936934266, 654069497, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7193), -590738629, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7194) },
                    { 205955242, 669349671, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6387), -606520858, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6388) },
                    { 257722673, 669349671, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6361), 1465097198, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6362) },
                    { 480549114, 669349671, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6399), -1098321682, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6400) },
                    { 768246004, 669349671, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6338), -1544437237, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6339) },
                    { 878634595, 669349671, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6349), -2003395589, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6350) },
                    { 936934266, 669349671, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6373), 2122647444, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6374) },
                    { 205955242, 673270737, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8160), -1779223837, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8161) },
                    { 257722673, 673270737, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8136), -321656053, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8137) },
                    { 480549114, 673270737, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8172), 1530379224, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8173) },
                    { 768246004, 673270737, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8112), -938370203, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8113) },
                    { 878634595, 673270737, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8124), 154203548, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8125) },
                    { 936934266, 673270737, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8148), -1083306734, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8149) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 205955242, 691866751, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6676), -15142783, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6677) },
                    { 257722673, 691866751, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6652), -1658901833, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6653) },
                    { 480549114, 691866751, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6688), 311286713, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6689) },
                    { 768246004, 691866751, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6628), 1660989456, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6629) },
                    { 878634595, 691866751, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6640), 1355349564, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6641) },
                    { 936934266, 691866751, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6664), -2047611748, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6665) },
                    { 205955242, 704155633, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5802), -682232359, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5804) },
                    { 257722673, 704155633, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5760), -1904406929, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5761) },
                    { 480549114, 704155633, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5823), 1994739881, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5825) },
                    { 768246004, 704155633, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5716), -1511479781, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5718) },
                    { 878634595, 704155633, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5737), -1803223988, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5738) },
                    { 936934266, 704155633, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5780), 1816354841, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5782) },
                    { 205955242, 711020803, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8599), -160930003, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8600) },
                    { 257722673, 711020803, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8575), 386292965, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8576) },
                    { 480549114, 711020803, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8611), 779488295, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8612) },
                    { 768246004, 711020803, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8550), 1957916799, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8551) },
                    { 878634595, 711020803, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8562), -1789664242, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8563) },
                    { 936934266, 711020803, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8587), 1483833240, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8588) },
                    { 205955242, 742243511, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5930), -1360166107, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5932) },
                    { 257722673, 742243511, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5886), -1245627107, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5888) },
                    { 480549114, 742243511, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5952), 1395709160, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5954) },
                    { 768246004, 742243511, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5844), -1276138475, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5846) },
                    { 878634595, 742243511, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5866), 2071964385, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5868) },
                    { 936934266, 742243511, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5908), -173960725, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5911) },
                    { 205955242, 744779174, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5334), 643676045, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5335) },
                    { 257722673, 744779174, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5311), 22058672, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5312) },
                    { 480549114, 744779174, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5346), 909375206, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5347) },
                    { 768246004, 744779174, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5287), 1293340532, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5288) },
                    { 878634595, 744779174, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5299), 100037935, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5300) },
                    { 936934266, 744779174, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5323), -412419032, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5324) },
                    { 205955242, 750813958, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8304), -1632768529, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8305) },
                    { 257722673, 750813958, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8280), 1727917313, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8281) },
                    { 480549114, 750813958, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8316), -125843777, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8317) },
                    { 768246004, 750813958, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8256), -1438691471, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8257) },
                    { 878634595, 750813958, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8268), -1454091200, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8269) },
                    { 936934266, 750813958, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8292), -286673296, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8293) },
                    { 205955242, 756399385, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8525), 1892124234, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8526) },
                    { 257722673, 756399385, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8501), 1188446927, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8502) },
                    { 480549114, 756399385, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8537), 1109118650, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8538) },
                    { 768246004, 756399385, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8476), -1005976561, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8477) },
                    { 878634595, 756399385, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8488), -786013127, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8489) },
                    { 936934266, 756399385, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8513), -1481692436, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8514) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 205955242, 767851674, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7493), 764135861, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7494) },
                    { 257722673, 767851674, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7469), 1697754609, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7471) },
                    { 480549114, 767851674, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7505), -2141589806, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7506) },
                    { 768246004, 767851674, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7446), -1595885318, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7447) },
                    { 878634595, 767851674, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7458), -64948913, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7459) },
                    { 936934266, 767851674, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7481), -1409877458, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7482) },
                    { 205955242, 793869023, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7421), 172071559, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7422) },
                    { 257722673, 793869023, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7397), 178107674, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7398) },
                    { 480549114, 793869023, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7433), 25917409, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7434) },
                    { 768246004, 793869023, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7373), -1068738074, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7374) },
                    { 878634595, 793869023, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7385), -1824533621, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7386) },
                    { 936934266, 793869023, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7409), -1802684137, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7410) },
                    { 205955242, 797878368, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8896), 224434882, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8898) },
                    { 257722673, 797878368, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8872), 878401562, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8873) },
                    { 480549114, 797878368, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8908), 1342629675, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8910) },
                    { 768246004, 797878368, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8844), -638914067, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8845) },
                    { 878634595, 797878368, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8860), -1989553715, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8861) },
                    { 936934266, 797878368, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8885), 583881719, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8886) },
                    { 205955242, 803943424, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8968), 288382546, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8969) },
                    { 257722673, 803943424, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8945), -71433683, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8946) },
                    { 480549114, 803943424, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8980), -1331488448, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8981) },
                    { 768246004, 803943424, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8921), 198434584, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8922) },
                    { 878634595, 803943424, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8933), -350820998, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8934) },
                    { 936934266, 803943424, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8957), -759811783, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8958) },
                    { 205955242, 826814846, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6243), -1626520643, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6244) },
                    { 257722673, 826814846, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6220), 606716060, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6221) },
                    { 480549114, 826814846, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6255), -890379296, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6256) },
                    { 768246004, 826814846, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6197), 89910140, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6198) },
                    { 878634595, 826814846, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6208), 47431351, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6210) },
                    { 936934266, 826814846, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6232), 1861672100, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6233) },
                    { 205955242, 828848701, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5693), -1157443069, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5694) },
                    { 257722673, 828848701, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5670), -725716390, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5671) },
                    { 480549114, 828848701, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5704), 2068607142, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5705) },
                    { 768246004, 828848701, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5646), -2092067428, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5647) },
                    { 878634595, 828848701, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5658), 232963408, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5659) },
                    { 936934266, 828848701, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5681), -126691951, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5682) },
                    { 205955242, 829886609, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4688), -1376669470, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4689) },
                    { 257722673, 829886609, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4664), 2074381794, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4666) },
                    { 480549114, 829886609, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4699), 1431652136, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4700) },
                    { 768246004, 829886609, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4641), 1442518317, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4642) },
                    { 878634595, 829886609, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4653), -489587233, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4654) },
                    { 936934266, 829886609, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4676), -866947922, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4677) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 205955242, 838287030, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5477), 1657549863, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5478) },
                    { 257722673, 838287030, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5453), 2005015766, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5454) },
                    { 480549114, 838287030, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5489), 1932427836, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5490) },
                    { 768246004, 838287030, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5430), -534155777, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5431) },
                    { 878634595, 838287030, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5441), 108680234, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5442) },
                    { 936934266, 838287030, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5465), -1751361268, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5466) },
                    { 205955242, 843766787, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6460), 783791474, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6461) },
                    { 257722673, 843766787, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6435), -1250848259, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6436) },
                    { 480549114, 843766787, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6471), -1490214712, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6473) },
                    { 768246004, 843766787, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6412), -1202540462, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6413) },
                    { 878634595, 843766787, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6423), 708680282, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6424) },
                    { 936934266, 843766787, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6447), -311445535, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6449) },
                    { 205955242, 855318452, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5263), 1328570186, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5264) },
                    { 257722673, 855318452, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5240), -2007336203, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5241) },
                    { 480549114, 855318452, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5275), 2113451847, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5276) },
                    { 768246004, 855318452, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5216), 46092934, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5217) },
                    { 878634595, 855318452, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5228), 834015047, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5229) },
                    { 936934266, 855318452, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5252), -2117238749, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5253) },
                    { 205955242, 855509733, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7277), 372343226, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7278) },
                    { 257722673, 855509733, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7253), 1429758936, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7254) },
                    { 480549114, 855509733, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7289), -1927566629, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7290) },
                    { 768246004, 855509733, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7229), -1369536826, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7230) },
                    { 878634595, 855509733, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7241), -2090550203, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7242) },
                    { 936934266, 855509733, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7265), -786647501, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7266) },
                    { 205955242, 861591214, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6173), -368995063, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6174) },
                    { 257722673, 861591214, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6146), 872831831, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6148) },
                    { 480549114, 861591214, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6185), 726976868, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6186) },
                    { 768246004, 861591214, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6110), -987384032, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6112) },
                    { 878634595, 861591214, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6133), 92060308, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6134) },
                    { 936934266, 861591214, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6161), -663364813, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6162) },
                    { 205955242, 872201290, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6314), 1702447614, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6315) },
                    { 257722673, 872201290, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6290), -88901320, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6292) },
                    { 480549114, 872201290, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6326), 309376670, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6327) },
                    { 768246004, 872201290, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6267), -611170276, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6268) },
                    { 878634595, 872201290, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6278), -1508000485, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6280) },
                    { 936934266, 872201290, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6303), 1600712915, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6304) },
                    { 205955242, 890101101, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8746), 18346447, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8748) },
                    { 257722673, 890101101, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8722), 1165062839, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8723) },
                    { 480549114, 890101101, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8759), -1118224651, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8760) },
                    { 768246004, 890101101, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8698), -2030944180, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8699) },
                    { 878634595, 890101101, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8710), 1767339738, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8711) },
                    { 936934266, 890101101, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8734), -1637091566, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(8735) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 205955242, 899828445, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7349), 1546515923, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7350) },
                    { 257722673, 899828445, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7325), 1991904714, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7326) },
                    { 480549114, 899828445, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7361), 1879008656, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7362) },
                    { 768246004, 899828445, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7301), -1049839843, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7302) },
                    { 878634595, 899828445, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7313), -651146395, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7314) },
                    { 936934266, 899828445, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7337), -825630889, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7338) },
                    { 205955242, 936013631, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6061), 1560123693, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6063) },
                    { 257722673, 936013631, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6017), 281914966, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6019) },
                    { 480549114, 936013631, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6087), -845793337, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6090) },
                    { 768246004, 936013631, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5974), 1688648769, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5975) },
                    { 878634595, 936013631, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5995), -1512074281, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(5997) },
                    { 936934266, 936013631, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6039), 68808875, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(6040) },
                    { 205955242, 974249981, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4759), 1340712698, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4760) },
                    { 257722673, 974249981, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4735), -1107611554, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4736) },
                    { 480549114, 974249981, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4770), 626246222, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4771) },
                    { 768246004, 974249981, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4711), 1128130272, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4712) },
                    { 878634595, 974249981, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4723), -1193532628, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4724) },
                    { 936934266, 974249981, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4747), -1115593478, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(4748) },
                    { 205955242, 986147304, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7642), -481198243, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7644) },
                    { 257722673, 986147304, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7619), -1033896811, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7620) },
                    { 480549114, 986147304, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7654), 12015919, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7656) },
                    { 768246004, 986147304, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7594), -1593998626, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7595) },
                    { 878634595, 986147304, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7606), 1543074291, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7607) },
                    { 936934266, 986147304, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7631), 1383921342, new DateTime(2024, 3, 1, 16, 57, 28, 424, DateTimeKind.Local).AddTicks(7632) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_CorporateUserId",
                table: "DailyHour",
                column: "CorporateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_DailyUserId",
                table: "DailyHour",
                column: "DailyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_DisciplineId",
                table: "DailyHour",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_DrawingId",
                table: "DailyHour",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_OtherId",
                table: "DailyHour",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_PersonalUserId",
                table: "DailyHour",
                column: "PersonalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_ProjectId",
                table: "DailyHour",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_TimeSpanId",
                table: "DailyHour",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_TrainingUserId",
                table: "DailyHour",
                column: "TrainingUserId");

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
                name: "FK_Projects_Users_SubContractorId",
                table: "Projects",
                column: "SubContractorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_ProjectId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DailyHour");

            migrationBuilder.DropTable(
                name: "DisciplineEngineer");

            migrationBuilder.DropTable(
                name: "DrawingsEmployees");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "OthersEmployees");

            migrationBuilder.DropTable(
                name: "ProjectsPmanagers");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "TimeSpans");

            migrationBuilder.DropTable(
                name: "Drawings");

            migrationBuilder.DropTable(
                name: "Others");

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
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectType");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
