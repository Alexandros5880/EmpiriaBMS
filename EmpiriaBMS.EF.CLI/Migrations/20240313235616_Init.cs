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
                    { 131628184, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7124), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7125), "Fire Suppression" },
                    { 172260385, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7301), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7302), "Project Manager Hours" },
                    { 203759198, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7097), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7098), "Drainage" },
                    { 211974768, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7163), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7164), "Power Distribution" },
                    { 264272812, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7109), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7111), "Fire Detection" },
                    { 364847783, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7046), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7047), "HVAC" },
                    { 421270249, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7231), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7232), "Photovoltaics" },
                    { 515501566, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7083), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7085), "Potable Water" },
                    { 522865995, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7137), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7138), "Elevators" },
                    { 570574572, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7257), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7258), "Outsource" },
                    { 683749887, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7270), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7271), "TenderDocument" },
                    { 734606597, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7204), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7206), "CCTV" },
                    { 739164806, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7218), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7219), "BMS" },
                    { 761052882, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7191), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7193), "Burglar Alarm" },
                    { 816416837, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7284), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7286), "Construction Supervision" },
                    { 822776336, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7070), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7071), "Sewage" },
                    { 878891115, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7244), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7245), "Energy Efficiency" },
                    { 903767675, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7178), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7179), "Structured Cabling" },
                    { 918282165, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7150), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7151), "Natural Gas" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 707783922, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7529), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7530), "Documents" },
                    { 928450064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7546), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7547), "Calculations" },
                    { 971122747, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7558), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7560), "Drawings" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 262794403, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8117), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8118), "Printing" },
                    { 347259098, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8152), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8153), "Administration" },
                    { 556785712, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8095), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8097), "Communications" },
                    { 562701908, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8129), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8130), "On-Site" },
                    { 894920906, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8140), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8141), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 180650230, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4206), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4207), "See Dashboard Layout", 1 },
                    { 238179056, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4382), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4384), "Dashboard See My Hours", 8 },
                    { 368310583, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4368), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4370), "See Admin Layout", 7 },
                    { 389515541, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4423), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4424), "See All Projects", 11 },
                    { 599798696, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4310), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4311), "Dashboard Assign Designer", 3 },
                    { 623501136, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4355), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4356), "Dashboard Add Project", 6 },
                    { 651103419, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4410), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4411), "See All Drawings", 10 },
                    { 746372977, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4396), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4397), "See All Disciplines", 9 },
                    { 818703368, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4339), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4340), "Dashboard Assign Project Manager", 5 },
                    { 898707725, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4294), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4295), "Dashboard Edit My Hours", 2 },
                    { 988084498, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4325), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4326), "Dashboard Assign Engineer", 4 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 287906892, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6548), "Energy Description", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6549), "Energy" },
                    { 322808741, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6535), "Infrastructure Description", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6536), "Infrastructure" },
                    { 405654346, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6573), "Production Management Description", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6574), "Production Management" },
                    { 423322524, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6560), "Consulting Description", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6561), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { 553686263, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6518), "Buildings Description", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6519), "Buildings" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 200628071, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4483), false, true, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4484), "Project Manager" },
                    { 282065030, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4469), false, true, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4470), "Engineer" },
                    { 467086365, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4510), false, true, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4511), "CTO" },
                    { 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4496), false, true, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4498), "COO" },
                    { 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4524), false, true, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4525), "CEO" },
                    { 618696346, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4537), false, false, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4539), "Guest" },
                    { 627928876, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4551), false, false, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4552), "Customer" },
                    { 856371000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4580), false, false, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4581), "Secretariat" },
                    { 895347435, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4564), false, false, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4566), "Admin" },
                    { 998653718, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4438), false, true, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4440), "Designer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 200907616, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5410), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5412), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6312), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6313), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6227), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6228), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6268), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6270), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6184), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6185), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 342191674, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5353), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5354), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6434), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6435), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6477), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6478), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5891), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5892), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6102), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6103), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6394), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6395), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5931), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5933), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 463244561, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5683), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5684), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 483773346, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5768), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5769), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6353), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6354), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5810), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5811), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5974), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5975), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6143), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6144), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 711419855, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5725), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5726), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 732398512, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5493), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5494), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 805138079, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5534), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5536), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5850), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5852), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 851718699, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5626), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5627), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 891371381, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5579), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5580), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 983635565, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5452), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5453), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6045), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6046), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 231608849, "kkotsoni@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6059), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6060), 996550581 },
                    { 312279333, "ngal@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5989), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5990), 685475690 },
                    { 354873871, "vpax@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5824), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5825), 537863025 },
                    { 355127600, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6325), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6328), 235011510 },
                    { 367527017, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5782), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5783), 483773346 },
                    { 410194891, "pm@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5592), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5593), 891371381 },
                    { 419323512, "guest@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5550), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5551), 805138079 },
                    { 424649888, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5656), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5657), 851718699 },
                    { 465621026, "chkovras@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5945), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5946), 426321622 },
                    { 475847010, "vchontos@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6407), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6408), 425538222 },
                    { 480558497, "vtza@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6117), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6118), 404803692 },
                    { 485836731, "panperivollari@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6447), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6448), 343410463 },
                    { 522555796, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6490), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6492), 353142420 },
                    { 578252159, "embiria@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5643), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5644), 851718699 },
                    { 584826847, "kmargeti@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6200), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6201), 306591482 },
                    { 631783168, "coo@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5507), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5508), 732398512 },
                    { 639727873, "agretos@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6157), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6158), 704919000 },
                    { 720039298, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5740), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5742), 711419855 },
                    { 823292581, "sparisis@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5904), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5905), 355462881 },
                    { 855678060, "haris@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6240), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6242), 280299672 },
                    { 883616616, "blekou@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6367), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6368), 502336796 },
                    { 883993385, "ceo@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5425), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5426), 200907616 },
                    { 897916879, "gdoug@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5698), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5699), 463244561 },
                    { 915660321, "cto@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5466), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5467), 983635565 },
                    { 923209414, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5372), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5373), 342191674 },
                    { 974184498, "pfokianou@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6285), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6286), 292544303 },
                    { 976572763, "xmanarolis@embiria.gr", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5864), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5865), 817271961 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 204225181, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 7.0, 4, new DateTime(2024, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 4, "Test Description Project_2", null, new DateTime(2024, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), new DateTime(2024, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Project_2", 5.0, new DateTime(2024, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Payment Detailes For Project_6", 2.0, null, 322808741, new DateTime(2024, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f },
                    { 434889167, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 8.0, 9, new DateTime(2024, 12, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 9, "Test Description Project_18", null, new DateTime(2024, 12, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), new DateTime(2024, 12, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Project_3", 5.0, new DateTime(2024, 12, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Payment Detailes For Project_9", 3.0, null, 287906892, new DateTime(2024, 12, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f },
                    { 505328951, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 6.0, 1, new DateTime(2024, 4, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 1, "Test Description Project_4", null, new DateTime(2024, 4, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), new DateTime(2024, 4, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Project_1", 5.0, new DateTime(2024, 4, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Payment Detailes For Project_5", 1.0, null, 553686263, new DateTime(2024, 4, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f },
                    { 622065434, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 9.0, 16, new DateTime(2025, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 16, "Test Description Project_4", null, new DateTime(2025, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), new DateTime(2025, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Project_4", 5.0, new DateTime(2025, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Payment Detailes For Project_20", 4.0, null, 423322524, new DateTime(2025, 7, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f },
                    { 809643058, "ALPHA", 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 111.0, 90, new DateTime(2024, 6, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 1, "Test Description Project_PM", null, new DateTime(2024, 4, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), new DateTime(2024, 5, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Project_PM", 45.0, new DateTime(2024, 4, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), "Payment Detailes For Project_PM", 2.0, null, 405654346, new DateTime(2024, 5, 14, 1, 56, 16, 48, DateTimeKind.Local).AddTicks(1662), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 180650230, 200628071, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4729), -169127941, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4730) },
                    { 238179056, 200628071, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4772), 1894416521, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4773) },
                    { 651103419, 200628071, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4802), -775666484, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4804) },
                    { 746372977, 200628071, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4789), -1833972430, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4790) },
                    { 898707725, 200628071, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4742), 1288380411, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4743) },
                    { 988084498, 200628071, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4756), -1436592653, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4759) },
                    { 180650230, 282065030, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4645), 2144496938, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4647) },
                    { 238179056, 282065030, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4687), -664272188, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4689) },
                    { 599798696, 282065030, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4673), 1158324876, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4675) },
                    { 651103419, 282065030, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4715), -211134059, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4716) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 746372977, 282065030, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4701), -1428443648, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4702) },
                    { 898707725, 282065030, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4659), -973894859, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4661) },
                    { 180650230, 467086365, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4940), 1517926023, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4941) },
                    { 238179056, 467086365, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4993), 614922917, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4995) },
                    { 389515541, 467086365, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5034), 214477561, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5035) },
                    { 623501136, 467086365, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4980), 1197932112, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4981) },
                    { 651103419, 467086365, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5020), -262805390, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5021) },
                    { 746372977, 467086365, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5007), -1170788269, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5008) },
                    { 818703368, 467086365, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4967), -17787064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4968) },
                    { 898707725, 467086365, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4954), -118555825, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4955) },
                    { 180650230, 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4816), -1648979837, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4817) },
                    { 238179056, 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4887), -690421778, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4888) },
                    { 389515541, 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4927), 1218492509, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4928) },
                    { 599798696, 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4843), 1727659940, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4845) },
                    { 651103419, 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4913), 1811608709, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4915) },
                    { 746372977, 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4900), -729666859, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4902) },
                    { 818703368, 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4874), -1715632505, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4875) },
                    { 898707725, 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4829), 66071732, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4830) },
                    { 988084498, 502901581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4860), 315978251, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4862) },
                    { 180650230, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5047), 1784043851, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5048) },
                    { 368310583, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5129), -2028956831, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5131) },
                    { 389515541, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5169), -674909540, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5170) },
                    { 599798696, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5075), -1543756162, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5077) },
                    { 623501136, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5116), -1119453236, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5118) },
                    { 651103419, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5156), -921122095, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5157) },
                    { 746372977, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5142), 1738752251, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5144) },
                    { 818703368, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5103), 782300525, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5105) },
                    { 898707725, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5061), 88541470, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5063) },
                    { 988084498, 547554576, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5090), 1275666782, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5092) },
                    { 180650230, 618696346, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5182), 400696358, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5183) },
                    { 180650230, 627928876, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5195), -1947254872, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5197) },
                    { 180650230, 856371000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5272), -28172785, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5274) },
                    { 238179056, 856371000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5299), -561457804, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5300) },
                    { 389515541, 856371000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5338), 1846289147, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5340) },
                    { 651103419, 856371000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5325), -1667095622, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5326) },
                    { 746372977, 856371000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5312), -144335956, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5313) },
                    { 898707725, 856371000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5286), 2109466224, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5287) },
                    { 368310583, 895347435, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5217), 2005138188, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5218) },
                    { 389515541, 895347435, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5259), -1337950732, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5260) },
                    { 651103419, 895347435, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5243), 1310367789, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5244) },
                    { 746372977, 895347435, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5230), -238093217, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5231) },
                    { 180650230, 998653718, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4595), 2026618718, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4596) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 238179056, 998653718, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4632), -1856054362, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4633) },
                    { 898707725, 998653718, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4617), -1578259007, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(4618) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 547554576, 200907616, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5438), 529687451, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5440) },
                    { 282065030, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6340), 178922624, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6341) },
                    { 200628071, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6616), 291188920, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6618) },
                    { 282065030, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6254), 793525683, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6256) },
                    { 282065030, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6298), 579699155, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6299) },
                    { 282065030, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6213), 950677088, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6214) },
                    { 895347435, 342191674, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5390), 379389933, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5392) },
                    { 282065030, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6463), 245549673, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6464) },
                    { 282065030, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6504), 254412282, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6505) },
                    { 282065030, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5917), 439785341, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5918) },
                    { 282065030, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6130), 419230115, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6131) },
                    { 282065030, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6420), 655208578, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6421) },
                    { 282065030, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5960), 188312533, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5962) },
                    { 998653718, 463244561, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5712), 703655782, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5713) },
                    { 998653718, 483773346, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5795), 376701933, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5797) },
                    { 282065030, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6380), 694727582, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6381) },
                    { 200628071, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6587), 324690738, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6588) },
                    { 282065030, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5837), 729407550, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5838) },
                    { 282065030, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6003), 633450704, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6004) },
                    { 547554576, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6030), 226383486, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6031) },
                    { 895347435, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6016), 216436766, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6017) },
                    { 282065030, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6170), 307960511, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6171) },
                    { 998653718, 711419855, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5754), 280052197, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5755) },
                    { 502901581, 732398512, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5520), 146816005, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5521) },
                    { 618696346, 805138079, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5564), 541343054, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5565) },
                    { 282065030, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5877), 705739093, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5879) },
                    { 856371000, 851718699, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5669), 944929864, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5671) },
                    { 200628071, 891371381, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5607), 622082469, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5608) },
                    { 467086365, 983635565, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5479), 256845015, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(5480) },
                    { 200628071, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6602), 105744677, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6603) },
                    { 282065030, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6075), 380495199, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6076) },
                    { 502901581, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6088), 989357983, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6089) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1884463928, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7389), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7390), 204225181, 734606597, null },
                    { -1861477320, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7420), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7421), 204225181, 918282165, null },
                    { -1677613368, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7489), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7490), 622065434, 734606597, null },
                    { -1354384712, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7448), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7449), 434889167, 211974768, null },
                    { -1260535008, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7359), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7360), 505328951, 515501566, null },
                    { -600516888, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7374), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7375), 505328951, 822776336, null },
                    { -341694976, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7514), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7515), 809643058, 172260385, null },
                    { 1043140408, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7403), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7405), 204225181, 211974768, null },
                    { 1356770064, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7461), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7462), 434889167, 264272812, null },
                    { 1525216408, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7502), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7503), 622065434, 522865995, null },
                    { 1630020536, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7476), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7477), 622065434, 203759198, null },
                    { 1852283456, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7434), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7436), 434889167, 918282165, null },
                    { 1898552448, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7335), 0f, 500L, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7336), 505328951, 570574572, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 271583916, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6842), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6845), 3100.0, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6844), "Signature 142344", 39050, 204225181, 2.0, 24.0 },
                    { 300177781, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6925), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6928), 4000.0, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6926), "Signature 142343", 14619, 434889167, 3.0, 17.0 },
                    { 329780941, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7006), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7008), 13000.0, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7007), "Signature 1423420", 68589, 622065434, 4.0, 24.0 },
                    { 715585233, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6749), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6752), 3010.0, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6750), "Signature 142343", 88815, 505328951, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 434889167, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8946), 524628764, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8947) },
                    { 505328951, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8915), 492600183, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8916) },
                    { 622065434, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8958), 278128423, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8959) },
                    { 204225181, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8933), 348670202, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8934) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 144999258, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6882), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6884), null, "6949277783", null, null, 434889167, "alexpl_{i}@gmail.com" },
                    { 236277504, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6964), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6966), null, "6949277784", null, null, 622065434, "alexpl_{i}@gmail.com" },
                    { 742977403, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6698), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6699), null, "6949277781", null, null, 505328951, "alexpl_{i}@gmail.com" },
                    { 947780921, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6797), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6799), null, "6949277782", null, null, 204225181, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1884463928, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9876), 198582134, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9878) },
                    { -1884463928, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9832), 941682625, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9834) },
                    { -1884463928, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9854), 873503289, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9856) },
                    { -1884463928, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9809), 610575106, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9811) },
                    { -1884463928, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9941), 786239037, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9943) },
                    { -1884463928, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9961), 471879366, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9963) },
                    { -1884463928, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9679), 993995701, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9680) },
                    { -1884463928, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9765), 746372932, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9767) },
                    { -1884463928, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9919), 330173335, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9921) },
                    { -1884463928, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9699), 155891117, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9701) },
                    { -1884463928, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9897), 299061341, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9899) },
                    { -1884463928, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9640), 618773651, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9641) },
                    { -1884463928, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9722), 323484041, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9724) },
                    { -1884463928, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9787), 528281226, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9789) },
                    { -1884463928, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9659), 236322804, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9661) },
                    { -1884463928, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9744), 298912246, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9745) },
                    { -1861477320, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(542), 123722329, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(543) },
                    { -1861477320, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(502), 988109772, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(504) },
                    { -1861477320, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(521), 882706863, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(523) },
                    { -1861477320, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(482), 348015829, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(484) },
                    { -1861477320, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(609), 857333957, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(611) },
                    { -1861477320, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(631), 313148921, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(633) },
                    { -1861477320, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(361), 978832403, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(362) },
                    { -1861477320, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(439), 254326756, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(441) },
                    { -1861477320, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(585), 954875490, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(587) },
                    { -1861477320, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(381), 724334472, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(382) },
                    { -1861477320, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(562), 795407224, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(564) },
                    { -1861477320, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(322), 231472358, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(324) },
                    { -1861477320, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(399), 849096569, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(401) },
                    { -1861477320, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(460), 746831668, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(461) },
                    { -1861477320, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(342), 586849737, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(343) },
                    { -1861477320, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(419), 144233274, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(420) },
                    { -1677613368, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1645), 887997089, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1646) },
                    { -1677613368, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1622), 635353127, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1623) },
                    { -1677613368, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1634), 230430234, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1635) },
                    { -1677613368, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1610), 246670345, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1611) },
                    { -1677613368, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1681), 499472125, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1682) },
                    { -1677613368, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1692), 806891480, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1693) },
                    { -1677613368, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1539), 400443483, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1540) },
                    { -1677613368, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1587), 778686036, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1588) },
                    { -1677613368, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1669), 317413565, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1670) },
                    { -1677613368, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1550), 759264195, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1551) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1677613368, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1657), 158581159, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1658) },
                    { -1677613368, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1516), 623827728, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1517) },
                    { -1677613368, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1562), 130389135, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1563) },
                    { -1677613368, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1598), 252774428, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1599) },
                    { -1677613368, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1527), 586176152, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1528) },
                    { -1677613368, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1575), 182278698, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1576) },
                    { -1354384712, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1049), 931628968, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1050) },
                    { -1354384712, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1021), 281350388, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1023) },
                    { -1354384712, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1035), 129582971, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1036) },
                    { -1354384712, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1007), 138328837, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1009) },
                    { -1354384712, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1090), 253802952, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1091) },
                    { -1354384712, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1103), 682144197, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1105) },
                    { -1354384712, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(925), 672238450, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(927) },
                    { -1354384712, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(980), 331566215, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(981) },
                    { -1354384712, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1076), 489418624, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1077) },
                    { -1354384712, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(939), 563025649, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(940) },
                    { -1354384712, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1062), 434703304, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1064) },
                    { -1354384712, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(898), 709840012, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(900) },
                    { -1354384712, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(952), 322426794, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(954) },
                    { -1354384712, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(994), 509956531, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(995) },
                    { -1354384712, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(912), 769317672, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(913) },
                    { -1354384712, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(966), 928552786, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(967) },
                    { -1260535008, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9311), 703809507, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9312) },
                    { -1260535008, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9287), 583332076, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9288) },
                    { -1260535008, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9299), 993893315, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9300) },
                    { -1260535008, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9275), 265208634, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9276) },
                    { -1260535008, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9347), 290963717, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9348) },
                    { -1260535008, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9360), 946195023, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9361) },
                    { -1260535008, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9203), 981238560, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9204) },
                    { -1260535008, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9251), 846093461, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9252) },
                    { -1260535008, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9335), 829083284, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9336) },
                    { -1260535008, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9216), 332687057, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9217) },
                    { -1260535008, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9323), 765901425, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9324) },
                    { -1260535008, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9174), 477696451, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9176) },
                    { -1260535008, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9227), 917103625, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9228) },
                    { -1260535008, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9263), 586656418, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9264) },
                    { -1260535008, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9191), 484283700, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9192) },
                    { -1260535008, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9239), 549772914, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9240) },
                    { -600516888, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9534), 832682295, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9536) },
                    { -600516888, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9490), 388292283, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9492) },
                    { -600516888, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9511), 408168549, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9513) },
                    { -600516888, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9468), 260140393, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9470) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -600516888, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9595), 680587103, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9597) },
                    { -600516888, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9618), 559113579, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9620) },
                    { -600516888, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9397), 255475739, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9398) },
                    { -600516888, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9444), 802552129, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9445) },
                    { -600516888, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9577), 996224263, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9578) },
                    { -600516888, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9409), 377925821, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9410) },
                    { -600516888, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9558), 177115848, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9559) },
                    { -600516888, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9372), 656080226, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9373) },
                    { -600516888, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9420), 464334860, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9421) },
                    { -600516888, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9456), 325590572, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9457) },
                    { -600516888, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9385), 723551121, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9386) },
                    { -600516888, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9432), 929547633, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9433) },
                    { 1043140408, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(218), 215747471, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(219) },
                    { 1043140408, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(176), 531371353, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(178) },
                    { 1043140408, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(196), 152055309, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(198) },
                    { 1043140408, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(155), 563456299, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(157) },
                    { 1043140408, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(281), 443449725, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(283) },
                    { 1043140408, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(301), 216102061, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(303) },
                    { 1043140408, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(27), 387190568, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(29) },
                    { 1043140408, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(109), 854436459, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(111) },
                    { 1043140408, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(260), 652147633, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(262) },
                    { 1043140408, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(46), 460950005, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(48) },
                    { 1043140408, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(238), 717362839, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(240) },
                    { 1043140408, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9982), 135596766, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9984) },
                    { 1043140408, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(66), 849054367, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(68) },
                    { 1043140408, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(134), 322035965, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(135) },
                    { 1043140408, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(6), 683124500, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(8) },
                    { 1043140408, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(87), 272356221, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(89) },
                    { 1356770064, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1256), 773298640, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1257) },
                    { 1356770064, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1233), 575685499, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1234) },
                    { 1356770064, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1245), 571301080, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1246) },
                    { 1356770064, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1221), 960860454, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1222) },
                    { 1356770064, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1292), 318554942, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1293) },
                    { 1356770064, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1303), 823609871, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1304) },
                    { 1356770064, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1150), 673783347, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1151) },
                    { 1356770064, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1198), 785197841, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1199) },
                    { 1356770064, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1280), 412004734, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1281) },
                    { 1356770064, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1163), 374353905, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1164) },
                    { 1356770064, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1268), 286428653, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1269) },
                    { 1356770064, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1118), 839175896, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1119) },
                    { 1356770064, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1174), 790887725, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1175) },
                    { 1356770064, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1210), 446030538, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1211) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1356770064, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1137), 568412388, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1138) },
                    { 1356770064, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1186), 460257254, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1187) },
                    { 1525216408, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1838), 403562865, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1839) },
                    { 1525216408, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1811), 735569627, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1812) },
                    { 1525216408, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1823), 619542740, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1824) },
                    { 1525216408, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1799), 390411333, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1800) },
                    { 1525216408, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1874), 605772685, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1875) },
                    { 1525216408, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1886), 461563320, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1887) },
                    { 1525216408, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1727), 710001290, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1728) },
                    { 1525216408, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1775), 428073279, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1776) },
                    { 1525216408, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1861), 714451629, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1862) },
                    { 1525216408, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1739), 255484449, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1740) },
                    { 1525216408, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1850), 852600232, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1851) },
                    { 1525216408, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1704), 188868815, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1705) },
                    { 1525216408, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1751), 973110208, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1752) },
                    { 1525216408, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1787), 938267108, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1788) },
                    { 1525216408, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1716), 298555811, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1717) },
                    { 1525216408, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1763), 963516137, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1764) },
                    { 1630020536, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1444), 185905374, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1446) },
                    { 1630020536, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1421), 906088603, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1422) },
                    { 1630020536, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1432), 486200499, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1433) },
                    { 1630020536, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1409), 302263701, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1410) },
                    { 1630020536, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1492), 950056352, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1493) },
                    { 1630020536, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1503), 659261823, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1504) },
                    { 1630020536, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1338), 789931202, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1339) },
                    { 1630020536, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1385), 902236736, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1386) },
                    { 1630020536, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1480), 420342298, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1481) },
                    { 1630020536, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1350), 883141291, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1351) },
                    { 1630020536, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1468), 649282557, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1469) },
                    { 1630020536, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1315), 494072626, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1316) },
                    { 1630020536, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1361), 658207575, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1363) },
                    { 1630020536, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1397), 779783019, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1398) },
                    { 1630020536, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1327), 526343567, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1328) },
                    { 1630020536, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1373), 893630396, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(1375) },
                    { 1852283456, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(830), 743535951, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(832) },
                    { 1852283456, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(803), 371252270, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(804) },
                    { 1852283456, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(817), 590516288, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(818) },
                    { 1852283456, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(789), 767627882, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(791) },
                    { 1852283456, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(871), 485756275, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(872) },
                    { 1852283456, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(884), 378278678, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(886) },
                    { 1852283456, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(698), 429186027, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(700) },
                    { 1852283456, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(762), 752310054, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(763) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1852283456, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(857), 943134000, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(859) },
                    { 1852283456, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(716), 450108047, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(717) },
                    { 1852283456, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(844), 749893323, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(846) },
                    { 1852283456, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(653), 262972885, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(655) },
                    { 1852283456, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(730), 466652816, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(731) },
                    { 1852283456, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(776), 772601996, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(777) },
                    { 1852283456, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(674), 669105334, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(676) },
                    { 1852283456, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(744), 916605902, new DateTime(2024, 3, 14, 1, 56, 16, 58, DateTimeKind.Local).AddTicks(745) },
                    { 1898552448, 235011510, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9115), 977367326, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9116) },
                    { 1898552448, 280299672, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9091), 461665057, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9092) },
                    { 1898552448, 292544303, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9103), 547700981, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9104) },
                    { 1898552448, 306591482, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9078), 932805717, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9079) },
                    { 1898552448, 343410463, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9150), 468060110, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9151) },
                    { 1898552448, 353142420, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9162), 171789238, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9163) },
                    { 1898552448, 355462881, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9003), 951934891, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9004) },
                    { 1898552448, 404803692, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9054), 329709009, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9055) },
                    { 1898552448, 425538222, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9139), 574323610, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9140) },
                    { 1898552448, 426321622, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9016), 908968768, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9017) },
                    { 1898552448, 502336796, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9127), 751286831, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9128) },
                    { 1898552448, 537863025, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8972), 270220038, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8973) },
                    { 1898552448, 685475690, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9029), 413705735, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9030) },
                    { 1898552448, 704919000, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9067), 848742284, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9068) },
                    { 1898552448, 817271961, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8991), 525803682, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8992) },
                    { 1898552448, 996550581, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9042), 597369453, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(9043) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 156526402, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7622), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7620), -1260535008, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7621), 707783922 },
                    { 179519068, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7793), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7791), -1861477320, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7792), 928450064 },
                    { 182074657, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7963), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7961), 1630020536, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7962), 971122747 },
                    { 187792034, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7833), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7831), 1852283456, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7832), 928450064 },
                    { 197212854, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7922), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7920), 1356770064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7921), 971122747 },
                    { 238074360, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7729), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7727), -1884463928, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7728), 971122747 },
                    { 259554862, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7635), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7632), -1260535008, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7633), 928450064 },
                    { 259829600, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7935), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7932), 1630020536, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7934), 707783922 },
                    { 310248299, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7677), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7675), -600516888, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7676), 928450064 },
                    { 315350727, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7976), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7974), -1677613368, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7975), 707783922 },
                    { 326872327, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7859), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7856), -1354384712, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7857), 707783922 },
                    { 337365644, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7767), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7765), 1043140408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7766), 971122747 },
                    { 433161113, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7910), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7907), 1356770064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7909), 928450064 },
                    { 445938125, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7704), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7702), -1884463928, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7703), 707783922 },
                    { 514463645, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7780), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7778), -1861477320, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7779), 707783922 },
                    { 539702028, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7947), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7945), 1630020536, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7946), 928450064 },
                    { 554057080, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7989), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7987), -1677613368, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7988), 928450064 },
                    { 648691918, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7651), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7649), -1260535008, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7650), 971122747 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 663385934, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8042), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8039), 1525216408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8041), 971122747 },
                    { 679877012, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8056), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8053), -341694976, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8054), 707783922 },
                    { 700555400, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7717), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7715), -1884463928, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7716), 928450064 },
                    { 749261641, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7846), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7843), 1852283456, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7844), 971122747 },
                    { 765603546, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7821), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7818), 1852283456, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7819), 707783922 },
                    { 776782553, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7690), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7688), -600516888, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7689), 971122747 },
                    { 805163879, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8082), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8080), -341694976, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8081), 971122747 },
                    { 826057389, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7871), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7869), -1354384712, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7870), 928450064 },
                    { 829728665, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8002), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7999), -1677613368, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8000), 971122747 },
                    { 840091998, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7755), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7752), 1043140408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7754), 928450064 },
                    { 858495478, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7897), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7895), 1356770064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7896), 707783922 },
                    { 864012849, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7884), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7882), -1354384712, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7883), 971122747 },
                    { 878498846, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8017), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8014), 1525216408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8015), 707783922 },
                    { 927166236, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7609), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7606), 1898552448, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7607), 971122747 },
                    { 928706952, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7595), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7593), 1898552448, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7594), 928450064 },
                    { 929803524, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7808), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7805), -1861477320, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7807), 971122747 },
                    { 945126600, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8070), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8067), -341694976, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8068), 928450064 },
                    { 953090013, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7742), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7740), 1043140408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7741), 707783922 },
                    { 972291508, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7578), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7575), 1898552448, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7576), 707783922 },
                    { 973497000, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8029), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8027), 1525216408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8028), 928450064 },
                    { 987783850, new DateTime(2024, 3, 25, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7665), 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7662), -600516888, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(7663), 707783922 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 317584664, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6898), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6899), 144999258 },
                    { 498529786, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6979), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6981), 236277504 },
                    { 513415664, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6717), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6718), 742977403 },
                    { 567766846, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6814), new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6815), 947780921 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124531506, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8618), -1354384712, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8619), 347259098 },
                    { 126554233, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8368), -1884463928, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8370), 562701908 },
                    { 130041451, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8278), -1260535008, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8279), 347259098 },
                    { 134136115, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8491), -1861477320, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8492), 894920906 },
                    { 141656281, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8880), -341694976, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8881), 562701908 },
                    { 144465678, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8673), 1356770064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8674), 347259098 },
                    { 187884152, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8584), -1354384712, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8585), 262794403 },
                    { 188997626, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8729), 1630020536, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8730), 347259098 },
                    { 202619541, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8391), -1884463928, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8392), 347259098 },
                    { 219559783, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8840), 1525216408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8841), 347259098 },
                    { 228938179, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8334), -600516888, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8335), 347259098 },
                    { 229476838, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8562), 1852283456, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8563), 347259098 },
                    { 255450949, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8751), -1677613368, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8752), 262794403 },
                    { 277801663, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8573), -1354384712, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8574), 556785712 },
                    { 315270636, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8514), 1852283456, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8515), 556785712 },
                    { 326846140, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8684), 1630020536, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8686), 556785712 },
                    { 343108496, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8181), 1898552448, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8183), 262794403 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 350038932, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8695), 1630020536, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8696), 262794403 },
                    { 354209965, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8868), -341694976, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8870), 262794403 },
                    { 368219364, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8301), -600516888, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8302), 262794403 },
                    { 373148775, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8345), -1884463928, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8347), 556785712 },
                    { 377721459, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8806), 1525216408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8808), 262794403 },
                    { 378154614, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8240), -1260535008, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8241), 262794403 },
                    { 378700424, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8194), 1898552448, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8195), 562701908 },
                    { 383021325, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8469), -1861477320, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8470), 262794403 },
                    { 391946287, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8312), -600516888, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8313), 562701908 },
                    { 399448741, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8550), 1852283456, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8552), 894920906 },
                    { 414853720, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8795), 1525216408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8796), 556785712 },
                    { 418760808, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8525), 1852283456, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8526), 262794403 },
                    { 432299154, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8254), -1260535008, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8256), 562701908 },
                    { 449618775, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8480), -1861477320, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8481), 562701908 },
                    { 451002901, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8607), -1354384712, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8608), 894920906 },
                    { 452413310, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8640), 1356770064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8642), 262794403 },
                    { 476341576, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8651), 1356770064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8652), 562701908 },
                    { 477858485, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8356), -1884463928, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8357), 262794403 },
                    { 501921838, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8435), 1043140408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8437), 894920906 },
                    { 512469146, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8596), -1354384712, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8597), 562701908 },
                    { 512669376, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8891), -341694976, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8892), 894920906 },
                    { 545537410, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8458), -1861477320, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8459), 556785712 },
                    { 561625218, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8205), 1898552448, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8206), 894920906 },
                    { 604122781, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8762), -1677613368, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8763), 562701908 },
                    { 615499594, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8266), -1260535008, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8267), 894920906 },
                    { 650934170, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8402), 1043140408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8403), 556785712 },
                    { 656093028, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8290), -600516888, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8291), 556785712 },
                    { 673223608, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8852), -341694976, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8854), 556785712 },
                    { 681900825, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8830), 1525216408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8831), 894920906 },
                    { 689004236, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8784), -1677613368, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8785), 347259098 },
                    { 705858781, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8773), -1677613368, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8774), 894920906 },
                    { 708526501, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8819), 1525216408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8820), 562701908 },
                    { 729234905, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8167), 1898552448, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8168), 556785712 },
                    { 732422557, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8629), 1356770064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8630), 556785712 },
                    { 794372780, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8740), -1677613368, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8741), 556785712 },
                    { 798176589, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8413), 1043140408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8414), 262794403 },
                    { 861390819, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8380), -1884463928, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8381), 894920906 },
                    { 863180688, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8424), 1043140408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8425), 562701908 },
                    { 867901976, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8707), 1630020536, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8708), 562701908 },
                    { 904081641, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8228), -1260535008, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8229), 556785712 },
                    { 914929724, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8323), -600516888, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8324), 894920906 },
                    { 917444714, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8902), -341694976, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8903), 347259098 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 926102255, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8717), 1630020536, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8718), 894920906 },
                    { 928616258, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8446), 1043140408, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8447), 347259098 },
                    { 932296316, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8536), 1852283456, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8537), 562701908 },
                    { 933983131, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8216), 1898552448, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8217), 347259098 },
                    { 954625672, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8662), 1356770064, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8664), 894920906 },
                    { 983600537, 0f, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8502), -1861477320, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(8503), 347259098 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 627928876, 144999258, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6912), 553365811, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6913) },
                    { 627928876, 236277504, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6993), 689480729, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6995) },
                    { 627928876, 742977403, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6732), 751596095, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6734) },
                    { 627928876, 947780921, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6828), 428071538, new DateTime(2024, 3, 14, 1, 56, 16, 57, DateTimeKind.Local).AddTicks(6829) }
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
