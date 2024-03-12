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
                    { 246155755, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9305), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9306), "TenderDocument" },
                    { 265583258, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9168), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9170), "Fire Suppression" },
                    { 268726310, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9154), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9155), "Fire Detection" },
                    { 367467745, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9142), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9143), "Drainage" },
                    { 371458208, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9277), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9278), "Energy Efficiency" },
                    { 407412342, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9292), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9294), "Outsource" },
                    { 409129118, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9204), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9205), "Power Distribution" },
                    { 425082182, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9265), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9266), "Photovoltaics" },
                    { 474060950, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9129), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9131), "Potable Water" },
                    { 493391801, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9193), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9194), "Natural Gas" },
                    { 542536812, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9230), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9231), "Burglar Alarm" },
                    { 560720141, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9254), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9255), "BMS" },
                    { 713008353, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9099), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9100), "HVAC" },
                    { 728060820, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9218), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9219), "Structured Cabling" },
                    { 742998519, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9180), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9182), "Elevators" },
                    { 818083476, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9318), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9319), "Construction Supervision" },
                    { 849654312, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9242), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9243), "CCTV" },
                    { 924985410, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9117), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9118), "Sewage" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 174055251, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9519), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9520), "Documents" },
                    { 503998751, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9549), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9551), "Drawings" },
                    { 601110748, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9537), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9538), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 483356682, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(89), new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(90), "On-Site" },
                    { 645347740, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(101), new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(102), "Meetings" },
                    { 775048932, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(76), new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(77), "Printing" },
                    { 788453213, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(113), new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(114), "Administration" },
                    { 977900100, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(54), new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(55), "Communications" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 218359815, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6453), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6454), "Dashboard Assign Designer", 3 },
                    { 295248876, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6481), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6482), "Dashboard Assign Project Manager", 5 },
                    { 423532506, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6571), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6572), "See All Projects", 11 },
                    { 522021403, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6515), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6516), "See Admin Layout", 7 },
                    { 538643965, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6528), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6530), "Dashboard See My Hours", 8 },
                    { 573453504, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6542), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6544), "See All Disciplines", 9 },
                    { 656308516, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6500), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6502), "Dashboard Add Project", 6 },
                    { 690281925, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6319), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6321), "See Dashboard Layout", 1 },
                    { 791557446, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6436), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6437), "Dashboard Edit My Hours", 2 },
                    { 848345228, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6557), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6558), "See All Drawings", 10 },
                    { 874812004, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6467), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6468), "Dashboard Assign Engineer", 4 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 196565643, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8639), "Buildings Description", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8640), "Buildings" },
                    { 485912427, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8668), "Energy Description", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8669), "Energy" },
                    { 820787063, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8655), "Infrastructure Description", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8656), "Infrastructure" },
                    { 850259272, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8684), "Consulting Description", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8686), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[] { 186230809, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6650), false, true, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6651), "CTO" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 209941197, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6677), false, false, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6678), "Guest" },
                    { 272669657, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6624), false, true, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6625), "Project Manager" },
                    { 397805804, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6717), false, false, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6718), "Secretariat" },
                    { 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6664), false, true, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6665), "CEO" },
                    { 544718612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6690), false, false, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6691), "Customer" },
                    { 720025724, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6609), false, true, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6610), "Engineer" },
                    { 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6637), false, true, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6638), "COO" },
                    { 788982860, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6586), false, true, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6587), "Designer" },
                    { 923613575, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6703), false, false, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6704), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7971), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7972), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8434), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8435), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8393), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8394), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8305), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8306), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 447527393, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7890), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7891), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8352), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8353), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7930), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7932), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 511285846, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7533), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7534), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 551054073, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7615), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7616), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8474), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8476), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8264), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8265), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8515), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8517), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8556), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8558), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 693998400, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7806), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7807), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 703962669, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7848), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7849), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 717065744, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7706), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7707), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8223), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8224), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 761456439, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7749), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7750), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 784833924, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7660), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7661), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8057), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8058), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 859704866, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7575), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7576), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 905371891, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7478), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7479), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8097), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8099), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8597), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8598), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8167), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8168), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8016), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8017), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 132624151, "vchontos@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8530), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8531), 633359917 },
                    { 147781870, "cto@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7588), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7590), 859704866 },
                    { 168880194, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7496), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7498), 905371891 },
                    { 177386452, "xmanarolis@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7988), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7989), 259379798 },
                    { 183369932, "pm@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7720), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7722), 717065744 },
                    { 259508091, "ngal@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8113), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8114), 930358103 },
                    { 259894075, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8448), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8449), 313152533 },
                    { 278349737, "blekou@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8488), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8490), 578842111 },
                    { 299721939, "dtsa@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7904), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7905), 447527393 },
                    { 315480400, "vpax@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7945), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7946), 508042450 },
                    { 323780740, "gdoug@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7820), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7822), 693998400 },
                    { 326947634, "kkotsoni@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8181), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8182), 957927975 },
                    { 368789500, "embiria@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7765), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7767), 761456439 },
                    { 373941368, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8611), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8612), 937652959 },
                    { 464916513, "guest@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7676), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7677), 784833924 },
                    { 551453233, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7779), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7780), 761456439 },
                    { 635616766, "sparisis@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8030), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8031), 983700458 },
                    { 701620929, "pfokianou@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8407), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8408), 358945896 },
                    { 801794729, "haris@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8367), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8368), 494663084 },
                    { 809805897, "chkovras@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8071), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8072), 839389692 },
                    { 818571824, "kmargeti@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8324), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8325), 398780185 },
                    { 835015821, "vtza@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8238), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8239), 744335783 },
                    { 839150289, "agretos@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8278), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8279), 611461329 },
                    { 866759055, "ceo@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7547), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7548), 511285846 },
                    { 901942735, "coo@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7628), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7630), 551054073 },
                    { 906218675, "panperivollari@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8570), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8571), 633834230 },
                    { 940096754, "dtsa@embiria.gr", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7863), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7864), 703962669 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 276002457, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 9.0, 16, new DateTime(2025, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 16, "Test Description Project_24", "KL-4", new DateTime(2025, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), new DateTime(2025, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 0f, 100L, 12L, new DateTime(2024, 3, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), "Project_4", 5.0, new DateTime(2025, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), "Payment Detailes For Project_16", 4.0, null, 850259272, new DateTime(2025, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 0f },
                    { 343598709, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 7.0, 4, new DateTime(2024, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 4, "Test Description Project_6", "KL-2", new DateTime(2024, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), new DateTime(2024, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 0f, 100L, 12L, new DateTime(2024, 3, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), "Project_2", 5.0, new DateTime(2024, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), "Payment Detailes For Project_12", 2.0, null, 820787063, new DateTime(2024, 7, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 0f },
                    { 413129452, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 6.0, 1, new DateTime(2024, 4, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 1, "Test Description Project_1", "KL-1", new DateTime(2024, 4, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), new DateTime(2024, 4, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 0f, 100L, 12L, new DateTime(2024, 3, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), "Project_1", 5.0, new DateTime(2024, 4, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), "Payment Detailes For Project_5", 1.0, null, 196565643, new DateTime(2024, 4, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 0f },
                    { 754634582, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 8.0, 9, new DateTime(2024, 12, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 9, "Test Description Project_15", "KL-3", new DateTime(2024, 12, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), new DateTime(2024, 12, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 0f, 100L, 12L, new DateTime(2024, 3, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), "Project_3", 5.0, new DateTime(2024, 12, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), "Payment Detailes For Project_6", 3.0, null, 485912427, new DateTime(2024, 12, 12, 14, 38, 17, 445, DateTimeKind.Local).AddTicks(7105), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 295248876, 186230809, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7098), -1100773385, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7099) },
                    { 423532506, 186230809, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7164), 1485760721, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7166) },
                    { 538643965, 186230809, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7124), -217437268, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7126) },
                    { 573453504, 186230809, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7138), -513086075, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7139) },
                    { 656308516, 186230809, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7111), -435330764, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7112) },
                    { 690281925, 186230809, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7072), -2075968975, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7073) },
                    { 791557446, 186230809, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7085), -1088863856, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7086) },
                    { 848345228, 186230809, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7151), -789373646, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7152) },
                    { 690281925, 209941197, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7317), 93305075, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7318) },
                    { 538643965, 272669657, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6908), 1378663322, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6909) },
                    { 573453504, 272669657, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6923), -842716714, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6924) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 690281925, 272669657, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6864), -347770943, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6865) },
                    { 791557446, 272669657, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6877), 1323261288, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6878) },
                    { 848345228, 272669657, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6936), -2028815842, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6937) },
                    { 874812004, 272669657, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6894), 1487482529, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6895) },
                    { 423532506, 397805804, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7463), 1883671772, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7465) },
                    { 538643965, 397805804, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7422), -1705290385, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7424) },
                    { 573453504, 397805804, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7436), -1023166340, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7437) },
                    { 690281925, 397805804, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7396), -882536516, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7397) },
                    { 791557446, 397805804, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7409), -1771817854, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7410) },
                    { 848345228, 397805804, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7449), 915382589, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7450) },
                    { 218359815, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7208), -1541072236, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7209) },
                    { 295248876, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7234), -1561195178, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7235) },
                    { 423532506, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7304), -1654676, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7305) },
                    { 522021403, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7260), -405795275, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7261) },
                    { 573453504, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7277), -1487173324, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7278) },
                    { 656308516, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7247), -826706330, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7249) },
                    { 690281925, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7179), 1251094284, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7180) },
                    { 791557446, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7194), 1141108988, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7195) },
                    { 848345228, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7290), -1366505968, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7291) },
                    { 874812004, 400267612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7221), -1036821640, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7222) },
                    { 690281925, 544718612, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7330), 540804038, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7331) },
                    { 218359815, 720025724, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6810), 891950576, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6811) },
                    { 538643965, 720025724, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6823), -1770029288, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6824) },
                    { 573453504, 720025724, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6836), 537962432, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6838) },
                    { 690281925, 720025724, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6782), 67791857, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6783) },
                    { 791557446, 720025724, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6795), -1322536112, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6797) },
                    { 848345228, 720025724, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6850), 25473664, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6851) },
                    { 218359815, 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6978), 676241213, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6979) },
                    { 295248876, 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7004), 4478801, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7005) },
                    { 423532506, 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7057), -2137887791, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7059) },
                    { 538643965, 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7017), -56171407, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7019) },
                    { 573453504, 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7030), 518642123, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7032) },
                    { 690281925, 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6950), 1573486623, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6951) },
                    { 791557446, 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6963), 1648282068, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6964) },
                    { 848345228, 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7044), -701268713, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7045) },
                    { 874812004, 728894918, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6991), -460039877, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6992) },
                    { 538643965, 788982860, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6768), -250496509, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6769) },
                    { 690281925, 788982860, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6732), -39282367, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6733) },
                    { 791557446, 788982860, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6754), 1346493623, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(6756) },
                    { 423532506, 923613575, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7383), 523215014, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7384) },
                    { 522021403, 923613575, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7343), 942978173, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7344) },
                    { 573453504, 923613575, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7356), -592576028, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7357) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 848345228, 923613575, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7369), 1391912145, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7370) });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 720025724, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8002), 369655654, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8003) },
                    { 720025724, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8461), 155888014, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8462) },
                    { 720025724, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8420), 320761155, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8422) },
                    { 720025724, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8338), 408670873, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8339) },
                    { 788982860, 447527393, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7917), 502719824, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7918) },
                    { 272669657, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8728), 62649613, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8729) },
                    { 720025724, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8380), 372182913, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8381) },
                    { 272669657, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8699), 154387376, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8700) },
                    { 720025724, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7958), 452579502, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7959) },
                    { 400267612, 511285846, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7561), 447192447, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7562) },
                    { 728894918, 551054073, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7642), 814436037, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7643) },
                    { 720025724, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8502), 677999189, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8503) },
                    { 720025724, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8292), 568649697, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8293) },
                    { 720025724, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8543), 806777189, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8544) },
                    { 720025724, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8583), 411535582, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8585) },
                    { 788982860, 693998400, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7834), 512939932, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7836) },
                    { 788982860, 703962669, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7876), 640389140, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7877) },
                    { 272669657, 717065744, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7734), 141523445, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7735) },
                    { 720025724, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8251), 606121976, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8252) },
                    { 397805804, 761456439, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7792), 211509905, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7793) },
                    { 209941197, 784833924, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7691), 884198253, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7692) },
                    { 720025724, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8084), 417537113, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8085) },
                    { 186230809, 859704866, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7601), 171032494, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7603) },
                    { 923613575, 905371891, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7513), 629328495, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(7515) },
                    { 400267612, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8153), 186975965, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8154) },
                    { 720025724, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8126), 614310529, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8127) },
                    { 923613575, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8140), 547725980, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8141) },
                    { 720025724, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8624), 275994317, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8625) },
                    { 272669657, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8714), 84533615, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8715) },
                    { 720025724, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8196), 470282026, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8197) },
                    { 728894918, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8209), 776984078, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8210) },
                    { 720025724, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8043), 782133924, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8045) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2074810344, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9348), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9350), 413129452, 425082182, null },
                    { -2053333800, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9372), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9373), 413129452, 742998519, null },
                    { -1740572136, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9412), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9413), 343598709, 849654312, null },
                    { -1602393800, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9481), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9482), 276002457, 742998519, null },
                    { -1346568008, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9505), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9506), 276002457, 268726310, null },
                    { -370948048, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9453), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9454), 754634582, 924985410, null },
                    { -176215440, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9493), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9494), 276002457, 409129118, null },
                    { 1250029600, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9427), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9428), 343598709, 371458208, null },
                    { 1823235656, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9440), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9441), 754634582, 407412342, null },
                    { 1991017936, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9385), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9386), 413129452, 728060820, null },
                    { 2031119600, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9399), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9400), 343598709, 713008353, null },
                    { 2080311960, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9466), 0f, 1500L, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9467), 754634582, 246155755, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 225565462, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9008), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9011), 4000.0, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9010), "Signature 142343", 69292, 754634582, 3.0, 17.0 },
                    { 290230658, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8932), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8934), 3100.0, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8933), "Signature 142342", 62816, 343598709, 2.0, 24.0 },
                    { 542215785, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8848), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8850), 3010.0, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8849), "Signature 142342", 84350, 413129452, 1.0, 17.0 },
                    { 693958016, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9080), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9082), 13000.0, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9081), "Signature 1423416", 40753, 276002457, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 754634582, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(868), 646242389, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(869) },
                    { 276002457, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(880), 350564272, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(882) },
                    { 413129452, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(840), 851247616, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(841) },
                    { 343598709, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(856), 911315712, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(857) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 156200225, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8892), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8893), null, "6949277782", null, null, 343598709, "alexpl_{i}@gmail.com" },
                    { 646834733, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8967), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8968), null, "6949277783", null, null, 754634582, "alexpl_{i}@gmail.com" },
                    { 731387889, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8801), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8802), null, "6949277781", null, null, 413129452, "alexpl_{i}@gmail.com" },
                    { 862408246, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9042), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9043), null, "6949277784", null, null, 276002457, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2074810344, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(912), 917103802, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(913) },
                    { -2074810344, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1037), 708124905, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1038) },
                    { -2074810344, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1025), 997570462, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1026) },
                    { -2074810344, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1000), 265688302, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1001) },
                    { -2074810344, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1013), 463739561, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1014) },
                    { -2074810344, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(894), 675899633, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(896) },
                    { -2074810344, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1049), 219903851, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1050) },
                    { -2074810344, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(988), 380188453, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(989) },
                    { -2074810344, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1061), 125472794, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1062) },
                    { -2074810344, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1073), 522503487, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1074) },
                    { -2074810344, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(975), 384232072, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(976) },
                    { -2074810344, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(938), 328091274, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(939) },
                    { -2074810344, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(950), 480487874, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(951) },
                    { -2074810344, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1085), 732522128, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1086) },
                    { -2074810344, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(963), 851360461, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(964) },
                    { -2074810344, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(926), 995639207, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(927) },
                    { -2053333800, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1109), 601790864, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1110) },
                    { -2053333800, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1232), 393127946, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1233) },
                    { -2053333800, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1220), 526241512, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1221) },
                    { -2053333800, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1197), 344481022, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1198) },
                    { -2053333800, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1209), 578791771, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1210) },
                    { -2053333800, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1097), 687682463, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1098) },
                    { -2053333800, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1244), 444391346, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1245) },
                    { -2053333800, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1185), 760542263, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1186) },
                    { -2053333800, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1256), 481947536, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1257) },
                    { -2053333800, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1268), 587807636, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1269) },
                    { -2053333800, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1173), 140046473, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1174) },
                    { -2053333800, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1134), 779754806, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1135) },
                    { -2053333800, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1146), 288012916, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1147) },
                    { -2053333800, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1280), 234819545, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1281) },
                    { -2053333800, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1158), 408132193, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1159) },
                    { -2053333800, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1122), 831338654, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1123) },
                    { -1740572136, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1692), 995062517, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1693) },
                    { -1740572136, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1812), 981547253, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1813) },
                    { -1740572136, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1799), 696378800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1801) },
                    { -1740572136, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1775), 353113944, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1777) },
                    { -1740572136, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1788), 209395649, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1789) },
                    { -1740572136, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1679), 994255244, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1680) },
                    { -1740572136, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1823), 422028377, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1825) },
                    { -1740572136, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1764), 806252578, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1765) },
                    { -1740572136, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1838), 594249899, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1839) },
                    { -1740572136, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1850), 738067051, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1852) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1740572136, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1752), 392720683, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1753) },
                    { -1740572136, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1716), 366967582, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1717) },
                    { -1740572136, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1728), 167452755, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1729) },
                    { -1740572136, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1862), 606063472, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1863) },
                    { -1740572136, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1740), 243865562, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1741) },
                    { -1740572136, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1704), 978244776, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1705) },
                    { -1602393800, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2654), 947225007, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2655) },
                    { -1602393800, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2773), 433411281, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2774) },
                    { -1602393800, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2761), 747047832, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2762) },
                    { -1602393800, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2737), 451083902, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2738) },
                    { -1602393800, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2749), 607726427, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2751) },
                    { -1602393800, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2642), 221123730, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2643) },
                    { -1602393800, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2785), 959513392, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2786) },
                    { -1602393800, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2726), 927692863, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2727) },
                    { -1602393800, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2797), 197723121, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2798) },
                    { -1602393800, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2809), 875115080, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2810) },
                    { -1602393800, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2714), 794081570, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2715) },
                    { -1602393800, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2678), 483136481, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2679) },
                    { -1602393800, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2690), 392695525, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2691) },
                    { -1602393800, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2820), 628103460, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2822) },
                    { -1602393800, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2702), 873005586, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2703) },
                    { -1602393800, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2666), 343800845, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2667) },
                    { -1346568008, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3041), 894919653, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3042) },
                    { -1346568008, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3160), 710443991, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3161) },
                    { -1346568008, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3148), 998080265, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3149) },
                    { -1346568008, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3124), 297901724, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3126) },
                    { -1346568008, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3136), 238079190, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3137) },
                    { -1346568008, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3029), 369459760, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3030) },
                    { -1346568008, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3172), 867205375, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3173) },
                    { -1346568008, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3112), 997873199, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3114) },
                    { -1346568008, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3183), 676001619, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3185) },
                    { -1346568008, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3195), 186835726, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3196) },
                    { -1346568008, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3100), 253074620, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3102) },
                    { -1346568008, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3064), 616944278, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3065) },
                    { -1346568008, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3076), 675704771, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3077) },
                    { -1346568008, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3207), 524846636, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3208) },
                    { -1346568008, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3088), 421354494, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3090) },
                    { -1346568008, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3052), 850324691, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3054) },
                    { -370948048, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2269), 789560141, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2270) },
                    { -370948048, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2387), 304869985, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2389) },
                    { -370948048, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2376), 681833466, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2377) },
                    { -370948048, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2352), 260046628, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2353) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -370948048, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2364), 169769820, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2365) },
                    { -370948048, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2258), 474203339, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2259) },
                    { -370948048, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2399), 737161319, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2401) },
                    { -370948048, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2340), 789913657, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2341) },
                    { -370948048, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2411), 257567689, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2412) },
                    { -370948048, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2423), 447260284, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2424) },
                    { -370948048, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2328), 293952524, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2330) },
                    { -370948048, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2293), 845516613, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2294) },
                    { -370948048, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2305), 450672151, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2306) },
                    { -370948048, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2435), 183726442, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2436) },
                    { -370948048, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2316), 617459233, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2317) },
                    { -370948048, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2281), 527531591, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2282) },
                    { -176215440, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2845), 902559348, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2846) },
                    { -176215440, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2968), 569561558, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2970) },
                    { -176215440, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2957), 753983664, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2958) },
                    { -176215440, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2933), 748529242, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2934) },
                    { -176215440, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2945), 143786069, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2946) },
                    { -176215440, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2833), 554220312, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2834) },
                    { -176215440, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2981), 374780196, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2982) },
                    { -176215440, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2921), 290262131, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2922) },
                    { -176215440, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2993), 454642207, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2994) },
                    { -176215440, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3005), 597962668, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3006) },
                    { -176215440, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2909), 766247962, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2910) },
                    { -176215440, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2874), 259928191, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2875) },
                    { -176215440, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2886), 410213543, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2887) },
                    { -176215440, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3017), 276740839, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3018) },
                    { -176215440, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2898), 922084765, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2899) },
                    { -176215440, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2862), 414112496, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2863) },
                    { 1250029600, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1886), 146154702, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1887) },
                    { 1250029600, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2005), 735593851, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2006) },
                    { 1250029600, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1993), 274312702, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1994) },
                    { 1250029600, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1969), 738695728, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1970) },
                    { 1250029600, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1981), 901075867, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1982) },
                    { 1250029600, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1874), 254898831, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1875) },
                    { 1250029600, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2016), 943788253, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2017) },
                    { 1250029600, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1957), 238876981, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1959) },
                    { 1250029600, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2028), 805006048, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2029) },
                    { 1250029600, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2040), 978136843, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2041) },
                    { 1250029600, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1945), 144127811, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1946) },
                    { 1250029600, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1910), 668949845, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1911) },
                    { 1250029600, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1921), 564954587, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1922) },
                    { 1250029600, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2052), 349961877, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2053) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1250029600, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1933), 188844958, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1934) },
                    { 1250029600, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1898), 434910661, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1899) },
                    { 1823235656, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2076), 180530285, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2077) },
                    { 1823235656, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2195), 347130998, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2196) },
                    { 1823235656, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2183), 534270666, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2184) },
                    { 1823235656, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2159), 840654785, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2160) },
                    { 1823235656, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2171), 628416900, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2172) },
                    { 1823235656, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2064), 480194781, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2065) },
                    { 1823235656, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2210), 459083222, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2211) },
                    { 1823235656, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2147), 321121614, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2148) },
                    { 1823235656, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2222), 229684294, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2223) },
                    { 1823235656, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2234), 224444056, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2235) },
                    { 1823235656, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2135), 234676411, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2136) },
                    { 1823235656, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2100), 312991700, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2101) },
                    { 1823235656, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2112), 757967549, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2113) },
                    { 1823235656, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2246), 576667662, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2247) },
                    { 1823235656, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2124), 189434011, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2125) },
                    { 1823235656, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2088), 685201344, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2089) },
                    { 1991017936, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1305), 982527708, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1306) },
                    { 1991017936, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1424), 680557464, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1425) },
                    { 1991017936, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1412), 607620307, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1413) },
                    { 1991017936, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1388), 825055587, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1389) },
                    { 1991017936, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1400), 578065819, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1401) },
                    { 1991017936, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1292), 227446630, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1293) },
                    { 1991017936, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1436), 641431701, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1437) },
                    { 1991017936, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1376), 802031735, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1378) },
                    { 1991017936, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1448), 409836379, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1449) },
                    { 1991017936, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1460), 824360268, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1461) },
                    { 1991017936, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1364), 976068520, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1366) },
                    { 1991017936, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1329), 747359397, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1330) },
                    { 1991017936, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1341), 901520367, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1342) },
                    { 1991017936, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1471), 670943717, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1473) },
                    { 1991017936, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1353), 246188102, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1354) },
                    { 1991017936, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1316), 548500720, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1317) },
                    { 2031119600, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1496), 830220377, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1497) },
                    { 2031119600, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1618), 383165903, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1619) },
                    { 2031119600, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1606), 912936811, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1608) },
                    { 2031119600, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1583), 351730097, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1584) },
                    { 2031119600, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1594), 711985963, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1596) },
                    { 2031119600, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1483), 668086087, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1485) },
                    { 2031119600, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1630), 198944024, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1631) },
                    { 2031119600, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1571), 866195909, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1572) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 2031119600, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1642), 702609027, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1644) },
                    { 2031119600, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1655), 961736402, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1656) },
                    { 2031119600, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1559), 245304006, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1560) },
                    { 2031119600, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1523), 348301386, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1524) },
                    { 2031119600, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1535), 811746997, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1536) },
                    { 2031119600, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1667), 582570738, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1668) },
                    { 2031119600, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1547), 455547200, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1548) },
                    { 2031119600, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1511), 370090070, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(1512) },
                    { 2080311960, 259379798, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2460), 987992526, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2461) },
                    { 2080311960, 313152533, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2583), 875704368, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2584) },
                    { 2080311960, 358945896, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2571), 690447052, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2572) },
                    { 2080311960, 398780185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2547), 146785448, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2548) },
                    { 2080311960, 494663084, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2559), 427750077, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2560) },
                    { 2080311960, 508042450, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2447), 269431985, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2448) },
                    { 2080311960, 578842111, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2594), 989960364, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2596) },
                    { 2080311960, 611461329, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2535), 895110226, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2536) },
                    { 2080311960, 633359917, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2606), 708292622, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2607) },
                    { 2080311960, 633834230, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2618), 807456865, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2619) },
                    { 2080311960, 744335783, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2523), 727986956, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2524) },
                    { 2080311960, 839389692, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2488), 175459651, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2489) },
                    { 2080311960, 930358103, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2499), 653810449, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2500) },
                    { 2080311960, 937652959, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2630), 376380092, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2631) },
                    { 2080311960, 957927975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2512), 792258387, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2513) },
                    { 2080311960, 983700458, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2472), 739596407, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(2473) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 142718804, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9829), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9827), 1823235656, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9828), 601110748 },
                    { 146768970, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9775), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9773), 1250029600, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9774), 174055251 },
                    { 148763065, new DateTime(2024, 3, 23, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(28), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(25), -1346568008, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(27), 601110748 },
                    { 181123410, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9949), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9947), -1602393800, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9948), 601110748 },
                    { 216959791, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9737), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9735), -1740572136, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9736), 174055251 },
                    { 221717140, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9974), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9972), -176215440, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9973), 174055251 },
                    { 268721633, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9698), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9696), 2031119600, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9697), 174055251 },
                    { 274675906, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9750), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9747), -1740572136, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9749), 601110748 },
                    { 295115287, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9644), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9642), -2053333800, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9643), 503998751 },
                    { 307813158, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9868), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9865), -370948048, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9867), 601110748 },
                    { 316489918, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9894), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9891), 2080311960, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9892), 174055251 },
                    { 331430451, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9684), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9681), 1991017936, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9682), 503998751 },
                    { 340242392, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9906), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9904), 2080311960, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9905), 601110748 },
                    { 341452118, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9671), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9668), 1991017936, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9669), 601110748 },
                    { 372448933, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9658), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9655), 1991017936, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9656), 174055251 },
                    { 419219536, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9816), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9814), 1823235656, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9815), 174055251 },
                    { 447092897, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9803), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9800), 1250029600, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9801), 503998751 },
                    { 447924584, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9987), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9985), -176215440, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9986), 601110748 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 473502946, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9616), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9613), -2053333800, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9615), 174055251 },
                    { 507034924, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9599), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9597), -2074810344, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9598), 503998751 },
                    { 526293910, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9788), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9786), 1250029600, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9787), 601110748 },
                    { 545752799, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9629), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9627), -2053333800, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9628), 601110748 },
                    { 561460536, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9922), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9920), 2080311960, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9921), 503998751 },
                    { 612057639, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9842), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9839), 1823235656, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9840), 503998751 },
                    { 632319180, new DateTime(2024, 3, 23, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(40), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(38), -1346568008, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(39), 503998751 },
                    { 675742745, new DateTime(2024, 3, 23, 14, 38, 17, 455, DateTimeKind.Local), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9997), -176215440, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9999), 503998751 },
                    { 711654327, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9586), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9583), -2074810344, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9585), 601110748 },
                    { 718608906, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9724), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9722), 2031119600, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9723), 503998751 },
                    { 790449417, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9936), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9934), -1602393800, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9935), 174055251 },
                    { 825549356, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9855), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9853), -370948048, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9854), 174055251 },
                    { 932508270, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9881), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9879), -370948048, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9880), 503998751 },
                    { 953613965, new DateTime(2024, 3, 23, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(15), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(13), -1346568008, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(14), 174055251 },
                    { 954208337, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9762), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9760), -1740572136, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9761), 503998751 },
                    { 965822502, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9711), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9709), 2031119600, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9710), 601110748 },
                    { 983963227, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9567), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9564), -2074810344, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9565), 174055251 },
                    { 988891875, new DateTime(2024, 3, 23, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9962), 0f, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9959), -1602393800, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9961), 503998751 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 269950931, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9056), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9057), 862408246 },
                    { 403525453, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8818), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8820), 731387889 },
                    { 599043708, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8907), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8908), 156200225 },
                    { 994559538, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8984), new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8985), 646834733 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124213640, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(294), 1991017936, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(295), 645347740 },
                    { 129082334, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(711), -1602393800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(712), 788453213 },
                    { 138157446, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(722), -176215440, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(723), 977900100 },
                    { 151489026, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(620), 2080311960, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(621), 775048932 },
                    { 152350606, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(328), 2031119600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(330), 775048932 },
                    { 153904930, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(223), -2053333800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(224), 483356682 },
                    { 159169745, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(790), -1346568008, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(791), 775048932 },
                    { 160079701, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(665), -1602393800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(666), 977900100 },
                    { 164143747, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(260), 1991017936, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(261), 977900100 },
                    { 172919199, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(432), 1250029600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(433), 977900100 },
                    { 178313389, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(654), 2080311960, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(655), 788453213 },
                    { 183565497, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(597), -370948048, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(599), 788453213 },
                    { 195484708, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(552), -370948048, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(553), 977900100 },
                    { 231737212, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(283), 1991017936, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(284), 483356682 },
                    { 233681701, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(631), 2080311960, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(633), 483356682 },
                    { 242455373, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(609), 2080311960, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(610), 977900100 },
                    { 289772323, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(159), -2074810344, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(160), 483356682 },
                    { 306249706, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(643), 2080311960, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(644), 645347740 },
                    { 323453825, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(170), -2074810344, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(171), 645347740 },
                    { 327080627, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(444), 1250029600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(445), 775048932 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 333298894, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(756), -176215440, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(757), 645347740 },
                    { 346215283, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(341), 2031119600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(343), 483356682 },
                    { 365693746, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(455), 1250029600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(456), 483356682 },
                    { 366979311, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(421), -1740572136, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(422), 788453213 },
                    { 370980276, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(688), -1602393800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(689), 483356682 },
                    { 375943914, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(387), -1740572136, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(388), 775048932 },
                    { 404541525, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(574), -370948048, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(576), 483356682 },
                    { 414073318, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(563), -370948048, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(564), 775048932 },
                    { 446318733, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(364), 2031119600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(365), 788453213 },
                    { 475985034, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(182), -2074810344, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(183), 788453213 },
                    { 478351938, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(541), 1823235656, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(542), 788453213 },
                    { 491909853, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(234), -2053333800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(235), 645347740 },
                    { 493127686, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(305), 1991017936, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(306), 788453213 },
                    { 511000805, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(677), -1602393800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(678), 775048932 },
                    { 516606989, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(804), -1346568008, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(806), 483356682 },
                    { 572836164, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(466), 1250029600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(467), 645347740 },
                    { 582941415, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(409), -1740572136, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(410), 645347740 },
                    { 597213357, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(271), 1991017936, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(272), 775048932 },
                    { 607831565, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(196), -2053333800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(197), 977900100 },
                    { 648469365, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(376), -1740572136, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(377), 977900100 },
                    { 672315645, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(700), -1602393800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(701), 645347740 },
                    { 685366757, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(586), -370948048, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(587), 645347740 },
                    { 690756845, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(317), 2031119600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(318), 977900100 },
                    { 698689711, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(489), 1823235656, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(490), 977900100 },
                    { 733863921, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(529), 1823235656, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(530), 645347740 },
                    { 768889819, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(248), -2053333800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(249), 788453213 },
                    { 785721196, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(779), -1346568008, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(780), 977900100 },
                    { 797862468, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(353), 2031119600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(354), 645347740 },
                    { 819787389, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(512), 1823235656, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(513), 483356682 },
                    { 848179147, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(147), -2074810344, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(148), 775048932 },
                    { 854848361, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(768), -176215440, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(769), 788453213 },
                    { 864279210, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(398), -1740572136, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(399), 483356682 },
                    { 879796850, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(477), 1250029600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(479), 788453213 },
                    { 893739058, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(816), -1346568008, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(817), 645347740 },
                    { 900787688, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(500), 1823235656, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(501), 775048932 },
                    { 901762042, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(208), -2053333800, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(209), 775048932 },
                    { 906560578, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(745), -176215440, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(746), 483356682 },
                    { 909338496, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(827), -1346568008, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(829), 788453213 },
                    { 947679970, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(733), -176215440, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(734), 775048932 },
                    { 987077714, 0f, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(130), -2074810344, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(132), 977900100 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 544718612, 156200225, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8919), 142560835, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8920) },
                    { 544718612, 646834733, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8996), 727329112, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8997) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 544718612, 731387889, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8832), 479622928, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(8833) });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 544718612, 862408246, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9067), 736604204, new DateTime(2024, 3, 12, 14, 38, 17, 454, DateTimeKind.Local).AddTicks(9069) });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 447527393, 124213640, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3732), -1323494009, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3733) },
                    { 693998400, 124213640, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3708), -71056862, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3710) },
                    { 703962669, 124213640, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3720), 1990386081, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3721) },
                    { 447527393, 129082334, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5033), 1326948899, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5034) },
                    { 693998400, 129082334, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5009), -1092185540, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5010) },
                    { 703962669, 129082334, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5021), 509602118, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5022) },
                    { 447527393, 138157446, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5069), 1706257350, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5070) },
                    { 693998400, 138157446, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5045), -164782052, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5046) },
                    { 703962669, 138157446, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5057), -270891764, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5058) },
                    { 447527393, 151489026, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4742), 111080422, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4743) },
                    { 693998400, 151489026, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4718), 240806494, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4719) },
                    { 703962669, 151489026, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4730), 1154026427, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4731) },
                    { 447527393, 152350606, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3839), -1300815746, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3840) },
                    { 693998400, 152350606, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3815), 82653791, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3817) },
                    { 703962669, 152350606, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3827), -1002674483, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3828) },
                    { 447527393, 153904930, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3513), 36840758, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3514) },
                    { 693998400, 153904930, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3489), -368658193, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3490) },
                    { 703962669, 153904930, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3501), -419429897, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3502) },
                    { 447527393, 159169745, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5282), 1842538869, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5283) },
                    { 693998400, 159169745, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5258), 1320755216, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5259) },
                    { 703962669, 159169745, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5270), -1227604859, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5271) },
                    { 447527393, 160079701, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4887), 1517862983, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4888) },
                    { 693998400, 160079701, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4863), -1687199975, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4864) },
                    { 703962669, 160079701, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4874), 169034734, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4876) },
                    { 447527393, 164143747, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3624), -653743187, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3625) },
                    { 693998400, 164143747, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3599), 2106721224, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3601) },
                    { 703962669, 164143747, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3612), -1195395164, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3613) },
                    { 447527393, 172919199, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4164), -872214979, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4166) },
                    { 693998400, 172919199, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4141), -1315789712, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4142) },
                    { 703962669, 172919199, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4152), 617385407, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4154) },
                    { 447527393, 178313389, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4851), 2104004804, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4852) },
                    { 693998400, 178313389, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4827), -794257051, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4828) },
                    { 703962669, 178313389, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4839), -388486705, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4840) },
                    { 447527393, 183565497, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4671), 1555570148, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4672) },
                    { 693998400, 183565497, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4646), -196952575, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4647) },
                    { 703962669, 183565497, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4659), 1404110921, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4660) },
                    { 447527393, 195484708, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4524), -328251406, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4525) },
                    { 693998400, 195484708, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4500), -2084273162, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4501) },
                    { 703962669, 195484708, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4512), 1030735904, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4513) },
                    { 447527393, 231737212, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3696), -914217691, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3697) },
                    { 693998400, 231737212, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3673), 336837227, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3674) },
                    { 703962669, 231737212, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3684), -815628752, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3686) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 447527393, 233681701, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4777), 280838890, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4778) },
                    { 693998400, 233681701, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4754), -1804465228, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4755) },
                    { 703962669, 233681701, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4766), 264613460, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4767) },
                    { 447527393, 242455373, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4706), 408318760, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4707) },
                    { 693998400, 242455373, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4682), 672831203, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4684) },
                    { 703962669, 242455373, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4695), -1912272722, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4696) },
                    { 447527393, 289772323, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3331), -382990576, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3332) },
                    { 693998400, 289772323, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3307), -1212107053, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3308) },
                    { 703962669, 289772323, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3319), -531977471, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3320) },
                    { 447527393, 306249706, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4815), 1232745264, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4816) },
                    { 693998400, 306249706, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4791), 989512214, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4792) },
                    { 703962669, 306249706, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4803), 117147367, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4804) },
                    { 447527393, 323453825, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3369), 1574799368, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3370) },
                    { 693998400, 323453825, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3345), 1413791892, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3346) },
                    { 703962669, 323453825, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3357), 1589107991, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3358) },
                    { 447527393, 327080627, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4200), -259989709, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4201) },
                    { 693998400, 327080627, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4176), -2054949304, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4178) },
                    { 703962669, 327080627, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4188), -223425404, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4189) },
                    { 447527393, 333298894, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5176), -1216860736, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5177) },
                    { 693998400, 333298894, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5152), 45545756, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5153) },
                    { 703962669, 333298894, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5164), -589385110, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5165) },
                    { 447527393, 346215283, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3874), -1288787372, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3876) },
                    { 693998400, 346215283, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3851), 18772925, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3852) },
                    { 703962669, 346215283, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3863), -529815275, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3864) },
                    { 447527393, 365693746, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4236), -225937390, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4237) },
                    { 693998400, 365693746, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4212), -2137559453, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4213) },
                    { 703962669, 365693746, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4224), -1379986190, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4225) },
                    { 447527393, 366979311, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4129), -1122896600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4130) },
                    { 693998400, 366979311, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4105), 1846919237, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4106) },
                    { 703962669, 366979311, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4117), -1203783695, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4118) },
                    { 447527393, 370980276, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4962), -556138124, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4963) },
                    { 693998400, 370980276, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4938), 1934539997, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4939) },
                    { 703962669, 370980276, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4950), -1442775815, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4951) },
                    { 447527393, 375943914, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4022), -277194293, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4023) },
                    { 693998400, 375943914, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3997), -1836214271, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3998) },
                    { 703962669, 375943914, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4008), -443235401, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4010) },
                    { 447527393, 404541525, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4595), 486157721, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4596) },
                    { 693998400, 404541525, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4571), 1127151216, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4572) },
                    { 703962669, 404541525, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4583), -36025969, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4584) },
                    { 447527393, 414073318, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4559), 1600530134, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4560) },
                    { 693998400, 414073318, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4535), 108049420, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4537) },
                    { 703962669, 414073318, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4547), 2004421622, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4548) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 447527393, 446318733, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3948), -599329520, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3949) },
                    { 693998400, 446318733, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3922), 1533100154, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3923) },
                    { 703962669, 446318733, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3933), -19530175, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3934) },
                    { 447527393, 475985034, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3404), -617662714, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3405) },
                    { 693998400, 475985034, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3381), 1916318813, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3382) },
                    { 703962669, 475985034, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3393), 644285156, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3394) },
                    { 447527393, 478351938, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4488), -507030389, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4489) },
                    { 693998400, 478351938, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4465), -1707005384, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4466) },
                    { 703962669, 478351938, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4476), -2139384473, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4478) },
                    { 447527393, 491909853, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3548), 1651825346, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3550) },
                    { 693998400, 491909853, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3525), 1113027363, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3526) },
                    { 703962669, 491909853, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3537), 254082596, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3538) },
                    { 447527393, 493127686, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3767), 1349165907, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3768) },
                    { 693998400, 493127686, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3744), -1936221025, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3745) },
                    { 703962669, 493127686, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3756), 183615688, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3757) },
                    { 447527393, 511000805, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4925), 734471213, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4926) },
                    { 693998400, 511000805, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4899), 855209939, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4900) },
                    { 703962669, 511000805, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4911), -1688120014, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4912) },
                    { 447527393, 516606989, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5321), 1831923072, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5323) },
                    { 693998400, 516606989, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5297), 311651339, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5299) },
                    { 703962669, 516606989, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5309), 898607795, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5311) },
                    { 447527393, 572836164, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4274), -1317084812, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4275) },
                    { 693998400, 572836164, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4247), 210748762, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4249) },
                    { 703962669, 572836164, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4259), 1710052002, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4260) },
                    { 447527393, 582941415, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4093), -1727178803, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4095) },
                    { 693998400, 582941415, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4069), -852027763, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4070) },
                    { 703962669, 582941415, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4081), -1474750223, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4083) },
                    { 447527393, 597213357, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3661), -220505309, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3662) },
                    { 693998400, 597213357, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3637), 1420717068, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3638) },
                    { 703962669, 597213357, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3649), -1272082882, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3650) },
                    { 447527393, 607831565, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3441), 279829589, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3442) },
                    { 693998400, 607831565, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3416), -641359633, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3417) },
                    { 703962669, 607831565, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3428), 828854708, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3429) },
                    { 447527393, 648469365, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3984), 1422170933, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3985) },
                    { 693998400, 648469365, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3961), 1417029795, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3962) },
                    { 703962669, 648469365, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3973), -1230042572, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3974) },
                    { 447527393, 672315645, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4997), 890093678, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4998) },
                    { 693998400, 672315645, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4974), 1056920252, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4975) },
                    { 703962669, 672315645, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4985), -1895702215, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4986) },
                    { 447527393, 685366757, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4630), -1154519428, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4632) },
                    { 693998400, 685366757, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4607), 1624958424, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4608) },
                    { 703962669, 685366757, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4619), -1004779345, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4620) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 447527393, 690756845, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3804), -57332659, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3805) },
                    { 693998400, 690756845, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3779), -789275965, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3781) },
                    { 703962669, 690756845, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3791), -11401217, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3792) },
                    { 447527393, 698689711, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4345), -1533399295, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4346) },
                    { 693998400, 698689711, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4321), 1552366422, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4322) },
                    { 703962669, 698689711, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4333), -524699252, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4334) },
                    { 447527393, 733863921, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4453), 1581329804, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4454) },
                    { 693998400, 733863921, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4429), -2125755328, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4430) },
                    { 703962669, 733863921, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4441), 295265498, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4442) },
                    { 447527393, 768889819, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3584), -1219431892, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3585) },
                    { 693998400, 768889819, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3561), 1378344506, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3562) },
                    { 703962669, 768889819, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3572), 405185027, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3573) },
                    { 447527393, 785721196, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5247), -1264475564, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5248) },
                    { 693998400, 785721196, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5223), -176662759, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5224) },
                    { 703962669, 785721196, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5235), -1433369461, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5236) },
                    { 447527393, 797862468, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3910), 389942762, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3911) },
                    { 693998400, 797862468, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3886), 1956780558, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3887) },
                    { 703962669, 797862468, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3898), -1107396022, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3899) },
                    { 447527393, 819787389, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4417), -1352123482, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4418) },
                    { 693998400, 819787389, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4394), 1235665008, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4395) },
                    { 703962669, 819787389, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4406), -114783934, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4407) },
                    { 447527393, 848179147, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3295), -973466491, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3296) },
                    { 693998400, 848179147, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3270), -1508311160, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3271) },
                    { 703962669, 848179147, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3282), 1341266292, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3283) },
                    { 447527393, 854848361, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5211), 1574206767, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5212) },
                    { 693998400, 854848361, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5188), 326470600, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5189) },
                    { 703962669, 854848361, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5199), -963629185, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5200) },
                    { 447527393, 864279210, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4057), 1829566472, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4058) },
                    { 693998400, 864279210, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4034), -830753216, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4035) },
                    { 703962669, 864279210, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4046), 330538681, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4047) },
                    { 447527393, 879796850, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4309), 1780760642, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4311) },
                    { 693998400, 879796850, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4286), 1529026344, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4287) },
                    { 703962669, 879796850, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4298), -1149697102, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4299) },
                    { 447527393, 893739058, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5357), -1019307685, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5358) },
                    { 693998400, 893739058, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5333), -115468159, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5335) },
                    { 703962669, 893739058, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5345), 180976249, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5346) },
                    { 447527393, 900787688, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4382), -1171532888, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4383) },
                    { 693998400, 900787688, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4357), -26822708, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4359) },
                    { 703962669, 900787688, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4369), -435493030, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(4370) },
                    { 447527393, 901762042, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3477), -2122026857, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3478) },
                    { 693998400, 901762042, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3453), -60180776, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3454) },
                    { 703962669, 901762042, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3465), -723348350, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3466) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 447527393, 906560578, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5140), -1242506866, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5141) },
                    { 693998400, 906560578, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5117), 366774485, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5118) },
                    { 703962669, 906560578, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5128), 2009598863, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5130) },
                    { 447527393, 909338496, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5393), -935533511, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5394) },
                    { 693998400, 909338496, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5369), -1726439705, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5370) },
                    { 703962669, 909338496, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5381), -1420747685, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5382) },
                    { 447527393, 947679970, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5105), -169962146, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5106) },
                    { 693998400, 947679970, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5081), -266102891, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5082) },
                    { 703962669, 947679970, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5093), 1987750053, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(5094) },
                    { 447527393, 987077714, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3257), 958985393, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3259) },
                    { 693998400, 987077714, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3221), -1438812310, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3222) },
                    { 703962669, 987077714, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3244), -1635478379, new DateTime(2024, 3, 12, 14, 38, 17, 455, DateTimeKind.Local).AddTicks(3245) }
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
