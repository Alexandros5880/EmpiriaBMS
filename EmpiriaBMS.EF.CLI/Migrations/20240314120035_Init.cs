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
                    { 143108007, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7718), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7720), "Photovoltaics" },
                    { 181424378, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7584), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7586), "Drainage" },
                    { 221309065, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7612), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7613), "Fire Suppression" },
                    { 245918897, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7625), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7626), "Elevators" },
                    { 255319380, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7597), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7599), "Fire Detection" },
                    { 264908970, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7680), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7681), "Burglar Alarm" },
                    { 388780929, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7638), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7639), "Natural Gas" },
                    { 396204557, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7785), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7787), "Project Manager Hours" },
                    { 404911201, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7666), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7667), "Structured Cabling" },
                    { 421612240, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7571), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7573), "Potable Water" },
                    { 424755772, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7692), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7694), "CCTV" },
                    { 432429795, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7557), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7559), "Sewage" },
                    { 472037421, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7732), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7733), "Energy Efficiency" },
                    { 502980227, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7534), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7536), "HVAC" },
                    { 556550761, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7744), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7746), "Outsource" },
                    { 619954779, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7758), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7759), "TenderDocument" },
                    { 674133899, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7705), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7707), "BMS" },
                    { 683567299, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7772), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7773), "Construction Supervision" },
                    { 767832548, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7651), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7653), "Power Distribution" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 243639382, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8029), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8030), "Calculations" },
                    { 464706508, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8012), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8013), "Documents" },
                    { 565691020, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8042), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8043), "Drawings" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 152728230, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8615), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8616), "Communications" },
                    { 257181575, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8658), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8659), "Meetings" },
                    { 275556256, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8646), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8647), "On-Site" },
                    { 797386508, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8669), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8671), "Administration" },
                    { 943430569, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8634), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8636), "Printing" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 406483227, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4841), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4843), "Dashboard Add Project", 6 },
                    { 413314940, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4855), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4856), "See Admin Layout", 7 },
                    { 642341293, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4869), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4870), "Dashboard See My Hours", 8 },
                    { 686103878, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4704), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4705), "See Dashboard Layout", 1 },
                    { 728097174, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4897), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4898), "See All Drawings", 10 },
                    { 827171121, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4812), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4813), "Dashboard Assign Engineer", 4 },
                    { 833212899, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4910), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4912), "See All Projects", 11 },
                    { 862736974, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4780), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4782), "Dashboard Edit My Hours", 2 },
                    { 863826190, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4882), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4884), "See All Disciplines", 9 },
                    { 912589782, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4826), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4828), "Dashboard Assign Project Manager", 5 },
                    { 948517278, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4798), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4799), "Dashboard Assign Designer", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 164873649, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7057), "Consulting Description", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7059), "Consulting" },
                    { 331570921, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7070), "Production Management Description", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7071), "Production Management" },
                    { 484793853, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7044), "Energy Description", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7045), "Energy" },
                    { 518921123, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7031), "Infrastructure Description", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7032), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { 825715335, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7014), "Buildings Description", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7016), "Buildings" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 176307350, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4952), false, true, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4953), "Engineer" },
                    { 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5010), false, true, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5011), "CEO" },
                    { 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4979), false, true, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4981), "COO" },
                    { 511764475, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5064), false, false, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5066), "Secretariat" },
                    { 710750329, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4966), false, true, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4967), "Project Manager" },
                    { 714381378, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4926), false, true, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4927), "Designer" },
                    { 765070095, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5037), false, false, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5038), "Customer" },
                    { 845664666, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5024), false, false, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5025), "Guest" },
                    { 848477460, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5050), false, false, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5052), "Admin" },
                    { 968992925, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4993), false, true, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(4994), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6576), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6578), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 129106686, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5882), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5884), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 135165033, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6194), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6195), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6362), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6364), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6280), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6281), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6621), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6623), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6322), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6323), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 218102774, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6239), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6240), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6800), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6801), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6931), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6932), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 336142932, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6006), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6008), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 444225830, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5824), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5825), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 566760639, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6152), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6153), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 604146935, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5965), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5967), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6890), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6891), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 616151601, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5924), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5925), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6710), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6711), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 648527225, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6093), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6094), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6848), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6849), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6665), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6667), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6444), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6445), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6972), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6973), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 870918998, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6050), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6052), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6754), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6756), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6403), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6405), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6516), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6518), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 136923869, "pm@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6064), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6065), 870918998 },
                    { 154246975, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5845), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5847), 444225830 },
                    { 202111323, "vtza@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6592), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6593), 123616211 },
                    { 237329437, "coo@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5979), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5980), 604146935 },
                    { 302248695, "kkotsoni@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6531), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6533), 988727835 },
                    { 306075318, "ceo@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5897), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5898), 129106686 },
                    { 337341960, "kmargeti@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6681), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6683), 744801142 },
                    { 351373538, "embiria@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6109), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6111), 648527225 },
                    { 385689800, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6986), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6988), 787189578 },
                    { 394324953, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6209), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6210), 135165033 },
                    { 408683460, "haris@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6725), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6727), 630519026 },
                    { 434108592, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6253), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6255), 218102774 },
                    { 446536772, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6815), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6816), 282164909 },
                    { 447010900, "gdoug@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6166), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6168), 566760639 },
                    { 470508569, "panperivollari@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6945), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6946), 305890240 },
                    { 519128201, "agretos@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6636), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6638), 212683779 },
                    { 529046377, "blekou@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6862), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6864), 732628725 },
                    { 580052341, "sparisis@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6377), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6378), 150480890 },
                    { 590390419, "cto@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5937), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5939), 616151601 },
                    { 624848852, "ngal@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6459), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6460), 752428647 },
                    { 650132518, "vchontos@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6905), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6906), 611433924 },
                    { 664658945, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6123), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6124), 648527225 },
                    { 732976097, "xmanarolis@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6335), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6337), 213728507 },
                    { 778900258, "guest@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6021), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6023), 336142932 },
                    { 838424293, "pfokianou@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6771), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6772), 941102841 },
                    { 853993823, "vpax@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6295), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6296), 162555599 },
                    { 980615276, "chkovras@embiria.gr", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6417), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6418), 959966333 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 124267142, true, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 9.0, 16, new DateTime(2025, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 16, "Test Description Project_8", new DateTime(2025, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), new DateTime(2025, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Project_4", 5.0, new DateTime(2025, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Payment Detailes For Project_12", 4.0, null, 164873649, new DateTime(2025, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f },
                    { 325787076, false, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 6.0, 1, new DateTime(2024, 4, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 1, "Test Description Project_3", new DateTime(2024, 4, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), new DateTime(2024, 4, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Project_1", 5.0, new DateTime(2024, 4, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Payment Detailes For Project_3", 1.0, null, 825715335, new DateTime(2024, 4, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f },
                    { 748361171, true, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 7.0, 4, new DateTime(2024, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 4, "Test Description Project_4", new DateTime(2024, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), new DateTime(2024, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Project_2", 5.0, new DateTime(2024, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Payment Detailes For Project_2", 2.0, null, 518921123, new DateTime(2024, 7, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f },
                    { 933938789, false, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 8.0, 9, new DateTime(2024, 12, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 9, "Test Description Project_12", new DateTime(2024, 12, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), new DateTime(2024, 12, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Project_3", 5.0, new DateTime(2024, 12, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Payment Detailes For Project_15", 3.0, null, 484793853, new DateTime(2024, 12, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f },
                    { 984384553, true, "ALPHA", 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 111.0, 90, new DateTime(2024, 6, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 1, "Test Description Project_PM", new DateTime(2024, 4, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), new DateTime(2024, 5, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Project_PM", 45.0, new DateTime(2024, 4, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), "Payment Detailes For Project_PM", 2.0, null, 331570921, new DateTime(2024, 5, 14, 14, 0, 35, 92, DateTimeKind.Local).AddTicks(3656), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 642341293, 176307350, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5166), -332508577, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5167) },
                    { 686103878, 176307350, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5124), 1913524974, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5126) },
                    { 728097174, 176307350, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5194), 1732624646, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5195) },
                    { 862736974, 176307350, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5138), 1631210823, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5139) },
                    { 863826190, 176307350, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5180), 768081596, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5181) },
                    { 948517278, 176307350, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5152), 1236083724, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5154) },
                    { 406483227, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5594), 263200334, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5595) },
                    { 413314940, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5607), 1963530176, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5609) },
                    { 686103878, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5526), 284845042, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5527) },
                    { 728097174, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5634), 324904996, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5635) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 827171121, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5568), -656822537, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5569) },
                    { 833212899, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5647), 725202401, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5648) },
                    { 862736974, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5541), 317754046, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5542) },
                    { 863826190, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5620), 1937925401, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5621) },
                    { 912589782, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5581), 1712187176, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5582) },
                    { 948517278, 297973745, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5555), 1784878947, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5556) },
                    { 642341293, 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5361), 803838551, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5362) },
                    { 686103878, 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5292), -432697544, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5293) },
                    { 728097174, 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5388), 1992596279, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5389) },
                    { 827171121, 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5334), 1846050197, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5336) },
                    { 833212899, 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5404), 1691148069, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5405) },
                    { 862736974, 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5305), -1941776270, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5307) },
                    { 863826190, 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5374), -1271428667, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5376) },
                    { 912589782, 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5348), 1504915200, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5349) },
                    { 948517278, 374211987, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5320), 260767522, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5322) },
                    { 642341293, 511764475, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5767), -642303521, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5768) },
                    { 686103878, 511764475, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5740), -708195968, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5742) },
                    { 728097174, 511764475, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5796), -578374303, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5797) },
                    { 833212899, 511764475, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5810), -2032622018, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5811) },
                    { 862736974, 511764475, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5753), -2073518266, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5755) },
                    { 863826190, 511764475, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5780), 175152551, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5781) },
                    { 642341293, 710750329, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5252), 1693148522, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5253) },
                    { 686103878, 710750329, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5212), -2048977462, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5213) },
                    { 728097174, 710750329, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5278), 299457905, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5279) },
                    { 827171121, 710750329, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5238), 557379896, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5240) },
                    { 862736974, 710750329, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5225), -816934657, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5226) },
                    { 863826190, 710750329, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5265), 1289060627, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5266) },
                    { 642341293, 714381378, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5110), 1086949571, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5112) },
                    { 686103878, 714381378, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5078), -2078417443, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5080) },
                    { 862736974, 714381378, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5097), 1377468131, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5098) },
                    { 686103878, 765070095, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5674), 896885897, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5675) },
                    { 686103878, 845664666, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5661), 759930530, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5662) },
                    { 413314940, 848477460, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5687), -2143931219, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5688) },
                    { 728097174, 848477460, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5714), 1540415183, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5715) },
                    { 833212899, 848477460, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5727), -302217389, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5728) },
                    { 863826190, 848477460, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5700), 1905782688, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5702) },
                    { 406483227, 968992925, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5458), -427970825, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5460) },
                    { 642341293, 968992925, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5472), -1492622351, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5473) },
                    { 686103878, 968992925, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5418), 1127691617, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5419) },
                    { 728097174, 968992925, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5498), -690673018, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5500) },
                    { 833212899, 968992925, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5512), 1729226129, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5513) },
                    { 862736974, 968992925, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5431), -406053571, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5432) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 863826190, 968992925, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5485), -2056399361, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5486) },
                    { 912589782, 968992925, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5445), 1831643996, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5446) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 176307350, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6607), 195102781, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6608) },
                    { 297973745, 129106686, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5910), 764465529, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5912) },
                    { 714381378, 135165033, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6224), 359406059, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6225) },
                    { 176307350, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6390), 559908246, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6391) },
                    { 176307350, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6308), 697693850, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6310) },
                    { 710750329, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7086), 267690691, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7087) },
                    { 176307350, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6650), 283112578, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6652) },
                    { 176307350, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6348), 142681879, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6349) },
                    { 714381378, 218102774, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6266), 864406392, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6268) },
                    { 176307350, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6832), 443682177, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6834) },
                    { 176307350, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6958), 593166734, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6959) },
                    { 845664666, 336142932, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6036), 334392773, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6037) },
                    { 848477460, 444225830, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5864), 603212524, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5865) },
                    { 714381378, 566760639, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6180), 809903334, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6182) },
                    { 374211987, 604146935, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5993), 623704063, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5994) },
                    { 176307350, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6917), 774088005, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6919) },
                    { 968992925, 616151601, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5951), 594058860, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(5952) },
                    { 176307350, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6740), 284573095, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6741) },
                    { 710750329, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7116), 290455364, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7118) },
                    { 511764475, 648527225, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6136), 764693306, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6137) },
                    { 176307350, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6876), 385679887, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6877) },
                    { 176307350, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6696), 585982126, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6697) },
                    { 176307350, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6472), 204507750, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6474) },
                    { 297973745, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6502), 264089649, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6503) },
                    { 848477460, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6488), 385410178, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6489) },
                    { 176307350, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7000), 530876343, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7001) },
                    { 710750329, 870918998, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6077), 738298271, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6078) },
                    { 176307350, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6785), 372475437, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6787) },
                    { 176307350, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6430), 727928557, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6431) },
                    { 176307350, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6546), 184473378, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6548) },
                    { 374211987, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6561), 284916520, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(6563) },
                    { 710750329, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7101), 293662531, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7102) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1570072608, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7980), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7982), 124267142, 472037421, null },
                    { -1509802576, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7954), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7955), 124267142, 556550761, null },
                    { -1480681744, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7815), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7816), 325787076, 421612240, null },
                    { -1342501384, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7967), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7969), 124267142, 264908970, null },
                    { -1245890312, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7994), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7995), 984384553, 396204557, null },
                    { -1171579016, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7882), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7884), 748361171, 472037421, null },
                    { -1089923616, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7911), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7912), 933938789, 619954779, null },
                    { -966822808, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7853), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7854), 325787076, 388780929, null },
                    { -268586296, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7897), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7898), 748361171, 221309065, null },
                    { 1319048376, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7868), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7869), 748361171, 619954779, null },
                    { 1416480136, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7938), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7939), 933938789, 255319380, null },
                    { 1423218416, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7836), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7837), 325787076, 432429795, null },
                    { 2130640432, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7925), 0f, 500L, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7926), 933938789, 143108007, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 244572639, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7336), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7339), 3100.0, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7338), "Signature 142344", 23795, 748361171, 2.0, 24.0 },
                    { 421097022, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7416), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7419), 4000.0, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7417), "Signature 142346", 45000, 933938789, 3.0, 17.0 },
                    { 803786499, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7496), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7498), 13000.0, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7497), "Signature 1423420", 36501, 124267142, 4.0, 24.0 },
                    { 890616184, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7249), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7251), 3010.0, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7250), "Signature 142343", 61052, 325787076, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 124267142, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9495), 555821329, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9496) },
                    { 325787076, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9454), 610372780, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9455) },
                    { 933938789, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9482), 381795025, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9483) },
                    { 748361171, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9470), 731003877, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9471) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 169762943, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7452), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7453), null, "6949277784", null, null, 124267142, "alexpl_{i}@gmail.com" },
                    { 192000310, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7295), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7296), null, "6949277782", null, null, 748361171, "alexpl_{i}@gmail.com" },
                    { 318505361, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7194), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7195), null, "6949277781", null, null, 325787076, "alexpl_{i}@gmail.com" },
                    { 395505563, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7374), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7375), null, "6949277783", null, null, 933938789, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1570072608, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1793), 652135005, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1795) },
                    { -1570072608, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1744), 616212292, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1745) },
                    { -1570072608, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1719), 537902449, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1720) },
                    { -1570072608, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1806), 232086328, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1807) },
                    { -1570072608, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1731), 311037354, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1733) },
                    { -1570072608, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1856), 470533695, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1857) },
                    { -1570072608, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1893), 397573494, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1894) },
                    { -1570072608, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1881), 837676577, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1882) },
                    { -1570072608, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1831), 461636760, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1832) },
                    { -1570072608, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1869), 957562837, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1870) },
                    { -1570072608, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1819), 951591228, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1820) },
                    { -1570072608, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1769), 188963349, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1770) },
                    { -1570072608, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1906), 475775189, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1907) },
                    { -1570072608, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1844), 442716562, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1845) },
                    { -1570072608, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1756), 971624372, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1757) },
                    { -1570072608, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1781), 520475659, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1782) },
                    { -1509802576, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1391), 583198921, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1393) },
                    { -1509802576, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1342), 828282635, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1343) },
                    { -1509802576, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1317), 133152009, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1318) },
                    { -1509802576, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1405), 810205475, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1406) },
                    { -1509802576, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1329), 887500402, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1331) },
                    { -1509802576, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1454), 262362826, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1456) },
                    { -1509802576, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1492), 879698861, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1493) },
                    { -1509802576, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1479), 125689210, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1481) },
                    { -1509802576, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1430), 506165436, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1431) },
                    { -1509802576, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1467), 123708704, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1468) },
                    { -1509802576, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1417), 396322076, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1419) },
                    { -1509802576, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1367), 298507595, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1368) },
                    { -1509802576, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1505), 933445059, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1506) },
                    { -1509802576, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1442), 133345410, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1443) },
                    { -1509802576, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1354), 279526522, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1356) },
                    { -1509802576, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1379), 393573488, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1380) },
                    { -1480681744, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9589), 644292701, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9590) },
                    { -1480681744, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9539), 252041938, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9540) },
                    { -1480681744, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9508), 704080699, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9510) },
                    { -1480681744, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9601), 751559206, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9602) },
                    { -1480681744, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9526), 911731162, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9527) },
                    { -1480681744, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9652), 355353694, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9653) },
                    { -1480681744, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9688), 623611207, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9689) },
                    { -1480681744, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9676), 704625641, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9677) },
                    { -1480681744, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9626), 665519585, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9628) },
                    { -1480681744, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9664), 318498545, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9665) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1480681744, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9614), 538798041, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9615) },
                    { -1480681744, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9564), 967738984, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9565) },
                    { -1480681744, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9700), 693104872, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9701) },
                    { -1480681744, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9639), 171404762, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9640) },
                    { -1480681744, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9551), 882777463, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9553) },
                    { -1480681744, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9577), 779340618, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9578) },
                    { -1342501384, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1595), 294846930, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1597) },
                    { -1342501384, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1546), 711028983, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1547) },
                    { -1342501384, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1517), 910042440, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1518) },
                    { -1342501384, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1608), 686315739, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1609) },
                    { -1342501384, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1533), 589730188, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1535) },
                    { -1342501384, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1657), 965400549, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1658) },
                    { -1342501384, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1694), 796420903, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1695) },
                    { -1342501384, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1682), 242503821, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1683) },
                    { -1342501384, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1632), 834608752, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1633) },
                    { -1342501384, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1669), 780031640, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1671) },
                    { -1342501384, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1620), 848581917, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1621) },
                    { -1342501384, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1571), 308092674, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1572) },
                    { -1342501384, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1706), 448682261, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1707) },
                    { -1342501384, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1644), 806900243, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1646) },
                    { -1342501384, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1558), 758943807, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1560) },
                    { -1342501384, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1583), 398842284, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1584) },
                    { -1171579016, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(380), 683414463, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(381) },
                    { -1171579016, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(331), 625334539, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(333) },
                    { -1171579016, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(305), 933432312, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(306) },
                    { -1171579016, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(392), 909198016, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(393) },
                    { -1171579016, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(319), 867583281, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(320) },
                    { -1171579016, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(440), 541185091, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(441) },
                    { -1171579016, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(480), 767626658, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(482) },
                    { -1171579016, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(468), 412170850, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(469) },
                    { -1171579016, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(416), 266843172, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(417) },
                    { -1171579016, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(455), 944290429, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(456) },
                    { -1171579016, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(404), 283892694, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(405) },
                    { -1171579016, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(356), 634542522, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(357) },
                    { -1171579016, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(493), 467202489, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(494) },
                    { -1171579016, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(428), 534299943, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(429) },
                    { -1171579016, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(343), 871640807, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(345) },
                    { -1171579016, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(367), 928647828, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(369) },
                    { -1089923616, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(775), 912287415, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(776) },
                    { -1089923616, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(726), 919799801, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(727) },
                    { -1089923616, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(701), 797752726, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(702) },
                    { -1089923616, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(787), 978767144, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(788) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1089923616, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(714), 439156709, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(715) },
                    { -1089923616, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(839), 868011658, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(840) },
                    { -1089923616, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(889), 939561543, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(890) },
                    { -1089923616, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(877), 786696826, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(878) },
                    { -1089923616, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(811), 164338533, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(812) },
                    { -1089923616, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(851), 434795193, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(852) },
                    { -1089923616, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(799), 983050806, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(800) },
                    { -1089923616, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(750), 167062745, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(751) },
                    { -1089923616, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(901), 614395147, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(902) },
                    { -1089923616, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(823), 181447407, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(824) },
                    { -1089923616, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(738), 592016734, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(739) },
                    { -1089923616, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(763), 160370882, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(764) },
                    { -966822808, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9986), 241608614, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9987) },
                    { -966822808, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9938), 737827632, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9939) },
                    { -966822808, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9913), 822620736, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9914) },
                    { -966822808, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9998), 577641017, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9999) },
                    { -966822808, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9926), 540303608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9927) },
                    { -966822808, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(46), 621167686, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(48) },
                    { -966822808, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(83), 230725373, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(85) },
                    { -966822808, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(71), 512250495, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(72) },
                    { -966822808, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(22), 257344040, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(23) },
                    { -966822808, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(59), 508365900, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(60) },
                    { -966822808, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(10), 560426700, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(11) },
                    { -966822808, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9962), 265777428, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9963) },
                    { -966822808, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(95), 928483865, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(97) },
                    { -966822808, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(34), 522261841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(36) },
                    { -966822808, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9950), 538440549, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9951) },
                    { -966822808, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9974), 360929608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9975) },
                    { -268586296, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(579), 753547203, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(580) },
                    { -268586296, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(530), 882018848, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(531) },
                    { -268586296, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(506), 255357903, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(507) },
                    { -268586296, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(591), 353061189, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(592) },
                    { -268586296, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(518), 271004083, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(519) },
                    { -268586296, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(640), 428937557, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(641) },
                    { -268586296, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(676), 413010834, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(677) },
                    { -268586296, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(664), 610058956, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(665) },
                    { -268586296, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(615), 537837431, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(616) },
                    { -268586296, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(652), 760433845, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(653) },
                    { -268586296, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(603), 501413679, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(604) },
                    { -268586296, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(555), 371848120, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(556) },
                    { -268586296, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(688), 266722274, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(690) },
                    { -268586296, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(627), 955679950, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(629) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -268586296, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(542), 971874359, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(544) },
                    { -268586296, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(566), 899022862, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(568) },
                    { 1319048376, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(184), 133113878, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(185) },
                    { 1319048376, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(135), 503957623, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(137) },
                    { 1319048376, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(108), 696047016, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(109) },
                    { 1319048376, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(196), 721202290, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(197) },
                    { 1319048376, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(123), 525363137, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(125) },
                    { 1319048376, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(244), 659628424, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(245) },
                    { 1319048376, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(281), 223810576, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(282) },
                    { 1319048376, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(269), 591380037, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(270) },
                    { 1319048376, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(220), 704856669, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(221) },
                    { 1319048376, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(256), 754513806, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(257) },
                    { 1319048376, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(207), 702442638, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(209) },
                    { 1319048376, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(159), 969926448, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(161) },
                    { 1319048376, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(293), 133691169, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(294) },
                    { 1319048376, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(232), 924355114, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(233) },
                    { 1319048376, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(147), 228380933, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(149) },
                    { 1319048376, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(172), 998213901, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(173) },
                    { 1416480136, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1192), 571018100, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1194) },
                    { 1416480136, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1143), 684145773, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1144) },
                    { 1416480136, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1113), 766838130, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1114) },
                    { 1416480136, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1205), 473408097, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1206) },
                    { 1416480136, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1127), 297587923, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1128) },
                    { 1416480136, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1254), 570346207, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1255) },
                    { 1416480136, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1292), 668148475, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1293) },
                    { 1416480136, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1279), 499448433, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1280) },
                    { 1416480136, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1229), 632908218, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1230) },
                    { 1416480136, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1267), 942036616, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1268) },
                    { 1416480136, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1217), 235953445, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1218) },
                    { 1416480136, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1167), 503770770, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1169) },
                    { 1416480136, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1304), 425610738, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1305) },
                    { 1416480136, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1242), 502064450, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1243) },
                    { 1416480136, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1155), 620397735, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1156) },
                    { 1416480136, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1180), 856757708, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1181) },
                    { 1423218416, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9791), 639678800, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9792) },
                    { 1423218416, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9739), 564020807, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9740) },
                    { 1423218416, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9713), 132555449, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9714) },
                    { 1423218416, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9803), 843576368, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9804) },
                    { 1423218416, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9726), 270331475, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9727) },
                    { 1423218416, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9852), 883030403, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9853) },
                    { 1423218416, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9888), 743839258, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9889) },
                    { 1423218416, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9876), 980855647, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9877) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1423218416, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9827), 540824526, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9829) },
                    { 1423218416, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9864), 475179275, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9865) },
                    { 1423218416, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9815), 695787545, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9816) },
                    { 1423218416, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9766), 139408643, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9767) },
                    { 1423218416, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9900), 761865337, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9901) },
                    { 1423218416, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9840), 461755569, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9841) },
                    { 1423218416, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9751), 249326893, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9752) },
                    { 1423218416, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9779), 233430151, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9780) },
                    { 2130640432, 123616211, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(988), 851204522, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(989) },
                    { 2130640432, 150480890, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(939), 739960770, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(940) },
                    { 2130640432, 162555599, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(914), 533664819, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(915) },
                    { 2130640432, 212683779, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1001), 485717032, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1002) },
                    { 2130640432, 213728507, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(927), 685276831, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(928) },
                    { 2130640432, 282164909, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1051), 703592532, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1052) },
                    { 2130640432, 305890240, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1088), 141558647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1089) },
                    { 2130640432, 611433924, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1076), 964209156, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1077) },
                    { 2130640432, 630519026, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1026), 713407907, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1027) },
                    { 2130640432, 732628725, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1063), 737915745, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1064) },
                    { 2130640432, 744801142, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1013), 458598497, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1015) },
                    { 2130640432, 752428647, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(963), 550091314, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(965) },
                    { 2130640432, 787189578, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1100), 435332343, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1101) },
                    { 2130640432, 941102841, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1038), 339882859, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(1039) },
                    { 2130640432, 959966333, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(951), 531524032, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(952) },
                    { 2130640432, 988727835, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(976), 729114750, new DateTime(2024, 3, 14, 14, 0, 35, 102, DateTimeKind.Local).AddTicks(977) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 127766641, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8165), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8162), -966822808, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8163), 243639382 },
                    { 153842286, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8255), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8252), -1171579016, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8253), 243639382 },
                    { 161204748, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8240), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8237), -1171579016, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8239), 464706508 },
                    { 181253875, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8269), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8266), -1171579016, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8267), 565691020 },
                    { 202923025, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8534), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8531), -1570072608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8533), 464706508 },
                    { 209223163, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8601), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8599), -1245890312, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8600), 565691020 },
                    { 213254056, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8197), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8194), 1319048376, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8196), 464706508 },
                    { 222492547, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8106), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8103), 1423218416, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8105), 464706508 },
                    { 227906007, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8150), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8147), -966822808, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8149), 464706508 },
                    { 237381040, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8179), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8176), -966822808, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8177), 565691020 },
                    { 246555223, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8061), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8057), -1480681744, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8059), 464706508 },
                    { 327117428, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8136), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8133), 1423218416, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8134), 565691020 },
                    { 342775002, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8384), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8381), 2130640432, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8383), 243639382 },
                    { 389967730, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8370), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8367), 2130640432, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8368), 464706508 },
                    { 402269102, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8451), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8448), -1509802576, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8449), 464706508 },
                    { 421245770, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8438), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8436), 1416480136, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8437), 565691020 },
                    { 442171286, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8356), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8353), -1089923616, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8354), 565691020 },
                    { 485968312, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8560), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8558), -1570072608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8559), 565691020 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 494862011, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8464), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8461), -1509802576, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8462), 243639382 },
                    { 578415072, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8312), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8310), -268586296, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8311), 565691020 },
                    { 607516684, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8398), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8396), 2130640432, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8397), 565691020 },
                    { 616016602, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8490), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8487), -1342501384, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8488), 464706508 },
                    { 616378072, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8412), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8410), 1416480136, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8411), 464706508 },
                    { 622802947, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8425), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8423), 1416480136, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8424), 243639382 },
                    { 624257405, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8502), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8500), -1342501384, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8501), 243639382 },
                    { 635323731, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8515), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8513), -1342501384, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8514), 565691020 },
                    { 640725896, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8211), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8209), 1319048376, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8210), 243639382 },
                    { 734172197, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8547), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8544), -1570072608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8546), 243639382 },
                    { 741958443, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8226), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8223), 1319048376, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8224), 565691020 },
                    { 853251762, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8575), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8572), -1245890312, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8573), 464706508 },
                    { 865564953, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8588), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8586), -1245890312, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8587), 243639382 },
                    { 867251477, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8283), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8280), -268586296, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8281), 464706508 },
                    { 895334393, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8297), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8294), -268586296, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8296), 243639382 },
                    { 913628709, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8092), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8089), -1480681744, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8091), 565691020 },
                    { 968286684, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8341), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8338), -1089923616, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8339), 243639382 },
                    { 990031948, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8078), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8075), -1480681744, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8076), 243639382 },
                    { 990722499, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8327), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8324), -1089923616, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8326), 464706508 },
                    { 991622998, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8476), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8474), -1509802576, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8475), 565691020 },
                    { 992100764, new DateTime(2024, 3, 25, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8120), 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8118), 1423218416, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8119), 243639382 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 286073242, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7389), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7391), 395505563 },
                    { 366953016, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7467), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7468), 169762943 },
                    { 611412626, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7217), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7219), 318505361 },
                    { 757153748, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7310), new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7311), 192000310 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124198414, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8793), 1423218416, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8794), 797386508 },
                    { 126124723, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9308), -1342501384, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9309), 257181575 },
                    { 134204505, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8722), -1480681744, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8723), 257181575 },
                    { 136123868, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9376), -1570072608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9377), 797386508 },
                    { 136510344, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9240), -1509802576, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9241), 275556256 },
                    { 162286683, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9097), 2130640432, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9098), 152728230 },
                    { 165020063, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9353), -1570072608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9354), 275556256 },
                    { 179506050, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9319), -1342501384, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9320), 797386508 },
                    { 181195291, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9435), -1245890312, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9437), 797386508 },
                    { 198386000, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9039), -1089923616, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9040), 152728230 },
                    { 201841448, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9251), -1509802576, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9252), 257181575 },
                    { 205630803, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8780), 1423218416, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8781), 257181575 },
                    { 209261316, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9330), -1570072608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9332), 152728230 },
                    { 245628642, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8937), -1171579016, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8938), 943430569 },
                    { 257657236, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9051), -1089923616, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9052), 943430569 },
                    { 275251189, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8698), -1480681744, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8700), 943430569 },
                    { 291753477, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9342), -1570072608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9343), 943430569 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 298562838, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9016), -268586296, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9018), 257181575 },
                    { 331741292, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8913), 1319048376, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8914), 797386508 },
                    { 338441028, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9217), -1509802576, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9218), 152728230 },
                    { 340724951, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9262), -1509802576, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9263), 797386508 },
                    { 357592628, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9274), -1342501384, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9275), 152728230 },
                    { 366851517, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9388), -1245890312, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9390), 152728230 },
                    { 372482396, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9182), 1416480136, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9184), 275556256 },
                    { 378845058, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8746), 1423218416, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8747), 152728230 },
                    { 378856588, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8959), -1171579016, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8960), 257181575 },
                    { 394914050, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8733), -1480681744, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8734), 797386508 },
                    { 412689230, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9424), -1245890312, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9425), 257181575 },
                    { 438013884, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9074), -1089923616, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9076), 257181575 },
                    { 483014953, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8902), 1319048376, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8903), 257181575 },
                    { 483269691, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8867), 1319048376, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8868), 152728230 },
                    { 514796900, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9229), -1509802576, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9230), 943430569 },
                    { 518099487, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8805), -966822808, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8806), 152728230 },
                    { 528902884, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8891), 1319048376, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8892), 275556256 },
                    { 539693489, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9194), 1416480136, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9195), 257181575 },
                    { 546729827, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9171), 1416480136, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9172), 943430569 },
                    { 554494381, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8948), -1171579016, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8949), 275556256 },
                    { 579899764, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8925), -1171579016, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8927), 152728230 },
                    { 586391023, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9365), -1570072608, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9366), 257181575 },
                    { 602771990, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8994), -268586296, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8995), 943430569 },
                    { 642406324, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9028), -268586296, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9029), 797386508 },
                    { 652581559, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9147), 2130640432, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9148), 797386508 },
                    { 655923031, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9160), 1416480136, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9161), 152728230 },
                    { 658644559, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8982), -268586296, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8983), 152728230 },
                    { 692816837, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9206), 1416480136, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9207), 797386508 },
                    { 720768631, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8710), -1480681744, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8711), 275556256 },
                    { 727605358, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8822), -966822808, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8823), 943430569 },
                    { 732783123, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9062), -1089923616, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9063), 275556256 },
                    { 735430100, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9401), -1245890312, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9403), 943430569 },
                    { 755957074, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8879), 1319048376, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8880), 943430569 },
                    { 760643808, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9086), -1089923616, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9087), 797386508 },
                    { 783678286, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9124), 2130640432, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9125), 275556256 },
                    { 787373618, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8833), -966822808, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8834), 275556256 },
                    { 802392057, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8970), -1171579016, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8972), 797386508 },
                    { 819149400, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9285), -1342501384, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9286), 943430569 },
                    { 827197850, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9005), -268586296, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9006), 275556256 },
                    { 848948566, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9136), 2130640432, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9137), 257181575 },
                    { 858179128, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8844), -966822808, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8845), 257181575 },
                    { 883380293, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8684), -1480681744, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8685), 152728230 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 897807323, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8856), -966822808, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8857), 797386508 },
                    { 922614924, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8769), 1423218416, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8770), 275556256 },
                    { 932481866, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9413), -1245890312, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9414), 275556256 },
                    { 932932460, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9296), -1342501384, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9298), 275556256 },
                    { 973340010, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8758), 1423218416, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(8759), 943430569 },
                    { 989855464, 0f, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9109), 2130640432, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(9110), 943430569 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 765070095, 169762943, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7480), 870878732, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7481) },
                    { 765070095, 192000310, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7323), 181647044, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7324) },
                    { 765070095, 318505361, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7232), 235897483, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7234) },
                    { 765070095, 395505563, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7403), 445706748, new DateTime(2024, 3, 14, 14, 0, 35, 101, DateTimeKind.Local).AddTicks(7404) }
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
