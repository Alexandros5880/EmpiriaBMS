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
                    PaymentDetailes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayCost = table.Column<double>(type: "float", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidFee = table.Column<double>(type: "float", nullable: true),
                    DaysUntilPayment = table.Column<int>(type: "int", nullable: true),
                    PendingPayments = table.Column<double>(type: "float", nullable: true),
                    CalculationDaly = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: true),
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
                name: "Complains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
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
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false),
                    PMSignature = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complains_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complains_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complains_Users_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ProjectsPmanagers",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsPmanagers", x => new { x.ProjectManagerId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectsPmanagers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsPmanagers_Users_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
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
                    { 166356098, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(91), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(92), "BMS" },
                    { 205673014, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(151), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(152), "Construction Supervision" },
                    { 209440484, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(137), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(138), "TenderDocument" },
                    { 259860886, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(126), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(127), "Outsource" },
                    { 267789909, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9957), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9959), "Sewage" },
                    { 297377336, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(8), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(9), "Fire Suppression" },
                    { 342518393, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(68), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(69), "Burglar Alarm" },
                    { 392898696, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(43), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(44), "Power Distribution" },
                    { 414892703, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9937), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9938), "HVAC" },
                    { 424748923, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(79), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(80), "CCTV" },
                    { 500149738, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9970), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9971), "Potable Water" },
                    { 509551362, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(114), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(115), "Energy Efficiency" },
                    { 516718800, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(56), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(57), "Structured Cabling" },
                    { 587994589, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(163), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(164), "Project Manager Hours" },
                    { 644763374, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(102), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(103), "Photovoltaics" },
                    { 670642391, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9982), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9983), "Drainage" },
                    { 788014219, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(20), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(21), "Elevators" },
                    { 877622036, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9995), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9996), "Fire Detection" },
                    { 982478832, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(32), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(33), "Natural Gas" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 294095324, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(386), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(387), "Documents" },
                    { 474962244, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(419), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(420), "Drawings" },
                    { 838861407, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(406), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(408), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 175775220, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1093), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1094), "Meetings" },
                    { 177314930, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1042), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1043), "Communications" },
                    { 299726238, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1067), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1068), "Printing" },
                    { 430969363, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1106), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1108), "Administration" },
                    { 840816154, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1080), new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1081), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 132633226, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6114), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6115), "Dashboard Assign Engineer", 4 },
                    { 182904847, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6156), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6157), "See Admin Layout", 7 },
                    { 189748193, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6099), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6100), "Dashboard Assign Designer", 3 },
                    { 219157683, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6183), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6184), "See All Disciplines", 9 },
                    { 400864088, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6128), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6129), "Dashboard Assign Project Manager", 5 },
                    { 670138102, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6143), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6144), "Dashboard Add Project", 6 },
                    { 754843601, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6082), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6084), "Dashboard Edit My Hours", 2 },
                    { 828410460, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6197), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6199), "See All Drawings", 10 },
                    { 866547428, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6170), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6171), "Dashboard See My Hours", 8 },
                    { 907883105, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(5814), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(5816), "See Dashboard Layout", 1 },
                    { 933589591, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6220), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6222), "See All Projects", 11 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 319449039, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9477), "Energy Description", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9478), "Energy" },
                    { 350433176, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9463), "Infrastructure Description", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9464), "Infrastructure" },
                    { 355045691, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9441), "Buildings Description", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9443), "Buildings" },
                    { 487688457, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9490), "Consulting Description", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9492), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { 848968860, false, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9504), "Production Management Description", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9505), "Production Management" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 147912577, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6243), false, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6245), "Designer" },
                    { 158159581, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6429), false, false, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6431), "Admin" },
                    { 204432894, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6410), false, false, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6412), "Customer" },
                    { 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6319), false, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6321), "COO" },
                    { 461311853, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6275), false, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6277), "Engineer" },
                    { 603025118, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6390), false, false, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6392), "Guest" },
                    { 652890913, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6297), false, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6299), "Project Manager" },
                    { 717013726, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6343), false, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6345), "CTO" },
                    { 855592790, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6455), false, false, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6456), "Secretariat" },
                    { 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6368), false, true, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6370), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9214), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9215), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9361), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9362), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 249085152, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8639), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8641), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 262468560, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8374), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8376), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8759), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8761), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9090), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9092), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9278), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9279), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 437325885, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7943), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7945), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 457932177, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7803), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7805), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8953), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8954), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8881), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8882), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 547798198, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8157), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8159), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9050), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9051), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8710), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8712), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 666802108, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8559), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8561), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8799), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8801), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9321), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9322), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 748418353, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8475), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8477), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 756307908, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8015), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8017), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9401), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9402), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 812498810, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7704), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7706), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9173), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9174), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9008), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9009), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9133), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9134), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8840), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8841), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 983272617, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8083), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8085), null, "694927778", null, null, null, "guest@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 150417184, "xmanarolis@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8773), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8774), 290317956 },
                    { 174300832, "blekou@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9295), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9296), 405801477 },
                    { 225519474, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8588), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8590), 666802108 },
                    { 250021950, "chkovras@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8854), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8856), 949564203 },
                    { 270549343, "vpax@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8733), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8734), 658884672 },
                    { 297330984, "coo@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8039), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8041), 756307908 },
                    { 328634009, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7740), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7742), 812498810 },
                    { 367844949, "kkotsoni@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8968), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8969), 466515598 },
                    { 368387992, "embiria@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8402), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8404), 262468560 },
                    { 424926023, "ngal@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8896), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8897), 473058381 },
                    { 432058181, "cto@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7968), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7970), 437325885 },
                    { 432897886, "kmargeti@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9106), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9107), 365544049 },
                    { 470927475, "vtza@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9023), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9024), 884454194 },
                    { 485545672, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8664), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8667), 249085152 },
                    { 509545287, "agretos@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9064), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9065), 630729034 },
                    { 575306302, "panperivollari@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9375), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9376), 174815498 },
                    { 599909230, "ceo@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7826), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7827), 457932177 },
                    { 600675801, "vchontos@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9335), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9336), 726181736 },
                    { 624243066, "gdoug@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8504), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8506), 748418353 },
                    { 644951800, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9227), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9229), 171518101 },
                    { 668591345, "haris@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9147), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9148), 893467045 },
                    { 785585589, "guest@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8108), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8109), 983272617 },
                    { 796456000, "pfokianou@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9187), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9189), 851571892 },
                    { 881417048, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9415), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9416), 798063879 },
                    { 891469424, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8426), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8428), 262468560 },
                    { 904058433, "sparisis@embiria.gr", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8813), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8814), 691766384 },
                    { 994813444, "pm@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8184), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8186), 547798198 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 161801357, false, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 6.0, 1, new DateTime(2024, 4, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 1, "Test Description Project_1", new DateTime(2024, 4, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), new DateTime(2024, 4, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Project_1", 5.0, new DateTime(2024, 4, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Payment Detailes For Project_3", 1.0, null, 355045691, new DateTime(2024, 4, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f },
                    { 183544312, true, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 9.0, 16, new DateTime(2025, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 16, "Test Description Project_16", new DateTime(2025, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), new DateTime(2025, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Project_4", 5.0, new DateTime(2025, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Payment Detailes For Project_24", 4.0, null, 487688457, new DateTime(2025, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f },
                    { 301079669, true, "ALPHA", 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 111.0, 90, new DateTime(2024, 6, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 1, "Test Description Project_PM", new DateTime(2024, 4, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), new DateTime(2024, 5, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Project_PM", 45.0, new DateTime(2024, 4, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Payment Detailes For Project_PM", 2.0, null, 848968860, new DateTime(2024, 5, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f },
                    { 686805165, true, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 7.0, 4, new DateTime(2024, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 4, "Test Description Project_10", new DateTime(2024, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), new DateTime(2024, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Project_2", 5.0, new DateTime(2024, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Payment Detailes For Project_12", 2.0, null, 350433176, new DateTime(2024, 7, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f },
                    { 936648049, false, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 8.0, 9, new DateTime(2024, 12, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 9, "Test Description Project_9", new DateTime(2024, 12, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), new DateTime(2024, 12, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Project_3", 5.0, new DateTime(2024, 12, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), "Payment Detailes For Project_15", 3.0, null, 319449039, new DateTime(2024, 12, 14, 15, 31, 24, 905, DateTimeKind.Local).AddTicks(1989), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 754843601, 147912577, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6509), -1734720754, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6511) },
                    { 866547428, 147912577, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6531), -508485473, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6533) },
                    { 907883105, 147912577, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6475), -1182771112, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6476) },
                    { 182904847, 158159581, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7490), -1966815157, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7492) },
                    { 219157683, 158159581, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7510), -591049804, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7512) },
                    { 828410460, 158159581, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7531), -1256107724, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7532) },
                    { 933589591, 158159581, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7551), -134050513, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7553) },
                    { 907883105, 204432894, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7462), 1412264525, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7464) },
                    { 132633226, 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6917), -1496665318, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6919) },
                    { 189748193, 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6897), -2006753723, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6899) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 219157683, 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6980), -795934102, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6982) },
                    { 400864088, 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6938), 385427143, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6940) },
                    { 754843601, 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6874), 1717008822, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6876) },
                    { 828410460, 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7002), -1993006709, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7004) },
                    { 866547428, 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6959), -1170189782, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6961) },
                    { 907883105, 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6853), -2103869240, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6855) },
                    { 933589591, 436932997, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7022), -623779798, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7024) },
                    { 189748193, 461311853, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6597), 343720693, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6599) },
                    { 219157683, 461311853, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6640), 674304998, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6641) },
                    { 754843601, 461311853, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6575), 1448173125, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6577) },
                    { 828410460, 461311853, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6663), -1834291511, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6665) },
                    { 866547428, 461311853, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6618), 165049781, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6619) },
                    { 907883105, 461311853, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6554), 1538372057, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6555) },
                    { 907883105, 603025118, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7441), 95364847, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7442) },
                    { 132633226, 652890913, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6767), -2126683403, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6769) },
                    { 219157683, 652890913, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6810), -707359697, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6812) },
                    { 754843601, 652890913, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6746), -1421477122, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6748) },
                    { 828410460, 652890913, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6830), 2117195150, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6833) },
                    { 866547428, 652890913, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6788), -164551261, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6790) },
                    { 907883105, 652890913, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6725), -1516590035, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(6727) },
                    { 219157683, 717013726, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7155), -1376622427, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7157) },
                    { 400864088, 717013726, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7089), 1504319436, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7090) },
                    { 670138102, 717013726, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7114), -1087831295, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7116) },
                    { 754843601, 717013726, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7066), 33297620, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7068) },
                    { 828410460, 717013726, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7177), 49785391, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7179) },
                    { 866547428, 717013726, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7135), -135965164, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7137) },
                    { 907883105, 717013726, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7044), -1022187721, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7046) },
                    { 933589591, 717013726, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7200), -1076265098, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7202) },
                    { 219157683, 855592790, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7638), -485747387, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7640) },
                    { 754843601, 855592790, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7593), -1938395735, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7595) },
                    { 828410460, 855592790, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7661), -205203469, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7662) },
                    { 866547428, 855592790, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7616), 1612322807, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7618) },
                    { 907883105, 855592790, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7572), 2090586056, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7573) },
                    { 933589591, 855592790, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7682), 2039641641, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7684) },
                    { 132633226, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7286), -980306932, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7288) },
                    { 182904847, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7351), 331365142, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7353) },
                    { 189748193, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7264), 1339788753, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7266) },
                    { 219157683, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7372), -1756107310, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7374) },
                    { 400864088, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7307), -1984984901, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7309) },
                    { 670138102, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7329), 692041757, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7331) },
                    { 754843601, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7243), -1420488737, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7245) },
                    { 828410460, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7396), 1709215020, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7399) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 907883105, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7221), -978800764, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7223) },
                    { 933589591, 957012329, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7419), 1336786304, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7421) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 461311853, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9264), 411034459, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9266) },
                    { 461311853, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9387), 288666308, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9388) },
                    { 147912577, 249085152, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8686), 408574316, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8688) },
                    { 855592790, 262468560, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8449), 461948199, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8451) },
                    { 461311853, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8786), 836321594, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8787) },
                    { 461311853, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9118), 234112386, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9119) },
                    { 461311853, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9308), 381654545, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9309) },
                    { 717013726, 437325885, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7992), 327511836, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7994) },
                    { 957012329, 457932177, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7844), 580164892, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7846) },
                    { 436932997, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8995), 967907656, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8996) },
                    { 461311853, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8981), 797005791, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8982) },
                    { 652890913, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9534), 73328270, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9535) },
                    { 158159581, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8922), 252871873, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8923) },
                    { 461311853, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8908), 884269402, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8910) },
                    { 957012329, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8935), 410144029, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8937) },
                    { 652890913, 547798198, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8209), 495324543, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8210) },
                    { 461311853, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9077), 696770583, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9078) },
                    { 461311853, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8746), 176311896, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8747) },
                    { 652890913, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9519), 236978342, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9520) },
                    { 147912577, 666802108, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8612), 349222215, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8615) },
                    { 461311853, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8826), 262233385, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8827) },
                    { 461311853, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9347), 232524804, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9349) },
                    { 147912577, 748418353, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8529), 411312150, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8531) },
                    { 436932997, 756307908, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8060), 425075338, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8062) },
                    { 461311853, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9427), 652440437, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9428) },
                    { 158159581, 812498810, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7775), 377517736, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(7777) },
                    { 461311853, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9200), 828214486, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9202) },
                    { 461311853, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9037), 824211548, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9038) },
                    { 461311853, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9159), 897307257, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9160) },
                    { 652890913, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9547), 219984737, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9549) },
                    { 461311853, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8867), 886284582, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8869) },
                    { 603025118, 983272617, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8132), 750528506, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(8134) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1621753040, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(192), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(193), 161801357, 670642391, null },
                    { -1612418368, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(217), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(218), 161801357, 788014219, null },
                    { -1510108976, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(230), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(232), 161801357, 877622036, null },
                    { -1481914472, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(315), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(316), 936648049, 209440484, null },
                    { -1248346040, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(370), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(371), 301079669, 587994589, null },
                    { -1213272368, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(344), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(345), 183544312, 424748923, null },
                    { -1062108536, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(260), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(261), 686805165, 342518393, null },
                    { 1127297120, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(301), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(303), 936648049, 788014219, null },
                    { 1181755912, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(247), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(248), 686805165, 500149738, null },
                    { 1633465952, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(357), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(358), 183544312, 297377336, null },
                    { 1692513768, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(288), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(289), 936648049, 392898696, null },
                    { 1798425144, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(330), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(331), 183544312, 259860886, null },
                    { 1897805328, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(275), 0f, 500L, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(276), 686805165, 414892703, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 198085605, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9755), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9758), 3100.0, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9757), "Signature 1423412", 47495, 686805165, 2.0, 24.0 },
                    { 418174154, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9828), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9831), 4000.0, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9830), "Signature 142346", 18459, 936648049, 3.0, 17.0 },
                    { 499142311, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9673), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9675), 3010.0, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9674), "Signature 142345", 40746, 161801357, 1.0, 17.0 },
                    { 726601729, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9898), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9900), 13000.0, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9899), "Signature 1423416", 63783, 183544312, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 686805165, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2106), 713388792, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2107) },
                    { 161801357, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2086), 334733712, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2088) },
                    { 183544312, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2132), 914452739, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2133) },
                    { 936648049, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2119), 529322374, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2120) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 574039617, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9718), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9719), null, "6949277782", null, null, 686805165, "alexpl_{i}@gmail.com" },
                    { 710530323, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9625), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9626), null, "6949277781", null, null, 161801357, "alexpl_{i}@gmail.com" },
                    { 728304182, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9790), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9792), null, "6949277783", null, null, 936648049, "alexpl_{i}@gmail.com" },
                    { 863013865, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9861), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9862), null, "6949277784", null, null, 183544312, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1621753040, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2300), 958842617, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2301) },
                    { -1621753040, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2339), 742217531, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2340) },
                    { -1621753040, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2166), 607980230, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2167) },
                    { -1621753040, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2260), 996925070, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2261) },
                    { -1621753040, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2313), 723633336, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2314) },
                    { -1621753040, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2220), 930403813, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2221) },
                    { -1621753040, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2206), 932371754, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2207) },
                    { -1621753040, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2246), 910812779, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2248) },
                    { -1621753040, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2146), 845142758, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2147) },
                    { -1621753040, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2179), 230180079, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2181) },
                    { -1621753040, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2326), 697026969, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2327) },
                    { -1621753040, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2352), 856394653, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2353) },
                    { -1621753040, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2287), 649260899, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2288) },
                    { -1621753040, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2233), 589747940, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2234) },
                    { -1621753040, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2273), 318734964, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2275) },
                    { -1621753040, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2193), 150787698, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2194) },
                    { -1612418368, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2514), 676638220, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2515) },
                    { -1612418368, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2553), 637010074, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2555) },
                    { -1612418368, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2380), 931457626, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2381) },
                    { -1612418368, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2474), 854679197, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2475) },
                    { -1612418368, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2527), 569240393, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2528) },
                    { -1612418368, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2432), 343178014, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2433) },
                    { -1612418368, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2419), 494064608, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2420) },
                    { -1612418368, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2461), 917830971, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2462) },
                    { -1612418368, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2365), 718345387, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2367) },
                    { -1612418368, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2393), 266236162, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2394) },
                    { -1612418368, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2541), 965926283, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2542) },
                    { -1612418368, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2566), 141471079, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2568) },
                    { -1612418368, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2500), 731378581, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2501) },
                    { -1612418368, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2448), 937028618, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2449) },
                    { -1612418368, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2487), 564506702, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2489) },
                    { -1612418368, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2406), 866497439, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2407) },
                    { -1510108976, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2724), 997940883, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2726) },
                    { -1510108976, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2764), 150440871, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2765) },
                    { -1510108976, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2594), 735499675, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2595) },
                    { -1510108976, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2685), 528317723, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2687) },
                    { -1510108976, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2737), 585729905, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2739) },
                    { -1510108976, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2646), 363968709, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2648) },
                    { -1510108976, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2633), 608673445, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2635) },
                    { -1510108976, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2672), 462933874, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2673) },
                    { -1510108976, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2580), 989463997, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2581) },
                    { -1510108976, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2607), 772732097, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2609) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1510108976, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2750), 490439180, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2751) },
                    { -1510108976, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2777), 244839359, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2778) },
                    { -1510108976, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2711), 460537711, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2713) },
                    { -1510108976, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2659), 953770849, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2661) },
                    { -1510108976, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2698), 322802681, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2700) },
                    { -1510108976, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2620), 166842079, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2622) },
                    { -1481914472, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3918), 973883779, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3919) },
                    { -1481914472, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3955), 551766917, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3956) },
                    { -1481914472, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3793), 673093120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3794) },
                    { -1481914472, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3881), 582298971, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3882) },
                    { -1481914472, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3930), 881511391, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3931) },
                    { -1481914472, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3845), 680694832, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3846) },
                    { -1481914472, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3833), 830403755, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3834) },
                    { -1481914472, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3869), 328716639, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3870) },
                    { -1481914472, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3780), 225569231, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3781) },
                    { -1481914472, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3805), 983942939, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3806) },
                    { -1481914472, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3943), 577065920, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3944) },
                    { -1481914472, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3967), 585847667, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3968) },
                    { -1481914472, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3906), 903163513, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3907) },
                    { -1481914472, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3857), 238790523, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3858) },
                    { -1481914472, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3894), 303362121, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3895) },
                    { -1481914472, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3818), 837870773, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3819) },
                    { -1213272368, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4359), 924918270, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4360) },
                    { -1213272368, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4395), 430537386, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4396) },
                    { -1213272368, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4233), 876815487, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4235) },
                    { -1213272368, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4322), 879962605, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4323) },
                    { -1213272368, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4371), 732591734, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4372) },
                    { -1213272368, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4285), 777689220, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4287) },
                    { -1213272368, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4273), 681859735, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4274) },
                    { -1213272368, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4310), 186563766, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4311) },
                    { -1213272368, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4221), 647248101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4222) },
                    { -1213272368, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4246), 453283178, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4247) },
                    { -1213272368, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4383), 812645614, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4384) },
                    { -1213272368, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4408), 722190346, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4409) },
                    { -1213272368, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4347), 744792736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4348) },
                    { -1213272368, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4298), 550651054, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4299) },
                    { -1213272368, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4334), 288889291, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4336) },
                    { -1213272368, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4261), 442410941, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4262) },
                    { -1062108536, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3126), 753585699, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3127) },
                    { -1062108536, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3165), 729798653, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3166) },
                    { -1062108536, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3005), 186088896, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3006) },
                    { -1062108536, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3090), 859261770, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3091) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1062108536, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3138), 353730898, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3139) },
                    { -1062108536, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3054), 307649879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3055) },
                    { -1062108536, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3041), 715326972, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3042) },
                    { -1062108536, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3077), 803357567, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3079) },
                    { -1062108536, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2992), 896291721, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2993) },
                    { -1062108536, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3017), 985846082, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3018) },
                    { -1062108536, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3150), 825718191, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3151) },
                    { -1062108536, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3177), 365892377, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3178) },
                    { -1062108536, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3114), 440957514, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3115) },
                    { -1062108536, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3065), 927508661, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3067) },
                    { -1062108536, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3102), 718356898, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3103) },
                    { -1062108536, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3029), 622367770, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3030) },
                    { 1127297120, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3718), 238171433, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3719) },
                    { 1127297120, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3755), 214076910, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3756) },
                    { 1127297120, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3595), 853684245, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3596) },
                    { 1127297120, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3681), 796701862, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3682) },
                    { 1127297120, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3730), 774132895, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3731) },
                    { 1127297120, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3644), 743403587, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3645) },
                    { 1127297120, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3632), 940824523, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3633) },
                    { 1127297120, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3669), 461306135, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3670) },
                    { 1127297120, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3583), 530830027, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3584) },
                    { 1127297120, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3607), 847669533, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3609) },
                    { 1127297120, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3743), 743953805, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3744) },
                    { 1127297120, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3767), 585185687, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3768) },
                    { 1127297120, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3705), 564634619, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3706) },
                    { 1127297120, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3656), 353344646, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3657) },
                    { 1127297120, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3693), 964330251, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3694) },
                    { 1127297120, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3619), 972570578, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3621) },
                    { 1181755912, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2931), 149031259, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2932) },
                    { 1181755912, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2967), 622816559, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2969) },
                    { 1181755912, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2803), 920955160, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2804) },
                    { 1181755912, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2895), 151455566, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2896) },
                    { 1181755912, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2943), 366552934, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2944) },
                    { 1181755912, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2858), 742230239, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2860) },
                    { 1181755912, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2845), 409277115, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2846) },
                    { 1181755912, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2883), 911078099, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2884) },
                    { 1181755912, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2790), 756956609, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2791) },
                    { 1181755912, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2816), 300725746, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2817) },
                    { 1181755912, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2955), 851210643, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2957) },
                    { 1181755912, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2979), 449397120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2981) },
                    { 1181755912, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2919), 814125136, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2920) },
                    { 1181755912, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2871), 699636981, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2872) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1181755912, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2907), 132350958, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2908) },
                    { 1181755912, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2832), 973921896, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2833) },
                    { 1633465952, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4555), 537458723, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4556) },
                    { 1633465952, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4592), 844578870, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4593) },
                    { 1633465952, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4433), 371160325, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4434) },
                    { 1633465952, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4518), 636988318, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4519) },
                    { 1633465952, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4567), 143754130, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4568) },
                    { 1633465952, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4482), 663142768, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4483) },
                    { 1633465952, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4470), 618330644, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4471) },
                    { 1633465952, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4506), 248542573, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4507) },
                    { 1633465952, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4420), 249196011, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4421) },
                    { 1633465952, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4445), 157449397, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4446) },
                    { 1633465952, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4580), 360457209, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4581) },
                    { 1633465952, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4605), 697729212, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4606) },
                    { 1633465952, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4543), 887900886, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4544) },
                    { 1633465952, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4494), 127780717, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4495) },
                    { 1633465952, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4531), 523710856, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4532) },
                    { 1633465952, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4457), 355494624, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4458) },
                    { 1692513768, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3518), 508481514, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3519) },
                    { 1692513768, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3558), 616219298, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3559) },
                    { 1692513768, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3397), 830545811, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3398) },
                    { 1692513768, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3482), 469331451, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3483) },
                    { 1692513768, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3531), 793118598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3532) },
                    { 1692513768, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3445), 255224835, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3447) },
                    { 1692513768, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3433), 401833276, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3434) },
                    { 1692513768, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3470), 716192774, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3471) },
                    { 1692513768, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3385), 480894576, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3386) },
                    { 1692513768, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3409), 623357120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3410) },
                    { 1692513768, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3546), 963964533, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3547) },
                    { 1692513768, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3570), 349112798, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3572) },
                    { 1692513768, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3506), 143915397, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3507) },
                    { 1692513768, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3458), 532948174, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3459) },
                    { 1692513768, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3494), 223340571, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3495) },
                    { 1692513768, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3421), 158238737, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3422) },
                    { 1798425144, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4160), 534609762, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4161) },
                    { 1798425144, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4196), 708311423, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4197) },
                    { 1798425144, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4033), 275596783, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4035) },
                    { 1798425144, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4123), 864367078, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4124) },
                    { 1798425144, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4172), 715542884, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4173) },
                    { 1798425144, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4085), 265398911, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4086) },
                    { 1798425144, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4073), 198108298, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4074) },
                    { 1798425144, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4110), 216916031, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4111) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1798425144, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3979), 618922008, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3980) },
                    { 1798425144, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4048), 367871486, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4049) },
                    { 1798425144, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4184), 170239599, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4185) },
                    { 1798425144, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4208), 690971739, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4210) },
                    { 1798425144, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4147), 137902196, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4148) },
                    { 1798425144, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4098), 889203968, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4099) },
                    { 1798425144, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4135), 613563064, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4136) },
                    { 1798425144, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4060), 217763648, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(4061) },
                    { 1897805328, 171518101, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3324), 745854465, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3325) },
                    { 1897805328, 174815498, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3360), 173397616, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3361) },
                    { 1897805328, 290317956, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3202), 284295619, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3203) },
                    { 1897805328, 365544049, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3287), 710000202, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3288) },
                    { 1897805328, 405801477, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3336), 832685428, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3337) },
                    { 1897805328, 466515598, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3251), 972692587, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3252) },
                    { 1897805328, 473058381, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3239), 362178737, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3240) },
                    { 1897805328, 630729034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3275), 658348799, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3276) },
                    { 1897805328, 658884672, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3190), 737289518, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3191) },
                    { 1897805328, 691766384, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3214), 758035000, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3216) },
                    { 1897805328, 726181736, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3348), 806761335, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3349) },
                    { 1897805328, 798063879, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3372), 718438034, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3373) },
                    { 1897805328, 851571892, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3312), 640203972, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3313) },
                    { 1897805328, 884454194, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3263), 556074112, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3264) },
                    { 1897805328, 893467045, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3300), 631349514, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3301) },
                    { 1897805328, 949564203, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3227), 289182165, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(3228) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 137176510, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(880), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(878), -1213272368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(879), 474962244 },
                    { 164986174, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(612), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(609), -1062108536, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(610), 294095324 },
                    { 206558076, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(436), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(432), -1621753040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(433), 294095324 },
                    { 227162584, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(707), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(705), 1692513768, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(706), 838861407 },
                    { 229798298, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(994), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(937), -1248346040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(992), 294095324 },
                    { 231732723, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(720), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(718), 1692513768, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(719), 474962244 },
                    { 238950569, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(925), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(922), 1633465952, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(924), 474962244 },
                    { 271669251, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(638), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(636), -1062108536, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(637), 474962244 },
                    { 273366876, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(539), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(537), -1510108976, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(538), 838861407 },
                    { 295339405, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(813), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(811), 1798425144, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(812), 294095324 },
                    { 321828479, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(497), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(494), -1612418368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(496), 838861407 },
                    { 339300652, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(680), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(678), 1897805328, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(679), 474962244 },
                    { 353276846, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(665), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(663), 1897805328, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(664), 838861407 },
                    { 356533088, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(912), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(909), 1633465952, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(910), 838861407 },
                    { 358592087, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(787), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(784), -1481914472, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(785), 838861407 },
                    { 376303520, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(585), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(582), 1181755912, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(583), 838861407 },
                    { 402366509, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(827), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(825), 1798425144, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(826), 838861407 },
                    { 404934256, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(512), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(510), -1612418368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(511), 474962244 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 524522018, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(571), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(569), 1181755912, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(570), 294095324 },
                    { 558846986, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(773), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(771), -1481914472, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(772), 294095324 },
                    { 565604527, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(598), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(596), 1181755912, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(597), 474962244 },
                    { 569384850, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(455), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(453), -1621753040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(454), 838861407 },
                    { 574603334, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(867), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(864), -1213272368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(865), 838861407 },
                    { 582440475, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(760), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(758), 1127297120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(759), 474962244 },
                    { 583015771, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(747), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(745), 1127297120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(746), 838861407 },
                    { 667609120, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(526), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(524), -1510108976, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(525), 294095324 },
                    { 684161583, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1012), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1009), -1248346040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1011), 838861407 },
                    { 700807646, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(625), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(622), -1062108536, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(623), 838861407 },
                    { 718813232, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(694), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(691), 1692513768, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(692), 294095324 },
                    { 758239224, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(734), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(731), 1127297120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(733), 294095324 },
                    { 814987761, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(898), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(896), 1633465952, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(897), 294095324 },
                    { 817436585, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(483), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(480), -1612418368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(481), 294095324 },
                    { 834131998, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1027), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1024), -1248346040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1026), 474962244 },
                    { 855444875, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(652), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(649), 1897805328, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(651), 294095324 },
                    { 915937883, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(840), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(838), 1798425144, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(839), 474962244 },
                    { 927876222, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(469), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(467), -1621753040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(468), 474962244 },
                    { 948078285, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(800), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(798), -1481914472, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(799), 474962244 },
                    { 949621300, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(853), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(851), -1213272368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(852), 294095324 },
                    { 994228343, new DateTime(2024, 3, 25, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(553), 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(550), -1510108976, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(552), 474962244 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 129863514, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9804), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9805), 728304182 },
                    { 258049613, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9874), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9875), 863013865 },
                    { 294750905, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9732), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9733), 574039617 },
                    { 603374847, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9642), new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9644), 710530323 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 131903644, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1426), 1181755912, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1429), 430969363 },
                    { 143849303, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1512), -1062108536, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1513), 175775220 },
                    { 150070544, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1251), -1612418368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1253), 430969363 },
                    { 176818351, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1705), 1692513768, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1706), 430969363 },
                    { 184691830, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1548), 1897805328, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1549), 299726238 },
                    { 193355391, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1536), 1897805328, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1537), 177314930 },
                    { 226545147, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1378), 1181755912, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1380), 840816154 },
                    { 241901241, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1145), -1621753040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1146), 299726238 },
                    { 264258935, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1994), 1633465952, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1995), 175775220 },
                    { 272127472, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1982), 1633465952, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1983), 840816154 },
                    { 289127390, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1923), -1213272368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1924), 840816154 },
                    { 296848984, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1852), 1798425144, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1853), 299726238 },
                    { 303550359, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1524), -1062108536, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1525), 430969363 },
                    { 358231518, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1171), -1621753040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1173), 175775220 },
                    { 371160847, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1225), -1612418368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1226), 840816154 },
                    { 376693461, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1238), -1612418368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1239), 175775220 },
                    { 380519238, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1495), -1062108536, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1497), 840816154 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 396366179, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1970), 1633465952, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1971), 299726238 },
                    { 410835285, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1184), -1621753040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1186), 430969363 },
                    { 413648106, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1693), 1692513768, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1694), 175775220 },
                    { 414166602, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1828), -1481914472, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1829), 430969363 },
                    { 417284588, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1958), 1633465952, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1960), 177314930 },
                    { 435530446, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1816), -1481914472, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1817), 175775220 },
                    { 438146094, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1840), 1798425144, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1841), 177314930 },
                    { 463181600, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1320), -1510108976, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1321), 430969363 },
                    { 473126531, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1911), -1213272368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1912), 299726238 },
                    { 479276645, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2069), -1248346040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2070), 430969363 },
                    { 479589288, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1717), 1127297120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1718), 177314930 },
                    { 489752605, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1124), -1621753040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1125), 177314930 },
                    { 517545423, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1781), -1481914472, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1782), 177314930 },
                    { 525281851, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1158), -1621753040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1160), 840816154 },
                    { 530857423, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1805), -1481914472, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1806), 840816154 },
                    { 531485245, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1793), -1481914472, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1794), 299726238 },
                    { 545811287, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1757), 1127297120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1758), 175775220 },
                    { 556983251, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1212), -1612418368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1213), 299726238 },
                    { 560020248, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1864), 1798425144, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1865), 840816154 },
                    { 567896902, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1475), -1062108536, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1477), 299726238 },
                    { 587352880, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1290), -1510108976, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1292), 840816154 },
                    { 599495613, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1564), 1897805328, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1566), 840816154 },
                    { 609427643, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1278), -1510108976, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1279), 299726238 },
                    { 625316918, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1653), 1692513768, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1655), 299726238 },
                    { 635886489, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1947), -1213272368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1948), 430969363 },
                    { 644837579, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2057), -1248346040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2058), 175775220 },
                    { 647675180, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2006), 1633465952, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2007), 430969363 },
                    { 666338054, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1630), 1692513768, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1632), 177314930 },
                    { 680577300, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1307), -1510108976, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1308), 175775220 },
                    { 687414618, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2019), -1248346040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2020), 177314930 },
                    { 718935068, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1935), -1213272368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1936), 175775220 },
                    { 722172544, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1899), -1213272368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1900), 177314930 },
                    { 748125518, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1451), -1062108536, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1453), 177314930 },
                    { 754484766, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2045), -1248346040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2046), 840816154 },
                    { 774555851, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1265), -1510108976, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1266), 177314930 },
                    { 831419671, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1875), 1798425144, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1876), 175775220 },
                    { 832401362, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1742), 1127297120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1743), 840816154 },
                    { 858121553, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1401), 1181755912, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1404), 175775220 },
                    { 858970245, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1354), 1181755912, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1357), 299726238 },
                    { 880076382, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1585), 1897805328, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1587), 175775220 },
                    { 882479883, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1887), 1798425144, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1888), 430969363 },
                    { 894404305, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1607), 1897805328, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1608), 430969363 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 899115617, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1729), 1127297120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1730), 299726238 },
                    { 929421678, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2033), -1248346040, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(2034), 299726238 },
                    { 935105457, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1769), 1127297120, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1770), 430969363 },
                    { 940716434, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1333), 1181755912, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1335), 177314930 },
                    { 964337739, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1199), -1612418368, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1200), 177314930 },
                    { 987369263, 0f, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1677), 1692513768, new DateTime(2024, 3, 14, 15, 31, 24, 920, DateTimeKind.Local).AddTicks(1678), 840816154 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 204432894, 574039617, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9743), 625243096, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9744) },
                    { 204432894, 710530323, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9655), 538030115, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9656) },
                    { 204432894, 728304182, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9816), 450534235, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9817) },
                    { 204432894, 863013865, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9886), 733153053, new DateTime(2024, 3, 14, 15, 31, 24, 919, DateTimeKind.Local).AddTicks(9887) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complains_CustomerId",
                table: "Complains",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Complains_ProjectId",
                table: "Complains",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Complains_ProjectManagerId",
                table: "Complains",
                column: "ProjectManagerId");

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
                name: "IX_Projects_SubContractorId",
                table: "Projects",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TypeId",
                table: "Projects",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsPmanagers_ProjectId",
                table: "ProjectsPmanagers",
                column: "ProjectId");

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
                name: "FK_Projects_Users_SubContractorId",
                table: "Projects",
                column: "SubContractorId",
                principalTable: "Users",
                principalColumn: "Id");
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
                name: "ProjectsPmanagers");

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
