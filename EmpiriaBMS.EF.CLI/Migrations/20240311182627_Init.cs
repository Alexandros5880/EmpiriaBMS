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
                    { 152061088, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6543), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6544), "Construction Supervision" },
                    { 220884879, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6505), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6506), "Energy Efficiency" },
                    { 247755868, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6517), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6518), "Outsource" },
                    { 292864174, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6396), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6397), "Fire Suppression" },
                    { 435940098, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6419), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6421), "Natural Gas" },
                    { 477729207, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6328), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6330), "HVAC" },
                    { 569580295, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6529), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6530), "TenderDocument" },
                    { 577632277, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6360), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6361), "Potable Water" },
                    { 627876737, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6483), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6484), "BMS" },
                    { 657752258, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6408), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6409), "Elevators" },
                    { 738019575, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6431), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6432), "Power Distribution" },
                    { 834008318, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6383), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6384), "Fire Detection" },
                    { 860748178, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6494), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6495), "Photovoltaics" },
                    { 904658067, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6347), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6348), "Sewage" },
                    { 927471181, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6456), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6457), "Burglar Alarm" },
                    { 935224292, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6471), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6472), "CCTV" },
                    { 941325982, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6444), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6445), "Structured Cabling" },
                    { 960026678, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6372), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6373), "Drainage" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 323696182, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6732), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6733), "Documents" },
                    { 484039243, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6753), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6754), "Calculations" },
                    { 691047663, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6765), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6767), "Drawings" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 126230196, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7338), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7339), "Administration" },
                    { 363193151, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7313), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7315), "On-Site" },
                    { 708861165, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7326), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7327), "Meetings" },
                    { 778930725, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7277), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7278), "Communications" },
                    { 904516040, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7301), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7302), "Printing" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 252133641, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3818), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3819), "See All Disciplines", 9 },
                    { 293930692, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3761), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3762), "Dashboard Assign Project Manager", 5 },
                    { 308476819, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3716), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3717), "Dashboard Edit My Hours", 2 },
                    { 377526522, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3791), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3792), "See Admin Layout", 7 },
                    { 668463486, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3733), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3734), "Dashboard Assign Designer", 3 },
                    { 744801811, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3845), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3846), "See All Projects", 11 },
                    { 790005348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3804), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3805), "Dashboard See My Hours", 8 },
                    { 831966401, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3748), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3749), "Dashboard Assign Engineer", 4 },
                    { 871304519, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3777), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3778), "Dashboard Add Project", 6 },
                    { 896910793, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3627), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3628), "See Dashboard Layout", 1 },
                    { 997668658, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3831), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3833), "See All Drawings", 10 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 263899235, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5912), "Consulting Description", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5914), "Consulting" },
                    { 579620290, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5885), "Infrastructure Description", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5887), "Infrastructure" },
                    { 589861776, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5866), "Buildings Description", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5867), "Buildings" },
                    { 655494967, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5898), "Energy Description", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5900), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[] { 291086659, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3896), false, true, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3897), "Project Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 319702151, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3859), false, true, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3861), "Designer" },
                    { 564052696, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3975), false, false, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3977), "Admin" },
                    { 629441445, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3962), false, false, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3963), "Customer" },
                    { 762103443, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3922), false, true, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3923), "CTO" },
                    { 793497653, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3990), false, false, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3991), "Secretariat" },
                    { 818979157, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3949), false, false, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3950), "Guest" },
                    { 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3936), false, true, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3937), "CEO" },
                    { 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3909), false, true, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3910), "COO" },
                    { 968466668, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3882), false, true, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(3883), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 129475032, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5046), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5048), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5293), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5294), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5402), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5403), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5703), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5704), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 237297632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4865), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4867), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 274010109, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5087), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5088), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5782), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5784), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5456), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5458), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 450445982, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4947), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4948), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 463836728, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4820), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4822), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 492722989, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4906), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4907), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5663), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5664), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5168), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5170), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5212), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5213), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5253), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5254), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5333), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5334), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 599870663, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5127), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5128), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 671754035, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4992), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4993), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5497), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5499), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5822), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5823), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5743), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5744), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5622), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5624), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5582), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5584), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 987086128, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4766), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4767), null, "694927778", null, null, null, "admin@gmail.com" },
                    { 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5541), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5542), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 148574620, "vtza@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5470), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5472), 382564701 },
                    { 186852921, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5021), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5022), 671754035 },
                    { 225188693, "coo@gmail.com", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4920), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4921), 492722989 },
                    { 250290271, "guest@gmail.com", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4961), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4962), 450445982 },
                    { 250844083, "agretos@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5515), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5516), 737992348 },
                    { 254528063, "dtsa@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5100), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5101), 274010109 },
                    { 324220286, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5836), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5837), 752429091 },
                    { 411458858, "dtsa@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5141), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5142), 599870663 },
                    { 485623159, "cto@gmail.com", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4879), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4881), 237297632 },
                    { 492243991, "gdoug@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5061), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5062), 129475032 },
                    { 522758211, "embiria@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5008), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5009), 671754035 },
                    { 523660783, "panperivollari@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5796), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5797), 292529512 },
                    { 556933519, "xmanarolis@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5226), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5227), 550689214 },
                    { 597039023, "vchontos@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5756), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5757), 804380554 },
                    { 599189636, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5677), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5678), 514385684 },
                    { 614835382, "vpax@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5186), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5187), 546496367 },
                    { 630285972, "chkovras@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5307), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5308), 147387515 },
                    { 652744707, "sparisis@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5267), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5268), 589689582 },
                    { 656716240, "haris@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5596), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5597), 971202183 },
                    { 661860327, "ceo@gmail.com", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4834), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4835), 463836728 },
                    { 742212036, "kmargeti@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5556), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5557), 987992086 },
                    { 775238061, "kkotsoni@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5415), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5417), 150743538 },
                    { 782885620, "ngal@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5347), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5348), 598429451 },
                    { 802622695, "admin@gmail.com", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4784), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4785), 987086128 },
                    { 867631434, "blekou@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5717), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5718), 168381769 },
                    { 875631716, "pfokianou@embiria.gr", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5636), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5638), 930931483 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 413905700, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 7.0, 4, new DateTime(2024, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 4, "Test Description Project_10", "KL-2", new DateTime(2024, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), new DateTime(2024, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 0f, 100L, 12L, new DateTime(2024, 3, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), "Project_2", 5.0, new DateTime(2024, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), "Payment Detailes For Project_12", 2.0, null, 579620290, new DateTime(2024, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 0f },
                    { 429371496, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 9.0, 16, new DateTime(2025, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 16, "Test Description Project_4", "KL-4", new DateTime(2025, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), new DateTime(2025, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 0f, 100L, 12L, new DateTime(2024, 3, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), "Project_4", 5.0, new DateTime(2025, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), "Payment Detailes For Project_8", 4.0, null, 263899235, new DateTime(2025, 7, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 0f },
                    { 604222875, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 6.0, 1, new DateTime(2024, 4, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 4, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), new DateTime(2024, 4, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 0f, 100L, 12L, new DateTime(2024, 3, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), "Project_1", 5.0, new DateTime(2024, 4, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), "Payment Detailes For Project_2", 1.0, null, 589861776, new DateTime(2024, 4, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 0f },
                    { 809539116, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 8.0, 9, new DateTime(2024, 12, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 9, "Test Description Project_12", "KL-3", new DateTime(2024, 12, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), new DateTime(2024, 12, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 0f, 100L, 12L, new DateTime(2024, 3, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), "Project_3", 5.0, new DateTime(2024, 12, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), "Payment Detailes For Project_9", 3.0, null, 655494967, new DateTime(2024, 12, 11, 20, 26, 26, 789, DateTimeKind.Local).AddTicks(8420), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 252133641, 291086659, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4195), -1072657970, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4196) },
                    { 308476819, 291086659, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4154), -1972390535, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4156) },
                    { 790005348, 291086659, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4181), -1537728533, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4183) },
                    { 831966401, 291086659, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4168), 1200868286, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4169) },
                    { 896910793, 291086659, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4141), 1626073520, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4142) },
                    { 997668658, 291086659, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4209), -292272430, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4211) },
                    { 308476819, 319702151, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4026), 1388774070, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4027) },
                    { 790005348, 319702151, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4040), 2053922783, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4042) },
                    { 896910793, 319702151, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4003), 97155095, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4005) },
                    { 252133641, 564052696, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4634), -321622078, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4635) },
                    { 377526522, 564052696, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4621), 1133403966, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4622) },
                    { 744801811, 564052696, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4660), -326416877, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4661) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 997668658, 564052696, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4647), -1567752326, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4648) },
                    { 896910793, 629441445, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4608), -3345250, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4609) },
                    { 252133641, 762103443, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4416), -973828772, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4417) },
                    { 293930692, 762103443, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4375), 1088391533, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4377) },
                    { 308476819, 762103443, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4362), -333482143, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4364) },
                    { 744801811, 762103443, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4442), -879975832, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4443) },
                    { 790005348, 762103443, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4402), 467746097, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4403) },
                    { 871304519, 762103443, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4389), 1550618789, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4390) },
                    { 896910793, 762103443, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4349), 1730718302, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4351) },
                    { 997668658, 762103443, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4429), 2145801699, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4430) },
                    { 252133641, 793497653, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4712), 1563041723, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4714) },
                    { 308476819, 793497653, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4686), 1042426706, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4687) },
                    { 744801811, 793497653, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4752), -581673428, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4753) },
                    { 790005348, 793497653, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4699), -1696550557, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4700) },
                    { 896910793, 793497653, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4673), -275986997, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4674) },
                    { 997668658, 793497653, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4726), -1724531291, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4727) },
                    { 896910793, 818979157, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4595), -1992390781, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4596) },
                    { 252133641, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4556), 1167165927, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4557) },
                    { 293930692, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4515), 1548364599, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4516) },
                    { 308476819, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4475), -1980585422, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4476) },
                    { 377526522, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4542), 1328286209, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4544) },
                    { 668463486, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4488), -1140372764, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4489) },
                    { 744801811, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4582), -670877131, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4583) },
                    { 831966401, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4501), -1488364618, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4502) },
                    { 871304519, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4529), -2067168410, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4530) },
                    { 896910793, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4456), 1760362385, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4457) },
                    { 997668658, 833646297, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4569), -822882194, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4570) },
                    { 252133641, 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4309), -2016108638, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4311) },
                    { 293930692, 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4282), -1195794242, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4283) },
                    { 308476819, 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4237), -21110993, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4238) },
                    { 668463486, 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4252), 93251318, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4254) },
                    { 744801811, 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4336), 1583484836, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4338) },
                    { 790005348, 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4296), 1579085091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4297) },
                    { 831966401, 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4268), 1316647490, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4269) },
                    { 896910793, 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4223), 1910137158, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4224) },
                    { 997668658, 851998202, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4322), -1850767870, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4324) },
                    { 252133641, 968466668, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4113), -1794992224, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4114) },
                    { 308476819, 968466668, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4067), -779899121, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4068) },
                    { 668463486, 968466668, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4086), -580227925, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4087) },
                    { 790005348, 968466668, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4099), 288770500, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4101) },
                    { 896910793, 968466668, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4053), 1828813662, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4054) },
                    { 997668658, 968466668, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4126), -219578494, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4127) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 319702151, 129475032, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5074), 408506092, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5075) },
                    { 968466668, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5319), 453778735, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5321) },
                    { 291086659, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5941), 114279018, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5943) },
                    { 851998202, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5444), 127324030, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5445) },
                    { 968466668, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5429), 261383720, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5431) },
                    { 968466668, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5729), 768868974, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5731) },
                    { 762103443, 237297632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4893), 826714328, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4894) },
                    { 319702151, 274010109, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5114), 304075296, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5115) },
                    { 968466668, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5809), 201925984, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5810) },
                    { 968466668, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5484), 174752335, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5485) },
                    { 818979157, 450445982, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4974), 219294787, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4975) },
                    { 833646297, 463836728, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4849), 197565503, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4850) },
                    { 851998202, 492722989, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4932), 286669006, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4934) },
                    { 968466668, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5690), 238659612, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5691) },
                    { 291086659, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5926), 214236868, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5928) },
                    { 968466668, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5199), 872557876, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5200) },
                    { 968466668, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5240), 469985070, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5241) },
                    { 968466668, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5279), 891605102, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5281) },
                    { 564052696, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5374), 166450229, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5375) },
                    { 833646297, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5388), 972031651, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5389) },
                    { 968466668, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5360), 365016259, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5362) },
                    { 319702151, 599870663, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5154), 453908598, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5155) },
                    { 793497653, 671754035, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5033), 757348963, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5035) },
                    { 968466668, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5528), 804034420, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5529) },
                    { 968466668, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5852), 186457836, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5853) },
                    { 968466668, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5769), 730725717, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5770) },
                    { 968466668, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5650), 653112378, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5651) },
                    { 291086659, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5956), 66832345, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5957) },
                    { 968466668, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5609), 211314889, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5610) },
                    { 564052696, 987086128, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4801), 912705831, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(4802) },
                    { 968466668, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5569), 372250886, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(5570) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1758557216, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6615), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6616), 413905700, 834008318, null },
                    { -1484226232, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6707), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6708), 429371496, 935224292, null },
                    { -1297619632, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6602), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6603), 604222875, 577632277, null },
                    { -1161018440, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6695), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6696), 429371496, 220884879, null },
                    { -1029843960, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6642), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6643), 413905700, 435940098, null },
                    { -1026362616, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6680), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6681), 809539116, 834008318, null },
                    { -678710016, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6718), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6720), 429371496, 860748178, null },
                    { -65346688, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6627), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6628), 413905700, 935224292, null },
                    { 466492608, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6568), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6569), 604222875, 904658067, null },
                    { 1134162440, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6655), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6656), 809539116, 960026678, null },
                    { 1578848888, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6667), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6668), 809539116, 927471181, null },
                    { 2140817600, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6589), 0f, 1500L, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6590), 604222875, 834008318, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 150843626, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6080), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6082), 3010.0, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6081), "Signature 142344", 47917, 604222875, 1.0, 17.0 },
                    { 349134386, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6163), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6165), 3100.0, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6164), "Signature 142342", 56478, 413905700, 2.0, 24.0 },
                    { 540475611, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6239), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6241), 4000.0, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6240), "Signature 142346", 85340, 809539116, 3.0, 17.0 },
                    { 899009514, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6310), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6312), 13000.0, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6311), "Signature 142348", 22415, 429371496, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 413905700, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8062), 149377799, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8063) },
                    { 429371496, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8088), 190908220, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8089) },
                    { 604222875, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8042), 334393134, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8043) },
                    { 809539116, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8075), 413207283, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8076) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 264915157, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6123), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6124), null, "6949277782", null, null, 413905700, "alexpl_{i}@gmail.com" },
                    { 852253076, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6033), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6035), null, "6949277781", null, null, 604222875, "alexpl_{i}@gmail.com" },
                    { 868066547, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6272), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6273), null, "6949277784", null, null, 429371496, "alexpl_{i}@gmail.com" },
                    { 939818018, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6201), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6203), null, "6949277783", null, null, 809539116, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1758557216, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8716), 672670667, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8717) },
                    { -1758557216, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8739), 979866637, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8740) },
                    { -1758557216, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8820), 702352180, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8822) },
                    { -1758557216, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8844), 612506514, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8845) },
                    { -1758557216, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8750), 849893484, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8752) },
                    { -1758557216, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8809), 915271667, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8810) },
                    { -1758557216, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8681), 854550865, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8682) },
                    { -1758557216, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8693), 488339479, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8694) },
                    { -1758557216, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8704), 203775198, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8705) },
                    { -1758557216, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8728), 236849945, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8729) },
                    { -1758557216, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8762), 793365383, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8763) },
                    { -1758557216, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8856), 962278133, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8857) },
                    { -1758557216, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8832), 356354883, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8833) },
                    { -1758557216, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8797), 269858802, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8798) },
                    { -1758557216, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8785), 944266501, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8786) },
                    { -1758557216, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8774), 785093348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8775) },
                    { -1484226232, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(37), 916182713, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(38) },
                    { -1484226232, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(60), 840055682, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(61) },
                    { -1484226232, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(142), 410795995, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(143) },
                    { -1484226232, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(166), 497274461, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(167) },
                    { -1484226232, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(72), 565239723, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(73) },
                    { -1484226232, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(130), 673121074, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(131) },
                    { -1484226232, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2), 808344943, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(3) },
                    { -1484226232, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(13), 225066967, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(14) },
                    { -1484226232, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(25), 924264064, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(26) },
                    { -1484226232, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(48), 428390494, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(50) },
                    { -1484226232, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(83), 210692139, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(84) },
                    { -1484226232, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(177), 443040853, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(178) },
                    { -1484226232, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(153), 147131496, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(154) },
                    { -1484226232, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(118), 446451973, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(119) },
                    { -1484226232, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(107), 393556250, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(108) },
                    { -1484226232, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(95), 886609750, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(96) },
                    { -1297619632, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8526), 666179964, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8527) },
                    { -1297619632, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8549), 242359855, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8551) },
                    { -1297619632, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8630), 803567768, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8631) },
                    { -1297619632, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8654), 812781390, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8655) },
                    { -1297619632, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8561), 319425506, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8562) },
                    { -1297619632, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8619), 200881341, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8620) },
                    { -1297619632, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8490), 215569396, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8491) },
                    { -1297619632, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8503), 550193432, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8504) },
                    { -1297619632, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8514), 943381354, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8515) },
                    { -1297619632, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8538), 945123089, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8539) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1297619632, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8572), 501419205, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8573) },
                    { -1297619632, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8669), 913518061, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8670) },
                    { -1297619632, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8643), 492611823, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8644) },
                    { -1297619632, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8607), 337620954, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8608) },
                    { -1297619632, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8595), 477902855, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8597) },
                    { -1297619632, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8584), 443877310, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8585) },
                    { -1161018440, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9847), 578536184, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9848) },
                    { -1161018440, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9870), 132760336, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9871) },
                    { -1161018440, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9952), 561098303, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9953) },
                    { -1161018440, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9975), 277977206, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9976) },
                    { -1161018440, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9882), 702647855, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9883) },
                    { -1161018440, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9940), 880340027, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9941) },
                    { -1161018440, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9811), 755537619, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9812) },
                    { -1161018440, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9823), 949871172, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9824) },
                    { -1161018440, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9834), 547486981, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9836) },
                    { -1161018440, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9858), 288146329, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9860) },
                    { -1161018440, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9893), 573562974, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9895) },
                    { -1161018440, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9990), 592176720, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9991) },
                    { -1161018440, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9964), 267633424, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9965) },
                    { -1161018440, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9928), 740422645, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9929) },
                    { -1161018440, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9917), 447330301, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9918) },
                    { -1161018440, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9905), 195574704, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9906) },
                    { -1029843960, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9093), 526474937, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9094) },
                    { -1029843960, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9116), 436205398, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9117) },
                    { -1029843960, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9198), 320180750, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9199) },
                    { -1029843960, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9221), 524379919, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9222) },
                    { -1029843960, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9128), 609605732, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9129) },
                    { -1029843960, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9186), 829278421, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9187) },
                    { -1029843960, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9058), 599698892, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9059) },
                    { -1029843960, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9070), 455509547, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9071) },
                    { -1029843960, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9081), 433160097, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9082) },
                    { -1029843960, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9105), 713770569, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9106) },
                    { -1029843960, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9139), 783730649, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9140) },
                    { -1029843960, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9232), 262282293, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9233) },
                    { -1029843960, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9209), 874892945, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9210) },
                    { -1029843960, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9175), 806122902, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9176) },
                    { -1029843960, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9163), 293165027, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9164) },
                    { -1029843960, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9151), 653829526, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9152) },
                    { -1026362616, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9660), 188986543, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9661) },
                    { -1026362616, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9683), 434078367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9684) },
                    { -1026362616, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9764), 894434269, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9765) },
                    { -1026362616, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9787), 169990063, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9789) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1026362616, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9695), 402589401, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9696) },
                    { -1026362616, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9753), 875943769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9754) },
                    { -1026362616, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9621), 230828343, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9622) },
                    { -1026362616, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9636), 399205400, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9637) },
                    { -1026362616, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9648), 425928127, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9649) },
                    { -1026362616, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9671), 818205863, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9672) },
                    { -1026362616, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9707), 423097819, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9708) },
                    { -1026362616, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9799), 242079727, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9800) },
                    { -1026362616, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9776), 215353222, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9777) },
                    { -1026362616, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9741), 430354051, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9742) },
                    { -1026362616, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9730), 322860426, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9731) },
                    { -1026362616, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9718), 860758134, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9719) },
                    { -678710016, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(224), 948742768, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(225) },
                    { -678710016, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(248), 991850067, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(249) },
                    { -678710016, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(329), 723404447, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(330) },
                    { -678710016, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(356), 355945204, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(357) },
                    { -678710016, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(260), 825431675, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(261) },
                    { -678710016, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(318), 755850102, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(319) },
                    { -678710016, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(189), 204334694, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(191) },
                    { -678710016, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(201), 391688990, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(202) },
                    { -678710016, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(213), 790465926, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(214) },
                    { -678710016, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(236), 471345786, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(237) },
                    { -678710016, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(271), 244095564, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(272) },
                    { -678710016, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(368), 653932550, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(369) },
                    { -678710016, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(341), 324562505, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(342) },
                    { -678710016, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(306), 491132559, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(307) },
                    { -678710016, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(294), 796230431, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(295) },
                    { -678710016, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(282), 156322230, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(284) },
                    { -65346688, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8903), 271245023, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8904) },
                    { -65346688, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8927), 877233958, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8928) },
                    { -65346688, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9012), 968818971, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9013) },
                    { -65346688, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9035), 912793179, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9036) },
                    { -65346688, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8938), 995530043, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8939) },
                    { -65346688, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9000), 792498523, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9001) },
                    { -65346688, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8868), 695574603, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8869) },
                    { -65346688, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8880), 843335741, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8881) },
                    { -65346688, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8892), 320582389, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8893) },
                    { -65346688, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8915), 138774946, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8916) },
                    { -65346688, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8950), 443738309, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8951) },
                    { -65346688, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9047), 339755530, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9048) },
                    { -65346688, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9023), 242662395, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9024) },
                    { -65346688, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8988), 474804020, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8989) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -65346688, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8974), 307741465, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8975) },
                    { -65346688, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8962), 875142660, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8963) },
                    { 466492608, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8144), 640797030, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8145) },
                    { 466492608, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8170), 231539639, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8171) },
                    { 466492608, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8253), 963838113, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8255) },
                    { 466492608, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8277), 724986986, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8278) },
                    { 466492608, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8182), 749082364, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8183) },
                    { 466492608, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8241), 886942907, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8242) },
                    { 466492608, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8101), 754811829, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8102) },
                    { 466492608, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8120), 889345503, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8121) },
                    { 466492608, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8132), 314388717, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8133) },
                    { 466492608, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8156), 505576513, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8158) },
                    { 466492608, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8194), 401235702, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8195) },
                    { 466492608, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8288), 780340676, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8289) },
                    { 466492608, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8265), 546370728, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8266) },
                    { 466492608, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8229), 985750747, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8231) },
                    { 466492608, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8218), 464037497, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8219) },
                    { 466492608, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8206), 252852959, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8207) },
                    { 1134162440, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9280), 285655207, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9281) },
                    { 1134162440, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9303), 666446861, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9304) },
                    { 1134162440, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9387), 256660661, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9388) },
                    { 1134162440, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9411), 169349672, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9412) },
                    { 1134162440, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9315), 379053245, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9316) },
                    { 1134162440, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9375), 396897967, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9377) },
                    { 1134162440, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9244), 822279623, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9245) },
                    { 1134162440, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9256), 538481270, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9258) },
                    { 1134162440, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9268), 632807069, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9269) },
                    { 1134162440, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9292), 720423123, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9293) },
                    { 1134162440, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9326), 368107711, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9327) },
                    { 1134162440, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9422), 407379014, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9424) },
                    { 1134162440, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9399), 336159478, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9400) },
                    { 1134162440, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9363), 452118024, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9364) },
                    { 1134162440, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9352), 446136375, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9353) },
                    { 1134162440, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9337), 770627083, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9338) },
                    { 1578848888, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9470), 210459703, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9471) },
                    { 1578848888, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9493), 864243768, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9494) },
                    { 1578848888, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9574), 258561772, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9575) },
                    { 1578848888, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9597), 540145618, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9598) },
                    { 1578848888, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9505), 767596025, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9506) },
                    { 1578848888, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9562), 746464498, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9563) },
                    { 1578848888, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9434), 907542371, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9436) },
                    { 1578848888, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9446), 391415336, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9447) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1578848888, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9457), 874263860, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9459) },
                    { 1578848888, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9482), 595496599, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9483) },
                    { 1578848888, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9516), 499077151, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9517) },
                    { 1578848888, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9609), 305886460, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9610) },
                    { 1578848888, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9586), 687101698, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9587) },
                    { 1578848888, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9551), 335410275, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9552) },
                    { 1578848888, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9539), 907043290, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9540) },
                    { 1578848888, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9528), 816433043, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(9529) },
                    { 2140817600, 147387515, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8339), 458357563, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8340) },
                    { 2140817600, 150743538, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8362), 906122684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8363) },
                    { 2140817600, 168381769, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8443), 544697188, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8444) },
                    { 2140817600, 292529512, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8467), 801443462, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8468) },
                    { 2140817600, 382564701, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8374), 123513098, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8375) },
                    { 2140817600, 514385684, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8432), 355185456, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8433) },
                    { 2140817600, 546496367, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8300), 961940183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8301) },
                    { 2140817600, 550689214, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8313), 449147975, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8314) },
                    { 2140817600, 589689582, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8327), 759727198, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8328) },
                    { 2140817600, 598429451, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8351), 339771642, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8352) },
                    { 2140817600, 737992348, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8385), 832457113, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8386) },
                    { 2140817600, 752429091, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8478), 371080620, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8479) },
                    { 2140817600, 804380554, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8455), 962242389, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8456) },
                    { 2140817600, 930931483, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8420), 272273530, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8421) },
                    { 2140817600, 971202183, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8408), 528713791, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8409) },
                    { 2140817600, 987992086, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8397), 549712813, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8398) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 170445845, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6786), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6783), 466492608, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6784), 323696182 },
                    { 201719205, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7198), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7196), -1484226232, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7197), 323696182 },
                    { 243847878, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7091), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7089), 1578848888, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7090), 484039243 },
                    { 253475611, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6874), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6871), -1297619632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6872), 323696182 },
                    { 255936396, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7012), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7009), -1029843960, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7011), 484039243 },
                    { 307549757, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7040), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7038), 1134162440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7039), 323696182 },
                    { 335335969, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6804), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6801), 466492608, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6802), 484039243 },
                    { 344031067, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6941), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6939), -1758557216, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6940), 691047663 },
                    { 344379771, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6954), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6952), -65346688, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6953), 323696182 },
                    { 358987456, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7066), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7063), 1134162440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7064), 691047663 },
                    { 359000338, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6999), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6996), -1029843960, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6997), 323696182 },
                    { 388157935, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7160), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7157), -1161018440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7158), 323696182 },
                    { 409240749, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6915), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6913), -1758557216, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6914), 323696182 },
                    { 425048558, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7120), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7118), -1026362616, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7119), 323696182 },
                    { 465391869, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7211), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7208), -1484226232, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7209), 484039243 },
                    { 477056800, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7238), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7236), -678710016, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7237), 323696182 },
                    { 493110016, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6967), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6965), -65346688, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6966), 484039243 },
                    { 494557565, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6832), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6830), 2140817600, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6831), 323696182 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 507832992, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6845), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6843), 2140817600, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6844), 484039243 },
                    { 559725948, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7079), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7076), 1578848888, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7077), 323696182 },
                    { 609500730, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6900), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6898), -1297619632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6899), 691047663 },
                    { 644762193, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7107), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7105), 1578848888, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7106), 691047663 },
                    { 662800814, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7026), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7024), -1029843960, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7025), 691047663 },
                    { 664580850, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6860), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6857), 2140817600, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6859), 691047663 },
                    { 686281342, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7264), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7261), -678710016, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7263), 691047663 },
                    { 709113338, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7146), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7144), -1026362616, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7145), 691047663 },
                    { 724162022, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7224), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7221), -1484226232, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7222), 691047663 },
                    { 784044462, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7053), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7051), 1134162440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7052), 484039243 },
                    { 878503109, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6929), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6926), -1758557216, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6927), 484039243 },
                    { 886691540, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6818), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6815), 466492608, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6816), 691047663 },
                    { 889815592, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7134), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7131), -1026362616, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7132), 484039243 },
                    { 913398025, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7172), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7170), -1161018440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7171), 484039243 },
                    { 916128620, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6985), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6982), -65346688, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6984), 691047663 },
                    { 951262174, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7185), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7183), -1161018440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7184), 691047663 },
                    { 955233249, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7251), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7249), -678710016, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7250), 484039243 },
                    { 960904142, new DateTime(2024, 3, 22, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6887), 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6885), -1297619632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6886), 484039243 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 316969345, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6137), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6138), 264915157 },
                    { 367809108, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6051), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6052), 852253076 },
                    { 687706697, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6215), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6216), 939818018 },
                    { 857410869, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6285), new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6286), 868066547 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124515875, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7488), -1297619632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7489), 904516040 },
                    { 128376476, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7703), 1134162440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7704), 778930725 },
                    { 154975868, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7750), 1134162440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7751), 126230196 },
                    { 165527239, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7805), 1578848888, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7806), 126230196 },
                    { 197095269, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7557), -1758557216, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7558), 363193151 },
                    { 246080117, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7761), 1578848888, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7762), 778930725 },
                    { 246313654, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7916), -1161018440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7917), 126230196 },
                    { 275228578, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7794), 1578848888, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7795), 708861165 },
                    { 302056421, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7380), 466492608, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7381), 363193151 },
                    { 302813929, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7816), -1026362616, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7817), 778930725 },
                    { 312895851, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7656), -1029843960, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7657), 904516040 },
                    { 320777763, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7987), -678710016, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7988), 778930725 },
                    { 366565182, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7477), -1297619632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7478), 778930725 },
                    { 383379733, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7590), -65346688, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7591), 778930725 },
                    { 417246306, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7739), 1134162440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7740), 708861165 },
                    { 441823539, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7442), 2140817600, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7443), 363193151 },
                    { 484322874, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7772), 1578848888, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7773), 904516040 },
                    { 508016091, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7997), -678710016, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7998), 904516040 },
                    { 517680786, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7612), -65346688, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7613), 363193151 },
                    { 520523082, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7431), 2140817600, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7432), 904516040 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 550667218, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7860), -1026362616, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7861), 126230196 },
                    { 571231191, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7959), -1484226232, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7960), 708861165 },
                    { 572954941, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7905), -1161018440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7906), 708861165 },
                    { 592632864, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7927), -1484226232, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7928), 778930725 },
                    { 593640545, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7871), -1161018440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7872), 778930725 },
                    { 599799343, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7937), -1484226232, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7939), 904516040 },
                    { 607463251, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8030), -678710016, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8031), 126230196 },
                    { 636073337, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7634), -65346688, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7635), 126230196 },
                    { 652086357, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7579), -1758557216, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7580), 126230196 },
                    { 673598884, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7849), -1026362616, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7850), 708861165 },
                    { 689213346, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7714), 1134162440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7715), 904516040 },
                    { 691109450, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7949), -1484226232, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7950), 363193151 },
                    { 695625977, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7783), 1578848888, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7784), 363193151 },
                    { 702195958, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7533), -1758557216, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7534), 778930725 },
                    { 732231840, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7827), -1026362616, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7829), 904516040 },
                    { 735403384, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7667), -1029843960, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7668), 363193151 },
                    { 748156671, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7882), -1161018440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7883), 904516040 },
                    { 749574823, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7645), -1029843960, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7646), 778930725 },
                    { 753305563, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7893), -1161018440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7894), 363193151 },
                    { 759148905, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7466), 2140817600, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7467), 126230196 },
                    { 781426055, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7601), -65346688, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7602), 904516040 },
                    { 811156518, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7453), 2140817600, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7454), 708861165 },
                    { 811723097, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8008), -678710016, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8009), 363193151 },
                    { 823533070, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7391), 466492608, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7392), 708861165 },
                    { 853534371, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7839), -1026362616, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7840), 363193151 },
                    { 853920243, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7725), 1134162440, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7726), 363193151 },
                    { 857360920, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8019), -678710016, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(8020), 708861165 },
                    { 895127128, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7623), -65346688, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7624), 708861165 },
                    { 895553367, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7511), -1297619632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7512), 708861165 },
                    { 895764288, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7419), 2140817600, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7420), 778930725 },
                    { 903398819, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7522), -1297619632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7523), 126230196 },
                    { 909428484, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7678), -1029843960, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7679), 708861165 },
                    { 947978946, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7692), -1029843960, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7693), 126230196 },
                    { 949273777, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7369), 466492608, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7370), 904516040 },
                    { 950991985, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7352), 466492608, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7354), 778930725 },
                    { 953641622, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7975), -1484226232, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7976), 126230196 },
                    { 976013356, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7403), 466492608, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7404), 126230196 },
                    { 977464321, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7544), -1758557216, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7546), 904516040 },
                    { 994240247, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7499), -1297619632, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7500), 363193151 },
                    { 997942632, 0f, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7568), -1758557216, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(7569), 708861165 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 629441445, 264915157, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6149), 514807883, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6150) },
                    { 629441445, 852253076, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6066), 852936809, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6068) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 629441445, 868066547, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6297), 540550561, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6298) });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 629441445, 939818018, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6227), 313777977, new DateTime(2024, 3, 11, 20, 26, 26, 805, DateTimeKind.Local).AddTicks(6228) });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 129475032, 124515875, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(776), 1079138957, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(777) },
                    { 274010109, 124515875, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(787), -1087055162, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(788) },
                    { 599870663, 124515875, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(799), 1614033626, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(800) },
                    { 129475032, 128376476, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1442), 2030071005, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1443) },
                    { 274010109, 128376476, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1453), -365284232, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1454) },
                    { 599870663, 128376476, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1464), 1841597874, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1466) },
                    { 129475032, 154975868, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1579), 1125117536, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1580) },
                    { 274010109, 154975868, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1590), 515123546, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1591) },
                    { 599870663, 154975868, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1602), -1557538897, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1603) },
                    { 129475032, 165527239, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1758), 2108689110, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1759) },
                    { 274010109, 165527239, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1769), 584677706, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1770) },
                    { 599870663, 165527239, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1780), 1284240434, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1781) },
                    { 129475032, 197095269, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(986), -1313168944, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(987) },
                    { 274010109, 197095269, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(997), 1346579127, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(998) },
                    { 599870663, 197095269, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1008), 1360096497, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1009) },
                    { 129475032, 246080117, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1613), -1427199439, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1614) },
                    { 274010109, 246080117, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1624), -1630500232, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1625) },
                    { 599870663, 246080117, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1636), 40418551, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1637) },
                    { 129475032, 246313654, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2108), -160935182, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2109) },
                    { 274010109, 246313654, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2119), -1945875581, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2120) },
                    { 599870663, 246313654, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2130), -287735768, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2131) },
                    { 129475032, 275228578, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1723), 1263523919, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1724) },
                    { 274010109, 275228578, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1735), 165258293, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1736) },
                    { 599870663, 275228578, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1746), 1144692180, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1747) },
                    { 129475032, 302056421, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(459), -33242908, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(460) },
                    { 274010109, 302056421, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(471), 1666904153, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(472) },
                    { 599870663, 302056421, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(482), 2132773533, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(483) },
                    { 129475032, 302813929, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1792), 723703469, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1793) },
                    { 274010109, 302813929, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1804), -765501281, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1805) },
                    { 599870663, 302813929, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1815), 1311502860, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1816) },
                    { 129475032, 312895851, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1301), 1983220349, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1302) },
                    { 274010109, 312895851, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1312), -1777050386, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1313) },
                    { 599870663, 312895851, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1323), 402561959, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1324) },
                    { 129475032, 320777763, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2315), -314222102, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2316) },
                    { 274010109, 320777763, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2327), -2144981663, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2328) },
                    { 599870663, 320777763, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2342), -139793791, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2343) },
                    { 129475032, 366565182, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(740), -1058557112, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(741) },
                    { 274010109, 366565182, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(752), 832120070, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(753) },
                    { 599870663, 366565182, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(763), -248499629, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(764) },
                    { 129475032, 383379733, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1091), -2928145, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1093) },
                    { 274010109, 383379733, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1103), 741245234, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1104) },
                    { 599870663, 383379733, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1114), 247830283, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1115) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 129475032, 417246306, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1545), 175057835, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1546) },
                    { 274010109, 417246306, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1556), 662336717, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1557) },
                    { 599870663, 417246306, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1567), -399329369, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1568) },
                    { 129475032, 441823539, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(633), 1574406230, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(634) },
                    { 274010109, 441823539, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(644), -90415718, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(645) },
                    { 599870663, 441823539, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(656), 2100412035, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(657) },
                    { 129475032, 484322874, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1647), -456744730, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1648) },
                    { 274010109, 484322874, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1658), -167486750, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1660) },
                    { 599870663, 484322874, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1671), 251349229, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1672) },
                    { 129475032, 508016091, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2354), -454007569, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2355) },
                    { 274010109, 508016091, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2365), 1387903140, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2366) },
                    { 599870663, 508016091, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2376), 169470208, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2378) },
                    { 129475032, 517680786, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1161), -1494453842, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1162) },
                    { 274010109, 517680786, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1173), -817998488, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1174) },
                    { 599870663, 517680786, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1184), -1605249593, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1185) },
                    { 129475032, 520523082, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(599), 185835128, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(600) },
                    { 274010109, 520523082, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(610), -470187026, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(611) },
                    { 599870663, 520523082, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(621), -1950184376, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(623) },
                    { 129475032, 550667218, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1932), -1312608077, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1933) },
                    { 274010109, 550667218, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1943), -1475230648, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1944) },
                    { 599870663, 550667218, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1955), -748712659, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1956) },
                    { 129475032, 571231191, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2245), -1086953282, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2246) },
                    { 274010109, 571231191, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2257), -158149894, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2258) },
                    { 599870663, 571231191, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2268), 935601143, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2269) },
                    { 129475032, 572954941, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2074), -1254300767, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2075) },
                    { 274010109, 572954941, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2085), 662112860, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2086) },
                    { 599870663, 572954941, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2096), 211377115, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2097) },
                    { 129475032, 592632864, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2142), -954006718, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2143) },
                    { 274010109, 592632864, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2154), -317659409, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2155) },
                    { 599870663, 592632864, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2165), 1708774803, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2166) },
                    { 129475032, 593640545, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1966), -76467262, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1967) },
                    { 274010109, 593640545, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1981), -1607136772, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1982) },
                    { 599870663, 593640545, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1993), -626784713, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1994) },
                    { 129475032, 599799343, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2177), -2067161480, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2178) },
                    { 274010109, 599799343, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2188), 1532415240, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2189) },
                    { 599870663, 599799343, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2199), -2102195429, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2200) },
                    { 129475032, 607463251, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2458), -717106738, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2459) },
                    { 274010109, 607463251, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2469), -608914408, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2470) },
                    { 599870663, 607463251, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2481), -1098020263, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2482) },
                    { 129475032, 636073337, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1230), 1916046491, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1231) },
                    { 274010109, 636073337, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1241), -1453888790, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1242) },
                    { 599870663, 636073337, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1253), 257768884, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1254) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 129475032, 652086357, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1057), -807964348, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1058) },
                    { 274010109, 652086357, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1068), 1152888876, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1070) },
                    { 599870663, 652086357, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1080), -1090148777, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1081) },
                    { 129475032, 673598884, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1897), 1537860861, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1898) },
                    { 274010109, 673598884, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1909), -756208012, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1910) },
                    { 599870663, 673598884, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1920), -1195160917, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1921) },
                    { 129475032, 689213346, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1476), -1779201949, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1477) },
                    { 274010109, 689213346, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1488), -1938108923, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1489) },
                    { 599870663, 689213346, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1499), 1744262024, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1500) },
                    { 129475032, 691109450, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2211), -1871726462, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2212) },
                    { 274010109, 691109450, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2222), 2043367074, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2224) },
                    { 599870663, 691109450, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2234), 1789497621, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2235) },
                    { 129475032, 695625977, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1683), -981409918, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1684) },
                    { 274010109, 695625977, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1694), 1259877065, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1695) },
                    { 599870663, 695625977, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1711), -893449876, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1713) },
                    { 129475032, 702195958, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(917), -1909399931, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(918) },
                    { 274010109, 702195958, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(928), 2098395279, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(929) },
                    { 599870663, 702195958, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(939), -921793576, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(940) },
                    { 129475032, 732231840, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1826), 1904035136, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1827) },
                    { 274010109, 732231840, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1839), -245913367, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1840) },
                    { 599870663, 732231840, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1850), -1774052770, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1851) },
                    { 129475032, 735403384, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1335), -637983355, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1336) },
                    { 274010109, 735403384, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1349), 1697632335, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1350) },
                    { 599870663, 735403384, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1361), 1735186118, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1362) },
                    { 129475032, 748156671, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2005), 501388043, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2006) },
                    { 274010109, 748156671, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2016), 1373477693, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2017) },
                    { 599870663, 748156671, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2028), 1778400725, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2029) },
                    { 129475032, 749574823, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1266), 192674363, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1267) },
                    { 274010109, 749574823, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1277), 1977053454, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1278) },
                    { 599870663, 749574823, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1288), 920502383, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1289) },
                    { 129475032, 753305563, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2039), 677787845, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2040) },
                    { 274010109, 753305563, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2051), -1530452402, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2052) },
                    { 599870663, 753305563, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2062), 513564053, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2063) },
                    { 129475032, 759148905, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(706), 676718204, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(707) },
                    { 274010109, 759148905, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(717), -1035022607, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(718) },
                    { 599870663, 759148905, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(729), 1951752821, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(730) },
                    { 129475032, 781426055, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1126), 1829663658, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1127) },
                    { 274010109, 781426055, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1137), -2002015651, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1138) },
                    { 599870663, 781426055, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1150), -1276191782, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1151) },
                    { 129475032, 811156518, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(667), -1430072198, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(668) },
                    { 274010109, 811156518, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(679), -362751898, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(680) },
                    { 599870663, 811156518, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(694), 963284045, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(695) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 129475032, 811723097, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2388), -1524452404, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2389) },
                    { 274010109, 811723097, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2400), -1176655193, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2401) },
                    { 599870663, 811723097, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2411), -841598423, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2412) },
                    { 129475032, 823533070, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(495), -1184937272, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(496) },
                    { 274010109, 823533070, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(506), 1953402710, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(507) },
                    { 599870663, 823533070, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(518), -700505761, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(519) },
                    { 129475032, 853534371, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1862), 214312271, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1863) },
                    { 274010109, 853534371, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1873), 1953823586, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1874) },
                    { 599870663, 853534371, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1884), 524009741, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1886) },
                    { 129475032, 853920243, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1510), -1029838022, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1511) },
                    { 274010109, 853920243, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1522), -1696558535, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1523) },
                    { 599870663, 853920243, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1533), 1999390536, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1534) },
                    { 129475032, 857360920, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2422), -476994703, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2424) },
                    { 274010109, 857360920, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2434), 491321030, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2435) },
                    { 599870663, 857360920, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2445), 1287111519, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2447) },
                    { 129475032, 895127128, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1196), -233121806, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1197) },
                    { 274010109, 895127128, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1207), 1393802883, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1208) },
                    { 599870663, 895127128, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1219), 1405360800, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1220) },
                    { 129475032, 895553367, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(847), 1863469031, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(848) },
                    { 274010109, 895553367, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(858), 1680231947, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(859) },
                    { 599870663, 895553367, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(870), -1685315911, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(871) },
                    { 129475032, 895764288, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(564), 1093284716, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(565) },
                    { 274010109, 895764288, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(575), -1442897711, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(576) },
                    { 599870663, 895764288, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(587), 28626629, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(588) },
                    { 129475032, 903398819, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(882), -448849214, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(883) },
                    { 274010109, 903398819, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(893), -510883658, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(895) },
                    { 599870663, 903398819, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(905), 136281871, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(906) },
                    { 129475032, 909428484, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1373), -442282355, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1374) },
                    { 274010109, 909428484, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1384), 1268749962, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1385) },
                    { 599870663, 909428484, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1396), -1421664286, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1397) },
                    { 129475032, 947978946, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1407), -1735908151, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1408) },
                    { 274010109, 947978946, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1418), 1148554544, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1420) },
                    { 599870663, 947978946, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1430), -1505153780, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1432) },
                    { 129475032, 949273777, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(423), 228778615, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(424) },
                    { 274010109, 949273777, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(434), -1539133208, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(436) },
                    { 599870663, 949273777, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(447), 1046674607, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(448) },
                    { 129475032, 950991985, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(382), -62409131, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(384) },
                    { 274010109, 950991985, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(399), 485268260, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(401) },
                    { 599870663, 950991985, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(411), 149389489, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(412) },
                    { 129475032, 953641622, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2280), -452824685, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2281) },
                    { 274010109, 953641622, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2292), 1614889845, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2293) },
                    { 599870663, 953641622, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2304), 47382584, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(2305) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 129475032, 976013356, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(529), -1389522437, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(530) },
                    { 274010109, 976013356, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(541), 39293672, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(542) },
                    { 599870663, 976013356, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(552), -174702820, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(553) },
                    { 129475032, 977464321, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(951), 2088927603, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(952) },
                    { 274010109, 977464321, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(963), -2098425509, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(964) },
                    { 599870663, 977464321, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(974), 695846561, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(975) },
                    { 129475032, 994240247, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(810), 771732158, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(812) },
                    { 274010109, 994240247, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(823), 787528193, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(824) },
                    { 599870663, 994240247, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(835), -1971396760, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(836) },
                    { 129475032, 997942632, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1020), -1377390581, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1021) },
                    { 274010109, 997942632, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1034), -423814652, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1035) },
                    { 599870663, 997942632, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1046), -135638000, new DateTime(2024, 3, 11, 20, 26, 26, 806, DateTimeKind.Local).AddTicks(1047) }
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
