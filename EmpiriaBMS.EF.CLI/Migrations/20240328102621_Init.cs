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
                name: "Issues",
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
                    table.PrimaryKey("PK_Issues", x => x.Id);
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
                    { 132322692, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5457), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5458), "Construction Supervision" },
                    { 155271193, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5414), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5416), "Energy Efficiency" },
                    { 160030591, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5484), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5485), "Project Manager Hours" },
                    { 231118267, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5275), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5276), "Fire Detection" },
                    { 244768623, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5317), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5318), "Natural Gas" },
                    { 258798853, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5331), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5332), "Power Distribution" },
                    { 272729730, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5304), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5305), "Elevators" },
                    { 314866761, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5470), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5471), "DWG Admin/Clearing" },
                    { 350054576, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5233), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5235), "Sewage" },
                    { 365324321, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5290), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5291), "Fire Suppression" },
                    { 393913326, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5209), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5210), "HVAC" },
                    { 484044312, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5247), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5248), "Potable Water" },
                    { 504396219, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5373), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5375), "CCTV" },
                    { 505808690, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5360), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5361), "Burglar Alarm" },
                    { 507080092, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5346), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5347), "Structured Cabling" },
                    { 538327537, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5387), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5388), "BMS" },
                    { 829372022, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5400), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5402), "Photovoltaics" },
                    { 871357142, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5428), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5429), "Outsource" },
                    { 968488719, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5441), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5442), "TenderDocument" },
                    { 983578885, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5261), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5262), "Drainage" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 404497094, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5787), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5789), "Drawings" },
                    { 755840185, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5755), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5756), "Documents" },
                    { 829459157, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5773), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5775), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 218567543, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6592), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6593), "Meetings" },
                    { 227945353, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6564), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6565), "Printing" },
                    { 296131956, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6605), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6607), "Administration" },
                    { 337561976, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6578), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6579), "On-Site" },
                    { 348358404, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6635), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6636), "Hours To Be Raised" },
                    { 361053100, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6621), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6622), "Soft Copy" },
                    { 428559813, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6540), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6541), "Communications" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 270248835, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1679), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1682), "Dashboard Edit Other", 16 },
                    { 289949473, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1199), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1201), "Dashboard Assign Designer", 3 },
                    { 333687113, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1327), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1329), "Dashboard See My Hours", 8 },
                    { 464075419, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1647), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1650), "Dashboard Edit Deliverable", 15 },
                    { 488505096, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1174), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1176), "Dashboard Edit My Hours", 2 },
                    { 513540116, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1390), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1392), "See All Drawings", 10 },
                    { 555871266, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1350), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1353), "See All Disciplines", 9 },
                    { 594120758, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1221), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1223), "Dashboard Assign Engineer", 4 },
                    { 615355365, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1539), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1541), "Edit Project On Dashboard", 12 },
                    { 651371108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1276), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1278), "Dashboard Add Project", 6 },
                    { 720479382, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1044), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1047), "See Dashboard Layout", 1 },
                    { 725680501, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1566), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1568), "Display Projects Code", 13 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 728138796, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1248), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1250), "Dashboard Assign Project Manager", 5 },
                    { 856292555, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1590), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1592), "Dashboard Edit Discipline", 14 },
                    { 894793994, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1515), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1517), "See All Projects", 11 },
                    { 942103459, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1302), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1304), "See Admin Layout", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 480172664, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4793), "Buildings Description", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4794), "Buildings" },
                    { 542556013, false, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4862), "Production Management Description", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4864), "Production Management" },
                    { 572116564, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4817), "Infrastructure Description", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4818), "Infrastructure" },
                    { 707946919, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4847), "Consulting Description", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4849), "Consulting" },
                    { 951046237, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4832), "Energy Description", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4834), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 348504965, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2190), false, false, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2191), "Admin", null },
                    { 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1748), false, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1750), "CEO", null },
                    { 934663543, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2158), false, false, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2159), "Guest", null },
                    { 956215265, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2174), false, false, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2175), "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4256), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4257), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 201158868, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3540), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3542), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4019), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4020), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4066), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4067), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4479), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4481), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3972), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3973), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4526), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4527), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4745), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4747), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 478822725, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3841), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3843), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4622), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4623), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4431), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4433), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4380), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4383), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4179), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4180), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4114), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4115), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4575), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4576), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4697), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4698), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4331), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4333), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3922), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3924), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 943583034, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3630), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3631), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 949772354, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3678), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3679), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 229628486, "pfokianou@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4496), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4497), 276236016 },
                    { 233662193, "chkovras@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4082), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4083), 231511305 },
                    { 240713369, "panperivollari@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4714), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4715), 780602166 },
                    { 271933736, "dtsa@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3886), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3888), 478822725 },
                    { 317566339, "vchontos@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4638), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4639), 487891438 },
                    { 421023319, "kkotsoni@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4195), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4197), 729524521 },
                    { 453304447, "haris@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4448), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4449), 565596634 },
                    { 497849528, "embiria@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3566), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3568), 201158868 },
                    { 508667494, "gdoug@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3647), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3649), 943583034 },
                    { 528763840, "sparisis@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4035), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4036), 222609572 },
                    { 537652296, "vpax@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3940), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3942), 929166556 },
                    { 755530194, "xmanarolis@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3989), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3990), 317205777 },
                    { 768638175, "ngal@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4132), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4133), 736777450 },
                    { 775022602, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3590), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3591), 201158868 },
                    { 835029475, "dtsa@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3693), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3695), 949772354 },
                    { 841607242, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4543), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4544), 432610301 },
                    { 879009741, "kmargeti@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4400), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4402), 705169641 },
                    { 889133025, "vtza@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4299), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4300), 136265368 },
                    { 890261408, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4762), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4763), 473123990 },
                    { 943207250, "blekou@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4592), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4593), 758153546 },
                    { 975761710, "agretos@embiria.gr", new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4348), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4349), 857452372 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 234587387, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), new DateTime(2024, 7, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Test Description Project_4", new DateTime(2024, 7, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 0f, new DateTime(2024, 7, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 1500L, 12L, 10000.0, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Project_2", 729524521, null, 572116564, 0f },
                    { 381764293, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), new DateTime(2025, 7, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Test Description Project_4", new DateTime(2025, 7, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 0f, new DateTime(2025, 7, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 1500L, 12L, 10000.0, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Project_4", 729524521, null, 707946919, 0f },
                    { 409659777, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), new DateTime(2024, 12, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Test Description Project_9", new DateTime(2024, 12, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 0f, new DateTime(2024, 12, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 1500L, 12L, 10000.0, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Project_3", 729524521, null, 951046237, 0f },
                    { 706443163, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), new DateTime(2024, 6, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Test Description Project_PM", new DateTime(2024, 4, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 0f, new DateTime(2024, 5, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 1500L, 12L, null, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Project_PM", null, null, 542556013, 0f },
                    { 960233523, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), new DateTime(2024, 4, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Test Description Project_2", new DateTime(2024, 4, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 0f, new DateTime(2024, 4, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), 1500L, 12L, 10000.0, new DateTime(2024, 3, 28, 12, 26, 20, 775, DateTimeKind.Local).AddTicks(8728), "Project_1", 729524521, null, 480172664, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 513540116, 348504965, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3344), 1179296532, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3345) },
                    { 555871266, 348504965, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3311), -843049048, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3312) },
                    { 894793994, 348504965, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3359), -63380609, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3360) },
                    { 942103459, 348504965, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3296), -1538278186, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3297) },
                    { 289949473, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2926), 321946804, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2928) },
                    { 488505096, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2911), 1225461497, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2912) },
                    { 513540116, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3172), -2025548108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3173) },
                    { 555871266, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3157), -2054596018, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3158) },
                    { 594120758, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2942), 1721439455, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2944) },
                    { 615355365, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3250), 149751725, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3251) },
                    { 651371108, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3141), 270123688, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3142) },
                    { 720479382, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2896), -1344108352, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2897) },
                    { 725680501, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3234), 1055025311, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3236) },
                    { 728138796, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3125), -780929878, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3127) },
                    { 894793994, 744844349, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3218), -763415792, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3220) },
                    { 720479382, 934663543, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3265), 1347257147, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3266) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 720479382, 956215265, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3280), -1877814382, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3281) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1789), false, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1791), "COO", 744844349 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 744844349, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4163), 257201118, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4164) });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2017322880, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5618), 0f, 408L, 51L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5619), 234587387, 484044312, null },
                    { -1848123296, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5695), 0f, 400L, 50L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5696), 381764293, 132322692, null },
                    { -1821434424, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5710), 0f, 408L, 51L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5711), 381764293, 829372022, null },
                    { -1543926328, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5664), 0f, 408L, 51L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5666), 409659777, 231118267, null },
                    { -1404891016, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5679), 0f, 416L, 52L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5680), 409659777, 968488719, null },
                    { -1232945472, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5650), 0f, 400L, 50L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5651), 409659777, 538327537, null },
                    { -933058024, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5572), 0f, 408L, 51L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5573), 960233523, 507080092, null },
                    { -886486104, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5603), 0f, 400L, 50L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5604), 234587387, 132322692, null },
                    { -872341936, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5738), 0f, 500L, 0L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5740), 706443163, 160030591, null },
                    { -690861216, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5724), 0f, 416L, 52L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5725), 381764293, 871357142, null },
                    { 1151735360, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5634), 0f, 416L, 52L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5636), 234587387, 983578885, null },
                    { 1491013136, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5587), 0f, 416L, 52L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5589), 960233523, 871357142, null },
                    { 1508854384, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5517), 0f, 400L, 50L, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5519), 960233523, 393913326, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 404277893, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5169), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5171), 13000.0, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5170), "Signature 1423424", 19852, 381764293, 4.0, 24.0 },
                    { 890233888, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5051), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5053), 3100.0, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5052), "Signature 142346", 42704, 234587387, 2.0, 24.0 },
                    { 946261533, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5001), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5004), 3010.0, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5003), "Signature 142346", 16747, 960233523, 1.0, 17.0 },
                    { 975120904, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5087), new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5090), 4000.0, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5089), "Signature 1423418", 61061, 409659777, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289949473, 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2597), -769293440, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2599) },
                    { 333687113, 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2645), 1322539367, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2646) },
                    { 488505096, 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2580), 40808341, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2581) },
                    { 513540116, 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2676), 2117147891, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2678) },
                    { 555871266, 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2660), -1804629662, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2662) },
                    { 594120758, 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2614), 309406924, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2615) },
                    { 720479382, 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2534), -56590379, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2535) },
                    { 728138796, 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2630), 114954445, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2631) },
                    { 894793994, 809905108, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2692), -1028362364, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2693) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1817), false, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1818), "CTO", 809905108 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 809905108, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4225), 928359002, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4226) });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2017322880, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9202), 848256808, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9204) },
                    { -2017322880, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9146), 779912256, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9147) },
                    { -2017322880, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9160), 384042387, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9161) },
                    { -2017322880, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9259), 775225653, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9260) },
                    { -2017322880, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9131), 435622519, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9132) },
                    { -2017322880, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9273), 327088464, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9274) },
                    { -2017322880, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9355), 689593667, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9356) },
                    { -2017322880, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9301), 551858145, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9303) },
                    { -2017322880, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9245), 153945571, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9246) },
                    { -2017322880, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9231), 394830549, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9232) },
                    { -2017322880, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9188), 869182303, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9189) },
                    { -2017322880, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9174), 170350104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9175) },
                    { -2017322880, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9287), 543575022, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9288) },
                    { -2017322880, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9315), 234446799, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9316) },
                    { -2017322880, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9217), 872780782, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9218) },
                    { -2017322880, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9115), 813781462, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9117) },
                    { -1848123296, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(985), 565909982, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(986) },
                    { -1848123296, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(928), 787806833, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(929) },
                    { -1848123296, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(942), 570142997, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(944) },
                    { -1848123296, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1041), 572881001, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1043) },
                    { -1848123296, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(914), 640229277, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(915) },
                    { -1848123296, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1055), 512699470, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1057) },
                    { -1848123296, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1112), 934839746, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1113) },
                    { -1848123296, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1084), 488066246, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1085) },
                    { -1848123296, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1027), 908242063, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1029) },
                    { -1848123296, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1013), 164271518, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1014) },
                    { -1848123296, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(971), 166133404, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(972) },
                    { -1848123296, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(957), 919169957, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(958) },
                    { -1848123296, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1069), 597903162, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1071) },
                    { -1848123296, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1098), 768631650, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1099) },
                    { -1848123296, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(999), 761788044, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1000) },
                    { -1848123296, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(899), 907041002, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(901) },
                    { -1821434424, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1436), 650429382, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1437) },
                    { -1821434424, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1155), 282559727, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1156) },
                    { -1821434424, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1169), 776029340, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1170) },
                    { -1821434424, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1493), 517339405, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1494) },
                    { -1821434424, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1140), 528090514, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1142) },
                    { -1821434424, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1507), 598244997, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1508) },
                    { -1821434424, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1565), 500667650, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1566) },
                    { -1821434424, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1536), 687123540, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1537) },
                    { -1821434424, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1479), 905579914, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1480) },
                    { -1821434424, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1464), 901803945, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1466) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1821434424, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1422), 913233236, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1423) },
                    { -1821434424, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1406), 574334725, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1408) },
                    { -1821434424, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1521), 154557250, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1523) },
                    { -1821434424, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1550), 699757588, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1551) },
                    { -1821434424, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1450), 762958081, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1451) },
                    { -1821434424, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1126), 815271662, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1128) },
                    { -1543926328, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(238), 737271305, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(240) },
                    { -1543926328, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(181), 557189276, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(182) },
                    { -1543926328, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(195), 503619297, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(196) },
                    { -1543926328, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(293), 285798214, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(294) },
                    { -1543926328, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(168), 549791759, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(169) },
                    { -1543926328, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(307), 664846220, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(308) },
                    { -1543926328, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(362), 336091113, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(364) },
                    { -1543926328, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(334), 429366834, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(336) },
                    { -1543926328, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(279), 139457944, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(281) },
                    { -1543926328, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(266), 462699871, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(267) },
                    { -1543926328, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(224), 598343955, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(225) },
                    { -1543926328, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(210), 559167357, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(211) },
                    { -1543926328, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(320), 628017442, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(322) },
                    { -1543926328, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(349), 861183970, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(350) },
                    { -1543926328, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(252), 203074949, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(254) },
                    { -1543926328, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(153), 419154473, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(155) },
                    { -1404891016, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(755), 588225976, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(757) },
                    { -1404891016, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(407), 334025172, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(409) },
                    { -1404891016, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(422), 604398005, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(423) },
                    { -1404891016, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(813), 401828350, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(814) },
                    { -1404891016, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(393), 925587904, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(394) },
                    { -1404891016, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(828), 668459782, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(829) },
                    { -1404891016, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(885), 852099081, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(886) },
                    { -1404891016, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(857), 622366486, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(858) },
                    { -1404891016, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(799), 385442001, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(800) },
                    { -1404891016, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(785), 526575824, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(786) },
                    { -1404891016, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(739), 761460241, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(740) },
                    { -1404891016, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(435), 708567586, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(437) },
                    { -1404891016, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(842), 586587767, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(844) },
                    { -1404891016, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(871), 128130218, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(872) },
                    { -1404891016, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(770), 258889409, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(771) },
                    { -1404891016, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(376), 803704624, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(378) },
                    { -1232945472, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9802), 653820669, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9803) },
                    { -1232945472, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9745), 200439563, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9747) },
                    { -1232945472, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9760), 126120259, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9761) },
                    { -1232945472, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9867), 989277762, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9869) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1232945472, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9731), 358114963, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9733) },
                    { -1232945472, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9892), 741147332, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9895) },
                    { -1232945472, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(139), 472700558, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(140) },
                    { -1232945472, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9944), 336067761, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9947) },
                    { -1232945472, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9844), 618295205, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9845) },
                    { -1232945472, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9830), 151548973, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9831) },
                    { -1232945472, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9788), 710205873, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9789) },
                    { -1232945472, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9774), 549501441, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9775) },
                    { -1232945472, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9917), 560034632, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9920) },
                    { -1232945472, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(122), 891790766, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(123) },
                    { -1232945472, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9816), 429132760, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9817) },
                    { -1232945472, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9715), 975927664, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9716) },
                    { -933058024, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8404), 519141336, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8405) },
                    { -933058024, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8347), 437114988, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8348) },
                    { -933058024, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8362), 445045185, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8363) },
                    { -933058024, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8501), 614886311, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8502) },
                    { -933058024, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8333), 917648194, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8334) },
                    { -933058024, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8515), 469853336, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8516) },
                    { -933058024, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8571), 190847887, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8572) },
                    { -933058024, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8543), 336684685, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8544) },
                    { -933058024, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8487), 512505371, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8488) },
                    { -933058024, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8472), 632355551, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8473) },
                    { -933058024, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8390), 441061064, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8391) },
                    { -933058024, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8376), 283711596, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8377) },
                    { -933058024, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8529), 756681861, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8530) },
                    { -933058024, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8557), 845687921, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8558) },
                    { -933058024, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8455), 972501428, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8456) },
                    { -933058024, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8317), 483760578, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8319) },
                    { -886486104, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8972), 464434285, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8974) },
                    { -886486104, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8841), 848706782, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8842) },
                    { -886486104, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8854), 671487303, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8856) },
                    { -886486104, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9030), 759793795, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9031) },
                    { -886486104, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8826), 374149133, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8828) },
                    { -886486104, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9044), 352408102, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9045) },
                    { -886486104, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9101), 485808626, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9102) },
                    { -886486104, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9073), 133468472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9074) },
                    { -886486104, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9015), 529114043, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9016) },
                    { -886486104, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9001), 733106054, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9002) },
                    { -886486104, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8958), 626578047, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8959) },
                    { -886486104, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8942), 754716294, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8944) },
                    { -886486104, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9058), 171829494, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9059) },
                    { -886486104, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9087), 755654214, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9088) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -886486104, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8987), 238190611, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8988) },
                    { -886486104, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8813), 444159112, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8814) },
                    { -690861216, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1664), 239890203, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1665) },
                    { -690861216, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1607), 417617832, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1608) },
                    { -690861216, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1621), 470987607, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1623) },
                    { -690861216, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1720), 276643500, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1722) },
                    { -690861216, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1593), 825852210, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1595) },
                    { -690861216, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1734), 131636287, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1736) },
                    { -690861216, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1791), 272867996, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1792) },
                    { -690861216, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1762), 771949881, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1764) },
                    { -690861216, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1706), 528984623, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1708) },
                    { -690861216, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1692), 202043069, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1693) },
                    { -690861216, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1650), 510653397, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1651) },
                    { -690861216, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1636), 968254475, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1637) },
                    { -690861216, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1749), 189969272, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1750) },
                    { -690861216, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1777), 927187946, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1778) },
                    { -690861216, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1678), 316711078, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1679) },
                    { -690861216, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1579), 479169232, new DateTime(2024, 3, 28, 12, 26, 20, 792, DateTimeKind.Local).AddTicks(1580) },
                    { 1151735360, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9456), 891685727, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9458) },
                    { 1151735360, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9400), 151888074, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9401) },
                    { 1151735360, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9414), 915005411, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9415) },
                    { 1151735360, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9513), 862517093, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9514) },
                    { 1151735360, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9386), 679206125, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9387) },
                    { 1151735360, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9527), 764032139, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9530) },
                    { 1151735360, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9688), 702711569, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9690) },
                    { 1151735360, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9636), 462486302, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9639) },
                    { 1151735360, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9499), 516739634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9500) },
                    { 1151735360, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9485), 841642020, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9487) },
                    { 1151735360, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9442), 523472399, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9443) },
                    { 1151735360, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9428), 898533379, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9429) },
                    { 1151735360, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9611), 975142592, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9613) },
                    { 1151735360, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9663), 828749565, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9666) },
                    { 1151735360, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9470), 126589435, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9472) },
                    { 1151735360, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9370), 697495503, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(9372) },
                    { 1491013136, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8672), 962735611, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8673) },
                    { 1491013136, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8615), 576808968, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8617) },
                    { 1491013136, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8630), 379072855, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8631) },
                    { 1491013136, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8728), 495086258, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8730) },
                    { 1491013136, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8601), 961544074, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8602) },
                    { 1491013136, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8742), 680628441, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8743) },
                    { 1491013136, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8798), 290666233, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8800) },
                    { 1491013136, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8770), 671746923, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8771) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1491013136, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8714), 847777088, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8715) },
                    { 1491013136, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8700), 622895454, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8701) },
                    { 1491013136, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8658), 219429255, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8659) },
                    { 1491013136, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8644), 440141109, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8645) },
                    { 1491013136, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8756), 733799726, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8757) },
                    { 1491013136, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8784), 610181693, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8786) },
                    { 1491013136, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8686), 166914031, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8687) },
                    { 1491013136, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8585), 701806783, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8587) },
                    { 1508854384, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8176), 340787273, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8177) },
                    { 1508854384, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8118), 885067960, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8119) },
                    { 1508854384, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8132), 601835286, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8134) },
                    { 1508854384, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8233), 536496388, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8234) },
                    { 1508854384, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8102), 860362758, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8103) },
                    { 1508854384, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8247), 742234675, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8248) },
                    { 1508854384, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8303), 636259028, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8304) },
                    { 1508854384, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8275), 677513924, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8276) },
                    { 1508854384, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8218), 304624052, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8219) },
                    { 1508854384, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8203), 575197767, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8205) },
                    { 1508854384, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8161), 448536609, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8162) },
                    { 1508854384, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8146), 407332438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8148) },
                    { 1508854384, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8261), 253248859, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8262) },
                    { 1508854384, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8289), 991282395, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8290) },
                    { 1508854384, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8190), 586478417, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8191) },
                    { 1508854384, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8078), 863746613, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8080) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 127161925, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6170), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6168), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6169), 404497094 },
                    { 170989861, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5830), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5827), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5829), 829459157 },
                    { 199072347, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6216), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6214), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6215), 404497094 },
                    { 205211850, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6339), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6336), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6337), 829459157 },
                    { 238925190, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6247), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6244), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6245), 829459157 },
                    { 255154391, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6123), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6120), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6121), 404497094 },
                    { 281853997, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6138), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6135), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6137), 755840185 },
                    { 292734529, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6027), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6024), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6026), 404497094 },
                    { 297998500, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5846), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5843), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5845), 404497094 },
                    { 319155741, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5930), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5927), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5929), 829459157 },
                    { 332657786, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6186), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6183), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6184), 755840185 },
                    { 406647195, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6153), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6150), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6151), 829459157 },
                    { 406837811, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6092), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6089), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6090), 755840185 },
                    { 437487847, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5862), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5859), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5860), 755840185 },
                    { 438494311, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6460), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6458), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6459), 829459157 },
                    { 476724566, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6045), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6042), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6044), 755840185 },
                    { 487868174, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6493), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6489), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6491), 755840185 },
                    { 501270063, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6232), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6229), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6230), 755840185 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 509761331, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6262), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6259), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6260), 404497094 },
                    { 612901425, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6427), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6424), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6425), 404497094 },
                    { 615415017, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6308), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6305), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6306), 404497094 },
                    { 641004874, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6509), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6506), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6508), 829459157 },
                    { 648351250, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6201), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6199), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6200), 829459157 },
                    { 676314947, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6061), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6058), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6059), 829459157 },
                    { 703540328, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5808), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5804), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5805), 755840185 },
                    { 706097944, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6445), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6442), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6443), 755840185 },
                    { 795536579, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5968), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5964), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5966), 755840185 },
                    { 809212994, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6277), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6275), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6276), 755840185 },
                    { 813485729, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6324), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6321), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6322), 755840185 },
                    { 852489051, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6524), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6522), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6523), 404497094 },
                    { 857711843, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6010), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6007), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6009), 829459157 },
                    { 867706436, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6354), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6351), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6352), 404497094 },
                    { 891283526, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5951), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5948), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(5949), 404497094 },
                    { 902111087, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6410), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6408), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6409), 829459157 },
                    { 941261554, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6476), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6473), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6474), 404497094 },
                    { 959231909, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6108), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6105), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6106), 829459157 },
                    { 975660309, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6076), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6074), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6075), 404497094 },
                    { 983784432, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6369), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6366), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6368), 755840185 },
                    { 992059818, new DateTime(2024, 4, 8, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6293), 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6290), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6291), 829459157 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124971835, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7026), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7028), 218567543 },
                    { 146174461, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7068), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7069), 348358404 },
                    { 188530926, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7364), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7365), 296131956 },
                    { 190169678, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7660), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7662), 337561976 },
                    { 193845977, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7392), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7393), 348358404 },
                    { 196986045, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7211), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7212), 428559813 },
                    { 202003666, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6674), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6675), 227945353 },
                    { 205451313, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7040), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7042), 296131956 },
                    { 215349158, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6871), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6872), 348358404 },
                    { 228924893, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7814), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7815), 348358404 },
                    { 242963861, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8021), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8022), 218567543 },
                    { 249756001, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6885), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6886), 428559813 },
                    { 251045410, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7054), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7055), 361053100 },
                    { 259426138, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7529), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7530), 337561976 },
                    { 270585846, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7419), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7421), 227945353 },
                    { 271891510, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7295), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7296), 348358404 },
                    { 285669724, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6799), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6800), 227945353 },
                    { 293941209, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8049), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8050), 361053100 },
                    { 303062289, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7884), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7886), 296131956 },
                    { 303306308, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7323), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7324), 227945353 },
                    { 306198659, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7447), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7448), 218567543 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 308031208, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6956), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6958), 361053100 },
                    { 322209142, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7110), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7111), 337561976 },
                    { 326997287, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7688), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7690), 296131956 },
                    { 333240287, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7616), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7618), 348358404 },
                    { 337298430, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7600), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7601), 361053100 },
                    { 352547595, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7123), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7125), 218567543 },
                    { 358720991, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7502), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7503), 428559813 },
                    { 361699087, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7942), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7944), 227945353 },
                    { 364110032, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7716), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7717), 348358404 },
                    { 371058092, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6929), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6930), 218567543 },
                    { 377914867, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6943), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6944), 296131956 },
                    { 381385765, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7013), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7014), 337561976 },
                    { 383072078, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7758), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7759), 337561976 },
                    { 383651583, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7870), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7872), 218567543 },
                    { 401077376, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6758), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6759), 428559813 },
                    { 401390791, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6857), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6858), 361053100 },
                    { 402841058, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7912), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7913), 348358404 },
                    { 428755431, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7800), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7801), 361053100 },
                    { 441518317, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7730), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7731), 428559813 },
                    { 468189757, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6999), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7000), 227945353 },
                    { 494132985, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8006), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8007), 337561976 },
                    { 500953427, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7082), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7083), 428559813 },
                    { 523679977, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6971), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6972), 348358404 },
                    { 535826520, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6900), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6901), 227945353 },
                    { 544154513, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6744), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6746), 348358404 },
                    { 554845254, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7786), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7788), 296131956 },
                    { 564918101, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6913), 1491013136, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6915), 337561976 },
                    { 573881042, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6731), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6732), 361053100 },
                    { 577738920, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6702), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6703), 218567543 },
                    { 579233297, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7350), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7351), 218567543 },
                    { 589179984, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7253), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7254), 218567543 },
                    { 595443221, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7828), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7830), 428559813 },
                    { 604832742, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7096), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7097), 227945353 },
                    { 620340098, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7267), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7268), 296131956 },
                    { 621814224, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7543), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7544), 218567543 },
                    { 626894919, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7674), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7676), 218567543 },
                    { 639680325, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7474), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7475), 361053100 },
                    { 643413212, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7225), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7226), 227945353 },
                    { 645803660, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7281), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7282), 361053100 },
                    { 648389242, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7927), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7928), 428559813 },
                    { 652783666, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8035), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8036), 296131956 },
                    { 672402452, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7460), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7462), 296131956 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 679416677, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7406), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7407), 428559813 },
                    { 688007986, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7137), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7138), 296131956 },
                    { 691224026, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7378), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7379), 361053100 },
                    { 708358583, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7646), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7647), 227945353 },
                    { 716615977, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6815), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6816), 337561976 },
                    { 719133075, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6985), -886486104, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6986), 428559813 },
                    { 720651576, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8062), -872341936, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(8064), 348358404 },
                    { 724428475, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7309), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7310), 428559813 },
                    { 727980107, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7181), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7182), 361053100 },
                    { 729382395, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7433), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7434), 337561976 },
                    { 739793708, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7856), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7858), 337561976 },
                    { 740196533, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7557), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7558), 296131956 },
                    { 743981654, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6829), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6831), 218567543 },
                    { 766422444, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7632), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7633), 428559813 },
                    { 772244786, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7744), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7745), 227945353 },
                    { 779648243, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6843), -933058024, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6844), 296131956 },
                    { 785161838, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7337), -1232945472, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7338), 337561976 },
                    { 787468103, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7239), 1151735360, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7240), 337561976 },
                    { 806756689, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7196), -2017322880, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7197), 348358404 },
                    { 812734356, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7842), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7844), 227945353 },
                    { 831920703, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7702), -1848123296, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7703), 361053100 },
                    { 855901519, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7488), -1543926328, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7489), 348358404 },
                    { 857114698, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7515), -1404891016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7517), 227945353 },
                    { 886033077, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7898), -690861216, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7900), 361053100 },
                    { 912956631, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6651), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6653), 428559813 },
                    { 943678343, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6688), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6690), 337561976 },
                    { 967950251, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6716), 1508854384, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(6717), 296131956 },
                    { 978035975, 0f, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7772), -1821434424, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(7773), 218567543 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 270248835, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2880), -18144008, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2882) },
                    { 333687113, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2770), -421969450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2772) },
                    { 464075419, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2865), -1370065261, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2866) },
                    { 488505096, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2724), -1074589123, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2725) },
                    { 513540116, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2802), -1898992507, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2803) },
                    { 555871266, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2787), 1408958150, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2788) },
                    { 615355365, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2832), -1901982208, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2834) },
                    { 651371108, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2754), -1347235190, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2756) },
                    { 720479382, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2709), -147566150, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2710) },
                    { 728138796, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2739), 1462606853, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2741) },
                    { 856292555, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2849), -1469629102, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2851) },
                    { 894793994, 778831837, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2817), -1172421872, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2818) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 377056530, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1999), false, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2001), "Project Manager", 778831837 },
                    { 991258311, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1833), false, false, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(1835), "Secretariat", 778831837 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 778831837, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4240), 725668459, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4242) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 333687113, 377056530, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2487), 207687124, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2489) },
                    { 488505096, 377056530, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2457), 1986200780, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2458) },
                    { 513540116, 377056530, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2518), -1841550236, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2520) },
                    { 555871266, 377056530, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2502), -1896024203, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2504) },
                    { 594120758, 377056530, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2472), -471515287, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2473) },
                    { 720479382, 377056530, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2442), -734090498, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2443) },
                    { 333687113, 991258311, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3477), -1612140911, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3478) },
                    { 488505096, 991258311, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3462), 1635053171, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3463) },
                    { 513540116, 991258311, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3507), -1050995375, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3508) },
                    { 555871266, 991258311, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3492), -975530159, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3493) },
                    { 720479382, 991258311, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3409), 1881401630, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3448) },
                    { 894793994, 991258311, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3523), -27045409, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3524) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 912040338, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2028), false, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2030), "Engineer", 377056530 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 991258311, 201158868, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3607), 692495996, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3608) },
                    { 377056530, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4911), 78035944, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4913) },
                    { 377056530, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4896), 130706298, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4897) },
                    { 377056530, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4879), 52665984, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4880) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 289949473, 912040338, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2377), -2037023567, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2379) },
                    { 333687113, 912040338, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2394), -806588617, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2395) },
                    { 488505096, 912040338, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2360), -1607886080, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2362) },
                    { 513540116, 912040338, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2425), -582816082, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2426) },
                    { 555871266, 912040338, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2410), -199884653, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2411) },
                    { 720479382, 912040338, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2344), -1092634694, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2345) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 340637499, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2141), false, true, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2143), "Designer", 912040338 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 912040338, 136265368, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4315), 932085573, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4317) },
                    { 912040338, 222609572, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4051), 289698087, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4052) },
                    { 912040338, 231511305, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4099), 440170673, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4100) },
                    { 912040338, 276236016, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4510), 173714915, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4512) },
                    { 912040338, 317205777, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4004), 646428505, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4005) },
                    { 912040338, 432610301, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4559), 280809044, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4561) },
                    { 912040338, 473123990, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4777), 741930798, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4778) },
                    { 912040338, 487891438, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4653), 469988096, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4654) },
                    { 912040338, 565596634, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4463), 663170491, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4464) },
                    { 912040338, 705169641, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4416), 935462992, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4417) },
                    { 912040338, 729524521, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4210), 892836655, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4211) },
                    { 912040338, 736777450, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4147), 415848290, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4149) },
                    { 912040338, 758153546, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4607), 198152753, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4608) },
                    { 912040338, 780602166, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4730), 915658670, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4731) },
                    { 912040338, 857452372, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4363), 873399941, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(4365) },
                    { 912040338, 929166556, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3955), 983579749, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3957) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 333687113, 340637499, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2252), -1290408898, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2327) },
                    { 488505096, 340637499, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2235), -1056795011, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2237) },
                    { 720479382, 340637499, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2208), -1502406782, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(2210) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 340637499, 478822725, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3905), 674887338, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3907) },
                    { 340637499, 943583034, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3662), 560110100, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3664) },
                    { 340637499, 949772354, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3826), 497638153, new DateTime(2024, 3, 28, 12, 26, 20, 791, DateTimeKind.Local).AddTicks(3827) }
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
                name: "IX_Issues_ProjectId",
                table: "Issues",
                column: "ProjectId");

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
                name: "FK_Issues_Projects_ProjectId",
                table: "Issues",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
