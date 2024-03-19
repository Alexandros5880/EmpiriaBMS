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
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayCost = table.Column<double>(type: "float", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaidFee = table.Column<double>(type: "float", nullable: true),
                    DaysUntilPayment = table.Column<int>(type: "int", nullable: true),
                    PendingPayments = table.Column<double>(type: "float", nullable: true),
                    CalculationDaly = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
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
                    { 276652821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2804), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2805), "Potable Water" },
                    { 285337639, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2930), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2931), "BMS" },
                    { 390901940, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2829), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2830), "Fire Detection" },
                    { 490747887, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2867), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2868), "Natural Gas" },
                    { 514818658, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2906), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2907), "Burglar Alarm" },
                    { 583052587, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2770), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2771), "HVAC" },
                    { 600745182, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2816), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2817), "Drainage" },
                    { 669330853, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2942), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2943), "Photovoltaics" },
                    { 673260758, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2979), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2981), "TenderDocument" },
                    { 690938181, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2843), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2844), "Fire Suppression" },
                    { 742421705, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3006), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3008), "Project Manager Hours" },
                    { 751632561, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2967), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2968), "Outsource" },
                    { 794338957, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2994), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2995), "Construction Supervision" },
                    { 800355906, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2855), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2856), "Elevators" },
                    { 828495373, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2791), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2792), "Sewage" },
                    { 861854863, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2893), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2895), "Structured Cabling" },
                    { 870438231, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2955), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2956), "Energy Efficiency" },
                    { 892449013, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2918), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2919), "CCTV" },
                    { 952173011, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2879), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2881), "Power Distribution" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 673301436, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3238), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3240), "Documents" },
                    { 757859839, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3272), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3273), "Drawings" },
                    { 913605929, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3258), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3259), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 211147631, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3911), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3912), "Meetings" },
                    { 340964783, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3899), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3900), "On-Site" },
                    { 480486116, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3923), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3924), "Administration" },
                    { 646187785, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3865), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3866), "Communications" },
                    { 857255615, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3886), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3887), "Printing" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 172148237, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9717), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9718), "See Dashboard Layout", 1 },
                    { 196110467, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9870), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9872), "Dashboard Add Project", 6 },
                    { 296609203, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9825), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9826), "Dashboard Assign Designer", 3 },
                    { 518503804, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9886), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9887), "See Admin Layout", 7 },
                    { 544797477, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9900), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9901), "Dashboard See My Hours", 8 },
                    { 617431446, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9855), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9856), "Dashboard Assign Project Manager", 5 },
                    { 651776715, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9807), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9808), "Dashboard Edit My Hours", 2 },
                    { 690137601, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9914), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9915), "See All Disciplines", 9 },
                    { 731645432, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9947), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9948), "See All Projects", 11 },
                    { 766347413, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9962), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9963), "Add Project On Dashboard", 12 },
                    { 828772234, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9840), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9842), "Dashboard Assign Engineer", 4 },
                    { 932676739, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9932), new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9933), "See All Drawings", 10 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 154114338, true, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2220), "Infrastructure Description", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2221), "Infrastructure" },
                    { 157300344, true, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2234), "Energy Description", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2235), "Energy" },
                    { 231022962, false, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2262), "Production Management Description", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2263), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 285596029, true, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2202), "Buildings Description", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2203), "Buildings" },
                    { 677842999, true, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2248), "Consulting Description", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2249), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 157813450, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(76), false, false, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(77), "Guest" },
                    { 245023273, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9978), false, true, new DateTime(2024, 3, 19, 15, 27, 23, 783, DateTimeKind.Local).AddTicks(9979), "Designer" },
                    { 394255337, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1), false, true, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3), "Engineer" },
                    { 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(46), false, true, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(48), "CTO" },
                    { 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(32), false, true, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(33), "COO" },
                    { 483429475, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(17), false, true, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(18), "Project Manager" },
                    { 540637605, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(124), false, false, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(125), "Secretariat" },
                    { 565082405, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(109), false, false, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(110), "Admin" },
                    { 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(62), false, true, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(63), "CEO" },
                    { 717700357, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(95), false, false, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(96), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1642), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1643), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1475), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1476), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 283474587, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1433), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1435), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 331953890, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1018), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1020), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2115), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2116), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1559), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1560), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 432580833, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1284), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1285), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1900), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1901), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1772), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1773), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1715), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1717), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 504686469, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1107), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1109), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1984), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1985), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 590086229, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(958), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(959), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1601), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1602), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 655903525, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1388), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1390), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2157), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2158), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1857), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1858), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 696052248, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1241), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1242), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2073), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2075), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 740820310, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1341), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1342), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 791279427, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1064), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1065), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 868445772, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1197), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1198), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1942), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1943), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1814), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1815), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1517), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1518), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2029), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2031), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 151251870, "haris@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1914), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1915), 442918694 },
                    { 163177053, "pm@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1255), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1257), 696052248 },
                    { 217835714, "vchontos@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2088), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2089), 698058668 },
                    { 219182867, "coo@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1169), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1171), 504686469 },
                    { 270124536, "dtsa@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1405), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1406), 655903525 },
                    { 282047245, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1313), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1315), 432580833 },
                    { 284702546, "vtza@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1786), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1788), 458308057 },
                    { 312444943, "embiria@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1300), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1301), 432580833 },
                    { 322790780, "guest@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1212), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1213), 868445772 },
                    { 325210528, "kkotsoni@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1730), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1731), 489159360 },
                    { 359023793, "ngal@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1657), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1658), 181195075 },
                    { 361974126, "agretos@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1829), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1830), 957556366 },
                    { 388971929, "pfokianou@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1956), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1957), 868865253 },
                    { 437388902, "gdoug@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1359), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1360), 740820310 },
                    { 481247075, "xmanarolis@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1533), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1534), 963284117 },
                    { 539219173, "blekou@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2045), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2046), 986657695 },
                    { 572107533, "vpax@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1490), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1491), 207656562 },
                    { 654893285, "kmargeti@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1872), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1874), 687254840 },
                    { 655953914, "ceo@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1034), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1035), 331953890 },
                    { 675926233, "panperivollari@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2129), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2131), 381758411 },
                    { 696405197, "dtsa@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1448), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1450), 283474587 },
                    { 697965640, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(978), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(980), 590086229 },
                    { 788305234, "chkovras@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1615), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1616), 618545826 },
                    { 818645299, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2172), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2173), 678386123 },
                    { 891451347, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1998), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1999), 515058188 },
                    { 945643419, "cto@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1079), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1080), 791279427 },
                    { 965568831, "sparisis@embiria.gr", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1573), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1575), 418912568 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetails", "PendingPayments", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 124646421, true, "ALPHA", 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 111.0, 90, new DateTime(2024, 6, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 1, "Test Description Project_PM", new DateTime(2024, 4, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), new DateTime(2024, 5, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f, 1500L, 12L, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Project_PM", 45.0, new DateTime(2024, 4, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Payment Detailes For Project_PM", 2.0, null, null, 231022962, new DateTime(2024, 5, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f },
                    { 160633848, false, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 6.0, 1, new DateTime(2024, 4, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 1, "Test Description Project_4", new DateTime(2024, 4, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), new DateTime(2024, 4, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f, 1500L, 12L, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Project_1", 5.0, new DateTime(2024, 4, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Payment Detailes For Project_3", 1.0, null, null, 285596029, new DateTime(2024, 4, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f },
                    { 366579541, true, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 7.0, 4, new DateTime(2024, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 4, "Test Description Project_2", new DateTime(2024, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), new DateTime(2024, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f, 1500L, 12L, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Project_2", 5.0, new DateTime(2024, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Payment Detailes For Project_12", 2.0, null, null, 154114338, new DateTime(2024, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f },
                    { 739862122, false, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 8.0, 9, new DateTime(2024, 12, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 9, "Test Description Project_15", new DateTime(2024, 12, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), new DateTime(2024, 12, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f, 1500L, 12L, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Project_3", 5.0, new DateTime(2024, 12, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Payment Detailes For Project_15", 3.0, null, null, 157300344, new DateTime(2024, 12, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f },
                    { 981844398, true, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 9.0, 16, new DateTime(2025, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 16, "Test Description Project_8", new DateTime(2025, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), new DateTime(2025, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f, 1500L, 12L, new DateTime(2024, 3, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Project_4", 5.0, new DateTime(2025, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), "Payment Detailes For Project_4", 4.0, null, null, 677842999, new DateTime(2025, 7, 19, 15, 27, 23, 771, DateTimeKind.Local).AddTicks(4271), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 172148237, 157813450, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(781), -841489141, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(782) },
                    { 172148237, 245023273, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(139), 15210424, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(140) },
                    { 544797477, 245023273, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(180), 1274361561, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(181) },
                    { 651776715, 245023273, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(164), 1253422161, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(166) },
                    { 172148237, 394255337, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(194), -1005737647, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(195) },
                    { 296609203, 394255337, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(225), -1247725484, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(226) },
                    { 544797477, 394255337, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(239), -580201388, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(240) },
                    { 651776715, 394255337, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(209), 1970093187, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(211) },
                    { 690137601, 394255337, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(253), -14554556, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(254) },
                    { 932676739, 394255337, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(267), -1379921809, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(269) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 172148237, 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(500), -2033129627, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(502) },
                    { 196110467, 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(546), 945023081, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(548) },
                    { 544797477, 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(560), -800580910, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(562) },
                    { 617431446, 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(532), -1810666070, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(534) },
                    { 651776715, 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(518), -1098837935, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(519) },
                    { 690137601, 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(574), 735580778, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(576) },
                    { 731645432, 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(603), -982404800, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(604) },
                    { 766347413, 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(618), 1936025924, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(619) },
                    { 932676739, 416067821, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(589), -123492919, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(590) },
                    { 172148237, 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(369), -1763296604, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(370) },
                    { 296609203, 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(399), 1986071868, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(400) },
                    { 544797477, 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(443), -67629437, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(444) },
                    { 617431446, 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(429), 411829304, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(430) },
                    { 651776715, 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(384), 245719058, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(385) },
                    { 690137601, 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(458), -1936908332, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(459) },
                    { 731645432, 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(486), -717496915, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(487) },
                    { 828772234, 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(414), 130193267, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(415) },
                    { 932676739, 482099097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(472), -976071847, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(473) },
                    { 172148237, 483429475, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(283), -1108237112, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(284) },
                    { 544797477, 483429475, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(326), -1618381889, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(328) },
                    { 651776715, 483429475, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(298), 1133446982, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(300) },
                    { 690137601, 483429475, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(341), -1000058521, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(342) },
                    { 828772234, 483429475, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(313), -1498724765, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(314) },
                    { 932676739, 483429475, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(355), -241928189, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(356) },
                    { 172148237, 540637605, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(867), 1773397886, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(868) },
                    { 544797477, 540637605, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(896), -551986006, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(897) },
                    { 651776715, 540637605, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(881), 295120117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(882) },
                    { 690137601, 540637605, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(910), 1749541667, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(911) },
                    { 731645432, 540637605, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(942), 637395836, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(943) },
                    { 932676739, 540637605, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(924), -249505627, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(926) },
                    { 518503804, 565082405, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(809), -1498782770, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(810) },
                    { 690137601, 565082405, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(823), 1846985967, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(825) },
                    { 731645432, 565082405, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(852), -688873972, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(854) },
                    { 932676739, 565082405, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(838), -2008658069, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(839) },
                    { 172148237, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(633), -1409036687, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(635) },
                    { 196110467, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(707), -483386075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(708) },
                    { 296609203, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(663), -1332103504, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(665) },
                    { 518503804, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(721), -792555605, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(722) },
                    { 617431446, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(692), 1500185790, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(694) },
                    { 651776715, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(649), -1898479025, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(650) },
                    { 690137601, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(735), 107110373, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(737) },
                    { 731645432, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(766), -1860419807, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(767) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 828772234, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(678), -1594923146, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(679) },
                    { 932676739, 629223909, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(750), 1798277675, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(751) },
                    { 172148237, 717700357, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(795), 1730220404, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(796) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 394255337, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1670), 705808820, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1671) },
                    { 565082405, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1684), 644766294, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1685) },
                    { 629223909, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1701), 766975027, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1702) },
                    { 394255337, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1503), 590793046, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1504) },
                    { 483429475, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2277), 43317805, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2278) },
                    { 245023273, 283474587, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1461), 687209453, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1463) },
                    { 629223909, 331953890, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1049), 312152760, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1050) },
                    { 394255337, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2143), 929704267, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2144) },
                    { 394255337, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1586), 310424070, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1588) },
                    { 540637605, 432580833, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1326), 733589151, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1328) },
                    { 394255337, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1927), 864395120, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1928) },
                    { 483429475, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2307), 302801604, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2308) },
                    { 394255337, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1800), 428953971, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1801) },
                    { 394255337, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1744), 246577008, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1745) },
                    { 482099097, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1758), 979075529, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1759) },
                    { 483429475, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2292), 179557962, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2293) },
                    { 482099097, 504686469, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1183), 338097943, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1184) },
                    { 394255337, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2011), 480379480, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2013) },
                    { 565082405, 590086229, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(998), 700564444, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(999) },
                    { 394255337, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1628), 205175101, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1629) },
                    { 245023273, 655903525, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1418), 721972236, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1419) },
                    { 394255337, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2186), 566707803, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2187) },
                    { 394255337, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1886), 765729819, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1887) },
                    { 483429475, 696052248, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1270), 419257616, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1271) },
                    { 394255337, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2101), 201581929, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2103) },
                    { 245023273, 740820310, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1374), 531998001, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1375) },
                    { 416067821, 791279427, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1093), 589064803, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1094) },
                    { 157813450, 868445772, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1226), 232219635, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1227) },
                    { 394255337, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1970), 991575109, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1971) },
                    { 394255337, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1843), 751284583, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1844) },
                    { 394255337, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1545), 777807481, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(1547) },
                    { 394255337, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2058), 250985575, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2060) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2113487680, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3209), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3210), 981844398, 828495373, null },
                    { -1754135968, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3038), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3040), 160633848, 514818658, null },
                    { 56358688, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3222), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3224), 124646421, 742421705, null },
                    { 152343144, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3065), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3066), 160633848, 600745182, null },
                    { 614729784, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3127), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3128), 366579541, 390901940, null },
                    { 774912448, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3080), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3081), 160633848, 751632561, null },
                    { 983946984, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3195), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3196), 981844398, 514818658, null },
                    { 1175802104, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3167), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3168), 739862122, 751632561, null },
                    { 1374539288, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3098), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3099), 366579541, 669330853, null },
                    { 1686821024, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3154), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3155), 739862122, 583052587, null },
                    { 1830486536, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3111), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3112), 366579541, 583052587, null },
                    { 1934236648, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3182), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3183), 981844398, 600745182, null },
                    { 2069035824, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3141), 0f, 500L, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3142), 739862122, 276652821, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 319784041, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2452), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2454), 3010.0, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2453), "Signature 142343", 76687, 160633848, 1.0, 17.0 },
                    { 375783832, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2546), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2549), 3100.0, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2547), "Signature 142348", 83190, 366579541, 2.0, 24.0 },
                    { 440012299, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2719), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2721), 13000.0, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2720), "Signature 1423412", 21561, 981844398, 4.0, 24.0 },
                    { 820848194, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2633), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2636), 4000.0, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2634), "Signature 1423418", 46421, 739862122, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 169717872, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2679), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2680), null, "6949277784", null, null, 981844398, "alexpl_{i}@gmail.com" },
                    { 400426069, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2594), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2595), null, "6949277783", null, null, 739862122, "alexpl_{i}@gmail.com" },
                    { 637355174, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2401), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2402), null, "6949277781", null, null, 160633848, "alexpl_{i}@gmail.com" },
                    { 903932845, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2507), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2508), null, "6949277782", null, null, 366579541, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2113487680, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7024), 385774449, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7026) },
                    { -2113487680, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6975), 870416038, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6976) },
                    { -2113487680, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7148), 459650519, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7149) },
                    { -2113487680, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7000), 290526559, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7001) },
                    { -2113487680, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7086), 836926230, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7087) },
                    { -2113487680, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7049), 912073678, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7051) },
                    { -2113487680, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7037), 944577837, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7038) },
                    { -2113487680, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7111), 493682690, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7112) },
                    { -2113487680, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7012), 916551713, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7013) },
                    { -2113487680, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7160), 969989967, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7161) },
                    { -2113487680, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7074), 784772022, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7075) },
                    { -2113487680, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7135), 411217265, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7136) },
                    { -2113487680, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7098), 973770959, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7100) },
                    { -2113487680, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7062), 429549842, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7063) },
                    { -2113487680, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6987), 174946280, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6988) },
                    { -2113487680, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7123), 871371362, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(7124) },
                    { -1754135968, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4812), 872995010, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4813) },
                    { -1754135968, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4754), 471282393, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4755) },
                    { -1754135968, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4938), 357632116, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4940) },
                    { -1754135968, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4786), 311950252, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4787) },
                    { -1754135968, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4876), 817811152, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4877) },
                    { -1754135968, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4838), 360177165, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4839) },
                    { -1754135968, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4825), 441035365, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4826) },
                    { -1754135968, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4901), 208661526, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4902) },
                    { -1754135968, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4799), 963932907, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4800) },
                    { -1754135968, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4951), 622986068, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4952) },
                    { -1754135968, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4863), 388713774, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4864) },
                    { -1754135968, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4926), 288178808, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4927) },
                    { -1754135968, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4889), 510604644, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4890) },
                    { -1754135968, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4850), 393261851, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4851) },
                    { -1754135968, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4773), 322063078, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4774) },
                    { -1754135968, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4914), 526667760, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4915) },
                    { 152343144, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5014), 182101517, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5016) },
                    { 152343144, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4964), 154356003, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4965) },
                    { 152343144, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5142), 163559682, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5143) },
                    { 152343144, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4989), 261716704, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4990) },
                    { 152343144, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5080), 273152489, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5081) },
                    { 152343144, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5039), 541304418, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5040) },
                    { 152343144, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5027), 996715950, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5028) },
                    { 152343144, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5105), 565051565, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5106) },
                    { 152343144, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5002), 694688197, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5003) },
                    { 152343144, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5154), 662712155, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5155) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 152343144, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5064), 782110330, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5065) },
                    { 152343144, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5129), 185902750, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5131) },
                    { 152343144, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5092), 473829180, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5093) },
                    { 152343144, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5052), 624738448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5053) },
                    { 152343144, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4977), 986130731, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4978) },
                    { 152343144, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5117), 684758818, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5118) },
                    { 614729784, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5821), 642884772, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5822) },
                    { 614729784, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5768), 193077862, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5769) },
                    { 614729784, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5945), 815601913, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5946) },
                    { 614729784, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5796), 928631960, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5797) },
                    { 614729784, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5883), 725098286, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5884) },
                    { 614729784, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5846), 387016976, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5847) },
                    { 614729784, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5833), 369544296, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5834) },
                    { 614729784, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5908), 943133141, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5909) },
                    { 614729784, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5808), 412960960, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5809) },
                    { 614729784, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5958), 850702565, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5959) },
                    { 614729784, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5871), 143965629, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5872) },
                    { 614729784, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5932), 638624568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5933) },
                    { 614729784, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5895), 842590213, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5896) },
                    { 614729784, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5859), 645709125, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5860) },
                    { 614729784, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5783), 859795995, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5784) },
                    { 614729784, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5920), 299609985, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5921) },
                    { 774912448, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5217), 686594633, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5219) },
                    { 774912448, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5166), 582262436, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5168) },
                    { 774912448, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5341), 682803086, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5342) },
                    { 774912448, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5192), 753939512, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5194) },
                    { 774912448, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5279), 352476691, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5280) },
                    { 774912448, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5242), 338164711, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5243) },
                    { 774912448, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5230), 877251536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5231) },
                    { 774912448, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5304), 323933987, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5305) },
                    { 774912448, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5205), 823680494, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5206) },
                    { 774912448, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5354), 305478390, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5355) },
                    { 774912448, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5267), 297120076, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5268) },
                    { 774912448, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5329), 986334233, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5330) },
                    { 774912448, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5292), 862171876, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5293) },
                    { 774912448, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5255), 428584023, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5256) },
                    { 774912448, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5180), 161122823, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5181) },
                    { 774912448, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5317), 412742906, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5318) },
                    { 983946984, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6823), 809247978, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6824) },
                    { 983946984, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6774), 921740728, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6775) },
                    { 983946984, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6950), 516825827, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6951) },
                    { 983946984, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6799), 272732556, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6800) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 983946984, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6888), 226130713, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6889) },
                    { 983946984, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6851), 190094077, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6852) },
                    { 983946984, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6836), 169256883, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6837) },
                    { 983946984, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6913), 525013002, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6914) },
                    { 983946984, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6811), 980000219, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6812) },
                    { 983946984, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6962), 541915368, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6963) },
                    { 983946984, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6876), 394221852, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6877) },
                    { 983946984, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6938), 268724836, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6939) },
                    { 983946984, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6901), 971547365, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6902) },
                    { 983946984, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6864), 310982600, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6865) },
                    { 983946984, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6786), 818025097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6787) },
                    { 983946984, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6925), 685467630, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6926) },
                    { 1175802104, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6422), 161380976, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6423) },
                    { 1175802104, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6371), 317630908, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6372) },
                    { 1175802104, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6550), 219815508, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6551) },
                    { 1175802104, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6398), 923878611, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6399) },
                    { 1175802104, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6488), 570045097, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6489) },
                    { 1175802104, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6447), 359043205, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6448) },
                    { 1175802104, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6435), 506406244, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6436) },
                    { 1175802104, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6513), 583341751, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6514) },
                    { 1175802104, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6410), 382470989, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6411) },
                    { 1175802104, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6562), 216804171, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6563) },
                    { 1175802104, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6475), 206907673, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6476) },
                    { 1175802104, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6537), 343849168, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6538) },
                    { 1175802104, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6500), 546729299, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6501) },
                    { 1175802104, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6463), 537236448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6464) },
                    { 1175802104, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6385), 450114294, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6386) },
                    { 1175802104, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6525), 251931945, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6526) },
                    { 1374539288, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5416), 636251364, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5417) },
                    { 1374539288, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5366), 712317476, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5368) },
                    { 1374539288, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5543), 402572131, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5544) },
                    { 1374539288, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5391), 357437272, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5392) },
                    { 1374539288, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5481), 304578338, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5482) },
                    { 1374539288, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5443), 854316597, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5445) },
                    { 1374539288, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5428), 828610530, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5429) },
                    { 1374539288, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5506), 190216810, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5507) },
                    { 1374539288, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5404), 821832912, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5405) },
                    { 1374539288, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5555), 771004458, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5556) },
                    { 1374539288, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5469), 581742890, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5470) },
                    { 1374539288, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5530), 461335911, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5532) },
                    { 1374539288, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5493), 161382032, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5494) },
                    { 1374539288, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5456), 127592811, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5458) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1374539288, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5379), 314432997, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5380) },
                    { 1374539288, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5518), 206074313, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5519) },
                    { 1686821024, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6223), 766415238, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6224) },
                    { 1686821024, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6173), 520190171, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6174) },
                    { 1686821024, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6347), 154124533, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6348) },
                    { 1686821024, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6198), 628153160, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6199) },
                    { 1686821024, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6285), 885247266, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6286) },
                    { 1686821024, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6247), 353950397, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6248) },
                    { 1686821024, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6235), 414537984, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6236) },
                    { 1686821024, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6310), 276946751, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6311) },
                    { 1686821024, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6210), 531179052, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6211) },
                    { 1686821024, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6359), 538872710, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6360) },
                    { 1686821024, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6272), 582269777, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6273) },
                    { 1686821024, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6334), 764609233, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6335) },
                    { 1686821024, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6297), 290865210, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6298) },
                    { 1686821024, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6260), 443053002, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6261) },
                    { 1686821024, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6185), 565439735, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6186) },
                    { 1686821024, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6322), 389492163, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6323) },
                    { 1830486536, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5619), 326219742, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5620) },
                    { 1830486536, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5568), 196279373, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5569) },
                    { 1830486536, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5743), 730828550, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5744) },
                    { 1830486536, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5594), 162085214, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5595) },
                    { 1830486536, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5681), 640725980, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5682) },
                    { 1830486536, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5643), 344908675, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5644) },
                    { 1830486536, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5631), 377932879, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5632) },
                    { 1830486536, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5706), 534388191, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5707) },
                    { 1830486536, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5606), 994411257, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5607) },
                    { 1830486536, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5755), 260706167, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5757) },
                    { 1830486536, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5668), 447108161, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5669) },
                    { 1830486536, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5730), 474892073, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5732) },
                    { 1830486536, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5693), 189199879, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5694) },
                    { 1830486536, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5655), 331591960, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5657) },
                    { 1830486536, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5581), 545057973, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5583) },
                    { 1830486536, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5718), 413248252, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5719) },
                    { 1934236648, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6625), 501169373, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6626) },
                    { 1934236648, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6575), 370714133, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6576) },
                    { 1934236648, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6749), 522940142, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6751) },
                    { 1934236648, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6600), 272813317, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6601) },
                    { 1934236648, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6687), 909144110, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6688) },
                    { 1934236648, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6650), 323058532, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6651) },
                    { 1934236648, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6638), 789462393, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6639) },
                    { 1934236648, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6712), 977744218, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6713) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1934236648, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6613), 518942282, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6614) },
                    { 1934236648, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6762), 546152046, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6763) },
                    { 1934236648, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6675), 509674476, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6676) },
                    { 1934236648, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6737), 159515124, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6738) },
                    { 1934236648, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6699), 893160438, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6700) },
                    { 1934236648, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6662), 609902382, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6664) },
                    { 1934236648, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6588), 257986419, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6589) },
                    { 1934236648, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6725), 754151637, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6726) },
                    { 2069035824, 181195075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6020), 769054181, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6021) },
                    { 2069035824, 207656562, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5970), 465999855, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5971) },
                    { 2069035824, 381758411, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6143), 786571489, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6144) },
                    { 2069035824, 418912568, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5995), 940426380, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5996) },
                    { 2069035824, 442918694, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6081), 150358282, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6082) },
                    { 2069035824, 458308057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6044), 484620761, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6045) },
                    { 2069035824, 489159360, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6032), 818327855, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6033) },
                    { 2069035824, 515058188, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6106), 816462625, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6107) },
                    { 2069035824, 618545826, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6007), 249393166, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6009) },
                    { 2069035824, 678386123, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6155), 428785899, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6157) },
                    { 2069035824, 687254840, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6069), 666238403, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6070) },
                    { 2069035824, 698058668, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6131), 376003291, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6132) },
                    { 2069035824, 868865253, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6094), 763701416, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6095) },
                    { 2069035824, 957556366, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6056), 562766057, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6058) },
                    { 2069035824, 963284117, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5982), 645860431, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(5984) },
                    { 2069035824, 986657695, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6119), 476789075, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(6120) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 146117903, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3577), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3574), 2069035824, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3576), 913605929 },
                    { 186009558, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3806), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3804), -2113487680, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3805), 757859839 },
                    { 194989001, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3717), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3714), 1934236648, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3715), 757859839 },
                    { 208278784, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3325), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3323), -1754135968, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3324), 757859839 },
                    { 222212602, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3793), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3791), -2113487680, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3792), 913605929 },
                    { 257405106, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3837), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3834), 56358688, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3836), 913605929 },
                    { 282275941, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3779), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3777), -2113487680, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3778), 673301436 },
                    { 287243303, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3504), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3502), 1830486536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3503), 757859839 },
                    { 291177936, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3462), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3460), 1374539288, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3461), 757859839 },
                    { 295462117, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3385), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3383), 774912448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3384), 673301436 },
                    { 310428021, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3476), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3474), 1830486536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3475), 673301436 },
                    { 371170598, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3633), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3630), 1686821024, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3631), 757859839 },
                    { 409557674, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3661), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3658), 1175802104, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3659), 913605929 },
                    { 416404211, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3311), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3308), -1754135968, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3309), 913605929 },
                    { 434155530, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3371), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3368), 152343144, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3370), 757859839 },
                    { 439024513, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3745), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3742), 983946984, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3743), 913605929 },
                    { 465980584, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3532), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3529), 614729784, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3531), 913605929 },
                    { 474560149, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3822), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3819), 56358688, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3820), 673301436 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 528294514, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3703), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3700), 1934236648, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3701), 913605929 },
                    { 537689663, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3688), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3686), 1934236648, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3687), 673301436 },
                    { 541661981, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3851), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3848), 56358688, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3849), 757859839 },
                    { 556807878, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3605), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3602), 1686821024, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3604), 673301436 },
                    { 557626463, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3562), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3560), 2069035824, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3561), 673301436 },
                    { 564687588, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3433), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3431), 1374539288, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3432), 673301436 },
                    { 578976851, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3291), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3288), -1754135968, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3289), 673301436 },
                    { 583938001, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3340), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3338), 152343144, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3339), 673301436 },
                    { 589879924, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3758), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3756), 983946984, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3757), 757859839 },
                    { 603187857, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3619), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3616), 1686821024, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3617), 913605929 },
                    { 612858207, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3490), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3487), 1830486536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3489), 913605929 },
                    { 614585455, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3518), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3516), 614729784, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3517), 673301436 },
                    { 732310241, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3448), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3445), 1374539288, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3447), 913605929 },
                    { 759147904, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3647), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3644), 1175802104, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3645), 673301436 },
                    { 771728526, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3354), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3352), 152343144, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3353), 913605929 },
                    { 796751554, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3548), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3546), 614729784, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3547), 757859839 },
                    { 879219221, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3731), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3728), 983946984, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3730), 673301436 },
                    { 891366383, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3400), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3397), 774912448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3399), 913605929 },
                    { 922363841, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3414), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3412), 774912448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3413), 757859839 },
                    { 925091455, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3591), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3588), 2069035824, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3589), 757859839 },
                    { 989285120, new DateTime(2024, 3, 30, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3674), 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3672), 1175802104, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3673), 757859839 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 135407701, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2419), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2420), 637355174 },
                    { 306888606, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2608), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2609), 400426069 },
                    { 340306274, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2693), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2695), 169717872 },
                    { 917621986, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2521), new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2522), 903932845 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 132198608, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4207), 1830486536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4208), 857255615 },
                    { 157794515, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4564), 983946984, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4565), 646187785 },
                    { 161800046, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4430), 1686821024, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4431), 480486116 },
                    { 171548490, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4527), 1934236648, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4529), 340964783 },
                    { 178143812, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4576), 983946984, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4577), 857255615 },
                    { 179601052, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4044), 152343144, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4045), 211147631 },
                    { 196719706, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4057), 152343144, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4058), 480486116 },
                    { 197566528, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4406), 1686821024, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4407), 340964783 },
                    { 221093541, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4256), 614729784, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4257), 646187785 },
                    { 230789695, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4700), 56358688, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4701), 857255615 },
                    { 235762112, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3939), -1754135968, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3941), 646187785 },
                    { 276661753, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4455), 1175802104, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4456), 857255615 },
                    { 296222100, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4244), 1830486536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4245), 480486116 },
                    { 299137941, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4195), 1830486536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4196), 646187785 },
                    { 316485586, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4737), 56358688, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4738), 480486116 },
                    { 317443211, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4443), 1175802104, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4444), 646187785 },
                    { 322799094, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4588), 983946984, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4589), 340964783 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 326562955, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4293), 614729784, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4294), 211147631 },
                    { 342093050, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4182), 1374539288, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4184), 480486116 },
                    { 357153515, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4069), 774912448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4070), 646187785 },
                    { 413571089, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3994), -1754135968, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3995), 480486116 },
                    { 426263762, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4491), 1175802104, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4492), 480486116 },
                    { 442269241, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3981), -1754135968, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3982), 211147631 },
                    { 466283277, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4007), 152343144, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4008), 646187785 },
                    { 467732336, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4145), 1374539288, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4146), 857255615 },
                    { 468304719, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4081), 774912448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4082), 857255615 },
                    { 472137432, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4552), 1934236648, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4553), 480486116 },
                    { 478872196, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4613), 983946984, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4614), 480486116 },
                    { 480657898, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4133), 1374539288, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4134), 646187785 },
                    { 481472597, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4515), 1934236648, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4516), 857255615 },
                    { 515424475, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4170), 1374539288, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4171), 211147631 },
                    { 544419331, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4503), 1934236648, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4504), 646187785 },
                    { 544604679, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4467), 1175802104, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4468), 340964783 },
                    { 544851768, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4686), 56358688, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4688), 646187785 },
                    { 558662570, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4637), -2113487680, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4638), 857255615 },
                    { 577290229, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4109), 774912448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4110), 211147631 },
                    { 581679106, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4317), 2069035824, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4318), 646187785 },
                    { 597829075, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4341), 2069035824, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4342), 340964783 },
                    { 642398071, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4031), 152343144, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4032), 340964783 },
                    { 642688038, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3956), -1754135968, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3957), 857255615 },
                    { 672421021, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4305), 614729784, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4306), 480486116 },
                    { 708034850, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4673), -2113487680, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4674), 480486116 },
                    { 714829291, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4219), 1830486536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4220), 340964783 },
                    { 720432136, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4600), 983946984, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4602), 211147631 },
                    { 724280245, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4329), 2069035824, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4330), 857255615 },
                    { 726344090, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4713), 56358688, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4714), 340964783 },
                    { 727594437, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4366), 2069035824, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4368), 480486116 },
                    { 741796097, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4281), 614729784, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4282), 340964783 },
                    { 779234577, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4725), 56358688, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4726), 211147631 },
                    { 781633580, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4268), 614729784, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4270), 857255615 },
                    { 785794090, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4379), 1686821024, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4380), 646187785 },
                    { 791246339, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4158), 1374539288, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4159), 340964783 },
                    { 799203060, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4540), 1934236648, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4541), 211147631 },
                    { 805329365, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4479), 1175802104, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4480), 211147631 },
                    { 809431754, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4649), -2113487680, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4650), 340964783 },
                    { 831034903, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4418), 1686821024, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4419), 211147631 },
                    { 838155184, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4019), 152343144, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4021), 857255615 },
                    { 843438166, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4661), -2113487680, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4662), 211147631 },
                    { 881404987, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4625), -2113487680, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4626), 646187785 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 886016398, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4231), 1830486536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4232), 211147631 },
                    { 908845532, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4097), 774912448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4098), 340964783 },
                    { 940035727, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4391), 1686821024, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4392), 857255615 },
                    { 942576105, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4121), 774912448, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4122), 480486116 },
                    { 964677965, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4354), 2069035824, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(4356), 211147631 },
                    { 988162712, 0f, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3969), -1754135968, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(3970), 340964783 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 717700357, 169717872, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2706), 696200800, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2707) },
                    { 717700357, 400426069, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2620), 689874368, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2622) },
                    { 717700357, 637355174, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2432), 181341536, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2433) },
                    { 717700357, 903932845, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2533), 602334688, new DateTime(2024, 3, 19, 15, 27, 23, 784, DateTimeKind.Local).AddTicks(2535) }
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
                onDelete: ReferentialAction.SetNull);
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
