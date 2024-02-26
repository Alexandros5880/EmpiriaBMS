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
                name: "Drawings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionEstimation = table.Column<float>(type: "real", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionEstimation = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
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
                name: "DailyHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSpanId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyHours_TimeSpans_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "TimeSpans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedCompleted = table.Column<float>(type: "real", nullable: false),
                    Completed = table.Column<float>(type: "real", nullable: false),
                    EngineerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesDraws",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    DrawId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesDraws", x => new { x.DisciplineId, x.DrawId });
                    table.ForeignKey(
                        name: "FK_DisciplinesDraws_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinesDraws_Drawings_DrawId",
                        column: x => x.DrawId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesOthers",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    OtherId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesOthers", x => new { x.DisciplineId, x.OtherId });
                    table.ForeignKey(
                        name: "FK_DisciplinesOthers_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinesOthers_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesPojects",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesPojects", x => new { x.DisciplineId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_DisciplinesPojects_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
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
                    Drawing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedMandays = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedCompleted = table.Column<float>(type: "real", nullable: false),
                    Completed = table.Column<float>(type: "real", nullable: false),
                    WorkPackegedCompleted = table.Column<float>(type: "real", nullable: false),
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
                    ProjectManagerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "ManHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawingId = table.Column<int>(type: "int", nullable: true),
                    OtherId = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManHours_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHours_Drawings_DrawingId",
                        column: x => x.DrawingId,
                        principalTable: "Drawings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHours_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHours_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManHours_Users_UserId",
                        column: x => x.UserId,
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

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 125220500, new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4264), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4265), "Draw_9_0" },
                    { 135922768, new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2986), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2987), "Draw_7_0" },
                    { 137430188, new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5267), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5268), "Draw_10_4" },
                    { 147214168, new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4536), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4537), "Draw_9_3" },
                    { 177187683, new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3076), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3077), "Draw_7_1" },
                    { 182684857, new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(689), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(690), "Draw_3_3" },
                    { 188728213, new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9298), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9299), "Draw_1_2" },
                    { 196465576, new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4996), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4997), "Draw_10_1" },
                    { 203068023, new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(600), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(601), "Draw_3_2" },
                    { 204139108, new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3806), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3808), "Draw_8_2" },
                    { 207880998, new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(507), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(508), "Draw_3_1" },
                    { 221347219, new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9570), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9571), "Draw_1_5" },
                    { 237420820, new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4074), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4076), "Draw_8_5" },
                    { 251880728, new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2798), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2799), "Draw_6_5" },
                    { 318658687, new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(778), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(780), "Draw_3_4" },
                    { 359127311, new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3345), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3346), "Draw_7_4" },
                    { 387254420, new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3896), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3898), "Draw_8_3" },
                    { 402541393, new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4354), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4355), "Draw_9_1" },
                    { 405971828, new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4905), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4906), "Draw_10_0" },
                    { 412003390, new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1420), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1421), "Draw_4_4" },
                    { 433744899, new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(416), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(417), "Draw_3_0" },
                    { 447308040, new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1883), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1884), "Draw_5_2" },
                    { 457620838, new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9953), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9954), "Draw_2_2" },
                    { 495047332, new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1329), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1330), "Draw_4_3" },
                    { 513281233, new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2523), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2524), "Draw_6_2" },
                    { 525873031, new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1790), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1791), "Draw_5_1" },
                    { 526046679, new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9100), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9101), "Draw_1_0" },
                    { 542340938, new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2062), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2063), "Draw_5_4" },
                    { 567559800, new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1972), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1973), "Draw_5_3" },
                    { 582176356, new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1147), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1148), "Draw_4_1" },
                    { 585727298, new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2151), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2152), "Draw_5_5" },
                    { 600575123, new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1700), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1701), "Draw_5_0" },
                    { 608881719, new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1057), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1058), "Draw_4_0" },
                    { 622104915, new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5085), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5086), "Draw_10_2" },
                    { 634186050, new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9771), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9772), "Draw_2_0" },
                    { 682141004, new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2709), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2710), "Draw_6_4" },
                    { 682302355, new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5356), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5357), "Draw_10_5" },
                    { 690767936, new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3164), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3165), "Draw_7_2" },
                    { 720383637, new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4446), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4447), "Draw_9_2" },
                    { 732737403, new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(869), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(870), "Draw_3_5" },
                    { 751170213, new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9479), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9480), "Draw_1_4" },
                    { 754044301, new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(44), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(45), "Draw_2_3" }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 758249654, new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9862), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9863), "Draw_2_1" },
                    { 764685381, new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4714), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4715), "Draw_9_5" },
                    { 770657524, new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4625), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4626), "Draw_9_4" },
                    { 781590196, new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2433), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2434), "Draw_6_1" },
                    { 789071088, new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3257), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3258), "Draw_7_3" },
                    { 790267382, new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(133), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(134), "Draw_2_4" },
                    { 793640125, new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9203), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9204), "Draw_1_1" },
                    { 800297736, new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3714), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3716), "Draw_8_1" },
                    { 804708702, new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2343), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2344), "Draw_6_0" },
                    { 810540455, new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9389), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9390), "Draw_1_3" },
                    { 814971713, new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3985), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3986), "Draw_8_4" },
                    { 818430760, new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3434), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3435), "Draw_7_5" },
                    { 821657534, new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2619), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2620), "Draw_6_3" },
                    { 903079188, new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1236), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1238), "Draw_4_2" },
                    { 913228353, new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1510), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1511), "Draw_4_5" },
                    { 928695003, new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5178), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5179), "Draw_10_3" },
                    { 933579832, new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3622), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3623), "Draw_8_0" },
                    { 956069010, new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(227), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(228), "Draw_2_5" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -1653384500, 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8472), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8473), "Printing" },
                    { -690325840, 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8450), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8452), "Communications" },
                    { -53035071, 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8487), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8488), "On-Site" },
                    { 1371831793, 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8501), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8502), "Meetings" },
                    { 2093238865, 0f, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8515), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8517), "Administration" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 371265866, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8015), true, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8016), "Designer" },
                    { 485477883, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8038), true, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8039), "COO" },
                    { 789512258, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8023), true, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8024), "Engineer" },
                    { 827879427, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8052), true, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8053), "CEO" },
                    { 838722852, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8071), false, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8072), "Customer" },
                    { 856205846, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8045), true, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8046), "CTO" },
                    { 858366205, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8064), false, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8065), "Guest" },
                    { 933884826, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8030), true, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8031), "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8297), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8298), null, "6949277781", null, null, null },
                    { 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8215), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8217), null, "6949277780", null, null, null },
                    { 316137886, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2887), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2888), null, "6949277789", null, null, null },
                    { 328613225, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2241), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2242), null, "6949277788", null, null, null },
                    { 445665580, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(962), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(963), null, "6949277786", null, null, null },
                    { 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8327), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8328), null, "6949277782", null, null, null },
                    { 515261593, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5448), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5449), null, "6949277783", null, null, null },
                    { 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8416), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8417), null, "6949277785", null, null, null },
                    { 547175720, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6337), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6338), null, "6949277784", null, null, null },
                    { 599407131, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4803), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4805), null, "69492777812", null, null, null },
                    { 611406163, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8950), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8951), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 643404233, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1603), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1604), null, "6949277787", null, null, null },
                    { 807031032, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(317), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(318), null, "6949277785", null, null, null },
                    { 847497821, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3523), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3524), null, "69492777810", null, null, null },
                    { 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8385), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8386), null, "6949277784", null, null, null },
                    { 925130494, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4167), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4168), null, "69492777811", null, null, null },
                    { 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8356), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8357), null, "6949277783", null, null, null },
                    { 973891434, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9665), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9666), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedCompleted", "EstimatedHours", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -980988440, 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6367), 547175720, 0f, 1500L, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6368), "HVAC" },
                    { 1066154936, 0f, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5481), 515261593, 0f, 1500L, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5482), "ELEC" }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 125220500, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4291), 1588227012, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4292) },
                    { 125220500, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4279), 5172193, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4280) },
                    { 125220500, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4304), 1673275451, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4305) },
                    { 125220500, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4341), 1451539076, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4342) },
                    { 125220500, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4329), 1816177707, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4330) },
                    { 125220500, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4316), 2080569213, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4317) },
                    { 135922768, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3013), -780337129, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3014) },
                    { 135922768, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3000), 304698263, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3001) },
                    { 135922768, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3025), -1292894999, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3027) },
                    { 135922768, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3063), 743626697, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3064) },
                    { 135922768, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3051), 1472735714, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3052) },
                    { 135922768, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3038), -1735265182, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3039) },
                    { 137430188, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5293), -847012288, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5294) },
                    { 137430188, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5281), 1733273906, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5282) },
                    { 137430188, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5306), 1998869166, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5307) },
                    { 137430188, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5343), -1661207399, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5344) },
                    { 137430188, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5331), 2023071701, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5332) },
                    { 137430188, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5318), -1995727751, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5319) },
                    { 147214168, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4562), -387618727, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4564) },
                    { 147214168, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4550), -938928176, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4551) },
                    { 147214168, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4575), -989711009, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4576) },
                    { 147214168, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4612), -1746084235, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4614) },
                    { 147214168, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4600), -46219918, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4601) },
                    { 147214168, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4587), 1727389062, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4588) },
                    { 177187683, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3102), -2007181583, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3103) },
                    { 177187683, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3089), -1610204930, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3090) },
                    { 177187683, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3114), 1384885746, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3115) },
                    { 177187683, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3152), 45988556, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3153) },
                    { 177187683, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3139), 730916222, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3140) },
                    { 177187683, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3127), -72658844, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3128) },
                    { 182684857, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(716), -1178128124, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(717) },
                    { 182684857, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(703), -745995599, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(704) },
                    { 182684857, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(728), -788104322, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(730) },
                    { 182684857, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(766), 30818242, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(767) },
                    { 182684857, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(754), 613328198, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(755) },
                    { 182684857, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(741), 700893806, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(742) },
                    { 188728213, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9325), 1985039942, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9326) },
                    { 188728213, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9312), 379676161, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9313) },
                    { 188728213, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9337), 714917039, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9338) },
                    { 188728213, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9376), 1579294751, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9377) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 188728213, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9363), 1590389523, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9364) },
                    { 188728213, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9350), -1967270440, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9351) },
                    { 196465576, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5023), 1871205786, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5024) },
                    { 196465576, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5010), -1802197300, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5011) },
                    { 196465576, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5035), 1115144172, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5036) },
                    { 196465576, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5072), 1792096178, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5073) },
                    { 196465576, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5060), 1194793772, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5061) },
                    { 196465576, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5048), 1763640842, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5049) },
                    { 203068023, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(626), 21054574, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(628) },
                    { 203068023, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(614), 61511248, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(615) },
                    { 203068023, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(639), 1930801379, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(640) },
                    { 203068023, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(676), -1420433009, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(678) },
                    { 203068023, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(664), -1856406140, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(665) },
                    { 203068023, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(651), -654876611, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(652) },
                    { 204139108, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3833), 1669515017, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3834) },
                    { 204139108, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3820), 1588924913, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3821) },
                    { 204139108, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3846), 1150482650, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3847) },
                    { 204139108, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3884), -404705263, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3885) },
                    { 204139108, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3871), -1917426833, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3872) },
                    { 204139108, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3858), -1327772704, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3860) },
                    { 207880998, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(533), -2146960183, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(535) },
                    { 207880998, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(521), -2021569735, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(522) },
                    { 207880998, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(546), 497634827, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(547) },
                    { 207880998, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(587), -2035793524, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(588) },
                    { 207880998, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(574), -1830534974, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(575) },
                    { 207880998, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(561), -1711592828, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(562) },
                    { 221347219, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9600), 1562900733, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9602) },
                    { 221347219, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9583), -921345632, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9585) },
                    { 221347219, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9613), 325311584, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9614) },
                    { 221347219, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9652), 1671515906, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9653) },
                    { 221347219, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9640), -356349149, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9641) },
                    { 221347219, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9627), 1762833191, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9628) },
                    { 237420820, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4101), 302813195, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4102) },
                    { 237420820, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4088), 957934256, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4089) },
                    { 237420820, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4113), -1656127394, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4114) },
                    { 237420820, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4154), 1528808067, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4155) },
                    { 237420820, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4141), -2092507015, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4142) },
                    { 237420820, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4126), 1933969734, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4127) },
                    { 251880728, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2824), -1125632614, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2825) },
                    { 251880728, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2812), -2032895281, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2813) },
                    { 251880728, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2837), 1660694684, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2838) },
                    { 251880728, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2874), 1783787616, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2876) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 251880728, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2862), -248440202, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2863) },
                    { 251880728, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2849), 225885650, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2850) },
                    { 318658687, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(806), 1333661801, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(808) },
                    { 318658687, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(794), 1068594224, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(795) },
                    { 318658687, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(819), -1168326517, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(820) },
                    { 318658687, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(856), 103981249, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(857) },
                    { 318658687, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(844), 185496845, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(845) },
                    { 318658687, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(831), -2012526620, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(832) },
                    { 359127311, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3372), 1832878985, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3373) },
                    { 359127311, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3359), -442971985, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3360) },
                    { 359127311, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3384), -1946283866, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3385) },
                    { 359127311, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3421), -2018606404, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3422) },
                    { 359127311, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3409), -932077772, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3410) },
                    { 359127311, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3396), -1886773657, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3397) },
                    { 387254420, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3923), -1949800666, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3924) },
                    { 387254420, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3910), 1638077427, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3911) },
                    { 387254420, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3935), -303169706, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3937) },
                    { 387254420, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3973), 713139035, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3974) },
                    { 387254420, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3960), 938102639, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3961) },
                    { 387254420, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3948), 1607224361, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3949) },
                    { 402541393, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4380), -578781688, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4381) },
                    { 402541393, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4367), -1588110803, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4369) },
                    { 402541393, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4392), -424200550, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4393) },
                    { 402541393, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4430), -790302158, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4431) },
                    { 402541393, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4418), -1706956334, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4419) },
                    { 402541393, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4405), 179768818, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4406) },
                    { 405971828, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4933), 1127912027, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4934) },
                    { 405971828, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4920), 954159926, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4921) },
                    { 405971828, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4946), -251449366, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4947) },
                    { 405971828, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4983), 478876433, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4985) },
                    { 405971828, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4971), 64073818, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4972) },
                    { 405971828, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4959), -1807536820, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4960) },
                    { 412003390, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1446), 724645508, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1447) },
                    { 412003390, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1434), 1510364124, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1435) },
                    { 412003390, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1459), 1001536988, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1460) },
                    { 412003390, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1497), -973646648, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1498) },
                    { 412003390, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1484), -2012079410, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1485) },
                    { 412003390, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1472), -598744399, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1473) },
                    { 433744899, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(444), 982548626, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(445) },
                    { 433744899, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(431), 105942542, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(432) },
                    { 433744899, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(457), -56826265, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(458) },
                    { 433744899, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(494), -1785522370, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(496) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 433744899, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(482), -1014759697, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(483) },
                    { 433744899, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(469), 1894618877, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(471) },
                    { 447308040, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1909), 825153953, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1910) },
                    { 447308040, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1897), -207929573, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1898) },
                    { 447308040, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1921), -434140775, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1923) },
                    { 447308040, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1960), 2133977765, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1961) },
                    { 447308040, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1947), 1398315434, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1948) },
                    { 447308040, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1934), 1086056888, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1935) },
                    { 457620838, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9981), -1587219394, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9982) },
                    { 457620838, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9969), -980361530, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9970) },
                    { 457620838, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9994), -1993074205, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9995) },
                    { 457620838, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(32), -771851803, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(33) },
                    { 457620838, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(19), -307102423, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(20) },
                    { 457620838, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6), -1569277196, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7) },
                    { 495047332, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1355), -1953865111, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1356) },
                    { 495047332, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1343), 2091533765, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1344) },
                    { 495047332, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1368), -1446929504, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1369) },
                    { 495047332, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1407), -717963938, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1408) },
                    { 495047332, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1395), -1227219290, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1396) },
                    { 495047332, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1382), -885452980, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1383) },
                    { 513281233, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2555), 1509015560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2556) },
                    { 513281233, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2542), 2034519890, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2543) },
                    { 513281233, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2568), 1589963639, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2569) },
                    { 513281233, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2607), -1712680402, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2608) },
                    { 513281233, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2594), -1236211298, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2595) },
                    { 513281233, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2581), -1870537639, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2582) },
                    { 525873031, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1817), -1976296135, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1818) },
                    { 525873031, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1804), -346021550, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1805) },
                    { 525873031, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1829), 178686707, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1830) },
                    { 525873031, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1870), 1887665126, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1871) },
                    { 525873031, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1854), -1687183226, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1856) },
                    { 525873031, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1842), 953550887, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1843) },
                    { 526046679, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9137), -766314454, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9138) },
                    { 526046679, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9120), -1991065922, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9121) },
                    { 526046679, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9150), -970300106, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9151) },
                    { 526046679, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9189), -1670821307, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9191) },
                    { 526046679, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9176), -1386219622, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9177) },
                    { 526046679, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9162), 1535691983, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9164) },
                    { 542340938, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2088), 735543635, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2089) },
                    { 542340938, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2076), -1236731012, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2077) },
                    { 542340938, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2101), 1853036397, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2102) },
                    { 542340938, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2138), -816999281, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2139) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 542340938, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2126), -526225598, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2127) },
                    { 542340938, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2113), 192431458, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2114) },
                    { 567559800, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1999), 1345799457, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2000) },
                    { 567559800, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1986), 577294313, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1987) },
                    { 567559800, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2011), -491744312, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2012) },
                    { 567559800, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2050), -700267189, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2051) },
                    { 567559800, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2036), -134662351, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2038) },
                    { 567559800, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2024), -1137372929, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2025) },
                    { 582176356, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1173), -755979353, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1174) },
                    { 582176356, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1161), 855193010, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1162) },
                    { 582176356, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1186), -1554588508, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1187) },
                    { 582176356, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1224), -1190344346, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1225) },
                    { 582176356, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1211), -1685401132, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1212) },
                    { 582176356, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1198), 1857761348, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1199) },
                    { 585727298, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2178), 1074323696, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2179) },
                    { 585727298, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2165), 1781480993, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2166) },
                    { 585727298, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2190), -1015871678, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2191) },
                    { 585727298, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2228), 345178409, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2229) },
                    { 585727298, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2215), -1601266922, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2216) },
                    { 585727298, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2203), 1283740191, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2204) },
                    { 600575123, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1727), -1429794823, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1728) },
                    { 600575123, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1714), 1780138917, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1715) },
                    { 600575123, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1739), 1192787267, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1740) },
                    { 600575123, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1777), 1461084782, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1779) },
                    { 600575123, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1764), 1656676553, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1765) },
                    { 600575123, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1752), 782607731, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1753) },
                    { 608881719, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1084), -435938881, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1085) },
                    { 608881719, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1071), -1653758032, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1072) },
                    { 608881719, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1097), -520292033, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1098) },
                    { 608881719, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1134), -1195148915, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1135) },
                    { 608881719, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1122), -1427350522, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1123) },
                    { 608881719, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1109), -508420327, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1110) },
                    { 622104915, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5111), -1015966552, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5112) },
                    { 622104915, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5099), -971943988, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5100) },
                    { 622104915, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5124), 1276092572, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5125) },
                    { 622104915, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5165), 1173287588, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5166) },
                    { 622104915, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5152), 1575541665, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5153) },
                    { 622104915, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5136), -144919138, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5137) },
                    { 634186050, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9799), -1567081772, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9800) },
                    { 634186050, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9785), 287772818, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9786) },
                    { 634186050, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9811), -729983308, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9813) },
                    { 634186050, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9849), -437627290, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9850) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 634186050, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9837), -842322311, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9838) },
                    { 634186050, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9824), 1454024417, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9825) },
                    { 682141004, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2735), 71045591, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2736) },
                    { 682141004, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2722), -110326706, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2723) },
                    { 682141004, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2747), -500769188, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2748) },
                    { 682141004, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2785), -1361886943, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2786) },
                    { 682141004, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2772), -967034020, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2774) },
                    { 682141004, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2760), -1999922372, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2761) },
                    { 682302355, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5382), -1681428725, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5383) },
                    { 682302355, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5370), 1741954649, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5371) },
                    { 682302355, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5395), 1219413776, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5396) },
                    { 682302355, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5433), 468070340, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5434) },
                    { 682302355, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5420), 1649217524, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5421) },
                    { 682302355, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5408), -1367477077, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5409) },
                    { 690767936, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3190), 1092169949, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3192) },
                    { 690767936, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3178), 1152048654, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3179) },
                    { 690767936, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3203), 1097262131, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3204) },
                    { 690767936, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3244), -1949108008, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3245) },
                    { 690767936, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3228), -595547612, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3229) },
                    { 690767936, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3216), 1833133244, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3217) },
                    { 720383637, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4472), 797455418, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4474) },
                    { 720383637, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4460), 490543871, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4461) },
                    { 720383637, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4485), 1356915879, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4486) },
                    { 720383637, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4523), 624985583, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4524) },
                    { 720383637, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4510), -1622185694, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4512) },
                    { 720383637, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4498), 684648950, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4499) },
                    { 732737403, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(895), 502371329, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(896) },
                    { 732737403, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(882), 176794457, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(884) },
                    { 732737403, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(908), -1157542258, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(909) },
                    { 732737403, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(949), 1521129636, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(950) },
                    { 732737403, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(936), -1826334782, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(938) },
                    { 732737403, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(924), 1606593515, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(925) },
                    { 751170213, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9506), -702985792, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9508) },
                    { 751170213, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9494), 67021183, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9495) },
                    { 751170213, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9519), 758103962, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9520) },
                    { 751170213, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9557), -2123950720, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9558) },
                    { 751170213, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9544), 1727160584, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9545) },
                    { 751170213, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9532), 1966745993, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9533) },
                    { 754044301, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(71), -932274346, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(72) },
                    { 754044301, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(58), -1297965343, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(59) },
                    { 754044301, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(83), -1810408729, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(84) },
                    { 754044301, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(121), 956954291, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(122) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 754044301, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(108), -1809453226, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(109) },
                    { 754044301, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(95), -1058767433, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(97) },
                    { 758249654, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9888), -168332498, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9889) },
                    { 758249654, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9875), -1073790994, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9876) },
                    { 758249654, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9903), -1821416561, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9904) },
                    { 758249654, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9941), -1420381048, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9942) },
                    { 758249654, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9928), -848959208, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9929) },
                    { 758249654, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9916), 1699972088, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9917) },
                    { 764685381, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4741), -841867577, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4742) },
                    { 764685381, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4728), 1224267998, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4729) },
                    { 764685381, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4753), -779423287, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4755) },
                    { 764685381, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4791), 2123017484, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4792) },
                    { 764685381, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4778), -495665009, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4779) },
                    { 764685381, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4766), -434381417, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4767) },
                    { 770657524, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4652), -353066606, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4653) },
                    { 770657524, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4639), -1880509994, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4640) },
                    { 770657524, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4664), -1463976215, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4665) },
                    { 770657524, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4702), -1999572866, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4703) },
                    { 770657524, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4689), 448053368, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4690) },
                    { 770657524, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4677), 440786444, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4678) },
                    { 781590196, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2460), -1934764150, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2461) },
                    { 781590196, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2447), 1338072449, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2448) },
                    { 781590196, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2472), 1279746842, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2474) },
                    { 781590196, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2510), 30129409, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2511) },
                    { 781590196, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2498), -721053625, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2499) },
                    { 781590196, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2485), -777379355, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2486) },
                    { 789071088, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3283), 1218267450, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3284) },
                    { 789071088, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3271), -1470101705, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3272) },
                    { 789071088, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3295), -1315961059, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3296) },
                    { 789071088, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3333), -2120426216, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3334) },
                    { 789071088, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3320), -1587936329, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3322) },
                    { 789071088, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3308), -1927408342, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3309) },
                    { 790267382, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(160), 1221909809, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(161) },
                    { 790267382, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(147), -956123540, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(148) },
                    { 790267382, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(172), 1653071729, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(173) },
                    { 790267382, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(211), 2005186154, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(212) },
                    { 790267382, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(197), -499510052, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(198) },
                    { 790267382, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(185), 1202995719, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(186) },
                    { 793640125, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9233), -1609608307, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9234) },
                    { 793640125, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9218), -1244389760, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9219) },
                    { 793640125, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9246), 1596302397, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9247) },
                    { 793640125, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9285), -1810389725, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9286) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 793640125, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9273), -458377235, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9274) },
                    { 793640125, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9260), 1095698759, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9261) },
                    { 800297736, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3741), -532741405, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3742) },
                    { 800297736, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3728), 1895178965, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3729) },
                    { 800297736, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3756), -1544896354, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3757) },
                    { 800297736, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3794), 1288832342, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3795) },
                    { 800297736, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3781), -826794206, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3783) },
                    { 800297736, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3769), 2097875597, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3770) },
                    { 804708702, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2371), -1807727030, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2372) },
                    { 804708702, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2358), -1753182931, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2359) },
                    { 804708702, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2383), -982459205, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2384) },
                    { 804708702, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2421), -250855240, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2422) },
                    { 804708702, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2408), -2063759062, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2409) },
                    { 804708702, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2396), 1504444460, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2397) },
                    { 810540455, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9416), -1687883143, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9417) },
                    { 810540455, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9403), -168741886, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9404) },
                    { 810540455, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9428), 1180722308, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9429) },
                    { 810540455, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9466), -1316497531, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9467) },
                    { 810540455, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9453), 2130599133, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9454) },
                    { 810540455, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9441), 1786301082, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9442) },
                    { 814971713, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4012), -1647837557, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4013) },
                    { 814971713, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3999), 1800163710, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4000) },
                    { 814971713, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4024), 1184738688, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4025) },
                    { 814971713, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4062), -906135146, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4063) },
                    { 814971713, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4050), 1714756365, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4051) },
                    { 814971713, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4037), 1508924147, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4038) },
                    { 818430760, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3460), 199388026, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3461) },
                    { 818430760, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3447), -1697658497, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3448) },
                    { 818430760, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3472), -1102636075, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3473) },
                    { 818430760, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3510), -2045536325, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3511) },
                    { 818430760, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3497), -2000847815, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3498) },
                    { 818430760, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3485), 1523461257, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3486) },
                    { 821657534, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2646), -1701217849, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2647) },
                    { 821657534, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2633), 1828738301, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2634) },
                    { 821657534, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2658), -1212538243, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2659) },
                    { 821657534, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2696), -730786675, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2697) },
                    { 821657534, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2683), -656337037, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2684) },
                    { 821657534, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2670), 797441792, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2672) },
                    { 903079188, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1265), -903933328, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1266) },
                    { 903079188, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1253), -1759531085, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1254) },
                    { 903079188, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1278), 2076141074, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1279) },
                    { 903079188, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1316), -1465373708, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1317) }
                });

            migrationBuilder.InsertData(
                table: "DrawingsEmployees",
                columns: new[] { "DrawingId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 903079188, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1303), -492553615, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1304) },
                    { 903079188, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1291), -51050195, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1292) },
                    { 913228353, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1536), -272334361, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1537) },
                    { 913228353, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1524), 196971341, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1525) },
                    { 913228353, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1552), -1713677858, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1553) },
                    { 913228353, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1590), 2049893460, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1591) },
                    { 913228353, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1577), 1658032200, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1578) },
                    { 913228353, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1565), -561400888, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1566) },
                    { 928695003, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5204), 1946660216, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5205) },
                    { 928695003, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5191), 1922938520, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5192) },
                    { 928695003, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5216), 1741571456, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5218) },
                    { 928695003, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5254), -455725907, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5256) },
                    { 928695003, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5242), -109677577, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5243) },
                    { 928695003, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5229), 2058983028, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5230) },
                    { 933579832, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3649), -1404843664, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3650) },
                    { 933579832, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3636), 465107279, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3637) },
                    { 933579832, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3662), 1945010588, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3663) },
                    { 933579832, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3701), 332040259, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3703) },
                    { 933579832, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3687), 79363913, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3688) },
                    { 933579832, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3674), 132542308, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3675) },
                    { 956069010, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(254), 1950617619, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(255) },
                    { 956069010, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(241), 1657210127, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(242) },
                    { 956069010, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(266), -1897017776, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(268) },
                    { 956069010, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(304), -632695243, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(305) },
                    { 956069010, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(291), -132100195, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(292) },
                    { 956069010, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(279), 1305725526, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(280) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 204501724, -1653384500, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8625), -1820694334, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8626) },
                    { 254050538, -1653384500, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8551), -53921434, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8553) },
                    { 480367780, -1653384500, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8692), -1487606948, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8693) },
                    { 522967658, -1653384500, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8891), -2029082930, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8893) },
                    { 908427068, -1653384500, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8823), 1198894631, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8824) },
                    { 934328560, -1653384500, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8757), 551049575, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8758) },
                    { 204501724, -690325840, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8611), 2020460130, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8613) },
                    { 254050538, -690325840, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8533), -620507488, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8535) },
                    { 480367780, -690325840, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8679), -1778304671, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8680) },
                    { 522967658, -690325840, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8878), -1803142115, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8880) },
                    { 908427068, -690325840, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8810), -594513409, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8811) },
                    { 934328560, -690325840, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8744), -1683850625, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8745) },
                    { 204501724, -53035071, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8638), 2066721255, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8639) },
                    { 254050538, -53035071, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8567), -1828814746, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8568) },
                    { 480367780, -53035071, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8704), 157004326, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8705) },
                    { 522967658, -53035071, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8904), 1292948280, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8906) }
                });

            migrationBuilder.InsertData(
                table: "OthersEmployees",
                columns: new[] { "EmployeeId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 908427068, -53035071, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8839), -5469515, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8840) },
                    { 934328560, -53035071, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8770), -1707087842, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8772) },
                    { 204501724, 1371831793, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8651), -489687254, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8652) },
                    { 254050538, 1371831793, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8581), 1625536085, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8583) },
                    { 480367780, 1371831793, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8717), -1714529506, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8718) },
                    { 522967658, 1371831793, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8917), 621946499, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8918) },
                    { 908427068, 1371831793, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8852), -1378269953, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8853) },
                    { 934328560, 1371831793, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8783), 1469301552, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8784) },
                    { 204501724, 2093238865, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8665), 809042963, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8666) },
                    { 254050538, 2093238865, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8596), 2056011462, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8597) },
                    { 480367780, 2093238865, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8731), -1370326423, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8732) },
                    { 522967658, 2093238865, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8931), -814552433, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8932) },
                    { 908427068, 2093238865, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8865), -646463587, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8866) },
                    { 934328560, 2093238865, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8797), -1346607368, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8798) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 192038727, "ALPHA", 1, "D-22-168", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 13.0, 64, new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 64, "Test Description Project_32", "KL-8", new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_8", 5.0, new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_48", 8.0, 847497821, new DateTime(2029, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f },
                    { 200953521, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 6.0, 1, new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 1, "Test Description Project_2", "KL-1", new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_1", 5.0, new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_2", 1.0, 611406163, new DateTime(2024, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f },
                    { 211141271, "ALPHA", 1, "D-22-1610", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 15.0, 100, new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 100, "Test Description Project_60", "KL-10", new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_10", 5.0, new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_40", 10.0, 599407131, new DateTime(2032, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f },
                    { 410119294, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 9.0, 16, new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 16, "Test Description Project_12", "KL-4", new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_4", 5.0, new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_8", 4.0, 445665580, new DateTime(2025, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f },
                    { 653111909, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 7.0, 4, new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 4, "Test Description Project_2", "KL-2", new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_2", 5.0, new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_4", 2.0, 973891434, new DateTime(2024, 6, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f },
                    { 719250456, "NBG_IBANK", 1, "D-22-165", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 10.0, 25, new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 25, "Test Description Project_20", "KL-5", new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_5", 5.0, new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_25", 5.0, 643404233, new DateTime(2026, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f },
                    { 746650628, "NBG_IBANK", 1, "D-22-169", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 14.0, 81, new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 81, "Test Description Project_27", "KL-9", new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_9", 5.0, new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_18", 9.0, 925130494, new DateTime(2030, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f },
                    { 840770531, "ALPHA", 1, "D-22-166", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 11.0, 36, new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 36, "Test Description Project_12", "KL-6", new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_6", 5.0, new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_6", 6.0, 328613225, new DateTime(2027, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f },
                    { 928699674, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 8.0, 9, new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 9, "Test Description Project_18", "KL-3", new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_3", 5.0, new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_15", 3.0, 807031032, new DateTime(2024, 11, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f },
                    { 999387938, "NBG_IBANK", 1, "D-22-167", 0f, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 12.0, 49, new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 49, "Test Description Project_35", "KL-7", new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f, 100L, 12L, new DateTime(2024, 2, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Project_7", 5.0, new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), "Payment Detailes For Project_21", 7.0, 316137886, new DateTime(2028, 3, 26, 18, 10, 21, 151, DateTimeKind.Local).AddTicks(3526), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 371265866, 204501724, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8313), 520360249, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8314) },
                    { 371265866, 254050538, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8275), 925832168, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8276) },
                    { 933884826, 316137886, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2906), 370554610, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2907) },
                    { 933884826, 328613225, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2262), 581964766, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2263) },
                    { 933884826, 445665580, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(978), 606581892, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(979) },
                    { 371265866, 480367780, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8343), 343200531, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8344) },
                    { 789512258, 515261593, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5466), 472286069, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5467) },
                    { 371265866, 522967658, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8432), 815749758, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8433) },
                    { 789512258, 547175720, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6353), 446132031, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6354) },
                    { 933884826, 599407131, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4823), 895493968, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4824) },
                    { 933884826, 611406163, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8971), 476383566, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8972) },
                    { 933884826, 643404233, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1618), 410992012, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1619) },
                    { 933884826, 807031032, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(333), 275697034, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(334) },
                    { 933884826, 847497821, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3539), 850629541, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3540) },
                    { 371265866, 908427068, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8402), 555729419, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8403) },
                    { 933884826, 925130494, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4182), 992857558, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4183) },
                    { 371265866, 934328560, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8372), 628211469, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(8373) },
                    { 933884826, 973891434, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9682), 249477146, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9683) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -980988440, 125220500, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7048), 715597684, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7049) },
                    { -980988440, 135922768, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6896), 595204276, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6897) },
                    { -980988440, 137430188, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7173), 767498698, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7174) },
                    { -980988440, 147214168, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7086), 364357172, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7087) },
                    { -980988440, 177187683, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6908), 771400140, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6909) },
                    { -980988440, 182684857, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6635), 659373647, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6636) },
                    { -980988440, 188728213, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6469), 980949413, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6470) },
                    { -980988440, 196465576, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7135), 144494228, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7136) },
                    { -980988440, 203068023, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6623), 434602124, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6624) },
                    { -980988440, 204139108, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6999), 343334641, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7000) },
                    { -980988440, 207880998, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6610), 452527068, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6611) },
                    { -980988440, 221347219, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6507), 238621089, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6508) },
                    { -980988440, 237420820, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7036), 912252288, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7037) },
                    { -980988440, 251880728, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6884), 434138488, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6885) },
                    { -980988440, 318658687, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6648), 899820542, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6649) },
                    { -980988440, 359127311, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6945), 975951072, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6947) },
                    { -980988440, 387254420, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7011), 985068613, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7012) },
                    { -980988440, 402541393, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7061), 605731363, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7062) },
                    { -980988440, 405971828, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7123), 429820860, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7124) },
                    { -980988440, 412003390, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6723), 771037216, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6724) },
                    { -980988440, 433744899, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6598), 936331366, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6599) },
                    { -980988440, 447308040, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6772), 612991849, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6773) },
                    { -980988440, 457620838, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6545), 505303687, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6546) },
                    { -980988440, 495047332, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6710), 758183328, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6711) },
                    { -980988440, 513281233, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6846), 514114452, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6847) },
                    { -980988440, 525873031, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6760), 582939281, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6761) },
                    { -980988440, 526046679, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6443), 357377098, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6444) },
                    { -980988440, 542340938, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6797), 191698142, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6798) },
                    { -980988440, 567559800, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6785), 723630572, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6786) },
                    { -980988440, 582176356, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6685), 765331409, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6686) },
                    { -980988440, 585727298, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6809), 752663874, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6810) },
                    { -980988440, 600575123, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6747), 371874404, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6748) },
                    { -980988440, 608881719, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6673), 267560784, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6674) },
                    { -980988440, 622104915, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7148), 238246154, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7149) },
                    { -980988440, 634186050, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6520), 171817004, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6521) },
                    { -980988440, 682141004, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6871), 824426992, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6872) },
                    { -980988440, 682302355, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7185), 217959133, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7186) },
                    { -980988440, 690767936, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6921), 867954246, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6922) },
                    { -980988440, 720383637, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7073), 826137296, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7075) },
                    { -980988440, 732737403, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6660), 759491510, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6662) },
                    { -980988440, 751170213, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6493), 590335834, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6495) },
                    { -980988440, 754044301, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6557), 524191629, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6558) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -980988440, 758249654, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6532), 262936389, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6533) },
                    { -980988440, 764685381, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7111), 600844404, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7112) },
                    { -980988440, 770657524, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7098), 672334532, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7099) },
                    { -980988440, 781590196, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6834), 970267423, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6835) },
                    { -980988440, 789071088, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6933), 439284301, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6934) },
                    { -980988440, 790267382, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6572), 651089127, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6574) },
                    { -980988440, 793640125, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6456), 553472514, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6457) },
                    { -980988440, 800297736, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6986), 819591994, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6987) },
                    { -980988440, 804708702, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6822), 683857457, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6823) },
                    { -980988440, 810540455, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6481), 545340303, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6482) },
                    { -980988440, 814971713, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7023), 751750421, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7025) },
                    { -980988440, 818430760, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6961), 264766715, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6962) },
                    { -980988440, 821657534, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6859), 231573968, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6860) },
                    { -980988440, 903079188, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6698), 994643307, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6699) },
                    { -980988440, 913228353, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6735), 806145683, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6736) },
                    { -980988440, 928695003, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7160), 510747643, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7161) },
                    { -980988440, 933579832, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6974), 296813191, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6975) },
                    { -980988440, 956069010, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6585), 280856335, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6586) },
                    { 1066154936, 125220500, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6184), 327102107, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6185) },
                    { 1066154936, 135922768, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6037), 270777350, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6038) },
                    { 1066154936, 137430188, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6312), 467967197, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6314) },
                    { 1066154936, 147214168, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6221), 539062214, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6222) },
                    { 1066154936, 177187683, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6049), 326820136, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6050) },
                    { 1066154936, 182684857, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5771), 203673936, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5772) },
                    { 1066154936, 188728213, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5608), 474577501, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5609) },
                    { 1066154936, 196465576, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6276), 878621487, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6277) },
                    { 1066154936, 203068023, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5759), 575429027, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5760) },
                    { 1066154936, 204139108, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6135), 537880120, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6136) },
                    { 1066154936, 207880998, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5746), 760356939, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5747) },
                    { 1066154936, 221347219, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5646), 157961991, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5648) },
                    { 1066154936, 237420820, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6172), 822949850, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6173) },
                    { 1066154936, 251880728, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6024), 665675650, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6025) },
                    { 1066154936, 318658687, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5783), 766117696, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5785) },
                    { 1066154936, 359127311, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6086), 487471911, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6087) },
                    { 1066154936, 387254420, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6147), 386769173, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6149) },
                    { 1066154936, 402541393, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6196), 570982024, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6198) },
                    { 1066154936, 405971828, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6263), 935058438, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6265) },
                    { 1066154936, 412003390, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5858), 233603972, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5859) },
                    { 1066154936, 433744899, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5734), 447562439, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5735) },
                    { 1066154936, 447308040, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5912), 216469181, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5913) },
                    { 1066154936, 457620838, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5683), 336011503, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5684) },
                    { 1066154936, 495047332, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5846), 468703269, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5847) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1066154936, 513281233, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5986), 863578801, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5987) },
                    { 1066154936, 525873031, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5899), 770603669, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5900) },
                    { 1066154936, 526046679, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5577), 586927166, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5579) },
                    { 1066154936, 542340938, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5936), 696310605, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5938) },
                    { 1066154936, 567559800, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5924), 364151735, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5925) },
                    { 1066154936, 582176356, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5821), 641957055, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5822) },
                    { 1066154936, 585727298, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5949), 792943515, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5950) },
                    { 1066154936, 600575123, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5883), 342704411, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5884) },
                    { 1066154936, 608881719, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5809), 716551032, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5810) },
                    { 1066154936, 622104915, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6288), 802678603, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6289) },
                    { 1066154936, 634186050, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5659), 470270691, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5660) },
                    { 1066154936, 682141004, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6012), 297963502, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6013) },
                    { 1066154936, 682302355, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6325), 295862508, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6326) },
                    { 1066154936, 690767936, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6061), 985321330, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6062) },
                    { 1066154936, 720383637, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6209), 150633082, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6210) },
                    { 1066154936, 732737403, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5797), 204899210, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5798) },
                    { 1066154936, 751170213, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5633), 820789250, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5634) },
                    { 1066154936, 754044301, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5696), 387063867, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5698) },
                    { 1066154936, 758249654, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5671), 488974980, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5672) },
                    { 1066154936, 764685381, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6251), 358764027, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6252) },
                    { 1066154936, 770657524, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6234), 753190837, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6235) },
                    { 1066154936, 781590196, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5974), 573546274, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5975) },
                    { 1066154936, 789071088, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6074), 730993618, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6075) },
                    { 1066154936, 790267382, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5709), 830722365, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5710) },
                    { 1066154936, 793640125, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5595), 808917804, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5596) },
                    { 1066154936, 800297736, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6123), 664159767, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6124) },
                    { 1066154936, 804708702, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5961), 167800610, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5963) },
                    { 1066154936, 810540455, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5620), 798403937, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5621) },
                    { 1066154936, 814971713, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6160), 167189918, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6161) },
                    { 1066154936, 818430760, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6098), 663766408, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6099) },
                    { 1066154936, 821657534, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5999), 969644470, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6001) },
                    { 1066154936, 903079188, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5834), 733318334, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5835) },
                    { 1066154936, 913228353, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5871), 575214568, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5872) },
                    { 1066154936, 928695003, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6300), 216977390, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6301) },
                    { 1066154936, 933579832, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6110), 533584971, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6112) },
                    { 1066154936, 956069010, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5721), 125424918, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5723) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -980988440, -1653384500, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6393), 883280000, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6394) },
                    { -980988440, -690325840, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6380), 346159204, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6381) },
                    { -980988440, -53035071, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6405), 223125187, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6406) },
                    { -980988440, 1371831793, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6418), 291302888, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6419) },
                    { -980988440, 2093238865, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6431), 483437205, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(6432) },
                    { 1066154936, -1653384500, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5520), 883245589, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5521) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1066154936, -690325840, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5499), 939814101, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5500) },
                    { 1066154936, -53035071, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5534), 789560872, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5535) },
                    { 1066154936, 1371831793, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5547), 248237780, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5548) },
                    { 1066154936, 2093238865, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5560), 980600640, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(5562) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -980988440, 192038727, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7409), 2145135894, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7410) },
                    { -980988440, 200953521, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7218), -780277496, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7219) },
                    { -980988440, 211141271, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7463), 757040392, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7464) },
                    { -980988440, 410119294, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7299), -1342708660, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7300) },
                    { -980988440, 653111909, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7245), -1154288704, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7246) },
                    { -980988440, 719250456, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7326), -1272806582, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7327) },
                    { -980988440, 746650628, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7437), 1244111012, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7438) },
                    { -980988440, 840770531, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7355), -1499783195, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7357) },
                    { -980988440, 928699674, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7273), 1673880450, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7274) },
                    { -980988440, 999387938, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7382), 1102409304, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7383) },
                    { 1066154936, 192038727, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7396), -1077215376, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7397) },
                    { 1066154936, 200953521, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7200), 217279800, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7201) },
                    { 1066154936, 211141271, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7450), -991692626, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7451) },
                    { 1066154936, 410119294, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7286), 2098788117, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7287) },
                    { 1066154936, 653111909, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7232), 1085352200, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7233) },
                    { 1066154936, 719250456, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7312), 2008408648, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7313) },
                    { 1066154936, 746650628, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7423), -1305902944, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7424) },
                    { 1066154936, 840770531, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7339), -1255953088, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7340) },
                    { 1066154936, 928699674, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7259), 1359512452, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7260) },
                    { 1066154936, 999387938, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7369), -993050847, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(7370) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 135848536, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1041), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1043), 13000.0, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1042), "Signature 1423420", 80537, 410119294, 4.0, 24.0 },
                    { 197521309, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9078), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9080), 3010.0, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9079), "Signature 142345", 82964, 200953521, 1.0, 17.0 },
                    { 261572733, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4248), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4250), 1000003000.0, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4249), "Signature 1423445", 42959, 746650628, 9.0, 17.0 },
                    { 351271350, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3605), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3607), 100003000.0, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3606), "Signature 1423416", 22640, 192038727, 8.0, 24.0 },
                    { 592588168, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(398), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(400), 4000.0, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(399), "Signature 142349", 20901, 928699674, 3.0, 17.0 },
                    { 611084261, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4889), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4891), 10000003000.0, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4890), "Signature 1423450", 69270, 211141271, 10.0, 24.0 },
                    { 748607480, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2326), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2328), 1003000.0, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2327), "Signature 1423424", 29306, 840770531, 6.0, 24.0 },
                    { 898943802, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1682), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1685), 103000.0, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1684), "Signature 1423420", 59519, 719250456, 5.0, 17.0 },
                    { 906184771, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9751), new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9753), 3100.0, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9752), "Signature 1423412", 53424, 653111909, 2.0, 24.0 },
                    { 961361663, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2970), new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2972), 10003000.0, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2971), "Signature 142347", 67586, 999387938, 7.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 151709139, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4857), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4859), null, "69492777810", null, null, 211141271 },
                    { 198494504, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1652), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1653), null, "6949277785", null, null, 719250456 },
                    { 229849715, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9040), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9046), null, "6949277781", null, null, 200953521 },
                    { 401476706, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(367), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(368), null, "6949277783", null, null, 928699674 },
                    { 421064569, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3575), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3576), null, "6949277788", null, null, 192038727 },
                    { 515539443, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4218), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4219), null, "6949277789", null, null, 746650628 },
                    { 542054109, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2295), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2297), null, "6949277786", null, null, 840770531 },
                    { 643629295, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9719), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9720), null, "6949277782", null, null, 653111909 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 894114735, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2940), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2941), null, "6949277787", null, null, 999387938 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 998972313, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1010), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1011), null, "6949277784", null, null, 410119294 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 838722852, 151709139, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4875), 966620173, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4876) },
                    { 838722852, 198494504, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1669), 200172580, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1670) },
                    { 838722852, 229849715, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9063), 293176372, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9065) },
                    { 838722852, 401476706, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(384), 534828758, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(385) },
                    { 838722852, 421064569, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3591), 396153651, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(3592) },
                    { 838722852, 515539443, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4234), 489098155, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(4235) },
                    { 838722852, 542054109, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2312), 937439217, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2314) },
                    { 838722852, 643629295, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9736), 822643475, new DateTime(2024, 2, 26, 18, 10, 21, 160, DateTimeKind.Local).AddTicks(9738) },
                    { 838722852, 894114735, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2956), 949507024, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(2957) },
                    { 838722852, 998972313, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1027), 745740402, new DateTime(2024, 2, 26, 18, 10, 21, 161, DateTimeKind.Local).AddTicks(1028) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyHours_TimeSpanId",
                table: "DailyHours",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHours_UserId",
                table: "DailyHours",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_EngineerId",
                table: "Disciplines",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesDraws_DrawId",
                table: "DisciplinesDraws",
                column: "DrawId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesOthers_OtherId",
                table: "DisciplinesOthers",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesPojects_ProjectId",
                table: "DisciplinesPojects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawingsEmployees_EmployeeId",
                table: "DrawingsEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ManHours_DisciplineId",
                table: "ManHours",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHours_DrawingId",
                table: "ManHours",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHours_OtherId",
                table: "ManHours",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHours_ProjectId",
                table: "ManHours",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ManHours_UserId",
                table: "ManHours",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OthersEmployees_EmployeeId",
                table: "OthersEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

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
                name: "FK_DailyHours_Users_UserId",
                table: "DailyHours",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Users_EngineerId",
                table: "Disciplines",
                column: "EngineerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinesPojects_Projects_ProjectId",
                table: "DisciplinesPojects",
                column: "ProjectId",
                principalTable: "Projects",
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
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

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
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "DailyHours");

            migrationBuilder.DropTable(
                name: "DisciplinesDraws");

            migrationBuilder.DropTable(
                name: "DisciplinesOthers");

            migrationBuilder.DropTable(
                name: "DisciplinesPojects");

            migrationBuilder.DropTable(
                name: "DrawingsEmployees");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ManHours");

            migrationBuilder.DropTable(
                name: "OthersEmployees");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "TimeSpans");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Drawings");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
