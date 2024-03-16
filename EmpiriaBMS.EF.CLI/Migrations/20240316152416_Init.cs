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
                    PaymentDetailes = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { 146063663, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7562), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7563), "Photovoltaics" },
                    { 149077241, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7514), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7515), "Structured Cabling" },
                    { 176075020, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7623), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7624), "Project Manager Hours" },
                    { 359391870, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7538), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7539), "CCTV" },
                    { 428195479, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7448), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7449), "Fire Detection" },
                    { 477983693, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7489), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7490), "Natural Gas" },
                    { 524393079, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7501), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7502), "Power Distribution" },
                    { 606948020, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7597), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7598), "TenderDocument" },
                    { 671625631, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7425), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7426), "Potable Water" },
                    { 682623075, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7462), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7463), "Fire Suppression" },
                    { 686468757, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7585), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7586), "Outsource" },
                    { 747356566, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7526), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7527), "Burglar Alarm" },
                    { 748398614, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7437), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7438), "Drainage" },
                    { 790380741, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7413), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7414), "Sewage" },
                    { 799215159, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7573), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7574), "Energy Efficiency" },
                    { 829723767, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7550), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7551), "BMS" },
                    { 923767835, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7474), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7475), "Elevators" },
                    { 967781929, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7610), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7611), "Construction Supervision" },
                    { 994730490, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7391), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7392), "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 381883916, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7850), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7851), "Documents" },
                    { 507002765, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7884), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7885), "Drawings" },
                    { 559030193, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7870), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7871), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 137148909, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8513), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8515), "Meetings" },
                    { 411147833, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8526), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8527), "Administration" },
                    { 499888698, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8463), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8464), "Communications" },
                    { 508256876, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8487), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8488), "Printing" },
                    { 996509883, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8501), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8502), "On-Site" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 268419821, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4502), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4504), "Dashboard Edit My Hours", 2 },
                    { 272575096, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4548), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4549), "Dashboard Assign Project Manager", 5 },
                    { 287922488, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4413), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4415), "See Dashboard Layout", 1 },
                    { 358350555, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4534), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4535), "Dashboard Assign Engineer", 4 },
                    { 438965231, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4519), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4521), "Dashboard Assign Designer", 3 },
                    { 568828302, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4607), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4608), "See All Disciplines", 9 },
                    { 591823479, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4622), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4623), "See All Drawings", 10 },
                    { 686193747, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4564), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4565), "Dashboard Add Project", 6 },
                    { 687574474, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4636), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4637), "See All Projects", 11 },
                    { 943519933, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4579), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4580), "See Admin Layout", 7 },
                    { 978453863, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4592), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4594), "Dashboard See My Hours", 8 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 168957340, false, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6913), "Production Management Description", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6914), "Production Management" },
                    { 345324720, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6899), "Consulting Description", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6900), "Consulting" },
                    { 571573384, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6853), "Buildings Description", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6854), "Buildings" },
                    { 911511267, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6871), "Infrastructure Description", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6872), "Infrastructure" }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[] { 958502534, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6885), "Energy Description", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6886), "Energy" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 136143054, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4651), false, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4653), "Designer" },
                    { 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4734), false, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4736), "CEO" },
                    { 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4705), false, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4706), "COO" },
                    { 277799047, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4778), false, false, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4780), "Admin" },
                    { 333429261, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4750), false, false, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4751), "Guest" },
                    { 438134464, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4764), false, false, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4765), "Customer" },
                    { 666843609, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4690), false, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4692), "Project Manager" },
                    { 773548819, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4794), false, false, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4795), "Secretariat" },
                    { 833716015, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4719), false, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4721), "CTO" },
                    { 954913108, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4676), false, true, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4677), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 128458272, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5987), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5989), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 141488269, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6034), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6035), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com" },
                    { 164246084, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5597), "Admin", "Platanios", "Alexandros", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5598), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com" },
                    { 167711265, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5879), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5880), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com" },
                    { 197662225, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5789), "Guest", "Platanios", "Alexandros", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5790), null, "694927778", null, null, null, "guest@gmail.com" },
                    { 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6675), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6677), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com" },
                    { 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6762), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6763), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com" },
                    { 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6457), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6458), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com" },
                    { 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6080), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6082), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com" },
                    { 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6407), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6409), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com" },
                    { 470649085, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5656), "CEO", "Platanios", "Alexandros", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5657), null, "694927778", null, null, null, "ceo@gmail.com" },
                    { 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6805), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6806), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com" },
                    { 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6500), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6501), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com" },
                    { 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6544), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6545), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com" },
                    { 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6208), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6210), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com" },
                    { 621207024, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5943), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5944), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com" },
                    { 667258335, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5700), "CTO", "Platanios", "Alexandros", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5701), null, "694927778", null, null, null, "cto@gmail.com" },
                    { 723800143, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5834), "Project Manager", "Platanios", "Alexandros", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5835), null, "694927778", null, null, null, "pm@gmail.com" },
                    { 742824100, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5746), "COO", "Platanios", "Alexandros", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5748), null, "694927778", null, null, null, "coo@gmail.com" },
                    { 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6587), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6588), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com" },
                    { 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6166), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6167), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com" },
                    { 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6630), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6631), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com" },
                    { 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6719), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6721), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com" },
                    { 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6252), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6254), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com" },
                    { 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6348), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6349), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com" },
                    { 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6123), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6124), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 173496349, "akonstantinidou@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5913), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5914), 167711265 },
                    { 179009162, "ntriantafyllou@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6823), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6825), 497122066 },
                    { 221874232, "agretos@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6472), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6474), 288526387 },
                    { 236298906, "vpax@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6096), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6097), 355643372 },
                    { 240459026, "embiria@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5897), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5899), 167711265 },
                    { 242971002, "vtza@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6424), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6425), 410969392 },
                    { 281578776, "kkotsoni@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6363), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6365), 907870427 },
                    { 336573927, "vchontos@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6734), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6736), 879227760 },
                    { 369137705, "blekou@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6690), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6692), 270680498 },
                    { 377759894, "xmanarolis@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6138), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6140), 946249654 },
                    { 378479448, "dtsa@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6049), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6050), 141488269 },
                    { 437750046, "dtsa@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6004), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6006), 128458272 },
                    { 445065387, "alexandrosplatanios15@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5617), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5618), 164246084 },
                    { 499467328, "ngal@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6288), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6289), 888094041 },
                    { 520979921, "sparisis@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6180), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6182), 802373452 },
                    { 554733607, "ceo@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5671), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5672), 470649085 },
                    { 555890154, "cto@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5714), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5716), 667258335 },
                    { 606722296, "pfokianou@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6601), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6603), 800212641 },
                    { 632045547, "ogiannoglou@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6647), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6648), 836486281 },
                    { 639818974, "pm@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5850), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5851), 723800143 },
                    { 653558617, "kmargeti@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6516), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6517), 503764598 },
                    { 659576535, "gdoug@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5959), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5960), 621207024 },
                    { 705697482, "panperivollari@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6777), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6778), 279336811 },
                    { 767950776, "chkovras@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6223), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6225), 609178691 },
                    { 862640062, "guest@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5805), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5806), 197662225 },
                    { 877328086, "coo@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5761), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5763), 742824100 },
                    { 947746910, "haris@embiria.gr", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6558), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6560), 510400043 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "SubContractorId", "TypeId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 282399733, false, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 8.0, 9, new DateTime(2024, 12, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 9, "Test Description Project_6", new DateTime(2024, 12, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), new DateTime(2024, 12, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f, 1500L, 12L, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Project_3", 5.0, new DateTime(2024, 12, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Payment Detailes For Project_9", 3.0, null, null, 958502534, new DateTime(2024, 12, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f },
                    { 306257293, true, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 7.0, 4, new DateTime(2024, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 4, "Test Description Project_4", new DateTime(2024, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), new DateTime(2024, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f, 1500L, 12L, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Project_2", 5.0, new DateTime(2024, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Payment Detailes For Project_2", 2.0, null, null, 911511267, new DateTime(2024, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f },
                    { 445143759, false, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 6.0, 1, new DateTime(2024, 4, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 1, "Test Description Project_6", new DateTime(2024, 4, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), new DateTime(2024, 4, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f, 1500L, 12L, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Project_1", 5.0, new DateTime(2024, 4, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Payment Detailes For Project_6", 1.0, null, null, 571573384, new DateTime(2024, 4, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f },
                    { 561990111, true, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 9.0, 16, new DateTime(2025, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 16, "Test Description Project_16", new DateTime(2025, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), new DateTime(2025, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f, 1500L, 12L, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Project_4", 5.0, new DateTime(2025, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Payment Detailes For Project_20", 4.0, null, null, 345324720, new DateTime(2025, 7, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f },
                    { 710349608, true, "ALPHA", 345, "D-22-16-PM", 0f, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 111.0, 90, new DateTime(2024, 6, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 1, "Test Description Project_PM", new DateTime(2024, 4, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), new DateTime(2024, 5, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f, 1500L, 12L, new DateTime(2024, 3, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Project_PM", 45.0, new DateTime(2024, 4, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), "Payment Detailes For Project_PM", 2.0, null, null, 168957340, new DateTime(2024, 5, 16, 17, 24, 15, 836, DateTimeKind.Local).AddTicks(9539), 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 268419821, 136143054, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4833), -1823938019, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4834) },
                    { 287922488, 136143054, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4809), -553730368, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4810) },
                    { 978453863, 136143054, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4847), -322451207, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4848) },
                    { 268419821, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5293), 303680741, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5294) },
                    { 272575096, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5339), -1050771455, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5341) },
                    { 287922488, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5277), 187718923, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5279) },
                    { 358350555, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5325), -2115273397, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5326) },
                    { 438965231, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5311), -1108152278, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5312) },
                    { 568828302, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5381), -970115359, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5382) },
                    { 591823479, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5395), -368730013, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5396) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 686193747, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5353), -2089810997, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5355) },
                    { 687574474, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5410), -1777300357, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5411) },
                    { 943519933, 204995557, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5367), -1274700005, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5368) },
                    { 268419821, 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5051), -955431431, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5052) },
                    { 272575096, 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5095), -1029488444, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5096) },
                    { 287922488, 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5037), -339860191, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5038) },
                    { 358350555, 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5081), 218017684, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5082) },
                    { 438965231, 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5066), -1828500083, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5067) },
                    { 568828302, 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5123), -507046868, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5124) },
                    { 591823479, 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5137), 210939638, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5138) },
                    { 687574474, 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5151), -1946194861, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5152) },
                    { 978453863, 208908936, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5109), -193821902, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5110) },
                    { 568828302, 277799047, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5466), -632809849, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5468) },
                    { 591823479, 277799047, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5480), -1481589688, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5482) },
                    { 687574474, 277799047, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5495), -645964478, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5496) },
                    { 943519933, 277799047, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5452), -1109566813, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5454) },
                    { 287922488, 333429261, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5424), -1589800234, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5425) },
                    { 287922488, 438134464, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5438), -889783964, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5439) },
                    { 268419821, 666843609, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4967), 1429494341, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4968) },
                    { 287922488, 666843609, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4953), 2109008885, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4955) },
                    { 358350555, 666843609, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4981), 1782571307, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4982) },
                    { 568828302, 666843609, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5009), 843817262, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5011) },
                    { 591823479, 666843609, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5023), -1013292431, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5024) },
                    { 978453863, 666843609, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4995), 1330430243, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4996) },
                    { 268419821, 773548819, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5523), -1387825289, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5524) },
                    { 287922488, 773548819, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5509), 85812625, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5510) },
                    { 568828302, 773548819, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5551), 1296062946, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5553) },
                    { 591823479, 773548819, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5567), -514003922, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5568) },
                    { 687574474, 773548819, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5581), -998484317, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5582) },
                    { 978453863, 773548819, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5538), 1841558409, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5539) },
                    { 268419821, 833716015, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5179), -1259836055, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5180) },
                    { 272575096, 833716015, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5192), -1967702116, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5194) },
                    { 287922488, 833716015, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5165), -247710388, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5166) },
                    { 568828302, 833716015, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5234), -402294761, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5235) },
                    { 591823479, 833716015, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5248), 1224210006, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5250) },
                    { 686193747, 833716015, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5206), -770331248, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5207) },
                    { 687574474, 833716015, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5262), -1478218963, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5264) },
                    { 978453863, 833716015, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5220), -678225307, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5221) },
                    { 268419821, 954913108, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4876), 1952689010, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4877) },
                    { 287922488, 954913108, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4862), -2055389660, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4863) },
                    { 438965231, 954913108, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4891), 158477180, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4892) },
                    { 568828302, 954913108, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4924), -106566871, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4925) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 591823479, 954913108, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4938), 1850796954, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4939) },
                    { 978453863, 954913108, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4905), -179575195, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(4906) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 136143054, 128458272, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6018), 513876514, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6020) },
                    { 136143054, 141488269, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6063), 569630751, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6064) },
                    { 277799047, 164246084, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5634), 457575846, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5635) },
                    { 773548819, 167711265, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5926), 139433244, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5928) },
                    { 333429261, 197662225, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5819), 755114329, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5820) },
                    { 954913108, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6704), 470820520, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6705) },
                    { 954913108, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6790), 449150625, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6791) },
                    { 954913108, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6486), 889437953, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6487) },
                    { 666843609, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6929), 310454707, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6930) },
                    { 954913108, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6109), 764387223, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6110) },
                    { 954913108, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6438), 282756330, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6439) },
                    { 204995557, 470649085, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5686), 710772097, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5687) },
                    { 954913108, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6838), 486940193, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6839) },
                    { 954913108, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6529), 290449281, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6530) },
                    { 666843609, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6959), 293041918, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6960) },
                    { 954913108, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6572), 493780028, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6574) },
                    { 954913108, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6237), 385802211, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6238) },
                    { 136143054, 621207024, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5973), 213826298, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5974) },
                    { 833716015, 667258335, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5732), 226214909, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5733) },
                    { 666843609, 723800143, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5863), 538956378, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5865) },
                    { 208908936, 742824100, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5775), 475746702, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(5776) },
                    { 954913108, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6615), 988942645, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6616) },
                    { 954913108, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6194), 857167649, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6195) },
                    { 954913108, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6660), 813689343, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6661) },
                    { 954913108, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6748), 706106807, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6749) },
                    { 204995557, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6332), 267900570, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6333) },
                    { 277799047, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6317), 620587335, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6318) },
                    { 954913108, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6302), 727388958, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6303) },
                    { 208908936, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6393), 128725111, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6394) },
                    { 666843609, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6945), 85510561, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6946) },
                    { 954913108, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6378), 566850717, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6379) },
                    { 954913108, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6151), 224562681, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(6153) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -1831516064, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7680), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7681), 445143759, 747356566, null },
                    { -1703774184, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7777), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7778), 282399733, 790380741, null },
                    { -1660529528, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7723), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7724), 306257293, 799215159, null },
                    { -1378459520, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7655), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7656), 445143759, 428195479, null },
                    { -257937256, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7809), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7810), 561990111, 524393079, null },
                    { 42697200, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7694), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7695), 445143759, 146063663, null },
                    { 78577000, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7708), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7710), 306257293, 149077241, null },
                    { 82819888, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7751), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7752), 282399733, 671625631, null },
                    { 214577552, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7822), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7823), 561990111, 359391870, null },
                    { 240582328, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7737), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7738), 306257293, 428195479, null },
                    { 1316815352, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7764), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7766), 282399733, 477983693, null },
                    { 1518936840, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7835), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7836), 710349608, 176075020, null },
                    { 2006586200, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7792), 0f, 500L, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7793), 561990111, 606948020, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 373310979, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7271), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7274), 4000.0, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7272), "Signature 1423412", 88559, 282399733, 3.0, 17.0 },
                    { 616356404, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7095), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7098), 3010.0, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7097), "Signature 142346", 12269, 445143759, 1.0, 17.0 },
                    { 748932614, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7347), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7349), 13000.0, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7348), "Signature 1423412", 59894, 561990111, 4.0, 24.0 },
                    { 939242587, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7191), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7194), 3100.0, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7193), "Signature 1423410", 69104, 306257293, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress" },
                values: new object[,]
                {
                    { 435626679, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7147), "Test Description Customer 2", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7148), null, "6949277782", null, null, 306257293, "alexpl_{i}@gmail.com" },
                    { 492551523, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7307), "Test Description Customer 4", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7308), null, "6949277784", null, null, 561990111, "alexpl_{i}@gmail.com" },
                    { 600227926, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7231), "Test Description Customer 3", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7232), null, "6949277783", null, null, 282399733, "alexpl_{i}@gmail.com" },
                    { 863225184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7046), "Test Description Customer 1", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7047), null, "6949277781", null, null, 445143759, "alexpl_{i}@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1831516064, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9761), 433892735, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9762) },
                    { -1831516064, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9787), 403180101, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9788) },
                    { -1831516064, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9697), 489409285, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9698) },
                    { -1831516064, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9609), 574452873, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9610) },
                    { -1831516064, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9685), 586283791, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9686) },
                    { -1831516064, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9800), 648890569, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9801) },
                    { -1831516064, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9709), 949204163, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9710) },
                    { -1831516064, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9722), 349866196, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9723) },
                    { -1831516064, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9648), 986113417, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9649) },
                    { -1831516064, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9735), 632765817, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9736) },
                    { -1831516064, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9635), 323953129, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9636) },
                    { -1831516064, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9748), 726015775, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9749) },
                    { -1831516064, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9774), 368734403, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9775) },
                    { -1831516064, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9660), 226313332, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9661) },
                    { -1831516064, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9672), 910122332, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9673) },
                    { -1831516064, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9623), 265261083, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9624) },
                    { -1703774184, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1193), 317544116, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1194) },
                    { -1703774184, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1218), 573921285, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1219) },
                    { -1703774184, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1130), 648865324, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1131) },
                    { -1703774184, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1041), 601455169, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1042) },
                    { -1703774184, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1117), 340904841, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1119) },
                    { -1703774184, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1231), 700794724, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1232) },
                    { -1703774184, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1142), 575704063, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1144) },
                    { -1703774184, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1155), 561269597, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1156) },
                    { -1703774184, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1080), 943010505, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1081) },
                    { -1703774184, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1168), 678722158, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1169) },
                    { -1703774184, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1067), 973195224, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1068) },
                    { -1703774184, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1180), 902348166, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1181) },
                    { -1703774184, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1205), 472151345, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1206) },
                    { -1703774184, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1093), 517452407, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1094) },
                    { -1703774184, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1105), 476476166, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1106) },
                    { -1703774184, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1054), 997852271, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1056) },
                    { -1660529528, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(379), 420961889, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(380) },
                    { -1660529528, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(404), 991547664, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(405) },
                    { -1660529528, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(316), 141895215, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(317) },
                    { -1660529528, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(223), 170282909, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(224) },
                    { -1660529528, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(303), 743499924, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(304) },
                    { -1660529528, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(417), 320967641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(418) },
                    { -1660529528, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(329), 783330213, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(330) },
                    { -1660529528, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(342), 899139662, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(343) },
                    { -1660529528, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(265), 696791257, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(267) },
                    { -1660529528, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(354), 892150548, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(355) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1660529528, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(253), 867013283, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(254) },
                    { -1660529528, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(367), 682003375, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(368) },
                    { -1660529528, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(392), 562872403, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(393) },
                    { -1660529528, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(278), 732668314, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(279) },
                    { -1660529528, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(291), 357173789, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(292) },
                    { -1660529528, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(239), 510455582, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(241) },
                    { -1378459520, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9559), 229985362, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9560) },
                    { -1378459520, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9584), 460251838, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9585) },
                    { -1378459520, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9490), 369212969, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9491) },
                    { -1378459520, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9385), 596960508, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9386) },
                    { -1378459520, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9477), 136140207, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9478) },
                    { -1378459520, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9596), 530797140, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9597) },
                    { -1378459520, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9506), 245975102, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9507) },
                    { -1378459520, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9520), 463298278, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9521) },
                    { -1378459520, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9436), 523588151, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9437) },
                    { -1378459520, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9533), 695192252, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9534) },
                    { -1378459520, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9423), 709981370, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9424) },
                    { -1378459520, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9546), 421115961, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9547) },
                    { -1378459520, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9571), 673728529, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9572) },
                    { -1378459520, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9450), 954510616, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9451) },
                    { -1378459520, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9464), 764422429, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9465) },
                    { -1378459520, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9410), 207995306, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9411) },
                    { -257937256, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1599), 886004443, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1600) },
                    { -257937256, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1624), 903346302, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1625) },
                    { -257937256, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1536), 685336126, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1537) },
                    { -257937256, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1449), 303358452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1450) },
                    { -257937256, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1524), 593885118, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1525) },
                    { -257937256, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1636), 822979046, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1637) },
                    { -257937256, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1549), 219840171, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1550) },
                    { -257937256, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1561), 187727341, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1562) },
                    { -257937256, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1486), 861099721, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1487) },
                    { -257937256, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1574), 295016579, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1575) },
                    { -257937256, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1474), 701990805, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1475) },
                    { -257937256, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1587), 996785506, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1588) },
                    { -257937256, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1612), 490394433, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1613) },
                    { -257937256, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1499), 918703840, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1500) },
                    { -257937256, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1511), 221702348, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1512) },
                    { -257937256, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1462), 604429951, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1463) },
                    { 42697200, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9970), 603830965, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9971) },
                    { 42697200, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9995), 293361925, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9996) },
                    { 42697200, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9907), 467447490, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9908) },
                    { 42697200, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9813), 360661160, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9814) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 42697200, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9894), 124593845, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9895) },
                    { 42697200, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(8), 196994008, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(9) },
                    { 42697200, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9919), 362887774, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9921) },
                    { 42697200, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9932), 382615388, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9933) },
                    { 42697200, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9855), 799017484, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9857) },
                    { 42697200, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9944), 574728828, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9946) },
                    { 42697200, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9840), 519965336, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9841) },
                    { 42697200, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9957), 729569761, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9958) },
                    { 42697200, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9982), 382300633, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9984) },
                    { 42697200, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9869), 256329815, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9870) },
                    { 42697200, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9882), 869043672, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9883) },
                    { 42697200, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9827), 584194490, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9828) },
                    { 78577000, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(173), 882145578, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(174) },
                    { 78577000, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(198), 571795796, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(199) },
                    { 78577000, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(110), 674816154, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(111) },
                    { 78577000, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(21), 427100908, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(22) },
                    { 78577000, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(97), 365428178, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(98) },
                    { 78577000, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(210), 449500494, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(212) },
                    { 78577000, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(122), 881398948, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(123) },
                    { 78577000, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(135), 524216361, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(136) },
                    { 78577000, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(59), 935663677, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(60) },
                    { 78577000, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(147), 315768753, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(148) },
                    { 78577000, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(46), 473349748, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(47) },
                    { 78577000, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(160), 257627192, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(161) },
                    { 78577000, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(186), 771879536, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(187) },
                    { 78577000, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(71), 952374985, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(73) },
                    { 78577000, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(84), 695542647, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(85) },
                    { 78577000, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(33), 435375376, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(34) },
                    { 82819888, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(786), 400939397, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(787) },
                    { 82819888, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(811), 972141753, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(812) },
                    { 82819888, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(723), 934394230, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(724) },
                    { 82819888, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(635), 888169030, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(636) },
                    { 82819888, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(710), 140509661, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(711) },
                    { 82819888, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(824), 594109576, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(825) },
                    { 82819888, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(736), 224327395, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(737) },
                    { 82819888, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(748), 550933200, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(749) },
                    { 82819888, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(673), 158305149, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(674) },
                    { 82819888, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(761), 700357587, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(762) },
                    { 82819888, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(660), 942423596, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(661) },
                    { 82819888, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(773), 348509432, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(775) },
                    { 82819888, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(798), 449758791, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(799) },
                    { 82819888, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(685), 968234057, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(686) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 82819888, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(698), 409063765, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(699) },
                    { 82819888, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(648), 180130152, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(649) },
                    { 214577552, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1804), 929016320, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1805) },
                    { 214577552, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1830), 943955602, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1831) },
                    { 214577552, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1741), 636219813, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1742) },
                    { 214577552, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1649), 966872372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1650) },
                    { 214577552, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1729), 775990370, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1730) },
                    { 214577552, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1843), 136329171, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1844) },
                    { 214577552, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1753), 268665438, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1755) },
                    { 214577552, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1766), 326748327, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1767) },
                    { 214577552, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1691), 877098338, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1692) },
                    { 214577552, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1779), 431359121, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1780) },
                    { 214577552, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1678), 215702834, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1680) },
                    { 214577552, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1791), 750588274, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1792) },
                    { 214577552, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1817), 235741099, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1818) },
                    { 214577552, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1703), 557520776, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1704) },
                    { 214577552, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1716), 448048642, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1717) },
                    { 214577552, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1662), 412243009, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1663) },
                    { 240582328, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(580), 356823526, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(581) },
                    { 240582328, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(609), 587879456, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(611) },
                    { 240582328, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(517), 357291488, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(518) },
                    { 240582328, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(429), 721533828, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(430) },
                    { 240582328, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(505), 462992905, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(506) },
                    { 240582328, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(622), 470376833, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(623) },
                    { 240582328, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(530), 488606292, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(531) },
                    { 240582328, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(542), 656861375, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(543) },
                    { 240582328, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(467), 433582867, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(468) },
                    { 240582328, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(555), 633415917, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(556) },
                    { 240582328, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(454), 915967321, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(456) },
                    { 240582328, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(567), 717284510, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(568) },
                    { 240582328, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(596), 846024898, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(597) },
                    { 240582328, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(479), 898103690, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(480) },
                    { 240582328, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(492), 320910990, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(493) },
                    { 240582328, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(442), 340610457, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(443) },
                    { 1316815352, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(990), 849232538, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(991) },
                    { 1316815352, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1015), 512837020, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1016) },
                    { 1316815352, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(924), 497502898, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(925) },
                    { 1316815352, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(836), 308091007, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(837) },
                    { 1316815352, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(912), 917073947, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(913) },
                    { 1316815352, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1028), 137472661, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1029) },
                    { 1316815352, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(937), 292920692, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(938) },
                    { 1316815352, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(950), 502566809, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(951) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1316815352, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(875), 913650453, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(876) },
                    { 1316815352, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(962), 998586553, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(963) },
                    { 1316815352, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(861), 205044342, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(863) },
                    { 1316815352, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(975), 792414497, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(976) },
                    { 1316815352, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1003), 195021192, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1004) },
                    { 1316815352, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(887), 539960477, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(888) },
                    { 1316815352, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(899), 480739298, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(900) },
                    { 1316815352, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(849), 621934252, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(850) },
                    { 2006586200, 270680498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1399), 802672392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1400) },
                    { 2006586200, 279336811, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1424), 236315744, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1425) },
                    { 2006586200, 288526387, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1336), 451611107, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1337) },
                    { 2006586200, 355643372, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1243), 255837517, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1244) },
                    { 2006586200, 410969392, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1323), 628769960, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1324) },
                    { 2006586200, 497122066, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1436), 758186460, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1438) },
                    { 2006586200, 503764598, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1348), 691792947, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1349) },
                    { 2006586200, 510400043, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1362), 483165810, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1363) },
                    { 2006586200, 609178691, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1285), 307443337, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1286) },
                    { 2006586200, 800212641, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1374), 779655118, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1375) },
                    { 2006586200, 802373452, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1269), 170695986, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1270) },
                    { 2006586200, 836486281, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1387), 993556618, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1388) },
                    { 2006586200, 879227760, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1412), 795608533, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1413) },
                    { 2006586200, 888094041, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1297), 243479498, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1298) },
                    { 2006586200, 907870427, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1310), 600048985, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1311) },
                    { 2006586200, 946249654, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1256), 834251759, new DateTime(2024, 3, 16, 17, 24, 15, 849, DateTimeKind.Local).AddTicks(1257) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 128680142, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8194), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8191), 82819888, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8193), 507002765 },
                    { 169594488, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7921), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7918), -1378459520, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7919), 559030193 },
                    { 282646252, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8050), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8048), 78577000, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8049), 559030193 },
                    { 288638791, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7964), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7961), -1831516064, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7962), 559030193 },
                    { 338375516, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8092), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8090), -1660529528, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8091), 559030193 },
                    { 374716784, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8377), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8375), 214577552, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8376), 381883916 },
                    { 384377672, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8305), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8303), 2006586200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8304), 559030193 },
                    { 408311341, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8277), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8275), -1703774184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8276), 507002765 },
                    { 415515837, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8263), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8261), -1703774184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8262), 559030193 },
                    { 426298401, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7993), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7991), 42697200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7992), 381883916 },
                    { 433024304, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7935), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7932), -1378459520, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7934), 507002765 },
                    { 435313254, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8166), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8164), 82819888, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8165), 381883916 },
                    { 454296271, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8222), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8219), 1316815352, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8220), 559030193 },
                    { 465453171, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8235), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8233), 1316815352, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8234), 507002765 },
                    { 487041080, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8404), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8402), 214577552, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8403), 507002765 },
                    { 496568399, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7979), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7977), -1831516064, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7978), 507002765 },
                    { 546218483, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8180), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8177), 82819888, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8179), 559030193 },
                    { 599351184, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8021), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8019), 42697200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8020), 507002765 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 603987877, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8152), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8149), 240582328, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8151), 507002765 },
                    { 606969688, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8421), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8418), 1518936840, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8419), 381883916 },
                    { 618204666, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8347), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8345), -257937256, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8346), 559030193 },
                    { 700350530, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7903), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7899), -1378459520, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7901), 381883916 },
                    { 710807546, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8319), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8317), 2006586200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8318), 507002765 },
                    { 721313547, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8361), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8359), -257937256, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8360), 507002765 },
                    { 724231813, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8119), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8116), 240582328, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8118), 381883916 },
                    { 795827105, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8132), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8130), 240582328, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8131), 559030193 },
                    { 797450495, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8105), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8103), -1660529528, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8104), 507002765 },
                    { 814551906, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8450), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8447), 1518936840, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8449), 507002765 },
                    { 823156228, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8078), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8075), -1660529528, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8077), 381883916 },
                    { 853390700, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8249), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8247), -1703774184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8248), 381883916 },
                    { 860441852, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8208), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8206), 1316815352, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8207), 381883916 },
                    { 861825421, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8064), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8061), 78577000, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8062), 507002765 },
                    { 895481079, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7950), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7947), -1831516064, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7948), 381883916 },
                    { 899165814, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8291), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8289), 2006586200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8290), 381883916 },
                    { 946649919, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8391), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8388), 214577552, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8390), 559030193 },
                    { 951758939, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8007), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8005), 42697200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8006), 559030193 },
                    { 984998611, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8333), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8331), -257937256, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8332), 381883916 },
                    { 993283540, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8436), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8434), 1518936840, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8435), 559030193 },
                    { 993383854, new DateTime(2024, 3, 27, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8036), 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8034), 78577000, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8035), 381883916 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 191471205, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7321), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7322), 492551523 },
                    { 458925898, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7162), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7163), 435626679 },
                    { 627970793, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7245), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7246), 600227926 },
                    { 727555347, "alexpl_{i}@gmail.com", new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7065), new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7066), 863225184 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 130323837, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9087), -1703774184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9088), 996509883 },
                    { 142824792, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9036), 1316815352, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9037), 137148909 },
                    { 146536915, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9277), 214577552, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9279), 996509883 },
                    { 181800309, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8541), -1378459520, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8543), 499888698 },
                    { 190036240, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9215), -257937256, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9216), 996509883 },
                    { 191313030, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9302), 214577552, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9303), 411147833 },
                    { 203692961, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9227), -257937256, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9228), 137148909 },
                    { 230508943, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8727), 42697200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8728), 411147833 },
                    { 230898972, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8689), 42697200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8690), 508256876 },
                    { 232927726, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8998), 1316815352, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8999), 499888698 },
                    { 250160432, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9011), 1316815352, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9012), 508256876 },
                    { 277706880, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9290), 214577552, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9291), 137148909 },
                    { 289371664, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8702), 42697200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8703), 996509883 },
                    { 297897771, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9316), 1518936840, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9317), 499888698 },
                    { 302211933, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8833), -1660529528, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8834), 996509883 },
                    { 306122256, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9265), 214577552, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9266), 508256876 },
                    { 310609509, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8858), -1660529528, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8859), 411147833 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 338475424, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8677), 42697200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8678), 499888698 },
                    { 347811567, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8714), 42697200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8715), 137148909 },
                    { 363789276, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8638), -1831516064, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8639), 996509883 },
                    { 388474134, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8921), 240582328, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8922), 411147833 },
                    { 399635393, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9023), 1316815352, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9024), 996509883 },
                    { 406938532, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9137), 2006586200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9138), 508256876 },
                    { 407612253, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8625), -1831516064, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8626), 508256876 },
                    { 443099991, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9357), 1518936840, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9358), 137148909 },
                    { 458895120, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8933), 82819888, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8935), 499888698 },
                    { 466021370, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8560), -1378459520, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8561), 508256876 },
                    { 490405699, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8908), 240582328, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8910), 137148909 },
                    { 490493225, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8985), 82819888, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8986), 411147833 },
                    { 499884198, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9165), 2006586200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9166), 137148909 },
                    { 508483924, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9074), -1703774184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9075), 508256876 },
                    { 518041107, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8896), 240582328, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8897), 996509883 },
                    { 527641498, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8573), -1378459520, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8574), 996509883 },
                    { 536733636, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9240), -257937256, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9241), 411147833 },
                    { 538476025, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9061), -1703774184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9062), 499888698 },
                    { 542329620, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8884), 240582328, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8885), 508256876 },
                    { 570589353, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8664), -1831516064, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8665), 411147833 },
                    { 580484540, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9125), 2006586200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9126), 499888698 },
                    { 580552655, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9149), 2006586200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9150), 996509883 },
                    { 605485931, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8871), 240582328, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8872), 499888698 },
                    { 611979566, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8739), 78577000, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8741), 499888698 },
                    { 617130436, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8820), -1660529528, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8821), 508256876 },
                    { 619784113, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8650), -1831516064, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8652), 137148909 },
                    { 653170905, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8612), -1831516064, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8613), 499888698 },
                    { 659220882, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9190), -257937256, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9191), 499888698 },
                    { 665135104, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8959), 82819888, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8960), 996509883 },
                    { 669124990, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9344), 1518936840, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9346), 996509883 },
                    { 672803331, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8946), 82819888, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8947), 508256876 },
                    { 686799243, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9099), -1703774184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9100), 137148909 },
                    { 705073165, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8752), 78577000, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8753), 508256876 },
                    { 706919616, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8766), 78577000, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8767), 996509883 },
                    { 732274548, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9369), 1518936840, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9370), 411147833 },
                    { 746893325, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9112), -1703774184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9113), 411147833 },
                    { 762970455, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8599), -1378459520, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8600), 411147833 },
                    { 807876717, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8586), -1378459520, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8587), 137148909 },
                    { 818437728, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8804), -1660529528, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8805), 499888698 },
                    { 821859833, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9178), 2006586200, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9179), 411147833 },
                    { 880677764, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8972), 82819888, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8973), 137148909 },
                    { 889230696, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9330), 1518936840, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9332), 508256876 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 901714284, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9253), 214577552, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9254), 499888698 },
                    { 909758402, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9203), -257937256, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9204), 508256876 },
                    { 916530735, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9049), 1316815352, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(9050), 411147833 },
                    { 942277905, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8846), -1660529528, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8847), 137148909 },
                    { 943827325, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8779), 78577000, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8780), 137148909 },
                    { 949766153, 0f, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8791), 78577000, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(8792), 411147833 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 438134464, 435626679, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7174), 549859576, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7175) },
                    { 438134464, 492551523, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7333), 328025988, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7334) },
                    { 438134464, 600227926, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7257), 788232300, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7259) },
                    { 438134464, 863225184, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7078), 752984394, new DateTime(2024, 3, 16, 17, 24, 15, 848, DateTimeKind.Local).AddTicks(7080) }
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
