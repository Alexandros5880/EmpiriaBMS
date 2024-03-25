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
                    { 167439396, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4140), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4141), "Fire Detection" },
                    { 215350201, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4128), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4129), "Drainage" },
                    { 232447979, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4103), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4104), "Sewage" },
                    { 260609659, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4240), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4241), "BMS" },
                    { 423335734, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4264), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4265), "Energy Efficiency" },
                    { 455729248, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4154), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4155), "Fire Suppression" },
                    { 473622205, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4166), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4168), "Elevators" },
                    { 511169105, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4178), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4179), "Natural Gas" },
                    { 533730998, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4228), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4229), "CCTV" },
                    { 546738970, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4276), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4277), "Outsource" },
                    { 603543252, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4313), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4314), "DWG Admin/Clearing" },
                    { 614124399, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4084), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4085), "HVAC" },
                    { 625076865, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4204), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4205), "Structured Cabling" },
                    { 675808513, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4252), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4253), "Photovoltaics" },
                    { 798074789, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4301), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4302), "Construction Supervision" },
                    { 822968974, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4216), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4218), "Burglar Alarm" },
                    { 859821994, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4328), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4329), "Project Manager Hours" },
                    { 914552017, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4288), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4289), "TenderDocument" },
                    { 953420279, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4191), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4192), "Power Distribution" },
                    { 993789144, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4116), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4117), "Potable Water" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 237445791, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4657), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4658), "Calculations" },
                    { 297929891, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4637), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4638), "Documents" },
                    { 586442767, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4670), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4672), "Drawings" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 335352332, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5321), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5322), "On-Site" },
                    { 349296592, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5285), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5286), "Communications" },
                    { 386442323, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5334), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5335), "Meetings" },
                    { 487251312, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5373), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5375), "Hours To Be Raised" },
                    { 520138413, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5308), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5309), "Printing" },
                    { 630390973, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5346), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5347), "Administration" },
                    { 991955173, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5360), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5361), "Soft Copy" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 213336185, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1580), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1581), "Add Project On Dashboard", 12 },
                    { 246730926, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1443), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1445), "Dashboard Assign Designer", 3 },
                    { 328412620, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1458), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1459), "Dashboard Assign Engineer", 4 },
                    { 422779947, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1567), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1568), "See All Projects", 11 },
                    { 458485878, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1533), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1534), "See All Disciplines", 9 },
                    { 504155641, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1475), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1476), "Dashboard Assign Project Manager", 5 },
                    { 510954614, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1490), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1491), "Dashboard Add Project", 6 },
                    { 592142853, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1337), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1338), "See Dashboard Layout", 1 },
                    { 599087784, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1428), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1429), "Dashboard Edit My Hours", 2 },
                    { 703209724, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1552), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1553), "See All Drawings", 10 },
                    { 717203153, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1593), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1594), "Display Projects Code", 13 },
                    { 771102760, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1619), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1620), "Dashboard Add Deliverable", 15 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 844727609, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1606), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1607), "Dashboard Add Discipline", 14 },
                    { 862736177, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1519), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1521), "Dashboard See My Hours", 8 },
                    { 917350086, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1505), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1506), "See Admin Layout", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 141197734, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3696), "Buildings Description", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3697), "Buildings" },
                    { 500279241, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3713), "Infrastructure Description", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3714), "Infrastructure" },
                    { 599898445, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3728), "Energy Description", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3729), "Energy" },
                    { 829981620, false, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3756), "Production Management Description", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3757), "Production Management" },
                    { 848874362, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3742), "Consulting Description", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3743), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 154570527, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1734), false, false, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1735), "Customer" },
                    { 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1695), false, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1696), "CTO" },
                    { 305877908, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1762), false, false, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1763), "Secretariat" },
                    { 492895903, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1655), false, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1656), "Engineer" },
                    { 608341164, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1747), false, false, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1749), "Admin" },
                    { 634955398, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1633), false, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1635), "Designer" },
                    { 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1708), false, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1710), "CEO" },
                    { 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1681), false, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1683), "COO" },
                    { 844799763, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1721), false, false, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1722), "Guest" },
                    { 983422778, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1668), false, true, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1669), "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3221), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3222), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 225326953, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2777), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2778), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3559), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3560), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2928), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2929), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2975), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2977), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3509), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3510), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 363968519, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2830), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2831), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3364), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3366), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3604), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3605), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3461), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3463), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3072), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3073), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3316), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3318), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3269), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3270), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3651), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3652), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3413), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3414), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3023), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3024), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3138), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3140), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 807142064, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2728), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2729), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 816683019, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2640), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2641), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2879), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2880), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 197223611, "kkotsoni@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3155), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3156), 804388585 },
                    { 259966767, "dtsa@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2846), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2847), 363968519 },
                    { 337817206, "ngal@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3090), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3091), 702532667 },
                    { 363559108, "chkovras@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3039), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3040), 782355345 },
                    { 367283079, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3666), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3667), 754069989 },
                    { 388020525, "vtza@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3237), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3239), 190502107 },
                    { 472261247, "xmanarolis@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2944), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2945), 279472560 },
                    { 592362904, "gdoug@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2745), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2746), 807142064 },
                    { 619855351, "kmargeti@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3333), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3335), 715980807 },
                    { 630898653, "agretos@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3285), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3286), 726499458 },
                    { 637174252, "embiria@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2665), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2667), 816683019 },
                    { 663289154, "vpax@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2896), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2897), 819980434 },
                    { 746880868, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2687), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2688), 816683019 },
                    { 787997149, "panperivollari@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3619), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3621), 535805242 },
                    { 799772579, "blekou@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3525), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3526), 333714843 },
                    { 817301983, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3477), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3479), 681834677 },
                    { 829007338, "sparisis@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2992), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2993), 296438651 },
                    { 867028068, "pfokianou@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3429), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3431), 755192033 },
                    { 878400633, "vchontos@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3574), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3576), 273426431 },
                    { 961729941, "dtsa@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2794), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2795), 225326953 },
                    { 990397062, "haris@embiria.gr", new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3380), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3381), 455162621 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 509542377, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), new DateTime(2024, 6, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Test Description Project_PM", new DateTime(2024, 4, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 0f, new DateTime(2024, 5, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 1500L, 12L, null, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Project_PM", null, null, 829981620, 0f },
                    { 732760570, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), new DateTime(2025, 7, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Test Description Project_24", new DateTime(2025, 7, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 0f, new DateTime(2025, 7, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Project_4", 804388585, null, 848874362, 0f },
                    { 739398544, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), new DateTime(2024, 7, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Test Description Project_6", new DateTime(2024, 7, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 0f, new DateTime(2024, 7, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Project_2", 804388585, null, 500279241, 0f },
                    { 863588589, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), new DateTime(2024, 4, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Test Description Project_3", new DateTime(2024, 4, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 0f, new DateTime(2024, 4, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Project_1", 804388585, null, 141197734, 0f },
                    { 933294545, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), new DateTime(2024, 12, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Test Description Project_6", new DateTime(2024, 12, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 0f, new DateTime(2024, 12, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), 1500L, 12L, 10000.0, new DateTime(2024, 3, 25, 17, 10, 1, 822, DateTimeKind.Local).AddTicks(8665), "Project_3", 804388585, null, 599898445, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 592142853, 154570527, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2466), -1069113181, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2467) },
                    { 213336185, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2231), -799189456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2232) },
                    { 422779947, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2215), -526258300, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2217) },
                    { 458485878, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2185), -2002927477, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2186) },
                    { 504155641, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2139), 350714084, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2140) },
                    { 510954614, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2154), 752608193, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2155) },
                    { 592142853, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2110), -356640290, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2112) },
                    { 599087784, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2124), 1558724756, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2125) },
                    { 703209724, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2200), -1528054402, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2202) },
                    { 771102760, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2263), 808352735, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2265) },
                    { 844727609, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2247), -655100099, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2249) },
                    { 862736177, 206308020, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2169), -172178617, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2171) },
                    { 422779947, 305877908, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2622), 1614480962, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2624) },
                    { 458485878, 305877908, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2591), -1225533334, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2592) },
                    { 592142853, 305877908, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2544), -1906412660, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2545) },
                    { 599087784, 305877908, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2559), 646451321, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2561) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 703209724, 305877908, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2607), -424166336, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2608) },
                    { 862736177, 305877908, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2575), -176605726, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2577) },
                    { 246730926, 492895903, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1849), -1492587940, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1850) },
                    { 458485878, 492895903, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1877), -1743649852, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1878) },
                    { 592142853, 492895903, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1821), 1926183794, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1823) },
                    { 599087784, 492895903, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1835), -1827857614, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1836) },
                    { 703209724, 492895903, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1890), 1860819899, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1892) },
                    { 862736177, 492895903, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1863), -779026828, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1864) },
                    { 422779947, 608341164, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2528), 290090354, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2530) },
                    { 458485878, 608341164, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2497), 1721239664, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2498) },
                    { 703209724, 608341164, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2513), -1379920387, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2514) },
                    { 917350086, 608341164, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2481), -1699564661, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2483) },
                    { 592142853, 634955398, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1775), -1384529678, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1776) },
                    { 599087784, 634955398, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1794), 188131262, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1795) },
                    { 862736177, 634955398, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1808), 2020487724, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1809) },
                    { 213336185, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2435), -1691658035, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2437) },
                    { 246730926, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2309), 1323472325, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2310) },
                    { 328412620, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2324), -1082753531, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2326) },
                    { 422779947, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2404), -619806068, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2406) },
                    { 458485878, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2374), -716673707, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2375) },
                    { 504155641, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2340), 1241391434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2341) },
                    { 510954614, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2358), -16096801, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2360) },
                    { 592142853, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2278), -1717384706, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2280) },
                    { 599087784, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2294), 1930161587, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2295) },
                    { 703209724, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2389), -652142600, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2391) },
                    { 717203153, 679116034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2420), -1143091610, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2421) },
                    { 246730926, 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2017), -1631344342, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2018) },
                    { 328412620, 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2031), -632698951, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2032) },
                    { 422779947, 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2097), -735952373, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2098) },
                    { 458485878, 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2071), -100323094, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2072) },
                    { 504155641, 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2044), -329279336, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2045) },
                    { 592142853, 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1989), -526152415, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1991) },
                    { 599087784, 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2002), 1665286047, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2004) },
                    { 703209724, 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2084), 331083905, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2085) },
                    { 862736177, 707674676, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2057), 1548782861, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2059) },
                    { 592142853, 844799763, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2450), -1291748818, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2452) },
                    { 328412620, 983422778, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1932), 866835950, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1933) },
                    { 458485878, 983422778, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1963), -2064633259, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1964) },
                    { 592142853, 983422778, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1905), -1461911489, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1906) },
                    { 599087784, 983422778, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1918), -1837219981, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1919) },
                    { 703209724, 983422778, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1976), 1431433706, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1977) },
                    { 862736177, 983422778, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1949), 1177747173, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(1950) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 492895903, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3253), 735767172, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3255) },
                    { 634955398, 225326953, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2810), 836381639, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2811) },
                    { 492895903, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3589), 480895617, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3590) },
                    { 492895903, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2959), 124453556, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2961) },
                    { 492895903, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3007), 611641739, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3008) },
                    { 492895903, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3539), 302457361, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3540) },
                    { 634955398, 363968519, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2863), 621187887, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2864) },
                    { 492895903, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3396), 253026500, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3397) },
                    { 983422778, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3802), 324958752, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3804) },
                    { 492895903, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3634), 973037555, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3635) },
                    { 492895903, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3493), 987469438, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3495) },
                    { 492895903, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3106), 593979788, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3107) },
                    { 679116034, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3122), 461428699, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3124) },
                    { 492895903, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3348), 278357798, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3350) },
                    { 492895903, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3300), 598309932, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3301) },
                    { 492895903, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3680), 536540018, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3682) },
                    { 492895903, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3445), 504697927, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3446) },
                    { 492895903, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3055), 993447942, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3057) },
                    { 206308020, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3205), 759603108, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3207) },
                    { 492895903, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3171), 742706002, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3172) },
                    { 707674676, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3186), 702486942, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3188) },
                    { 983422778, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3787), 93751839, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3789) },
                    { 634955398, 807142064, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2761), 910921798, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2762) },
                    { 305877908, 816683019, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2705), 904009992, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2706) },
                    { 492895903, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2911), 493672043, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(2913) },
                    { 983422778, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3772), 183958879, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3773) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2101603080, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4413), 0f, 400L, 50L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4414), 739398544, 914552017, null },
                    { -1778038240, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4621), 0f, 500L, 0L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4622), 509542377, 859821994, null },
                    { -1612097328, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4594), 0f, 408L, 51L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4595), 732760570, 546738970, null },
                    { -1597771632, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4360), 0f, 400L, 50L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4361), 863588589, 533730998, null },
                    { -1591024832, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4456), 0f, 400L, 50L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4458), 933294545, 993789144, null },
                    { -1573284304, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4426), 0f, 408L, 51L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4428), 739398544, 798074789, null },
                    { -1273528480, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4484), 0f, 416L, 52L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4485), 933294545, 953420279, null },
                    { -702801432, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4579), 0f, 400L, 50L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4580), 732760570, 625076865, null },
                    { -309892208, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4442), 0f, 416L, 52L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4444), 739398544, 625076865, null },
                    { 1115109648, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4384), 0f, 408L, 51L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4385), 863588589, 993789144, null },
                    { 1563194824, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4607), 0f, 416L, 52L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4609), 732760570, 473622205, null },
                    { 1665354048, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4398), 0f, 416L, 52L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4399), 863588589, 215350201, null },
                    { 1908377456, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4470), 0f, 408L, 51L, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4472), 933294545, 423335734, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 309350355, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3870), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3872), 3010.0, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3871), "Signature 142346", 11822, 863588589, 1.0, 17.0 },
                    { 400768795, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3911), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3913), 3100.0, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(3912), "Signature 142348", 49469, 739398544, 2.0, 24.0 },
                    { 507278477, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4049), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4051), 13000.0, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4050), "Signature 142348", 26016, 732760570, 4.0, 24.0 },
                    { 877020575, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4015), new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4018), 4000.0, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4016), "Signature 1423412", 72044, 933294545, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2101603080, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7257), 852841597, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7258) },
                    { -2101603080, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7342), 319349442, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7343) },
                    { -2101603080, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7198), 243340702, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7199) },
                    { -2101603080, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7210), 860805596, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7211) },
                    { -2101603080, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7330), 558320846, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7331) },
                    { -2101603080, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7293), 840191452, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7295) },
                    { -2101603080, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7354), 313341892, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7355) },
                    { -2101603080, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7318), 892307992, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7319) },
                    { -2101603080, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7234), 131073032, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7235) },
                    { -2101603080, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7281), 596118779, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7282) },
                    { -2101603080, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7269), 260893596, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7270) },
                    { -2101603080, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7366), 542950906, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7367) },
                    { -2101603080, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7306), 902552446, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7307) },
                    { -2101603080, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7222), 881701110, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7223) },
                    { -2101603080, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7246), 767582375, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7247) },
                    { -2101603080, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7186), 696160607, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7187) },
                    { -1612097328, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8776), 429514607, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8777) },
                    { -1612097328, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8859), 721424685, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8860) },
                    { -1612097328, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8716), 739728591, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8717) },
                    { -1612097328, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8728), 994236208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8729) },
                    { -1612097328, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8847), 790829609, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8848) },
                    { -1612097328, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8812), 226828866, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8813) },
                    { -1612097328, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8871), 760054479, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8872) },
                    { -1612097328, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8835), 493407403, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8836) },
                    { -1612097328, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8752), 710000324, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8753) },
                    { -1612097328, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8800), 869854970, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8801) },
                    { -1612097328, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8788), 898740771, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8789) },
                    { -1612097328, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8883), 255751695, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8884) },
                    { -1612097328, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8823), 391221269, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8824) },
                    { -1612097328, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8740), 882516001, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8741) },
                    { -1612097328, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8764), 708570724, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8765) },
                    { -1612097328, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8704), 654796547, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8705) },
                    { -1597771632, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6652), 886917489, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6653) },
                    { -1597771632, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6740), 124658503, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6741) },
                    { -1597771632, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6571), 341472217, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6573) },
                    { -1597771632, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6584), 296615299, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6585) },
                    { -1597771632, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6728), 678624095, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6729) },
                    { -1597771632, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6692), 882245000, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6693) },
                    { -1597771632, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6752), 850944535, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6753) },
                    { -1597771632, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6716), 567125296, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6717) },
                    { -1597771632, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6608), 128962413, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6609) },
                    { -1597771632, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6678), 981388926, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6679) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1597771632, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6665), 374939513, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6666) },
                    { -1597771632, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6764), 317925407, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6765) },
                    { -1597771632, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6704), 476579362, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6705) },
                    { -1597771632, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6596), 758734705, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6597) },
                    { -1597771632, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6620), 864756969, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6621) },
                    { -1597771632, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6552), 353399789, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6553) },
                    { -1591024832, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7942), 144692015, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7943) },
                    { -1591024832, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8032), 318808439, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8033) },
                    { -1591024832, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7877), 342823779, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7878) },
                    { -1591024832, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7890), 774887262, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7891) },
                    { -1591024832, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8019), 794048721, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8020) },
                    { -1591024832, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7981), 248111187, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7982) },
                    { -1591024832, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8045), 894492569, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8046) },
                    { -1591024832, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8006), 631129242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8007) },
                    { -1591024832, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7916), 137656857, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7917) },
                    { -1591024832, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7968), 433423864, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7969) },
                    { -1591024832, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7955), 502902833, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7956) },
                    { -1591024832, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8058), 789021113, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8059) },
                    { -1591024832, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7993), 363380926, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7995) },
                    { -1591024832, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7903), 427907263, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7904) },
                    { -1591024832, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7929), 458531514, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7930) },
                    { -1591024832, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7864), 704850582, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7865) },
                    { -1573284304, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7482), 509246255, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7483) },
                    { -1573284304, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7566), 576913522, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7568) },
                    { -1573284304, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7420), 399050989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7421) },
                    { -1573284304, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7433), 427322035, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7434) },
                    { -1573284304, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7554), 623475028, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7555) },
                    { -1573284304, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7518), 698290905, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7519) },
                    { -1573284304, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7578), 827590284, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7579) },
                    { -1573284304, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7542), 550532413, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7543) },
                    { -1573284304, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7458), 240970266, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7459) },
                    { -1573284304, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7506), 756965357, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7507) },
                    { -1573284304, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7494), 266043115, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7495) },
                    { -1573284304, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7590), 786542697, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7591) },
                    { -1573284304, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7530), 362503228, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7531) },
                    { -1573284304, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7445), 617617078, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7446) },
                    { -1573284304, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7470), 942248021, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7471) },
                    { -1573284304, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7406), 769761830, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7407) },
                    { -1273528480, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8370), 535739860, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8371) },
                    { -1273528480, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8454), 163215364, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8455) },
                    { -1273528480, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8310), 514477648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8311) },
                    { -1273528480, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8322), 976113136, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8323) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1273528480, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8442), 729792429, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8443) },
                    { -1273528480, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8406), 940784096, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8407) },
                    { -1273528480, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8466), 604765340, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8467) },
                    { -1273528480, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8430), 746114937, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8431) },
                    { -1273528480, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8346), 977980548, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8347) },
                    { -1273528480, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8394), 674010848, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8395) },
                    { -1273528480, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8382), 227784037, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8383) },
                    { -1273528480, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8478), 612980951, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8479) },
                    { -1273528480, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8418), 637951209, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8419) },
                    { -1273528480, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8334), 532675889, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8335) },
                    { -1273528480, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8358), 877247309, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8359) },
                    { -1273528480, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8295), 516628414, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8296) },
                    { -702801432, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8584), 699544849, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8585) },
                    { -702801432, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8668), 727586659, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8669) },
                    { -702801432, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8523), 562828520, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8524) },
                    { -702801432, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8536), 729961523, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8537) },
                    { -702801432, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8656), 759086583, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8657) },
                    { -702801432, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8620), 554154546, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8621) },
                    { -702801432, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8680), 466389371, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8681) },
                    { -702801432, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8644), 234216702, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8645) },
                    { -702801432, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8560), 144089932, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8561) },
                    { -702801432, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8608), 543665789, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8609) },
                    { -702801432, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8596), 525161531, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8597) },
                    { -702801432, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8692), 829449641, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8693) },
                    { -702801432, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8632), 415867304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8633) },
                    { -702801432, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8547), 801271126, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8549) },
                    { -702801432, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8572), 631649746, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8573) },
                    { -702801432, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8490), 347499085, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8491) },
                    { -309892208, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7676), 375460234, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7677) },
                    { -309892208, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7824), 556418414, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7825) },
                    { -309892208, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7615), 458233274, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7616) },
                    { -309892208, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7627), 638050095, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7628) },
                    { -309892208, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7811), 489655132, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7812) },
                    { -309892208, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7712), 669979936, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7713) },
                    { -309892208, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7837), 394795669, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7838) },
                    { -309892208, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7796), 153452559, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7798) },
                    { -309892208, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7651), 494677838, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7652) },
                    { -309892208, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7700), 483130724, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7701) },
                    { -309892208, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7688), 665956171, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7689) },
                    { -309892208, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7850), 988455654, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7851) },
                    { -309892208, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7724), 183792225, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7725) },
                    { -309892208, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7639), 671834509, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7640) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -309892208, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7663), 682846677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7664) },
                    { -309892208, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7602), 203681571, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7604) },
                    { 1115109648, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6850), 317394165, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6851) },
                    { 1115109648, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6934), 550557303, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6935) },
                    { 1115109648, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6790), 722012337, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6791) },
                    { 1115109648, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6802), 283643595, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6803) },
                    { 1115109648, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6922), 148212007, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6923) },
                    { 1115109648, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6886), 861488476, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6887) },
                    { 1115109648, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6945), 705540874, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6946) },
                    { 1115109648, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6909), 487004826, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6911) },
                    { 1115109648, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6826), 940351522, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6827) },
                    { 1115109648, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6874), 864513317, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6875) },
                    { 1115109648, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6862), 349295060, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6863) },
                    { 1115109648, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6957), 226990799, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6958) },
                    { 1115109648, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6897), 348311113, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6899) },
                    { 1115109648, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6814), 871401305, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6815) },
                    { 1115109648, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6838), 560524813, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6839) },
                    { 1115109648, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6777), 393137293, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6778) },
                    { 1563194824, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8990), 457237918, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8991) },
                    { 1563194824, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9073), 766807181, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9074) },
                    { 1563194824, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8930), 337001464, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8931) },
                    { 1563194824, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8942), 464960745, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8943) },
                    { 1563194824, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9061), 548784793, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9062) },
                    { 1563194824, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9026), 865660103, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9027) },
                    { 1563194824, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9085), 276868493, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9086) },
                    { 1563194824, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9049), 634956265, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9050) },
                    { 1563194824, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8966), 956993409, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8967) },
                    { 1563194824, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9013), 306058387, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9015) },
                    { 1563194824, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9002), 954548478, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9003) },
                    { 1563194824, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9096), 342140843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9098) },
                    { 1563194824, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9037), 656265436, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(9038) },
                    { 1563194824, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8954), 942503236, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8955) },
                    { 1563194824, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8977), 911400346, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8979) },
                    { 1563194824, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8916), 244209844, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8917) },
                    { 1665354048, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7065), 819614301, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7066) },
                    { 1665354048, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7149), 321003670, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7151) },
                    { 1665354048, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7003), 349274928, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7004) },
                    { 1665354048, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7016), 198290097, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7018) },
                    { 1665354048, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7137), 920471525, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7138) },
                    { 1665354048, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7101), 489269170, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7102) },
                    { 1665354048, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7161), 677275722, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7162) },
                    { 1665354048, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7125), 328465372, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7127) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1665354048, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7041), 971016022, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7042) },
                    { 1665354048, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7089), 913785451, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7090) },
                    { 1665354048, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7077), 513051385, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7078) },
                    { 1665354048, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7173), 890747176, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7174) },
                    { 1665354048, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7113), 545888617, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7114) },
                    { 1665354048, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7029), 945166455, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7030) },
                    { 1665354048, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7053), 446073056, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(7054) },
                    { 1665354048, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6969), 175893054, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6970) },
                    { 1908377456, 190502107, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8148), 174488103, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8149) },
                    { 1908377456, 273426431, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8258), 858696916, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8259) },
                    { 1908377456, 279472560, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8084), 918953977, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8085) },
                    { 1908377456, 296438651, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8097), 701122034, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8098) },
                    { 1908377456, 333714843, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8246), 629898959, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8247) },
                    { 1908377456, 455162621, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8187), 951217491, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8188) },
                    { 1908377456, 535805242, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8271), 967654508, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8272) },
                    { 1908377456, 681834677, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8233), 445442156, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8234) },
                    { 1908377456, 702532667, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8123), 649583360, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8124) },
                    { 1908377456, 715980807, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8174), 820874845, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8176) },
                    { 1908377456, 726499458, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8161), 928734088, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8162) },
                    { 1908377456, 754069989, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8283), 277813333, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8284) },
                    { 1908377456, 755192033, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8220), 458014470, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8221) },
                    { 1908377456, 782355345, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8110), 438546319, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8111) },
                    { 1908377456, 804388585, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8135), 996922605, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8137) },
                    { 1908377456, 819980434, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8071), 834514808, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(8072) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 190652928, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5221), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5218), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5219), 297929891 },
                    { 240017744, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4752), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4749), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4751), 237445791 },
                    { 253166074, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5089), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5086), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5087), 586442767 },
                    { 265918791, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4882), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4880), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4881), 237445791 },
                    { 285852153, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4841), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4838), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4839), 237445791 },
                    { 299803283, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5034), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5031), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5032), 237445791 },
                    { 312639606, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4977), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4974), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4976), 297929891 },
                    { 328949431, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5047), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5045), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5046), 586442767 },
                    { 359408020, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5270), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5268), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5269), 586442767 },
                    { 368059346, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5206), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5203), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5204), 586442767 },
                    { 369898107, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5193), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5191), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5192), 237445791 },
                    { 423091050, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4910), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4907), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4908), 297929891 },
                    { 440449706, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4723), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4721), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4722), 586442767 },
                    { 462275873, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5005), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5002), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5004), 586442767 },
                    { 467364336, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4855), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4852), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4853), 586442767 },
                    { 475763724, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5140), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5137), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5138), 297929891 },
                    { 500793839, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5114), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5112), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5113), 237445791 },
                    { 515826582, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4923), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4921), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4922), 237445791 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 554655570, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4783), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4780), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4781), 297929891 },
                    { 586900391, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4826), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4823), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4825), 297929891 },
                    { 591252888, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4709), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4706), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4707), 237445791 },
                    { 621311281, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4962), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4959), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4960), 586442767 },
                    { 635327925, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5180), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5178), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5179), 297929891 },
                    { 638355924, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5102), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5099), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5100), 297929891 },
                    { 680089123, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4991), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4989), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4990), 237445791 },
                    { 688032254, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4797), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4794), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4795), 237445791 },
                    { 688348000, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4688), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4685), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4686), 297929891 },
                    { 757262852, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4896), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4893), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4894), 586442767 },
                    { 787504589, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5061), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5059), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5060), 297929891 },
                    { 793209856, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5152), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5150), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5151), 237445791 },
                    { 803542558, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5237), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5234), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5235), 237445791 },
                    { 818239809, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4810), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4808), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4809), 586442767 },
                    { 834751218, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5165), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5163), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5164), 586442767 },
                    { 898667656, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4768), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4766), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4767), 586442767 },
                    { 902488417, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4869), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4866), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4867), 297929891 },
                    { 940060203, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4738), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4735), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(4736), 297929891 },
                    { 966474337, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5075), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5072), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5073), 237445791 },
                    { 979225754, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5019), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5016), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5018), 297929891 },
                    { 981786488, new DateTime(2024, 4, 5, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5127), 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5125), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5126), 586442767 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124481492, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5601), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5603), 386442323 },
                    { 145240866, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5863), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5864), 335352332 },
                    { 159463189, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5980), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5981), 386442323 },
                    { 196249255, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6157), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6159), 630390973 },
                    { 198688124, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5731), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5732), 991955173 },
                    { 204053579, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6134), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6135), 335352332 },
                    { 204403536, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6075), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6076), 630390973 },
                    { 211237790, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6098), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6100), 487251312 },
                    { 211620358, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5779), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5780), 335352332 },
                    { 212216062, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6204), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6206), 520138413 },
                    { 218045083, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6298), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6299), 349296592 },
                    { 226955925, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5899), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5900), 991955173 },
                    { 242982510, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6526), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6527), 991955173 },
                    { 245145356, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6016), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6017), 487251312 },
                    { 250092272, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6515), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6516), 630390973 },
                    { 259121857, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5419), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5420), 335352332 },
                    { 291109891, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6382), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6383), 349296592 },
                    { 300991671, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6394), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6395), 520138413 },
                    { 308251734, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5589), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5590), 335352332 },
                    { 308999750, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5791), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5792), 386442323 },
                    { 319626518, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5565), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5566), 349296592 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 350096596, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6230), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6231), 386442323 },
                    { 354385013, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5553), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5554), 487251312 },
                    { 364581496, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5468), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5469), 487251312 },
                    { 377228655, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5992), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5993), 630390973 },
                    { 383004675, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6370), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6371), 487251312 },
                    { 390113795, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6028), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6029), 349296592 },
                    { 406204305, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6503), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6504), 386442323 },
                    { 414681211, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6253), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6254), 991955173 },
                    { 418330737, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6241), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6243), 630390973 },
                    { 426780728, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5672), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5673), 349296592 },
                    { 427655177, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5828), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5829), 487251312 },
                    { 447122693, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6479), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6481), 520138413 },
                    { 464254358, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6429), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6430), 630390973 },
                    { 477094260, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6538), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6539), 487251312 },
                    { 479821781, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6310), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6311), 520138413 },
                    { 484237327, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6181), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6182), 487251312 },
                    { 495439916, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5684), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5685), 520138413 },
                    { 509975411, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5635), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5636), 630390973 },
                    { 513749796, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5577), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5578), 520138413 },
                    { 514370446, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6110), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6111), 349296592 },
                    { 520916853, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5719), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5720), 630390973 },
                    { 525265160, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5492), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5494), 520138413 },
                    { 538908402, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5887), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5888), 630390973 },
                    { 546823665, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6040), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6041), 520138413 },
                    { 547213181, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6169), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6170), 991955173 },
                    { 555466783, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5851), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5852), 520138413 },
                    { 562334466, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5743), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5744), 487251312 },
                    { 595870178, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6322), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6323), 335352332 },
                    { 596817698, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5707), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5708), 386442323 },
                    { 597807508, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6441), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6442), 991955173 },
                    { 599013354, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5647), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5648), 991955173 },
                    { 601620599, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5695), -2101603080, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5696), 335352332 },
                    { 607331173, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6004), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6005), 991955173 },
                    { 609525756, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5815), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5817), 991955173 },
                    { 610841635, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5840), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5841), 349296592 },
                    { 617965629, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5388), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5389), 349296592 },
                    { 619527894, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6491), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6492), 335352332 },
                    { 621957490, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5430), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5431), 386442323 },
                    { 648096279, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5529), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5530), 630390973 },
                    { 675329305, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5480), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5481), 349296592 },
                    { 676636322, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6063), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6065), 386442323 },
                    { 684160898, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6217), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6219), 335352332 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 715960049, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5803), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5804), 630390973 },
                    { 722640805, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6417), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6418), 386442323 },
                    { 732955484, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6358), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6359), 991955173 },
                    { 739149120, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5505), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5506), 335352332 },
                    { 739343206, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6334), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6335), 386442323 },
                    { 755798835, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5541), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5542), 991955173 },
                    { 756558910, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6122), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6123), 520138413 },
                    { 776558857, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5934), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5935), 520138413 },
                    { 786462300, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6193), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6194), 349296592 },
                    { 786495837, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6466), -1778038240, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6467), 349296592 },
                    { 790599689, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5875), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5876), 386442323 },
                    { 792044727, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5910), -309892208, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5911), 487251312 },
                    { 813294900, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6146), -1273528480, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6147), 386442323 },
                    { 822283505, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6452), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6453), 487251312 },
                    { 828996638, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6286), -702801432, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6287), 487251312 },
                    { 829435119, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5659), 1665354048, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5660), 487251312 },
                    { 833206752, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5923), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5924), 349296592 },
                    { 836246586, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5455), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5456), 991955173 },
                    { 838230653, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6087), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6088), 991955173 },
                    { 840790087, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5406), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5408), 520138413 },
                    { 844085102, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5518), 1115109648, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5519), 386442323 },
                    { 875326356, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6406), 1563194824, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6407), 335352332 },
                    { 962090280, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5443), -1597771632, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5444), 630390973 },
                    { 965423170, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5755), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5756), 349296592 },
                    { 972980463, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6346), -1612097328, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6347), 630390973 },
                    { 973779008, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5967), -1591024832, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5968), 335352332 },
                    { 983562987, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5767), -1573284304, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(5768), 520138413 },
                    { 992657994, 0f, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6052), 1908377456, new DateTime(2024, 3, 25, 17, 10, 1, 833, DateTimeKind.Local).AddTicks(6053), 335352332 }
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
