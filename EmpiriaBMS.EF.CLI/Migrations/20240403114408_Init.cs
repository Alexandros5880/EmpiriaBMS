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
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Issues_Users_CreatorId",
                        column: x => x.CreatorId,
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyTime_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyTime_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_Users_DailyUserId",
                        column: x => x.DailyUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_Users_PersonalUserId",
                        column: x => x.PersonalUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DailyTime_Users_TrainingUserId",
                        column: x => x.TrainingUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    { 164385389, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1023), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1025), "Structured Cabling" },
                    { 184189092, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1090), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1091), "Energy Efficiency" },
                    { 290350167, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1143), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1145), "DWG Admin/Clearing" },
                    { 331354428, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(884), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(885), "HVAC" },
                    { 390116240, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1158), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1159), "Project Manager Hours" },
                    { 409266178, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(923), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(924), "Potable Water" },
                    { 482509020, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1050), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1051), "CCTV" },
                    { 501166454, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1064), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1065), "BMS" },
                    { 628937181, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1102), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1104), "Outsource" },
                    { 651723815, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(940), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(941), "Drainage" },
                    { 655146632, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(968), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(970), "Fire Suppression" },
                    { 669499730, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(982), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(983), "Elevators" },
                    { 687142022, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1077), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1078), "Photovoltaics" },
                    { 717305095, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(995), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(996), "Natural Gas" },
                    { 727931962, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(909), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(910), "Sewage" },
                    { 731022631, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1116), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1117), "TenderDocument" },
                    { 764445405, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(953), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(955), "Fire Detection" },
                    { 867770896, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1037), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1038), "Burglar Alarm" },
                    { 885615685, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1130), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1132), "Construction Supervision" },
                    { 951621683, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1009), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1010), "Power Distribution" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 264194405, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1734), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1735), "Drawings" },
                    { 657063491, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1720), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1722), "Calculations" },
                    { 834534160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1700), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1701), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 207022497, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3424), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3426), "Soft Copy" },
                    { 498609019, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3409), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3410), "Administration" },
                    { 716360954, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3379), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3380), "On-Site" },
                    { 722064785, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3343), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3344), "Communications" },
                    { 724276678, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3364), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3365), "Printing" },
                    { 775558853, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3438), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3440), "Hours To Be Erased" },
                    { 852909449, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3392), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3393), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 130091889, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7248), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7249), "Dashboard Edit Other", 16 },
                    { 142482156, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7099), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7101), "Dashboard Add Project", 6 },
                    { 210009642, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7355), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7357), "See Active Delayed Project Types Counter KPI", 23 },
                    { 249695161, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7323), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7324), "See Employee Turnover KPI", 21 },
                    { 271958213, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7069), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7070), "Dashboard Assign Engineer", 4 },
                    { 357392399, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7279), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7280), "See Hours Per Role KPI", 18 },
                    { 377058179, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7130), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7131), "Dashboard See My Hours", 8 },
                    { 399056263, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7189), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7190), "Edit Project On Dashboard", 12 },
                    { 412283420, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7115), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7116), "See Admin Layout", 7 },
                    { 479578946, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7053), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7054), "Dashboard Assign Designer", 3 },
                    { 482303752, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7308), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7310), "See All Projects Missed DeadLine KPI", 20 },
                    { 502867731, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7035), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7036), "Dashboard Edit My Hours", 2 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 535075931, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7262), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7265), "Dashboard See KPIS", 17 },
                    { 604322297, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7160), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7161), "See All Drawings", 10 },
                    { 674379550, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7083), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7085), "Dashboard Assign Project Manager", 5 },
                    { 698742277, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7294), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7295), "See Active Delayed Projects KPI", 19 },
                    { 705377858, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7219), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7220), "Dashboard Edit Discipline", 14 },
                    { 710856637, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7175), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7176), "See All Projects", 11 },
                    { 837327415, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(6928), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(6930), "See Dashboard Layout", 1 },
                    { 854265727, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7144), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7146), "See All Disciplines", 9 },
                    { 859859026, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7203), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7205), "Display Projects Code", 13 },
                    { 876989901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7338), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7339), "See My Projects Missed DeadLine KPI", 22 },
                    { 877357391, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7233), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7234), "Dashboard Edit Deliverable", 15 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 188084384, true, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(263), "Infrastructure Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(264), "Infrastructure" },
                    { 423946154, true, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(240), "Buildings Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(242), "Buildings" },
                    { 751518333, true, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(292), "Consulting Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(293), "Consulting" },
                    { 797155677, false, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(310), "Production Management Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(311), "Production Management" },
                    { 961011244, true, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(277), "Energy Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(279), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7514), false, false, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7515), "Admin", null },
                    { 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7372), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7373), "CEO", null },
                    { 822198159, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7485), false, false, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7486), "Guest", null },
                    { 871737531, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7499), false, false, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7500), "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9503), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9505), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(15), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(16), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(195), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(197), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9582), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9584), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 396069851, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(372), "Admin", "Alexandros", "Platanios", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(373), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com", null },
                    { 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9273), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9275), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(149), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(151), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9429), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9430), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 530043390, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9127), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9129), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 590012631, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9056), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9058), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9783), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9784), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9694), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9696), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(104), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(106), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9874), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9875), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9919), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9920), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 825284728, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8834), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8836), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 835483227, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8965), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8967), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(59), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(61), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9970), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9971), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9199), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9202), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9828), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9830), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 339226810, "ngal@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9612), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9615), 310844693 },
                    { 348259806, "gdoug@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8993), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8995), 835483227 },
                    { 414022111, "vtza@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9798), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9799), 604231330 },
                    { 428785915, "dtsa@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9084), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9086), 590012631 },
                    { 462665831, "ogiannoglou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(29), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(31), 221583835 },
                    { 478869674, "ntriantafyllou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(210), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(212), 222029997 },
                    { 480495823, "kkotsoni@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9720), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9721), 667465284 },
                    { 597598690, "empiriasoft@empiriasoftplat.onmicrosoft.com", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(387), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(388), 396069851 },
                    { 631486737, "kmargeti@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9891), 693577134 },
                    { 637049161, "pfokianou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9985), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9987), 989427526 },
                    { 643162329, "sparisis@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9452), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9454), 523335748 },
                    { 647500833, "dtsa@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9151), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9153), 530043390 },
                    { 685942768, "agretos@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9844), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9845), 997222832 },
                    { 724124329, "vchontos@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(119), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(121), 689402813 },
                    { 761469600, "blekou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(75), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(76), 980722489 },
                    { 797299087, "panperivollari@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(165), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(166), 481435429 },
                    { 821570621, "xmanarolis@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9381), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9383), 423324696 },
                    { 841051034, "embiria@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8871), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8873), 825284728 },
                    { 843479288, "vpax@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9225), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9227), 995610588 },
                    { 847734435, "akonstantinidou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8906), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8909), 825284728 },
                    { 861757778, "haris@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9934), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9935), 804725668 },
                    { 989853979, "chkovras@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9529), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9531), 159794805 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "StartDate", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 198329397, false, 1, "D-22-163", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 3, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_3", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_3", 995610588, new DateTime(2024, 2, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 423946154, 0f },
                    { 360899757, true, 2, "D-22-164", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 2, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_10", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_4", 667465284, new DateTime(2023, 12, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 188084384, 0f },
                    { 547254174, true, 4, "D-22-164", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2025, 8, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_4", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_4", 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 751518333, 0f },
                    { 564441100, false, 1, "D-22-169", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2023, 9, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_14", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_9", 995610588, new DateTime(2023, 2, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 961011244, 0f },
                    { 658695706, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 7, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_PM", 0f, 1500L, 12L, null, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_PM", null, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 797155677, 0f },
                    { 667712873, false, 1, "D-22-167", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2023, 11, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_10", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_7", 667465284, new DateTime(2023, 6, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 423946154, 0f },
                    { 682107086, false, 3, "D-22-165", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 1, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_6", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_5", 804725668, new DateTime(2023, 10, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 961011244, 0f },
                    { 694095980, true, 4, "D-22-166", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2023, 12, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_20", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_6", 995610588, new DateTime(2023, 8, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 751518333, 0f },
                    { 749387009, false, 1, "D-22-161", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 5, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_5", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_1", 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 423946154, 0f },
                    { 882693604, true, 2, "D-22-162", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 8, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_4", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_2", 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 188084384, 0f },
                    { 887658868, false, 3, "D-22-163", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2025, 1, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_18", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_3", 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 961011244, 0f },
                    { 905642845, true, 1, "D-22-168", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2023, 10, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_36", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_8", 804725668, new DateTime(2023, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 188084384, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 412283420, 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8674), -1305652130, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8675) },
                    { 604322297, 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8706), 760194527, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8707) },
                    { 710856637, 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8721), 785047361, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8722) },
                    { 854265727, 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8689), 882743837, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8690) },
                    { 142482156, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8393), 1754683011, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8395) },
                    { 210009642, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8628), -363811085, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8629) },
                    { 249695161, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8612), 712464656, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8613) },
                    { 271958213, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8345), 1208850084, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8347) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 357392399, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8566), -1381845514, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8567) },
                    { 399056263, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8521), 1304261190, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8523) },
                    { 479578946, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8324), 605662250, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8326) },
                    { 482303752, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8597), -2097053801, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8598) },
                    { 502867731, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8302), -423880892, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8304) },
                    { 535075931, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8547), 1177069883, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8549) },
                    { 604322297, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8440), 1864093055, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8443) },
                    { 674379550, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8369), 397584532, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8371) },
                    { 698742277, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8581), -612792058, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8583) },
                    { 710856637, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8468), -1439005315, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8470) },
                    { 837327415, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8280), 166833064, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8282) },
                    { 854265727, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8416), -900380366, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8418) },
                    { 859859026, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8495), 725686466, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8497) },
                    { 837327415, 822198159, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8643), 725156186, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8645) },
                    { 837327415, 871737531, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8659), -1918373431, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8660) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7396), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7398), "COO", 532804602 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 532804602, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9667), 973571426, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9670) },
                    { 290102901, 396069851, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(401), 244861720, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(403) },
                    { 290102901, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(416), 308731576, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(417) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2126765688, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1310), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1311), 887658868, 331354428, null },
                    { -2043627592, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1353), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1355), 547254174, 731022631, null },
                    { -2039382160, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1578), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1580), 667712873, 731022631, null },
                    { -2018807360, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1262), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1263), 882693604, 867770896, null },
                    { -1765060216, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1192), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1194), 749387009, 717305095, null },
                    { -1466298128, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1593), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1594), 905642845, 501166454, null },
                    { -1461728600, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1324), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1325), 887658868, 409266178, null },
                    { -1387564456, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1625), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1626), 905642845, 482509020, null },
                    { -1374660912, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1436), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1437), 360899757, 482509020, null },
                    { -1304128112, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1395), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1396), 198329397, 651723815, null },
                    { -1072777880, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1408), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1410), 198329397, 951621683, null },
                    { -1025676768, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1422), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1423), 360899757, 628937181, null },
                    { -1004363320, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1367), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1368), 547254174, 727931962, null },
                    { -821294672, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1610), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1612), 905642845, 184189092, null },
                    { -766589960, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1232), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1233), 749387009, 764445405, null },
                    { -669688480, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1667), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1668), 564441100, 687142022, null },
                    { -13046320, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1381), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1382), 198329397, 731022631, null },
                    { 48500184, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1494), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1495), 682107086, 331354428, null },
                    { 55276880, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1653), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1654), 564441100, 717305095, null },
                    { 761217232, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1639), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1640), 564441100, 867770896, null },
                    { 853549824, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1536), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1537), 694095980, 867770896, null },
                    { 858113144, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1452), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1453), 360899757, 717305095, null },
                    { 903388600, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1550), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1551), 667712873, 687142022, null },
                    { 1014884392, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1247), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1248), 882693604, 482509020, null },
                    { 1249013408, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1296), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1297), 887658868, 885615685, null },
                    { 1338483552, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1218), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1219), 749387009, 731022631, null },
                    { 1476244320, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1480), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1482), 682107086, 731022631, null },
                    { 1514478272, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1466), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1468), 682107086, 628937181, null },
                    { 1735143456, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1277), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1279), 882693604, 501166454, null },
                    { 1786998136, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1339), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1341), 547254174, 885615685, null },
                    { 1922016840, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1564), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1565), 667712873, 482509020, null },
                    { 1961561656, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1508), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1510), 694095980, 727931962, null },
                    { 2058347776, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1522), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1524), 694095980, 655146632, null },
                    { 2091716744, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1682), 0f, 500L, 0L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1683), 658695706, 390116240, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 146696663, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(803), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(806), 103000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(805), "Signature 1423425", 81416, 667712873, 5.0, 17.0 },
                    { 380678347, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(714), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(716), 3100.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(715), "Signature 142346", 64709, 360899757, 2.0, 24.0 },
                    { 422248645, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(589), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(591), 4000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(590), "Signature 142343", 49829, 887658868, 3.0, 17.0 },
                    { 444653229, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(833), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(836), 1003000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(834), "Signature 1423430", 74720, 905642845, 6.0, 24.0 },
                    { 467307575, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(506), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(509), 3010.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(507), "Signature 142345", 34954, 749387009, 1.0, 17.0 },
                    { 513310416, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(554), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(556), 3100.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(555), "Signature 1423410", 39512, 882693604, 2.0, 24.0 },
                    { 603505183, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(744), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(747), 4000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(745), "Signature 1423415", 20947, 682107086, 3.0, 17.0 },
                    { 694633497, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(774), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(777), 13000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(775), "Signature 142348", 57542, 694095980, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 749276467, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(862), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(865), 10003000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(864), "Signature 1423414", 78590, 564441100, 7.0, 17.0 },
                    { 910211743, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(619), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(622), 13000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(621), "Signature 142348", 11157, 547254174, 4.0, 24.0 },
                    { 978781555, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(679), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(682), 3010.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(680), "Signature 142346", 26783, 198329397, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 271958213, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7872), -1189180151, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7874) },
                    { 377058179, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7903), -2122727129, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7904) },
                    { 479578946, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7856), -1355621008, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7857) },
                    { 502867731, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7841), -246021506, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7842) },
                    { 604322297, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7933), 1125439061, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7935) },
                    { 674379550, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7888), -1083012268, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7889) },
                    { 710856637, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7949), 1792343790, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7950) },
                    { 837327415, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7826), -170748742, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7827) },
                    { 854265727, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7918), -183194027, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7919) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7411), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7412), "CTO", 692744033 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 692744033, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9753), 543913233, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9755) });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2126765688, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8416), 191833669, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8417) },
                    { -2126765688, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8526), 799449099, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8527) },
                    { -2126765688, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8581), 517121614, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8583) },
                    { -2126765688, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8430), 249431689, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8431) },
                    { -2126765688, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8385), 362884497, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8386) },
                    { -2126765688, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8567), 166419031, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8569) },
                    { -2126765688, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8398), 438613537, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8400) },
                    { -2126765688, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8458), 767513509, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8459) },
                    { -2126765688, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8444), 965517265, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8445) },
                    { -2126765688, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8553), 493780500, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8555) },
                    { -2126765688, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8485), 781410009, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8486) },
                    { -2126765688, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8499), 694196502, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8500) },
                    { -2126765688, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8540), 433617525, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8541) },
                    { -2126765688, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8512), 429488598, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8514) },
                    { -2126765688, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8371), 961276025, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8373) },
                    { -2126765688, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8471), 927403803, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8472) },
                    { -2043627592, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9129), 673107828, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9131) },
                    { -2043627592, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9242), 215955371, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9243) },
                    { -2043627592, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9297), 575641429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9298) },
                    { -2043627592, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9143), 923287453, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9144) },
                    { -2043627592, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9102), 628070861, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9104) },
                    { -2043627592, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9283), 448731189, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9284) },
                    { -2043627592, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9116), 622057938, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9117) },
                    { -2043627592, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9170), 766183762, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9171) },
                    { -2043627592, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9156), 161343063, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9157) },
                    { -2043627592, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9269), 669475397, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9271) },
                    { -2043627592, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9198), 134692638, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9199) },
                    { -2043627592, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9215), 308954316, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9216) },
                    { -2043627592, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9256), 127528433, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9257) },
                    { -2043627592, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9229), 279876497, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9230) },
                    { -2043627592, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9089), 337465411, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9090) },
                    { -2043627592, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9184), 190960429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9185) },
                    { -2039382160, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2706), 392205745, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2708) },
                    { -2039382160, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2827), 977514955, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2828) },
                    { -2039382160, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2886), 508123705, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2888) },
                    { -2039382160, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2720), 389739181, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2721) },
                    { -2039382160, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2679), 683763831, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2680) },
                    { -2039382160, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2868), 876347052, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2869) },
                    { -2039382160, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2692), 595215093, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2694) },
                    { -2039382160, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2760), 743597023, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2761) },
                    { -2039382160, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2747), 343296125, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2748) },
                    { -2039382160, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2854), 460330700, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2855) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2039382160, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2787), 909266853, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2788) },
                    { -2039382160, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2800), 403898136, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2802) },
                    { -2039382160, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2840), 444829017, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2842) },
                    { -2039382160, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2814), 635451291, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2815) },
                    { -2039382160, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2665), 325279538, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2666) },
                    { -2039382160, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2774), 768113359, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2775) },
                    { -2018807360, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7753), 960645466, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7754) },
                    { -2018807360, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7863), 288952942, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7864) },
                    { -2018807360, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7917), 600304234, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7919) },
                    { -2018807360, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7766), 231328729, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7768) },
                    { -2018807360, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7726), 939868974, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7727) },
                    { -2018807360, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7904), 517234666, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7905) },
                    { -2018807360, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7740), 338114435, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7741) },
                    { -2018807360, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7794), 811415681, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7795) },
                    { -2018807360, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7780), 536998742, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7782) },
                    { -2018807360, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7890), 948227671, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7891) },
                    { -2018807360, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7821), 682984176, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7823) },
                    { -2018807360, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7836), 150418441, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7837) },
                    { -2018807360, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7876), 527215027, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7878) },
                    { -2018807360, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7849), 244632067, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7850) },
                    { -2018807360, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7711), 948377260, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7713) },
                    { -2018807360, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7808), 393269274, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7809) },
                    { -1765060216, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6865), 997410370, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6867) },
                    { -1765060216, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6978), 418750600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6979) },
                    { -1765060216, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7032), 820576933, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7034) },
                    { -1765060216, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6879), 904990428, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6880) },
                    { -1765060216, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6838), 787113164, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6839) },
                    { -1765060216, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7018), 234045912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7020) },
                    { -1765060216, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6852), 922222088, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6853) },
                    { -1765060216, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6907), 358071669, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6908) },
                    { -1765060216, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6893), 250473566, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6895) },
                    { -1765060216, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7005), 218208110, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7006) },
                    { -1765060216, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6934), 447867930, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6935) },
                    { -1765060216, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6948), 318378699, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6950) },
                    { -1765060216, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6991), 691464607, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6993) },
                    { -1765060216, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6962), 202071200, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6964) },
                    { -1765060216, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6813), 157474850, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6815) },
                    { -1765060216, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6920), 751648719, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6922) },
                    { -1466298128, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2942), 660327090, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2943) },
                    { -1466298128, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3062), 852304353, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3063) },
                    { -1466298128, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3114), 736004042, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3115) },
                    { -1466298128, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2955), 764644757, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2956) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1466298128, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2915), 636719313, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2916) },
                    { -1466298128, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3101), 726032683, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3102) },
                    { -1466298128, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2928), 975188951, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2929) },
                    { -1466298128, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2982), 306488295, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2983) },
                    { -1466298128, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2968), 581289605, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2970) },
                    { -1466298128, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3088), 540094299, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3089) },
                    { -1466298128, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3009), 771594491, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3010) },
                    { -1466298128, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3022), 983278535, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3024) },
                    { -1466298128, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3075), 371522987, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3076) },
                    { -1466298128, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3049), 780208056, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3050) },
                    { -1466298128, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2900), 919563755, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2902) },
                    { -1466298128, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2995), 681556038, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2997) },
                    { -1461728600, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8636), 533063285, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8638) },
                    { -1461728600, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8800), 940437042, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8802) },
                    { -1461728600, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8855), 490958204, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8857) },
                    { -1461728600, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8650), 880081095, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8651) },
                    { -1461728600, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8609), 296095516, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8611) },
                    { -1461728600, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8842), 992693018, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8843) },
                    { -1461728600, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8623), 197470819, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8624) },
                    { -1461728600, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8677), 927977569, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8678) },
                    { -1461728600, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8663), 267960297, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8665) },
                    { -1461728600, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8828), 204958009, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8829) },
                    { -1461728600, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8704), 228678634, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8706) },
                    { -1461728600, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8767), 702807067, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8769) },
                    { -1461728600, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8814), 571323323, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8816) },
                    { -1461728600, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8787), 217832847, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8788) },
                    { -1461728600, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8595), 423801066, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8596) },
                    { -1461728600, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8690), 916594527, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8692) },
                    { -1387564456, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3382), 792634378, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3383) },
                    { -1387564456, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3487), 930132625, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3488) },
                    { -1387564456, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3539), 132674392, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3540) },
                    { -1387564456, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3395), 311884763, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3396) },
                    { -1387564456, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3356), 307607887, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3357) },
                    { -1387564456, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3526), 934794164, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3527) },
                    { -1387564456, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3369), 997531758, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3370) },
                    { -1387564456, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3421), 513855163, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3423) },
                    { -1387564456, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3408), 439416748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3410) },
                    { -1387564456, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3513), 237979438, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3514) },
                    { -1387564456, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3447), 606993764, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3449) },
                    { -1387564456, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3461), 643848200, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3462) },
                    { -1387564456, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3500), 316432661, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3501) },
                    { -1387564456, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3474), 525160549, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3475) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1387564456, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3342), 322110376, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3343) },
                    { -1387564456, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3434), 511147639, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3436) },
                    { -1374660912, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(452), 875603473, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(453) },
                    { -1374660912, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(559), 250332015, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(561) },
                    { -1374660912, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(613), 570899236, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(615) },
                    { -1374660912, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(465), 186221258, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(467) },
                    { -1374660912, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(425), 766735897, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(426) },
                    { -1374660912, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(600), 204103268, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(601) },
                    { -1374660912, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(438), 866127864, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(440) },
                    { -1374660912, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(492), 288066636, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(493) },
                    { -1374660912, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(479), 856394041, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(480) },
                    { -1374660912, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(586), 729221136, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(588) },
                    { -1374660912, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(519), 823111945, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(520) },
                    { -1374660912, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(532), 557657693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(534) },
                    { -1374660912, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(573), 670810594, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(574) },
                    { -1374660912, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(546), 201705391, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(547) },
                    { -1374660912, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(407), 536509644, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(408) },
                    { -1374660912, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(505), 268617777, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(507) },
                    { -1304128112, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9791), 227670356, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9792) },
                    { -1304128112, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9901), 470426329, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9902) },
                    { -1304128112, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9955), 940421358, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9956) },
                    { -1304128112, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9804), 396698974, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9806) },
                    { -1304128112, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9763), 191810991, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9765) },
                    { -1304128112, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9942), 518298764, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9943) },
                    { -1304128112, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9777), 817077441, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9778) },
                    { -1304128112, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9832), 479011780, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9833) },
                    { -1304128112, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9818), 261306514, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9819) },
                    { -1304128112, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9928), 961284592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9929) },
                    { -1304128112, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9859), 378752760, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9860) },
                    { -1304128112, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9873), 916368874, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9875) },
                    { -1304128112, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9914), 677015087, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9916) },
                    { -1304128112, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9887), 687462373, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9888) },
                    { -1304128112, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9750), 702740612, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9751) },
                    { -1304128112, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9845), 807030145, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9847) },
                    { -1072777880, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(10), 984533269, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(11) },
                    { -1072777880, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(124), 144555584, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(126) },
                    { -1072777880, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(177), 993878137, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(179) },
                    { -1072777880, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(23), 510703754, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(25) },
                    { -1072777880, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9983), 373265313, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9984) },
                    { -1072777880, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(164), 245144421, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(165) },
                    { -1072777880, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9996), 571446493, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9998) },
                    { -1072777880, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(54), 562880411, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(55) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1072777880, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(37), 259799705, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(38) },
                    { -1072777880, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(151), 848805657, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(152) },
                    { -1072777880, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(84), 499678566, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(85) },
                    { -1072777880, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(97), 834208772, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(99) },
                    { -1072777880, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(137), 204669500, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(139) },
                    { -1072777880, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(111), 434468982, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(112) },
                    { -1072777880, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9969), 228540616, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9970) },
                    { -1072777880, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(70), 337752888, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(71) },
                    { -1025676768, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(233), 934556782, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(234) },
                    { -1025676768, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(340), 270627528, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(341) },
                    { -1025676768, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(393), 802706892, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(394) },
                    { -1025676768, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(246), 867395295, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(247) },
                    { -1025676768, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(205), 238346610, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(206) },
                    { -1025676768, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(380), 763320303, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(381) },
                    { -1025676768, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(219), 759945833, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(220) },
                    { -1025676768, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(273), 921987970, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(274) },
                    { -1025676768, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(259), 785248801, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(261) },
                    { -1025676768, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(367), 199324890, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(368) },
                    { -1025676768, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(300), 716071325, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(301) },
                    { -1025676768, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(313), 260054352, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(314) },
                    { -1025676768, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(353), 889110274, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(354) },
                    { -1025676768, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(326), 358241036, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(328) },
                    { -1025676768, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(191), 444968362, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(192) },
                    { -1025676768, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(286), 205179350, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(288) },
                    { -1004363320, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9351), 245312995, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9352) },
                    { -1004363320, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9459), 700963837, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9461) },
                    { -1004363320, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9513), 386896261, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9515) },
                    { -1004363320, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9365), 773715190, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9366) },
                    { -1004363320, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9324), 723514253, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9325) },
                    { -1004363320, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9500), 978039626, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9501) },
                    { -1004363320, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9338), 950409027, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9339) },
                    { -1004363320, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9392), 510841284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9393) },
                    { -1004363320, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9378), 157265759, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9379) },
                    { -1004363320, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9486), 380028612, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9488) },
                    { -1004363320, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9418), 967103507, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9420) },
                    { -1004363320, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9432), 603007105, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9433) },
                    { -1004363320, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9473), 477284622, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9474) },
                    { -1004363320, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9446), 138586754, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9447) },
                    { -1004363320, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9310), 246101032, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9312) },
                    { -1004363320, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9405), 305653009, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9406) },
                    { -821294672, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3167), 231023498, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3168) },
                    { -821294672, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3272), 472752979, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3273) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -821294672, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3328), 476672123, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3329) },
                    { -821294672, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3180), 580408460, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3182) },
                    { -821294672, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3141), 734463800, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3143) },
                    { -821294672, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3315), 810425828, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3316) },
                    { -821294672, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3154), 607120993, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3156) },
                    { -821294672, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3206), 482376137, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3208) },
                    { -821294672, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3193), 376986429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3195) },
                    { -821294672, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3298), 306083665, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3300) },
                    { -821294672, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3233), 345702151, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3234) },
                    { -821294672, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3246), 443341989, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3247) },
                    { -821294672, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3285), 383803327, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3287) },
                    { -821294672, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3259), 899903279, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3260) },
                    { -821294672, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3128), 930466672, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3129) },
                    { -821294672, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3220), 266707222, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3221) },
                    { -766589960, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7311), 591479261, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7312) },
                    { -766589960, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7421), 593341423, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7422) },
                    { -766589960, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7475), 786683585, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7477) },
                    { -766589960, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7325), 460100054, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7326) },
                    { -766589960, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7284), 798593618, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7285) },
                    { -766589960, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7461), 380873041, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7463) },
                    { -766589960, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7297), 854142770, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7299) },
                    { -766589960, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7352), 895980251, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7354) },
                    { -766589960, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7339), 430908431, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7340) },
                    { -766589960, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7448), 735624777, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7449) },
                    { -766589960, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7380), 923235503, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7381) },
                    { -766589960, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7393), 983015216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7394) },
                    { -766589960, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7434), 579976911, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7435) },
                    { -766589960, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7407), 898817736, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7408) },
                    { -766589960, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7269), 619535616, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7271) },
                    { -766589960, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7366), 393484258, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7367) },
                    { -669688480, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4025), 718003533, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4026) },
                    { -669688480, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4130), 541239155, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4131) },
                    { -669688480, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4186), 570743561, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4187) },
                    { -669688480, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4038), 887048780, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4039) },
                    { -669688480, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3998), 686333810, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3999) },
                    { -669688480, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4173), 448637605, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4174) },
                    { -669688480, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4011), 698198553, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4012) },
                    { -669688480, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4064), 154684076, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4065) },
                    { -669688480, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4051), 209784791, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4052) },
                    { -669688480, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4159), 743268421, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4161) },
                    { -669688480, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4090), 292410715, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4092) },
                    { -669688480, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4104), 507377133, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4105) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -669688480, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4146), 934966150, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4147) },
                    { -669688480, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4117), 981294653, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4118) },
                    { -669688480, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3979), 722828470, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3980) },
                    { -669688480, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4077), 487006524, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4078) },
                    { -13046320, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9568), 259135582, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9570) },
                    { -13046320, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9681), 186866251, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9683) },
                    { -13046320, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9736), 906152324, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9738) },
                    { -13046320, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9582), 242452382, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9583) },
                    { -13046320, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9541), 733668310, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9542) },
                    { -13046320, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9723), 402047453, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9724) },
                    { -13046320, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9555), 721734554, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9556) },
                    { -13046320, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9609), 534468562, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9611) },
                    { -13046320, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9595), 452454756, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9597) },
                    { -13046320, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9709), 275962409, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9710) },
                    { -13046320, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9640), 524669281, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9642) },
                    { -13046320, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9654), 556030090, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9655) },
                    { -13046320, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9695), 422003585, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9697) },
                    { -13046320, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9668), 422800842, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9669) },
                    { -13046320, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9527), 517817817, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9528) },
                    { -13046320, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9623), 398234551, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9624) },
                    { 48500184, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1326), 752672115, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1328) },
                    { 48500184, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1434), 495817267, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1436) },
                    { 48500184, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1488), 339598917, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1489) },
                    { 48500184, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1340), 583964093, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1341) },
                    { 48500184, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1299), 913683224, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1301) },
                    { 48500184, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1475), 442025486, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1476) },
                    { 48500184, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1313), 915981737, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1314) },
                    { 48500184, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1367), 928551773, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1368) },
                    { 48500184, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1353), 433855919, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1355) },
                    { 48500184, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1461), 133434342, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1462) },
                    { 48500184, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1394), 550346407, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1395) },
                    { 48500184, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1407), 848559115, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1409) },
                    { 48500184, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1448), 578999851, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1449) },
                    { 48500184, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1421), 841400224, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1422) },
                    { 48500184, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1286), 851529399, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1287) },
                    { 48500184, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1380), 145309695, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1382) },
                    { 55276880, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3807), 911190400, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3808) },
                    { 55276880, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3912), 562589477, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3914) },
                    { 55276880, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3965), 716643490, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3966) },
                    { 55276880, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3820), 421897634, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3821) },
                    { 55276880, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3781), 684350295, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3782) },
                    { 55276880, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3952), 326418245, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3953) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 55276880, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3794), 959633372, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3795) },
                    { 55276880, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3847), 954411469, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3848) },
                    { 55276880, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3833), 237083837, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3835) },
                    { 55276880, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3939), 980337712, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3940) },
                    { 55276880, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3873), 739304200, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3875) },
                    { 55276880, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3886), 334432709, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3887) },
                    { 55276880, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3926), 248098462, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3927) },
                    { 55276880, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3899), 274933475, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3901) },
                    { 55276880, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3768), 806953735, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3769) },
                    { 55276880, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3860), 157066438, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3861) },
                    { 761217232, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3591), 918675366, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3593) },
                    { 761217232, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3697), 726238855, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3699) },
                    { 761217232, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3754), 697639354, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3755) },
                    { 761217232, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3605), 535742816, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3606) },
                    { 761217232, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3565), 195323095, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3567) },
                    { 761217232, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3741), 568328228, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3742) },
                    { 761217232, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3578), 705718876, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3580) },
                    { 761217232, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3632), 394828058, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3633) },
                    { 761217232, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3619), 604966802, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3620) },
                    { 761217232, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3727), 479597960, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3728) },
                    { 761217232, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3658), 955983293, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3659) },
                    { 761217232, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3671), 505379500, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3673) },
                    { 761217232, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3711), 794912940, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3712) },
                    { 761217232, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3684), 296896675, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3686) },
                    { 761217232, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3552), 268116057, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3554) },
                    { 761217232, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3645), 912898057, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3646) },
                    { 853549824, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2042), 685076935, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2043) },
                    { 853549824, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2152), 692543338, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2154) },
                    { 853549824, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2207), 216185739, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2208) },
                    { 853549824, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2056), 249266717, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2057) },
                    { 853549824, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2010), 162737631, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2011) },
                    { 853549824, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2193), 634967945, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2195) },
                    { 853549824, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2028), 881252761, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2029) },
                    { 853549824, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2084), 233573439, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2085) },
                    { 853549824, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2070), 762616719, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2071) },
                    { 853549824, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2180), 343429817, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2181) },
                    { 853549824, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2112), 600312692, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2113) },
                    { 853549824, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2125), 255207986, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2126) },
                    { 853549824, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2166), 228287637, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2167) },
                    { 853549824, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2139), 822150130, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2140) },
                    { 853549824, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1996), 837384798, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1997) },
                    { 853549824, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2098), 405204031, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2099) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 858113144, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(667), 920637398, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(669) },
                    { 858113144, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(778), 611861761, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(780) },
                    { 858113144, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(833), 701507392, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(834) },
                    { 858113144, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(681), 695273302, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(682) },
                    { 858113144, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(640), 391247924, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(642) },
                    { 858113144, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(819), 468389065, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(821) },
                    { 858113144, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(654), 315019082, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(655) },
                    { 858113144, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(711), 353995030, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(712) },
                    { 858113144, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(697), 962225044, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(698) },
                    { 858113144, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(806), 926788162, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(807) },
                    { 858113144, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(738), 836716436, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(739) },
                    { 858113144, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(751), 939498009, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(753) },
                    { 858113144, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(792), 379637870, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(793) },
                    { 858113144, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(765), 618234908, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(766) },
                    { 858113144, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(627), 384353842, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(628) },
                    { 858113144, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(724), 392191570, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(726) },
                    { 903388600, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2262), 996285064, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2263) },
                    { 903388600, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2372), 945909765, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2373) },
                    { 903388600, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2427), 864147538, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2428) },
                    { 903388600, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2276), 458026091, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2277) },
                    { 903388600, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2234), 363200617, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2236) },
                    { 903388600, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2413), 595976074, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2414) },
                    { 903388600, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2248), 236534567, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2249) },
                    { 903388600, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2303), 500587565, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2304) },
                    { 903388600, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2289), 137351644, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2291) },
                    { 903388600, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2399), 588137404, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2401) },
                    { 903388600, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2331), 758601383, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2332) },
                    { 903388600, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2344), 675177592, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2346) },
                    { 903388600, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2386), 227722953, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2387) },
                    { 903388600, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2358), 125279315, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2359) },
                    { 903388600, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2221), 296185213, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2222) },
                    { 903388600, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2316), 314393972, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2318) },
                    { 1014884392, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7530), 919353632, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7531) },
                    { 1014884392, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7643), 274517080, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7644) },
                    { 1014884392, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7698), 606526240, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7699) },
                    { 1014884392, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7543), 930254369, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7545) },
                    { 1014884392, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7502), 648644156, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7504) },
                    { 1014884392, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7684), 614230217, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7685) },
                    { 1014884392, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7516), 327051785, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7517) },
                    { 1014884392, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7571), 185793595, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7572) },
                    { 1014884392, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7557), 721647111, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7558) },
                    { 1014884392, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7670), 733700388, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7672) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1014884392, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7598), 836264403, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7600) },
                    { 1014884392, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7615), 763873440, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7617) },
                    { 1014884392, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7657), 953998567, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7658) },
                    { 1014884392, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7630), 490746864, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7631) },
                    { 1014884392, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7489), 322757009, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7490) },
                    { 1014884392, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7585), 511415976, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7586) },
                    { 1249013408, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8194), 443832636, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8195) },
                    { 1249013408, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8302), 286847410, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8303) },
                    { 1249013408, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8358), 927364989, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8359) },
                    { 1249013408, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8207), 139521992, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8208) },
                    { 1249013408, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8166), 952573830, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8167) },
                    { 1249013408, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8343), 914890852, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8345) },
                    { 1249013408, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8180), 505549618, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8181) },
                    { 1249013408, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8234), 410136393, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8236) },
                    { 1249013408, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8221), 792301735, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8222) },
                    { 1249013408, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8330), 703627544, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8331) },
                    { 1249013408, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8261), 270479392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8263) },
                    { 1249013408, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8275), 311251764, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8276) },
                    { 1249013408, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8316), 210196172, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8317) },
                    { 1249013408, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8288), 838218245, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8290) },
                    { 1249013408, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8152), 802214206, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8154) },
                    { 1249013408, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8248), 802373307, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8249) },
                    { 1338483552, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7089), 659709600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7090) },
                    { 1338483552, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7198), 836641227, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7199) },
                    { 1338483552, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7256), 142212362, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7257) },
                    { 1338483552, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7102), 950456154, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7104) },
                    { 1338483552, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7061), 405138564, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7062) },
                    { 1338483552, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7242), 471639006, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7243) },
                    { 1338483552, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7075), 515673644, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7076) },
                    { 1338483552, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7130), 327468463, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7131) },
                    { 1338483552, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7116), 294931716, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7118) },
                    { 1338483552, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7229), 651368708, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7230) },
                    { 1338483552, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7157), 513028312, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7158) },
                    { 1338483552, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7171), 657725993, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7172) },
                    { 1338483552, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7215), 834599650, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7216) },
                    { 1338483552, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7185), 348406940, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7186) },
                    { 1338483552, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7046), 293422701, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7047) },
                    { 1338483552, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7143), 272622492, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7145) },
                    { 1476244320, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1104), 937721119, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1105) },
                    { 1476244320, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1218), 754961908, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1220) },
                    { 1476244320, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1272), 254540183, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1274) },
                    { 1476244320, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1122), 280613632, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1123) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1476244320, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1077), 593178666, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1078) },
                    { 1476244320, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1259), 150208835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1260) },
                    { 1476244320, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1090), 171927549, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1092) },
                    { 1476244320, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1149), 417198771, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1151) },
                    { 1476244320, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1135), 996499580, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1137) },
                    { 1476244320, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1245), 891994853, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1246) },
                    { 1476244320, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1177), 440911271, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1178) },
                    { 1476244320, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1190), 584092100, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1191) },
                    { 1476244320, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1232), 861985088, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1233) },
                    { 1476244320, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1205), 549415747, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1206) },
                    { 1476244320, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1063), 330835784, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1065) },
                    { 1476244320, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1163), 867532972, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1164) },
                    { 1514478272, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(887), 805704415, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(888) },
                    { 1514478272, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(995), 873456227, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(996) },
                    { 1514478272, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1049), 327097051, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1051) },
                    { 1514478272, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(901), 479749911, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(902) },
                    { 1514478272, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(860), 449727897, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(861) },
                    { 1514478272, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1036), 418580951, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1037) },
                    { 1514478272, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(873), 189632848, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(875) },
                    { 1514478272, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(927), 682769908, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(929) },
                    { 1514478272, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(914), 728261357, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(915) },
                    { 1514478272, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1022), 467115441, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1023) },
                    { 1514478272, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(955), 904940582, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(956) },
                    { 1514478272, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(968), 496236945, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(970) },
                    { 1514478272, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1008), 447295932, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1010) },
                    { 1514478272, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(982), 695059693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(983) },
                    { 1514478272, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(847), 572940984, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(848) },
                    { 1514478272, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(941), 638573336, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(942) },
                    { 1735143456, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7972), 728002564, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7973) },
                    { 1735143456, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8085), 150284988, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8086) },
                    { 1735143456, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8139), 992785902, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8140) },
                    { 1735143456, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7988), 840546175, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7990) },
                    { 1735143456, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7945), 799186892, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7946) },
                    { 1735143456, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8125), 954400821, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8127) },
                    { 1735143456, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7958), 975191131, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7959) },
                    { 1735143456, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8016), 293588158, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8017) },
                    { 1735143456, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8002), 330789496, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8004) },
                    { 1735143456, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8112), 947359050, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8113) },
                    { 1735143456, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8044), 933419051, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8045) },
                    { 1735143456, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8057), 906921565, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8059) },
                    { 1735143456, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8098), 458374927, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8100) },
                    { 1735143456, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8071), 332689239, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8072) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1735143456, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7931), 987884353, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7932) },
                    { 1735143456, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8030), 569488939, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8031) },
                    { 1786998136, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8910), 823027596, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8912) },
                    { 1786998136, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9021), 937701026, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9022) },
                    { 1786998136, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9075), 412310641, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9076) },
                    { 1786998136, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8924), 215853539, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8925) },
                    { 1786998136, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8883), 381811642, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8884) },
                    { 1786998136, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9061), 402626909, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9063) },
                    { 1786998136, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8897), 865708115, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8898) },
                    { 1786998136, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8951), 619671873, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8953) },
                    { 1786998136, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8938), 253811483, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8939) },
                    { 1786998136, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9048), 820348905, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9049) },
                    { 1786998136, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8979), 736516707, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8980) },
                    { 1786998136, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8993), 137676242, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8994) },
                    { 1786998136, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9034), 593276645, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9035) },
                    { 1786998136, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9007), 773343990, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9008) },
                    { 1786998136, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8869), 796622624, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8871) },
                    { 1786998136, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8965), 196980893, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8966) },
                    { 1922016840, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2486), 789782069, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2487) },
                    { 1922016840, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2596), 849378798, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2597) },
                    { 1922016840, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2651), 362358582, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2652) },
                    { 1922016840, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2500), 764623009, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2501) },
                    { 1922016840, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2458), 807667764, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2460) },
                    { 1922016840, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2637), 950149866, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2638) },
                    { 1922016840, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2472), 364734621, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2473) },
                    { 1922016840, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2527), 605153400, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2529) },
                    { 1922016840, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2514), 142104119, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2515) },
                    { 1922016840, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2623), 471583675, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2625) },
                    { 1922016840, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2555), 847649601, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2556) },
                    { 1922016840, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2569), 172682383, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2570) },
                    { 1922016840, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2610), 551081649, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2611) },
                    { 1922016840, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2582), 846804873, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2584) },
                    { 1922016840, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2441), 601274040, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2442) },
                    { 1922016840, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2541), 841551736, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2543) },
                    { 1961561656, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1546), 902265386, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1547) },
                    { 1961561656, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1653), 174689236, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1654) },
                    { 1961561656, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1707), 257743318, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1708) },
                    { 1961561656, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1559), 709353008, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1560) },
                    { 1961561656, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1515), 734069270, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1516) },
                    { 1961561656, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1693), 168431305, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1695) },
                    { 1961561656, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1528), 719159230, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1530) },
                    { 1961561656, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1586), 828398660, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1587) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1961561656, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1573), 720286561, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1574) },
                    { 1961561656, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1680), 868698604, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1681) },
                    { 1961561656, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1612), 935733328, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1614) },
                    { 1961561656, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1626), 636249782, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1627) },
                    { 1961561656, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1666), 254561564, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1668) },
                    { 1961561656, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1639), 958674371, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1641) },
                    { 1961561656, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1501), 796985922, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1503) },
                    { 1961561656, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1599), 713472430, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1600) },
                    { 2058347776, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1761), 880332138, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1762) },
                    { 2058347776, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1924), 133048343, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1925) },
                    { 2058347776, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1981), 566222643, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1982) },
                    { 2058347776, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1774), 365916309, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1776) },
                    { 2058347776, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1734), 292885179, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1735) },
                    { 2058347776, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1967), 425072832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1968) },
                    { 2058347776, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1747), 429752391, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1749) },
                    { 2058347776, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1802), 326150968, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1803) },
                    { 2058347776, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1788), 273564298, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1790) },
                    { 2058347776, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1953), 127973782, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1954) },
                    { 2058347776, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1829), 293778410, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1830) },
                    { 2058347776, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1893), 873909572, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1894) },
                    { 2058347776, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1938), 351688421, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1939) },
                    { 2058347776, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1909), 667896793, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1911) },
                    { 2058347776, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1720), 863804242, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1722) },
                    { 2058347776, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1815), 609876556, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1817) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 139389886, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1823), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1820), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1821), 657063491 },
                    { 141863418, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2439), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2436), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2437), 834534160 },
                    { 144940712, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3167), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3164), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3165), 834534160 },
                    { 144996997, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2590), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2587), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2589), 834534160 },
                    { 145438318, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2050), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2047), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2048), 657063491 },
                    { 165748714, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2182), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2179), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2181), 657063491 },
                    { 166806025, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1756), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1751), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1753), 834534160 },
                    { 188641697, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3282), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3279), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3281), 264194405 },
                    { 195394316, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1960), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1958), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1959), 657063491 },
                    { 196765683, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2620), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2617), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2618), 264194405 },
                    { 233393383, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3123), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3121), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3122), 834534160 },
                    { 238070596, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2240), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2237), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2239), 264194405 },
                    { 245985170, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2874), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2871), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2872), 657063491 },
                    { 286584383, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2321), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2318), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2320), 657063491 },
                    { 324109566, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2917), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2914), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2915), 657063491 },
                    { 330135627, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2335), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2333), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2334), 264194405 },
                    { 331994708, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3023), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3020), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3021), 264194405 },
                    { 346958205, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2664), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2661), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2662), 264194405 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 351105458, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2816), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2813), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2814), 834534160 },
                    { 365873516, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2605), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2602), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2604), 657063491 },
                    { 366107512, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2079), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2076), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2078), 834534160 },
                    { 382780665, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2152), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2150), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2151), 264194405 },
                    { 401097784, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3066), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3063), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3064), 264194405 },
                    { 410989400, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2004), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2001), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2003), 657063491 },
                    { 415458283, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2379), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2376), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2378), 264194405 },
                    { 430225625, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2395), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2392), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2393), 834534160 },
                    { 433650873, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3328), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3325), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3326), 264194405 },
                    { 445716980, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1868), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1865), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1867), 657063491 },
                    { 449122456, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2290), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2287), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2288), 264194405 },
                    { 452435566, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2830), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2827), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2829), 657063491 },
                    { 458648265, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2365), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2362), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2363), 657063491 },
                    { 466067187, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3080), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3077), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3079), 834534160 },
                    { 471993376, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2306), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2303), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2305), 834534160 },
                    { 483098671, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3195), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3193), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3194), 264194405 },
                    { 492471635, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1931), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1929), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1930), 264194405 },
                    { 509588651, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2259), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2257), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2258), 834534160 },
                    { 517164727, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1839), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1836), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1837), 264194405 },
                    { 522007574, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2888), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2885), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2886), 264194405 },
                    { 528237580, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2274), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2271), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2273), 657063491 },
                    { 532196716, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2990), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2987), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2988), 834534160 },
                    { 533136314, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2064), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2061), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2063), 264194405 },
                    { 550574008, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2211), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2208), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2210), 834534160 },
                    { 578870416, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1808), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1805), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1806), 834534160 },
                    { 582464991, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2931), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2929), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2930), 264194405 },
                    { 584123569, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2559), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2557), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2558), 657063491 },
                    { 584706630, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3253), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3250), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3252), 834534160 },
                    { 591979027, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2513), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2510), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2511), 657063491 },
                    { 594261554, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2741), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2738), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2740), 657063491 },
                    { 599209268, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2634), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2632), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2633), 834534160 },
                    { 605633336, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1883), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1880), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1881), 264194405 },
                    { 605909021, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3109), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3106), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3107), 264194405 },
                    { 608313961, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3224), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3222), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3223), 657063491 },
                    { 610892276, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2108), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2105), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2107), 264194405 },
                    { 614331024, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2123), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2120), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2122), 834534160 },
                    { 637433106, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3268), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3265), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3266), 657063491 },
                    { 637469910, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2712), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2709), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2711), 264194405 },
                    { 654931239, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3152), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3150), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3151), 264194405 },
                    { 662048967, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1854), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1851), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1852), 834534160 },
                    { 662244733, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2424), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2421), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2422), 264194405 },
                    { 662862392, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2530), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2527), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2528), 264194405 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 663241534, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3051), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3049), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3050), 657063491 },
                    { 677620455, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2167), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2165), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2166), 834534160 },
                    { 679146884, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3298), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3294), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3296), 834534160 },
                    { 685108337, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1778), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1775), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1776), 657063491 },
                    { 690155728, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2960), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2958), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2959), 657063491 },
                    { 693129786, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1946), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1943), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1945), 834534160 },
                    { 695450397, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2094), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2091), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2092), 657063491 },
                    { 702662235, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1899), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1896), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1898), 834534160 },
                    { 720071025, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3095), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3092), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3093), 657063491 },
                    { 727891081, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1913), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1911), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1912), 657063491 },
                    { 734332619, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2350), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2347), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2349), 834534160 },
                    { 740163096, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3138), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3135), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3136), 657063491 },
                    { 741951895, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2902), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2900), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2901), 834534160 },
                    { 747712163, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2225), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2223), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2224), 657063491 },
                    { 749463614, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2138), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2135), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2136), 657063491 },
                    { 749827857, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2727), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2724), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2726), 834534160 },
                    { 760100214, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3210), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3207), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3209), 834534160 },
                    { 768938438, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3239), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3236), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3237), 264194405 },
                    { 774325581, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2770), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2767), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2769), 834534160 },
                    { 790216596, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3313), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3311), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3312), 657063491 },
                    { 793944305, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1989), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1987), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1988), 834534160 },
                    { 800430559, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2946), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2943), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2944), 834534160 },
                    { 816769314, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2649), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2646), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2648), 657063491 },
                    { 831310279, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2575), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2572), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2573), 264194405 },
                    { 848354721, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1975), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1972), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1973), 264194405 },
                    { 861383022, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2975), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2973), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2974), 264194405 },
                    { 864035135, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2756), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2753), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2754), 264194405 },
                    { 874809491, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2679), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2676), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2677), 834534160 },
                    { 896791374, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2545), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2542), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2543), 834534160 },
                    { 904233760, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2020), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2018), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2019), 264194405 },
                    { 915688254, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2801), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2799), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2800), 264194405 },
                    { 917369037, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2035), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2032), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2034), 834534160 },
                    { 918859602, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2859), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2857), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2858), 834534160 },
                    { 920132106, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2845), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2842), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2844), 264194405 },
                    { 926371964, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3181), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3178), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3180), 657063491 },
                    { 931332767, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1793), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1790), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1791), 264194405 },
                    { 938458115, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3037), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3035), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3036), 834534160 },
                    { 940218524, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2784), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2782), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2783), 657063491 },
                    { 960896484, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2693), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2691), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2692), 657063491 },
                    { 961832443, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3008), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3005), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3006), 657063491 },
                    { 977582482, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2409), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2406), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2408), 657063491 },
                    { 979904213, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2196), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2194), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2195), 264194405 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 126063958, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3618), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3619), 498609019 },
                    { 134473820, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5067), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5068), 852909449 },
                    { 134805857, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3478), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3479), 724276678 },
                    { 139053606, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5662), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5663), 722064785 },
                    { 144509740, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5528), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5529), 724276678 },
                    { 145800218, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4662), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4663), 716360954 },
                    { 146690114, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5306), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5308), 775558853 },
                    { 147698393, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5220), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5221), 722064785 },
                    { 148782614, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5471), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5473), 498609019 },
                    { 151236730, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6629), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6630), 724276678 },
                    { 154936229, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4200), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4201), 498609019 },
                    { 155437173, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6314), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6316), 775558853 },
                    { 157564405, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6453), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6455), 716360954 },
                    { 158145370, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3534), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3535), 207022497 },
                    { 160447486, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4172), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4173), 716360954 },
                    { 166441017, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5108), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5109), 775558853 },
                    { 169239853, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4383), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4385), 852909449 },
                    { 171674864, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4088), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4089), 852909449 },
                    { 173141223, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4269), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4270), 716360954 },
                    { 180004949, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6382), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6384), 498609019 },
                    { 180824655, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4539), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4540), 722064785 },
                    { 181115801, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4983), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4985), 498609019 },
                    { 184525603, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6044), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6045), 722064785 },
                    { 185217033, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5053), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5054), 716360954 },
                    { 190831966, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6413), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6414), 775558853 },
                    { 202648671, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5758), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5759), 722064785 },
                    { 203939403, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4327), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4329), 775558853 },
                    { 214816263, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4827), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4829), 722064785 },
                    { 223455921, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5892), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5893), 852909449 },
                    { 225696179, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4675), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4677), 852909449 },
                    { 226732102, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5744), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5746), 775558853 },
                    { 234424144, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5703), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5704), 852909449 },
                    { 242267469, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3965), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3967), 724276678 },
                    { 245134540, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6481), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6482), 498609019 },
                    { 246959514, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4424), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4426), 775558853 },
                    { 253158146, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5375), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5377), 498609019 },
                    { 256396501, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3687), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3689), 716360954 },
                    { 268707202, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6642), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6644), 716360954 },
                    { 274488782, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4955), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4956), 716360954 },
                    { 278137378, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5389), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5390), 207022497 },
                    { 282594345, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6616), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6617), 722064785 },
                    { 282744356, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4411), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4412), 207022497 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 283092996, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6111), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6112), 207022497 },
                    { 289823663, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3993), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3994), 852909449 },
                    { 295176940, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4942), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4943), 724276678 },
                    { 295442006, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6767), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6769), 498609019 },
                    { 297498086, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6696), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6697), 775558853 },
                    { 299698831, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5011), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5012), 775558853 },
                    { 302397690, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5136), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5137), 724276678 },
                    { 305459711, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3492), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3493), 716360954 },
                    { 309858500, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4928), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4929), 722064785 },
                    { 331535684, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4497), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4498), 498609019 },
                    { 334066236, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5631), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5633), 207022497 },
                    { 342351434, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4397), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4398), 498609019 },
                    { 345017295, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5717), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5718), 498609019 },
                    { 351982007, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4074), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4076), 716360954 },
                    { 354691895, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3771), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3772), 724276678 },
                    { 358210545, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3896), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3897), 852909449 },
                    { 358761038, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3910), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3911), 498609019 },
                    { 359153437, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4021), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4022), 207022497 },
                    { 359446938, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4552), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4553), 724276678 },
                    { 360587055, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5811), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5813), 498609019 },
                    { 368150147, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4914), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4915), 775558853 },
                    { 369934560, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4438), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4440), 722064785 },
                    { 371241452, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4034), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4035), 775558853 },
                    { 373407703, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5265), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5267), 852909449 },
                    { 381845923, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6440), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6441), 724276678 },
                    { 383553101, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6535), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6536), 724276678 },
                    { 384112042, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4773), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4774), 852909449 },
                    { 388643955, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3590), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3592), 716360954 },
                    { 392070281, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6396), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6397), 207022497 },
                    { 395811635, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5852), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5853), 722064785 },
                    { 396118172, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4997), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4998), 207022497 },
                    { 396217945, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4689), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4691), 498609019 },
                    { 404634333, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5555), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5556), 852909449 },
                    { 407733156, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4255), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4256), 724276678 },
                    { 409105923, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3604), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3605), 852909449 },
                    { 411806401, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6287), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6288), 498609019 },
                    { 411963670, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3925), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3926), 207022497 },
                    { 412610174, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4341), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4342), 722064785 },
                    { 413925770, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6780), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6782), 207022497 },
                    { 417726192, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6138), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6140), 722064785 },
                    { 424616608, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5080), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5081), 498609019 },
                    { 427188878, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6369), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6370), 852909449 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 427984797, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6589), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6590), 207022497 },
                    { 431625352, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4128), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4129), 775558853 },
                    { 431741932, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4355), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4356), 724276678 },
                    { 439919129, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4841), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4842), 724276678 },
                    { 442150090, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5838), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5839), 775558853 },
                    { 447600728, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3842), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3843), 775558853 },
                    { 450572624, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4115), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4116), 207022497 },
                    { 450865314, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5293), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5294), 207022497 },
                    { 455495418, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5122), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5123), 722064785 },
                    { 455789061, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3716), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3717), 498609019 },
                    { 456797368, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3979), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3981), 716360954 },
                    { 461832385, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3673), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3674), 724276678 },
                    { 462333272, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5334), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5335), 724276678 },
                    { 470497093, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4882), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4883), 498609019 },
                    { 470954226, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6098), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6099), 498609019 },
                    { 472418252, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3757), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3758), 722064785 },
                    { 475227446, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5417), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5418), 722064785 },
                    { 475583646, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5192), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5193), 207022497 },
                    { 481334510, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5362), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5363), 852909449 },
                    { 488092338, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3576), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3577), 724276678 },
                    { 491893251, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6710), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6712), 722064785 },
                    { 492170232, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3632), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3633), 207022497 },
                    { 498955767, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5279), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5280), 498609019 },
                    { 499524573, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6467), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6469), 852909449 },
                    { 503761209, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4145), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4146), 722064785 },
                    { 506022457, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5932), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5933), 775558853 },
                    { 506852522, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3828), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3829), 207022497 },
                    { 517156757, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5771), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5773), 724276678 },
                    { 519337672, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4635), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4636), 722064785 },
                    { 521958035, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3938), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3939), 775558853 },
                    { 524386225, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4746), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4747), 724276678 },
                    { 525605719, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4855), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4856), 716360954 },
                    { 528568138, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6071), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6072), 716360954 },
                    { 532152993, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6725), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6726), 724276678 },
                    { 532749109, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6656), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6657), 852909449 },
                    { 537219141, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6301), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6302), 207022497 },
                    { 537310341, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5798), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5800), 852909449 },
                    { 537501606, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5444), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5445), 716360954 },
                    { 540688801, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4214), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4215), 207022497 },
                    { 541140804, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4061), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4062), 724276678 },
                    { 548242798, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4703), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4704), 207022497 },
                    { 550123250, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5972), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5974), 716360954 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 553375523, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3814), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3815), 498609019 },
                    { 557376595, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5959), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5960), 724276678 },
                    { 561666140, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4716), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4718), 775558853 },
                    { 562670575, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5320), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5322), 722064785 },
                    { 568788948, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3454), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3456), 722064785 },
                    { 569890174, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5234), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5235), 724276678 },
                    { 572923330, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5206), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5207), 775558853 },
                    { 573704288, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5825), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5826), 207022497 },
                    { 573913337, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5676), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5677), 724276678 },
                    { 581211026, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6206), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6208), 207022497 },
                    { 582747204, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4299), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4300), 498609019 },
                    { 586901122, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3645), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3647), 775558853 },
                    { 590167047, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4580), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4581), 852909449 },
                    { 591756576, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6179), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6180), 852909449 },
                    { 595457837, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4814), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4815), 775558853 },
                    { 600446950, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5865), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5867), 724276678 },
                    { 609267289, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5918), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5920), 207022497 },
                    { 613470609, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5025), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5026), 722064785 },
                    { 613597598, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4511), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4512), 207022497 },
                    { 618064032, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3883), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3884), 716360954 },
                    { 623142008, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5403), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5404), 775558853 },
                    { 626240035, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4525), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4526), 775558853 },
                    { 629419542, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6273), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6275), 852909449 },
                    { 633021231, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6260), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6262), 716360954 },
                    { 634820096, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6797), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6798), 775558853 },
                    { 646288114, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5500), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5501), 775558853 },
                    { 647524075, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4101), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4103), 498609019 },
                    { 659436530, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3801), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3802), 852909449 },
                    { 661982021, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3730), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3731), 207022497 },
                    { 668791091, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4607), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4609), 207022497 },
                    { 671766057, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5986), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5987), 852909449 },
                    { 677259498, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6669), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6670), 498609019 },
                    { 682314890, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3744), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3745), 775558853 },
                    { 689277252, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5094), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5095), 207022497 },
                    { 690083203, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6233), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6235), 722064785 },
                    { 697262262, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6507), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6509), 775558853 },
                    { 703605342, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6739), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6740), 716360954 },
                    { 704402649, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4800), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4801), 207022497 },
                    { 706651076, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3659), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3661), 722064785 },
                    { 712626673, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3548), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3549), 775558853 },
                    { 719538118, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5999), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6000), 498609019 },
                    { 721191519, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5514), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5515), 722064785 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 723619736, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6494), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6495), 207022497 },
                    { 725464947, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4899), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4901), 207022497 },
                    { 726043906, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5178), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5180), 498609019 },
                    { 726716596, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3787), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3788), 716360954 },
                    { 735137275, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5730), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5731), 207022497 },
                    { 745570230, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6355), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6356), 716360954 },
                    { 746808719, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5648), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5649), 775558853 },
                    { 748330282, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4007), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4008), 498609019 },
                    { 748810018, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6548), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6549), 716360954 },
                    { 751814570, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5247), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5248), 716360954 },
                    { 753217552, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4186), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4188), 852909449 },
                    { 764176679, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5569), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5570), 498609019 },
                    { 768165449, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4648), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4650), 724276678 },
                    { 775691139, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4480), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4481), 852909449 },
                    { 776786555, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4759), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4760), 716360954 },
                    { 776971727, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3855), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3857), 722064785 },
                    { 785606972, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6219), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6221), 775558853 },
                    { 802893246, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6575), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6577), 498609019 },
                    { 805066220, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6016), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6018), 207022497 },
                    { 805082566, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5039), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5040), 724276678 },
                    { 806352171, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6165), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6167), 716360954 },
                    { 816405029, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3562), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3563), 722064785 },
                    { 821638235, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6193), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6194), 498609019 },
                    { 826282664, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5785), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5786), 716360954 },
                    { 827490006, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4731), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4732), 722064785 },
                    { 844215306, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4283), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4285), 852909449 },
                    { 846366107, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3505), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3507), 852909449 },
                    { 848640872, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5485), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5487), 207022497 },
                    { 848772692, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5690), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5691), 716360954 },
                    { 852772967, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6602), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6603), 775558853 },
                    { 853186500, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3869), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3870), 724276678 },
                    { 853941054, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3702), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3704), 852909449 },
                    { 854672914, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6562), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6563), 852909449 },
                    { 857022856, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6030), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6031), 775558853 },
                    { 857633717, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5348), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5349), 716360954 },
                    { 864372855, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4969), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4970), 852909449 },
                    { 866272710, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5878), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5880), 716360954 },
                    { 868726405, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4869), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4870), 852909449 },
                    { 871030929, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5946), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5947), 722064785 },
                    { 871978983, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4466), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4468), 716360954 },
                    { 878843610, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3520), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3521), 498609019 },
                    { 880338149, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5541), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5543), 716360954 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 883144123, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4048), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4049), 722064785 },
                    { 887930821, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4241), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4243), 722064785 },
                    { 890225599, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6085), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6086), 852909449 },
                    { 894269875, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4621), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4622), 775558853 },
                    { 895388749, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4369), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4371), 716360954 },
                    { 896664005, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6328), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6329), 722064785 },
                    { 898531413, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6682), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6684), 207022497 },
                    { 902137372, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4228), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4229), 775558853 },
                    { 907582130, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6057), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6058), 724276678 },
                    { 911804476, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6521), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6522), 722064785 },
                    { 914745421, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4452), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4454), 724276678 },
                    { 924068678, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4594), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4595), 498609019 },
                    { 924815749, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6426), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6428), 722064785 },
                    { 931457317, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5458), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5459), 852909449 },
                    { 933137808, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5151), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5152), 716360954 },
                    { 940829396, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6152), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6153), 724276678 },
                    { 942637849, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6752), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6753), 852909449 },
                    { 943084058, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4158), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4160), 724276678 },
                    { 954651892, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3952), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3953), 722064785 },
                    { 959629463, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5431), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5432), 724276678 },
                    { 961225835, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6247), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6248), 724276678 },
                    { 962608977, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4787), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4788), 498609019 },
                    { 968602713, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4313), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4315), 207022497 },
                    { 970773276, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5165), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5166), 852909449 },
                    { 972507514, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6341), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6343), 724276678 },
                    { 972720869, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6125), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6126), 775558853 },
                    { 991428229, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5905), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5906), 498609019 },
                    { 997987218, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4566), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4567), 716360954 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 130091889, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8133), -399823987, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8135) },
                    { 142482156, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8010), -79753189, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8011) },
                    { 210009642, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8254), -523512980, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8256) },
                    { 357392399, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8177), -965443558, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8180) },
                    { 377058179, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8025), 1456267131, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8026) },
                    { 399056263, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8087), -1117250045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8088) },
                    { 482303752, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8230), 2114720541, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8232) },
                    { 502867731, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7979), -157087754, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7981) },
                    { 535075931, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8151), -54464305, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8153) },
                    { 604322297, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8056), 376250311, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8058) },
                    { 674379550, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7994), 1256897183, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7996) },
                    { 698742277, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8203), 1503073256, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8206) },
                    { 705377858, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8102), 196399036, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8103) },
                    { 710856637, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8072), 1721831396, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8073) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 837327415, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7964), -380484859, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7966) },
                    { 854265727, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8040), -2090907967, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8041) },
                    { 877357391, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8117), 1507872911, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8119) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7441), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7442), "Project Manager", 524835668 },
                    { 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7426), false, false, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7427), "Secretariat", 524835668 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 524835668, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9767), 971790611, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9769) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 210009642, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7811), -240334883, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7812) },
                    { 271958213, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7714), -314010958, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7715) },
                    { 377058179, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7729), -441782338, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7731) },
                    { 502867731, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7699), -815869052, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7700) },
                    { 535075931, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7776), -1511620586, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7777) },
                    { 604322297, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7760), -1320640127, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7761) },
                    { 837327415, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7683), 1374444405, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7684) },
                    { 854265727, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7745), 278331976, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7746) },
                    { 876989901, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7795), -1803645989, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7796) },
                    { 377058179, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8766), 59970745, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8767) },
                    { 502867731, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8751), 1806634233, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8752) },
                    { 604322297, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8800), 2042824532, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8802) },
                    { 710856637, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8816), -1251164290, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8818) },
                    { 837327415, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8736), -368418838, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8737) },
                    { 854265727, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8781), -522286771, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8783) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7456), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7457), "Engineer", 391103299 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 391103299, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(342), 329527785, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(344) },
                    { 391103299, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(357), 282930588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(358) },
                    { 395911868, 825284728, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8932), 925499488, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8934) },
                    { 391103299, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(326), 291627152, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(328) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 377058179, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7636), -811907041, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7638) },
                    { 479578946, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7621), 142671772, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7623) },
                    { 502867731, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7605), -108336946, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7607) },
                    { 604322297, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7667), -660253486, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7668) },
                    { 837327415, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7589), 344095853, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7590) },
                    { 854265727, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7652), 1347976580, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7653) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 479451032, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7470), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7472), "Designer", 164644045 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 164644045, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9559), 243029691, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9561) },
                    { 164644045, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(44), 288570026, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(46) },
                    { 164644045, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(225), 905284720, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(226) },
                    { 164644045, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9638), 524048362, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9641) },
                    { 164644045, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9406), 709301732, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9408) },
                    { 164644045, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(179), 408862968, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(181) },
                    { 164644045, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9479), 738459459, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9481) },
                    { 164644045, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9813), 460668531, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9815) },
                    { 164644045, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9738), 720458760, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9739) },
                    { 164644045, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(134), 788317312, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(135) },
                    { 164644045, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9904), 863035425, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9906) },
                    { 164644045, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9953), 939495899, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9955) },
                    { 164644045, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(89), 388329060, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(90) },
                    { 164644045, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local), 237500796, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1) },
                    { 164644045, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9247), 738501245, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9249) },
                    { 164644045, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9859), 511670765, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9860) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 377058179, 479451032, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7574), -1474443274, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7575) },
                    { 502867731, 479451032, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7557), -1110510454, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7559) },
                    { 837327415, 479451032, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7529), 1990282307, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7531) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 479451032, 530043390, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9176), 933319169, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9178) },
                    { 479451032, 590012631, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9105), 726612307, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9107) },
                    { 479451032, 835483227, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9034), 856899277, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9037) }
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
                principalColumn: "Id");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Others_Disciplines_DisciplineId",
                table: "Others",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                principalTable: "Users",
                principalColumn: "Id");

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
