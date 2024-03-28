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
                    ParentRoleId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Roles_ParentRoleId",
                        column: x => x.ParentRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
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
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 133707407, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8411), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8412), "Photovoltaics" },
                    { 178486685, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8505), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8508), "Construction Supervision" },
                    { 181717885, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8079), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8081), "HVAC" },
                    { 216391094, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8319), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8321), "Structured Cabling" },
                    { 225094633, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8144), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8147), "Potable Water" },
                    { 294759102, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8343), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8345), "Burglar Alarm" },
                    { 391357624, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8433), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8435), "Energy Efficiency" },
                    { 522178424, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8528), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8530), "DWG Admin/Clearing" },
                    { 544486916, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8387), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8390), "BMS" },
                    { 548534120, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8292), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8294), "Power Distribution" },
                    { 628349470, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8169), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8171), "Drainage" },
                    { 641016352, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8365), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8367), "CCTV" },
                    { 647020412, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8552), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8554), "Project Manager Hours" },
                    { 663760546, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8245), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8247), "Elevators" },
                    { 715588562, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8220), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8222), "Fire Suppression" },
                    { 729458033, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8194), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8196), "Fire Detection" },
                    { 767030834, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8268), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8270), "Natural Gas" },
                    { 854277040, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8119), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8121), "Sewage" },
                    { 858521165, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8457), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8459), "Outsource" },
                    { 861106252, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8479), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8481), "TenderDocument" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 225396990, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9052), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9054), "Drawings" },
                    { 521490670, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8995), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8997), "Documents" },
                    { 978228986, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9028), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9030), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 262752774, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(126), new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(128), "Communications" },
                    { 473750228, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(280), new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(282), "Hours To Be Raised" },
                    { 496254784, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(206), new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(208), "Meetings" },
                    { 595733045, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(230), new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(232), "Administration" },
                    { 634696287, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(159), new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(161), "Printing" },
                    { 723821933, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(256), new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(257), "Soft Copy" },
                    { 939717144, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(185), new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(187), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 127569837, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3526), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3528), "Dashboard Assign Project Manager", 5 },
                    { 200009041, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3505), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3506), "Dashboard Assign Engineer", 4 },
                    { 366006744, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3602), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3604), "Dashboard See My Hours", 8 },
                    { 397268784, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3675), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3677), "See All Projects", 11 },
                    { 408304515, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3624), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3626), "See All Disciplines", 9 },
                    { 415699129, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3771), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3773), "Dashboard Edit Deliverable", 15 },
                    { 449346104, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3455), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3457), "Dashboard Edit My Hours", 2 },
                    { 473553775, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3650), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3652), "See All Drawings", 10 },
                    { 485038220, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3482), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3484), "Dashboard Assign Designer", 3 },
                    { 661704158, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3579), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3581), "See Admin Layout", 7 },
                    { 672684262, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3555), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3556), "Dashboard Add Project", 6 },
                    { 723037331, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3747), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3749), "Dashboard Edit Discipline", 14 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 737660858, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3722), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3724), "Display Projects Code", 13 },
                    { 911686435, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3699), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3701), "Edit Project On Dashboard", 12 },
                    { 978112837, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3794), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3795), "Dashboard Edit Other", 16 },
                    { 997226447, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3299), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3301), "See Dashboard Layout", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 211688405, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7541), "Infrastructure Description", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7543), "Infrastructure" },
                    { 469322554, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7589), "Consulting Description", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7591), "Consulting" },
                    { 626248443, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7509), "Buildings Description", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7511), "Buildings" },
                    { 669088171, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7565), "Energy Description", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7567), "Energy" },
                    { 788407788, false, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7611), "Production Management Description", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7612), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 535296966, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4067), false, false, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4069), "Guest", null },
                    { 664544649, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4120), false, false, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4123), "Admin", null },
                    { 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3819), false, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3821), "CEO", null },
                    { 754782295, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4092), false, false, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4094), "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6682), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6685), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 256571765, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5723), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5725), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6359), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6362), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7331), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7334), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6209), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6212), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7023), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7025), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6863), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6866), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7257), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7260), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7101), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7103), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6285), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6288), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7179), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7181), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6943), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6945), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7432), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7435), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 709860905, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6009), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6011), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6440), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6442), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6549), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6551), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 886511778, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5938), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5940), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6790), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6793), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 932200484, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5860), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5863), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6126), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6128), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 210982043, "panperivollari@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7356), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7358), 396039044 },
                    { 229071258, "kkotsoni@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6574), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6576), 849495470 },
                    { 277515750, "xmanarolis@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6236), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6238), 474314516 },
                    { 299098784, "vtza@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6710), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6712), 146466287 },
                    { 305045508, "vpax@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6157), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6160), 983952441 },
                    { 426885584, "dtsa@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6035), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6037), 709860905 },
                    { 434746927, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7128), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7130), 563011825 },
                    { 469351542, "chkovras@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6386), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6389), 294907113 },
                    { 471400512, "haris@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6970), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6972), 661891042 },
                    { 569453671, "kmargeti@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6891), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6894), 519393236 },
                    { 639063047, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7457), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7459), 696165427 },
                    { 732579771, "blekou@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7205), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7207), 655145213 },
                    { 740133676, "agretos@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6816), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6818), 925851760 },
                    { 751472975, "embiria@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5760), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5762), 256571765 },
                    { 807384031, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5798), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5800), 256571765 },
                    { 810502044, "gdoug@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5890), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5892), 932200484 },
                    { 849159823, "pfokianou@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7049), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7051), 515033626 },
                    { 896201708, "ngal@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6470), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6472), 725168282 },
                    { 908286122, "vchontos@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7283), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7285), 528463447 },
                    { 931970826, "dtsa@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5961), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5963), 886511778 },
                    { 970005175, "sparisis@embiria.gr", new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6311), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6314), 573389145 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 246712662, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), new DateTime(2025, 7, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Test Description Project_4", new DateTime(2025, 7, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 0f, new DateTime(2025, 7, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 1500L, 12L, 10000.0, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Project_4", 849495470, null, 469322554, 0f },
                    { 430186288, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), new DateTime(2024, 4, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Test Description Project_2", new DateTime(2024, 4, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 0f, new DateTime(2024, 4, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 1500L, 12L, 10000.0, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Project_1", 849495470, null, 626248443, 0f },
                    { 742593503, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), new DateTime(2024, 6, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Test Description Project_PM", new DateTime(2024, 4, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 0f, new DateTime(2024, 5, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 1500L, 12L, null, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Project_PM", null, null, 788407788, 0f },
                    { 747728255, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), new DateTime(2024, 12, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Test Description Project_12", new DateTime(2024, 12, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 0f, new DateTime(2024, 12, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 1500L, 12L, 10000.0, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Project_3", 849495470, null, 669088171, 0f },
                    { 930591104, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), new DateTime(2024, 7, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Test Description Project_8", new DateTime(2024, 7, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 0f, new DateTime(2024, 7, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), 1500L, 12L, 10000.0, new DateTime(2024, 3, 28, 19, 40, 32, 397, DateTimeKind.Local).AddTicks(9879), "Project_2", 849495470, null, 211688405, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 997226447, 535296966, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5421), -291694967, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5423) },
                    { 397268784, 664544649, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5545), 84522583, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5548) },
                    { 408304515, 664544649, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5496), 106755809, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5499) },
                    { 473553775, 664544649, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5521), -1639433519, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5523) },
                    { 661704158, 664544649, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5472), -2075153714, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5474) },
                    { 127569837, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5205), 1373098046, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5207) },
                    { 200009041, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5180), 2024030741, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5183) },
                    { 397268784, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5307), -814558661, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5310) },
                    { 408304515, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5258), -1189225813, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5260) },
                    { 449346104, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5132), 2118234803, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5134) },
                    { 473553775, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5283), 758861150, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5285) },
                    { 485038220, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5156), -375844711, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5158) },
                    { 672684262, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5232), -1809022990, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5235) },
                    { 737660858, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5333), -609095375, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5335) },
                    { 911686435, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5391), -102456274, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5393) },
                    { 997226447, 713470422, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5107), 1584800384, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5109) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 997226447, 754782295, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5447), -1234667776, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5449) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3905), false, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3907), "COO", 713470422 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 713470422, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6523), 897607438, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6525) });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1775186912, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8790), 0f, 416L, 52L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8792), 930591104, 715588562, null },
                    { -1763399872, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8740), 0f, 400L, 50L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8742), 930591104, 178486685, null },
                    { -1677189264, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8916), 0f, 408L, 51L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8917), 246712662, 294759102, null },
                    { -1569898208, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8965), 0f, 500L, 0L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8967), 742593503, 647020412, null },
                    { -845074232, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8814), 0f, 400L, 50L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8816), 747728255, 181717885, null },
                    { -824871240, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8598), 0f, 400L, 50L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8600), 430186288, 861106252, null },
                    { -672487056, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8862), 0f, 416L, 52L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8864), 747728255, 715588562, null },
                    { 80272376, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8838), 0f, 408L, 51L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8840), 747728255, 729458033, null },
                    { 97538272, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8890), 0f, 400L, 50L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8892), 246712662, 854277040, null },
                    { 341857424, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8764), 0f, 408L, 51L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8766), 930591104, 225094633, null },
                    { 837919536, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8661), 0f, 416L, 52L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8663), 430186288, 178486685, null },
                    { 1185006512, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8636), 0f, 408L, 51L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8638), 430186288, 641016352, null },
                    { 1251809816, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8941), 0f, 416L, 52L, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(8944), 246712662, 729458033, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 647548499, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7927), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7931), 4000.0, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7929), "Signature 142349", 12903, 747728255, 3.0, 17.0 },
                    { 830876106, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7981), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7985), 13000.0, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7983), "Signature 142344", 71431, 246712662, 4.0, 24.0 },
                    { 908927362, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7795), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7799), 3010.0, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7797), "Signature 142343", 76882, 430186288, 1.0, 17.0 },
                    { 984765706, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7868), new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7873), 3100.0, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7871), "Signature 1423410", 35968, 930591104, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 127569837, 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4676), 1138062816, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4678) },
                    { 200009041, 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4648), 269996608, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4650) },
                    { 366006744, 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4701), 1274480136, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4703) },
                    { 397268784, 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4772), -411945223, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4774) },
                    { 408304515, 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4725), -233045279, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4727) },
                    { 449346104, 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4567), -1849165366, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4569) },
                    { 473553775, 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4748), 753811547, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4750) },
                    { 485038220, 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4623), -324724648, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4626) },
                    { 997226447, 342685494, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4542), -966599914, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4545) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3932), false, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3933), "CTO", 342685494 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 342685494, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6630), 812549701, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6632) });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1775186912, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(349), 717520083, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(351) },
                    { -1775186912, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(275), 801638493, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(277) },
                    { -1775186912, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(535), 644315184, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(537) },
                    { -1775186912, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(227), 405217703, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(229) },
                    { -1775186912, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(442), 763455406, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(444) },
                    { -1775186912, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(396), 563264413, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(398) },
                    { -1775186912, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(512), 516313273, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(513) },
                    { -1775186912, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(466), 872605556, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(468) },
                    { -1775186912, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(251), 513078580, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(253) },
                    { -1775186912, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(489), 165496747, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(491) },
                    { -1775186912, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(418), 743374908, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(420) },
                    { -1775186912, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(558), 521010103, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(560) },
                    { -1775186912, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(298), 253042074, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(300) },
                    { -1775186912, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(325), 404584914, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(327) },
                    { -1775186912, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(372), 426210678, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(374) },
                    { -1775186912, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(205), 660730153, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(207) },
                    { -1763399872, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9596), 582862642, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9598) },
                    { -1763399872, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9527), 977897615, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9529) },
                    { -1763399872, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9791), 601865577, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9793) },
                    { -1763399872, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9480), 950912821, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9482) },
                    { -1763399872, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9688), 394146047, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9690) },
                    { -1763399872, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9643), 775668230, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9645) },
                    { -1763399872, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9768), 162409541, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9770) },
                    { -1763399872, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9721), 708354840, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9723) },
                    { -1763399872, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9504), 967169388, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9506) },
                    { -1763399872, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9745), 807501479, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9747) },
                    { -1763399872, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9665), 768382073, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9667) },
                    { -1763399872, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9815), 585062599, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9817) },
                    { -1763399872, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9549), 631683055, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9551) },
                    { -1763399872, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9573), 205408664, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9576) },
                    { -1763399872, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9619), 346825429, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9621) },
                    { -1763399872, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9457), 752180919, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9459) },
                    { -1677189264, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2240), 523988879, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2242) },
                    { -1677189264, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2174), 639541751, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2176) },
                    { -1677189264, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2424), 470389289, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2426) },
                    { -1677189264, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2128), 263642087, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2131) },
                    { -1677189264, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2333), 799180328, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2335) },
                    { -1677189264, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2284), 805119876, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2286) },
                    { -1677189264, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2401), 594674421, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2403) },
                    { -1677189264, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2355), 663339191, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2357) },
                    { -1677189264, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2150), 984087847, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2152) },
                    { -1677189264, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2379), 155938590, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2381) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1677189264, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2306), 567677462, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2309) },
                    { -1677189264, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2447), 761659956, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2449) },
                    { -1677189264, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2197), 711148633, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2199) },
                    { -1677189264, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2219), 815862646, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2221) },
                    { -1677189264, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2262), 343864617, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2264) },
                    { -1677189264, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2104), 263765360, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2106) },
                    { -845074232, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(725), 938647462, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(727) },
                    { -845074232, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(656), 572100579, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(658) },
                    { -845074232, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(911), 585555660, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(913) },
                    { -845074232, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(608), 634173956, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(610) },
                    { -845074232, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(822), 769509165, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(824) },
                    { -845074232, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(773), 365146585, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(775) },
                    { -845074232, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(887), 532757096, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(889) },
                    { -845074232, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(845), 887857985, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(847) },
                    { -845074232, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(632), 663035864, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(634) },
                    { -845074232, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(866), 668786065, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(867) },
                    { -845074232, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(797), 571391139, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(800) },
                    { -845074232, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(934), 227229649, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(935) },
                    { -845074232, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(680), 336047671, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(682) },
                    { -845074232, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(703), 756473955, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(705) },
                    { -845074232, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(749), 514432689, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(752) },
                    { -845074232, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(582), 995526732, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(585) },
                    { -824871240, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8465), 283534470, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8466) },
                    { -824871240, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8388), 616449367, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8389) },
                    { -824871240, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8644), 956605343, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8646) },
                    { -824871240, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8195), 183562119, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8197) },
                    { -824871240, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8555), 911452919, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8557) },
                    { -824871240, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8508), 842666321, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8510) },
                    { -824871240, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8621), 374496018, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8623) },
                    { -824871240, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8577), 631317002, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8579) },
                    { -824871240, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8360), 713309726, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8362) },
                    { -824871240, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8599), 636354679, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8601) },
                    { -824871240, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8532), 315085832, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8534) },
                    { -824871240, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8667), 853467082, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8670) },
                    { -824871240, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8411), 611555354, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8413) },
                    { -824871240, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8442), 615083934, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8443) },
                    { -824871240, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8487), 462706468, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8489) },
                    { -824871240, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2638), 409957007, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2640) },
                    { -672487056, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1484), 675879024, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1487) },
                    { -672487056, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1411), 402017704, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1413) },
                    { -672487056, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1681), 863803710, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1683) },
                    { -672487056, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1363), 628820092, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1364) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -672487056, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1579), 414849957, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1582) },
                    { -672487056, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1530), 635368237, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1533) },
                    { -672487056, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1657), 307749471, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1660) },
                    { -672487056, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1603), 672382242, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1605) },
                    { -672487056, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1387), 474543834, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1389) },
                    { -672487056, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1632), 618628823, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1634) },
                    { -672487056, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1555), 641439101, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1557) },
                    { -672487056, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1705), 314873628, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1707) },
                    { -672487056, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1436), 663120811, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1438) },
                    { -672487056, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1460), 846323926, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1462) },
                    { -672487056, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1507), 586103438, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1509) },
                    { -672487056, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1334), 734300783, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1336) },
                    { 80272376, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1099), 462458352, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1101) },
                    { 80272376, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1026), 893349466, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1028) },
                    { 80272376, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1288), 597672722, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1290) },
                    { 80272376, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(980), 827427487, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(982) },
                    { 80272376, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1193), 734474865, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1195) },
                    { 80272376, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1147), 650795114, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1149) },
                    { 80272376, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1265), 808996323, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1267) },
                    { 80272376, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1217), 912162811, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1218) },
                    { 80272376, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1004), 535802602, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1006) },
                    { 80272376, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1240), 448308369, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1242) },
                    { 80272376, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1170), 610811062, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1172) },
                    { 80272376, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1311), 302735039, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1313) },
                    { 80272376, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1052), 423811977, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1054) },
                    { 80272376, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1076), 327900004, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1078) },
                    { 80272376, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1122), 584696694, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1124) },
                    { 80272376, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(957), 207062993, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(959) },
                    { 97538272, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1870), 957348250, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1873) },
                    { 97538272, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1799), 453611280, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1801) },
                    { 97538272, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2057), 142864160, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2059) },
                    { 97538272, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1753), 728713507, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1755) },
                    { 97538272, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1966), 877052179, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1968) },
                    { 97538272, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1919), 703492158, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1921) },
                    { 97538272, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2037), 254947847, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2038) },
                    { 97538272, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1989), 840175056, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1991) },
                    { 97538272, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1775), 728780350, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1778) },
                    { 97538272, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2014), 227295765, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2016) },
                    { 97538272, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1943), 457719883, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1945) },
                    { 97538272, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2080), 948295581, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2082) },
                    { 97538272, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1823), 934998652, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1825) },
                    { 97538272, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1846), 570739322, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1848) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 97538272, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1895), 641796829, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1897) },
                    { 97538272, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1730), 427667948, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(1731) },
                    { 341857424, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9980), 752012541, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9981) },
                    { 341857424, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9911), 783359858, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9912) },
                    { 341857424, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(159), 695515263, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(161) },
                    { 341857424, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9866), 615702988, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9867) },
                    { 341857424, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(69), 197828401, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(71) },
                    { 341857424, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(25), 210379570, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(27) },
                    { 341857424, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(137), 208972807, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(138) },
                    { 341857424, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(92), 389870878, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(94) },
                    { 341857424, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9889), 833360104, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9891) },
                    { 341857424, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(114), 913588190, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(115) },
                    { 341857424, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(47), 934317771, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(48) },
                    { 341857424, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(182), 666078336, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(184) },
                    { 341857424, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9932), 533445382, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9935) },
                    { 341857424, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9956), 540764409, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9959) },
                    { 341857424, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(4), 937390946, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(5) },
                    { 341857424, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9839), 176111801, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9842) },
                    { 837919536, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9215), 983292301, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9217) },
                    { 837919536, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9144), 312873096, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9146) },
                    { 837919536, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9408), 659399295, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9410) },
                    { 837919536, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9097), 857556687, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9099) },
                    { 837919536, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9311), 549729887, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9313) },
                    { 837919536, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9262), 371963807, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9264) },
                    { 837919536, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9384), 205608269, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9386) },
                    { 837919536, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9334), 684071526, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9335) },
                    { 837919536, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9121), 678619486, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9123) },
                    { 837919536, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9357), 444233809, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9359) },
                    { 837919536, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9288), 216073193, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9290) },
                    { 837919536, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9432), 175254982, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9434) },
                    { 837919536, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9167), 667099996, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9169) },
                    { 837919536, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9191), 536235121, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9194) },
                    { 837919536, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9239), 901677656, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9241) },
                    { 837919536, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9071), 737472684, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9073) },
                    { 1185006512, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8829), 131899014, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8831) },
                    { 1185006512, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8762), 134883999, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8764) },
                    { 1185006512, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9023), 446025467, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9026) },
                    { 1185006512, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8715), 547800204, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8717) },
                    { 1185006512, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8922), 414370763, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8925) },
                    { 1185006512, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8876), 124299068, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8878) },
                    { 1185006512, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8994), 125074436, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8996) },
                    { 1185006512, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8946), 581600520, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8949) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1185006512, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8740), 202031337, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8741) },
                    { 1185006512, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8970), 202051439, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8972) },
                    { 1185006512, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8899), 257344556, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8901) },
                    { 1185006512, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9047), 809336126, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(9050) },
                    { 1185006512, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8783), 993083083, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8786) },
                    { 1185006512, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8806), 930311096, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8808) },
                    { 1185006512, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8851), 420450267, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8853) },
                    { 1185006512, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8692), 323732889, new DateTime(2024, 3, 28, 19, 40, 32, 415, DateTimeKind.Local).AddTicks(8693) },
                    { 1251809816, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2611), 605562942, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2614) },
                    { 1251809816, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2540), 504245628, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2542) },
                    { 1251809816, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2796), 946761239, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2798) },
                    { 1251809816, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2494), 946944480, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2495) },
                    { 1251809816, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2702), 197758281, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2704) },
                    { 1251809816, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2658), 844663295, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2660) },
                    { 1251809816, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2771), 703774268, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2772) },
                    { 1251809816, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2725), 281248622, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2727) },
                    { 1251809816, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2517), 758403531, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2519) },
                    { 1251809816, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2749), 625854624, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2750) },
                    { 1251809816, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2680), 500633995, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2682) },
                    { 1251809816, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2819), 341122564, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2821) },
                    { 1251809816, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2563), 618490876, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2566) },
                    { 1251809816, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2588), 722861529, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2590) },
                    { 1251809816, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2635), 804356239, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2637) },
                    { 1251809816, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2471), 485032533, new DateTime(2024, 3, 28, 19, 40, 32, 416, DateTimeKind.Local).AddTicks(2472) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 209612917, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9263), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9259), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9261), 978228986 },
                    { 256551262, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9366), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9362), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9364), 978228986 },
                    { 261029568, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9539), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9536), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9537), 225396990 },
                    { 273319215, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9717), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9712), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9714), 521490670 },
                    { 285796103, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9340), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9336), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9338), 521490670 },
                    { 311991649, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9167), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9163), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9165), 521490670 },
                    { 371091279, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9489), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9485), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9487), 521490670 },
                    { 421350289, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9872), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9868), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9870), 521490670 },
                    { 441098909, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9897), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9893), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9895), 978228986 },
                    { 445734026, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9415), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9411), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9413), 521490670 },
                    { 491200783, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9665), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9661), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9663), 978228986 },
                    { 506796867, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9613), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9608), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9611), 225396990 },
                    { 516647876, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9085), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9079), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9082), 521490670 },
                    { 523250102, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9217), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9213), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9215), 225396990 },
                    { 538530954, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9588), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9585), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9586), 978228986 },
                    { 624489736, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9439), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9435), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9437), 978228986 },
                    { 649846964, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9239), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9236), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9237), 521490670 },
                    { 675840241, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9192), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9187), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9189), 978228986 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 781818352, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9691), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9686), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9688), 225396990 },
                    { 786417739, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9141), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9137), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9139), 225396990 },
                    { 789296165, new DateTime(2024, 4, 8, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(6), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(4), 978228986 },
                    { 799795266, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9742), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9737), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9739), 978228986 },
                    { 800443330, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9767), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9763), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9765), 225396990 },
                    { 811741652, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9116), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9113), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9114), 978228986 },
                    { 816095834, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9391), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9387), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9389), 225396990 },
                    { 818947830, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9463), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9459), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9461), 225396990 },
                    { 824670732, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9821), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9816), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9818), 978228986 },
                    { 845255128, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9640), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9635), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9638), 521490670 },
                    { 882824009, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9513), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9508), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9510), 978228986 },
                    { 900485151, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9847), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9843), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9845), 225396990 },
                    { 918876950, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9980), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9976), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9978), 521490670 },
                    { 920655831, new DateTime(2024, 4, 8, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(77), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(73), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(75), 978228986 },
                    { 926226956, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9921), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9917), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9918), 225396990 },
                    { 946547706, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9565), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9560), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9562), 521490670 },
                    { 953622737, new DateTime(2024, 4, 8, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(28), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(24), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(26), 225396990 },
                    { 971668461, new DateTime(2024, 4, 8, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(53), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(48), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(50), 521490670 },
                    { 976931096, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9794), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9790), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9792), 521490670 },
                    { 990428174, new DateTime(2024, 4, 8, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9286), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9282), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(9284), 225396990 },
                    { 990523589, new DateTime(2024, 4, 8, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(100), 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(96), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(98), 225396990 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 134858282, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1336), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1338), 595733045 },
                    { 148471837, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1496), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1498), 595733045 },
                    { 174401587, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2313), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2314), 634696287 },
                    { 176685564, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1973), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1975), 634696287 },
                    { 182124082, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2050), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2052), 595733045 },
                    { 213581961, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2123), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2125), 262752774 },
                    { 221538467, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2002), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2004), 939717144 },
                    { 223029674, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(510), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(512), 634696287 },
                    { 224040950, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2455), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2457), 262752774 },
                    { 224782272, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(940), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(942), 496254784 },
                    { 225580818, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1145), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1147), 595733045 },
                    { 268948387, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(770), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(773), 496254784 },
                    { 278104038, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1831), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1833), 595733045 },
                    { 285832554, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1759), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1761), 634696287 },
                    { 288205051, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1012), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1014), 473750228 },
                    { 290793729, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1381), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1383), 473750228 },
                    { 303406620, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2195), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2197), 496254784 },
                    { 311925094, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1807), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1809), 496254784 },
                    { 325172928, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1901), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1903), 262752774 },
                    { 328822699, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2075), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2077), 723821933 },
                    { 333671696, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2586), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2588), 723821933 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 341782096, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(592), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(594), 496254784 },
                    { 356975880, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(415), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(417), 595733045 },
                    { 373965959, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1474), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1476), 496254784 },
                    { 392348960, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2098), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2100), 473750228 },
                    { 395097738, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(487), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(488), 262752774 },
                    { 400180672, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2526), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2529), 496254784 },
                    { 404171607, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(391), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(394), 496254784 },
                    { 417140487, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(617), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(620), 595733045 },
                    { 497202555, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(796), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(798), 595733045 },
                    { 501875915, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1405), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1406), 262752774 },
                    { 517723308, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1781), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1783), 939717144 },
                    { 525882169, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1360), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1362), 723821933 },
                    { 527745235, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1614), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1616), 939717144 },
                    { 546391257, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2358), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2360), 496254784 },
                    { 554535589, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(342), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(344), 634696287 },
                    { 565632743, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(667), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(669), 473750228 },
                    { 567180496, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1194), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1196), 473750228 },
                    { 567705211, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1060), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1062), 634696287 },
                    { 576208481, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1567), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1569), 262752774 },
                    { 579099097, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1543), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1545), 473750228 },
                    { 584185818, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2147), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2149), 634696287 },
                    { 598459253, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1109), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1111), 496254784 },
                    { 600671922, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1272), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1274), 634696287 },
                    { 601286713, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(440), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(442), 723821933 },
                    { 602198983, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2218), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2221), 595733045 },
                    { 602611822, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(844), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(846), 473750228 },
                    { 608316452, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1590), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1593), 634696287 },
                    { 616647222, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1713), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1715), 473750228 },
                    { 619940375, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1170), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1172), 723821933 },
                    { 622011805, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2243), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2244), 723821933 },
                    { 624787232, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2026), 97538272, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2028), 496254784 },
                    { 625267086, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(916), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(917), 939717144 },
                    { 634728214, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2289), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2292), 262752774 },
                    { 639926704, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2480), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2482), 634696287 },
                    { 651418697, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2336), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2338), 939717144 },
                    { 667222398, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2611), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2613), 473750228 },
                    { 669385272, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2407), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2409), 723821933 },
                    { 674224552, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(692), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(695), 262752774 },
                    { 680718520, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(643), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(645), 723821933 },
                    { 683145962, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(988), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(991), 723821933 },
                    { 683380987, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(963), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(966), 595733045 },
                    { 689553830, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2503), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2505), 939717144 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 696128713, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(537), 1185006512, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(539), 939717144 },
                    { 696302897, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(867), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(869), 262752774 },
                    { 710165787, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2383), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2385), 595733045 },
                    { 715237821, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2550), -1569898208, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2552), 595733045 },
                    { 724376368, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(744), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(746), 939717144 },
                    { 728827705, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1638), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1641), 496254784 },
                    { 736450623, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1085), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1087), 939717144 },
                    { 739785954, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(307), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(309), 262752774 },
                    { 740553273, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1036), 341857424, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1038), 262752774 },
                    { 746009111, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2264), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2267), 473750228 },
                    { 746675047, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1665), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1667), 595733045 },
                    { 759651844, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(820), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(822), 723821933 },
                    { 763192049, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1294), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1296), 939717144 },
                    { 765014712, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(891), -1763399872, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(893), 634696287 },
                    { 796447423, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1520), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1522), 723821933 },
                    { 797453623, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1854), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1857), 723821933 },
                    { 813320674, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1247), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1249), 262752774 },
                    { 814686017, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2171), -1677189264, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2173), 939717144 },
                    { 896191690, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(463), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(466), 473750228 },
                    { 908675028, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1428), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1430), 634696287 },
                    { 912699953, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(717), 837919536, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(719), 634696287 },
                    { 941127340, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1688), 80272376, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1690), 723821933 },
                    { 942522712, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2431), 1251809816, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(2433), 473750228 },
                    { 943639138, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1735), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1738), 262752774 },
                    { 960664470, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(366), -824871240, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(367), 939717144 },
                    { 965177841, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1878), -672487056, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1880), 473750228 },
                    { 965722236, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1450), -845074232, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1452), 939717144 },
                    { 968198094, 0f, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1315), -1775186912, new DateTime(2024, 3, 28, 19, 40, 32, 414, DateTimeKind.Local).AddTicks(1316), 496254784 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 127569837, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4847), 1374131354, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4849) },
                    { 366006744, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4897), -968161742, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4899) },
                    { 397268784, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4977), 859285751, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4980) },
                    { 408304515, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4925), -691127311, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4927) },
                    { 415699129, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5056), -1735305803, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5058) },
                    { 449346104, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4822), 346237435, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4824) },
                    { 473553775, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4951), -275669585, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4953) },
                    { 672684262, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4873), 984681743, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4875) },
                    { 723037331, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5031), -1926890567, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5032) },
                    { 911686435, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5002), 1260143069, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5003) },
                    { 978112837, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5080), 1335098565, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5083) },
                    { 997226447, 795574939, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4797), -452988368, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4799) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 562062998, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3958), false, false, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3961), "Secretariat", 795574939 },
                    { 913082523, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3985), false, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(3987), "Project Manager", 795574939 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 795574939, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6656), 597053482, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6658) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 366006744, 562062998, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5619), 369741209, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5621) },
                    { 397268784, 562062998, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5693), -243075136, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5695) },
                    { 408304515, 562062998, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5645), 1415451411, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5647) },
                    { 449346104, 562062998, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5593), -237458681, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5595) },
                    { 473553775, 562062998, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5669), -996151490, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5671) },
                    { 997226447, 562062998, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5570), 45658207, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5572) },
                    { 200009041, 913082523, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4448), -707055403, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4450) },
                    { 366006744, 913082523, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4473), -374017985, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4475) },
                    { 408304515, 913082523, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4496), -1940721047, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4498) },
                    { 449346104, 913082523, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4426), -2145379081, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4427) },
                    { 473553775, 913082523, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4518), -689360381, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4520) },
                    { 997226447, 913082523, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4397), -818428355, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4399) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 743188935, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4015), false, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4017), "Engineer", 913082523 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 562062998, 256571765, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5823), 188694605, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5825) },
                    { 913082523, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7685), 173628963, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7687) },
                    { 913082523, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7663), 221111267, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7665) },
                    { 913082523, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7636), 174229358, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7639) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 366006744, 743188935, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4327), -208618006, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4329) },
                    { 408304515, 743188935, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4350), 1557595094, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4352) },
                    { 449346104, 743188935, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4274), -830509388, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4276) },
                    { 473553775, 743188935, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4374), 1144939019, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4375) },
                    { 485038220, 743188935, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4302), 1524445979, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4304) },
                    { 997226447, 743188935, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4248), -2105364352, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4250) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 826710918, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4040), false, true, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4042), "Designer", 743188935 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 743188935, 146466287, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6736), 138780418, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6738) },
                    { 743188935, 294907113, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6414), 676238272, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6417) },
                    { 743188935, 396039044, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7408), 825689348, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7410) },
                    { 743188935, 474314516, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6261), 850409650, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6263) },
                    { 743188935, 515033626, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7075), 133587306, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7077) },
                    { 743188935, 519393236, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6917), 126347404, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6920) },
                    { 743188935, 528463447, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7306), 894638590, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7308) },
                    { 743188935, 563011825, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7155), 332075108, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7156) },
                    { 743188935, 573389145, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6336), 618764415, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6338) },
                    { 743188935, 655145213, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7231), 961202322, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7234) },
                    { 743188935, 661891042, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6995), 137570014, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6997) },
                    { 743188935, 696165427, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7482), 813609419, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(7484) },
                    { 743188935, 725168282, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6496), 781305457, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6498) },
                    { 743188935, 849495470, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6603), 529333708, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6606) },
                    { 743188935, 925851760, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6839), 555284877, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6841) },
                    { 743188935, 983952441, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6183), 717025466, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6185) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 366006744, 826710918, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4221), -733502893, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4223) },
                    { 449346104, 826710918, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4193), 596701292, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4195) },
                    { 997226447, 826710918, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4149), 1569571079, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(4151) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 826710918, 709860905, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6063), 483985191, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(6065) },
                    { 826710918, 886511778, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5984), 167515642, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5986) },
                    { 826710918, 932200484, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5914), 653320822, new DateTime(2024, 3, 28, 19, 40, 32, 413, DateTimeKind.Local).AddTicks(5916) }
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
                name: "IX_Issues_ProjectId",
                table: "Issues",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_RoleId",
                table: "Issues",
                column: "RoleId");

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
                name: "IX_Roles_ParentRoleId",
                table: "Roles",
                column: "ParentRoleId");

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
                name: "FK_Issues_Projects_ProjectId",
                table: "Issues",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "Issues");

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
