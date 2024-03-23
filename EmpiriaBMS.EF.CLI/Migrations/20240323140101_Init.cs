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
                    { 126211318, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8921), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8923), "Energy Efficiency" },
                    { 131639923, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8956), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8958), "TenderDocument" },
                    { 203741273, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8688), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8690), "Potable Water" },
                    { 356079185, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8849), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8851), "Burglar Alarm" },
                    { 429405734, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8728), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8730), "Fire Detection" },
                    { 430038693, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8903), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8905), "Photovoltaics" },
                    { 439652606, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8825), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8826), "Structured Cabling" },
                    { 467344415, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8637), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8639), "HVAC" },
                    { 468377812, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8804), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8806), "Power Distribution" },
                    { 498253317, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9014), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9015), "Project Manager Hours" },
                    { 501153511, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8667), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8669), "Sewage" },
                    { 571683501, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8867), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8869), "CCTV" },
                    { 685064177, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8885), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8887), "BMS" },
                    { 700618277, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8977), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8979), "Construction Supervision" },
                    { 731763782, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8708), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8710), "Drainage" },
                    { 746029057, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8786), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8788), "Natural Gas" },
                    { 750537870, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8768), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8770), "Elevators" },
                    { 808060416, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8749), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8751), "Fire Suppression" },
                    { 850838865, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8939), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8940), "Outsource" },
                    { 872638772, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8995), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8997), "DWG Admin/Clearing" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 136218555, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9352), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9353), "Calculations" },
                    { 152300584, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9371), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9373), "Drawings" },
                    { 233654590, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9325), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9327), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 331437657, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(308), new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(310), "Soft Copy" },
                    { 425036266, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(198), new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(200), "Communications" },
                    { 495946777, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(226), new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(228), "Printing" },
                    { 509059720, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(287), new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(289), "Administration" },
                    { 560034051, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(265), new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(267), "Meetings" },
                    { 708429379, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(246), new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(248), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 320276217, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4935), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4936), "Dashboard Assign Engineer", 4 },
                    { 366184266, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5129), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5131), "Display Projects Code", 13 },
                    { 421994687, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4955), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4957), "Dashboard Assign Project Manager", 5 },
                    { 422367698, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5001), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5003), "See Admin Layout", 7 },
                    { 466031974, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4913), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4914), "Dashboard Assign Designer", 3 },
                    { 471433742, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5022), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5024), "Dashboard See My Hours", 8 },
                    { 563385073, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5108), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5110), "Add Project On Dashboard", 12 },
                    { 684462859, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5087), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5089), "See All Projects", 11 },
                    { 720432166, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4979), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4981), "Dashboard Add Project", 6 },
                    { 727872312, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4767), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4769), "See Dashboard Layout", 1 },
                    { 860200212, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5043), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5045), "See All Disciplines", 9 },
                    { 880947745, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5066), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5068), "See All Drawings", 10 },
                    { 940325823, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4889), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(4891), "Dashboard Edit My Hours", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 213297476, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8161), "Buildings Description", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8164), "Buildings" },
                    { 226183475, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8186), "Infrastructure Description", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8188), "Infrastructure" },
                    { 576885543, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8208), "Energy Description", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8211), "Energy" },
                    { 629867200, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8230), "Consulting Description", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8232), "Consulting" },
                    { 962355820, false, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8251), "Production Management Description", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8254), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 167094422, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5183), false, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5185), "Engineer" },
                    { 249969168, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5311), false, false, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5313), "Customer" },
                    { 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5225), false, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5227), "COO" },
                    { 377972600, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5291), false, false, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5292), "Guest" },
                    { 481601376, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5151), false, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5152), "Designer" },
                    { 489798245, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5354), false, false, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5356), "Secretariat" },
                    { 577595813, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5332), false, false, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5334), "Admin" },
                    { 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5246), false, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5248), "CTO" },
                    { 890853243, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5205), false, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5206), "Project Manager" },
                    { 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5269), false, true, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5271), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7593), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7595), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7341), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7343), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7099), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7101), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 319197987, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6628), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6630), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8094), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8096), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 483067437, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6886), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6888), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7241), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7243), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7662), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7664), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7030), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7032), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7960), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7962), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7818), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7820), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7730), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7732), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7458), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7460), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7168), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7170), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 872668915, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6818), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6820), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8027), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8029), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 915948275, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6748), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6750), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6957), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6959), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7890), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7892), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7526), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7528), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 146840126, "embiria@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6663), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6666), 319197987 },
                    { 159889411, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8116), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8119), 386366520 },
                    { 184184492, "vchontos@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7982), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7984), 666052042 },
                    { 372531658, "dtsa@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6909), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6911), 483067437 },
                    { 438688613, "panperivollari@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8050), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8052), 915635217 },
                    { 450186253, "kmargeti@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7618), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7620), 129278631 },
                    { 576054629, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6693), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6695), 319197987 },
                    { 626759414, "blekou@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7914), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7916), 985466004 },
                    { 664108362, "sparisis@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7122), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7124), 298047605 },
                    { 689326765, "vpax@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6983), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6985), 919071394 },
                    { 700369137, "haris@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7684), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7687), 614304899 },
                    { 727775550, "chkovras@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7191), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7193), 818706292 },
                    { 731791284, "gdoug@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6773), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6775), 915948275 },
                    { 735147331, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7842), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7844), 666196274 },
                    { 735619211, "xmanarolis@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7054), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7056), 647176061 },
                    { 881542818, "vtza@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7481), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7484), 800597705 },
                    { 885555969, "dtsa@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6841), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6843), 872668915 },
                    { 910196384, "kkotsoni@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7365), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7367), 289576416 },
                    { 916511607, "pfokianou@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7753), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7755), 697814958 },
                    { 922495275, "agretos@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7550), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7552), 990762167 },
                    { 995208028, "ngal@embiria.gr", new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7269), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7271), 598167107 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 298494861, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), new DateTime(2024, 6, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Test Description Project_PM", new DateTime(2024, 4, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 0f, new DateTime(2024, 5, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 1500L, 12L, null, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Project_PM", null, null, 962355820, 0f },
                    { 660417922, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), new DateTime(2025, 7, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Test Description Project_12", new DateTime(2025, 7, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 0f, new DateTime(2025, 7, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 1500L, 12L, 10000.0, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Project_4", 289576416, null, 629867200, 0f },
                    { 759514003, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), new DateTime(2024, 12, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Test Description Project_6", new DateTime(2024, 12, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 0f, new DateTime(2024, 12, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 1500L, 12L, 10000.0, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Project_3", 289576416, null, 576885543, 0f },
                    { 827117932, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), new DateTime(2024, 7, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Test Description Project_4", new DateTime(2024, 7, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 0f, new DateTime(2024, 7, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 1500L, 12L, 10000.0, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Project_2", 289576416, null, 226183475, 0f },
                    { 967177697, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), new DateTime(2024, 4, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Test Description Project_4", new DateTime(2024, 4, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 0f, new DateTime(2024, 4, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), 1500L, 12L, 10000.0, new DateTime(2024, 3, 23, 16, 1, 0, 536, DateTimeKind.Local).AddTicks(8726), "Project_1", 289576416, null, 213297476, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 466031974, 167094422, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5504), 614344703, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5506) },
                    { 471433742, 167094422, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5526), -335144542, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5528) },
                    { 727872312, 167094422, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5459), 1115679839, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5461) },
                    { 860200212, 167094422, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5548), -9393443, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5550) },
                    { 880947745, 167094422, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5570), -992310448, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5572) },
                    { 940325823, 167094422, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5481), -1153771424, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5483) },
                    { 727872312, 249969168, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6372), 1368286961, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6374) },
                    { 320276217, 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5786), -1337133671, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5788) },
                    { 421994687, 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5807), -1486402829, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5809) },
                    { 466031974, 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5764), -1573424590, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5766) },
                    { 471433742, 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5829), 1452137414, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5831) },
                    { 684462859, 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5893), -2088071869, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5895) },
                    { 727872312, 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5721), 1484763795, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5722) },
                    { 860200212, 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5850), 1148589468, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5852) },
                    { 880947745, 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5871), -167653966, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5873) },
                    { 940325823, 252225842, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5742), -1589960560, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5743) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 727872312, 377972600, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6351), 45130159, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6353) },
                    { 471433742, 481601376, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5437), -1561187137, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5439) },
                    { 727872312, 481601376, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5375), -1883958106, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5378) },
                    { 940325823, 481601376, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5415), 433095674, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5417) },
                    { 471433742, 489798245, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6531), -2050612766, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6533) },
                    { 684462859, 489798245, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6601), 572213372, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6603) },
                    { 727872312, 489798245, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6484), 1162723725, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6486) },
                    { 860200212, 489798245, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6555), 1369091543, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6557) },
                    { 880947745, 489798245, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6578), -1419262915, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6580) },
                    { 940325823, 489798245, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6507), -152246866, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6509) },
                    { 422367698, 577595813, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6394), -1776156295, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6396) },
                    { 684462859, 577595813, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6461), 1092465644, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6463) },
                    { 860200212, 577595813, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6415), -162248291, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6417) },
                    { 880947745, 577595813, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6437), -866075669, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6439) },
                    { 421994687, 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5957), -2022045826, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5959) },
                    { 471433742, 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6001), -1245848534, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6003) },
                    { 563385073, 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6092), -39153554, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6094) },
                    { 684462859, 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6070), -974405155, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6072) },
                    { 720432166, 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5980), 509805527, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5982) },
                    { 727872312, 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5915), 2001993143, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5916) },
                    { 860200212, 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6023), -1966046957, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6025) },
                    { 880947745, 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6049), -445581796, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6051) },
                    { 940325823, 769921179, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5936), -1370980714, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5938) },
                    { 320276217, 890853243, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5635), -1107662809, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5637) },
                    { 471433742, 890853243, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5657), 1059354185, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5659) },
                    { 727872312, 890853243, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5593), 1241320716, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5595) },
                    { 860200212, 890853243, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5678), 47542384, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5680) },
                    { 880947745, 890853243, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5699), 636863549, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5701) },
                    { 940325823, 890853243, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5614), 488055848, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(5616) },
                    { 320276217, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6180), 270285841, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6181) },
                    { 366184266, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6308), 105344060, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6310) },
                    { 421994687, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6201), -806577551, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6203) },
                    { 466031974, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6158), -1931897155, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6160) },
                    { 563385073, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6330), -61946194, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6332) },
                    { 684462859, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6287), -909434740, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6289) },
                    { 720432166, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6223), -1781194922, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6224) },
                    { 727872312, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6115), -894687272, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6117) },
                    { 860200212, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6244), -1111058792, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6246) },
                    { 880947745, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6265), -28561828, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6267) },
                    { 940325823, 958187916, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6136), 1934628908, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6138) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 167094422, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7639), 933504656, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7642) },
                    { 167094422, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7388), 129941617, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7391) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 252225842, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7412), 537694057, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7414) },
                    { 769921179, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7435), 523547989, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7437) },
                    { 890853243, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8302), 211596214, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8304) },
                    { 167094422, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7144), 623477735, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7146) },
                    { 489798245, 319197987, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6718), 509414312, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6720) },
                    { 167094422, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8138), 973125568, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8140) },
                    { 481601376, 483067437, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6933), 617452247, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6935) },
                    { 167094422, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7292), 177732905, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7295) },
                    { 958187916, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7316), 557020738, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7318) },
                    { 167094422, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7705), 657368383, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7708) },
                    { 890853243, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8325), 219878520, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8327) },
                    { 167094422, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7077), 835205181, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7079) },
                    { 167094422, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8005), 353446775, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8007) },
                    { 167094422, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7866), 528388890, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7868) },
                    { 167094422, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7774), 469028492, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7777) },
                    { 167094422, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7504), 645023928, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7506) },
                    { 167094422, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7214), 756829401, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7217) },
                    { 481601376, 872668915, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6863), 963107099, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6865) },
                    { 167094422, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8072), 890999737, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8074) },
                    { 481601376, 915948275, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6795), 754383077, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(6797) },
                    { 167094422, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7006), 906645521, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7008) },
                    { 890853243, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8277), 164824791, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8279) },
                    { 167094422, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7937), 501615316, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7939) },
                    { 167094422, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7571), 866489865, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(7573) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2055059000, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9299), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9301), 298494861, 498253317, null },
                    { -1440545152, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9185), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9187), 759514003, 750537870, null },
                    { -1393091488, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9105), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9107), 967177697, 700618277, null },
                    { -1113970928, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9281), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9282), 660417922, 501153511, null },
                    { -1086210416, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9204), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9206), 759514003, 808060416, null },
                    { -1072154960, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9262), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9264), 660417922, 126211318, null },
                    { -1004166208, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9144), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9146), 827117932, 203741273, null },
                    { -929399552, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9085), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9087), 967177697, 808060416, null },
                    { -905258040, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9052), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9054), 967177697, 126211318, null },
                    { -873316656, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9222), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9224), 759514003, 700618277, null },
                    { 590103336, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9125), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9127), 827117932, 430038693, null },
                    { 1014014848, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9243), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9245), 660417922, 429405734, null },
                    { 1564773352, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9166), 0f, 500L, 0L, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9167), 827117932, 571683501, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 449108724, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8423), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8427), 3010.0, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8425), "Signature 142342", 26358, 967177697, 1.0, 17.0 },
                    { 692251993, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8535), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8539), 4000.0, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8537), "Signature 142343", 29274, 759514003, 3.0, 17.0 },
                    { 761770469, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8585), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8588), 13000.0, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8586), "Signature 1423412", 35594, 660417922, 4.0, 24.0 },
                    { 998365893, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8484), new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8488), 3100.0, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(8486), "Signature 1423412", 62873, 827117932, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1440545152, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3723), 672812160, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3725) },
                    { -1440545152, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3669), 984415200, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3670) },
                    { -1440545152, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3614), 567553422, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3615) },
                    { -1440545152, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3850), 403712055, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3852) },
                    { -1440545152, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3650), 300408618, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3652) },
                    { -1440545152, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3741), 234040411, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3743) },
                    { -1440545152, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3596), 544924983, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3597) },
                    { -1440545152, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3814), 148829417, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3816) },
                    { -1440545152, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3778), 216046523, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3779) },
                    { -1440545152, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3759), 891337311, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3761) },
                    { -1440545152, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3687), 953465681, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3688) },
                    { -1440545152, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3632), 382100830, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3633) },
                    { -1440545152, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3832), 287780534, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3834) },
                    { -1440545152, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3578), 766659102, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3579) },
                    { -1440545152, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3796), 231124259, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3797) },
                    { -1440545152, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3705), 907229225, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3706) },
                    { -1393091488, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2541), 269762568, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2543) },
                    { -1393091488, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2486), 619441183, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2488) },
                    { -1393091488, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2431), 875966824, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2433) },
                    { -1393091488, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2668), 926796173, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2669) },
                    { -1393091488, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2468), 848467954, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2470) },
                    { -1393091488, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2559), 327947766, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2561) },
                    { -1393091488, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2413), 591676118, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2414) },
                    { -1393091488, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2631), 301106538, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2633) },
                    { -1393091488, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2595), 555790887, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2597) },
                    { -1393091488, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2577), 399276895, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2579) },
                    { -1393091488, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2505), 850842028, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2506) },
                    { -1393091488, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2450), 996141039, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2452) },
                    { -1393091488, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2650), 928689410, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2651) },
                    { -1393091488, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2393), 319513204, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2394) },
                    { -1393091488, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2613), 140194600, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2615) },
                    { -1393091488, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2523), 209326234, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2525) },
                    { -1113970928, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5200), 942420731, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5201) },
                    { -1113970928, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5146), 471014037, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5147) },
                    { -1113970928, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5090), 533219541, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5092) },
                    { -1113970928, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5327), 582033661, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5328) },
                    { -1113970928, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5128), 764864260, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5129) },
                    { -1113970928, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5218), 848714953, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5220) },
                    { -1113970928, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5072), 392586391, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5074) },
                    { -1113970928, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5291), 191300709, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5292) },
                    { -1113970928, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5255), 153835840, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5256) },
                    { -1113970928, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5236), 525838897, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5238) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1113970928, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5164), 322439649, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5165) },
                    { -1113970928, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5108), 819894494, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5110) },
                    { -1113970928, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5309), 603078117, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5310) },
                    { -1113970928, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5054), 880116075, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5055) },
                    { -1113970928, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5273), 796084392, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5274) },
                    { -1113970928, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5182), 191275295, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5183) },
                    { -1086210416, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4019), 334245130, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4021) },
                    { -1086210416, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3965), 266618322, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3966) },
                    { -1086210416, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3910), 172823876, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3912) },
                    { -1086210416, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4146), 930147431, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4148) },
                    { -1086210416, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3947), 222785211, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3948) },
                    { -1086210416, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4037), 676098809, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4039) },
                    { -1086210416, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3892), 891416724, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3894) },
                    { -1086210416, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4110), 260567776, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4112) },
                    { -1086210416, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4074), 934670092, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4075) },
                    { -1086210416, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4055), 847287932, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4057) },
                    { -1086210416, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3983), 351072786, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3984) },
                    { -1086210416, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3929), 685267303, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3930) },
                    { -1086210416, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4128), 313168269, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4130) },
                    { -1086210416, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3873), 889006750, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3875) },
                    { -1086210416, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4092), 846034626, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4093) },
                    { -1086210416, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4001), 445269522, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4003) },
                    { -1072154960, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4909), 507074591, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4910) },
                    { -1072154960, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4850), 912952277, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4851) },
                    { -1072154960, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4795), 500798706, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4797) },
                    { -1072154960, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5035), 857801313, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5037) },
                    { -1072154960, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4831), 294495871, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4833) },
                    { -1072154960, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4926), 840644137, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4928) },
                    { -1072154960, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4777), 676743085, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4779) },
                    { -1072154960, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4999), 752967725, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5000) },
                    { -1072154960, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4962), 573470172, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4964) },
                    { -1072154960, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4944), 828306830, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4946) },
                    { -1072154960, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4872), 268298261, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4874) },
                    { -1072154960, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4813), 504119210, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4815) },
                    { -1072154960, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5017), 483536278, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(5019) },
                    { -1072154960, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4759), 521266385, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4761) },
                    { -1072154960, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4981), 393449085, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4982) },
                    { -1072154960, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4891), 761901944, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4892) },
                    { -1004166208, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3133), 706375541, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3135) },
                    { -1004166208, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3078), 455584323, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3080) },
                    { -1004166208, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3024), 493453142, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3026) },
                    { -1004166208, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3261), 156789293, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3262) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1004166208, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3060), 399603674, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3062) },
                    { -1004166208, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3152), 342798767, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3154) },
                    { -1004166208, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3006), 161943043, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3007) },
                    { -1004166208, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3225), 288995753, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3226) },
                    { -1004166208, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3189), 621522780, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3190) },
                    { -1004166208, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3171), 535378318, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3172) },
                    { -1004166208, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3097), 552618791, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3098) },
                    { -1004166208, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3042), 495650248, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3044) },
                    { -1004166208, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3243), 257647021, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3244) },
                    { -1004166208, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2985), 755423027, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2987) },
                    { -1004166208, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3207), 192353695, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3208) },
                    { -1004166208, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3115), 141522626, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3117) },
                    { -929399552, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2242), 534504091, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2244) },
                    { -929399552, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2188), 341678353, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2190) },
                    { -929399552, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2133), 999604627, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2134) },
                    { -929399552, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2374), 126368593, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2376) },
                    { -929399552, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2169), 684106875, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2171) },
                    { -929399552, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2264), 451156882, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2266) },
                    { -929399552, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2114), 190120877, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2116) },
                    { -929399552, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2338), 858189543, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2339) },
                    { -929399552, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2301), 955597237, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2303) },
                    { -929399552, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2283), 192848652, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2285) },
                    { -929399552, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2206), 250800476, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2208) },
                    { -929399552, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2151), 218934186, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2152) },
                    { -929399552, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2356), 687618195, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2357) },
                    { -929399552, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2094), 320932938, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2096) },
                    { -929399552, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2319), 536456272, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2321) },
                    { -929399552, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2224), 296803374, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2226) },
                    { -905258040, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1944), 354792072, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1945) },
                    { -905258040, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1888), 437174386, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1890) },
                    { -905258040, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1832), 769738868, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1833) },
                    { -905258040, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2075), 599016612, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2077) },
                    { -905258040, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1869), 235859979, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1870) },
                    { -905258040, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1963), 850450027, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1965) },
                    { -905258040, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1813), 670557534, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1814) },
                    { -905258040, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2039), 660621334, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2040) },
                    { -905258040, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2001), 594904622, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2002) },
                    { -905258040, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1982), 850163371, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1984) },
                    { -905258040, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1907), 206906540, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1908) },
                    { -905258040, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1850), 319442638, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1852) },
                    { -905258040, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2057), 983850077, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2059) },
                    { -905258040, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1786), 158104716, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1788) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -905258040, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2020), 716626746, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2022) },
                    { -905258040, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1925), 912980518, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1927) },
                    { -873316656, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4317), 302930243, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4319) },
                    { -873316656, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4258), 628116132, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4259) },
                    { -873316656, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4203), 557305931, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4205) },
                    { -873316656, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4447), 555064744, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4448) },
                    { -873316656, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4239), 724413042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4241) },
                    { -873316656, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4336), 516279957, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4338) },
                    { -873316656, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4185), 734985795, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4187) },
                    { -873316656, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4409), 214983538, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4411) },
                    { -873316656, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4372), 223319078, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4374) },
                    { -873316656, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4355), 980585600, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4356) },
                    { -873316656, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4276), 641620153, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4277) },
                    { -873316656, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4221), 284497801, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4223) },
                    { -873316656, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4428), 225107000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4430) },
                    { -873316656, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4165), 353536497, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4166) },
                    { -873316656, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4391), 154562732, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4392) },
                    { -873316656, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4299), 920310164, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4300) },
                    { 590103336, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2839), 766659612, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2841) },
                    { 590103336, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2778), 794944749, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2779) },
                    { 590103336, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2723), 223606448, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2725) },
                    { 590103336, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2967), 327712956, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2968) },
                    { 590103336, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2759), 703700883, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2761) },
                    { 590103336, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2857), 761551363, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2859) },
                    { 590103336, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2705), 604902356, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2706) },
                    { 590103336, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2930), 352986855, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2932) },
                    { 590103336, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2894), 702510586, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2895) },
                    { 590103336, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2875), 870522201, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2877) },
                    { 590103336, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2800), 727168710, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2802) },
                    { 590103336, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2741), 480503444, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2743) },
                    { 590103336, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2948), 930657939, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2950) },
                    { 590103336, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2686), 342197144, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2688) },
                    { 590103336, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2912), 442295253, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2914) },
                    { 590103336, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2820), 324628161, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(2821) },
                    { 1014014848, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4611), 352931341, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4613) },
                    { 1014014848, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4557), 742922305, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4558) },
                    { 1014014848, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4502), 190082826, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4504) },
                    { 1014014848, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4740), 820942738, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4742) },
                    { 1014014848, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4538), 344115733, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4540) },
                    { 1014014848, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4630), 430139344, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4631) },
                    { 1014014848, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4484), 909693399, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4486) },
                    { 1014014848, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4703), 448526458, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4705) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1014014848, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4667), 877913686, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4668) },
                    { 1014014848, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4649), 147565626, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4650) },
                    { 1014014848, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4575), 923336478, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4577) },
                    { 1014014848, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4520), 902276097, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4522) },
                    { 1014014848, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4722), 955139189, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4724) },
                    { 1014014848, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4466), 423787127, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4467) },
                    { 1014014848, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4685), 272902316, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4686) },
                    { 1014014848, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4593), 480622491, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(4595) },
                    { 1564773352, 129278631, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3432), 250972843, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3433) },
                    { 1564773352, 289576416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3377), 511491632, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3379) },
                    { 1564773352, 298047605, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3322), 590683223, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3323) },
                    { 1564773352, 386366520, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3559), 928205488, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3560) },
                    { 1564773352, 598167107, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3358), 476139719, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3360) },
                    { 1564773352, 614304899, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3450), 425173301, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3452) },
                    { 1564773352, 647176061, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3303), 685746057, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3305) },
                    { 1564773352, 666052042, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3523), 540168027, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3524) },
                    { 1564773352, 666196274, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3486), 958657510, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3488) },
                    { 1564773352, 697814958, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3468), 632545087, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3470) },
                    { 1564773352, 800597705, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3395), 262900334, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3397) },
                    { 1564773352, 818706292, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3340), 942294391, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3342) },
                    { 1564773352, 915635217, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3541), 304974016, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3542) },
                    { 1564773352, 919071394, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3280), 856803356, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3282) },
                    { 1564773352, 985466004, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3505), 147328018, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3506) },
                    { 1564773352, 990762167, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3413), 452672027, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(3415) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 156758589, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9876), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9872), -1086210416, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9874), 152300584 },
                    { 161578623, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9709), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9705), 1564773352, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9707), 233654590 },
                    { 221454107, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9915), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9912), -873316656, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9913), 136218555 },
                    { 229086376, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9567), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9564), -1393091488, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9566), 152300584 },
                    { 231033191, new DateTime(2024, 4, 3, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(180), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(176), -2055059000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(178), 152300584 },
                    { 231188509, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9425), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9422), -905258040, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9423), 136218555 },
                    { 238323860, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9446), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9442), -905258040, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9444), 152300584 },
                    { 239988860, new DateTime(2024, 4, 3, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(34), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(31), -1072154960, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(32), 136218555 },
                    { 256847156, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9816), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9812), -1440545152, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9814), 152300584 },
                    { 257843107, new DateTime(2024, 4, 3, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(54), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(50), -1072154960, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(52), 152300584 },
                    { 313237381, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9486), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9482), -929399552, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9484), 136218555 },
                    { 377488701, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9896), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9892), -873316656, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9894), 233654590 },
                    { 389581675, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9466), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9462), -929399552, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9464), 233654590 },
                    { 442679038, new DateTime(2024, 4, 3, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(160), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(157), -2055059000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(159), 136218555 },
                    { 501062666, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9689), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9686), -1004166208, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9687), 152300584 },
                    { 531710493, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9610), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9607), 590103336, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9608), 136218555 },
                    { 583897427, new DateTime(2024, 4, 3, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(97), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(93), -1113970928, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(95), 136218555 },
                    { 590786536, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9650), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9647), -1004166208, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9649), 233654590 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 593223847, new DateTime(2024, 4, 3, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(139), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(134), -2055059000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(136), 233654590 },
                    { 630342507, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9856), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9853), -1086210416, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9854), 136218555 },
                    { 653965660, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9974), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9971), 1014014848, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9972), 136218555 },
                    { 668173397, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9771), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9768), -1440545152, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9769), 233654590 },
                    { 689960187, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9836), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9833), -1086210416, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9834), 233654590 },
                    { 693933406, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9670), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9666), -1004166208, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9668), 136218555 },
                    { 720990803, new DateTime(2024, 4, 3, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(14), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(11), -1072154960, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(12), 233654590 },
                    { 724088215, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9994), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9990), 1014014848, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9992), 152300584 },
                    { 733432999, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9508), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9504), -929399552, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9506), 152300584 },
                    { 737000463, new DateTime(2024, 4, 3, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(116), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(113), -1113970928, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(114), 152300584 },
                    { 749358804, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9630), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9627), 590103336, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9629), 152300584 },
                    { 762316490, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9955), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9951), 1014014848, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9953), 233654590 },
                    { 772807470, new DateTime(2024, 4, 3, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(77), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(73), -1113970928, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(75), 233654590 },
                    { 780123222, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9398), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9393), -905258040, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9395), 233654590 },
                    { 821408198, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9590), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9586), 590103336, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9588), 233654590 },
                    { 913486892, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9528), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9525), -1393091488, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9526), 233654590 },
                    { 942363024, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9935), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9931), -873316656, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9933), 152300584 },
                    { 948623731, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9791), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9787), -1440545152, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9789), 136218555 },
                    { 955371952, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9729), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9725), 1564773352, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9727), 136218555 },
                    { 973175566, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9548), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9544), -1393091488, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9546), 136218555 },
                    { 983409850, new DateTime(2024, 4, 3, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9751), 0f, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9748), 1564773352, new DateTime(2024, 3, 23, 16, 1, 0, 555, DateTimeKind.Local).AddTicks(9749), 152300584 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 128014838, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(971), 1564773352, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(973), 509059720 },
                    { 146340107, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1285), -873316656, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1286), 560034051 },
                    { 163433566, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1339), 1014014848, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1341), 425036266 },
                    { 166609695, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1079), -1440545152, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1081), 509059720 },
                    { 179394590, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1098), -1440545152, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1099), 331437657 },
                    { 185907774, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(652), -1393091488, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(654), 331437657 },
                    { 199761834, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1556), -1113970928, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1558), 425036266 },
                    { 210269079, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1134), -1086210416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1135), 495946777 },
                    { 220745790, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(355), -905258040, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(357), 495946777 },
                    { 223128185, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1429), 1014014848, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1430), 331437657 },
                    { 255151152, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(861), -1004166208, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(862), 509059720 },
                    { 263841300, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(842), -1004166208, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(844), 560034051 },
                    { 271337841, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1303), -873316656, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1304), 509059720 },
                    { 275956875, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1447), -1072154960, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1448), 425036266 },
                    { 278348850, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1008), -1440545152, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1010), 425036266 },
                    { 305818349, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(743), 590103336, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(745), 509059720 },
                    { 308858802, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1207), -1086210416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1208), 331437657 },
                    { 310103474, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(374), -905258040, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(376), 708429379 },
                    { 316708184, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1225), -873316656, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1226), 425036266 },
                    { 317884363, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(615), -1393091488, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(617), 560034051 },
                    { 320573126, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(879), -1004166208, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(880), 331437657 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 350963696, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(689), 590103336, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(691), 495946777 },
                    { 362041544, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(671), 590103336, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(673), 425036266 },
                    { 373762410, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1044), -1440545152, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1046), 708429379 },
                    { 383297864, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(393), -905258040, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(395), 560034051 },
                    { 408190589, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(989), 1564773352, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(991), 331437657 },
                    { 434770444, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(933), 1564773352, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(935), 708429379 },
                    { 435510692, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1501), -1072154960, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1502), 560034051 },
                    { 438107889, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1266), -873316656, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1268), 708429379 },
                    { 478490944, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1170), -1086210416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1172), 560034051 },
                    { 506934757, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1765), -2055059000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1767), 331437657 },
                    { 549919737, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1538), -1072154960, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1540), 331437657 },
                    { 569993614, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1243), -873316656, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1244), 495946777 },
                    { 575755079, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(824), -1004166208, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(826), 708429379 },
                    { 587562321, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1593), -1113970928, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1594), 708429379 },
                    { 603860513, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(543), -929399552, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(544), 331437657 },
                    { 606126949, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1375), 1014014848, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1377), 708429379 },
                    { 619016940, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1667), -2055059000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1669), 425036266 },
                    { 625289105, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(707), 590103336, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(709), 708429379 },
                    { 661108888, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(451), -929399552, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(453), 425036266 },
                    { 668476559, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(916), 1564773352, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(917), 495946777 },
                    { 673267369, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1188), -1086210416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1190), 509059720 },
                    { 681081471, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(786), -1004166208, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(787), 425036266 },
                    { 687178632, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1519), -1072154960, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1520), 509059720 },
                    { 705320359, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(525), -929399552, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(527), 509059720 },
                    { 754353854, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(897), 1564773352, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(899), 425036266 },
                    { 774156477, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1357), 1014014848, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1359), 495946777 },
                    { 785711595, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(633), -1393091488, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(635), 509059720 },
                    { 804858897, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1393), 1014014848, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1395), 560034051 },
                    { 821376988, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1748), -2055059000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1749), 509059720 },
                    { 829371867, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1483), -1072154960, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1484), 708429379 },
                    { 829706878, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(579), -1393091488, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(581), 495946777 },
                    { 837465745, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(469), -929399552, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(471), 495946777 },
                    { 840538669, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(761), 590103336, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(763), 331437657 },
                    { 842389600, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(507), -929399552, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(508), 560034051 },
                    { 850591930, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1611), -1113970928, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1613), 560034051 },
                    { 851938993, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(597), -1393091488, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(599), 708429379 },
                    { 857472779, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1729), -2055059000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1731), 560034051 },
                    { 858047434, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(725), 590103336, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(727), 560034051 },
                    { 866138183, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(412), -905258040, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(413), 509059720 },
                    { 878970707, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1575), -1113970928, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1576), 495946777 },
                    { 881365153, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1687), -2055059000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1689), 495946777 },
                    { 892533402, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(805), -1004166208, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(808), 495946777 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 930559651, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1629), -1113970928, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1630), 509059720 },
                    { 931666692, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1321), -873316656, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1323), 331437657 },
                    { 931688425, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1411), 1014014848, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1412), 509059720 },
                    { 933135831, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1706), -2055059000, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1708), 708429379 },
                    { 940473752, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1062), -1440545152, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1063), 560034051 },
                    { 941855082, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(431), -905258040, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(433), 331437657 },
                    { 946736836, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(561), -1393091488, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(563), 425036266 },
                    { 947085258, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(329), -905258040, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(331), 425036266 },
                    { 951561965, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(953), 1564773352, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(955), 560034051 },
                    { 965188636, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1116), -1086210416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1118), 425036266 },
                    { 972401416, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1647), -1113970928, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1648), 331437657 },
                    { 977056063, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1151), -1086210416, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1153), 708429379 },
                    { 979707263, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1465), -1072154960, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1467), 495946777 },
                    { 991783800, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1026), -1440545152, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(1027), 495946777 },
                    { 995118824, 0f, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(487), -929399552, new DateTime(2024, 3, 23, 16, 1, 0, 556, DateTimeKind.Local).AddTicks(489), 708429379 }
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
