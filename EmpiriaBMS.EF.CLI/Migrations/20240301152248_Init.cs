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
                name: "DailyTime",
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
                    table.PrimaryKey("PK_DailyTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyTime_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_TimeSpans_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "TimeSpans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyTime_Users_CorporateUserId",
                        column: x => x.CorporateUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyTime_Users_DailyUserId",
                        column: x => x.DailyUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyTime_Users_PersonalUserId",
                        column: x => x.PersonalUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyTime_Users_TrainingUserId",
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
                    { 172968193, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4432), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4433), "Fire Detection" },
                    { 333950945, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4553), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4554), "Photovoltaics" },
                    { 409944808, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4419), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4420), "Drainage" },
                    { 450889022, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4374), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4375), "HVAC" },
                    { 474184973, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4591), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4592), "TenderDocument" },
                    { 536927687, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4606), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4607), "Construction Supervision" },
                    { 546000744, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4579), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4580), "Outsource" },
                    { 552504005, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4446), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4448), "Fire Suppression" },
                    { 573240289, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4406), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4407), "Potable Water" },
                    { 614464088, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4485), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4486), "Power Distribution" },
                    { 766145390, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4512), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4513), "Burglar Alarm" },
                    { 769147815, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4472), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4474), "Natural Gas" },
                    { 869591208, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4499), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4501), "Structured Cabling" },
                    { 884601650, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4460), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4461), "Elevators" },
                    { 910427803, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4524), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4526), "CCTV" },
                    { 911839150, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4566), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4567), "Energy Efficiency" },
                    { 914862890, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4540), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4541), "BMS" },
                    { 934144976, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4392), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4394), "Sewage" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 243044296, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4816), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4818), "Calculations" },
                    { 871378577, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4829), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4831), "Drawings" },
                    { 972044161, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4797), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4798), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 425763481, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5407), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5408), "Administration" },
                    { 464221588, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5368), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5369), "Printing" },
                    { 497280772, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5394), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5395), "Meetings" },
                    { 603627237, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5348), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5349), "Communications" },
                    { 908498660, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5381), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5382), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 508093367, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3868), "Buildings Description", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3869), "Buildings" },
                    { 698154630, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3915), "Consulting Description", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3916), "Consulting" },
                    { 736620640, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3886), "Infrastructure Description", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3888), "Infrastructure" },
                    { 992128840, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3901), "Energy Description", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3902), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 334496286, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3140), false, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3142), "Guest" },
                    { 339207389, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3147), false, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3148), "Customer" },
                    { 485249153, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3095), true, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3097), "Designer" },
                    { 521403968, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3111), true, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3113), "Project Manager" },
                    { 536329949, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3119), true, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3120), "COO" },
                    { 562532645, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3154), false, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3156), "Admin" },
                    { 584741166, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3126), true, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3127), "CTO" },
                    { 886761836, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3134), true, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3135), "CEO" },
                    { 968012066, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3104), true, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3105), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 178161854, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3397), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3398), null, "694927778", null, null, null },
                    { 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3836), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3837), null, "6949277785", null, null, null },
                    { 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3666), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3668), null, "6949277780", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 299354066, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3427), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3428), null, "694927778", null, null, null },
                    { 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3709), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3710), null, "6949277781", null, null, null },
                    { 353454767, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3979), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3980), null, "6949277782", null, null, null },
                    { 392160920, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3604), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3605), null, "6949277784", null, null, null },
                    { 441874521, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3574), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3575), null, "6949277783", null, null, null },
                    { 445715605, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3460), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3461), null, "6949277780", null, null, null },
                    { 474015927, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3292), "Admin", "admin@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3293), null, "694927778", null, null, null },
                    { 496508338, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3634), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3635), null, "6949277785", null, null, null },
                    { 572679627, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3335), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3336), null, "694927778", null, null, null },
                    { 580878256, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3365), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3366), null, "694927778", null, null, null },
                    { 614140926, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4008), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4009), null, "6949277783", null, null, null },
                    { 628802181, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3518), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3519), null, "6949277781", null, null, null },
                    { 746830103, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4037), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4038), null, "6949277784", null, null, null },
                    { 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3738), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3739), null, "6949277782", null, null, null },
                    { 826037567, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3546), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3547), null, "6949277782", null, null, null },
                    { 856350679, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3941), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3942), null, "6949277781", null, null, null },
                    { 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3806), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3807), null, "6949277784", null, null, null },
                    { 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3766), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3767), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 274405059, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 9.0, 16, new DateTime(2025, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 16, "Test Description Project_24", "KL-4", new DateTime(2025, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), new DateTime(2025, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 0f, 100L, 12L, new DateTime(2024, 3, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), "Project_4", 5.0, new DateTime(2025, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), "Payment Detailes For Project_16", 4.0, null, 698154630, new DateTime(2025, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 0f },
                    { 502814518, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 6.0, 1, new DateTime(2024, 4, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 4, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), new DateTime(2024, 4, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 0f, 100L, 12L, new DateTime(2024, 3, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), "Project_1", 5.0, new DateTime(2024, 4, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), "Payment Detailes For Project_2", 1.0, null, 508093367, new DateTime(2024, 4, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 0f },
                    { 610973605, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 7.0, 4, new DateTime(2024, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 4, "Test Description Project_6", "KL-2", new DateTime(2024, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), new DateTime(2024, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 0f, 100L, 12L, new DateTime(2024, 3, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), "Project_2", 5.0, new DateTime(2024, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), "Payment Detailes For Project_8", 2.0, null, 736620640, new DateTime(2024, 7, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 0f },
                    { 867478260, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 8.0, 9, new DateTime(2024, 12, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 9, "Test Description Project_9", "KL-3", new DateTime(2024, 12, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), new DateTime(2024, 12, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 0f, 100L, 12L, new DateTime(2024, 3, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), "Project_3", 5.0, new DateTime(2024, 12, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), "Payment Detailes For Project_15", 3.0, null, 992128840, new DateTime(2024, 12, 1, 17, 22, 48, 257, DateTimeKind.Local).AddTicks(1670), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 536329949, 178161854, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3412), 367641801, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3413) },
                    { 968012066, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3852), 548683896, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3853) },
                    { 968012066, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3694), 124125822, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3696) },
                    { 334496286, 299354066, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3442), 230170616, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3443) },
                    { 968012066, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3725), 457962724, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3726) },
                    { 521403968, 353454767, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3995), 585520290, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3996) },
                    { 485249153, 392160920, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3621), 988449590, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3622) },
                    { 485249153, 441874521, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3591), 669157416, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3592) },
                    { 485249153, 445715605, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3504), 884160378, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3505) },
                    { 562532645, 474015927, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3314), 357518165, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3315) },
                    { 485249153, 496508338, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3649), 756465238, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3650) },
                    { 886761836, 572679627, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3350), 690318868, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3351) },
                    { 584741166, 580878256, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3380), 290534779, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3381) },
                    { 521403968, 614140926, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4023), 840347321, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4024) },
                    { 485249153, 628802181, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3533), 472526866, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3534) },
                    { 521403968, 746830103, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4052), 269060989, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4053) },
                    { 968012066, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3753), 125708152, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3754) },
                    { 485249153, 826037567, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3561), 939323795, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3562) },
                    { 521403968, 856350679, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3964), 624078763, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3965) },
                    { 968012066, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3822), 892894781, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3824) },
                    { 968012066, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3793), 236624290, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(3794) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1921420592, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4728), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4729), 867478260, 869591208, null },
                    { -1720151224, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4674), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4675), 610973605, 910427803, null },
                    { -1572689160, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4755), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4756), 274405059, 474184973, null },
                    { -1448869160, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4768), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4770), 274405059, 409944808, null },
                    { -1316599648, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4646), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4647), 502814518, 409944808, null },
                    { -999763112, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4687), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4688), 610973605, 552504005, null },
                    { -918601592, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4625), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4626), 502814518, 333950945, null },
                    { -577501280, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4715), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4716), 867478260, 333950945, null },
                    { -503237096, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4701), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4702), 610973605, 911839150, null },
                    { 180164312, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4741), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4742), 867478260, 769147815, null },
                    { 1059191520, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4660), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4661), 502814518, 910427803, null },
                    { 1770924416, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4781), 0f, 1500L, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4782), 274405059, 911839150, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 533553753, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4354), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4356), 13000.0, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4355), "Signature 142348", 11224, 274405059, 4.0, 24.0 },
                    { 736381929, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4217), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4219), 3100.0, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4218), "Signature 142346", 16931, 610973605, 2.0, 24.0 },
                    { 764455928, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4145), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4148), 3010.0, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4147), "Signature 142344", 57425, 502814518, 1.0, 17.0 },
                    { 793422767, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4290), new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4293), 4000.0, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4291), "Signature 1423415", 34429, 867478260, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 610973605, 353454767, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6218), 626094273, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6219) },
                    { 867478260, 614140926, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6230), 870889885, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6231) },
                    { 274405059, 746830103, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6243), 526784883, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6244) },
                    { 502814518, 856350679, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6201), 203734965, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6202) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 270474853, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4187), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4189), null, "6949277782", null, null, 610973605 },
                    { 349648670, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4111), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4112), null, "6949277781", null, null, 502814518 },
                    { 928381880, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4325), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4326), null, "6949277784", null, null, 274405059 },
                    { 983304425, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4261), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4262), null, "6949277783", null, null, 867478260 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1921420592, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6858), 218745714, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6860) },
                    { -1921420592, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6796), 475932920, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6797) },
                    { -1921420592, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6809), 323248415, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6810) },
                    { -1921420592, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6821), 597436978, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6822) },
                    { -1921420592, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6846), 646490601, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6847) },
                    { -1921420592, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6834), 238700993, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6835) },
                    { -1720151224, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6559), 732388127, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6560) },
                    { -1720151224, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6493), 751572343, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6494) },
                    { -1720151224, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6509), 883077308, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6510) },
                    { -1720151224, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6521), 948337828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6523) },
                    { -1720151224, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6546), 681394362, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6547) },
                    { -1720151224, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6534), 762779340, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6535) },
                    { -1572689160, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7013), 888912503, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7014) },
                    { -1572689160, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6950), 155474528, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6951) },
                    { -1572689160, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6963), 195740242, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6964) },
                    { -1572689160, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6975), 264959962, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6976) },
                    { -1572689160, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7000), 868410748, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7001) },
                    { -1572689160, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6988), 756345067, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6989) },
                    { -1448869160, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7089), 833804891, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7090) },
                    { -1448869160, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7026), 473914120, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7027) },
                    { -1448869160, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7038), 995462839, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7039) },
                    { -1448869160, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7050), 345181915, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7051) },
                    { -1448869160, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7075), 817848691, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7076) },
                    { -1448869160, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7063), 590089070, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7064) },
                    { -1316599648, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6405), 590186705, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6406) },
                    { -1316599648, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6341), 962525518, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6342) },
                    { -1316599648, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6354), 929739972, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6355) },
                    { -1316599648, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6366), 917861363, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6367) },
                    { -1316599648, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6392), 439531385, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6393) },
                    { -1316599648, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6380), 491495406, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6381) },
                    { -999763112, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6633), 497882721, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6635) },
                    { -999763112, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6571), 737369932, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6572) },
                    { -999763112, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6584), 394840978, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6585) },
                    { -999763112, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6596), 777248298, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6597) },
                    { -999763112, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6621), 785795884, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6622) },
                    { -999763112, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6609), 168854472, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6610) },
                    { -918601592, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6327), 521494355, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6329) },
                    { -918601592, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6257), 153560695, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6258) },
                    { -918601592, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6274), 843568985, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6275) },
                    { -918601592, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6287), 935298243, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6288) },
                    { -918601592, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6313), 930746270, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6314) },
                    { -918601592, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6300), 929074546, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6301) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -577501280, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6784), 476923008, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6785) },
                    { -577501280, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6721), 797364050, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6722) },
                    { -577501280, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6734), 463260923, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6735) },
                    { -577501280, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6746), 526412383, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6748) },
                    { -577501280, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6772), 222393072, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6773) },
                    { -577501280, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6759), 430009162, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6760) },
                    { -503237096, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6709), 144635747, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6710) },
                    { -503237096, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6646), 636242246, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6647) },
                    { -503237096, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6658), 266717163, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6660) },
                    { -503237096, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6671), 137071281, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6672) },
                    { -503237096, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6697), 645982157, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6698) },
                    { -503237096, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6684), 256679546, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6685) },
                    { 180164312, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6938), 675766111, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6939) },
                    { 180164312, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6875), 422629877, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6876) },
                    { 180164312, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6888), 305318601, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6889) },
                    { 180164312, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6901), 464657050, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6902) },
                    { 180164312, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6926), 504723029, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6927) },
                    { 180164312, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6913), 848417330, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6914) },
                    { 1059191520, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6481), 749880448, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6482) },
                    { 1059191520, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6417), 622740373, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6419) },
                    { 1059191520, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6430), 431772753, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6431) },
                    { 1059191520, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6442), 989048136, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6443) },
                    { 1059191520, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6467), 779931460, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6468) },
                    { 1059191520, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6455), 198378076, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6456) },
                    { 1770924416, 233406904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7164), 878737282, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7165) },
                    { 1770924416, 274878052, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7101), 128127982, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7103) },
                    { 1770924416, 350325828, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7114), 306147080, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7115) },
                    { 1770924416, 787884851, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7126), 201803514, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7127) },
                    { 1770924416, 881397638, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7151), 970095632, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7152) },
                    { 1770924416, 916336706, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7139), 575755886, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7140) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 139023241, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5102), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5099), -577501280, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5100), 972044161 },
                    { 144983613, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5335), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5333), 1770924416, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5334), 871378577 },
                    { 178489816, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5115), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5112), -577501280, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5114), 243044296 },
                    { 184110254, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4924), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4921), -1316599648, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4923), 871378577 },
                    { 208217798, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4938), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4935), 1059191520, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4936), 972044161 },
                    { 233644865, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5088), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5086), -503237096, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5087), 871378577 },
                    { 267265522, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5073), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5071), -503237096, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5072), 243044296 },
                    { 272390154, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5226), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5224), -1572689160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5225), 972044161 },
                    { 278742346, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5006), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5004), -1720151224, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5005), 871378577 },
                    { 290852659, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5293), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5290), -1448869160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5292), 871378577 },
                    { 310365966, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5240), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5237), -1572689160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5238), 243044296 },
                    { 311123613, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5033), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5030), -999763112, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5032), 243044296 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 383170022, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4964), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4962), 1059191520, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4963), 871378577 },
                    { 418550084, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5169), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5166), -1921420592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5168), 871378577 },
                    { 422094556, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4980), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4977), -1720151224, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4978), 972044161 },
                    { 422107852, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4951), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4948), 1059191520, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4950), 243044296 },
                    { 427262758, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5060), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5057), -503237096, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5059), 972044161 },
                    { 448477417, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4867), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4864), -918601592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4866), 243044296 },
                    { 448800900, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5128), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5126), -577501280, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5127), 871378577 },
                    { 510605103, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5142), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5139), -1921420592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5141), 972044161 },
                    { 518013915, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4993), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4991), -1720151224, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4992), 243044296 },
                    { 524177419, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5156), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5153), -1921420592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5154), 243044296 },
                    { 544558452, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5020), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5017), -999763112, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5018), 972044161 },
                    { 545082823, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5046), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5044), -999763112, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5045), 871378577 },
                    { 550500632, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5280), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5277), -1448869160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5278), 243044296 },
                    { 561827849, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4846), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4843), -918601592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4844), 972044161 },
                    { 562867382, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5309), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5306), 1770924416, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5307), 972044161 },
                    { 570451122, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5200), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5197), 180164312, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5199), 243044296 },
                    { 636973676, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5213), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5211), 180164312, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5212), 871378577 },
                    { 787353343, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4881), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4879), -918601592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4880), 871378577 },
                    { 835943615, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5186), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5184), 180164312, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5185), 972044161 },
                    { 925264846, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5253), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5250), -1572689160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5252), 871378577 },
                    { 933803369, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4895), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4893), -1316599648, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4894), 972044161 },
                    { 944653026, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5267), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5264), -1448869160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5265), 972044161 },
                    { 953320781, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5322), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5319), 1770924416, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5321), 243044296 },
                    { 991369149, new DateTime(2024, 3, 12, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4909), 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4906), -1316599648, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4907), 243044296 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 129015496, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5467), -918601592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5468), 497280772 },
                    { 131294371, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5522), -1316599648, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5523), 908498660 },
                    { 147756512, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5575), 1059191520, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5576), 464221588 },
                    { 148034887, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6046), -1572689160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6047), 497280772 },
                    { 164500322, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5612), 1059191520, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5613), 425763481 },
                    { 182601059, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6121), -1448869160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6122), 425763481 },
                    { 188664521, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5625), -1720151224, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5626), 603627237 },
                    { 197296216, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5908), -1921420592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5909), 908498660 },
                    { 197546652, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5496), -1316599648, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5497), 603627237 },
                    { 206060672, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5509), -1316599648, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5510), 464221588 },
                    { 233775796, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5818), -577501280, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5819), 603627237 },
                    { 246396804, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5422), -918601592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5423), 603627237 },
                    { 289196171, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6109), -1448869160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6110), 497280772 },
                    { 319057334, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5857), -577501280, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5859), 497280772 },
                    { 319943459, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5870), -577501280, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5871), 425763481 },
                    { 325797300, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5945), 180164312, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5947), 603627237 },
                    { 343550672, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5689), -999763112, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5690), 603627237 },
                    { 345597554, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6071), -1448869160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6072), 603627237 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 368817695, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5789), -503237096, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5791), 497280772 },
                    { 390143619, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5843), -577501280, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5844), 908498660 },
                    { 390984916, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5920), -1921420592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5921), 497280772 },
                    { 421568877, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5831), -577501280, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5832), 464221588 },
                    { 427004645, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6021), -1572689160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6022), 464221588 },
                    { 427522131, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5651), -1720151224, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5652), 908498660 },
                    { 466367649, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5777), -503237096, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5778), 908498660 },
                    { 517312482, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5714), -999763112, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5716), 908498660 },
                    { 612456588, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5895), -1921420592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5897), 464221588 },
                    { 613403655, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5958), 180164312, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5959), 464221588 },
                    { 631435626, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5637), -1720151224, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5638), 464221588 },
                    { 650096903, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5764), -503237096, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5765), 464221588 },
                    { 659409290, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6150), 1770924416, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6151), 464221588 },
                    { 668208490, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5802), -503237096, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5803), 425763481 },
                    { 681798316, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5534), -1316599648, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5535), 497280772 },
                    { 687474042, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5727), -999763112, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5728), 497280772 },
                    { 729268174, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5702), -999763112, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5703), 464221588 },
                    { 739480211, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5548), -1316599648, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5549), 425763481 },
                    { 745532024, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5600), 1059191520, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5601), 497280772 },
                    { 758981771, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6096), -1448869160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6098), 908498660 },
                    { 778181365, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6059), -1572689160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6060), 425763481 },
                    { 811829555, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5454), -918601592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5455), 908498660 },
                    { 817329937, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5752), -503237096, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5753), 603627237 },
                    { 818077130, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5587), 1059191520, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5588), 908498660 },
                    { 819625513, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6187), 1770924416, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6188), 425763481 },
                    { 842008124, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5562), 1059191520, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5563), 603627237 },
                    { 879139554, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5739), -999763112, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5740), 425763481 },
                    { 883929750, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6034), -1572689160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6035), 908498660 },
                    { 887501708, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6175), 1770924416, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6176), 497280772 },
                    { 896849693, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6162), 1770924416, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6163), 908498660 },
                    { 927722043, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5933), -1921420592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5934), 425763481 },
                    { 929336218, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5480), -918601592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5481), 425763481 },
                    { 942250423, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5664), -1720151224, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5665), 497280772 },
                    { 942625061, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6137), 1770924416, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6138), 603627237 },
                    { 942785653, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5441), -918601592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5442), 464221588 },
                    { 955015936, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5996), 180164312, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5997), 425763481 },
                    { 964826332, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5676), -1720151224, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5678), 425763481 },
                    { 974518472, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5883), -1921420592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5884), 603627237 },
                    { 975002638, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6009), -1572689160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6010), 603627237 },
                    { 996748799, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6084), -1448869160, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(6085), 464221588 },
                    { 997581994, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5971), 180164312, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5972), 908498660 },
                    { 997646043, 0f, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5984), 180164312, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(5985), 497280772 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 339207389, 270474853, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4204), 509740658, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4205) },
                    { 339207389, 349648670, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4130), 435655850, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4132) },
                    { 339207389, 928381880, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4341), 972950961, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4342) },
                    { 339207389, 983304425, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4277), 916156981, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(4278) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 392160920, 129015496, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7452), -904035626, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7453) },
                    { 441874521, 129015496, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7440), 948143696, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7441) },
                    { 445715605, 129015496, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7405), -1080213808, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7406) },
                    { 496508338, 129015496, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7464), -25319704, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7465) },
                    { 628802181, 129015496, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7416), -1476158309, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7417) },
                    { 826037567, 129015496, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7428), 1110983531, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7429) },
                    { 392160920, 131294371, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7741), -288622169, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7742) },
                    { 441874521, 131294371, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7729), -1678616990, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7730) },
                    { 445715605, 131294371, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7694), -2060745862, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7695) },
                    { 496508338, 131294371, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7753), 1761929771, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7754) },
                    { 628802181, 131294371, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7705), -2044753150, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7706) },
                    { 826037567, 131294371, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7717), 1146034553, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7718) },
                    { 392160920, 147756512, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8032), -682825315, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8033) },
                    { 441874521, 147756512, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8020), 1357159131, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8021) },
                    { 445715605, 147756512, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7984), 863572127, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7986) },
                    { 496508338, 147756512, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8044), 1048716779, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8045) },
                    { 628802181, 147756512, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7997), -1016388058, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7998) },
                    { 826037567, 147756512, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8008), 95222071, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8010) },
                    { 392160920, 148034887, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(704), -1598995921, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(705) },
                    { 441874521, 148034887, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(692), -865346395, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(694) },
                    { 445715605, 148034887, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(657), 383779418, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(658) },
                    { 496508338, 148034887, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(717), 827418848, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(718) },
                    { 628802181, 148034887, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(669), 1797307412, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(670) },
                    { 826037567, 148034887, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(681), 1535510660, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(682) },
                    { 392160920, 164500322, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8249), -1118364812, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8250) },
                    { 441874521, 164500322, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8237), 356963608, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8239) },
                    { 445715605, 164500322, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8199), 1403660489, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8200) },
                    { 496508338, 164500322, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8261), -401812267, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8262) },
                    { 628802181, 164500322, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8211), 750798563, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8212) },
                    { 826037567, 164500322, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8223), -1013934950, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8224) },
                    { 392160920, 182601059, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1136), -2028219164, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1137) },
                    { 441874521, 182601059, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1124), 781345040, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1125) },
                    { 445715605, 182601059, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1089), 2014164932, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1090) },
                    { 496508338, 182601059, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1148), -1442374087, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1149) },
                    { 628802181, 182601059, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1101), -1267227346, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1102) },
                    { 826037567, 182601059, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1113), -715386221, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1114) },
                    { 392160920, 188664521, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8322), 1638290934, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8323) },
                    { 441874521, 188664521, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8310), -99709960, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8311) },
                    { 445715605, 188664521, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8274), -1243617101, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8275) },
                    { 496508338, 188664521, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8333), 850360532, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8334) },
                    { 628802181, 188664521, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8286), 1974645090, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8287) },
                    { 826037567, 188664521, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8298), -662055407, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8299) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 392160920, 197296216, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9907), 1852471611, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9908) },
                    { 441874521, 197296216, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9896), 21579584, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9897) },
                    { 445715605, 197296216, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9860), -706234949, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9861) },
                    { 496508338, 197296216, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9919), -1585691792, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9920) },
                    { 628802181, 197296216, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9872), -1261948517, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9873) },
                    { 826037567, 197296216, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9884), 2146617338, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9885) },
                    { 392160920, 197546652, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7598), -1788871058, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7599) },
                    { 441874521, 197546652, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7587), -1653819596, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7588) },
                    { 445715605, 197546652, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7547), 1215369108, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7548) },
                    { 496508338, 197546652, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7610), 1174608986, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7611) },
                    { 628802181, 197546652, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7562), 1256517918, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7563) },
                    { 826037567, 197546652, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7574), 1488942581, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7575) },
                    { 392160920, 206060672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7670), -1756782782, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7671) },
                    { 441874521, 206060672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7658), 1972597280, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7659) },
                    { 445715605, 206060672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7622), -2143819120, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7623) },
                    { 496508338, 206060672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7682), -282380404, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7683) },
                    { 628802181, 206060672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7634), -942087005, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7635) },
                    { 826037567, 206060672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7646), -823368730, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7647) },
                    { 392160920, 233775796, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9403), -516316900, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9404) },
                    { 441874521, 233775796, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9391), 947774390, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9392) },
                    { 445715605, 233775796, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9355), 2092024796, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9356) },
                    { 496508338, 233775796, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9414), 1120065786, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9415) },
                    { 628802181, 233775796, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9367), 1396150821, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9368) },
                    { 826037567, 233775796, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9379), -358911328, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9380) },
                    { 392160920, 246396804, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7234), 2071184544, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7235) },
                    { 441874521, 246396804, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7221), -1857424342, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7223) },
                    { 445715605, 246396804, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7178), -1555231139, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7179) },
                    { 496508338, 246396804, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7247), -1548780385, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7248) },
                    { 628802181, 246396804, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7194), 1750214795, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7195) },
                    { 826037567, 246396804, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7209), -1756269031, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7210) },
                    { 392160920, 289196171, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1065), -1154986181, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1066) },
                    { 441874521, 289196171, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1054), 1331289162, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1055) },
                    { 445715605, 289196171, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1017), 1556661155, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1019) },
                    { 496508338, 289196171, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1077), 2115705609, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1078) },
                    { 628802181, 289196171, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1029), -513204718, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1030) },
                    { 826037567, 289196171, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1041), -324692135, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1043) },
                    { 392160920, 319057334, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9617), 1302839325, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9618) },
                    { 441874521, 319057334, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9605), -34022078, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9607) },
                    { 445715605, 319057334, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9570), 2036762699, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9571) },
                    { 496508338, 319057334, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9632), -945538811, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9634) },
                    { 628802181, 319057334, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9582), 996966653, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9583) },
                    { 826037567, 319057334, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9594), 2122253096, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9595) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 392160920, 319943459, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9692), 1205738051, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9693) },
                    { 441874521, 319943459, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9680), -338255338, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9682) },
                    { 445715605, 319943459, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9645), -680767060, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9646) },
                    { 496508338, 319943459, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9704), -1380846302, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9705) },
                    { 628802181, 319943459, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9657), 86803259, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9658) },
                    { 826037567, 319943459, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9669), 1725827090, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9670) },
                    { 392160920, 325797300, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(125), -1025333563, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(126) },
                    { 441874521, 325797300, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(113), 210371900, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(114) },
                    { 445715605, 325797300, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(77), 1386684288, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(78) },
                    { 496508338, 325797300, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(137), -1751749793, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(138) },
                    { 628802181, 325797300, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(89), 337663697, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(90) },
                    { 826037567, 325797300, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(101), -1315419488, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(102) },
                    { 392160920, 343550672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8681), 238176208, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8682) },
                    { 441874521, 343550672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8669), -996578918, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8671) },
                    { 445715605, 343550672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8634), 135143281, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8635) },
                    { 496508338, 343550672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8693), 1501248461, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8694) },
                    { 628802181, 343550672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8646), -93007916, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8647) },
                    { 826037567, 343550672, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8658), 137406695, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8659) },
                    { 392160920, 345597554, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(848), -914240231, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(849) },
                    { 441874521, 345597554, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(836), 957455735, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(837) },
                    { 445715605, 345597554, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(800), 409169575, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(801) },
                    { 496508338, 345597554, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(859), 175328726, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(860) },
                    { 628802181, 345597554, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(812), -834491452, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(813) },
                    { 826037567, 345597554, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(824), -296494784, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(825) },
                    { 392160920, 368817695, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9260), 1880846321, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9261) },
                    { 441874521, 368817695, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9245), 970925297, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9246) },
                    { 445715605, 368817695, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9209), -2050289351, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9211) },
                    { 496508338, 368817695, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9272), -1403246029, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9273) },
                    { 628802181, 368817695, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9221), -2108031200, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9222) },
                    { 826037567, 368817695, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9233), 1670528664, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9234) },
                    { 392160920, 390143619, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9546), 50387486, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9547) },
                    { 441874521, 390143619, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9534), 1384113429, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9535) },
                    { 445715605, 390143619, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9498), 1840435713, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9500) },
                    { 496508338, 390143619, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9558), 1963839186, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9559) },
                    { 628802181, 390143619, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9510), -1922465335, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9511) },
                    { 826037567, 390143619, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9522), -1519056539, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9524) },
                    { 392160920, 390984916, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9978), -1156788121, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9980) },
                    { 441874521, 390984916, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9967), -724226476, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9968) },
                    { 445715605, 390984916, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9931), -511038103, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9932) },
                    { 496508338, 390984916, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9991), -1419148876, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9992) },
                    { 628802181, 390984916, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9943), -1214736200, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9944) },
                    { 826037567, 390984916, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9955), -383905957, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9956) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 392160920, 421568877, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9474), 80313904, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9475) },
                    { 441874521, 421568877, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9462), -1363758808, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9463) },
                    { 445715605, 421568877, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9426), -2121245999, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9427) },
                    { 496508338, 421568877, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9486), -1372387841, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9487) },
                    { 628802181, 421568877, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9438), 119517976, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9439) },
                    { 826037567, 421568877, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9450), -1059084350, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9451) },
                    { 392160920, 427004645, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(561), 1375333749, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(562) },
                    { 441874521, 427004645, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(547), 1816923785, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(548) },
                    { 445715605, 427004645, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(512), -39107254, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(513) },
                    { 496508338, 427004645, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(573), -982172497, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(575) },
                    { 628802181, 427004645, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(523), 1399286169, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(524) },
                    { 826037567, 427004645, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(535), -179701213, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(536) },
                    { 392160920, 427522131, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8464), -976001278, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8465) },
                    { 441874521, 427522131, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8452), -2006642663, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8453) },
                    { 445715605, 427522131, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8416), -1426219541, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8417) },
                    { 496508338, 427522131, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8475), 948981281, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8476) },
                    { 628802181, 427522131, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8428), 865459886, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8429) },
                    { 826037567, 427522131, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8440), -1037243479, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8441) },
                    { 392160920, 466367649, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9185), 645432206, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9186) },
                    { 441874521, 466367649, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9174), -1067485157, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9175) },
                    { 445715605, 466367649, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9138), 2069342181, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9139) },
                    { 496508338, 466367649, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9197), 1486930203, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9198) },
                    { 628802181, 466367649, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9150), -1325788924, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9151) },
                    { 826037567, 466367649, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9162), -2039048531, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9163) },
                    { 392160920, 517312482, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8825), -776730181, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8826) },
                    { 441874521, 517312482, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8813), 89041748, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8814) },
                    { 445715605, 517312482, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8778), 1885367133, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8779) },
                    { 496508338, 517312482, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8837), -884383834, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8838) },
                    { 628802181, 517312482, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8790), -809040568, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8791) },
                    { 826037567, 517312482, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8801), -706717088, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8802) },
                    { 392160920, 612456588, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9836), -1360295522, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9837) },
                    { 441874521, 612456588, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9824), -1833278269, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9825) },
                    { 445715605, 612456588, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9788), 2133173619, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9789) },
                    { 496508338, 612456588, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9848), -2059166848, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9849) },
                    { 628802181, 612456588, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9800), -2127354497, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9801) },
                    { 826037567, 612456588, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9812), 170770703, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9813) },
                    { 392160920, 613403655, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(196), -989861899, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(197) },
                    { 441874521, 613403655, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(184), 2015749787, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(185) },
                    { 445715605, 613403655, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(149), 2077328228, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(150) },
                    { 496508338, 613403655, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(208), 82759883, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(209) },
                    { 628802181, 613403655, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(160), -756922315, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(161) },
                    { 826037567, 613403655, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(172), -1715810867, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(173) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 392160920, 631435626, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8393), -771187076, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8394) },
                    { 441874521, 631435626, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8381), -1055391317, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8382) },
                    { 445715605, 631435626, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8345), -396351814, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8347) },
                    { 496508338, 631435626, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8404), 317551739, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8405) },
                    { 628802181, 631435626, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8357), -174290075, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8358) },
                    { 826037567, 631435626, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8369), 2102060831, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8370) },
                    { 392160920, 650096903, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9114), 1526812272, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9115) },
                    { 441874521, 650096903, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9102), -1033196156, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9103) },
                    { 445715605, 650096903, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9067), 1987978554, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9068) },
                    { 496508338, 650096903, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9126), -19592567, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9127) },
                    { 628802181, 650096903, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9078), 2047774932, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9080) },
                    { 826037567, 650096903, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9090), 1257058, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9091) },
                    { 392160920, 659409290, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1280), 671603765, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1281) },
                    { 441874521, 659409290, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1268), -144557837, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1269) },
                    { 445715605, 659409290, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1232), -226077308, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1233) },
                    { 496508338, 659409290, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1291), -677258387, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1293) },
                    { 628802181, 659409290, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1244), -1137121141, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1245) },
                    { 826037567, 659409290, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1256), -229059076, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1257) },
                    { 392160920, 668208490, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9331), 1840747712, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9332) },
                    { 441874521, 668208490, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9319), 1955371563, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9320) },
                    { 445715605, 668208490, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9284), -982387547, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9285) },
                    { 496508338, 668208490, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9343), -1707330145, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9344) },
                    { 628802181, 668208490, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9295), -1654080988, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9297) },
                    { 826037567, 668208490, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9307), -151792226, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9308) },
                    { 392160920, 681798316, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7811), -1464571700, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7812) },
                    { 441874521, 681798316, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7800), -921124930, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7801) },
                    { 445715605, 681798316, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7765), -164041141, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7766) },
                    { 496508338, 681798316, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7823), -1496991352, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7824) },
                    { 628802181, 681798316, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7776), -780111503, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7777) },
                    { 826037567, 681798316, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7788), -838483253, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7789) },
                    { 392160920, 687474042, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8899), 2140086762, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8900) },
                    { 441874521, 687474042, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8887), -278418275, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8888) },
                    { 445715605, 687474042, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8849), -469862869, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8850) },
                    { 496508338, 687474042, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8912), 829530959, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8913) },
                    { 628802181, 687474042, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8861), -819034289, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8862) },
                    { 826037567, 687474042, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8873), 1461213716, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8874) },
                    { 392160920, 729268174, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8754), -999011713, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8755) },
                    { 441874521, 729268174, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8742), 1345523801, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8743) },
                    { 445715605, 729268174, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8705), 1796383967, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8706) },
                    { 496508338, 729268174, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8766), -1053006047, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8767) },
                    { 628802181, 729268174, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8717), -24621011, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8718) },
                    { 826037567, 729268174, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8729), 1974568739, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8730) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 392160920, 739480211, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7883), 238152295, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7884) },
                    { 441874521, 739480211, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7871), -1100131811, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7872) },
                    { 445715605, 739480211, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7835), -1742286541, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7836) },
                    { 496508338, 739480211, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7895), -941868323, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7896) },
                    { 628802181, 739480211, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7847), 1314775350, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7848) },
                    { 826037567, 739480211, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7859), 2016621774, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7860) },
                    { 392160920, 745532024, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8175), -716294515, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8176) },
                    { 441874521, 745532024, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8163), -1146726449, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8164) },
                    { 445715605, 745532024, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8127), -80290592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8129) },
                    { 496508338, 745532024, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8187), 533321204, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8188) },
                    { 628802181, 745532024, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8140), -73033402, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8141) },
                    { 826037567, 745532024, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8151), 43921787, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8152) },
                    { 392160920, 758981771, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(993), 1116038925, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(995) },
                    { 441874521, 758981771, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(982), -596972816, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(983) },
                    { 445715605, 758981771, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(946), 1943628840, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(947) },
                    { 496508338, 758981771, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1005), 1585161216, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1006) },
                    { 628802181, 758981771, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(958), 1749129656, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(959) },
                    { 826037567, 758981771, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(970), -388529383, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(971) },
                    { 392160920, 778181365, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(776), 1060639610, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(777) },
                    { 441874521, 778181365, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(764), -1807024454, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(765) },
                    { 445715605, 778181365, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(729), -1208444728, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(730) },
                    { 496508338, 778181365, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(788), -1604431142, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(789) },
                    { 628802181, 778181365, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(740), 989838221, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(742) },
                    { 826037567, 778181365, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(752), -947279137, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(753) },
                    { 392160920, 811829555, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7380), 782167973, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7381) },
                    { 441874521, 811829555, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7368), 1811809418, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7369) },
                    { 445715605, 811829555, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7332), -117469624, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7333) },
                    { 496508338, 811829555, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7393), -2122032298, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7394) },
                    { 628802181, 811829555, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7344), 1594216692, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7345) },
                    { 826037567, 811829555, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7356), -1604095699, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7357) },
                    { 392160920, 817329937, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9043), 1144284773, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9044) },
                    { 441874521, 817329937, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9031), -801396107, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9032) },
                    { 445715605, 817329937, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8995), -143565286, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8996) },
                    { 496508338, 817329937, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9054), 1221023363, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9056) },
                    { 628802181, 817329937, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9007), -1379517592, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9008) },
                    { 826037567, 817329937, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9019), -206437688, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9020) },
                    { 392160920, 818077130, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8103), -1173405275, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8104) },
                    { 441874521, 818077130, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8092), -2083316462, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8093) },
                    { 445715605, 818077130, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8056), 1188547317, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8057) },
                    { 496508338, 818077130, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8115), -541329907, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8116) },
                    { 628802181, 818077130, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8068), 1109934356, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8069) },
                    { 826037567, 818077130, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8080), -59812550, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8081) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 392160920, 819625513, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1496), 1747693850, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1497) },
                    { 441874521, 819625513, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1484), -1088087458, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1485) },
                    { 445715605, 819625513, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1449), -643964417, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1450) },
                    { 496508338, 819625513, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1508), -2140780742, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1509) },
                    { 628802181, 819625513, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1461), 1987365578, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1462) },
                    { 826037567, 819625513, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1472), -1884665137, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1473) },
                    { 392160920, 842008124, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7958), 1883536011, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7960) },
                    { 441874521, 842008124, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7947), -595049984, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7948) },
                    { 445715605, 842008124, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7911), 2028757325, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7912) },
                    { 496508338, 842008124, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7972), 252497233, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7973) },
                    { 628802181, 842008124, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7923), -874810934, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7924) },
                    { 826037567, 842008124, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7935), 1537426116, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7936) },
                    { 392160920, 879139554, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8971), 1700535996, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8972) },
                    { 441874521, 879139554, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8959), 265479881, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8961) },
                    { 445715605, 879139554, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8924), -1363728028, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8925) },
                    { 496508338, 879139554, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8983), -1944995021, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8984) },
                    { 628802181, 879139554, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8936), -1488085658, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8937) },
                    { 826037567, 879139554, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8948), 1084193573, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8949) },
                    { 392160920, 883929750, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(633), 330080320, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(634) },
                    { 441874521, 883929750, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(621), 1832615897, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(622) },
                    { 445715605, 883929750, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(586), -1532937469, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(587) },
                    { 496508338, 883929750, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(645), 1841835294, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(646) },
                    { 628802181, 883929750, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(597), 1599757983, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(598) },
                    { 826037567, 883929750, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(609), -1521975595, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(610) },
                    { 392160920, 887501708, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1425), -819308002, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1426) },
                    { 441874521, 887501708, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1413), 1920791673, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1414) },
                    { 445715605, 887501708, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1378), -972438524, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1379) },
                    { 496508338, 887501708, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1437), -996653753, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1438) },
                    { 628802181, 887501708, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1389), -470025310, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1391) },
                    { 826037567, 887501708, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1401), 1329424254, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1402) },
                    { 392160920, 896849693, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1354), -142243937, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1355) },
                    { 441874521, 896849693, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1342), 448776860, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1343) },
                    { 445715605, 896849693, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1306), -1602878044, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1307) },
                    { 496508338, 896849693, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1366), -391673002, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1367) },
                    { 628802181, 896849693, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1318), -531095210, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1319) },
                    { 826037567, 896849693, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1330), -1086004633, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1331) },
                    { 392160920, 927722043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(53), 1779550808, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(54) },
                    { 441874521, 927722043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(41), 2121573573, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(42) },
                    { 445715605, 927722043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(5), -869730241, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(6) },
                    { 496508338, 927722043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(64), 1813881699, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(66) },
                    { 628802181, 927722043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(17), -1615114723, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(18) },
                    { 826037567, 927722043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(29), 438861344, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(30) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 392160920, 929336218, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7523), 1026025268, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7524) },
                    { 441874521, 929336218, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7511), -647247230, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7512) },
                    { 445715605, 929336218, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7476), 1146391776, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7477) },
                    { 496508338, 929336218, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7535), 782578391, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7536) },
                    { 628802181, 929336218, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7488), -1484183969, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7489) },
                    { 826037567, 929336218, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7499), 1283671485, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7500) },
                    { 392160920, 942250423, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8535), -1869855691, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8536) },
                    { 441874521, 942250423, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8523), -1967061721, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8524) },
                    { 445715605, 942250423, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8487), -1365541870, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8489) },
                    { 496508338, 942250423, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8546), -122624293, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8547) },
                    { 628802181, 942250423, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8499), 1974953664, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8500) },
                    { 826037567, 942250423, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8511), 1409503910, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8512) },
                    { 392160920, 942625061, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1208), -1324602368, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1209) },
                    { 441874521, 942625061, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1196), 1827346725, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1197) },
                    { 445715605, 942625061, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1160), 344751098, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1161) },
                    { 496508338, 942625061, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1219), 164714468, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1221) },
                    { 628802181, 942625061, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1172), -1730109163, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1173) },
                    { 826037567, 942625061, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1184), -547117406, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(1185) },
                    { 392160920, 942785653, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7309), 1285368048, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7310) },
                    { 441874521, 942785653, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7296), 608224073, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7297) },
                    { 445715605, 942785653, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7259), 752607716, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7260) },
                    { 496508338, 942785653, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7320), -1340743850, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7321) },
                    { 628802181, 942785653, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7272), -1131634844, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7273) },
                    { 826037567, 942785653, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7284), -2145204521, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(7285) },
                    { 392160920, 955015936, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(417), 91315418, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(418) },
                    { 441874521, 955015936, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(405), -1859603453, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(406) },
                    { 445715605, 955015936, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(369), -1120396369, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(370) },
                    { 496508338, 955015936, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(428), -704010734, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(429) },
                    { 628802181, 955015936, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(381), 2052716369, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(382) },
                    { 826037567, 955015936, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(392), -2018827453, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(394) },
                    { 392160920, 964826332, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8609), -1409949823, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8610) },
                    { 441874521, 964826332, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8594), -1605578237, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8595) },
                    { 445715605, 964826332, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8558), -55767838, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8559) },
                    { 496508338, 964826332, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8621), -233929673, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8622) },
                    { 628802181, 964826332, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8570), -955940917, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8572) },
                    { 826037567, 964826332, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8582), 52111562, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(8583) },
                    { 392160920, 974518472, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9764), -1675390612, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9765) },
                    { 441874521, 974518472, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9752), 1550840531, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9753) },
                    { 445715605, 974518472, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9716), -595911005, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9717) },
                    { 496508338, 974518472, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9776), -741109711, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9777) },
                    { 628802181, 974518472, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9728), -940210177, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9729) },
                    { 826037567, 974518472, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9740), -226240636, new DateTime(2024, 3, 1, 17, 22, 48, 268, DateTimeKind.Local).AddTicks(9741) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 392160920, 975002638, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(488), 1345102506, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(489) },
                    { 441874521, 975002638, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(476), 1906352100, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(477) },
                    { 445715605, 975002638, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(440), 1548105926, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(441) },
                    { 496508338, 975002638, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(500), -177749869, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(501) },
                    { 628802181, 975002638, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(452), 380741248, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(453) },
                    { 826037567, 975002638, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(464), 1157171355, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(465) },
                    { 392160920, 996748799, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(919), -1914951910, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(920) },
                    { 441874521, 996748799, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(907), -1869608020, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(908) },
                    { 445715605, 996748799, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(871), -1743430387, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(872) },
                    { 496508338, 996748799, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(934), -1674468278, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(935) },
                    { 628802181, 996748799, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(883), -1221924271, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(884) },
                    { 826037567, 996748799, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(895), -355201969, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(896) },
                    { 392160920, 997581994, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(267), 206016283, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(268) },
                    { 441874521, 997581994, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(255), 658757921, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(256) },
                    { 445715605, 997581994, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(220), -652578565, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(221) },
                    { 496508338, 997581994, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(285), 1012704386, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(286) },
                    { 628802181, 997581994, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(231), 171180343, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(232) },
                    { 826037567, 997581994, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(243), -1427267947, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(244) },
                    { 392160920, 997646043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(345), -1142719901, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(346) },
                    { 441874521, 997646043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(333), -767987707, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(334) },
                    { 445715605, 997646043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(297), 743420786, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(298) },
                    { 496508338, 997646043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(357), -238227506, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(358) },
                    { 628802181, 997646043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(309), -1367956412, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(310) },
                    { 826037567, 997646043, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(321), -1029876074, new DateTime(2024, 3, 1, 17, 22, 48, 269, DateTimeKind.Local).AddTicks(322) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyTime_CorporateUserId",
                table: "DailyTime",
                column: "CorporateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTime_DailyUserId",
                table: "DailyTime",
                column: "DailyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTime_DisciplineId",
                table: "DailyTime",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTime_DrawingId",
                table: "DailyTime",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTime_OtherId",
                table: "DailyTime",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTime_PersonalUserId",
                table: "DailyTime",
                column: "PersonalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTime_ProjectId",
                table: "DailyTime",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTime_TimeSpanId",
                table: "DailyTime",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTime_TrainingUserId",
                table: "DailyTime",
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
                name: "DailyTime");

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
