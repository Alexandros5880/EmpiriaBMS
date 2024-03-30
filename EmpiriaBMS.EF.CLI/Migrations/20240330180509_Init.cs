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
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Evaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerificatorSignature = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PMSignature = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsClose = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Users_CreatorId",
                        column: x => x.CreatorId,
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
                    { 303538163, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8646), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8647), "HVAC" },
                    { 395580076, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8730), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8731), "Drainage" },
                    { 479199907, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3974), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3976), "TenderDocument" },
                    { 492434166, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3604), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3606), "Elevators" },
                    { 501163094, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8708), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8710), "Potable Water" },
                    { 504847749, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8778), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8780), "Fire Suppression" },
                    { 538753295, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4021), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4023), "DWG Admin/Clearing" },
                    { 570582637, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3866), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3868), "CCTV" },
                    { 573860360, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4000), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4002), "Construction Supervision" },
                    { 596876294, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3751), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3753), "Natural Gas" },
                    { 630433741, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3888), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3889), "BMS" },
                    { 635677059, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3909), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3911), "Photovoltaics" },
                    { 650854836, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3845), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3847), "Burglar Alarm" },
                    { 690431637, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8751), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8753), "Fire Detection" },
                    { 697970038, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3931), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3933), "Energy Efficiency" },
                    { 742132665, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3952), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3954), "Outsource" },
                    { 802414591, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3774), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3776), "Power Distribution" },
                    { 830401654, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8685), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8687), "Sewage" },
                    { 894878923, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3821), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(3823), "Structured Cabling" },
                    { 895496169, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4043), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4045), "Project Manager Hours" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 231291258, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4934), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4935), "Calculations" },
                    { 279923365, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4954), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4955), "Drawings" },
                    { 363337492, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4899), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4900), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 334884396, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7537), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7539), "Meetings" },
                    { 396670392, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7454), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7456), "Communications" },
                    { 558347465, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7517), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7519), "On-Site" },
                    { 572746915, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7604), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7606), "Hours To Be Raised" },
                    { 721177858, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7496), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7498), "Printing" },
                    { 823371891, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7581), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7583), "Soft Copy" },
                    { 929717431, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7557), new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7559), "Administration" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 129220142, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2627), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2629), "See Active Delayed Projects KPI", 19 },
                    { 162475563, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2541), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2544), "Dashboard Edit Other", 16 },
                    { 192159944, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2173), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2176), "Dashboard See My Hours", 8 },
                    { 209525611, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2394), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2396), "See All Projects", 11 },
                    { 269409196, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2568), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2571), "Dashboard See KPIS", 17 },
                    { 418293565, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2057), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2060), "Dashboard Assign Engineer", 4 },
                    { 428601689, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(1994), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(1996), "Dashboard Edit My Hours", 2 },
                    { 451505012, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(1835), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(1838), "See Dashboard Layout", 1 },
                    { 507789813, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2732), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2735), "See Active Delayed Project Types Counter KPI", 23 },
                    { 531870664, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2653), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2655), "See All Projects Missed DeadLine KPI", 20 },
                    { 595013983, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2086), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2088), "Dashboard Assign Project Manager", 5 },
                    { 606964243, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2028), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2031), "Dashboard Assign Designer", 3 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 618359960, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2117), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2120), "Dashboard Add Project", 6 },
                    { 631368307, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2423), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2426), "Edit Project On Dashboard", 12 },
                    { 631470000, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2512), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2515), "Dashboard Edit Deliverable", 15 },
                    { 687752758, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2705), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2708), "See My Projects Missed DeadLine KPI", 22 },
                    { 699704031, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2201), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2204), "See All Disciplines", 9 },
                    { 719845367, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2452), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2454), "Display Projects Code", 13 },
                    { 791816748, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2146), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2148), "See Admin Layout", 7 },
                    { 875246938, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2233), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2236), "See All Drawings", 10 },
                    { 875526512, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2599), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2601), "See Hours Per Role KPI", 18 },
                    { 898022612, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2484), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2487), "Dashboard Edit Discipline", 14 },
                    { 904411822, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2680), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2682), "See Employee Turnover KPI", 21 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 439019060, false, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7732), "Production Management Description", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7734), "Production Management" },
                    { 544532525, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7705), "Consulting Description", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7708), "Consulting" },
                    { 630690249, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7611), "Buildings Description", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7613), "Buildings" },
                    { 777906847, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7651), "Infrastructure Description", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7654), "Infrastructure" },
                    { 914073797, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7679), "Energy Description", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7681), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 175732871, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3087), false, false, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3090), "Admin", null },
                    { 705092614, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3030), false, false, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3033), "Guest", null },
                    { 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2763), false, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2766), "CEO", null },
                    { 831955738, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3058), false, false, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3060), "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7279), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7282), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7526), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7529), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6638), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6640), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 262886843, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5804), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5806), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6721), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6724), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7445), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7447), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6222), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6224), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 437267550, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5889), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5892), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6498), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6500), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6981), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6984), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7364), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7365), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 537075709, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5435), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5438), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5976), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5979), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 611676993, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5690), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5692), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6144), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6146), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6804), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6807), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6379), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6381), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6062), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6064), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7191), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7194), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6895), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6898), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 147392486, "gdoug@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5750), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5752), 611676993 },
                    { 157449717, "xmanarolis@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6090), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6092), 851326738 },
                    { 182529142, "vtza@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6667), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6670), 202270979 },
                    { 206869361, "panperivollari@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7473), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7475), 318195714 },
                    { 244486883, "chkovras@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6250), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6252), 411446807 },
                    { 250914191, "pfokianou@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7011), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7014), 511886378 },
                    { 275093355, "ngal@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6412), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6414), 781885152 },
                    { 312214160, "vpax@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6006), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6008), 598788129 },
                    { 330018511, "sparisis@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6168), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6170), 635481089 },
                    { 350840820, "blekou@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7308), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7311), 131481135 },
                    { 415014715, "agretos@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6750), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6752), 291820155 },
                    { 570585836, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7220), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7222), 946188819 },
                    { 595501419, "embiria@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5512), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5515), 537075709 },
                    { 609678247, "vchontos@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7389), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7392), 534512041 },
                    { 624036468, "kmargeti@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6837), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6839), 650787772 },
                    { 700732771, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7554), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7556), 139394253 },
                    { 842537412, "dtsa@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5917), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5919), 437267550 },
                    { 867605467, "kkotsoni@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6526), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6529), 448331562 },
                    { 872294377, "dtsa@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5833), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5836), 262886843 },
                    { 896778654, "haris@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6923), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6926), 987647449 },
                    { 931443624, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5609), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5612), 537075709 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 144351450, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2025, 7, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_16", new DateTime(2025, 7, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2025, 7, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 10000.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_4", 448331562, null, 544532525, 0f },
                    { 214355374, false, 1, "D-22-169", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2023, 8, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_28", new DateTime(2024, 3, 23, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 3, 23, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 1325.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_Missed_DeadLine_9", 598788129, null, 914073797, 0f },
                    { 229341700, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2024, 6, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_PM", new DateTime(2024, 4, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 5, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, null, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_PM", null, null, 439019060, 0f },
                    { 230219891, true, 1, "D-22-168", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2023, 9, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_30", new DateTime(2024, 3, 24, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 3, 24, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 1325.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_Missed_DeadLine_8", 987647449, null, 777906847, 0f },
                    { 256925256, true, 4, "D-22-166", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2023, 11, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_16", new DateTime(2024, 3, 26, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 3, 26, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 1325.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_Missed_DeadLine_6", 598788129, null, 544532525, 0f },
                    { 303314923, false, 3, "D-22-165", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2023, 12, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_6", new DateTime(2024, 3, 27, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 3, 27, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 1325.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_Missed_DeadLine_5", 987647449, null, 914073797, 0f },
                    { 384497728, false, 1, "D-22-167", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2023, 10, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_5", new DateTime(2024, 3, 25, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 3, 25, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 1325.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_Missed_DeadLine_7", 448331562, null, 630690249, 0f },
                    { 431315434, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2024, 4, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_4", new DateTime(2024, 4, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 4, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 10000.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_1", 448331562, null, 630690249, 0f },
                    { 550902459, true, 2, "D-22-164", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2024, 1, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_12", new DateTime(2024, 3, 28, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 3, 28, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 1325.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_Missed_DeadLine_4", 448331562, null, 777906847, 0f },
                    { 570008853, false, 1, "D-22-163", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2024, 2, 29, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_6", new DateTime(2024, 3, 29, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 3, 29, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 1325.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_Missed_DeadLine_3", 598788129, null, 630690249, 0f },
                    { 740440654, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2024, 12, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_18", new DateTime(2024, 12, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 12, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 10000.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_3", 448331562, null, 914073797, 0f },
                    { 855720064, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), new DateTime(2024, 7, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Test Description Project_8", new DateTime(2024, 7, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 0f, new DateTime(2024, 7, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), 1500L, 12L, 10000.0, new DateTime(2024, 3, 30, 20, 5, 8, 529, DateTimeKind.Local).AddTicks(6391), "Project_2", 448331562, null, 777906847, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 209525611, 175732871, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5241), 110448950, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5244) },
                    { 699704031, 175732871, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5177), 634838972, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5179) },
                    { 791816748, 175732871, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5151), 1298522534, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5153) },
                    { 875246938, 175732871, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5210), -1318838381, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5212) },
                    { 451505012, 705092614, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5096), -1423698223, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5099) },
                    { 129220142, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4988), 1989094865, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4990) },
                    { 209525611, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4852), 929553125, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4854) },
                    { 269409196, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4936), 1477364063, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4937) },
                    { 418293565, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4641), -678321926, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4643) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 428601689, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4583), 1133047355, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4586) },
                    { 451505012, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4549), 174106670, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4552) },
                    { 507789813, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5068), -472085275, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5070) },
                    { 531870664, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5013), 257193563, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5016) },
                    { 595013983, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4670), 824861066, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4673) },
                    { 606964243, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4612), -249346817, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4615) },
                    { 618359960, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4766), 1785406496, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4769) },
                    { 631368307, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4907), -1391594606, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4910) },
                    { 699704031, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4796), 202712194, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4799) },
                    { 719845367, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4879), 463425638, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4882) },
                    { 875246938, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4824), 505037138, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4826) },
                    { 875526512, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4961), -299715785, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4965) },
                    { 904411822, 799218399, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5042), -873212476, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5044) },
                    { 451505012, 831955738, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5124), 1351246824, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5126) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2810), false, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2813), "COO", 799218399 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 799218399, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6468), 802325701, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6471) });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2107613504, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4145), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4146), 431315434, 690431637, null },
                    { -1942446648, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4648), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4650), 256925256, 650854836, null },
                    { -1757403224, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4780), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4781), 230219891, 742132665, null },
                    { -1636089760, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4672), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4674), 384497728, 742132665, null },
                    { -1589661400, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4739), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4740), 230219891, 501163094, null },
                    { -1435164104, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4168), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4170), 431315434, 303538163, null },
                    { -1424536728, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4235), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4237), 855720064, 303538163, null },
                    { -1337464240, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4583), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4586), 303314923, 596876294, null },
                    { -1157514200, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4539), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4541), 303314923, 492434166, null },
                    { -1145123608, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4424), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4426), 570008853, 303538163, null },
                    { -1005871752, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4096), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4098), 431315434, 635677059, null },
                    { -768655360, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4628), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4630), 256925256, 573860360, null },
                    { -729304656, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4718), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4720), 384497728, 830401654, null },
                    { -675330504, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4355), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4357), 144351450, 573860360, null },
                    { -662693128, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4829), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4830), 214355374, 830401654, null },
                    { -222086192, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4472), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4474), 550902459, 303538163, null },
                    { 333033344, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4849), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4850), 214355374, 697970038, null },
                    { 405545192, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4276), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4277), 740440654, 504847749, null },
                    { 478689528, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4562), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4563), 303314923, 802414591, null },
                    { 481870600, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4401), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4403), 570008853, 830401654, null },
                    { 814382056, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4449), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4450), 570008853, 697970038, null },
                    { 877757688, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4805), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4807), 214355374, 479199907, null },
                    { 994340272, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4333), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4335), 144351450, 635677059, null },
                    { 1034084040, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4516), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4518), 550902459, 596876294, null },
                    { 1043474432, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4608), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4610), 256925256, 802414591, null },
                    { 1324035064, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4695), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4697), 384497728, 303538163, null },
                    { 1445916624, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4378), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4379), 144351450, 570582637, null },
                    { 1513790600, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4494), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4495), 550902459, 742132665, null },
                    { 1612226704, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4256), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4258), 740440654, 596876294, null },
                    { 1754655664, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4759), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4761), 230219891, 492434166, null },
                    { 1863577136, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4212), 0f, 408L, 51L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4213), 855720064, 504847749, null },
                    { 2067616128, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4872), 0f, 500L, 0L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4874), 229341700, 895496169, null },
                    { 2123881168, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4190), 0f, 400L, 50L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4192), 855720064, 650854836, null },
                    { 2134478152, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4296), 0f, 416L, 52L, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4298), 740440654, 697970038, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 154532968, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8286), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8291), 3010.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8288), "Signature 142345", 20658, 570008853, 1.0, 17.0 },
                    { 164331450, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8513), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8516), 103000.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8514), "Signature 1423420", 23007, 384497728, 5.0, 17.0 },
                    { 284609260, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8068), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8072), 3100.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8070), "Signature 142342", 33249, 855720064, 2.0, 24.0 },
                    { 355099723, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8615), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8618), 10003000.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8617), "Signature 1423442", 51089, 214355374, 7.0, 17.0 },
                    { 373292253, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8341), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8345), 3100.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8343), "Signature 1423410", 29034, 550902459, 2.0, 24.0 },
                    { 470433812, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8388), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8392), 4000.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8390), "Signature 142343", 70472, 303314923, 3.0, 17.0 },
                    { 485036166, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8129), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8134), 4000.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8131), "Signature 1423412", 83204, 740440654, 3.0, 17.0 },
                    { 496731988, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7988), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7992), 3010.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7990), "Signature 142345", 74277, 431315434, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 581623417, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8562), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8566), 1003000.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8564), "Signature 1423430", 47068, 230219891, 6.0, 24.0 },
                    { 657289205, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8464), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8468), 13000.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8466), "Signature 1423424", 41683, 256925256, 4.0, 24.0 },
                    { 937451420, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8188), new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8193), 13000.0, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(8191), "Signature 1423420", 35586, 144351450, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 192159944, 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3897), 689218502, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3900) },
                    { 209525611, 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3986), 1718992116, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3989) },
                    { 418293565, 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3838), 652135415, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3841) },
                    { 428601689, 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3721), 1304573229, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3723) },
                    { 451505012, 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3692), -1479396545, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3695) },
                    { 595013983, 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3868), 1857176388, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3871) },
                    { 606964243, 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3808), -33427097, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3809) },
                    { 699704031, 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3927), -1793481830, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3929) },
                    { 875246938, 258035755, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3954), 829078655, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3956) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2841), false, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2843), "CTO", 258035755 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 258035755, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6581), 307500807, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6583) });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2107613504, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4101), 282345735, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4104) },
                    { -2107613504, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4181), 537141127, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4183) },
                    { -2107613504, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3961), 924205701, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3963) },
                    { -2107613504, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3983), 808730521, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3985) },
                    { -2107613504, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4147), 418904375, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4149) },
                    { -2107613504, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3889), 455522805, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3891) },
                    { -2107613504, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3936), 265466927, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3938) },
                    { -2107613504, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4053), 970458379, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4055) },
                    { -2107613504, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4124), 946577120, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4126) },
                    { -2107613504, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3819), 966320086, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3820) },
                    { -2107613504, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3867), 154297949, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3868) },
                    { -2107613504, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4007), 833138016, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4008) },
                    { -2107613504, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3912), 479353037, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3914) },
                    { -2107613504, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3843), 333513801, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3846) },
                    { -2107613504, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4076), 721214020, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4077) },
                    { -2107613504, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4030), 349506415, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4032) },
                    { -1942446648, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4861), 211226672, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4863) },
                    { -1942446648, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4942), 274291351, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4945) },
                    { -1942446648, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4690), 286726486, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4693) },
                    { -1942446648, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4719), 790506598, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4721) },
                    { -1942446648, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4915), 425895494, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4917) },
                    { -1942446648, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4599), 248056038, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4602) },
                    { -1942446648, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4661), 558957631, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4664) },
                    { -1942446648, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4804), 487813289, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4807) },
                    { -1942446648, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4887), 167459049, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4889) },
                    { -1942446648, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4517), 376169086, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4520) },
                    { -1942446648, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4572), 271517999, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4575) },
                    { -1942446648, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4747), 242474664, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4750) },
                    { -1942446648, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4626), 928351097, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4628) },
                    { -1942446648, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4545), 912849240, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4548) },
                    { -1942446648, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4833), 416263780, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4835) },
                    { -1942446648, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4776), 133896870, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4778) },
                    { -1757403224, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7402), 274928147, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7404) },
                    { -1757403224, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7467), 699682062, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7469) },
                    { -1757403224, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7262), 292072191, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7264) },
                    { -1757403224, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7287), 655494796, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7288) },
                    { -1757403224, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7446), 707431894, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7447) },
                    { -1757403224, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7134), 411018132, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7136) },
                    { -1757403224, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7239), 495701352, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7241) },
                    { -1757403224, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7353), 573735834, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7355) },
                    { -1757403224, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7425), 945305819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7426) },
                    { -1757403224, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7059), 894540893, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7061) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1757403224, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7110), 432354540, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7112) },
                    { -1757403224, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7310), 805428925, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7311) },
                    { -1757403224, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7217), 563663404, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7219) },
                    { -1757403224, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7084), 358553889, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7085) },
                    { -1757403224, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7376), 693351769, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7379) },
                    { -1757403224, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7331), 716217037, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7333) },
                    { -1636089760, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5294), 978979083, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5297) },
                    { -1636089760, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5376), 378126133, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5379) },
                    { -1636089760, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5127), 707805843, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5130) },
                    { -1636089760, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5155), 202524216, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5157) },
                    { -1636089760, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5349), 740042190, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5351) },
                    { -1636089760, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5049), 207975739, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5051) },
                    { -1636089760, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5101), 696263791, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5103) },
                    { -1636089760, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5237), 516748918, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5239) },
                    { -1636089760, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5321), 717372446, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5323) },
                    { -1636089760, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4970), 491762173, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4972) },
                    { -1636089760, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5022), 452588565, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5025) },
                    { -1636089760, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5182), 145998485, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5185) },
                    { -1636089760, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5075), 224188933, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5077) },
                    { -1636089760, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4997), 141123274, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4999) },
                    { -1636089760, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5265), 625033210, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5268) },
                    { -1636089760, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5210), 770935778, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5212) },
                    { -1589661400, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6534), 481861254, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6536) },
                    { -1589661400, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6599), 875204092, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6601) },
                    { -1589661400, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6403), 144192018, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6405) },
                    { -1589661400, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6424), 539980863, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6425) },
                    { -1589661400, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6578), 588366187, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6580) },
                    { -1589661400, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6336), 305506275, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6338) },
                    { -1589661400, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6381), 671700256, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6382) },
                    { -1589661400, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6493), 665411348, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6495) },
                    { -1589661400, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6557), 497365352, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6558) },
                    { -1589661400, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6264), 820375030, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6267) },
                    { -1589661400, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6311), 593649930, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6313) },
                    { -1589661400, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6446), 881340801, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6449) },
                    { -1589661400, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6359), 478988132, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6361) },
                    { -1589661400, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6289), 608314394, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6291) },
                    { -1589661400, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6513), 686908673, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6515) },
                    { -1589661400, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6467), 543390392, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6469) },
                    { -1435164104, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4487), 574722772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4489) },
                    { -1435164104, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4559), 200460721, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4560) },
                    { -1435164104, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4352), 386291024, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4354) },
                    { -1435164104, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4375), 426256731, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4377) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1435164104, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4533), 438067201, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4536) },
                    { -1435164104, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4282), 846350511, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4284) },
                    { -1435164104, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4329), 389687448, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4331) },
                    { -1435164104, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4442), 343938885, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4444) },
                    { -1435164104, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4510), 952999309, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4512) },
                    { -1435164104, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4208), 191936439, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4210) },
                    { -1435164104, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4258), 473383345, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4261) },
                    { -1435164104, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4398), 831223076, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4400) },
                    { -1435164104, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4305), 476598636, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4307) },
                    { -1435164104, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4234), 211192004, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4236) },
                    { -1435164104, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4466), 906799491, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4467) },
                    { -1435164104, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4420), 625883783, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4422) },
                    { -1424536728, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5594), 492608699, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5595) },
                    { -1424536728, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5660), 778134185, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5663) },
                    { -1424536728, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5451), 611788659, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5453) },
                    { -1424536728, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5478), 443149972, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5480) },
                    { -1424536728, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5638), 859438677, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5640) },
                    { -1424536728, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5383), 215181835, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5385) },
                    { -1424536728, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5429), 424903457, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5431) },
                    { -1424536728, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5548), 725974402, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5550) },
                    { -1424536728, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5615), 413556381, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5617) },
                    { -1424536728, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5316), 333082776, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5318) },
                    { -1424536728, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5361), 930466540, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5363) },
                    { -1424536728, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5501), 145010825, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5502) },
                    { -1424536728, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5405), 932354321, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5407) },
                    { -1424536728, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5338), 985386426, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5340) },
                    { -1424536728, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5571), 413903387, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5573) },
                    { -1424536728, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5524), 568741779, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5525) },
                    { -1337464240, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3513), 601334968, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3515) },
                    { -1337464240, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3589), 197423992, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3592) },
                    { -1337464240, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3355), 697340258, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3357) },
                    { -1337464240, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3381), 667485156, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3384) },
                    { -1337464240, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3563), 351880293, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3565) },
                    { -1337464240, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3274), 430980699, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3277) },
                    { -1337464240, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3328), 801004928, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3331) },
                    { -1337464240, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3459), 241524910, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3462) },
                    { -1337464240, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3538), 484036072, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3540) },
                    { -1337464240, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3194), 353758943, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3196) },
                    { -1337464240, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3247), 951634880, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3250) },
                    { -1337464240, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3406), 585089255, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3408) },
                    { -1337464240, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3301), 886961105, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3303) },
                    { -1337464240, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3221), 531773439, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3224) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1337464240, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3485), 342134454, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3488) },
                    { -1337464240, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3432), 249067250, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3434) },
                    { -1157514200, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2655), 171316541, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2657) },
                    { -1157514200, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2726), 385494429, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2729) },
                    { -1157514200, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2494), 208113451, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2496) },
                    { -1157514200, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2522), 886390173, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2524) },
                    { -1157514200, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2700), 430963437, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2702) },
                    { -1157514200, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2413), 900949430, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2416) },
                    { -1157514200, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2466), 922822319, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2468) },
                    { -1157514200, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2600), 533199944, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2603) },
                    { -1157514200, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2679), 150293918, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2681) },
                    { -1157514200, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2340), 858166579, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2342) },
                    { -1157514200, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2391), 680711849, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2392) },
                    { -1157514200, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2549), 368301145, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2551) },
                    { -1157514200, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2439), 788867604, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2441) },
                    { -1157514200, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2366), 201958970, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2368) },
                    { -1157514200, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2627), 561763278, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2629) },
                    { -1157514200, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2574), 396467035, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2576) },
                    { -1145123608, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(480), 743843920, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(482) },
                    { -1145123608, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(563), 488239359, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(565) },
                    { -1145123608, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(310), 483434124, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(313) },
                    { -1145123608, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(339), 932777002, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(342) },
                    { -1145123608, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(535), 791230073, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(538) },
                    { -1145123608, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(226), 404888811, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(228) },
                    { -1145123608, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(281), 523884701, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(283) },
                    { -1145123608, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(424), 671636838, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(427) },
                    { -1145123608, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(508), 776397851, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(510) },
                    { -1145123608, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(149), 677224396, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(152) },
                    { -1145123608, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(201), 304380360, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(203) },
                    { -1145123608, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(367), 535401132, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(370) },
                    { -1145123608, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(253), 993646957, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(256) },
                    { -1145123608, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(176), 812748651, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(178) },
                    { -1145123608, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(453), 773989385, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(455) },
                    { -1145123608, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(395), 382132628, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(398) },
                    { -1005871752, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3718), 753268124, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3720) },
                    { -1005871752, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3794), 422538938, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3796) },
                    { -1005871752, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3569), 370367291, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3571) },
                    { -1005871752, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3592), 406946807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3594) },
                    { -1005871752, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3768), 132352623, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3770) },
                    { -1005871752, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3493), 355212132, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3495) },
                    { -1005871752, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3546), 497434064, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3548) },
                    { -1005871752, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3665), 988615677, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3668) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1005871752, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3744), 740939826, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3746) },
                    { -1005871752, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3379), 887632456, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3381) },
                    { -1005871752, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3468), 877924589, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3470) },
                    { -1005871752, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3617), 478724008, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3618) },
                    { -1005871752, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3517), 673566992, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3519) },
                    { -1005871752, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3434), 136781369, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3437) },
                    { -1005871752, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3691), 720899303, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3693) },
                    { -1005871752, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3642), 881549986, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3644) },
                    { -768655360, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4400), 445865983, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4403) },
                    { -768655360, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4488), 909682132, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4490) },
                    { -768655360, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4230), 620068499, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4233) },
                    { -768655360, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4259), 386875296, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4262) },
                    { -768655360, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4460), 386578158, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4462) },
                    { -768655360, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4145), 258630658, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4147) },
                    { -768655360, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4201), 510314445, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4204) },
                    { -768655360, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4344), 706533073, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4347) },
                    { -768655360, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4431), 647824774, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4434) },
                    { -768655360, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4056), 803091110, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4059) },
                    { -768655360, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4117), 569607110, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4119) },
                    { -768655360, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4287), 735877151, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4290) },
                    { -768655360, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4172), 265345097, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4174) },
                    { -768655360, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4086), 834348746, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4089) },
                    { -768655360, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4372), 482972780, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4374) },
                    { -768655360, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4315), 270845504, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4318) },
                    { -729304656, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6171), 551918058, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6173) },
                    { -729304656, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6239), 877169808, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6241) },
                    { -729304656, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6022), 198662205, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6024) },
                    { -729304656, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6045), 558591613, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6048) },
                    { -729304656, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6218), 947990396, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6220) },
                    { -729304656, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5950), 806571966, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5952) },
                    { -729304656, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5997), 752001297, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5999) },
                    { -729304656, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6128), 869665253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6129) },
                    { -729304656, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6194), 307539866, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6195) },
                    { -729304656, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5879), 858541781, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5881) },
                    { -729304656, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5927), 839925703, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5928) },
                    { -729304656, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6071), 511343645, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6073) },
                    { -729304656, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5972), 642810406, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5974) },
                    { -729304656, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5902), 309743567, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5906) },
                    { -729304656, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6149), 739727509, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6151) },
                    { -729304656, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6106), 479610675, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6107) },
                    { -675330504, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9177), 482261593, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9180) },
                    { -675330504, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9260), 969669965, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9263) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -675330504, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9015), 266929684, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9018) },
                    { -675330504, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9040), 231631410, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9042) },
                    { -675330504, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9233), 663988899, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9236) },
                    { -675330504, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8936), 270715864, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8938) },
                    { -675330504, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8989), 611038199, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8990) },
                    { -675330504, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9115), 285904109, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9117) },
                    { -675330504, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9206), 782737722, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9208) },
                    { -675330504, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8856), 935950323, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8858) },
                    { -675330504, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8909), 337195419, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8912) },
                    { -675330504, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9066), 421919687, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9068) },
                    { -675330504, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8962), 748632259, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8964) },
                    { -675330504, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8884), 439363087, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8887) },
                    { -675330504, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9141), 496823494, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9143) },
                    { -675330504, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9091), 251664976, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9093) },
                    { -662693128, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8188), 826563847, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8191) },
                    { -662693128, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8270), 443420160, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8273) },
                    { -662693128, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8030), 744901054, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8032) },
                    { -662693128, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8054), 332339839, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8056) },
                    { -662693128, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8243), 699665500, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8245) },
                    { -662693128, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7955), 647870085, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7957) },
                    { -662693128, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8005), 208892443, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8007) },
                    { -662693128, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8136), 137661242, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8138) },
                    { -662693128, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8214), 998612661, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8217) },
                    { -662693128, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7873), 559289577, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7876) },
                    { -662693128, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7930), 813615235, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7933) },
                    { -662693128, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8079), 475561131, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8082) },
                    { -662693128, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7980), 934131021, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7981) },
                    { -662693128, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7904), 981670639, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7906) },
                    { -662693128, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8161), 441642389, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8163) },
                    { -662693128, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8106), 220033332, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8108) },
                    { -222086192, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1341), 931433638, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1344) },
                    { -222086192, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1421), 868892110, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1423) },
                    { -222086192, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1188), 433729622, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1190) },
                    { -222086192, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1215), 881901743, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1217) },
                    { -222086192, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1394), 234365308, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1397) },
                    { -222086192, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1107), 308071035, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1109) },
                    { -222086192, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1160), 340072198, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1163) },
                    { -222086192, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1291), 442503452, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1293) },
                    { -222086192, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1368), 511170200, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1370) },
                    { -222086192, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1026), 846024174, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1028) },
                    { -222086192, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1080), 281584959, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1082) },
                    { -222086192, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1239), 792783394, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1242) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -222086192, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1134), 622912384, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1136) },
                    { -222086192, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1054), 756834923, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1056) },
                    { -222086192, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1315), 688531908, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1318) },
                    { -222086192, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1264), 488644056, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1266) },
                    { 333033344, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8623), 420657426, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8626) },
                    { 333033344, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8698), 895306026, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8700) },
                    { 333033344, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8464), 437980537, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8467) },
                    { 333033344, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8491), 552110833, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8493) },
                    { 333033344, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8674), 138252367, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8676) },
                    { 333033344, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8387), 787411710, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8389) },
                    { 333033344, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8439), 872870853, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8441) },
                    { 333033344, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8571), 747984559, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8574) },
                    { 333033344, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8649), 730514067, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8651) },
                    { 333033344, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8297), 225439230, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8300) },
                    { 333033344, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8363), 318409415, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8366) },
                    { 333033344, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8516), 250406616, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8518) },
                    { 333033344, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8412), 211258953, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8414) },
                    { 333033344, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8338), 832092475, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8341) },
                    { 333033344, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8597), 183346498, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8599) },
                    { 333033344, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8542), 463355809, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(8545) },
                    { 405545192, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6342), 868648179, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6345) },
                    { 405545192, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6415), 609321597, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6416) },
                    { 405545192, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6198), 444522868, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6200) },
                    { 405545192, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6222), 937565232, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6224) },
                    { 405545192, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6391), 953732369, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6393) },
                    { 405545192, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6120), 612976836, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6122) },
                    { 405545192, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6169), 931733190, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6171) },
                    { 405545192, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6297), 544036565, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6299) },
                    { 405545192, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6367), 753958992, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6369) },
                    { 405545192, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6052), 285535992, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6054) },
                    { 405545192, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6098), 739391978, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6100) },
                    { 405545192, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6245), 751688084, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6247) },
                    { 405545192, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6144), 705699147, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6146) },
                    { 405545192, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6074), 156105033, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6076) },
                    { 405545192, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6320), 226128700, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6322) },
                    { 405545192, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6269), 209591843, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6270) },
                    { 478689528, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3084), 232701963, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3087) },
                    { 478689528, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3166), 278820138, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3168) },
                    { 478689528, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2917), 989515339, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2919) },
                    { 478689528, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2947), 462885619, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2950) },
                    { 478689528, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3139), 567721892, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3140) },
                    { 478689528, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2835), 509836347, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2837) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 478689528, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2890), 883874551, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2892) },
                    { 478689528, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3029), 162839906, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3031) },
                    { 478689528, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3112), 788416738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3115) },
                    { 478689528, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2754), 652661137, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2756) },
                    { 478689528, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2808), 780463648, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2810) },
                    { 478689528, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2974), 604686287, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2977) },
                    { 478689528, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2862), 746854659, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2864) },
                    { 478689528, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2780), 305770686, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2782) },
                    { 478689528, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3057), 986869375, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3060) },
                    { 478689528, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3001), 124397553, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3004) },
                    { 481870600, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(43), 858726698, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(46) },
                    { 481870600, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(124), 252251877, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(126) },
                    { 481870600, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9879), 814310621, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9881) },
                    { 481870600, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9905), 298763613, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9907) },
                    { 481870600, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(97), 846472433, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(99) },
                    { 481870600, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9796), 203554484, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9799) },
                    { 481870600, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9851), 332767989, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9854) },
                    { 481870600, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9985), 905891790, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9988) },
                    { 481870600, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(70), 200963494, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(73) },
                    { 481870600, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9716), 316088092, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9718) },
                    { 481870600, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9771), 604611216, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9773) },
                    { 481870600, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9932), 831292724, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9934) },
                    { 481870600, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9824), 367584686, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9826) },
                    { 481870600, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9743), 181040322, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9746) },
                    { 481870600, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(17), 870444514, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(19) },
                    { 481870600, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9959), 436794258, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9961) },
                    { 814382056, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(916), 583094811, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(919) },
                    { 814382056, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(998), 656864819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1001) },
                    { 814382056, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(754), 246340793, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(757) },
                    { 814382056, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(782), 142172194, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(783) },
                    { 814382056, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(971), 330443855, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(974) },
                    { 814382056, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(672), 675303116, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(675) },
                    { 814382056, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(726), 592982964, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(729) },
                    { 814382056, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(865), 625851716, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(868) },
                    { 814382056, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(943), 208625223, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(946) },
                    { 814382056, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(591), 708576743, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(593) },
                    { 814382056, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(645), 545905990, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(648) },
                    { 814382056, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(806), 376704621, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(809) },
                    { 814382056, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(699), 527696521, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(702) },
                    { 814382056, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(618), 639150813, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(620) },
                    { 814382056, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(892), 160391969, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(894) },
                    { 814382056, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(834), 135020591, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(836) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 877757688, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7771), 834487556, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7773) },
                    { 877757688, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7847), 930335328, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7849) },
                    { 877757688, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7629), 132420510, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7632) },
                    { 877757688, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7654), 788252972, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7656) },
                    { 877757688, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7822), 630396336, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7824) },
                    { 877757688, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7556), 347130801, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7558) },
                    { 877757688, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7604), 180748628, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7606) },
                    { 877757688, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7722), 215588033, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7724) },
                    { 877757688, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7797), 386403661, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7799) },
                    { 877757688, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7489), 454127622, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7491) },
                    { 877757688, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7534), 412349412, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7536) },
                    { 877757688, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7678), 808187471, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7680) },
                    { 877757688, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7580), 383565590, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7582) },
                    { 877757688, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7513), 257881545, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7515) },
                    { 877757688, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7745), 180447747, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7747) },
                    { 877757688, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7700), 340245944, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7701) },
                    { 994340272, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8747), 364165709, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8749) },
                    { 994340272, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8827), 350385749, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8830) },
                    { 994340272, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8321), 430897676, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8323) },
                    { 994340272, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8344), 955767717, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8345) },
                    { 994340272, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8800), 489365928, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8803) },
                    { 994340272, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8257), 885499379, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8259) },
                    { 994340272, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8300), 754422177, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8302) },
                    { 994340272, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8692), 678737623, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8694) },
                    { 994340272, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8773), 564031769, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8775) },
                    { 994340272, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8193), 859608134, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8194) },
                    { 994340272, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8238), 239633290, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8239) },
                    { 994340272, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8491), 262339370, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8516) },
                    { 994340272, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8279), 514117556, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8280) },
                    { 994340272, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8217), 429728469, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8218) },
                    { 994340272, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8720), 732767234, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8722) },
                    { 994340272, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8664), 655925785, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8666) },
                    { 1034084040, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2233), 672238942, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2235) },
                    { 1034084040, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2314), 201747900, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2316) },
                    { 1034084040, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2065), 641499897, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2068) },
                    { 1034084040, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2091), 717326730, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2094) },
                    { 1034084040, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2286), 204848789, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2289) },
                    { 1034084040, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1982), 830726263, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1984) },
                    { 1034084040, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2037), 782716791, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2039) },
                    { 1034084040, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2179), 842015916, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2181) },
                    { 1034084040, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2259), 310398702, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2262) },
                    { 1034084040, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1901), 407083716, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1903) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1034084040, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1954), 141243742, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1957) },
                    { 1034084040, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2122), 201186773, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2125) },
                    { 1034084040, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2010), 295190963, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2012) },
                    { 1034084040, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1927), 241462250, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1929) },
                    { 1034084040, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2206), 135431089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2209) },
                    { 1034084040, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2151), 561881826, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(2154) },
                    { 1043474432, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3946), 198771319, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3948) },
                    { 1043474432, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4027), 194703750, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4030) },
                    { 1043474432, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3783), 441220898, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3786) },
                    { 1043474432, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3811), 244730300, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3814) },
                    { 1043474432, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4000), 132755529, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(4003) },
                    { 1043474432, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3699), 188341177, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3702) },
                    { 1043474432, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3755), 627098982, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3757) },
                    { 1043474432, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3893), 242593411, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3895) },
                    { 1043474432, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3973), 208952785, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3975) },
                    { 1043474432, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3616), 638087037, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3619) },
                    { 1043474432, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3672), 367233613, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3674) },
                    { 1043474432, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3840), 237229917, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3843) },
                    { 1043474432, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3726), 992876554, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3729) },
                    { 1043474432, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3644), 461638154, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3646) },
                    { 1043474432, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3919), 421583922, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3922) },
                    { 1043474432, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3867), 432660484, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(3869) },
                    { 1324035064, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5725), 215398542, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5728) },
                    { 1324035064, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5855), 566153935, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5858) },
                    { 1324035064, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5571), 587692284, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5573) },
                    { 1324035064, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5598), 572173310, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5601) },
                    { 1324035064, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5831), 864657240, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5833) },
                    { 1324035064, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5486), 902571855, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5489) },
                    { 1324035064, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5544), 588953077, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5547) },
                    { 1324035064, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5676), 796347305, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5679) },
                    { 1324035064, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5807), 433835205, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5809) },
                    { 1324035064, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5404), 355356158, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5406) },
                    { 1324035064, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5457), 168042349, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5460) },
                    { 1324035064, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5626), 399446282, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5629) },
                    { 1324035064, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5517), 615926629, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5520) },
                    { 1324035064, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5432), 535607780, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5434) },
                    { 1324035064, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5701), 596256487, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5703) },
                    { 1324035064, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5650), 634894764, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(5652) },
                    { 1445916624, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9606), 181182706, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9609) },
                    { 1445916624, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9689), 608317639, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9691) },
                    { 1445916624, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9447), 447095793, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9449) },
                    { 1445916624, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9473), 938905116, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9475) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1445916624, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9661), 460760432, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9663) },
                    { 1445916624, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9366), 328657757, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9369) },
                    { 1445916624, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9421), 448834776, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9422) },
                    { 1445916624, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9552), 462417164, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9555) },
                    { 1445916624, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9634), 491897358, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9636) },
                    { 1445916624, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9286), 405900207, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9288) },
                    { 1445916624, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9341), 322242629, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9343) },
                    { 1445916624, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9500), 718854436, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9502) },
                    { 1445916624, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9394), 704432278, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9396) },
                    { 1445916624, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9314), 965420699, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9316) },
                    { 1445916624, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9579), 459969265, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9581) },
                    { 1445916624, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9525), 949616885, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9528) },
                    { 1513790600, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1791), 202459006, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1793) },
                    { 1513790600, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1873), 131715491, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1875) },
                    { 1513790600, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1631), 577560492, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1633) },
                    { 1513790600, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1657), 565051428, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1659) },
                    { 1513790600, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1845), 757853360, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1848) },
                    { 1513790600, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1549), 576764545, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1551) },
                    { 1513790600, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1603), 981943100, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1605) },
                    { 1513790600, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1736), 346765380, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1739) },
                    { 1513790600, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1818), 749848456, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1820) },
                    { 1513790600, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1447), 434453360, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1450) },
                    { 1513790600, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1523), 209991904, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1525) },
                    { 1513790600, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1684), 609020589, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1687) },
                    { 1513790600, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1575), 978943939, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1578) },
                    { 1513790600, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1494), 280466954, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1497) },
                    { 1513790600, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1763), 375439133, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1766) },
                    { 1513790600, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1711), 360944652, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(1713) },
                    { 1612226704, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5959), 456170586, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5961) },
                    { 1612226704, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6029), 650176473, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6031) },
                    { 1612226704, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5823), 842225806, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5825) },
                    { 1612226704, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5845), 143246914, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5847) },
                    { 1612226704, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6007), 801000296, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6009) },
                    { 1612226704, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5755), 317651482, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5757) },
                    { 1612226704, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5800), 859862403, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5802) },
                    { 1612226704, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5913), 557697132, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5915) },
                    { 1612226704, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5984), 128221662, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5986) },
                    { 1612226704, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5685), 331919796, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5688) },
                    { 1612226704, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5732), 882188102, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5734) },
                    { 1612226704, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5867), 288745629, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5869) },
                    { 1612226704, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5778), 396215019, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5780) },
                    { 1612226704, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5709), 705147021, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5711) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1612226704, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5936), 357026804, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5938) },
                    { 1612226704, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5889), 528088800, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5891) },
                    { 1754655664, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6956), 846557234, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6958) },
                    { 1754655664, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7034), 527800619, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7036) },
                    { 1754655664, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6814), 564343805, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6815) },
                    { 1754655664, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6835), 744863792, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6837) },
                    { 1754655664, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7008), 501476349, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(7011) },
                    { 1754655664, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6747), 857436284, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6749) },
                    { 1754655664, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6793), 517599483, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6795) },
                    { 1754655664, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6906), 420009290, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6908) },
                    { 1754655664, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6982), 769917357, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6985) },
                    { 1754655664, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6621), 489000080, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6623) },
                    { 1754655664, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6724), 583872128, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6725) },
                    { 1754655664, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6858), 896236645, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6860) },
                    { 1754655664, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6772), 373338935, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6774) },
                    { 1754655664, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6644), 521245429, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6646) },
                    { 1754655664, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6932), 646582298, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6935) },
                    { 1754655664, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6883), 428874605, new DateTime(2024, 3, 30, 20, 5, 8, 555, DateTimeKind.Local).AddTicks(6885) },
                    { 1863577136, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5225), 397277901, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5227) },
                    { 1863577136, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5294), 130358379, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5296) },
                    { 1863577136, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5089), 649521836, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5092) },
                    { 1863577136, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5112), 822241198, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5114) },
                    { 1863577136, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5271), 660295716, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5274) },
                    { 1863577136, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5022), 809220863, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5024) },
                    { 1863577136, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5066), 659944428, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5068) },
                    { 1863577136, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5180), 811816022, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5182) },
                    { 1863577136, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5248), 362182431, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5250) },
                    { 1863577136, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4951), 135054383, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4953) },
                    { 1863577136, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4999), 838196805, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5001) },
                    { 1863577136, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5134), 460001083, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5136) },
                    { 1863577136, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5044), 497830132, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5046) },
                    { 1863577136, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4976), 510082006, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4978) },
                    { 1863577136, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5203), 542292507, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5205) },
                    { 1863577136, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5157), 399117071, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(5159) },
                    { 2123881168, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4860), 759968087, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4861) },
                    { 2123881168, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4927), 392198229, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4929) },
                    { 2123881168, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4717), 309636487, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4719) },
                    { 2123881168, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4741), 423332723, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4743) },
                    { 2123881168, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4905), 475780710, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4907) },
                    { 2123881168, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4648), 620092979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4650) },
                    { 2123881168, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4695), 522418627, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4697) },
                    { 2123881168, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4810), 325480234, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4812) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 2123881168, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4883), 650650326, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4885) },
                    { 2123881168, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4582), 728146073, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4584) },
                    { 2123881168, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4627), 749145073, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4628) },
                    { 2123881168, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4764), 286184234, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4766) },
                    { 2123881168, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4670), 659141868, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4672) },
                    { 2123881168, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4604), 632077710, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4606) },
                    { 2123881168, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4832), 911091030, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4834) },
                    { 2123881168, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4787), 973373289, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(4789) },
                    { 2134478152, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6764), 429887836, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6766) },
                    { 2134478152, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8172), 248938106, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8173) },
                    { 2134478152, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6615), 498624541, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6617) },
                    { 2134478152, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6639), 806444938, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6641) },
                    { 2134478152, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8129), 421015411, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(8131) },
                    { 2134478152, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6516), 412860014, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6518) },
                    { 2134478152, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6593), 627523498, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6595) },
                    { 2134478152, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6718), 306470151, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6720) },
                    { 2134478152, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(7138), 876780151, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(7140) },
                    { 2134478152, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6439), 960569493, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6441) },
                    { 2134478152, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6493), 520944389, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6495) },
                    { 2134478152, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6674), 876239189, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6676) },
                    { 2134478152, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6571), 697702407, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6573) },
                    { 2134478152, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6468), 746477171, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6470) },
                    { 2134478152, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6742), 146134369, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6744) },
                    { 2134478152, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6696), 465909870, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(6698) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 129364037, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5348), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5343), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5345), 279923365 },
                    { 131517491, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7050), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7047), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7048), 363337492 },
                    { 138744190, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5667), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5661), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5664), 279923365 },
                    { 160568577, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6464), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6460), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6462), 363337492 },
                    { 162048773, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7222), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7219), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7221), 279923365 },
                    { 170546372, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5457), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5454), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5456), 363337492 },
                    { 190467082, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5745), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5741), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5743), 279923365 },
                    { 211673639, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6686), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6683), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6684), 231291258 },
                    { 226496909, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5798), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5793), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5795), 231291258 },
                    { 230110120, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6143), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6139), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6141), 279923365 },
                    { 230954124, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6960), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6956), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6958), 279923365 },
                    { 232011853, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6042), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6036), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6039), 231291258 },
                    { 232114443, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6015), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6010), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6013), 363337492 },
                    { 233017609, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5088), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5083), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5085), 231291258 },
                    { 238897012, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5718), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5714), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5716), 231291258 },
                    { 259599527, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5185), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5182), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5184), 279923365 },
                    { 266712615, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6812), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6809), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6810), 231291258 },
                    { 277262267, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6165), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6162), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6164), 363337492 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 281345259, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7179), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7176), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7177), 363337492 },
                    { 285328618, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6485), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6481), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6483), 231291258 },
                    { 287565639, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6196), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6192), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6194), 231291258 },
                    { 300577287, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6374), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6369), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6371), 279923365 },
                    { 300633778, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5065), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5062), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5063), 363337492 },
                    { 304284841, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7071), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7068), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7070), 231291258 },
                    { 304549962, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6917), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6913), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6915), 363337492 },
                    { 304895897, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6526), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6523), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6524), 363337492 },
                    { 310365502, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6227), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6223), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6225), 279923365 },
                    { 321435261, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5936), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5931), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5933), 363337492 },
                    { 337635456, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6092), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6088), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6090), 363337492 },
                    { 344749364, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7407), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7404), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7405), 231291258 },
                    { 377386180, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7201), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7197), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7199), 231291258 },
                    { 378132361, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5237), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5232), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5234), 231291258 },
                    { 384777038, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6769), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6766), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6767), 279923365 },
                    { 414054549, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7428), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7424), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7426), 279923365 },
                    { 427945744, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6119), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6114), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6116), 231291258 },
                    { 438527502, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7158), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7155), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7156), 279923365 },
                    { 445308845, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7340), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7336), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7338), 231291258 },
                    { 446313017, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5263), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5258), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5260), 279923365 },
                    { 465508550, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6566), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6563), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6565), 279923365 },
                    { 473589350, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5537), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5531), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5534), 363337492 },
                    { 481697901, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7002), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6999), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7000), 231291258 },
                    { 483981103, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6546), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6543), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6545), 231291258 },
                    { 514464469, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5640), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5636), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5638), 231291258 },
                    { 518358846, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6666), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6662), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6664), 363337492 },
                    { 559922612, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5114), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5109), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5111), 279923365 },
                    { 560321717, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6325), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6321), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6323), 363337492 },
                    { 586540366, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6875), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6872), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6873), 231291258 },
                    { 593563843, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5905), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5901), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5902), 279923365 },
                    { 614072127, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5563), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5557), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5560), 231291258 },
                    { 626586340, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7138), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7134), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7136), 231291258 },
                    { 629606659, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7117), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7113), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7115), 363337492 },
                    { 630337959, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6301), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6296), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6298), 279923365 },
                    { 636450096, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5163), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5159), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5161), 231291258 },
                    { 658537023, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6616), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6613), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6614), 231291258 },
                    { 661433049, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5853), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5847), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5850), 363337492 },
                    { 679493173, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5692), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5687), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5689), 363337492 },
                    { 685693726, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6939), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6935), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6937), 231291258 },
                    { 693186135, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5962), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5958), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5959), 231291258 },
                    { 696601177, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7093), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7089), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7091), 279923365 },
                    { 711736875, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6982), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6978), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6980), 363337492 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 723427160, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5988), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5984), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5987), 279923365 },
                    { 727274694, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6728), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6725), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6726), 363337492 },
                    { 731085376, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6791), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6788), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6789), 363337492 },
                    { 732295860, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6896), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6893), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6894), 279923365 },
                    { 737538415, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4983), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4978), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(4980), 363337492 },
                    { 742757098, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5614), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5610), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5612), 363337492 },
                    { 746700981, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7028), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7024), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7026), 279923365 },
                    { 749167072, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6641), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6637), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6639), 279923365 },
                    { 750572377, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5772), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5768), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5770), 363337492 },
                    { 755768723, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5316), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5312), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5314), 231291258 },
                    { 765663805, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7318), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7314), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7316), 363337492 },
                    { 773829553, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6276), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6272), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6274), 231291258 },
                    { 778670649, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6505), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6502), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6504), 279923365 },
                    { 780387187, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6421), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6416), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6418), 231291258 },
                    { 787907637, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5022), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5019), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5020), 231291258 },
                    { 789518238, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6397), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6393), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6395), 363337492 },
                    { 795140915, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7263), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7260), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7261), 231291258 },
                    { 797792618, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6251), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6247), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6249), 363337492 },
                    { 809393038, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5290), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5285), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5287), 363337492 },
                    { 819055837, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5375), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5370), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5372), 363337492 },
                    { 820831547, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5484), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5480), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5482), 231291258 },
                    { 833899948, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6068), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6062), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6065), 279923365 },
                    { 839851305, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5402), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5398), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5399), 231291258 },
                    { 844291351, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5824), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5818), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5821), 279923365 },
                    { 844569039, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6349), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6345), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6347), 231291258 },
                    { 857937207, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7362), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7358), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7360), 279923365 },
                    { 867374269, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6594), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6590), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6592), 363337492 },
                    { 870037920, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5211), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5208), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5210), 363337492 },
                    { 877791437, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5588), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5584), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5586), 279923365 },
                    { 884843280, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5044), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5040), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5042), 279923365 },
                    { 908862497, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5138), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5134), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5136), 363337492 },
                    { 912172554, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6853), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6850), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6851), 363337492 },
                    { 917495861, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6443), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6439), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6441), 279923365 },
                    { 924251830, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7243), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7239), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7241), 363337492 },
                    { 931614187, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6833), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6829), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6831), 279923365 },
                    { 942307601, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5879), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5874), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5877), 231291258 },
                    { 946884372, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5511), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5506), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5508), 279923365 },
                    { 949247955, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5431), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5427), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(5428), 279923365 },
                    { 961006548, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6749), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6745), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6747), 231291258 },
                    { 971325343, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7385), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7380), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7382), 363337492 },
                    { 982115832, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6707), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6703), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(6705), 279923365 },
                    { 987782310, new DateTime(2024, 4, 10, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7297), 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7294), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7295), 279923365 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 125182566, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1984), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1986), 558347465 },
                    { 133792106, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(648), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(650), 396670392 },
                    { 142523094, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1166), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1168), 721177858 },
                    { 145709650, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9253), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9255), 558347465 },
                    { 151935020, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(879), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(881), 334884396 },
                    { 154180526, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8326), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8328), 334884396 },
                    { 157728781, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2075), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2077), 572746915 },
                    { 161032019, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(744), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(745), 929717431 },
                    { 162779729, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8550), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8551), 572746915 },
                    { 163178123, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(788), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(790), 572746915 },
                    { 166085490, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1961), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1963), 721177858 },
                    { 177640126, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2471), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2473), 396670392 },
                    { 182589529, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3050), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3051), 558347465 },
                    { 186639899, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8264), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8265), 396670392 },
                    { 189046823, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1276), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1277), 572746915 },
                    { 190445863, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9616), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9619), 823371891 },
                    { 195740025, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(625), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(627), 572746915 },
                    { 195844580, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(256), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(257), 823371891 },
                    { 201885506, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9103), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9105), 558347465 },
                    { 210369423, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(953), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(955), 572746915 },
                    { 211677300, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7814), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7816), 396670392 },
                    { 212503653, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2956), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2958), 823371891 },
                    { 217854845, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(671), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(673), 721177858 },
                    { 224352964, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8914), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8916), 721177858 },
                    { 224916240, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1895), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1897), 823371891 },
                    { 226878132, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1532), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1533), 929717431 },
                    { 228843614, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2186), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2188), 334884396 },
                    { 230818721, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8506), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8508), 929717431 },
                    { 234017085, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(719), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(721), 334884396 },
                    { 240510057, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2812), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2814), 572746915 },
                    { 242694546, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7938), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7940), 572746915 },
                    { 242805343, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9595), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9596), 929717431 },
                    { 248179229, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7743), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7745), 929717431 },
                    { 250288980, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9751), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9753), 929717431 },
                    { 251452134, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2737), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2739), 334884396 },
                    { 255525907, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1577), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1579), 572746915 },
                    { 255915458, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3304), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3306), 929717431 },
                    { 262545678, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(327), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(329), 721177858 },
                    { 264751489, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8050), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8052), 929717431 },
                    { 266307610, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8866), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8868), 572746915 },
                    { 268365056, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9554), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9555), 558347465 },
                    { 269674531, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9980), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9983), 396670392 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 271210759, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9333), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9335), 572746915 },
                    { 274370379, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9354), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9356), 396670392 },
                    { 274381159, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1382), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1383), 929717431 },
                    { 281597594, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(7), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(9), 721177858 },
                    { 287527417, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1425), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1426), 572746915 },
                    { 293319865, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8750), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8751), 721177858 },
                    { 296795511, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8242), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8244), 572746915 },
                    { 298588000, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9145), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9147), 929717431 },
                    { 309296643, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7898), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7899), 929717431 },
                    { 312610700, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2540), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2542), 334884396 },
                    { 314862363, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2493), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2495), 721177858 },
                    { 318090748, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8571), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8572), 396670392 },
                    { 319180337, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9638), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9640), 572746915 },
                    { 321947604, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9402), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9403), 558347465 },
                    { 323662163, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9662), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9665), 396670392 },
                    { 328247994, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7677), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7679), 721177858 },
                    { 330671530, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9273), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9275), 334884396 },
                    { 331189302, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(139), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(141), 396670392 },
                    { 332900128, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7793), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7795), 572746915 },
                    { 335587767, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3169), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3171), 396670392 },
                    { 335921720, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9931), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9933), 823371891 },
                    { 339571225, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(74), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(77), 929717431 },
                    { 340446071, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9887), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9888), 334884396 },
                    { 343478099, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8025), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8026), 334884396 },
                    { 357119397, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8960), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8963), 334884396 },
                    { 359074533, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2030), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2031), 929717431 },
                    { 360413635, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(417), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(419), 823371891 },
                    { 363070727, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9774), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9776), 823371891 },
                    { 367111749, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8221), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8222), 823371891 },
                    { 367804458, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2141), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2147), 558347465 },
                    { 369845157, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9512), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9513), 396670392 },
                    { 372363949, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8002), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8004), 558347465 },
                    { 372840395, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8073), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8074), 823371891 },
                    { 378066602, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7961), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7962), 396670392 },
                    { 378079407, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2978), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2980), 572746915 },
                    { 382740708, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8592), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8593), 721177858 },
                    { 382982569, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9167), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9169), 823371891 },
                    { 383868070, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8306), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8307), 558347465 },
                    { 387990454, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(96), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(98), 823371891 },
                    { 391001367, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(52), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(53), 334884396 },
                    { 392946040, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9057), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9059), 396670392 },
                    { 409838585, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7721), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7723), 334884396 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 412148341, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8845), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8847), 823371891 },
                    { 417322250, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9313), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9315), 823371891 },
                    { 418671294, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(833), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(835), 721177858 },
                    { 421425668, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2632), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2634), 572746915 },
                    { 427812833, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8134), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8136), 721177858 },
                    { 429054619, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7699), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7701), 558347465 },
                    { 441210245, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2563), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2565), 929717431 },
                    { 442993615, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3196), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3198), 721177858 },
                    { 447797251, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8414), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8416), 396670392 },
                    { 454641784, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1489), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1491), 558347465 },
                    { 455419292, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8439), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8441), 721177858 },
                    { 456965460, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9728), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9730), 334884396 },
                    { 458528802, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1297), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1299), 396670392 },
                    { 462622376, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3350), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3352), 572746915 },
                    { 467072360, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1693), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1694), 334884396 },
                    { 472143072, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1088), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1090), 823371891 },
                    { 490574255, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9705), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9707), 558347465 },
                    { 498777175, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1622), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1624), 721177858 },
                    { 498805742, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(394), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(396), 929717431 },
                    { 502076861, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9796), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9798), 572746915 },
                    { 502279161, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1065), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1066), 929717431 },
                    { 511979460, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(280), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(282), 572746915 },
                    { 519921864, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8155), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8157), 558347465 },
                    { 521341982, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7982), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7984), 721177858 },
                    { 532263547, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2885), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2887), 558347465 },
                    { 532499014, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8284), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8286), 721177858 },
                    { 539552141, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9124), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9125), 334884396 },
                    { 539884255, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8889), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8890), 396670392 },
                    { 541357821, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2008), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2009), 334884396 },
                    { 545701514, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9820), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9822), 396670392 },
                    { 547118168, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8485), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8487), 334884396 },
                    { 551761679, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7835), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7836), 721177858 },
                    { 556227059, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2932), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2934), 929717431 },
                    { 556622063, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3327), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3329), 823371891 },
                    { 563799264, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(766), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(768), 823371891 },
                    { 570271846, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1234), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1236), 929717431 },
                    { 571421034, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9909), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9910), 929717431 },
                    { 572702374, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1917), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1919), 572746915 },
                    { 572755392, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9843), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9845), 721177858 },
                    { 576875530, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8462), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8464), 558347465 },
                    { 594158965, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2787), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2789), 823371891 },
                    { 596101088, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9294), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9295), 929717431 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 599865083, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8176), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8178), 334884396 },
                    { 617603218, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7918), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7920), 823371891 },
                    { 618458448, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8681), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8682), 823371891 },
                    { 621938819, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8392), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8394), 572746915 },
                    { 622658892, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3026), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3028), 721177858 },
                    { 628073486, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(491), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(493), 721177858 },
                    { 641476637, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2714), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2716), 558347465 },
                    { 651034730, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2098), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2100), 396670392 },
                    { 657359246, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8773), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8775), 558347465 },
                    { 660835043, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2120), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2122), 721177858 },
                    { 661415602, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8346), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8348), 929717431 },
                    { 663733615, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2762), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2764), 929717431 },
                    { 665885215, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9574), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9576), 334884396 },
                    { 665890520, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1340), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1342), 558347465 },
                    { 669976950, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3072), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3075), 334884396 },
                    { 672144234, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8822), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8824), 929717431 },
                    { 674691413, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(975), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(977), 396670392 },
                    { 676010470, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2658), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2660), 396670392 },
                    { 676190956, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8197), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8198), 929717431 },
                    { 676518107, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8093), -1435164104, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8095), 572746915 },
                    { 678113369, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1138), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1139), 396670392 },
                    { 678391019, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1511), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1513), 334884396 },
                    { 683418346, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1756), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1758), 572746915 },
                    { 685964257, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(581), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(583), 929717431 },
                    { 689832286, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1469), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1470), 721177858 },
                    { 690101962, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2438), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2440), 572746915 },
                    { 693873125, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3099), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3101), 929717431 },
                    { 695293372, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(117), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(119), 572746915 },
                    { 696700015, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8936), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8938), 558347465 },
                    { 703067274, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8796), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8798), 334884396 },
                    { 703630978, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1210), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1212), 334884396 },
                    { 710152321, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7857), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7858), 558347465 },
                    { 711444518, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8371), 1863577136, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8373), 823371891 },
                    { 713056198, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(461), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(462), 396670392 },
                    { 713272651, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9209), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9211), 396670392 },
                    { 716413771, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(695), 478689528, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(697), 558347465 },
                    { 721991973, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(303), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(305), 396670392 },
                    { 722143143, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3121), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3124), 823371891 },
                    { 722987097, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2052), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2054), 823371891 },
                    { 732161639, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(186), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(188), 558347465 },
                    { 733239097, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2234), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2236), 823371891 },
                    { 733786703, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(603), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(605), 823371891 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 737860413, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2681), 877757688, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2683), 721177858 },
                    { 743848828, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3144), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3146), 572746915 },
                    { 769536465, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1039), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1041), 334884396 },
                    { 776653849, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1446), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1448), 396670392 },
                    { 777465340, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1188), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1190), 558347465 },
                    { 783538396, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9380), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9382), 721177858 },
                    { 783608423, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9426), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9428), 334884396 },
                    { 784336398, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1116), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1118), 572746915 },
                    { 784781262, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9533), 481870600, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9534), 721177858 },
                    { 785821519, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8655), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8657), 929717431 },
                    { 788804400, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(904), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(905), 929717431 },
                    { 794874793, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(998), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(999), 721177858 },
                    { 796296797, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9034), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9036), 572746915 },
                    { 799687668, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(811), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(813), 396670392 },
                    { 800597610, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9448), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9450), 929717431 },
                    { 801508933, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3260), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3262), 558347465 },
                    { 803960579, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8114), 2123881168, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8116), 396670392 },
                    { 813978846, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7877), -2107613504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7879), 334884396 },
                    { 814352989, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1714), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1715), 929717431 },
                    { 818854949, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(372), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(374), 334884396 },
                    { 827754401, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1601), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1602), 396670392 },
                    { 830308744, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1871), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1872), 929717431 },
                    { 834506136, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1939), -1589661400, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1940), 396670392 },
                    { 840877861, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9683), -1145123608, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9685), 721177858 },
                    { 843533516, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2587), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2589), 823371891 },
                    { 848565447, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2211), 1754655664, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2213), 929717431 },
                    { 849952548, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9955), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9957), 572746915 },
                    { 857259267, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2836), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2838), 396670392 },
                    { 860863668, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(29), -222086192, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(31), 558347465 },
                    { 865222558, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7635), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7637), 396670392 },
                    { 865694809, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(528), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(530), 558347465 },
                    { 868391496, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1826), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1828), 558347465 },
                    { 870279612, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1735), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1737), 823371891 },
                    { 872265679, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8987), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8990), 929717431 },
                    { 872993610, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8527), -1424536728, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8529), 823371891 },
                    { 878787755, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3002), 333033344, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3004), 396670392 },
                    { 892541714, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(349), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(351), 558347465 },
                    { 897840808, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(857), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(858), 558347465 },
                    { 898558430, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1256), -768655360, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1257), 823371891 },
                    { 910894111, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9231), -675330504, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9233), 721177858 },
                    { 911458893, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9013), 2134478152, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9015), 823371891 },
                    { 919815026, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1848), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1850), 334884396 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 920178651, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3283), 2067616128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(3285), 334884396 },
                    { 921731126, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9469), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9471), 823371891 },
                    { 923867369, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1799), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1801), 721177858 },
                    { 928255576, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9078), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9080), 721177858 },
                    { 935485998, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1657), 1324035064, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1659), 558347465 },
                    { 935850567, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9490), 1445916624, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9491), 572746915 },
                    { 936717014, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(231), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(233), 929717431 },
                    { 941782511, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9189), 994340272, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9191), 572746915 },
                    { 945409707, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1555), -1636089760, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1557), 823371891 },
                    { 957833479, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(209), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(210), 334884396 },
                    { 958699980, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8612), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8614), 558347465 },
                    { 962429714, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9865), 814382056, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(9867), 558347465 },
                    { 962642134, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(558), -1157514200, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(560), 334884396 },
                    { 962781090, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(163), 1513790600, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(165), 721177858 },
                    { 962834662, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1404), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1405), 823371891 },
                    { 963630242, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1361), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1363), 334884396 },
                    { 967937105, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1018), 1043474432, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1020), 558347465 },
                    { 969671148, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1776), -729304656, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1778), 396670392 },
                    { 971289377, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2908), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2910), 334884396 },
                    { 973327682, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8728), 405545192, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8730), 396670392 },
                    { 975839820, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8634), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8635), 334884396 },
                    { 981563198, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1318), -1942446648, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(1320), 721177858 },
                    { 983325507, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(439), 1034084040, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(441), 572746915 },
                    { 984628405, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8704), 1612226704, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(8706), 572746915 },
                    { 991163484, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2518), -1757403224, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2520), 558347465 },
                    { 997884401, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2862), -662693128, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(2864), 721177858 },
                    { 999174258, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7769), -1005871752, new DateTime(2024, 3, 30, 20, 5, 8, 553, DateTimeKind.Local).AddTicks(7771), 823371891 },
                    { 999224543, 0f, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(927), -1337464240, new DateTime(2024, 3, 30, 20, 5, 8, 554, DateTimeKind.Local).AddTicks(929), 823371891 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 129220142, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4448), 1787031432, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4451) },
                    { 162475563, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4348), 315971465, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4351) },
                    { 192159944, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4137), -1465613680, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4140) },
                    { 209525611, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4230), -514811704, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4233) },
                    { 269409196, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4376), -1635999061, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4377) },
                    { 428601689, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4046), 1843324362, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4049) },
                    { 451505012, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4015), 825020042, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4018) },
                    { 507789813, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4519), -1977654284, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4522) },
                    { 531870664, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4479), 1339986024, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4481) },
                    { 595013983, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4076), -226109884, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4080) },
                    { 618359960, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4106), -291501688, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4108) },
                    { 631368307, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4257), -695428532, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4260) },
                    { 631470000, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4317), -2053335149, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4319) },
                    { 699704031, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4166), -579415153, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4169) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 875246938, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4198), 2128875327, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4201) },
                    { 875526512, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4417), -1459503593, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4419) },
                    { 898022612, 352244897, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4287), -211213619, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(4289) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 341810778, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2871), false, false, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2874), "Secretariat", 352244897 },
                    { 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2940), false, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2942), "Project Manager", 352244897 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 352244897, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6610), 180099282, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6612) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 192159944, 341810778, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5320), 2023507058, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5323) },
                    { 209525611, 341810778, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5405), 903720290, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5407) },
                    { 428601689, 341810778, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5293), 232837313, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5295) },
                    { 451505012, 341810778, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5269), 2032118456, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5272) },
                    { 699704031, 341810778, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5348), -710785061, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5351) },
                    { 875246938, 341810778, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5377), 421726136, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5379) },
                    { 192159944, 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3500), 1193116194, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3503) },
                    { 269409196, 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3595), -1217318372, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3597) },
                    { 418293565, 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3471), 232379519, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3474) },
                    { 428601689, 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3442), 1273822353, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3445) },
                    { 451505012, 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3414), 119996006, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3416) },
                    { 507789813, 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3657), -1626352978, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3659) },
                    { 687752758, 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3624), -1873622677, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3627) },
                    { 699704031, 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3534), -1738199371, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3536) },
                    { 875246938, 973487301, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3564), 1598408708, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3567) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 519374762, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2972), false, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(2975), "Engineer", 973487301 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 973487301, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7792), 162194589, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7795) },
                    { 341810778, 537075709, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5643), 592823565, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5645) },
                    { 973487301, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7762), 261874064, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7764) },
                    { 973487301, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7823), 304889674, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7826) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 192159944, 519374762, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3323), -752892070, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3326) },
                    { 428601689, 519374762, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3260), -89524988, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3263) },
                    { 451505012, 519374762, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3231), -122360714, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3233) },
                    { 606964243, 519374762, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3291), -2135899201, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3293) },
                    { 699704031, 519374762, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3353), 1109753933, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3356) },
                    { 875246938, 519374762, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3382), -1063550407, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3385) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 840074487, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3001), false, true, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3003), "Designer", 519374762 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 519374762, 131481135, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7335), 439212942, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7338) },
                    { 519374762, 139394253, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7581), 282207408, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7584) },
                    { 519374762, 202270979, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6693), 234842767, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6696) },
                    { 519374762, 291820155, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6776), 307361210, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6779) },
                    { 519374762, 318195714, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7498), 586956757, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7500) },
                    { 519374762, 411446807, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6280), 488802984, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6282) },
                    { 519374762, 448331562, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6553), 656433788, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6555) },
                    { 519374762, 511886378, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7038), 540763829, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7041) },
                    { 519374762, 534512041, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7414), 597638617, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7417) },
                    { 519374762, 598788129, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6030), 361132986, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6033) },
                    { 519374762, 635481089, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6193), 374785723, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6196) },
                    { 519374762, 650787772, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6865), 551082782, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6868) },
                    { 519374762, 781885152, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6439), 977947097, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6442) },
                    { 519374762, 851326738, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6116), 936494237, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6119) },
                    { 519374762, 946188819, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7251), 508543287, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(7253) },
                    { 519374762, 987647449, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6950), 835795754, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(6953) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 192159944, 840074487, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3202), -79745647, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3205) },
                    { 428601689, 840074487, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3170), -1342523137, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3173) },
                    { 451505012, 840074487, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3118), 1884391349, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(3121) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 840074487, 262886843, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5862), 559519210, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5864) },
                    { 840074487, 437267550, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5946), 880193484, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5948) },
                    { 840074487, 611676993, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5775), 734626105, new DateTime(2024, 3, 30, 20, 5, 8, 551, DateTimeKind.Local).AddTicks(5778) }
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
                name: "IX_Issues_CreatorId",
                table: "Issues",
                column: "CreatorId");

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
