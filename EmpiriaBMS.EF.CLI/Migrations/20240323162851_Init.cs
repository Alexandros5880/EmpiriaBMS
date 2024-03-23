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
                    { 135988942, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7058), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7059), "DWG Admin/Clearing" },
                    { 180711141, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6826), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6827), "HVAC" },
                    { 247358216, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6918), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6919), "Natural Gas" },
                    { 297884286, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6868), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6870), "Drainage" },
                    { 436964624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7028), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7029), "TenderDocument" },
                    { 493564746, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6880), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6881), "Fire Detection" },
                    { 566950448, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7004), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7005), "Energy Efficiency" },
                    { 616177718, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6943), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6944), "Structured Cabling" },
                    { 634031162, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7016), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7017), "Outsource" },
                    { 722857861, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6894), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6895), "Fire Suppression" },
                    { 733181537, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6930), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6931), "Power Distribution" },
                    { 786017662, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6844), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6845), "Sewage" },
                    { 809771443, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7070), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7071), "Project Manager Hours" },
                    { 813383881, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6906), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6907), "Elevators" },
                    { 827297833, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6992), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6993), "Photovoltaics" },
                    { 906107001, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6968), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6969), "CCTV" },
                    { 929830655, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6980), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6981), "BMS" },
                    { 933975164, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6856), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6857), "Potable Water" },
                    { 954943839, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7045), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7046), "Construction Supervision" },
                    { 970834133, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6956), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6957), "Burglar Alarm" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 238957590, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7298), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7299), "Calculations" },
                    { 383329857, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7311), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7312), "Drawings" },
                    { 398147889, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7280), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7282), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 178394164, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7958), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7959), "Meetings" },
                    { 204381308, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7911), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7913), "Communications" },
                    { 266081500, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7971), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7972), "Administration" },
                    { 566579125, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7932), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7933), "Printing" },
                    { 691198037, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7997), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7998), "Hours To Be Raised" },
                    { 879885197, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7945), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7947), "On-Site" },
                    { 987195710, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7984), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7985), "Soft Copy" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 157205405, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4565), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4566), "Dashboard Add Project", 6 },
                    { 195475492, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4519), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4520), "Dashboard Assign Designer", 3 },
                    { 231326162, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4419), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4420), "See Dashboard Layout", 1 },
                    { 241088757, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4658), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4659), "Display Projects Code", 13 },
                    { 452148670, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4645), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4646), "Add Project On Dashboard", 12 },
                    { 503875991, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4534), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4535), "Dashboard Assign Engineer", 4 },
                    { 512542014, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4632), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4633), "See All Projects", 11 },
                    { 572556270, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4499), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4501), "Dashboard Edit My Hours", 2 },
                    { 653318319, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4592), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4593), "Dashboard See My Hours", 8 },
                    { 659174320, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4605), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4606), "See All Disciplines", 9 },
                    { 892820114, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4619), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4620), "See All Drawings", 10 },
                    { 910355554, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4578), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4579), "See Admin Layout", 7 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[] { 920976458, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4550), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4552), "Dashboard Assign Project Manager", 5 });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 339709515, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6520), "Buildings Description", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6521), "Buildings" },
                    { 493940755, false, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6577), "Production Management Description", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6579), "Production Management" },
                    { 510093205, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6537), "Infrastructure Description", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6539), "Infrastructure" },
                    { 632032850, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6564), "Consulting Description", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6565), "Consulting" },
                    { 943064423, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6551), "Energy Description", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6552), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4746), false, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4748), "CEO" },
                    { 167194797, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4692), false, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4693), "Engineer" },
                    { 234744324, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4773), false, false, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4774), "Customer" },
                    { 238479469, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4705), false, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4706), "Project Manager" },
                    { 494449342, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4800), false, false, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4801), "Secretariat" },
                    { 583936668, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4760), false, false, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4761), "Guest" },
                    { 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4718), false, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4719), "COO" },
                    { 892504441, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4786), false, false, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4787), "Admin" },
                    { 976278891, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4672), false, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4673), "Designer" },
                    { 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4731), false, true, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4733), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6030), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6032), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6436), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6437), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 167914967, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5752), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5753), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6396), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6397), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5840), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5841), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5796), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5797), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6306), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6307), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6349), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6351), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6141), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6142), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6181), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6182), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5968), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5969), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 697943453, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5663), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5665), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 699546755, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5592), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5593), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 740572834, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5711), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5712), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6100), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6101), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6477), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6478), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6265), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6266), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6223), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6224), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5882), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5884), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5924), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5926), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 126275412, "agretos@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6155), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6156), 514227888 },
                    { 267017279, "kkotsoni@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6046), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6047), 146108222 },
                    { 267632569, "chkovras@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5939), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5940), 972251322 },
                    { 488338261, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6321), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6322), 413264475 },
                    { 488427165, "dtsa@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5725), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5726), 740572834 },
                    { 497886319, "embiria@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5614), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5615), 699546755 },
                    { 530097269, "xmanarolis@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5854), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5855), 364918508 },
                    { 585509441, "vpax@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5811), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5813), 408971458 },
                    { 620061672, "blekou@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6368), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6369), 452227970 },
                    { 640317231, "sparisis@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5897), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5899), 934181627 },
                    { 676687498, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6492), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6493), 824731343 },
                    { 698100500, "dtsa@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5767), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5768), 167914967 },
                    { 723117561, "kmargeti@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6196), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6198), 521324924 },
                    { 748576692, "panperivollari@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6450), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6451), 158905668 },
                    { 756903884, "vchontos@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6410), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6411), 358552869 },
                    { 780453622, "ngal@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5983), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5985), 531117701 },
                    { 783393275, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5630), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5632), 699546755 },
                    { 797668901, "vtza@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6114), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6115), 799203199 },
                    { 867372586, "pfokianou@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6279), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6281), 827337634 },
                    { 917277406, "gdoug@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5679), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5680), 697943453 },
                    { 973463675, "haris@embiria.gr", new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6237), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6238), 890906941 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 448279046, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), new DateTime(2024, 4, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Test Description Project_2", new DateTime(2024, 4, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 0f, new DateTime(2024, 4, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 1500L, 12L, 10000.0, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Project_1", 146108222, null, 339709515, 0f },
                    { 483792554, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), new DateTime(2024, 6, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Test Description Project_PM", new DateTime(2024, 4, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 0f, new DateTime(2024, 5, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 1500L, 12L, null, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Project_PM", null, null, 493940755, 0f },
                    { 592946383, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), new DateTime(2024, 12, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Test Description Project_3", new DateTime(2024, 12, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 0f, new DateTime(2024, 12, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 1500L, 12L, 10000.0, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Project_3", 146108222, null, 943064423, 0f },
                    { 644872025, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), new DateTime(2024, 7, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Test Description Project_8", new DateTime(2024, 7, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 0f, new DateTime(2024, 7, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 1500L, 12L, 10000.0, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Project_2", 146108222, null, 510093205, 0f },
                    { 720393496, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), new DateTime(2025, 7, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Test Description Project_4", new DateTime(2025, 7, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 0f, new DateTime(2025, 7, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), 1500L, 12L, 10000.0, new DateTime(2024, 3, 23, 18, 28, 51, 253, DateTimeKind.Local).AddTicks(3923), "Project_4", 146108222, null, 632032850, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 157205405, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5344), 1911234501, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5345) },
                    { 195475492, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5302), -1031133838, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5304) },
                    { 231326162, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5272), -785969068, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5273) },
                    { 241088757, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5397), 94749296, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5398) },
                    { 452148670, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5410), 757596272, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5412) },
                    { 503875991, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5316), -1488301321, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5317) },
                    { 512542014, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5384), 193333010, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5385) },
                    { 572556270, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5289), -542783344, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5290) },
                    { 659174320, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5357), 1511012381, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5358) },
                    { 892820114, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5370), -1733801773, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5372) },
                    { 920976458, 136929080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5329), -1893393058, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5331) },
                    { 195475492, 167194797, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4889), 1668087432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4891) },
                    { 231326162, 167194797, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4862), -1384783465, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4864) },
                    { 572556270, 167194797, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4876), -1651014481, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4877) },
                    { 653318319, 167194797, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4903), -618209725, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4904) },
                    { 659174320, 167194797, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4920), -1028114599, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4921) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 892820114, 167194797, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4933), 89714818, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4935) },
                    { 231326162, 234744324, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5438), -50232662, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5439) },
                    { 231326162, 238479469, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4948), -2114644076, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4949) },
                    { 503875991, 238479469, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4975), 489825383, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4976) },
                    { 572556270, 238479469, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4962), 1478658182, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4963) },
                    { 653318319, 238479469, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4988), -1986302546, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4989) },
                    { 659174320, 238479469, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5001), -1773729526, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5003) },
                    { 892820114, 238479469, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5015), -757975027, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5016) },
                    { 231326162, 494449342, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5507), -1149682414, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5508) },
                    { 512542014, 494449342, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5575), 608552753, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5576) },
                    { 572556270, 494449342, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5520), 87744119, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5521) },
                    { 653318319, 494449342, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5534), -1835386523, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5535) },
                    { 659174320, 494449342, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5547), -1300446805, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5549) },
                    { 892820114, 494449342, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5561), -2024465899, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5562) },
                    { 231326162, 583936668, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5424), -1263972122, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5426) },
                    { 195475492, 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5056), 2017866902, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5058) },
                    { 231326162, 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5028), 2124049730, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5029) },
                    { 503875991, 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5070), 831249788, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5071) },
                    { 512542014, 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5136), 1786605732, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5138) },
                    { 572556270, 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5042), -1304993861, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5043) },
                    { 653318319, 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5097), 1398459344, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5098) },
                    { 659174320, 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5110), 1282681265, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5111) },
                    { 892820114, 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5123), -2027731585, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5124) },
                    { 920976458, 716363860, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5084), 1326340854, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5085) },
                    { 512542014, 892504441, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5493), 128164042, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5494) },
                    { 659174320, 892504441, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5466), 1703908607, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5467) },
                    { 892820114, 892504441, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5480), -714956156, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5481) },
                    { 910355554, 892504441, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5451), -204455096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5453) },
                    { 231326162, 976278891, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4813), -894498155, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4815) },
                    { 572556270, 976278891, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4835), -1611418918, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4836) },
                    { 653318319, 976278891, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4849), -613750040, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(4850) },
                    { 157205405, 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5191), 1626062400, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5192) },
                    { 231326162, 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5149), -1377136781, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5150) },
                    { 452148670, 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5257), -1918673909, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5258) },
                    { 512542014, 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5244), -216657571, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5245) },
                    { 572556270, 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5164), -1719080864, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5165) },
                    { 653318319, 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5204), -618557539, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5205) },
                    { 659174320, 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5218), -33801965, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5219) },
                    { 892820114, 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5231), -2091438881, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5232) },
                    { 920976458, 997096806, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5177), 794423417, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5178) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 167194797, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6060), 596683398, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6061) },
                    { 238479469, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6607), 181702857, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6608) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 716363860, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6073), 868943747, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6074) },
                    { 997096806, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6086), 788564743, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6088) },
                    { 167194797, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6463), 194345133, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6465) },
                    { 976278891, 167914967, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5781), 236410827, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5783) },
                    { 167194797, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6423), 223771615, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6424) },
                    { 167194797, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5868), 155304607, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5869) },
                    { 167194797, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5825), 223796281, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5826) },
                    { 238479469, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6592), 120031515, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6593) },
                    { 167194797, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6335), 576944943, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6336) },
                    { 167194797, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6382), 542482929, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6384) },
                    { 167194797, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6168), 937952090, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6169) },
                    { 167194797, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6210), 386085536, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6211) },
                    { 136929080, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6011), 986937785, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6012) },
                    { 167194797, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5997), 407843528, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5998) },
                    { 976278891, 697943453, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5697), 419349319, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5698) },
                    { 494449342, 699546755, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5646), 437754059, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5647) },
                    { 976278891, 740572834, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5738), 296933073, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5740) },
                    { 167194797, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6128), 713774337, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6129) },
                    { 167194797, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6505), 957574608, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6506) },
                    { 167194797, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6293), 198623955, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6294) },
                    { 167194797, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6250), 155731702, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6251) },
                    { 238479469, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6621), 249029538, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6622) },
                    { 167194797, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5911), 496962507, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5912) },
                    { 167194797, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5954), 540389920, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(5955) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2132046200, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7187), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7188), 592946383, 813383881, null },
                    { -2113506624, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7158), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7159), 644872025, 722857861, null },
                    { -2069441072, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7211), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7213), 592946383, 297884286, null },
                    { -1425197432, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7252), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7254), 720393496, 566950448, null },
                    { -1338813928, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7097), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7098), 448279046, 436964624, null },
                    { -1277034808, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7239), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7240), 720393496, 493564746, null },
                    { -1171345704, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7146), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7147), 644872025, 180711141, null },
                    { -1099816176, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7199), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7200), 592946383, 566950448, null },
                    { -321705096, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7118), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7119), 448279046, 566950448, null },
                    { -147016080, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7265), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7266), 483792554, 809771443, null },
                    { 585104304, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7173), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7174), 644872025, 436964624, null },
                    { 1441300248, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7132), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7133), 448279046, 929830655, null },
                    { 1861421488, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7226), 0f, 500L, 0L, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7227), 720393496, 634031162, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 246215509, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6684), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6686), 3010.0, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6685), "Signature 142345", 50420, 448279046, 1.0, 17.0 },
                    { 777240031, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6793), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6795), 13000.0, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6794), "Signature 1423416", 45004, 720393496, 4.0, 24.0 },
                    { 799853059, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6762), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6764), 4000.0, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6763), "Signature 1423412", 56619, 592946383, 3.0, 17.0 },
                    { 922423006, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6729), new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6732), 3100.0, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(6731), "Signature 142344", 82695, 644872025, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2132046200, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(652), 553848362, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(654) },
                    { -2132046200, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(761), 891178970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(763) },
                    { -2132046200, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(749), 186668429, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(751) },
                    { -2132046200, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(604), 238002179, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(605) },
                    { -2132046200, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(591), 178824224, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(592) },
                    { -2132046200, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(725), 761051081, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(726) },
                    { -2132046200, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(737), 481729644, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(739) },
                    { -2132046200, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(677), 204717031, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(678) },
                    { -2132046200, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(689), 398748286, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(690) },
                    { -2132046200, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(640), 955064743, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(641) },
                    { -2132046200, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(664), 930853607, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(666) },
                    { -2132046200, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(773), 123744119, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(774) },
                    { -2132046200, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(713), 514087487, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(714) },
                    { -2132046200, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(701), 129784119, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(702) },
                    { -2132046200, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(616), 815317507, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(617) },
                    { -2132046200, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(628), 891781858, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(629) },
                    { -2113506624, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(239), 146857347, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(240) },
                    { -2113506624, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(348), 824716911, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(349) },
                    { -2113506624, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(336), 431464086, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(337) },
                    { -2113506624, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(188), 496583909, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(189) },
                    { -2113506624, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(151), 146069442, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(152) },
                    { -2113506624, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(312), 515942558, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(313) },
                    { -2113506624, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(324), 788170430, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(325) },
                    { -2113506624, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(263), 593852292, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(264) },
                    { -2113506624, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(276), 319776596, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(277) },
                    { -2113506624, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(227), 982273263, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(228) },
                    { -2113506624, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(251), 888292375, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(252) },
                    { -2113506624, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(360), 579508794, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(362) },
                    { -2113506624, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(300), 558930128, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(301) },
                    { -2113506624, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(288), 466588698, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(289) },
                    { -2113506624, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(201), 718399938, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(203) },
                    { -2113506624, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(214), 521099714, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(216) },
                    { -2069441072, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1068), 339359369, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1069) },
                    { -2069441072, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1177), 845369817, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1178) },
                    { -2069441072, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1165), 131594440, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1166) },
                    { -2069441072, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1019), 439988284, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1020) },
                    { -2069441072, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1005), 748659504, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1007) },
                    { -2069441072, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1141), 183209933, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1142) },
                    { -2069441072, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1153), 369070633, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1154) },
                    { -2069441072, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1093), 922414651, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1094) },
                    { -2069441072, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1105), 212373278, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1106) },
                    { -2069441072, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1056), 693034349, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1057) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2069441072, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1081), 827796614, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1082) },
                    { -2069441072, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1189), 304993426, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1190) },
                    { -2069441072, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1129), 424905979, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1130) },
                    { -2069441072, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1117), 626062343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1118) },
                    { -2069441072, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1031), 841839551, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1033) },
                    { -2069441072, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1044), 911814606, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1045) },
                    { -1425197432, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1706), 999363307, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1707) },
                    { -1425197432, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1818), 727758970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1819) },
                    { -1425197432, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1805), 143026049, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1806) },
                    { -1425197432, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1628), 203946129, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1629) },
                    { -1425197432, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1616), 436481008, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1617) },
                    { -1425197432, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1781), 695173054, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1782) },
                    { -1425197432, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1793), 558102953, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1794) },
                    { -1425197432, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1731), 878137210, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1732) },
                    { -1425197432, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1744), 499154061, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1745) },
                    { -1425197432, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1664), 707134195, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1665) },
                    { -1425197432, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1719), 905195372, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1720) },
                    { -1425197432, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1830), 767674529, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1831) },
                    { -1425197432, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1769), 510730527, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1770) },
                    { -1425197432, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1756), 328471686, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1757) },
                    { -1425197432, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1640), 579783990, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1641) },
                    { -1425197432, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1652), 580847098, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1653) },
                    { -1338813928, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9376), 797093765, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9377) },
                    { -1338813928, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9511), 696484219, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9512) },
                    { -1338813928, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9499), 765926870, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9500) },
                    { -1338813928, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9326), 693708008, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9327) },
                    { -1338813928, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9305), 651708847, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9306) },
                    { -1338813928, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9475), 247223009, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9476) },
                    { -1338813928, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9487), 218458614, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9488) },
                    { -1338813928, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9401), 837945896, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9402) },
                    { -1338813928, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9414), 658406268, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9415) },
                    { -1338813928, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9363), 439177373, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9364) },
                    { -1338813928, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9389), 671550625, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9390) },
                    { -1338813928, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9523), 128611161, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9524) },
                    { -1338813928, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9463), 647356664, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9464) },
                    { -1338813928, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9427), 287125486, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9428) },
                    { -1338813928, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9338), 705148794, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9340) },
                    { -1338813928, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9351), 757835071, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9352) },
                    { -1277034808, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1483), 356467182, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1484) },
                    { -1277034808, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1592), 897315508, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1593) },
                    { -1277034808, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1579), 466336216, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1581) },
                    { -1277034808, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1434), 917382519, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1435) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1277034808, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1422), 605854460, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1423) },
                    { -1277034808, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1555), 268194808, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1556) },
                    { -1277034808, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1567), 618937143, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1568) },
                    { -1277034808, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1507), 666364097, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1508) },
                    { -1277034808, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1519), 926963551, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1520) },
                    { -1277034808, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1470), 511567953, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1472) },
                    { -1277034808, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1495), 281455363, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1496) },
                    { -1277034808, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1604), 535996552, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1605) },
                    { -1277034808, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1543), 676061289, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1544) },
                    { -1277034808, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1531), 950192540, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1532) },
                    { -1277034808, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1446), 525745253, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1447) },
                    { -1277034808, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1458), 528928939, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1459) },
                    { -1171345704, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(17), 978117352, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(19) },
                    { -1171345704, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(127), 766291797, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(128) },
                    { -1171345704, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(114), 473069283, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(116) },
                    { -1171345704, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9969), 670001917, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9970) },
                    { -1171345704, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9957), 275000532, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9958) },
                    { -1171345704, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(90), 341989523, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(91) },
                    { -1171345704, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(103), 125657493, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(104) },
                    { -1171345704, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(42), 946314667, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(43) },
                    { -1171345704, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(54), 390802686, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(55) },
                    { -1171345704, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(5), 292785902, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(6) },
                    { -1171345704, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(30), 430612500, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(31) },
                    { -1171345704, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(139), 980041711, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(140) },
                    { -1171345704, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(78), 931024596, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(79) },
                    { -1171345704, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(66), 890149552, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(67) },
                    { -1171345704, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9981), 416842986, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9982) },
                    { -1171345704, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9993), 357341716, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9994) },
                    { -1099816176, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(848), 156781820, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(849) },
                    { -1099816176, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(957), 428117490, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(958) },
                    { -1099816176, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(945), 954653640, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(946) },
                    { -1099816176, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(798), 174830235, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(800) },
                    { -1099816176, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(786), 516356797, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(787) },
                    { -1099816176, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(920), 924908701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(921) },
                    { -1099816176, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(932), 813510048, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(933) },
                    { -1099816176, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(872), 602779445, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(873) },
                    { -1099816176, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(884), 241666962, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(885) },
                    { -1099816176, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(835), 217600135, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(837) },
                    { -1099816176, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(860), 791912175, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(861) },
                    { -1099816176, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(992), 339429993, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(993) },
                    { -1099816176, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(908), 665693781, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(909) },
                    { -1099816176, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(896), 227487807, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(897) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1099816176, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(811), 888724193, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(812) },
                    { -1099816176, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(824), 525609639, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(825) },
                    { -321705096, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9598), 555841510, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9599) },
                    { -321705096, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9707), 629972315, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9708) },
                    { -321705096, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9695), 504193938, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9696) },
                    { -321705096, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9549), 636251846, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9551) },
                    { -321705096, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9536), 157033408, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9537) },
                    { -321705096, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9670), 341469142, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9671) },
                    { -321705096, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9683), 758543057, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9684) },
                    { -321705096, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9622), 473354982, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9623) },
                    { -321705096, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9634), 425901083, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9635) },
                    { -321705096, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9586), 176309717, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9587) },
                    { -321705096, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9610), 967049581, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9611) },
                    { -321705096, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9719), 144629418, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9720) },
                    { -321705096, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9658), 890699011, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9660) },
                    { -321705096, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9646), 712720587, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9648) },
                    { -321705096, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9562), 548865426, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9563) },
                    { -321705096, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9574), 757045519, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9575) },
                    { 585104304, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(433), 217236629, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(434) },
                    { 585104304, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(542), 981364934, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(543) },
                    { 585104304, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(530), 358564278, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(531) },
                    { 585104304, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(385), 485401046, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(386) },
                    { 585104304, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(373), 994154968, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(374) },
                    { 585104304, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(505), 689056965, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(507) },
                    { 585104304, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(518), 834033565, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(519) },
                    { 585104304, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(457), 622955350, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(458) },
                    { 585104304, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(469), 907803896, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(471) },
                    { 585104304, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(421), 363128606, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(422) },
                    { 585104304, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(445), 180259996, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(446) },
                    { 585104304, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(554), 151418160, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(555) },
                    { 585104304, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(493), 533554785, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(494) },
                    { 585104304, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(481), 707398796, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(483) },
                    { 585104304, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(397), 344362208, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(398) },
                    { 585104304, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(409), 976453498, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(410) },
                    { 1441300248, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9793), 531026671, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9794) },
                    { 1441300248, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9932), 621678019, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9933) },
                    { 1441300248, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9919), 742402942, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9921) },
                    { 1441300248, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9744), 732920063, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9745) },
                    { 1441300248, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9731), 905639238, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9732) },
                    { 1441300248, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9895), 281838507, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9896) },
                    { 1441300248, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9907), 360250783, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9908) },
                    { 1441300248, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9845), 338495651, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9846) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1441300248, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9858), 464899308, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9859) },
                    { 1441300248, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9781), 369115152, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9782) },
                    { 1441300248, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9832), 243325574, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9833) },
                    { 1441300248, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9944), 876235476, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9945) },
                    { 1441300248, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9883), 872405614, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9884) },
                    { 1441300248, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9870), 162564185, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9871) },
                    { 1441300248, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9757), 222327932, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9758) },
                    { 1441300248, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9769), 478040585, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9770) },
                    { 1861421488, 146108222, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1262), 444552062, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1263) },
                    { 1861421488, 158905668, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1397), 968037860, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1398) },
                    { 1861421488, 358552869, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1385), 591867002, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1386) },
                    { 1861421488, 364918508, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1214), 794650484, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1215) },
                    { 1861421488, 408971458, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1201), 983623104, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1203) },
                    { 1861421488, 413264475, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1360), 302327282, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1361) },
                    { 1861421488, 452227970, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1373), 205655196, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1374) },
                    { 1861421488, 514227888, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1310), 735596097, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1311) },
                    { 1861421488, 521324924, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1322), 619803069, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1323) },
                    { 1861421488, 531117701, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1249), 773808258, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1250) },
                    { 1861421488, 799203199, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1297), 874378071, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1299) },
                    { 1861421488, 824731343, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1409), 248159205, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1411) },
                    { 1861421488, 827337634, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1347), 931809672, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1348) },
                    { 1861421488, 890906941, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1334), 497896419, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1335) },
                    { 1861421488, 934181627, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1226), 206869625, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1227) },
                    { 1861421488, 972251322, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1237), 383986962, new DateTime(2024, 3, 23, 18, 28, 51, 264, DateTimeKind.Local).AddTicks(1239) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 144612771, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7601), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7599), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7600), 398147889 },
                    { 150064965, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7514), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7511), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7513), 398147889 },
                    { 161687204, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7412), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7410), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7411), 383329857 },
                    { 228739858, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7543), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7540), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7541), 383329857 },
                    { 293743756, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7487), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7484), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7485), 238957590 },
                    { 311158978, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7703), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7700), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7702), 238957590 },
                    { 322532413, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7751), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7749), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7750), 238957590 },
                    { 326679170, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7884), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7882), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7883), 238957590 },
                    { 343673370, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7854), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7851), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7853), 383329857 },
                    { 367518259, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7645), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7642), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7643), 398147889 },
                    { 392035245, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7780), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7777), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7778), 398147889 },
                    { 403984604, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7897), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7895), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7896), 383329857 },
                    { 440276457, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7587), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7584), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7585), 383329857 },
                    { 443656862, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7809), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7806), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7807), 383329857 },
                    { 443729323, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7366), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7363), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7365), 383329857 },
                    { 519434096, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7737), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7734), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7736), 398147889 },
                    { 539034161, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7473), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7470), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7471), 398147889 },
                    { 544459507, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7500), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7497), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7498), 383329857 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 587885259, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7869), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7866), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7868), 398147889 },
                    { 603290479, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7557), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7555), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7556), 398147889 },
                    { 638819847, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7442), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7439), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7440), 238957590 },
                    { 649272753, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7528), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7526), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7527), 238957590 },
                    { 655616058, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7615), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7613), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7614), 238957590 },
                    { 673816257, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7688), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7686), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7687), 398147889 },
                    { 688524338, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7840), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7837), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7838), 238957590 },
                    { 699250150, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7396), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7393), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7394), 238957590 },
                    { 724039901, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7329), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7326), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7327), 398147889 },
                    { 742301274, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7427), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7425), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7426), 398147889 },
                    { 754053603, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7766), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7763), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7764), 383329857 },
                    { 763438036, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7825), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7822), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7824), 398147889 },
                    { 807318291, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7659), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7656), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7658), 238957590 },
                    { 860684878, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7571), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7569), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7570), 238957590 },
                    { 863585376, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7630), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7627), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7628), 383329857 },
                    { 869197276, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7348), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7345), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7346), 238957590 },
                    { 887337420, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7674), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7671), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7673), 383329857 },
                    { 910274165, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7456), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7453), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7455), 383329857 },
                    { 942052852, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7794), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7791), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7793), 238957590 },
                    { 968873279, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7723), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7720), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7721), 383329857 },
                    { 974961691, new DateTime(2024, 4, 3, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7381), 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7378), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(7380), 398147889 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 131039537, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8976), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8977), 178394164 },
                    { 153935767, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8531), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8532), 566579125 },
                    { 185337735, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8457), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8458), 879885197 },
                    { 194488797, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8579), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8580), 987195710 },
                    { 212421155, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8818), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8820), 266081500 },
                    { 245121578, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8604), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8606), 204381308 },
                    { 245750824, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9096), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9097), 266081500 },
                    { 249892929, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8169), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8170), 566579125 },
                    { 275137757, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8219), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8220), 987195710 },
                    { 276886384, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8469), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8470), 178394164 },
                    { 286010593, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8395), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8396), 987195710 },
                    { 290819272, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8806), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8807), 178394164 },
                    { 291822699, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8641), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8642), 178394164 },
                    { 293069725, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8544), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8545), 879885197 },
                    { 294153020, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8617), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8618), 566579125 },
                    { 296683527, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8346), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8347), 566579125 },
                    { 304000532, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8144), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8145), 691198037 },
                    { 318557639, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8902), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8903), 266081500 },
                    { 318848892, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8782), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8784), 566579125 },
                    { 336022221, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8653), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8654), 266081500 },
                    { 342390747, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8855), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8856), 204381308 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 343923150, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8256), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8257), 566579125 },
                    { 344245447, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9204), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9205), 691198037 },
                    { 349450008, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9280), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9281), 987195710 },
                    { 353273093, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8195), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8196), 178394164 },
                    { 356188351, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9268), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9269), 266081500 },
                    { 378285591, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8843), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8844), 691198037 },
                    { 378533848, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8281), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8282), 178394164 },
                    { 395838225, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8519), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8520), 204381308 },
                    { 401066682, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8494), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8495), 987195710 },
                    { 419114111, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8555), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8556), 178394164 },
                    { 433598311, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9157), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9158), 879885197 },
                    { 436799951, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9000), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9001), 987195710 },
                    { 441584045, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9218), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9219), 204381308 },
                    { 465831248, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8507), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8508), 691198037 },
                    { 467240081, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9133), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9134), 204381308 },
                    { 468981118, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8891), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8892), 178394164 },
                    { 471112495, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8305), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8307), 987195710 },
                    { 492107524, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8567), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8568), 266081500 },
                    { 532093400, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8358), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8359), 879885197 },
                    { 540070093, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8419), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8420), 204381308 },
                    { 540839954, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8950), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8951), 566579125 },
                    { 547881812, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8118), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8119), 266081500 },
                    { 548226059, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8131), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8132), 987195710 },
                    { 551089838, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8182), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8183), 879885197 },
                    { 564016783, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8443), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8445), 566579125 },
                    { 575013990, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9024), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9025), 204381308 },
                    { 575583363, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9121), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9122), 691198037 },
                    { 579909060, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9169), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9170), 178394164 },
                    { 581987642, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8988), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8989), 266081500 },
                    { 584675562, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8206), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8208), 266081500 },
                    { 587726063, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8926), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8927), 691198037 },
                    { 600881242, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9108), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9109), 987195710 },
                    { 608288320, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8664), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8666), 987195710 },
                    { 615183702, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9256), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9257), 178394164 },
                    { 638758454, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9145), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9146), 566579125 },
                    { 666168901, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8771), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8772), 204381308 },
                    { 689946951, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8106), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8107), 178394164 },
                    { 694406823, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8629), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8630), 879885197 },
                    { 696028200, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9012), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9013), 691198037 },
                    { 702682830, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8382), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8384), 266081500 },
                    { 720585786, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8406), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8407), 691198037 },
                    { 739544055, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9193), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9194), 987195710 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 752923913, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8293), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8295), 266081500 },
                    { 753511779, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9244), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9245), 879885197 },
                    { 756659700, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8795), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8796), 879885197 },
                    { 772656157, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8879), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8880), 879885197 },
                    { 787633055, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8156), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8158), 204381308 },
                    { 802319446, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8938), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8939), 204381308 },
                    { 807942270, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9232), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9233), 566579125 },
                    { 827515879, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8268), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8269), 879885197 },
                    { 839728039, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9181), -1425197432, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9182), 266081500 },
                    { 859946430, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8371), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8372), 178394164 },
                    { 861789934, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8591), 585104304, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8593), 691198037 },
                    { 862065276, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8867), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8868), 566579125 },
                    { 864823988, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9083), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9084), 178394164 },
                    { 870097551, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8914), -2069441072, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8915), 987195710 },
                    { 875158139, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8481), -2113506624, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8482), 266081500 },
                    { 890954856, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8244), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8245), 204381308 },
                    { 894559849, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8231), -321705096, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8232), 691198037 },
                    { 908936233, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8029), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8030), 566579125 },
                    { 917823323, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9292), -147016080, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9293), 691198037 },
                    { 925890097, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8756), -2132046200, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8757), 691198037 },
                    { 934016339, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8831), -1099816176, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8832), 987195710 },
                    { 935763731, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8963), 1861421488, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8964), 879885197 },
                    { 943598676, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8330), -1171345704, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8331), 204381308 },
                    { 948427103, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8317), 1441300248, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8319), 691198037 },
                    { 957847699, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8093), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8094), 879885197 },
                    { 976006615, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8011), -1338813928, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(8012), 204381308 },
                    { 979342886, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9047), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9049), 879885197 },
                    { 979786059, 0f, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9036), -1277034808, new DateTime(2024, 3, 23, 18, 28, 51, 263, DateTimeKind.Local).AddTicks(9037), 566579125 }
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
