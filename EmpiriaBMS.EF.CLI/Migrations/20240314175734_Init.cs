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
                    IsClose = table.Column<bool>(type: "bit", nullable: false),
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
                    { 187642174, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3883), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3884), "Photovoltaics" },
                    { 229148182, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3859), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3860), "CCTV" },
                    { 301115277, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3782), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3783), "Fire Suppression" },
                    { 354156439, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3947), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3948), "Project Manager Hours" },
                    { 414382028, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3920), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3921), "TenderDocument" },
                    { 425820782, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3740), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3741), "Potable Water" },
                    { 438054161, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3820), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3821), "Power Distribution" },
                    { 526752918, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3766), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3767), "Fire Detection" },
                    { 530947974, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3753), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3754), "Drainage" },
                    { 532168767, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3808), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3809), "Natural Gas" },
                    { 584773765, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3895), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3896), "Energy Efficiency" },
                    { 653446481, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3847), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3848), "Burglar Alarm" },
                    { 774583258, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3706), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3707), "HVAC" },
                    { 775358922, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3934), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3935), "Construction Supervision" },
                    { 806950646, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3871), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3872), "BMS" },
                    { 873610050, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3795), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3796), "Elevators" },
                    { 924701775, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3833), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3835), "Structured Cabling" },
                    { 963369882, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3907), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3908), "Outsource" },
                    { 997266258, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3727), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3728), "Sewage" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 143865155, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4235), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4236), "Drawings" },
                    { 403755662, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4202), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4203), "Documents" },
                    { 873378759, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4222), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4223), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 136175058, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4852), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4853), "Printing" },
                    { 770598498, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4892), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4893), "Administration" },
                    { 915672307, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4829), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4830), "Communications" },
                    { 983021197, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4879), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4880), "Meetings" },
                    { 994059721, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4866), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4867), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 195509334, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(800), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(801), "Dashboard Assign Designer", 3 },
                    { 212193292, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(846), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(848), "Dashboard Add Project", 6 },
                    { 476300073, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(908), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(909), "See All Drawings", 10 },
                    { 496333570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(892), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(893), "See All Disciplines", 9 },
                    { 539850717, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(923), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(924), "See All Projects", 11 },
                    { 664239774, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(682), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(684), "See Dashboard Layout", 1 },
                    { 787754645, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(829), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(831), "Dashboard Assign Project Manager", 5 },
                    { 938700348, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(782), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(784), "Dashboard Edit My Hours", 2 },
                    { 947731967, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(862), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(863), "See Admin Layout", 7 },
                    { 967930680, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(815), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(816), "Dashboard Assign Engineer", 4 },
                    { 985508998, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(877), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(878), "Dashboard See My Hours", 8 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 507206643, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3190), "Infrastructure Description", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3191), "Infrastructure" },
                    { 664963804, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3168), "Buildings Description", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3169), "Buildings" },
                    { 820714094, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3204), "Energy Description", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3206), "Energy" },
                    { 829833374, false, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3233), "Production Management Description", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3234), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { 914400879, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3219), "Consulting Description", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3220), "Consulting" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 326266838, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1012), false, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1013), "CTO" },
                    { 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(998), false, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(999), "COO" },
                    { 470037389, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1071), false, false, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1072), "Admin" },
                    { 633466692, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(968), false, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(969), "Engineer" },
                    { 682379894, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1086), false, false, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1087), "Secretariat" },
                    { 721870707, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(983), false, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(984), "Project Manager" },
                    { 728075880, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1056), false, false, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1058), "Customer" },
                    { 764930164, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1042), false, false, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1043), "Guest" },
                    { 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1027), false, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1028), "CEO" },
                    { 973380791, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(939), false, true, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(941), "Designer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2542), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2543), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2662), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2663), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2458), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2459), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2499), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2501), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 349781651, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1980), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1981), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2946), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2948), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2815), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2816), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3034), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3035), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2412), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2413), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 541162845, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2212), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2213), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 550310721, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1919), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1920), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2722), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2723), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3124), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3125), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2771), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2772), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 653277514, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2366), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2367), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2990), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2992), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2860), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2862), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 676488074, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2074), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2075), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 821306947, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2165), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2166), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 828416547, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2027), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2028), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 852971836, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2319), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2321), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2903), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2904), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2585), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2587), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3077), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3078), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 893371590, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2117), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2118), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 914807197, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2273), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2274), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 123638212, "gdoug@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2289), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2291), 914807197 },
                    { 190586124, "sparisis@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2514), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2516), 340876949 },
                    { 192082572, "pfokianou@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2918), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2920), 861573605 },
                    { 199875541, "vchontos@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3049), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3050), 526696926 },
                    { 201483202, "blekou@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3005), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3007), 665196012 },
                    { 212109204, "panperivollari@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3092), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3093), 891706961 },
                    { 237100174, "vpax@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2429), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2430), 536405986 },
                    { 267683179, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2381), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2382), 653277514 },
                    { 289636902, "coo@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2089), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2090), 676488074 },
                    { 299803013, "haris@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2875), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2876), 665482134 },
                    { 359827602, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2244), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2245), 541162845 },
                    { 404200636, "cto@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2042), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2043), 828416547 },
                    { 437040258, "embiria@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2230), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2231), 541162845 },
                    { 478512936, "kkotsoni@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2677), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2679), 236159493 },
                    { 502997051, "ngal@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2602), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2603), 866353681 },
                    { 566369574, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2961), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2962), 397050875 },
                    { 580148920, "ceo@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1997), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1998), 349781651 },
                    { 602147205, "vtza@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2742), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2743), 612337098 },
                    { 605330648, "chkovras@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2558), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2559), 205262901 },
                    { 711053459, "guest@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2134), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2135), 893371590 },
                    { 713939871, "agretos@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2786), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2788), 648748195 },
                    { 754664592, "pm@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2180), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2181), 821306947 },
                    { 880341487, "xmanarolis@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2472), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2474), 325523283 },
                    { 902070454, "kmargeti@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2831), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2832), 475583034 },
                    { 915133625, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3139), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3140), 625786790 },
                    { 943942836, "dtsa@embiria.gr", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2336), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2337), 852971836 },
                    { 974845622, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1939), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1940), 550310721 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 508217235, false, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 8.0, 9, new DateTime(2024, 12, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 9, "Test Description Project_9", new DateTime(2024, 12, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), new DateTime(2024, 12, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Project_3", 5.0, new DateTime(2024, 12, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Payment Detailes For Project_6", 3.0, null, 820714094, new DateTime(2024, 12, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f },
                    { 686943398, true, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 7.0, 4, new DateTime(2024, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 4, "Test Description Project_4", new DateTime(2024, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), new DateTime(2024, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Project_2", 5.0, new DateTime(2024, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Payment Detailes For Project_4", 2.0, null, 507206643, new DateTime(2024, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f },
                    { 691612398, true, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 9.0, 16, new DateTime(2025, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 16, "Test Description Project_24", new DateTime(2025, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), new DateTime(2025, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Project_4", 5.0, new DateTime(2025, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Payment Detailes For Project_24", 4.0, null, 914400879, new DateTime(2025, 7, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f },
                    { 829368683, true, "ALPHA", 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 111.0, 90, new DateTime(2024, 6, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 1, "Test Description Project_PM", new DateTime(2024, 4, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), new DateTime(2024, 5, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Project_PM", 45.0, new DateTime(2024, 4, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Payment Detailes For Project_PM", 2.0, null, 829833374, new DateTime(2024, 5, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f },
                    { 935931963, false, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 6.0, 1, new DateTime(2024, 4, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 1, "Test Description Project_6", new DateTime(2024, 4, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), new DateTime(2024, 4, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f, 1500L, 12L, new DateTime(2024, 3, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Project_1", 5.0, new DateTime(2024, 4, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), "Payment Detailes For Project_6", 1.0, null, 664963804, new DateTime(2024, 4, 14, 19, 57, 34, 89, DateTimeKind.Local).AddTicks(4685), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 212193292, 326266838, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1520), -1174052398, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1521) },
                    { 476300073, 326266838, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1563), -1564321013, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1564) },
                    { 496333570, 326266838, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1549), 1478521602, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1550) },
                    { 539850717, 326266838, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1577), 628141955, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1579) },
                    { 664239774, 326266838, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1478), -259788865, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1479) },
                    { 787754645, 326266838, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1506), 1825409403, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1507) },
                    { 938700348, 326266838, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1492), 743133704, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1493) },
                    { 985508998, 326266838, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1534), -1174335020, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1536) },
                    { 195509334, 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1377), -1302813427, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1378) },
                    { 476300073, 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1449), 1755657896, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1450) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 496333570, 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1435), 139921007, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1436) },
                    { 539850717, 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1464), 1896991677, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1465) },
                    { 664239774, 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1347), 407448253, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1348) },
                    { 787754645, 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1406), -418449136, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1407) },
                    { 938700348, 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1361), 1495043352, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1363) },
                    { 967930680, 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1392), 423396383, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1393) },
                    { 985508998, 400783570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1421), 1292787860, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1422) },
                    { 476300073, 470037389, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1801), -1213097818, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1802) },
                    { 496333570, 470037389, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1786), -1016230877, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1788) },
                    { 539850717, 470037389, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1815), -1344357121, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1816) },
                    { 947731967, 470037389, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1772), -1334742961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1774) },
                    { 195509334, 633466692, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1190), -521554270, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1191) },
                    { 476300073, 633466692, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1236), -720502744, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1237) },
                    { 496333570, 633466692, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1222), 2116542987, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1223) },
                    { 664239774, 633466692, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1160), -1760774525, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1161) },
                    { 938700348, 633466692, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1174), -1241870422, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1176) },
                    { 985508998, 633466692, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1207), -356659330, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1208) },
                    { 476300073, 682379894, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1888), 1143794489, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1889) },
                    { 496333570, 682379894, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1874), 1940879196, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1875) },
                    { 539850717, 682379894, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1903), 549441851, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1904) },
                    { 664239774, 682379894, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1831), 670679852, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1832) },
                    { 938700348, 682379894, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1845), -1867119857, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1846) },
                    { 985508998, 682379894, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1859), 1553006633, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1861) },
                    { 476300073, 721870707, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1333), -248175274, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1334) },
                    { 496333570, 721870707, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1318), -857410969, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1319) },
                    { 664239774, 721870707, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1261), -576729872, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1262) },
                    { 938700348, 721870707, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1276), -1703834995, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1277) },
                    { 967930680, 721870707, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1290), -2002016114, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1291) },
                    { 985508998, 721870707, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1304), -954804662, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1305) },
                    { 664239774, 728075880, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1758), 2012387841, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1760) },
                    { 664239774, 764930164, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1744), 529779560, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1745) },
                    { 195509334, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1626), 1227839711, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1627) },
                    { 212193292, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1673), -1757554348, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1674) },
                    { 476300073, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1716), 1294977330, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1717) },
                    { 496333570, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1701), 1514983230, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1702) },
                    { 539850717, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1730), 382406684, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1731) },
                    { 664239774, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1592), 1535607252, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1593) },
                    { 787754645, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1656), 1456965275, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1657) },
                    { 938700348, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1608), 1588545810, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1609) },
                    { 947731967, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1687), -15402041, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1688) },
                    { 967930680, 776563123, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1641), 666684374, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1642) },
                    { 664239774, 973380791, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1102), -1667351402, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1103) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 938700348, 973380791, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1130), -18593401, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1131) },
                    { 985508998, 973380791, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1144), 848297318, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1146) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 633466692, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2571), 743790490, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2572) },
                    { 400783570, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2707), 805610662, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2708) },
                    { 633466692, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2692), 936959628, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2693) },
                    { 721870707, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3267), 91259062, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3268) },
                    { 633466692, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2485), 593249230, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2487) },
                    { 633466692, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2528), 550314301, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2529) },
                    { 776563123, 349781651, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2011), 164898060, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2012) },
                    { 633466692, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2975), 646400753, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2976) },
                    { 633466692, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2846), 652911706, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2847) },
                    { 633466692, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3063), 833837228, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3064) },
                    { 633466692, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2443), 619537735, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2444) },
                    { 721870707, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3250), 119363689, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3251) },
                    { 682379894, 541162845, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2258), 148746559, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2259) },
                    { 470037389, 550310721, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1960), 742810506, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(1961) },
                    { 633466692, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2756), 283128446, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2758) },
                    { 633466692, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3153), 870651943, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3154) },
                    { 633466692, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2800), 188142429, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2801) },
                    { 973380791, 653277514, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2395), 737200232, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2396) },
                    { 633466692, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3019), 390451048, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3020) },
                    { 633466692, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2889), 772448305, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2890) },
                    { 721870707, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3282), 82288299, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3283) },
                    { 400783570, 676488074, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2102), 948824315, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2103) },
                    { 721870707, 821306947, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2194), 893562861, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2195) },
                    { 326266838, 828416547, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2059), 327327826, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2060) },
                    { 973380791, 852971836, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2350), 176611167, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2351) },
                    { 633466692, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2932), 283858282, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2933) },
                    { 470037389, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2631), 520068366, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2632) },
                    { 633466692, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2616), 525883996, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2618) },
                    { 776563123, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2646), 161313756, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2647) },
                    { 633466692, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3106), 166940024, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3107) },
                    { 764930164, 893371590, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2149), 335850608, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2150) },
                    { 973380791, 914807197, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2305), 449651422, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(2306) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1647917232, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4021), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4022), 935931963, 873610050, null },
                    { -1537742552, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4036), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4037), 686943398, 187642174, null },
                    { -1073567200, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4050), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4051), 686943398, 438054161, null },
                    { -943902040, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3977), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3978), 935931963, 997266258, null },
                    { -837646848, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4186), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4187), 829368683, 354156439, null },
                    { -826610016, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4144), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4145), 691612398, 997266258, null },
                    { -440960944, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4112), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4113), 508217235, 924701775, null },
                    { 178830936, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4158), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4159), 691612398, 806950646, null },
                    { 730240472, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4006), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4007), 935931963, 924701775, null },
                    { 1028583896, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4066), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4067), 686943398, 997266258, null },
                    { 1101025744, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4172), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4173), 691612398, 301115277, null },
                    { 1112974368, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4125), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4126), 508217235, 584773765, null },
                    { 1516200488, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4098), 0f, 500L, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4099), 508217235, 438054161, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 399675940, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3510), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3512), 3100.0, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3511), "Signature 142348", 43948, 686943398, 2.0, 24.0 },
                    { 835116746, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3665), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3668), 13000.0, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3667), "Signature 1423412", 29752, 691612398, 4.0, 24.0 },
                    { 956071924, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3414), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3416), 3010.0, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3415), "Signature 142341", 56097, 935931963, 1.0, 17.0 },
                    { 973737305, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3589), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3591), 4000.0, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3590), "Signature 1423418", 53335, 508217235, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectsPmanagers",
                columns: new[] { "ProjectId", "ProjectManagerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 686943398, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5801), 931513132, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5802) },
                    { 691612398, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5825), 710087935, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5826) },
                    { 935931963, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5783), 416955638, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5784) },
                    { 508217235, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5813), 917216648, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5814) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 421332808, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3548), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3549), null, "6949277783", null, null, 508217235, "alexpl_{i}@gmail.com" },
                    { 737781858, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3625), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3626), null, "6949277784", null, null, 691612398, "alexpl_{i}@gmail.com" },
                    { 757123402, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3363), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3365), null, "6949277781", null, null, 935931963, "alexpl_{i}@gmail.com" },
                    { 959512011, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3464), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3465), null, "6949277782", null, null, 686943398, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1647917232, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6299), 236548960, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6300) },
                    { -1647917232, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6324), 912090211, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6325) },
                    { -1647917232, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6273), 397473699, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6275) },
                    { -1647917232, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6286), 469175177, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6288) },
                    { -1647917232, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6398), 223312197, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6399) },
                    { -1647917232, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6361), 767357437, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6362) },
                    { -1647917232, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6423), 913303094, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6424) },
                    { -1647917232, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6260), 487193851, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6261) },
                    { -1647917232, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6336), 954722763, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6337) },
                    { -1647917232, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6448), 362830862, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6449) },
                    { -1647917232, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6348), 938034814, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6349) },
                    { -1647917232, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6410), 972078665, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6411) },
                    { -1647917232, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6373), 739770088, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6374) },
                    { -1647917232, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6385), 845894562, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6386) },
                    { -1647917232, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6311), 594095479, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6312) },
                    { -1647917232, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6435), 816268523, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6436) },
                    { -1537742552, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6497), 990686679, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6498) },
                    { -1537742552, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6522), 862121316, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6524) },
                    { -1537742552, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6472), 283828728, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6474) },
                    { -1537742552, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6485), 135189587, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6486) },
                    { -1537742552, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6597), 651755295, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6598) },
                    { -1537742552, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6559), 576438001, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6561) },
                    { -1537742552, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6625), 671464605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6626) },
                    { -1537742552, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6460), 339595733, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6461) },
                    { -1537742552, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6535), 135284885, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6536) },
                    { -1537742552, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6650), 813934096, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6651) },
                    { -1537742552, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6547), 402577667, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6548) },
                    { -1537742552, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6613), 251954297, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6614) },
                    { -1537742552, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6572), 196335104, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6573) },
                    { -1537742552, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6584), 550684058, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6585) },
                    { -1537742552, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6510), 933901259, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6511) },
                    { -1537742552, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6637), 827622766, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6639) },
                    { -1073567200, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6702), 956810845, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6703) },
                    { -1073567200, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6726), 861908694, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6728) },
                    { -1073567200, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6676), 254504095, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6678) },
                    { -1073567200, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6689), 648932446, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6690) },
                    { -1073567200, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6801), 253932356, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6803) },
                    { -1073567200, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6764), 831511620, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6765) },
                    { -1073567200, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6827), 881280548, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6828) },
                    { -1073567200, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6663), 381713242, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6664) },
                    { -1073567200, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6739), 883554924, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6740) },
                    { -1073567200, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6851), 709605187, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6852) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1073567200, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6752), 776364075, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6753) },
                    { -1073567200, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6814), 359457831, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6815) },
                    { -1073567200, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6777), 251714783, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6778) },
                    { -1073567200, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6789), 452800131, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6790) },
                    { -1073567200, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6714), 879284595, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6715) },
                    { -1073567200, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6839), 203694157, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6840) },
                    { -943902040, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5890), 718082845, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5891) },
                    { -943902040, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5916), 213787532, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5917) },
                    { -943902040, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5861), 943245168, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5862) },
                    { -943902040, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5877), 772751583, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5878) },
                    { -943902040, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5993), 405190255, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5994) },
                    { -943902040, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5954), 978509644, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5955) },
                    { -943902040, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6018), 894744616, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6019) },
                    { -943902040, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5839), 382567699, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5840) },
                    { -943902040, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5929), 810059004, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5930) },
                    { -943902040, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6043), 438870152, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6044) },
                    { -943902040, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5942), 669392270, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5943) },
                    { -943902040, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6006), 879784874, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6007) },
                    { -943902040, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5969), 664456883, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5970) },
                    { -943902040, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5981), 184773176, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5982) },
                    { -943902040, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5903), 740905733, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5904) },
                    { -943902040, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6031), 152093216, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6032) },
                    { -826610016, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7709), 463383847, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7710) },
                    { -826610016, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7733), 617926587, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7734) },
                    { -826610016, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7684), 899699664, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7685) },
                    { -826610016, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7697), 649582969, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7698) },
                    { -826610016, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7808), 391371779, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7809) },
                    { -826610016, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7770), 989437159, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7771) },
                    { -826610016, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7833), 156372298, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7834) },
                    { -826610016, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7672), 682991409, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7673) },
                    { -826610016, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7746), 315327655, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7747) },
                    { -826610016, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7858), 968179963, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7859) },
                    { -826610016, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7758), 316377946, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7759) },
                    { -826610016, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7821), 851020317, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7822) },
                    { -826610016, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7783), 680962735, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7784) },
                    { -826610016, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7796), 965148164, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7797) },
                    { -826610016, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7721), 481895422, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7722) },
                    { -826610016, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7845), 938160221, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7846) },
                    { -440960944, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7303), 975953369, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7305) },
                    { -440960944, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7328), 149231848, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7329) },
                    { -440960944, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7278), 176227055, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7279) },
                    { -440960944, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7291), 793454785, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7292) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -440960944, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7406), 259933632, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7407) },
                    { -440960944, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7369), 460196929, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7370) },
                    { -440960944, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7431), 341700591, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7432) },
                    { -440960944, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7266), 181758352, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7267) },
                    { -440960944, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7344), 878226140, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7345) },
                    { -440960944, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7455), 345757094, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7456) },
                    { -440960944, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7356), 990670785, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7358) },
                    { -440960944, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7418), 632381167, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7419) },
                    { -440960944, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7381), 206576843, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7382) },
                    { -440960944, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7394), 285613347, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7395) },
                    { -440960944, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7316), 745193922, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7317) },
                    { -440960944, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7443), 822825625, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7444) },
                    { 178830936, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7908), 964699274, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7909) },
                    { 178830936, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7933), 423607537, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7934) },
                    { 178830936, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7883), 414692542, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7884) },
                    { 178830936, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7895), 439002388, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7896) },
                    { 178830936, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8007), 222399194, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8009) },
                    { 178830936, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7970), 704289278, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7971) },
                    { 178830936, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8036), 259223071, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8037) },
                    { 178830936, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7870), 580868913, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7871) },
                    { 178830936, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7945), 488026583, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7946) },
                    { 178830936, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8061), 407908908, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8062) },
                    { 178830936, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7957), 372987867, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7958) },
                    { 178830936, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8023), 128397215, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8024) },
                    { 178830936, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7982), 701252570, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7984) },
                    { 178830936, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7995), 380070271, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7996) },
                    { 178830936, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7920), 316763358, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7921) },
                    { 178830936, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8048), 327291884, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8049) },
                    { 730240472, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6094), 571644382, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6095) },
                    { 730240472, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6119), 950303016, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6120) },
                    { 730240472, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6069), 958798693, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6070) },
                    { 730240472, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6082), 957876360, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6083) },
                    { 730240472, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6194), 488482763, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6195) },
                    { 730240472, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6157), 563054019, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6158) },
                    { 730240472, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6219), 630993431, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6220) },
                    { 730240472, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6056), 138893503, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6057) },
                    { 730240472, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6132), 429379197, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6133) },
                    { 730240472, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6246), 471180261, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6248) },
                    { 730240472, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6145), 825517113, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6146) },
                    { 730240472, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6207), 958407996, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6208) },
                    { 730240472, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6169), 572357716, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6170) },
                    { 730240472, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6182), 932303991, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6183) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 730240472, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6107), 318143763, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6108) },
                    { 730240472, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6231), 464237023, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6232) },
                    { 1028583896, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6901), 485404176, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6902) },
                    { 1028583896, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6926), 410707450, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6927) },
                    { 1028583896, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6876), 514442859, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6877) },
                    { 1028583896, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6889), 385277314, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6890) },
                    { 1028583896, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7004), 922636954, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7005) },
                    { 1028583896, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6967), 938157565, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6968) },
                    { 1028583896, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7029), 629353561, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7030) },
                    { 1028583896, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6864), 981356755, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6865) },
                    { 1028583896, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6938), 137169835, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6940) },
                    { 1028583896, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7054), 620099883, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7055) },
                    { 1028583896, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6954), 970641329, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6955) },
                    { 1028583896, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7016), 592312705, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7017) },
                    { 1028583896, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6979), 321845366, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6980) },
                    { 1028583896, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6992), 293394331, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6993) },
                    { 1028583896, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6914), 868949539, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(6915) },
                    { 1028583896, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7041), 323942688, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7042) },
                    { 1101025744, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8111), 814851996, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8112) },
                    { 1101025744, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8135), 323048200, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8136) },
                    { 1101025744, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8086), 291618557, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8087) },
                    { 1101025744, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8098), 374395762, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8099) },
                    { 1101025744, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8209), 893286746, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8210) },
                    { 1101025744, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8172), 523305100, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8173) },
                    { 1101025744, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8234), 370269653, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8235) },
                    { 1101025744, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8073), 595605289, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8074) },
                    { 1101025744, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8147), 245891430, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8149) },
                    { 1101025744, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8259), 190411071, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8260) },
                    { 1101025744, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8160), 837014307, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8161) },
                    { 1101025744, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8222), 292544656, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8223) },
                    { 1101025744, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8184), 254959303, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8185) },
                    { 1101025744, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8197), 732145944, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8198) },
                    { 1101025744, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8123), 535083884, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8124) },
                    { 1101025744, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8246), 934126517, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(8247) },
                    { 1112974368, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7507), 992136382, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7508) },
                    { 1112974368, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7531), 475672966, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7532) },
                    { 1112974368, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7482), 619091915, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7483) },
                    { 1112974368, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7494), 533614656, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7495) },
                    { 1112974368, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7606), 254927617, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7607) },
                    { 1112974368, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7569), 961145951, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7570) },
                    { 1112974368, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7634), 622135962, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7635) },
                    { 1112974368, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7468), 366233283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7469) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1112974368, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7544), 850299421, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7545) },
                    { 1112974368, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7659), 714490193, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7660) },
                    { 1112974368, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7556), 177977351, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7557) },
                    { 1112974368, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7618), 915705502, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7619) },
                    { 1112974368, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7581), 133245367, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7582) },
                    { 1112974368, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7593), 415565774, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7595) },
                    { 1112974368, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7519), 531952675, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7520) },
                    { 1112974368, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7646), 226778333, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7647) },
                    { 1516200488, 205262901, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7104), 612282938, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7105) },
                    { 1516200488, 236159493, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7129), 137242922, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7130) },
                    { 1516200488, 325523283, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7079), 766082072, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7080) },
                    { 1516200488, 340876949, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7092), 937612605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7093) },
                    { 1516200488, 397050875, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7204), 394344071, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7205) },
                    { 1516200488, 475583034, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7166), 689263001, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7167) },
                    { 1516200488, 526696926, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7229), 320898019, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7230) },
                    { 1516200488, 536405986, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7066), 363679503, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7068) },
                    { 1516200488, 612337098, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7142), 985635645, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7143) },
                    { 1516200488, 625786790, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7253), 774310622, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7255) },
                    { 1516200488, 648748195, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7154), 792196053, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7155) },
                    { 1516200488, 665196012, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7217), 129583182, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7218) },
                    { 1516200488, 665482134, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7180), 255778209, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7181) },
                    { 1516200488, 861573605, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7192), 500753797, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7193) },
                    { 1516200488, 866353681, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7116), 932670631, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7117) },
                    { 1516200488, 891706961, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7241), 428792340, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(7242) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 129859558, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4738), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4736), 1101025744, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4737), 403755662 },
                    { 145461440, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4348), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4345), -1647917232, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4347), 403755662 },
                    { 146802884, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4436), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4433), -1073567200, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4434), 403755662 },
                    { 149520131, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4753), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4750), 1101025744, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4752), 873378759 },
                    { 150085729, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4317), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4315), 730240472, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4316), 873378759 },
                    { 161799604, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4652), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4649), -826610016, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4650), 403755662 },
                    { 161967448, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4333), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4331), 730240472, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4332), 143865155 },
                    { 189044954, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4477), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4475), 1028583896, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4476), 403755662 },
                    { 204607473, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4525), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4523), 1516200488, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4524), 403755662 },
                    { 238234026, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4274), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4271), -943902040, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4272), 873378759 },
                    { 275008040, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4491), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4489), 1028583896, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4490), 873378759 },
                    { 288555410, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4255), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4251), -943902040, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4253), 403755662 },
                    { 304209916, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4510), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4508), 1028583896, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4509), 143865155 },
                    { 328243559, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4421), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4419), -1537742552, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4420), 143865155 },
                    { 340496352, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4376), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4374), -1647917232, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4375), 143865155 },
                    { 363303537, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4393), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4390), -1537742552, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4391), 403755662 },
                    { 425277942, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4782), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4779), -837646848, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4780), 403755662 },
                    { 465108936, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4595), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4593), -440960944, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4594), 143865155 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 493865099, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4407), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4405), -1537742552, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4406), 873378759 },
                    { 521274753, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4539), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4537), 1516200488, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4538), 873378759 },
                    { 524442566, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4812), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4809), -837646848, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4810), 143865155 },
                    { 532297389, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4288), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4286), -943902040, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4287), 143865155 },
                    { 534136445, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4767), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4764), 1101025744, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4765), 143865155 },
                    { 536185046, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4463), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4461), -1073567200, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4462), 143865155 },
                    { 569159609, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4449), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4447), -1073567200, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4448), 873378759 },
                    { 589308328, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4581), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4579), -440960944, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4580), 873378759 },
                    { 618052417, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4798), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4795), -837646848, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4797), 873378759 },
                    { 630292081, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4610), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4607), 1112974368, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4608), 403755662 },
                    { 636661344, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4303), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4300), 730240472, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4301), 403755662 },
                    { 644407497, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4362), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4360), -1647917232, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4361), 873378759 },
                    { 645587655, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4694), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4691), 178830936, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4692), 403755662 },
                    { 660418293, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4721), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4719), 178830936, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4720), 143865155 },
                    { 797595865, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4666), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4663), -826610016, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4664), 873378759 },
                    { 808838974, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4623), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4621), 1112974368, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4622), 873378759 },
                    { 859547626, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4567), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4565), -440960944, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4566), 403755662 },
                    { 867405306, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4553), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4551), 1516200488, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4552), 143865155 },
                    { 898250310, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4637), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4635), 1112974368, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4636), 143865155 },
                    { 912457302, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4708), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4705), 178830936, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4706), 873378759 },
                    { 949352569, new DateTime(2024, 3, 25, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4679), 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4677), -826610016, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4678), 143865155 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 211105762, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3483), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3484), 959512011 },
                    { 495810051, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3563), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3565), 421332808 },
                    { 956348251, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3641), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3642), 737781858 },
                    { 981667557, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3383), new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3384), 757123402 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 127221584, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5353), 1516200488, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5354), 983021197 },
                    { 128524374, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5602), 178830936, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5603), 994059721 },
                    { 158990651, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5211), -1073567200, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5212), 994059721 },
                    { 189443178, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5288), 1028583896, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5289), 983021197 },
                    { 197432842, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5300), 1028583896, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5301), 770598498 },
                    { 201820063, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5065), -1647917232, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5066), 136175058 },
                    { 218963343, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5456), 1112974368, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5457), 136175058 },
                    { 236652607, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5169), -1537742552, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5170), 770598498 },
                    { 248501355, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5224), -1073567200, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5225), 983021197 },
                    { 250393708, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5508), -826610016, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5509), 915672307 },
                    { 265714578, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5198), -1073567200, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5200), 136175058 },
                    { 268509107, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5703), 1101025744, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5704), 770598498 },
                    { 314749083, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5366), 1516200488, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5367), 770598498 },
                    { 320154053, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5589), 178830936, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5590), 136175058 },
                    { 322559260, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5768), -837646848, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5769), 770598498 },
                    { 323138069, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5185), -1073567200, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5187), 915672307 },
                    { 330103008, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5090), -1647917232, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5091), 983021197 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 340436762, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5077), -1647917232, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5078), 994059721 },
                    { 375363854, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5379), -440960944, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5380), 915672307 },
                    { 382210262, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4971), -943902040, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4972), 770598498 },
                    { 388838623, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5156), -1537742552, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5157), 983021197 },
                    { 402604973, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5430), -440960944, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5431), 770598498 },
                    { 419663407, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5392), -440960944, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5393), 136175058 },
                    { 448620817, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5537), -826610016, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5538), 994059721 },
                    { 453945698, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5262), 1028583896, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5263), 136175058 },
                    { 462722390, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5443), 1112974368, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5444), 915672307 },
                    { 468278204, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4910), -943902040, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4912), 915672307 },
                    { 503357216, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5716), -837646848, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5718), 915672307 },
                    { 510361359, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5275), 1028583896, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5276), 994059721 },
                    { 516603805, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4985), 730240472, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4986), 915672307 },
                    { 525194894, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5143), -1537742552, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5144), 994059721 },
                    { 572518679, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4932), -943902040, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4933), 136175058 },
                    { 574120744, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5640), 178830936, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5641), 770598498 },
                    { 604704183, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5103), -1647917232, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5104), 770598498 },
                    { 625339067, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5563), -826610016, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5564), 770598498 },
                    { 645809112, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5051), -1647917232, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5053), 915672307 },
                    { 655597630, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5495), 1112974368, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5496), 770598498 },
                    { 660221775, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5327), 1516200488, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5328), 136175058 },
                    { 680484484, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5614), 178830936, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5615), 983021197 },
                    { 683602965, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5129), -1537742552, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5130), 136175058 },
                    { 686786749, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5116), -1537742552, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5117), 915672307 },
                    { 711817145, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5469), 1112974368, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5470), 994059721 },
                    { 738190175, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5653), 1101025744, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5654), 915672307 },
                    { 739133093, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5482), 1112974368, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5483), 983021197 },
                    { 753784335, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5665), 1101025744, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5667), 136175058 },
                    { 764541688, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5678), 1101025744, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5679), 994059721 },
                    { 766215151, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5339), 1516200488, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5340), 994059721 },
                    { 790319521, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5237), -1073567200, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5238), 770598498 },
                    { 806782929, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4999), 730240472, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5000), 136175058 },
                    { 817024733, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5038), 730240472, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5039), 770598498 },
                    { 830588982, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5524), -826610016, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5525), 136175058 },
                    { 840570896, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5731), -837646848, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5732), 136175058 },
                    { 841541637, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4945), -943902040, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4946), 994059721 },
                    { 845566144, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5576), 178830936, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5577), 915672307 },
                    { 845630538, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5690), 1101025744, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5692), 983021197 },
                    { 851609613, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5404), -440960944, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5406), 994059721 },
                    { 864973583, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4958), -943902040, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(4959), 983021197 },
                    { 895153715, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5024), 730240472, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5026), 983021197 },
                    { 906138233, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5313), 1516200488, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5314), 915672307 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 946523652, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5550), -826610016, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5551), 983021197 },
                    { 949982788, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5755), -837646848, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5757), 983021197 },
                    { 967515319, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5012), 730240472, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5013), 994059721 },
                    { 969535538, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5417), -440960944, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5418), 983021197 },
                    { 970775447, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5250), 1028583896, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5251), 915672307 },
                    { 977371740, 0f, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5743), -837646848, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(5744), 994059721 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 728075880, 421332808, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3576), 960784842, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3577) },
                    { 728075880, 737781858, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3653), 567115241, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3654) },
                    { 728075880, 757123402, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3397), 436227253, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3398) },
                    { 728075880, 959512011, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3496), 919620918, new DateTime(2024, 3, 14, 19, 57, 34, 107, DateTimeKind.Local).AddTicks(3497) }
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
