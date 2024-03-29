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
                    { 189523085, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3183), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3185), "Drainage" },
                    { 284914670, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3269), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3270), "Power Distribution" },
                    { 351323495, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3287), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3289), "Structured Cabling" },
                    { 434718477, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3165), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3167), "Potable Water" },
                    { 441949949, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3320), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3322), "CCTV" },
                    { 445773537, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3377), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3378), "Energy Efficiency" },
                    { 543616053, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3410), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3412), "TenderDocument" },
                    { 545760439, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3337), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3338), "BMS" },
                    { 551613112, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3445), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3447), "DWG Admin/Clearing" },
                    { 576029815, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3353), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3355), "Photovoltaics" },
                    { 590019909, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3462), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3464), "Project Manager Hours" },
                    { 631277612, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3218), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3220), "Fire Suppression" },
                    { 703059607, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3304), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3305), "Burglar Alarm" },
                    { 758349242, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3252), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3254), "Natural Gas" },
                    { 810686617, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3393), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3395), "Outsource" },
                    { 844458768, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3199), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3201), "Fire Detection" },
                    { 853248104, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3428), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3430), "Construction Supervision" },
                    { 888769834, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3147), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3149), "Sewage" },
                    { 897370615, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3119), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3121), "HVAC" },
                    { 897426083, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3235), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3237), "Elevators" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 192466642, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3787), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3788), "Drawings" },
                    { 552724691, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3746), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3748), "Documents" },
                    { 693780878, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3771), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3772), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 227713029, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4576), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4578), "Printing" },
                    { 346240323, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4611), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4613), "Meetings" },
                    { 545740029, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4551), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4553), "Communications" },
                    { 633047561, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4629), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4630), "Administration" },
                    { 805724788, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4664), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4665), "Hours To Be Raised" },
                    { 922585797, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4647), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4649), "Soft Copy" },
                    { 944377721, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4594), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4596), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 131753518, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9845), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9847), "Dashboard Add Project", 6 },
                    { 169386897, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9), "Edit Project On Dashboard", 12 },
                    { 237627039, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(81), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(83), "Dashboard Edit Other", 16 },
                    { 247600686, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9806), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9808), "Dashboard Assign Engineer", 4 },
                    { 284656640, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9924), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9926), "Dashboard See My Hours", 8 },
                    { 312305830, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9970), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9972), "See All Drawings", 10 },
                    { 352675779, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(45), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(47), "Dashboard Edit Discipline", 14 },
                    { 543380060, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9825), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9826), "Dashboard Assign Project Manager", 5 },
                    { 649109052, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9662), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9664), "See Dashboard Layout", 1 },
                    { 745032429, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9864), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9865), "See Admin Layout", 7 },
                    { 822289049, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9764), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9766), "Dashboard Edit My Hours", 2 },
                    { 898616068, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9943), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9944), "See All Disciplines", 9 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 932157147, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9786), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9788), "Dashboard Assign Designer", 3 },
                    { 953510643, new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9989), new DateTime(2024, 3, 29, 16, 35, 31, 806, DateTimeKind.Local).AddTicks(9990), "See All Projects", 11 },
                    { 964480610, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(63), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(64), "Dashboard Edit Deliverable", 15 },
                    { 995478138, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(27), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(28), "Display Projects Code", 13 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 335828681, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2771), "Consulting Description", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2773), "Consulting" },
                    { 553539467, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2753), "Energy Description", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2755), "Energy" },
                    { 635633376, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2713), "Buildings Description", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2715), "Buildings" },
                    { 644992721, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2735), "Infrastructure Description", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2737), "Infrastructure" },
                    { 935168455, false, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2789), "Production Management Description", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2790), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 313034011, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(270), false, false, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(272), "Customer", null },
                    { 639298585, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(252), false, false, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(254), "Guest", null },
                    { 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(101), false, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(103), "CEO", null },
                    { 903001998, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(291), false, false, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(292), "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2040), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2042), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 297831671, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1615), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1617), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 456493530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1671), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1673), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1963), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1965), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1795), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1796), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2367), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2369), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2595), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2596), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1851), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1853), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1735), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1737), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 651148487, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1460), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1462), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2308), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2310), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2133), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2135), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2483), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2484), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 714110673, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1556), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1558), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1907), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1908), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2423), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2424), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2192), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2194), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2248), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2251), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2538), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2539), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2656), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2658), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 145638671, "sparisis@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1870), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1872), 596000240 },
                    { 197576595, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2444), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2446), 810725970 },
                    { 273596434, "gdoug@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1578), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1579), 714110673 },
                    { 297571176, "pfokianou@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2386), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2388), 576940199 },
                    { 298894983, "vpax@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1757), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1758), 603758372 },
                    { 360461893, "ngal@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1984), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1986), 487067930 },
                    { 383766552, "vtza@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2153), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2154), 677693324 },
                    { 423504174, "kkotsoni@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2059), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2061), 252267971 },
                    { 451132277, "embiria@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1487), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1489), 651148487 },
                    { 489185192, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1509), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1511), 651148487 },
                    { 502118842, "haris@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2329), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2331), 661401165 },
                    { 534900021, "agretos@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2211), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2213), 837922543 },
                    { 559572984, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2675), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2677), 944013839 },
                    { 578774615, "dtsa@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1690), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1692), 456493530 },
                    { 729612877, "dtsa@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1634), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1636), 297831671 },
                    { 731805153, "vchontos@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2556), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2558), 924596368 },
                    { 808674350, "kmargeti@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2270), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2272), 898624076 },
                    { 816597634, "panperivollari@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2615), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2617), 595566531 },
                    { 872946366, "chkovras@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1925), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1927), 807742125 },
                    { 909380209, "xmanarolis@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1814), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1815), 574914758 },
                    { 992728933, "blekou@embiria.gr", new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2502), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2504), 711909562 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 309066649, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), new DateTime(2025, 7, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Test Description Project_8", new DateTime(2025, 7, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 0f, new DateTime(2025, 7, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 1500L, 12L, 10000.0, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Project_4", 252267971, null, 335828681, 0f },
                    { 529623084, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), new DateTime(2024, 6, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Test Description Project_PM", new DateTime(2024, 4, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 0f, new DateTime(2024, 5, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 1500L, 12L, null, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Project_PM", null, null, 935168455, 0f },
                    { 747067592, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), new DateTime(2024, 12, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Test Description Project_3", new DateTime(2024, 12, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 0f, new DateTime(2024, 12, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 1500L, 12L, 10000.0, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Project_3", 252267971, null, 553539467, 0f },
                    { 932560887, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), new DateTime(2024, 7, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Test Description Project_8", new DateTime(2024, 7, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 0f, new DateTime(2024, 7, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 1500L, 12L, 10000.0, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Project_2", 252267971, null, 644992721, 0f },
                    { 981895181, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), new DateTime(2024, 4, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Test Description Project_4", new DateTime(2024, 4, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 0f, new DateTime(2024, 4, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), 1500L, 12L, 10000.0, new DateTime(2024, 3, 29, 16, 35, 31, 791, DateTimeKind.Local).AddTicks(1330), "Project_1", 252267971, null, 635633376, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 649109052, 313034011, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1249), 1640354738, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1251) },
                    { 649109052, 639298585, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1230), -2077098911, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1232) },
                    { 131753518, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1114), 372510109, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1116) },
                    { 169386897, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1207), -1752230339, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1209) },
                    { 247600686, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1076), 1510445282, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1078) },
                    { 312305830, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1151), -425758387, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1153) },
                    { 543380060, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1096), 1715016447, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1097) },
                    { 649109052, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1020), -1484436352, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1022) },
                    { 822289049, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1040), 1575642839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1041) },
                    { 898616068, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1133), 222207859, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1135) },
                    { 932157147, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1058), -152686070, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1059) },
                    { 953510643, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1170), 332814538, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1172) },
                    { 995478138, 834281530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1189), -1328629558, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1190) },
                    { 312305830, 903001998, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1307), 227405264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1309) },
                    { 745032429, 903001998, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1269), 339931580, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1271) },
                    { 898616068, 903001998, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1288), -2033249723, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1290) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 953510643, 903001998, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1326), -1808705821, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1328) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(133), false, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(135), "COO", 834281530 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 834281530, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2021), 980816124, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2023) });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2088732480, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3637), 0f, 408L, 51L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3639), 747067592, 844458768, null },
                    { -2039405960, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3675), 0f, 400L, 50L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3677), 309066649, 810686617, null },
                    { -2036718216, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3655), 0f, 416L, 52L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3657), 747067592, 441949949, null },
                    { -1785068624, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3692), 0f, 408L, 51L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3693), 309066649, 545760439, null },
                    { -1775574584, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3564), 0f, 400L, 50L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3566), 932560887, 543616053, null },
                    { -1688078704, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3620), 0f, 400L, 50L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3622), 747067592, 545760439, null },
                    { -1568426264, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3727), 0f, 500L, 0L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3728), 529623084, 590019909, null },
                    { -1380978280, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3709), 0f, 416L, 52L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3710), 309066649, 844458768, null },
                    { -950546232, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3542), 0f, 416L, 52L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3544), 981895181, 189523085, null },
                    { -117647920, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3581), 0f, 408L, 51L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3583), 932560887, 703059607, null },
                    { 911402976, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3524), 0f, 408L, 51L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3526), 981895181, 576029815, null },
                    { 1728102488, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3496), 0f, 400L, 50L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3498), 981895181, 853248104, null },
                    { 2067016488, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3602), 0f, 416L, 52L, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3604), 932560887, 758349242, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 204395194, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3031), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3034), 4000.0, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3032), "Signature 1423418", 42157, 747067592, 3.0, 17.0 },
                    { 224199605, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2931), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2934), 3010.0, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2933), "Signature 142346", 86703, 981895181, 1.0, 17.0 },
                    { 475157284, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3070), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3074), 13000.0, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3072), "Signature 142344", 70362, 309066649, 4.0, 24.0 },
                    { 599296823, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2985), new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2988), 3100.0, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2986), "Signature 142342", 53126, 932560887, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 247600686, 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(676), -1742128708, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(677) },
                    { 284656640, 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(715), 1557457538, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(716) },
                    { 312305830, 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(753), -20751214, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(754) },
                    { 543380060, 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(696), -217148125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(697) },
                    { 649109052, 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(613), -894636661, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(615) },
                    { 822289049, 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(631), -989937202, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(633) },
                    { 898616068, 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(734), -1966119254, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(736) },
                    { 932157147, 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(651), 1655566488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(654) },
                    { 953510643, 239884658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(771), -1287624325, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(773) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(153), false, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(155), "CTO", 239884658 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 239884658, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2097), 648073767, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2098) });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2088732480, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8193), 220615799, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8194) },
                    { -2088732480, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8180), 610009104, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8181) },
                    { -2088732480, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8139), 461572892, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8140) },
                    { -2088732480, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8257), 301048748, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8258) },
                    { -2088732480, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8308), 236148529, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8309) },
                    { -2088732480, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8153), 689049894, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8154) },
                    { -2088732480, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8123), 422339426, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8125) },
                    { -2088732480, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8244), 158884493, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8245) },
                    { -2088732480, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8205), 443127806, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8206) },
                    { -2088732480, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8282), 712632299, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8284) },
                    { -2088732480, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8167), 995778822, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8168) },
                    { -2088732480, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8270), 979622953, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8271) },
                    { -2088732480, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8218), 823036723, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8220) },
                    { -2088732480, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8231), 363749913, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8232) },
                    { -2088732480, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8295), 769697386, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8296) },
                    { -2088732480, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8320), 983597234, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8322) },
                    { -2039405960, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8611), 282684457, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8612) },
                    { -2039405960, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8598), 307022053, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8599) },
                    { -2039405960, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8559), 166970610, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8560) },
                    { -2039405960, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8674), 359144782, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8676) },
                    { -2039405960, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8726), 539290855, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8727) },
                    { -2039405960, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8572), 386100691, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8573) },
                    { -2039405960, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8545), 369262344, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8547) },
                    { -2039405960, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8662), 594015309, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8663) },
                    { -2039405960, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8623), 268658769, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8625) },
                    { -2039405960, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8700), 509484640, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8701) },
                    { -2039405960, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8585), 510354166, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8586) },
                    { -2039405960, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8688), 275612091, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8689) },
                    { -2039405960, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8636), 233975329, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8637) },
                    { -2039405960, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8649), 354743729, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8650) },
                    { -2039405960, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8713), 460743190, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8714) },
                    { -2039405960, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8740), 802765841, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8741) },
                    { -2036718216, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8399), 656868528, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8400) },
                    { -2036718216, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8386), 749333988, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8387) },
                    { -2036718216, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8348), 527337593, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8349) },
                    { -2036718216, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8467), 390399575, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8468) },
                    { -2036718216, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8519), 163034584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8520) },
                    { -2036718216, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8360), 829451725, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8362) },
                    { -2036718216, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8333), 170777081, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8335) },
                    { -2036718216, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8454), 363375049, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8455) },
                    { -2036718216, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8412), 462347698, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8413) },
                    { -2036718216, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8493), 385674272, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8494) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2036718216, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8373), 388954514, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8374) },
                    { -2036718216, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8479), 447823591, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8481) },
                    { -2036718216, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8424), 694580461, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8426) },
                    { -2036718216, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8441), 679917091, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8442) },
                    { -2036718216, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8506), 814569259, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8507) },
                    { -2036718216, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8532), 474772687, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8533) },
                    { -1785068624, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8819), 701370850, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8820) },
                    { -1785068624, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8806), 672710918, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8807) },
                    { -1785068624, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8766), 875583104, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8767) },
                    { -1785068624, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8887), 199301237, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8888) },
                    { -1785068624, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8939), 327680679, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8940) },
                    { -1785068624, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8779), 622341636, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8781) },
                    { -1785068624, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8753), 456943595, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8754) },
                    { -1785068624, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8874), 441088841, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8875) },
                    { -1785068624, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8832), 569436654, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8833) },
                    { -1785068624, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8912), 735164695, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8914) },
                    { -1785068624, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8792), 888454001, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8794) },
                    { -1785068624, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8900), 400492602, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8901) },
                    { -1785068624, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8848), 233449152, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8849) },
                    { -1785068624, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8861), 478937993, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8862) },
                    { -1785068624, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8926), 736962658, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8927) },
                    { -1785068624, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8952), 875031500, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8953) },
                    { -1775574584, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7164), 178059289, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7166) },
                    { -1775574584, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7148), 994846454, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7150) },
                    { -1775574584, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7097), 401058412, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7098) },
                    { -1775574584, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7252), 865416062, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7254) },
                    { -1775574584, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7318), 932691758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7320) },
                    { -1775574584, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7113), 453224907, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7115) },
                    { -1775574584, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7080), 471611756, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7082) },
                    { -1775574584, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7235), 686404440, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7237) },
                    { -1775574584, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7181), 644800744, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7183) },
                    { -1775574584, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7285), 286289799, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7287) },
                    { -1775574584, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7131), 823730626, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7132) },
                    { -1775574584, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7269), 183422355, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7271) },
                    { -1775574584, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7202), 654402151, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7204) },
                    { -1775574584, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7219), 207688713, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7220) },
                    { -1775574584, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7302), 370092795, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7303) },
                    { -1775574584, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7335), 773726960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7336) },
                    { -1688078704, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7981), 896927161, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7982) },
                    { -1688078704, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7968), 671515190, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7969) },
                    { -1688078704, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7907), 394118655, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7908) },
                    { -1688078704, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8045), 228530992, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8046) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1688078704, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8097), 429374161, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8098) },
                    { -1688078704, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7923), 269419373, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7925) },
                    { -1688078704, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7890), 709123089, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7892) },
                    { -1688078704, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8032), 494990414, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8034) },
                    { -1688078704, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7994), 798787842, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7995) },
                    { -1688078704, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8071), 513401822, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8072) },
                    { -1688078704, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7940), 930249644, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7942) },
                    { -1688078704, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8058), 616419611, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8059) },
                    { -1688078704, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8007), 357671035, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8008) },
                    { -1688078704, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8020), 676587104, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8021) },
                    { -1688078704, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8084), 628529483, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8085) },
                    { -1688078704, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8110), 670740463, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8111) },
                    { -1380978280, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9029), 149931196, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9030) },
                    { -1380978280, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9016), 897476002, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9017) },
                    { -1380978280, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8978), 729502358, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8979) },
                    { -1380978280, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9094), 690946598, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9096) },
                    { -1380978280, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9146), 820653708, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9148) },
                    { -1380978280, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8991), 680254779, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8992) },
                    { -1380978280, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8965), 453135341, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(8966) },
                    { -1380978280, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9082), 888583492, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9083) },
                    { -1380978280, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9042), 204531937, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9043) },
                    { -1380978280, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9120), 764721879, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9121) },
                    { -1380978280, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9003), 558266998, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9005) },
                    { -1380978280, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9107), 243412922, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9108) },
                    { -1380978280, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9055), 369748823, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9056) },
                    { -1380978280, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9068), 842943720, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9070) },
                    { -1380978280, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9133), 130589556, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9134) },
                    { -1380978280, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9160), 568044465, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(9161) },
                    { -950546232, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6896), 898916060, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6898) },
                    { -950546232, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6880), 536031241, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6881) },
                    { -950546232, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6829), 779992577, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6831) },
                    { -950546232, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6980), 155897446, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6982) },
                    { -950546232, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7046), 986629439, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7048) },
                    { -950546232, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6846), 250021205, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6848) },
                    { -950546232, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6811), 690456832, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6813) },
                    { -950546232, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6963), 825936386, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6965) },
                    { -950546232, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6914), 815979162, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6915) },
                    { -950546232, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7013), 916749915, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7015) },
                    { -950546232, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6863), 182024318, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6864) },
                    { -950546232, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6997), 323266219, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6998) },
                    { -950546232, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6930), 469062021, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6932) },
                    { -950546232, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6947), 492803595, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6948) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -950546232, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7030), 753997045, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7031) },
                    { -950546232, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7064), 196836285, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7065) },
                    { -117647920, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7436), 309322909, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7437) },
                    { -117647920, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7419), 864337358, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7421) },
                    { -117647920, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7370), 703358988, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7371) },
                    { -117647920, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7519), 762014099, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7521) },
                    { -117647920, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7585), 160351903, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7587) },
                    { -117647920, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7386), 337351313, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7388) },
                    { -117647920, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7351), 240122159, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7353) },
                    { -117647920, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7503), 225914551, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7504) },
                    { -117647920, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7452), 753762002, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7454) },
                    { -117647920, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7552), 938982592, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7554) },
                    { -117647920, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7403), 818323426, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7404) },
                    { -117647920, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7536), 968308050, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7537) },
                    { -117647920, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7469), 408225796, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7470) },
                    { -117647920, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7486), 266751230, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7487) },
                    { -117647920, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7569), 825131556, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7570) },
                    { -117647920, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7602), 930823792, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7603) },
                    { 911402976, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6622), 630357698, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6623) },
                    { 911402976, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6605), 295341687, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6607) },
                    { 911402976, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6556), 885603145, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6557) },
                    { 911402976, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6711), 407757300, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6713) },
                    { 911402976, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6778), 331540308, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6780) },
                    { 911402976, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6572), 440214376, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6574) },
                    { 911402976, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6537), 636243083, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6539) },
                    { 911402976, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6690), 541213732, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6692) },
                    { 911402976, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6639), 972023649, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6641) },
                    { 911402976, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6744), 462209550, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6746) },
                    { 911402976, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6589), 498432841, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6590) },
                    { 911402976, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6728), 739979301, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6729) },
                    { 911402976, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6656), 216068521, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6658) },
                    { 911402976, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6673), 652305727, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6675) },
                    { 911402976, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6761), 632489092, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6763) },
                    { 911402976, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6795), 332153376, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6796) },
                    { 1728102488, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6351), 297056281, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6353) },
                    { 1728102488, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6333), 680700620, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6335) },
                    { 1728102488, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6281), 241777633, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6283) },
                    { 1728102488, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6437), 669013364, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6439) },
                    { 1728102488, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6503), 894245118, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6505) },
                    { 1728102488, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6299), 201047237, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6300) },
                    { 1728102488, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6254), 983843436, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6256) },
                    { 1728102488, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6420), 316380846, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6422) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1728102488, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6368), 824713688, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6369) },
                    { 1728102488, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6470), 644039130, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6472) },
                    { 1728102488, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6316), 307270429, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6318) },
                    { 1728102488, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6454), 730313538, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6455) },
                    { 1728102488, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6384), 673851543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6386) },
                    { 1728102488, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6402), 882169523, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6404) },
                    { 1728102488, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6487), 518265326, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6489) },
                    { 1728102488, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6520), 180050667, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6521) },
                    { 2067016488, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7706), 814397549, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7707) },
                    { 2067016488, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7689), 755206538, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7690) },
                    { 2067016488, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7635), 781773679, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7636) },
                    { 2067016488, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7791), 646489616, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7792) },
                    { 2067016488, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7857), 654316143, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7859) },
                    { 2067016488, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7655), 730869038, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7657) },
                    { 2067016488, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7618), 865411324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7620) },
                    { 2067016488, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7774), 275770015, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7776) },
                    { 2067016488, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7722), 867600580, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7724) },
                    { 2067016488, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7824), 983194999, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7825) },
                    { 2067016488, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7672), 866088428, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7674) },
                    { 2067016488, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7807), 192707210, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7809) },
                    { 2067016488, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7739), 503745905, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7741) },
                    { 2067016488, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7757), 335758068, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7758) },
                    { 2067016488, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7840), 955367849, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7842) },
                    { 2067016488, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7874), 141678406, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(7875) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 185188869, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4066), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4063), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4065), 693780878 },
                    { 199628410, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4048), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4045), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4047), 552724691 },
                    { 219803263, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4395), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4392), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4393), 693780878 },
                    { 246053203, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4413), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4410), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4411), 192466642 },
                    { 250210800, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4251), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4248), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4250), 192466642 },
                    { 263278147, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4377), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4374), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4375), 552724691 },
                    { 284775384, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3811), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3806), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3807), 552724691 },
                    { 313520202, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4306), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4302), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4304), 192466642 },
                    { 330251837, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4341), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4338), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4340), 693780878 },
                    { 336748837, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4270), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4267), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4268), 552724691 },
                    { 337954904, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4120), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4117), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4119), 693780878 },
                    { 435555820, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4474), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4471), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4472), 192466642 },
                    { 551970485, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4214), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4210), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4212), 552724691 },
                    { 569484282, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4494), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4490), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4491), 552724691 },
                    { 575959222, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4012), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4009), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4011), 693780878 },
                    { 587515680, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4141), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4137), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4139), 192466642 },
                    { 604131793, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3835), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3831), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3833), 693780878 },
                    { 620863179, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3914), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3911), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3912), 192466642 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 651907484, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4177), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4174), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4176), 693780878 },
                    { 691142872, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4084), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4081), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4082), 192466642 },
                    { 691404684, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4532), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4528), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4530), 192466642 },
                    { 692266568, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4233), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4230), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4231), 693780878 },
                    { 710235169, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4359), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4356), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4357), 192466642 },
                    { 716065334, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4288), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4284), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4286), 693780878 },
                    { 795367982, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3932), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3929), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3931), 552724691 },
                    { 804905892, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3893), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3890), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3892), 693780878 },
                    { 818409133, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3970), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3966), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3968), 192466642 },
                    { 833112119, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3951), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3947), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3949), 693780878 },
                    { 847807870, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4159), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4156), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4157), 552724691 },
                    { 855858014, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4103), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4099), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4101), 552724691 },
                    { 861014979, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4436), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4433), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4435), 552724691 },
                    { 862460989, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3993), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3990), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3991), 552724691 },
                    { 870400344, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4514), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4510), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4512), 693780878 },
                    { 880959641, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3856), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3853), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3854), 192466642 },
                    { 884400997, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4031), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4027), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4029), 192466642 },
                    { 928128659, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3875), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3872), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(3874), 552724691 },
                    { 938567850, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4456), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4452), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4453), 693780878 },
                    { 973598876, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4196), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4193), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4194), 192466642 },
                    { 984405178, new DateTime(2024, 4, 9, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4324), 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4320), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4322), 552724691 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124194013, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5204), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5205), 944377721 },
                    { 130384648, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4950), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4951), 227713029 },
                    { 132822195, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5221), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5223), 346240323 },
                    { 132916409, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6149), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6151), 227713029 },
                    { 143489351, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5701), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5703), 346240323 },
                    { 151386415, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5717), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5719), 633047561 },
                    { 152894296, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4844), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4845), 944377721 },
                    { 174101333, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5617), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5619), 922585797 },
                    { 176675324, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5330), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5332), 944377721 },
                    { 182723143, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5018), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5019), 922585797 },
                    { 207219634, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5963), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5964), 633047561 },
                    { 224722192, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6047), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6048), 944377721 },
                    { 237029737, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5136), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5137), 922585797 },
                    { 239841290, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5877), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5879), 805724788 },
                    { 239927300, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5566), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5568), 944377721 },
                    { 240106448, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5549), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5551), 227713029 },
                    { 246162458, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5382), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5384), 922585797 },
                    { 252364614, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6203), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6204), 633047561 },
                    { 253612603, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4899), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4900), 922585797 },
                    { 266856669, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6063), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6065), 346240323 },
                    { 269505076, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4792), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4793), 805724788 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 270601287, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5979), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5981), 922585797 },
                    { 271659164, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5416), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5417), 545740029 },
                    { 294356685, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4705), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4707), 227713029 },
                    { 295446200, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5651), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5653), 545740029 },
                    { 297782117, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5273), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5275), 805724788 },
                    { 306182094, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5001), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5002), 633047561 },
                    { 315297281, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4682), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4684), 545740029 },
                    { 318088524, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6182), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6184), 346240323 },
                    { 330043142, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5238), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5239), 633047561 },
                    { 335510949, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6219), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6221), 922585797 },
                    { 337949584, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6166), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6167), 944377721 },
                    { 338542925, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5685), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5686), 944377721 },
                    { 351267820, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6030), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6032), 227713029 },
                    { 376162958, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5861), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5862), 922585797 },
                    { 384812454, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5826), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5828), 346240323 },
                    { 386485405, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5843), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5845), 633047561 },
                    { 387691426, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5809), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5811), 944377721 },
                    { 387791414, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5482), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5484), 633047561 },
                    { 397539846, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4740), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4742), 346240323 },
                    { 401942465, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5946), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5947), 346240323 },
                    { 402800933, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5911), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5913), 227713029 },
                    { 414678051, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5347), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5348), 346240323 },
                    { 426102803, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5498), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5500), 922585797 },
                    { 443727644, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6131), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6133), 545740029 },
                    { 444675765, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5256), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5257), 922585797 },
                    { 458879799, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5119), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5121), 633047561 },
                    { 459925650, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5996), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5997), 805724788 },
                    { 470527398, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4723), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4724), 944377721 },
                    { 486304562, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5895), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5896), 545740029 },
                    { 488895998, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5366), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5367), 633047561 },
                    { 493519010, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4966), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4968), 944377721 },
                    { 500004920, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5790), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5792), 227713029 },
                    { 502289967, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6080), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6082), 633047561 },
                    { 507030073, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5432), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5434), 227713029 },
                    { 518433653, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6235), -1568426264, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6237), 805724788 },
                    { 518809602, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5052), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5053), 545740029 },
                    { 519361673, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5154), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5155), 805724788 },
                    { 539995880, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5187), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5189), 227713029 },
                    { 553750388, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5929), -1785068624, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5930), 944377721 },
                    { 608510662, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5583), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5585), 346240323 },
                    { 651440865, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5068), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5070), 227713029 },
                    { 668778185, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4984), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4986), 346240323 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 681858630, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6097), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6098), 922585797 },
                    { 693487295, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4865), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4866), 346240323 },
                    { 695830480, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4933), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4935), 545740029 },
                    { 707726032, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5171), -117647920, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5172), 545740029 },
                    { 743167183, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5449), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5450), 944377721 },
                    { 753314107, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4775), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4776), 922585797 },
                    { 778064431, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4882), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4883), 633047561 },
                    { 784081483, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5751), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5752), 805724788 },
                    { 787911140, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4915), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4917), 805724788 },
                    { 819358559, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5634), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5636), 805724788 },
                    { 835139676, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5102), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5104), 346240323 },
                    { 837392421, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5034), -950546232, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5036), 805724788 },
                    { 838952211, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5465), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5467), 346240323 },
                    { 844782149, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5734), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5736), 922585797 },
                    { 848214297, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6013), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6015), 545740029 },
                    { 859880296, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5601), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5602), 633047561 },
                    { 876488304, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5399), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5400), 805724788 },
                    { 885027424, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5314), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5315), 227713029 },
                    { 897509860, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5532), -2088732480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5533), 545740029 },
                    { 904491719, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5768), -2039405960, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5770), 545740029 },
                    { 912798266, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4757), 1728102488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4758), 633047561 },
                    { 913113146, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5515), -1688078704, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5517), 805724788 },
                    { 919323222, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4825), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4827), 227713029 },
                    { 939226224, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5296), 2067016488, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5297), 545740029 },
                    { 956295632, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4808), 911402976, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(4810), 545740029 },
                    { 957540283, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6113), -1380978280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(6115), 805724788 },
                    { 958044290, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5086), -1775574584, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5087), 944377721 },
                    { 981362146, 0f, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5668), -2036718216, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(5669), 227713029 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 131753518, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(846), 1878547608, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(848) },
                    { 169386897, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(942), -1151901296, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(944) },
                    { 237627039, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1002), -606908312, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1004) },
                    { 284656640, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(865), -37157642, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(867) },
                    { 312305830, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(904), 1672421247, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(905) },
                    { 352675779, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(963), -1321206344, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(965) },
                    { 543380060, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(828), 592452410, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(829) },
                    { 649109052, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(790), 6580796, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(792) },
                    { 822289049, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(809), -2010076784, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(811) },
                    { 898616068, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(885), 2105229816, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(887) },
                    { 953510643, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(923), 1821425927, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(924) },
                    { 964480610, 663198714, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(983), 1970648271, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(984) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 499260551, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(173), false, false, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(174), "Secretariat", 663198714 },
                    { 905190942, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(192), false, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(194), "Project Manager", 663198714 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 663198714, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2114), 311289835, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2116) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 284656640, 499260551, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1383), 1417559859, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1385) },
                    { 312305830, 499260551, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1421), -207905656, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1423) },
                    { 649109052, 499260551, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1345), -1611138140, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1346) },
                    { 822289049, 499260551, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1363), -479541568, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1365) },
                    { 898616068, 499260551, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1402), 482813078, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1404) },
                    { 953510643, 499260551, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1440), -1900147648, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1441) },
                    { 247600686, 905190942, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(540), -1900116211, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(541) },
                    { 284656640, 905190942, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(558), 1765711805, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(560) },
                    { 312305830, 905190942, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(595), 51942785, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(597) },
                    { 649109052, 905190942, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(502), 1393976633, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(504) },
                    { 822289049, 905190942, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(521), 1167233081, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(522) },
                    { 898616068, 905190942, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(577), 83198210, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(578) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 587344151, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(212), false, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(214), "Engineer", 905190942 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 905190942, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2830), 100255883, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2832) },
                    { 905190942, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2810), 246546572, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2812) },
                    { 499260551, 651148487, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1529), 487883036, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1531) },
                    { 905190942, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2848), 241183480, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2850) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 284656640, 587344151, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(444), -1590267905, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(446) },
                    { 312305830, 587344151, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(482), -217986979, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(484) },
                    { 649109052, 587344151, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(385), -1622293879, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(386) },
                    { 822289049, 587344151, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(404), -1779162056, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(406) },
                    { 898616068, 587344151, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(463), 338898038, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(465) },
                    { 932157147, 587344151, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(424), 1810231191, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(426) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 951301476, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(233), false, true, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(234), "Designer", 587344151 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 587344151, 252267971, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2079), 264202540, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2080) },
                    { 587344151, 487067930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2002), 578635091, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2004) },
                    { 587344151, 574914758, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1833), 809958280, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1834) },
                    { 587344151, 576940199, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2404), 409158674, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2406) },
                    { 587344151, 595566531, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2638), 463752930, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2639) },
                    { 587344151, 596000240, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1888), 649288285, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1890) },
                    { 587344151, 603758372, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1775), 185141575, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1776) },
                    { 587344151, 661401165, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2347), 920273595, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2349) },
                    { 587344151, 677693324, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2171), 634129721, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2172) },
                    { 587344151, 711909562, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2520), 519900603, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2521) },
                    { 587344151, 807742125, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1945), 413578966, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1946) },
                    { 587344151, 810725970, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2464), 186715193, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2465) },
                    { 587344151, 837922543, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2229), 643835551, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2231) },
                    { 587344151, 898624076, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2288), 557272854, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2290) },
                    { 587344151, 924596368, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2574), 136551582, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2576) },
                    { 587344151, 944013839, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2693), 785411663, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(2695) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 284656640, 951301476, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(365), 255761033, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(367) },
                    { 649109052, 951301476, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(310), 895604081, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(312) },
                    { 822289049, 951301476, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(346), 2122895583, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(348) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 951301476, 297831671, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1652), 655536580, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1654) },
                    { 951301476, 456493530, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1712), 491626022, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1714) },
                    { 951301476, 714110673, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1596), 160758786, new DateTime(2024, 3, 29, 16, 35, 31, 807, DateTimeKind.Local).AddTicks(1598) }
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
