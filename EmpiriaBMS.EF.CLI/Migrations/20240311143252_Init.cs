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
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ord = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
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
                    IsEditable = table.Column<bool>(type: "bit", nullable: false),
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
                name: "RolePermission",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
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
                    { 153207808, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6870), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6871), "Natural Gas" },
                    { 167985985, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6992), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6993), "Construction Supervision" },
                    { 168179354, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6910), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6911), "Burglar Alarm" },
                    { 292944600, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6858), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6860), "Elevators" },
                    { 392639550, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6945), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6946), "Photovoltaics" },
                    { 395878097, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6847), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6848), "Fire Suppression" },
                    { 402067832, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6979), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6980), "TenderDocument" },
                    { 420677574, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6922), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6923), "CCTV" },
                    { 579842227, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6933), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6934), "BMS" },
                    { 582430115, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6821), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6822), "Drainage" },
                    { 591227152, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6967), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6969), "Outsource" },
                    { 647391789, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6810), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6811), "Potable Water" },
                    { 713130138, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6881), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6882), "Power Distribution" },
                    { 793314425, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6833), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6834), "Fire Detection" },
                    { 819551042, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6898), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6899), "Structured Cabling" },
                    { 900088496, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6797), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6798), "Sewage" },
                    { 916699040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6778), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6779), "HVAC" },
                    { 984335200, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6956), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6957), "Energy Efficiency" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 231017905, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7208), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7209), "Drawings" },
                    { 619820236, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7175), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7176), "Documents" },
                    { 673965964, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7193), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7194), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 145457931, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7736), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7737), "On-Site" },
                    { 325743807, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7760), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7761), "Administration" },
                    { 335552232, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7706), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7707), "Communications" },
                    { 749894662, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7723), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7724), "Printing" },
                    { 815054804, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7748), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7749), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 262982472, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4984), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4986), "See All Drawings", 10 },
                    { 280121087, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4900), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4902), "Dashboard Assign Engineer", 4 },
                    { 325127843, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4929), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4930), "Dashboard Add Project", 6 },
                    { 379963461, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4914), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4915), "Dashboard Assign Project Manager", 5 },
                    { 437698721, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4869), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4870), "Dashboard Edit My Hours", 2 },
                    { 471373200, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4997), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4998), "See All Projects", 11 },
                    { 517877972, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4887), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4888), "Dashboard Assign Designer", 3 },
                    { 537446174, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4721), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4722), "See Dashboard Layout", 1 },
                    { 565099233, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4970), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4971), "See All Disciplines", 9 },
                    { 747550253, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4957), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4958), "Dashboard See My Hours", 8 },
                    { 869157262, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4943), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(4944), "See Admin Layout", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 186875018, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6305), "Buildings Description", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6306), "Buildings" },
                    { 560391743, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6322), "Infrastructure Description", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6323), "Infrastructure" },
                    { 571647475, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6335), "Energy Description", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6336), "Energy" },
                    { 733594964, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6350), "Consulting Description", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6351), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[] { 133318446, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5011), false, true, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5013), "Designer" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5085), false, true, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5086), "CEO" },
                    { 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5057), false, true, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5058), "COO" },
                    { 567450142, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5031), false, true, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5032), "Engineer" },
                    { 578647042, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5128), false, false, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5129), "Admin" },
                    { 691539297, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5044), false, true, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5046), "Project Manager" },
                    { 824254259, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5070), false, true, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5071), "CTO" },
                    { 928479978, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5101), false, false, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5103), "Guest" },
                    { 987445339, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5115), false, false, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5116), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6143), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6144), null, "6949277780", null, null, null },
                    { 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6249), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6251), null, "6949277784", null, null, null },
                    { 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6199), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6200), null, "6949277782", null, null, null },
                    { 352745766, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5866), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5867), null, "694927778", null, null, null },
                    { 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6224), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6225), null, "6949277783", null, null, null },
                    { 422831525, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5920), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5921), null, "694927778", null, null, null },
                    { 458191167, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6004), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6005), null, "6949277781", null, null, null },
                    { 531478291, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6461), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6462), null, "6949277784", null, null, null },
                    { 556283439, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6375), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6376), null, "6949277781", null, null, null },
                    { 572484573, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5797), "Admin", "admin@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5799), null, "694927778", null, null, null },
                    { 600294015, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6407), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6408), null, "6949277782", null, null, null },
                    { 639051752, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6030), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6031), null, "6949277782", null, null, null },
                    { 651983377, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5833), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5834), null, "694927778", null, null, null },
                    { 666267354, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6083), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6084), null, "6949277784", null, null, null },
                    { 713061634, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5893), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5894), null, "694927778", null, null, null },
                    { 739085382, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6116), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6117), null, "6949277785", null, null, null },
                    { 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6276), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6277), null, "6949277785", null, null, null },
                    { 913469088, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6434), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6435), null, "6949277783", null, null, null },
                    { 965471659, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6055), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6057), null, "6949277783", null, null, null },
                    { 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6174), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6175), null, "6949277781", null, null, null },
                    { 980745327, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5952), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5953), null, "6949277780", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 448295723, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 9.0, 16, new DateTime(2025, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 16, "Test Description Project_12", "KL-4", new DateTime(2025, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), new DateTime(2025, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 0f, 100L, 12L, new DateTime(2024, 3, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), "Project_4", 5.0, new DateTime(2025, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), "Payment Detailes For Project_12", 4.0, null, 733594964, new DateTime(2025, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 0f },
                    { 546593469, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 8.0, 9, new DateTime(2024, 12, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 9, "Test Description Project_15", "KL-3", new DateTime(2024, 12, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), new DateTime(2024, 12, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 0f, 100L, 12L, new DateTime(2024, 3, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), "Project_3", 5.0, new DateTime(2024, 12, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), "Payment Detailes For Project_6", 3.0, null, 571647475, new DateTime(2024, 12, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 0f },
                    { 650220489, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 6.0, 1, new DateTime(2024, 4, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 4, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), new DateTime(2024, 4, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 0f, 100L, 12L, new DateTime(2024, 3, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), "Project_1", 5.0, new DateTime(2024, 4, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), "Payment Detailes For Project_2", 1.0, null, 186875018, new DateTime(2024, 4, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 0f },
                    { 727007588, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 7.0, 4, new DateTime(2024, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 4, "Test Description Project_8", "KL-2", new DateTime(2024, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), new DateTime(2024, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 0f, 100L, 12L, new DateTime(2024, 3, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), "Project_2", 5.0, new DateTime(2024, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), "Payment Detailes For Project_8", 2.0, null, 560391743, new DateTime(2024, 7, 11, 16, 32, 51, 739, DateTimeKind.Local).AddTicks(2771), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 437698721, 133318446, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5178), -281206268, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5179) },
                    { 537446174, 133318446, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5155), 2035021284, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5156) },
                    { 747550253, 133318446, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5191), 141270179, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5193) },
                    { 262982472, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5694), -585332414, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5695) },
                    { 280121087, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5629), 176869661, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5630) },
                    { 325127843, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5655), -1932670192, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5656) },
                    { 379963461, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5642), -1984296059, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5643) },
                    { 437698721, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5603), -1907194207, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5605) },
                    { 471373200, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5707), -451362176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5708) },
                    { 517877972, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5616), 243589001, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5617) },
                    { 537446174, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5589), -701201474, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5591) },
                    { 565099233, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5681), -1248025121, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5682) },
                    { 869157262, 194726992, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5668), 1556635793, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5669) },
                    { 262982472, 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5454), 684335111, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5455) },
                    { 280121087, 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5402), -188274698, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5403) },
                    { 379963461, 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5414), -1017373684, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5416) },
                    { 437698721, 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5373), 1167444032, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5374) },
                    { 471373200, 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5467), -557823487, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5468) },
                    { 517877972, 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5387), -56312702, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5388) },
                    { 537446174, 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5360), -1887799621, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5362) },
                    { 565099233, 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5440), 1769390753, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5441) },
                    { 747550253, 394635568, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5427), -919863112, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5428) },
                    { 262982472, 567450142, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5271), -1474908799, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5272) },
                    { 437698721, 567450142, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5217), -1234239290, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5218) },
                    { 517877972, 567450142, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5231), 1002817661, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5232) },
                    { 537446174, 567450142, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5204), -789015140, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5205) },
                    { 565099233, 567450142, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5258), -1794116947, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5259) },
                    { 747550253, 567450142, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5245), -430990825, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5246) },
                    { 262982472, 578647042, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5771), 1707902249, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5772) },
                    { 471373200, 578647042, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5784), -99115375, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5785) },
                    { 565099233, 578647042, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5758), -1198430923, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5760) },
                    { 869157262, 578647042, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5745), 261971533, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5746) },
                    { 262982472, 691539297, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5348), 1414367397, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5349) },
                    { 280121087, 691539297, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5310), 1816068893, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5311) },
                    { 437698721, 691539297, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5297), 1437307088, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5298) },
                    { 537446174, 691539297, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5284), -1332055655, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5285) },
                    { 565099233, 691539297, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5335), 1813693352, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5336) },
                    { 747550253, 691539297, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5322), -127866451, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5323) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 262982472, 824254259, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5562), 1316628513, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5563) },
                    { 325127843, 824254259, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5522), -1358595440, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5523) },
                    { 379963461, 824254259, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5509), -1536148705, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5510) },
                    { 437698721, 824254259, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5496), -1098629563, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5497) },
                    { 471373200, 824254259, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5575), -299758355, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5576) },
                    { 537446174, 824254259, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5483), 1197224015, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5484) },
                    { 565099233, 824254259, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5549), 1527999251, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5551) },
                    { 747550253, 824254259, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5535), 1901596185, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5536) },
                    { 537446174, 928479978, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5719), -1009114978, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5721) },
                    { 537446174, 987445339, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5732), -1741635746, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5733) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 567450142, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6161), 725389407, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6162) },
                    { 567450142, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6264), 506093392, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6265) },
                    { 567450142, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6212), 844235588, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6213) },
                    { 824254259, 352745766, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5880), 734983171, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5881) },
                    { 567450142, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6238), 733688930, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6239) },
                    { 928479978, 422831525, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5934), 350738826, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5935) },
                    { 133318446, 458191167, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6018), 252352388, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6019) },
                    { 691539297, 531478291, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6474), 168796036, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6475) },
                    { 691539297, 556283439, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6393), 921897658, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6394) },
                    { 578647042, 572484573, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5816), 744629315, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5817) },
                    { 691539297, 600294015, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6421), 837017070, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6422) },
                    { 133318446, 639051752, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6043), 792080054, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6045) },
                    { 194726992, 651983377, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5847), 919505252, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5849) },
                    { 133318446, 666267354, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6099), 151556641, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6100) },
                    { 394635568, 713061634, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5907), 788257668, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5908) },
                    { 133318446, 739085382, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6130), 720569223, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6131) },
                    { 567450142, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6290), 759968195, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6291) },
                    { 691539297, 913469088, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6449), 299056647, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6450) },
                    { 133318446, 965471659, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6070), 258182556, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6071) },
                    { 567450142, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6188), 415434994, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6189) },
                    { 133318446, 980745327, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5991), 694912761, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(5992) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1963934176, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7010), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7011), 650220489, 395878097, null },
                    { -1691630440, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7110), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7111), 546593469, 153207808, null },
                    { -1349598128, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7122), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7123), 546593469, 647391789, null },
                    { -1005410952, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7160), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7161), 448295723, 402067832, null },
                    { -942355120, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7031), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7033), 650220489, 984335200, null },
                    { -563646176, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7057), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7058), 727007588, 292944600, null },
                    { 383535624, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7084), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7085), 727007588, 582430115, null },
                    { 388084664, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7097), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7098), 546593469, 900088496, null },
                    { 830644256, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7044), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7045), 650220489, 292944600, null },
                    { 1407128432, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7135), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7137), 448295723, 582430115, null },
                    { 1599904680, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7148), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7149), 448295723, 168179354, null },
                    { 1777285824, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7070), 0f, 1500L, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7071), 727007588, 420677574, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 265456634, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6566), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6568), 3010.0, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6567), "Signature 142341", 17585, 650220489, 1.0, 17.0 },
                    { 449260999, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6639), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6641), 3100.0, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6640), "Signature 142342", 28138, 727007588, 2.0, 24.0 },
                    { 579633401, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6701), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6703), 4000.0, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6702), "Signature 142343", 84994, 546593469, 3.0, 17.0 },
                    { 847951485, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6759), new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6761), 13000.0, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6760), "Signature 142348", 30172, 448295723, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 448295723, 531478291, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8537), 707783791, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8538) },
                    { 650220489, 556283439, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8497), 288338516, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8499) },
                    { 727007588, 600294015, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8514), 135885379, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8515) },
                    { 546593469, 913469088, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8525), 221357942, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8527) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 158279613, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6734), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6735), null, "6949277784", null, null, 448295723 },
                    { 401665403, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6675), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6676), null, "6949277783", null, null, 546593469 },
                    { 616957452, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6610), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6611), null, "6949277782", null, null, 727007588 },
                    { 721337185, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6535), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6536), null, "6949277781", null, null, 650220489 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1963934176, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8549), 182502448, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8550) },
                    { -1963934176, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8602), 575706011, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8603) },
                    { -1963934176, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8579), 238867700, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8580) },
                    { -1963934176, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8590), 758990149, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8591) },
                    { -1963934176, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8614), 733965105, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8615) },
                    { -1963934176, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8566), 920160561, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8568) },
                    { -1691630440, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9057), 527918954, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9058) },
                    { -1691630440, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9108), 531749898, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9109) },
                    { -1691630440, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9081), 717013004, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9082) },
                    { -1691630440, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9096), 220366800, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9097) },
                    { -1691630440, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9120), 960330664, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9121) },
                    { -1691630440, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9069), 352005895, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9070) },
                    { -1349598128, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9132), 907168312, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9133) },
                    { -1349598128, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9178), 602034216, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9179) },
                    { -1349598128, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9155), 341456671, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9156) },
                    { -1349598128, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9166), 713707190, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9167) },
                    { -1349598128, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9190), 794185715, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9191) },
                    { -1349598128, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9143), 129431965, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9144) },
                    { -1005410952, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9348), 331198347, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9349) },
                    { -1005410952, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9395), 789195025, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9396) },
                    { -1005410952, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9372), 799222865, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9373) },
                    { -1005410952, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9383), 289219561, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9384) },
                    { -1005410952, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9406), 753104929, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9407) },
                    { -1005410952, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9360), 414950147, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9361) },
                    { -942355120, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8627), 806952096, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8628) },
                    { -942355120, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8676), 678746364, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8677) },
                    { -942355120, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8651), 548613831, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8652) },
                    { -942355120, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8664), 405978228, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8665) },
                    { -942355120, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8687), 458840729, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8688) },
                    { -942355120, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8639), 159682429, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8640) },
                    { -563646176, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8774), 818625169, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8775) },
                    { -563646176, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8820), 820005953, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8821) },
                    { -563646176, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8797), 749576067, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8798) },
                    { -563646176, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8808), 818755209, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8809) },
                    { -563646176, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8831), 700303807, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8832) },
                    { -563646176, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8785), 850382811, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8786) },
                    { 383535624, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8913), 877203013, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8914) },
                    { 383535624, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8961), 191447695, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8962) },
                    { 383535624, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8936), 607318856, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8937) },
                    { 383535624, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8949), 644827521, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8950) },
                    { 383535624, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8973), 600259980, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8974) },
                    { 383535624, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8925), 344975546, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8926) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 388084664, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8985), 519010157, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8986) },
                    { 388084664, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9033), 414950279, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9034) },
                    { 388084664, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9009), 211353324, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9010) },
                    { 388084664, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9021), 693082176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9022) },
                    { 388084664, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9045), 997248670, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9046) },
                    { 388084664, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8997), 806391943, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8998) },
                    { 830644256, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8699), 837922712, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8700) },
                    { 830644256, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8746), 128834344, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8747) },
                    { 830644256, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8722), 123509908, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8723) },
                    { 830644256, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8734), 192203658, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8735) },
                    { 830644256, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8761), 621581695, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8762) },
                    { 830644256, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8711), 846299827, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8712) },
                    { 1407128432, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9202), 558679634, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9203) },
                    { 1407128432, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9253), 991488520, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9254) },
                    { 1407128432, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9230), 749909399, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9231) },
                    { 1407128432, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9242), 147528107, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9243) },
                    { 1407128432, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9265), 247298354, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9266) },
                    { 1407128432, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9213), 177291606, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9214) },
                    { 1599904680, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9277), 502793065, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9278) },
                    { 1599904680, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9323), 374888031, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9324) },
                    { 1599904680, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9300), 599582613, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9301) },
                    { 1599904680, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9312), 184815450, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9313) },
                    { 1599904680, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9336), 661592577, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9337) },
                    { 1599904680, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9289), 396391802, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9290) },
                    { 1777285824, 254888409, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8843), 431351007, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8844) },
                    { 1777285824, 264347928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8890), 174809194, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8891) },
                    { 1777285824, 310468040, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8867), 515880696, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8868) },
                    { 1777285824, 408690850, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8879), 532392581, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8880) },
                    { 1777285824, 842007338, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8901), 708666237, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8902) },
                    { 1777285824, 979452413, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8855), 911595641, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8856) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 143982758, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7642), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7639), 1599904680, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7640), 673965964 },
                    { 159757275, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7404), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7401), 1777285824, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7402), 673965964 },
                    { 179213138, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7324), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7322), 830644256, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7323), 673965964 },
                    { 244018023, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7669), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7667), -1005410952, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7668), 619820236 },
                    { 298189873, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7298), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7295), -942355120, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7296), 231017905 },
                    { 306384921, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7577), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7575), -1349598128, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7576), 231017905 },
                    { 331362916, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7365), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7363), -563646176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7364), 673965964 },
                    { 340999683, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7225), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7222), -1963934176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7223), 619820236 },
                    { 347792135, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7429), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7427), 383535624, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7428), 619820236 },
                    { 357181969, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7337), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7334), 830644256, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7336), 231017905 },
                    { 360873150, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7525), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7523), -1691630440, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7524), 673965964 },
                    { 421503532, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7352), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7349), -563646176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7350), 619820236 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 427011577, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7616), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7613), 1407128432, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7614), 231017905 },
                    { 472317559, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7456), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7454), 383535624, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7455), 231017905 },
                    { 474169600, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7591), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7588), 1407128432, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7589), 619820236 },
                    { 532407794, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7244), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7241), -1963934176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7243), 673965964 },
                    { 561697018, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7496), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7493), 388084664, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7495), 231017905 },
                    { 581725868, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7391), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7389), 1777285824, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7390), 619820236 },
                    { 592506806, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7564), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7562), -1349598128, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7563), 673965964 },
                    { 598998110, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7283), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7281), -942355120, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7282), 673965964 },
                    { 600416027, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7469), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7467), 388084664, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7468), 619820236 },
                    { 627379949, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7311), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7309), 830644256, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7310), 619820236 },
                    { 628064444, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7508), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7506), -1691630440, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7507), 619820236 },
                    { 706188492, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7654), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7652), 1599904680, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7653), 231017905 },
                    { 798805055, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7270), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7268), -942355120, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7269), 619820236 },
                    { 829702746, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7378), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7376), -563646176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7377), 231017905 },
                    { 870331329, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7482), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7480), 388084664, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7481), 673965964 },
                    { 875567447, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7603), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7601), 1407128432, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7602), 673965964 },
                    { 888697282, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7681), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7679), -1005410952, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7680), 673965964 },
                    { 914382858, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7538), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7536), -1691630440, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7537), 231017905 },
                    { 930707971, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7257), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7254), -1963934176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7256), 231017905 },
                    { 932149863, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7694), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7692), -1005410952, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7693), 231017905 },
                    { 952024036, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7629), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7626), 1599904680, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7628), 619820236 },
                    { 953101738, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7442), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7440), 383535624, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7441), 673965964 },
                    { 981262203, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7416), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7414), 1777285824, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7415), 231017905 },
                    { 993502521, new DateTime(2024, 3, 22, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7551), 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7549), -1349598128, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7550), 619820236 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 126051091, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7828), -1963934176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7830), 325743807 },
                    { 126365862, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8054), 1777285824, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8055), 815054804 },
                    { 150053358, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8236), -1691630440, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8237), 815054804 },
                    { 167643350, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8008), -563646176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8009), 325743807 },
                    { 185734215, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8282), -1349598128, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8283), 145457931 },
                    { 224500590, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8352), 1407128432, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8353), 815054804 },
                    { 233066754, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7854), -942355120, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7855), 749894662 },
                    { 237444412, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7817), -1963934176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7818), 815054804 },
                    { 251617623, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7865), -942355120, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7867), 145457931 },
                    { 283844547, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8164), 388084664, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8165), 145457931 },
                    { 285902109, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7937), 830644256, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7938), 815054804 },
                    { 319078549, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7985), -563646176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7986), 145457931 },
                    { 328620145, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8341), 1407128432, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8342), 145457931 },
                    { 340752187, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8387), 1599904680, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8388), 749894662 },
                    { 341671923, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8031), 1777285824, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8032), 749894662 },
                    { 360398620, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8248), -1691630440, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8249), 325743807 },
                    { 375984582, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8364), 1407128432, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8365), 325743807 },
                    { 419032575, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8424), 1599904680, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8425), 325743807 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 425957892, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7972), -563646176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7973), 749894662 },
                    { 457849556, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7996), -563646176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7997), 815054804 },
                    { 485296590, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8448), -1005410952, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8449), 749894662 },
                    { 529629948, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8178), 388084664, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8179), 815054804 },
                    { 529777820, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7914), 830644256, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7915), 749894662 },
                    { 531454056, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8329), 1407128432, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8330), 749894662 },
                    { 553506834, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7775), -1963934176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7776), 335552232 },
                    { 558987624, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8459), -1005410952, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8460), 145457931 },
                    { 567212978, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8375), 1599904680, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8376), 335552232 },
                    { 585654457, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8306), -1349598128, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8307), 325743807 },
                    { 586935968, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8470), -1005410952, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8472), 815054804 },
                    { 603416275, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8401), 1599904680, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8402), 145457931 },
                    { 613846965, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8153), 388084664, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8154), 749894662 },
                    { 627590161, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8100), 383535624, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8101), 145457931 },
                    { 638833574, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7877), -942355120, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7878), 815054804 },
                    { 660766572, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7926), 830644256, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7927), 145457931 },
                    { 667613330, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8482), -1005410952, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8483), 325743807 },
                    { 680572172, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8225), -1691630440, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8226), 145457931 },
                    { 692066188, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8318), 1407128432, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8319), 335552232 },
                    { 719032839, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8129), 383535624, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8130), 325743807 },
                    { 726125297, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7902), 830644256, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7903), 335552232 },
                    { 756421282, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8259), -1349598128, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8260), 335552232 },
                    { 758506662, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7790), -1963934176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7791), 749894662 },
                    { 775714006, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8116), 383535624, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8117), 815054804 },
                    { 797234079, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8077), 383535624, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8078), 335552232 },
                    { 811117421, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7890), -942355120, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7891), 325743807 },
                    { 819084108, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8043), 1777285824, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8044), 145457931 },
                    { 820907510, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8294), -1349598128, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8295), 815054804 },
                    { 825047400, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8271), -1349598128, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8272), 749894662 },
                    { 849019605, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8213), -1691630440, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8214), 749894662 },
                    { 864665087, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8189), 388084664, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8190), 325743807 },
                    { 874908594, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7842), -942355120, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7843), 335552232 },
                    { 883767964, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8201), -1691630440, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8202), 335552232 },
                    { 885246041, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7960), -563646176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7962), 335552232 },
                    { 897016436, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8065), 1777285824, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8066), 325743807 },
                    { 922749820, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8020), 1777285824, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8021), 335552232 },
                    { 951073262, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8413), 1599904680, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8414), 815054804 },
                    { 958178792, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8089), 383535624, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8090), 749894662 },
                    { 960173928, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7802), -1963934176, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7804), 145457931 },
                    { 967568779, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7949), 830644256, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(7950), 325743807 },
                    { 974641431, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8141), 388084664, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8142), 335552232 },
                    { 982562684, 0f, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8436), -1005410952, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(8437), 335552232 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 987445339, 158279613, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6748), 805852758, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6749) },
                    { 987445339, 401665403, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6689), 312571063, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6690) },
                    { 987445339, 616957452, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6627), 226775427, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6628) },
                    { 987445339, 721337185, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6552), 885308102, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(6553) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458191167, 126051091, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9707), -2135027848, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9709) },
                    { 639051752, 126051091, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9718), -1993092164, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9719) },
                    { 666267354, 126051091, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9743), -1040175791, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9744) },
                    { 739085382, 126051091, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9755), -879732139, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9756) },
                    { 965471659, 126051091, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9729), -263622608, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9730) },
                    { 980745327, 126051091, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9697), -610137994, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9698) },
                    { 458191167, 126365862, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(986), 463539101, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(987) },
                    { 639051752, 126365862, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(997), 1426867070, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(998) },
                    { 666267354, 126365862, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1019), -2002116608, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1020) },
                    { 739085382, 126365862, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1030), -243590503, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1031) },
                    { 965471659, 126365862, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1008), -389947333, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1009) },
                    { 980745327, 126365862, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(975), -1786353358, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(976) },
                    { 458191167, 150053358, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1984), 1238546565, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1985) },
                    { 639051752, 150053358, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1995), -1995871391, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1996) },
                    { 666267354, 150053358, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2020), 1683436649, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2022) },
                    { 739085382, 150053358, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2032), -869602958, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2033) },
                    { 965471659, 150053358, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2009), 1727401428, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2010) },
                    { 980745327, 150053358, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1973), -1606244827, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1975) },
                    { 458191167, 167643350, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(714), -154546654, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(715) },
                    { 639051752, 167643350, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(726), -1862261320, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(727) },
                    { 666267354, 167643350, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(747), -1444026941, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(748) },
                    { 739085382, 167643350, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(758), 2120122998, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(759) },
                    { 965471659, 167643350, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(737), -330928802, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(738) },
                    { 980745327, 167643350, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(700), 17837776, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(701) },
                    { 458191167, 185734215, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2251), -696928868, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2252) },
                    { 639051752, 185734215, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2262), -1568072515, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2263) },
                    { 666267354, 185734215, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2284), -96686014, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2285) },
                    { 739085382, 185734215, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2300), -529439458, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2301) },
                    { 965471659, 185734215, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2273), 2038501755, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2274) },
                    { 980745327, 185734215, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2240), 1968702363, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2241) },
                    { 458191167, 224500590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2656), 665634758, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2657) },
                    { 639051752, 224500590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2667), 1873046412, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2668) },
                    { 666267354, 224500590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2689), 823539110, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2690) },
                    { 739085382, 224500590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2700), 428953676, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2701) },
                    { 965471659, 224500590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2678), -305111974, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2679) },
                    { 980745327, 224500590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2645), 304708172, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2646) },
                    { 458191167, 233066754, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9845), -579199639, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9846) },
                    { 639051752, 233066754, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9856), -1094688881, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9857) },
                    { 666267354, 233066754, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9879), -1377217471, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9880) },
                    { 739085382, 233066754, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9889), 1930041428, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9890) },
                    { 965471659, 233066754, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9867), -159597350, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9868) },
                    { 980745327, 233066754, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9835), 1333521828, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9836) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458191167, 237444412, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9642), -1961426065, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9643) },
                    { 639051752, 237444412, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9653), -973374416, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9654) },
                    { 666267354, 237444412, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9674), 1464467621, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9675) },
                    { 739085382, 237444412, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9685), -1936565747, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9686) },
                    { 965471659, 237444412, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9664), 1316729844, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9665) },
                    { 980745327, 237444412, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9631), 377439260, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9632) },
                    { 458191167, 251617623, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9911), 1757736374, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9912) },
                    { 639051752, 251617623, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9922), 1054385294, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9923) },
                    { 666267354, 251617623, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9944), 256619710, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9945) },
                    { 739085382, 251617623, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9955), -249462094, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9956) },
                    { 965471659, 251617623, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9933), -1284855979, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9934) },
                    { 980745327, 251617623, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9900), -444156394, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9902) },
                    { 458191167, 283844547, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1587), -1942114985, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1588) },
                    { 639051752, 283844547, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1598), -846505547, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1599) },
                    { 666267354, 283844547, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1619), -677340679, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1620) },
                    { 739085382, 283844547, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1630), 1815354176, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1631) },
                    { 965471659, 283844547, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1608), 1375734879, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1610) },
                    { 980745327, 283844547, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1576), -1401513997, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1577) },
                    { 458191167, 285902109, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(311), -1804717291, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(312) },
                    { 639051752, 285902109, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(322), -287713700, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(323) },
                    { 666267354, 285902109, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(344), -608667686, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(345) },
                    { 739085382, 285902109, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(355), -424683562, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(356) },
                    { 965471659, 285902109, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(333), 255365308, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(334) },
                    { 980745327, 285902109, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(300), -413295560, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(301) },
                    { 458191167, 319078549, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(578), 374828954, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(579) },
                    { 639051752, 319078549, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(589), 982619816, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(590) },
                    { 666267354, 319078549, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(611), -926122904, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(613) },
                    { 739085382, 319078549, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(622), -1427214392, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(623) },
                    { 965471659, 319078549, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(600), -881574799, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(601) },
                    { 980745327, 319078549, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(568), -525585829, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(569) },
                    { 458191167, 328620145, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2589), -2091272462, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2591) },
                    { 639051752, 328620145, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2600), -1900439576, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2602) },
                    { 666267354, 328620145, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2623), 637652804, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2624) },
                    { 739085382, 328620145, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2634), 46456345, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2635) },
                    { 965471659, 328620145, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2611), -824962306, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2613) },
                    { 980745327, 328620145, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2579), -1328636267, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2580) },
                    { 458191167, 340752187, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2853), -1038167914, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2855) },
                    { 639051752, 340752187, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2868), -1260103949, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2869) },
                    { 666267354, 340752187, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2890), -1257411451, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2891) },
                    { 739085382, 340752187, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2902), -313686157, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2903) },
                    { 965471659, 340752187, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2879), 1512721805, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2880) },
                    { 980745327, 340752187, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2843), 2077923375, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2844) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458191167, 341671923, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(847), 1327430943, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(848) },
                    { 639051752, 341671923, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(858), 1740308495, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(859) },
                    { 666267354, 341671923, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(881), -649272419, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(882) },
                    { 739085382, 341671923, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(892), 1291146251, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(893) },
                    { 965471659, 341671923, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(870), -961274258, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(871) },
                    { 980745327, 341671923, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(836), 1542915887, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(837) },
                    { 458191167, 360398620, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2053), -1715615072, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2055) },
                    { 639051752, 360398620, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2065), -71921384, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2066) },
                    { 666267354, 360398620, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2086), -130926608, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2087) },
                    { 739085382, 360398620, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2097), 701569463, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2099) },
                    { 965471659, 360398620, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2076), 1545840855, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2077) },
                    { 980745327, 360398620, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2043), -2095666865, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2044) },
                    { 458191167, 375984582, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2722), 205211854, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2723) },
                    { 639051752, 375984582, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2733), -646734199, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2734) },
                    { 666267354, 375984582, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2755), -557918783, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2756) },
                    { 739085382, 375984582, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2766), -1755539851, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2767) },
                    { 965471659, 375984582, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2744), -1416707423, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2745) },
                    { 980745327, 375984582, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2711), 1297947015, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2712) },
                    { 458191167, 419032575, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3058), 1879375743, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3059) },
                    { 639051752, 419032575, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3069), -379781621, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3070) },
                    { 666267354, 419032575, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3091), 932278370, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3092) },
                    { 739085382, 419032575, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3102), 87400846, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3103) },
                    { 965471659, 419032575, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3080), -80700034, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3081) },
                    { 980745327, 419032575, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3047), 1361032209, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3048) },
                    { 458191167, 425957892, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(513), 1339483469, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(514) },
                    { 639051752, 425957892, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(523), 1772380076, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(525) },
                    { 666267354, 425957892, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(545), -812653357, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(546) },
                    { 739085382, 425957892, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(556), -1297303370, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(557) },
                    { 965471659, 425957892, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(534), -699405146, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(536) },
                    { 980745327, 425957892, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(502), 772509686, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(503) },
                    { 458191167, 457849556, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(645), -1749456130, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(646) },
                    { 639051752, 457849556, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(656), -1149733052, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(657) },
                    { 666267354, 457849556, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(677), -334927282, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(678) },
                    { 739085382, 457849556, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(688), -2006688118, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(689) },
                    { 965471659, 457849556, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(666), -1877535233, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(668) },
                    { 980745327, 457849556, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(634), 1271342142, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(635) },
                    { 458191167, 485296590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3191), 2029139703, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3192) },
                    { 639051752, 485296590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3201), 1488921260, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3202) },
                    { 666267354, 485296590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3226), 1236286440, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3227) },
                    { 739085382, 485296590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3237), 1817158388, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3238) },
                    { 965471659, 485296590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3215), -949416461, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3216) },
                    { 980745327, 485296590, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3180), 187819138, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3181) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458191167, 529629948, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1652), -1317160124, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1653) },
                    { 639051752, 529629948, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1666), -152503951, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1667) },
                    { 666267354, 529629948, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1688), -2018902796, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1689) },
                    { 739085382, 529629948, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1699), -654464470, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1700) },
                    { 965471659, 529629948, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1677), -491844595, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1678) },
                    { 980745327, 529629948, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1641), -261512639, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1642) },
                    { 458191167, 529777820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(179), -1376893727, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(180) },
                    { 639051752, 529777820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(190), -1018385531, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(191) },
                    { 666267354, 529777820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(212), -606501490, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(213) },
                    { 739085382, 529777820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(223), 672634895, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(224) },
                    { 965471659, 529777820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(201), -2094677572, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(202) },
                    { 980745327, 529777820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(168), 209825974, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(169) },
                    { 458191167, 531454056, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2524), -1338847375, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2525) },
                    { 639051752, 531454056, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2535), -1165879831, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2536) },
                    { 666267354, 531454056, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2557), -1133174312, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2558) },
                    { 739085382, 531454056, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2568), -1928506157, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2569) },
                    { 965471659, 531454056, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2546), -1709159566, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2547) },
                    { 980745327, 531454056, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2510), -618866450, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2511) },
                    { 458191167, 553506834, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9438), -164018110, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9439) },
                    { 639051752, 553506834, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9449), -1330070831, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9450) },
                    { 666267354, 553506834, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9470), 189679330, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9472) },
                    { 739085382, 553506834, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9483), -890498848, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9484) },
                    { 965471659, 553506834, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9459), 1629990522, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9460) },
                    { 980745327, 553506834, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9422), -1995248650, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9423) },
                    { 458191167, 558987624, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3259), 2146950626, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3261) },
                    { 639051752, 558987624, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3270), -1265867752, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3271) },
                    { 666267354, 558987624, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3292), -902909569, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3293) },
                    { 739085382, 558987624, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3303), -1997701253, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3304) },
                    { 965471659, 558987624, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3281), -942282139, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3282) },
                    { 980745327, 558987624, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3248), -911584772, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3249) },
                    { 458191167, 567212978, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2788), 245822045, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2789) },
                    { 639051752, 567212978, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2799), -1975468760, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2800) },
                    { 666267354, 567212978, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2821), 1262670656, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2822) },
                    { 739085382, 567212978, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2831), -1711833646, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2832) },
                    { 965471659, 567212978, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2810), 2059990263, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2811) },
                    { 980745327, 567212978, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2777), 1768634267, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2778) },
                    { 458191167, 585654457, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2389), 870488024, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2390) },
                    { 639051752, 585654457, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2400), -718551562, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2401) },
                    { 666267354, 585654457, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2422), -300213355, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2423) },
                    { 739085382, 585654457, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2433), -388433785, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2434) },
                    { 965471659, 585654457, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2411), 988391048, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2412) },
                    { 980745327, 585654457, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2378), 105677474, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2380) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458191167, 586935968, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3326), -195519833, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3327) },
                    { 639051752, 586935968, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3337), 1610134497, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3338) },
                    { 666267354, 586935968, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3359), -1206805184, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3360) },
                    { 739085382, 586935968, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3370), 1354627553, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3371) },
                    { 965471659, 586935968, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3348), -1121603939, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3349) },
                    { 980745327, 586935968, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3314), 181947371, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3315) },
                    { 458191167, 603416275, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2924), 1771550442, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2925) },
                    { 639051752, 603416275, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2935), -326999047, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2936) },
                    { 666267354, 603416275, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2957), 1387790618, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2958) },
                    { 739085382, 603416275, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2968), -996520108, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2969) },
                    { 965471659, 603416275, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2946), -82696697, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2947) },
                    { 980745327, 603416275, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2913), -1717853809, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2914) },
                    { 458191167, 613846965, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1520), 820109498, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1521) },
                    { 639051752, 613846965, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1532), 1832152905, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1533) },
                    { 666267354, 613846965, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1554), -842631380, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1555) },
                    { 739085382, 613846965, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1565), 437493470, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1566) },
                    { 965471659, 613846965, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1542), -276586429, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1543) },
                    { 980745327, 613846965, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1509), -1773529622, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1510) },
                    { 458191167, 627590161, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1251), 2036340054, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1252) },
                    { 639051752, 627590161, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1262), 1384228125, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1263) },
                    { 666267354, 627590161, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1286), 1417025106, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1287) },
                    { 739085382, 627590161, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1297), 1117952946, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1298) },
                    { 965471659, 627590161, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1275), 1397938892, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1276) },
                    { 980745327, 627590161, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1240), -1303702082, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1241) },
                    { 458191167, 638833574, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9977), -947505424, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9978) },
                    { 639051752, 638833574, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9988), 1502514567, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9989) },
                    { 666267354, 638833574, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(10), -736517096, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(11) },
                    { 739085382, 638833574, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(21), -2036383694, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(22) },
                    { 965471659, 638833574, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9999), -1958694007, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local) },
                    { 980745327, 638833574, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9966), -1666881989, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9967) },
                    { 458191167, 660766572, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(245), -1069970660, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(246) },
                    { 639051752, 660766572, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(256), -30138182, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(257) },
                    { 666267354, 660766572, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(277), 113406521, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(278) },
                    { 739085382, 660766572, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(288), 783362939, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(289) },
                    { 965471659, 660766572, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(266), 1853589974, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(268) },
                    { 980745327, 660766572, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(234), 302500387, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(235) },
                    { 458191167, 667613330, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3392), -1017177925, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3393) },
                    { 639051752, 667613330, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3403), 875320961, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3404) },
                    { 666267354, 667613330, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3425), -1333623446, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3426) },
                    { 739085382, 667613330, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3436), -735966076, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3437) },
                    { 965471659, 667613330, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3414), -1297074406, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3415) },
                    { 980745327, 667613330, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3381), -427171481, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3382) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458191167, 680572172, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1919), 370398475, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1920) },
                    { 639051752, 680572172, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1930), -1472309873, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1931) },
                    { 666267354, 680572172, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1951), -1283556487, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1952) },
                    { 739085382, 680572172, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1962), -1937506351, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1963) },
                    { 965471659, 680572172, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1940), 2085035819, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1941) },
                    { 980745327, 680572172, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1908), -83250508, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1909) },
                    { 458191167, 692066188, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2455), 1929356393, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2456) },
                    { 639051752, 692066188, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2466), -466371778, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2467) },
                    { 666267354, 692066188, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2488), 1321552130, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2489) },
                    { 739085382, 692066188, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2499), 1367091342, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2500) },
                    { 965471659, 692066188, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2477), -1676367139, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2478) },
                    { 980745327, 692066188, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2444), -1877677816, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2445) },
                    { 458191167, 719032839, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1387), -207106123, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1388) },
                    { 639051752, 719032839, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1398), -730953139, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1399) },
                    { 666267354, 719032839, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1420), -1301135192, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1421) },
                    { 739085382, 719032839, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1431), -1597231651, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1432) },
                    { 965471659, 719032839, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1409), -290979449, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1410) },
                    { 980745327, 719032839, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1376), 1703430509, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1377) },
                    { 458191167, 726125297, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(111), -945390914, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(112) },
                    { 639051752, 726125297, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(122), 257138632, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(123) },
                    { 666267354, 726125297, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(145), -1869686693, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(146) },
                    { 739085382, 726125297, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(157), 10967216, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(158) },
                    { 965471659, 726125297, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(133), -616665757, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(135) },
                    { 980745327, 726125297, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(100), -1336358002, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(101) },
                    { 458191167, 756421282, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2119), -328093766, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2121) },
                    { 639051752, 756421282, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2130), 1832520533, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2131) },
                    { 666267354, 756421282, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2152), 379492588, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2154) },
                    { 739085382, 756421282, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2163), 1824525581, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2165) },
                    { 965471659, 756421282, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2141), -2028261739, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2142) },
                    { 980745327, 756421282, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2109), 1803965211, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2110) },
                    { 458191167, 758506662, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9507), -818698274, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9508) },
                    { 639051752, 758506662, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9518), 1228178687, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9519) },
                    { 666267354, 758506662, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9541), -1361535902, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9542) },
                    { 739085382, 758506662, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9552), -136116314, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9553) },
                    { 965471659, 758506662, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9530), 1654440341, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9531) },
                    { 980745327, 758506662, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9495), -1353928193, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9496) },
                    { 458191167, 775714006, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1322), 1127839824, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1323) },
                    { 639051752, 775714006, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1332), 1261420970, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1333) },
                    { 666267354, 775714006, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1354), -329952262, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1355) },
                    { 739085382, 775714006, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1365), 25477655, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1366) },
                    { 965471659, 775714006, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1343), 2014785288, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1344) },
                    { 980745327, 775714006, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1308), -1290222103, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1309) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458191167, 797234079, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1119), -734148125, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1120) },
                    { 639051752, 797234079, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1129), -1230842213, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1130) },
                    { 666267354, 797234079, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1151), 1697062406, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1153) },
                    { 739085382, 797234079, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1162), 310833356, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1164) },
                    { 965471659, 797234079, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1141), 1759147119, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1142) },
                    { 980745327, 797234079, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1108), -187012763, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1109) },
                    { 458191167, 811117421, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(43), -984069224, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(44) },
                    { 639051752, 811117421, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(54), -2043283013, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(55) },
                    { 666267354, 811117421, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(79), -715096250, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(80) },
                    { 739085382, 811117421, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(89), -1760630404, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(90) },
                    { 965471659, 811117421, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(68), -1021618156, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(69) },
                    { 980745327, 811117421, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(32), 1061506544, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(33) },
                    { 458191167, 819084108, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(915), 16171061, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(916) },
                    { 639051752, 819084108, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(926), -1912031522, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(927) },
                    { 666267354, 819084108, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(948), 814928306, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(949) },
                    { 739085382, 819084108, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(959), 1264220019, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(960) },
                    { 965471659, 819084108, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(937), -1934796113, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(938) },
                    { 980745327, 819084108, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(904), 1572673914, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(905) },
                    { 458191167, 820907510, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2323), 1296204647, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2324) },
                    { 639051752, 820907510, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2334), 1593896405, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2335) },
                    { 666267354, 820907510, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2356), 1760204822, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2357) },
                    { 739085382, 820907510, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2367), -2008769462, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2368) },
                    { 965471659, 820907510, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2345), 1802339321, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2346) },
                    { 980745327, 820907510, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2312), -2059091324, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2313) },
                    { 458191167, 825047400, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2185), -1622885624, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2187) },
                    { 639051752, 825047400, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2196), -1435816030, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2197) },
                    { 666267354, 825047400, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2218), -812761244, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2219) },
                    { 739085382, 825047400, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2229), 1901034014, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2230) },
                    { 965471659, 825047400, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2207), 1684709604, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2208) },
                    { 980745327, 825047400, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2175), -148530320, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2176) },
                    { 458191167, 849019605, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1852), -1861100833, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1853) },
                    { 639051752, 849019605, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1863), 30280303, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1865) },
                    { 666267354, 849019605, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1885), -1212257204, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1886) },
                    { 739085382, 849019605, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1896), -52960639, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1897) },
                    { 965471659, 849019605, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1874), -843319637, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1875) },
                    { 980745327, 849019605, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1841), -1800684818, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1843) },
                    { 458191167, 864665087, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1721), -1763902727, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1722) },
                    { 639051752, 864665087, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1732), -1147546673, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1733) },
                    { 666267354, 864665087, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1754), 73700740, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1755) },
                    { 739085382, 864665087, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1765), -722882227, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1766) },
                    { 965471659, 864665087, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1743), -547883297, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1744) },
                    { 980745327, 864665087, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1710), -1803599644, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1711) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458191167, 874908594, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9777), -743180620, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9778) },
                    { 639051752, 874908594, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9790), -559453207, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9791) },
                    { 666267354, 874908594, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9813), -793738637, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9814) },
                    { 739085382, 874908594, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9824), -475930754, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9825) },
                    { 965471659, 874908594, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9802), -894592322, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9803) },
                    { 980745327, 874908594, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9766), -1275912445, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9767) },
                    { 458191167, 883767964, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1787), -1634040481, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1788) },
                    { 639051752, 883767964, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1798), -382999886, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1799) },
                    { 666267354, 883767964, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1820), 2092227444, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1821) },
                    { 739085382, 883767964, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1830), -272351339, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1831) },
                    { 965471659, 883767964, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1809), -1409295199, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1810) },
                    { 980745327, 883767964, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1776), -1605961061, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1777) },
                    { 458191167, 885246041, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(446), 1121558288, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(447) },
                    { 639051752, 885246041, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(457), 1633461417, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(458) },
                    { 666267354, 885246041, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(479), -1387802177, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(480) },
                    { 739085382, 885246041, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(490), -499056781, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(491) },
                    { 965471659, 885246041, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(468), -362714453, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(469) },
                    { 980745327, 885246041, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(435), 154002722, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(436) },
                    { 458191167, 897016436, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1052), 793574825, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1053) },
                    { 639051752, 897016436, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1063), 446860904, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1064) },
                    { 666267354, 897016436, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1086), 2080865421, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1087) },
                    { 739085382, 897016436, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1096), -876538975, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1098) },
                    { 965471659, 897016436, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1074), -1047211883, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1075) },
                    { 980745327, 897016436, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1041), -2001318637, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1042) },
                    { 458191167, 922749820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(780), 1629035024, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(782) },
                    { 639051752, 922749820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(791), 1817424396, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(792) },
                    { 666267354, 922749820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(814), -1452113095, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(815) },
                    { 739085382, 922749820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(825), 1895590638, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(826) },
                    { 965471659, 922749820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(803), -1003743035, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(804) },
                    { 980745327, 922749820, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(770), -1033775698, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(771) },
                    { 458191167, 951073262, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2991), 1282520385, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2992) },
                    { 639051752, 951073262, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3002), 606976493, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3003) },
                    { 666267354, 951073262, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3024), -1825520660, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3025) },
                    { 739085382, 951073262, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3035), -539118868, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3036) },
                    { 965471659, 951073262, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3013), 279966196, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3014) },
                    { 980745327, 951073262, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2979), 1967138492, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(2980) },
                    { 458191167, 958178792, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1185), 620625155, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1186) },
                    { 639051752, 958178792, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1195), -245438792, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1196) },
                    { 666267354, 958178792, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1217), -1742642873, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1218) },
                    { 739085382, 958178792, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1228), -542433172, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1229) },
                    { 965471659, 958178792, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1206), 1607946503, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1207) },
                    { 980745327, 958178792, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1174), 882299210, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1175) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 458191167, 960173928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9574), 889025558, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9575) },
                    { 639051752, 960173928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9586), 2073205166, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9587) },
                    { 666267354, 960173928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9608), -2044101257, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9609) },
                    { 739085382, 960173928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9620), 27222436, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9621) },
                    { 965471659, 960173928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9597), 548992184, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9598) },
                    { 980745327, 960173928, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9563), 948267194, new DateTime(2024, 3, 11, 16, 32, 51, 749, DateTimeKind.Local).AddTicks(9565) },
                    { 458191167, 967568779, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(380), -185198233, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(381) },
                    { 639051752, 967568779, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(391), 1888653204, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(392) },
                    { 666267354, 967568779, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(413), -1572478802, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(414) },
                    { 739085382, 967568779, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(424), -129735823, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(425) },
                    { 965471659, 967568779, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(402), -1900428011, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(403) },
                    { 980745327, 967568779, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(369), -712571386, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(370) },
                    { 458191167, 974641431, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1453), -676516117, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1455) },
                    { 639051752, 974641431, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1464), -1389860320, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1466) },
                    { 666267354, 974641431, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1486), 641956865, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1487) },
                    { 739085382, 974641431, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1498), -1272586873, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1499) },
                    { 965471659, 974641431, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1475), 79304279, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1476) },
                    { 980745327, 974641431, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1442), -1645742146, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(1443) },
                    { 458191167, 982562684, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3124), -2070538933, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3125) },
                    { 639051752, 982562684, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3135), 771823526, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3136) },
                    { 666267354, 982562684, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3157), 576509774, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3158) },
                    { 739085382, 982562684, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3168), 422214269, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3169) },
                    { 965471659, 982562684, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3146), 345825464, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3147) },
                    { 980745327, 982562684, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3113), 1743252165, new DateTime(2024, 3, 11, 16, 32, 51, 750, DateTimeKind.Local).AddTicks(3114) }
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
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

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
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "TimeSpans");

            migrationBuilder.DropTable(
                name: "Drawings");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Permission");

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
