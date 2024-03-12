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
                    { 204833047, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7895), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7896), "Construction Supervision" },
                    { 306034920, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7739), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7740), "Fire Suppression" },
                    { 350779024, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7804), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7805), "Burglar Alarm" },
                    { 384730001, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7817), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7818), "CCTV" },
                    { 456871643, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7868), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7869), "Outsource" },
                    { 461305935, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7880), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7881), "TenderDocument" },
                    { 499127754, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7830), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7831), "BMS" },
                    { 556738909, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7711), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7712), "Drainage" },
                    { 586520336, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7791), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7792), "Structured Cabling" },
                    { 659165880, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7855), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7856), "Energy Efficiency" },
                    { 694263631, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7752), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7753), "Elevators" },
                    { 710491544, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7661), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7662), "HVAC" },
                    { 819638731, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7843), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7844), "Photovoltaics" },
                    { 831582282, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7724), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7725), "Fire Detection" },
                    { 882562551, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7764), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7765), "Natural Gas" },
                    { 888869335, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7682), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7683), "Sewage" },
                    { 898371208, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7695), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7696), "Potable Water" },
                    { 999984489, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7777), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7778), "Power Distribution" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 155041826, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8141), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8142), "Drawings" },
                    { 541261286, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8127), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8128), "Calculations" },
                    { 775684437, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8107), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8109), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 266940967, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8699), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8700), "Printing" },
                    { 312196297, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8676), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8677), "Communications" },
                    { 583458666, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8741), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8742), "Administration" },
                    { 807428653, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8728), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8729), "Meetings" },
                    { 822484845, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8715), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8716), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 210135529, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4969), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4970), "See All Projects", 11 },
                    { 309209990, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4866), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4868), "Dashboard Assign Engineer", 4 },
                    { 362179455, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4955), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4956), "See All Drawings", 10 },
                    { 378282378, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4852), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4853), "Dashboard Assign Designer", 3 },
                    { 441046345, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4940), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4941), "See All Disciplines", 9 },
                    { 637408317, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4759), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4761), "See Dashboard Layout", 1 },
                    { 638535018, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4897), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4899), "Dashboard Add Project", 6 },
                    { 732519182, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4912), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4914), "See Admin Layout", 7 },
                    { 867674281, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4926), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4927), "Dashboard See My Hours", 8 },
                    { 906318060, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4881), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4882), "Dashboard Assign Project Manager", 5 },
                    { 934851277, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4834), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4836), "Dashboard Edit My Hours", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 233947524, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7209), "Consulting Description", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7210), "Consulting" },
                    { 405035316, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7165), "Buildings Description", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7166), "Buildings" },
                    { 477430435, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7196), "Energy Description", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7197), "Energy" },
                    { 883163298, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7182), "Infrastructure Description", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7183), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[] { 221359595, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5109), false, false, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5110), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 275372843, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5081), false, false, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5083), "Guest" },
                    { 332793618, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5124), false, false, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5125), "Secretariat" },
                    { 341678459, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5052), false, true, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5053), "CTO" },
                    { 587923136, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4984), false, true, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(4985), "Designer" },
                    { 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5067), false, true, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5068), "CEO" },
                    { 755319331, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5095), false, false, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5096), "Customer" },
                    { 792941867, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5024), false, true, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5025), "Project Manager" },
                    { 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5038), false, true, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5039), "COO" },
                    { 983964834, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5008), false, true, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5010), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6665), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6667), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6546), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6548), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6503), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6505), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6903), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6905), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 264098939, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6373), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6375), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 289543987, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6170), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6172), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7078), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7079), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6861), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6863), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 479721226, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6323), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6324), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6590), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6591), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6946), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6947), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6461), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6462), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 654432399, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5991), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5992), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6774), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6775), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 669017649, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6277), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6278), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 677758865, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5931), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5932), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6988), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6989), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7120), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7122), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 739407676, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6123), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6125), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6816), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6818), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 778482537, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6079), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6081), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7034), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7035), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 866226096, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6217), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6218), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6729), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6730), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 943518012, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6035), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6037), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6417), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6418), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 139064853, "pfokianou@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6917), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6919), 251267435 },
                    { 168839781, "embiria@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6234), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6235), 866226096 },
                    { 192061425, "kkotsoni@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6680), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6682), 129961804 },
                    { 237744486, "coo@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6094), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6095), 778482537 },
                    { 261927346, "kmargeti@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6831), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6833), 764914348 },
                    { 265791580, "vpax@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6432), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6433), 947068809 },
                    { 309661178, "pm@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6185), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6186), 289543987 },
                    { 366711272, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6960), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6961), 528289874 },
                    { 373185194, "panperivollari@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7092), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7094), 347275694 },
                    { 392967511, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7136), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7137), 717678211 },
                    { 401713976, "vchontos@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7049), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7050), 797860065 },
                    { 410364256, "blekou@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7002), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7004), 685504959 },
                    { 494160466, "gdoug@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6293), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6294), 669017649 },
                    { 524886670, "dtsa@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6343), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6344), 479721226 },
                    { 568915811, "dtsa@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6388), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6389), 264098939 },
                    { 585086788, "chkovras@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6561), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6563), 206483965 },
                    { 591810806, "haris@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6875), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6877), 387806154 },
                    { 604736708, "cto@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6050), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6051), 943518012 },
                    { 630930702, "vtza@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6745), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6746), 867884099 },
                    { 661037902, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6249), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6250), 866226096 },
                    { 689980219, "ceo@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6005), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6007), 654432399 },
                    { 697851337, "xmanarolis@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6475), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6477), 624360079 },
                    { 873351574, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5949), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5951), 677758865 },
                    { 875646735, "sparisis@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6518), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6519), 216475263 },
                    { 905114096, "ngal@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6606), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6607), 495900610 },
                    { 907928597, "guest@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6139), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6140), 739407676 },
                    { 954902657, "agretos@embiria.gr", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6788), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6789), 656842909 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 170405438, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 6.0, 1, new DateTime(2024, 4, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 4, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), new DateTime(2024, 4, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 0f, 1500L, 12L, new DateTime(2024, 3, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), "Project_1", 5.0, new DateTime(2024, 4, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), "Payment Detailes For Project_5", 1.0, null, 405035316, new DateTime(2024, 4, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 0f },
                    { 225285541, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 8.0, 9, new DateTime(2024, 12, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 9, "Test Description Project_18", "KL-3", new DateTime(2024, 12, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), new DateTime(2024, 12, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 0f, 1500L, 12L, new DateTime(2024, 3, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), "Project_3", 5.0, new DateTime(2024, 12, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), "Payment Detailes For Project_12", 3.0, null, 477430435, new DateTime(2024, 12, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 0f },
                    { 691099338, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 7.0, 4, new DateTime(2024, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 4, "Test Description Project_2", "KL-2", new DateTime(2024, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), new DateTime(2024, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 0f, 1500L, 12L, new DateTime(2024, 3, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), "Project_2", 5.0, new DateTime(2024, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), "Payment Detailes For Project_8", 2.0, null, 883163298, new DateTime(2024, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 0f },
                    { 760525570, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 9.0, 16, new DateTime(2025, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 16, "Test Description Project_16", "KL-4", new DateTime(2025, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), new DateTime(2025, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 0f, 1500L, 12L, new DateTime(2024, 3, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), "Project_4", 5.0, new DateTime(2025, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), "Payment Detailes For Project_12", 4.0, null, 233947524, new DateTime(2025, 7, 12, 19, 32, 55, 711, DateTimeKind.Local).AddTicks(9516), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 210135529, 221359595, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5832), -1976320673, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5833) },
                    { 362179455, 221359595, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5818), 1284255378, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5819) },
                    { 441046345, 221359595, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5804), -76659376, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5805) },
                    { 732519182, 221359595, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5790), 1342678145, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5791) },
                    { 637408317, 275372843, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5762), 364457534, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5763) },
                    { 210135529, 332793618, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5916), -1696568453, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5917) },
                    { 362179455, 332793618, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5902), 2078676036, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5903) },
                    { 441046345, 332793618, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5888), 981593258, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5889) },
                    { 637408317, 332793618, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5846), -182467714, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5847) },
                    { 867674281, 332793618, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5874), -1249021250, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5875) },
                    { 934851277, 332793618, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5860), 1772308593, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5861) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 210135529, 341678459, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5603), -779536435, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5604) },
                    { 362179455, 341678459, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5588), -263243515, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5589) },
                    { 441046345, 341678459, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5574), 1151032649, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5575) },
                    { 637408317, 341678459, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5499), -583989646, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5501) },
                    { 638535018, 341678459, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5541), -407420576, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5543) },
                    { 867674281, 341678459, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5559), 644627894, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5561) },
                    { 906318060, 341678459, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5527), 1561450482, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5528) },
                    { 934851277, 341678459, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5513), 1043355911, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5515) },
                    { 637408317, 587923136, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5143), 1144664568, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5144) },
                    { 867674281, 587923136, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5183), -270234602, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5184) },
                    { 934851277, 587923136, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5168), -2061154700, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5169) },
                    { 210135529, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5748), -890196178, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5749) },
                    { 309209990, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5662), 1878662628, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5664) },
                    { 362179455, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5734), 2102979848, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5735) },
                    { 378282378, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5648), -1054999727, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5650) },
                    { 441046345, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5720), 704381243, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5721) },
                    { 637408317, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5617), 2001949655, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5619) },
                    { 638535018, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5690), 1770214082, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5692) },
                    { 732519182, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5705), -1524235324, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5707) },
                    { 906318060, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5676), 1754417291, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5677) },
                    { 934851277, 734824158, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5634), -1615226219, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5635) },
                    { 637408317, 755319331, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5776), -900961762, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5777) },
                    { 309209990, 792941867, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5313), 1649243165, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5315) },
                    { 362179455, 792941867, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5355), -211321003, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5356) },
                    { 441046345, 792941867, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5341), -1866534907, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5342) },
                    { 637408317, 792941867, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5284), 1405353335, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5286) },
                    { 867674281, 792941867, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5327), 1444203333, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5328) },
                    { 934851277, 792941867, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5299), -775154200, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5300) },
                    { 210135529, 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5485), 1939722570, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5486) },
                    { 309209990, 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5414), -1514630042, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5415) },
                    { 362179455, 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5471), -12272035, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5473) },
                    { 378282378, 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5400), -216271498, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5401) },
                    { 441046345, 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5456), -1669644242, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5457) },
                    { 637408317, 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5370), -60938117, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5371) },
                    { 867674281, 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5442), 372101918, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5443) },
                    { 906318060, 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5428), 337153082, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5429) },
                    { 934851277, 977927026, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5384), -1315207300, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5385) },
                    { 362179455, 983964834, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5269), -454949914, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5270) },
                    { 378282378, 983964834, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5227), -2142014975, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5228) },
                    { 441046345, 983964834, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5255), -802112768, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5256) },
                    { 637408317, 983964834, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5197), -1001679830, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5198) },
                    { 867674281, 983964834, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5241), 1486787009, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5242) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 934851277, 983964834, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5212), -228395267, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5213) });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 792941867, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7239), 226669530, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7241) },
                    { 977927026, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6714), 363082308, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6715) },
                    { 983964834, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6700), 802777959, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6701) },
                    { 983964834, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6576), 338187739, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6577) },
                    { 983964834, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6532), 421268863, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6533) },
                    { 983964834, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6932), 833336496, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6933) },
                    { 587923136, 264098939, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6402), 379943524, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6403) },
                    { 792941867, 289543987, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6200), 879324033, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6201) },
                    { 983964834, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7106), 423868364, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7108) },
                    { 792941867, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7255), 70917245, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7256) },
                    { 983964834, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6889), 396711165, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6891) },
                    { 587923136, 479721226, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6358), 562181025, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6359) },
                    { 221359595, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6636), 575868033, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6638) },
                    { 734824158, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6650), 864495959, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6651) },
                    { 983964834, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6621), 744025356, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6623) },
                    { 983964834, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6974), 816538139, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6975) },
                    { 983964834, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6489), 828866664, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6491) },
                    { 734824158, 654432399, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6021), 373216392, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6023) },
                    { 983964834, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6802), 842541983, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6803) },
                    { 587923136, 669017649, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6309), 596427938, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6310) },
                    { 221359595, 677758865, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5973), 676829335, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(5974) },
                    { 983964834, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7016), 750781659, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7018) },
                    { 983964834, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7150), 995821182, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7151) },
                    { 275372843, 739407676, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6154), 254860473, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6156) },
                    { 983964834, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6846), 328677214, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6848) },
                    { 977927026, 778482537, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6109), 878178259, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6110) },
                    { 983964834, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7063), 383139192, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7064) },
                    { 332793618, 866226096, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6262), 841050740, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6264) },
                    { 983964834, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6759), 269853188, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6761) },
                    { 341678459, 943518012, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6065), 437530998, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6066) },
                    { 792941867, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7224), 90881046, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7225) },
                    { 983964834, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6447), 463097702, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(6448) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1461816104, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7976), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7977), 691099338, 694263631, null },
                    { -1450750872, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8079), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8080), 760525570, 831582282, null },
                    { -907215328, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7923), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7924), 170405438, 306034920, null },
                    { -675987904, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7989), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7991), 691099338, 586520336, null },
                    { -316404496, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8005), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8006), 691099338, 888869335, null },
                    { -112576536, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7961), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7962), 170405438, 659165880, null },
                    { -98499040, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8033), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8034), 225285541, 819638731, null },
                    { -11739776, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7946), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7948), 170405438, 710491544, null },
                    { 891312296, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8046), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8047), 225285541, 888869335, null },
                    { 1415882688, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8020), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8021), 225285541, 499127754, null },
                    { 1511914720, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8066), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8067), 760525570, 456871643, null },
                    { 1728194336, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8092), 0f, 500L, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8093), 760525570, 694263631, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 274391562, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7638), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7640), 13000.0, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7639), "Signature 1423424", 16238, 760525570, 4.0, 24.0 },
                    { 350383555, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7389), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7392), 3010.0, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7390), "Signature 142345", 47721, 170405438, 1.0, 17.0 },
                    { 490906664, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7482), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7485), 3100.0, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7483), "Signature 142342", 24126, 691099338, 2.0, 24.0 },
                    { 952312897, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7562), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7564), 4000.0, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7563), "Signature 142346", 34993, 225285541, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 691099338, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9543), 310556563, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9544) },
                    { 225285541, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9557), 516371195, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9558) },
                    { 170405438, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9524), 363309566, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9526) },
                    { 760525570, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9570), 394921162, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9571) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 168375146, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7521), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7523), null, "6949277783", null, null, 225285541, "alexpl_{i}@gmail.com" },
                    { 337971719, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7441), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7442), null, "6949277782", null, null, 691099338, "alexpl_{i}@gmail.com" },
                    { 530340249, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7597), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7599), null, "6949277784", null, null, 760525570, "alexpl_{i}@gmail.com" },
                    { 701969859, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7340), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7341), null, "6949277781", null, null, 170405438, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1461816104, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(289), 544055123, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(290) },
                    { -1461816104, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(263), 977776459, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(264) },
                    { -1461816104, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(250), 283465000, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(251) },
                    { -1461816104, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(354), 740462890, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(355) },
                    { -1461816104, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(405), 681616108, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(406) },
                    { -1461816104, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(341), 137013114, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(342) },
                    { -1461816104, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(276), 343632335, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(277) },
                    { -1461816104, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(367), 237634793, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(368) },
                    { -1461816104, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(237), 987144950, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(238) },
                    { -1461816104, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(315), 975885210, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(316) },
                    { -1461816104, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(380), 682381338, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(381) },
                    { -1461816104, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(418), 317149630, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(419) },
                    { -1461816104, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(328), 288890233, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(329) },
                    { -1461816104, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(392), 964871692, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(394) },
                    { -1461816104, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(302), 811299880, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(303) },
                    { -1461816104, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(224), 427814751, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(225) },
                    { -1450750872, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1865), 405911922, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1867) },
                    { -1450750872, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1840), 843827029, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1841) },
                    { -1450750872, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1827), 284892841, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1828) },
                    { -1450750872, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1929), 219439369, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1931) },
                    { -1450750872, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1980), 524380374, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1982) },
                    { -1450750872, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1916), 871978471, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1918) },
                    { -1450750872, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1853), 289819100, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1854) },
                    { -1450750872, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1942), 518324844, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1943) },
                    { -1450750872, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1814), 860367560, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1815) },
                    { -1450750872, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1891), 169082164, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1892) },
                    { -1450750872, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1955), 982965149, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1956) },
                    { -1450750872, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1993), 779135187, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1994) },
                    { -1450750872, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1904), 582530135, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1905) },
                    { -1450750872, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1968), 857626838, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1969) },
                    { -1450750872, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1878), 426343962, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1880) },
                    { -1450750872, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1801), 320961716, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1802) },
                    { -907215328, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9657), 872784639, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9658) },
                    { -907215328, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9630), 309864024, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9632) },
                    { -907215328, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9617), 958060369, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9618) },
                    { -907215328, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9727), 144963520, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9728) },
                    { -907215328, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9778), 732468559, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9779) },
                    { -907215328, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9710), 834776538, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9711) },
                    { -907215328, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9643), 445839902, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9644) },
                    { -907215328, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9740), 905939109, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9741) },
                    { -907215328, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9603), 535414259, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9604) },
                    { -907215328, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9683), 169553216, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9684) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -907215328, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9752), 463103719, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9753) },
                    { -907215328, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9790), 757686143, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9792) },
                    { -907215328, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9696), 454280445, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9697) },
                    { -907215328, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9765), 239902614, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9766) },
                    { -907215328, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9670), 578411429, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9671) },
                    { -907215328, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9584), 674040357, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9585) },
                    { -675987904, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(615), 215818116, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(616) },
                    { -675987904, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(588), 232536145, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(589) },
                    { -675987904, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(575), 573270823, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(576) },
                    { -675987904, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(679), 971456532, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(680) },
                    { -675987904, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(731), 437015181, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(732) },
                    { -675987904, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(666), 831992244, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(667) },
                    { -675987904, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(602), 466481797, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(603) },
                    { -675987904, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(692), 570231963, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(693) },
                    { -675987904, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(561), 657219043, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(563) },
                    { -675987904, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(640), 995457114, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(642) },
                    { -675987904, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(705), 982118575, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(706) },
                    { -675987904, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(744), 740667026, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(745) },
                    { -675987904, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(653), 714209224, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(654) },
                    { -675987904, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(718), 761867455, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(719) },
                    { -675987904, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(627), 128688363, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(629) },
                    { -675987904, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(431), 500058788, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(432) },
                    { -316404496, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(821), 326625899, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(822) },
                    { -316404496, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(795), 695827359, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(796) },
                    { -316404496, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(782), 891338310, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(783) },
                    { -316404496, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(885), 561675039, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(886) },
                    { -316404496, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(937), 898598225, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(938) },
                    { -316404496, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(872), 175325354, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(873) },
                    { -316404496, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(808), 719002374, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(809) },
                    { -316404496, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(898), 460315772, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(899) },
                    { -316404496, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(769), 381057230, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(770) },
                    { -316404496, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(846), 809414149, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(847) },
                    { -316404496, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(911), 211591824, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(912) },
                    { -316404496, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(953), 397868988, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(954) },
                    { -316404496, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(859), 616528429, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(860) },
                    { -316404496, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(923), 671623292, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(924) },
                    { -316404496, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(833), 670960898, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(834) },
                    { -316404496, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(756), 480056053, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(758) },
                    { -112576536, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(83), 944233824, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(84) },
                    { -112576536, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(52), 914993974, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(53) },
                    { -112576536, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(39), 956346887, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(41) },
                    { -112576536, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(147), 635123630, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(148) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -112576536, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(198), 482821100, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(199) },
                    { -112576536, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(134), 558206187, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(135) },
                    { -112576536, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(66), 340705888, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(68) },
                    { -112576536, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(160), 518049757, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(161) },
                    { -112576536, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(26), 841336556, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(27) },
                    { -112576536, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(108), 351874809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(109) },
                    { -112576536, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(173), 402870900, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(174) },
                    { -112576536, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(211), 821657734, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(212) },
                    { -112576536, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(121), 637168092, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(122) },
                    { -112576536, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(185), 449342321, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(187) },
                    { -112576536, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(96), 359729747, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(97) },
                    { -112576536, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(13), 243389722, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(14) },
                    { -98499040, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1236), 767358195, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1237) },
                    { -98499040, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1211), 208796822, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1212) },
                    { -98499040, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1197), 779047799, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1198) },
                    { -98499040, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1300), 170085896, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1301) },
                    { -98499040, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1357), 502678087, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1358) },
                    { -98499040, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1287), 388108664, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1288) },
                    { -98499040, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1224), 580178833, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1225) },
                    { -98499040, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1313), 554299941, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1314) },
                    { -98499040, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1185), 159601247, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1186) },
                    { -98499040, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1262), 350562595, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1263) },
                    { -98499040, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1326), 823718737, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1327) },
                    { -98499040, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1369), 762854313, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1371) },
                    { -98499040, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1274), 864725597, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1275) },
                    { -98499040, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1339), 965810609, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1340) },
                    { -98499040, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1249), 872270211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1250) },
                    { -98499040, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1171), 447623308, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1173) },
                    { -11739776, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9870), 471638509, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9871) },
                    { -11739776, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9844), 766329585, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9845) },
                    { -11739776, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9831), 783907217, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9832) },
                    { -11739776, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9935), 409881401, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9937) },
                    { -11739776, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9987), 139383581, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9988) },
                    { -11739776, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9922), 169462140, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9923) },
                    { -11739776, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9857), 599041032, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9858) },
                    { -11739776, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9949), 915422427, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9950) },
                    { -11739776, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9817), 405557926, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9818) },
                    { -11739776, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9895), 981862517, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9896) },
                    { -11739776, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9962), 804644594, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9963) },
                    { -11739776, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local), 816932118, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1) },
                    { -11739776, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9909), 233648846, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9910) },
                    { -11739776, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9974), 517137504, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9976) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -11739776, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9882), 489082522, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9883) },
                    { -11739776, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9804), 919906856, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9805) },
                    { 891312296, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1448), 738412122, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1449) },
                    { 891312296, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1422), 918420548, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1423) },
                    { 891312296, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1410), 967515914, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1411) },
                    { 891312296, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1512), 496709617, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1513) },
                    { 891312296, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1563), 569571245, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1564) },
                    { 891312296, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1499), 948819518, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1500) },
                    { 891312296, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1435), 996832513, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1436) },
                    { 891312296, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1525), 188784594, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1526) },
                    { 891312296, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1397), 557022953, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1398) },
                    { 891312296, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1473), 337667351, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1474) },
                    { 891312296, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1537), 266940933, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1539) },
                    { 891312296, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1576), 992330476, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1577) },
                    { 891312296, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1486), 711612269, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1487) },
                    { 891312296, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1550), 677605100, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1551) },
                    { 891312296, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1460), 678395575, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1462) },
                    { 891312296, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1382), 282204875, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1384) },
                    { 1415882688, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1030), 282968298, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1031) },
                    { 1415882688, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1004), 361681872, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1005) },
                    { 1415882688, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(991), 342924417, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(992) },
                    { 1415882688, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1095), 518852657, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1096) },
                    { 1415882688, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1146), 707631328, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1147) },
                    { 1415882688, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1082), 537865435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1083) },
                    { 1415882688, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1017), 775063002, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1018) },
                    { 1415882688, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1108), 357887463, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1109) },
                    { 1415882688, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(978), 694341859, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(980) },
                    { 1415882688, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1055), 385562461, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1057) },
                    { 1415882688, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1120), 471034215, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1121) },
                    { 1415882688, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1158), 618633454, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1159) },
                    { 1415882688, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1069), 649205029, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1070) },
                    { 1415882688, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1133), 926077256, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1134) },
                    { 1415882688, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1043), 332735881, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1044) },
                    { 1415882688, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(966), 228146695, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(967) },
                    { 1511914720, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1660), 887313717, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1661) },
                    { 1511914720, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1628), 472178829, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1629) },
                    { 1511914720, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1615), 525805926, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1616) },
                    { 1511914720, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1724), 424682870, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1725) },
                    { 1511914720, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1775), 500136262, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1776) },
                    { 1511914720, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1711), 498128153, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1712) },
                    { 1511914720, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1640), 911305283, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1642) },
                    { 1511914720, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1737), 999045869, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1738) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1511914720, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1602), 958622359, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1603) },
                    { 1511914720, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1685), 226838640, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1686) },
                    { 1511914720, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1749), 815143396, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1750) },
                    { 1511914720, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1788), 535454047, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1789) },
                    { 1511914720, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1698), 221139703, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1699) },
                    { 1511914720, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1762), 629789160, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1763) },
                    { 1511914720, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1672), 520878472, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1673) },
                    { 1511914720, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1589), 327871822, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(1590) },
                    { 1728194336, 129961804, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2074), 932591041, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2075) },
                    { 1728194336, 206483965, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2045), 752772844, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2046) },
                    { 1728194336, 216475263, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2032), 929140936, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2033) },
                    { 1728194336, 251267435, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2139), 776196299, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2140) },
                    { 1728194336, 347275694, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2190), 758036959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2191) },
                    { 1728194336, 387806154, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2126), 657251774, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2127) },
                    { 1728194336, 495900610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2061), 514406944, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2062) },
                    { 1728194336, 528289874, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2151), 743786422, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2152) },
                    { 1728194336, 624360079, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2019), 290083538, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2021) },
                    { 1728194336, 656842909, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2100), 847150654, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2101) },
                    { 1728194336, 685504959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2164), 463602284, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2165) },
                    { 1728194336, 717678211, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2203), 638682667, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2204) },
                    { 1728194336, 764914348, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2113), 885167982, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2114) },
                    { 1728194336, 797860065, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2177), 260753194, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2178) },
                    { 1728194336, 867884099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2087), 408422202, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2088) },
                    { 1728194336, 947068809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2006), 132997937, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2007) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124772892, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8270), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8267), -112576536, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8268), 541261286 },
                    { 131711895, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8538), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8536), 891312296, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8537), 155041826 },
                    { 144304827, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8327), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8324), -1461816104, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8325), 155041826 },
                    { 177508549, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8340), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8338), -675987904, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8339), 775684437 },
                    { 188164904, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8579), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8576), 1511914720, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8578), 155041826 },
                    { 193099804, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8483), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8481), -98499040, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8482), 541261286 },
                    { 225955942, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8313), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8310), -1461816104, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8312), 541261286 },
                    { 263731872, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8160), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8157), -907215328, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8158), 775684437 },
                    { 283357941, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8227), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8224), -11739776, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8225), 541261286 },
                    { 319152998, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8470), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8467), -98499040, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8468), 775684437 },
                    { 320845298, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8368), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8366), -675987904, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8367), 155041826 },
                    { 336582061, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8212), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8210), -11739776, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8211), 775684437 },
                    { 388715377, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8511), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8508), 891312296, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8510), 775684437 },
                    { 407656653, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8649), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8647), 1728194336, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8648), 541261286 },
                    { 420405328, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8193), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8190), -907215328, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8191), 155041826 },
                    { 437689010, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8620), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8617), -1450750872, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8618), 155041826 },
                    { 450553235, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8177), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8175), -907215328, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8176), 541261286 },
                    { 460351456, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8284), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8281), -112576536, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8283), 155041826 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 461291219, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8525), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8522), 891312296, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8523), 541261286 },
                    { 494253235, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8256), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8254), -112576536, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8255), 775684437 },
                    { 528944174, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8442), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8440), 1415882688, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8441), 541261286 },
                    { 566903920, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8354), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8351), -675987904, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8353), 541261286 },
                    { 600273914, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8415), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8412), -316404496, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8413), 155041826 },
                    { 603569954, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8456), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8453), 1415882688, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8455), 155041826 },
                    { 677232003, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8299), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8297), -1461816104, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8298), 775684437 },
                    { 704829980, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8636), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8633), 1728194336, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8634), 775684437 },
                    { 721468719, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8396), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8394), -316404496, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8395), 541261286 },
                    { 723316084, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8565), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8563), 1511914720, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8564), 541261286 },
                    { 724965333, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8593), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8590), -1450750872, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8591), 775684437 },
                    { 772441769, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8606), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8604), -1450750872, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8605), 541261286 },
                    { 781288470, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8382), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8380), -316404496, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8381), 775684437 },
                    { 788418179, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8429), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8426), 1415882688, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8428), 775684437 },
                    { 871097676, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8552), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8549), 1511914720, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8551), 775684437 },
                    { 912776340, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8242), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8239), -11739776, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8240), 155041826 },
                    { 943714747, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8663), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8660), 1728194336, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8661), 155041826 },
                    { 977754229, new DateTime(2024, 3, 23, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8497), 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8494), -98499040, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8496), 155041826 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 311913387, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7456), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7457), 337971719 },
                    { 452016519, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7358), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7360), 701969859 },
                    { 651580433, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7536), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7537), 168375146 },
                    { 791872329, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7612), new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7613), 530340249 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 125336739, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8802), -907215328, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8803), 807428653 },
                    { 187452934, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8789), -907215328, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8791), 822484845 },
                    { 201981097, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8842), -11739776, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8843), 266940967 },
                    { 206912200, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9321), 891312296, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9323), 583458666 },
                    { 207672981, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9048), -675987904, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9049), 822484845 },
                    { 214471974, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8776), -907215328, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8777), 266940967 },
                    { 217342725, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9085), -316404496, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9086), 312196297 },
                    { 261981323, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9437), -1450750872, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9438), 807428653 },
                    { 270107643, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9260), -98499040, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9261), 583458666 },
                    { 297692744, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9171), 1415882688, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9172), 822484845 },
                    { 308297342, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8930), -112576536, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8931), 807428653 },
                    { 328731809, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9210), -98499040, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9211), 312196297 },
                    { 345536919, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9097), -316404496, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9098), 266940967 },
                    { 378676199, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9235), -98499040, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9236), 822484845 },
                    { 385405069, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9159), 1415882688, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9160), 266940967 },
                    { 404836742, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8954), -1461816104, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8956), 312196297 },
                    { 411793133, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9285), 891312296, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9286), 266940967 },
                    { 432898144, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9223), -98499040, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9224), 266940967 },
                    { 471684363, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8918), -112576536, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8919), 822484845 },
                    { 474967940, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8829), -11739776, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8831), 312196297 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 479096144, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9122), -316404496, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9123), 807428653 },
                    { 514204851, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8994), -1461816104, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8995), 807428653 },
                    { 547443044, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9387), 1511914720, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9389), 583458666 },
                    { 569558510, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8905), -112576536, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8907), 266940967 },
                    { 579220969, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9334), 1511914720, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9335), 312196297 },
                    { 600913635, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9134), -316404496, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9135), 583458666 },
                    { 615701631, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8866), -11739776, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8868), 807428653 },
                    { 616923288, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9498), 1728194336, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9500), 807428653 },
                    { 618997144, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8942), -112576536, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8943), 583458666 },
                    { 645805584, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9400), -1450750872, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9401), 312196297 },
                    { 659543471, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8757), -907215328, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8759), 312196297 },
                    { 675909226, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9309), 891312296, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9310), 807428653 },
                    { 689334802, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9198), 1415882688, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9199), 583458666 },
                    { 694021035, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9147), 1415882688, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9148), 312196297 },
                    { 698364630, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8981), -1461816104, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8983), 822484845 },
                    { 703439750, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9375), 1511914720, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9376), 807428653 },
                    { 707703610, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9247), -98499040, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9249), 807428653 },
                    { 749147369, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8880), -11739776, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8881), 583458666 },
                    { 764506678, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9110), -316404496, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9111), 822484845 },
                    { 773395596, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9185), 1415882688, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9186), 807428653 },
                    { 791731439, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9511), 1728194336, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9512), 583458666 },
                    { 799764764, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9486), 1728194336, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9487), 822484845 },
                    { 820893778, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9424), -1450750872, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9425), 822484845 },
                    { 828353813, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9060), -675987904, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9061), 807428653 },
                    { 831933502, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8893), -112576536, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8894), 312196297 },
                    { 854568022, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8815), -907215328, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8816), 583458666 },
                    { 856752300, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9363), 1511914720, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9364), 822484845 },
                    { 856837755, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8967), -1461816104, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8968), 266940967 },
                    { 879677073, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9461), 1728194336, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9463), 312196297 },
                    { 906579172, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9474), 1728194336, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9475), 266940967 },
                    { 913616672, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9297), 891312296, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9298), 822484845 },
                    { 913932619, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9449), -1450750872, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9450), 583458666 },
                    { 923831112, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9272), 891312296, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9273), 312196297 },
                    { 930096722, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8854), -11739776, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(8855), 822484845 },
                    { 937913135, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9006), -1461816104, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9007), 583458666 },
                    { 945276649, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9072), -675987904, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9073), 583458666 },
                    { 951260626, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9019), -675987904, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9020), 312196297 },
                    { 959666513, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9350), 1511914720, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9351), 266940967 },
                    { 985813320, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9412), -1450750872, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9413), 266940967 },
                    { 993825388, 0f, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9035), -675987904, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(9036), 266940967 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 755319331, 168375146, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7549), 741940986, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7550) },
                    { 755319331, 337971719, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7469), 688020474, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7470) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 755319331, 530340249, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7624), 152054169, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7626) });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 755319331, 701969859, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7373), 675200901, new DateTime(2024, 3, 12, 19, 32, 55, 722, DateTimeKind.Local).AddTicks(7374) });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 264098939, 125336739, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2370), -1155874283, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2371) },
                    { 479721226, 125336739, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2357), -575663710, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2358) },
                    { 669017649, 125336739, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2344), -1587738401, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2345) },
                    { 264098939, 187452934, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2330), 1476938583, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2331) },
                    { 479721226, 187452934, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2317), -976857857, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2318) },
                    { 669017649, 187452934, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2304), 793001543, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2305) },
                    { 264098939, 201981097, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2490), 530555099, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2492) },
                    { 479721226, 201981097, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2478), 2054745194, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2479) },
                    { 669017649, 201981097, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2465), -2059727404, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2466) },
                    { 264098939, 206912200, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3983), -632649194, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3984) },
                    { 479721226, 206912200, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3970), 198467411, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3971) },
                    { 669017649, 206912200, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3957), -292030771, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3958) },
                    { 264098939, 207672981, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3119), -911384302, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3120) },
                    { 479721226, 207672981, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3107), 1370566269, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3108) },
                    { 669017649, 207672981, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3094), -755721643, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3095) },
                    { 264098939, 214471974, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2291), 1658443149, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2292) },
                    { 479721226, 214471974, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2277), -1182228340, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2278) },
                    { 669017649, 214471974, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2264), -39711784, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2265) },
                    { 264098939, 217342725, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3240), -1299908114, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3241) },
                    { 479721226, 217342725, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3227), 1453361742, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3228) },
                    { 669017649, 217342725, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3214), -1182558968, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3215) },
                    { 264098939, 261981323, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4338), 2135940809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4339) },
                    { 479721226, 261981323, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4325), -1016695124, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4326) },
                    { 669017649, 261981323, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4311), -491434190, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4312) },
                    { 264098939, 270107643, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3784), 822427772, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3785) },
                    { 479721226, 270107643, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3771), -1616787391, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3772) },
                    { 669017649, 270107643, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3758), 1324490499, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3759) },
                    { 264098939, 297692744, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3509), -105144713, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3510) },
                    { 479721226, 297692744, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3496), -328993523, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3497) },
                    { 669017649, 297692744, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3484), 1321799180, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3485) },
                    { 264098939, 308297342, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2762), 1742909589, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2764) },
                    { 479721226, 308297342, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2750), -573463628, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2751) },
                    { 669017649, 308297342, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2737), 1639702616, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2738) },
                    { 264098939, 328731809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3629), 1016559968, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3630) },
                    { 479721226, 328731809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3616), 709220255, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3617) },
                    { 669017649, 328731809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3604), 240774548, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3605) },
                    { 264098939, 345536919, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3278), -1609210574, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3280) },
                    { 479721226, 345536919, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3266), 604131404, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3267) },
                    { 669017649, 345536919, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3253), 54247636, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3254) },
                    { 264098939, 378676199, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3706), -1071190255, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3708) },
                    { 479721226, 378676199, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3693), -1260876851, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3694) },
                    { 669017649, 378676199, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3680), 1359439992, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3681) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 264098939, 385405069, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3471), -1741411705, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3472) },
                    { 479721226, 385405069, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3458), 1298117381, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3459) },
                    { 669017649, 385405069, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3445), 295131947, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3446) },
                    { 264098939, 404836742, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2847), 324036626, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2848) },
                    { 479721226, 404836742, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2834), -199958314, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2835) },
                    { 669017649, 404836742, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2814), 284630725, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2815) },
                    { 264098939, 411793133, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3861), -332409721, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3862) },
                    { 479721226, 411793133, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3848), 1623270699, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3849) },
                    { 669017649, 411793133, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3835), -372604193, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3837) },
                    { 264098939, 432898144, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3667), -2103847226, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3668) },
                    { 479721226, 432898144, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3654), -1486232860, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3656) },
                    { 669017649, 432898144, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3642), 1149185462, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3643) },
                    { 264098939, 471684363, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2724), 1391668983, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2725) },
                    { 479721226, 471684363, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2711), -585705374, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2713) },
                    { 669017649, 471684363, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2699), 2076023228, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2700) },
                    { 264098939, 474967940, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2451), 874557779, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2452) },
                    { 479721226, 474967940, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2434), -1628228987, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2436) },
                    { 669017649, 474967940, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2422), -1173617959, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2423) },
                    { 264098939, 479096144, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3355), 1429789793, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3356) },
                    { 479721226, 479096144, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3342), -694269791, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3343) },
                    { 669017649, 479096144, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3329), 2055496937, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3331) },
                    { 264098939, 514204851, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2963), 1565741178, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2964) },
                    { 479721226, 514204851, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2950), 1199779047, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2951) },
                    { 669017649, 514204851, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2937), -409768361, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2939) },
                    { 264098939, 547443044, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4178), 53138579, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4180) },
                    { 479721226, 547443044, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4166), 773654747, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4167) },
                    { 669017649, 547443044, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4153), 1728318042, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4154) },
                    { 264098939, 569558510, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2686), 1569341700, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2687) },
                    { 479721226, 569558510, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2673), 1350814500, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2674) },
                    { 669017649, 569558510, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2660), -692755762, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2661) },
                    { 264098939, 579220969, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4022), -1575309118, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4023) },
                    { 479721226, 579220969, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4009), -1870933346, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4011) },
                    { 669017649, 579220969, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3996), -862635464, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3998) },
                    { 264098939, 600913635, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3393), 1189667736, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3395) },
                    { 479721226, 600913635, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3381), 903803900, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3382) },
                    { 669017649, 600913635, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3368), -784043554, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3369) },
                    { 264098939, 615701631, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2569), 675068531, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2570) },
                    { 479721226, 615701631, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2556), 1337530640, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2557) },
                    { 669017649, 615701631, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2543), -1941063277, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2544) },
                    { 264098939, 616923288, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4531), -337606528, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4532) },
                    { 479721226, 616923288, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4518), -1571731519, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4519) },
                    { 669017649, 616923288, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4505), 1654271375, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4506) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 264098939, 618997144, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2801), 1607576031, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2802) },
                    { 479721226, 618997144, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2788), -2078513104, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2789) },
                    { 669017649, 618997144, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2775), -1699443827, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2776) },
                    { 264098939, 645805584, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4217), 1306383809, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4218) },
                    { 479721226, 645805584, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4204), -283867465, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4205) },
                    { 669017649, 645805584, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4192), -415699901, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4193) },
                    { 264098939, 659543471, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2251), -1842610913, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2252) },
                    { 479721226, 659543471, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2236), 1294499331, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2237) },
                    { 669017649, 659543471, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2217), 1145988500, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2218) },
                    { 264098939, 675909226, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3945), -1635681473, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3946) },
                    { 479721226, 675909226, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3932), -1037336413, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3933) },
                    { 669017649, 675909226, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3918), 1868784759, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3919) },
                    { 264098939, 689334802, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3590), 344599363, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3591) },
                    { 479721226, 689334802, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3574), 1471982936, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3575) },
                    { 669017649, 689334802, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3561), -2034263006, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3562) },
                    { 264098939, 694021035, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3432), -1088394002, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3433) },
                    { 479721226, 694021035, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3419), -893967839, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3420) },
                    { 669017649, 694021035, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3406), -538025710, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3408) },
                    { 264098939, 698364630, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2924), -1515709336, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2925) },
                    { 479721226, 698364630, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2912), -2137272938, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2913) },
                    { 669017649, 698364630, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2899), -1833266290, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2900) },
                    { 264098939, 703439750, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4140), 1914030351, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4141) },
                    { 479721226, 703439750, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4127), -1949765953, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4128) },
                    { 669017649, 703439750, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4113), -1565489006, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4115) },
                    { 264098939, 707703610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3745), -1179654488, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3746) },
                    { 479721226, 707703610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3733), 61772671, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3734) },
                    { 669017649, 707703610, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3720), -592368767, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3721) },
                    { 264098939, 749147369, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2608), -678706393, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2609) },
                    { 479721226, 749147369, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2595), 160386670, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2596) },
                    { 669017649, 749147369, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2582), -1228380367, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2583) },
                    { 264098939, 764506678, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3317), 1453796820, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3318) },
                    { 479721226, 764506678, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3304), 1867467569, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3305) },
                    { 669017649, 764506678, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3291), 1136597697, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3292) },
                    { 264098939, 773395596, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3548), -2033488286, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3550) },
                    { 479721226, 773395596, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3535), 407832085, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3536) },
                    { 669017649, 773395596, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3522), 1264433967, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3523) },
                    { 264098939, 791731439, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4569), -1277630549, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4571) },
                    { 479721226, 791731439, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4557), 1027412555, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4558) },
                    { 669017649, 791731439, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4544), -629748899, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4545) },
                    { 264098939, 799764764, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4492), -1432518484, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4493) },
                    { 479721226, 799764764, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4479), 933178190, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4480) },
                    { 669017649, 799764764, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4467), 1708482362, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4468) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 264098939, 820893778, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4298), -2131574975, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4300) },
                    { 479721226, 820893778, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4282), 1643399361, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4283) },
                    { 669017649, 820893778, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4269), -1425864055, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4270) },
                    { 264098939, 828353813, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3159), -98314555, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3160) },
                    { 479721226, 828353813, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3146), -1659118549, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3147) },
                    { 669017649, 828353813, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3132), 381425482, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3134) },
                    { 264098939, 831933502, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2646), 453039611, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2647) },
                    { 479721226, 831933502, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2633), 339831523, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2635) },
                    { 669017649, 831933502, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2621), -135576247, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2622) },
                    { 264098939, 854568022, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2409), -492547328, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2410) },
                    { 479721226, 854568022, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2396), -1529749642, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2397) },
                    { 669017649, 854568022, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2383), -1616513516, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2384) },
                    { 264098939, 856752300, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4100), -76672606, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4101) },
                    { 479721226, 856752300, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4087), 1798694316, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4088) },
                    { 669017649, 856752300, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4074), 995203436, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4075) },
                    { 264098939, 856837755, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2885), 18212576, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2887) },
                    { 479721226, 856837755, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2873), -2110375367, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2874) },
                    { 669017649, 856837755, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2860), -708462440, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2861) },
                    { 264098939, 879677073, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4415), 365726602, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4416) },
                    { 479721226, 879677073, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4402), 323034926, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4403) },
                    { 669017649, 879677073, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4389), 2036938185, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4390) },
                    { 264098939, 906579172, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4453), 1628087621, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4455) },
                    { 479721226, 906579172, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4441), 1999567062, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4442) },
                    { 669017649, 906579172, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4428), 2031913980, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4429) },
                    { 264098939, 913616672, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3900), -558081022, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3901) },
                    { 479721226, 913616672, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3887), 1886436005, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3888) },
                    { 669017649, 913616672, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3874), -1967461622, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3876) },
                    { 264098939, 913932619, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4376), 755927780, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4377) },
                    { 479721226, 913932619, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4363), -697739930, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4364) },
                    { 669017649, 913932619, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4351), 1129885754, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4352) },
                    { 264098939, 923831112, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3822), -1507259479, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3824) },
                    { 479721226, 923831112, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3809), 1985960682, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3810) },
                    { 669017649, 923831112, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3797), -1170247972, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3798) },
                    { 264098939, 930096722, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2529), -884060000, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2531) },
                    { 479721226, 930096722, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2516), -531310486, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2517) },
                    { 669017649, 930096722, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2503), -1401375167, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2505) },
                    { 264098939, 937913135, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3002), -1704788815, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3003) },
                    { 479721226, 937913135, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2989), 48283849, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2990) },
                    { 669017649, 937913135, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2976), 396881168, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(2978) },
                    { 264098939, 945276649, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3201), 81478247, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3203) },
                    { 479721226, 945276649, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3189), 1689866915, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3190) },
                    { 669017649, 945276649, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3171), 1990238202, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3173) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 264098939, 951260626, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3040), 561516089, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3042) },
                    { 479721226, 951260626, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3028), -175950256, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3029) },
                    { 669017649, 951260626, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3015), 1121888700, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3016) },
                    { 264098939, 959666513, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4061), -511342402, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4062) },
                    { 479721226, 959666513, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4048), -506558960, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4049) },
                    { 669017649, 959666513, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4035), -1343270254, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4036) },
                    { 264098939, 985813320, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4255), -113249546, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4257) },
                    { 479721226, 985813320, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4243), 2872450, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4244) },
                    { 669017649, 985813320, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4230), 1639178037, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(4231) },
                    { 264098939, 993825388, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3080), 1938149118, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3081) },
                    { 479721226, 993825388, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3066), -500264846, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3067) },
                    { 669017649, 993825388, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3053), -756414179, new DateTime(2024, 3, 12, 19, 32, 55, 723, DateTimeKind.Local).AddTicks(3054) }
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
