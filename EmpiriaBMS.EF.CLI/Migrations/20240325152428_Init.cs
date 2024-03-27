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
                    { 126511258, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9425), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9426), "Fire Detection" },
                    { 167926921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9564), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9565), "Outsource" },
                    { 176563775, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9478), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9479), "Power Distribution" },
                    { 333795694, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9576), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9577), "TenderDocument" },
                    { 359884378, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9504), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9505), "Burglar Alarm" },
                    { 363806183, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9552), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9553), "Energy Efficiency" },
                    { 405790386, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9492), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9493), "Structured Cabling" },
                    { 421159882, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9442), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9443), "Fire Suppression" },
                    { 479642008, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9454), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9455), "Elevators" },
                    { 486840292, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9602), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9603), "DWG Admin/Clearing" },
                    { 541849282, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9413), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9414), "Drainage" },
                    { 548868269, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9528), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9529), "BMS" },
                    { 569127840, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9540), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9541), "Photovoltaics" },
                    { 589024398, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9401), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9402), "Potable Water" },
                    { 648092441, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9371), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9372), "HVAC" },
                    { 765294899, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9589), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9591), "Construction Supervision" },
                    { 806025373, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9389), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9390), "Sewage" },
                    { 929882248, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9516), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9517), "CCTV" },
                    { 939316762, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9466), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9467), "Natural Gas" },
                    { 941757881, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9614), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9615), "Project Manager Hours" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 262630033, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9973), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9974), "Calculations" },
                    { 543611290, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9986), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9987), "Drawings" },
                    { 967576680, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9831), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9832), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 280170162, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(617), new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(618), "Administration" },
                    { 298865232, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(605), new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(606), "Meetings" },
                    { 544632982, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(666), new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(668), "Hours To Be Raised" },
                    { 634901506, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(558), new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(559), "Communications" },
                    { 752753312, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(593), new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(594), "On-Site" },
                    { 828810783, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(654), new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(655), "Soft Copy" },
                    { 944263992, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(580), new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(581), "Printing" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 144101904, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7120), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7121), "Dashboard Edit Discipline", 14 },
                    { 215018941, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6995), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6996), "Dashboard Assign Project Manager", 5 },
                    { 228048480, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6852), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6854), "See Dashboard Layout", 1 },
                    { 247978500, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7037), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7038), "Dashboard See My Hours", 8 },
                    { 290839984, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7023), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7025), "See Admin Layout", 7 },
                    { 485548789, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7147), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7148), "Dashboard Edit Other", 16 },
                    { 599717445, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7065), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7066), "See All Drawings", 10 },
                    { 620496979, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7107), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7108), "Display Projects Code", 13 },
                    { 704000156, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7133), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7135), "Dashboard Edit Deliverable", 15 },
                    { 753234189, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7079), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7080), "See All Projects", 11 },
                    { 756403516, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6981), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6982), "Dashboard Assign Engineer", 4 },
                    { 801915825, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7050), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7051), "See All Disciplines", 9 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 815145926, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7010), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7011), "Dashboard Add Project", 6 },
                    { 883422907, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6967), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6968), "Dashboard Assign Designer", 3 },
                    { 899945478, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7093), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7094), "Edit Project On Dashboard", 12 },
                    { 971138762, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6952), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(6953), "Dashboard Edit My Hours", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 167037412, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9102), "Consulting Description", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9103), "Consulting" },
                    { 511198496, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9089), "Energy Description", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9090), "Energy" },
                    { 529533827, false, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9118), "Production Management Description", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9120), "Production Management" },
                    { 704281487, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9061), "Buildings Description", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9062), "Buildings" },
                    { 996407014, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9076), "Infrastructure Description", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9077), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 291106305, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7296), false, false, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7297), "Secretariat" },
                    { 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7224), false, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7225), "CTO" },
                    { 624039796, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7264), false, false, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7265), "Customer" },
                    { 706379986, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7183), false, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7184), "Engineer" },
                    { 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7211), false, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7212), "COO" },
                    { 727160196, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7277), false, false, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7278), "Admin" },
                    { 768521671, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7251), false, false, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7252), "Guest" },
                    { 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7238), false, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7239), "CEO" },
                    { 942305441, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7197), false, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7198), "Project Manager" },
                    { 983035965, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7161), false, true, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7162), "Designer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8469), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8471), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8937), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8938), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 215091664, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8297), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8298), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9019), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9020), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 261256047, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8136), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8137), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8896), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8897), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8978), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8979), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8339), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8341), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8383), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8384), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8678), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8679), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8637), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8638), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8512), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8513), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8424), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8425), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8852), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8853), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8718), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8720), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 776576941, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8256), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8258), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8760), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8761), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8810), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8811), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 935326469, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8212), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8214), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8569), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8571), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 202396211, "vtza@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8651), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8652), 487546115 },
                    { 238178777, "sparisis@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8441), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8442), 569251687 },
                    { 275206853, "kmargeti@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8733), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8734), 648305951 },
                    { 298081850, "xmanarolis@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8396), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8398), 432257301 },
                    { 301142410, "blekou@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8910), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8912), 293710541 },
                    { 321055566, "vchontos@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8951), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8952), 206533006 },
                    { 382808819, "embiria@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8157), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8158), 261256047 },
                    { 386372675, "chkovras@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8483), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8485), 131461425 },
                    { 404972677, "vpax@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8355), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8356), 427479300 },
                    { 416796298, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8177), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8178), 261256047 },
                    { 486461149, "panperivollari@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8992), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8994), 422454290 },
                    { 503779342, "gdoug@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8228), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8229), 935326469 },
                    { 579709442, "ngal@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8527), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8529), 538867006 },
                    { 617838948, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8868), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8869), 594156751 },
                    { 713991978, "dtsa@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8270), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8271), 776576941 },
                    { 752908561, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9033), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9034), 259810206 },
                    { 775754328, "kkotsoni@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8583), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8584), 939204178 },
                    { 804089354, "dtsa@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8311), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8312), 215091664 },
                    { 817498837, "agretos@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8692), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8693), 440825486 },
                    { 917744877, "pfokianou@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8824), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8825), 921520134 },
                    { 919411985, "haris@embiria.gr", new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8781), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8782), 831887282 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 264754523, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), new DateTime(2024, 7, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Test Description Project_10", new DateTime(2024, 7, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 0f, new DateTime(2024, 7, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Project_2", 939204178, null, 996407014, 0f },
                    { 386018162, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), new DateTime(2025, 7, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Test Description Project_8", new DateTime(2025, 7, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 0f, new DateTime(2025, 7, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Project_4", 939204178, null, 167037412, 0f },
                    { 491960751, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), new DateTime(2024, 6, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Test Description Project_PM", new DateTime(2024, 4, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 0f, new DateTime(2024, 5, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 1500L, 12L, null, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Project_PM", null, null, 529533827, 0f },
                    { 776914543, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), new DateTime(2024, 4, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Test Description Project_2", new DateTime(2024, 4, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 0f, new DateTime(2024, 4, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Project_1", 939204178, null, 704281487, 0f },
                    { 893813857, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), new DateTime(2024, 12, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Test Description Project_6", new DateTime(2024, 12, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 0f, new DateTime(2024, 12, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 17, 24, 27, 634, DateTimeKind.Local).AddTicks(4163), "Project_3", 939204178, null, 511198496, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 228048480, 291106305, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8049), 1937132118, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8050) },
                    { 247978500, 291106305, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8078), 342752297, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8080) },
                    { 599717445, 291106305, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8106), -2058282944, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8108) },
                    { 753234189, 291106305, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8120), -1268518229, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8121) },
                    { 801915825, 291106305, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8093), 990230441, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8094) },
                    { 971138762, 291106305, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8062), -256156609, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8063) },
                    { 144101904, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7777), 762563345, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7778) },
                    { 215018941, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7678), -1550569711, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7679) },
                    { 228048480, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7651), 1502540546, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7652) },
                    { 247978500, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7708), -1349783648, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7709) },
                    { 485548789, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7804), -863470768, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7805) },
                    { 599717445, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7735), -1434990397, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7736) },
                    { 704000156, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7790), 15228541, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7792) },
                    { 753234189, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7748), 303055295, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7749) },
                    { 801915825, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7721), -324744056, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7722) },
                    { 815145926, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7694), 1572361187, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7696) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 899945478, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7762), -1627097044, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7764) },
                    { 971138762, 339666364, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7664), 542397722, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7665) },
                    { 228048480, 624039796, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7981), 40061228, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7983) },
                    { 228048480, 706379986, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7362), -1418689538, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7363) },
                    { 247978500, 706379986, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7404), -641022376, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7405) },
                    { 599717445, 706379986, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7431), -1323045197, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7432) },
                    { 801915825, 706379986, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7417), 1524914964, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7419) },
                    { 883422907, 706379986, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7390), 621484466, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7391) },
                    { 971138762, 706379986, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7375), 403509695, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7377) },
                    { 215018941, 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7583), -456461275, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7584) },
                    { 228048480, 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7527), -1438229407, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7529) },
                    { 247978500, 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7597), 1245524058, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7598) },
                    { 599717445, 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7624), -405880991, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7625) },
                    { 753234189, 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7637), -1488746600, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7639) },
                    { 756403516, 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7569), 1452804309, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7571) },
                    { 801915825, 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7610), 1056842681, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7611) },
                    { 883422907, 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7556), -140187595, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7557) },
                    { 971138762, 726210607, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7541), -128533679, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7543) },
                    { 290839984, 727160196, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7995), 1891206369, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7996) },
                    { 599717445, 727160196, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8022), -1058084419, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8023) },
                    { 753234189, 727160196, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8035), -681435305, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8037) },
                    { 801915825, 727160196, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8008), -1672003574, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8009) },
                    { 228048480, 768521671, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7968), 526652411, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7969) },
                    { 215018941, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7871), -1884131194, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7873) },
                    { 228048480, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7817), -241934908, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7818) },
                    { 599717445, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7912), 1424533829, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7914) },
                    { 620496979, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7941), 1884046964, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7942) },
                    { 753234189, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7927), -89023603, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7928) },
                    { 756403516, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7858), 630547943, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7859) },
                    { 801915825, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7899), 869768483, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7900) },
                    { 815145926, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7885), -2054669215, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7887) },
                    { 883422907, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7845), -8045369, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7846) },
                    { 899945478, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7954), 247607479, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7956) },
                    { 971138762, 788532921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7831), 468080960, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7833) },
                    { 228048480, 942305441, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7445), 367432385, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7446) },
                    { 247978500, 942305441, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7487), -572840081, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7488) },
                    { 599717445, 942305441, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7514), -1995892555, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7515) },
                    { 756403516, 942305441, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7474), 2099621237, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7475) },
                    { 801915825, 942305441, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7500), 1432767227, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7502) },
                    { 971138762, 942305441, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7460), -453575425, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7461) },
                    { 228048480, 983035965, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7310), -1857975529, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7311) },
                    { 247978500, 983035965, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7348), -871116587, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7349) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 971138762, 983035965, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7334), -273761797, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(7335) });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 706379986, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8498), 219763156, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8499) },
                    { 706379986, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8964), 828278922, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8965) },
                    { 983035965, 215091664, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8325), 327463757, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8326) },
                    { 706379986, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9046), 717121002, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9047) },
                    { 291106305, 261256047, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8191), 456463111, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8192) },
                    { 706379986, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8924), 432139793, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8925) },
                    { 706379986, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9006), 150513347, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9007) },
                    { 706379986, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8368), 882451698, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8369) },
                    { 942305441, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9133), 63540048, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9134) },
                    { 706379986, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8410), 893854026, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8411) },
                    { 706379986, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8705), 571751760, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8706) },
                    { 706379986, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8665), 636050184, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8666) },
                    { 706379986, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8541), 656878626, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8542) },
                    { 788532921, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8555), 576989118, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8557) },
                    { 706379986, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8455), 725429046, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8456) },
                    { 706379986, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8882), 699018921, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8883) },
                    { 706379986, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8746), 796732276, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8747) },
                    { 983035965, 776576941, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8283), 896165840, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8285) },
                    { 706379986, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8795), 838068710, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8796) },
                    { 942305441, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9162), 314050324, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9163) },
                    { 706379986, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8838), 801635359, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8839) },
                    { 983035965, 935326469, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8242), 316348715, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8244) },
                    { 339666364, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8624), 667055691, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8625) },
                    { 706379986, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8597), 386991630, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8598) },
                    { 726210607, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8610), 944770677, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(8611) },
                    { 942305441, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9148), 259575326, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9149) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1595621368, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9669), 0f, 408L, 51L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9670), 776914543, 648092441, null },
                    { -1522909840, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9710), 0f, 408L, 51L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9711), 264754523, 929882248, null },
                    { -1492539104, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9684), 0f, 416L, 52L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9685), 776914543, 167926921, null },
                    { -1312329040, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9644), 0f, 400L, 50L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9645), 776914543, 421159882, null },
                    { -1273567776, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9777), 0f, 400L, 50L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9779), 386018162, 359884378, null },
                    { -1235945912, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9815), 0f, 500L, 0L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9816), 491960751, 941757881, null },
                    { -846811648, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9724), 0f, 416L, 52L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9725), 264754523, 363806183, null },
                    { -586049128, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9802), 0f, 416L, 52L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9803), 386018162, 806025373, null },
                    { 665865888, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9762), 0f, 416L, 52L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9763), 893813857, 176563775, null },
                    { 1142935016, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9697), 0f, 400L, 50L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9698), 264754523, 333795694, null },
                    { 1183334216, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9790), 0f, 408L, 51L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9791), 386018162, 939316762, null },
                    { 1397120936, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9749), 0f, 408L, 51L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9751), 893813857, 548868269, null },
                    { 2062609040, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9737), 0f, 400L, 50L, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9738), 893813857, 541849282, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 140821583, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9226), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9229), 3010.0, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9227), "Signature 142346", 30890, 776914543, 1.0, 17.0 },
                    { 272243414, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9270), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9273), 3100.0, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9272), "Signature 142346", 62995, 264754523, 2.0, 24.0 },
                    { 576158203, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9337), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9339), 13000.0, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9338), "Signature 1423424", 83727, 386018162, 4.0, 24.0 },
                    { 762513186, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9304), new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9306), 4000.0, new DateTime(2024, 3, 25, 17, 24, 27, 648, DateTimeKind.Local).AddTicks(9305), "Signature 1423418", 55822, 893813857, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1595621368, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2121), 545708487, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2122) },
                    { -1595621368, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2242), 163793438, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2243) },
                    { -1595621368, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2266), 284785209, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2267) },
                    { -1595621368, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2230), 714851508, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2231) },
                    { -1595621368, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2255), 860686418, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2256) },
                    { -1595621368, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2084), 879959983, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2085) },
                    { -1595621368, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2097), 900268560, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2098) },
                    { -1595621368, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2171), 929392614, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2172) },
                    { -1595621368, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2159), 966691099, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2160) },
                    { -1595621368, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2134), 890485739, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2135) },
                    { -1595621368, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2109), 802093776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2110) },
                    { -1595621368, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2218), 413792772, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2219) },
                    { -1595621368, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2183), 572806837, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2184) },
                    { -1595621368, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2195), 678833674, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2196) },
                    { -1595621368, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2206), 237994233, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2207) },
                    { -1595621368, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2146), 556957443, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2147) },
                    { -1522909840, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2761), 265656373, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2763) },
                    { -1522909840, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2887), 278988098, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2888) },
                    { -1522909840, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2911), 596744450, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2912) },
                    { -1522909840, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2874), 980399674, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2875) },
                    { -1522909840, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2899), 590972096, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2900) },
                    { -1522909840, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2692), 156072622, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2693) },
                    { -1522909840, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2705), 217735117, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2706) },
                    { -1522909840, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2813), 442140810, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2814) },
                    { -1522909840, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2800), 713190407, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2801) },
                    { -1522909840, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2776), 827639151, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2777) },
                    { -1522909840, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2717), 333124642, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2719) },
                    { -1522909840, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2862), 356859053, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2863) },
                    { -1522909840, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2825), 224293691, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2826) },
                    { -1522909840, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2837), 403532008, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2838) },
                    { -1522909840, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2850), 711052814, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2851) },
                    { -1522909840, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2788), 640588217, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2789) },
                    { -1492539104, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2316), 127085665, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2317) },
                    { -1492539104, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2462), 943955386, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2463) },
                    { -1492539104, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2486), 929084941, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2487) },
                    { -1492539104, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2450), 418438304, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2451) },
                    { -1492539104, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2474), 475035398, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2475) },
                    { -1492539104, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2278), 798422948, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2279) },
                    { -1492539104, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2291), 411213871, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2293) },
                    { -1492539104, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2364), 556589848, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2366) },
                    { -1492539104, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2352), 845718621, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2353) },
                    { -1492539104, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2328), 446200016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2329) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1492539104, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2304), 346321717, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2305) },
                    { -1492539104, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2438), 434123761, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2439) },
                    { -1492539104, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2377), 704954149, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2378) },
                    { -1492539104, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2413), 892999867, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2414) },
                    { -1492539104, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2425), 269149999, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2427) },
                    { -1492539104, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2340), 858149170, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2341) },
                    { -1312329040, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1900), 471068966, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1901) },
                    { -1312329040, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2047), 892278129, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2048) },
                    { -1312329040, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2071), 443402154, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2073) },
                    { -1312329040, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2010), 925332062, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2011) },
                    { -1312329040, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2059), 558897391, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2060) },
                    { -1312329040, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1855), 207323883, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1856) },
                    { -1312329040, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1876), 887867875, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1877) },
                    { -1312329040, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1949), 743373727, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1951) },
                    { -1312329040, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1937), 878481791, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1938) },
                    { -1312329040, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1912), 929216778, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1913) },
                    { -1312329040, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1888), 443746715, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1889) },
                    { -1312329040, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1998), 946612411, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1999) },
                    { -1312329040, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1962), 674962226, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1963) },
                    { -1312329040, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1974), 426926422, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1975) },
                    { -1312329040, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1986), 566733670, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1987) },
                    { -1312329040, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1924), 276721134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1925) },
                    { -1273567776, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3790), 451271710, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3792) },
                    { -1273567776, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3935), 792889252, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3936) },
                    { -1273567776, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3959), 617421810, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3960) },
                    { -1273567776, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3923), 677777398, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3924) },
                    { -1273567776, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3947), 354582653, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3948) },
                    { -1273567776, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3754), 255190957, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3755) },
                    { -1273567776, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3767), 658429640, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3768) },
                    { -1273567776, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3839), 429616510, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3840) },
                    { -1273567776, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3826), 626583486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3827) },
                    { -1273567776, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3802), 156943680, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3803) },
                    { -1273567776, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3779), 245622258, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3780) },
                    { -1273567776, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3911), 373313998, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3912) },
                    { -1273567776, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3873), 648645412, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3875) },
                    { -1273567776, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3886), 241417162, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3888) },
                    { -1273567776, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3899), 960583220, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3900) },
                    { -1273567776, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3814), 194413861, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3816) },
                    { -846811648, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2961), 780157760, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2962) },
                    { -846811648, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3082), 524964859, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3083) },
                    { -846811648, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3106), 547529397, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3108) },
                    { -846811648, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3070), 741955644, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3071) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -846811648, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3094), 998259345, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3095) },
                    { -846811648, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2924), 691415661, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2925) },
                    { -846811648, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2936), 661537992, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2937) },
                    { -846811648, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3009), 422835682, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3010) },
                    { -846811648, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2997), 634119992, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2998) },
                    { -846811648, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2973), 470682980, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2974) },
                    { -846811648, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2948), 151097502, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2950) },
                    { -846811648, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3058), 293024107, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3059) },
                    { -846811648, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3021), 990642539, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3022) },
                    { -846811648, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3033), 569705122, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3034) },
                    { -846811648, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3045), 590973955, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3046) },
                    { -846811648, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2985), 324264225, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2986) },
                    { -586049128, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4200), 707048770, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4202) },
                    { -586049128, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4345), 586640112, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4346) },
                    { -586049128, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4369), 382425679, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4370) },
                    { -586049128, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4333), 811988083, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4334) },
                    { -586049128, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4357), 265762298, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4358) },
                    { -586049128, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4165), 846779709, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4166) },
                    { -586049128, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4177), 380621072, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4178) },
                    { -586049128, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4270), 611212882, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4272) },
                    { -586049128, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4236), 280213504, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4237) },
                    { -586049128, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4212), 626456780, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4213) },
                    { -586049128, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4189), 198175024, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4190) },
                    { -586049128, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4320), 805487479, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4321) },
                    { -586049128, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4284), 695391061, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4285) },
                    { -586049128, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4296), 883204213, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4297) },
                    { -586049128, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4308), 157624840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4309) },
                    { -586049128, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4224), 975324276, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4225) },
                    { 665865888, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3596), 676373949, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3597) },
                    { 665865888, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3718), 394317594, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3719) },
                    { 665865888, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3742), 418510587, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3743) },
                    { 665865888, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3706), 187529212, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3707) },
                    { 665865888, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3730), 633377737, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3731) },
                    { 665865888, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3533), 378983018, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3534) },
                    { 665865888, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3570), 217797835, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3571) },
                    { 665865888, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3645), 753054989, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3646) },
                    { 665865888, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3633), 866286376, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3634) },
                    { 665865888, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3608), 614131661, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3609) },
                    { 665865888, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3584), 578273052, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3585) },
                    { 665865888, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3694), 665332225, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3695) },
                    { 665865888, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3657), 688807854, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3658) },
                    { 665865888, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3670), 799894330, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3671) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 665865888, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3682), 927083911, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3683) },
                    { 665865888, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3621), 838898248, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3622) },
                    { 1142935016, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2535), 436852776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2536) },
                    { 1142935016, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2656), 723638995, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2657) },
                    { 1142935016, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2680), 940471407, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2681) },
                    { 1142935016, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2644), 598779153, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2645) },
                    { 1142935016, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2668), 594410319, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2669) },
                    { 1142935016, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2498), 910690632, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2500) },
                    { 1142935016, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2511), 922481652, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2512) },
                    { 1142935016, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2583), 366833820, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2584) },
                    { 1142935016, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2571), 295690588, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2572) },
                    { 1142935016, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2547), 267996400, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2548) },
                    { 1142935016, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2523), 690809514, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2524) },
                    { 1142935016, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2632), 753945870, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2633) },
                    { 1142935016, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2595), 930149973, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2596) },
                    { 1142935016, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2607), 260664946, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2608) },
                    { 1142935016, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2620), 486956157, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2621) },
                    { 1142935016, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2559), 127975272, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2560) },
                    { 1183334216, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4008), 355503840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4009) },
                    { 1183334216, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4128), 572011345, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4130) },
                    { 1183334216, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4152), 506715641, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4154) },
                    { 1183334216, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4117), 961148122, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4118) },
                    { 1183334216, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4140), 655273177, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4141) },
                    { 1183334216, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3972), 397840129, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3973) },
                    { 1183334216, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3984), 868069365, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3985) },
                    { 1183334216, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4056), 405672364, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4057) },
                    { 1183334216, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4043), 574799794, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4045) },
                    { 1183334216, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4020), 797797028, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4021) },
                    { 1183334216, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3996), 685069043, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3997) },
                    { 1183334216, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4105), 692647993, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4106) },
                    { 1183334216, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4067), 280950745, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4069) },
                    { 1183334216, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4080), 331893811, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4081) },
                    { 1183334216, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4092), 235557410, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4094) },
                    { 1183334216, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4032), 389257784, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4033) },
                    { 1397120936, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3374), 537831706, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3375) },
                    { 1397120936, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3496), 330621995, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3497) },
                    { 1397120936, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3521), 319599962, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3522) },
                    { 1397120936, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3484), 485823142, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3485) },
                    { 1397120936, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3508), 928474351, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3509) },
                    { 1397120936, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3338), 711998052, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3339) },
                    { 1397120936, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3350), 133643138, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3351) },
                    { 1397120936, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3422), 655842256, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3423) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1397120936, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3410), 492999352, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3412) },
                    { 1397120936, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3386), 763021753, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3387) },
                    { 1397120936, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3362), 562890714, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3363) },
                    { 1397120936, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3472), 530724171, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3473) },
                    { 1397120936, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3435), 773623420, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3436) },
                    { 1397120936, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3447), 961111361, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3448) },
                    { 1397120936, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3459), 236460877, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3461) },
                    { 1397120936, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3399), 689280014, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3400) },
                    { 2062609040, 131461425, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3179), 759264012, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3181) },
                    { 2062609040, 206533006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3302), 468034655, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3303) },
                    { 2062609040, 259810206, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3326), 128308370, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3327) },
                    { 2062609040, 293710541, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3290), 984142174, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3291) },
                    { 2062609040, 422454290, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3314), 568500386, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3315) },
                    { 2062609040, 427479300, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3119), 447146566, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3120) },
                    { 2062609040, 432257301, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3131), 743092766, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3133) },
                    { 2062609040, 440825486, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3229), 354779822, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3230) },
                    { 2062609040, 487546115, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3217), 676592980, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3218) },
                    { 2062609040, 538867006, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3192), 759103018, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3193) },
                    { 2062609040, 569251687, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3166), 925664406, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3168) },
                    { 2062609040, 594156751, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3277), 773304418, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3278) },
                    { 2062609040, 648305951, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3241), 194177988, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3242) },
                    { 2062609040, 831887282, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3253), 782551756, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3254) },
                    { 2062609040, 921520134, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3265), 396390203, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3266) },
                    { 2062609040, 939204178, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3204), 839785208, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(3206) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 134833068, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(78), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(76), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(77), 543611290 },
                    { 155379667, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(118), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(116), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(117), 543611290 },
                    { 225159259, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(396), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(393), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(395), 967576680 },
                    { 245708622, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(199), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(196), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(197), 543611290 },
                    { 305645074, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(185), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(183), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(184), 262630033 },
                    { 325302911, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(93), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(90), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(91), 967576680 },
                    { 330648498, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(462), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(459), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(460), 543611290 },
                    { 382438075, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(133), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(130), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(131), 967576680 },
                    { 412766151, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(253), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(251), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(252), 967576680 },
                    { 514139356, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(356), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(354), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(355), 967576680 },
                    { 515527425, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(532), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(529), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(530), 262630033 },
                    { 517507459, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(383), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(380), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(381), 543611290 },
                    { 519234978, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(159), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(157), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(158), 543611290 },
                    { 552085651, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(23), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(20), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(22), 262630033 },
                    { 570920580, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(544), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(542), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(543), 543611290 },
                    { 592590148, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(63), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(61), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(62), 262630033 },
                    { 621833018, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(369), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(367), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(368), 262630033 },
                    { 641651460, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(37), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(34), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(35), 543611290 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 675705877, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(422), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(420), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(421), 543611290 },
                    { 737058323, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(279), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(277), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(278), 543611290 },
                    { 742720923, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(212), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(210), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(211), 967576680 },
                    { 746066412, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(172), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(170), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(171), 967576680 },
                    { 762792072, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(502), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(500), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(501), 543611290 },
                    { 788420405, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(490), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(487), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(488), 262630033 },
                    { 831669626, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(106), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(103), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(104), 262630033 },
                    { 858736510, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(225), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(223), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(224), 262630033 },
                    { 876991758, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(409), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(407), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(408), 262630033 },
                    { 891454356, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(343), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(341), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(342), 543611290 },
                    { 891573354, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(517), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(514), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(515), 967576680 },
                    { 896713394, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(266), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(264), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(265), 262630033 },
                    { 904082750, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(146), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(144), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(145), 262630033 },
                    { 943115349, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(240), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(238), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(239), 543611290 },
                    { 944628368, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(435), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(433), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(434), 967576680 },
                    { 956322989, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(448), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(446), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(447), 262630033 },
                    { 956800172, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(4), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(2), 967576680 },
                    { 973656850, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(477), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(474), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(475), 967576680 },
                    { 978248686, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(316), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(313), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(314), 967576680 },
                    { 982960525, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(50), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(48), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(49), 967576680 },
                    { 993163412, new DateTime(2024, 4, 5, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(329), 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(327), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(328), 262630033 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 138938003, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(913), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(914), 828810783 },
                    { 164627471, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1272), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1273), 828810783 },
                    { 164911946, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1584), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1586), 944263992 },
                    { 170049920, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(961), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(962), 752753312 },
                    { 179140892, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1009), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1010), 280170162 },
                    { 182529839, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1816), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1818), 280170162 },
                    { 205282481, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(720), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(721), 298865232 },
                    { 208008572, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1284), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1285), 544632982 },
                    { 208875180, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1033), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1034), 544632982 },
                    { 238051141, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(876), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(878), 752753312 },
                    { 256198166, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1441), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1442), 298865232 },
                    { 257892621, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1841), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1842), 544632982 },
                    { 260050402, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1608), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1609), 298865232 },
                    { 264851043, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1429), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1430), 752753312 },
                    { 271798594, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1189), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1190), 828810783 },
                    { 276502825, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1296), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1297), 634901506 },
                    { 279407346, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1525), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1526), 298865232 },
                    { 284808389, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(829), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(830), 828810783 },
                    { 308305999, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1237), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1238), 752753312 },
                    { 312516624, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1719), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1721), 298865232 },
                    { 318070389, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1201), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1202), 544632982 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 322981495, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1684), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1685), 634901506 },
                    { 327205976, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1405), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1406), 634901506 },
                    { 332789912, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(937), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(938), 634901506 },
                    { 341026240, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1370), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1371), 280170162 },
                    { 357971520, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1117), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1118), 544632982 },
                    { 375982854, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1069), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1070), 752753312 },
                    { 397977141, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(889), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(890), 298865232 },
                    { 398204816, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(744), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(745), 828810783 },
                    { 402412151, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(948), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(950), 944263992 },
                    { 404062658, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1537), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1538), 280170162 },
                    { 412814291, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1596), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1597), 752753312 },
                    { 422115403, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1768), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1769), 634901506 },
                    { 425980237, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1476), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1477), 544632982 },
                    { 426790060, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1660), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1661), 828810783 },
                    { 429936504, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1248), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1250), 298865232 },
                    { 438383347, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1672), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1673), 544632982 },
                    { 443078122, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1141), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1142), 944263992 },
                    { 457663508, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1488), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1489), 634901506 },
                    { 459281791, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1092), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1093), 280170162 },
                    { 463573900, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1057), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1058), 944263992 },
                    { 491930125, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1129), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1130), 634901506 },
                    { 510036251, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(853), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(854), 634901506 },
                    { 511123677, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1793), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1794), 752753312 },
                    { 511150236, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1805), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1806), 298865232 },
                    { 512860640, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1708), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1709), 752753312 },
                    { 521973945, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1080), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1082), 298865232 },
                    { 534094737, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1213), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1214), 634901506 },
                    { 551855825, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1345), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1347), 752753312 },
                    { 559599719, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(732), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(733), 280170162 },
                    { 580125102, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1105), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1106), 828810783 },
                    { 586355778, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(806), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(807), 298865232 },
                    { 587399760, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(708), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(709), 752753312 },
                    { 588470862, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1393), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1394), 544632982 },
                    { 600899272, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1755), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1756), 544632982 },
                    { 626803895, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1549), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1550), 828810783 },
                    { 628782156, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(925), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(926), 544632982 },
                    { 632946322, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(769), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(770), 634901506 },
                    { 637218384, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1165), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1166), 298865232 },
                    { 646046119, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1513), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1514), 752753312 },
                    { 653640239, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1829), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1830), 828810783 },
                    { 655529313, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1781), -1235945912, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1782), 944263992 },
                    { 656849990, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1417), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1418), 944263992 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 665930534, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1021), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1022), 828810783 },
                    { 684500019, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(794), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(795), 752753312 },
                    { 745842753, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(996), 1142935016, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(997), 298865232 },
                    { 748974569, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(817), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(818), 280170162 },
                    { 756671352, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1045), -1522909840, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1046), 634901506 },
                    { 764660350, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1731), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1732), 280170162 },
                    { 778350370, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1561), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1562), 544632982 },
                    { 788882835, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(865), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(866), 944263992 },
                    { 790636650, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1500), -1273567776, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1501), 944263992 },
                    { 801864435, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1464), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1466), 828810783 },
                    { 811026121, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(901), -1492539104, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(903), 280170162 },
                    { 836470114, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1358), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1359), 298865232 },
                    { 838060140, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1177), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1178), 280170162 },
                    { 858245607, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1743), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1744), 828810783 },
                    { 875510758, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1153), -846811648, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1154), 752753312 },
                    { 885586377, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(841), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(842), 544632982 },
                    { 886639873, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1260), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1262), 280170162 },
                    { 903441006, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(781), -1595621368, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(782), 944263992 },
                    { 905374107, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1308), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1309), 944263992 },
                    { 909389178, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1696), -586049128, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1697), 944263992 },
                    { 912639349, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1381), 1397120936, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1383), 828810783 },
                    { 914485874, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(757), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(758), 544632982 },
                    { 917729993, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1225), 2062609040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1226), 944263992 },
                    { 927504759, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1573), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1574), 634901506 },
                    { 929516805, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(680), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(681), 634901506 },
                    { 945234885, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1620), 1183334216, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1621), 280170162 },
                    { 979919388, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(696), -1312329040, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(697), 944263992 },
                    { 981463263, 0f, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1453), 665865888, new DateTime(2024, 3, 25, 17, 24, 27, 649, DateTimeKind.Local).AddTicks(1454), 280170162 }
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
