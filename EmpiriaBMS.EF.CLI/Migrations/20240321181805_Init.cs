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
                    TeamsObjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    EstimatedMandays = table.Column<long>(type: "bigint", nullable: false),
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
                    { 198101778, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2778), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2779), "Potable Water" },
                    { 229905637, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2803), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2804), "Fire Detection" },
                    { 259132261, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2872), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2873), "Structured Cabling" },
                    { 291336159, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2944), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2945), "Outsource" },
                    { 302506726, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2858), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2859), "Power Distribution" },
                    { 308478501, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2896), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2897), "CCTV" },
                    { 320006667, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2845), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2846), "Natural Gas" },
                    { 334001917, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2884), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2885), "Burglar Alarm" },
                    { 392466777, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2932), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2933), "Energy Efficiency" },
                    { 399669692, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2833), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2834), "Elevators" },
                    { 461282721, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2956), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2957), "TenderDocument" },
                    { 494203799, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2908), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2909), "BMS" },
                    { 500171099, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2970), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2971), "Construction Supervision" },
                    { 599742083, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2983), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2984), "Project Manager Hours" },
                    { 733262797, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2820), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2821), "Fire Suppression" },
                    { 895768666, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2920), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2921), "Photovoltaics" },
                    { 940108912, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2765), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2766), "Sewage" },
                    { 970307720, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2791), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2792), "Drainage" },
                    { 994250585, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2745), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2746), "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 610582217, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3235), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3237), "Drawings" },
                    { 694269607, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3223), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3224), "Calculations" },
                    { 917437195, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3204), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3205), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 171409682, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3862), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3863), "Administration" },
                    { 343646037, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3850), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3851), "Meetings" },
                    { 853802686, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3824), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3825), "Printing" },
                    { 888441840, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3837), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3838), "On-Site" },
                    { 997457239, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3803), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3804), "Communications" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 195867155, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(406), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(407), "Dashboard Assign Designer", 3 },
                    { 198482754, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(300), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(301), "See Dashboard Layout", 1 },
                    { 271764173, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(494), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(495), "See All Disciplines", 9 },
                    { 383524648, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(436), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(437), "Dashboard Assign Project Manager", 5 },
                    { 395679643, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(536), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(537), "Add Project On Dashboard", 12 },
                    { 420496936, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(479), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(481), "Dashboard See My Hours", 8 },
                    { 490407257, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(389), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(390), "Dashboard Edit My Hours", 2 },
                    { 682979795, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(465), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(467), "See Admin Layout", 7 },
                    { 755427341, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(522), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(523), "See All Projects", 11 },
                    { 802336680, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(452), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(453), "Dashboard Add Project", 6 },
                    { 878178467, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(420), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(422), "Dashboard Assign Engineer", 4 },
                    { 884404057, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(508), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(509), "See All Drawings", 10 },
                    { 897317705, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(549), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(551), "Display Projects Code", 13 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 130820427, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2425), "Buildings Description", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2426), "Buildings" },
                    { 299992358, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2441), "Infrastructure Description", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2442), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 481954345, false, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2485), "Production Management Description", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2487), "Production Management" },
                    { 512644110, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2454), "Energy Description", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2455), "Energy" },
                    { 736707764, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2472), "Consulting Description", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2473), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(612), false, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(613), "COO" },
                    { 245886468, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(599), false, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(600), "Project Manager" },
                    { 273380139, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(585), false, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(586), "Engineer" },
                    { 468861185, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(697), false, false, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(698), "Secretariat" },
                    { 523028925, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(565), false, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(566), "Designer" },
                    { 762970937, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(669), false, false, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(670), "Customer" },
                    { 770729896, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(656), false, false, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(657), "Guest" },
                    { 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(625), false, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(627), "CTO" },
                    { 935923977, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(683), false, false, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(684), "Admin" },
                    { 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(643), false, true, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(644), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1940), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1942), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 185306717, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1669), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1670), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1882), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1884), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2088), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2089), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2174), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2175), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2341), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2343), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2214), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2216), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1841), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1842), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1754), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1755), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2129), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2130), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 626159222, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1627), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1628), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2008), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2009), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1795), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1796), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 698512178, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1585), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1586), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2256), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2258), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1712), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1713), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2048), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2049), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2299), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2300), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2383), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2384), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 979809013, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1507), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1508), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 186948328, "kmargeti@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2102), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2104), 275820874 },
                    { 208444823, "pfokianou@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2188), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2189), 459775630 },
                    { 318170539, "blekou@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2271), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2272), 848772157 },
                    { 362718195, "xmanarolis@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1768), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1770), 597380054 },
                    { 389016541, "agretos@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2062), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2063), 884784744 },
                    { 428519844, "ngal@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1899), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1900), 261230524 },
                    { 469204061, "haris@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2147), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2148), 616097751 },
                    { 486079943, "embiria@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1530), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1531), 979809013 },
                    { 526764309, "vpax@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1727), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1728), 860241955 },
                    { 607344179, "kkotsoni@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1955), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1956), 161922446 },
                    { 623823731, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1552), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1553), 979809013 },
                    { 640216374, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2228), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2230), 583839038 },
                    { 649466122, "chkovras@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1855), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1856), 596983049 },
                    { 667162155, "dtsa@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1683), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1684), 185306717 },
                    { 674003019, "vchontos@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2313), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2314), 952187523 },
                    { 784338344, "gdoug@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1600), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1601), 698512178 },
                    { 793207060, "sparisis@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1814), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1815), 685919460 },
                    { 845711371, "panperivollari@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2356), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2357), 521991735 },
                    { 881778533, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2397), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2398), 979290353 },
                    { 882372978, "vtza@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2022), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2023), 646108196 },
                    { 965931833, "dtsa@embiria.gr", new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1641), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1642), 626159222 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 257273718, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), new DateTime(2024, 12, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Test Description Project_12", new DateTime(2024, 12, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 0f, new DateTime(2024, 12, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Project_3", 161922446, null, 512644110, 0f },
                    { 289538295, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), new DateTime(2024, 7, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Test Description Project_4", new DateTime(2024, 7, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 0f, new DateTime(2024, 7, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Project_2", 161922446, null, 299992358, 0f },
                    { 475482597, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), new DateTime(2024, 6, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Test Description Project_PM", new DateTime(2024, 4, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 0f, new DateTime(2024, 5, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 1500L, 12L, null, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Project_PM", null, null, 481954345, 0f },
                    { 578464411, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), new DateTime(2024, 4, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Test Description Project_1", new DateTime(2024, 4, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 0f, new DateTime(2024, 4, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Project_1", 161922446, null, 130820427, 0f },
                    { 810594321, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), new DateTime(2025, 7, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Test Description Project_16", new DateTime(2025, 7, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 0f, new DateTime(2025, 7, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 20, 18, 4, 939, DateTimeKind.Local).AddTicks(4574), "Project_4", 161922446, null, 736707764, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 195867155, 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(956), -625299038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(957) },
                    { 198482754, 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(927), -841994990, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(928) },
                    { 271764173, 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1011), 1869235425, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1012) },
                    { 383524648, 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(983), -321341057, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(984) },
                    { 420496936, 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(997), 1584901521, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(998) },
                    { 490407257, 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(941), 311570839, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(942) },
                    { 755427341, 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1041), -1497254152, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1042) },
                    { 878178467, 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(969), 1427483034, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(971) },
                    { 884404057, 178531948, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1025), -811600667, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1026) },
                    { 198482754, 245886468, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(845), -183431551, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(846) },
                    { 271764173, 245886468, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(900), 362791144, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(901) },
                    { 420496936, 245886468, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(886), 1397612691, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(887) },
                    { 490407257, 245886468, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(858), -975992611, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(860) },
                    { 878178467, 245886468, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(872), -1958278706, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(873) },
                    { 884404057, 245886468, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(914), 1296135441, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(915) },
                    { 195867155, 273380139, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(788), -1481477057, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(789) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 198482754, 273380139, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(760), -441713569, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(762) },
                    { 271764173, 273380139, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(816), 1787066519, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(817) },
                    { 420496936, 273380139, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(802), -67300919, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(803) },
                    { 490407257, 273380139, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(774), -2123221715, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(775) },
                    { 884404057, 273380139, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(830), -209879887, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(831) },
                    { 198482754, 468861185, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1417), -987551963, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1418) },
                    { 271764173, 468861185, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1463), 1048538552, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1465) },
                    { 420496936, 468861185, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1449), -1465277534, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1450) },
                    { 490407257, 468861185, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1431), -894804173, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1432) },
                    { 755427341, 468861185, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1491), 2076174203, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1493) },
                    { 884404057, 468861185, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1478), 1234960151, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1479) },
                    { 198482754, 523028925, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(710), -1380604688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(711) },
                    { 420496936, 523028925, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(747), -1357095487, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(748) },
                    { 490407257, 523028925, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(732), 1030253342, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(734) },
                    { 198482754, 762970937, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1348), 1726317090, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1349) },
                    { 198482754, 770729896, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1334), 100375759, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1335) },
                    { 198482754, 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1055), 1262539346, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1057) },
                    { 271764173, 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1125), -47340472, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1126) },
                    { 383524648, 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1084), -955066333, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1085) },
                    { 395679643, 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1166), 636872702, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1168) },
                    { 420496936, 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1111), 1692022608, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1112) },
                    { 490407257, 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1070), -836726975, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1071) },
                    { 755427341, 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1153), -499486684, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1154) },
                    { 802336680, 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1097), 918534470, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1099) },
                    { 884404057, 839280507, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1139), -1969554721, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1140) },
                    { 271764173, 935923977, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1375), -97303625, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1376) },
                    { 682979795, 935923977, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1362), 721507910, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1363) },
                    { 755427341, 935923977, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1403), -770610100, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1405) },
                    { 884404057, 935923977, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1389), -742808335, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1390) },
                    { 195867155, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1209), 1112279427, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1210) },
                    { 198482754, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1181), -264966101, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1182) },
                    { 271764173, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1265), 1619574008, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1266) },
                    { 383524648, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1238), -565296596, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1239) },
                    { 395679643, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1320), -1269863657, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1321) },
                    { 490407257, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1195), 1880419280, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1196) },
                    { 755427341, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1293), 132852754, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1294) },
                    { 802336680, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1251), -1023833659, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1253) },
                    { 878178467, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1224), -15726824, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1225) },
                    { 884404057, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1279), -292984199, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1280) },
                    { 897317705, 974060553, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1306), -251961623, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1308) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 178531948, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1981), 827380049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1982) },
                    { 245886468, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2515), 151984456, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2516) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 273380139, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1968), 928746118, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1969) },
                    { 839280507, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1995), 159303100, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1996) },
                    { 523028925, 185306717, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1697), 301043417, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1698) },
                    { 273380139, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1912), 886170927, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1913) },
                    { 974060553, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1927), 951699754, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1928) },
                    { 273380139, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2116), 338439673, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2117) },
                    { 273380139, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2201), 865134693, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2202) },
                    { 273380139, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2369), 807483078, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2370) },
                    { 273380139, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2243), 441982620, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2244) },
                    { 273380139, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1869), 139109276, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1870) },
                    { 273380139, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1782), 872877158, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1783) },
                    { 245886468, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2529), 235562969, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2530) },
                    { 273380139, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2160), 168514792, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2161) },
                    { 523028925, 626159222, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1655), 194820086, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1656) },
                    { 273380139, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2035), 906982726, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2036) },
                    { 273380139, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1827), 630955650, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1829) },
                    { 523028925, 698512178, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1613), 683059398, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1614) },
                    { 273380139, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2285), 342504015, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2286) },
                    { 245886468, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2500), 289351360, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2501) },
                    { 273380139, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1740), 502203323, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1741) },
                    { 273380139, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2075), 399492013, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2076) },
                    { 273380139, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2327), 481706121, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2328) },
                    { 273380139, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2410), 494678786, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2411) },
                    { 468861185, 979809013, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1566), 521232483, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(1567) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2062305392, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3089), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3090), 289538295, 198101778, null },
                    { -1549965688, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3117), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3118), 257273718, 334001917, null },
                    { -1093834280, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3011), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3013), 578464411, 308478501, null },
                    { -1017156216, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3162), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3163), 810594321, 994250585, null },
                    { -773506000, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3104), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3105), 257273718, 940108912, null },
                    { -492421312, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3035), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3036), 578464411, 494203799, null },
                    { -333837336, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3048), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3049), 578464411, 994250585, null },
                    { 378073184, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3129), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3130), 257273718, 229905637, null },
                    { 832805832, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3175), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3176), 810594321, 302506726, null },
                    { 1172320112, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3149), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3150), 810594321, 733262797, null },
                    { 1243352016, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3188), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3190), 475482597, 599742083, null },
                    { 1664531736, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3062), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3063), 289538295, 461282721, null },
                    { 2066543256, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3074), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3075), 289538295, 302506726, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 493341174, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2681), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2683), 4000.0, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2682), "Signature 1423418", 12762, 257273718, 3.0, 17.0 },
                    { 852466724, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2712), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2714), 13000.0, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2713), "Signature 1423412", 25461, 810594321, 4.0, 24.0 },
                    { 928603740, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2599), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2601), 3010.0, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2600), "Signature 142344", 83371, 578464411, 1.0, 17.0 },
                    { 967279891, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2644), new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2647), 3100.0, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(2645), "Signature 142346", 75900, 289538295, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2062305392, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5772), 922937955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5773) },
                    { -2062305392, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5760), 768735364, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5761) },
                    { -2062305392, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5808), 159779887, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5809) },
                    { -2062305392, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5832), 633364106, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5833) },
                    { -2062305392, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5885), 413560120, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5886) },
                    { -2062305392, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5848), 882221315, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5849) },
                    { -2062305392, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5747), 505005225, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5748) },
                    { -2062305392, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5723), 512529849, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5725) },
                    { -2062305392, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5820), 788417770, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5821) },
                    { -2062305392, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5784), 677718180, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5785) },
                    { -2062305392, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5735), 900405681, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5737) },
                    { -2062305392, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5861), 308249494, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5862) },
                    { -2062305392, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5711), 895985081, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5713) },
                    { -2062305392, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5796), 745159042, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5797) },
                    { -2062305392, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5873), 607110822, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5874) },
                    { -2062305392, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5897), 771914092, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5898) },
                    { -1549965688, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6166), 157630380, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6167) },
                    { -1549965688, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6154), 643222760, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6155) },
                    { -1549965688, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6202), 487699917, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6203) },
                    { -1549965688, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6230), 867863091, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6231) },
                    { -1549965688, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6279), 481477511, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6280) },
                    { -1549965688, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6242), 361279985, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6243) },
                    { -1549965688, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6141), 714518933, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6142) },
                    { -1549965688, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6117), 140783702, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6118) },
                    { -1549965688, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6214), 534661442, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6215) },
                    { -1549965688, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6178), 945348416, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6179) },
                    { -1549965688, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6129), 597392027, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6130) },
                    { -1549965688, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6254), 870365814, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6256) },
                    { -1549965688, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6105), 220307470, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6106) },
                    { -1549965688, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6190), 987859645, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6191) },
                    { -1549965688, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6267), 365858824, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6268) },
                    { -1549965688, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6291), 395952848, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6292) },
                    { -1093834280, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4774), 756493466, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4776) },
                    { -1093834280, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4758), 218926799, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4759) },
                    { -1093834280, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4813), 424929837, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4814) },
                    { -1093834280, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4838), 547650738, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4840) },
                    { -1093834280, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4887), 686623030, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4889) },
                    { -1093834280, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4851), 218748486, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4852) },
                    { -1093834280, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4745), 322689450, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4747) },
                    { -1093834280, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4720), 488969956, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4721) },
                    { -1093834280, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4826), 215716450, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4827) },
                    { -1093834280, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4788), 430149764, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4789) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1093834280, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4733), 664016937, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4734) },
                    { -1093834280, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4863), 850024289, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4864) },
                    { -1093834280, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4701), 839430266, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4702) },
                    { -1093834280, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4801), 376236517, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4802) },
                    { -1093834280, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4875), 945773844, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4876) },
                    { -1093834280, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4900), 836224666, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4901) },
                    { -1017156216, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6760), 681815973, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6761) },
                    { -1017156216, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6748), 900020660, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6749) },
                    { -1017156216, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6797), 268423453, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6798) },
                    { -1017156216, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6822), 255075804, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6823) },
                    { -1017156216, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6870), 756481462, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6872) },
                    { -1017156216, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6834), 222233673, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6835) },
                    { -1017156216, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6735), 152244503, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6737) },
                    { -1017156216, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6711), 397883498, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6712) },
                    { -1017156216, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6809), 741659227, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6810) },
                    { -1017156216, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6772), 560420455, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6774) },
                    { -1017156216, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6723), 945466369, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6724) },
                    { -1017156216, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6846), 156894422, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6847) },
                    { -1017156216, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6699), 218447571, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6700) },
                    { -1017156216, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6785), 702698189, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6786) },
                    { -1017156216, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6858), 506585350, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6859) },
                    { -1017156216, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6882), 961856277, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6884) },
                    { -773506000, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5970), 634153541, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5971) },
                    { -773506000, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5958), 928017770, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5959) },
                    { -773506000, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6007), 716915619, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6008) },
                    { -773506000, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6031), 590904698, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6032) },
                    { -773506000, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6080), 294075099, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6081) },
                    { -773506000, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6043), 980776418, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6044) },
                    { -773506000, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5946), 901497638, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5947) },
                    { -773506000, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5922), 229328758, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5923) },
                    { -773506000, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6019), 570943152, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6020) },
                    { -773506000, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5983), 538235678, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5984) },
                    { -773506000, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5934), 393887990, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5935) },
                    { -773506000, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6055), 577234241, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6056) },
                    { -773506000, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5909), 454988420, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5911) },
                    { -773506000, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5995), 765487494, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5996) },
                    { -773506000, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6067), 961474396, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6068) },
                    { -773506000, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6092), 410625385, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6094) },
                    { -492421312, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4975), 621169837, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4976) },
                    { -492421312, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4962), 146750223, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4963) },
                    { -492421312, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5011), 390516003, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5012) },
                    { -492421312, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5036), 217170326, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5037) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -492421312, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5084), 974407672, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5085) },
                    { -492421312, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5048), 680014657, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5049) },
                    { -492421312, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4950), 322147542, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4951) },
                    { -492421312, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4925), 930476041, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4926) },
                    { -492421312, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5023), 169821842, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5024) },
                    { -492421312, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4987), 595592967, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4988) },
                    { -492421312, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4938), 375640204, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4939) },
                    { -492421312, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5060), 962689137, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5061) },
                    { -492421312, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4912), 141815958, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4913) },
                    { -492421312, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4999), 406954633, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5000) },
                    { -492421312, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5072), 535597763, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5073) },
                    { -492421312, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5096), 161812912, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5097) },
                    { -333837336, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5176), 414729024, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5177) },
                    { -333837336, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5164), 583758112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5165) },
                    { -333837336, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5212), 998839868, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5213) },
                    { -333837336, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5237), 844370001, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5238) },
                    { -333837336, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5286), 450805233, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5287) },
                    { -333837336, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5249), 219251951, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5250) },
                    { -333837336, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5151), 637030411, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5152) },
                    { -333837336, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5126), 317586819, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5127) },
                    { -333837336, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5224), 319610451, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5225) },
                    { -333837336, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5188), 504722467, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5189) },
                    { -333837336, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5139), 203909716, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5140) },
                    { -333837336, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5261), 404239007, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5262) },
                    { -333837336, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5109), 677511932, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5110) },
                    { -333837336, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5200), 147731353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5201) },
                    { -333837336, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5274), 409236164, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5275) },
                    { -333837336, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5298), 167024959, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5299) },
                    { 378073184, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6366), 197605981, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6367) },
                    { 378073184, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6353), 346403235, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6355) },
                    { 378073184, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6402), 522348546, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6403) },
                    { 378073184, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6426), 404748808, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6427) },
                    { 378073184, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6475), 982629112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6477) },
                    { 378073184, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6439), 527443659, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6440) },
                    { 378073184, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6341), 727300895, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6342) },
                    { 378073184, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6317), 642214800, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6318) },
                    { 378073184, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6414), 816089187, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6415) },
                    { 378073184, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6378), 487686714, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6379) },
                    { 378073184, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6329), 462843910, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6330) },
                    { 378073184, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6451), 662342676, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6452) },
                    { 378073184, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6303), 487989920, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6304) },
                    { 378073184, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6390), 355792919, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6391) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 378073184, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6463), 318231010, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6464) },
                    { 378073184, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6488), 232605822, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6489) },
                    { 832805832, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6960), 683685951, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6961) },
                    { 832805832, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6948), 467133949, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6949) },
                    { 832805832, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6996), 652333715, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6997) },
                    { 832805832, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7021), 363748398, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7022) },
                    { 832805832, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7069), 751784281, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7070) },
                    { 832805832, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7033), 906511920, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7034) },
                    { 832805832, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6936), 145008652, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6937) },
                    { 832805832, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6911), 636796076, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6912) },
                    { 832805832, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7008), 176036858, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7009) },
                    { 832805832, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6972), 484128816, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6973) },
                    { 832805832, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6923), 427525131, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6924) },
                    { 832805832, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7045), 406538384, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7046) },
                    { 832805832, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6899), 414535663, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6900) },
                    { 832805832, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6984), 221302889, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6985) },
                    { 832805832, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7057), 606933388, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7058) },
                    { 832805832, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7081), 587100477, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(7082) },
                    { 1172320112, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6565), 620438038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6566) },
                    { 1172320112, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6553), 793141746, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6554) },
                    { 1172320112, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6602), 622937774, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6603) },
                    { 1172320112, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6626), 495105635, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6627) },
                    { 1172320112, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6675), 838890694, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6676) },
                    { 1172320112, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6638), 840636566, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6639) },
                    { 1172320112, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6540), 662838183, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6541) },
                    { 1172320112, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6515), 400911447, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6516) },
                    { 1172320112, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6614), 246866060, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6615) },
                    { 1172320112, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6577), 289093821, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6578) },
                    { 1172320112, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6528), 498941385, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6529) },
                    { 1172320112, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6650), 210615460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6651) },
                    { 1172320112, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6500), 862182877, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6501) },
                    { 1172320112, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6589), 186457399, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6591) },
                    { 1172320112, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6663), 668025999, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6664) },
                    { 1172320112, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6687), 537898386, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(6688) },
                    { 1664531736, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5372), 762063489, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5373) },
                    { 1664531736, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5359), 233834227, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5360) },
                    { 1664531736, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5408), 444810707, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5409) },
                    { 1664531736, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5433), 145418645, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5434) },
                    { 1664531736, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5481), 803035452, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5482) },
                    { 1664531736, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5445), 912411684, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5446) },
                    { 1664531736, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5347), 552586649, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5348) },
                    { 1664531736, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5323), 130292662, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5324) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1664531736, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5420), 802954389, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5421) },
                    { 1664531736, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5384), 515570995, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5385) },
                    { 1664531736, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5335), 983720937, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5336) },
                    { 1664531736, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5457), 682113466, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5458) },
                    { 1664531736, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5311), 563671168, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5312) },
                    { 1664531736, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5396), 851332904, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5397) },
                    { 1664531736, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5469), 522007034, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5470) },
                    { 1664531736, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5493), 758217473, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5494) },
                    { 2066543256, 161922446, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5577), 495327478, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5578) },
                    { 2066543256, 261230524, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5565), 487615709, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5566) },
                    { 2066543256, 275820874, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5614), 670433246, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5615) },
                    { 2066543256, 459775630, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5638), 590615688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5639) },
                    { 2066543256, 521991735, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5687), 206382329, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5688) },
                    { 2066543256, 583839038, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5650), 837223903, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5651) },
                    { 2066543256, 596983049, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5553), 238051147, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5554) },
                    { 2066543256, 597380054, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5527), 387273062, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5528) },
                    { 2066543256, 616097751, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5626), 937101756, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5627) },
                    { 2066543256, 646108196, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5589), 539447545, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5590) },
                    { 2066543256, 685919460, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5541), 738466956, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5542) },
                    { 2066543256, 848772157, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5662), 696857989, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5663) },
                    { 2066543256, 860241955, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5513), 194221355, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5514) },
                    { 2066543256, 884784744, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5601), 617076942, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5603) },
                    { 2066543256, 952187523, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5675), 562195357, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5676) },
                    { 2066543256, 979290353, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5699), 979149945, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(5700) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 138303234, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3672), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3669), -1017156216, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3670), 917437195 },
                    { 150617942, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3356), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3354), -333837336, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3355), 694269607 },
                    { 177729216, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3299), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3297), -492421312, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3298), 917437195 },
                    { 211112236, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3619), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3616), 378073184, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3617), 610582217 },
                    { 219385427, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3271), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3269), -1093834280, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3270), 694269607 },
                    { 220242149, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3605), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3603), 378073184, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3604), 694269607 },
                    { 234547230, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3466), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3464), -2062305392, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3465), 917437195 },
                    { 251312729, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3499), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3496), -2062305392, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3498), 610582217 },
                    { 252669444, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3632), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3630), 1172320112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3631), 917437195 },
                    { 282893878, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3645), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3643), 1172320112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3644), 694269607 },
                    { 355332266, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3342), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3340), -333837336, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3341), 917437195 },
                    { 372558856, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3385), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3383), 1664531736, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3384), 917437195 },
                    { 379000748, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3729), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3726), 832805832, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3727), 694269607 },
                    { 419645536, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3480), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3477), -2062305392, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3478), 694269607 },
                    { 428750795, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3286), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3283), -1093834280, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3284), 610582217 },
                    { 436972176, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3253), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3249), -1093834280, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3250), 917437195 },
                    { 439277966, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3370), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3368), -333837336, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3369), 610582217 },
                    { 440905771, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3539), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3537), -773506000, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3538), 610582217 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 479174593, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3579), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3577), -1549965688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3578), 610582217 },
                    { 578325437, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3658), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3656), 1172320112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3657), 610582217 },
                    { 604919976, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3513), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3510), -773506000, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3512), 917437195 },
                    { 693995697, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3699), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3696), -1017156216, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3697), 610582217 },
                    { 699019219, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3566), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3564), -1549965688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3565), 694269607 },
                    { 708950559, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3439), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3437), 2066543256, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3438), 694269607 },
                    { 717576614, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3592), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3590), 378073184, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3591), 917437195 },
                    { 739665907, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3399), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3397), 1664531736, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3398), 694269607 },
                    { 759788992, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3524), -773506000, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3525), 694269607 },
                    { 779834786, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3426), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3424), 2066543256, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3425), 917437195 },
                    { 822488682, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3685), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3683), -1017156216, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3684), 694269607 },
                    { 829113770, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3553), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3551), -1549965688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3552), 917437195 },
                    { 862301833, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3772), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3769), 1243352016, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3770), 694269607 },
                    { 883916376, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3313), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3310), -492421312, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3311), 694269607 },
                    { 901568122, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3412), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3410), 1664531736, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3411), 610582217 },
                    { 908275349, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3329), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3327), -492421312, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3328), 610582217 },
                    { 932998156, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3714), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3712), 832805832, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3713), 917437195 },
                    { 945567546, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3453), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3450), 2066543256, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3452), 610582217 },
                    { 971322049, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3757), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3754), 1243352016, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3755), 917437195 },
                    { 974593664, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3742), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3739), 832805832, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3740), 610582217 },
                    { 985386090, new DateTime(2024, 4, 1, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3788), 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3786), 1243352016, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3787), 610582217 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 144498053, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4250), -2062305392, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4251), 171409682 },
                    { 178689296, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4364), -1549965688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4365), 343646037 },
                    { 178858839, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4301), -773506000, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4302), 343646037 },
                    { 185119418, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4011), -333837336, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4012), 997457239 },
                    { 192593165, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4412), 378073184, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4413), 888441840 },
                    { 194107677, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4226), -2062305392, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4227), 888441840 },
                    { 198880389, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4141), 2066543256, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4142), 997457239 },
                    { 211930240, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4313), -773506000, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4314), 171409682 },
                    { 235833977, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4502), 1172320112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4503), 171409682 },
                    { 279155127, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4376), -1549965688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4377), 171409682 },
                    { 289368325, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3921), -1093834280, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3922), 343646037 },
                    { 295360314, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4400), 378073184, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4401), 853802686 },
                    { 298431964, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4035), -333837336, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4036), 888441840 },
                    { 314076564, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4388), 378073184, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4389), 997457239 },
                    { 353955978, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4526), -1017156216, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4527), 853802686 },
                    { 360308712, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4622), 832805832, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4623), 171409682 },
                    { 397639499, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4059), -333837336, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4060), 171409682 },
                    { 398231352, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4598), 832805832, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4599), 888441840 },
                    { 402758822, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4424), 378073184, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4425), 343646037 },
                    { 414311512, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4574), 832805832, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4575), 997457239 },
                    { 439155566, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3947), -492421312, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3948), 997457239 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 443375782, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4047), -333837336, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4048), 343646037 },
                    { 449854186, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4490), 1172320112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4491), 343646037 },
                    { 460880246, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4262), -773506000, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4263), 997457239 },
                    { 464643715, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4286), -773506000, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4287), 888441840 },
                    { 486010901, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4165), 2066543256, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4166), 888441840 },
                    { 500041976, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4437), 378073184, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4438), 171409682 },
                    { 505152400, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4465), 1172320112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4466), 853802686 },
                    { 510087478, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4127), 1664531736, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4128), 171409682 },
                    { 528585766, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4650), 1243352016, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4651), 853802686 },
                    { 535323951, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4686), 1243352016, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4687), 171409682 },
                    { 536240461, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4339), -1549965688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4340), 853802686 },
                    { 537155848, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3895), -1093834280, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3896), 853802686 },
                    { 554425523, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4189), 2066543256, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4190), 171409682 },
                    { 570739510, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3960), -492421312, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3961), 853802686 },
                    { 589863342, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3879), -1093834280, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3880), 997457239 },
                    { 605165326, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3933), -1093834280, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3934), 171409682 },
                    { 614149869, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4072), 1664531736, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4073), 997457239 },
                    { 618334917, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4097), 1664531736, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4098), 888441840 },
                    { 633256656, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4023), -333837336, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4024), 853802686 },
                    { 633939601, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4586), 832805832, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4587), 853802686 },
                    { 643836493, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4352), -1549965688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4353), 888441840 },
                    { 668174677, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4153), 2066543256, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4154), 853802686 },
                    { 691330622, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4636), 1243352016, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4637), 997457239 },
                    { 708460777, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3908), -1093834280, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3909), 888441840 },
                    { 725456353, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4538), -1017156216, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4539), 888441840 },
                    { 726770372, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4109), 1664531736, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4111), 343646037 },
                    { 744681304, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4673), 1243352016, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4674), 343646037 },
                    { 748481487, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4514), -1017156216, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4515), 997457239 },
                    { 754233668, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4213), -2062305392, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4214), 853802686 },
                    { 761296323, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4610), 832805832, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4611), 343646037 },
                    { 778901658, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4326), -1549965688, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4327), 997457239 },
                    { 806914628, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4238), -2062305392, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4239), 343646037 },
                    { 822648778, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3998), -492421312, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3999), 171409682 },
                    { 823148297, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4562), -1017156216, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4563), 171409682 },
                    { 848489826, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4177), 2066543256, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4178), 343646037 },
                    { 858432525, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4449), 1172320112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4450), 997457239 },
                    { 885780432, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4084), 1664531736, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4085), 853802686 },
                    { 902409149, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3985), -492421312, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3986), 343646037 },
                    { 925079053, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4550), -1017156216, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4551), 343646037 },
                    { 976723891, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4201), -2062305392, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4202), 997457239 },
                    { 978642004, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3973), -492421312, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(3974), 888441840 },
                    { 987993316, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4661), 1243352016, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4663), 888441840 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[] { 990006193, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4274), -773506000, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4275), 853802686 });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[] { 996955170, 0f, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4477), 1172320112, new DateTime(2024, 3, 21, 20, 18, 4, 950, DateTimeKind.Local).AddTicks(4478), 888441840 });

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
