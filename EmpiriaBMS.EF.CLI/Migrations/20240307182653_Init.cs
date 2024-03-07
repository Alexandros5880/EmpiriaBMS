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
                    { 127284216, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3928), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3929), "Fire Detection" },
                    { 331819124, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3916), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3917), "Drainage" },
                    { 340814031, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3943), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3944), "Fire Suppression" },
                    { 385669379, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3968), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3969), "Natural Gas" },
                    { 407595373, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4019), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4020), "CCTV" },
                    { 438649304, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3890), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3891), "Sewage" },
                    { 462931762, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3980), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3981), "Power Distribution" },
                    { 502207224, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4096), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4097), "Construction Supervision" },
                    { 610040596, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3955), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3956), "Elevators" },
                    { 625449860, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3994), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3995), "Structured Cabling" },
                    { 635742179, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3903), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3904), "Potable Water" },
                    { 675856219, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4056), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4057), "Energy Efficiency" },
                    { 676433055, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3870), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3871), "HVAC" },
                    { 689826513, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4043), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4044), "Photovoltaics" },
                    { 758438903, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4068), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4069), "Outsource" },
                    { 787199131, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4006), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4008), "Burglar Alarm" },
                    { 908564162, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4031), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4032), "BMS" },
                    { 996337555, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4080), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4081), "TenderDocument" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 143009756, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4322), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4324), "Drawings" },
                    { 581373969, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4309), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4311), "Calculations" },
                    { 641981041, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4290), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4291), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 422566158, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4894), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4895), "Meetings" },
                    { 508719989, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4882), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4883), "On-Site" },
                    { 651225402, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4850), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4851), "Communications" },
                    { 678677170, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4906), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4907), "Administration" },
                    { 790899525, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4869), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4870), "Printing" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 137157942, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1768), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1770), "Dashboard Assign Engineer", 4 },
                    { 320282169, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1604), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1606), "See Dashboard Layout", 1 },
                    { 358929731, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1814), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1815), "See Admin Layout", 7 },
                    { 404004645, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1783), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1785), "Dashboard Assign Project Manager", 5 },
                    { 571328725, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1799), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1800), "Dashboard Add Project", 6 },
                    { 627980271, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1856), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1857), "See All Drawings", 10 },
                    { 707875175, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1870), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1871), "See All Projects", 11 },
                    { 776803707, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1737), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1738), "Dashboard Edit My Hours", 2 },
                    { 788436228, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1841), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1843), "See All Disciplines", 9 },
                    { 902102345, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1754), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1755), "Dashboard Assign Designer", 3 },
                    { 951171791, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1827), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1829), "Dashboard See My Hours", 8 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 261789553, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3392), "Infrastructure Description", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3393), "Infrastructure" },
                    { 644291574, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3374), "Buildings Description", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3375), "Buildings" },
                    { 760184363, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3406), "Energy Description", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3407), "Energy" },
                    { 872440109, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3420), "Consulting Description", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3421), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[] { 159451496, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1905), false, true, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1907), "Engineer" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1947), false, true, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1948), "CTO" },
                    { 557028166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1885), false, true, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1886), "Designer" },
                    { 574103270, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2002), false, false, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2003), "Admin" },
                    { 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1933), false, true, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1935), "COO" },
                    { 661825489, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1975), false, false, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1976), "Guest" },
                    { 792280675, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1920), false, true, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1921), "Project Manager" },
                    { 911227502, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1989), false, false, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1990), "Customer" },
                    { 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1961), false, true, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(1963), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 168604583, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3538), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3539), null, "6949277784", null, null, null },
                    { 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3343), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3344), null, "6949277785", null, null, null },
                    { 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3248), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3249), null, "6949277782", null, null, null },
                    { 297521371, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3104), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3105), null, "6949277784", null, null, null },
                    { 302566291, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3446), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3447), null, "6949277781", null, null, null },
                    { 349680428, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2774), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2776), null, "694927778", null, null, null },
                    { 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3275), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3276), null, "6949277783", null, null, null },
                    { 383631558, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2832), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2834), null, "694927778", null, null, null },
                    { 395840898, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3046), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3047), null, "6949277782", null, null, null },
                    { 587934852, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2804), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2805), null, "694927778", null, null, null },
                    { 626355603, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2898), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2899), null, "6949277780", null, null, null },
                    { 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3214), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3215), null, "6949277781", null, null, null },
                    { 674242822, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3134), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3135), null, "6949277785", null, null, null },
                    { 752028467, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2862), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2864), null, "694927778", null, null, null },
                    { 769207340, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3479), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3481), null, "6949277782", null, null, null },
                    { 835280550, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3074), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3075), null, "6949277783", null, null, null },
                    { 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3164), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3165), null, "6949277780", null, null, null },
                    { 927956939, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3510), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3511), null, "6949277783", null, null, null },
                    { 974719519, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2954), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2955), null, "6949277781", null, null, null },
                    { 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3314), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3315), null, "6949277784", null, null, null },
                    { 997768710, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2735), "Admin", "admin@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2737), null, "694927778", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 181666636, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 9.0, 16, new DateTime(2025, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 16, "Test Description Project_12", "KL-4", new DateTime(2025, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), new DateTime(2025, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 0f, 100L, 12L, new DateTime(2024, 3, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), "Project_4", 5.0, new DateTime(2025, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), "Payment Detailes For Project_12", 4.0, null, 872440109, new DateTime(2025, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 0f },
                    { 332987322, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 8.0, 9, new DateTime(2024, 12, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 9, "Test Description Project_9", "KL-3", new DateTime(2024, 12, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), new DateTime(2024, 12, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 0f, 100L, 12L, new DateTime(2024, 3, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), "Project_3", 5.0, new DateTime(2024, 12, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), "Payment Detailes For Project_15", 3.0, null, 760184363, new DateTime(2024, 12, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 0f },
                    { 805427831, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 6.0, 1, new DateTime(2024, 4, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 1, "Test Description Project_5", "KL-1", new DateTime(2024, 4, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), new DateTime(2024, 4, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 0f, 100L, 12L, new DateTime(2024, 3, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), "Project_1", 5.0, new DateTime(2024, 4, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), "Payment Detailes For Project_2", 1.0, null, 644291574, new DateTime(2024, 4, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 0f },
                    { 944020610, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 7.0, 4, new DateTime(2024, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 4, "Test Description Project_6", "KL-2", new DateTime(2024, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), new DateTime(2024, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 0f, 100L, 12L, new DateTime(2024, 3, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), "Project_2", 5.0, new DateTime(2024, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), "Payment Detailes For Project_6", 2.0, null, 261789553, new DateTime(2024, 7, 7, 20, 26, 53, 198, DateTimeKind.Local).AddTicks(3835), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 320282169, 159451496, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2079), -2061633824, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2080) },
                    { 627980271, 159451496, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2153), -153186794, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2155) },
                    { 776803707, 159451496, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2093), 2015207910, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2094) },
                    { 788436228, 159451496, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2139), 1489822124, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2141) },
                    { 902102345, 159451496, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2108), 548867453, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2109) },
                    { 951171791, 159451496, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2125), 1144567148, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2126) },
                    { 137157942, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2416), 1856194893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2418) },
                    { 320282169, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2374), 1700677490, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2375) },
                    { 404004645, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2430), 1353711861, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2432) },
                    { 571328725, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2444), -1392713396, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2445) },
                    { 627980271, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2485), 165122614, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2486) },
                    { 707875175, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2499), -336309893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2501) },
                    { 776803707, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2389), -1576444108, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2390) },
                    { 788436228, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2471), 58220870, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2473) },
                    { 902102345, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2402), 314727674, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2404) },
                    { 951171791, 165414009, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2457), 134002526, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2459) },
                    { 320282169, 557028166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2031), 1215580050, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2032) },
                    { 776803707, 557028166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2052), -978660638, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2053) },
                    { 951171791, 557028166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2065), -1420697141, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2067) },
                    { 358929731, 574103270, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2679), -420861181, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2680) },
                    { 627980271, 574103270, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2707), -71931761, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2708) },
                    { 707875175, 574103270, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2720), -237783905, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2721) },
                    { 788436228, 574103270, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2692), 1749289469, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2693) },
                    { 137157942, 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2293), 915633806, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2294) },
                    { 320282169, 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2250), -55395917, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2251) },
                    { 404004645, 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2306), 1297295055, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2308) },
                    { 627980271, 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2347), -1402440241, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2348) },
                    { 707875175, 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2361), -406844450, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2362) },
                    { 776803707, 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2264), 1764522374, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2265) },
                    { 788436228, 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2334), -1239729875, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2335) },
                    { 902102345, 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2278), -1034564962, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2280) },
                    { 951171791, 659624320, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2320), -1027343699, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2321) },
                    { 320282169, 661825489, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2652), 1390282389, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2653) },
                    { 137157942, 792280675, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2195), -1885636471, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2196) },
                    { 320282169, 792280675, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2168), 281254888, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2169) },
                    { 627980271, 792280675, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2236), 124173010, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2238) },
                    { 776803707, 792280675, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2181), -1972588828, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2183) },
                    { 788436228, 792280675, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2222), -256041314, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2223) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 951171791, 792280675, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2208), -1878860758, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2210) },
                    { 320282169, 911227502, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2665), -788401615, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2666) },
                    { 137157942, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2557), 476005541, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2558) },
                    { 320282169, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2516), 231249380, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2518) },
                    { 358929731, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2597), -1554956819, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2599) },
                    { 404004645, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2570), 1796432504, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2571) },
                    { 571328725, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2584), 268781270, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2585) },
                    { 627980271, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2625), 87236159, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2626) },
                    { 707875175, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2638), -121536715, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2640) },
                    { 776803707, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2530), -86904314, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2531) },
                    { 788436228, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2611), -978110914, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2612) },
                    { 902102345, 979039370, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2543), -2017110887, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2544) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 792280675, 168604583, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3553), 193167393, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3554) },
                    { 159451496, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3359), 766439988, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3360) },
                    { 159451496, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3262), 323730948, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3263) },
                    { 557028166, 297521371, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3121), 132149665, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3122) },
                    { 792280675, 302566291, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3465), 527445787, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3466) },
                    { 979039370, 349680428, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2790), 505187658, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2791) },
                    { 159451496, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3301), 442924448, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3302) },
                    { 659624320, 383631558, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2848), 229568105, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2849) },
                    { 557028166, 395840898, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3062), 902911508, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3063) },
                    { 165414009, 587934852, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2818), 756314265, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2819) },
                    { 557028166, 626355603, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2940), 950601381, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2941) },
                    { 159451496, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3234), 992473461, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3235) },
                    { 557028166, 674242822, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3149), 347053128, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3150) },
                    { 661825489, 752028467, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2878), 674678351, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2879) },
                    { 792280675, 769207340, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3495), 514548707, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3496) },
                    { 557028166, 835280550, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3091), 994837523, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3092) },
                    { 159451496, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3200), 880516270, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3201) },
                    { 792280675, 927956939, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3525), 865080217, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3527) },
                    { 557028166, 974719519, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3030), 947972641, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3031) },
                    { 159451496, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3330), 209476615, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3331) },
                    { 574103270, 997768710, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2755), 804615861, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(2756) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2108606120, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4262), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4263), 181666636, 758438903, null },
                    { -2033316344, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4234), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4235), 332987322, 908564162, null },
                    { -2005224472, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4137), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4138), 805427831, 127284216, null },
                    { -1674256704, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4194), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4195), 944020610, 407595373, null },
                    { -986417824, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4208), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4209), 332987322, 675856219, null },
                    { -686581760, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4151), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4153), 805427831, 625449860, null },
                    { -676922952, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4250), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4251), 181666636, 462931762, null },
                    { -660700968, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4275), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4276), 181666636, 675856219, null },
                    { 1098311424, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4165), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4166), 944020610, 676433055, null },
                    { 1535687384, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4114), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4115), 805427831, 787199131, null },
                    { 1570793416, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4179), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4180), 944020610, 385669379, null },
                    { 2146300184, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4221), 0f, 1500L, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4222), 332987322, 438649304, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 260936405, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3647), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3649), 3010.0, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3648), "Signature 142346", 83928, 805427831, 1.0, 17.0 },
                    { 616247783, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3720), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3722), 3100.0, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3721), "Signature 1423410", 46998, 944020610, 2.0, 24.0 },
                    { 895610599, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3787), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3789), 4000.0, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3788), "Signature 142343", 47947, 332987322, 3.0, 17.0 },
                    { 993791598, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3850), new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3853), 13000.0, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3852), "Signature 142348", 39282, 181666636, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 181666636, 168604583, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5759), 939501245, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5760) },
                    { 805427831, 302566291, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5714), 188864753, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5715) },
                    { 944020610, 769207340, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5733), 350111737, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5734) },
                    { 332987322, 927956939, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5746), 665264821, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5747) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 202571044, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3615), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3616), null, "6949277781", null, null, 805427831 },
                    { 652189734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3821), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3823), null, "6949277784", null, null, 181666636 },
                    { 787518811, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3692), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3693), null, "6949277782", null, null, 944020610 },
                    { 875092407, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3757), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3758), null, "6949277783", null, null, 332987322 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2108606120, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6653), 200430896, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6654) },
                    { -2108606120, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6614), 145665433, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6615) },
                    { -2108606120, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6627), 867852185, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6628) },
                    { -2108606120, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6602), 744373423, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6603) },
                    { -2108606120, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6589), 437256408, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6590) },
                    { -2108606120, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6639), 448872612, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6640) },
                    { -2033316344, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6499), 436807094, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6500) },
                    { -2033316344, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6462), 948282855, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6463) },
                    { -2033316344, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6474), 638047877, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6475) },
                    { -2033316344, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6450), 547377724, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6451) },
                    { -2033316344, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6437), 451543719, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6438) },
                    { -2033316344, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6487), 958102968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6488) },
                    { -2005224472, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5922), 574202844, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5923) },
                    { -2005224472, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5882), 444074442, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5883) },
                    { -2005224472, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5896), 844919960, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5897) },
                    { -2005224472, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5870), 813427589, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5871) },
                    { -2005224472, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5856), 600115281, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5858) },
                    { -2005224472, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5909), 849628188, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5910) },
                    { -1674256704, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6275), 552614636, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6276) },
                    { -1674256704, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6237), 456563633, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6238) },
                    { -1674256704, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6251), 572597323, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6252) },
                    { -1674256704, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6224), 152343158, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6225) },
                    { -1674256704, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6211), 400804997, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6213) },
                    { -1674256704, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6263), 158016827, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6264) },
                    { -986417824, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6350), 624943890, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6351) },
                    { -986417824, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6313), 149907647, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6314) },
                    { -986417824, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6325), 779634835, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6326) },
                    { -986417824, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6300), 758208010, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6301) },
                    { -986417824, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6288), 528892172, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6289) },
                    { -986417824, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6338), 965131784, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6339) },
                    { -686581760, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5999), 236815822, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6000) },
                    { -686581760, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5960), 138029856, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5961) },
                    { -686581760, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5973), 463400409, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5974) },
                    { -686581760, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5947), 924094374, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5948) },
                    { -686581760, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5935), 477595915, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5936) },
                    { -686581760, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5985), 888639647, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5986) },
                    { -676922952, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6576), 164284543, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6577) },
                    { -676922952, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6539), 613584464, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6540) },
                    { -676922952, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6552), 673813588, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6553) },
                    { -676922952, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6527), 771870472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6528) },
                    { -676922952, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6514), 680516269, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6515) },
                    { -676922952, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6564), 198474788, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6565) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -660700968, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6728), 480960872, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6729) },
                    { -660700968, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6691), 242930688, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6692) },
                    { -660700968, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6703), 385339165, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6704) },
                    { -660700968, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6678), 906574971, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6679) },
                    { -660700968, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6665), 852793470, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6666) },
                    { -660700968, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6716), 163129167, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6717) },
                    { 1098311424, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6119), 915464321, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6120) },
                    { 1098311424, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6079), 915394730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6080) },
                    { 1098311424, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6094), 671623970, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6095) },
                    { 1098311424, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6024), 367198773, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6026) },
                    { 1098311424, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6012), 539365467, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6013) },
                    { 1098311424, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6107), 144240634, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6108) },
                    { 1535687384, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5843), 979676700, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5844) },
                    { 1535687384, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5804), 232827858, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5805) },
                    { 1535687384, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5817), 685195538, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5818) },
                    { 1535687384, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5790), 176007556, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5792) },
                    { 1535687384, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5773), 750949050, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5774) },
                    { 1535687384, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5830), 762204918, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5831) },
                    { 1570793416, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6199), 558428573, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6200) },
                    { 1570793416, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6161), 879784788, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6163) },
                    { 1570793416, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6174), 239644435, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6175) },
                    { 1570793416, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6148), 431981711, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6149) },
                    { 1570793416, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6132), 353223602, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6134) },
                    { 1570793416, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6187), 749229120, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6188) },
                    { 2146300184, 270862682, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6425), 351644374, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6426) },
                    { 2146300184, 290949730, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6388), 646050000, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6389) },
                    { 2146300184, 353403070, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6400), 422331546, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6401) },
                    { 2146300184, 674081893, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6375), 998058374, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6376) },
                    { 2146300184, 902627204, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6363), 274173446, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6364) },
                    { 2146300184, 977769054, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6412), 395066501, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6414) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 208632639, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4544), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4542), 1570793416, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4543), 143009756 },
                    { 223348019, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4557), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4555), -1674256704, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4556), 641981041 },
                    { 259087047, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4358), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4355), 1535687384, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4357), 581373969 },
                    { 275203947, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4386), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4384), -2005224472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4385), 641981041 },
                    { 378939303, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4447), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4445), -686581760, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4446), 581373969 },
                    { 383028578, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4836), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4834), -660700968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4835), 143009756 },
                    { 394154889, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4503), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4500), 1098311424, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4502), 143009756 },
                    { 456674738, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4586), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4584), -1674256704, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4585), 143009756 },
                    { 477167565, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4613), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4611), -986417824, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4612), 581373969 },
                    { 489198342, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4571), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4568), -1674256704, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4569), 581373969 },
                    { 526847581, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4736), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4734), -676922952, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4735), 581373969 },
                    { 552995573, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4460), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4458), -686581760, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4459), 143009756 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 591294202, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4694), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4692), -2033316344, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4693), 581373969 },
                    { 613797542, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4708), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4705), -2033316344, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4706), 143009756 },
                    { 620526514, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4600), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4597), -986417824, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4598), 641981041 },
                    { 636573093, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4640), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4638), 2146300184, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4639), 641981041 },
                    { 653790006, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4517), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4514), 1570793416, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4515), 641981041 },
                    { 676963348, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4530), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4528), 1570793416, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4529), 581373969 },
                    { 710707956, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4340), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4336), 1535687384, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4338), 641981041 },
                    { 720884143, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4433), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4431), -686581760, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4432), 641981041 },
                    { 722885366, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4667), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4665), 2146300184, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4666), 143009756 },
                    { 755909812, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4823), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4820), -660700968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4822), 581373969 },
                    { 762677885, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4750), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4747), -676922952, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4748), 143009756 },
                    { 762784343, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4419), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4416), -2005224472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4417), 143009756 },
                    { 775399507, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4680), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4678), -2033316344, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4679), 641981041 },
                    { 800389361, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4489), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4487), 1098311424, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4488), 581373969 },
                    { 801810639, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4627), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4624), -986417824, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4625), 143009756 },
                    { 817906426, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4780), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4778), -2108606120, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4779), 581373969 },
                    { 862262771, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4476), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4473), 1098311424, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4474), 641981041 },
                    { 871490773, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4766), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4764), -2108606120, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4765), 641981041 },
                    { 885590472, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4654), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4651), 2146300184, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4652), 581373969 },
                    { 951253732, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4809), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4807), -660700968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4808), 641981041 },
                    { 965119198, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4723), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4720), -676922952, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4721), 641981041 },
                    { 965365163, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4794), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4791), -2108606120, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4792), 143009756 },
                    { 979230759, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4372), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4370), 1535687384, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4371), 143009756 },
                    { 998514311, new DateTime(2024, 3, 18, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4400), 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4398), -2005224472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4399), 581373969 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 138367353, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5404), 2146300184, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5405), 790899525 },
                    { 156754269, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5168), 1098311424, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5169), 422566158 },
                    { 163937201, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5206), 1570793416, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5208), 790899525 },
                    { 165717120, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5584), -2108606120, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5586), 651225402 },
                    { 170788849, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5006), -2005224472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5007), 790899525 },
                    { 193487609, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5391), 2146300184, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5392), 651225402 },
                    { 198735166, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4993), -2005224472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4994), 651225402 },
                    { 207293925, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5219), 1570793416, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5220), 508719989 },
                    { 218413013, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4922), 1535687384, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4923), 651225402 },
                    { 229071973, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5076), -686581760, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5077), 790899525 },
                    { 235812789, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5193), 1570793416, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5195), 651225402 },
                    { 237835596, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5140), 1098311424, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5141), 790899525 },
                    { 251605852, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4965), 1535687384, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4966), 422566158 },
                    { 277782398, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5661), -660700968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5662), 790899525 },
                    { 301752139, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5322), -986417824, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5323), 651225402 },
                    { 303535808, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5258), -1674256704, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5259), 651225402 },
                    { 316963131, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5468), -2033316344, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5469), 790899525 },
                    { 332119919, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5520), -676922952, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5521), 651225402 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 336442854, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5271), -1674256704, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5272), 790899525 },
                    { 343542734, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5032), -2005224472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5033), 422566158 },
                    { 375297429, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5507), -2033316344, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5508), 678677170 },
                    { 382559460, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5232), 1570793416, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5233), 422566158 },
                    { 388291014, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5442), 2146300184, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5443), 678677170 },
                    { 405271737, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5296), -1674256704, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5298), 422566158 },
                    { 416638378, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4978), 1535687384, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4979), 678677170 },
                    { 421183224, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5571), -676922952, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5572), 678677170 },
                    { 454980044, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5309), -1674256704, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5310), 678677170 },
                    { 470729345, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5114), -686581760, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5116), 678677170 },
                    { 508933132, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5623), -2108606120, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5624), 422566158 },
                    { 538964982, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5545), -676922952, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5546), 508719989 },
                    { 544678231, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5635), -2108606120, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5637), 678677170 },
                    { 555224464, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5102), -686581760, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5103), 422566158 },
                    { 559238811, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5417), 2146300184, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5418), 508719989 },
                    { 561473451, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5063), -686581760, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5064), 651225402 },
                    { 567130653, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5610), -2108606120, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5611), 508719989 },
                    { 573842735, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5597), -2108606120, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5598), 790899525 },
                    { 590804327, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5481), -2033316344, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5482), 508719989 },
                    { 626009310, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5558), -676922952, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5559), 422566158 },
                    { 642620466, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5674), -660700968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5675), 508719989 },
                    { 643107075, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4952), 1535687384, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4954), 508719989 },
                    { 650636176, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5378), -986417824, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5379), 678677170 },
                    { 661138177, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5335), -986417824, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5336), 790899525 },
                    { 663028991, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5687), -660700968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5688), 422566158 },
                    { 680066147, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5180), 1098311424, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5181), 678677170 },
                    { 724694446, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5348), -986417824, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5349), 508719989 },
                    { 727795905, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5365), -986417824, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5366), 422566158 },
                    { 728566573, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5699), -660700968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5700), 678677170 },
                    { 741484202, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5648), -660700968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5650), 651225402 },
                    { 749200347, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5245), 1570793416, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5246), 678677170 },
                    { 766568624, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5283), -1674256704, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5284), 508719989 },
                    { 774356566, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5019), -2005224472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5020), 508719989 },
                    { 789516865, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5127), 1098311424, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5129), 651225402 },
                    { 835113626, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5455), -2033316344, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5456), 651225402 },
                    { 846059657, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5429), 2146300184, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5430), 422566158 },
                    { 847236740, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5046), -2005224472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5047), 678677170 },
                    { 874350391, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5533), -676922952, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5534), 790899525 },
                    { 922445209, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4939), 1535687384, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(4940), 790899525 },
                    { 927321047, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5089), -686581760, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5090), 508719989 },
                    { 933897715, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5155), 1098311424, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5156), 508719989 },
                    { 995269734, 0f, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5494), -2033316344, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(5495), 422566158 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 911227502, 202571044, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3633), 375165674, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3634) },
                    { 911227502, 652189734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3837), 627695728, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3838) },
                    { 911227502, 787518811, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3707), 974564222, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3708) },
                    { 911227502, 875092407, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3772), 199510454, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(3773) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 297521371, 138367353, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9501), -516115466, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9502) },
                    { 395840898, 138367353, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9476), -943888171, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9477) },
                    { 626355603, 138367353, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9452), 1319966717, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9453) },
                    { 674242822, 138367353, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9513), 231573106, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9514) },
                    { 835280550, 138367353, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9488), -30270275, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9489) },
                    { 974719519, 138367353, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9464), 2076035189, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9465) },
                    { 297521371, 156754269, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8132), -1018838560, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8133) },
                    { 395840898, 156754269, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8108), -240580993, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8109) },
                    { 626355603, 156754269, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8084), 331905376, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8085) },
                    { 674242822, 156754269, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8144), -495539639, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8145) },
                    { 835280550, 156754269, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8120), -129104329, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8121) },
                    { 974719519, 156754269, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8096), -2130162758, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8097) },
                    { 297521371, 163937201, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8357), 1607611676, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8358) },
                    { 395840898, 163937201, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8331), 1547592822, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8332) },
                    { 626355603, 163937201, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8307), 1918838129, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8308) },
                    { 674242822, 163937201, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8369), 403859444, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8370) },
                    { 835280550, 163937201, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8344), 1883259059, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8345) },
                    { 974719519, 163937201, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8319), -889527113, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8320) },
                    { 297521371, 165717120, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(535), -1089906457, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(536) },
                    { 395840898, 165717120, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(510), -1927167556, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(511) },
                    { 626355603, 165717120, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(486), -1815875072, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(487) },
                    { 674242822, 165717120, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(547), -1633492790, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(548) },
                    { 835280550, 165717120, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(523), 407001200, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(524) },
                    { 974719519, 165717120, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(498), 124135930, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(499) },
                    { 297521371, 170788849, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7245), -1996641656, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7247) },
                    { 395840898, 170788849, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7221), 662845442, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7222) },
                    { 626355603, 170788849, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7197), -16832663, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7198) },
                    { 674242822, 170788849, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7258), -477104399, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7259) },
                    { 835280550, 170788849, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7233), -563710198, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7235) },
                    { 974719519, 170788849, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7209), 1588629272, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7210) },
                    { 297521371, 193487609, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9427), -185502239, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9428) },
                    { 395840898, 193487609, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9403), -1214069224, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9404) },
                    { 626355603, 193487609, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9378), -95281352, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9380) },
                    { 674242822, 193487609, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9439), -2037614728, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9440) },
                    { 835280550, 193487609, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9415), -763923455, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9416) },
                    { 974719519, 193487609, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9391), 1897306268, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9392) },
                    { 297521371, 198735166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7166), 366743692, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7168) },
                    { 395840898, 198735166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7141), 2052309060, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7142) },
                    { 626355603, 198735166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7117), 247834580, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7118) },
                    { 674242822, 198735166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7179), 1569451478, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7180) },
                    { 835280550, 198735166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7154), -2116215053, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7155) },
                    { 974719519, 198735166, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7129), -1534187938, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7130) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 297521371, 207293925, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8430), 1467628538, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8431) },
                    { 395840898, 207293925, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8405), 26436929, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8407) },
                    { 626355603, 207293925, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8381), 559711679, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8382) },
                    { 674242822, 207293925, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8442), 1515955140, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8443) },
                    { 835280550, 207293925, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8417), 1524025175, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8419) },
                    { 974719519, 207293925, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8393), 2005052913, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8395) },
                    { 297521371, 218413013, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6794), 1858575960, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6795) },
                    { 395840898, 218413013, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6770), -1380327844, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6771) },
                    { 626355603, 218413013, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6742), 1177997472, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6744) },
                    { 674242822, 218413013, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6807), -1454336360, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6808) },
                    { 835280550, 218413013, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6782), 1889296907, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6783) },
                    { 974719519, 218413013, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6757), -1577696741, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6758) },
                    { 297521371, 229071973, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7615), -1520109395, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7616) },
                    { 395840898, 229071973, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7590), -619148762, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7591) },
                    { 626355603, 229071973, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7566), 1816292570, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7567) },
                    { 674242822, 229071973, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7627), -1966248949, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7628) },
                    { 835280550, 229071973, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7602), -781752833, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7604) },
                    { 974719519, 229071973, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7578), -244755049, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7579) },
                    { 297521371, 235812789, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8282), -690600779, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8283) },
                    { 395840898, 235812789, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8254), 175410163, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8255) },
                    { 626355603, 235812789, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8230), 1675416807, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8231) },
                    { 674242822, 235812789, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8294), 415366484, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8295) },
                    { 835280550, 235812789, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8266), 1685757708, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8267) },
                    { 974719519, 235812789, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8242), 1035255173, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8243) },
                    { 297521371, 237835596, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7986), 1565832794, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7987) },
                    { 395840898, 237835596, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7962), 782363318, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7963) },
                    { 626355603, 237835596, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7937), -1073757257, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7938) },
                    { 674242822, 237835596, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7999), -1809198184, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8000) },
                    { 835280550, 237835596, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7974), 1189431072, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7975) },
                    { 974719519, 237835596, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7949), -737853007, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7951) },
                    { 297521371, 251605852, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7020), -800114989, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7021) },
                    { 395840898, 251605852, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6996), 1149797831, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6997) },
                    { 626355603, 251605852, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6971), -679740781, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6973) },
                    { 674242822, 251605852, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7032), 205767676, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7033) },
                    { 835280550, 251605852, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7008), -169432582, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7009) },
                    { 974719519, 251605852, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6984), 1760860400, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6985) },
                    { 297521371, 277782398, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(975), -244214423, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(976) },
                    { 395840898, 277782398, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(951), -1170853087, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(952) },
                    { 626355603, 277782398, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(926), 1228357791, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(928) },
                    { 674242822, 277782398, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(987), 301974044, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(988) },
                    { 835280550, 277782398, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(963), -753821558, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(964) },
                    { 974719519, 277782398, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(939), -2019382366, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(940) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 297521371, 301752139, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9019), -647785552, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9020) },
                    { 395840898, 301752139, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8995), 453569621, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8996) },
                    { 626355603, 301752139, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8971), -499391198, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8972) },
                    { 674242822, 301752139, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9031), -879761105, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9032) },
                    { 835280550, 301752139, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9007), -1297484527, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9008) },
                    { 974719519, 301752139, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8983), 41982998, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8984) },
                    { 297521371, 303535808, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8651), 544137602, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8652) },
                    { 395840898, 303535808, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8626), -819781451, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8628) },
                    { 626355603, 303535808, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8602), 1368863811, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8603) },
                    { 674242822, 303535808, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8663), 1146074283, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8664) },
                    { 835280550, 303535808, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8639), 1747355859, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8640) },
                    { 974719519, 303535808, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8614), -749576672, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8615) },
                    { 297521371, 316963131, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9869), -1350399928, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9870) },
                    { 395840898, 316963131, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9845), 582757997, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9846) },
                    { 626355603, 316963131, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9821), -17734279, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9822) },
                    { 674242822, 316963131, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9881), 2018886440, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9883) },
                    { 835280550, 316963131, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9857), -1760771911, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9858) },
                    { 974719519, 316963131, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9833), -1436662133, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9834) },
                    { 297521371, 332119919, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(166), 1139023656, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(167) },
                    { 395840898, 332119919, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(142), -459242702, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(143) },
                    { 626355603, 332119919, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(118), -281995784, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(119) },
                    { 674242822, 332119919, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(178), 1447649735, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(179) },
                    { 835280550, 332119919, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(154), -1012755104, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(155) },
                    { 974719519, 332119919, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(130), -903895681, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(131) },
                    { 297521371, 336442854, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8723), 1654360299, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8724) },
                    { 395840898, 336442854, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8699), -1416391825, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8700) },
                    { 626355603, 336442854, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8675), 1429458399, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8676) },
                    { 674242822, 336442854, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8736), 2129939055, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8737) },
                    { 835280550, 336442854, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8711), -1401210143, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8712) },
                    { 974719519, 336442854, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8687), 119296018, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8688) },
                    { 297521371, 343542734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7392), 1244770367, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7393) },
                    { 395840898, 343542734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7367), -752342521, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7368) },
                    { 626355603, 343542734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7343), 1611839205, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7344) },
                    { 674242822, 343542734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7404), -664511197, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7405) },
                    { 835280550, 343542734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7379), 74195663, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7381) },
                    { 974719519, 343542734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7355), 1485730467, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7356) },
                    { 297521371, 375297429, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(94), -1411878779, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(95) },
                    { 395840898, 375297429, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(69), -603171400, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(70) },
                    { 626355603, 375297429, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(45), -1893482540, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(46) },
                    { 674242822, 375297429, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(106), 1887225440, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(107) },
                    { 835280550, 375297429, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(82), 1193177264, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(83) },
                    { 974719519, 375297429, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(57), 805079111, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(58) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 297521371, 382559460, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8503), -727219466, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8504) },
                    { 395840898, 382559460, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8478), 1345626576, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8479) },
                    { 626355603, 382559460, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8454), -1767252649, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8455) },
                    { 674242822, 382559460, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8515), -1907804393, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8516) },
                    { 835280550, 382559460, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8490), 2088747558, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8491) },
                    { 974719519, 382559460, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8466), 1242576549, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8467) },
                    { 297521371, 388291014, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9720), -520452913, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9721) },
                    { 395840898, 388291014, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9696), 548944034, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9697) },
                    { 626355603, 388291014, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9671), 2125943469, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9672) },
                    { 674242822, 388291014, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9732), 129224476, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9733) },
                    { 835280550, 388291014, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9708), 1719038205, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9709) },
                    { 974719519, 388291014, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9683), -1739792006, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9685) },
                    { 297521371, 405271737, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8870), 1615249737, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8871) },
                    { 395840898, 405271737, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8846), -2038058180, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8847) },
                    { 626355603, 405271737, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8822), 82650250, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8823) },
                    { 674242822, 405271737, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8882), 324162968, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8883) },
                    { 835280550, 405271737, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8858), 408716326, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8859) },
                    { 974719519, 405271737, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8834), -1308046585, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8835) },
                    { 297521371, 416638378, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7093), 2103487817, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7094) },
                    { 395840898, 416638378, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7069), 764951711, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7070) },
                    { 626355603, 416638378, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7045), -357777017, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7046) },
                    { 674242822, 416638378, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7105), 1162463072, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7106) },
                    { 835280550, 416638378, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7081), -1560817345, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7082) },
                    { 974719519, 416638378, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7057), 948703757, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7058) },
                    { 297521371, 421183224, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(462), 1813405298, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(463) },
                    { 395840898, 421183224, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(438), 1916352513, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(439) },
                    { 626355603, 421183224, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(413), -1797161197, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(415) },
                    { 674242822, 421183224, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(474), -2103485570, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(475) },
                    { 835280550, 421183224, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(450), 1263000114, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(451) },
                    { 974719519, 421183224, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(426), -588972838, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(427) },
                    { 297521371, 454980044, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8946), -290488594, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8947) },
                    { 395840898, 454980044, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8919), 795796097, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8920) },
                    { 626355603, 454980044, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8895), 851677331, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8896) },
                    { 674242822, 454980044, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8958), 1507666869, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8960) },
                    { 835280550, 454980044, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8931), -2009830112, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8932) },
                    { 974719519, 454980044, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8907), -2030033366, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8908) },
                    { 297521371, 470729345, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7834), 1372341528, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7835) },
                    { 395840898, 470729345, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7810), -994169456, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7811) },
                    { 626355603, 470729345, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7785), -90087628, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7786) },
                    { 674242822, 470729345, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7846), 295937578, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7847) },
                    { 835280550, 470729345, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7822), -1114428104, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7823) },
                    { 974719519, 470729345, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7797), 2041794473, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7798) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 297521371, 508933132, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(756), -431175028, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(757) },
                    { 395840898, 508933132, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(732), -50082241, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(733) },
                    { 626355603, 508933132, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(708), -527267267, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(709) },
                    { 674242822, 508933132, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(768), -620861224, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(769) },
                    { 835280550, 508933132, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(744), 1655068010, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(745) },
                    { 974719519, 508933132, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(720), -2084536957, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(721) },
                    { 297521371, 538964982, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(312), 1851914606, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(313) },
                    { 395840898, 538964982, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(288), -460025270, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(289) },
                    { 626355603, 538964982, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(263), -873553652, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(264) },
                    { 674242822, 538964982, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(327), -1548456565, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(329) },
                    { 835280550, 538964982, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(300), -985858784, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(301) },
                    { 974719519, 538964982, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(275), -446572151, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(276) },
                    { 297521371, 544678231, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(829), 1334934648, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(830) },
                    { 395840898, 544678231, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(805), -470612308, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(806) },
                    { 626355603, 544678231, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(780), 277867598, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(782) },
                    { 674242822, 544678231, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(841), 1344895097, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(842) },
                    { 835280550, 544678231, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(817), 916923911, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(818) },
                    { 974719519, 544678231, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(793), -132972596, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(794) },
                    { 297521371, 555224464, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7761), 1009796360, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7762) },
                    { 395840898, 555224464, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7737), 1812852252, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7738) },
                    { 626355603, 555224464, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7712), 1001184575, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7713) },
                    { 674242822, 555224464, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7773), -1711825294, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7774) },
                    { 835280550, 555224464, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7749), 196690406, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7750) },
                    { 974719519, 555224464, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7725), -667234111, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7726) },
                    { 297521371, 559238811, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9574), -55936651, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9575) },
                    { 395840898, 559238811, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9549), -1541979382, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9551) },
                    { 626355603, 559238811, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9525), -761289749, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9526) },
                    { 674242822, 559238811, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9586), 178996622, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9587) },
                    { 835280550, 559238811, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9562), 218130251, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9563) },
                    { 974719519, 559238811, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9537), -969984089, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9539) },
                    { 297521371, 561473451, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7537), -1067773004, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7538) },
                    { 395840898, 561473451, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7513), -1484010949, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7514) },
                    { 626355603, 561473451, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7489), -567117598, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7490) },
                    { 674242822, 561473451, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7554), -1307449606, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7555) },
                    { 835280550, 561473451, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7525), -1714497223, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7526) },
                    { 974719519, 561473451, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7501), -1499051915, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7502) },
                    { 297521371, 567130653, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(680), 516725645, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(682) },
                    { 395840898, 567130653, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(656), -800296604, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(657) },
                    { 626355603, 567130653, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(632), -1303775864, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(633) },
                    { 674242822, 567130653, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(693), -2137287721, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(694) },
                    { 835280550, 567130653, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(668), 1677416585, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(669) },
                    { 974719519, 567130653, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(644), 1733943015, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(645) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 297521371, 573842735, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(607), 952890692, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(609) },
                    { 395840898, 573842735, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(583), 470879546, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(585) },
                    { 626355603, 573842735, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(559), 214272829, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(560) },
                    { 674242822, 573842735, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(620), 406082305, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(621) },
                    { 835280550, 573842735, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(595), 1949325899, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(597) },
                    { 974719519, 573842735, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(571), -1139994323, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(572) },
                    { 297521371, 590804327, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9942), -368776309, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9943) },
                    { 395840898, 590804327, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9918), 117302486, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9919) },
                    { 626355603, 590804327, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9894), -416016931, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9895) },
                    { 674242822, 590804327, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9960), 887858528, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9961) },
                    { 835280550, 590804327, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9930), -1528766198, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9931) },
                    { 974719519, 590804327, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9906), -1616410259, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9907) },
                    { 297521371, 626009310, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(389), 248699975, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(390) },
                    { 395840898, 626009310, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(365), 1203619919, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(366) },
                    { 626355603, 626009310, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(340), -321285487, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(341) },
                    { 674242822, 626009310, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(401), -485527081, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(402) },
                    { 835280550, 626009310, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(377), -1724484199, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(378) },
                    { 974719519, 626009310, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(353), -482763212, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(354) },
                    { 297521371, 642620466, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1048), 357952321, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1049) },
                    { 395840898, 642620466, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1023), 1582166633, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1024) },
                    { 626355603, 642620466, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(999), -1558509484, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1000) },
                    { 674242822, 642620466, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1060), 1406401461, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1061) },
                    { 835280550, 642620466, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1036), 262064098, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1037) },
                    { 974719519, 642620466, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1011), 1327045145, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1012) },
                    { 297521371, 643107075, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6946), 1397588373, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6947) },
                    { 395840898, 643107075, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6922), 197509492, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6923) },
                    { 626355603, 643107075, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6898), -90457145, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6899) },
                    { 674242822, 643107075, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6959), -1937708756, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6960) },
                    { 835280550, 643107075, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6934), 1180289039, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6935) },
                    { 974719519, 643107075, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6910), -799685225, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6911) },
                    { 297521371, 650636176, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9351), -875610922, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9352) },
                    { 395840898, 650636176, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9326), -848661110, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9327) },
                    { 626355603, 650636176, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9302), 1159625507, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9303) },
                    { 674242822, 650636176, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9366), -1348467304, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9367) },
                    { 835280550, 650636176, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9339), -1795877693, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9340) },
                    { 974719519, 650636176, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9314), -1212650324, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9316) },
                    { 297521371, 661138177, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9130), -477589769, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9131) },
                    { 395840898, 661138177, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9068), 1516376484, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9069) },
                    { 626355603, 661138177, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9043), -918166369, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9044) },
                    { 674242822, 661138177, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9143), -1383010492, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9144) },
                    { 835280550, 661138177, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9080), 32855428, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9117) },
                    { 974719519, 661138177, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9056), -1613662145, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9057) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 297521371, 663028991, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1124), 1381714646, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1125) },
                    { 395840898, 663028991, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1100), -1387099669, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1101) },
                    { 626355603, 663028991, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1072), -1392346160, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1073) },
                    { 674242822, 663028991, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1136), -2041224079, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1137) },
                    { 835280550, 663028991, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1112), -2021112512, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1113) },
                    { 974719519, 663028991, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1087), 747975002, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1088) },
                    { 297521371, 680066147, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8205), -76764334, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8206) },
                    { 395840898, 680066147, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8181), 1114942613, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8182) },
                    { 626355603, 680066147, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8157), 782153483, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8158) },
                    { 674242822, 680066147, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8218), 1942351241, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8219) },
                    { 835280550, 680066147, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8193), 1797914016, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8194) },
                    { 974719519, 680066147, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8169), -148034330, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8170) },
                    { 297521371, 724694446, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9205), -31095922, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9206) },
                    { 395840898, 724694446, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9180), -1353978661, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9181) },
                    { 626355603, 724694446, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9156), -1084908478, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9157) },
                    { 674242822, 724694446, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9217), 1792611113, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9218) },
                    { 835280550, 724694446, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9193), -537058732, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9194) },
                    { 974719519, 724694446, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9168), -1042474661, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9169) },
                    { 297521371, 727795905, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9278), 2079455517, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9279) },
                    { 395840898, 727795905, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9254), -941640646, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9255) },
                    { 626355603, 727795905, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9229), -11578292, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9230) },
                    { 674242822, 727795905, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9290), -1843710110, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9291) },
                    { 835280550, 727795905, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9266), -312207695, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9267) },
                    { 974719519, 727795905, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9241), -867078215, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9243) },
                    { 297521371, 728566573, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1197), -2040599888, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1198) },
                    { 395840898, 728566573, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1173), 1456031111, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1174) },
                    { 626355603, 728566573, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1149), -15412445, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1150) },
                    { 674242822, 728566573, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1209), -436353713, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1210) },
                    { 835280550, 728566573, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1185), 134888977, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1186) },
                    { 974719519, 728566573, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1161), 317828516, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(1162) },
                    { 297521371, 741484202, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(902), -1814143175, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(903) },
                    { 395840898, 741484202, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(878), -1026234539, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(879) },
                    { 626355603, 741484202, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(853), 239779603, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(855) },
                    { 674242822, 741484202, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(914), -1617963965, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(915) },
                    { 835280550, 741484202, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(890), 747270446, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(891) },
                    { 974719519, 741484202, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(866), 1924890413, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(867) },
                    { 297521371, 749200347, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8578), -1562901484, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8579) },
                    { 395840898, 749200347, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8551), -1982356339, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8552) },
                    { 626355603, 749200347, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8527), 1021677602, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8528) },
                    { 674242822, 749200347, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8590), 1369397574, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8591) },
                    { 835280550, 749200347, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8563), 1315732631, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8564) },
                    { 974719519, 749200347, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8539), -892081187, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8540) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 297521371, 766568624, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8797), -1055816761, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8798) },
                    { 395840898, 766568624, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8772), 1760622188, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8773) },
                    { 626355603, 766568624, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8748), 1818836654, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8749) },
                    { 674242822, 766568624, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8809), 1138992683, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8810) },
                    { 835280550, 766568624, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8784), 1883881935, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8785) },
                    { 974719519, 766568624, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8760), 127428985, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8761) },
                    { 297521371, 774356566, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7319), 1229804109, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7320) },
                    { 395840898, 774356566, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7294), -1143398380, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7295) },
                    { 626355603, 774356566, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7270), -2124870961, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7271) },
                    { 674242822, 774356566, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7331), 66499430, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7332) },
                    { 835280550, 774356566, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7307), 765248927, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7308) },
                    { 974719519, 774356566, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7282), 1475646237, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7283) },
                    { 297521371, 789516865, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7913), 1936676214, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7914) },
                    { 395840898, 789516865, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7883), 1346921910, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7884) },
                    { 626355603, 789516865, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7858), -444848030, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7859) },
                    { 674242822, 789516865, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7925), -1964640100, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7926) },
                    { 835280550, 789516865, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7895), 1756223978, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7896) },
                    { 974719519, 789516865, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7870), -1938560404, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7871) },
                    { 297521371, 835113626, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9796), 1655660813, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9798) },
                    { 395840898, 835113626, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9772), 204174289, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9773) },
                    { 626355603, 835113626, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9748), 844194227, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9749) },
                    { 674242822, 835113626, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9809), -1774276627, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9810) },
                    { 835280550, 835113626, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9784), -415372792, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9785) },
                    { 974719519, 835113626, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9760), 213325880, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9761) },
                    { 297521371, 846059657, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9646), -1560519089, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9648) },
                    { 395840898, 846059657, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9622), -132873880, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9623) },
                    { 626355603, 846059657, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9598), 1965347028, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9599) },
                    { 674242822, 846059657, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9659), 1318484565, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9660) },
                    { 835280550, 846059657, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9634), -201182611, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9636) },
                    { 974719519, 846059657, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9610), -1505204432, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9611) },
                    { 297521371, 847236740, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7464), 1872840794, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7465) },
                    { 395840898, 847236740, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7440), 1766382872, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7441) },
                    { 626355603, 847236740, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7416), 2012337117, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7417) },
                    { 674242822, 847236740, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7476), -1092221882, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7477) },
                    { 835280550, 847236740, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7452), -17905882, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7453) },
                    { 974719519, 847236740, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7428), -1359847714, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7429) },
                    { 297521371, 874350391, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(239), -430858331, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(240) },
                    { 395840898, 874350391, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(215), 1893250742, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(216) },
                    { 626355603, 874350391, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(191), 1818963252, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(192) },
                    { 674242822, 874350391, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(251), 1223373056, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(252) },
                    { 835280550, 874350391, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(227), 1901402987, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(228) },
                    { 974719519, 874350391, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(203), -1673011961, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(204) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 297521371, 922445209, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6874), -1338307213, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6875) },
                    { 395840898, 922445209, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6848), 1872737829, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6849) },
                    { 626355603, 922445209, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6820), -1577330941, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6821) },
                    { 674242822, 922445209, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6886), 1730298825, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6887) },
                    { 835280550, 922445209, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6861), -1832616287, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6862) },
                    { 974719519, 922445209, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6832), 186296482, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(6833) },
                    { 297521371, 927321047, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7688), 1190130080, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7689) },
                    { 395840898, 927321047, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7664), -723214768, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7665) },
                    { 626355603, 927321047, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7639), -1922851822, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7640) },
                    { 674242822, 927321047, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7700), 1644888024, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7701) },
                    { 835280550, 927321047, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7676), -1665168502, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7677) },
                    { 974719519, 927321047, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7651), 1586173059, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(7652) },
                    { 297521371, 933897715, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8059), 69556537, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8060) },
                    { 395840898, 933897715, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8035), -2040112394, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8036) },
                    { 626355603, 933897715, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8011), 1967750352, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8012) },
                    { 674242822, 933897715, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8072), 175016269, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8073) },
                    { 835280550, 933897715, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8047), -398287952, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8048) },
                    { 974719519, 933897715, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8023), -1775955347, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(8024) },
                    { 297521371, 995269734, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(21), -1747913642, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(22) },
                    { 395840898, 995269734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9996), -1611737432, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9997) },
                    { 626355603, 995269734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9972), 1643770, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9973) },
                    { 674242822, 995269734, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(33), 855991508, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(34) },
                    { 835280550, 995269734, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(9), 276888362, new DateTime(2024, 3, 7, 20, 26, 53, 209, DateTimeKind.Local).AddTicks(10) },
                    { 974719519, 995269734, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9984), -2054857576, new DateTime(2024, 3, 7, 20, 26, 53, 208, DateTimeKind.Local).AddTicks(9985) }
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
