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
                    CanAssignePM = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
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
                    EstimatedMandays = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedCompleted = table.Column<float>(type: "real", nullable: false),
                    Completed = table.Column<float>(type: "real", nullable: false),
                    WorkPackegedCompleted = table.Column<float>(type: "real", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                    ProxyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 167058877, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6981), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6983), "HVAC" },
                    { 180585988, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7158), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7159), "Photovoltaics" },
                    { 292451943, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7014), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7016), "Potable Water" },
                    { 355267366, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7173), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7174), "Energy Efficiency" },
                    { 425864070, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7002), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7003), "Sewage" },
                    { 435665107, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7093), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7094), "Power Distribution" },
                    { 444210197, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7027), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7029), "Drainage" },
                    { 463232793, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7107), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7108), "Structured Cabling" },
                    { 488715815, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7040), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7041), "Fire Detection" },
                    { 636639876, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7145), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7146), "BMS" },
                    { 721592524, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7055), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7056), "Fire Suppression" },
                    { 730180695, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7198), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7199), "TenderDocument" },
                    { 765954117, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7068), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7069), "Elevators" },
                    { 812049959, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7120), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7121), "Burglar Alarm" },
                    { 833685658, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7212), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7214), "Construction Supervision" },
                    { 857271500, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7226), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7227), "Project Manager Hours" },
                    { 859661838, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7080), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7081), "Natural Gas" },
                    { 876656765, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7186), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7187), "Outsource" },
                    { 954575940, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7133), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7134), "CCTV" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 253603156, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7446), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7448), "Documents" },
                    { 671086288, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7478), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7479), "Drawings" },
                    { 987470756, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7465), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7467), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 184411881, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8054), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8055), "Communications" },
                    { 318623841, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8076), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8077), "Printing" },
                    { 437394989, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8113), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8115), "Administration" },
                    { 649556535, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8088), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8090), "On-Site" },
                    { 690142586, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8101), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8102), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 130963470, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4211), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4212), "See All Disciplines", 9 },
                    { 331256223, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4121), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4122), "Dashboard Assign Designer", 3 },
                    { 339936467, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4022), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4023), "See Dashboard Layout", 1 },
                    { 359141577, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4166), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4167), "Dashboard Add Project", 6 },
                    { 408693394, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4240), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4242), "See All Projects", 11 },
                    { 426491918, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4180), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4181), "See Admin Layout", 7 },
                    { 476097622, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4197), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4199), "Dashboard See My Hours", 8 },
                    { 583230683, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4136), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4137), "Dashboard Assign Engineer", 4 },
                    { 610265184, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4227), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4228), "See All Drawings", 10 },
                    { 775310188, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4104), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4106), "Dashboard Edit My Hours", 2 },
                    { 856561328, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4150), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4152), "Dashboard Assign Project Manager", 5 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 311104139, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6509), "Consulting Description", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6511), "Consulting" },
                    { 729135534, false, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6523), "Production Management Description", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6524), "Production Management" },
                    { 823118206, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6465), "Buildings Description", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6466), "Buildings" },
                    { 832400266, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6482), "Infrastructure Description", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6483), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { 999634372, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6496), "Energy Description", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6497), "Energy" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 155689457, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4388), false, false, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4389), "Secretariat" },
                    { 191941878, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4345), false, false, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4347), "Guest" },
                    { 194965934, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4373), false, false, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4374), "Admin" },
                    { 222859893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4317), false, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4318), "CTO" },
                    { 260751443, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4290), false, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4291), "Project Manager" },
                    { 298252180, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4276), false, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4277), "Engineer" },
                    { 327783981, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4255), false, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4256), "Designer" },
                    { 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4304), false, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4305), "COO" },
                    { 398735260, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4360), false, false, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4361), "Customer" },
                    { 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4331), false, true, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4333), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 138471006, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5281), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5282), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5832), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5833), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 169612550, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5367), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5368), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6293), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6294), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5746), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5747), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6058), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6059), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 260982548, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5463), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5464), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 278316525, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5183), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5184), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5906), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5908), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 328720238, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5324), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5325), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 488519758, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5522), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5525), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6013), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6014), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 534765322, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5612), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5613), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6378), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6379), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5967), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5969), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5701), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5702), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 642224957, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5236), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5238), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6421), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6422), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6335), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6337), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 737201795, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5567), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5569), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5789), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5791), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6147), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6202), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6104), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6106), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6248), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6249), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 963394930, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5417), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5418), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5656), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5658), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 139894589, "vtza@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5984), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5985), 551965690 },
                    { 156524575, "guest@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5384), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5385), 169612550 },
                    { 181800363, "ceo@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5252), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5253), 642224957 },
                    { 186218313, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5494), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5495), 260982548 },
                    { 196096382, "panperivollari@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6393), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6394), 535552236 },
                    { 216134937, "xmanarolis@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5715), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5716), 619972813 },
                    { 241430958, "vchontos@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6350), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6351), 706702778 },
                    { 268087731, "coo@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5338), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5340), 328720238 },
                    { 279894663, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5627), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5628), 534765322 },
                    { 282916563, "blekou@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6307), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6308), 199316113 },
                    { 320896088, "cto@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5295), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5297), 138471006 },
                    { 470214884, "agretos@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6028), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6030), 533706200 },
                    { 480019657, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5201), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5203), 278316525 },
                    { 497913455, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6262), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6264), 903271620 },
                    { 510349720, "pm@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5432), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5433), 963394930 },
                    { 522221115, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5583), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5584), 737201795 },
                    { 522775671, "ngal@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5848), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5849), 167139560 },
                    { 535879443, "sparisis@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5761), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5763), 232919948 },
                    { 614332687, "haris@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6119), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6120), 899274211 },
                    { 689986688, "kmargeti@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6073), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6074), 245548035 },
                    { 694607664, "chkovras@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5805), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5806), 776723462 },
                    { 762045968, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6435), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6436), 682657649 },
                    { 787645823, "kkotsoni@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5922), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5923), 319618752 },
                    { 822281097, "embiria@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5480), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5481), 260982548 },
                    { 902109880, "pfokianou@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6219), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6220), 793607774 },
                    { 906113537, "vpax@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5672), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5674), 982185375 },
                    { 979679056, "gdoug@embiria.gr", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5538), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5539), 488519758 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 333654279, false, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 6.0, 1, new DateTime(2024, 4, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 1, "Test Description Project_3", new DateTime(2024, 4, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), new DateTime(2024, 4, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Project_1", 5.0, new DateTime(2024, 4, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Payment Detailes For Project_4", 1.0, null, 823118206, new DateTime(2024, 4, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f },
                    { 517611368, true, "ALPHA", 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 111.0, 90, new DateTime(2024, 6, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 1, "Test Description Project_PM", new DateTime(2024, 4, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), new DateTime(2024, 5, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Project_PM", 45.0, new DateTime(2024, 4, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Payment Detailes For Project_PM", 2.0, null, 729135534, new DateTime(2024, 5, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f },
                    { 586391448, false, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 8.0, 9, new DateTime(2024, 12, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 9, "Test Description Project_15", new DateTime(2024, 12, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), new DateTime(2024, 12, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Project_3", 5.0, new DateTime(2024, 12, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Payment Detailes For Project_12", 3.0, null, 999634372, new DateTime(2024, 12, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f },
                    { 923783563, true, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 9.0, 16, new DateTime(2025, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 16, "Test Description Project_16", new DateTime(2025, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), new DateTime(2025, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Project_4", 5.0, new DateTime(2025, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Payment Detailes For Project_24", 4.0, null, 311104139, new DateTime(2025, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f },
                    { 984128545, true, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 7.0, 4, new DateTime(2024, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 4, "Test Description Project_10", new DateTime(2024, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), new DateTime(2024, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Project_2", 5.0, new DateTime(2024, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), "Payment Detailes For Project_6", 2.0, null, 832400266, new DateTime(2024, 7, 14, 14, 30, 28, 0, DateTimeKind.Local).AddTicks(3499), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 130963470, 155689457, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5140), -972599831, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5141) },
                    { 339936467, 155689457, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5098), -1057293976, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5099) },
                    { 408693394, 155689457, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5168), -349368925, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5169) },
                    { 476097622, 155689457, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5126), -1483223899, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5127) },
                    { 610265184, 155689457, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5154), -1031352844, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5155) },
                    { 775310188, 155689457, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5112), -1392793420, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5113) },
                    { 339936467, 191941878, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5012), -1326753737, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5013) },
                    { 130963470, 194965934, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5054), 138324367, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5056) },
                    { 408693394, 194965934, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5083), 2031535827, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5084) },
                    { 426491918, 194965934, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5040), -898937810, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5042) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 610265184, 194965934, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5068), 1788344051, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5070) },
                    { 130963470, 222859893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4824), -1985581700, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4825) },
                    { 339936467, 222859893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4753), 1323120596, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4755) },
                    { 359141577, 222859893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4796), 1342909215, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4797) },
                    { 408693394, 222859893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4852), 1269933548, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4853) },
                    { 476097622, 222859893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4810), 1191424100, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4811) },
                    { 610265184, 222859893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4838), -1468493855, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4839) },
                    { 775310188, 222859893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4767), 1540194831, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4769) },
                    { 856561328, 222859893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4782), -968671975, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4783) },
                    { 130963470, 260751443, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4595), 2051362391, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4596) },
                    { 339936467, 260751443, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4539), -695918870, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4540) },
                    { 476097622, 260751443, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4581), 219998044, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4582) },
                    { 583230683, 260751443, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4567), 200199245, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4569) },
                    { 610265184, 260751443, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4612), -627580237, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4614) },
                    { 775310188, 260751443, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4553), -1818039667, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4555) },
                    { 130963470, 298252180, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4510), 555421928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4511) },
                    { 331256223, 298252180, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4481), -156470255, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4482) },
                    { 339936467, 298252180, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4452), 1459547100, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4453) },
                    { 476097622, 298252180, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4496), 1775796629, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4497) },
                    { 610265184, 298252180, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4524), -214179938, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4525) },
                    { 775310188, 298252180, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4466), -645178463, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4467) },
                    { 339936467, 327783981, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4402), -1175833169, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4403) },
                    { 476097622, 327783981, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4438), 175392019, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4439) },
                    { 775310188, 327783981, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4424), -1501196665, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4425) },
                    { 130963470, 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4712), 1644088059, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4713) },
                    { 331256223, 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4656), -1959603695, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4657) },
                    { 339936467, 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4627), -1486850669, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4628) },
                    { 408693394, 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4740), -1916805262, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4741) },
                    { 476097622, 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4698), 957408170, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4699) },
                    { 583230683, 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4670), -1172696206, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4671) },
                    { 610265184, 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4726), -612652333, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4727) },
                    { 775310188, 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4641), 1860472935, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4642) },
                    { 856561328, 375488862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4685), 1669791011, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4686) },
                    { 339936467, 398735260, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5026), 703844456, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5027) },
                    { 130963470, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4967), -1147191169, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4969) },
                    { 331256223, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4896), -635752412, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4897) },
                    { 339936467, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4866), -1119475678, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4867) },
                    { 359141577, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4940), -1851689222, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4941) },
                    { 408693394, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4998), -1187405410, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4999) },
                    { 426491918, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4954), 1283722254, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4955) },
                    { 583230683, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4910), -788506316, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4912) },
                    { 610265184, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4981), 1451992793, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4982) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 775310188, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4882), -1220577763, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4883) },
                    { 856561328, 440391406, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4925), -1861052066, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(4927) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 222859893, 138471006, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5310), 391550160, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5311) },
                    { 194965934, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5876), 389372784, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5878) },
                    { 298252180, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5862), 712025248, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5863) },
                    { 440391406, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5891), 185017411, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5892) },
                    { 191941878, 169612550, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5401), 863092134, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5403) },
                    { 298252180, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6321), 442656093, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6322) },
                    { 298252180, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5775), 562732893, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5776) },
                    { 298252180, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6090), 525049331, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6091) },
                    { 155689457, 260982548, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5508), 131702948, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5509) },
                    { 194965934, 278316525, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5219), 251968351, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5221) },
                    { 260751443, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6558), 233673668, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6559) },
                    { 298252180, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5937), 465008903, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5938) },
                    { 375488862, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5953), 494117391, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5954) },
                    { 375488862, 328720238, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5352), 857036294, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5353) },
                    { 327783981, 488519758, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5553), 874848060, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5554) },
                    { 298252180, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6043), 295867110, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6044) },
                    { 327783981, 534765322, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5641), 516449239, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5642) },
                    { 298252180, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6406), 416047602, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6408) },
                    { 298252180, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5999), 603488150, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6000) },
                    { 298252180, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5728), 679677697, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5730) },
                    { 440391406, 642224957, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5266), 630762395, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5267) },
                    { 298252180, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6449), 326636009, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6450) },
                    { 298252180, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6364), 255990897, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6365) },
                    { 327783981, 737201795, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5597), 180094050, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5598) },
                    { 298252180, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5818), 997143897, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5819) },
                    { 298252180, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6233), 163617549, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6234) },
                    { 260751443, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6573), 168610461, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6574) },
                    { 298252180, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6133), 839509218, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6134) },
                    { 298252180, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6277), 658253900, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6278) },
                    { 260751443, 963394930, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5446), 386419159, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5447) },
                    { 260751443, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6541), 172190860, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6543) },
                    { 298252180, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5686), 990474916, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(5688) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1537837520, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7290), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7291), 333654279, 180585988, null },
                    { -1286801272, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7347), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7348), 586391448, 425864070, null },
                    { -1264455928, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7361), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7362), 586391448, 292451943, null },
                    { -624824368, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7255), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7257), 333654279, 765954117, null },
                    { -411142496, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7431), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7432), 517611368, 857271500, null },
                    { -341178056, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7333), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7334), 984128545, 435665107, null },
                    { 112251488, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7403), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7405), 923783563, 167058877, null },
                    { 1196909568, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7304), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7305), 984128545, 954575940, null },
                    { 1250437616, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7276), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7277), 333654279, 488715815, null },
                    { 1636190096, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7318), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7319), 984128545, 730180695, null },
                    { 1751108120, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7390), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7391), 923783563, 425864070, null },
                    { 1866591760, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7417), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7418), 923783563, 488715815, null },
                    { 2065252888, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7374), 0f, 500L, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7375), 586391448, 463232793, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 219188080, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6783), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6785), 3100.0, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6784), "Signature 142346", 11554, 984128545, 2.0, 24.0 },
                    { 423916063, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6699), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6701), 3010.0, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6700), "Signature 142342", 84270, 333654279, 1.0, 17.0 },
                    { 443387168, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6942), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6944), 13000.0, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6943), "Signature 142344", 44682, 923783563, 4.0, 24.0 },
                    { 923475511, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6866), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6869), 4000.0, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6868), "Signature 142346", 12174, 586391448, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 984128545, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8967), 677724891, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8968) },
                    { 586391448, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8980), 873103085, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8981) },
                    { 333654279, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8949), 181294582, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8950) },
                    { 923783563, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8993), 907079359, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8995) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 605169479, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6650), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6651), null, "6949277781", null, null, 333654279, "alexpl_{i}@gmail.com" },
                    { 815409472, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6901), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6902), null, "6949277784", null, null, 923783563, "alexpl_{i}@gmail.com" },
                    { 874371953, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6821), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6822), null, "6949277783", null, null, 586391448, "alexpl_{i}@gmail.com" },
                    { 911882015, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6742), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6743), null, "6949277782", null, null, 984128545, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1537837520, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9546), 933422288, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9547) },
                    { -1537837520, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9654), 321950987, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9656) },
                    { -1537837520, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9519), 794086445, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9521) },
                    { -1537837520, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9602), 302508201, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9603) },
                    { -1537837520, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9559), 894148387, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9560) },
                    { -1537837520, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9588), 849069817, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9589) },
                    { -1537837520, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9681), 682305337, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9682) },
                    { -1537837520, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9572), 578557044, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9573) },
                    { -1537837520, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9506), 855786258, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9507) },
                    { -1537837520, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9694), 291886928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9695) },
                    { -1537837520, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9668), 716688082, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9669) },
                    { -1537837520, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9533), 501602872, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9534) },
                    { -1537837520, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9628), 319893639, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9629) },
                    { -1537837520, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9615), 959504903, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9616) },
                    { -1537837520, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9641), 135973941, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9642) },
                    { -1537837520, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9491), 585164889, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9493) },
                    { -1286801272, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(401), 181660389, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(402) },
                    { -1286801272, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(507), 420207963, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(508) },
                    { -1286801272, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(374), 853344815, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(376) },
                    { -1286801272, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(454), 346583885, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(455) },
                    { -1286801272, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(414), 241977007, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(415) },
                    { -1286801272, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(441), 302799315, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(442) },
                    { -1286801272, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(533), 364511728, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(534) },
                    { -1286801272, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(427), 132477694, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(429) },
                    { -1286801272, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(361), 403327646, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(362) },
                    { -1286801272, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(546), 347272608, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(548) },
                    { -1286801272, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(520), 863658668, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(521) },
                    { -1286801272, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(388), 909615054, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(389) },
                    { -1286801272, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(480), 223840824, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(481) },
                    { -1286801272, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(467), 708785986, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(468) },
                    { -1286801272, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(493), 891715815, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(494) },
                    { -1286801272, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(348), 366869698, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(349) },
                    { -1264455928, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(613), 155986395, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(614) },
                    { -1264455928, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(720), 344407745, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(721) },
                    { -1264455928, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(586), 765299468, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(588) },
                    { -1264455928, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(667), 776915248, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(668) },
                    { -1264455928, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(626), 965783178, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(627) },
                    { -1264455928, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(654), 433406694, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(655) },
                    { -1264455928, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(746), 744194411, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(747) },
                    { -1264455928, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(640), 987191293, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(641) },
                    { -1264455928, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(573), 716046013, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(575) },
                    { -1264455928, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(762), 484825332, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(763) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1264455928, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(733), 789247827, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(734) },
                    { -1264455928, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(600), 865067650, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(601) },
                    { -1264455928, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(693), 579280636, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(695) },
                    { -1264455928, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(680), 982962970, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(682) },
                    { -1264455928, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(707), 699709587, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(708) },
                    { -1264455928, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(560), 627463932, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(561) },
                    { -624824368, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9067), 881227077, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9068) },
                    { -624824368, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9224), 128998064, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9225) },
                    { -624824368, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9040), 503232049, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9041) },
                    { -624824368, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9121), 464275238, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9123) },
                    { -624824368, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9081), 250826609, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9082) },
                    { -624824368, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9108), 453951644, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9109) },
                    { -624824368, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9251), 645860607, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9252) },
                    { -624824368, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9095), 952608810, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9096) },
                    { -624824368, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9027), 900339764, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9028) },
                    { -624824368, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9264), 334014383, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9265) },
                    { -624824368, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9237), 797037942, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9238) },
                    { -624824368, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9054), 461874318, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9055) },
                    { -624824368, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9193), 692511600, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9194) },
                    { -624824368, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9178), 764536745, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9179) },
                    { -624824368, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9210), 977163723, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9211) },
                    { -624824368, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9008), 464581155, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9009) },
                    { -341178056, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(187), 352565252, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(189) },
                    { -341178056, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(293), 617577803, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(294) },
                    { -341178056, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(161), 432616303, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(162) },
                    { -341178056, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(240), 845095283, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(242) },
                    { -341178056, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(201), 518833104, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(202) },
                    { -341178056, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(227), 609694486, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(228) },
                    { -341178056, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(319), 418022463, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(320) },
                    { -341178056, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(214), 693274235, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(215) },
                    { -341178056, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(148), 361673061, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(149) },
                    { -341178056, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(332), 245851091, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(333) },
                    { -341178056, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(306), 219216371, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(307) },
                    { -341178056, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(174), 642170210, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(175) },
                    { -341178056, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(267), 788688520, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(268) },
                    { -341178056, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(253), 665890370, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(255) },
                    { -341178056, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(280), 218411928, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(281) },
                    { -341178056, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(135), 145864482, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(136) },
                    { 112251488, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1265), 745920897, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1266) },
                    { 112251488, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1371), 485779405, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1372) },
                    { 112251488, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1239), 967694324, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1240) },
                    { 112251488, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1318), 861262640, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1319) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 112251488, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1278), 337259111, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1279) },
                    { 112251488, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1305), 957287621, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1306) },
                    { 112251488, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1398), 795820917, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1399) },
                    { 112251488, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1292), 735417789, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1293) },
                    { 112251488, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1225), 928903507, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1226) },
                    { 112251488, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1411), 584087743, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1412) },
                    { 112251488, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1384), 895609766, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1386) },
                    { 112251488, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1252), 994319471, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1253) },
                    { 112251488, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1345), 393857061, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1346) },
                    { 112251488, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1331), 529610721, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1332) },
                    { 112251488, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1358), 484702897, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1359) },
                    { 112251488, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1212), 790629173, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1213) },
                    { 1196909568, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9760), 625539005, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9761) },
                    { 1196909568, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9866), 741874712, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9868) },
                    { 1196909568, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9734), 376485585, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9735) },
                    { 1196909568, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9813), 946707241, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9815) },
                    { 1196909568, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9773), 732802873, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9774) },
                    { 1196909568, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9800), 970153986, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9801) },
                    { 1196909568, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9893), 888776266, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9894) },
                    { 1196909568, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9786), 627482908, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9788) },
                    { 1196909568, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9720), 848637832, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9722) },
                    { 1196909568, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9906), 456725211, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9907) },
                    { 1196909568, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9880), 957649327, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9881) },
                    { 1196909568, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9747), 329339162, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9748) },
                    { 1196909568, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9840), 383145872, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9841) },
                    { 1196909568, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9827), 285920790, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9828) },
                    { 1196909568, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9853), 239790052, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9855) },
                    { 1196909568, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9707), 329151628, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9708) },
                    { 1250437616, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9331), 294529759, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9333) },
                    { 1250437616, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9437), 199936916, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9439) },
                    { 1250437616, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9305), 426886339, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9306) },
                    { 1250437616, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9384), 847083639, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9385) },
                    { 1250437616, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9344), 728945173, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9346) },
                    { 1250437616, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9371), 939883697, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9372) },
                    { 1250437616, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9465), 800078923, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9466) },
                    { 1250437616, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9358), 498751692, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9359) },
                    { 1250437616, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9292), 518572673, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9293) },
                    { 1250437616, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9478), 461154711, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9479) },
                    { 1250437616, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9452), 865465601, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9453) },
                    { 1250437616, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9318), 474479265, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9320) },
                    { 1250437616, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9411), 959110496, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9412) },
                    { 1250437616, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9398), 356523262, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9399) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1250437616, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9424), 143200851, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9425) },
                    { 1250437616, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9278), 753264401, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9279) },
                    { 1636190096, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9976), 194902544, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9977) },
                    { 1636190096, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(82), 272481213, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(83) },
                    { 1636190096, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9949), 187462216, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9950) },
                    { 1636190096, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(29), 789634130, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(30) },
                    { 1636190096, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9989), 728958862, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9990) },
                    { 1636190096, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(16), 721555233, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(17) },
                    { 1636190096, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(108), 729024475, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(109) },
                    { 1636190096, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(2), 691504744, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(3) },
                    { 1636190096, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9933), 294773120, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9934) },
                    { 1636190096, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(121), 980876724, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(122) },
                    { 1636190096, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(95), 270832968, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(96) },
                    { 1636190096, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9962), 605773196, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9964) },
                    { 1636190096, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(55), 663118468, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(56) },
                    { 1636190096, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(42), 374486843, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(43) },
                    { 1636190096, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(69), 200893374, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(70) },
                    { 1636190096, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9919), 600267821, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(9920) },
                    { 1751108120, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1050), 483552115, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1051) },
                    { 1751108120, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1159), 942400795, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1160) },
                    { 1751108120, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1024), 408198829, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1025) },
                    { 1751108120, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1105), 754392012, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1106) },
                    { 1751108120, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1063), 708181509, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1065) },
                    { 1751108120, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1092), 373177823, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1093) },
                    { 1751108120, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1186), 955497963, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1187) },
                    { 1751108120, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1079), 833564298, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1080) },
                    { 1751108120, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1010), 466658933, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1011) },
                    { 1751108120, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1199), 899990256, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1200) },
                    { 1751108120, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1172), 521055803, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1173) },
                    { 1751108120, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1037), 747051127, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1038) },
                    { 1751108120, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1133), 673267521, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1134) },
                    { 1751108120, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1119), 340514681, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1120) },
                    { 1751108120, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1146), 937376532, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1147) },
                    { 1751108120, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(997), 129173211, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(998) },
                    { 1866591760, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1478), 991292355, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1479) },
                    { 1866591760, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1586), 298736219, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1587) },
                    { 1866591760, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1451), 610165760, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1452) },
                    { 1866591760, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1533), 572628720, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1535) },
                    { 1866591760, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1493), 511203743, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1495) },
                    { 1866591760, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1520), 433257350, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1522) },
                    { 1866591760, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1613), 261227669, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1614) },
                    { 1866591760, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1507), 682805811, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1508) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1866591760, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1438), 711982407, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1439) },
                    { 1866591760, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1626), 818759180, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1627) },
                    { 1866591760, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1599), 554083077, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1600) },
                    { 1866591760, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1465), 802016005, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1466) },
                    { 1866591760, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1560), 393837742, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1561) },
                    { 1866591760, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1547), 710349752, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1548) },
                    { 1866591760, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1573), 497742791, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1574) },
                    { 1866591760, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1424), 959169344, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(1425) },
                    { 2065252888, 167139560, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(838), 450918626, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(840) },
                    { 2065252888, 199316113, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(944), 310432180, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(945) },
                    { 2065252888, 232919948, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(811), 303430602, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(812) },
                    { 2065252888, 245548035, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(891), 609375132, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(892) },
                    { 2065252888, 319618752, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(852), 755043164, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(853) },
                    { 2065252888, 533706200, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(878), 157707215, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(879) },
                    { 2065252888, 535552236, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(970), 285509243, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(971) },
                    { 2065252888, 551965690, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(865), 188128549, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(866) },
                    { 2065252888, 619972813, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(790), 861844683, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(791) },
                    { 2065252888, 682657649, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(983), 858677131, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(984) },
                    { 2065252888, 706702778, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(957), 992250936, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(958) },
                    { 2065252888, 776723462, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(825), 668886687, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(826) },
                    { 2065252888, 793607774, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(917), 467730721, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(918) },
                    { 2065252888, 899274211, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(904), 615294273, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(905) },
                    { 2065252888, 903271620, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(931), 984838504, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(932) },
                    { 2065252888, 982185375, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(775), 332688023, new DateTime(2024, 3, 14, 14, 30, 28, 11, DateTimeKind.Local).AddTicks(776) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 127891649, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7686), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7683), 1636190096, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7684), 987470756 },
                    { 132330006, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7588), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7585), -1537837520, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7586), 253603156 },
                    { 139710717, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7672), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7670), 1636190096, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7671), 253603156 },
                    { 183455275, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7926), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7923), 112251488, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7925), 253603156 },
                    { 254206818, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7799), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7796), -1264455928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7798), 253603156 },
                    { 297886696, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7771), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7768), -1286801272, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7769), 987470756 },
                    { 306121269, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7558), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7556), 1250437616, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7557), 987470756 },
                    { 310950481, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7658), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7656), 1196909568, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7657), 671086288 },
                    { 331560501, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7826), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7824), -1264455928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7825), 671086288 },
                    { 347142398, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7630), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7628), 1196909568, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7629), 253603156 },
                    { 376255634, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7497), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7494), -624824368, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7495), 253603156 },
                    { 382042113, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7969), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7967), 1866591760, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7968), 253603156 },
                    { 396218316, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7644), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7642), 1196909568, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7643), 987470756 },
                    { 400490566, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7871), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7869), 2065252888, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7870), 671086288 },
                    { 417119154, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8026), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8024), -411142496, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8025), 987470756 },
                    { 425260152, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7813), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7810), -1264455928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7811), 987470756 },
                    { 433389256, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7954), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7951), 112251488, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7953), 671086288 },
                    { 553721227, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8012), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8009), -411142496, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8010), 253603156 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 565559108, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7885), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7882), 1751108120, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7883), 253603156 },
                    { 571501097, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7727), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7725), -341178056, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7726), 987470756 },
                    { 611736731, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7857), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7855), 2065252888, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7856), 987470756 },
                    { 639171011, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7983), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7981), 1866591760, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7982), 987470756 },
                    { 643266544, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7912), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7909), 1751108120, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7911), 671086288 },
                    { 662435373, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7700), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7697), 1636190096, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7698), 671086288 },
                    { 706252514, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7785), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7783), -1286801272, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7784), 671086288 },
                    { 722705246, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7574), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7571), 1250437616, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7572), 671086288 },
                    { 728981100, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7602), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7599), -1537837520, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7600), 987470756 },
                    { 781236171, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7898), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7896), 1751108120, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7897), 987470756 },
                    { 801785457, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7615), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7613), -1537837520, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7614), 671086288 },
                    { 805601417, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7939), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7937), 112251488, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7938), 987470756 },
                    { 806113756, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7713), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7711), -341178056, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7712), 253603156 },
                    { 855535966, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7545), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7542), 1250437616, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7543), 253603156 },
                    { 875252810, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7516), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7514), -624824368, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7515), 987470756 },
                    { 917573570, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7531), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7528), -624824368, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7529), 671086288 },
                    { 935730649, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7843), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7841), 2065252888, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7842), 253603156 },
                    { 956283222, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7757), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7755), -1286801272, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7756), 253603156 },
                    { 956687468, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8041), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8038), -411142496, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8039), 671086288 },
                    { 972424019, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7997), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7994), 1866591760, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7995), 671086288 },
                    { 975497511, new DateTime(2024, 3, 25, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7743), 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7741), -341178056, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(7742), 671086288 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 452915752, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6916), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6917), 815409472 },
                    { 481502971, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6839), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6840), 874371953 },
                    { 628930531, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6756), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6758), 911882015 },
                    { 765246398, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6669), new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6670), 605169479 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 166734984, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8609), -1264455928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8610), 690142586 },
                    { 176511913, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8909), -411142496, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8910), 649556535 },
                    { 184101466, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8769), 112251488, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8770), 318623841 },
                    { 198900020, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8845), 1866591760, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8846), 649556535 },
                    { 208440837, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8498), -341178056, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8499), 437394989 },
                    { 218462259, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8869), 1866591760, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8870), 437394989 },
                    { 237451706, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8334), 1196909568, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8335), 318623841 },
                    { 237506620, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8707), 1751108120, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8708), 318623841 },
                    { 240794276, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8310), -1537837520, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8311), 437394989 },
                    { 280702243, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8298), -1537837520, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8300), 690142586 },
                    { 282028973, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8857), 1866591760, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8858), 690142586 },
                    { 304344030, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8384), 1636190096, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8385), 184411881 },
                    { 312468510, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8597), -1264455928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8598), 649556535 },
                    { 327512899, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8896), -411142496, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8897), 318623841 },
                    { 334940832, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8756), 112251488, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8757), 184411881 },
                    { 346188024, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8482), -341178056, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8484), 690142586 },
                    { 350777390, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8434), 1636190096, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8435), 437394989 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 353744762, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8658), 2065252888, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8659), 649556535 },
                    { 357165530, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8360), 1196909568, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8361), 690142586 },
                    { 359464609, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8396), 1636190096, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8398), 318623841 },
                    { 377650920, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8833), 1866591760, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8834), 318623841 },
                    { 404751629, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8274), -1537837520, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8275), 318623841 },
                    { 413434800, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8372), 1196909568, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8373), 437394989 },
                    { 417125408, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8744), 1751108120, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8745), 437394989 },
                    { 435849414, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8682), 2065252888, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8683), 437394989 },
                    { 444485593, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8572), -1264455928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8574), 184411881 },
                    { 449472294, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8458), -341178056, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8459), 318623841 },
                    { 485555791, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8224), 1250437616, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8225), 649556535 },
                    { 498000803, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8199), 1250437616, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8201), 184411881 },
                    { 520011460, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8732), 1751108120, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8733), 690142586 },
                    { 556712283, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8793), 112251488, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8794), 690142586 },
                    { 575168547, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8129), -624824368, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8130), 184411881 },
                    { 577617650, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8237), 1250437616, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8238), 690142586 },
                    { 591484049, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8535), -1286801272, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8536), 649556535 },
                    { 606367116, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8560), -1286801272, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8561), 437394989 },
                    { 629691555, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8348), 1196909568, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8349), 649556535 },
                    { 632149103, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8621), -1264455928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8622), 437394989 },
                    { 637491366, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8820), 1866591760, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8821), 184411881 },
                    { 639328142, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8250), 1250437616, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8251), 437394989 },
                    { 641850615, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8645), 2065252888, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8647), 318623841 },
                    { 652246612, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8186), -624824368, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8187), 437394989 },
                    { 667040885, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8883), -411142496, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8884), 184411881 },
                    { 699890854, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8695), 1751108120, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8696), 184411881 },
                    { 737041471, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8322), 1196909568, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8323), 184411881 },
                    { 757827359, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8422), 1636190096, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8423), 690142586 },
                    { 764647248, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8805), 112251488, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8806), 437394989 },
                    { 777720666, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8933), -411142496, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8934), 437394989 },
                    { 783660678, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8174), -624824368, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8175), 690142586 },
                    { 791642638, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8146), -624824368, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8147), 318623841 },
                    { 801530606, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8409), 1636190096, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8410), 649556535 },
                    { 806759746, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8446), -341178056, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8447), 184411881 },
                    { 829429730, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8781), 112251488, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8782), 649556535 },
                    { 847172979, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8670), 2065252888, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8671), 690142586 },
                    { 853262266, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8212), 1250437616, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8213), 318623841 },
                    { 859618107, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8161), -624824368, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8163), 649556535 },
                    { 860613748, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8510), -1286801272, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8512), 184411881 },
                    { 877636235, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8286), -1537837520, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8287), 649556535 },
                    { 886259537, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8585), -1264455928, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8586), 318623841 },
                    { 889155274, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8921), -411142496, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8922), 690142586 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 901576465, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8262), -1537837520, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8263), 184411881 },
                    { 927111493, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8633), 2065252888, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8635), 184411881 },
                    { 939548564, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8523), -1286801272, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8524), 318623841 },
                    { 973356928, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8719), 1751108120, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8720), 649556535 },
                    { 973490057, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8470), -341178056, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8471), 649556535 },
                    { 978877583, 0f, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8548), -1286801272, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(8549), 690142586 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 398735260, 605169479, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6683), 936195457, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6684) },
                    { 398735260, 815409472, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6929), 646346918, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6930) },
                    { 398735260, 874371953, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6853), 403069801, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6854) },
                    { 398735260, 911882015, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6770), 458728072, new DateTime(2024, 3, 14, 14, 30, 28, 10, DateTimeKind.Local).AddTicks(6771) }
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
                name: "IX_Emails_UserId",
                table: "Emails",
                column: "UserId");

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
                name: "FK_Emails_Users_UserId",
                table: "Emails",
                column: "UserId",
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
                name: "Emails");

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
