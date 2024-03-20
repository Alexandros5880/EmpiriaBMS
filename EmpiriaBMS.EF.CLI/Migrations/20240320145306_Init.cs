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
                    { 172100725, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7425), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7426), "Natural Gas" },
                    { 186074285, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7487), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7489), "BMS" },
                    { 198391504, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7562), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7563), "Project Manager Hours" },
                    { 283620520, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7523), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7525), "Outsource" },
                    { 349372243, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7550), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7551), "Construction Supervision" },
                    { 355839175, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7463), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7464), "Burglar Alarm" },
                    { 366956793, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7437), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7438), "Power Distribution" },
                    { 397750566, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7387), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7388), "Fire Detection" },
                    { 479532379, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7499), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7501), "Photovoltaics" },
                    { 637754401, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7535), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7536), "TenderDocument" },
                    { 664253753, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7350), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7351), "Sewage" },
                    { 758627886, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7475), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7476), "CCTV" },
                    { 803541822, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7375), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7376), "Drainage" },
                    { 818325369, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7511), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7513), "Energy Efficiency" },
                    { 819886094, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7451), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7452), "Structured Cabling" },
                    { 837476857, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7413), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7414), "Elevators" },
                    { 858548399, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7328), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7330), "HVAC" },
                    { 860603527, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7401), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7402), "Fire Suppression" },
                    { 965718780, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7363), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7364), "Potable Water" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 169662456, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7836), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7838), "Calculations" },
                    { 227055275, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7849), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7851), "Drawings" },
                    { 865613230, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7815), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7817), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 165421732, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8509), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8510), "Meetings" },
                    { 189992110, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8522), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8523), "Administration" },
                    { 484208098, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8465), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8466), "Communications" },
                    { 506622338, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8496), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8497), "On-Site" },
                    { 579904188, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8483), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8485), "Printing" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 193816538, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4460), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4461), "Dashboard Assign Engineer", 4 },
                    { 211316622, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4256), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4257), "See Dashboard Layout", 1 },
                    { 316224155, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4546), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4547), "See All Drawings", 10 },
                    { 324661367, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4587), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4588), "Display Projects Code", 13 },
                    { 370120036, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4445), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4447), "Dashboard Assign Designer", 3 },
                    { 450032704, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4474), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4476), "Dashboard Assign Project Manager", 5 },
                    { 451092306, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4573), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4574), "Add Project On Dashboard", 12 },
                    { 506451568, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4490), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4491), "Dashboard Add Project", 6 },
                    { 595314144, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4517), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4518), "Dashboard See My Hours", 8 },
                    { 687865253, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4429), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4430), "Dashboard Edit My Hours", 2 },
                    { 814673807, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4504), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4505), "See Admin Layout", 7 },
                    { 893568788, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4559), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4561), "See All Projects", 11 },
                    { 924488473, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4530), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4532), "See All Disciplines", 9 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 248999006, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6766), "Infrastructure Description", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6767), "Infrastructure" },
                    { 359533810, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6792), "Consulting Description", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6794), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 438711074, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6749), "Buildings Description", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6750), "Buildings" },
                    { 456877595, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6780), "Energy Description", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6781), "Energy" },
                    { 691567033, false, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6806), "Production Management Description", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6808), "Production Management" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 206770108, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4625), false, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4626), "Engineer" },
                    { 255157588, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4721), false, false, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4723), "Admin" },
                    { 514301477, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4736), false, false, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4737), "Secretariat" },
                    { 541183351, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4601), false, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4602), "Designer" },
                    { 658641439, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4639), false, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4640), "Project Manager" },
                    { 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4681), false, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4682), "CEO" },
                    { 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4653), false, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4654), "COO" },
                    { 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4667), false, true, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4668), "CTO" },
                    { 849365862, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4695), false, false, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4696), "Guest" },
                    { 949616405, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4708), false, false, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4709), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6326), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6328), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 160249707, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5669), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5670), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 176749873, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5901), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5903), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6665), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6666), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6028), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6029), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6452), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6453), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 294523581, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5710), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5711), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6270), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6271), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 380454902, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5844), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5845), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6111), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6112), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 477469123, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5627), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5629), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 494154701, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5985), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5986), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6369), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6370), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6069), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6071), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" },
                    { 618935017, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5943), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5945), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6540), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6541), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6582), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6583), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6410), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6411), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6493), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6494), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6153), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6154), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6623), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6624), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6198), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6199), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 864305950, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5796), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5797), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6706), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6707), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 944200363, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5752), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5753), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 985479541, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5568), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5570), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 167037067, "kmargeti@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6425), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6426), 691664186 },
                    { 167078247, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5874), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5875), 380454902 },
                    { 206373556, "dtsa@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6000), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6001), 494154701 },
                    { 224458387, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6554), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6556), 624575747 },
                    { 241855941, "blekou@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6596), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6597), 681672876 },
                    { 274018990, "sparisis@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6126), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6127), 423661495 },
                    { 279560816, "kkotsoni@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6285), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6286), 315280497 },
                    { 283964309, "ceo@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5642), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5643), 477469123 },
                    { 316128654, "gdoug@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5915), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5917), 176749873 },
                    { 385887784, "vtza@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6342), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6343), 139276396 },
                    { 401092478, "dtsa@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5958), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5959), 618935017 },
                    { 413156333, "pfokianou@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6511), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6513), 758340740 },
                    { 480582025, "chkovras@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6167), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6168), 764356924 },
                    { 591919779, "panperivollari@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6679), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6680), 225265570 },
                    { 604654451, "haris@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6466), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6467), 294047603 },
                    { 620499737, "guest@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5767), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5768), 944200363 },
                    { 645333704, "coo@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5724), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5725), 294523581 },
                    { 700742073, "embiria@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5860), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5861), 380454902 },
                    { 749802416, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6720), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6721), 868823787 },
                    { 752894343, "agretos@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6383), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6384), 542554939 },
                    { 752984070, "pm@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5810), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5812), 864305950 },
                    { 820315843, "vpax@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6042), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6044), 272170333 },
                    { 847026708, "ngal@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6213), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6214), 818287581 },
                    { 880028844, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5589), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5590), 985479541 },
                    { 895115354, "xmanarolis@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6083), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6084), 589297259 },
                    { 955497046, "cto@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5683), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5684), 160249707 },
                    { 970978676, "vchontos@embiria.gr", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6637), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6638), 770071884 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "DurationDate", "EstimatedCompleted", "EstimatedDate", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 727801577, false, 1, "D-22-161", 0f, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), new DateTime(2024, 4, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Test Description Project_1", new DateTime(2024, 4, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 0f, new DateTime(2024, 4, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Project_1", 315280497, null, 438711074, 0f },
                    { 731527127, true, 4, "D-22-164", 0f, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), new DateTime(2025, 7, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Test Description Project_24", new DateTime(2025, 7, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 0f, new DateTime(2025, 7, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Project_4", 315280497, null, 359533810, 0f },
                    { 741953091, false, 3, "D-22-163", 0f, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), new DateTime(2024, 12, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Test Description Project_9", new DateTime(2024, 12, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 0f, new DateTime(2024, 12, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Project_3", 315280497, null, 456877595, 0f },
                    { 760061021, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), new DateTime(2024, 6, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Test Description Project_PM", new DateTime(2024, 4, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 0f, new DateTime(2024, 5, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 1500L, 12L, null, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Project_PM", null, null, 691567033, 0f },
                    { 949007555, true, 2, "D-22-162", 0f, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), new DateTime(2024, 7, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Test Description Project_12", new DateTime(2024, 7, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 0f, new DateTime(2024, 7, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), 1500L, 12L, 10000.0, new DateTime(2024, 3, 20, 16, 53, 6, 330, DateTimeKind.Local).AddTicks(4059), "Project_2", 315280497, null, 248999006, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 211316622, 206770108, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4798), 43553390, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4799) },
                    { 316224155, 206770108, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4872), -1898125946, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4874) },
                    { 370120036, 206770108, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4828), 523531517, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4829) },
                    { 595314144, 206770108, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4843), 443710049, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4844) },
                    { 687865253, 206770108, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4812), -125072662, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4814) },
                    { 924488473, 206770108, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4858), 1232614755, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4859) },
                    { 316224155, 255157588, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5447), -983067317, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5449) },
                    { 814673807, 255157588, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5418), 652766243, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5420) },
                    { 893568788, 255157588, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5466), -551189591, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5467) },
                    { 924488473, 255157588, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5433), 1559610644, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5434) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 211316622, 514301477, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5480), -712628342, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5482) },
                    { 316224155, 514301477, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5538), 532275602, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5539) },
                    { 595314144, 514301477, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5509), 1112681808, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5511) },
                    { 687865253, 514301477, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5495), -335699720, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5496) },
                    { 893568788, 514301477, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5551), -1054164271, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5553) },
                    { 924488473, 514301477, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5524), -2025825133, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5526) },
                    { 211316622, 541183351, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4750), 1290310943, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4751) },
                    { 595314144, 541183351, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4785), -1562731285, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4786) },
                    { 687865253, 541183351, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4770), -1596343117, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4772) },
                    { 193816538, 658641439, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4917), -1208790746, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4918) },
                    { 211316622, 658641439, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4887), 2081358657, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4889) },
                    { 316224155, 658641439, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4962), 386920148, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4963) },
                    { 595314144, 658641439, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4933), 247193254, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4935) },
                    { 687865253, 658641439, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4902), -28551451, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4904) },
                    { 924488473, 658641439, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4948), -1593549805, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4949) },
                    { 193816538, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5286), 1594045242, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5287) },
                    { 211316622, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5242), -449796392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5243) },
                    { 316224155, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5344), -204750188, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5346) },
                    { 324661367, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5373), 1329490575, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5375) },
                    { 370120036, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5272), -2015100517, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5273) },
                    { 450032704, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5301), -164233480, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5302) },
                    { 506451568, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5315), -1926942326, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5317) },
                    { 687865253, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5257), -1839188825, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5259) },
                    { 893568788, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5359), -885710969, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5360) },
                    { 924488473, 674832237, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5330), -709872142, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5331) },
                    { 193816538, 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5018), 674299283, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5019) },
                    { 211316622, 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4975), -627121664, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4977) },
                    { 316224155, 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5079), 1162686218, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5080) },
                    { 370120036, 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5005), 604901633, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5006) },
                    { 450032704, 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5035), -671496745, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5036) },
                    { 595314144, 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5050), -175902614, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5051) },
                    { 687865253, 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4990), 561819776, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(4991) },
                    { 893568788, 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5094), -1111613845, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5096) },
                    { 924488473, 780372777, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5064), -1382335186, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5066) },
                    { 211316622, 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5109), -224729014, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5110) },
                    { 316224155, 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5197), -1281400910, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5198) },
                    { 450032704, 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5138), -761637770, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5140) },
                    { 451092306, 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5226), 817890062, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5227) },
                    { 506451568, 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5152), -1256029217, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5154) },
                    { 595314144, 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5167), -1674576589, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5169) },
                    { 687865253, 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5123), -1936343123, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5125) },
                    { 893568788, 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5211), -943468847, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5212) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 924488473, 788612851, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5182), -2122972703, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5184) },
                    { 211316622, 849365862, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5388), -2103089705, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5389) },
                    { 211316622, 949616405, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5403), -719299160, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5404) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 206770108, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6355), 513187767, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6356) },
                    { 788612851, 160249707, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5697), 482834947, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5698) },
                    { 541183351, 176749873, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5930), 838943614, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5931) },
                    { 206770108, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6692), 876786828, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6694) },
                    { 206770108, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6056), 274656350, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6057) },
                    { 658641439, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6821), 53458852, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6823) },
                    { 206770108, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6479), 342650644, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6481) },
                    { 658641439, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6850), 329747992, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6852) },
                    { 780372777, 294523581, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5738), 243796775, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5739) },
                    { 206770108, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6299), 893496604, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6300) },
                    { 658641439, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6836), 282315819, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6838) },
                    { 780372777, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6313), 137615815, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6314) },
                    { 514301477, 380454902, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5887), 451839549, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5888) },
                    { 206770108, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6139), 949717783, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6141) },
                    { 674832237, 477469123, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5656), 348579291, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5657) },
                    { 541183351, 494154701, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6013), 922182499, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6015) },
                    { 206770108, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6396), 716111640, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6397) },
                    { 206770108, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6097), 731706574, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6098) },
                    { 541183351, 618935017, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5971), 462449670, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5972) },
                    { 206770108, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6568), 244596892, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6569) },
                    { 206770108, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6610), 367254534, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6611) },
                    { 206770108, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6438), 798853437, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6439) },
                    { 206770108, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6525), 752265920, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6526) },
                    { 206770108, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6184), 166623519, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6186) },
                    { 206770108, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6651), 543638711, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6652) },
                    { 206770108, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6227), 467239149, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6228) },
                    { 255157588, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6241), 286896639, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6242) },
                    { 674832237, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6255), 674480131, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6256) },
                    { 658641439, 864305950, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5824), 221666745, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5826) },
                    { 206770108, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6733), 378857251, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6735) },
                    { 849365862, 944200363, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5781), 670910997, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5783) },
                    { 255157588, 985479541, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5610), 796679568, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(5611) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1605577584, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7727), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7729), 741953091, 818325369, null },
                    { -1231010944, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7741), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7743), 741953091, 758627886, null },
                    { -1023948608, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7799), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7800), 760061021, 198391504, null },
                    { -654386392, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7668), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7670), 949007555, 860603527, null },
                    { -74627472, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7771), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7772), 731527127, 837476857, null },
                    { 65182864, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7592), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7594), 727801577, 803541822, null },
                    { 202852024, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7714), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7715), 741953091, 479532379, null },
                    { 452261816, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7699), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7700), 949007555, 397750566, null },
                    { 1080813432, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7683), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7684), 949007555, 366956793, null },
                    { 1122624280, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7639), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7640), 727801577, 965718780, null },
                    { 1629948936, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7757), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7758), 731527127, 637754401, null },
                    { 1801392480, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7785), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7786), 731527127, 803541822, null },
                    { 1858177752, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7653), 0f, 500L, 0L, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7655), 727801577, 283620520, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 258855442, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7195), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7197), 4000.0, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7196), "Signature 142346", 44762, 741953091, 3.0, 17.0 },
                    { 803546808, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7294), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7297), 13000.0, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7296), "Signature 142344", 56046, 731527127, 4.0, 24.0 },
                    { 917720669, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7119), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7122), 3100.0, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7121), "Signature 142346", 19763, 949007555, 2.0, 24.0 },
                    { 932818759, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7037), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7039), 3010.0, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7038), "Signature 142343", 13211, 727801577, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 174457096, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7156), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7157), null, "6949277783", null, null, 741953091, "alexpl_{i}@gmail.com" },
                    { 678969380, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7229), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7230), null, "6949277784", null, null, 731527127, "alexpl_{i}@gmail.com" },
                    { 854285583, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7081), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7082), null, "6949277782", null, null, 949007555, "alexpl_{i}@gmail.com" },
                    { 989614246, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6991), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(6992), null, "6949277781", null, null, 727801577, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1605577584, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1097), 419255972, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1098) },
                    { -1605577584, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1222), 135238389, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1224) },
                    { -1605577584, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1021), 505235186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1022) },
                    { -1605577584, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1135), 280069480, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1136) },
                    { -1605577584, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1084), 557380088, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1086) },
                    { -1605577584, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1047), 398526426, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1048) },
                    { -1605577584, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1110), 449248701, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1111) },
                    { -1605577584, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1033), 913316167, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1035) },
                    { -1605577584, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1160), 963002494, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1161) },
                    { -1605577584, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1172), 363332980, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1174) },
                    { -1605577584, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1122), 609501429, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1123) },
                    { -1605577584, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1147), 673537934, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1148) },
                    { -1605577584, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1059), 568230143, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1060) },
                    { -1605577584, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1185), 896211183, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1187) },
                    { -1605577584, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1072), 861483783, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1073) },
                    { -1605577584, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1236), 241530202, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1238) },
                    { -1231010944, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1331), 832720810, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1333) },
                    { -1231010944, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1435), 144438251, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1437) },
                    { -1231010944, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1250), 914773631, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1251) },
                    { -1231010944, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1370), 509214759, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1371) },
                    { -1231010944, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1318), 718491928, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1320) },
                    { -1231010944, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1279), 733269222, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1280) },
                    { -1231010944, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1344), 598916190, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1346) },
                    { -1231010944, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1265), 882507613, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1266) },
                    { -1231010944, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1396), 454041443, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1397) },
                    { -1231010944, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1409), 208294340, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1410) },
                    { -1231010944, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1357), 874161821, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1358) },
                    { -1231010944, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1383), 326906669, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1384) },
                    { -1231010944, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1292), 306158729, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1293) },
                    { -1231010944, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1422), 954256231, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1423) },
                    { -1231010944, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1305), 414300476, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1306) },
                    { -1231010944, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1448), 943784406, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1449) },
                    { -654386392, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(231), 186739035, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(233) },
                    { -654386392, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(334), 320646784, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(335) },
                    { -654386392, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(155), 415141409, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(156) },
                    { -654386392, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(270), 488113851, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(271) },
                    { -654386392, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(219), 168766766, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(220) },
                    { -654386392, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(180), 867809138, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(181) },
                    { -654386392, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(244), 446181321, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(245) },
                    { -654386392, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(168), 137456176, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(169) },
                    { -654386392, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(295), 190227820, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(296) },
                    { -654386392, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(308), 989865177, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(309) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -654386392, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(257), 374906475, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(258) },
                    { -654386392, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(282), 682003284, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(284) },
                    { -654386392, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(193), 609318214, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(194) },
                    { -654386392, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(321), 227735931, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(322) },
                    { -654386392, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(206), 633200594, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(207) },
                    { -654386392, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(346), 998507725, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(348) },
                    { -74627472, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1770), 940040540, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1771) },
                    { -74627472, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1871), 733136768, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1872) },
                    { -74627472, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1693), 950559745, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1694) },
                    { -74627472, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1808), 767412300, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1809) },
                    { -74627472, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1757), 199387166, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1758) },
                    { -74627472, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1719), 897850382, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1720) },
                    { -74627472, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1782), 574855730, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1783) },
                    { -74627472, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1706), 832536134, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1707) },
                    { -74627472, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1833), 134477147, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1834) },
                    { -74627472, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1845), 563703871, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1847) },
                    { -74627472, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1795), 432311546, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1796) },
                    { -74627472, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1820), 556598299, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1822) },
                    { -74627472, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1731), 963062549, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1732) },
                    { -74627472, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1858), 773157050, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1859) },
                    { -74627472, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1744), 490107494, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1745) },
                    { -74627472, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1884), 824536666, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1885) },
                    { 65182864, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9555), 828681384, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9556) },
                    { 65182864, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9682), 410861827, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9684) },
                    { 65182864, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9456), 595850774, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9457) },
                    { 65182864, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9617), 653442224, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9618) },
                    { 65182864, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9542), 203405445, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9543) },
                    { 65182864, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9502), 827181351, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9503) },
                    { 65182864, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9568), 973362168, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9569) },
                    { 65182864, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9475), 373311762, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9476) },
                    { 65182864, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9644), 723467038, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9645) },
                    { 65182864, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9657), 634421848, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9658) },
                    { 65182864, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9580), 289915394, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9581) },
                    { 65182864, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9631), 164274319, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9632) },
                    { 65182864, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9515), 497397229, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9517) },
                    { 65182864, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9670), 182942730, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9671) },
                    { 65182864, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9528), 933062214, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9529) },
                    { 65182864, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9695), 815919433, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9696) },
                    { 202852024, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(894), 526988253, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(895) },
                    { 202852024, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(995), 587406600, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(996) },
                    { 202852024, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(817), 131351059, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(818) },
                    { 202852024, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(932), 561366450, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(934) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 202852024, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(881), 171682336, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(882) },
                    { 202852024, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(843), 902574789, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(844) },
                    { 202852024, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(907), 636759356, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(908) },
                    { 202852024, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(830), 541885424, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(831) },
                    { 202852024, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(957), 610895449, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(959) },
                    { 202852024, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(970), 672158558, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(971) },
                    { 202852024, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(920), 419218148, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(921) },
                    { 202852024, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(945), 573795959, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(946) },
                    { 202852024, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(856), 789761315, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(857) },
                    { 202852024, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(983), 128264766, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(984) },
                    { 202852024, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(869), 517478875, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(870) },
                    { 202852024, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1008), 434132923, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1009) },
                    { 452261816, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(665), 511883038, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(666) },
                    { 452261816, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(765), 998474928, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(766) },
                    { 452261816, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(589), 335636094, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(590) },
                    { 452261816, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(702), 999362517, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(704) },
                    { 452261816, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(652), 289370824, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(653) },
                    { 452261816, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(615), 933210912, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(616) },
                    { 452261816, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(677), 938128240, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(678) },
                    { 452261816, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(602), 959248374, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(603) },
                    { 452261816, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(728), 478386964, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(729) },
                    { 452261816, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(740), 434806004, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(741) },
                    { 452261816, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(690), 156384924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(691) },
                    { 452261816, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(715), 785950237, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(716) },
                    { 452261816, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(627), 791888180, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(628) },
                    { 452261816, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(753), 993802088, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(754) },
                    { 452261816, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(640), 251213984, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(641) },
                    { 452261816, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(803), 293415872, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(804) },
                    { 1080813432, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(462), 652544891, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(463) },
                    { 1080813432, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(564), 956994974, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(565) },
                    { 1080813432, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(359), 726147646, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(361) },
                    { 1080813432, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(501), 570683822, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(502) },
                    { 1080813432, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(449), 842097575, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(450) },
                    { 1080813432, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(410), 235577172, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(411) },
                    { 1080813432, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(474), 923426524, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(475) },
                    { 1080813432, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(396), 744466664, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(398) },
                    { 1080813432, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(526), 631325927, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(527) },
                    { 1080813432, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(539), 524936070, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(540) },
                    { 1080813432, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(487), 720638404, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(489) },
                    { 1080813432, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(513), 976673255, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(515) },
                    { 1080813432, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(423), 221289134, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(424) },
                    { 1080813432, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(551), 922559397, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(553) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1080813432, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(435), 690655622, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(437) },
                    { 1080813432, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(576), 173729925, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(577) },
                    { 1122624280, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9786), 396325425, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9787) },
                    { 1122624280, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9888), 962524207, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9889) },
                    { 1122624280, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9708), 609358070, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9710) },
                    { 1122624280, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9825), 476181974, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9826) },
                    { 1122624280, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9774), 156851347, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9775) },
                    { 1122624280, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9736), 163765224, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9737) },
                    { 1122624280, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9799), 401911148, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9800) },
                    { 1122624280, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9723), 770561742, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9724) },
                    { 1122624280, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9850), 980760217, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9851) },
                    { 1122624280, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9863), 137388319, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9864) },
                    { 1122624280, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9812), 158728043, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9813) },
                    { 1122624280, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9837), 965928201, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9838) },
                    { 1122624280, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9748), 553279174, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9750) },
                    { 1122624280, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9875), 832028206, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9877) },
                    { 1122624280, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9761), 329506392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9762) },
                    { 1122624280, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9901), 943471299, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9902) },
                    { 1629948936, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1563), 961426378, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1565) },
                    { 1629948936, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1667), 163375891, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1669) },
                    { 1629948936, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1462), 774504005, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1463) },
                    { 1629948936, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1603), 786179521, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1604) },
                    { 1629948936, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1549), 235689737, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1550) },
                    { 1629948936, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1487), 898250057, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1488) },
                    { 1629948936, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1577), 530127097, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1578) },
                    { 1629948936, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1474), 602719884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1475) },
                    { 1629948936, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1628), 429331349, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1630) },
                    { 1629948936, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1642), 355655464, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1643) },
                    { 1629948936, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1589), 515598865, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1591) },
                    { 1629948936, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1616), 997056766, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1617) },
                    { 1629948936, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1500), 977595274, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1502) },
                    { 1629948936, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1654), 721613454, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1656) },
                    { 1629948936, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1513), 820594732, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1515) },
                    { 1629948936, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1680), 210376455, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1681) },
                    { 1801392480, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1998), 934682060, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1999) },
                    { 1801392480, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2102), 260993137, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2104) },
                    { 1801392480, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1897), 655495121, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1898) },
                    { 1801392480, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2037), 448254549, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2039) },
                    { 1801392480, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1986), 351012222, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1987) },
                    { 1801392480, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1922), 238204351, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1923) },
                    { 1801392480, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2011), 966817496, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2013) },
                    { 1801392480, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1909), 555084220, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1910) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1801392480, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2063), 636311448, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2065) },
                    { 1801392480, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2077), 961814824, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2078) },
                    { 1801392480, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2024), 475921565, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2026) },
                    { 1801392480, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2050), 560523423, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2052) },
                    { 1801392480, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1934), 871718289, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1935) },
                    { 1801392480, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2090), 305770614, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2091) },
                    { 1801392480, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1973), 852682027, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(1974) },
                    { 1801392480, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2115), 642797460, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(2116) },
                    { 1858177752, 139276396, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(23), 564173125, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(24) },
                    { 1858177752, 225265570, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(128), 947000804, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(129) },
                    { 1858177752, 272170333, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9918), 739648324, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9919) },
                    { 1858177752, 294047603, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(62), 977201586, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(63) },
                    { 1858177752, 315280497, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(9), 953593067, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(10) },
                    { 1858177752, 423661495, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9945), 531857906, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9946) },
                    { 1858177752, 542554939, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(36), 410235644, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(37) },
                    { 1858177752, 589297259, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9932), 985515141, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9934) },
                    { 1858177752, 624575747, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(87), 601535366, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(89) },
                    { 1858177752, 681672876, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(100), 691039422, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(101) },
                    { 1858177752, 691664186, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(49), 126854083, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(50) },
                    { 1858177752, 758340740, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(74), 192378470, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(76) },
                    { 1858177752, 764356924, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9958), 884231726, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9959) },
                    { 1858177752, 770071884, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(116), 462212611, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(117) },
                    { 1858177752, 818287581, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9971), 902473556, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9972) },
                    { 1858177752, 868823787, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(141), 274702596, new DateTime(2024, 3, 20, 16, 53, 6, 342, DateTimeKind.Local).AddTicks(142) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 180008156, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8081), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8079), 1080813432, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8080), 169662456 },
                    { 185511328, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8164), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8162), 202852024, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8163), 169662456 },
                    { 200703839, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8205), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8202), -1605577584, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8203), 169662456 },
                    { 227294025, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8245), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8243), -1231010944, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8244), 169662456 },
                    { 258514159, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7867), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7864), 65182864, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7865), 865613230 },
                    { 263176312, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8177), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8175), 202852024, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8176), 227055275 },
                    { 269247522, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7956), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7953), 1858177752, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7954), 865613230 },
                    { 276898829, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8121), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8119), 452261816, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8120), 169662456 },
                    { 352644564, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7941), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7939), 1122624280, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7940), 227055275 },
                    { 368235342, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8191), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8189), -1605577584, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8190), 865613230 },
                    { 372988997, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8054), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8051), -654386392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8053), 227055275 },
                    { 380443154, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8299), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8297), 1629948936, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8298), 227055275 },
                    { 423092000, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8068), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8065), 1080813432, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8067), 865613230 },
                    { 427129409, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8381), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8378), 1801392480, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8380), 865613230 },
                    { 469337394, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8423), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8420), -1023948608, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8421), 865613230 },
                    { 472165161, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7997), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7994), 1858177752, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7995), 169662456 },
                    { 483119326, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8365), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8363), -74627472, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8364), 227055275 },
                    { 501990372, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8150), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8148), 202852024, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8149), 865613230 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 506503857, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7899), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7896), 65182864, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7897), 227055275 },
                    { 507978026, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8259), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8256), -1231010944, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8258), 227055275 },
                    { 510072483, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8027), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8025), -654386392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8026), 865613230 },
                    { 523677944, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8408), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8405), 1801392480, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8407), 227055275 },
                    { 605002671, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8095), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8092), 1080813432, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8093), 227055275 },
                    { 609142048, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7926), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7924), 1122624280, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7925), 169662456 },
                    { 612401394, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8395), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8392), 1801392480, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8393), 169662456 },
                    { 636749733, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7885), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7882), 65182864, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7883), 169662456 },
                    { 675564629, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8041), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8038), -654386392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8039), 169662456 },
                    { 685208668, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8351), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8349), -74627472, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8350), 169662456 },
                    { 766938067, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8272), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8270), 1629948936, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8271), 865613230 },
                    { 775904407, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7913), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7910), 1122624280, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7911), 865613230 },
                    { 805078409, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8452), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8449), -1023948608, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8450), 227055275 },
                    { 817185675, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8231), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8229), -1231010944, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8230), 865613230 },
                    { 886133064, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8438), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8435), -1023948608, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8436), 169662456 },
                    { 910308663, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8011), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8009), 1858177752, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8010), 227055275 },
                    { 916688715, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8218), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8215), -1605577584, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8217), 227055275 },
                    { 934759843, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8108), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8106), 452261816, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8107), 865613230 },
                    { 958398580, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8286), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8283), 1629948936, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8284), 169662456 },
                    { 979372799, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8137), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8134), 452261816, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8135), 227055275 },
                    { 988503599, new DateTime(2024, 3, 31, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8312), 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8310), -74627472, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8311), 865613230 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 313336578, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7008), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7009), 989614246 },
                    { 354828770, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7268), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7269), 678969380 },
                    { 387698138, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7170), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7171), 174457096 },
                    { 631582979, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7095), new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7096), 854285583 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 145737194, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8582), 65182864, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8583), 165421732 },
                    { 158573297, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8719), 1858177752, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8720), 506622338 },
                    { 158642517, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9368), 1801392480, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9369), 165421732 },
                    { 185009525, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9104), -1231010944, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9105), 506622338 },
                    { 185517303, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8890), 452261816, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8891), 579904188 },
                    { 203995920, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9380), 1801392480, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9381), 189992110 },
                    { 207784300, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9117), -1231010944, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9118), 165421732 },
                    { 255094513, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9406), -1023948608, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9407), 579904188 },
                    { 263524865, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9189), 1629948936, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9190), 189992110 },
                    { 290409581, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9283), -74627472, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9284), 579904188 },
                    { 291398469, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8557), 65182864, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8558), 579904188 },
                    { 295882126, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8830), 1080813432, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8831), 579904188 },
                    { 312505791, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9092), -1231010944, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9093), 579904188 },
                    { 321355202, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9080), -1231010944, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9081), 484208098 },
                    { 328283651, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9430), -1023948608, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9431), 165421732 },
                    { 345456751, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8866), 1080813432, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8867), 189992110 },
                    { 350242020, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9153), 1629948936, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9154), 579904188 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 369457005, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9177), 1629948936, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9178), 165421732 },
                    { 373856325, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9043), -1605577584, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9044), 506622338 },
                    { 376126274, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8620), 1122624280, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8622), 579904188 },
                    { 378995118, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8818), 1080813432, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8819), 484208098 },
                    { 406221078, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9129), -1231010944, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9130), 189992110 },
                    { 408140265, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8926), 452261816, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8927), 189992110 },
                    { 418415642, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9392), -1023948608, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9393), 484208098 },
                    { 420680918, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9331), 1801392480, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9333), 484208098 },
                    { 425345308, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9307), -74627472, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9308), 165421732 },
                    { 426729593, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8707), 1858177752, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8708), 579904188 },
                    { 428967813, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9031), -1605577584, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9032), 579904188 },
                    { 467217724, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8902), 452261816, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8903), 506622338 },
                    { 486573637, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9005), 202852024, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9006), 189992110 },
                    { 497418206, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8681), 1122624280, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8682), 189992110 },
                    { 513492292, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9018), -1605577584, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9019), 484208098 },
                    { 513784733, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9295), -74627472, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9296), 506622338 },
                    { 532561096, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9055), -1605577584, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9057), 165421732 },
                    { 546857504, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8731), 1858177752, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8732), 165421732 },
                    { 555124395, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8962), 202852024, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8963), 506622338 },
                    { 557228951, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8914), 452261816, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8915), 165421732 },
                    { 580931539, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8794), -654386392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8795), 165421732 },
                    { 595057774, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8756), -654386392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8757), 484208098 },
                    { 595212855, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8878), 452261816, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8880), 484208098 },
                    { 601843171, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8539), 65182864, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8540), 484208098 },
                    { 622256279, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8854), 1080813432, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8855), 165421732 },
                    { 644009653, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9141), 1629948936, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9142), 484208098 },
                    { 644687017, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9441), -1023948608, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9443), 189992110 },
                    { 665012008, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8594), 65182864, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8595), 189992110 },
                    { 710577919, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8694), 1858177752, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8695), 484208098 },
                    { 723249816, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9356), 1801392480, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9357), 506622338 },
                    { 740453353, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8938), 202852024, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8939), 484208098 },
                    { 742423999, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8633), 1122624280, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8634), 506622338 },
                    { 769415989, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8950), 202852024, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8951), 579904188 },
                    { 771508029, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8608), 1122624280, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8609), 484208098 },
                    { 836367377, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8806), -654386392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8807), 189992110 },
                    { 839720435, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9165), 1629948936, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9166), 506622338 },
                    { 868431210, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9067), -1605577584, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9069), 189992110 },
                    { 907214662, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8842), 1080813432, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8844), 506622338 },
                    { 929486137, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9270), -74627472, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9271), 484208098 },
                    { 936417066, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8569), 65182864, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8571), 506622338 },
                    { 940956376, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8743), 1858177752, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8745), 189992110 },
                    { 943602033, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8976), 202852024, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8977), 165421732 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 950035209, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8781), -654386392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8783), 506622338 },
                    { 952602764, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8645), 1122624280, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8646), 165421732 },
                    { 967737306, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9418), -1023948608, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9419), 506622338 },
                    { 981074506, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9319), -74627472, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9320), 189992110 },
                    { 983113616, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9344), 1801392480, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(9345), 579904188 },
                    { 996291046, 0f, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8768), -654386392, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(8769), 579904188 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 949616405, 174457096, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7182), 201138637, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7183) },
                    { 949616405, 678969380, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7281), 378762059, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7283) },
                    { 949616405, 854285583, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7107), 425327483, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7108) },
                    { 949616405, 989614246, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7022), 648634982, new DateTime(2024, 3, 20, 16, 53, 6, 341, DateTimeKind.Local).AddTicks(7023) }
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
