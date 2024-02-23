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
                name: "Draws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenHours = table.Column<double>(type: "float", nullable: false),
                    CompletionEstimation = table.Column<int>(type: "int", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenHours = table.Column<double>(type: "float", nullable: false),
                    CompletionEstimation = table.Column<int>(type: "int", nullable: false),
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
                name: "Timespan",
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
                    table.PrimaryKey("PK_Timespan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyHour",
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
                    table.PrimaryKey("PK_DailyHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyHour_Timespan_TimeSpanId",
                        column: x => x.TimeSpanId,
                        principalTable: "Timespan",
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
                    MenHours = table.Column<long>(type: "bigint", nullable: false),
                    Completed = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_DisciplinesDraws_Draws_DrawId",
                        column: x => x.DrawId,
                        principalTable: "Draws",
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
                name: "DisciplinesEmployees",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesEmployees", x => new { x.DisciplineId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_DisciplinesEmployees_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
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
                    MenHours = table.Column<long>(type: "bigint", nullable: false),
                    Completed = table.Column<int>(type: "int", nullable: true),
                    WorkPackegedCompleted = table.Column<int>(type: "int", nullable: true),
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
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 135283283, new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5083), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5084), 0.0, "Draw_5_2" },
                    { 151328532, new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4945), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4946), 0.0, "Draw_4_5" },
                    { 152687525, new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4701), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4702), 0.0, "Draw_3_0" },
                    { 159846080, new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5305), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5306), 0.0, "Draw_6_5" },
                    { 172497234, new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4757), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4758), 0.0, "Draw_3_4" },
                    { 178592072, new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6004), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6005), 0.0, "Draw_10_4" },
                    { 183951480, new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5055), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5056), 0.0, "Draw_5_0" },
                    { 185704484, new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5629), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5631), 0.0, "Draw_8_3" },
                    { 188332220, new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5603), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5604), 0.0, "Draw_8_1" },
                    { 238363042, new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5783), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5784), 0.0, "Draw_9_1" },
                    { 248698320, new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4578), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4579), 0.0, "Draw_2_4" },
                    { 249694443, new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4345), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4346), 0.0, "Draw_1_1" },
                    { 252467591, new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5249), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5250), 0.0, "Draw_6_1" },
                    { 253675685, new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5973), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5974), 0.0, "Draw_10_2" },
                    { 260426119, new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4387), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4388), 0.0, "Draw_1_4" },
                    { 286219254, new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5987), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5988), 0.0, "Draw_10_3" },
                    { 302119171, new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5768), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5769), 0.0, "Draw_9_0" },
                    { 317099504, new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4744), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4745), 0.0, "Draw_3_3" },
                    { 317632973, new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5110), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5111), 0.0, "Draw_5_4" },
                    { 326351244, new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4373), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4374), 0.0, "Draw_1_3" },
                    { 326961596, new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4591), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4592), 0.0, "Draw_2_5" },
                    { 335004857, new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4519), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4520), 0.0, "Draw_2_0" },
                    { 337222197, new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4918), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4919), 0.0, "Draw_4_3" },
                    { 374674460, new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5838), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5839), 0.0, "Draw_9_5" },
                    { 393112204, new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5263), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5264), 0.0, "Draw_6_2" },
                    { 395031003, new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4564), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4565), 0.0, "Draw_2_3" },
                    { 412315343, new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5589), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5590), 0.0, "Draw_8_0" },
                    { 435616950, new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4877), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4878), 0.0, "Draw_4_0" },
                    { 472634912, new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5292), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5293), 0.0, "Draw_6_4" },
                    { 480906561, new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4534), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4535), 0.0, "Draw_2_1" },
                    { 523663430, new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5797), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5798), 0.0, "Draw_9_2" },
                    { 559989001, new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5235), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5236), 0.0, "Draw_6_0" },
                    { 561100029, new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5410), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5411), 0.0, "Draw_7_0" },
                    { 568913324, new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5438), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5439), 0.0, "Draw_7_2" },
                    { 596150476, new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4359), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4360), 0.0, "Draw_1_2" },
                    { 626488386, new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4716), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4717), 0.0, "Draw_3_1" },
                    { 677197874, new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5824), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5825), 0.0, "Draw_9_4" },
                    { 686955630, new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4932), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4933), 0.0, "Draw_4_4" },
                    { 690988964, new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5960), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5961), 0.0, "Draw_10_1" },
                    { 712119492, new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5643), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5644), 0.0, "Draw_8_4" },
                    { 724922565, new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5616), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5617), 0.0, "Draw_8_2" },
                    { 751107373, new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5123), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5124), 0.0, "Draw_5_5" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 766740476, new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6018), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6019), 0.0, "Draw_10_5" },
                    { 767256752, new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5069), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5071), 0.0, "Draw_5_1" },
                    { 774326261, new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5097), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5098), 0.0, "Draw_5_3" },
                    { 782536846, new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4548), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4549), 0.0, "Draw_2_2" },
                    { 782716849, new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4891), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4892), 0.0, "Draw_4_1" },
                    { 787188938, new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4324), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4325), 0.0, "Draw_1_0" },
                    { 798894468, new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4402), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4403), 0.0, "Draw_1_5" },
                    { 830837060, new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5451), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5453), 0.0, "Draw_7_3" },
                    { 920715356, new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5810), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5812), 0.0, "Draw_9_3" },
                    { 939167777, new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5278), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5279), 0.0, "Draw_6_3" },
                    { 944696383, new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5945), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5946), 0.0, "Draw_10_0" },
                    { 944957738, new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4772), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4774), 0.0, "Draw_3_5" },
                    { 957989165, new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5483), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5484), 0.0, "Draw_7_5" },
                    { 958037698, new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5424), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5425), 0.0, "Draw_7_1" },
                    { 969522628, new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5657), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5658), 0.0, "Draw_8_5" },
                    { 987602944, new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5469), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5471), 0.0, "Draw_7_4" },
                    { 996049789, new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4730), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4731), 0.0, "Draw_3_2" },
                    { 999350876, new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4905), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4906), 0.0, "Draw_4_2" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1790313986, 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4145), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4147), 0.0, "Inside" },
                    { -92149088, 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4172), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4173), 0.0, "Administration" },
                    { 1204734251, 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4131), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4132), 0.0, "Printing" },
                    { 1828130981, 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4159), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4160), 0.0, "Meeting" },
                    { 1922683410, 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4112), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4113), 0.0, "Comm" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 295961467, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3681), true, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3682), "COO" },
                    { 435091630, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3688), true, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3689), "CTO" },
                    { 518935410, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3674), true, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3675), "Project Manager" },
                    { 590014266, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3695), true, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3697), "CEO" },
                    { 613349264, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3666), true, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3667), "Engineer" },
                    { 723565574, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3710), false, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3711), "Customer" },
                    { 824196180, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3657), true, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3658), "Draftsmen" },
                    { 958367799, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3703), false, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3704), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 130238708, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3880), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3881), null, "6949277780", null, null, null },
                    { 187270224, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4017), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4019), null, "6949277783", null, null, null },
                    { 252294877, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3958), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3959), null, "6949277781", null, null, null },
                    { 372418846, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4605), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4606), null, "6949277785", null, null, null },
                    { 430190780, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5851), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5853), null, "69492777812", null, null, null },
                    { 433985615, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6987), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6988), null, "6949277784", null, null, null },
                    { 438450477, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3989), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3990), null, "6949277782", null, null, null },
                    { 440084449, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4961), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4962), null, "6949277787", null, null, null },
                    { 441407887, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4421), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4422), null, "6949277784", null, null, null },
                    { 451153422, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5137), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5138), null, "6949277788", null, null, null },
                    { 560149143, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5319), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5320), null, "6949277789", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 569244280, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4787), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4788), null, "6949277786", null, null, null },
                    { 596122513, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5670), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5671), null, "69492777811", null, null, null },
                    { 611547646, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6033), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6035), null, "6949277783", null, null, null },
                    { 830003300, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4046), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4047), null, "6949277784", null, null, null },
                    { 858669971, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5497), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5498), null, "69492777810", null, null, null },
                    { 870243980, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4081), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4082), null, "6949277785", null, null, null },
                    { 931122983, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4188), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4189), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1412341384, 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6066), 611547646, 2345L, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6067), 3425L, "ELEC" },
                    { -1247623744, 0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7015), 433985615, 2345L, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7016), 3425L, "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 285156508, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 10.0, 25, new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 25, "Test Description Project_10", "KL-5", new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 16L, 125L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_5", 5.0, new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_25", 5.0, 440084449, new DateTime(2026, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 },
                    { 310459915, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 15.0, 100, new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 100, "Test Description Project_60", "KL-10", new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 125L, 1000L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_10", 5.0, new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_60", 10.0, 430190780, new DateTime(2032, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 },
                    { 356549997, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 13.0, 64, new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 64, "Test Description Project_40", "KL-8", new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 64L, 512L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_8", 5.0, new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_48", 8.0, 858669971, new DateTime(2029, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 },
                    { 418369298, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 12.0, 49, new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 49, "Test Description Project_28", "KL-7", new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 43L, 343L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_7", 5.0, new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_42", 7.0, 560149143, new DateTime(2028, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 },
                    { 548039927, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 7.0, 4, new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 4, "Test Description Project_6", "KL-2", new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 1L, 8L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_2", 5.0, new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_10", 2.0, 441407887, new DateTime(2024, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 },
                    { 581899319, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 14.0, 81, new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 81, "Test Description Project_18", "KL-9", new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 91L, 729L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_9", 5.0, new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_9", 9.0, 596122513, new DateTime(2030, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 },
                    { 707952542, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 11.0, 36, new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 36, "Test Description Project_6", "KL-6", new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 27L, 216L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_6", 5.0, new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_30", 6.0, 451153422, new DateTime(2027, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 },
                    { 804131660, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 6.0, 1, new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 1, "Test Description Project_2", "KL-1", new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, 1L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_1", 5.0, new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_4", 1.0, 931122983, new DateTime(2024, 3, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 },
                    { 841501686, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 8.0, 9, new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 9, "Test Description Project_6", "KL-3", new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 3L, 27L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_3", 5.0, new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_12", 3.0, 372418846, new DateTime(2024, 11, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 },
                    { 975893284, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 9.0, 16, new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 16, "Test Description Project_24", "KL-4", new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 8L, 64L, new DateTime(2024, 2, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0L, "Project_4", 5.0, new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), "Payment Detailes For Project_4", 4.0, 569244280, new DateTime(2025, 6, 23, 13, 10, 32, 884, DateTimeKind.Local).AddTicks(9824), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 824196180, 130238708, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3937), 235719295, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3938) },
                    { 824196180, 187270224, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4032), 475770124, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4034) },
                    { 824196180, 252294877, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3975), 600437818, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(3976) },
                    { 518935410, 372418846, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4621), 124127245, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4622) },
                    { 518935410, 430190780, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5868), 726319711, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5869) },
                    { 613349264, 433985615, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7003), 531200249, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7004) },
                    { 824196180, 438450477, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4005), 464050864, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4006) },
                    { 518935410, 440084449, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4977), 162677690, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4979) },
                    { 518935410, 441407887, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4438), 491758641, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4439) },
                    { 518935410, 451153422, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5153), 364735067, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5154) },
                    { 518935410, 560149143, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5334), 497053351, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5335) },
                    { 518935410, 569244280, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4802), 367156674, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4803) },
                    { 518935410, 596122513, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5687), 466783893, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5688) },
                    { 613349264, 611547646, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6052), 383657892, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6053) },
                    { 824196180, 830003300, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4067), 460902363, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4068) },
                    { 518935410, 858669971, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5513), 600573469, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5514) },
                    { 824196180, 870243980, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4096), 166385690, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4098) },
                    { 518935410, 931122983, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4208), 173064671, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4210) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1412341384, 135283283, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6582), 723361747, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6583) },
                    { -1412341384, 151328532, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6547), 836002652, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6548) },
                    { -1412341384, 152687525, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6416), 933417794, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6418) },
                    { -1412341384, 159846080, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6690), 313016453, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6691) },
                    { -1412341384, 172497234, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6463), 585158658, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6464) },
                    { -1412341384, 178592072, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6963), 597833850, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6964) },
                    { -1412341384, 183951480, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6558), 600710693, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6560) },
                    { -1412341384, 185704484, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6810), 449404235, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6811) },
                    { -1412341384, 188332220, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6787), 228081001, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6788) },
                    { -1412341384, 238363042, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6857), 588189330, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6858) },
                    { -1412341384, 248698320, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6393), 606566526, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6394) },
                    { -1412341384, 249694443, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6269), 282400332, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6271) },
                    { -1412341384, 252467591, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6641), 178355822, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6642) },
                    { -1412341384, 253675685, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6939), 231037786, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6940) },
                    { -1412341384, 260426119, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6305), 152818533, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6306) },
                    { -1412341384, 286219254, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6951), 715079752, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6952) },
                    { -1412341384, 302119171, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6845), 896112400, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6846) },
                    { -1412341384, 317099504, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6452), 366234775, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6453) },
                    { -1412341384, 317632973, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6606), 246037624, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6607) },
                    { -1412341384, 326351244, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6293), 825347541, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6294) },
                    { -1412341384, 326961596, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6405), 161337358, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6406) },
                    { -1412341384, 335004857, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6329), 429015054, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6331) },
                    { -1412341384, 337222197, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6523), 581347977, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6524) },
                    { -1412341384, 374674460, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6904), 646009928, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6905) },
                    { -1412341384, 393112204, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6652), 619700264, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6653) },
                    { -1412341384, 395031003, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6380), 969366656, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6382) },
                    { -1412341384, 412315343, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6775), 240353522, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6776) },
                    { -1412341384, 435616950, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6488), 328198406, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6489) },
                    { -1412341384, 472634912, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6678), 406498019, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6679) },
                    { -1412341384, 480906561, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6341), 726621481, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6342) },
                    { -1412341384, 523663430, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6869), 861606538, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6870) },
                    { -1412341384, 559989001, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6629), 209963631, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6630) },
                    { -1412341384, 561100029, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6701), 398424592, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6702) },
                    { -1412341384, 568913324, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6728), 124665535, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6729) },
                    { -1412341384, 596150476, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6281), 603487398, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6282) },
                    { -1412341384, 626488386, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6428), 978363998, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6429) },
                    { -1412341384, 677197874, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6892), 566510369, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6893) },
                    { -1412341384, 686955630, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6535), 786571070, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6536) },
                    { -1412341384, 690988964, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6927), 738001656, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6929) },
                    { -1412341384, 712119492, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6822), 298957099, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6823) },
                    { -1412341384, 724922565, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6799), 559449238, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6800) },
                    { -1412341384, 751107373, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6617), 805695262, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6618) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1412341384, 766740476, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6974), 337366963, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6976) },
                    { -1412341384, 767256752, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6571), 207329327, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6572) },
                    { -1412341384, 774326261, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6594), 465934680, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6595) },
                    { -1412341384, 782536846, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6353), 602595603, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6354) },
                    { -1412341384, 782716849, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6500), 900500895, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6501) },
                    { -1412341384, 787188938, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6252), 644741527, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6253) },
                    { -1412341384, 798894468, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6318), 192842318, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6319) },
                    { -1412341384, 830837060, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6740), 758501680, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6741) },
                    { -1412341384, 920715356, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6881), 624533440, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6882) },
                    { -1412341384, 939167777, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6665), 641893779, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6666) },
                    { -1412341384, 944696383, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6916), 894916709, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6917) },
                    { -1412341384, 944957738, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6476), 171032318, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6477) },
                    { -1412341384, 957989165, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6763), 541843914, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6764) },
                    { -1412341384, 958037698, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6716), 295890669, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6717) },
                    { -1412341384, 969522628, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6834), 633306179, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6835) },
                    { -1412341384, 987602944, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6751), 388149097, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6752) },
                    { -1412341384, 996049789, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6440), 254762469, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6441) },
                    { -1412341384, 999350876, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6511), 875275308, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6512) },
                    { -1247623744, 135283283, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7476), 914263263, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7477) },
                    { -1247623744, 151328532, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7440), 735547778, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7442) },
                    { -1247623744, 152687525, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7310), 380674301, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7311) },
                    { -1247623744, 159846080, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7580), 247060163, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7581) },
                    { -1247623744, 172497234, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7356), 138689715, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7357) },
                    { -1247623744, 178592072, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7851), 308103619, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7852) },
                    { -1247623744, 183951480, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7452), 835754611, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7454) },
                    { -1247623744, 185704484, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7697), 859497275, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7698) },
                    { -1247623744, 188332220, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7673), 141418641, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7675) },
                    { -1247623744, 238363042, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7747), 686006596, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7748) },
                    { -1247623744, 248698320, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7286), 497680386, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7288) },
                    { -1247623744, 249694443, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7180), 657480423, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7182) },
                    { -1247623744, 252467591, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7534), 206888422, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7535) },
                    { -1247623744, 253675685, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7828), 770852016, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7829) },
                    { -1247623744, 260426119, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7215), 186482894, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7216) },
                    { -1247623744, 286219254, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7840), 827561300, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7841) },
                    { -1247623744, 302119171, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7733), 999301815, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7734) },
                    { -1247623744, 317099504, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7345), 613565518, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7346) },
                    { -1247623744, 317632973, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7499), 935680265, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7500) },
                    { -1247623744, 326351244, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7204), 619977492, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7205) },
                    { -1247623744, 326961596, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7298), 236207790, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7299) },
                    { -1247623744, 335004857, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7240), 906489190, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7241) },
                    { -1247623744, 337222197, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7417), 977870862, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7418) },
                    { -1247623744, 374674460, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7794), 882189448, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7795) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1247623744, 393112204, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7545), 586618714, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7546) },
                    { -1247623744, 395031003, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7275), 150859657, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7276) },
                    { -1247623744, 412315343, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7662), 202081467, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7663) },
                    { -1247623744, 435616950, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7382), 657123420, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7383) },
                    { -1247623744, 472634912, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7568), 880404955, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7569) },
                    { -1247623744, 480906561, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7252), 355906272, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7253) },
                    { -1247623744, 523663430, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7759), 847399455, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7760) },
                    { -1247623744, 559989001, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7522), 692812678, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7523) },
                    { -1247623744, 561100029, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7592), 935250768, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7593) },
                    { -1247623744, 568913324, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7615), 835382485, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7616) },
                    { -1247623744, 596150476, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7192), 914919084, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7193) },
                    { -1247623744, 626488386, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7321), 672041234, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7322) },
                    { -1247623744, 677197874, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7782), 890752949, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7783) },
                    { -1247623744, 686955630, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7429), 704081797, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7430) },
                    { -1247623744, 690988964, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7817), 226409083, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7818) },
                    { -1247623744, 712119492, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7709), 500426850, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7710) },
                    { -1247623744, 724922565, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7685), 838495797, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7687) },
                    { -1247623744, 751107373, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7511), 355774994, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7512) },
                    { -1247623744, 766740476, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7863), 501894701, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7864) },
                    { -1247623744, 767256752, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7464), 980175332, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7465) },
                    { -1247623744, 774326261, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7487), 319788084, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7488) },
                    { -1247623744, 782536846, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7263), 440627247, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7265) },
                    { -1247623744, 782716849, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7394), 964740438, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7395) },
                    { -1247623744, 787188938, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7168), 544940857, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7169) },
                    { -1247623744, 798894468, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7228), 298353431, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7230) },
                    { -1247623744, 830837060, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7627), 898508225, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7628) },
                    { -1247623744, 920715356, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7771), 939208043, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7772) },
                    { -1247623744, 939167777, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7557), 433658733, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7558) },
                    { -1247623744, 944696383, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7805), 303360893, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7806) },
                    { -1247623744, 944957738, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7368), 932423517, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7369) },
                    { -1247623744, 957989165, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7650), 474045417, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7652) },
                    { -1247623744, 958037698, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7603), 501571517, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7605) },
                    { -1247623744, 969522628, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7721), 405099368, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7722) },
                    { -1247623744, 987602944, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7639), 126353556, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7640) },
                    { -1247623744, 996049789, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7333), 421306562, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7334) },
                    { -1247623744, 999350876, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7406), 529821222, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7407) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1412341384, 130238708, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6160), 1595846673, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6161) },
                    { -1412341384, 187270224, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6207), 933548063, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6208) },
                    { -1412341384, 252294877, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6181), 1726752992, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6183) },
                    { -1412341384, 438450477, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6195), 1488679124, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6196) },
                    { -1412341384, 830003300, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6221), 1957350416, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6222) },
                    { -1412341384, 870243980, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6235), 905764541, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6236) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1247623744, 130238708, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7091), -1077006590, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7092) },
                    { -1247623744, 187270224, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7130), -999972598, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7131) },
                    { -1247623744, 252294877, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7104), 1993956129, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7105) },
                    { -1247623744, 438450477, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7117), -1847188583, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7118) },
                    { -1247623744, 830003300, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7143), -828423341, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7144) },
                    { -1247623744, 870243980, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7155), 303940234, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7156) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1412341384, -1790313986, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6118), 501597156, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6120) },
                    { -1412341384, -92149088, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6144), 944920622, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6146) },
                    { -1412341384, 1204734251, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6105), 177314638, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6106) },
                    { -1412341384, 1828130981, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6132), 654025768, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6133) },
                    { -1412341384, 1922683410, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6089), 475906940, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(6090) },
                    { -1247623744, -1790313986, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7051), 480182732, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7052) },
                    { -1247623744, -92149088, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7079), 712550292, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7080) },
                    { -1247623744, 1204734251, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7040), 884439014, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7041) },
                    { -1247623744, 1828130981, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7066), 136898572, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7067) },
                    { -1247623744, 1922683410, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7028), 386470880, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7029) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1412341384, 285156508, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7987), 2071580968, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7988) },
                    { -1412341384, 310459915, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8117), -1373600874, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8118) },
                    { -1412341384, 356549997, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8062), -1633467163, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8063) },
                    { -1412341384, 418369298, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8038), -976418325, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8039) },
                    { -1412341384, 548039927, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7911), 1592849228, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7912) },
                    { -1412341384, 581899319, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8088), -995129298, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8089) },
                    { -1412341384, 707952542, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8013), -1488623700, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8014) },
                    { -1412341384, 804131660, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7877), -353111422, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7878) },
                    { -1412341384, 841501686, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7936), 413283108, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7937) },
                    { -1412341384, 975893284, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7962), 610655336, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7963) },
                    { -1247623744, 285156508, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8000), 280179194, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8001) },
                    { -1247623744, 310459915, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8130), -702903830, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8131) },
                    { -1247623744, 356549997, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8075), 847971698, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8076) },
                    { -1247623744, 418369298, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8050), -259113290, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8051) },
                    { -1247623744, 548039927, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7923), -859776944, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7924) },
                    { -1247623744, 581899319, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8101), -1120342518, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8102) },
                    { -1247623744, 707952542, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8025), 1800374523, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(8026) },
                    { -1247623744, 804131660, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7896), 485832848, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7897) },
                    { -1247623744, 841501686, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7949), 1768055548, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7950) },
                    { -1247623744, 975893284, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7975), -623791970, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(7976) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 189999456, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5219), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5221), 1003000.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5220), "Signature 1423424", 86160, 707952542, 6.0, 24.0 },
                    { 229753704, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4502), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4504), 3100.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4503), "Signature 142342", 51941, 548039927, 2.0, 24.0 },
                    { 324776765, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5574), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5576), 100003000.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5575), "Signature 1423424", 27395, 356549997, 8.0, 24.0 },
                    { 443685328, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5752), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5754), 1000003000.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5753), "Signature 1423454", 82407, 581899319, 9.0, 17.0 },
                    { 802222081, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4686), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4688), 4000.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4687), "Signature 142346", 77238, 841501686, 3.0, 17.0 },
                    { 821071331, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5929), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5932), 10000003000.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5931), "Signature 1423460", 21832, 310459915, 10.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 827880183, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4303), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4305), 3010.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4304), "Signature 142344", 14795, 804131660, 1.0, 17.0 },
                    { 923821752, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5394), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5396), 10003000.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5395), "Signature 1423428", 21029, 418369298, 7.0, 17.0 },
                    { 958537445, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4861), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4863), 13000.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4862), "Signature 1423416", 33874, 975893284, 4.0, 24.0 },
                    { 971160940, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5039), new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5041), 103000.0, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5040), "Signature 1423410", 68738, 285156508, 5.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 150077735, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5901), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5902), null, "69492777810", null, null, 310459915 },
                    { 151803048, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4270), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4271), null, "6949277781", null, null, 804131660 },
                    { 355098010, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5010), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5011), null, "6949277785", null, null, 285156508 },
                    { 541770524, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4654), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4655), null, "6949277783", null, null, 841501686 },
                    { 557615430, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4833), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4834), null, "6949277784", null, null, 975893284 },
                    { 828262131, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4475), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4476), null, "6949277782", null, null, 548039927 },
                    { 853726694, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5366), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5367), null, "6949277787", null, null, 418369298 },
                    { 923217209, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5723), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5724), null, "6949277789", null, null, 581899319 },
                    { 970374026, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5186), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5187), null, "6949277786", null, null, 707952542 },
                    { 974851312, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5546), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5547), null, "6949277788", null, null, 356549997 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 723565574, 150077735, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5917), 139605632, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5918) },
                    { 723565574, 151803048, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4288), 148993347, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4290) },
                    { 723565574, 355098010, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5026), 400388579, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5027) },
                    { 723565574, 541770524, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4673), 340421768, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4674) },
                    { 723565574, 557615430, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4848), 657698021, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4849) },
                    { 723565574, 828262131, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4490), 318089760, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(4491) },
                    { 723565574, 853726694, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5381), 249975749, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5383) },
                    { 723565574, 923217209, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5738), 670881736, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5739) },
                    { 723565574, 970374026, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5206), 262617000, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5207) },
                    { 723565574, 974851312, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5562), 249705961, new DateTime(2024, 2, 23, 13, 10, 32, 888, DateTimeKind.Local).AddTicks(5563) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_TimeSpanId",
                table: "DailyHour",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyHour_UserId",
                table: "DailyHour",
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
                name: "IX_DisciplinesEmployees_EmployeeId",
                table: "DisciplinesEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesOthers_OtherId",
                table: "DisciplinesOthers",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesPojects_ProjectId",
                table: "DisciplinesPojects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

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
                name: "FK_DailyHour_Users_UserId",
                table: "DailyHour",
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
                name: "FK_DisciplinesEmployees_Users_EmployeeId",
                table: "DisciplinesEmployees",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinesPojects_Projects_ProjectId",
                table: "DisciplinesPojects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

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
                name: "DailyHour");

            migrationBuilder.DropTable(
                name: "DisciplinesDraws");

            migrationBuilder.DropTable(
                name: "DisciplinesEmployees");

            migrationBuilder.DropTable(
                name: "DisciplinesOthers");

            migrationBuilder.DropTable(
                name: "DisciplinesPojects");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Timespan");

            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
