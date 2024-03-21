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
                    { 202853465, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6894), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6895), "Elevators" },
                    { 269518097, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6973), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6974), "BMS" },
                    { 342313655, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6882), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6883), "Fire Suppression" },
                    { 358220353, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6868), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6869), "Fire Detection" },
                    { 382729001, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6843), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6845), "Potable Water" },
                    { 487001429, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6999), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7001), "Energy Efficiency" },
                    { 487221608, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6947), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6948), "Burglar Alarm" },
                    { 521625323, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6986), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6988), "Photovoltaics" },
                    { 541495820, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6960), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6961), "CCTV" },
                    { 615357356, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7012), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7014), "Outsource" },
                    { 648385688, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6811), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6812), "HVAC" },
                    { 753919835, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6906), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6907), "Natural Gas" },
                    { 767162181, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7026), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7027), "TenderDocument" },
                    { 833668483, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7054), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7055), "Project Manager Hours" },
                    { 845836848, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6934), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6935), "Structured Cabling" },
                    { 847313232, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7040), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7041), "Construction Supervision" },
                    { 876781193, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6856), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6857), "Drainage" },
                    { 934144227, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6831), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6832), "Sewage" },
                    { 956640577, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6919), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6920), "Power Distribution" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 556107721, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7279), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7281), "Documents" },
                    { 905097702, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7310), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7311), "Drawings" },
                    { 967706797, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7297), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7298), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 347881428, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7929), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7930), "Administration" },
                    { 408799508, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7871), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7872), "Communications" },
                    { 643289526, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7890), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7891), "Printing" },
                    { 697475397, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7916), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7917), "Meetings" },
                    { 879514320, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7903), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7904), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 230616297, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4491), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4492), "Dashboard Add Project", 6 },
                    { 236066511, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4551), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4552), "See All Drawings", 10 },
                    { 258372551, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4475), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4477), "Dashboard Assign Project Manager", 5 },
                    { 279289892, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4564), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4566), "See All Projects", 11 },
                    { 300319765, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4430), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4431), "Dashboard Edit My Hours", 2 },
                    { 515872871, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4343), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4344), "See Dashboard Layout", 1 },
                    { 598912606, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4536), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4537), "See All Disciplines", 9 },
                    { 667605310, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4447), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4448), "Dashboard Assign Designer", 3 },
                    { 694444484, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4462), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4463), "Dashboard Assign Engineer", 4 },
                    { 756338274, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4519), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4520), "Dashboard See My Hours", 8 },
                    { 840250062, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4591), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4593), "Display Projects Code", 13 },
                    { 921385813, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4578), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4579), "Add Project On Dashboard", 12 },
                    { 985478399, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4505), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4506), "See Admin Layout", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 237447260, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6498), "Buildings Description", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6499), "Buildings" },
                    { 651852659, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6515), "Infrastructure Description", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6516), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 705126219, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6543), "Consulting Description", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6544), "Consulting" },
                    { 908990001, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6529), "Energy Description", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6530), "Energy" },
                    { 928564771, false, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6557), "Production Management Description", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6558), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 291407471, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4713), false, false, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4714), "Customer" },
                    { 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4658), false, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4659), "COO" },
                    { 319725511, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4608), false, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4609), "Designer" },
                    { 332494721, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4740), false, false, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4741), "Secretariat" },
                    { 393642470, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4629), false, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4631), "Engineer" },
                    { 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4671), false, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4672), "CTO" },
                    { 896031082, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4644), false, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4645), "Project Manager" },
                    { 959268592, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4726), false, false, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4727), "Admin" },
                    { 983776628, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4699), false, false, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4700), "Guest" },
                    { 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4685), false, true, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4686), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6456), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6457), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6414), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6415), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 173705430, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5641), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5642), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 226688330, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5725), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5726), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6241), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6242), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6156), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6157), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6113), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6114), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 387385853, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5562), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5564), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5999), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6000), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6199), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6200), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 479685577, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5684), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5685), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6068), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6069), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6283), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6284), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6325), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6327), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6368), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6370), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5900), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5901), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5857), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5858), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5816), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5817), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5772), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5773), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5942), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5943), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 141846148, "blekou@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6341), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6342), 727973649 },
                    { 189706580, "agretos@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6128), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6129), 360689923 },
                    { 222683876, "panperivollari@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6428), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6430), 135037539 },
                    { 473588727, "gdoug@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5656), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5657), 173705430 },
                    { 559282954, "vtza@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6086), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6087), 610922851 },
                    { 569456123, "haris@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6213), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6214), 402491796 },
                    { 592366865, "dtsa@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5739), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5740), 226688330 },
                    { 597681918, "dtsa@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5698), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5699), 479685577 },
                    { 602262190, "kkotsoni@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6014), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6015), 401133005 },
                    { 605531196, "chkovras@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5914), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5915), 788756432 },
                    { 608488290, "ngal@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5957), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5958), 986932773 },
                    { 615756342, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5606), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5607), 387385853 },
                    { 631523713, "sparisis@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5871), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5872), 850333790 },
                    { 669748950, "vchontos@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6382), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6384), 764279183 },
                    { 718759910, "xmanarolis@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5830), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5831), 867975792 },
                    { 735727391, "kmargeti@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6171), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6172), 344445296 },
                    { 759341012, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6470), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6471), 130054862 },
                    { 929722859, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6297), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6298), 616192107 },
                    { 942161990, "pfokianou@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6255), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6256), 272537563 },
                    { 952244165, "embiria@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5583), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5585), 387385853 },
                    { 961996288, "vpax@embiria.gr", new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5788), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5789), 955955768 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 146932966, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), new DateTime(2024, 6, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Test Description Project_PM", new DateTime(2024, 4, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 0f, new DateTime(2024, 5, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 1500L, 12L, null, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Project_PM", null, null, 928564771, 0f },
                    { 162033542, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), new DateTime(2024, 7, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Test Description Project_4", new DateTime(2024, 7, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 0f, new DateTime(2024, 7, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Project_2", 401133005, null, 651852659, 0f },
                    { 319926819, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), new DateTime(2024, 4, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Test Description Project_1", new DateTime(2024, 4, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 0f, new DateTime(2024, 4, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Project_1", 401133005, null, 237447260, 0f },
                    { 376943842, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), new DateTime(2025, 7, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Test Description Project_4", new DateTime(2025, 7, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 0f, new DateTime(2025, 7, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Project_4", 401133005, null, 705126219, 0f },
                    { 587605288, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), new DateTime(2024, 12, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Test Description Project_18", new DateTime(2024, 12, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 0f, new DateTime(2024, 12, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), 1500L, 12L, 10000.0, new DateTime(2024, 3, 21, 14, 10, 9, 214, DateTimeKind.Local).AddTicks(6452), "Project_3", 401133005, null, 908990001, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 515872871, 291407471, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5401), -1826292806, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5402) },
                    { 236066511, 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5075), -446734745, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5076) },
                    { 258372551, 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5034), -575958802, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5035) },
                    { 279289892, 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5090), -1028572708, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5091) },
                    { 300319765, 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4992), 1727146301, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4993) },
                    { 515872871, 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4978), -1699886542, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4979) },
                    { 598912606, 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5061), -786023401, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5063) },
                    { 667605310, 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5006), 1232289720, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5008) },
                    { 694444484, 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5020), -652164727, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5022) },
                    { 756338274, 301476071, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5048), 983612993, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5049) },
                    { 300319765, 319725511, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4775), -1321563770, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4776) },
                    { 515872871, 319725511, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4753), 317279867, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4756) },
                    { 756338274, 319725511, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4790), 691630016, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4791) },
                    { 236066511, 332494721, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5531), 82918531, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5532) },
                    { 279289892, 332494721, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5545), -773825764, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5546) },
                    { 300319765, 332494721, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5487), 1355248400, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5488) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 515872871, 332494721, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5472), 1868461452, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5473) },
                    { 598912606, 332494721, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5517), 1391641209, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5518) },
                    { 756338274, 332494721, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5502), 1319384399, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5503) },
                    { 236066511, 393642470, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4875), -241762081, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4877) },
                    { 300319765, 393642470, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4818), -1829563699, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4819) },
                    { 515872871, 393642470, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4804), -1519796051, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4806) },
                    { 598912606, 393642470, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4861), 894848054, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4863) },
                    { 667605310, 393642470, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4833), 1341629397, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4835) },
                    { 756338274, 393642470, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4847), -1767629987, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4848) },
                    { 230616297, 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5144), -1095220124, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5146) },
                    { 236066511, 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5186), 1586561535, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5187) },
                    { 258372551, 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5130), -1252008076, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5132) },
                    { 279289892, 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5199), -1916151893, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5201) },
                    { 300319765, 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5117), -1463758145, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5118) },
                    { 515872871, 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5103), 1966257356, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5105) },
                    { 598912606, 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5172), -1156439672, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5173) },
                    { 756338274, 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5158), -1132116731, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5159) },
                    { 921385813, 420234709, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5213), 1178781224, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5214) },
                    { 236066511, 896031082, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4963), -1990618951, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4965) },
                    { 300319765, 896031082, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4904), 142115608, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4906) },
                    { 515872871, 896031082, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4891), -1322950004, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4892) },
                    { 598912606, 896031082, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4949), 1228915305, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4950) },
                    { 694444484, 896031082, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4918), -255246533, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4919) },
                    { 756338274, 896031082, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4932), -1692977417, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(4933) },
                    { 236066511, 959268592, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5443), 1759771179, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5444) },
                    { 279289892, 959268592, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5457), 1152536144, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5459) },
                    { 598912606, 959268592, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5429), 1290882605, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5430) },
                    { 985478399, 959268592, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5415), -819963229, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5416) },
                    { 515872871, 983776628, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5387), 1625335767, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5388) },
                    { 230616297, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5300), -1402587629, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5301) },
                    { 236066511, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5328), 1925750457, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5329) },
                    { 258372551, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5286), -812816842, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5287) },
                    { 279289892, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5345), 1648852965, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5347) },
                    { 300319765, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5244), 100746392, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5245) },
                    { 515872871, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5229), -921547822, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5230) },
                    { 598912606, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5314), -1300979920, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5315) },
                    { 667605310, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5258), -349895825, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5259) },
                    { 694444484, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5272), 607764659, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5273) },
                    { 840250062, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5359), -1683402452, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5360) },
                    { 921385813, 992532762, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5373), -1554402347, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5374) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 393642470, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6483), 687069575, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6485) },
                    { 393642470, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6442), 557339499, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6443) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 319725511, 173705430, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5669), 938951410, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5670) },
                    { 319725511, 226688330, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5757), 364868252, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5758) },
                    { 393642470, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6269), 543873610, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6270) },
                    { 393642470, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6185), 736947842, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6186) },
                    { 393642470, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6142), 779011524, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6143) },
                    { 332494721, 387385853, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5621), 394433891, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5623) },
                    { 301476071, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6041), 685155827, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6042) },
                    { 393642470, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6028), 690444023, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6029) },
                    { 420234709, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6054), 729669612, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6056) },
                    { 896031082, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6587), 210406075, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6588) },
                    { 393642470, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6226), 720158029, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6227) },
                    { 896031082, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6601), 186381408, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6602) },
                    { 319725511, 479685577, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5711), 443308159, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5712) },
                    { 393642470, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6100), 319472684, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6101) },
                    { 393642470, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6312), 510665513, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6313) },
                    { 393642470, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6355), 233802086, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6356) },
                    { 393642470, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6397), 970593538, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6398) },
                    { 393642470, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5928), 480947880, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5929) },
                    { 393642470, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5885), 656891081, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5887) },
                    { 393642470, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5843), 278394485, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5844) },
                    { 393642470, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5801), 838003772, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5803) },
                    { 896031082, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6572), 66603034, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6573) },
                    { 393642470, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5971), 703635445, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5972) },
                    { 992532762, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5985), 930888752, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(5986) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1454614768, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7263), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7264), 146932966, 833668483, null },
                    { -1431331256, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7184), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7185), 587605288, 269518097, null },
                    { -1124969696, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7224), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7225), 376943842, 358220353, null },
                    { -818991168, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7084), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7085), 319926819, 541495820, null },
                    { -453324264, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7170), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7171), 162033542, 845836848, null },
                    { 412079096, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7110), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7111), 319926819, 487001429, null },
                    { 608522048, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7154), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7155), 162033542, 202853465, null },
                    { 637731232, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7124), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7126), 319926819, 358220353, null },
                    { 1311582544, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7196), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7198), 587605288, 876781193, null },
                    { 1399431840, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7237), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7238), 376943842, 541495820, null },
                    { 1474959440, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7140), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7141), 162033542, 342313655, null },
                    { 1751555064, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7210), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7211), 587605288, 541495820, null },
                    { 1927545736, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7250), 0f, 500L, 0L, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7251), 376943842, 342313655, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 161463694, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6709), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6711), 3100.0, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6710), "Signature 1423410", 17269, 162033542, 2.0, 24.0 },
                    { 180364795, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6666), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6668), 3010.0, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6667), "Signature 142346", 16572, 319926819, 1.0, 17.0 },
                    { 354503002, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6778), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6780), 13000.0, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6779), "Signature 1423420", 16324, 376943842, 4.0, 24.0 },
                    { 555445326, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6743), new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6745), 4000.0, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(6744), "Signature 1423418", 86913, 587605288, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1431331256, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(210), 393089686, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(211) },
                    { -1431331256, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(197), 735063003, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(198) },
                    { -1431331256, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(144), 660142790, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(145) },
                    { -1431331256, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(119), 471269272, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(120) },
                    { -1431331256, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(106), 907910521, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(108) },
                    { -1431331256, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(81), 439217962, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(82) },
                    { -1431331256, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(131), 306247492, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(133) },
                    { -1431331256, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(94), 229122795, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(95) },
                    { -1431331256, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(157), 787586660, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(158) },
                    { -1431331256, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(169), 735088020, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(170) },
                    { -1431331256, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(182), 900387750, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(183) },
                    { -1431331256, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(56), 309405165, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(57) },
                    { -1431331256, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(43), 812606161, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(44) },
                    { -1431331256, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(30), 366366467, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(31) },
                    { -1431331256, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(18), 840384579, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(19) },
                    { -1431331256, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(68), 459747153, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(70) },
                    { -1124969696, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1011), 645030082, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1012) },
                    { -1124969696, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(998), 930191286, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(999) },
                    { -1124969696, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(946), 468557950, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(948) },
                    { -1124969696, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(921), 399859668, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(922) },
                    { -1124969696, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(908), 428423240, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(909) },
                    { -1124969696, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(882), 994974415, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(884) },
                    { -1124969696, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(933), 867578661, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(935) },
                    { -1124969696, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(895), 705750100, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(896) },
                    { -1124969696, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(959), 224410615, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(960) },
                    { -1124969696, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(972), 626147101, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(973) },
                    { -1124969696, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(985), 334934631, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(986) },
                    { -1124969696, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(857), 146516516, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(858) },
                    { -1124969696, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(844), 487657988, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(845) },
                    { -1124969696, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(831), 729015573, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(832) },
                    { -1124969696, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(819), 409483187, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(820) },
                    { -1124969696, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(870), 438160329, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(871) },
                    { -818991168, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8977), 541031948, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8978) },
                    { -818991168, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8964), 161848784, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8966) },
                    { -818991168, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8914), 158300731, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8915) },
                    { -818991168, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8887), 323539974, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8888) },
                    { -818991168, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8874), 825674341, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8876) },
                    { -818991168, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8849), 560399840, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8850) },
                    { -818991168, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8901), 798592109, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8902) },
                    { -818991168, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8862), 326604938, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8863) },
                    { -818991168, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8926), 421300694, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8927) },
                    { -818991168, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8939), 211763516, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8940) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -818991168, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8952), 647776119, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8953) },
                    { -818991168, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8822), 650718695, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8823) },
                    { -818991168, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8809), 771596494, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8810) },
                    { -818991168, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8796), 217986994, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8797) },
                    { -818991168, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8778), 400515686, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8779) },
                    { -818991168, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8835), 509122955, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8836) },
                    { -453324264, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(5), 882964324, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(6) },
                    { -453324264, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9992), 343447539, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9994) },
                    { -453324264, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9941), 221520906, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9942) },
                    { -453324264, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9916), 623474607, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9917) },
                    { -453324264, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9904), 931483719, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9905) },
                    { -453324264, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9878), 785543068, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9879) },
                    { -453324264, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9929), 967998609, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9930) },
                    { -453324264, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9891), 409943300, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9892) },
                    { -453324264, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9954), 367600167, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9955) },
                    { -453324264, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9967), 714465513, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9968) },
                    { -453324264, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9979), 386498346, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9981) },
                    { -453324264, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9853), 666099503, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9854) },
                    { -453324264, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9840), 950945817, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9842) },
                    { -453324264, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9828), 843746566, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9829) },
                    { -453324264, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9815), 208288405, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9816) },
                    { -453324264, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9866), 822393163, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9867) },
                    { 412079096, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9185), 991079219, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9186) },
                    { 412079096, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9172), 296103336, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9173) },
                    { 412079096, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9121), 835930679, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9122) },
                    { 412079096, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9095), 646468732, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9097) },
                    { 412079096, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9080), 126422844, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9081) },
                    { 412079096, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9054), 983422951, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9056) },
                    { 412079096, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9108), 721459607, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9109) },
                    { 412079096, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9067), 610973591, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9068) },
                    { 412079096, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9134), 243348744, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9135) },
                    { 412079096, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9147), 137455058, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9148) },
                    { 412079096, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9159), 210908974, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9160) },
                    { 412079096, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9029), 240946893, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9030) },
                    { 412079096, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9016), 739325347, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9017) },
                    { 412079096, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9003), 391968618, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9004) },
                    { 412079096, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8990), 640812229, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8991) },
                    { 412079096, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9042), 875504950, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9043) },
                    { 608522048, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9799), 509912343, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9800) },
                    { 608522048, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9786), 535123571, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9787) },
                    { 608522048, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9736), 724352170, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9737) },
                    { 608522048, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9711), 829478424, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9712) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 608522048, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9698), 841718682, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9699) },
                    { 608522048, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9673), 884290343, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9674) },
                    { 608522048, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9723), 636254199, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9724) },
                    { 608522048, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9685), 900458247, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9686) },
                    { 608522048, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9749), 176302553, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9750) },
                    { 608522048, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9761), 396525297, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9762) },
                    { 608522048, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9774), 531436906, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9775) },
                    { 608522048, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9647), 326351417, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9648) },
                    { 608522048, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9634), 533300687, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9635) },
                    { 608522048, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9622), 678732996, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9623) },
                    { 608522048, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9608), 413261829, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9609) },
                    { 608522048, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9660), 916250243, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9661) },
                    { 637731232, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9389), 401607180, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9390) },
                    { 637731232, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9376), 942049550, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9377) },
                    { 637731232, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9325), 245648668, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9326) },
                    { 637731232, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9300), 819147271, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9301) },
                    { 637731232, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9287), 484493774, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9288) },
                    { 637731232, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9262), 286017901, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9263) },
                    { 637731232, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9313), 824751292, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9314) },
                    { 637731232, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9275), 968581442, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9276) },
                    { 637731232, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9338), 484946027, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9339) },
                    { 637731232, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9351), 639663781, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9352) },
                    { 637731232, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9364), 477852110, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9365) },
                    { 637731232, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9236), 520634796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9238) },
                    { 637731232, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9224), 872816892, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9225) },
                    { 637731232, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9211), 465977554, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9212) },
                    { 637731232, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9198), 825802227, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9199) },
                    { 637731232, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9249), 252912725, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9250) },
                    { 1311582544, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(571), 992299150, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(573) },
                    { 1311582544, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(547), 532290411, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(549) },
                    { 1311582544, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(452), 774356465, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(454) },
                    { 1311582544, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(407), 973491404, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(409) },
                    { 1311582544, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(370), 512797477, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(372) },
                    { 1311582544, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(326), 646571020, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(328) },
                    { 1311582544, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(429), 597297147, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(431) },
                    { 1311582544, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(347), 558724436, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(349) },
                    { 1311582544, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(475), 969830178, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(477) },
                    { 1311582544, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(498), 224127200, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(500) },
                    { 1311582544, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(522), 220691090, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(524) },
                    { 1311582544, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(282), 346334367, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(284) },
                    { 1311582544, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(261), 787971404, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(262) },
                    { 1311582544, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(237), 914034861, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(239) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1311582544, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(223), 171811641, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(224) },
                    { 1311582544, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(305), 214259330, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(306) },
                    { 1399431840, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1219), 201850601, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1220) },
                    { 1399431840, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1206), 808660414, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1207) },
                    { 1399431840, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1155), 792036327, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1156) },
                    { 1399431840, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1129), 356033442, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1130) },
                    { 1399431840, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1117), 169641302, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1118) },
                    { 1399431840, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1091), 320091043, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1092) },
                    { 1399431840, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1142), 973906882, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1143) },
                    { 1399431840, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1104), 551784352, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1105) },
                    { 1399431840, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1168), 982354732, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1169) },
                    { 1399431840, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1181), 266562423, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1182) },
                    { 1399431840, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1193), 348995149, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1195) },
                    { 1399431840, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1062), 894035996, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1063) },
                    { 1399431840, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1049), 724234655, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1050) },
                    { 1399431840, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1036), 169002787, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1037) },
                    { 1399431840, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1024), 660438055, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1025) },
                    { 1399431840, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1077), 575280669, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1079) },
                    { 1474959440, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9595), 565535433, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9597) },
                    { 1474959440, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9583), 596892248, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9584) },
                    { 1474959440, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9532), 618025830, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9533) },
                    { 1474959440, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9507), 833469000, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9508) },
                    { 1474959440, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9494), 934934515, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9495) },
                    { 1474959440, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9468), 935335600, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9469) },
                    { 1474959440, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9520), 541018864, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9521) },
                    { 1474959440, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9482), 372286273, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9483) },
                    { 1474959440, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9545), 264840275, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9546) },
                    { 1474959440, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9558), 353707210, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9559) },
                    { 1474959440, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9570), 672207641, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9571) },
                    { 1474959440, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9440), 539219199, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9441) },
                    { 1474959440, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9427), 718386359, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9428) },
                    { 1474959440, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9414), 583781317, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9415) },
                    { 1474959440, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9402), 260851037, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9403) },
                    { 1474959440, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9453), 868224608, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(9454) },
                    { 1751555064, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(805), 490383477, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(807) },
                    { 1751555064, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(793), 470265195, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(794) },
                    { 1751555064, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(741), 369121784, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(742) },
                    { 1751555064, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(714), 999808060, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(716) },
                    { 1751555064, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(701), 697419450, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(703) },
                    { 1751555064, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(672), 759431034, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(673) },
                    { 1751555064, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(727), 789917588, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(728) },
                    { 1751555064, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(689), 842163345, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(690) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1751555064, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(754), 556456397, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(755) },
                    { 1751555064, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(767), 451038131, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(768) },
                    { 1751555064, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(780), 211252903, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(781) },
                    { 1751555064, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(646), 483439879, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(647) },
                    { 1751555064, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(633), 432496408, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(634) },
                    { 1751555064, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(619), 589673458, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(620) },
                    { 1751555064, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(593), 952452766, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(595) },
                    { 1751555064, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(659), 289239634, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(660) },
                    { 1927545736, 130054862, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1425), 598019571, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1426) },
                    { 1927545736, 135037539, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1412), 147041384, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1413) },
                    { 1927545736, 272537563, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1361), 143650405, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1362) },
                    { 1927545736, 344445296, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1335), 198752186, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1336) },
                    { 1927545736, 360689923, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1322), 346743795, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1323) },
                    { 1927545736, 401133005, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1297), 268458775, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1298) },
                    { 1927545736, 402491796, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1348), 894869888, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1349) },
                    { 1927545736, 610922851, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1309), 609143542, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1310) },
                    { 1927545736, 616192107, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1374), 427073649, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1375) },
                    { 1927545736, 727973649, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1387), 546262466, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1388) },
                    { 1927545736, 764279183, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1399), 449034380, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1400) },
                    { 1927545736, 788756432, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1271), 351135503, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1272) },
                    { 1927545736, 850333790, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1258), 945837727, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1259) },
                    { 1927545736, 867975792, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1245), 163501406, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1246) },
                    { 1927545736, 955955768, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1232), 489884229, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1233) },
                    { 1927545736, 986932773, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1284), 529767091, new DateTime(2024, 3, 21, 14, 10, 9, 226, DateTimeKind.Local).AddTicks(1285) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124044278, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7730), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7728), -1124969696, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7729), 905097702 },
                    { 125402997, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7743), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7741), 1399431840, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7742), 556107721 },
                    { 182519954, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7815), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7813), 1927545736, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7814), 905097702 },
                    { 228486530, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7387), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7385), 412079096, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7386), 967706797 },
                    { 256796437, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7773), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7770), 1399431840, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7771), 905097702 },
                    { 260776987, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7584), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7581), -1431331256, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7583), 556107721 },
                    { 273105936, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7637), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7634), 1311582544, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7635), 967706797 },
                    { 301139949, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7460), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7458), 1474959440, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7459), 556107721 },
                    { 303226129, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7610), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7608), -1431331256, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7609), 905097702 },
                    { 356518617, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7528), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7525), 608522048, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7526), 905097702 },
                    { 380045881, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7555), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7552), -453324264, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7553), 967706797 },
                    { 392288626, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7690), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7688), 1751555064, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7689), 905097702 },
                    { 422041433, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7360), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7358), -818991168, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7359), 905097702 },
                    { 444494661, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7327), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7324), -818991168, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7325), 556107721 },
                    { 479471018, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7830), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7827), -1454614768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7829), 556107721 },
                    { 484126161, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7514), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7512), 608522048, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7513), 967706797 },
                    { 499806717, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7501), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7499), 608522048, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7500), 556107721 },
                    { 527884432, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7677), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7675), 1751555064, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7676), 967706797 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 541723625, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7597), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7595), -1431331256, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7596), 967706797 },
                    { 550875678, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7623), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7621), 1311582544, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7622), 556107721 },
                    { 577764560, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7474), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7472), 1474959440, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7473), 967706797 },
                    { 592020561, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7650), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7648), 1311582544, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7649), 905097702 },
                    { 605614181, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7488), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7485), 1474959440, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7486), 905097702 },
                    { 605711371, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7717), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7715), -1124969696, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7716), 967706797 },
                    { 609012071, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7664), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7661), 1751555064, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7662), 556107721 },
                    { 623559955, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7757), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7754), 1399431840, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7756), 967706797 },
                    { 655432721, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7845), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7842), -1454614768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7843), 967706797 },
                    { 668309109, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7374), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7371), 412079096, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7372), 556107721 },
                    { 698900157, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7541), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7539), -453324264, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7540), 556107721 },
                    { 721315876, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7402), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7400), 412079096, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7401), 905097702 },
                    { 745017552, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7429), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7427), 637731232, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7428), 967706797 },
                    { 765461557, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7789), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7786), 1927545736, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7787), 556107721 },
                    { 805996803, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7346), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7343), -818991168, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7344), 967706797 },
                    { 877607991, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7416), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7414), 637731232, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7415), 556107721 },
                    { 907436052, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7445), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7443), 637731232, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7444), 905097702 },
                    { 914201520, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7858), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7856), -1454614768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7857), 905097702 },
                    { 928066201, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7802), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7800), 1927545736, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7801), 967706797 },
                    { 940983160, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7704), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7701), -1124969696, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7702), 556107721 },
                    { 970534119, new DateTime(2024, 4, 1, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7570), 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7567), -453324264, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7568), 905097702 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 137856547, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8319), -453324264, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8320), 347881428 },
                    { 146682004, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8208), 608522048, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8209), 408799508 },
                    { 169911477, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8014), 412079096, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8015), 408799508 },
                    { 206960656, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8144), 1474959440, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8145), 408799508 },
                    { 215657485, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8270), -453324264, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8271), 408799508 },
                    { 291794738, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8131), 637731232, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8132), 347881428 },
                    { 313488345, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8395), 1311582544, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8396), 408799508 },
                    { 363166467, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8423), 1311582544, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8424), 879514320 },
                    { 369016519, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8522), -1124969696, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8523), 408799508 },
                    { 408813968, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8307), -453324264, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8308), 697475397 },
                    { 411108565, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8748), -1454614768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8749), 697475397 },
                    { 419558306, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8736), -1454614768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8737), 879514320 },
                    { 442163462, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8670), 1927545736, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8672), 879514320 },
                    { 473263625, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8485), 1751555064, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8486), 879514320 },
                    { 474880054, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8039), 412079096, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8040), 879514320 },
                    { 479567577, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8382), -1431331256, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8383), 347881428 },
                    { 483324805, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8080), 637731232, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8081), 408799508 },
                    { 489643204, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8065), 412079096, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8066), 347881428 },
                    { 493110269, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8608), 1399431840, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8609), 879514320 },
                    { 494221445, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8118), 637731232, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8120), 697475397 },
                    { 495424953, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8435), 1311582544, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8436), 697475397 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 497647960, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8559), -1124969696, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8560), 697475397 },
                    { 498179523, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8571), -1124969696, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8572), 347881428 },
                    { 500225828, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8195), 1474959440, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8196), 347881428 },
                    { 502788415, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8156), 1474959440, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8158), 643289526 },
                    { 517692320, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8356), -1431331256, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8357), 879514320 },
                    { 527125825, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8646), 1927545736, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8647), 408799508 },
                    { 536423486, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8410), 1311582544, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8411), 643289526 },
                    { 536545702, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8620), 1399431840, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8621), 697475397 },
                    { 537555361, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7987), -818991168, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7988), 697475397 },
                    { 545584505, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8051), 412079096, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8052), 697475397 },
                    { 545618222, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8546), -1124969696, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8547), 879514320 },
                    { 551863754, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8183), 1474959440, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8184), 697475397 },
                    { 589370706, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8583), 1399431840, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8584), 408799508 },
                    { 634641165, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8332), -1431331256, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8333), 408799508 },
                    { 645234127, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8633), 1399431840, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8634), 347881428 },
                    { 656717124, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8695), 1927545736, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8696), 347881428 },
                    { 672203920, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8460), 1751555064, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8461), 408799508 },
                    { 687456261, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8093), 637731232, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8094), 643289526 },
                    { 688483598, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7944), -818991168, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7946), 408799508 },
                    { 701119771, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8595), 1399431840, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8597), 643289526 },
                    { 723515233, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8370), -1431331256, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8371), 697475397 },
                    { 726099507, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8344), -1431331256, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8345), 643289526 },
                    { 727182637, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8658), 1927545736, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8659), 643289526 },
                    { 738208323, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8026), 412079096, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8027), 643289526 },
                    { 742469591, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8244), 608522048, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8246), 697475397 },
                    { 775974410, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8257), 608522048, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8258), 347881428 },
                    { 791882460, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8763), -1454614768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8764), 347881428 },
                    { 793330927, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8232), 608522048, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8233), 879514320 },
                    { 797315337, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8000), -818991168, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8001), 347881428 },
                    { 797497466, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8447), 1311582544, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8448), 347881428 },
                    { 829716801, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8683), 1927545736, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8684), 697475397 },
                    { 840140070, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7962), -818991168, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7963), 643289526 },
                    { 851537479, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8294), -453324264, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8295), 879514320 },
                    { 854679890, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8170), 1474959440, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8171), 879514320 },
                    { 855331900, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8472), 1751555064, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8473), 643289526 },
                    { 863903998, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8723), -1454614768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8724), 643289526 },
                    { 870068878, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8509), 1751555064, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8511), 347881428 },
                    { 905086108, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8534), -1124969696, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8535), 643289526 },
                    { 918894292, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8282), -453324264, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8283), 643289526 },
                    { 933426536, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8106), 637731232, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8107), 879514320 },
                    { 957202987, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8709), -1454614768, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8711), 408799508 },
                    { 972885477, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8220), 608522048, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8221), 643289526 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[] { 974191543, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7975), -818991168, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(7976), 879514320 });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[] { 975514559, 0f, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8497), 1751555064, new DateTime(2024, 3, 21, 14, 10, 9, 225, DateTimeKind.Local).AddTicks(8498), 697475397 });

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
