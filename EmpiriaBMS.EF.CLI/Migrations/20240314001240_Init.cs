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
                    { 189478766, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4223), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4224), "Energy Efficiency" },
                    { 201402965, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4197), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4199), "BMS" },
                    { 204983649, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4037), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4038), "HVAC" },
                    { 270565608, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4133), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4134), "Natural Gas" },
                    { 318555422, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4160), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4161), "Structured Cabling" },
                    { 388924886, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4265), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4266), "Construction Supervision" },
                    { 525395979, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4120), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4122), "Elevators" },
                    { 543960287, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4210), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4211), "Photovoltaics" },
                    { 572605760, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4108), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4109), "Fire Suppression" },
                    { 589470587, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4251), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4252), "TenderDocument" },
                    { 592570956, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4238), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4239), "Outsource" },
                    { 603817639, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4185), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4186), "CCTV" },
                    { 609813659, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4172), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4173), "Burglar Alarm" },
                    { 619792133, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4146), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4147), "Power Distribution" },
                    { 674762384, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4278), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4279), "Project Manager Hours" },
                    { 709211382, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4069), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4070), "Potable Water" },
                    { 725503281, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4055), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4056), "Sewage" },
                    { 886427736, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4094), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4095), "Fire Detection" },
                    { 923781386, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4081), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4082), "Drainage" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 224267375, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4537), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4538), "Drawings" },
                    { 447909176, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4523), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4524), "Calculations" },
                    { 874974953, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4502), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4504), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 277411914, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5153), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5154), "Printing" },
                    { 329697275, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5179), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5180), "Meetings" },
                    { 358607375, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5132), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5134), "Communications" },
                    { 623407158, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5166), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5167), "On-Site" },
                    { 649294520, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5192), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5193), "Administration" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 153675072, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1240), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1241), "See Admin Layout", 7 },
                    { 170879316, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1304), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1305), "See All Projects", 11 },
                    { 363108466, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1160), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1161), "Dashboard Edit My Hours", 2 },
                    { 388080288, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1064), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1065), "See Dashboard Layout", 1 },
                    { 399638947, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1274), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1275), "See All Disciplines", 9 },
                    { 436235538, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1254), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1255), "Dashboard See My Hours", 8 },
                    { 486968497, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1178), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1179), "Dashboard Assign Designer", 3 },
                    { 603668625, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1289), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1290), "See All Drawings", 10 },
                    { 694927360, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1193), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1194), "Dashboard Assign Engineer", 4 },
                    { 698799626, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1223), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1225), "Dashboard Add Project", 6 },
                    { 957214227, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1207), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1208), "Dashboard Assign Project Manager", 5 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 196566488, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3545), "Consulting Description", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3546), "Consulting" },
                    { 366302050, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3517), "Infrastructure Description", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3518), "Infrastructure" },
                    { 505520847, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3559), "Production Management Description", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3560), "Production Management" },
                    { 684707247, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3531), "Energy Description", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3533), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { 802011338, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3499), "Buildings Description", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3500), "Buildings" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1371), false, true, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1373), "COO" },
                    { 229853532, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1342), false, true, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1343), "Engineer" },
                    { 369288185, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1357), false, true, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1358), "Project Manager" },
                    { 425780332, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1386), false, true, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1387), "CTO" },
                    { 565014817, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1458), false, false, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1460), "Secretariat" },
                    { 577983370, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1416), false, false, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1417), "Guest" },
                    { 662618234, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1429), false, false, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1431), "Customer" },
                    { 686559720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1443), false, false, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1444), "Admin" },
                    { 838268161, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1318), false, true, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1320), "Designer" },
                    { 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1401), false, true, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1402), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 123517329, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2704), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2706), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 210011692, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2326), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2328), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 222812399, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2659), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2660), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 268281117, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2507), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2509), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3099), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3100), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2997), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2998), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2791), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2792), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2880), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2881), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 657935898, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2457), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2458), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2924), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2925), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 731438054, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2371), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2373), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3142), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3144), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3455), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3456), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3234), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3235), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3366), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3367), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 832186174, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2270), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2271), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3279), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3280), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3323), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3324), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2834), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2835), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 882171667, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2552), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2553), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3409), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3410), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 912863571, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2414), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2416), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3055), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3056), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2747), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2748), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 945368675, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2612), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2613), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3191), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3192), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 161844235, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2290), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2292), 832186174 },
                    { 180115236, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3294), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3295), 853299930 },
                    { 182960724, "gdoug@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2629), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2630), 945368675 },
                    { 268431947, "kkotsoni@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3012), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3013), 381293112 },
                    { 319416671, "vchontos@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3381), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3382), 831710239 },
                    { 345836475, "guest@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2474), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2475), 657935898 },
                    { 359092727, "pm@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2522), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2523), 268281117 },
                    { 383322673, "xmanarolis@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2805), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2807), 393607841 },
                    { 445469244, "sparisis@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2852), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2853), 866067207 },
                    { 464780862, "kmargeti@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3158), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3159), 769262507 },
                    { 468290686, "vpax@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2763), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2764), 920888565 },
                    { 480188463, "ngal@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2939), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2941), 712371163 },
                    { 481670959, "panperivollari@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3425), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3426), 910410109 },
                    { 485668012, "chkovras@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2895), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2896), 561197579 },
                    { 497670089, "blekou@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3338), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3339), 854521939 },
                    { 597261459, "agretos@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3114), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3115), 337130841 },
                    { 601970715, "vtza@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3071), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3072), 914853709 },
                    { 620033474, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2583), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2584), 882171667 },
                    { 657219842, "haris@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3206), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3207), 995229897 },
                    { 777168841, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2719), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2720), 123517329 },
                    { 795410362, "embiria@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2569), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2570), 882171667 },
                    { 821197897, "coo@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2429), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2430), 912863571 },
                    { 825714985, "ceo@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2342), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2344), 210011692 },
                    { 839683833, "pfokianou@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3249), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3250), 799541395 },
                    { 865519666, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2675), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2676), 222812399 },
                    { 870614733, "cto@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2386), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2387), 731438054 },
                    { 979034696, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3470), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3471), 775559061 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 141754212, "ALPHA", 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 111.0, 90, new DateTime(2024, 6, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 1, "Test Description Project_PM", new DateTime(2024, 4, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), new DateTime(2024, 5, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Project_PM", 45.0, new DateTime(2024, 4, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Payment Detailes For Project_PM", 2.0, null, 505520847, new DateTime(2024, 5, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f },
                    { 211343731, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 8.0, 9, new DateTime(2024, 12, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 9, "Test Description Project_3", new DateTime(2024, 12, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), new DateTime(2024, 12, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Project_3", 5.0, new DateTime(2024, 12, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Payment Detailes For Project_6", 3.0, null, 684707247, new DateTime(2024, 12, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f },
                    { 275514402, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 9.0, 16, new DateTime(2025, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 16, "Test Description Project_16", new DateTime(2025, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), new DateTime(2025, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Project_4", 5.0, new DateTime(2025, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Payment Detailes For Project_24", 4.0, null, 196566488, new DateTime(2025, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f },
                    { 632663490, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 6.0, 1, new DateTime(2024, 4, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 1, "Test Description Project_1", new DateTime(2024, 4, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), new DateTime(2024, 4, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Project_1", 5.0, new DateTime(2024, 4, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Payment Detailes For Project_2", 1.0, null, 802011338, new DateTime(2024, 4, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f },
                    { 782675065, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 7.0, 4, new DateTime(2024, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 4, "Test Description Project_4", new DateTime(2024, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), new DateTime(2024, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Project_2", 5.0, new DateTime(2024, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), "Payment Detailes For Project_10", 2.0, null, 366302050, new DateTime(2024, 7, 14, 2, 12, 40, 495, DateTimeKind.Local).AddTicks(8929), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 170879316, 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1826), 1679160735, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1827) },
                    { 363108466, 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1714), -1015211060, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1715) },
                    { 388080288, 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1700), -883306183, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1701) },
                    { 399638947, 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1798), -1419133265, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1799) },
                    { 436235538, 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1783), 409747528, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1785) },
                    { 486968497, 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1729), 32260955, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1731) },
                    { 603668625, 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1812), -1217874397, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1813) },
                    { 694927360, 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1744), 99620879, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1745) },
                    { 957214227, 221253828, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1758), 1755947016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1759) },
                    { 363108466, 229853532, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1538), -1354143482, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1539) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 388080288, 229853532, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1524), 1904696541, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1525) },
                    { 399638947, 229853532, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1582), -683503343, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1583) },
                    { 436235538, 229853532, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1568), -1071871024, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1569) },
                    { 486968497, 229853532, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1553), 520252394, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1554) },
                    { 603668625, 229853532, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1595), 1794556674, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1597) },
                    { 363108466, 369288185, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1625), -722218288, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1626) },
                    { 388080288, 369288185, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1610), -509015609, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1612) },
                    { 399638947, 369288185, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1668), -934705664, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1669) },
                    { 436235538, 369288185, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1653), -1390848844, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1654) },
                    { 603668625, 369288185, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1686), 1241857868, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1687) },
                    { 694927360, 369288185, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1639), 710776994, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1640) },
                    { 170879316, 425780332, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1939), -1302261020, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1940) },
                    { 363108466, 425780332, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1854), -1629177502, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1856) },
                    { 388080288, 425780332, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1840), -1452929701, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1841) },
                    { 399638947, 425780332, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1911), 1999636079, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1912) },
                    { 436235538, 425780332, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1897), -52879922, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1898) },
                    { 603668625, 425780332, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1925), -1698177806, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1926) },
                    { 698799626, 425780332, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1883), 2132899407, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1884) },
                    { 957214227, 425780332, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1869), -2075573794, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1870) },
                    { 170879316, 565014817, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2255), -675672866, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2256) },
                    { 363108466, 565014817, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2198), 1490934308, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2200) },
                    { 388080288, 565014817, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2184), -1745566856, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2185) },
                    { 399638947, 565014817, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2227), 813598565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2228) },
                    { 436235538, 565014817, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2213), 741686756, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2214) },
                    { 603668625, 565014817, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2241), -689785298, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2242) },
                    { 388080288, 577983370, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2099), 672386738, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2100) },
                    { 388080288, 662618234, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2114), -1752480499, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2115) },
                    { 153675072, 686559720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2128), 1322057336, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2129) },
                    { 170879316, 686559720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2170), 1709625209, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2171) },
                    { 399638947, 686559720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2142), -2133932561, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2143) },
                    { 603668625, 686559720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2156), 260951054, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2157) },
                    { 363108466, 838268161, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1495), 1532499746, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1496) },
                    { 388080288, 838268161, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1473), 1260303714, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1474) },
                    { 436235538, 838268161, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1510), 214519046, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1511) },
                    { 153675072, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2040), -271035130, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2041) },
                    { 170879316, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2082), -2069905954, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2083) },
                    { 363108466, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1968), 1817676968, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1970) },
                    { 388080288, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1953), -1206138748, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1954) },
                    { 399638947, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2054), -987160841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2055) },
                    { 486968497, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1982), -849222634, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1983) },
                    { 603668625, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2068), 2062055646, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2069) },
                    { 694927360, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1996), -84319550, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(1997) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 698799626, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2026), 929785505, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2027) },
                    { 957214227, 838324563, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2011), 1859443790, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2012) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 838268161, 123517329, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2733), 220909487, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2734) },
                    { 838324563, 210011692, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2357), 463049128, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2358) },
                    { 838268161, 222812399, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2689), 596608454, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2690) },
                    { 369288185, 268281117, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2536), 895088395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2537) },
                    { 229853532, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3128), 373862880, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3129) },
                    { 221253828, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3041), 704311840, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3042) },
                    { 229853532, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3027), 550368895, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3028) },
                    { 369288185, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3595), 191873920, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3596) },
                    { 229853532, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2819), 678688124, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2821) },
                    { 229853532, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2909), 421871854, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2910) },
                    { 577983370, 657935898, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2492), 942227505, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2493) },
                    { 229853532, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2953), 806932339, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2954) },
                    { 686559720, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2967), 352754104, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2969) },
                    { 838324563, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2982), 342666607, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2983) },
                    { 425780332, 731438054, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2400), 952210424, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2401) },
                    { 229853532, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3172), 394590121, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3173) },
                    { 229853532, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3484), 665173910, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3485) },
                    { 229853532, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3264), 458153909, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3265) },
                    { 229853532, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3395), 318692937, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3396) },
                    { 686559720, 832186174, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2309), 703766223, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2310) },
                    { 229853532, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3309), 693483848, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3310) },
                    { 229853532, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3351), 994733029, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3353) },
                    { 229853532, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2866), 534996987, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2867) },
                    { 565014817, 882171667, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2596), 532723925, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2598) },
                    { 229853532, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3440), 930717600, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3441) },
                    { 221253828, 912863571, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2443), 354545688, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2444) },
                    { 229853532, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3085), 185118898, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3086) },
                    { 229853532, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2777), 692233785, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2778) },
                    { 369288185, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3578), 295461798, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3579) },
                    { 838268161, 945368675, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2644), 855737267, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(2645) },
                    { 229853532, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3220), 908105987, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3221) },
                    { 369288185, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3610), 251766246, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3611) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1742550896, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4487), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4488), 141754212, 674762384, null },
                    { -1171500680, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4389), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4390), 782675065, 201402965, null },
                    { -1152323024, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4416), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4417), 211343731, 886427736, null },
                    { -869515560, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4345), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4347), 632663490, 725503281, null },
                    { -561931536, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4331), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4333), 632663490, 609813659, null },
                    { -314784480, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4446), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4447), 275514402, 189478766, null },
                    { 154853016, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4459), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4460), 275514402, 603817639, null },
                    { 714448976, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4403), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4404), 211343731, 709211382, null },
                    { 991874000, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4430), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4431), 211343731, 572605760, null },
                    { 1003867704, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4473), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4474), 275514402, 709211382, null },
                    { 1324440720, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4373), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4374), 782675065, 603817639, null },
                    { 1439567088, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4360), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4361), 782675065, 923781386, null },
                    { 1447217944, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4310), 0f, 500L, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4312), 632663490, 589470587, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 294113254, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3749), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3752), 3010.0, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3751), "Signature 142346", 84426, 632663490, 1.0, 17.0 },
                    { 459882824, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3996), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3998), 13000.0, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3997), "Signature 1423412", 59319, 275514402, 4.0, 24.0 },
                    { 483597046, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3917), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3919), 4000.0, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3918), "Signature 1423415", 65749, 211343731, 3.0, 17.0 },
                    { 640208642, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3834), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3836), 3100.0, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3835), "Signature 142348", 11227, 782675065, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 782675065, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6041), 384044401, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6042) },
                    { 275514402, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6069), 188383006, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6070) },
                    { 632663490, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6024), 263390963, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6025) },
                    { 211343731, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6055), 882449876, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6056) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 846817880, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3792), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3793), null, "6949277782", null, null, 782675065, "alexpl_{i}@gmail.com" },
                    { 920687051, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3699), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3700), null, "6949277781", null, null, 632663490, "alexpl_{i}@gmail.com" },
                    { 948367074, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3955), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3956), null, "6949277784", null, null, 275514402, "alexpl_{i}@gmail.com" },
                    { 987448409, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3872), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3873), null, "6949277783", null, null, 211343731, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1171500680, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7247), 139536789, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7248) },
                    { -1171500680, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7221), 999744414, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7222) },
                    { -1171500680, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7169), 705377435, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7170) },
                    { -1171500680, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7195), 491476410, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7196) },
                    { -1171500680, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7207), 961320152, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7209) },
                    { -1171500680, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7260), 814169170, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7261) },
                    { -1171500680, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7351), 142700029, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7352) },
                    { -1171500680, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7286), 690997319, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7287) },
                    { -1171500680, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7325), 138015578, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7326) },
                    { -1171500680, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7299), 722108537, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7300) },
                    { -1171500680, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7312), 673947745, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7313) },
                    { -1171500680, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7181), 643703307, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7183) },
                    { -1171500680, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7338), 944620396, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7339) },
                    { -1171500680, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7234), 873129458, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7235) },
                    { -1171500680, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7155), 327127832, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7156) },
                    { -1171500680, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7273), 508608948, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7274) },
                    { -1152323024, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7669), 725611108, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7670) },
                    { -1152323024, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7643), 387710670, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7644) },
                    { -1152323024, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7591), 831529082, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7592) },
                    { -1152323024, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7617), 877100255, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7618) },
                    { -1152323024, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7630), 139639337, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7631) },
                    { -1152323024, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7682), 860274786, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7683) },
                    { -1152323024, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7774), 617365577, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7775) },
                    { -1152323024, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7709), 662701699, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7710) },
                    { -1152323024, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7748), 878173542, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7749) },
                    { -1152323024, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7722), 184694165, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7723) },
                    { -1152323024, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7735), 531793472, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7736) },
                    { -1152323024, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7604), 430634166, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7605) },
                    { -1152323024, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7761), 840668277, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7762) },
                    { -1152323024, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7656), 386371985, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7657) },
                    { -1152323024, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7578), 176316033, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7579) },
                    { -1152323024, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7696), 983069471, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7697) },
                    { -869515560, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6607), 479182349, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6609) },
                    { -869515560, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6581), 496398567, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6582) },
                    { -869515560, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6528), 807517909, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6530) },
                    { -869515560, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6555), 298719337, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6556) },
                    { -869515560, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6568), 551479901, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6569) },
                    { -869515560, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6627), 620564048, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6628) },
                    { -869515560, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6718), 583470484, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6720) },
                    { -869515560, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6654), 966972633, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6655) },
                    { -869515560, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6693), 860241488, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6694) },
                    { -869515560, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6667), 763385944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6668) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -869515560, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6680), 152807596, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6681) },
                    { -869515560, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6542), 240019630, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6543) },
                    { -869515560, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6706), 565678667, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6707) },
                    { -869515560, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6594), 426553603, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6595) },
                    { -869515560, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6514), 454142343, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6515) },
                    { -869515560, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6641), 832625298, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6642) },
                    { -561931536, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6396), 915288952, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6397) },
                    { -561931536, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6369), 623179805, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6370) },
                    { -561931536, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6317), 712852233, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6318) },
                    { -561931536, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6343), 565641001, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6344) },
                    { -561931536, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6356), 303872426, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6357) },
                    { -561931536, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6409), 715214032, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6410) },
                    { -561931536, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6501), 706568947, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6502) },
                    { -561931536, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6435), 301599297, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6436) },
                    { -561931536, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6475), 633565089, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6476) },
                    { -561931536, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6449), 526066207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6450) },
                    { -561931536, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6462), 624576232, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6463) },
                    { -561931536, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6330), 127477021, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6331) },
                    { -561931536, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6488), 815924638, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6489) },
                    { -561931536, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6383), 954843216, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6384) },
                    { -561931536, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6303), 355594948, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6304) },
                    { -561931536, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6422), 506718764, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6423) },
                    { -314784480, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8098), 632369585, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8099) },
                    { -314784480, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8068), 284676407, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8069) },
                    { -314784480, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8016), 602293448, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8017) },
                    { -314784480, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8042), 830387220, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8043) },
                    { -314784480, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8055), 292426051, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8056) },
                    { -314784480, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8111), 629442524, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8112) },
                    { -314784480, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8203), 680947115, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8204) },
                    { -314784480, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8137), 709441074, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8138) },
                    { -314784480, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8177), 495917856, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8178) },
                    { -314784480, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8151), 920966757, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8152) },
                    { -314784480, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8164), 297835039, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8165) },
                    { -314784480, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8029), 218678172, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8030) },
                    { -314784480, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8190), 545059348, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8191) },
                    { -314784480, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8081), 374384478, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8082) },
                    { -314784480, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8002), 606120346, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8004) },
                    { -314784480, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8124), 556279096, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8125) },
                    { 154853016, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8309), 220192343, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8310) },
                    { 154853016, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8283), 857556265, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8284) },
                    { 154853016, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8229), 265705972, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8230) },
                    { 154853016, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8256), 346162411, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8258) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 154853016, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8270), 494835028, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8271) },
                    { 154853016, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8322), 945605997, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8323) },
                    { 154853016, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8415), 788475342, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8416) },
                    { 154853016, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8349), 538379097, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8350) },
                    { 154853016, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8389), 886036743, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8390) },
                    { 154853016, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8362), 971656803, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8363) },
                    { 154853016, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8375), 848194513, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8376) },
                    { 154853016, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8243), 255020832, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8244) },
                    { 154853016, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8402), 227066490, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8403) },
                    { 154853016, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8296), 170371561, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8297) },
                    { 154853016, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8216), 151446954, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8217) },
                    { 154853016, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8335), 954287016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8337) },
                    { 714448976, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7460), 566663680, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7461) },
                    { 714448976, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7434), 764372090, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7435) },
                    { 714448976, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7381), 431750600, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7382) },
                    { 714448976, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7408), 541308351, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7409) },
                    { 714448976, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7421), 254852483, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7422) },
                    { 714448976, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7473), 976115205, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7474) },
                    { 714448976, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7564), 911016330, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7566) },
                    { 714448976, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7499), 151720333, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7500) },
                    { 714448976, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7539), 228135142, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7540) },
                    { 714448976, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7512), 744318944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7513) },
                    { 714448976, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7525), 725526207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7526) },
                    { 714448976, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7394), 866971879, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7396) },
                    { 714448976, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7551), 270558547, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7553) },
                    { 714448976, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7447), 165510081, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7448) },
                    { 714448976, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7364), 799872794, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7365) },
                    { 714448976, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7486), 151311269, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7487) },
                    { 991874000, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7884), 540142041, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7885) },
                    { 991874000, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7857), 814624566, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7858) },
                    { 991874000, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7805), 815999444, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7806) },
                    { 991874000, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7831), 372293414, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7832) },
                    { 991874000, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7844), 916946212, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7845) },
                    { 991874000, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7897), 643812754, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7898) },
                    { 991874000, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7989), 569560794, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7990) },
                    { 991874000, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7923), 537322761, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7924) },
                    { 991874000, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7962), 274405468, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7964) },
                    { 991874000, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7936), 388031481, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7937) },
                    { 991874000, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7949), 604149294, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7950) },
                    { 991874000, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7818), 606541941, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7819) },
                    { 991874000, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7976), 990437872, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7977) },
                    { 991874000, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7871), 679753977, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7872) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 991874000, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7790), 472944002, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7791) },
                    { 991874000, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7910), 870628948, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7911) },
                    { 1003867704, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8564), 568776354, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8566) },
                    { 1003867704, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8515), 303170816, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8517) },
                    { 1003867704, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8442), 692473870, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8443) },
                    { 1003867704, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8468), 527808035, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8471) },
                    { 1003867704, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8493), 661955398, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8495) },
                    { 1003867704, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8586), 346791972, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8588) },
                    { 1003867704, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8724), 805602254, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8725) },
                    { 1003867704, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8634), 198044435, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8636) },
                    { 1003867704, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8698), 640120092, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8699) },
                    { 1003867704, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8657), 728641672, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8659) },
                    { 1003867704, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8679), 627569135, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8681) },
                    { 1003867704, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8455), 939295158, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8456) },
                    { 1003867704, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8711), 194039427, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8712) },
                    { 1003867704, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8542), 445027380, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8544) },
                    { 1003867704, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8429), 467613715, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8430) },
                    { 1003867704, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8610), 486564310, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(8612) },
                    { 1324440720, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7037), 216856046, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7039) },
                    { 1324440720, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7011), 546102117, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7013) },
                    { 1324440720, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6955), 950427981, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6956) },
                    { 1324440720, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6985), 406422695, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6986) },
                    { 1324440720, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6998), 412690678, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6999) },
                    { 1324440720, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7051), 791531262, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7052) },
                    { 1324440720, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7142), 609123173, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7143) },
                    { 1324440720, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7077), 876883927, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7078) },
                    { 1324440720, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7116), 692024128, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7117) },
                    { 1324440720, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7090), 403359548, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7091) },
                    { 1324440720, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7103), 471230598, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7104) },
                    { 1324440720, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6971), 312612576, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6972) },
                    { 1324440720, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7129), 949105662, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7130) },
                    { 1324440720, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7025), 686368878, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7026) },
                    { 1324440720, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6941), 545174444, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6942) },
                    { 1324440720, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7064), 350808191, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(7065) },
                    { 1439567088, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6823), 720478771, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6824) },
                    { 1439567088, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6797), 439718747, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6798) },
                    { 1439567088, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6744), 565021002, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6745) },
                    { 1439567088, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6770), 838978859, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6772) },
                    { 1439567088, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6784), 986380629, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6785) },
                    { 1439567088, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6836), 941567528, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6838) },
                    { 1439567088, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6928), 624716622, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6929) },
                    { 1439567088, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6862), 190668302, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6864) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1439567088, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6902), 444711123, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6903) },
                    { 1439567088, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6876), 346802114, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6877) },
                    { 1439567088, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6889), 282142034, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6890) },
                    { 1439567088, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6757), 995350629, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6758) },
                    { 1439567088, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6915), 176120344, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6916) },
                    { 1439567088, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6810), 560433711, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6811) },
                    { 1439567088, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6731), 556506684, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6733) },
                    { 1439567088, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6849), 766013477, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6850) },
                    { 1447217944, 337130841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6181), 305175173, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6182) },
                    { 1447217944, 381293112, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6155), 703874020, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6156) },
                    { 1447217944, 393607841, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6101), 585410070, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6102) },
                    { 1447217944, 561197579, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6128), 301586599, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6129) },
                    { 1447217944, 712371163, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6141), 354598981, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6142) },
                    { 1447217944, 769262507, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6194), 603175678, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6195) },
                    { 1447217944, 775559061, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6290), 711435915, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6291) },
                    { 1447217944, 799541395, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6221), 526561414, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6222) },
                    { 1447217944, 831710239, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6264), 129061224, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6265) },
                    { 1447217944, 853299930, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6234), 501329527, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6235) },
                    { 1447217944, 854521939, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6251), 958159463, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6252) },
                    { 1447217944, 866067207, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6115), 285635213, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6116) },
                    { 1447217944, 910410109, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6277), 222424545, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6278) },
                    { 1447217944, 914853709, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6168), 895650786, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6169) },
                    { 1447217944, 920888565, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6083), 458254564, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6084) },
                    { 1447217944, 995229897, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6208), 156656876, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6209) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 136238368, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5015), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5013), 154853016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5014), 447909176 },
                    { 136676932, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4752), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4750), 1324440720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4751), 447909176 },
                    { 154268353, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4954), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4952), -314784480, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4953), 874974953 },
                    { 170832066, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4560), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4556), 1447217944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4557), 874974953 },
                    { 184540160, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4940), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4938), 991874000, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4939), 224267375 },
                    { 217438616, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5060), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5058), 1003867704, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5059), 447909176 },
                    { 233792834, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5046), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5043), 1003867704, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5045), 874974953 },
                    { 249424358, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4969), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4966), -314784480, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4967), 447909176 },
                    { 292987735, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4880), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4878), -1152323024, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4879), 447909176 },
                    { 298789798, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4838), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4835), 714448976, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4836), 447909176 },
                    { 300001064, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5074), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5072), 1003867704, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5073), 224267375 },
                    { 317835872, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4580), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4577), 1447217944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4578), 447909176 },
                    { 363733357, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4724), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4722), 1439567088, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4723), 224267375 },
                    { 392248184, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5029), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5027), 154853016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5028), 224267375 },
                    { 432797441, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4824), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4822), 714448976, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4823), 874974953 },
                    { 480221022, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4780), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4778), -1171500680, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4779), 874974953 },
                    { 500544083, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4982), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4980), -314784480, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4981), 224267375 },
                    { 528065121, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5119), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5116), -1742550896, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5118), 224267375 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 549494893, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4894), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4892), -1152323024, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4893), 224267375 },
                    { 553378895, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4697), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4694), 1439567088, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4695), 874974953 },
                    { 554610080, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4594), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4592), 1447217944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4593), 224267375 },
                    { 564739920, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4794), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4792), -1171500680, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4793), 447909176 },
                    { 569408877, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5001), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4999), 154853016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5000), 874974953 },
                    { 575573524, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4711), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4708), 1439567088, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4709), 447909176 },
                    { 603877193, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4609), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4606), -561931536, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4607), 874974953 },
                    { 685309083, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4810), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4807), -1171500680, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4809), 224267375 },
                    { 711551511, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4639), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4636), -561931536, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4637), 224267375 },
                    { 724819763, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4623), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4620), -561931536, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4621), 447909176 },
                    { 759806071, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5089), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5086), -1742550896, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5088), 874974953 },
                    { 770822379, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4653), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4651), -869515560, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4652), 874974953 },
                    { 805550313, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4738), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4736), 1324440720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4737), 874974953 },
                    { 840582165, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4866), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4864), -1152323024, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4865), 874974953 },
                    { 879325237, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4852), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4849), 714448976, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4851), 224267375 },
                    { 887729871, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4681), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4679), -869515560, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4680), 224267375 },
                    { 887914669, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4667), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4665), -869515560, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4666), 447909176 },
                    { 916349059, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4766), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4764), 1324440720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4765), 224267375 },
                    { 940491239, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5104), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5102), -1742550896, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5103), 447909176 },
                    { 941997055, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4912), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4909), 991874000, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4910), 874974953 },
                    { 960721053, new DateTime(2024, 3, 25, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4926), 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4924), 991874000, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(4925), 447909176 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 210455449, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3970), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3971), 948367074 },
                    { 558150575, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3807), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3808), 846817880 },
                    { 817913270, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3718), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3720), 920687051 },
                    { 872366391, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3887), new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3888), 987448409 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 123907395, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5626), 714448976, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5627), 329697275 },
                    { 138015129, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5499), 1324440720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5500), 329697275 },
                    { 138681562, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5663), -1152323024, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5664), 277411914 },
                    { 140081135, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5352), -869515560, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5353), 277411914 },
                    { 142446098, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5808), -314784480, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5810), 329697275 },
                    { 143306069, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5894), 1003867704, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5895), 358607375 },
                    { 145268773, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5303), -561931536, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5304), 623407158 },
                    { 150592968, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5475), 1324440720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5476), 277411914 },
                    { 160017856, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5858), 154853016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5859), 623407158 },
                    { 176811669, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5209), 1447217944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5210), 358607375 },
                    { 182968493, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5450), 1439567088, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5451), 649294520 },
                    { 189697155, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5638), 714448976, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5639), 649294520 },
                    { 191874793, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5973), -1742550896, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5974), 277411914 },
                    { 195211029, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5315), -561931536, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5316), 329697275 },
                    { 196116777, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5388), -869515560, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5389), 649294520 },
                    { 217845926, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5265), 1447217944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5266), 649294520 },
                    { 261738402, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5934), 1003867704, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5935), 329697275 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 276039693, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5821), -314784480, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5822), 649294520 },
                    { 326507462, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5711), 991874000, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5712), 358607375 },
                    { 346149536, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5613), 714448976, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5614), 623407158 },
                    { 349331672, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5687), -1152323024, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5688), 329697275 },
                    { 357276960, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5340), -869515560, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5341), 358607375 },
                    { 369266731, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5845), 154853016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5846), 277411914 },
                    { 390582853, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5736), 991874000, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5737), 623407158 },
                    { 397079365, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5225), 1447217944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5226), 277411914 },
                    { 408342006, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5922), 1003867704, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5923), 623407158 },
                    { 418614164, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5253), 1447217944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5254), 329697275 },
                    { 462696156, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5438), 1439567088, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5439), 329697275 },
                    { 463279294, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5772), -314784480, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5773), 358607375 },
                    { 471575611, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5748), 991874000, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5749), 329697275 },
                    { 488652362, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5572), -1171500680, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5573), 649294520 },
                    { 498747381, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5724), 991874000, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5725), 277411914 },
                    { 499576293, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5487), 1324440720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5488), 623407158 },
                    { 508222734, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5291), -561931536, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5292), 277411914 },
                    { 508897678, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5511), 1324440720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5512), 649294520 },
                    { 531938195, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5998), -1742550896, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5999), 329697275 },
                    { 532958187, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5946), 1003867704, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5947), 649294520 },
                    { 547734738, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5882), 154853016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5883), 649294520 },
                    { 596234829, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5413), 1439567088, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5414), 277411914 },
                    { 616602393, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5364), -869515560, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5365), 623407158 },
                    { 626849669, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5376), -869515560, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5377), 329697275 },
                    { 674545130, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5589), 714448976, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5590), 358607375 },
                    { 689469857, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5797), -314784480, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5798), 623407158 },
                    { 690736308, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5426), 1439567088, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5427), 623407158 },
                    { 738025832, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5559), -1171500680, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5561), 329697275 },
                    { 762394687, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5523), -1171500680, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5524), 358607375 },
                    { 770581591, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5699), -1152323024, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5700), 649294520 },
                    { 775488310, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5675), -1152323024, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5676), 623407158 },
                    { 778985769, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5462), 1324440720, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5463), 358607375 },
                    { 794748267, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5760), 991874000, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5761), 649294520 },
                    { 825769391, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5278), -561931536, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5279), 358607375 },
                    { 852920605, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5650), -1152323024, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5652), 358607375 },
                    { 857280626, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5601), 714448976, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5602), 277411914 },
                    { 858786672, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5327), -561931536, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5329), 649294520 },
                    { 879885809, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5237), 1447217944, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5238), 623407158 },
                    { 885809393, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5910), 1003867704, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5911), 277411914 },
                    { 893769897, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5870), 154853016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5871), 329697275 },
                    { 897663735, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5535), -1171500680, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5536), 277411914 },
                    { 900307635, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5547), -1171500680, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5548), 623407158 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 919846581, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5401), 1439567088, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5402), 358607375 },
                    { 951445331, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5784), -314784480, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5785), 277411914 },
                    { 963400340, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5960), -1742550896, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5961), 358607375 },
                    { 979929924, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5985), -1742550896, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5987), 623407158 },
                    { 982403294, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6010), -1742550896, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(6011), 649294520 },
                    { 998879179, 0f, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5833), 154853016, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(5834), 358607375 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 662618234, 846817880, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3820), 422803155, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3821) },
                    { 662618234, 920687051, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3733), 565973003, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3734) },
                    { 662618234, 948367074, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3983), 761494127, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3984) },
                    { 662618234, 987448409, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3900), 447394856, new DateTime(2024, 3, 14, 2, 12, 40, 506, DateTimeKind.Local).AddTicks(3901) }
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
