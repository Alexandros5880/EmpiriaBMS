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
                    { 202075696, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8536), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8537), "Drainage" },
                    { 306139686, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8511), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8512), "Sewage" },
                    { 310879401, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8584), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8585), "Natural Gas" },
                    { 392062246, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8633), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8634), "CCTV" },
                    { 430837786, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8524), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8525), "Potable Water" },
                    { 439846552, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8609), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8610), "Structured Cabling" },
                    { 568391421, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8547), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8548), "Fire Detection" },
                    { 581231358, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8720), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8721), "Project Manager Hours" },
                    { 609887088, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8573), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8574), "Elevators" },
                    { 611374834, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8668), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8669), "Energy Efficiency" },
                    { 640002807, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8560), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8561), "Fire Suppression" },
                    { 761675410, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8495), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8496), "HVAC" },
                    { 797336846, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8621), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8622), "Burglar Alarm" },
                    { 812947267, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8707), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8708), "Construction Supervision" },
                    { 861601844, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8679), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8680), "Outsource" },
                    { 888682159, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8644), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8646), "BMS" },
                    { 924606338, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8656), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8657), "Photovoltaics" },
                    { 936451000, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8596), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8597), "Power Distribution" },
                    { 995448996, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8691), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8692), "TenderDocument" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 245315495, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8953), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8954), "Drawings" },
                    { 522212112, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8923), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8924), "Documents" },
                    { 908937360, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8940), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8941), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 670600962, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9546), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9547), "Meetings" },
                    { 697193106, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9534), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9535), "On-Site" },
                    { 760986459, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9522), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9523), "Printing" },
                    { 960054527, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9502), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9503), "Communications" },
                    { 975580521, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9557), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9558), "Administration" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 185966692, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6245), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6246), "Dashboard Assign Engineer", 4 },
                    { 500436528, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6369), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6370), "Display Projects Code", 13 },
                    { 556274618, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6211), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6212), "Dashboard Edit My Hours", 2 },
                    { 584929404, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6343), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6344), "See All Projects", 11 },
                    { 610616854, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6230), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6231), "Dashboard Assign Designer", 3 },
                    { 614164402, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6315), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6316), "See All Disciplines", 9 },
                    { 668294320, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6356), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6357), "Add Project On Dashboard", 12 },
                    { 682991044, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6330), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6331), "See All Drawings", 10 },
                    { 802947744, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6275), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6276), "Dashboard Add Project", 6 },
                    { 894001198, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6134), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6135), "See Dashboard Layout", 1 },
                    { 909981199, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6288), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6290), "See Admin Layout", 7 },
                    { 944996623, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6302), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6303), "Dashboard See My Hours", 8 },
                    { 985658454, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6259), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6260), "Dashboard Assign Project Manager", 5 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 181846188, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8188), "Buildings Description", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8189), "Buildings" },
                    { 350017894, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8230), "Consulting Description", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8231), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 813226173, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8204), "Infrastructure Description", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8205), "Infrastructure" },
                    { 982471349, false, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8243), "Production Management Description", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8244), "Production Management" },
                    { 996967924, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8216), "Energy Description", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8218), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 225979454, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6384), false, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6385), "Designer" },
                    { 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6460), false, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6461), "CEO" },
                    { 279878208, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6500), false, false, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6501), "Admin" },
                    { 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6446), false, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6447), "CTO" },
                    { 637804666, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6405), false, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6406), "Engineer" },
                    { 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6433), false, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6434), "COO" },
                    { 783811727, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6487), false, false, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6488), "Customer" },
                    { 946389296, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6474), false, false, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6475), "Guest" },
                    { 963992602, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6514), false, false, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6515), "Secretariat" },
                    { 968272970, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6419), false, true, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6420), "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7816), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7818), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7622), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7623), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7983), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7984), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7941), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7942), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 250480293, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7418), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7419), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8067), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8068), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7543), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7544), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7776), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7777), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 403458205, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7303), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7304), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7857), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7858), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7662), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7663), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7899), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7900), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8023), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8024), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 873404079, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7374), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7375), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8148), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8149), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8108), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8109), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7501), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7502), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7723), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7724), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7583), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7584), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 997952501, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7459), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7460), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 140628205, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7996), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7998), 228127368 },
                    { 215508703, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8161), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8163), 886365690 },
                    { 218159636, "pfokianou@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7954), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7956), 232469903 },
                    { 223859988, "vpax@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7516), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7517), 940537940 },
                    { 250181545, "dtsa@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7432), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7433), 250480293 },
                    { 356932001, "vchontos@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8080), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8081), 296594867 },
                    { 443072447, "haris@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7913), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7914), 682173113 },
                    { 452489547, "vtza@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7789), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7791), 367600131 },
                    { 479958937, "kmargeti@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7872), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7873), 558234949 },
                    { 539437527, "embiria@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7324), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7326), 403458205 },
                    { 553867968, "blekou@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8040), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8042), 772614221 },
                    { 557789004, "agretos@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7830), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7831), 146396061 },
                    { 567662307, "kkotsoni@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7737), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7738), 944727193 },
                    { 626001864, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7343), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7344), 403458205 },
                    { 656275748, "chkovras@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7635), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7636), 199433870 },
                    { 664569859, "panperivollari@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8121), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8123), 899598367 },
                    { 793026929, "ngal@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7678), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7680), 608714937 },
                    { 800164240, "dtsa@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7473), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7474), 997952501 },
                    { 827022344, "xmanarolis@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7557), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7558), 347445624 },
                    { 862145378, "gdoug@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7389), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7390), 873404079 },
                    { 993115072, "sparisis@embiria.gr", new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7596), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7597), 981498645 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 255701987, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), new DateTime(2024, 4, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Test Description Project_2", new DateTime(2024, 4, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 0f, new DateTime(2024, 4, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Project_1", 944727193, null, 181846188, 0f },
                    { 523499100, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), new DateTime(2024, 7, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Test Description Project_2", new DateTime(2024, 7, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 0f, new DateTime(2024, 7, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Project_2", 944727193, null, 813226173, 0f },
                    { 670097789, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), new DateTime(2025, 7, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Test Description Project_20", new DateTime(2025, 7, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 0f, new DateTime(2025, 7, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Project_4", 944727193, null, 350017894, 0f },
                    { 940383381, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), new DateTime(2024, 6, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Test Description Project_PM", new DateTime(2024, 4, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 0f, new DateTime(2024, 5, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 1500L, 12L, null, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Project_PM", null, null, 982471349, 0f },
                    { 961779006, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), new DateTime(2024, 12, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Test Description Project_6", new DateTime(2024, 12, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 0f, new DateTime(2024, 12, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 18, 48, 51, 254, DateTimeKind.Local).AddTicks(1935), "Project_3", 944727193, null, 996967924, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 556274618, 225979454, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6551), -486549436, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6552) },
                    { 894001198, 225979454, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6528), 1400683527, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6529) },
                    { 944996623, 225979454, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6566), -1092089956, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6567) },
                    { 185966692, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7038), 64128047, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7039) },
                    { 500436528, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7116), -1283460412, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7117) },
                    { 556274618, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7010), -575390960, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7011) },
                    { 584929404, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7103), -613228031, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7104) },
                    { 610616854, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7025), -993858641, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7026) },
                    { 614164402, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7077), -1724193755, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7078) },
                    { 668294320, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7129), 129212942, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7131) },
                    { 682991044, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7090), 1071886541, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7091) },
                    { 802947744, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7064), -1457694886, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7065) },
                    { 894001198, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6993), -1617605311, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6994) },
                    { 985658454, 269224628, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7051), -1973199262, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7052) },
                    { 584929404, 279878208, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7208), 310802896, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7210) },
                    { 614164402, 279878208, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7182), -1759385087, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7184) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 682991044, 279878208, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7195), -118725533, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7197) },
                    { 909981199, 279878208, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7169), -79175915, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7171) },
                    { 556274618, 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6887), -2050367008, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6888) },
                    { 584929404, 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6965), 256431605, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6966) },
                    { 614164402, 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6940), 1086299708, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6941) },
                    { 668294320, 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6978), -692257972, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6979) },
                    { 682991044, 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6953), 153907583, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6954) },
                    { 802947744, 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6913), -1786622210, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6914) },
                    { 894001198, 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6874), -956030845, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6875) },
                    { 944996623, 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6926), -1852274722, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6928) },
                    { 985658454, 320639903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6900), 612535370, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6901) },
                    { 556274618, 637804666, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6594), 970532042, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6596) },
                    { 610616854, 637804666, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6609), -1170454787, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6611) },
                    { 614164402, 637804666, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6641), 281831297, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6643) },
                    { 682991044, 637804666, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6655), 1615751874, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6656) },
                    { 894001198, 637804666, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6580), 105930235, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6581) },
                    { 944996623, 637804666, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6624), 551075972, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6626) },
                    { 185966692, 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6793), 1197590274, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6794) },
                    { 556274618, 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6765), 213891548, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6766) },
                    { 584929404, 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6861), 462419852, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6862) },
                    { 610616854, 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6779), -1984164245, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6780) },
                    { 614164402, 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6833), -1040183855, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6834) },
                    { 682991044, 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6846), 377006288, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6848) },
                    { 894001198, 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6752), 1194247251, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6753) },
                    { 944996623, 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6819), 1745975417, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6821) },
                    { 985658454, 768947339, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6806), -675587146, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6808) },
                    { 894001198, 783811727, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7156), -1015579736, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7157) },
                    { 894001198, 946389296, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7142), 1905715292, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7143) },
                    { 556274618, 963992602, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7234), 39104569, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7235) },
                    { 584929404, 963992602, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7286), -1823966045, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7287) },
                    { 614164402, 963992602, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7261), 1193745974, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7262) },
                    { 682991044, 963992602, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7274), -285694888, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7275) },
                    { 894001198, 963992602, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7221), -1113153443, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7223) },
                    { 944996623, 963992602, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7248), -502736894, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7249) },
                    { 185966692, 968272970, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6699), 1470398895, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6700) },
                    { 556274618, 968272970, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6685), 1997965310, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6686) },
                    { 614164402, 968272970, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6725), -1524590018, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6727) },
                    { 682991044, 968272970, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6739), -211836694, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6740) },
                    { 894001198, 968272970, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6670), -476059540, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6671) },
                    { 944996623, 968272970, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6712), 476867696, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(6714) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 637804666, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7844), 406057389, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7845) },
                    { 637804666, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7649), 951235886, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7650) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 637804666, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8010), 861770687, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8011) },
                    { 637804666, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7969), 484663200, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7970) },
                    { 225979454, 250480293, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7444), 829862412, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7446) },
                    { 637804666, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8093), 716285624, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8095) },
                    { 637804666, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7569), 380664946, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7571) },
                    { 637804666, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7803), 554422516, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7804) },
                    { 963992602, 403458205, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7356), 658660724, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7358) },
                    { 637804666, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7886), 861514638, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7887) },
                    { 269224628, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7706), 867990025, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7708) },
                    { 637804666, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7692), 643794899, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7693) },
                    { 637804666, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7926), 642831740, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7928) },
                    { 968272970, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8286), 68586264, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8287) },
                    { 637804666, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8054), 398483256, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8055) },
                    { 225979454, 873404079, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7405), 349747097, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7406) },
                    { 637804666, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8174), 362063672, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8175) },
                    { 637804666, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8134), 635833303, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8136) },
                    { 637804666, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7529), 532433245, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7531) },
                    { 968272970, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8258), 288721338, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8259) },
                    { 637804666, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7750), 973431858, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7751) },
                    { 768947339, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7763), 335728465, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7764) },
                    { 968272970, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8272), 182755107, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8273) },
                    { 637804666, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7609), 323437962, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7610) },
                    { 225979454, 997952501, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7487), 269333915, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(7488) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2144663944, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8871), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8872), 670097789, 924606338, null },
                    { -1811525552, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8845), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8846), 961779006, 861601844, null },
                    { -1523196496, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8884), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8885), 670097789, 797336846, null },
                    { -1424105848, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8896), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8897), 670097789, 861601844, null },
                    { -1272958440, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8748), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8749), 255701987, 888682159, null },
                    { -1192723264, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8821), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8822), 523499100, 924606338, null },
                    { -930148184, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8807), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8808), 523499100, 611374834, null },
                    { -921478440, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8833), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8834), 961779006, 392062246, null },
                    { -757819112, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8769), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8770), 255701987, 310879401, null },
                    { 300175576, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8857), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8858), 961779006, 924606338, null },
                    { 755117416, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8795), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8796), 523499100, 797336846, null },
                    { 1087365344, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8782), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8783), 255701987, 936451000, null },
                    { 1667480056, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8908), 0f, 500L, 0L, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8909), 940383381, 581231358, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 138769851, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8462), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8464), 13000.0, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8463), "Signature 1423420", 21342, 670097789, 4.0, 24.0 },
                    { 169822314, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8396), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8398), 3100.0, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8397), "Signature 142346", 18671, 523499100, 2.0, 24.0 },
                    { 201908768, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8359), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8362), 3010.0, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8360), "Signature 142344", 47121, 255701987, 1.0, 17.0 },
                    { 950181642, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8430), new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8432), 4000.0, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8431), "Signature 142343", 37364, 961779006, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2144663944, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2242), 143237827, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2243) },
                    { -2144663944, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2192), 780216638, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2193) },
                    { -2144663944, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2291), 557157632, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2292) },
                    { -2144663944, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2279), 170855051, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2280) },
                    { -2144663944, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2315), 875520601, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2317) },
                    { -2144663944, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2167), 957005201, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2168) },
                    { -2144663944, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2229), 152490693, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2230) },
                    { -2144663944, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2254), 840769890, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2255) },
                    { -2144663944, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2205), 588249996, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2206) },
                    { -2144663944, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2266), 530101815, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2267) },
                    { -2144663944, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2303), 260952158, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2304) },
                    { -2144663944, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2342), 788894031, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2343) },
                    { -2144663944, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2328), 240160330, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2329) },
                    { -2144663944, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2155), 604677061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2156) },
                    { -2144663944, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2217), 430552653, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2218) },
                    { -2144663944, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2180), 569864849, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2181) },
                    { -1811525552, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1843), 868702626, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1844) },
                    { -1811525552, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1795), 801721074, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1796) },
                    { -1811525552, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1891), 210059650, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1892) },
                    { -1811525552, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1878), 298472966, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1879) },
                    { -1811525552, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1916), 320084529, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1917) },
                    { -1811525552, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1770), 929270686, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1771) },
                    { -1811525552, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1831), 384689058, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1832) },
                    { -1811525552, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1854), 593781084, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1855) },
                    { -1811525552, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1807), 962845666, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1808) },
                    { -1811525552, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1866), 993899545, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1867) },
                    { -1811525552, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1904), 485833956, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1905) },
                    { -1811525552, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1940), 406503895, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1941) },
                    { -1811525552, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1928), 166291888, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1929) },
                    { -1811525552, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1758), 231154557, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1759) },
                    { -1811525552, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1819), 622029654, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1820) },
                    { -1811525552, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1782), 280235902, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1784) },
                    { -1523196496, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2442), 841552459, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2443) },
                    { -1523196496, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2392), 221935005, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2393) },
                    { -1523196496, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2490), 694741320, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2491) },
                    { -1523196496, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2478), 301588132, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2479) },
                    { -1523196496, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2515), 775663616, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2516) },
                    { -1523196496, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2367), 563824252, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2369) },
                    { -1523196496, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2429), 682894053, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2430) },
                    { -1523196496, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2454), 928706342, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2455) },
                    { -1523196496, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2404), 946905471, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2406) },
                    { -1523196496, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2466), 199592993, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2467) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1523196496, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2502), 915131136, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2504) },
                    { -1523196496, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2540), 631613265, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2541) },
                    { -1523196496, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2527), 833104011, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2528) },
                    { -1523196496, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2355), 944910136, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2356) },
                    { -1523196496, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2417), 561254154, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2418) },
                    { -1523196496, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2380), 857979305, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2381) },
                    { -1424105848, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2640), 312678439, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2641) },
                    { -1424105848, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2590), 818876354, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2591) },
                    { -1424105848, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2689), 780033923, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2690) },
                    { -1424105848, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2677), 645486874, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2678) },
                    { -1424105848, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2714), 889449673, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2715) },
                    { -1424105848, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2565), 914454782, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2566) },
                    { -1424105848, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2627), 315847914, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2628) },
                    { -1424105848, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2652), 796173212, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2653) },
                    { -1424105848, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2603), 792813508, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2604) },
                    { -1424105848, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2664), 694552712, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2665) },
                    { -1424105848, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2701), 327606982, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2702) },
                    { -1424105848, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2742), 708942244, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2743) },
                    { -1424105848, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2729), 174292925, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2730) },
                    { -1424105848, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2553), 679470245, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2554) },
                    { -1424105848, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2615), 305986628, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2616) },
                    { -1424105848, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2578), 527968560, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2579) },
                    { -1272958440, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(471), 261106206, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(472) },
                    { -1272958440, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(421), 683178900, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(422) },
                    { -1272958440, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(519), 766417903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(520) },
                    { -1272958440, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(507), 925436060, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(508) },
                    { -1272958440, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(542), 812610599, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(543) },
                    { -1272958440, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(396), 781220739, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(397) },
                    { -1272958440, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(459), 138636881, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(460) },
                    { -1272958440, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(482), 699247898, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(483) },
                    { -1272958440, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(433), 372070068, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(435) },
                    { -1272958440, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(495), 530736289, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(496) },
                    { -1272958440, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(531), 474310137, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(532) },
                    { -1272958440, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(566), 502927555, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(567) },
                    { -1272958440, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(554), 652574805, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(555) },
                    { -1272958440, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(380), 424609612, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(381) },
                    { -1272958440, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(446), 190583329, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(447) },
                    { -1272958440, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(409), 213575109, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(410) },
                    { -1192723264, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1451), 484768133, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1452) },
                    { -1192723264, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1403), 940466357, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1404) },
                    { -1192723264, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1498), 391046112, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1499) },
                    { -1192723264, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1486), 389759482, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1487) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1192723264, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1523), 662472942, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1525) },
                    { -1192723264, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1379), 433773332, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1380) },
                    { -1192723264, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1439), 146847421, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1440) },
                    { -1192723264, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1463), 531898406, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1464) },
                    { -1192723264, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1415), 457300944, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1416) },
                    { -1192723264, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1474), 198107333, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1476) },
                    { -1192723264, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1511), 961781537, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1512) },
                    { -1192723264, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1547), 940983557, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1548) },
                    { -1192723264, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1535), 439027979, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1536) },
                    { -1192723264, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1367), 898569741, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1368) },
                    { -1192723264, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1427), 401547477, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1428) },
                    { -1192723264, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1391), 384824777, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1392) },
                    { -930148184, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1255), 247607885, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1256) },
                    { -930148184, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1207), 596524558, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1208) },
                    { -930148184, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1306), 900008885, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1307) },
                    { -930148184, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1294), 938832099, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1295) },
                    { -930148184, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1330), 131951181, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1331) },
                    { -930148184, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1182), 852635119, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1183) },
                    { -930148184, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1243), 556513080, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1244) },
                    { -930148184, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1267), 873797451, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1268) },
                    { -930148184, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1219), 564315346, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1220) },
                    { -930148184, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1279), 969606016, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1280) },
                    { -930148184, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1318), 381205929, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1319) },
                    { -930148184, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1354), 276809649, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1356) },
                    { -930148184, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1342), 908405926, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1343) },
                    { -930148184, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1169), 400835564, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1170) },
                    { -930148184, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1231), 375423783, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1232) },
                    { -930148184, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1195), 929256585, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1196) },
                    { -921478440, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1645), 376305526, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1646) },
                    { -921478440, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1596), 349968519, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1597) },
                    { -921478440, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1697), 930531626, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1698) },
                    { -921478440, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1685), 246468590, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1686) },
                    { -921478440, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1721), 281060777, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1723) },
                    { -921478440, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1572), 433363004, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1573) },
                    { -921478440, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1632), 699772352, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1633) },
                    { -921478440, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1657), 642054636, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1658) },
                    { -921478440, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1608), 649026890, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1609) },
                    { -921478440, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1673), 124852780, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1674) },
                    { -921478440, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1709), 767682026, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1710) },
                    { -921478440, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1745), 176989776, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1746) },
                    { -921478440, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1733), 912896870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1734) },
                    { -921478440, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1559), 445878911, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1560) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -921478440, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1621), 352185532, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1622) },
                    { -921478440, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1584), 501687148, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1585) },
                    { -757819112, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(665), 502961773, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(666) },
                    { -757819112, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(618), 897851119, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(619) },
                    { -757819112, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(713), 511285035, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(714) },
                    { -757819112, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(701), 797626964, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(702) },
                    { -757819112, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(736), 596284859, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(737) },
                    { -757819112, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(591), 461447176, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(592) },
                    { -757819112, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(653), 906362914, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(654) },
                    { -757819112, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(677), 744339495, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(678) },
                    { -757819112, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(629), 498484225, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(630) },
                    { -757819112, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(689), 686477228, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(690) },
                    { -757819112, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(725), 675511616, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(726) },
                    { -757819112, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(760), 517369764, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(761) },
                    { -757819112, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(748), 604047460, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(749) },
                    { -757819112, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(578), 841599679, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(579) },
                    { -757819112, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(641), 854221654, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(642) },
                    { -757819112, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(606), 168884210, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(607) },
                    { 300175576, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2043), 778602454, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2044) },
                    { 300175576, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1994), 248860786, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1995) },
                    { 300175576, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2092), 887301552, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2094) },
                    { 300175576, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2080), 662438775, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2081) },
                    { 300175576, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2118), 451177698, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2119) },
                    { 300175576, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1969), 485709763, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1970) },
                    { 300175576, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2031), 544650454, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2032) },
                    { 300175576, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2056), 949536637, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2057) },
                    { 300175576, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2006), 889052716, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2007) },
                    { 300175576, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2068), 474490382, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2069) },
                    { 300175576, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2105), 818555173, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2106) },
                    { 300175576, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2142), 476448847, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2143) },
                    { 300175576, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2130), 352483445, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2131) },
                    { 300175576, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1952), 176155852, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1953) },
                    { 300175576, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2019), 408063935, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(2020) },
                    { 300175576, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1981), 576077003, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1982) },
                    { 755117416, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1049), 212566317, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1050) },
                    { 755117416, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1002), 963198468, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1003) },
                    { 755117416, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1096), 523559002, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1097) },
                    { 755117416, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1084), 281844493, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1085) },
                    { 755117416, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1120), 683595839, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1121) },
                    { 755117416, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(978), 814066140, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(979) },
                    { 755117416, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1037), 700298763, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1038) },
                    { 755117416, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1060), 372646055, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1061) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 755117416, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1013), 485261786, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1014) },
                    { 755117416, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1072), 806197301, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1073) },
                    { 755117416, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1108), 328808065, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1109) },
                    { 755117416, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1143), 869771210, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1144) },
                    { 755117416, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1132), 967510003, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1133) },
                    { 755117416, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(966), 298360475, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(967) },
                    { 755117416, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1025), 302707504, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1026) },
                    { 755117416, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(990), 505922717, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(991) },
                    { 1087365344, 146396061, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(857), 330078423, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(858) },
                    { 1087365344, 199433870, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(810), 915737701, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(811) },
                    { 1087365344, 228127368, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(904), 268731783, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(905) },
                    { 1087365344, 232469903, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(892), 488676028, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(893) },
                    { 1087365344, 296594867, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(928), 877171523, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(929) },
                    { 1087365344, 347445624, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(786), 466555662, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(787) },
                    { 1087365344, 367600131, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(846), 254535631, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(847) },
                    { 1087365344, 558234949, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(869), 668423311, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(870) },
                    { 1087365344, 608714937, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(822), 216288475, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(823) },
                    { 1087365344, 682173113, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(881), 591746096, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(882) },
                    { 1087365344, 772614221, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(916), 291675387, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(917) },
                    { 1087365344, 886365690, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(954), 483095234, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(955) },
                    { 1087365344, 899598367, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(940), 807943226, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(941) },
                    { 1087365344, 940537940, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(773), 758326175, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(774) },
                    { 1087365344, 944727193, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(834), 527732329, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(835) },
                    { 1087365344, 981498645, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(798), 265860927, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(799) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 163190622, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9141), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9139), -930148184, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9140), 522212112 },
                    { 172862702, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9155), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9152), -930148184, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9153), 908937360 },
                    { 182220349, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9342), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9340), -2144663944, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9341), 522212112 },
                    { 218665958, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9002), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8999), -1272958440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9001), 245315495 },
                    { 249194039, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9047), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9044), -757819112, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9045), 245315495 },
                    { 249491844, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9209), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9206), -1192723264, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9208), 245315495 },
                    { 253873248, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9490), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9487), 1667480056, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9489), 245315495 },
                    { 309179976, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9313), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9311), 300175576, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9312), 908937360 },
                    { 314310894, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9407), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9405), -1523196496, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9406), 245315495 },
                    { 330002787, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9423), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9420), -1424105848, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9421), 522212112 },
                    { 368132733, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8970), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8966), -1272958440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8968), 522212112 },
                    { 422979266, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9300), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9298), 300175576, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9299), 522212112 },
                    { 424411616, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9101), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9099), 755117416, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9100), 522212112 },
                    { 456724231, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9274), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9272), -1811525552, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9273), 908937360 },
                    { 475102032, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9248), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9246), -921478440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9247), 245315495 },
                    { 482496406, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9477), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9474), 1667480056, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9475), 908937360 },
                    { 486962491, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9015), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9013), -757819112, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9014), 522212112 },
                    { 491725249, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9381), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9379), -1523196496, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9380), 522212112 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 504307935, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9463), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9460), 1667480056, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9461), 522212112 },
                    { 566281438, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9031), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9029), -757819112, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9030), 908937360 },
                    { 569510485, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9235), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9233), -921478440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9234), 908937360 },
                    { 571533822, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9449), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9446), -1424105848, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9447), 245315495 },
                    { 613011737, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9128), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9126), 755117416, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9127), 245315495 },
                    { 636160231, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9394), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9392), -1523196496, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9393), 908937360 },
                    { 656089947, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9287), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9285), -1811525552, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9286), 245315495 },
                    { 658061919, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9436), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9433), -1424105848, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9434), 908937360 },
                    { 723118439, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9355), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9353), -2144663944, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9354), 908937360 },
                    { 728513966, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9326), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9324), 300175576, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9325), 245315495 },
                    { 735911782, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9194), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9192), -1192723264, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9193), 908937360 },
                    { 788131346, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9222), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9220), -921478440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9221), 522212112 },
                    { 834837800, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9168), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9165), -930148184, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9166), 245315495 },
                    { 839882821, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9073), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9071), 1087365344, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9072), 908937360 },
                    { 855174127, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9087), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9084), 1087365344, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9085), 245315495 },
                    { 859032403, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8989), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8986), -1272958440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(8987), 908937360 },
                    { 902894168, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9060), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9058), 1087365344, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9059), 522212112 },
                    { 914656853, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9181), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9179), -1192723264, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9180), 522212112 },
                    { 929089861, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9115), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9113), 755117416, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9114), 908937360 },
                    { 941902303, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9261), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9259), -1811525552, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9260), 522212112 },
                    { 980758952, new DateTime(2024, 3, 31, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9368), 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9366), -2144663944, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9367), 245315495 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 132765479, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9803), 755117416, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9804), 670600962 },
                    { 164316981, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(86), 300175576, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(87), 760986459 },
                    { 164525272, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9730), 1087365344, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9731), 697193106 },
                    { 187532139, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(74), 300175576, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(75), 960054527 },
                    { 199868128, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(195), -1523196496, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(196), 960054527 },
                    { 206655313, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9600), -1272958440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9601), 697193106 },
                    { 237459437, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(171), -2144663944, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(172), 670600962 },
                    { 240280446, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(62), -1811525552, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(63), 975580521 },
                    { 242951796, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(267), -1424105848, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(268), 760986459 },
                    { 244615305, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9667), -757819112, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9668), 697193106 },
                    { 250105298, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(12), -1811525552, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(14), 960054527 },
                    { 264056165, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9875), -930148184, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9876), 975580521 },
                    { 266834634, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9948), -921478440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9949), 960054527 },
                    { 270560015, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(147), -2144663944, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(148), 760986459 },
                    { 272016552, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local), -921478440, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(1), 975580521 },
                    { 295527505, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(331), 1667480056, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(332), 760986459 },
                    { 301632346, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9815), 755117416, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9816), 975580521 },
                    { 302142903, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(25), -1811525552, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(26), 760986459 },
                    { 325288818, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(354), 1667480056, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(355), 670600962 },
                    { 345836236, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9851), -930148184, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9852), 697193106 },
                    { 360725017, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(122), 300175576, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(123), 975580521 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 371758735, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(37), -1811525552, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(38), 697193106 },
                    { 385350322, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(98), 300175576, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(99), 697193106 },
                    { 417009372, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9654), -757819112, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9655), 760986459 },
                    { 428407451, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9988), -921478440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9989), 670600962 },
                    { 438613090, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9960), -921478440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9961), 760986459 },
                    { 450427260, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(182), -2144663944, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(184), 975580521 },
                    { 450615420, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(219), -1523196496, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(220), 697193106 },
                    { 479568420, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9936), -1192723264, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9937), 975580521 },
                    { 489959389, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9766), 755117416, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9767), 960054527 },
                    { 495024695, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9705), 1087365344, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9707), 960054527 },
                    { 502722033, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(343), 1667480056, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(344), 697193106 },
                    { 514094494, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9863), -930148184, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9864), 670600962 },
                    { 514300093, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9827), -930148184, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9828), 960054527 },
                    { 514753215, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9625), -1272958440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9626), 975580521 },
                    { 520087592, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9572), -1272958440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9573), 960054527 },
                    { 550156598, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9718), 1087365344, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9719), 760986459 },
                    { 574160251, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(135), -2144663944, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(136), 960054527 },
                    { 583230158, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9742), 1087365344, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9743), 670600962 },
                    { 623195657, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(279), -1424105848, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(280), 697193106 },
                    { 623847123, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9613), -1272958440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9614), 670600962 },
                    { 639380192, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9974), -921478440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9975), 697193106 },
                    { 650216118, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9680), -757819112, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9682), 670600962 },
                    { 654613672, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(242), -1523196496, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(243), 975580521 },
                    { 700574622, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9588), -1272958440, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9589), 760986459 },
                    { 722758204, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(207), -1523196496, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(208), 760986459 },
                    { 743661423, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9839), -930148184, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9840), 760986459 },
                    { 749594572, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(231), -1523196496, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(232), 670600962 },
                    { 752924331, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(159), -2144663944, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(160), 697193106 },
                    { 764050337, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9912), -1192723264, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9913), 697193106 },
                    { 764700303, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(110), 300175576, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(111), 670600962 },
                    { 784111494, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9754), 1087365344, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9755), 975580521 },
                    { 798804157, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9638), -757819112, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9639), 960054527 },
                    { 800377704, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9791), 755117416, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9792), 697193106 },
                    { 855458475, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(255), -1424105848, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(256), 960054527 },
                    { 863615161, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9888), -1192723264, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9889), 960054527 },
                    { 866925023, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(49), -1811525552, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(50), 670600962 },
                    { 873985288, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(290), -1424105848, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(292), 670600962 },
                    { 878880093, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9693), -757819112, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9694), 975580521 },
                    { 885277796, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(365), 1667480056, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(366), 975580521 },
                    { 923657025, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9778), 755117416, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9779), 760986459 },
                    { 931994542, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9924), -1192723264, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9925), 670600962 },
                    { 942226170, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(305), -1424105848, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(306), 975580521 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[] { 947217647, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9900), -1192723264, new DateTime(2024, 3, 20, 18, 48, 51, 265, DateTimeKind.Local).AddTicks(9901), 760986459 });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[] { 994236101, 0f, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(318), 1667480056, new DateTime(2024, 3, 20, 18, 48, 51, 266, DateTimeKind.Local).AddTicks(319), 960054527 });

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
