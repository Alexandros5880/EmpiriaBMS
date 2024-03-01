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
                name: "DailyHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSpanId = table.Column<int>(type: "int", nullable: false),
                    DailyUserId = table.Column<int>(type: "int", nullable: false),
                    PersonalUserId = table.Column<int>(type: "int", nullable: false),
                    TrainingUserId = table.Column<int>(type: "int", nullable: false),
                    CorporateUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyHour_TimeSpans_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "TimeSpans",
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

            migrationBuilder.CreateTable(
                name: "ManHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawingId = table.Column<int>(type: "int", nullable: true),
                    OtherId = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManHour_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHour_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHour_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHour_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHour_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DisciplineTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 196676470, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6784), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6785), "BMS" },
                    { 199942108, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6667), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6668), "Drainage" },
                    { 253331956, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6641), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6642), "Sewage" },
                    { 283337957, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6760), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6761), "Burglar Alarm" },
                    { 297042897, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6832), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6834), "TenderDocument" },
                    { 315728140, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6820), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6822), "Outsource" },
                    { 322680407, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6808), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6809), "Energy Efficiency" },
                    { 334923639, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6796), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6797), "Photovoltaics" },
                    { 348645505, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6733), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6734), "Power Distribution" },
                    { 440404392, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6721), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6722), "Natural Gas" },
                    { 447619615, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6621), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6622), "HVAC" },
                    { 481965742, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6772), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6773), "CCTV" },
                    { 528782666, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6679), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6680), "Fire Detection" },
                    { 534491605, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6747), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6748), "Structured Cabling" },
                    { 600166854, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6709), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6710), "Elevators" },
                    { 619695621, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6654), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6655), "Potable Water" },
                    { 842231965, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6846), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6847), "Construction Supervision" },
                    { 976930872, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6696), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6697), "Fire Suppression" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 174665589, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7055), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7056), "Calculations" },
                    { 296145934, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7034), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7035), "Documents" },
                    { 693680482, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7068), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7069), "Drawings" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 540774339, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7713), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7714), "Printing" },
                    { 688884562, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7752), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7753), "Administration" },
                    { 754610090, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7588), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7589), "Communications" },
                    { 860231055, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7739), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7740), "Meetings" },
                    { 926284532, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7726), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7728), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 191157857, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6176), "Consulting Description", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6177), "Consulting" },
                    { 357430549, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6130), "Buildings Description", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6132), "Buildings" },
                    { 387255825, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6148), "Infrastructure Description", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6149), "Infrastructure" },
                    { 975235615, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6162), "Energy Description", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6163), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 132930697, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5319), true, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5320), "CTO" },
                    { 554815485, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5334), false, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5335), "Guest" },
                    { 558429116, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5298), true, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5299), "Engineer" },
                    { 620316800, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5327), true, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5328), "CEO" },
                    { 628511180, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5305), true, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5306), "Project Manager" },
                    { 639009401, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5349), false, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5350), "Admin" },
                    { 664376506, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5341), false, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5343), "Customer" },
                    { 697570185, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5289), true, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5290), "Designer" },
                    { 836988230, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5312), true, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5313), "COO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 293236226, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6290), "Test Description PM 4", "pm4@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6292), null, "6949277784", null, null, null },
                    { 295008877, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6263), "Test Description PM 3", "pm3@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6264), null, "6949277783", null, null, null },
                    { 326388869, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5758), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5759), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5936), "Test Description Engineer 3", "engineer_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5937), null, "6949277783", null, null, null },
                    { 365854612, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5642), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5643), null, "6949277780", null, null, null },
                    { 424825672, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6202), "Test Description PM 1", "pm1@gmail.com", "Platanios_PM_1", "Alexandros_1", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6203), null, "6949277781", null, null, null },
                    { 425352499, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5479), "Admin", "admin@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5481), null, "694927778", null, null, null },
                    { 464503470, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5703), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5704), null, "6949277781", null, null, null },
                    { 475768910, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5581), "COO", "coo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5582), null, "694927778", null, null, null },
                    { 500141972, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5610), "Guest", "guest@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5611), null, "694927778", null, null, null },
                    { 502149727, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5521), "CEO", "ceo@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5522), null, "694927778", null, null, null },
                    { 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5850), "Test Description Engineer 0", "engineer_0@gmail.com", "Platanios_Engineer_0", "Alexandros_0", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5851), null, "6949277780", null, null, null },
                    { 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5963), "Test Description Engineer 4", "engineer_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5964), null, "6949277784", null, null, null },
                    { 797614877, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5821), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5822), null, "6949277785", null, null, null },
                    { 812198941, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5730), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5732), null, "6949277782", null, null, null },
                    { 814670692, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5791), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5792), null, "6949277784", null, null, null },
                    { 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5882), "Test Description Engineer 1", "engineer_1@gmail.com", "Platanios_Engineer_1", "Alexandros_1", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5883), null, "6949277781", null, null, null },
                    { 924188091, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6235), "Test Description PM 2", "pm2@gmail.com", "Platanios_PM_2", "Alexandros_2", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6236), null, "6949277782", null, null, null },
                    { 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5909), "Test Description Engineer 2", "engineer_2@gmail.com", "Platanios_Engineer_2", "Alexandros_2", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5910), null, "6949277782", null, null, null },
                    { 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5991), "Test Description Engineer 5", "engineer_5@gmail.com", "Platanios_Engineer_5", "Alexandros_5", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5992), null, "6949277785", null, null, null },
                    { 991050497, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5552), "CTO", "cto@gmail.com", "Platanios", "Alexandros", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5553), null, "694927778", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 242907668, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 7.0, 4, new DateTime(2024, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 4, "Test Description Project_6", "KL-2", new DateTime(2024, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), new DateTime(2024, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 0f, 100L, 12L, new DateTime(2024, 3, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), "Project_2", 5.0, new DateTime(2024, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), "Payment Detailes For Project_4", 2.0, null, 387255825, new DateTime(2024, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 0f },
                    { 344756620, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 6.0, 1, new DateTime(2024, 4, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 1, "Test Description Project_5", "KL-1", new DateTime(2024, 4, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), new DateTime(2024, 4, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 0f, 100L, 12L, new DateTime(2024, 3, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), "Project_1", 5.0, new DateTime(2024, 4, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), "Payment Detailes For Project_4", 1.0, null, 357430549, new DateTime(2024, 4, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 0f },
                    { 650353389, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 8.0, 9, new DateTime(2024, 12, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 9, "Test Description Project_12", "KL-3", new DateTime(2024, 12, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), new DateTime(2024, 12, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 0f, 100L, 12L, new DateTime(2024, 3, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), "Project_3", 5.0, new DateTime(2024, 12, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), "Payment Detailes For Project_3", 3.0, null, 975235615, new DateTime(2024, 12, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 0f },
                    { 995751927, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 9.0, 16, new DateTime(2025, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 16, "Test Description Project_24", "KL-4", new DateTime(2025, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), new DateTime(2025, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 0f, 100L, 12L, new DateTime(2024, 3, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), "Project_4", 5.0, new DateTime(2025, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), "Payment Detailes For Project_12", 4.0, null, 191157857, new DateTime(2025, 7, 1, 16, 29, 0, 913, DateTimeKind.Local).AddTicks(6543), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 628511180, 293236226, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6305), 248735385, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6306) },
                    { 628511180, 295008877, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6277), 659165934, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6279) },
                    { 697570185, 326388869, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5774), 486478767, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5775) },
                    { 558429116, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5951), 197927808, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5952) },
                    { 697570185, 365854612, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5689), 481234248, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5690) },
                    { 628511180, 424825672, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6220), 296736324, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6221) },
                    { 639009401, 425352499, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5501), 710183970, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5503) },
                    { 697570185, 464503470, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5718), 217732877, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5719) },
                    { 836988230, 475768910, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5595), 978690947, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5596) },
                    { 554815485, 500141972, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5625), 760576567, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5626) },
                    { 620316800, 502149727, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5537), 920491080, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5539) },
                    { 558429116, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5868), 744730700, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5869) },
                    { 558429116, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5979), 948971365, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5980) },
                    { 697570185, 797614877, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5836), 327970672, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5837) },
                    { 697570185, 812198941, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5746), 230497855, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5747) },
                    { 697570185, 814670692, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5808), 586548017, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5809) },
                    { 558429116, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5897), 556257803, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5898) },
                    { 628511180, 924188091, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6250), 940479567, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6251) },
                    { 558429116, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5924), 411109116, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5925) },
                    { 558429116, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6008), 231436004, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6009) },
                    { 132930697, 991050497, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5567), 612039896, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(5568) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1841364880, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6911), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6912), 242907668, 528782666, null },
                    { -1738060160, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7007), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7008), 995751927, 534491605, null },
                    { -1719935600, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6924), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6925), 242907668, 283337957, null },
                    { -808216000, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6965), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6966), 650353389, 440404392, null },
                    { -667635128, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6884), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6885), 344756620, 322680407, null },
                    { -626514384, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7020), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7021), 995751927, 348645505, null },
                    { -244578600, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6952), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6953), 650353389, 297042897, null },
                    { -125437728, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6992), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6993), 995751927, 334923639, null },
                    { 67777384, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6939), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6940), 242907668, 440404392, null },
                    { 109876920, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6862), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6864), 344756620, 600166854, null },
                    { 1147119624, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6898), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6899), 344756620, 619695621, null },
                    { 1684468368, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6978), 0f, 1500L, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6979), 650353389, 481965742, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 507998353, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6477), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6479), 3100.0, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6478), "Signature 142348", 15786, 242907668, 2.0, 24.0 },
                    { 551311961, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6540), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6542), 4000.0, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6541), "Signature 142349", 70471, 650353389, 3.0, 17.0 },
                    { 661841740, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6601), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6604), 13000.0, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6603), "Signature 1423420", 27231, 995751927, 4.0, 24.0 },
                    { 778768813, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6402), new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6405), 3010.0, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6403), "Signature 142341", 58972, 344756620, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 995751927, 293236226, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8647), 527760814, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8648) },
                    { 650353389, 295008877, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8634), 943282775, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8636) },
                    { 344756620, 424825672, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8602), 259914067, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8604) },
                    { 242907668, 924188091, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8621), 204779320, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8622) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 471326775, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6368), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6369), null, "6949277781", null, null, 344756620 },
                    { 626606558, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6449), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6450), null, "6949277782", null, null, 242907668 },
                    { 711287615, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6574), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6575), null, "6949277784", null, null, 995751927 },
                    { 790575635, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6512), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6513), null, "6949277783", null, null, 650353389 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1841364880, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8936), 920478986, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8938) },
                    { -1841364880, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8899), 551157128, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8900) },
                    { -1841364880, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8949), 930048047, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8950) },
                    { -1841364880, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8912), 293924312, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8913) },
                    { -1841364880, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8924), 912393339, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8925) },
                    { -1841364880, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8961), 361159332, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8963) },
                    { -1738060160, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9464), 348463798, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9465) },
                    { -1738060160, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9427), 670587117, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9428) },
                    { -1738060160, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9476), 223595085, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9477) },
                    { -1738060160, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9439), 536738641, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9441) },
                    { -1738060160, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9452), 481710956, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9453) },
                    { -1738060160, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9490), 959628748, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9491) },
                    { -1719935600, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9012), 621577982, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9013) },
                    { -1719935600, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8974), 225849532, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8975) },
                    { -1719935600, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9024), 782596356, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9026) },
                    { -1719935600, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8986), 603951124, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8988) },
                    { -1719935600, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8999), 211353305, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9000) },
                    { -1719935600, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9037), 545785242, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9038) },
                    { -808216000, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9241), 800820410, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9242) },
                    { -808216000, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9203), 347244854, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9204) },
                    { -808216000, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9253), 982852772, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9254) },
                    { -808216000, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9216), 634785430, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9217) },
                    { -808216000, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9228), 236942388, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9229) },
                    { -808216000, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9266), 842438213, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9267) },
                    { -667635128, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8783), 210995539, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8784) },
                    { -667635128, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8745), 740372811, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8746) },
                    { -667635128, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8795), 911561027, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8797) },
                    { -667635128, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8757), 196445749, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8758) },
                    { -667635128, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8770), 919060408, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8771) },
                    { -667635128, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8808), 684337358, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8809) },
                    { -626514384, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9542), 898292127, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9544) },
                    { -626514384, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9502), 882751312, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9504) },
                    { -626514384, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9555), 257235900, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9556) },
                    { -626514384, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9518), 362909191, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9519) },
                    { -626514384, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9530), 204778499, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9531) },
                    { -626514384, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9567), 332356350, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9568) },
                    { -244578600, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9163), 166109899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9164) },
                    { -244578600, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9125), 893887842, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9126) },
                    { -244578600, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9178), 767404965, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9179) },
                    { -244578600, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9137), 593766479, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9138) },
                    { -244578600, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9150), 163314211, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9151) },
                    { -244578600, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9191), 147835068, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9192) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -125437728, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9390), 795134946, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9391) },
                    { -125437728, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9353), 496255493, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9354) },
                    { -125437728, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9402), 262061984, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9404) },
                    { -125437728, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9365), 481858839, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9366) },
                    { -125437728, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9377), 842394770, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9378) },
                    { -125437728, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9415), 993690230, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9416) },
                    { 67777384, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9087), 822735239, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9088) },
                    { 67777384, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9049), 507472694, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9051) },
                    { 67777384, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9100), 533027440, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9101) },
                    { 67777384, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9062), 565689865, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9063) },
                    { 67777384, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9074), 406049453, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9075) },
                    { 67777384, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9113), 471519487, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9114) },
                    { 109876920, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8705), 971034657, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8706) },
                    { 109876920, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8660), 649712274, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8661) },
                    { 109876920, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8718), 423117275, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8719) },
                    { 109876920, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8679), 618401054, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8680) },
                    { 109876920, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8692), 299715330, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8693) },
                    { 109876920, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8731), 401709229, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8732) },
                    { 1147119624, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8860), 701582624, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8861) },
                    { 1147119624, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8823), 219580118, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8824) },
                    { 1147119624, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8873), 255004398, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8874) },
                    { 1147119624, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8835), 657037858, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8836) },
                    { 1147119624, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8848), 691105284, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8849) },
                    { 1147119624, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8886), 159262524, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8887) },
                    { 1684468368, 346417169, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9315), 420924940, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9317) },
                    { 1684468368, 653958228, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9279), 679959997, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9280) },
                    { 1684468368, 765744354, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9328), 177318561, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9329) },
                    { 1684468368, 828627511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9291), 847633398, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9292) },
                    { 1684468368, 948367293, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9303), 627176012, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9304) },
                    { 1684468368, 974254899, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9340), 669093430, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9341) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 130651244, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7173), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7171), 1147119624, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7172), 296145934 },
                    { 147317825, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7325), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7323), 67777384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7324), 693680482 },
                    { 148425643, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7479), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7477), -125437728, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7478), 174665589 },
                    { 163961900, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7356), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7354), -244578600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7355), 174665589 },
                    { 173268270, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7159), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7157), -667635128, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7158), 693680482 },
                    { 219120763, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7144), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7142), -667635128, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7143), 174665589 },
                    { 222095642, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7519), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7517), -1738060160, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7518), 174665589 },
                    { 229738631, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7533), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7531), -1738060160, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7532), 693680482 },
                    { 275060078, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7117), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7114), 109876920, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7115), 693680482 },
                    { 299987659, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7439), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7436), 1684468368, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7438), 174665589 },
                    { 342800713, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7230), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7227), -1841364880, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7228), 174665589 },
                    { 374694083, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7297), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7295), 67777384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7296), 296145934 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 392948050, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7384), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7382), -808216000, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7383), 296145934 },
                    { 396464612, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7216), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7213), -1841364880, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7215), 296145934 },
                    { 426500204, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7271), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7268), -1719935600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7269), 174665589 },
                    { 434767003, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7562), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7560), -626514384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7561), 174665589 },
                    { 466501104, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7493), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7490), -125437728, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7491), 693680482 },
                    { 506920544, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7243), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7241), -1841364880, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7242), 693680482 },
                    { 524387219, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7370), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7367), -244578600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7369), 693680482 },
                    { 538858283, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7103), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7100), 109876920, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7101), 174665589 },
                    { 544113530, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7576), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7573), -626514384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7575), 693680482 },
                    { 554132945, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7425), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7423), 1684468368, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7424), 296145934 },
                    { 571675712, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7412), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7409), -808216000, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7410), 693680482 },
                    { 611764641, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7343), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7340), -244578600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7341), 296145934 },
                    { 634377192, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7130), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7128), -667635128, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7129), 296145934 },
                    { 688560900, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7310), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7308), 67777384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7309), 174665589 },
                    { 699973224, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7200), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7198), 1147119624, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7199), 693680482 },
                    { 737202285, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7257), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7255), -1719935600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7256), 296145934 },
                    { 749628165, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7549), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7547), -626514384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7548), 296145934 },
                    { 766018576, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7452), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7450), 1684468368, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7451), 693680482 },
                    { 812398388, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7187), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7184), 1147119624, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7185), 174665589 },
                    { 906932031, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7085), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7082), 109876920, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7083), 296145934 },
                    { 907420218, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7398), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7395), -808216000, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7397), 174665589 },
                    { 919890080, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7284), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7282), -1719935600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7283), 693680482 },
                    { 957018212, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7506), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7504), -1738060160, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7505), 296145934 },
                    { 995911060, new DateTime(2024, 3, 12, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7465), 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7463), -125437728, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7464), 296145934 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 137577220, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8518), -1738060160, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8519), 860231055 },
                    { 143096727, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7985), -1841364880, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7986), 926284532 },
                    { 150239803, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8143), -244578600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8144), 754610090 },
                    { 181897297, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8494), -1738060160, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8495), 540774339 },
                    { 191173412, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8530), -1738060160, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8531), 688884562 },
                    { 214159009, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8577), -626514384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8578), 860231055 },
                    { 215561355, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8180), -244578600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8181), 860231055 },
                    { 247252779, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7948), 1147119624, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7949), 688884562 },
                    { 274433783, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8021), -1719935600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8022), 754610090 },
                    { 289546538, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7874), -667635128, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7875), 860231055 },
                    { 290510050, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8276), 1684468368, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8277), 540774339 },
                    { 341315511, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7771), 109876920, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7772), 754610090 },
                    { 352907394, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7838), -667635128, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7839), 754610090 },
                    { 359139965, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8228), -808216000, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8229), 926284532 },
                    { 365228463, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7787), 109876920, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7788), 540774339 },
                    { 365651265, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8458), -125437728, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8459), 860231055 },
                    { 366285670, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8406), 1684468368, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8407), 688884562 },
                    { 396459632, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7912), 1147119624, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7914), 540774339 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 401524717, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8419), -125437728, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8420), 754610090 },
                    { 414815263, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8542), -626514384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8543), 754610090 },
                    { 415077152, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8566), -626514384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8567), 926284532 },
                    { 430698981, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8431), -125437728, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8432), 540774339 },
                    { 456373974, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8131), 67777384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8132), 688884562 },
                    { 484734584, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8216), -808216000, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8217), 540774339 },
                    { 498411339, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8265), 1684468368, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8266), 754610090 },
                    { 500857077, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8506), -1738060160, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8507), 926284532 },
                    { 509641686, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8241), -808216000, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8242), 860231055 },
                    { 522067846, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7824), 109876920, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7825), 688884562 },
                    { 525805888, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8096), 67777384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8097), 540774339 },
                    { 530527227, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8155), -244578600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8156), 540774339 },
                    { 549671682, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8589), -626514384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8590), 688884562 },
                    { 551655235, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8084), 67777384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8085), 754610090 },
                    { 556215581, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8482), -1738060160, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8483), 754610090 },
                    { 561137666, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7924), 1147119624, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7925), 926284532 },
                    { 573145086, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7888), -667635128, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7889), 688884562 },
                    { 583446052, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7800), 109876920, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7801), 926284532 },
                    { 584567762, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8009), -1841364880, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8010), 688884562 },
                    { 611790864, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8192), -244578600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8193), 688884562 },
                    { 624676316, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8167), -244578600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8168), 926284532 },
                    { 626511130, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8033), -1719935600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8034), 540774339 },
                    { 654442055, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8554), -626514384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8555), 540774339 },
                    { 673149528, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7971), -1841364880, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7973), 540774339 },
                    { 675930080, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8204), -808216000, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8205), 754610090 },
                    { 683027226, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8107), 67777384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8109), 926284532 },
                    { 689014842, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7812), 109876920, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7813), 860231055 },
                    { 696393608, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8470), -125437728, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8471), 688884562 },
                    { 707040124, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7960), -1841364880, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7961), 754610090 },
                    { 708683091, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8072), -1719935600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8073), 688884562 },
                    { 735883593, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7900), 1147119624, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7901), 754610090 },
                    { 744583675, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8252), -808216000, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8254), 688884562 },
                    { 746991313, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8059), -1719935600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8060), 860231055 },
                    { 763100588, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8383), 1684468368, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8384), 926284532 },
                    { 777390693, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7850), -667635128, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7851), 540774339 },
                    { 823342121, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7862), -667635128, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7863), 926284532 },
                    { 840723467, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8045), -1719935600, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8046), 926284532 },
                    { 847116662, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7936), 1147119624, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7937), 860231055 },
                    { 867245028, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8119), 67777384, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8120), 860231055 },
                    { 881398163, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7997), -1841364880, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(7998), 860231055 },
                    { 956442179, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8443), -125437728, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8444), 926284532 },
                    { 959346336, 0f, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8394), 1684468368, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(8396), 860231055 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 664376506, 471326775, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6386), 239565353, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6388) },
                    { 664376506, 626606558, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6465), 453245659, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6466) },
                    { 664376506, 711287615, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6589), 887720240, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6590) },
                    { 664376506, 790575635, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6528), 559971745, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(6529) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 326388869, 137577220, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3596), -1017723019, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3597) },
                    { 365854612, 137577220, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3559), -1687738157, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3560) },
                    { 464503470, 137577220, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3571), 1712190236, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3572) },
                    { 797614877, 137577220, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3620), -1505059906, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3622) },
                    { 812198941, 137577220, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3583), 272803775, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3584) },
                    { 814670692, 137577220, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3608), 845031488, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3609) },
                    { 326388869, 143096727, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(903), -1909026278, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(904) },
                    { 365854612, 143096727, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(866), -1795452205, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(867) },
                    { 464503470, 143096727, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(879), 893897708, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(880) },
                    { 797614877, 143096727, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(928), 1627375361, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(929) },
                    { 812198941, 143096727, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(891), 958295021, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(892) },
                    { 814670692, 143096727, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(916), -686908997, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(917) },
                    { 326388869, 150239803, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1876), -2098516594, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1877) },
                    { 365854612, 150239803, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1839), -1156670923, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1841) },
                    { 464503470, 150239803, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1852), -311793668, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1853) },
                    { 797614877, 150239803, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1901), -964178455, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1902) },
                    { 812198941, 150239803, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1864), 1080381011, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1865) },
                    { 814670692, 150239803, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1888), -1476065542, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1890) },
                    { 326388869, 181897297, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3447), 2020426979, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3448) },
                    { 365854612, 181897297, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3410), -113772703, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3412) },
                    { 464503470, 181897297, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3423), -5705036, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3424) },
                    { 797614877, 181897297, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3472), -1454083406, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3473) },
                    { 812198941, 181897297, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3435), 1349511494, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3436) },
                    { 814670692, 181897297, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3459), -2030254240, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3460) },
                    { 326388869, 191173412, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3670), 763512890, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3671) },
                    { 365854612, 191173412, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3633), 21090722, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3634) },
                    { 464503470, 191173412, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3645), -86154673, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3646) },
                    { 797614877, 191173412, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3694), -1321529957, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3695) },
                    { 812198941, 191173412, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3658), 1999123983, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3659) },
                    { 814670692, 191173412, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3682), 124390189, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3683) },
                    { 326388869, 214159009, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3970), 2035960673, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3971) },
                    { 365854612, 214159009, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3933), -250335980, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3934) },
                    { 464503470, 214159009, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3945), -1466666590, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3946) },
                    { 797614877, 214159009, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3994), -247281394, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3995) },
                    { 812198941, 214159009, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3957), 1731045231, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3958) },
                    { 814670692, 214159009, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3982), 1748647094, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3983) },
                    { 326388869, 215561355, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2100), -160557443, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2101) },
                    { 365854612, 215561355, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2063), -1848997021, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2064) },
                    { 464503470, 215561355, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2075), 1802706287, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2076) },
                    { 797614877, 215561355, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2125), 321531445, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2126) },
                    { 812198941, 215561355, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2088), -64879064, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2089) },
                    { 814670692, 215561355, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2113), -1170168875, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2114) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 326388869, 247252779, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(681), -1408895860, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(682) },
                    { 365854612, 247252779, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(644), 765359861, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(645) },
                    { 464503470, 247252779, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(656), 2050002590, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(657) },
                    { 797614877, 247252779, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(705), -1926839326, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(706) },
                    { 812198941, 247252779, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(668), -1089740267, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(669) },
                    { 814670692, 247252779, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(693), -444307468, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(694) },
                    { 326388869, 274433783, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1128), -919892389, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1129) },
                    { 365854612, 274433783, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1092), 2045114024, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1093) },
                    { 464503470, 274433783, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1104), 300991177, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1105) },
                    { 797614877, 274433783, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1153), 1770679998, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1154) },
                    { 812198941, 274433783, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1116), -2057984203, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1117) },
                    { 814670692, 274433783, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1141), 460212836, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1142) },
                    { 326388869, 289546538, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(227), -1044191564, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(228) },
                    { 365854612, 289546538, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(190), -780328255, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(191) },
                    { 464503470, 289546538, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(202), -1825106840, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(203) },
                    { 797614877, 289546538, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(255), 1674809937, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(256) },
                    { 812198941, 289546538, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(214), -1280764817, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(216) },
                    { 814670692, 289546538, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(239), 1231698641, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(241) },
                    { 326388869, 290510050, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2696), -140984536, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2697) },
                    { 365854612, 290510050, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2658), 2136973388, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2659) },
                    { 464503470, 290510050, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2671), -1832790379, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2672) },
                    { 797614877, 290510050, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2720), -2069995765, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2722) },
                    { 812198941, 290510050, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2683), -2143089814, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2684) },
                    { 814670692, 290510050, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2708), -1479789764, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2709) },
                    { 326388869, 341315511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9627), 1651654476, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9628) },
                    { 365854612, 341315511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9581), -208435792, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9583) },
                    { 464503470, 341315511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9601), -1802931524, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9602) },
                    { 797614877, 341315511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9653), 2068469694, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9654) },
                    { 812198941, 341315511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9615), -1504424960, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9616) },
                    { 814670692, 341315511, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9640), -922304195, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9641) },
                    { 326388869, 352907394, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(6), -328383260, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(7) },
                    { 365854612, 352907394, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9968), 1634118872, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9969) },
                    { 464503470, 352907394, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9980), -2045368948, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9982) },
                    { 797614877, 352907394, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(30), 1490418873, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(31) },
                    { 812198941, 352907394, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9993), 1123021940, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9994) },
                    { 814670692, 352907394, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(18), -386517968, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(19) },
                    { 326388869, 359139965, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2396), 1542002319, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2397) },
                    { 365854612, 359139965, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2359), 1834341746, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2360) },
                    { 464503470, 359139965, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2371), 92237513, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2372) },
                    { 797614877, 359139965, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2423), 1669410369, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2424) },
                    { 812198941, 359139965, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2384), -1738746764, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2385) },
                    { 814670692, 359139965, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2408), 307025704, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2409) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 326388869, 365228463, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9705), -2045789369, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9706) },
                    { 365854612, 365228463, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9666), -1158175201, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9667) },
                    { 464503470, 365228463, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9679), 411461321, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9680) },
                    { 797614877, 365228463, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9729), -626290946, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9730) },
                    { 812198941, 365228463, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9691), -476195570, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9692) },
                    { 814670692, 365228463, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9717), -1211871757, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9718) },
                    { 326388869, 365651265, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3223), -2118499663, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3224) },
                    { 365854612, 365651265, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3186), -1587693860, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3187) },
                    { 464503470, 365651265, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3198), 596820452, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3199) },
                    { 797614877, 365651265, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3247), 144939119, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3248) },
                    { 812198941, 365651265, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3210), -129423955, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3211) },
                    { 814670692, 365651265, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3235), 2110924494, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3236) },
                    { 326388869, 366285670, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2923), -18541772, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2924) },
                    { 365854612, 366285670, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2886), 392410990, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2887) },
                    { 464503470, 366285670, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2898), 1440561168, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2899) },
                    { 797614877, 366285670, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2948), -1257223468, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2950) },
                    { 812198941, 366285670, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2910), 187697723, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2911) },
                    { 814670692, 366285670, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2936), -1022966536, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2937) },
                    { 326388869, 396459632, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(454), 694294106, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(455) },
                    { 365854612, 396459632, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(417), -1731744233, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(418) },
                    { 464503470, 396459632, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(429), -727104455, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(430) },
                    { 797614877, 396459632, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(479), 2095467692, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(480) },
                    { 812198941, 396459632, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(442), -210497606, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(443) },
                    { 814670692, 396459632, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(466), 1189933106, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(468) },
                    { 326388869, 401524717, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3001), 1307502122, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3002) },
                    { 365854612, 401524717, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2961), 1614930885, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2962) },
                    { 464503470, 401524717, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2973), -1119413776, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2974) },
                    { 797614877, 401524717, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3026), 528548999, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3027) },
                    { 812198941, 401524717, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2985), 1695960644, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2986) },
                    { 814670692, 401524717, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3013), 1953421560, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3014) },
                    { 326388869, 414815263, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3744), -1630240964, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3745) },
                    { 365854612, 414815263, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3707), 492777149, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3708) },
                    { 464503470, 414815263, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3719), 1978619306, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3720) },
                    { 797614877, 414815263, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3772), 952669472, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3773) },
                    { 812198941, 414815263, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3731), 1276808657, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3732) },
                    { 814670692, 414815263, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3757), -2028988961, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3758) },
                    { 326388869, 415077152, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3896), -419850121, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3897) },
                    { 365854612, 415077152, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3858), 1805893502, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3859) },
                    { 464503470, 415077152, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3871), -755636714, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3872) },
                    { 797614877, 415077152, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3920), -603117958, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3921) },
                    { 812198941, 415077152, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3883), -150600136, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3884) },
                    { 814670692, 415077152, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3908), 1591879766, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3909) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 326388869, 430698981, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3075), 997188728, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3076) },
                    { 365854612, 430698981, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3038), 1949386559, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3039) },
                    { 464503470, 430698981, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3050), -740343892, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3051) },
                    { 797614877, 430698981, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3100), -550054921, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3101) },
                    { 812198941, 430698981, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3063), -699936632, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3064) },
                    { 814670692, 430698981, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3087), 1883257421, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3088) },
                    { 326388869, 456373974, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1803), -892923920, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1804) },
                    { 365854612, 456373974, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1766), -1865998835, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1767) },
                    { 464503470, 456373974, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1778), 710060630, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1779) },
                    { 797614877, 456373974, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1827), 68189630, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1828) },
                    { 812198941, 456373974, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1790), -1916592709, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1791) },
                    { 814670692, 456373974, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1815), -411809467, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1816) },
                    { 326388869, 484734584, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2322), 1723734657, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2323) },
                    { 365854612, 484734584, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2285), 806404613, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2286) },
                    { 464503470, 484734584, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2297), 1136369957, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2298) },
                    { 797614877, 484734584, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2346), 1892773593, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2347) },
                    { 812198941, 484734584, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2310), -947937271, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2311) },
                    { 814670692, 484734584, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2334), 1552423905, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2335) },
                    { 326388869, 498411339, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2621), -803940011, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2622) },
                    { 365854612, 498411339, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2584), 1950280578, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2585) },
                    { 464503470, 498411339, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2596), -251654566, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2598) },
                    { 797614877, 498411339, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2646), -1674493501, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2647) },
                    { 812198941, 498411339, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2609), -1596292024, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2610) },
                    { 814670692, 498411339, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2633), -412662199, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2634) },
                    { 326388869, 500857077, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3521), 773534741, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3522) },
                    { 365854612, 500857077, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3484), 2059767473, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3486) },
                    { 464503470, 500857077, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3497), 1192624983, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3498) },
                    { 797614877, 500857077, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3546), -1694361694, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3547) },
                    { 812198941, 500857077, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3509), -1183874174, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3510) },
                    { 814670692, 500857077, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3533), -903392279, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3535) },
                    { 326388869, 509641686, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2473), 1867165965, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2474) },
                    { 365854612, 509641686, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2436), -15950659, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2437) },
                    { 464503470, 509641686, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2448), -1942164539, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2449) },
                    { 797614877, 509641686, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2498), -1508967013, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2499) },
                    { 812198941, 509641686, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2461), -1627222135, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2462) },
                    { 814670692, 509641686, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2485), -2030613916, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2486) },
                    { 326388869, 522067846, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9931), -158501951, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9932) },
                    { 365854612, 522067846, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9894), -1737103490, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9895) },
                    { 464503470, 522067846, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9907), 454989263, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9908) },
                    { 797614877, 522067846, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9955), -1397090852, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9957) },
                    { 812198941, 522067846, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9919), 1549528349, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9920) },
                    { 814670692, 522067846, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9943), 1759311914, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9944) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 326388869, 525805888, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1577), -1696703417, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1578) },
                    { 365854612, 525805888, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1541), -967515128, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1542) },
                    { 464503470, 525805888, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1553), -368932441, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1554) },
                    { 797614877, 525805888, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1602), -937451258, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1603) },
                    { 812198941, 525805888, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1565), 1648324697, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1566) },
                    { 814670692, 525805888, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1589), -2097581705, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1590) },
                    { 326388869, 530527227, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1950), -1457165362, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1951) },
                    { 365854612, 530527227, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1913), 1280925594, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1914) },
                    { 464503470, 530527227, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1925), 1898976582, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1926) },
                    { 797614877, 530527227, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1974), -2001062380, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1975) },
                    { 812198941, 530527227, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1937), -339796633, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1938) },
                    { 814670692, 530527227, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1962), 1011229052, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1963) },
                    { 326388869, 549671682, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4044), -1109839895, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4045) },
                    { 365854612, 549671682, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4007), -762901802, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4008) },
                    { 464503470, 549671682, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4019), -1248320218, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4020) },
                    { 797614877, 549671682, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4068), -165330715, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4069) },
                    { 812198941, 549671682, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4031), -1995269336, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4032) },
                    { 814670692, 549671682, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4056), 1507253423, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(4057) },
                    { 326388869, 551655235, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1504), -1540741531, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1505) },
                    { 365854612, 551655235, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1466), 1087194344, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1468) },
                    { 464503470, 551655235, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1479), -1375391591, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1480) },
                    { 797614877, 551655235, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1528), 314502958, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1529) },
                    { 812198941, 551655235, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1491), 916196000, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1492) },
                    { 814670692, 551655235, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1516), -470786858, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1517) },
                    { 326388869, 556215581, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3371), -1323120433, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3372) },
                    { 365854612, 556215581, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3334), -1907683960, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3335) },
                    { 464503470, 556215581, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3346), 2049523205, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3348) },
                    { 797614877, 556215581, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3398), 709199312, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3399) },
                    { 812198941, 556215581, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3359), -1565781362, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3360) },
                    { 814670692, 556215581, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3386), -672558236, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3387) },
                    { 326388869, 561137666, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(529), -721416298, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(530) },
                    { 365854612, 561137666, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(491), 1824461496, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(492) },
                    { 464503470, 561137666, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(504), 1879840454, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(505) },
                    { 797614877, 561137666, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(554), 1820767325, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(555) },
                    { 812198941, 561137666, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(517), 1141856424, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(518) },
                    { 814670692, 561137666, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(542), -1774980863, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(543) },
                    { 326388869, 573145086, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(305), -1666787818, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(306) },
                    { 365854612, 573145086, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(268), 1553146592, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(269) },
                    { 464503470, 573145086, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(280), -886553077, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(281) },
                    { 797614877, 573145086, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(329), -996374996, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(330) },
                    { 812198941, 573145086, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(292), 2086163082, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(293) },
                    { 814670692, 573145086, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(317), 157024490, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(318) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 326388869, 583446052, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9778), -1491260530, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9780) },
                    { 365854612, 583446052, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9742), -248535908, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9743) },
                    { 464503470, 583446052, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9754), 1313054289, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9755) },
                    { 797614877, 583446052, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9804), -1730836759, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9805) },
                    { 812198941, 583446052, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9766), 1142242902, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9767) },
                    { 814670692, 583446052, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9791), 523315454, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9792) },
                    { 326388869, 584567762, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1054), -961612159, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1055) },
                    { 365854612, 584567762, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1017), 1632154352, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1018) },
                    { 464503470, 584567762, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1029), -347540777, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1030) },
                    { 797614877, 584567762, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1079), 1765875798, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1080) },
                    { 812198941, 584567762, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1042), 551812919, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1043) },
                    { 814670692, 584567762, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1067), 192125728, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1068) },
                    { 326388869, 611790864, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2174), -555550996, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2175) },
                    { 365854612, 611790864, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2137), 117925201, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2139) },
                    { 464503470, 611790864, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2150), -1688649533, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2151) },
                    { 797614877, 611790864, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2199), 1295950577, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2200) },
                    { 812198941, 611790864, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2162), -248960254, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2163) },
                    { 814670692, 611790864, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2186), -1677203689, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2187) },
                    { 326388869, 624676316, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2024), -963946966, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2025) },
                    { 365854612, 624676316, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1987), -737304646, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1988) },
                    { 464503470, 624676316, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1999), 1720216193, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2000) },
                    { 797614877, 624676316, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2051), -1201152122, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2052) },
                    { 812198941, 624676316, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2011), 1547008394, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2012) },
                    { 814670692, 624676316, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2038), 2121208560, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2040) },
                    { 326388869, 626511130, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1204), -915235208, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1205) },
                    { 365854612, 626511130, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1166), -491817775, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1167) },
                    { 464503470, 626511130, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1178), 770098271, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1179) },
                    { 797614877, 626511130, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1229), 166778263, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1230) },
                    { 812198941, 626511130, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1191), -890674510, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1192) },
                    { 814670692, 626511130, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1217), -100499174, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1218) },
                    { 326388869, 654442055, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3821), 38172070, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3823) },
                    { 365854612, 654442055, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3785), -333798961, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3786) },
                    { 464503470, 654442055, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3797), 1475231472, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3798) },
                    { 797614877, 654442055, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3846), 2049990984, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3847) },
                    { 812198941, 654442055, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3809), -1743363962, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3810) },
                    { 814670692, 654442055, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3834), 2080445189, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3835) },
                    { 326388869, 673149528, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(829), -1966212782, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(830) },
                    { 365854612, 673149528, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(792), -455060060, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(793) },
                    { 464503470, 673149528, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(804), 2125725696, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(805) },
                    { 797614877, 673149528, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(854), -17337041, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(855) },
                    { 812198941, 673149528, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(817), 1746845469, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(818) },
                    { 814670692, 673149528, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(841), 764538269, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(842) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 326388869, 675930080, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2248), 316315549, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2249) },
                    { 365854612, 675930080, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2211), -814651933, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2212) },
                    { 464503470, 675930080, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2223), 1710724937, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2224) },
                    { 797614877, 675930080, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2273), -53762467, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2274) },
                    { 812198941, 675930080, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2236), -1859561864, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2237) },
                    { 814670692, 675930080, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2260), 2107596830, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2261) },
                    { 326388869, 683027226, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1654), -1884138596, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1656) },
                    { 365854612, 683027226, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1614), -1807437041, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1615) },
                    { 464503470, 683027226, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1627), -1710665693, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1628) },
                    { 797614877, 683027226, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1679), 1750085334, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1680) },
                    { 812198941, 683027226, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1639), 1900487556, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1640) },
                    { 814670692, 683027226, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1667), 1624429764, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1668) },
                    { 326388869, 689014842, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9853), -944076455, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9854) },
                    { 365854612, 689014842, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9817), -1638689723, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9818) },
                    { 464503470, 689014842, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9829), 1568901272, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9830) },
                    { 797614877, 689014842, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9878), 1070193497, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9879) },
                    { 812198941, 689014842, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9841), -1919434544, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9842) },
                    { 814670692, 689014842, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9866), 1475849669, new DateTime(2024, 3, 1, 16, 29, 0, 921, DateTimeKind.Local).AddTicks(9867) },
                    { 326388869, 696393608, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3297), 254231281, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3298) },
                    { 365854612, 696393608, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3260), -949847984, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3261) },
                    { 464503470, 696393608, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3272), 1361588270, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3273) },
                    { 797614877, 696393608, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3321), -578317900, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3323) },
                    { 812198941, 696393608, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3285), -506136631, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3286) },
                    { 814670692, 696393608, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3309), -180860377, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3310) },
                    { 326388869, 707040124, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(755), 1394991140, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(756) },
                    { 365854612, 707040124, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(718), -862801465, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(719) },
                    { 464503470, 707040124, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(730), -1059747074, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(731) },
                    { 797614877, 707040124, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(779), -885660740, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(780) },
                    { 812198941, 707040124, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(742), -1771455271, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(743) },
                    { 814670692, 707040124, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(767), 174793726, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(768) },
                    { 326388869, 708683091, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1429), -665952677, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1430) },
                    { 365854612, 708683091, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1392), 1710418136, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1393) },
                    { 464503470, 708683091, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1404), 95557532, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1405) },
                    { 797614877, 708683091, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1454), -956237728, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1455) },
                    { 812198941, 708683091, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1417), 1837702148, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1418) },
                    { 814670692, 708683091, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1441), 1177214009, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1443) },
                    { 326388869, 735883593, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(378), -1124771030, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(380) },
                    { 365854612, 735883593, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(341), 1799753409, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(342) },
                    { 464503470, 735883593, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(354), 1117729098, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(355) },
                    { 797614877, 735883593, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(405), -160857733, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(406) },
                    { 812198941, 735883593, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(366), 1369265310, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(367) },
                    { 814670692, 735883593, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(391), -1332396679, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(392) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 326388869, 744583675, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2547), -901480198, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2548) },
                    { 365854612, 744583675, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2510), -1635607853, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2511) },
                    { 464503470, 744583675, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2523), 357089473, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2524) },
                    { 797614877, 744583675, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2572), -809407210, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2573) },
                    { 812198941, 744583675, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2535), -539542628, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2536) },
                    { 814670692, 744583675, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2559), 1842401619, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2561) },
                    { 326388869, 746991313, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1355), -1932573014, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1356) },
                    { 365854612, 746991313, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1318), 1492151639, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1319) },
                    { 464503470, 746991313, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1331), -1261968353, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1332) },
                    { 797614877, 746991313, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1379), -632438509, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1381) },
                    { 812198941, 746991313, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1343), 270171505, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1344) },
                    { 814670692, 746991313, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1367), -1298112407, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1368) },
                    { 326388869, 763100588, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2770), -717955573, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2771) },
                    { 365854612, 763100588, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2733), -986081800, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2734) },
                    { 464503470, 763100588, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2745), 181297742, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2746) },
                    { 797614877, 763100588, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2798), -253727099, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2799) },
                    { 812198941, 763100588, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2757), 1022866493, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2758) },
                    { 814670692, 763100588, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2782), 1902450443, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2783) },
                    { 326388869, 777390693, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(79), -1565848484, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(80) },
                    { 365854612, 777390693, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(43), -1623247577, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(44) },
                    { 464503470, 777390693, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(55), 1870545420, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(56) },
                    { 797614877, 777390693, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(104), 2094764040, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(105) },
                    { 812198941, 777390693, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(67), -1984519174, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(68) },
                    { 814670692, 777390693, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(91), 138672208, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(93) },
                    { 326388869, 823342121, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(153), -1101906004, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(154) },
                    { 365854612, 823342121, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(116), -1754408204, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(117) },
                    { 464503470, 823342121, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(128), -2143101266, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(129) },
                    { 797614877, 823342121, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(177), 1219694729, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(178) },
                    { 812198941, 823342121, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(140), 1757468741, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(141) },
                    { 814670692, 823342121, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(165), 156391354, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(166) },
                    { 326388869, 840723467, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1281), -980976194, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1282) },
                    { 365854612, 840723467, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1241), -2110960705, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1242) },
                    { 464503470, 840723467, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1253), -419485454, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1254) },
                    { 797614877, 840723467, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1306), 1370489522, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1307) },
                    { 812198941, 840723467, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1268), 1728941360, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1269) },
                    { 814670692, 840723467, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1293), 1174459149, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1294) },
                    { 326388869, 847116662, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(607), 1917539078, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(608) },
                    { 365854612, 847116662, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(567), -1776895681, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(568) },
                    { 464503470, 847116662, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(579), -2057884618, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(580) },
                    { 797614877, 847116662, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(631), 1179372065, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(632) },
                    { 812198941, 847116662, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(594), -2070827054, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(595) },
                    { 814670692, 847116662, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(619), 688932851, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(620) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 326388869, 867245028, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1728), -179149760, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1729) },
                    { 365854612, 867245028, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1691), 533688656, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1693) },
                    { 464503470, 867245028, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1704), -1863754370, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1705) },
                    { 797614877, 867245028, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1753), -1835515300, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1754) },
                    { 812198941, 867245028, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1716), -796151407, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1717) },
                    { 814670692, 867245028, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1740), -672708095, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1742) },
                    { 326388869, 881398163, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(980), -235312307, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(981) },
                    { 365854612, 881398163, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(940), 1242671166, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(941) },
                    { 464503470, 881398163, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(952), -1531960469, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(953) },
                    { 797614877, 881398163, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1004), 1206044411, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(1005) },
                    { 812198941, 881398163, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(964), -1183447777, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(966) },
                    { 814670692, 881398163, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(992), 1696666928, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(993) },
                    { 326388869, 956442179, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3148), 937389065, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3150) },
                    { 365854612, 956442179, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3112), 1395052214, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3113) },
                    { 464503470, 956442179, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3124), 965691842, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3125) },
                    { 797614877, 956442179, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3173), -839916310, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3174) },
                    { 812198941, 956442179, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3136), 1951364151, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3137) },
                    { 814670692, 956442179, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3161), -2097799172, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(3162) },
                    { 326388869, 959346336, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2848), 1196720276, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2849) },
                    { 365854612, 959346336, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2811), -948678790, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2812) },
                    { 464503470, 959346336, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2823), -668015446, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2824) },
                    { 797614877, 959346336, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2873), 1542607448, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2874) },
                    { 812198941, 959346336, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2835), -83267239, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2836) },
                    { 814670692, 959346336, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2860), -245394944, new DateTime(2024, 3, 1, 16, 29, 0, 922, DateTimeKind.Local).AddTicks(2861) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_CorporateUserId",
                table: "DailyHour",
                column: "CorporateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_DailyUserId",
                table: "DailyHour",
                column: "DailyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_PersonalUserId",
                table: "DailyHour",
                column: "PersonalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_TimeSpanId",
                table: "DailyHour",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_TrainingUserId",
                table: "DailyHour",
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
                name: "IX_ManHour_DisciplineId",
                table: "ManHour",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHour_DrawingId",
                table: "ManHour",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHour_OtherId",
                table: "ManHour",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHour_ProjectId",
                table: "ManHour",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHour_UserId",
                table: "ManHour",
                column: "UserId");

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
                name: "FK_DailyHour_Users_CorporateUserId",
                table: "DailyHour",
                column: "CorporateUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyHour_Users_DailyUserId",
                table: "DailyHour",
                column: "DailyUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyHour_Users_PersonalUserId",
                table: "DailyHour",
                column: "PersonalUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyHour_Users_TrainingUserId",
                table: "DailyHour",
                column: "TrainingUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Projects_Users_SubContractorId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "DailyHour");

            migrationBuilder.DropTable(
                name: "DisciplineEngineer");

            migrationBuilder.DropTable(
                name: "DrawingsEmployees");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ManHour");

            migrationBuilder.DropTable(
                name: "OthersEmployees");

            migrationBuilder.DropTable(
                name: "ProjectsPmanagers");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "TimeSpans");

            migrationBuilder.DropTable(
                name: "Drawings");

            migrationBuilder.DropTable(
                name: "Others");

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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectType");
        }
    }
}
