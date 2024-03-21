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
                    { 161488550, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9131), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9132), "Potable Water" },
                    { 269340934, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9292), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9294), "Outsource" },
                    { 285383472, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9098), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9099), "HVAC" },
                    { 319576669, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9155), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9156), "Fire Detection" },
                    { 323637922, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9143), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9144), "Drainage" },
                    { 339668000, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9243), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9244), "CCTV" },
                    { 355578190, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9219), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9220), "Structured Cabling" },
                    { 408038541, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9268), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9269), "Photovoltaics" },
                    { 424189563, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9279), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9280), "Energy Efficiency" },
                    { 425090104, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9305), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9306), "TenderDocument" },
                    { 478269732, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9169), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9170), "Fire Suppression" },
                    { 509232911, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9256), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9257), "BMS" },
                    { 535936180, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9193), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9194), "Natural Gas" },
                    { 545998069, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9333), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9335), "Project Manager Hours" },
                    { 733783374, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9118), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9119), "Sewage" },
                    { 775937231, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9320), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9321), "Construction Supervision" },
                    { 824624628, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9231), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9233), "Burglar Alarm" },
                    { 903985154, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9205), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9206), "Power Distribution" },
                    { 917543510, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9181), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9182), "Elevators" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 446299172, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9556), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9557), "Documents" },
                    { 489535757, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9588), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9589), "Drawings" },
                    { 880492614, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9574), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9576), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 128478450, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(239), new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(240), "Meetings" },
                    { 658574611, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(252), new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(253), "Administration" },
                    { 818485978, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(212), new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(214), "Printing" },
                    { 888841437, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(190), new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(191), "Communications" },
                    { 950257540, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(226), new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(227), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 156692506, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6717), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6719), "Dashboard Assign Designer", 3 },
                    { 224193589, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6774), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6775), "See Admin Layout", 7 },
                    { 257927613, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6702), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6703), "Dashboard Edit My Hours", 2 },
                    { 347932684, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6745), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6747), "Dashboard Assign Project Manager", 5 },
                    { 367003879, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6829), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6830), "See All Projects", 11 },
                    { 429210054, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6599), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6600), "See Dashboard Layout", 1 },
                    { 525433834, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6843), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6844), "Add Project On Dashboard", 12 },
                    { 571149074, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6731), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6733), "Dashboard Assign Engineer", 4 },
                    { 575040475, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6857), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6858), "Display Projects Code", 13 },
                    { 616376095, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6815), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6816), "See All Drawings", 10 },
                    { 823741407, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6800), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6802), "See All Disciplines", 9 },
                    { 875231031, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6761), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6762), "Dashboard Add Project", 6 },
                    { 948884916, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6787), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6789), "Dashboard See My Hours", 8 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 149809442, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8787), "Buildings Description", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8788), "Buildings" },
                    { 186107087, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8814), "Energy Description", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8816), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 413843233, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8801), "Infrastructure Description", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8802), "Infrastructure" },
                    { 440649725, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8828), "Consulting Description", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8830), "Consulting" },
                    { 725593025, false, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8842), "Production Management Description", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8843), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6936), false, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6938), "CTO" },
                    { 236710271, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6977), false, false, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6978), "Customer" },
                    { 469860976, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6895), false, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6896), "Engineer" },
                    { 587181750, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6990), false, false, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6992), "Admin" },
                    { 684202807, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6871), false, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6872), "Designer" },
                    { 730600529, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7004), false, false, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7006), "Secretariat" },
                    { 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6951), false, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6952), "CEO" },
                    { 835361981, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6909), false, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6910), "Project Manager" },
                    { 900888658, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6964), false, false, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6965), "Guest" },
                    { 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6923), false, true, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(6924), "COO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8742), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8743), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8045), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8046), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8569), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8570), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8438), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8439), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8395), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8396), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8094), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8095), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8483), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8484), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8138), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8140), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8226), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8227), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8613), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8614), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 484107891, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7953), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7954), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 484509856, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7907), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7908), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8353), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8354), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 524142460, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7830), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7831), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 595031365, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7998), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8000), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8183), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8184), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8657), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8658), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8284), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8286), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8699), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8700), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8526), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8527), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 200003709, "dtsa@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7968), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7970), 484107891 },
                    { 214388119, "kkotsoni@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8299), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8300), 871267311 },
                    { 266779608, "sparisis@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8153), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8155), 344128236 },
                    { 281490547, "dtsa@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8014), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8015), 595031365 },
                    { 374944010, "kmargeti@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8456), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8457), 211445836 },
                    { 380219631, "embiria@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7851), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7853), 524142460 },
                    { 410499140, "vpax@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8062), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8063), 162907081 },
                    { 432986704, "blekou@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8628), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8630), 387388705 },
                    { 445958688, "panperivollari@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8713), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8714), 879294169 },
                    { 463091875, "pfokianou@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8541), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8542), 886867167 },
                    { 483297249, "chkovras@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8197), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8198), 684362969 },
                    { 542388663, "vchontos@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8671), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8672), 786031254 },
                    { 545524258, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8756), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8757), 127501926 },
                    { 622737197, "vtza@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8367), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8368), 501376163 },
                    { 690418765, "xmanarolis@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8109), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8111), 296359945 },
                    { 795496177, "ngal@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8241), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8242), 383923327 },
                    { 837563057, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7872), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7874), 524142460 },
                    { 878572670, "agretos@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8408), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8410), 247957789 },
                    { 933286221, "gdoug@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7923), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7925), 484509856 },
                    { 957030750, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8583), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8585), 181360261 },
                    { 993976676, "haris@embiria.gr", new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8498), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8499), 325633098 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 157041028, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), new DateTime(2024, 7, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Test Description Project_4", new DateTime(2024, 7, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 0f, new DateTime(2024, 7, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Project_2", 871267311, null, 413843233, 0f },
                    { 405870683, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), new DateTime(2024, 4, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Test Description Project_6", new DateTime(2024, 4, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 0f, new DateTime(2024, 4, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Project_1", 871267311, null, 149809442, 0f },
                    { 475827744, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), new DateTime(2024, 6, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Test Description Project_PM", new DateTime(2024, 4, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 0f, new DateTime(2024, 5, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 1500L, 12L, null, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Project_PM", null, null, 725593025, 0f },
                    { 532811110, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), new DateTime(2025, 7, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Test Description Project_12", new DateTime(2025, 7, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 0f, new DateTime(2025, 7, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Project_4", 871267311, null, 440649725, 0f },
                    { 605636508, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), new DateTime(2024, 12, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Test Description Project_3", new DateTime(2024, 12, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 0f, new DateTime(2024, 12, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 20, 55, 7, 446, DateTimeKind.Local).AddTicks(8296), "Project_3", 871267311, null, 186107087, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 257927613, 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7382), -346213993, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7383) },
                    { 347932684, 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7396), -272149784, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7397) },
                    { 367003879, 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7465), -1721832709, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7466) },
                    { 429210054, 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7368), 1021575911, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7369) },
                    { 525433834, 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7479), -1601168363, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7480) },
                    { 616376095, 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7451), 462518591, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7452) },
                    { 823741407, 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7437), -107704201, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7439) },
                    { 875231031, 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7410), 558202451, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7411) },
                    { 948884916, 190217945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7424), -362988715, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7425) },
                    { 429210054, 236710271, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7663), 1148545764, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7664) },
                    { 156692506, 469860976, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7099), 938429753, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7100) },
                    { 257927613, 469860976, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7084), 79696324, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7085) },
                    { 429210054, 469860976, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7069), -571930055, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7071) },
                    { 616376095, 469860976, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7141), 2008031180, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7142) },
                    { 823741407, 469860976, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7127), -96236315, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7128) },
                    { 948884916, 469860976, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7113), -707043208, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7114) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 224193589, 587181750, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7677), 1565318106, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7678) },
                    { 367003879, 587181750, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7722), -649165612, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7723) },
                    { 616376095, 587181750, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7707), 75408202, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7708) },
                    { 823741407, 587181750, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7693), -1650440924, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7694) },
                    { 257927613, 684202807, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7042), 165700828, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7043) },
                    { 429210054, 684202807, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7018), -115908754, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7019) },
                    { 948884916, 684202807, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7055), -1662589088, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7057) },
                    { 257927613, 730600529, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7751), 367840589, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7752) },
                    { 367003879, 730600529, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7811), 1433370078, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7812) },
                    { 429210054, 730600529, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7736), 1044490838, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7738) },
                    { 616376095, 730600529, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7796), -105689983, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7797) },
                    { 823741407, 730600529, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7781), -1261752461, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7782) },
                    { 948884916, 730600529, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7766), -1082019244, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7768) },
                    { 156692506, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7523), 1674976293, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7524) },
                    { 257927613, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7510), -387955601, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7511) },
                    { 347932684, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7553), -2046015161, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7554) },
                    { 367003879, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7608), 1307381994, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7610) },
                    { 429210054, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7494), -1894326907, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7495) },
                    { 525433834, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7636), 491462681, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7637) },
                    { 571149074, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7539), -1117086097, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7540) },
                    { 575040475, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7622), -287138344, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7623) },
                    { 616376095, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7594), -548550242, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7595) },
                    { 823741407, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7580), 1825524536, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7582) },
                    { 875231031, 781153521, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7566), -1715613083, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7568) },
                    { 257927613, 835361981, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7170), 834721682, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7171) },
                    { 429210054, 835361981, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7155), -711246671, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7157) },
                    { 571149074, 835361981, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7183), 226628546, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7185) },
                    { 616376095, 835361981, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7224), -689586583, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7225) },
                    { 823741407, 835361981, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7211), -1953120302, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7212) },
                    { 948884916, 835361981, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7197), 296807432, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7198) },
                    { 429210054, 900888658, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7649), -718663180, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7651) },
                    { 156692506, 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7266), -1910025602, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7268) },
                    { 257927613, 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7251), -284588108, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7253) },
                    { 347932684, 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7298), -837719554, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7300) },
                    { 367003879, 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7354), -110681383, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7355) },
                    { 429210054, 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7238), -710462398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7239) },
                    { 571149074, 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7284), 2137582215, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7286) },
                    { 616376095, 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7340), -805308110, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7341) },
                    { 823741407, 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7326), -2022117610, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7327) },
                    { 948884916, 918293398, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7312), 1907431920, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7313) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 469860976, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8772), 226738281, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8774) },
                    { 469860976, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8076), 739342340, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8078) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 835361981, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8857), 83619045, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8859) },
                    { 469860976, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8598), 413776925, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8600) },
                    { 469860976, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8470), 287403672, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8471) },
                    { 469860976, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8422), 807349395, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8423) },
                    { 469860976, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8124), 686601722, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8125) },
                    { 469860976, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8511), 774038504, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8512) },
                    { 835361981, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8886), 281681831, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8887) },
                    { 469860976, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8168), 929689717, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8169) },
                    { 469860976, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8255), 861292846, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8257) },
                    { 781153521, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8270), 831404694, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8271) },
                    { 469860976, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8643), 909869945, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8644) },
                    { 684202807, 484107891, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7983), 521188626, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7984) },
                    { 684202807, 484509856, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7938), 508148792, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7939) },
                    { 469860976, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8381), 807237147, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8382) },
                    { 730600529, 524142460, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7889), 169452609, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(7890) },
                    { 684202807, 595031365, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8029), 998384421, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8031) },
                    { 469860976, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8212), 144692793, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8213) },
                    { 469860976, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8685), 943475002, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8686) },
                    { 190217945, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8339), 838806333, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8340) },
                    { 469860976, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8312), 223301045, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8313) },
                    { 835361981, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8872), 203903890, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8873) },
                    { 918293398, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8326), 309329222, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8327) },
                    { 469860976, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8727), 452651055, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8729) },
                    { 469860976, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8555), 145524137, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8556) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1833950136, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9513), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9514), 532811110, 509232911, null },
                    { -1796054160, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9362), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9363), 405870683, 824624628, null },
                    { -1202086344, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9540), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9541), 475827744, 545998069, null },
                    { -1050571968, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9526), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9527), 532811110, 319576669, null },
                    { -929987592, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9457), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9458), 605636508, 424189563, null },
                    { -868149912, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9499), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9500), 532811110, 269340934, null },
                    { 130674256, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9484), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9485), 605636508, 285383472, null },
                    { 188907168, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9426), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9427), 157041028, 161488550, null },
                    { 599921328, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9384), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9386), 405870683, 323637922, null },
                    { 1040762080, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9441), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9442), 157041028, 535936180, null },
                    { 1346574080, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9413), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9414), 157041028, 509232911, null },
                    { 1828411032, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9399), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9400), 405870683, 733783374, null },
                    { 1965421808, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9471), 0f, 500L, 0L, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9472), 605636508, 509232911, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 297574018, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9001), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9003), 3100.0, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9002), "Signature 142342", 43137, 157041028, 2.0, 24.0 },
                    { 344217702, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9064), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9066), 13000.0, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9065), "Signature 1423416", 65234, 532811110, 4.0, 24.0 },
                    { 426673732, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9033), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9035), 4000.0, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9034), "Signature 1423415", 59363, 605636508, 3.0, 17.0 },
                    { 489404519, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8962), new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8964), 3010.0, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(8963), "Signature 142346", 43563, 405870683, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1833950136, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3366), 416237709, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3367) },
                    { -1833950136, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3180), 363286153, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3181) },
                    { -1833950136, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3316), 177231521, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3317) },
                    { -1833950136, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3277), 802480718, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3278) },
                    { -1833950136, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3265), 627178367, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3266) },
                    { -1833950136, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3193), 136800092, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3194) },
                    { -1833950136, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3290), 187199627, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3291) },
                    { -1833950136, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3205), 774967849, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3206) },
                    { -1833950136, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3229), 634475597, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3230) },
                    { -1833950136, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3329), 687154054, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3330) },
                    { -1833950136, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3253), 732426613, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3254) },
                    { -1833950136, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3217), 968005018, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3218) },
                    { -1833950136, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3341), 894163949, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3342) },
                    { -1833950136, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3241), 929444564, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3242) },
                    { -1833950136, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3354), 263533268, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3355) },
                    { -1833950136, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3302), 173435593, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3303) },
                    { -1796054160, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1381), 844059534, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1382) },
                    { -1796054160, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1183), 545518626, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1184) },
                    { -1796054160, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1331), 605578340, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1332) },
                    { -1796054160, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1292), 632437769, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1293) },
                    { -1796054160, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1280), 223070262, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1281) },
                    { -1796054160, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1203), 754700881, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1204) },
                    { -1796054160, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1305), 764236299, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1307) },
                    { -1796054160, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1216), 834014719, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1218) },
                    { -1796054160, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1241), 612006086, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1243) },
                    { -1796054160, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1343), 389638741, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1344) },
                    { -1796054160, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1268), 739488412, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1269) },
                    { -1796054160, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1229), 524090334, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1230) },
                    { -1796054160, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1355), 798044785, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1356) },
                    { -1796054160, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1255), 348026688, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1256) },
                    { -1796054160, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1368), 821978950, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1370) },
                    { -1796054160, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1318), 701743929, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1319) },
                    { -1050571968, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3560), 719187493, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3561) },
                    { -1050571968, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3378), 656164822, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3379) },
                    { -1050571968, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3511), 270209994, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3512) },
                    { -1050571968, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3475), 698360458, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3476) },
                    { -1050571968, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3463), 688784854, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3464) },
                    { -1050571968, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3390), 511434007, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3391) },
                    { -1050571968, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3487), 624046591, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3488) },
                    { -1050571968, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3402), 728940840, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3403) },
                    { -1050571968, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3427), 354905252, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3428) },
                    { -1050571968, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3523), 125895588, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3525) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1050571968, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3451), 931252388, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3452) },
                    { -1050571968, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3415), 225555247, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3416) },
                    { -1050571968, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3536), 213098275, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3537) },
                    { -1050571968, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3439), 190301348, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3440) },
                    { -1050571968, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3548), 436706724, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3549) },
                    { -1050571968, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3499), 977939764, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3500) },
                    { -929987592, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2576), 431946457, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2577) },
                    { -929987592, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2394), 701808440, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2395) },
                    { -929987592, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2528), 954028816, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2529) },
                    { -929987592, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2491), 308233311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2492) },
                    { -929987592, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2479), 544592509, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2480) },
                    { -929987592, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2406), 223803503, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2407) },
                    { -929987592, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2503), 583675883, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2504) },
                    { -929987592, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2418), 466292998, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2419) },
                    { -929987592, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2443), 756942340, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2444) },
                    { -929987592, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2540), 688497877, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2541) },
                    { -929987592, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2467), 877971911, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2468) },
                    { -929987592, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2430), 833104726, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2431) },
                    { -929987592, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2552), 362414158, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2553) },
                    { -929987592, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2455), 949979154, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2456) },
                    { -929987592, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2564), 622654164, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2565) },
                    { -929987592, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2515), 714782813, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2517) },
                    { -868149912, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3168), 499887996, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3169) },
                    { -868149912, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2986), 746654745, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2987) },
                    { -868149912, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3120), 259260198, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3121) },
                    { -868149912, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3083), 498905878, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3085) },
                    { -868149912, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3071), 916935361, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3072) },
                    { -868149912, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2998), 633059880, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2999) },
                    { -868149912, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3096), 780190794, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3097) },
                    { -868149912, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3010), 899583311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3011) },
                    { -868149912, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3035), 186043615, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3036) },
                    { -868149912, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3132), 421961324, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3133) },
                    { -868149912, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3059), 530606864, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3060) },
                    { -868149912, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3022), 801104873, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3023) },
                    { -868149912, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3144), 606945135, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3145) },
                    { -868149912, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3047), 286738927, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3048) },
                    { -868149912, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3156), 168474886, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3157) },
                    { -868149912, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3108), 498174194, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(3109) },
                    { 130674256, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2973), 207552740, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2975) },
                    { 130674256, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2787), 469886958, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2788) },
                    { 130674256, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2923), 705285160, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2924) },
                    { 130674256, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2886), 142750372, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2887) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 130674256, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2874), 974973612, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2875) },
                    { 130674256, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2801), 514477274, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2802) },
                    { 130674256, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2898), 894930914, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2899) },
                    { 130674256, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2813), 191688929, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2814) },
                    { 130674256, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2838), 623203946, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2839) },
                    { 130674256, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2937), 650959246, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2938) },
                    { 130674256, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2862), 186987958, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2863) },
                    { 130674256, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2826), 490346502, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2827) },
                    { 130674256, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2949), 357001603, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2950) },
                    { 130674256, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2850), 196226826, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2851) },
                    { 130674256, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2961), 251992210, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2962) },
                    { 130674256, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2910), 630328166, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2911) },
                    { 188907168, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2183), 212634392, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2184) },
                    { 188907168, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1996), 605420829, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1997) },
                    { 188907168, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2134), 650254220, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2135) },
                    { 188907168, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2096), 215853213, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2097) },
                    { 188907168, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2084), 713744504, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2085) },
                    { 188907168, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2009), 828909013, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2010) },
                    { 188907168, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2109), 969717852, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2110) },
                    { 188907168, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2021), 183341010, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2023) },
                    { 188907168, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2046), 167553966, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2047) },
                    { 188907168, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2146), 474745716, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2147) },
                    { 188907168, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2071), 518469219, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2072) },
                    { 188907168, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2034), 267969967, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2035) },
                    { 188907168, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2158), 772142321, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2159) },
                    { 188907168, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2059), 167397149, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2060) },
                    { 188907168, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2171), 368505163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2172) },
                    { 188907168, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2121), 785044030, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2122) },
                    { 599921328, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1583), 582609053, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1584) },
                    { 599921328, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1394), 213951498, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1395) },
                    { 599921328, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1531), 157695196, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1532) },
                    { 599921328, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1494), 202846622, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1495) },
                    { 599921328, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1482), 805956946, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1483) },
                    { 599921328, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1408), 705645581, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1409) },
                    { 599921328, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1507), 718823204, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1508) },
                    { 599921328, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1420), 955314473, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1422) },
                    { 599921328, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1445), 527383903, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1446) },
                    { 599921328, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1543), 168937068, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1544) },
                    { 599921328, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1470), 246190366, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1471) },
                    { 599921328, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1433), 580654911, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1434) },
                    { 599921328, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1556), 986580884, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1557) },
                    { 599921328, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1457), 515381216, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1458) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 599921328, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1570), 618002982, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1572) },
                    { 599921328, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1519), 523110689, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1520) },
                    { 1040762080, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2382), 243578663, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2383) },
                    { 1040762080, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2196), 125703879, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2197) },
                    { 1040762080, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2333), 207742960, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2334) },
                    { 1040762080, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2296), 232559883, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2297) },
                    { 1040762080, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2284), 153064354, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2285) },
                    { 1040762080, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2208), 695336353, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2209) },
                    { 1040762080, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2308), 276185753, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2309) },
                    { 1040762080, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2220), 815883187, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2221) },
                    { 1040762080, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2245), 178619797, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2246) },
                    { 1040762080, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2345), 984640706, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2346) },
                    { 1040762080, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2272), 412679303, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2273) },
                    { 1040762080, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2232), 319469041, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2233) },
                    { 1040762080, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2357), 578934921, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2358) },
                    { 1040762080, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2257), 149668288, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2258) },
                    { 1040762080, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2369), 323163769, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2370) },
                    { 1040762080, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2320), 342972067, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2321) },
                    { 1346574080, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1983), 877088207, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1984) },
                    { 1346574080, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1796), 831360210, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1797) },
                    { 1346574080, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1933), 467880641, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1934) },
                    { 1346574080, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1894), 940041963, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1895) },
                    { 1346574080, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1881), 743195979, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1882) },
                    { 1346574080, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1808), 661898440, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1809) },
                    { 1346574080, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1906), 458317959, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1907) },
                    { 1346574080, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1820), 228698470, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1821) },
                    { 1346574080, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1845), 815094970, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1846) },
                    { 1346574080, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1946), 187625358, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1947) },
                    { 1346574080, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1869), 654254466, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1870) },
                    { 1346574080, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1832), 158002572, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1833) },
                    { 1346574080, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1958), 715167273, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1959) },
                    { 1346574080, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1857), 823199364, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1858) },
                    { 1346574080, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1971), 980518577, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1972) },
                    { 1346574080, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1918), 604764504, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1919) },
                    { 1828411032, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1783), 328599073, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1784) },
                    { 1828411032, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1595), 542144426, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1596) },
                    { 1828411032, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1734), 695554993, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1735) },
                    { 1828411032, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1696), 344205725, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1697) },
                    { 1828411032, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1684), 354401622, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1685) },
                    { 1828411032, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1609), 318309423, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1610) },
                    { 1828411032, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1708), 375352804, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1709) },
                    { 1828411032, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1622), 609192860, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1623) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1828411032, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1646), 768605595, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1647) },
                    { 1828411032, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1746), 529275876, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1747) },
                    { 1828411032, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1671), 525867496, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1673) },
                    { 1828411032, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1634), 795170215, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1635) },
                    { 1828411032, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1758), 638843524, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1759) },
                    { 1828411032, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1659), 193853430, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1660) },
                    { 1828411032, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1771), 403361070, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1772) },
                    { 1828411032, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1721), 778079578, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1722) },
                    { 1965421808, 127501926, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2774), 715311398, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2775) },
                    { 1965421808, 162907081, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2589), 155512565, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2590) },
                    { 1965421808, 181360261, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2726), 462516698, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2727) },
                    { 1965421808, 211445836, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2689), 996871805, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2690) },
                    { 1965421808, 247957789, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2677), 267103315, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2678) },
                    { 1965421808, 296359945, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2601), 579723495, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2602) },
                    { 1965421808, 325633098, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2701), 723206373, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2702) },
                    { 1965421808, 344128236, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2613), 953048011, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2614) },
                    { 1965421808, 383923327, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2637), 591505459, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2639) },
                    { 1965421808, 387388705, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2738), 151378710, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2739) },
                    { 1965421808, 501376163, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2665), 920109864, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2666) },
                    { 1965421808, 684362969, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2625), 183582809, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2626) },
                    { 1965421808, 786031254, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2750), 461055497, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2751) },
                    { 1965421808, 871267311, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2652), 837746130, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2653) },
                    { 1965421808, 879294169, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2762), 440230392, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2763) },
                    { 1965421808, 886867167, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2714), 251582486, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(2715) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 164227410, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9911), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9909), -929987592, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9910), 489535757 },
                    { 177505347, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(132), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(129), -1050571968, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(130), 489535757 },
                    { 187009892, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9746), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9743), 1346574080, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9745), 446299172 },
                    { 190722871, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(117), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(115), -1050571968, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(116), 880492614 },
                    { 203736309, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9868), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9865), 1040762080, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9866), 489535757 },
                    { 204212353, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9716), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9713), 1828411032, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9714), 880492614 },
                    { 251467056, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(176), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(173), -1202086344, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(174), 489535757 },
                    { 269981600, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9955), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9952), 1965421808, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9954), 489535757 },
                    { 289334984, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9808), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9805), 188907168, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9806), 880492614 },
                    { 355759211, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(84), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(81), -1833950136, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(82), 489535757 },
                    { 404137267, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9940), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9937), 1965421808, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9939), 880492614 },
                    { 411943776, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9641), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9638), -1796054160, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9639), 489535757 },
                    { 433213920, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9822), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9819), 188907168, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9821), 489535757 },
                    { 443077666, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9793), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9790), 188907168, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9791), 446299172 },
                    { 447195346, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9701), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9698), 1828411032, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9699), 446299172 },
                    { 447375115, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9837), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9834), 1040762080, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9835), 446299172 },
                    { 462470106, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(12), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(10), -868149912, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(11), 446299172 },
                    { 489850564, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(101), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(98), -1050571968, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(99), 446299172 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 585083304, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(162), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(159), -1202086344, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(160), 880492614 },
                    { 614114656, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9686), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9683), 599921328, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9684), 489535757 },
                    { 653447725, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(147), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(144), -1202086344, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(146), 446299172 },
                    { 662108185, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9655), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9653), 599921328, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9654), 446299172 },
                    { 682086672, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9897), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9894), -929987592, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9896), 880492614 },
                    { 682742471, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9969), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9967), 130674256, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9968), 446299172 },
                    { 695482906, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(26), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(24), -868149912, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(25), 880492614 },
                    { 710920172, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9776), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9773), 1346574080, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9774), 489535757 },
                    { 717620794, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(70), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(67), -1833950136, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(68), 880492614 },
                    { 721213767, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9606), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9603), -1796054160, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9604), 446299172 },
                    { 745838944, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9730), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9727), 1828411032, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9729), 489535757 },
                    { 787589561, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(41), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(38), -868149912, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(39), 489535757 },
                    { 821191848, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9670), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9667), 599921328, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9668), 880492614 },
                    { 831143220, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9761), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9758), 1346574080, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9760), 880492614 },
                    { 842031745, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9883), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9880), -929987592, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9881), 446299172 },
                    { 857541207, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9626), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9623), -1796054160, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9624), 880492614 },
                    { 937875681, new DateTime(2024, 4, 1, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(55), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(52), -1833950136, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(54), 446299172 },
                    { 948795651, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9998), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9995), 130674256, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9996), 489535757 },
                    { 972563659, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9984), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9981), 130674256, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9982), 880492614 },
                    { 973401879, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9851), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9849), 1040762080, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9850), 880492614 },
                    { 981502556, new DateTime(2024, 4, 1, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9926), 0f, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9923), 1965421808, new DateTime(2024, 3, 21, 20, 55, 7, 457, DateTimeKind.Local).AddTicks(9924), 446299172 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 125405024, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(399), 1828411032, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(401), 888841437 },
                    { 130682553, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(299), -1796054160, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(300), 950257540 },
                    { 146459982, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1043), -1833950136, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1044), 658574611 },
                    { 147004542, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(756), -929987592, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(757), 818485978 },
                    { 147801050, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(731), 1040762080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(732), 658574611 },
                    { 154687263, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(337), 599921328, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(338), 888841437 },
                    { 156912783, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1132), -1202086344, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1133), 818485978 },
                    { 196912645, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(944), -868149912, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(945), 818485978 },
                    { 207360678, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(633), 188907168, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(634), 818485978 },
                    { 227666861, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1092), -1050571968, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1093), 128478450 },
                    { 232559605, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(806), 1965421808, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(807), 888841437 },
                    { 245434314, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(311), -1796054160, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(312), 128478450 },
                    { 245444719, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(670), 188907168, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(671), 658574611 },
                    { 261106300, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1006), -1833950136, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1007), 818485978 },
                    { 263880463, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(645), 188907168, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(647), 950257540 },
                    { 312946252, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1080), -1050571968, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1081), 950257540 },
                    { 314016466, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(707), 1040762080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(708), 950257540 },
                    { 329207657, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(819), 1965421808, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(820), 818485978 },
                    { 332410409, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(920), 130674256, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(921), 658574611 },
                    { 342148854, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(621), 188907168, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(622), 888841437 },
                    { 367877018, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(412), 1828411032, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(413), 818485978 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 391454608, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(719), 1040762080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(720), 128478450 },
                    { 401062035, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(683), 1040762080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(684), 888841437 },
                    { 407101919, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1156), -1202086344, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1157), 128478450 },
                    { 411779261, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1168), -1202086344, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1169), 658574611 },
                    { 438827378, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(596), 1346574080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(597), 128478450 },
                    { 447284457, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(957), -868149912, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(958), 950257540 },
                    { 455524099, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(981), -868149912, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(982), 658574611 },
                    { 460340727, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1018), -1833950136, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1019), 950257540 },
                    { 470630227, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(526), 1828411032, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(527), 128478450 },
                    { 482365277, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(374), 599921328, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(375), 128478450 },
                    { 490594505, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(269), -1796054160, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(270), 888841437 },
                    { 636518383, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(794), -929987592, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(795), 658574611 },
                    { 646614699, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(349), 599921328, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(350), 818485978 },
                    { 653102544, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(583), 1346574080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(584), 950257540 },
                    { 653450891, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(883), 130674256, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(884), 818485978 },
                    { 655674763, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(895), 130674256, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(896), 950257540 },
                    { 673182112, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(323), -1796054160, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(324), 658574611 },
                    { 703260400, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1067), -1050571968, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1068), 818485978 },
                    { 712600070, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1104), -1050571968, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1105), 658574611 },
                    { 714340974, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(843), 1965421808, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(844), 128478450 },
                    { 735763502, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(969), -868149912, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(970), 128478450 },
                    { 744383351, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(695), 1040762080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(696), 818485978 },
                    { 767034919, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1144), -1202086344, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1145), 950257540 },
                    { 787287406, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(855), 1965421808, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(856), 658574611 },
                    { 787986306, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(658), 188907168, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(659), 128478450 },
                    { 793854581, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(424), 1828411032, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(425), 950257540 },
                    { 807820605, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(932), -868149912, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(933), 888841437 },
                    { 836002725, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(387), 599921328, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(388), 658574611 },
                    { 844508005, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1055), -1050571968, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1056), 888841437 },
                    { 857945013, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(781), -929987592, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(782), 128478450 },
                    { 859745829, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1118), -1202086344, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1119), 888841437 },
                    { 875472457, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(286), -1796054160, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(287), 818485978 },
                    { 877568019, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(553), 1346574080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(554), 888841437 },
                    { 886689440, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(541), 1828411032, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(542), 658574611 },
                    { 905404509, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(831), 1965421808, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(832), 950257540 },
                    { 916656664, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(569), 1346574080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(570), 818485978 },
                    { 918027400, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(361), 599921328, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(362), 950257540 },
                    { 919518594, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(609), 1346574080, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(610), 658574611 },
                    { 922182754, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(907), 130674256, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(908), 128478450 },
                    { 948835965, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(744), -929987592, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(745), 888841437 },
                    { 956037286, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(868), 130674256, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(869), 888841437 },
                    { 956929514, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(994), -1833950136, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(995), 888841437 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[] { 963617797, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(768), -929987592, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(769), 950257540 });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[] { 971053257, 0f, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1030), -1833950136, new DateTime(2024, 3, 21, 20, 55, 7, 458, DateTimeKind.Local).AddTicks(1031), 128478450 });

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
