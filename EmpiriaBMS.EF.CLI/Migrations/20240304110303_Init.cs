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
                    { 164858253, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8739), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8741), "Potable Water" },
                    { 175835317, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8860), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8861), "CCTV" },
                    { 220830717, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8766), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8767), "Fire Detection" },
                    { 296249470, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8781), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8782), "Fire Suppression" },
                    { 343254911, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8923), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8924), "TenderDocument" },
                    { 372386263, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8807), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8808), "Natural Gas" },
                    { 415310573, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8705), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8706), "HVAC" },
                    { 456133838, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8937), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8939), "Construction Supervision" },
                    { 574124011, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8726), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8727), "Sewage" },
                    { 581969039, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8834), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8835), "Structured Cabling" },
                    { 643217270, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8847), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8848), "Burglar Alarm" },
                    { 643760107, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8819), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8821), "Power Distribution" },
                    { 675950813, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8753), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8754), "Drainage" },
                    { 811649384, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8885), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8886), "Photovoltaics" },
                    { 818575233, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8910), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8911), "Outsource" },
                    { 833768567, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8794), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8795), "Elevators" },
                    { 839478473, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8872), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8873), "BMS" },
                    { 931619014, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8897), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8899), "Energy Efficiency" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 403854693, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9138), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9139), "Documents" },
                    { 669408468, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9155), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9156), "Calculations" },
                    { 709229865, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9168), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9169), "Drawings" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 157204008, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9697), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9698), "Communications" },
                    { 437346400, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9754), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9756), "Administration" },
                    { 465198673, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9729), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9730), "On-Site" },
                    { 538511898, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9716), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9717), "Printing" },
                    { 853759192, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9742), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9743), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 145073612, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6971), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6973), "Dashboard Assign Project Manager", 5 },
                    { 154068226, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6992), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6993), "Dashboard Add Project", 6 },
                    { 195990240, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6942), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6943), "Dashboard Assign Designer", 3 },
                    { 260065160, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6923), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6924), "Dashboard Edit My Hours", 2 },
                    { 302031533, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6766), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6768), "See Dashboard Layout", 1 },
                    { 708323739, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6957), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(6958), "Dashboard Assign Engineer", 4 },
                    { 956818570, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7006), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7008), "See Admin Layout", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 223438491, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8196), "Buildings Description", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8198), "Buildings" },
                    { 419665527, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8244), "Consulting Description", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8245), "Consulting" },
                    { 501036923, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8213), "Infrastructure Description", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8215), "Infrastructure" },
                    { 827097881, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8228), "Energy Description", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8230), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 164000245, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7102), false, true, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7103), "CEO" },
                    { 194809091, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7022), false, true, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7023), "Designer" },
                    { 346687028, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7132), false, false, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7133), "Customer" },
                    { 391520743, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7072), false, true, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7073), "COO" },
                    { 392151490, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7042), false, true, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7044), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 396794635, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7147), false, false, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7148), "Admin" },
                    { 439524049, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7117), false, false, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7119), "Guest" },
                    { 812713320, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7057), false, true, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7059), "Project Manager" },
                    { 840348790, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7086), false, true, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7088), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 193982548, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8270), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8271), null, "6949277781", null, null, null },
                    { 240182205, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7702), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7703), null, "694927778", null, null, null },
                    { 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8134), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8135), null, "6949277784", null, null, null },
                    { 289111365, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7859), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7861), null, "6949277782", null, null, null },
                    { 289935222, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7732), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7733), null, "694927778", null, null, null },
                    { 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8061), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8063), null, "6949277782", null, null, null },
                    { 314317098, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7921), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7922), null, "6949277784", null, null, null },
                    { 324322578, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8366), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8368), null, "6949277784", null, null, null },
                    { 342555527, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7953), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7954), null, "6949277785", null, null, null },
                    { 377820071, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8305), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8306), null, "6949277782", null, null, null },
                    { 395578488, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7890), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7891), null, "6949277783", null, null, null },
                    { 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7985), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7986), null, "6949277780", null, null, null },
                    { 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8031), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8032), null, "6949277781", null, null, null },
                    { 610482355, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7605), "Admin", "admin@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7606), null, "694927778", null, null, null },
                    { 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8094), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8095), null, "6949277783", null, null, null },
                    { 738858969, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7673), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7674), null, "694927778", null, null, null },
                    { 742928482, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7642), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7643), null, "694927778", null, null, null },
                    { 784481623, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7767), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7768), null, "6949277780", null, null, null },
                    { 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8164), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8166), null, "6949277785", null, null, null },
                    { 827209136, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8334), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8335), null, "6949277783", null, null, null },
                    { 957857250, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7828), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7829), null, "6949277781", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 187779731, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 8.0, 9, new DateTime(2024, 12, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 9, "Test Description Project_12", "KL-3", new DateTime(2024, 12, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), new DateTime(2024, 12, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 0f, 100L, 12L, new DateTime(2024, 3, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), "Project_3", 5.0, new DateTime(2024, 12, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), "Payment Detailes For Project_12", 3.0, null, 827097881, new DateTime(2024, 12, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 0f },
                    { 521183936, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 9.0, 16, new DateTime(2025, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 16, "Test Description Project_4", "KL-4", new DateTime(2025, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), new DateTime(2025, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 0f, 100L, 12L, new DateTime(2024, 3, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), "Project_4", 5.0, new DateTime(2025, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), "Payment Detailes For Project_16", 4.0, null, 419665527, new DateTime(2025, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 0f },
                    { 784492054, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 7.0, 4, new DateTime(2024, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 4, "Test Description Project_12", "KL-2", new DateTime(2024, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), new DateTime(2024, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 0f, 100L, 12L, new DateTime(2024, 3, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), "Project_2", 5.0, new DateTime(2024, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), "Payment Detailes For Project_4", 2.0, null, 501036923, new DateTime(2024, 7, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 0f },
                    { 976996606, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 6.0, 1, new DateTime(2024, 4, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 1, "Test Description Project_2", "KL-1", new DateTime(2024, 4, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), new DateTime(2024, 4, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 0f, 100L, 12L, new DateTime(2024, 3, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), "Project_1", 5.0, new DateTime(2024, 4, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), "Payment Detailes For Project_1", 1.0, null, 223438491, new DateTime(2024, 4, 4, 13, 3, 3, 304, DateTimeKind.Local).AddTicks(8148), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 145073612, 164000245, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7518), 1233555975, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7519) },
                    { 154068226, 164000245, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7532), 1664776040, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7533) },
                    { 195990240, 164000245, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7489), -253079369, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7491) },
                    { 260065160, 164000245, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7475), 1948997745, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7476) },
                    { 302031533, 164000245, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7461), 1831264898, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7462) },
                    { 708323739, 164000245, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7504), -2011895486, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7505) },
                    { 956818570, 164000245, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7546), -789212969, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7547) },
                    { 260065160, 194809091, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7198), -434687827, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7199) },
                    { 302031533, 194809091, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7176), 275863627, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7178) },
                    { 302031533, 346687028, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7574), -1472373413, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7575) },
                    { 145073612, 391520743, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7357), 1267753788, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7359) },
                    { 195990240, 391520743, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7329), -1101635833, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7330) },
                    { 260065160, 391520743, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7315), -1638643, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7316) },
                    { 302031533, 391520743, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7300), -35247496, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7301) },
                    { 708323739, 391520743, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7343), 2134181376, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7345) },
                    { 195990240, 392151490, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7241), 1037802443, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7243) },
                    { 260065160, 392151490, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7227), -319771048, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7229) },
                    { 302031533, 392151490, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7213), 1142328794, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7214) },
                    { 956818570, 396794635, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7588), -435453772, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7589) },
                    { 302031533, 439524049, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7560), -353242322, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7561) },
                    { 260065160, 812713320, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7271), -921573341, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7272) },
                    { 302031533, 812713320, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7257), 212668718, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7258) },
                    { 708323739, 812713320, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7286), -153771686, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7287) },
                    { 145073612, 840348790, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7433), 400593281, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7434) },
                    { 154068226, 840348790, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7447), 1970189154, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7448) },
                    { 195990240, 840348790, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7400), 220448543, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7401) },
                    { 260065160, 840348790, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7386), -2068435934, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7387) },
                    { 302031533, 840348790, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7371), 2056347716, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7373) },
                    { 708323739, 840348790, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7414), -21960580, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7415) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 812713320, 193982548, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8290), 353923513, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8291) },
                    { 391520743, 240182205, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7717), 172021084, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7719) },
                    { 392151490, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8151), 195709877, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8152) },
                    { 194809091, 289111365, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7876), 866484657, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7877) },
                    { 439524049, 289935222, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7749), 353913205, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7750) },
                    { 392151490, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8081), 378830793, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8082) },
                    { 194809091, 314317098, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7939), 263109062, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7940) },
                    { 812713320, 324322578, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8382), 428066578, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8383) },
                    { 194809091, 342555527, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7969), 485643819, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7970) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 812713320, 377820071, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8321), 633683950, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8322) },
                    { 194809091, 395578488, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7907), 205905342, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7908) },
                    { 392151490, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8016), 316098781, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8018) },
                    { 392151490, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8048), 127400450, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8049) },
                    { 396794635, 610482355, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7624), 156099716, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7625) },
                    { 392151490, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8121), 613135594, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8122) },
                    { 840348790, 738858969, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7688), 511200878, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7689) },
                    { 164000245, 742928482, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7657), 687320638, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7659) },
                    { 194809091, 784481623, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7814), 554108467, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7815) },
                    { 392151490, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8181), 722306145, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8182) },
                    { 812713320, 827209136, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8349), 129232863, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8350) },
                    { 194809091, 957857250, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7846), 283483106, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(7847) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1289436072, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8955), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8957), 976996606, 818575233, null },
                    { -975938376, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9067), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9068), 187779731, 833768567, null },
                    { -825973880, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8982), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8983), 976996606, 675950813, null },
                    { -800977680, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9081), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9082), 187779731, 220830717, null },
                    { -435236240, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8997), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8998), 976996606, 372386263, null },
                    { -123145680, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9053), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9055), 187779731, 818575233, null },
                    { -39304040, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9122), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9123), 521183936, 643217270, null },
                    { 1309361856, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9096), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9097), 521183936, 581969039, null },
                    { 1682697928, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9011), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9012), 784492054, 574124011, null },
                    { 1767581048, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9109), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9110), 521183936, 839478473, null },
                    { 2013951624, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9039), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9040), 784492054, 175835317, null },
                    { 2121186592, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9024), 0f, 1500L, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9026), 784492054, 643760107, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 341102394, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8618), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8621), 4000.0, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8620), "Signature 142346", 71589, 187779731, 3.0, 17.0 },
                    { 475132999, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8551), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8553), 3100.0, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8552), "Signature 1423410", 50415, 784492054, 2.0, 24.0 },
                    { 645448398, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8685), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8688), 13000.0, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8687), "Signature 1423412", 77979, 521183936, 4.0, 24.0 },
                    { 900883035, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8476), new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8479), 3010.0, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8478), "Signature 142342", 55595, 976996606, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 976996606, 193982548, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(554), 801457050, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(555) },
                    { 521183936, 324322578, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(604), 644170688, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(605) },
                    { 784492054, 377820071, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(573), 696713361, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(574) },
                    { 187779731, 827209136, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(588), 454516903, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(589) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 394582484, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8442), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8443), null, "6949277781", null, null, 976996606 },
                    { 610722832, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8656), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8657), null, "6949277784", null, null, 521183936 },
                    { 711413635, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8520), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8521), null, "6949277782", null, null, 784492054 },
                    { 943728841, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8588), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8589), null, "6949277783", null, null, 187779731 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1289436072, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(679), 453429991, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(680) },
                    { -1289436072, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(652), 542192735, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(654) },
                    { -1289436072, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(618), 236041585, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(620) },
                    { -1289436072, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(639), 345500327, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(640) },
                    { -1289436072, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(666), 168345259, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(667) },
                    { -1289436072, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(693), 522437926, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(694) },
                    { -975938376, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1235), 730069711, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1236) },
                    { -975938376, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1209), 974535410, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1210) },
                    { -975938376, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1183), 612094670, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1184) },
                    { -975938376, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1196), 804005564, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1198) },
                    { -975938376, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1223), 533596855, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1224) },
                    { -975938376, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1249), 378970212, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1250) },
                    { -825973880, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(760), 820950787, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(761) },
                    { -825973880, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(733), 176750121, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(734) },
                    { -825973880, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(707), 159040598, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(708) },
                    { -825973880, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(720), 872088671, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(721) },
                    { -825973880, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(747), 866148430, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(749) },
                    { -825973880, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(773), 766745389, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(774) },
                    { -800977680, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1314), 815046034, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1315) },
                    { -800977680, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1288), 917249377, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1289) },
                    { -800977680, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1262), 436193028, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1263) },
                    { -800977680, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1275), 982061246, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1276) },
                    { -800977680, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1301), 846543142, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1302) },
                    { -800977680, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1327), 952923909, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1328) },
                    { -435236240, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(839), 574277584, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(840) },
                    { -435236240, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(813), 997169916, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(814) },
                    { -435236240, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(786), 501388640, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(788) },
                    { -435236240, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(800), 326817728, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(801) },
                    { -435236240, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(826), 376539634, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(827) },
                    { -435236240, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(854), 650015439, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(855) },
                    { -123145680, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1157), 384208740, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1158) },
                    { -123145680, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1131), 383554143, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1132) },
                    { -123145680, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1105), 489756365, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1106) },
                    { -123145680, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1118), 858588067, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1119) },
                    { -123145680, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1144), 427432839, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1145) },
                    { -123145680, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1170), 487278747, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1171) },
                    { -39304040, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1554), 847452694, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1555) },
                    { -39304040, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1528), 275277417, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1529) },
                    { -39304040, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1501), 339082803, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1502) },
                    { -39304040, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1515), 294728593, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1516) },
                    { -39304040, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1541), 944115504, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1542) },
                    { -39304040, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1567), 322314026, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1568) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1309361856, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1395), 349646750, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1397) },
                    { 1309361856, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1366), 750518441, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1367) },
                    { 1309361856, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1340), 312915044, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1341) },
                    { 1309361856, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1353), 539538031, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1354) },
                    { 1309361856, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1382), 170923631, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1384) },
                    { 1309361856, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1408), 231270208, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1410) },
                    { 1682697928, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(918), 135647090, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(920) },
                    { 1682697928, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(892), 543943294, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(894) },
                    { 1682697928, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(867), 972339147, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(868) },
                    { 1682697928, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(880), 237147658, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(881) },
                    { 1682697928, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(905), 788473305, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(907) },
                    { 1682697928, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(931), 461106327, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(932) },
                    { 1767581048, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1474), 981109092, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1475) },
                    { 1767581048, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1448), 981117086, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1449) },
                    { 1767581048, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1422), 830904700, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1423) },
                    { 1767581048, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1434), 579358723, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1436) },
                    { 1767581048, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1461), 228616844, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1462) },
                    { 1767581048, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1488), 412939899, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1489) },
                    { 2013951624, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1079), 400839912, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1080) },
                    { 2013951624, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1051), 239419280, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1053) },
                    { 2013951624, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1026), 554501125, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1027) },
                    { 2013951624, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1039), 736722238, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1040) },
                    { 2013951624, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1066), 350503743, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1067) },
                    { 2013951624, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1092), 433970869, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1093) },
                    { 2121186592, 281202825, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(999), 145848839, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1001) },
                    { 2121186592, 311196568, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(970), 794036802, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(971) },
                    { 2121186592, 538528734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(944), 376312408, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(946) },
                    { 2121186592, 577227420, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(957), 238724221, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(959) },
                    { 2121186592, 633358678, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(983), 770145086, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(984) },
                    { 2121186592, 822324850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1013), 844264829, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1014) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 129232930, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9583), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9580), 1309361856, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9582), 669408468 },
                    { 165450628, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9542), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9539), -800977680, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9540), 669408468 },
                    { 175633132, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9474), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9472), -123145680, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9473), 709229865 },
                    { 197760674, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9232), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9230), -825973880, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9231), 403854693 },
                    { 198786699, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9404), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9402), 2013951624, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9403), 403854693 },
                    { 219224177, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9418), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9416), 2013951624, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9417), 669408468 },
                    { 277415422, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9501), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9499), -975938376, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9500), 669408468 },
                    { 333543194, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9322), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9319), 1682697928, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9320), 403854693 },
                    { 343535595, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9528), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9526), -800977680, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9527), 403854693 },
                    { 368199986, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9447), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9445), -123145680, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9446), 403854693 },
                    { 381883105, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9246), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9243), -825973880, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9245), 669408468 },
                    { 428352461, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9305), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9303), -435236240, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9304), 709229865 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 431736043, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9596), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9594), 1309361856, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9595), 709229865 },
                    { 436146087, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9639), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9637), 1767581048, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9638), 709229865 },
                    { 483288953, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9363), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9361), 2121186592, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9362), 403854693 },
                    { 533102967, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9624), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9621), 1767581048, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9622), 669408468 },
                    { 566401196, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9261), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9259), -825973880, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9260), 709229865 },
                    { 572834992, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9684), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9681), -39304040, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9682), 709229865 },
                    { 609442703, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9569), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9567), 1309361856, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9568), 403854693 },
                    { 643179970, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9218), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9216), -1289436072, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9217), 709229865 },
                    { 643899057, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9390), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9388), 2121186592, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9389), 709229865 },
                    { 646914142, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9487), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9485), -975938376, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9486), 403854693 },
                    { 687485725, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9669), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9667), -39304040, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9668), 669408468 },
                    { 688078645, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9460), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9458), -123145680, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9459), 669408468 },
                    { 692110662, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9349), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9347), 1682697928, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9348), 709229865 },
                    { 718785493, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9555), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9553), -800977680, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9554), 709229865 },
                    { 725150034, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9289), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9287), -435236240, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9288), 669408468 },
                    { 736647523, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9433), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9431), 2013951624, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9432), 709229865 },
                    { 745921197, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9336), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9333), 1682697928, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9334), 669408468 },
                    { 778401277, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9610), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9608), 1767581048, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9609), 403854693 },
                    { 845351680, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9185), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9182), -1289436072, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9183), 403854693 },
                    { 878568526, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9275), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9273), -435236240, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9274), 403854693 },
                    { 888501027, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9377), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9374), 2121186592, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9375), 669408468 },
                    { 906089742, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9514), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9512), -975938376, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9513), 709229865 },
                    { 953021293, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9204), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9201), -1289436072, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9202), 669408468 },
                    { 969929854, new DateTime(2024, 3, 15, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9655), 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9653), -39304040, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9654), 403854693 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 135440589, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(288), -975938376, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(289), 437346400 },
                    { 139425262, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(515), -39304040, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(516), 465198673 },
                    { 150391863, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(351), -800977680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(352), 437346400 },
                    { 163287324, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(326), -800977680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(327), 465198673 },
                    { 165911110, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9815), -1289436072, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9816), 853759192 },
                    { 173004375, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9788), -1289436072, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9789), 538511898 },
                    { 176906910, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(402), 1309361856, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(403), 853759192 },
                    { 184562230, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(389), 1309361856, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(391), 465198673 },
                    { 194209148, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9880), -825973880, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9882), 853759192 },
                    { 201305962, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9962), -435236240, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9963), 437346400 },
                    { 206849975, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9868), -825973880, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9869), 465198673 },
                    { 209268816, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9842), -825973880, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9843), 157204008 },
                    { 217844646, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(263), -975938376, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(265), 465198673 },
                    { 230575221, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(30), 1682697928, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(31), 437346400 },
                    { 244243396, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9908), -435236240, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9909), 157204008 },
                    { 245116549, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9855), -825973880, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9856), 538511898 },
                    { 245713038, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(314), -800977680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(315), 538511898 },
                    { 268380866, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(250), -975938376, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(251), 538511898 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 272757977, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9770), -1289436072, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9771), 157204008 },
                    { 307960805, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(477), 1767581048, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(478), 437346400 },
                    { 326886113, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(119), 2013951624, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(120), 538511898 },
                    { 334502272, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(93), 2121186592, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(95), 437346400 },
                    { 344344436, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(414), 1309361856, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(415), 437346400 },
                    { 384648867, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(106), 2013951624, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(107), 157204008 },
                    { 393648706, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4), 1682697928, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5), 465198673 },
                    { 407197330, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(527), -39304040, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(528), 853759192 },
                    { 413271766, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(182), -123145680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(183), 538511898 },
                    { 413432008, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(169), -123145680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(170), 157204008 },
                    { 419815503, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(301), -800977680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(302), 157204008 },
                    { 426644933, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(208), -123145680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(209), 853759192 },
                    { 454462233, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(68), 2121186592, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(69), 465198673 },
                    { 455566259, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(17), 1682697928, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(18), 853759192 },
                    { 457801206, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(502), -39304040, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(503), 538511898 },
                    { 475145393, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9977), 1682697928, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9978), 157204008 },
                    { 502514954, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(221), -123145680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(222), 437346400 },
                    { 521109623, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(56), 2121186592, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(57), 538511898 },
                    { 535925659, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(364), 1309361856, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(365), 157204008 },
                    { 536694109, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(490), -39304040, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(491), 157204008 },
                    { 538791527, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(465), 1767581048, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(466), 853759192 },
                    { 554507085, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(440), 1767581048, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(441), 538511898 },
                    { 555460334, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(427), 1767581048, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(428), 157204008 },
                    { 601701284, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9921), -435236240, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9922), 538511898 },
                    { 605520194, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(81), 2121186592, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(82), 853759192 },
                    { 606425278, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9827), -1289436072, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9828), 437346400 },
                    { 620612391, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(452), 1767581048, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(453), 465198673 },
                    { 638992144, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(43), 2121186592, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(44), 157204008 },
                    { 717039849, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9802), -1289436072, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9803), 465198673 },
                    { 726556770, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9895), -825973880, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9896), 437346400 },
                    { 742852748, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(194), -123145680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(195), 465198673 },
                    { 754519303, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(377), 1309361856, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(378), 538511898 },
                    { 764777282, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9936), -435236240, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9937), 465198673 },
                    { 771090052, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(156), 2013951624, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(157), 437346400 },
                    { 817022590, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9949), -435236240, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9950), 853759192 },
                    { 826420768, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(237), -975938376, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(238), 157204008 },
                    { 833092746, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(339), -800977680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(340), 853759192 },
                    { 839386283, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(143), 2013951624, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(145), 853759192 },
                    { 857248993, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9989), 1682697928, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(9990), 538511898 },
                    { 904981613, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(276), -975938376, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(277), 853759192 },
                    { 926312004, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(540), -39304040, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(541), 437346400 },
                    { 988513297, 0f, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(131), 2013951624, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(132), 465198673 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 346687028, 394582484, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8461), 147910294, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8462) },
                    { 346687028, 610722832, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8672), 460393459, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8673) },
                    { 346687028, 711413635, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8538), 828845545, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8539) },
                    { 346687028, 943728841, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8605), 207999995, new DateTime(2024, 3, 4, 13, 3, 3, 314, DateTimeKind.Local).AddTicks(8606) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289111365, 135440589, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4571), 1016279060, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4572) },
                    { 314317098, 135440589, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4597), -1534019201, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4598) },
                    { 342555527, 135440589, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4610), 2083492476, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4611) },
                    { 395578488, 135440589, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4585), 545319725, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4586) },
                    { 784481623, 135440589, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4546), -1316695652, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4547) },
                    { 957857250, 135440589, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4558), -255719308, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4559) },
                    { 289111365, 139425262, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5939), 1187392082, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5940) },
                    { 314317098, 139425262, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5964), -1352298982, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5965) },
                    { 342555527, 139425262, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5976), 440393963, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5977) },
                    { 395578488, 139425262, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5951), 703601213, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5953) },
                    { 784481623, 139425262, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5914), 33582020, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5915) },
                    { 957857250, 139425262, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5927), 2037140865, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5928) },
                    { 289111365, 150391863, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4959), 1418508923, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4960) },
                    { 314317098, 150391863, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4984), -7678957, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4985) },
                    { 342555527, 150391863, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4997), 2056263579, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4998) },
                    { 395578488, 150391863, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4972), 814192268, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4973) },
                    { 784481623, 150391863, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4934), -60178459, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4935) },
                    { 957857250, 150391863, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4947), -1555165651, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4948) },
                    { 289111365, 163287324, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4802), 1381106520, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4803) },
                    { 314317098, 163287324, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4827), 123576985, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4828) },
                    { 342555527, 163287324, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4841), 282317464, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4842) },
                    { 395578488, 163287324, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4815), 1863526725, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4816) },
                    { 784481623, 163287324, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4777), -1915410982, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4778) },
                    { 957857250, 163287324, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4789), 53909398, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4790) },
                    { 289111365, 165911110, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1846), -1801694213, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1847) },
                    { 314317098, 165911110, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1871), -1480213574, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1872) },
                    { 342555527, 165911110, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1883), -1244172901, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1885) },
                    { 395578488, 165911110, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1858), 1434454173, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1859) },
                    { 784481623, 165911110, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1821), -418043416, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1822) },
                    { 957857250, 165911110, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1833), 1376967150, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1834) },
                    { 289111365, 173004375, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1687), 1201059653, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1689) },
                    { 314317098, 173004375, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1714), 263168497, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1715) },
                    { 342555527, 173004375, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1730), 1648120734, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1731) },
                    { 395578488, 173004375, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1701), -1484227210, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1702) },
                    { 784481623, 173004375, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1662), 1379421302, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1663) },
                    { 957857250, 173004375, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1675), -1966192262, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1676) },
                    { 289111365, 176906910, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5265), -654307217, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5266) },
                    { 314317098, 176906910, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5290), 1945272227, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5291) },
                    { 342555527, 176906910, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5303), 1496439959, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5304) },
                    { 395578488, 176906910, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5278), -673190810, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5279) },
                    { 784481623, 176906910, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5237), 1308934256, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5238) },
                    { 957857250, 176906910, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5253), -839235131, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5254) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289111365, 184562230, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5187), -1544766205, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5188) },
                    { 314317098, 184562230, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5212), -1742816398, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5213) },
                    { 342555527, 184562230, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5224), 287136226, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5225) },
                    { 395578488, 184562230, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5199), -380796776, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5200) },
                    { 784481623, 184562230, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5162), -1076615747, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5163) },
                    { 957857250, 184562230, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5174), -1307961530, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5175) },
                    { 289111365, 194209148, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2225), 252713291, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2226) },
                    { 314317098, 194209148, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2250), 403779173, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2251) },
                    { 342555527, 194209148, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2262), 1791549770, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2263) },
                    { 395578488, 194209148, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2237), -66968675, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2238) },
                    { 784481623, 194209148, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2200), 1376899884, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2201) },
                    { 957857250, 194209148, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2212), -1031038631, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2213) },
                    { 289111365, 201305962, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2677), 1111357269, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2678) },
                    { 314317098, 201305962, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2701), -935845834, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2703) },
                    { 342555527, 201305962, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2715), 1930696088, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2716) },
                    { 395578488, 201305962, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2689), -1531335298, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2690) },
                    { 784481623, 201305962, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2651), -957978764, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2652) },
                    { 957857250, 201305962, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2664), -2002650133, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2665) },
                    { 289111365, 206849975, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2150), 1863013622, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2151) },
                    { 314317098, 206849975, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2175), 55847804, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2176) },
                    { 342555527, 206849975, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2187), 2119498425, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2189) },
                    { 395578488, 206849975, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2162), 1215116204, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2164) },
                    { 784481623, 206849975, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2125), 1134156204, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2126) },
                    { 957857250, 206849975, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2137), -424328647, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2139) },
                    { 289111365, 209268816, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1995), -610642421, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1997) },
                    { 314317098, 209268816, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2022), -1776452300, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2023) },
                    { 342555527, 209268816, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2034), -2081072488, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2035) },
                    { 395578488, 209268816, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2009), 224201557, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2010) },
                    { 784481623, 209268816, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1971), 2007255821, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1972) },
                    { 957857250, 209268816, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1983), -957132962, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1984) },
                    { 289111365, 217844646, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4421), -833924753, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4422) },
                    { 314317098, 217844646, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4446), -401314049, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4447) },
                    { 342555527, 217844646, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4458), 504426479, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4459) },
                    { 395578488, 217844646, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4433), 1520659242, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4434) },
                    { 784481623, 217844646, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4396), -1351371032, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4397) },
                    { 957857250, 217844646, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4408), -886101182, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4410) },
                    { 289111365, 230575221, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3056), -1101619291, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3057) },
                    { 314317098, 230575221, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3081), -2048352434, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3082) },
                    { 342555527, 230575221, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3094), 1321740333, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3095) },
                    { 395578488, 230575221, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3068), -61035259, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3070) },
                    { 784481623, 230575221, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3031), -352237540, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3033) },
                    { 957857250, 230575221, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3044), -1486120031, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3045) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289111365, 244243396, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2375), 1623056450, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2376) },
                    { 314317098, 244243396, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2399), 1795972104, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2401) },
                    { 342555527, 244243396, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2416), -145672784, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2417) },
                    { 395578488, 244243396, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2387), -2128605470, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2388) },
                    { 784481623, 244243396, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2350), -1276525669, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2351) },
                    { 957857250, 244243396, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2362), -2125830307, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2363) },
                    { 289111365, 245116549, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2075), -97799399, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2076) },
                    { 314317098, 245116549, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2100), 827805119, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2101) },
                    { 342555527, 245116549, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2112), -1191903398, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2113) },
                    { 395578488, 245116549, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2087), 1250871525, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2088) },
                    { 784481623, 245116549, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2047), 1291661892, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2048) },
                    { 957857250, 245116549, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2059), -2103858368, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2060) },
                    { 289111365, 245713038, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4727), -248194201, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4728) },
                    { 314317098, 245713038, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4752), 91789043, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4753) },
                    { 342555527, 245713038, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4764), -1617162385, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4765) },
                    { 395578488, 245713038, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4739), -1835151493, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4740) },
                    { 784481623, 245713038, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4702), -782974552, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4703) },
                    { 957857250, 245713038, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4715), 481716725, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4716) },
                    { 289111365, 268380866, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4346), 1059250433, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4347) },
                    { 314317098, 268380866, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4371), 1870497342, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4372) },
                    { 342555527, 268380866, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4383), -371316806, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4384) },
                    { 395578488, 268380866, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4358), 975434, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4359) },
                    { 784481623, 268380866, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4321), -312525157, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4322) },
                    { 957857250, 268380866, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4333), 305436731, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4334) },
                    { 289111365, 272757977, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1611), -1868189332, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1612) },
                    { 314317098, 272757977, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1636), -932100844, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1637) },
                    { 342555527, 272757977, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1649), 489378668, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1650) },
                    { 395578488, 272757977, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1623), -353860357, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1624) },
                    { 784481623, 272757977, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1581), 1164986402, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1583) },
                    { 957857250, 272757977, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1598), 2135246018, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1599) },
                    { 289111365, 307960805, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5716), -1936991843, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5717) },
                    { 314317098, 307960805, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5740), -143272597, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5741) },
                    { 342555527, 307960805, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5753), 717914687, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5754) },
                    { 395578488, 307960805, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5728), -1502115974, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5729) },
                    { 784481623, 307960805, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5691), 68370670, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5692) },
                    { 957857250, 307960805, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5703), 1951607255, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5705) },
                    { 289111365, 326886113, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3587), 1215143267, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3589) },
                    { 314317098, 326886113, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3612), 1919700266, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3613) },
                    { 342555527, 326886113, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3625), -1809620873, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3626) },
                    { 395578488, 326886113, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3600), 1415093337, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3601) },
                    { 784481623, 326886113, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3562), -1879626487, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3564) },
                    { 957857250, 326886113, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3575), 1679226206, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3576) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289111365, 334502272, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3435), 1355033610, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3436) },
                    { 314317098, 334502272, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3460), -444861197, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3461) },
                    { 342555527, 334502272, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3472), 991754483, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3473) },
                    { 395578488, 334502272, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3448), 324021745, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3449) },
                    { 784481623, 334502272, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3410), 2144618384, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3412) },
                    { 957857250, 334502272, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3423), 62041055, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3424) },
                    { 289111365, 344344436, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5340), -1896454957, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5341) },
                    { 314317098, 344344436, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5365), 523743278, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5366) },
                    { 342555527, 344344436, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5377), 2134668915, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5378) },
                    { 395578488, 344344436, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5353), -1651888687, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5354) },
                    { 784481623, 344344436, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5315), -818803084, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5316) },
                    { 957857250, 344344436, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5327), -1207966189, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5329) },
                    { 289111365, 384648867, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3513), 231899833, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3514) },
                    { 314317098, 384648867, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3538), 1217043410, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3539) },
                    { 342555527, 384648867, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3550), -1445341891, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3551) },
                    { 395578488, 384648867, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3525), 1412631747, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3526) },
                    { 784481623, 384648867, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3488), -1589239930, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3489) },
                    { 957857250, 384648867, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3501), 685417082, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3502) },
                    { 289111365, 393648706, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2908), -645314629, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2909) },
                    { 314317098, 393648706, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2932), -867581666, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2933) },
                    { 342555527, 393648706, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2945), -490650817, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2946) },
                    { 395578488, 393648706, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2920), 119443829, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2921) },
                    { 784481623, 393648706, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2883), 1448989079, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2884) },
                    { 957857250, 393648706, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2895), -567050786, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2897) },
                    { 289111365, 407197330, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6013), 1111594910, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6015) },
                    { 314317098, 407197330, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6042), -342572399, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6044) },
                    { 342555527, 407197330, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6055), -98982611, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6056) },
                    { 395578488, 407197330, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6030), 1117140192, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6031) },
                    { 784481623, 407197330, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5989), -1372522364, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5990) },
                    { 957857250, 407197330, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6001), -1373359486, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6002) },
                    { 289111365, 413271766, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3965), -1409690659, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3966) },
                    { 314317098, 413271766, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3990), -1311164360, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3991) },
                    { 342555527, 413271766, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4002), 542666750, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4003) },
                    { 395578488, 413271766, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3977), -656840969, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3978) },
                    { 784481623, 413271766, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3940), 2117769903, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3941) },
                    { 957857250, 413271766, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3952), -1084261369, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3953) },
                    { 289111365, 413432008, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3889), 1661360229, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3890) },
                    { 314317098, 413432008, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3914), -2129851561, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3915) },
                    { 342555527, 413432008, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3927), -2002365256, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3928) },
                    { 395578488, 413432008, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3901), -418392530, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3903) },
                    { 784481623, 413432008, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3860), -1692788998, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3861) },
                    { 957857250, 413432008, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3876), -1788246188, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3877) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289111365, 419815503, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4648), 681566675, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4649) },
                    { 314317098, 419815503, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4677), 1915590839, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4678) },
                    { 342555527, 419815503, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4689), -1434060476, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4690) },
                    { 395578488, 419815503, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4664), -1562800000, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4665) },
                    { 784481623, 419815503, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4623), -140876554, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4624) },
                    { 957857250, 419815503, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4635), -426422002, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4636) },
                    { 289111365, 426644933, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4115), 1925103258, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4116) },
                    { 314317098, 426644933, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4140), -1728030487, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4141) },
                    { 342555527, 426644933, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4153), 1404181508, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4154) },
                    { 395578488, 426644933, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4128), -2116519559, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4129) },
                    { 784481623, 426644933, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4090), 1366100582, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4091) },
                    { 957857250, 426644933, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4103), -223287398, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4104) },
                    { 289111365, 454462233, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3286), -757045993, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3287) },
                    { 314317098, 454462233, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3311), -1521767479, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3312) },
                    { 342555527, 454462233, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3323), -1681710353, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3324) },
                    { 395578488, 454462233, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3298), 2094360647, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3299) },
                    { 784481623, 454462233, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3261), 2013700680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3262) },
                    { 957857250, 454462233, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3273), 135099631, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3274) },
                    { 289111365, 455566259, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2982), -1227373798, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2983) },
                    { 314317098, 455566259, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3006), -1865598209, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3007) },
                    { 342555527, 455566259, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3019), 1938237093, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3020) },
                    { 395578488, 455566259, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2994), -821681077, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2995) },
                    { 784481623, 455566259, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2957), 514671557, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2958) },
                    { 957857250, 455566259, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2970), 20332009, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2971) },
                    { 289111365, 457801206, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5865), -1108835392, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5866) },
                    { 314317098, 457801206, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5890), -1664038133, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5891) },
                    { 342555527, 457801206, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5902), -1112166481, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5903) },
                    { 395578488, 457801206, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5877), -2107033537, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5878) },
                    { 784481623, 457801206, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5840), 1726805691, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5841) },
                    { 957857250, 457801206, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5852), 325974344, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5853) },
                    { 289111365, 475145393, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2753), 2125696392, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2754) },
                    { 314317098, 475145393, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2779), -2040626578, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2780) },
                    { 342555527, 475145393, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2791), 1892439540, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2792) },
                    { 395578488, 475145393, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2766), -1268505823, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2767) },
                    { 784481623, 475145393, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2727), -308002747, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2729) },
                    { 957857250, 475145393, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2741), -20511004, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2742) },
                    { 289111365, 502514954, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4190), -66283712, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4191) },
                    { 314317098, 502514954, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4216), 307178524, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4217) },
                    { 342555527, 502514954, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4229), 1855703588, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4230) },
                    { 395578488, 502514954, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4204), 1893433896, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4205) },
                    { 784481623, 502514954, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4165), -1359976666, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4166) },
                    { 957857250, 502514954, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4178), 196949210, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4179) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289111365, 521109623, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3209), -139649624, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3210) },
                    { 314317098, 521109623, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3236), -1612292669, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3237) },
                    { 342555527, 521109623, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3248), -1533054059, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3250) },
                    { 395578488, 521109623, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3224), 999170123, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3225) },
                    { 784481623, 521109623, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3181), 1670213835, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3182) },
                    { 957857250, 521109623, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3196), 2145580511, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3197) },
                    { 289111365, 535925659, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5035), -522394073, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5036) },
                    { 314317098, 535925659, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5060), 372137005, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5061) },
                    { 342555527, 535925659, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5072), -1672005154, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5073) },
                    { 395578488, 535925659, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5047), 1476364064, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5048) },
                    { 784481623, 535925659, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5010), 209623217, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5011) },
                    { 957857250, 535925659, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5022), -487293745, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5023) },
                    { 289111365, 536694109, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5790), 1489703679, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5791) },
                    { 314317098, 536694109, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5815), 1157359118, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5816) },
                    { 342555527, 536694109, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5827), 1188348885, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5828) },
                    { 395578488, 536694109, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5803), -1787585377, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5804) },
                    { 784481623, 536694109, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5765), 1153643076, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5766) },
                    { 957857250, 536694109, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5778), -2103196814, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5779) },
                    { 289111365, 538791527, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5641), -1479291749, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5642) },
                    { 314317098, 538791527, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5666), 2023180547, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5667) },
                    { 342555527, 538791527, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5678), 531134258, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5680) },
                    { 395578488, 538791527, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5654), -765282919, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5655) },
                    { 784481623, 538791527, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5612), -470716397, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5613) },
                    { 957857250, 538791527, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5624), -475320068, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5625) },
                    { 289111365, 554507085, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5488), -561744805, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5489) },
                    { 314317098, 554507085, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5512), 141486049, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5514) },
                    { 342555527, 554507085, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5525), 1667277657, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5526) },
                    { 395578488, 554507085, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5500), -1857147403, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5501) },
                    { 784481623, 554507085, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5463), -996593318, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5464) },
                    { 957857250, 554507085, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5476), 189136256, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5477) },
                    { 289111365, 555460334, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5414), 301029850, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5415) },
                    { 314317098, 555460334, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5439), -401642432, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5440) },
                    { 342555527, 555460334, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5451), -1032086434, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5452) },
                    { 395578488, 555460334, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5426), -1383684016, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5428) },
                    { 784481623, 555460334, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5390), 717464363, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5391) },
                    { 957857250, 555460334, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5402), 607992836, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5403) },
                    { 289111365, 601701284, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2453), -2051410382, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2455) },
                    { 314317098, 601701284, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2478), -1966205893, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2479) },
                    { 342555527, 601701284, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2491), 1971078611, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2492) },
                    { 395578488, 601701284, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2466), -184701608, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2467) },
                    { 784481623, 601701284, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2428), -240482852, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2430) },
                    { 957857250, 601701284, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2441), -1501651858, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2442) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289111365, 605520194, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3360), 1193689148, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3362) },
                    { 314317098, 605520194, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3385), -1599906424, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3386) },
                    { 342555527, 605520194, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3398), 1603209344, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3399) },
                    { 395578488, 605520194, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3373), 2012761638, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3374) },
                    { 784481623, 605520194, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3336), -1692560636, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3337) },
                    { 957857250, 605520194, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3348), 604671251, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3349) },
                    { 289111365, 606425278, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1921), -87564032, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1922) },
                    { 314317098, 606425278, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1946), -902965247, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1947) },
                    { 342555527, 606425278, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1958), -1843352432, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1959) },
                    { 395578488, 606425278, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1933), -2138217952, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1934) },
                    { 784481623, 606425278, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1896), -684395482, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1897) },
                    { 957857250, 606425278, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1908), 1460332107, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1909) },
                    { 289111365, 620612391, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5562), -1780138426, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5563) },
                    { 314317098, 620612391, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5587), -1275941596, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5588) },
                    { 342555527, 620612391, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5599), 1729535292, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5600) },
                    { 395578488, 620612391, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5575), 726551078, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5576) },
                    { 784481623, 620612391, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5537), 221244193, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5538) },
                    { 957857250, 620612391, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5550), 1157749187, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5551) },
                    { 289111365, 638992144, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3131), -1201966042, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3132) },
                    { 314317098, 638992144, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3156), 2087790746, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3157) },
                    { 342555527, 638992144, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3168), 1246763754, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3169) },
                    { 395578488, 638992144, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3143), 309849431, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3144) },
                    { 784481623, 638992144, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3106), 50150435, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3107) },
                    { 957857250, 638992144, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3119), -2026110419, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3120) },
                    { 289111365, 717039849, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1768), -469810777, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1769) },
                    { 314317098, 717039849, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1795), 197356226, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1796) },
                    { 342555527, 717039849, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1808), -1155311108, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1809) },
                    { 395578488, 717039849, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1781), 1463038394, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1782) },
                    { 784481623, 717039849, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1743), 997962539, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1744) },
                    { 957857250, 717039849, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1756), -86749627, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(1757) },
                    { 289111365, 726556770, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2300), 1431004086, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2301) },
                    { 314317098, 726556770, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2325), -396302008, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2326) },
                    { 342555527, 726556770, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2337), 1986006362, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2338) },
                    { 395578488, 726556770, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2312), -646641427, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2313) },
                    { 784481623, 726556770, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2275), -728101259, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2276) },
                    { 957857250, 726556770, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2287), -323188996, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2289) },
                    { 289111365, 742852748, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4040), 245973790, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4041) },
                    { 314317098, 742852748, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4065), 1113369174, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4066) },
                    { 342555527, 742852748, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4078), 1099486247, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4079) },
                    { 395578488, 742852748, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4053), -673553290, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4054) },
                    { 784481623, 742852748, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4015), -2101288846, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4016) },
                    { 957857250, 742852748, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4028), -213710638, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4029) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289111365, 754519303, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5111), 1921537283, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5112) },
                    { 314317098, 754519303, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5136), 41978566, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5138) },
                    { 342555527, 754519303, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5149), -1274937295, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5150) },
                    { 395578488, 754519303, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5123), -492940835, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5125) },
                    { 784481623, 754519303, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5086), -689123357, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5087) },
                    { 957857250, 754519303, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5098), -718629574, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(5100) },
                    { 289111365, 764777282, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2528), 1261619807, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2529) },
                    { 314317098, 764777282, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2552), 936983948, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2553) },
                    { 342555527, 764777282, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2565), -1455436714, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2566) },
                    { 395578488, 764777282, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2540), -1383685946, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2541) },
                    { 784481623, 764777282, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2503), -617015780, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2504) },
                    { 957857250, 764777282, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2515), -510509137, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2516) },
                    { 289111365, 771090052, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3810), -2077933040, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3811) },
                    { 314317098, 771090052, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3835), -1317458555, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3836) },
                    { 342555527, 771090052, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3847), -1043096476, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3848) },
                    { 395578488, 771090052, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3823), -1256955457, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3824) },
                    { 784481623, 771090052, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3786), 226558571, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3787) },
                    { 957857250, 771090052, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3798), -675545701, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3799) },
                    { 289111365, 817022590, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2602), 182463040, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2603) },
                    { 314317098, 817022590, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2626), -1647862897, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2627) },
                    { 342555527, 817022590, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2639), -829261493, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2640) },
                    { 395578488, 817022590, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2614), 1219076186, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2615) },
                    { 784481623, 817022590, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2577), 2061083988, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2578) },
                    { 957857250, 817022590, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2589), -1560403538, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2590) },
                    { 289111365, 826420768, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4270), 872358872, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4271) },
                    { 314317098, 826420768, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4296), -1454101177, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4297) },
                    { 342555527, 826420768, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4308), -1475302292, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4309) },
                    { 395578488, 826420768, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4283), 217327559, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4284) },
                    { 784481623, 826420768, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4241), -2091332951, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4242) },
                    { 957857250, 826420768, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4254), -1833814624, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4255) },
                    { 289111365, 833092746, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4883), -1179228649, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4885) },
                    { 314317098, 833092746, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4909), -1447121083, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4910) },
                    { 342555527, 833092746, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4921), -705357670, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4922) },
                    { 395578488, 833092746, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4896), -2009893063, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4897) },
                    { 784481623, 833092746, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4858), 713468012, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4859) },
                    { 957857250, 833092746, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4871), -588149392, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4872) },
                    { 289111365, 839386283, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3736), 1201347680, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3737) },
                    { 314317098, 839386283, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3761), 1766241941, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3762) },
                    { 342555527, 839386283, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3773), 418972910, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3774) },
                    { 395578488, 839386283, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3749), 1944158369, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3750) },
                    { 784481623, 839386283, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3712), -798298667, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3713) },
                    { 957857250, 839386283, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3724), 1684787715, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3725) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289111365, 857248993, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2833), 1563253304, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2834) },
                    { 314317098, 857248993, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2858), -1000333804, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2859) },
                    { 342555527, 857248993, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2871), 161511760, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2872) },
                    { 395578488, 857248993, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2845), -1981382629, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2847) },
                    { 784481623, 857248993, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2808), -552619363, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2809) },
                    { 957857250, 857248993, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2821), 502252205, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(2822) },
                    { 289111365, 904981613, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4496), -604370402, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4497) },
                    { 314317098, 904981613, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4521), 164789807, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4522) },
                    { 342555527, 904981613, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4533), -1348288852, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4534) },
                    { 395578488, 904981613, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4508), -1785212392, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4509) },
                    { 784481623, 904981613, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4471), 112275163, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4472) },
                    { 957857250, 904981613, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4483), 1554087029, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(4484) },
                    { 289111365, 926312004, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6093), -1813708160, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6094) },
                    { 314317098, 926312004, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6118), -20598376, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6119) },
                    { 342555527, 926312004, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6130), 1766336796, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6132) },
                    { 395578488, 926312004, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6106), -894582616, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6107) },
                    { 784481623, 926312004, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6068), -898540159, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6069) },
                    { 957857250, 926312004, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6080), 329602694, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(6082) },
                    { 289111365, 988513297, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3662), -2130373255, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3663) },
                    { 314317098, 988513297, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3687), 69585575, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3688) },
                    { 342555527, 988513297, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3699), 2062998315, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3700) },
                    { 395578488, 988513297, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3674), 582523943, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3675) },
                    { 784481623, 988513297, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3637), -1432674148, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3638) },
                    { 957857250, 988513297, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3649), 807674324, new DateTime(2024, 3, 4, 13, 3, 3, 315, DateTimeKind.Local).AddTicks(3651) }
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
