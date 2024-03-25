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
                    { 163508546, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6090), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6091), "Elevators" },
                    { 247558954, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6224), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6225), "Construction Supervision" },
                    { 249670469, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6114), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6115), "Power Distribution" },
                    { 274705103, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6063), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6064), "Fire Detection" },
                    { 276743705, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6127), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6128), "Structured Cabling" },
                    { 300959392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6151), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6153), "CCTV" },
                    { 319613250, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6004), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6005), "HVAC" },
                    { 409220417, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6048), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6049), "Drainage" },
                    { 439530165, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6210), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6211), "TenderDocument" },
                    { 490086703, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6163), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6164), "BMS" },
                    { 634295574, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6236), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6237), "DWG Admin/Clearing" },
                    { 680295466, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6139), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6140), "Burglar Alarm" },
                    { 701719135, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6175), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6176), "Photovoltaics" },
                    { 739677119, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6023), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6024), "Sewage" },
                    { 745361118, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6199), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6200), "Outsource" },
                    { 789550187, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6187), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6188), "Energy Efficiency" },
                    { 830297324, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6036), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6037), "Potable Water" },
                    { 887476406, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6248), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6250), "Project Manager Hours" },
                    { 894329640, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6102), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6104), "Natural Gas" },
                    { 911420494, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6078), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6079), "Fire Suppression" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 176720701, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6495), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6496), "Drawings" },
                    { 229160176, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6464), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6465), "Documents" },
                    { 765172007, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6482), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6483), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 126510717, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7188), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7189), "Hours To Be Raised" },
                    { 139645808, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7106), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7107), "Communications" },
                    { 171420633, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7162), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7163), "Administration" },
                    { 301635973, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7126), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7127), "Printing" },
                    { 569296285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7176), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7177), "Soft Copy" },
                    { 768035898, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7150), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7151), "Meetings" },
                    { 811221262, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7138), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7139), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 172533509, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3613), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3614), "Display Projects Code", 13 },
                    { 195191786, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3445), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3446), "Dashboard Edit My Hours", 2 },
                    { 219897878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3547), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3548), "See All Disciplines", 9 },
                    { 309562400, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3627), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3628), "Dashboard Add Discipline", 14 },
                    { 422097288, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3561), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3562), "See All Drawings", 10 },
                    { 515749426, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3640), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3641), "Dashboard Add Deliverable", 15 },
                    { 582768084, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3587), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3588), "See All Projects", 11 },
                    { 633470398, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3475), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3477), "Dashboard Assign Engineer", 4 },
                    { 706207570, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3461), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3462), "Dashboard Assign Designer", 3 },
                    { 713566316, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3351), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3353), "See Dashboard Layout", 1 },
                    { 750538360, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3490), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3491), "Dashboard Assign Project Manager", 5 },
                    { 770363615, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3600), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3601), "Add Project On Dashboard", 12 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 834914836, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3506), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3508), "Dashboard Add Project", 6 },
                    { 862628355, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3534), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3535), "Dashboard See My Hours", 8 },
                    { 907198829, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3520), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3521), "See Admin Layout", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 182958832, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5724), "Energy Description", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5725), "Energy" },
                    { 219934156, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5737), "Consulting Description", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5738), "Consulting" },
                    { 414193021, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5706), "Infrastructure Description", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5708), "Infrastructure" },
                    { 453449029, false, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5750), "Production Management Description", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5751), "Production Management" },
                    { 898172105, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5688), "Buildings Description", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5691), "Buildings" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 161163534, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3678), false, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3679), "Engineer" },
                    { 204165609, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3793), false, false, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3794), "Secretariat" },
                    { 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3705), false, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3706), "COO" },
                    { 317013260, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3692), false, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3693), "Project Manager" },
                    { 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3734), false, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3735), "CEO" },
                    { 648912271, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3751), false, false, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3752), "Guest" },
                    { 712364947, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3655), false, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3656), "Designer" },
                    { 917975659, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3765), false, false, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3766), "Customer" },
                    { 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3719), false, true, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3720), "CTO" },
                    { 947179560, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3779), false, false, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3780), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5198), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5199), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5055), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5056), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 315581439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4923), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4925), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5010), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5011), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5266), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5267), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4967), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4968), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5139), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5140), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5437), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5438), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5478), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5480), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5347), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5349), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5520), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5522), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5097), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5098), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5562), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5564), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 725989395, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4759), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4760), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 732790100, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4880), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4881), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5307), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5308), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5605), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5606), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 875049465, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4837), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4838), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5647), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5648), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5393), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5394), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 159604405, "vtza@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5279), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5280), 366262527 },
                    { 171010252, "pfokianou@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5451), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5453), 440970855 },
                    { 188411786, "ngal@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5155), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5156), 410467878 },
                    { 212549913, "panperivollari@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5619), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5621), 839370213 },
                    { 255707277, "xmanarolis@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5025), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5026), 355603848 },
                    { 292453254, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5661), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5662), 886170439 },
                    { 321756929, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5493), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5494), 443875517 },
                    { 413602615, "dtsa@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4895), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4896), 732790100 },
                    { 413613836, "blekou@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5535), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5536), 475969285 },
                    { 444153361, "embiria@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4782), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4783), 725989395 },
                    { 565369660, "vpax@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4982), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4983), 376761470 },
                    { 590379588, "agretos@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5320), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5322), 732853784 },
                    { 664882153, "vchontos@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5577), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5578), 700006525 },
                    { 696599109, "chkovras@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5111), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5113), 558600702 },
                    { 729169227, "sparisis@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5069), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5071), 225797441 },
                    { 749058663, "dtsa@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4937), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4938), 315581439 },
                    { 773660161, "gdoug@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4852), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4853), 875049465 },
                    { 782374130, "kmargeti@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5363), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5364), 469142350 },
                    { 791313190, "haris@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5407), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5408), 887320685 },
                    { 868858477, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4799), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4800), 725989395 },
                    { 928470276, "kkotsoni@embiria.gr", new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5212), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5213), 182780207 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 321505758, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), new DateTime(2024, 7, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Test Description Project_6", new DateTime(2024, 7, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 0f, new DateTime(2024, 7, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Project_2", 182780207, null, 414193021, 0f },
                    { 393082206, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), new DateTime(2024, 4, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Test Description Project_4", new DateTime(2024, 4, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 0f, new DateTime(2024, 4, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Project_1", 182780207, null, 898172105, 0f },
                    { 685798548, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), new DateTime(2024, 6, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Test Description Project_PM", new DateTime(2024, 4, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 0f, new DateTime(2024, 5, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 1500L, 12L, null, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Project_PM", null, null, 453449029, 0f },
                    { 735277599, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), new DateTime(2024, 12, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Test Description Project_6", new DateTime(2024, 12, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 0f, new DateTime(2024, 12, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Project_3", 182780207, null, 182958832, 0f },
                    { 981038064, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), new DateTime(2025, 7, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Test Description Project_24", new DateTime(2025, 7, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 0f, new DateTime(2025, 7, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 16, 21, 14, 644, DateTimeKind.Local).AddTicks(2299), "Project_4", 182780207, null, 219934156, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 195191786, 161163534, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3870), 2096838936, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3871) },
                    { 219897878, 161163534, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3913), -336811387, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3915) },
                    { 422097288, 161163534, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3948), 1894940024, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3949) },
                    { 706207570, 161163534, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3886), 1652228316, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3887) },
                    { 713566316, 161163534, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3857), 234664975, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3858) },
                    { 862628355, 161163534, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3900), 1717478294, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3901) },
                    { 195191786, 204165609, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4690), -1569311167, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4692) },
                    { 219897878, 204165609, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4717), 2056620704, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4718) },
                    { 422097288, 204165609, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4731), 1392980153, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4732) },
                    { 582768084, 204165609, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4744), 1076919791, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4745) },
                    { 713566316, 204165609, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4673), 602473685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4674) },
                    { 862628355, 204165609, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4704), -831009874, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4705) },
                    { 195191786, 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4159), -1441351453, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4160) },
                    { 219897878, 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4229), 295864885, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4231) },
                    { 422097288, 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4243), 1243598868, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4244) },
                    { 582768084, 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4258), -1647270917, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4259) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 633470398, 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4188), -735640775, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4189) },
                    { 706207570, 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4174), -82580084, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4176) },
                    { 713566316, 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4146), -1676638606, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4147) },
                    { 750538360, 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4202), -837185822, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4203) },
                    { 862628355, 241761256, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4215), -1122611471, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4217) },
                    { 195191786, 317013260, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4077), -245047445, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4078) },
                    { 219897878, 317013260, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4118), -373878197, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4119) },
                    { 422097288, 317013260, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4131), 1101552440, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4133) },
                    { 633470398, 317013260, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4090), 1518044288, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4091) },
                    { 713566316, 317013260, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4063), 1720050476, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4064) },
                    { 862628355, 317013260, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4104), -986109187, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4105) },
                    { 172533509, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4562), -1000272208, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4563) },
                    { 195191786, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4440), -222929918, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4441) },
                    { 219897878, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4520), -965546198, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4521) },
                    { 422097288, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4534), 1266981710, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4535) },
                    { 582768084, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4548), 664452284, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4549) },
                    { 633470398, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4467), 1637248577, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4468) },
                    { 706207570, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4453), -1918012031, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4454) },
                    { 713566316, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4425), 2075666796, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4427) },
                    { 750538360, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4493), 509513882, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4494) },
                    { 770363615, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4577), -1519300295, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4578) },
                    { 834914836, 542503937, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4507), -294261893, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4508) },
                    { 713566316, 648912271, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4590), -1423930895, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4592) },
                    { 195191786, 712364947, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3829), -419781905, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3830) },
                    { 713566316, 712364947, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3808), 253722362, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3809) },
                    { 862628355, 712364947, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3843), -46548742, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(3845) },
                    { 713566316, 917975659, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4604), -684033146, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4605) },
                    { 195191786, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4288), -1589222627, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4290) },
                    { 219897878, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4342), -2035437821, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4344) },
                    { 309562400, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4398), -2119518269, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4399) },
                    { 422097288, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4356), 2096707248, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4357) },
                    { 515749426, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4412), 1426264313, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4413) },
                    { 582768084, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4369), 1493785665, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4370) },
                    { 713566316, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4274), 75261898, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4275) },
                    { 750538360, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4302), 1140526868, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4303) },
                    { 770363615, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4383), -1377107729, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4384) },
                    { 834914836, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4315), 2060920211, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4317) },
                    { 862628355, 942266358, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4329), 1849880390, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4330) },
                    { 219897878, 947179560, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4632), 254378395, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4633) },
                    { 422097288, 947179560, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4646), -1648426918, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4647) },
                    { 582768084, 947179560, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4659), -639506497, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4660) },
                    { 907198829, 947179560, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4618), 1764882990, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4619) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 161163534, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5225), 265581585, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5226) },
                    { 241761256, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5239), 279749083, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5240) },
                    { 317013260, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5780), 133754450, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5781) },
                    { 942266358, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5252), 369650566, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5253) },
                    { 161163534, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5083), 143490590, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5084) },
                    { 712364947, 315581439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4952), 955000709, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4953) },
                    { 161163534, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5038), 146468115, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5040) },
                    { 161163534, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5293), 375805581, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5294) },
                    { 161163534, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4995), 548033588, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4996) },
                    { 317013260, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5764), 263372413, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5766) },
                    { 161163534, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5169), 903763862, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5170) },
                    { 542503937, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5184), 915521514, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5185) },
                    { 161163534, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5465), 330597896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5466) },
                    { 161163534, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5506), 554545540, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5508) },
                    { 161163534, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5376), 730350576, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5377) },
                    { 161163534, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5548), 490488403, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5550) },
                    { 161163534, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5125), 916723412, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5127) },
                    { 161163534, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5591), 557541327, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5592) },
                    { 204165609, 725989395, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4815), 316404981, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4816) },
                    { 712364947, 732790100, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4908), 422842486, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4910) },
                    { 161163534, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5334), 881704695, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5335) },
                    { 161163534, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5633), 220846729, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5634) },
                    { 712364947, 875049465, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4866), 139244469, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(4868) },
                    { 161163534, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5674), 196884542, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5675) },
                    { 161163534, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5421), 249691390, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5422) },
                    { 317013260, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5793), 242305448, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5795) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1110141984, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6337), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6338), 321505758, 745361118, null },
                    { -1106953896, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6297), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6298), 393082206, 701719135, null },
                    { -1043482432, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6324), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6325), 321505758, 490086703, null },
                    { -870476720, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6310), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6311), 393082206, 789550187, null },
                    { -718226552, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6420), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6421), 981038064, 739677119, null },
                    { -670133000, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6445), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6446), 685798548, 887476406, null },
                    { -533335856, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6276), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6277), 393082206, 680295466, null },
                    { -254850064, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6364), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6366), 735277599, 319613250, null },
                    { 351106080, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6433), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6434), 981038064, 276743705, null },
                    { 377426392, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6377), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6378), 735277599, 274705103, null },
                    { 774309784, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6407), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6408), 981038064, 319613250, null },
                    { 1004035960, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6351), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6352), 321505758, 163508546, null },
                    { 2048166264, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6392), 0f, 500L, 0L, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6393), 735277599, 300959392, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 185173314, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5940), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5942), 4000.0, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5941), "Signature 1423412", 87400, 735277599, 3.0, 17.0 },
                    { 387266864, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5971), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5973), 13000.0, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5972), "Signature 142344", 30567, 981038064, 4.0, 24.0 },
                    { 538410351, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5865), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5867), 3010.0, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5866), "Signature 142345", 83310, 393082206, 1.0, 17.0 },
                    { 818355779, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5907), new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5909), 3100.0, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(5908), "Signature 142342", 81769, 321505758, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1110141984, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9408), 472941893, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9409) },
                    { -1110141984, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9371), 668649197, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9372) },
                    { -1110141984, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9359), 884930009, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9360) },
                    { -1110141984, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9419), 278708319, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9420) },
                    { -1110141984, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9346), 182184540, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9347) },
                    { -1110141984, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9395), 985415849, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9396) },
                    { -1110141984, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9468), 904924441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9469) },
                    { -1110141984, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9480), 300937330, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9481) },
                    { -1110141984, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9444), 657301129, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9445) },
                    { -1110141984, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9520), 212685453, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9521) },
                    { -1110141984, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9383), 518657447, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9384) },
                    { -1110141984, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9533), 928592548, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9534) },
                    { -1110141984, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9431), 194081977, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9432) },
                    { -1110141984, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9545), 196113778, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9546) },
                    { -1110141984, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9557), 429241571, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9558) },
                    { -1110141984, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9456), 718276626, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9457) },
                    { -1106953896, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8786), 243319366, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8787) },
                    { -1106953896, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8722), 978597957, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8723) },
                    { -1106953896, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8710), 779019859, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8711) },
                    { -1106953896, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8799), 293899278, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8800) },
                    { -1106953896, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8697), 228296422, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8698) },
                    { -1106953896, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8747), 470469634, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8748) },
                    { -1106953896, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8849), 613223245, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8850) },
                    { -1106953896, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8862), 595208477, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8863) },
                    { -1106953896, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8825), 516891733, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8826) },
                    { -1106953896, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8874), 622347885, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8875) },
                    { -1106953896, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8735), 699292905, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8736) },
                    { -1106953896, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8886), 440361816, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8887) },
                    { -1106953896, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8812), 975591509, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8813) },
                    { -1106953896, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8898), 133733368, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8900) },
                    { -1106953896, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8911), 959452704, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8912) },
                    { -1106953896, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8837), 596150709, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8838) },
                    { -1043482432, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9211), 402073321, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9212) },
                    { -1043482432, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9173), 632946513, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9174) },
                    { -1043482432, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9160), 960889137, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9161) },
                    { -1043482432, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9224), 495412741, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9225) },
                    { -1043482432, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9122), 571319158, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9123) },
                    { -1043482432, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9198), 907144746, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9199) },
                    { -1043482432, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9273), 795067618, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9274) },
                    { -1043482432, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9285), 903618150, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9286) },
                    { -1043482432, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9248), 971376196, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9249) },
                    { -1043482432, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9297), 903405264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9298) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1043482432, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9186), 833793566, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9187) },
                    { -1043482432, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9309), 458770541, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9310) },
                    { -1043482432, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9236), 609611972, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9237) },
                    { -1043482432, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9321), 546961321, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9322) },
                    { -1043482432, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9333), 878248572, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9334) },
                    { -1043482432, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9260), 402217459, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9261) },
                    { -870476720, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8986), 566166285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8987) },
                    { -870476720, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8949), 227466018, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8950) },
                    { -870476720, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8936), 156576193, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8938) },
                    { -870476720, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8998), 918025332, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8999) },
                    { -870476720, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8923), 988459145, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8925) },
                    { -870476720, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8973), 897351530, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8975) },
                    { -870476720, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9048), 585052491, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9049) },
                    { -870476720, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9060), 779790215, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9061) },
                    { -870476720, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9023), 855680425, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9024) },
                    { -870476720, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9073), 143408250, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9074) },
                    { -870476720, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8961), 640434859, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8962) },
                    { -870476720, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9085), 737936422, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9086) },
                    { -870476720, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9010), 736616151, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9011) },
                    { -870476720, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9097), 192248308, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9098) },
                    { -870476720, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9109), 541662607, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9110) },
                    { -870476720, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9036), 410599560, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9037) },
                    { -718226552, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(699), 955473874, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(700) },
                    { -718226552, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(662), 563042493, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(663) },
                    { -718226552, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(648), 953766300, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(649) },
                    { -718226552, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(712), 244485585, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(713) },
                    { -718226552, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(611), 960752293, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(612) },
                    { -718226552, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(687), 295248173, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(688) },
                    { -718226552, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(763), 527389295, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(764) },
                    { -718226552, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(776), 204300928, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(777) },
                    { -718226552, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(738), 567942675, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(739) },
                    { -718226552, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(788), 983695055, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(789) },
                    { -718226552, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(674), 650584364, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(675) },
                    { -718226552, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(801), 359309262, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(802) },
                    { -718226552, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(724), 768229544, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(725) },
                    { -718226552, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(813), 833260828, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(814) },
                    { -718226552, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(825), 176476005, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(826) },
                    { -718226552, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(750), 706648867, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(751) },
                    { -533335856, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8560), 589121511, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8561) },
                    { -533335856, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8523), 388259237, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8524) },
                    { -533335856, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8510), 874882282, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8511) },
                    { -533335856, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8573), 284928997, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8574) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -533335856, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8492), 963435284, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8493) },
                    { -533335856, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8547), 663051071, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8549) },
                    { -533335856, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8623), 701764762, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8624) },
                    { -533335856, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8635), 454721271, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8636) },
                    { -533335856, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8598), 944538107, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8599) },
                    { -533335856, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8647), 967455408, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8648) },
                    { -533335856, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8535), 469707776, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8537) },
                    { -533335856, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8660), 934431202, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8661) },
                    { -533335856, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8585), 480473039, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8586) },
                    { -533335856, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8672), 702215423, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8673) },
                    { -533335856, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8684), 654866583, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8686) },
                    { -533335856, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8610), 346107710, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8612) },
                    { -254850064, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9828), 710006438, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9829) },
                    { -254850064, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9791), 596359263, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9792) },
                    { -254850064, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9779), 813985949, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9780) },
                    { -254850064, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9840), 614863015, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9842) },
                    { -254850064, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9767), 857014189, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9768) },
                    { -254850064, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9816), 205692211, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9817) },
                    { -254850064, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9889), 208287845, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9890) },
                    { -254850064, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9925), 301140704, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9926) },
                    { -254850064, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9865), 568301376, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9866) },
                    { -254850064, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9937), 293140400, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9939) },
                    { -254850064, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9803), 495461721, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9804) },
                    { -254850064, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9950), 681994949, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9951) },
                    { -254850064, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9852), 443210935, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9853) },
                    { -254850064, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9963), 228779202, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9964) },
                    { -254850064, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9975), 213024424, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9976) },
                    { -254850064, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9877), 727447558, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9878) },
                    { 351106080, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(899), 916774921, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(900) },
                    { 351106080, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(862), 133264505, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(863) },
                    { 351106080, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(850), 523636802, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(851) },
                    { 351106080, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(911), 445760164, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(912) },
                    { 351106080, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(838), 650158395, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(839) },
                    { 351106080, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(887), 747072552, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(888) },
                    { 351106080, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(960), 663890678, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(961) },
                    { 351106080, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(972), 329453028, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(973) },
                    { 351106080, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(935), 798153227, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(936) },
                    { 351106080, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(984), 738830906, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(985) },
                    { 351106080, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(874), 470750959, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(875) },
                    { 351106080, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(996), 356393451, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(997) },
                    { 351106080, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(923), 175262011, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(924) },
                    { 351106080, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(1009), 800327832, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(1010) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 351106080, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(1021), 598636906, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(1022) },
                    { 351106080, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(948), 723456742, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(949) },
                    { 377426392, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(49), 972481310, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(50) },
                    { 377426392, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(12), 918600582, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(13) },
                    { 377426392, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local), 767018954, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(1) },
                    { 377426392, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(61), 164210061, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(62) },
                    { 377426392, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9988), 790026588, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9989) },
                    { 377426392, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(37), 636358642, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(38) },
                    { 377426392, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(111), 986376906, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(112) },
                    { 377426392, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(123), 399647481, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(124) },
                    { 377426392, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(86), 881122856, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(87) },
                    { 377426392, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(135), 340935670, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(136) },
                    { 377426392, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(25), 714169471, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(26) },
                    { 377426392, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(147), 664335535, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(149) },
                    { 377426392, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(74), 877850452, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(75) },
                    { 377426392, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(160), 401384378, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(161) },
                    { 377426392, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(172), 330114047, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(173) },
                    { 377426392, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(98), 800396203, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(99) },
                    { 774309784, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(475), 892373806, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(476) },
                    { 774309784, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(439), 269790432, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(440) },
                    { 774309784, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(426), 789020156, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(427) },
                    { 774309784, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(487), 714561344, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(489) },
                    { 774309784, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(414), 853023070, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(415) },
                    { 774309784, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(463), 516244790, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(464) },
                    { 774309784, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(537), 980113538, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(538) },
                    { 774309784, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(549), 718526629, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(550) },
                    { 774309784, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(512), 907791579, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(513) },
                    { 774309784, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(561), 138489770, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(562) },
                    { 774309784, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(451), 709518990, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(452) },
                    { 774309784, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(574), 408790461, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(575) },
                    { 774309784, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(500), 922278824, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(501) },
                    { 774309784, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(586), 336988077, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(587) },
                    { 774309784, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(598), 140144681, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(599) },
                    { 774309784, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(524), 777026524, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(525) },
                    { 1004035960, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9633), 182596655, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9634) },
                    { 1004035960, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9596), 992763827, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9597) },
                    { 1004035960, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9583), 862158709, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9584) },
                    { 1004035960, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9645), 827731224, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9646) },
                    { 1004035960, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9571), 576569308, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9572) },
                    { 1004035960, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9620), 826357745, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9621) },
                    { 1004035960, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9694), 960388068, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9695) },
                    { 1004035960, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9706), 907775030, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9707) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1004035960, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9669), 605010222, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9670) },
                    { 1004035960, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9718), 450950680, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9719) },
                    { 1004035960, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9608), 932608010, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9609) },
                    { 1004035960, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9730), 405134483, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9731) },
                    { 1004035960, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9657), 222354365, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9658) },
                    { 1004035960, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9742), 868556034, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9743) },
                    { 1004035960, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9755), 418324730, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9756) },
                    { 1004035960, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9682), 701531962, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(9683) },
                    { 2048166264, 182780207, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(277), 256795807, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(278) },
                    { 2048166264, 225797441, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(239), 350255903, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(240) },
                    { 2048166264, 355603848, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(198), 751268591, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(199) },
                    { 2048166264, 366262527, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(290), 335807799, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(291) },
                    { 2048166264, 376761470, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(184), 607926493, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(185) },
                    { 2048166264, 410467878, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(264), 219442361, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(265) },
                    { 2048166264, 440970855, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(339), 256341578, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(340) },
                    { 2048166264, 443875517, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(352), 268522353, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(353) },
                    { 2048166264, 469142350, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(314), 141553455, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(315) },
                    { 2048166264, 475969285, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(364), 183614619, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(365) },
                    { 2048166264, 558600702, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(252), 796111797, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(253) },
                    { 2048166264, 700006525, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(376), 805218165, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(377) },
                    { 2048166264, 732853784, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(302), 929502274, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(303) },
                    { 2048166264, 839370213, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(389), 915388499, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(390) },
                    { 2048166264, 886170439, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(401), 331130231, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(402) },
                    { 2048166264, 887320685, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(327), 158628827, new DateTime(2024, 3, 25, 16, 21, 14, 655, DateTimeKind.Local).AddTicks(328) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 215445586, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6705), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6702), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6704), 176720701 },
                    { 217492141, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6968), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6966), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6967), 229160176 },
                    { 231657845, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6529), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6527), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6528), 765172007 },
                    { 251775227, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6929), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6927), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6928), 229160176 },
                    { 254641076, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6770), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6768), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6769), 229160176 },
                    { 392345998, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6665), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6663), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6664), 176720701 },
                    { 442630642, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6556), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6554), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6555), 229160176 },
                    { 457806474, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7035), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7033), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7034), 176720701 },
                    { 464581153, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6839), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6837), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6838), 176720701 },
                    { 506869814, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6981), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6979), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6980), 765172007 },
                    { 523632632, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6865), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6863), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6864), 765172007 },
                    { 535736544, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6994), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6992), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6993), 176720701 },
                    { 546683096, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6639), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6636), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6638), 229160176 },
                    { 547620807, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6878), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6875), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6877), 176720701 },
                    { 560993465, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6624), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6622), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6623), 176720701 },
                    { 570367045, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6611), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6609), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6610), 765172007 },
                    { 648390825, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7092), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7090), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7091), 176720701 },
                    { 651123750, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6598), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6596), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6597), 229160176 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 654102908, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7009), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7007), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7008), 229160176 },
                    { 685560915, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7022), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7020), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7021), 765172007 },
                    { 700019119, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6904), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6901), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6902), 765172007 },
                    { 714659286, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6826), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6824), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6825), 765172007 },
                    { 740982961, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6570), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6568), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6569), 765172007 },
                    { 745611555, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6692), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6690), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6691), 765172007 },
                    { 755949190, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6800), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6798), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6799), 176720701 },
                    { 785596632, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6785), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6783), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6784), 765172007 },
                    { 793639749, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6543), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6541), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6542), 176720701 },
                    { 802236010, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6955), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6952), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6953), 176720701 },
                    { 856531005, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6679), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6677), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6678), 229160176 },
                    { 874657301, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6891), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6889), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6890), 229160176 },
                    { 875239127, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6942), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6940), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6941), 765172007 },
                    { 916644747, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6916), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6914), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6915), 176720701 },
                    { 919903014, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6852), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6850), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6851), 229160176 },
                    { 933422309, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6652), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6650), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6651), 765172007 },
                    { 945031098, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6511), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6508), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6509), 229160176 },
                    { 961281515, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7064), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7060), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7062), 229160176 },
                    { 963913931, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7079), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7077), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7078), 765172007 },
                    { 965101189, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6813), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6811), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6812), 229160176 },
                    { 982407824, new DateTime(2024, 4, 5, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6584), 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6582), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(6583), 176720701 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 134822959, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7869), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7870), 768035898 },
                    { 140792946, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8079), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8081), 171420633 },
                    { 145199403, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7523), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7524), 569296285 },
                    { 158963794, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8267), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8268), 569296285 },
                    { 160352542, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7221), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7223), 301635973 },
                    { 171576823, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7498), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7499), 768035898 },
                    { 203055287, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7979), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7980), 569296285 },
                    { 211993292, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7991), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7992), 126510717 },
                    { 216442168, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8466), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8467), 569296285 },
                    { 218429315, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8028), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8029), 811221262 },
                    { 242153822, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8328), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8329), 768035898 },
                    { 244457115, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7384), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7385), 301635973 },
                    { 245485898, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7966), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7968), 171420633 },
                    { 278550923, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7918), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7919), 139645808 },
                    { 280107545, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7423), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7424), 171420633 },
                    { 284875304, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8104), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8106), 126510717 },
                    { 291571103, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8092), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8093), 569296285 },
                    { 293611495, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8254), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8256), 171420633 },
                    { 310854694, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7371), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7372), 139645808 },
                    { 313060375, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8341), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8342), 171420633 },
                    { 317651232, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8353), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8354), 569296285 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 321606176, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7647), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7648), 301635973 },
                    { 331089422, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7609), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7610), 569296285 },
                    { 331565044, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7511), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7512), 171420633 },
                    { 348865565, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8442), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8443), 768035898 },
                    { 354031071, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7671), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7672), 768035898 },
                    { 360574955, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7622), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7623), 126510717 },
                    { 361654759, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8205), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8207), 139645808 },
                    { 367434856, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8168), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8169), 171420633 },
                    { 375277753, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7234), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7235), 811221262 },
                    { 379972195, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7572), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7573), 811221262 },
                    { 402920738, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7893), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7894), 569296285 },
                    { 422364564, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7560), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7561), 301635973 },
                    { 424559551, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8066), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8067), 768035898 },
                    { 443488388, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8192), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8194), 126510717 },
                    { 453965301, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7808), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7809), 569296285 },
                    { 461380126, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7881), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7882), 171420633 },
                    { 462169339, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7411), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7412), 768035898 },
                    { 470057201, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8143), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8144), 811221262 },
                    { 481980734, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7857), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7858), 811221262 },
                    { 487434926, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8430), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8431), 811221262 },
                    { 499572761, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7203), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7204), 139645808 },
                    { 506331387, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7844), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7845), 301635973 },
                    { 511592727, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7905), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7906), 126510717 },
                    { 535142134, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7757), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7758), 301635973 },
                    { 550877849, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8292), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8293), 139645808 },
                    { 558695099, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8478), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8479), 126510717 },
                    { 568867366, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7460), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7461), 139645808 },
                    { 569155257, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8316), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8317), 811221262 },
                    { 580598851, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7473), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7474), 301635973 },
                    { 588668145, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7954), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7955), 768035898 },
                    { 601986676, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7258), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7259), 171420633 },
                    { 608164957, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8242), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8243), 768035898 },
                    { 613079784, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8156), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8157), 768035898 },
                    { 614591262, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8015), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8017), 301635973 },
                    { 616303217, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8279), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8280), 126510717 },
                    { 621367841, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7659), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7660), 811221262 },
                    { 635109895, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7930), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7931), 301635973 },
                    { 647893240, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8366), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8367), 126510717 },
                    { 667295460, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7942), 377426392, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7943), 811221262 },
                    { 673581152, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8404), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8405), 139645808 },
                    { 694632023, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8218), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8219), 301635973 },
                    { 700158711, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8418), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8419), 301635973 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 701394659, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7770), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7771), 811221262 },
                    { 705202153, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7435), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7436), 569296285 },
                    { 706804413, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8129), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8130), 301635973 },
                    { 708557711, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7246), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7247), 768035898 },
                    { 717271480, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8454), -670133000, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8455), 171420633 },
                    { 722477090, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7720), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7721), 569296285 },
                    { 726528722, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7820), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7821), 126510717 },
                    { 733998486, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8117), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8118), 139645808 },
                    { 742594647, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8230), -718226552, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8231), 811221262 },
                    { 769726789, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7795), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7796), 171420633 },
                    { 785337958, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7584), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7585), 768035898 },
                    { 796712538, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7398), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7399), 811221262 },
                    { 815753305, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7547), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7548), 139645808 },
                    { 825970780, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7832), -254850064, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7833), 139645808 },
                    { 828042047, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7732), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7734), 126510717 },
                    { 849227605, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8003), 2048166264, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8004), 139645808 },
                    { 850973503, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7535), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7536), 126510717 },
                    { 885262724, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7745), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7746), 139645808 },
                    { 904197851, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7596), -1043482432, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7598), 171420633 },
                    { 911207162, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7447), -1106953896, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7449), 126510717 },
                    { 940906198, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7343), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7344), 569296285 },
                    { 951536697, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7634), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7636), 139645808 },
                    { 954099098, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7783), 1004035960, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7784), 768035898 },
                    { 961701217, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7485), -870476720, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7486), 811221262 },
                    { 962846444, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7706), -1110141984, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7707), 171420633 },
                    { 975284556, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8304), 351106080, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8305), 301635973 },
                    { 984906113, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8180), 774309784, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(8181), 569296285 },
                    { 989890477, 0f, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7358), -533335856, new DateTime(2024, 3, 25, 16, 21, 14, 654, DateTimeKind.Local).AddTicks(7359), 126510717 }
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
