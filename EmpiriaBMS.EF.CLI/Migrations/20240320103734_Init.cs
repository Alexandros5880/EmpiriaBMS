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
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayCost = table.Column<double>(type: "float", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidFee = table.Column<double>(type: "float", nullable: true),
                    DaysUntilPayment = table.Column<int>(type: "int", nullable: true),
                    PendingPayments = table.Column<double>(type: "float", nullable: true),
                    CalculationDaly = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
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
                    { 125156991, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3064), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3065), "Sewage" },
                    { 151850875, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3116), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3117), "Fire Suppression" },
                    { 193643473, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3280), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3281), "Project Manager Hours" },
                    { 263002349, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3180), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3181), "Burglar Alarm" },
                    { 287612104, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3129), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3130), "Elevators" },
                    { 289602524, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3043), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3045), "HVAC" },
                    { 294324181, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3077), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3078), "Potable Water" },
                    { 361761138, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3252), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3253), "TenderDocument" },
                    { 432040459, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3102), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3103), "Fire Detection" },
                    { 531712798, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3167), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3168), "Structured Cabling" },
                    { 578944849, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3227), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3229), "Energy Efficiency" },
                    { 656755719, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3191), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3192), "CCTV" },
                    { 693874900, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3203), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3205), "BMS" },
                    { 711197547, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3141), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3142), "Natural Gas" },
                    { 721867072, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3153), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3154), "Power Distribution" },
                    { 751305935, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3265), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3266), "Construction Supervision" },
                    { 829827595, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3089), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3090), "Drainage" },
                    { 867184741, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3215), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3217), "Photovoltaics" },
                    { 927801351, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3240), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3241), "Outsource" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 249609812, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3535), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3536), "Drawings" },
                    { 287621790, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3521), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3522), "Calculations" },
                    { 871101896, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3502), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3504), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 227643766, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4153), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4154), "On-Site" },
                    { 308871482, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4178), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4179), "Administration" },
                    { 562948469, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4139), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4140), "Printing" },
                    { 819713473, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4165), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4166), "Meetings" },
                    { 981724041, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4118), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4119), "Communications" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 222594205, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(92), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(93), "See All Projects", 11 },
                    { 248319058, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7), "Dashboard Assign Project Manager", 5 },
                    { 271322859, new DateTime(2024, 3, 20, 12, 37, 34, 420, DateTimeKind.Local).AddTicks(9991), new DateTime(2024, 3, 20, 12, 37, 34, 420, DateTimeKind.Local).AddTicks(9992), "Dashboard Assign Engineer", 4 },
                    { 396639502, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(105), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(107), "Add Project On Dashboard", 12 },
                    { 431455998, new DateTime(2024, 3, 20, 12, 37, 34, 420, DateTimeKind.Local).AddTicks(9960), new DateTime(2024, 3, 20, 12, 37, 34, 420, DateTimeKind.Local).AddTicks(9961), "Dashboard Edit My Hours", 2 },
                    { 488379596, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(63), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(64), "See All Disciplines", 9 },
                    { 555062797, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(35), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(36), "See Admin Layout", 7 },
                    { 571031534, new DateTime(2024, 3, 20, 12, 37, 34, 420, DateTimeKind.Local).AddTicks(9883), new DateTime(2024, 3, 20, 12, 37, 34, 420, DateTimeKind.Local).AddTicks(9885), "See Dashboard Layout", 1 },
                    { 596721414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(78), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(79), "See All Drawings", 10 },
                    { 789480888, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(49), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(50), "Dashboard See My Hours", 8 },
                    { 837367938, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(21), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(22), "Dashboard Add Project", 6 },
                    { 840919078, new DateTime(2024, 3, 20, 12, 37, 34, 420, DateTimeKind.Local).AddTicks(9976), new DateTime(2024, 3, 20, 12, 37, 34, 420, DateTimeKind.Local).AddTicks(9977), "Dashboard Assign Designer", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 215153223, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2487), "Consulting Description", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2488), "Consulting" },
                    { 461984205, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2459), "Infrastructure Description", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2460), "Infrastructure" },
                    { 529992728, false, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2501), "Production Management Description", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2503), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 682629759, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2441), "Buildings Description", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2442), "Buildings" },
                    { 855178719, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2473), "Energy Description", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2474), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 328713661, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(160), false, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(162), "Project Manager" },
                    { 342198539, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(246), false, false, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(247), "Customer" },
                    { 452799718, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(120), false, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(122), "Designer" },
                    { 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(178), false, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(180), "COO" },
                    { 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(192), false, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(194), "CTO" },
                    { 725179365, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(231), false, false, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(232), "Guest" },
                    { 853686655, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(261), false, false, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(263), "Admin" },
                    { 869289150, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(146), false, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(147), "Engineer" },
                    { 953745720, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(276), false, false, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(278), "Secretariat" },
                    { 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(213), false, true, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(214), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 178170325, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1618), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1619), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1881), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1883), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2142), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2144), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1835), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1837), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2229), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2231), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2184), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2185), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2398), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2400), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 285771561, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1664), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1665), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 363166262, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1469), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1470), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 373408464, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1513), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1514), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 404131688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1423), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1425), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2058), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2059), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2100), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2101), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 487356979, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1380), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1381), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1955), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1956), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2314), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2316), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 604025055, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1337), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1338), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2012), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2014), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2357), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2358), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 643411126, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1216), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1217), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1707), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1708), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1749), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1751), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 736483922, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1574), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1575), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 736957498, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1275), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1276), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1793), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1794), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2272), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2274), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 131382119, "cto@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1351), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1352), 604025055 },
                    { 190520997, "chkovras@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1850), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1851), 242435564 },
                    { 207259282, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2245), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2246), 247966110 },
                    { 210000629, "agretos@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2072), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2074), 434205920 },
                    { 213296056, "blekou@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2286), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2288), 936469678 },
                    { 216138895, "dtsa@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1635), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1636), 178170325 },
                    { 218866101, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2412), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2414), 280245665 },
                    { 246565610, "guest@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1439), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1440), 404131688 },
                    { 349831095, "xmanarolis@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1765), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1767), 674869529 },
                    { 351729735, "dtsa@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1679), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1680), 285771561 },
                    { 423125513, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1235), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1237), 643411126 },
                    { 448131401, "sparisis@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1807), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1809), 803771414 },
                    { 519537175, "ngal@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1899), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1900), 210151151 },
                    { 548603569, "panperivollari@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2371), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2373), 643110021 },
                    { 632967074, "vchontos@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2329), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2330), 542392894 },
                    { 725131912, "haris@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2157), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2158), 231384701 },
                    { 742749170, "embiria@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1532), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1534), 373408464 },
                    { 748300608, "kmargeti@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2115), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2117), 453226217 },
                    { 762965114, "kkotsoni@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1970), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1971), 532463714 },
                    { 822636134, "ceo@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1291), 736957498 },
                    { 885335062, "vtza@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2029), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2030), 622676884 },
                    { 915966647, "vpax@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1722), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1723), 652384721 },
                    { 922964566, "coo@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1394), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1395), 487356979 },
                    { 926048866, "pfokianou@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2198), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2200), 260432224 },
                    { 975146635, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1546), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1547), 373408464 },
                    { 976994112, "gdoug@embiria.gr", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1589), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1591), 736483922 },
                    { 979100001, "pm@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1483), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1485), 363166262 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetails", "PendingPayments", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 515415401, false, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 6.0, 1, new DateTime(2024, 4, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 1, "Test Description Project_3", new DateTime(2024, 4, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), new DateTime(2024, 4, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f, 1500L, 12L, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Project_1", 5.0, new DateTime(2024, 4, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Payment Detailes For Project_3", 1.0, 532463714, null, 682629759, new DateTime(2024, 4, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f },
                    { 778893200, true, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 9.0, 16, new DateTime(2025, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 16, "Test Description Project_12", new DateTime(2025, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), new DateTime(2025, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f, 1500L, 12L, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Project_4", 5.0, new DateTime(2025, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Payment Detailes For Project_20", 4.0, 532463714, null, 215153223, new DateTime(2025, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f },
                    { 799576395, true, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 7.0, 4, new DateTime(2024, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 4, "Test Description Project_4", new DateTime(2024, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), new DateTime(2024, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f, 1500L, 12L, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Project_2", 5.0, new DateTime(2024, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Payment Detailes For Project_6", 2.0, 532463714, null, 461984205, new DateTime(2024, 7, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f },
                    { 858659248, true, "ALPHA", 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 111.0, 90, new DateTime(2024, 6, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 1, "Test Description Project_PM", new DateTime(2024, 4, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), new DateTime(2024, 5, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f, 1500L, 12L, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Project_PM", 45.0, new DateTime(2024, 4, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Payment Detailes For Project_PM", 2.0, null, null, 529992728, new DateTime(2024, 5, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f },
                    { 933134526, false, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 8.0, 9, new DateTime(2024, 12, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 9, "Test Description Project_9", new DateTime(2024, 12, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), new DateTime(2024, 12, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f, 1500L, 12L, new DateTime(2024, 3, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Project_3", 5.0, new DateTime(2024, 12, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), "Payment Detailes For Project_15", 3.0, 532463714, null, 855178719, new DateTime(2024, 12, 20, 12, 37, 34, 410, DateTimeKind.Local).AddTicks(3970), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 271322859, 328713661, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(465), -1197126719, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(466) },
                    { 431455998, 328713661, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(451), -1915293797, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(452) },
                    { 488379596, 328713661, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(510), -96748325, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(511) },
                    { 571031534, 328713661, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(437), -1457854744, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(438) },
                    { 596721414, 328713661, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(524), -742627435, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(525) },
                    { 789480888, 328713661, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(479), -1684885927, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(480) },
                    { 571031534, 342198539, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1057), -966519535, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1058) },
                    { 431455998, 452799718, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(316), -453617860, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(318) },
                    { 571031534, 452799718, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(292), -654511868, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(293) },
                    { 789480888, 452799718, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(333), -1051435727, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(335) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 222594205, 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(760), -497418934, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(761) },
                    { 248319058, 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(699), -1277349034, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(700) },
                    { 271322859, 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(581), -1932101266, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(582) },
                    { 431455998, 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(552), 2037993156, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(553) },
                    { 488379596, 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(731), -1706830280, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(732) },
                    { 571031534, 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(538), -128517839, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(539) },
                    { 596721414, 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(745), -265444892, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(747) },
                    { 789480888, 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(714), 1762155086, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(715) },
                    { 840919078, 586692151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(566), 2134709577, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(568) },
                    { 222594205, 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(872), 1021328591, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(873) },
                    { 248319058, 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(802), 1920159167, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(803) },
                    { 396639502, 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(886), -452864605, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(887) },
                    { 431455998, 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(787), -1288524811, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(789) },
                    { 488379596, 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(844), 1292285813, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(845) },
                    { 571031534, 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(773), 1825400754, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(775) },
                    { 596721414, 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(858), -197406044, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(859) },
                    { 789480888, 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(830), -289208690, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(831) },
                    { 837367938, 704730248, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(816), -1127037878, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(817) },
                    { 571031534, 725179365, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1043), 1727453223, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1044) },
                    { 222594205, 853686655, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1114), -1163180429, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1115) },
                    { 488379596, 853686655, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1086), 5304511, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1088) },
                    { 555062797, 853686655, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1072), 2131057427, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1073) },
                    { 596721414, 853686655, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1100), -517958945, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1101) },
                    { 431455998, 869289150, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(364), -1457382541, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(366) },
                    { 488379596, 869289150, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(408), 2069066376, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(409) },
                    { 571031534, 869289150, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(349), -1733567228, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(350) },
                    { 596721414, 869289150, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(422), -1723211338, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(423) },
                    { 789480888, 869289150, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(394), -954968048, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(395) },
                    { 840919078, 869289150, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(379), -636730258, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(381) },
                    { 222594205, 953745720, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1200), -1403752864, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1202) },
                    { 431455998, 953745720, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1144), -1118505095, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1146) },
                    { 488379596, 953745720, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1173), -884139304, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1174) },
                    { 571031534, 953745720, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1128), 1937944157, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1129) },
                    { 596721414, 953745720, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1186), 637086200, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1188) },
                    { 789480888, 953745720, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1159), -352286855, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1160) },
                    { 222594205, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1028), 325623583, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1030) },
                    { 248319058, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(958), 865917392, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(959) },
                    { 271322859, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(944), 1846253538, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(945) },
                    { 431455998, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(916), -1803467654, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(917) },
                    { 488379596, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1000), 362769157, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1002) },
                    { 555062797, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(986), 465169172, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(987) },
                    { 571031534, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(902), 1873963958, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(903) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 596721414, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1014), 869697509, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1016) },
                    { 837367938, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(972), 345414736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(973) },
                    { 840919078, 991187406, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(930), 1495015592, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(931) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 452799718, 178170325, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1649), 202258661, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1650) },
                    { 853686655, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1926), 147349785, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1927) },
                    { 869289150, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1912), 714394190, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1913) },
                    { 991187406, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1940), 656892368, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1941) },
                    { 328713661, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2547), 125935607, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2548) },
                    { 869289150, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2170), 161069241, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2171) },
                    { 869289150, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1864), 525249722, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1865) },
                    { 869289150, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2258), 190416129, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2260) },
                    { 869289150, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2211), 759877560, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2213) },
                    { 869289150, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2426), 279017715, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2427) },
                    { 452799718, 285771561, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1693), 873201994, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1694) },
                    { 328713661, 363166262, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1496), 844391045, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1498) },
                    { 953745720, 373408464, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1559), 836820780, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1561) },
                    { 725179365, 404131688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1454), 123912818, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1455) },
                    { 869289150, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2085), 485886982, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2087) },
                    { 869289150, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2128), 618066236, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2130) },
                    { 586692151, 487356979, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1408), 274354281, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1410) },
                    { 328713661, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2533), 227680557, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2534) },
                    { 586692151, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1998), 817102239, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1999) },
                    { 869289150, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1984), 389556736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1985) },
                    { 869289150, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2343), 516737122, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2344) },
                    { 704730248, 604025055, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1366), 143316591, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1367) },
                    { 869289150, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2043), 153232699, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2044) },
                    { 869289150, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2384), 386699288, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2386) },
                    { 853686655, 643411126, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1254), 505907261, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1255) },
                    { 328713661, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2517), 74268120, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2519) },
                    { 869289150, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1735), 971066623, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1737) },
                    { 869289150, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1778), 645069550, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1780) },
                    { 452799718, 736483922, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1604), 498531957, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1605) },
                    { 991187406, 736957498, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1303), 396108135, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1305) },
                    { 869289150, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1821), 946408943, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(1822) },
                    { 869289150, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2299), 962681135, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2301) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2047848408, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3486), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3487), 858659248, 193643473, null },
                    { -1936504784, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3419), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3420), 933134526, 432040459, null },
                    { -1269109688, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3313), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3314), 515415401, 711197547, null },
                    { -629898280, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3446), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3447), 778893200, 263002349, null },
                    { -378858360, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3378), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3379), 799576395, 721867072, null },
                    { 427538544, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3350), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3351), 515415401, 693874900, null },
                    { 1149860680, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3364), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3366), 799576395, 693874900, null },
                    { 1157252776, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3473), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3474), 778893200, 125156991, null },
                    { 1389204424, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3336), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3338), 515415401, 927801351, null },
                    { 1553621008, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3460), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3461), 778893200, 867184741, null },
                    { 1752513736, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3431), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3432), 933134526, 361761138, null },
                    { 1787426776, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3392), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3393), 799576395, 829827595, null },
                    { 1940794256, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3406), 0f, 500L, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3407), 933134526, 693874900, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 405949447, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2922), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2924), 4000.0, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2923), "Signature 142346", 41756, 933134526, 3.0, 17.0 },
                    { 433686742, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2841), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2844), 3100.0, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2842), "Signature 142342", 23575, 799576395, 2.0, 24.0 },
                    { 712923149, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3005), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3007), 13000.0, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3006), "Signature 1423424", 84850, 778893200, 4.0, 24.0 },
                    { 890942625, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2684), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2686), 3010.0, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2685), "Signature 142345", 42306, 515415401, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 412738556, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2882), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2883), null, "6949277783", null, null, 933134526, "alexpl_{i}@gmail.com" },
                    { 597797750, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2634), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2635), null, "6949277781", null, null, 515415401, "alexpl_{i}@gmail.com" },
                    { 667183185, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2731), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2732), null, "6949277782", null, null, 799576395, "alexpl_{i}@gmail.com" },
                    { 866821755, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2965), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2966), null, "6949277784", null, null, 778893200, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1936504784, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6634), 281138289, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6635) },
                    { -1936504784, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6697), 391403962, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6698) },
                    { -1936504784, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6621), 152185764, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6622) },
                    { -1936504784, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6721), 683175515, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6722) },
                    { -1936504784, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6709), 161055023, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6710) },
                    { -1936504784, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6771), 844951662, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6772) },
                    { -1936504784, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6671), 244633492, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6673) },
                    { -1936504784, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6684), 839594567, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6685) },
                    { -1936504784, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6646), 760711031, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6647) },
                    { -1936504784, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6746), 887352820, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6747) },
                    { -1936504784, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6659), 259411171, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6660) },
                    { -1936504784, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6758), 791753487, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6760) },
                    { -1936504784, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6584), 535984987, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6585) },
                    { -1936504784, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6596), 513570692, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6597) },
                    { -1936504784, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6609), 397540959, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6610) },
                    { -1936504784, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6734), 201866281, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6735) },
                    { -1269109688, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5083), 671459667, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5084) },
                    { -1269109688, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5148), 834179335, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5150) },
                    { -1269109688, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5070), 589862831, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5072) },
                    { -1269109688, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5173), 799084299, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5175) },
                    { -1269109688, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5161), 807600545, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5162) },
                    { -1269109688, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5286), 226109087, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5287) },
                    { -1269109688, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5122), 393983101, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5123) },
                    { -1269109688, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5135), 757996179, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5136) },
                    { -1269109688, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5097), 275478704, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5098) },
                    { -1269109688, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5199), 399340907, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5200) },
                    { -1269109688, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5110), 238493444, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5111) },
                    { -1269109688, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5211), 444073391, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5212) },
                    { -1269109688, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5025), 849144460, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5026) },
                    { -1269109688, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5045), 818756759, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5046) },
                    { -1269109688, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5058), 507404060, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5059) },
                    { -1269109688, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5186), 343406661, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5188) },
                    { -629898280, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7045), 877447559, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7046) },
                    { -629898280, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7108), 172716776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7109) },
                    { -629898280, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7029), 476810106, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7031) },
                    { -629898280, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7134), 890722470, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7135) },
                    { -629898280, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7121), 371388068, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7122) },
                    { -629898280, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7185), 576131796, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7186) },
                    { -629898280, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7082), 924021197, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7084) },
                    { -629898280, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7095), 904629455, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7096) },
                    { -629898280, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7057), 881007318, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7058) },
                    { -629898280, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7159), 184810599, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7161) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -629898280, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7070), 929300270, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7071) },
                    { -629898280, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7172), 294714713, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7173) },
                    { -629898280, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6992), 259999468, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6993) },
                    { -629898280, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7004), 186142328, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7006) },
                    { -629898280, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7017), 140652159, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7018) },
                    { -629898280, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7147), 587757312, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7148) },
                    { -378858360, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5968), 698264797, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5970) },
                    { -378858360, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6033), 776926873, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6034) },
                    { -378858360, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5956), 173535794, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5957) },
                    { -378858360, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6106), 401425105, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6107) },
                    { -378858360, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6046), 543605600, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6047) },
                    { -378858360, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6161), 720559579, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6162) },
                    { -378858360, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6006), 189408039, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6008) },
                    { -378858360, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6020), 858265763, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6021) },
                    { -378858360, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5981), 458238679, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5982) },
                    { -378858360, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6135), 590682812, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6136) },
                    { -378858360, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5993), 566003979, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5995) },
                    { -378858360, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6148), 248566528, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6150) },
                    { -378858360, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5917), 925156158, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5918) },
                    { -378858360, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5931), 946682153, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5932) },
                    { -378858360, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5943), 674980823, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5945) },
                    { -378858360, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6119), 577065820, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6120) },
                    { 427538544, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5559), 883529181, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5560) },
                    { 427538544, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5622), 378180823, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5624) },
                    { 427538544, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5546), 257211464, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5547) },
                    { 427538544, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5647), 337667561, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5649) },
                    { 427538544, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5635), 756839235, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5636) },
                    { 427538544, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5700), 210233635, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5701) },
                    { 427538544, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5597), 828606597, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5598) },
                    { 427538544, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5609), 716726784, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5611) },
                    { 427538544, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5571), 731641077, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5572) },
                    { 427538544, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5673), 587945609, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5674) },
                    { 427538544, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5584), 142539833, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5585) },
                    { 427538544, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5685), 981094121, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5687) },
                    { 427538544, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5507), 298131709, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5508) },
                    { 427538544, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5521), 610904803, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5522) },
                    { 427538544, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5533), 603199327, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5535) },
                    { 427538544, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5660), 223617808, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5661) },
                    { 1149860680, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5767), 614811332, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5768) },
                    { 1149860680, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5829), 621436067, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5830) },
                    { 1149860680, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5754), 661152441, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5755) },
                    { 1149860680, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5854), 932428831, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5856) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1149860680, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5842), 364365039, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5843) },
                    { 1149860680, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5904), 165886816, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5906) },
                    { 1149860680, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5804), 590839975, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5805) },
                    { 1149860680, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5816), 842868849, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5818) },
                    { 1149860680, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5779), 522900554, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5780) },
                    { 1149860680, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5879), 288732637, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5880) },
                    { 1149860680, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5791), 793180126, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5792) },
                    { 1149860680, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5892), 526894008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5893) },
                    { 1149860680, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5713), 373949230, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5714) },
                    { 1149860680, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5725), 488729719, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5727) },
                    { 1149860680, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5741), 190114290, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5742) },
                    { 1149860680, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5867), 745788456, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5868) },
                    { 1157252776, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7459), 365110822, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7460) },
                    { 1157252776, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7522), 825233728, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7523) },
                    { 1157252776, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7446), 798056573, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7447) },
                    { 1157252776, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7547), 994566403, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7549) },
                    { 1157252776, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7534), 926194365, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7536) },
                    { 1157252776, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7598), 833217705, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7599) },
                    { 1157252776, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7497), 170658870, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7498) },
                    { 1157252776, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7509), 586404238, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7511) },
                    { 1157252776, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7471), 431336770, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7472) },
                    { 1157252776, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7572), 776225732, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7574) },
                    { 1157252776, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7483), 944747181, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7485) },
                    { 1157252776, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7585), 128459301, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7586) },
                    { 1157252776, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7407), 709035020, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7408) },
                    { 1157252776, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7420), 608197805, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7421) },
                    { 1157252776, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7433), 191849929, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7434) },
                    { 1157252776, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7560), 563598915, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7561) },
                    { 1389204424, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5351), 442542298, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5352) },
                    { 1389204424, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5418), 982668425, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5419) },
                    { 1389204424, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5338), 452414604, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5339) },
                    { 1389204424, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5443), 637843063, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5444) },
                    { 1389204424, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5430), 158843383, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5431) },
                    { 1389204424, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5495), 283216031, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5496) },
                    { 1389204424, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5392), 636190887, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5394) },
                    { 1389204424, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5405), 760260930, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5406) },
                    { 1389204424, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5366), 633991879, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5368) },
                    { 1389204424, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5468), 752209194, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5469) },
                    { 1389204424, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5379), 401081889, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5380) },
                    { 1389204424, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5481), 724314260, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5482) },
                    { 1389204424, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5299), 930239309, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5300) },
                    { 1389204424, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5313), 959057050, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5314) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1389204424, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5326), 384181642, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5327) },
                    { 1389204424, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5456), 224035148, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5457) },
                    { 1553621008, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7252), 802653642, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7253) },
                    { 1553621008, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7318), 396764349, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7319) },
                    { 1553621008, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7238), 487095559, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7240) },
                    { 1553621008, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7344), 940941811, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7345) },
                    { 1553621008, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7330), 772405737, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7331) },
                    { 1553621008, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7394), 966123083, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7395) },
                    { 1553621008, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7290), 798689876, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7291) },
                    { 1553621008, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7303), 961399953, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7304) },
                    { 1553621008, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7264), 443267448, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7265) },
                    { 1553621008, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7369), 149138679, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7370) },
                    { 1553621008, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7277), 520965891, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7278) },
                    { 1553621008, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7381), 696788656, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7383) },
                    { 1553621008, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7198), 423834864, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7199) },
                    { 1553621008, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7210), 353521731, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7211) },
                    { 1553621008, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7225), 512926257, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7227) },
                    { 1553621008, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7356), 521827123, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(7357) },
                    { 1752513736, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6841), 846586812, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6843) },
                    { 1752513736, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6904), 134579352, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6905) },
                    { 1752513736, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6829), 495697115, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6830) },
                    { 1752513736, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6929), 166948825, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6930) },
                    { 1752513736, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6917), 266898575, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6918) },
                    { 1752513736, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6979), 476823802, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6980) },
                    { 1752513736, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6880), 579779739, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6881) },
                    { 1752513736, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6892), 959959153, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6893) },
                    { 1752513736, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6854), 470939129, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6855) },
                    { 1752513736, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6954), 938979293, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6955) },
                    { 1752513736, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6867), 541596041, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6868) },
                    { 1752513736, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6967), 379899486, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6968) },
                    { 1752513736, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6784), 655992264, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6785) },
                    { 1752513736, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6798), 727383583, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6799) },
                    { 1752513736, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6811), 525333048, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6812) },
                    { 1752513736, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6942), 784593295, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6943) },
                    { 1787426776, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6224), 691555624, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6225) },
                    { 1787426776, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6287), 981154601, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6288) },
                    { 1787426776, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6212), 606002541, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6213) },
                    { 1787426776, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6312), 856343298, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6313) },
                    { 1787426776, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6299), 697118775, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6301) },
                    { 1787426776, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6362), 288641375, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6364) },
                    { 1787426776, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6262), 615385313, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6263) },
                    { 1787426776, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6274), 544505712, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6275) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1787426776, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6237), 975703544, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6238) },
                    { 1787426776, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6337), 983587532, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6338) },
                    { 1787426776, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6249), 925040130, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6251) },
                    { 1787426776, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6349), 897727749, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6351) },
                    { 1787426776, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6174), 558118623, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6175) },
                    { 1787426776, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6186), 770617377, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6188) },
                    { 1787426776, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6199), 668797062, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6200) },
                    { 1787426776, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6325), 911645286, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6326) },
                    { 1940794256, 210151151, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6425), 288489060, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6427) },
                    { 1940794256, 231384701, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6489), 758872018, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6490) },
                    { 1940794256, 242435564, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6413), 373458008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6414) },
                    { 1940794256, 247966110, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6514), 720085435, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6516) },
                    { 1940794256, 260432224, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6502), 408528441, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6503) },
                    { 1940794256, 280245665, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6570), 419344532, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6571) },
                    { 1940794256, 434205920, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6464), 464784263, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6465) },
                    { 1940794256, 453226217, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6477), 616244733, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6478) },
                    { 1940794256, 532463714, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6438), 681223377, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6439) },
                    { 1940794256, 542392894, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6544), 289665411, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6545) },
                    { 1940794256, 622676884, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6450), 627862471, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6452) },
                    { 1940794256, 643110021, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6557), 998261413, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6558) },
                    { 1940794256, 652384721, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6375), 508517995, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6377) },
                    { 1940794256, 674869529, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6388), 315851707, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6389) },
                    { 1940794256, 803771414, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6401), 430869319, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6402) },
                    { 1940794256, 936469678, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6530), 828701932, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(6532) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 138726760, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3664), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3661), 427538544, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3662), 287621790 },
                    { 184427049, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3734), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3732), -378858360, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3733), 871101896 },
                    { 192348392, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3762), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3759), -378858360, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3761), 249609812 },
                    { 223327713, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3790), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3787), 1787426776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3788), 287621790 },
                    { 246822186, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3847), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3844), 1940794256, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3845), 249609812 },
                    { 260297651, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3649), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3646), 427538544, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3647), 871101896 },
                    { 260640648, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4032), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4030), 1157252776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4031), 871101896 },
                    { 289536474, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3989), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3987), 1553621008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3988), 871101896 },
                    { 309064811, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3573), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3570), -1269109688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3571), 287621790 },
                    { 327162341, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3616), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3613), 1389204424, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3615), 287621790 },
                    { 377780652, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3554), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3551), -1269109688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3552), 871101896 },
                    { 400081362, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3776), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3773), 1787426776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3775), 871101896 },
                    { 433141867, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3972), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3969), -629898280, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3970), 249609812 },
                    { 440370524, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3677), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3675), 427538544, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3676), 249609812 },
                    { 441396359, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3748), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3746), -378858360, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3747), 287621790 },
                    { 465220792, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3889), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3886), -1936504784, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3887), 249609812 },
                    { 473997413, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3861), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3858), -1936504784, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3860), 871101896 },
                    { 474267348, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4091), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4089), -2047848408, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4090), 287621790 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 486571709, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3875), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3872), -1936504784, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3874), 287621790 },
                    { 517028063, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3944), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3942), -629898280, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3943), 871101896 },
                    { 538853879, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3819), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3817), 1940794256, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3818), 871101896 },
                    { 566539134, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3833), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3831), 1940794256, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3832), 287621790 },
                    { 618976112, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4060), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4058), 1157252776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4059), 249609812 },
                    { 621171362, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3601), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3599), 1389204424, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3600), 871101896 },
                    { 621234682, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3958), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3956), -629898280, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3957), 287621790 },
                    { 635159075, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3930), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3928), 1752513736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3929), 249609812 },
                    { 661430602, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4016), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4014), 1553621008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4015), 249609812 },
                    { 688027111, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3631), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3629), 1389204424, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3630), 249609812 },
                    { 718039640, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3706), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3704), 1149860680, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3705), 287621790 },
                    { 738477194, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4105), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4102), -2047848408, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4103), 249609812 },
                    { 752076130, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3720), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3718), 1149860680, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3719), 249609812 },
                    { 757425028, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3916), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3914), 1752513736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3915), 287621790 },
                    { 757855157, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3805), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3803), 1787426776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3804), 249609812 },
                    { 783987905, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4075), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4072), -2047848408, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4074), 871101896 },
                    { 828237982, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4047), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4044), 1157252776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4046), 287621790 },
                    { 835146266, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3692), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3690), 1149860680, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3691), 871101896 },
                    { 841559902, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3903), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3900), 1752513736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3901), 871101896 },
                    { 858960312, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3587), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3584), -1269109688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(3586), 249609812 },
                    { 961156651, new DateTime(2024, 3, 31, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4003), 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4000), 1553621008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4001), 287621790 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 681942840, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2815), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2816), 667183185 },
                    { 742822222, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2653), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2654), 597797750 },
                    { 916504053, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2979), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2980), 866821755 },
                    { 988015509, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2897), new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2898), 412738556 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 138652971, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4617), 1940794256, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4618), 819713473 },
                    { 146353318, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4222), -1269109688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4223), 227643766 },
                    { 150952930, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4390), 1149860680, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4391), 981724041 },
                    { 153377770, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4377), 427538544, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4378), 308871482 },
                    { 158591475, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4465), -378858360, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4466), 562948469 },
                    { 160520534, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4273), 1389204424, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4274), 562948469 },
                    { 186958336, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4952), -2047848408, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4954), 981724041 },
                    { 191419518, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4865), 1553621008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4866), 819713473 },
                    { 214555701, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4564), 1787426776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4565), 308871482 },
                    { 240686531, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4514), 1787426776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4515), 981724041 },
                    { 246921379, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4600), 1940794256, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4602), 227643766 },
                    { 256298226, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4285), 1389204424, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4287), 227643766 },
                    { 283727885, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4655), -1936504784, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4656), 562948469 },
                    { 287621030, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4803), -629898280, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4804), 819713473 },
                    { 302797872, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4501), -378858360, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4502), 308871482 },
                    { 313628303, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4193), -1269109688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4194), 981724041 },
                    { 315453618, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4828), 1553621008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4829), 981724041 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 315907744, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4551), 1787426776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4552), 819713473 },
                    { 316722234, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4209), -1269109688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4211), 562948469 },
                    { 324846273, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4816), -629898280, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4817), 308871482 },
                    { 351518474, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4364), 427538544, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4365), 819713473 },
                    { 356717583, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4527), 1787426776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4528), 562948469 },
                    { 358929292, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4314), 1389204424, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4315), 308871482 },
                    { 371823822, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4402), 1149860680, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4403), 562948469 },
                    { 417191582, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4729), 1752513736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4730), 227643766 },
                    { 418758428, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4440), 1149860680, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4442), 308871482 },
                    { 440727530, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4791), -629898280, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4792), 227643766 },
                    { 463466718, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4260), 1389204424, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4261), 981724041 },
                    { 479195247, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4428), 1149860680, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4429), 819713473 },
                    { 486074142, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4576), 1940794256, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4577), 981724041 },
                    { 495146437, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4840), 1553621008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4841), 562948469 },
                    { 503296905, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4926), 1157252776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4927), 819713473 },
                    { 524220941, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4995), -2047848408, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4996), 819713473 },
                    { 531822575, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4692), -1936504784, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4693), 308871482 },
                    { 531993274, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4630), 1940794256, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4631), 308871482 },
                    { 555036125, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4247), -1269109688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4248), 308871482 },
                    { 570377513, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4643), -1936504784, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4644), 981724041 },
                    { 603700916, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4416), 1149860680, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4417), 227643766 },
                    { 617574060, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4778), -629898280, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4780), 562948469 },
                    { 621544123, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5008), -2047848408, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(5009), 308871482 },
                    { 624791415, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4352), 427538544, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4353), 227643766 },
                    { 630660201, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4489), -378858360, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4490), 819713473 },
                    { 633326444, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4339), 427538544, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4341), 562948469 },
                    { 682259892, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4966), -2047848408, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4967), 562948469 },
                    { 694405902, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4234), -1269109688, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4236), 819713473 },
                    { 730221767, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4982), -2047848408, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4983), 227643766 },
                    { 747335041, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4327), 427538544, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4328), 981724041 },
                    { 747649251, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4742), 1752513736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4743), 819713473 },
                    { 758440276, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4938), 1157252776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4940), 308871482 },
                    { 780433464, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4754), 1752513736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4755), 308871482 },
                    { 791546900, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4705), 1752513736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4706), 981724041 },
                    { 797834113, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4300), 1389204424, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4301), 819713473 },
                    { 804534438, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4717), 1752513736, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4718), 562948469 },
                    { 806614154, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4766), -629898280, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4768), 981724041 },
                    { 831032874, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4539), 1787426776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4540), 227643766 },
                    { 849040119, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4852), 1553621008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4853), 227643766 },
                    { 855702172, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4668), -1936504784, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4669), 227643766 },
                    { 862546974, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4588), 1940794256, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4589), 562948469 },
                    { 873621073, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4877), 1553621008, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4878), 308871482 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 888178661, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4901), 1157252776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4902), 562948469 },
                    { 905409035, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4680), -1936504784, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4681), 819713473 },
                    { 956828366, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4914), 1157252776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4915), 227643766 },
                    { 981702846, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4477), -378858360, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4478), 227643766 },
                    { 991029620, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4889), 1157252776, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4890), 981724041 },
                    { 997214055, 0f, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4453), -378858360, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(4454), 981724041 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 342198539, 412738556, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2909), 403918475, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2910) },
                    { 342198539, 597797750, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2667), 298677966, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2668) },
                    { 342198539, 667183185, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2828), 127617903, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2829) },
                    { 342198539, 866821755, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2992), 245596347, new DateTime(2024, 3, 20, 12, 37, 34, 421, DateTimeKind.Local).AddTicks(2993) }
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
