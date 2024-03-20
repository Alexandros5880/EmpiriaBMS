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
                name: "Complains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Evaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerificatorSignature = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PMSignature = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsClose = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complains", x => x.Id);
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
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DelayInPayment = table.Column<int>(type: "int", nullable: true),
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayCost = table.Column<double>(type: "float", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysUntilPayment = table.Column<int>(type: "int", nullable: true),
                    PendingPayments = table.Column<double>(type: "float", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
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
                    Fee = table.Column<double>(type: "float", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DurationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedCompleted = table.Column<float>(type: "real", nullable: false),
                    Completed = table.Column<float>(type: "real", nullable: false),
                    WorkPackegedCompleted = table.Column<float>(type: "real", nullable: false),
                    CalculationDaly = table.Column<int>(type: "int", nullable: true),
                    SubContractorId = table.Column<int>(type: "int", nullable: true),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyTime_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyTime_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyTime_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { 123553168, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2532), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2533), "Sewage" },
                    { 247478833, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2728), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2730), "TenderDocument" },
                    { 346514349, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2652), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2653), "Burglar Alarm" },
                    { 497391960, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2743), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2744), "Construction Supervision" },
                    { 526675284, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2702), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2703), "Energy Efficiency" },
                    { 581497039, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2677), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2678), "BMS" },
                    { 641071336, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2512), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2514), "HVAC" },
                    { 680760688, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2664), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2665), "CCTV" },
                    { 683984538, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2625), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2626), "Power Distribution" },
                    { 704355038, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2761), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2763), "Project Manager Hours" },
                    { 712555487, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2559), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2560), "Drainage" },
                    { 739948020, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2587), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2588), "Fire Suppression" },
                    { 758220485, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2690), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2691), "Photovoltaics" },
                    { 770836366, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2715), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2716), "Outsource" },
                    { 776513730, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2600), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2601), "Elevators" },
                    { 779793382, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2612), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2613), "Natural Gas" },
                    { 818651180, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2639), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2640), "Structured Cabling" },
                    { 894055765, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2547), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2548), "Potable Water" },
                    { 999998878, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2572), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2573), "Fire Detection" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 357227491, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3142), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3145), "Documents" },
                    { 523161516, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3233), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3234), "Drawings" },
                    { 579809847, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3197), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3198), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 252614198, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3832), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3833), "Communications" },
                    { 488232122, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3854), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3855), "Printing" },
                    { 579731716, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3867), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3868), "On-Site" },
                    { 720449991, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3893), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3895), "Administration" },
                    { 851117311, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3880), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3881), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 148117801, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9372), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9373), "See All Disciplines", 9 },
                    { 202969585, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9500), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9502), "See All Drawings", 10 },
                    { 341370185, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9223), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9225), "Dashboard Assign Designer", 3 },
                    { 421933393, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9322), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9324), "See Admin Layout", 7 },
                    { 533256367, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9515), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9516), "See All Projects", 11 },
                    { 536615223, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9544), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9545), "Display Projects Code", 13 },
                    { 642985939, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9337), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9339), "Dashboard See My Hours", 8 },
                    { 690328064, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9194), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9196), "Dashboard Edit My Hours", 2 },
                    { 691011618, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9249), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9251), "Dashboard Assign Engineer", 4 },
                    { 802379544, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9041), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9042), "See Dashboard Layout", 1 },
                    { 829576094, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9275), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9277), "Dashboard Assign Project Manager", 5 },
                    { 873753376, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9302), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9304), "Dashboard Add Project", 6 },
                    { 890984151, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9529), new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9531), "Add Project On Dashboard", 12 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 542391564, true, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2029), "Consulting Description", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2030), "Consulting" },
                    { 683589331, false, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2043), "Production Management Description", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2044), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 726355678, true, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2001), "Infrastructure Description", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2002), "Infrastructure" },
                    { 917674200, true, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1976), "Buildings Description", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1978), "Buildings" },
                    { 941652715, true, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2015), "Energy Description", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2016), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9655), false, true, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9656), "CEO" },
                    { 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9640), false, true, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9641), "CTO" },
                    { 300158293, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9669), false, false, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9670), "Guest" },
                    { 330318698, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9561), false, true, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9562), "Designer" },
                    { 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9624), false, true, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9625), "COO" },
                    { 442886971, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9603), false, true, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9604), "Project Manager" },
                    { 476305015, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9588), false, true, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9589), "Engineer" },
                    { 697952532, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9711), false, false, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9712), "Secretariat" },
                    { 800363378, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9683), false, false, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9684), "Customer" },
                    { 821821007, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9696), false, false, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9698), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1620), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1621), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 201045309, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1010), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1011), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 232070587, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(855), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(857), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 290520266, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(629), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(630), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1889), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1890), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1576), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1577), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1053), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1054), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1757), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1758), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1663), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1664), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 411132391, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(762), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(763), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 437752750, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(921), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(922), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 470116593, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(808), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(809), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1096), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1097), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1800), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1802), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 601197940, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(718), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(719), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1532), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1534), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1845), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1846), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 659621516, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(674), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(675), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1181), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1182), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 705079033, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(964), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(966), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1707), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1708), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1340), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1341), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 843518595, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(555), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(556), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1139), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1140), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1932), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1933), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1266), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1267), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 127369750, "embiria@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(879), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(880), 232070587 },
                    { 145396380, "pm@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(823), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(824), 470116593 },
                    { 147007024, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(579), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(581), 843518595 },
                    { 266483421, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1947), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1948), 909865036 },
                    { 274479209, "vpax@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1067), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1069), 318450609 },
                    { 278079886, "kmargeti@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1635), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1636), 148110739 },
                    { 297747942, "haris@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1678), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1679), 351272280 },
                    { 309652265, "kkotsoni@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1355), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1356), 730910299 },
                    { 341975019, "ceo@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(644), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(646), 290520266 },
                    { 364290685, "ngal@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1281), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1282), 987798915 },
                    { 374582140, "vchontos@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1861), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1862), 643814359 },
                    { 375793129, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1771), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1773), 322479427 },
                    { 393833446, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(893), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(894), 232070587 },
                    { 415113567, "agretos@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1591), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1593), 309238727 },
                    { 431873025, "panperivollari@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1903), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1905), 291912260 },
                    { 507643676, "cto@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(689), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(690), 659621516 },
                    { 609484776, "chkovras@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1195), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1196), 701756541 },
                    { 663787352, "dtsa@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1024), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1026), 201045309 },
                    { 709320147, "vtza@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1548), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1549), 607386667 },
                    { 739265356, "pfokianou@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1721), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1722), 722643664 },
                    { 799473819, "guest@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(777), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(779), 411132391 },
                    { 855548784, "gdoug@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(935), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(937), 437752750 },
                    { 879986926, "dtsa@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(979), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(981), 705079033 },
                    { 967230438, "blekou@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1815), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1816), 509076046 },
                    { 967316282, "sparisis@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1153), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1154), 846662400 },
                    { 977620351, "coo@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(733), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(734), 601197940 },
                    { 987647530, "xmanarolis@embiria.gr", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1111), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1112), 498570860 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 145127827, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), new DateTime(2024, 7, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Test Description Project_4", new DateTime(2024, 7, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 0f, new DateTime(2024, 7, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Project_2", 730910299, null, 726355678, 0f },
                    { 355244768, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), new DateTime(2024, 4, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Test Description Project_5", new DateTime(2024, 4, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 0f, new DateTime(2024, 4, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Project_1", 730910299, null, 917674200, 0f },
                    { 528134776, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), new DateTime(2024, 6, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Test Description Project_PM", new DateTime(2024, 4, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 0f, new DateTime(2024, 5, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 1500L, 12L, null, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Project_PM", null, null, 683589331, 0f },
                    { 643540668, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), new DateTime(2025, 7, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Test Description Project_16", new DateTime(2025, 7, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 0f, new DateTime(2025, 7, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Project_4", 730910299, null, 542391564, 0f },
                    { 815561613, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), new DateTime(2024, 12, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Test Description Project_9", new DateTime(2024, 12, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 0f, new DateTime(2024, 12, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 16, 33, 36, 581, DateTimeKind.Local).AddTicks(3886), "Project_3", 730910299, null, 941652715, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 148117801, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(320), -963195524, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(321) },
                    { 202969585, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(335), -463746748, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(336) },
                    { 341370185, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(263), 243360734, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(264) },
                    { 533256367, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(350), 450914063, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(351) },
                    { 536615223, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(364), -1129059139, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(365) },
                    { 690328064, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(249), 330283733, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(250) },
                    { 691011618, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(277), -669353584, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(278) },
                    { 802379544, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(234), -1454559691, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(236) },
                    { 829576094, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(292), -335819717, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(293) },
                    { 873753376, 214594233, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(306), 1290356856, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(307) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 148117801, 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(174), 1912297847, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(175) },
                    { 202969585, 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(189), -493756042, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(190) },
                    { 533256367, 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(203), -1550024549, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(205) },
                    { 642985939, 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(160), 358629422, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(161) },
                    { 690328064, 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(116), 178495804, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(118) },
                    { 802379544, 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(101), 1013021447, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(102) },
                    { 829576094, 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(130), 807511262, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(132) },
                    { 873753376, 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(145), 1760413271, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(146) },
                    { 890984151, 297329010, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(217), 1055884775, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(219) },
                    { 802379544, 300158293, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(378), 1327084866, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(379) },
                    { 642985939, 330318698, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9773), -571302913, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9775) },
                    { 690328064, 330318698, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9758), -1205284850, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9759) },
                    { 802379544, 330318698, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9727), -1479434458, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9730) },
                    { 148117801, 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(57), 312241784, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(59) },
                    { 202969585, 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(72), -2017712915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(74) },
                    { 341370185, 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9995), 32289544, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9997) },
                    { 533256367, 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(87), -912743891, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(89) },
                    { 642985939, 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(40), -750616879, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(41) },
                    { 690328064, 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9979), -1682937922, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9981) },
                    { 691011618, 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(10), 97853747, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(11) },
                    { 802379544, 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9964), -920362724, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9966) },
                    { 829576094, 364624582, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(25), -792289399, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(26) },
                    { 148117801, 442886971, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9936), -1271308022, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9937) },
                    { 202969585, 442886971, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9950), 61372900, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9951) },
                    { 642985939, 442886971, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9920), -652805873, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9922) },
                    { 690328064, 442886971, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9891), -1548834151, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9892) },
                    { 691011618, 442886971, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9905), 2051951742, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9906) },
                    { 802379544, 442886971, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9876), -302057563, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9878) },
                    { 148117801, 476305015, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9847), -912697730, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9848) },
                    { 202969585, 476305015, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9861), -630078839, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9863) },
                    { 341370185, 476305015, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9818), -724561604, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9819) },
                    { 642985939, 476305015, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9833), 1434246723, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9834) },
                    { 690328064, 476305015, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9802), -300415220, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9803) },
                    { 802379544, 476305015, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9787), -1286823302, new DateTime(2024, 3, 20, 16, 33, 36, 597, DateTimeKind.Local).AddTicks(9789) },
                    { 148117801, 697952532, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(511), 1817976605, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(512) },
                    { 202969585, 697952532, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(525), 218274647, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(526) },
                    { 533256367, 697952532, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(539), -2048329633, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(541) },
                    { 642985939, 697952532, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(497), -1344763160, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(498) },
                    { 690328064, 697952532, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(482), 266454424, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(484) },
                    { 802379544, 697952532, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(465), -1551881569, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(466) },
                    { 802379544, 800363378, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(392), 522896657, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(394) },
                    { 148117801, 821821007, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(422), 149637970, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(423) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 202969585, 821821007, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(436), -1773525833, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(437) },
                    { 421933393, 821821007, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(407), 765121991, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(409) },
                    { 533256367, 821821007, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(451), -1439829301, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(452) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 476305015, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1649), 757340957, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1650) },
                    { 330318698, 201045309, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1038), 292498273, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1039) },
                    { 697952532, 232070587, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(907), 513123186, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(908) },
                    { 214594233, 290520266, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(660), 891993480, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(662) },
                    { 476305015, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1918), 502731996, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1919) },
                    { 476305015, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1606), 196161863, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1607) },
                    { 442886971, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2059), 122669306, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2060) },
                    { 476305015, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1081), 365445499, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1083) },
                    { 476305015, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1786), 444924608, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1787) },
                    { 442886971, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2089), 269839387, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2090) },
                    { 476305015, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1693), 736444350, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1694) },
                    { 300158293, 411132391, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(792), 533568280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(794) },
                    { 330318698, 437752750, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(951), 609666391, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(952) },
                    { 442886971, 470116593, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(837), 448141198, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(838) },
                    { 476305015, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1124), 539514444, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1126) },
                    { 476305015, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1829), 455958840, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1830) },
                    { 364624582, 601197940, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(747), 254823122, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(749) },
                    { 476305015, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1562), 968268419, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1563) },
                    { 476305015, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1875), 657005453, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1876) },
                    { 297329010, 659621516, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(703), 567671545, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(704) },
                    { 476305015, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1209), 949901361, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1210) },
                    { 330318698, 705079033, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(993), 879289414, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(994) },
                    { 476305015, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1736), 135125356, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1737) },
                    { 364624582, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1517), 962388510, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1519) },
                    { 442886971, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2075), 294327474, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2076) },
                    { 476305015, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1503), 292554813, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1504) },
                    { 821821007, 843518595, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(606), 503857577, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(607) },
                    { 476305015, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1167), 126657892, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1168) },
                    { 476305015, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1961), 391188082, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1962) },
                    { 214594233, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1324), 635804741, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1326) },
                    { 476305015, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1295), 193618022, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1297) },
                    { 821821007, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1311), 860629559, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(1312) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2029511320, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2989), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2990), 815561613, 581497039, null },
                    { -1731586464, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2899), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2901), 145127827, 712555487, null },
                    { -1442824568, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3067), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3069), 643540668, 770836366, null },
                    { -575383224, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2961), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2962), 815561613, 526675284, null },
                    { -297795176, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2976), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2977), 815561613, 680760688, null },
                    { 154966944, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3014), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3016), 643540668, 758220485, null },
                    { 329301048, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3090), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3092), 643540668, 581497039, null },
                    { 964146008, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2923), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2925), 145127827, 247478833, null },
                    { 1067492296, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2844), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2845), 355244768, 758220485, null },
                    { 1211404568, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2946), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2947), 145127827, 770836366, null },
                    { 1313124864, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2810), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2812), 355244768, 776513730, null },
                    { 1773735400, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2872), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2873), 355244768, 770836366, null },
                    { 1857661776, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3114), 0f, 500L, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3116), 528134776, 704355038, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 231026773, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2236), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2238), 3010.0, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2237), "Signature 142342", 18808, 355244768, 1.0, 17.0 },
                    { 233466214, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2321), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2323), 3100.0, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2322), "Signature 142344", 79213, 145127827, 2.0, 24.0 },
                    { 367309433, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2475), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2477), 13000.0, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2476), "Signature 142348", 82023, 643540668, 4.0, 24.0 },
                    { 581671192, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2397), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2399), 4000.0, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2398), "Signature 142343", 58653, 815561613, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 560511955, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2280), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2281), null, "6949277782", null, null, 145127827, "alexpl_{i}@gmail.com" },
                    { 644500211, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2431), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2432), null, "6949277784", null, null, 643540668, "alexpl_{i}@gmail.com" },
                    { 869218868, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2187), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2188), null, "6949277781", null, null, 355244768, "alexpl_{i}@gmail.com" },
                    { 995604772, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2357), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2358), null, "6949277783", null, null, 815561613, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2029511320, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6800), 469514005, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6801) },
                    { -2029511320, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6878), 412330982, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6879) },
                    { -2029511320, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6786), 555196912, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6787) },
                    { -2029511320, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6690), 874923479, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6691) },
                    { -2029511320, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6838), 484747670, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6839) },
                    { -2029511320, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6812), 338933985, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6814) },
                    { -2029511320, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6704), 236898546, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6705) },
                    { -2029511320, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6851), 181028586, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6852) },
                    { -2029511320, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6772), 811559449, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6774) },
                    { -2029511320, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6865), 637342747, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6866) },
                    { -2029511320, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6730), 472046705, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6731) },
                    { -2029511320, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6825), 698877591, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6827) },
                    { -2029511320, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6756), 761933684, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6757) },
                    { -2029511320, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6717), 949195127, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6718) },
                    { -2029511320, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6891), 548163227, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6892) },
                    { -2029511320, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6743), 432108896, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6744) },
                    { -1731586464, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5745), 716840638, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5746) },
                    { -1731586464, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5823), 424238044, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5824) },
                    { -1731586464, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5732), 973441938, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5733) },
                    { -1731586464, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5624), 303780275, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5625) },
                    { -1731586464, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5785), 495802709, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5786) },
                    { -1731586464, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5758), 613078269, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5759) },
                    { -1731586464, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5637), 236630637, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5638) },
                    { -1731586464, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5797), 238895767, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5799) },
                    { -1731586464, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5719), 329760439, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5720) },
                    { -1731586464, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5810), 538989744, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5811) },
                    { -1731586464, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5663), 421150829, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5665) },
                    { -1731586464, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5771), 427698779, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5772) },
                    { -1731586464, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5706), 907457478, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5707) },
                    { -1731586464, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5650), 356103726, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5651) },
                    { -1731586464, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5837), 367416967, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5838) },
                    { -1731586464, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5676), 265502832, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5678) },
                    { -1442824568, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7218), 553813612, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7219) },
                    { -1442824568, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7296), 703107106, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7297) },
                    { -1442824568, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7205), 685130105, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7206) },
                    { -1442824568, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7110), 886601285, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7112) },
                    { -1442824568, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7257), 551577766, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7258) },
                    { -1442824568, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7231), 695107884, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7232) },
                    { -1442824568, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7124), 472633058, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7125) },
                    { -1442824568, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7270), 131327663, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7271) },
                    { -1442824568, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7192), 661424156, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7193) },
                    { -1442824568, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7283), 650241797, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7284) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1442824568, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7149), 495953005, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7150) },
                    { -1442824568, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7244), 468114930, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7245) },
                    { -1442824568, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7179), 626341415, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7180) },
                    { -1442824568, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7136), 994569352, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7137) },
                    { -1442824568, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7309), 624560537, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7310) },
                    { -1442824568, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7163), 908926960, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7164) },
                    { -575383224, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6375), 274954714, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6377) },
                    { -575383224, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6453), 981337337, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6455) },
                    { -575383224, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6362), 366514828, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6364) },
                    { -575383224, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6272), 709304504, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6273) },
                    { -575383224, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6414), 930122416, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6415) },
                    { -575383224, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6388), 977959114, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6389) },
                    { -575383224, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6284), 420901049, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6286) },
                    { -575383224, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6427), 406346810, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6428) },
                    { -575383224, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6349), 386296353, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6350) },
                    { -575383224, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6440), 444391582, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6442) },
                    { -575383224, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6310), 882407873, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6311) },
                    { -575383224, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6401), 364627264, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6402) },
                    { -575383224, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6336), 123843070, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6338) },
                    { -575383224, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6297), 274866395, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6298) },
                    { -575383224, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6469), 247837442, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6470) },
                    { -575383224, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6323), 217831782, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6325) },
                    { -297795176, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6586), 134079414, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6587) },
                    { -297795176, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6664), 536574529, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6665) },
                    { -297795176, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6573), 919825449, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6574) },
                    { -297795176, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6483), 620295008, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6484) },
                    { -297795176, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6625), 251058699, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6626) },
                    { -297795176, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6599), 646956022, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6600) },
                    { -297795176, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6496), 752335394, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6497) },
                    { -297795176, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6638), 232531427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6639) },
                    { -297795176, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6560), 235330080, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6561) },
                    { -297795176, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6651), 719294041, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6652) },
                    { -297795176, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6521), 745863016, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6522) },
                    { -297795176, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6612), 691768675, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6613) },
                    { -297795176, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6547), 258648660, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6548) },
                    { -297795176, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6509), 199957806, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6510) },
                    { -297795176, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6677), 914164551, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6678) },
                    { -297795176, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6534), 182475850, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6535) },
                    { 154966944, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7007), 290850655, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7008) },
                    { 154966944, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7084), 402656659, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7085) },
                    { 154966944, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6994), 837258692, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6996) },
                    { 154966944, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6904), 653185423, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6905) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 154966944, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7046), 796987375, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7047) },
                    { 154966944, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7020), 863989777, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7021) },
                    { 154966944, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6917), 966076661, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6918) },
                    { 154966944, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7059), 551616953, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7060) },
                    { 154966944, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6982), 392153876, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6983) },
                    { 154966944, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7071), 430440174, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7072) },
                    { 154966944, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6943), 971529057, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6944) },
                    { 154966944, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7033), 972811821, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7034) },
                    { 154966944, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6969), 472873707, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6970) },
                    { 154966944, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6930), 859809396, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6931) },
                    { 154966944, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7097), 701169548, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7098) },
                    { 154966944, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6956), 305061070, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6957) },
                    { 329301048, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7499), 441787835, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7501) },
                    { 329301048, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7628), 686395255, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7629) },
                    { 329301048, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7475), 501259047, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7478) },
                    { 329301048, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7322), 741176146, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7324) },
                    { 329301048, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7571), 705464519, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7574) },
                    { 329301048, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7523), 460313191, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7524) },
                    { 329301048, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7335), 423783650, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7336) },
                    { 329301048, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7596), 305039101, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7597) },
                    { 329301048, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7451), 293679907, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7453) },
                    { 329301048, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7614), 176859147, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7615) },
                    { 329301048, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7383), 598249951, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7385) },
                    { 329301048, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7546), 838255199, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7548) },
                    { 329301048, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7427), 926175183, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7429) },
                    { 329301048, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7359), 195453957, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7361) },
                    { 329301048, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7641), 517840637, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7642) },
                    { 329301048, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7404), 791538983, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(7406) },
                    { 964146008, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5957), 585424964, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5958) },
                    { 964146008, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6035), 904962074, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6036) },
                    { 964146008, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5944), 892140345, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5945) },
                    { 964146008, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5851), 613265142, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5852) },
                    { 964146008, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5996), 554005157, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5997) },
                    { 964146008, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5970), 348552386, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5971) },
                    { 964146008, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5865), 647145652, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5866) },
                    { 964146008, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6009), 263432642, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6010) },
                    { 964146008, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5931), 986722766, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5932) },
                    { 964146008, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6021), 804052637, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6023) },
                    { 964146008, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5891), 478630652, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5892) },
                    { 964146008, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5983), 295810949, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5984) },
                    { 964146008, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5917), 272548381, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5918) },
                    { 964146008, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5878), 558123525, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5879) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 964146008, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6047), 357762159, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6049) },
                    { 964146008, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5904), 447762036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5905) },
                    { 1067492296, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5264), 552870643, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5265) },
                    { 1067492296, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5345), 455907862, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5346) },
                    { 1067492296, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5231), 699599076, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5232) },
                    { 1067492296, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5139), 657306704, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5140) },
                    { 1067492296, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5304), 699766639, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5305) },
                    { 1067492296, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5277), 567653963, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5278) },
                    { 1067492296, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5153), 993774231, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5154) },
                    { 1067492296, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5319), 264608250, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5320) },
                    { 1067492296, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5218), 566484449, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5219) },
                    { 1067492296, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5332), 904290984, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5333) },
                    { 1067492296, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5179), 473812085, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5180) },
                    { 1067492296, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5290), 889451856, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5291) },
                    { 1067492296, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5205), 948571933, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5206) },
                    { 1067492296, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5167), 297291048, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5168) },
                    { 1067492296, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5358), 530508925, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5359) },
                    { 1067492296, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5192), 668565692, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5193) },
                    { 1211404568, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6168), 532808113, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6169) },
                    { 1211404568, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6245), 177718194, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6246) },
                    { 1211404568, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6155), 777120671, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6156) },
                    { 1211404568, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6064), 886286475, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6066) },
                    { 1211404568, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6206), 150670976, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6208) },
                    { 1211404568, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6181), 515977976, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6182) },
                    { 1211404568, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6077), 188266916, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6078) },
                    { 1211404568, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6219), 843188985, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6221) },
                    { 1211404568, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6142), 986734097, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6143) },
                    { 1211404568, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6232), 156220045, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6233) },
                    { 1211404568, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6103), 930138217, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6104) },
                    { 1211404568, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6194), 771281843, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6195) },
                    { 1211404568, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6129), 184875379, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6130) },
                    { 1211404568, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6090), 713301446, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6091) },
                    { 1211404568, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6258), 222445447, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6260) },
                    { 1211404568, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6116), 315538401, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(6117) },
                    { 1313124864, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5031), 774059044, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5032) },
                    { 1313124864, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5111), 618102572, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5112) },
                    { 1313124864, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5017), 424890011, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5018) },
                    { 1313124864, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4909), 150182818, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4910) },
                    { 1313124864, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5071), 620287005, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5072) },
                    { 1313124864, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5045), 609000968, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5046) },
                    { 1313124864, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4934), 466590968, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4935) },
                    { 1313124864, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5084), 480010085, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5085) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1313124864, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5004), 628904358, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5005) },
                    { 1313124864, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5097), 953196081, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5098) },
                    { 1313124864, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4962), 337267044, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4963) },
                    { 1313124864, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5058), 582400861, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5059) },
                    { 1313124864, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4990), 688981905, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4991) },
                    { 1313124864, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4948), 703095879, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4949) },
                    { 1313124864, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5126), 254507845, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5127) },
                    { 1313124864, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4976), 782729272, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4977) },
                    { 1773735400, 148110739, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5475), 743593624, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5476) },
                    { 1773735400, 291912260, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5598), 385102506, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5599) },
                    { 1773735400, 309238727, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5462), 546511076, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5463) },
                    { 1773735400, 318450609, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5371), 372698280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5372) },
                    { 1773735400, 322479427, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5515), 617105223, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5516) },
                    { 1773735400, 351272280, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5489), 943105521, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5490) },
                    { 1773735400, 498570860, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5385), 755393501, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5386) },
                    { 1773735400, 509076046, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5530), 565211907, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5531) },
                    { 1773735400, 607386667, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5449), 624214188, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5451) },
                    { 1773735400, 643814359, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5543), 376804070, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5544) },
                    { 1773735400, 701756541, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5411), 592712202, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5412) },
                    { 1773735400, 722643664, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5502), 754774462, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5503) },
                    { 1773735400, 730910299, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5437), 151622182, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5438) },
                    { 1773735400, 846662400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5398), 395037502, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5399) },
                    { 1773735400, 909865036, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5611), 319130555, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5612) },
                    { 1773735400, 987798915, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5424), 326032558, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(5425) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124902043, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3584), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3582), -297795176, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3583), 579809847 },
                    { 126097520, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3378), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3376), 1773735400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3377), 523161516 },
                    { 138006454, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3364), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3362), 1773735400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3363), 579809847 },
                    { 143345072, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3711), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3708), -1442824568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3710), 579809847 },
                    { 149709492, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3470), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3467), 964146008, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3469), 523161516 },
                    { 156625738, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3336), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3333), 1067492296, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3334), 523161516 },
                    { 161450473, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3255), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3252), 1313124864, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3253), 357227491 },
                    { 201532551, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3655), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3653), 154966944, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3654), 357227491 },
                    { 236687707, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3498), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3496), 1211404568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3497), 579809847 },
                    { 267902888, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3626), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3624), -2029511320, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3625), 579809847 },
                    { 314917550, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3819), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3817), 1857661776, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3818), 523161516 },
                    { 350358138, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3398), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3396), -1731586464, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3397), 357227491 },
                    { 360757358, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3456), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3453), 964146008, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3455), 579809847 },
                    { 396130284, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3725), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3722), -1442824568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3723), 523161516 },
                    { 434597076, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3805), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3803), 1857661776, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3804), 579809847 },
                    { 463292628, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3745), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3743), 329301048, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3744), 357227491 },
                    { 485732645, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3697), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3695), -1442824568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3696), 357227491 },
                    { 495048931, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3790), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3787), 1857661776, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3789), 357227491 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 515497904, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3276), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3274), 1313124864, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3275), 579809847 },
                    { 520705680, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3543), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3540), -575383224, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3542), 579809847 },
                    { 523088133, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3305), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3302), 1067492296, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3304), 357227491 },
                    { 550353264, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3598), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3596), -297795176, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3597), 523161516 },
                    { 565528284, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3350), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3348), 1773735400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3349), 357227491 },
                    { 580314317, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3442), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3440), 964146008, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3441), 357227491 },
                    { 582813325, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3641), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3638), -2029511320, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3640), 523161516 },
                    { 606668554, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3514), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3511), 1211404568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3513), 523161516 },
                    { 624017854, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3683), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3680), 154966944, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3681), 523161516 },
                    { 647906946, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3571), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3568), -297795176, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3569), 357227491 },
                    { 686887726, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3413), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3410), -1731586464, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3412), 579809847 },
                    { 690318137, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3291), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3288), 1313124864, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3289), 523161516 },
                    { 690590628, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3669), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3666), 154966944, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3668), 579809847 },
                    { 708362624, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3484), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3481), 1211404568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3483), 357227491 },
                    { 722431664, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3612), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3609), -2029511320, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3610), 357227491 },
                    { 766923485, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3529), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3527), -575383224, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3528), 357227491 },
                    { 784786888, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3319), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3317), 1067492296, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3318), 579809847 },
                    { 841345889, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3556), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3554), -575383224, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3555), 523161516 },
                    { 928795324, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3428), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3426), -1731586464, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3427), 523161516 },
                    { 942750517, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3773), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3771), 329301048, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3772), 523161516 },
                    { 970124482, new DateTime(2024, 3, 31, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3759), 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3757), 329301048, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3758), 579809847 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 126110125, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2371), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2372), 995604772 },
                    { 245173656, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2206), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2207), 869218868 },
                    { 326583560, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2445), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2447), 644500211 },
                    { 350052451, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2295), new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2296), 560511955 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 133683001, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4644), 329301048, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4645), 488232122 },
                    { 139652057, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4414), -297795176, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4415), 851117311 },
                    { 144218433, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4126), -1731586464, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4127), 488232122 },
                    { 156111673, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4464), -2029511320, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4466), 579731716 },
                    { 156366838, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4075), 1773735400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4076), 579731716 },
                    { 180206651, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4345), -575383224, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4346), 851117311 },
                    { 185560673, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4657), 329301048, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4658), 579731716 },
                    { 186392004, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4606), -1442824568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4607), 851117311 },
                    { 205653081, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4478), -2029511320, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4479), 851117311 },
                    { 225260112, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4203), 964146008, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4204), 579731716 },
                    { 246297863, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4542), 154966944, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4543), 851117311 },
                    { 255517163, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4516), 154966944, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4518), 488232122 },
                    { 257204493, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4555), 154966944, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4556), 720449991 },
                    { 262499287, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4240), 1211404568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4242), 252614198 },
                    { 267499565, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4370), -297795176, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4372), 252614198 },
                    { 313853907, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4228), 964146008, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4229), 720449991 },
                    { 341729881, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3982), 1067492296, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3983), 252614198 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 348228039, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4319), -575383224, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4320), 488232122 },
                    { 349903006, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4632), 329301048, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4633), 252614198 },
                    { 353385987, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4140), -1731586464, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4141), 579731716 },
                    { 372925079, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4100), 1773735400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4102), 720449991 },
                    { 377377957, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4177), 964146008, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4178), 252614198 },
                    { 379151606, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4033), 1067492296, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4034), 720449991 },
                    { 404030687, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4737), 1857661776, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4738), 851117311 },
                    { 413160644, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4279), 1211404568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4281), 851117311 },
                    { 417058791, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4190), 964146008, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4191), 488232122 },
                    { 439545546, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4669), 329301048, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4670), 851117311 },
                    { 442688672, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4046), 1773735400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4048), 252614198 },
                    { 450933792, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4267), 1211404568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4268), 579731716 },
                    { 476759305, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4020), 1067492296, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4021), 851117311 },
                    { 496935350, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4581), -1442824568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4582), 488232122 },
                    { 503048622, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4292), 1211404568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4293), 720449991 },
                    { 532058139, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3943), 1313124864, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3944), 579731716 },
                    { 535578114, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4426), -297795176, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4427), 720449991 },
                    { 536070872, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4152), -1731586464, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4153), 851117311 },
                    { 539340541, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4568), -1442824568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4569), 252614198 },
                    { 553060909, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4503), 154966944, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4504), 252614198 },
                    { 557095568, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4401), -297795176, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4402), 579731716 },
                    { 563231544, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4305), -575383224, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4306), 252614198 },
                    { 584125291, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4529), 154966944, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4530), 579731716 },
                    { 603640170, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4619), -1442824568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4620), 720449991 },
                    { 635792965, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4682), 329301048, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4683), 720449991 },
                    { 642447522, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4697), 1857661776, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4698), 252614198 },
                    { 644668682, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4490), -2029511320, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4491), 720449991 },
                    { 647369169, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4357), -575383224, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4359), 720449991 },
                    { 667150882, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4007), 1067492296, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4008), 579731716 },
                    { 678879414, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4750), 1857661776, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4751), 720449991 },
                    { 682864077, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3994), 1067492296, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3995), 488232122 },
                    { 695982505, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4388), -297795176, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4390), 488232122 },
                    { 700810518, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4724), 1857661776, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4725), 579731716 },
                    { 758654480, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4439), -2029511320, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4440), 252614198 },
                    { 797712955, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4165), -1731586464, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4166), 720449991 },
                    { 806447562, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4452), -2029511320, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4453), 488232122 },
                    { 808516398, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4113), -1731586464, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4114), 252614198 },
                    { 841021247, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4331), -575383224, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4332), 579731716 },
                    { 843549414, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3929), 1313124864, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3931), 488232122 },
                    { 844316225, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4063), 1773735400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4064), 488232122 },
                    { 856007230, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4712), 1857661776, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4713), 488232122 },
                    { 871272341, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4254), 1211404568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4255), 488232122 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 894233607, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4215), 964146008, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4216), 851117311 },
                    { 932320772, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3955), 1313124864, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3956), 851117311 },
                    { 934760839, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3910), 1313124864, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3911), 252614198 },
                    { 976100104, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4594), -1442824568, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4595), 579731716 },
                    { 983915514, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4088), 1773735400, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(4089), 851117311 },
                    { 991752379, 0f, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3968), 1313124864, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(3969), 720449991 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 800363378, 560511955, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2308), 136004955, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2309) },
                    { 800363378, 644500211, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2461), 938289390, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2462) },
                    { 800363378, 869218868, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2220), 443242158, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2221) },
                    { 800363378, 995604772, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2384), 969567647, new DateTime(2024, 3, 20, 16, 33, 36, 598, DateTimeKind.Local).AddTicks(2385) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complains_ProjectId",
                table: "Complains",
                column: "ProjectId");

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
                name: "IX_Payment_ProjectId",
                table: "Payment",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SubContractorId",
                table: "Projects",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TypeId",
                table: "Projects",
                column: "TypeId");

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
                name: "FK_Complains_Projects_ProjectId",
                table: "Complains",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Payment_Projects_ProjectId",
                table: "Payment",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_SubContractorId",
                table: "Projects",
                column: "SubContractorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_ProjectId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Complains");

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
                name: "Payment");

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
