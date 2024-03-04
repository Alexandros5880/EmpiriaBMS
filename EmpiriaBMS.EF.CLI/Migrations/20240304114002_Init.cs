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
                    { 168417562, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(358), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(359), "Elevators" },
                    { 205104109, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(392), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(394), "Power Distribution" },
                    { 322477818, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(465), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(467), "BMS" },
                    { 350681200, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(232), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(234), "HVAC" },
                    { 467835241, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(281), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(283), "Potable Water" },
                    { 522624177, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(316), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(318), "Fire Detection" },
                    { 531155248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(430), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(432), "Burglar Alarm" },
                    { 669711220, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(534), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(536), "TenderDocument" },
                    { 754124512, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(448), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(449), "CCTV" },
                    { 774189489, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(517), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(518), "Outsource" },
                    { 793600306, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(299), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(301), "Drainage" },
                    { 830085862, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(262), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(264), "Sewage" },
                    { 832255239, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(413), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(414), "Structured Cabling" },
                    { 837669377, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(375), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(377), "Natural Gas" },
                    { 848732691, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(483), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(484), "Photovoltaics" },
                    { 943842264, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(340), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(341), "Fire Suppression" },
                    { 946016029, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(554), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(556), "Construction Supervision" },
                    { 990750521, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(500), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(501), "Energy Efficiency" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 124959595, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(875), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(877), "Drawings" },
                    { 306040847, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(857), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(859), "Calculations" },
                    { 923384606, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(831), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(833), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 243466567, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1688), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1689), "Administration" },
                    { 265212438, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1649), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1651), "On-Site" },
                    { 640144806, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1631), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1632), "Printing" },
                    { 707102844, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1667), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1669), "Meetings" },
                    { 843955479, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1602), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1604), "Communications" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 184789560, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7225), new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7226), "Dashboard Assign Project Manager", 5 },
                    { 307908095, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7159), new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7160), "Dashboard Edit My Hours", 2 },
                    { 494216242, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7287), new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7289), "Dashboard See My Hours", 8 },
                    { 667436301, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7268), new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7269), "See Admin Layout", 7 },
                    { 712864647, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(6981), new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(6982), "See Dashboard Layout", 1 },
                    { 831887348, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7248), new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7250), "Dashboard Add Project", 6 },
                    { 869624897, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7204), new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7206), "Dashboard Assign Engineer", 4 },
                    { 965979814, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7183), new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7184), "Dashboard Assign Designer", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 288732045, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9559), "Infrastructure Description", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9561), "Infrastructure" },
                    { 731570039, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9599), "Consulting Description", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9601), "Consulting" },
                    { 766699479, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9532), "Buildings Description", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9534), "Buildings" },
                    { 946107553, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9580), "Energy Description", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9581), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 177990423, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7460), false, false, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7462), "Customer" },
                    { 238118089, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7420), false, true, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7422), "CEO" },
                    { 273582824, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7480), false, false, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7482), "Admin" },
                    { 420424258, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7399), false, true, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7401), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 570169332, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7308), false, true, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7310), "Designer" },
                    { 595916608, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7440), false, false, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7442), "Guest" },
                    { 863576944, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7339), false, true, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7341), "Engineer" },
                    { 928478267, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7359), false, true, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7361), "Project Manager" },
                    { 967605979, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7379), false, true, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7381), "COO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 167604600, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8708), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8710), null, "694927778", null, null, null },
                    { 191615321, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8625), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8626), null, "694927778", null, null, null },
                    { 240148257, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8924), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8925), null, "6949277782", null, null, null },
                    { 300656172, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8668), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8670), null, "694927778", null, null, null },
                    { 354436692, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9773), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9774), null, "6949277784", null, null, null },
                    { 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9190), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9193), null, "6949277781", null, null, null },
                    { 385921122, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9733), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9735), null, "6949277783", null, null, null },
                    { 450543165, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8566), "Admin", "admin@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8567), null, "694927778", null, null, null },
                    { 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9415), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9417), null, "6949277784", null, null, null },
                    { 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9480), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9482), null, "6949277785", null, null, null },
                    { 596160704, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8962), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8964), null, "6949277783", null, null, null },
                    { 627332064, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9050), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9052), null, "6949277785", null, null, null },
                    { 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9091), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9093), null, "6949277780", null, null, null },
                    { 700533594, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8748), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8750), null, "694927778", null, null, null },
                    { 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9326), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9329), null, "6949277783", null, null, null },
                    { 770284718, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9008), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9010), null, "6949277784", null, null, null },
                    { 809046581, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8793), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8795), null, "6949277780", null, null, null },
                    { 821865082, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8882), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8884), null, "6949277781", null, null, null },
                    { 837036394, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9644), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9645), null, "6949277781", null, null, null },
                    { 943944200, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9693), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9694), null, "6949277782", null, null, null },
                    { 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9256), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9259), null, "6949277782", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 347575469, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 8.0, 9, new DateTime(2024, 12, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 9, "Test Description Project_6", "KL-3", new DateTime(2024, 12, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), new DateTime(2024, 12, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 0f, 100L, 12L, new DateTime(2024, 3, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), "Project_3", 5.0, new DateTime(2024, 12, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), "Payment Detailes For Project_3", 3.0, null, 946107553, new DateTime(2024, 12, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 0f },
                    { 376152349, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 7.0, 4, new DateTime(2024, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 4, "Test Description Project_10", "KL-2", new DateTime(2024, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), new DateTime(2024, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 0f, 100L, 12L, new DateTime(2024, 3, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), "Project_2", 5.0, new DateTime(2024, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), "Payment Detailes For Project_6", 2.0, null, 288732045, new DateTime(2024, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 0f },
                    { 533341512, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 6.0, 1, new DateTime(2024, 4, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 1, "Test Description Project_2", "KL-1", new DateTime(2024, 4, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), new DateTime(2024, 4, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 0f, 100L, 12L, new DateTime(2024, 3, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), "Project_1", 5.0, new DateTime(2024, 4, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), "Payment Detailes For Project_5", 1.0, null, 766699479, new DateTime(2024, 4, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 0f },
                    { 791630678, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 9.0, 16, new DateTime(2025, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 16, "Test Description Project_20", "KL-4", new DateTime(2025, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), new DateTime(2025, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 0f, 100L, 12L, new DateTime(2024, 3, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), "Project_4", 5.0, new DateTime(2025, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), "Payment Detailes For Project_8", 4.0, null, 731570039, new DateTime(2025, 7, 4, 13, 40, 1, 567, DateTimeKind.Local).AddTicks(2153), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 712864647, 177990423, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8512), 109946890, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8513) },
                    { 184789560, 238118089, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8434), -1128373289, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8436) },
                    { 307908095, 238118089, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8358), -1803720649, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8361) },
                    { 667436301, 238118089, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8472), -2144086172, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8474) },
                    { 712864647, 238118089, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8325), 807877868, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8327) },
                    { 831887348, 238118089, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8453), -910973137, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8455) },
                    { 869624897, 238118089, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8415), -78827318, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8417) },
                    { 965979814, 238118089, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8391), -577993625, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8393) },
                    { 667436301, 273582824, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8537), 1763960603, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8539) },
                    { 184789560, 420424258, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8222), 1104414449, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8225) },
                    { 307908095, 420424258, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8132), -18404243, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8135) },
                    { 494216242, 420424258, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8290), 1790285954, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8293) },
                    { 712864647, 420424258, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7898), 31975687, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8034) },
                    { 831887348, 420424258, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8253), 82515596, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8256) },
                    { 869624897, 420424258, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8194), 1957382262, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8196) },
                    { 965979814, 420424258, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8163), 1812002418, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8165) },
                    { 307908095, 570169332, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7551), -13997965, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7553) },
                    { 494216242, 570169332, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7572), 44284645, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7573) },
                    { 712864647, 570169332, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7519), 1298075472, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7521) },
                    { 712864647, 595916608, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8492), -1466736434, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8494) },
                    { 307908095, 863576944, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7611), 1703790063, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7612) },
                    { 494216242, 863576944, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7651), -1366086901, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7653) },
                    { 712864647, 863576944, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7591), 981567842, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7592) },
                    { 965979814, 863576944, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7631), -922714330, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7633) },
                    { 307908095, 928478267, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7695), 826136735, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7697) },
                    { 494216242, 928478267, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7736), -1992340079, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7737) },
                    { 712864647, 928478267, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7676), -124730851, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7677) },
                    { 869624897, 928478267, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7716), -1843333613, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7718) },
                    { 184789560, 967605979, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7832), 293941796, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7834) },
                    { 307908095, 967605979, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7774), -241055689, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7776) },
                    { 494216242, 967605979, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7862), -1686609278, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7865) },
                    { 712864647, 967605979, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7755), -400020083, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7757) },
                    { 869624897, 967605979, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7813), -284471329, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7814) },
                    { 965979814, 967605979, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7793), 1583697155, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(7795) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 967605979, 167604600, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8729), 417063134, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8730) },
                    { 238118089, 191615321, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8647), 882094571, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8648) },
                    { 570169332, 240148257, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8945), 655668204, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8946) },
                    { 420424258, 300656172, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8688), 253054661, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8690) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 928478267, 354436692, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9794), 553282730, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9796) },
                    { 863576944, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9227), 677173938, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9229) },
                    { 928478267, 385921122, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9754), 960257441, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9756) },
                    { 273582824, 450543165, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8598), 651128312, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8600) },
                    { 863576944, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9459), 403843488, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9461) },
                    { 863576944, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9510), 498356195, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9512) },
                    { 570169332, 596160704, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8984), 203043788, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8986) },
                    { 570169332, 627332064, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9072), 241885770, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9073) },
                    { 863576944, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9155), 193911702, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9158) },
                    { 595916608, 700533594, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8770), 961685986, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8771) },
                    { 863576944, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9381), 892632122, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9384) },
                    { 570169332, 770284718, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9031), 735545483, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9033) },
                    { 570169332, 809046581, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8862), 279032140, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8864) },
                    { 570169332, 821865082, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8906), 336376114, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(8908) },
                    { 928478267, 837036394, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9672), 513690742, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9674) },
                    { 928478267, 943944200, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9714), 877718253, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9716) },
                    { 863576944, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9294), 690409049, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9296) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2050984560, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(693), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(695), 376152349, 350681200, null },
                    { -1842643448, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(673), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(675), 376152349, 774189489, null },
                    { -1534915032, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(653), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(655), 376152349, 793600306, null },
                    { -1385150472, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(634), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(636), 533341512, 322477818, null },
                    { -962582152, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(615), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(616), 533341512, 793600306, null },
                    { -902712168, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(581), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(583), 533341512, 774189489, null },
                    { -774320056, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(731), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(733), 347575469, 832255239, null },
                    { -120295736, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(713), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(714), 347575469, 522624177, null },
                    { -106512248, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(773), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(775), 791630678, 832255239, null },
                    { -102508904, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(792), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(793), 791630678, 531155248, null },
                    { 956403672, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(749), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(751), 347575469, 774189489, null },
                    { 1812714288, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(810), 0f, 1500L, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(812), 791630678, 467835241, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 222132787, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(29), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(33), 3100.0, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(31), "Signature 142344", 58185, 376152349, 2.0, 24.0 },
                    { 313455855, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(205), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(208), 13000.0, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(207), "Signature 1423424", 58989, 791630678, 4.0, 24.0 },
                    { 325356543, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9925), new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9928), 3010.0, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9926), "Signature 142343", 60072, 533341512, 1.0, 17.0 },
                    { 493135189, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(119), new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(122), 4000.0, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(120), "Signature 142349", 76185, 347575469, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 791630678, 354436692, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2861), 471693424, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2862) },
                    { 347575469, 385921122, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2843), 359543279, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2845) },
                    { 533341512, 837036394, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2798), 304659255, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2800) },
                    { 376152349, 943944200, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2825), 618012573, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2826) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 355345345, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(167), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(168), null, "6949277784", null, null, 791630678 },
                    { 386729976, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9990), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9992), null, "6949277782", null, null, 376152349 },
                    { 416088615, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9876), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9878), null, "6949277781", null, null, 533341512 },
                    { 609538956, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(79), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(81), null, "6949277783", null, null, 347575469 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2050984560, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3464), 560912357, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3465) },
                    { -2050984560, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3518), 510009012, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3520) },
                    { -2050984560, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3536), 885553752, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3537) },
                    { -2050984560, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3446), 785544878, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3448) },
                    { -2050984560, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3501), 497883417, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3502) },
                    { -2050984560, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3481), 791473025, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3483) },
                    { -1842643448, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3357), 575449811, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3359) },
                    { -1842643448, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3410), 331173754, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3412) },
                    { -1842643448, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3428), 765469853, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3430) },
                    { -1842643448, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3339), 383687530, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3341) },
                    { -1842643448, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3393), 948661495, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3394) },
                    { -1842643448, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3375), 223682712, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3376) },
                    { -1534915032, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3251), 684641703, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3253) },
                    { -1534915032, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3304), 291131052, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3305) },
                    { -1534915032, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3321), 143709434, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3323) },
                    { -1534915032, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3233), 517957540, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3235) },
                    { -1534915032, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3286), 513992236, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3288) },
                    { -1534915032, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3269), 976830435, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3270) },
                    { -1385150472, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3138), 157309803, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3140) },
                    { -1385150472, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3192), 177468290, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3193) },
                    { -1385150472, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3215), 835577262, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3216) },
                    { -1385150472, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3120), 386513319, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3122) },
                    { -1385150472, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3174), 158932303, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3175) },
                    { -1385150472, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3156), 281792361, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3158) },
                    { -962582152, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3024), 222625666, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3025) },
                    { -962582152, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3080), 198785187, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3081) },
                    { -962582152, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3097), 538303143, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3099) },
                    { -962582152, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3006), 946025800, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3007) },
                    { -962582152, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3062), 356445557, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3063) },
                    { -962582152, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3042), 765650649, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3043) },
                    { -902712168, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2913), 135757304, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2915) },
                    { -902712168, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2968), 537865278, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2969) },
                    { -902712168, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2987), 865131970, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2988) },
                    { -902712168, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2883), 655571012, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2885) },
                    { -902712168, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2950), 935131914, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2951) },
                    { -902712168, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2931), 221018179, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2933) },
                    { -774320056, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3681), 540076181, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3683) },
                    { -774320056, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3734), 810431783, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3735) },
                    { -774320056, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3751), 826864255, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3753) },
                    { -774320056, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3663), 219857271, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3665) },
                    { -774320056, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3716), 654376747, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3717) },
                    { -774320056, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3698), 607492612, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3700) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -120295736, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3571), 933042092, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3572) },
                    { -120295736, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3628), 301441841, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3629) },
                    { -120295736, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3645), 246922755, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3647) },
                    { -120295736, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3553), 813150558, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3555) },
                    { -120295736, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3610), 850255289, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3611) },
                    { -120295736, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3588), 487110773, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3590) },
                    { -106512248, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3892), 742462683, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3893) },
                    { -106512248, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3945), 878924801, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3947) },
                    { -106512248, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3963), 624789560, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3964) },
                    { -106512248, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3874), 430472719, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3876) },
                    { -106512248, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3927), 422854973, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3929) },
                    { -106512248, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3909), 896806723, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3911) },
                    { -102508904, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3999), 323160764, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4001) },
                    { -102508904, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4052), 185802763, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4054) },
                    { -102508904, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4072), 230601171, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4073) },
                    { -102508904, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3982), 407562892, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3983) },
                    { -102508904, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4034), 185808966, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4036) },
                    { -102508904, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4017), 713046482, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4018) },
                    { 956403672, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3786), 343629764, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3788) },
                    { 956403672, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3839), 765585992, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3840) },
                    { 956403672, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3856), 232020215, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3858) },
                    { 956403672, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3769), 836934772, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3771) },
                    { 956403672, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3822), 502111182, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3823) },
                    { 956403672, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3804), 537409905, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(3806) },
                    { 1812714288, 382191069, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4112), 777981380, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4114) },
                    { 1812714288, 474232646, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4164), 965719882, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4166) },
                    { 1812714288, 580537184, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4182), 148230524, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4183) },
                    { 1812714288, 653968742, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4094), 680922546, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4096) },
                    { 1812714288, 736429270, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4147), 924961193, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4148) },
                    { 1812714288, 966986337, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4130), 855255212, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4131) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 131466959, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1448), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1445), -106512248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1446), 306040847 },
                    { 149006056, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1336), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1333), -774320056, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1335), 306040847 },
                    { 158825515, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1374), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1370), 956403672, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1372), 923384606 },
                    { 178192751, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1545), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1541), 1812714288, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1543), 923384606 },
                    { 191935063, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1317), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1313), -774320056, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1316), 923384606 },
                    { 219478773, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1392), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1389), 956403672, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1390), 306040847 },
                    { 220012979, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1029), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1026), -1385150472, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1027), 923384606 },
                    { 224109697, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1486), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1483), -102508904, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1484), 923384606 },
                    { 231201426, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1355), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1351), -774320056, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1353), 124959595 },
                    { 231686404, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1583), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1579), 1812714288, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1581), 124959595 },
                    { 244307719, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1504), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1501), -102508904, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1502), 306040847 },
                    { 285586309, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1088), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1085), -1534915032, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1086), 923384606 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 337590069, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1126), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1122), -1534915032, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1124), 124959595 },
                    { 371576541, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1107), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1103), -1534915032, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1105), 306040847 },
                    { 380843873, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1429), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1426), -106512248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1427), 923384606 },
                    { 479580035, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1181), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1178), -1842643448, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1179), 124959595 },
                    { 498143365, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(968), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(965), -962582152, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(966), 923384606 },
                    { 521033667, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(949), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(945), -902712168, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(947), 124959595 },
                    { 524237664, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1163), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1159), -1842643448, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1161), 306040847 },
                    { 564080583, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1242), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1239), -2050984560, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1241), 124959595 },
                    { 569280731, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(900), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(895), -902712168, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(896), 923384606 },
                    { 569653130, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1298), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1295), -120295736, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1296), 124959595 },
                    { 630106273, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1467), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1464), -106512248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1465), 124959595 },
                    { 633196069, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1280), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1276), -120295736, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1278), 306040847 },
                    { 684647631, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(929), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(925), -902712168, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(927), 306040847 },
                    { 748647228, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(988), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(984), -962582152, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(986), 306040847 },
                    { 769787779, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1218), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1215), -2050984560, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1216), 306040847 },
                    { 786415489, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1009), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1005), -962582152, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1007), 124959595 },
                    { 833119094, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1410), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1407), 956403672, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1409), 124959595 },
                    { 835512906, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1048), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1045), -1385150472, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1046), 306040847 },
                    { 848047541, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1066), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1063), -1385150472, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1064), 124959595 },
                    { 863096496, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1261), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1258), -120295736, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1259), 923384606 },
                    { 922184797, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1200), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1197), -2050984560, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1198), 923384606 },
                    { 935488250, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1144), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1141), -1842643448, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1143), 923384606 },
                    { 977862723, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1522), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1519), -102508904, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1521), 124959595 },
                    { 994072766, new DateTime(2024, 3, 15, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1563), 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1560), 1812714288, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1562), 306040847 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 126930188, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1791), -902712168, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1793), 243466567 },
                    { 144087132, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1755), -902712168, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1757), 265212438 },
                    { 146045986, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2638), -102508904, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2640), 640144806 },
                    { 157712701, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2370), -774320056, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2372), 640144806 },
                    { 191811493, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2318), -120295736, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2319), 707102844 },
                    { 206170719, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2101), -1842643448, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2102), 640144806 },
                    { 224098608, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1956), -1385150472, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1958), 707102844 },
                    { 237144559, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1812), -962582152, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1813), 843955479 },
                    { 238230059, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2118), -1842643448, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2120), 265212438 },
                    { 256589689, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2263), -120295736, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2264), 843955479 },
                    { 262224635, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2030), -1534915032, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2031), 265212438 },
                    { 263873582, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2388), -774320056, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2389), 265212438 },
                    { 265306253, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1921), -1385150472, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1923), 640144806 },
                    { 266122330, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1904), -1385150472, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1905), 843955479 },
                    { 267621324, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2423), -774320056, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2424), 243466567 },
                    { 272237714, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1973), -1385150472, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1975), 243466567 },
                    { 311690557, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1848), -962582152, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1849), 265212438 },
                    { 313179603, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2510), 956403672, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2512), 243466567 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 333403206, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2083), -1842643448, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2085), 843955479 },
                    { 333934705, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2335), -120295736, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2337), 243466567 },
                    { 374714119, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1710), -902712168, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1712), 843955479 },
                    { 384344839, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2353), -774320056, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2354), 843955479 },
                    { 410365896, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2140), -1842643448, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2141), 707102844 },
                    { 427965017, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2176), -2050984560, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2177), 843955479 },
                    { 430718136, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2691), -102508904, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2692), 243466567 },
                    { 448153051, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2528), -106512248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2529), 843955479 },
                    { 471539245, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2009), -1534915032, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2011), 640144806 },
                    { 471627441, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2585), -106512248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2587), 707102844 },
                    { 474882571, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2761), 1812714288, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2763), 707102844 },
                    { 492765394, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2656), -102508904, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2657), 265212438 },
                    { 498062624, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2280), -120295736, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2281), 640144806 },
                    { 581008992, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2065), -1534915032, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2067), 243466567 },
                    { 607013618, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1774), -902712168, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1775), 707102844 },
                    { 607463602, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1866), -962582152, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1867), 707102844 },
                    { 607763949, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2193), -2050984560, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2195), 640144806 },
                    { 608032764, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1991), -1534915032, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1993), 843955479 },
                    { 661624924, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2475), 956403672, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2476), 265212438 },
                    { 685796958, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2545), -106512248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2547), 640144806 },
                    { 697278108, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2245), -2050984560, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2247), 243466567 },
                    { 710902927, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2047), -1534915032, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2049), 707102844 },
                    { 714166585, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2405), -774320056, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2407), 707102844 },
                    { 726015291, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2492), 956403672, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2494), 707102844 },
                    { 749232087, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1939), -1385150472, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1940), 265212438 },
                    { 751956724, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2210), -2050984560, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2212), 265212438 },
                    { 814122989, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1736), -902712168, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1738), 640144806 },
                    { 840095494, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2621), -102508904, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2623), 843955479 },
                    { 840696413, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2567), -106512248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2569), 265212438 },
                    { 842714273, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2743), 1812714288, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2745), 265212438 },
                    { 854528778, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1886), -962582152, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1887), 243466567 },
                    { 857068629, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2297), -120295736, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2299), 265212438 },
                    { 863878412, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1830), -962582152, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(1832), 640144806 },
                    { 867732715, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2440), 956403672, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2442), 843955479 },
                    { 874420206, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2726), 1812714288, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2728), 640144806 },
                    { 880825325, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2778), 1812714288, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2780), 243466567 },
                    { 881623228, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2458), 956403672, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2459), 640144806 },
                    { 919069911, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2709), 1812714288, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2710), 843955479 },
                    { 942863321, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2158), -1842643448, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2159), 243466567 },
                    { 954704831, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2673), -102508904, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2675), 707102844 },
                    { 963458838, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2603), -106512248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2605), 243466567 },
                    { 989233423, 0f, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2228), -2050984560, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(2229), 707102844 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 177990423, 355345345, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(188), 461430547, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(190) },
                    { 177990423, 386729976, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(12), 683849963, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(13) },
                    { 177990423, 416088615, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9903), 651414795, new DateTime(2024, 3, 4, 13, 40, 1, 581, DateTimeKind.Local).AddTicks(9904) },
                    { 177990423, 609538956, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(101), 403226500, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(102) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 240148257, 126930188, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4662), 1830702110, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4664) },
                    { 596160704, 126930188, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4679), 1897880229, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4681) },
                    { 627332064, 126930188, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4713), 2064703005, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4715) },
                    { 770284718, 126930188, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4696), -812655688, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4698) },
                    { 809046581, 126930188, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4628), -1908352264, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4630) },
                    { 821865082, 126930188, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4645), -9685070, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4647) },
                    { 240148257, 144087132, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4455), 1421712329, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4457) },
                    { 596160704, 144087132, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4472), 107104348, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4473) },
                    { 627332064, 144087132, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4507), -179318380, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4508) },
                    { 770284718, 144087132, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4489), -955562629, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4490) },
                    { 809046581, 144087132, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4422), -1859247715, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4424) },
                    { 821865082, 144087132, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4438), 274045685, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4440) },
                    { 240148257, 146045986, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9433), -898014149, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9435) },
                    { 596160704, 146045986, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9450), -807822283, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9452) },
                    { 627332064, 146045986, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9484), -121535567, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9486) },
                    { 770284718, 146045986, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9468), -181073375, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9469) },
                    { 809046581, 146045986, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9400), 878177930, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9402) },
                    { 821865082, 146045986, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9417), 1716237788, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9418) },
                    { 240148257, 157712701, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7907), -870425554, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7909) },
                    { 596160704, 157712701, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7925), -2080444900, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7926) },
                    { 627332064, 157712701, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7957), 1849215951, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7959) },
                    { 770284718, 157712701, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7941), -525274721, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7943) },
                    { 809046581, 157712701, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7874), -1553683139, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7875) },
                    { 821865082, 157712701, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7891), -1061475227, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7892) },
                    { 240148257, 191811493, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7605), 963220892, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7606) },
                    { 596160704, 191811493, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7621), -120796766, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7623) },
                    { 627332064, 191811493, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7655), 395931799, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7656) },
                    { 770284718, 191811493, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7637), 931035605, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7639) },
                    { 809046581, 191811493, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7571), -144278680, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7573) },
                    { 821865082, 191811493, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7588), 1702725615, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7590) },
                    { 240148257, 206170719, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6386), 2083422326, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6388) },
                    { 596160704, 206170719, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6405), -1739150914, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6406) },
                    { 627332064, 206170719, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6438), 918446855, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6439) },
                    { 770284718, 206170719, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6421), -874383857, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6423) },
                    { 809046581, 206170719, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6352), 1198051479, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6353) },
                    { 821865082, 206170719, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6369), 1408910171, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6370) },
                    { 240148257, 224098608, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5578), 553461188, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5580) },
                    { 596160704, 224098608, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5595), 1235968659, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5597) },
                    { 627332064, 224098608, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5629), 1211994239, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5630) },
                    { 770284718, 224098608, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5612), -1150777313, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5614) },
                    { 809046581, 224098608, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5541), -73683904, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5542) },
                    { 821865082, 224098608, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5562), -2121261772, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5563) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 240148257, 237144559, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4763), 1970512056, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4765) },
                    { 596160704, 237144559, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4782), 2092749512, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4783) },
                    { 627332064, 237144559, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4815), 2106844025, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4817) },
                    { 770284718, 237144559, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4799), -894099095, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4800) },
                    { 809046581, 237144559, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4730), -1346603737, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4732) },
                    { 821865082, 237144559, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4746), -1658739262, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4748) },
                    { 240148257, 238230059, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6492), 960332162, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6494) },
                    { 596160704, 238230059, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6509), 1680275619, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6511) },
                    { 627332064, 238230059, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6543), 1297647720, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6544) },
                    { 770284718, 238230059, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6526), 2008084086, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6528) },
                    { 809046581, 238230059, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6455), -1368299164, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6456) },
                    { 821865082, 238230059, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6476), 1741871543, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6478) },
                    { 240148257, 256589689, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7300), -1496673265, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7302) },
                    { 596160704, 256589689, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7317), 2134973057, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7318) },
                    { 627332064, 256589689, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7350), 1764680391, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7352) },
                    { 770284718, 256589689, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7333), 1768281147, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7335) },
                    { 809046581, 256589689, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7267), 535342721, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7269) },
                    { 821865082, 256589689, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7284), -1083157604, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7285) },
                    { 240148257, 262224635, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5980), 1584379548, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5981) },
                    { 596160704, 262224635, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5996), -28497469, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5998) },
                    { 627332064, 262224635, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6030), -1777856962, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6031) },
                    { 770284718, 262224635, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6013), 892956713, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6015) },
                    { 809046581, 262224635, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5946), -1187119079, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5948) },
                    { 821865082, 262224635, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5963), -2045193934, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5965) },
                    { 240148257, 263873582, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8008), -912959477, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8009) },
                    { 596160704, 263873582, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8024), 407485400, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8026) },
                    { 627332064, 263873582, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8062), -857704495, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8064) },
                    { 770284718, 263873582, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8045), -836007884, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8046) },
                    { 809046581, 263873582, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7974), -483196468, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7976) },
                    { 821865082, 263873582, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7991), 241294042, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7992) },
                    { 240148257, 265306253, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5372), 1383278414, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5373) },
                    { 596160704, 265306253, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5389), -779086016, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5391) },
                    { 627332064, 265306253, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5423), -1716672023, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5424) },
                    { 770284718, 265306253, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5405), -1350902195, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5407) },
                    { 809046581, 265306253, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5339), -1272583421, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5341) },
                    { 821865082, 265306253, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5355), 1950350211, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5357) },
                    { 240148257, 266122330, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5270), -1987025251, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5271) },
                    { 596160704, 266122330, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5287), 1899394655, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5288) },
                    { 627332064, 266122330, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5322), -1326903434, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5324) },
                    { 770284718, 266122330, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5303), -905167385, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5305) },
                    { 809046581, 266122330, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5237), -75761594, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5238) },
                    { 821865082, 266122330, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5253), -849579502, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5255) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 240148257, 267621324, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8213), -1261888555, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8214) },
                    { 596160704, 267621324, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8229), 801024602, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8231) },
                    { 627332064, 267621324, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8263), -535250555, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8264) },
                    { 770284718, 267621324, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8246), 1929751385, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8248) },
                    { 809046581, 267621324, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8179), 179756375, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8181) },
                    { 821865082, 267621324, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8196), 538151144, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8198) },
                    { 240148257, 272237714, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5679), -758143223, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5680) },
                    { 596160704, 272237714, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5695), -1730367161, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5697) },
                    { 627332064, 272237714, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5729), 1613795274, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5730) },
                    { 770284718, 272237714, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5712), 38052329, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5714) },
                    { 809046581, 272237714, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5645), -19046947, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5647) },
                    { 821865082, 272237714, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5662), 274132067, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5664) },
                    { 240148257, 311690557, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4966), -1516117, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4967) },
                    { 596160704, 311690557, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4982), 1362761487, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4983) },
                    { 627332064, 311690557, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5015), -13701037, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5017) },
                    { 770284718, 311690557, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4998), 1416125597, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5000) },
                    { 809046581, 311690557, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4933), -1508001979, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4934) },
                    { 821865082, 311690557, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4949), 1443370298, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4951) },
                    { 240148257, 313179603, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8722), -1245708323, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8723) },
                    { 596160704, 313179603, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8738), -634868018, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8740) },
                    { 627332064, 313179603, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8771), 1351165932, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8773) },
                    { 770284718, 313179603, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8755), -131655194, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8756) },
                    { 809046581, 313179603, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8688), 232117376, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8690) },
                    { 821865082, 313179603, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8705), 1072049081, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8707) },
                    { 240148257, 333403206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6285), 1282079025, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6287) },
                    { 596160704, 333403206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6302), 1060712492, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6304) },
                    { 627332064, 333403206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6335), 1596072038, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6337) },
                    { 770284718, 333403206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6318), -1612159442, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6320) },
                    { 809046581, 333403206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6252), 1778136647, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6254) },
                    { 821865082, 333403206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6269), -562939208, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6270) },
                    { 240148257, 333934705, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7706), 845782628, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7708) },
                    { 596160704, 333934705, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7723), -2041878019, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7724) },
                    { 627332064, 333934705, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7756), -351516428, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7757) },
                    { 770284718, 333934705, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7739), 1001690888, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7741) },
                    { 809046581, 333934705, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7672), -104801642, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7673) },
                    { 821865082, 333934705, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7689), -594663065, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7690) },
                    { 240148257, 374714119, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4247), 2029319384, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4249) },
                    { 596160704, 374714119, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4264), -1157233135, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4266) },
                    { 627332064, 374714119, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4300), 1715789412, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4302) },
                    { 770284718, 374714119, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4282), -1746430766, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4284) },
                    { 809046581, 374714119, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4202), -440270414, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4204) },
                    { 821865082, 374714119, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4230), -488385688, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4232) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 240148257, 384344839, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7806), -1776638272, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7808) },
                    { 596160704, 384344839, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7823), -541839842, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7824) },
                    { 627332064, 384344839, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7856), -1161637982, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7858) },
                    { 770284718, 384344839, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7840), -637280567, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7841) },
                    { 809046581, 384344839, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7773), -1777662328, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7774) },
                    { 821865082, 384344839, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7790), -249447820, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7791) },
                    { 240148257, 410365896, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6594), 1441020434, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6595) },
                    { 596160704, 410365896, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6610), 159893222, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6612) },
                    { 627332064, 410365896, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6643), -1252343600, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6645) },
                    { 770284718, 410365896, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6627), 666745448, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6628) },
                    { 809046581, 410365896, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6560), -252828229, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6561) },
                    { 821865082, 410365896, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6577), -853953169, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6579) },
                    { 240148257, 427965017, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6794), -839260759, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6796) },
                    { 596160704, 427965017, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6811), 1875400025, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6812) },
                    { 627332064, 427965017, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6844), -655287052, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6845) },
                    { 770284718, 427965017, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6828), 1013038106, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6829) },
                    { 809046581, 427965017, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6761), -1452540568, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6763) },
                    { 821865082, 427965017, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6778), 2073283569, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6779) },
                    { 240148257, 430718136, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9735), 344339465, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9737) },
                    { 596160704, 430718136, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9752), 1323066555, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9753) },
                    { 627332064, 430718136, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9785), 282434617, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9787) },
                    { 770284718, 430718136, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9768), 1573261614, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9770) },
                    { 809046581, 430718136, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9702), 1345128219, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9703) },
                    { 821865082, 430718136, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9718), -1746105538, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9720) },
                    { 240148257, 448153051, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8825), -2065308304, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8827) },
                    { 596160704, 448153051, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8842), -1584407438, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8843) },
                    { 627332064, 448153051, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8875), -284876792, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8877) },
                    { 770284718, 448153051, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8859), -1555114261, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8860) },
                    { 809046581, 448153051, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8788), -2044196477, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8790) },
                    { 821865082, 448153051, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8805), -837459121, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8807) },
                    { 240148257, 471539245, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5879), -2128525672, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5881) },
                    { 596160704, 471539245, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5896), -1992079970, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5897) },
                    { 627332064, 471539245, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5930), -1706508139, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5931) },
                    { 770284718, 471539245, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5913), 18661618, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5915) },
                    { 809046581, 471539245, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5846), 218357515, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5847) },
                    { 821865082, 471539245, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5862), 1535185233, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5864) },
                    { 240148257, 471627441, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9127), -470173432, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9128) },
                    { 596160704, 471627441, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9144), 2115473648, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9146) },
                    { 627332064, 471627441, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9178), -1270252957, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9179) },
                    { 770284718, 471627441, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9161), -64659302, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9163) },
                    { 809046581, 471627441, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9093), -1399700024, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9095) },
                    { 821865082, 471627441, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9110), 2114179983, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9112) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 240148257, 474882571, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(141), 2144616372, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(142) },
                    { 596160704, 474882571, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(158), -1714003046, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(159) },
                    { 627332064, 474882571, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(191), 1753164869, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(193) },
                    { 770284718, 474882571, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(174), -914874880, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(176) },
                    { 809046581, 474882571, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(108), 626965007, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(109) },
                    { 821865082, 474882571, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(124), 1660644536, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(126) },
                    { 240148257, 492765394, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9534), -573103025, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9536) },
                    { 596160704, 492765394, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9551), -12577913, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9552) },
                    { 627332064, 492765394, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9584), -1897539925, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9585) },
                    { 770284718, 492765394, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9567), 1726006221, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9569) },
                    { 809046581, 492765394, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9501), -557947376, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9503) },
                    { 821865082, 492765394, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9518), 1665562361, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9519) },
                    { 240148257, 498062624, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7400), -291053911, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7402) },
                    { 596160704, 498062624, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7416), -1626612772, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7418) },
                    { 627332064, 498062624, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7450), -1300636808, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7452) },
                    { 770284718, 498062624, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7434), 791992625, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7436) },
                    { 809046581, 498062624, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7367), -2089911527, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7368) },
                    { 821865082, 498062624, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7383), 214759625, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7385) },
                    { 240148257, 581008992, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6186), 1023438254, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6187) },
                    { 596160704, 581008992, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6202), 16172195, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6204) },
                    { 627332064, 581008992, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6235), -1245701186, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6236) },
                    { 770284718, 581008992, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6219), 505723829, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6220) },
                    { 809046581, 581008992, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6153), 2025488903, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6154) },
                    { 821865082, 581008992, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6170), 2004994832, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6171) },
                    { 240148257, 607013618, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4558), 1415817711, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4559) },
                    { 596160704, 607013618, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4574), 1525124682, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4576) },
                    { 627332064, 607013618, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4610), 859774055, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4612) },
                    { 770284718, 607013618, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4590), 763181681, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4592) },
                    { 809046581, 607013618, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4524), -1967329547, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4526) },
                    { 821865082, 607013618, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4541), -1597162769, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4543) },
                    { 240148257, 607463602, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5066), -1145579233, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5067) },
                    { 596160704, 607463602, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5082), -2072108573, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5084) },
                    { 627332064, 607463602, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5120), -282459964, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5122) },
                    { 770284718, 607463602, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5103), 43250167, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5105) },
                    { 809046581, 607463602, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5032), -1577454331, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5034) },
                    { 821865082, 607463602, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5049), 1461365996, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5051) },
                    { 240148257, 607763949, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6894), 25944440, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6896) },
                    { 596160704, 607763949, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6911), 1177690338, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6912) },
                    { 627332064, 607763949, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6944), 1634431055, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6945) },
                    { 770284718, 607763949, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6927), 720869036, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6929) },
                    { 809046581, 607763949, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6861), -1771285783, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6863) },
                    { 821865082, 607763949, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6878), 339180859, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6880) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 240148257, 608032764, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5779), 578228414, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5781) },
                    { 596160704, 608032764, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5796), -575298832, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5797) },
                    { 627332064, 608032764, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5829), -1781782150, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5830) },
                    { 770284718, 608032764, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5812), 536725859, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5813) },
                    { 809046581, 608032764, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5746), 154595147, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5748) },
                    { 821865082, 608032764, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5763), 1698937781, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5764) },
                    { 240148257, 661624924, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8514), 489002423, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8516) },
                    { 596160704, 661624924, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8531), 1738402542, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8532) },
                    { 627332064, 661624924, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8571), 1773569070, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8573) },
                    { 770284718, 661624924, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8548), 2140780527, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8550) },
                    { 809046581, 661624924, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8481), 1856239290, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8482) },
                    { 821865082, 661624924, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8497), -675518066, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8499) },
                    { 240148257, 685796958, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8926), -612816182, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8927) },
                    { 596160704, 685796958, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8943), -2029252504, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8944) },
                    { 627332064, 685796958, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8976), 261923932, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8977) },
                    { 770284718, 685796958, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8959), -2128332536, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8961) },
                    { 809046581, 685796958, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8893), 910235903, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8894) },
                    { 821865082, 685796958, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8909), -1803352423, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8911) },
                    { 240148257, 697278108, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7200), 211849043, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7201) },
                    { 596160704, 697278108, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7217), 120527843, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7218) },
                    { 627332064, 697278108, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7250), -1382247575, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7252) },
                    { 770284718, 697278108, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7234), 1685459489, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7235) },
                    { 809046581, 697278108, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7167), -1526094872, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7168) },
                    { 821865082, 697278108, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7183), -1465327444, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7185) },
                    { 240148257, 710902927, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6086), -1502099239, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6087) },
                    { 596160704, 710902927, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6103), 1536999593, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6104) },
                    { 627332064, 710902927, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6136), 210568420, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6137) },
                    { 770284718, 710902927, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6119), -1818901511, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6121) },
                    { 809046581, 710902927, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6048), 1111959144, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6049) },
                    { 821865082, 710902927, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6065), 1663355732, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6067) },
                    { 240148257, 714166585, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8113), -2141247248, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8114) },
                    { 596160704, 714166585, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8129), -1804967801, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8130) },
                    { 627332064, 714166585, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8162), 1012261514, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8163) },
                    { 770284718, 714166585, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8146), 2145968631, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8147) },
                    { 809046581, 714166585, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8079), -1583799641, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8081) },
                    { 821865082, 714166585, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8096), -1681493368, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8098) },
                    { 240148257, 726015291, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8622), -2117054366, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8624) },
                    { 596160704, 726015291, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8639), -1083193145, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8640) },
                    { 627332064, 726015291, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8672), -1134530027, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8673) },
                    { 770284718, 726015291, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8655), -418441891, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8657) },
                    { 809046581, 726015291, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8589), 414973634, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8590) },
                    { 821865082, 726015291, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8606), 521957120, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8607) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 240148257, 749232087, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5473), -869542213, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5475) },
                    { 596160704, 749232087, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5490), 2070049775, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5492) },
                    { 627332064, 749232087, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5523), -1759223344, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5525) },
                    { 770284718, 749232087, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5507), -38616637, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5508) },
                    { 809046581, 749232087, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5440), 1128681149, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5442) },
                    { 821865082, 749232087, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5457), 1143340722, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5458) },
                    { 240148257, 751956724, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6999), -1688409764, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7001) },
                    { 596160704, 751956724, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7016), -1282702117, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7018) },
                    { 627332064, 751956724, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7050), -1358267885, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7051) },
                    { 770284718, 751956724, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7033), -1002360694, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7035) },
                    { 809046581, 751956724, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6961), -125590958, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6963) },
                    { 821865082, 751956724, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6978), 1988413169, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6980) },
                    { 240148257, 814122989, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4352), 303202306, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4354) },
                    { 596160704, 814122989, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4371), -1104832088, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4373) },
                    { 627332064, 814122989, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4405), 1970978594, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4407) },
                    { 770284718, 814122989, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4389), 676248170, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4390) },
                    { 809046581, 814122989, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4318), -266726699, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4320) },
                    { 821865082, 814122989, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4335), -387108526, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4337) },
                    { 240148257, 840095494, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9327), -864967243, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9329) },
                    { 596160704, 840095494, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9349), -1515192443, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9351) },
                    { 627332064, 840095494, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9383), 111495070, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9384) },
                    { 770284718, 840095494, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9366), -1727513252, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9367) },
                    { 809046581, 840095494, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9294), -1230979310, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9296) },
                    { 821865082, 840095494, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9311), -687611110, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9313) },
                    { 240148257, 840696413, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9027), 137720521, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9029) },
                    { 596160704, 840696413, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9044), 1264163675, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9045) },
                    { 627332064, 840696413, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9076), 2103310503, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9078) },
                    { 770284718, 840696413, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9060), 453015140, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9062) },
                    { 809046581, 840696413, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8993), -775347920, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8995) },
                    { 821865082, 840696413, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9011), 298208368, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9012) },
                    { 240148257, 842714273, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(41), 1778433377, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(43) },
                    { 596160704, 842714273, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(58), -1168276576, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(59) },
                    { 627332064, 842714273, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(91), 921361604, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(92) },
                    { 770284718, 842714273, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(74), -2127515458, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(76) },
                    { 809046581, 842714273, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(8), -509523407, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(9) },
                    { 821865082, 842714273, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(25), 1130591030, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(26) },
                    { 240148257, 854528778, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5170), 1616041508, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5172) },
                    { 596160704, 854528778, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5187), 1474781639, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5188) },
                    { 627332064, 854528778, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5220), 1525767705, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5221) },
                    { 770284718, 854528778, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5203), -862143020, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5205) },
                    { 809046581, 854528778, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5137), -791940037, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5138) },
                    { 821865082, 854528778, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5154), -2147229013, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(5155) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 240148257, 857068629, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7500), -1039031104, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7502) },
                    { 596160704, 857068629, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7521), -1245537629, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7522) },
                    { 627332064, 857068629, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7554), 271023476, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7556) },
                    { 770284718, 857068629, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7538), 1394920053, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7539) },
                    { 809046581, 857068629, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7467), -1188225733, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7469) },
                    { 821865082, 857068629, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7484), -1416410756, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7485) },
                    { 240148257, 863878412, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4866), 712872050, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4867) },
                    { 596160704, 863878412, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4882), -689230682, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4884) },
                    { 627332064, 863878412, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4916), -1394910724, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4917) },
                    { 770284718, 863878412, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4899), -1786084964, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4901) },
                    { 809046581, 863878412, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4832), -492269489, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4834) },
                    { 821865082, 863878412, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4849), 1486907109, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(4851) },
                    { 240148257, 867732715, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8313), -1563104677, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8315) },
                    { 596160704, 867732715, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8330), -1320683417, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8331) },
                    { 627332064, 867732715, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8363), -243602306, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8365) },
                    { 770284718, 867732715, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8347), 1186901604, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8348) },
                    { 809046581, 867732715, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8280), -581045336, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8282) },
                    { 821865082, 867732715, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8297), -2145241687, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8298) },
                    { 240148257, 874420206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9939), -1075444150, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9941) },
                    { 596160704, 874420206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9957), -1477058507, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9959) },
                    { 627332064, 874420206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9991), -1864390625, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9992) },
                    { 770284718, 874420206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9974), 130454641, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9975) },
                    { 809046581, 874420206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9906), -1056205561, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9908) },
                    { 821865082, 874420206, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9923), 2105253851, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9924) },
                    { 240148257, 880825325, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(243), 2129927639, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(244) },
                    { 596160704, 880825325, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(259), 880245572, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(261) },
                    { 627332064, 880825325, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(292), -101111323, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(294) },
                    { 770284718, 880825325, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(275), -330210773, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(277) },
                    { 809046581, 880825325, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(209), -1628917478, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(211) },
                    { 821865082, 880825325, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(226), 2071781748, new DateTime(2024, 3, 4, 13, 40, 1, 583, DateTimeKind.Local).AddTicks(227) },
                    { 240148257, 881623228, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8414), -1489375876, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8416) },
                    { 596160704, 881623228, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8431), 1140224972, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8432) },
                    { 627332064, 881623228, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8464), -2079896912, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8465) },
                    { 770284718, 881623228, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8447), -730444148, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8449) },
                    { 809046581, 881623228, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8380), -840668066, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8382) },
                    { 821865082, 881623228, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8397), 1157721273, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(8399) },
                    { 240148257, 919069911, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9835), 1159664472, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9837) },
                    { 596160704, 919069911, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9851), -1270442627, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9853) },
                    { 627332064, 919069911, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9889), -1778821348, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9891) },
                    { 770284718, 919069911, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9872), 936044510, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9874) },
                    { 809046581, 919069911, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9802), -1970530766, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9804) },
                    { 821865082, 919069911, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9819), 1327054752, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9820) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 240148257, 942863321, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6693), 1836168953, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6695) },
                    { 596160704, 942863321, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6710), 554266382, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6711) },
                    { 627332064, 942863321, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6743), -2067046627, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6745) },
                    { 770284718, 942863321, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6726), 1047316505, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6728) },
                    { 809046581, 942863321, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6660), 1484748612, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6662) },
                    { 821865082, 942863321, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6677), -111984043, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(6678) },
                    { 240148257, 954704831, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9635), -1408146592, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9636) },
                    { 596160704, 954704831, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9651), -1360015433, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9652) },
                    { 627332064, 954704831, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9685), -2002659983, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9686) },
                    { 770284718, 954704831, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9667), 1564402392, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9669) },
                    { 809046581, 954704831, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9601), 1811569185, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9603) },
                    { 821865082, 954704831, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9618), 262780543, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9620) },
                    { 240148257, 963458838, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9228), 886651781, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9229) },
                    { 596160704, 963458838, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9244), -798741476, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9246) },
                    { 627332064, 963458838, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9277), 221640355, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9279) },
                    { 770284718, 963458838, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9260), -545877040, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9262) },
                    { 809046581, 963458838, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9195), -1521815804, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9196) },
                    { 821865082, 963458838, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9211), -514961387, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(9213) },
                    { 240148257, 989233423, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7100), -1704071393, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7102) },
                    { 596160704, 989233423, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7117), 2136946478, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7118) },
                    { 627332064, 989233423, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7150), 1441683509, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7151) },
                    { 770284718, 989233423, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7133), -611159188, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7135) },
                    { 809046581, 989233423, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7067), 1779510663, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7069) },
                    { 821865082, 989233423, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7084), -1197564025, new DateTime(2024, 3, 4, 13, 40, 1, 582, DateTimeKind.Local).AddTicks(7085) }
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
