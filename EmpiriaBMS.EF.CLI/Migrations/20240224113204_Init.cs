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
                    MenHours = table.Column<long>(type: "bigint", nullable: false),
                    CompletionEstimation = table.Column<float>(type: "real", nullable: false),
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
                    MenHours = table.Column<long>(type: "bigint", nullable: false),
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
                    { 123905373, new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9959), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9960), 0L, "Draw_10_0" },
                    { 127435055, new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9649), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9650), 0L, "Draw_8_3" },
                    { 136996438, new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8439), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8440), 0L, "Draw_1_5" },
                    { 145743972, new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8756), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8757), 0L, "Draw_3_2" },
                    { 159235310, new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8932), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8933), 0L, "Draw_4_2" },
                    { 173098106, new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8801), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8802), 0L, "Draw_3_5" },
                    { 184081553, new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9447), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9448), 0L, "Draw_7_1" },
                    { 184948307, new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9135), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9136), 0L, "Draw_5_4" },
                    { 185444822, new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9607), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9609), 0L, "Draw_8_0" },
                    { 202007496, new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9838), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9839), 0L, "Draw_9_4" },
                    { 204415246, new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9254), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9256), 0L, "Draw_6_0" },
                    { 215918817, new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9851), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9852), 0L, "Draw_9_5" },
                    { 222264435, new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8918), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8920), 0L, "Draw_4_1" },
                    { 225899476, new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9821), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9822), 0L, "Draw_9_3" },
                    { 231415274, new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8622), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8623), 0L, "Draw_2_5" },
                    { 244140393, new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8609), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8610), 0L, "Draw_2_4" },
                    { 257645015, new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9675), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9676), 0L, "Draw_8_5" },
                    { 265271030, new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8382), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8383), 0L, "Draw_1_1" },
                    { 270404176, new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8945), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8946), 0L, "Draw_4_3" },
                    { 282631077, new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8396), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8397), 0L, "Draw_1_2" },
                    { 310749537, new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8904), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8906), 0L, "Draw_4_0" },
                    { 344802859, new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9973), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9974), 0L, "Draw_10_1" },
                    { 350276876, new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9081), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9082), 0L, "Draw_5_0" },
                    { 360729564, new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8359), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8361), 0L, "Draw_1_0" },
                    { 365103920, new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9433), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9434), 0L, "Draw_7_0" },
                    { 392768135, new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8410), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8412), 0L, "Draw_1_3" },
                    { 414890217, new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9301), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9302), 0L, "Draw_6_3" },
                    { 428556273, new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9460), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9461), 0L, "Draw_7_2" },
                    { 449283553, new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9500), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9501), 0L, "Draw_7_5" },
                    { 453528097, new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9781), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9782), 0L, "Draw_9_0" },
                    { 495558138, new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8971), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8973), 0L, "Draw_4_5" },
                    { 510646361, new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9095), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9096), 0L, "Draw_5_1" },
                    { 524285203, new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9122), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9123), 0L, "Draw_5_3" },
                    { 541354868, new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(27), new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(28), 0L, "Draw_10_5" },
                    { 552545930, new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8729), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8731), 0L, "Draw_3_0" },
                    { 556111382, new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9987), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9988), 0L, "Draw_10_2" },
                    { 566390103, new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9794), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9796), 0L, "Draw_9_1" },
                    { 574427316, new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9487), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9488), 0L, "Draw_7_4" },
                    { 644463951, new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9314), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9315), 0L, "Draw_6_4" },
                    { 654233651, new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9622), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9623), 0L, "Draw_8_1" },
                    { 697526943, new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(14), new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(15), 0L, "Draw_10_4" },
                    { 702970468, new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9109), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9110), 0L, "Draw_5_2" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 739026502, new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9148), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9150), 0L, "Draw_5_5" },
                    { 747475928, new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9662), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9663), 0L, "Draw_8_4" },
                    { 750964812, new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9808), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9809), 0L, "Draw_9_2" },
                    { 791041151, new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9282), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9283), 0L, "Draw_6_2" },
                    { 819830109, new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8769), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8771), 0L, "Draw_3_3" },
                    { 849267368, new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8581), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8582), 0L, "Draw_2_2" },
                    { 866317472, new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9328), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9329), 0L, "Draw_6_5" },
                    { 868310537, new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8568), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8569), 0L, "Draw_2_1" },
                    { 877417532, new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8424), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8425), 0L, "Draw_1_4" },
                    { 880600506, new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8743), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8744), 0L, "Draw_3_1" },
                    { 883676066, new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local), new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1), 0L, "Draw_10_3" },
                    { 889581597, new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9269), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9270), 0L, "Draw_6_1" },
                    { 919251942, new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8783), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8784), 0L, "Draw_3_4" },
                    { 951972933, new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8595), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8596), 0L, "Draw_2_3" },
                    { 960027372, new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8958), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8959), 0L, "Draw_4_4" },
                    { 963166693, new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8554), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8555), 0L, "Draw_2_0" },
                    { 968037365, new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9635), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9636), 0L, "Draw_8_2" },
                    { 981102813, new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9473), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9474), 0L, "Draw_7_3" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1226681395, 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8181), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8182), 0L, "On-Site" },
                    { -1110644489, 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8208), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8209), 0L, "Administration" },
                    { -1040944434, 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8194), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8195), 0L, "Meetings" },
                    { 1058665617, 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8150), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8151), 0L, "Communications" },
                    { 1653349426, 0f, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8166), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8168), 0L, "Printing" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 159987392, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7815), true, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7817), "COO" },
                    { 211430436, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7822), true, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7824), "CTO" },
                    { 261068178, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7830), true, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7832), "CEO" },
                    { 578203280, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7808), true, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7809), "Project Manager" },
                    { 621330370, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7844), false, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7845), "Customer" },
                    { 726215956, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7793), true, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7794), "Designer" },
                    { 841452384, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7801), true, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7802), "Engineer" },
                    { 998548051, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7837), false, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7838), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 155650359, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8093), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8094), null, "6949277784", null, null, null },
                    { 196293643, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8230), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8231), null, "6949277783", null, null, null },
                    { 290785993, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8122), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8123), null, "6949277785", null, null, null },
                    { 310756017, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8636), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8637), null, "6949277785", null, null, null },
                    { 316985221, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9341), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9342), null, "6949277789", null, null, null },
                    { 332159211, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9865), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9866), null, "69492777812", null, null, null },
                    { 379681564, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7947), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7949), null, "6949277780", null, null, null },
                    { 384534673, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9688), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9689), null, "69492777811", null, null, null },
                    { 627927396, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9162), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9163), null, "6949277788", null, null, null },
                    { 693240275, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(42), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(43), null, "6949277783", null, null, null },
                    { 772415579, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8066), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8067), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 811677337, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8039), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8040), null, "6949277782", null, null, null },
                    { 838642208, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9513), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9514), null, "69492777810", null, null, null },
                    { 854599066, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8985), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8986), null, "6949277787", null, null, null },
                    { 859659347, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(973), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(974), null, "6949277784", null, null, null },
                    { 863950782, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8815), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8816), null, "6949277786", null, null, null },
                    { 901109343, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8453), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8454), null, "6949277784", null, null, null },
                    { 943205830, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8011), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8012), null, "6949277781", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 179186488, 0f, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1000), 859659347, 1500L, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1001), 0L, "HVAC" },
                    { 331857512, 0f, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(73), 693240275, 1500L, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(75), 0L, "ELEC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 291923646, "ALPHA", 2, "D-22-162", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 7.0, 4, new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 4, "Test Description Project_2", "KL-2", new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_2", 5.0, new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_8", 2.0, 901109343, new DateTime(2024, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f },
                    { 306492740, "NBG_IBANK", 1, "D-22-161", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 6.0, 1, new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 1, "Test Description Project_5", "KL-1", new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_1", 5.0, new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_4", 1.0, 196293643, new DateTime(2024, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f },
                    { 306962532, "NBG_IBANK", 3, "D-22-163", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 8.0, 9, new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 9, "Test Description Project_12", "KL-3", new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_3", 5.0, new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_15", 3.0, 310756017, new DateTime(2024, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f },
                    { 364602110, "NBG_IBANK", 1, "D-22-169", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 14.0, 81, new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 81, "Test Description Project_45", "KL-9", new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_9", 5.0, new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_9", 9.0, 384534673, new DateTime(2030, 11, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f },
                    { 387391573, "ALPHA", 1, "D-22-168", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 13.0, 64, new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 64, "Test Description Project_24", "KL-8", new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_8", 5.0, new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_24", 8.0, 838642208, new DateTime(2029, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f },
                    { 440870912, "NBG_IBANK", 1, "D-22-167", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 12.0, 49, new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 49, "Test Description Project_14", "KL-7", new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_7", 5.0, new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_28", 7.0, 316985221, new DateTime(2028, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f },
                    { 491396297, "ALPHA", 1, "D-22-166", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 11.0, 36, new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 36, "Test Description Project_12", "KL-6", new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_6", 5.0, new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_6", 6.0, 627927396, new DateTime(2027, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f },
                    { 529740413, "NBG_IBANK", 1, "D-22-165", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 10.0, 25, new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 25, "Test Description Project_15", "KL-5", new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_5", 5.0, new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_10", 5.0, 854599066, new DateTime(2026, 3, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f },
                    { 790010109, "ALPHA", 4, "D-22-164", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 9.0, 16, new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 16, "Test Description Project_12", "KL-4", new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_4", 5.0, new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_12", 4.0, 863950782, new DateTime(2025, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f },
                    { 912508368, "ALPHA", 1, "D-22-1610", 0f, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 15.0, 100, new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 100, "Test Description Project_20", "KL-10", new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f, 100L, 12L, new DateTime(2024, 2, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0L, "Project_10", 5.0, new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), "Payment Detailes For Project_20", 10.0, 332159211, new DateTime(2032, 6, 24, 13, 32, 4, 434, DateTimeKind.Local).AddTicks(5462), 0f }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 726215956, 155650359, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8108), 843337313, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8109) },
                    { 578203280, 196293643, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8249), 319961209, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8250) },
                    { 726215956, 290785993, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8136), 324674934, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8137) },
                    { 578203280, 310756017, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8651), 699028334, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8652) },
                    { 578203280, 316985221, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9356), 767076471, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9357) },
                    { 578203280, 332159211, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9881), 300727092, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9882) },
                    { 726215956, 379681564, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7992), 502871706, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(7993) },
                    { 578203280, 384534673, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9703), 863248565, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9704) },
                    { 578203280, 627927396, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9178), 852815680, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9179) },
                    { 841452384, 693240275, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(59), 891942890, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(60) },
                    { 726215956, 772415579, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8080), 523182540, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8081) },
                    { 726215956, 811677337, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8053), 578570071, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8054) },
                    { 578203280, 838642208, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9529), 933409202, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9530) },
                    { 578203280, 854599066, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9000), 130255619, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9001) },
                    { 841452384, 859659347, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(987), 817322232, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(988) },
                    { 578203280, 863950782, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8830), 740796679, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8831) },
                    { 578203280, 901109343, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8469), 400696567, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8470) },
                    { 726215956, 943205830, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8026), 234537527, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8027) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 179186488, 123905373, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1776), 453956644, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1777) },
                    { 179186488, 127435055, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1674), 495616494, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1675) },
                    { 179186488, 136996438, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1208), 361084274, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1209) },
                    { 179186488, 145743972, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1313), 218401351, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1315) },
                    { 179186488, 159235310, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1383), 324244942, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1384) },
                    { 179186488, 173098106, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1348), 483152465, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1349) },
                    { 179186488, 184081553, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1582), 985058520, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1583) },
                    { 179186488, 184948307, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1476), 147226289, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1477) },
                    { 179186488, 185444822, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1640), 286064156, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1641) },
                    { 179186488, 202007496, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1753), 234019084, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1754) },
                    { 179186488, 204415246, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1503), 733148405, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1504) },
                    { 179186488, 215918817, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1764), 280287623, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1766) },
                    { 179186488, 222264435, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1371), 883583114, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1373) },
                    { 179186488, 225899476, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1742), 464957055, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1743) },
                    { 179186488, 231415274, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1278), 493098411, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1280) },
                    { 179186488, 244140393, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1267), 964729475, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1268) },
                    { 179186488, 257645015, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1697), 882387676, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1698) },
                    { 179186488, 265271030, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1156), 712395683, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1157) },
                    { 179186488, 270404176, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1395), 910265901, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1396) },
                    { 179186488, 282631077, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1172), 883105004, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1173) },
                    { 179186488, 310749537, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1360), 495083472, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1361) },
                    { 179186488, 344802859, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1787), 549345590, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1788) },
                    { 179186488, 350276876, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1430), 521708086, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1431) },
                    { 179186488, 360729564, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1144), 536905721, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1145) },
                    { 179186488, 365103920, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1571), 940233600, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1572) },
                    { 179186488, 392768135, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1183), 471220711, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1185) },
                    { 179186488, 414890217, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1537), 332873052, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1539) },
                    { 179186488, 428556273, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1594), 532989834, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1595) },
                    { 179186488, 449283553, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1628), 967020799, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1629) },
                    { 179186488, 453528097, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1708), 825451819, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1710) },
                    { 179186488, 495558138, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1418), 236608167, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1419) },
                    { 179186488, 510646361, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1441), 741502159, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1442) },
                    { 179186488, 524285203, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1465), 353657411, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1466) },
                    { 179186488, 541354868, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1832), 678315530, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1834) },
                    { 179186488, 552545930, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1290), 596439238, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1291) },
                    { 179186488, 556111382, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1798), 452772460, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1799) },
                    { 179186488, 566390103, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1720), 599669430, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1721) },
                    { 179186488, 574427316, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1617), 577883849, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1618) },
                    { 179186488, 644463951, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1549), 928759094, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1550) },
                    { 179186488, 654233651, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1651), 947617050, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1652) },
                    { 179186488, 697526943, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1821), 849930632, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1822) },
                    { 179186488, 702970468, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1453), 709976648, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1454) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 179186488, 739026502, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1492), 970485466, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1493) },
                    { 179186488, 747475928, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1686), 276151537, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1687) },
                    { 179186488, 750964812, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1731), 593967682, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1732) },
                    { 179186488, 791041151, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1526), 266419206, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1527) },
                    { 179186488, 819830109, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1325), 512305274, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1326) },
                    { 179186488, 849267368, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1243), 817928882, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1245) },
                    { 179186488, 866317472, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1560), 831038523, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1561) },
                    { 179186488, 868310537, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1232), 904396898, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1233) },
                    { 179186488, 877417532, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1195), 966337989, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1196) },
                    { 179186488, 880600506, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1302), 635224808, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1303) },
                    { 179186488, 883676066, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1810), 896732843, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1811) },
                    { 179186488, 889581597, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1515), 171790898, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1516) },
                    { 179186488, 919251942, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1337), 936739947, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1338) },
                    { 179186488, 951972933, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1255), 323151544, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1256) },
                    { 179186488, 960027372, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1406), 563721275, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1407) },
                    { 179186488, 963166693, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1220), 492483004, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1221) },
                    { 179186488, 968037365, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1663), 465140479, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1664) },
                    { 179186488, 981102813, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1606), 943910393, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1607) },
                    { 331857512, 123905373, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(901), 844907676, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(902) },
                    { 331857512, 127435055, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(790), 543423749, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(792) },
                    { 331857512, 136996438, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(310), 424403459, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(312) },
                    { 331857512, 145743972, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(418), 188651606, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(419) },
                    { 331857512, 159235310, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(493), 570113982, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(494) },
                    { 331857512, 173098106, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(454), 914253129, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(455) },
                    { 331857512, 184081553, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(696), 887555799, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(697) },
                    { 331857512, 184948307, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(587), 634869954, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(588) },
                    { 331857512, 185444822, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(755), 334998115, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(756) },
                    { 331857512, 202007496, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(878), 377561205, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(879) },
                    { 331857512, 204415246, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(611), 987068923, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(612) },
                    { 331857512, 215918817, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(889), 850557081, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(890) },
                    { 331857512, 222264435, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(481), 676206870, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(483) },
                    { 331857512, 225899476, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(866), 647491193, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(867) },
                    { 331857512, 231415274, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(382), 610174068, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(383) },
                    { 331857512, 244140393, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(371), 296137005, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(372) },
                    { 331857512, 257645015, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(814), 871701234, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(815) },
                    { 331857512, 265271030, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(262), 528594541, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(263) },
                    { 331857512, 270404176, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(505), 412167631, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(506) },
                    { 331857512, 282631077, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(274), 678357328, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(275) },
                    { 331857512, 310749537, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(466), 663629060, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(467) },
                    { 331857512, 344802859, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(913), 614603476, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(914) },
                    { 331857512, 350276876, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(540), 733637840, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(542) },
                    { 331857512, 360729564, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(244), 269125739, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(245) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 331857512, 365103920, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(684), 986496807, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(685) },
                    { 331857512, 392768135, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(286), 431930056, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(287) },
                    { 331857512, 414890217, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(648), 573157119, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(649) },
                    { 331857512, 428556273, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(708), 307475535, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(709) },
                    { 331857512, 449283553, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(743), 429724656, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(744) },
                    { 331857512, 453528097, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(829), 355985718, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(831) },
                    { 331857512, 495558138, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(529), 441350185, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(530) },
                    { 331857512, 510646361, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(552), 862594332, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(553) },
                    { 331857512, 524285203, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(576), 906841878, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(577) },
                    { 331857512, 541354868, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(960), 262202472, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(961) },
                    { 331857512, 552545930, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(394), 792953014, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(395) },
                    { 331857512, 556111382, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(925), 583853857, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(926) },
                    { 331857512, 566390103, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(842), 426140849, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(843) },
                    { 331857512, 574427316, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(732), 933292621, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(733) },
                    { 331857512, 644463951, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(660), 339170859, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(661) },
                    { 331857512, 654233651, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(767), 511821270, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(768) },
                    { 331857512, 697526943, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(949), 640765046, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(950) },
                    { 331857512, 702970468, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(564), 396159941, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(565) },
                    { 331857512, 739026502, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(599), 577758446, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(600) },
                    { 331857512, 747475928, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(802), 926499592, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(803) },
                    { 331857512, 750964812, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(854), 581528941, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(855) },
                    { 331857512, 791041151, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(635), 821511582, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(637) },
                    { 331857512, 819830109, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(429), 661513686, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(430) },
                    { 331857512, 849267368, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(346), 623481462, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(347) },
                    { 331857512, 866317472, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(673), 340010991, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(674) },
                    { 331857512, 868310537, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(334), 156629338, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(336) },
                    { 331857512, 877417532, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(297), 773750149, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(299) },
                    { 331857512, 880600506, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(406), 214453663, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(407) },
                    { 331857512, 883676066, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(936), 782801836, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(938) },
                    { 331857512, 889581597, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(623), 986356349, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(625) },
                    { 331857512, 919251942, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(441), 763081843, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(442) },
                    { 331857512, 951972933, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(359), 511955902, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(360) },
                    { 331857512, 960027372, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(517), 463299596, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(518) },
                    { 331857512, 963166693, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(323), 948659314, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(324) },
                    { 331857512, 968037365, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(779), 796089535, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(780) },
                    { 331857512, 981102813, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(720), 851022087, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(721) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 179186488, 155650359, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1121), -250918901, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1122) },
                    { 179186488, 290785993, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1132), 350202920, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1133) },
                    { 179186488, 379681564, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1072), 1453589370, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1073) },
                    { 179186488, 772415579, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1109), 1724620176, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1110) },
                    { 179186488, 811677337, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1096), 1915118874, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1097) },
                    { 179186488, 943205830, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1084), 1527795752, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1085) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 331857512, 155650359, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(218), -1110487495, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(219) },
                    { 331857512, 290785993, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(231), -432983087, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(232) },
                    { 331857512, 379681564, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(167), 2119124799, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(168) },
                    { 331857512, 772415579, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(206), -1368454409, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(207) },
                    { 331857512, 811677337, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(194), -683758763, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(195) },
                    { 331857512, 943205830, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(182), 895027046, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(184) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 179186488, -1226681395, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1037), 936991585, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1038) },
                    { 179186488, -1110644489, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1060), 836471423, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1061) },
                    { 179186488, -1040944434, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1048), 924942132, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1049) },
                    { 179186488, 1058665617, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1013), 898336302, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1014) },
                    { 179186488, 1653349426, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1025), 652684095, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1026) },
                    { 331857512, -1226681395, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(127), 638639765, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(128) },
                    { 331857512, -1110644489, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(152), 873489963, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(154) },
                    { 331857512, -1040944434, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(140), 992967307, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(141) },
                    { 331857512, 1058665617, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(95), 125300079, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(96) },
                    { 331857512, 1653349426, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(110), 412447028, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(111) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 179186488, 291923646, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1894), -680970436, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1895) },
                    { 179186488, 306492740, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1867), -764716896, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1868) },
                    { 179186488, 306962532, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1920), 1472875916, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1921) },
                    { 179186488, 364602110, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2071), 1483835531, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2072) },
                    { 179186488, 387391573, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2045), -738577225, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2046) },
                    { 179186488, 440870912, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2020), -1852116956, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2021) },
                    { 179186488, 491396297, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1995), 281126976, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1996) },
                    { 179186488, 529740413, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1970), -49486464, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1971) },
                    { 179186488, 790010109, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1944), -1893582680, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1945) },
                    { 179186488, 912508368, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2095), -1363547954, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2096) },
                    { 331857512, 291923646, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1881), 2037344430, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1882) },
                    { 331857512, 306492740, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1849), 2145153672, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1850) },
                    { 331857512, 306962532, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1906), 812295471, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1907) },
                    { 331857512, 364602110, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2057), -13380736, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2058) },
                    { 331857512, 387391573, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2032), 1605357096, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2034) },
                    { 331857512, 440870912, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2007), -1559699246, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2009) },
                    { 331857512, 491396297, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1982), 1952120736, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1983) },
                    { 331857512, 529740413, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1957), -355315912, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1958) },
                    { 331857512, 790010109, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1932), 1106477196, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(1933) },
                    { 331857512, 912508368, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2083), 1155907504, new DateTime(2024, 2, 24, 13, 32, 4, 438, DateTimeKind.Local).AddTicks(2084) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 253760523, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9238), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9240), 1003000.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9239), "Signature 1423424", 68995, 491396297, 6.0, 24.0 },
                    { 314256582, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8537), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8539), 3100.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8538), "Signature 142346", 28115, 291923646, 2.0, 24.0 },
                    { 331221389, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9944), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9946), 10000003000.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9945), "Signature 1423420", 73506, 912508368, 10.0, 24.0 },
                    { 484350637, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8713), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8715), 4000.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8714), "Signature 1423415", 15964, 306962532, 3.0, 17.0 },
                    { 607721384, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8889), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8891), 13000.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8890), "Signature 142344", 32072, 790010109, 4.0, 24.0 },
                    { 679526115, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9764), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9766), 1000003000.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9765), "Signature 1423427", 10901, 364602110, 9.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 731557489, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9592), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9594), 100003000.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9593), "Signature 1423448", 53007, 387391573, 8.0, 24.0 },
                    { 855757471, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9418), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9420), 10003000.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9419), "Signature 1423414", 88182, 440870912, 7.0, 17.0 },
                    { 859119776, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9064), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9066), 103000.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9065), "Signature 1423430", 14457, 529740413, 5.0, 17.0 },
                    { 998505592, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8338), new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8340), 3010.0, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8339), "Signature 142342", 49579, 306492740, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 137450925, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8860), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8862), null, "6949277784", null, null, 790010109 },
                    { 249194096, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9914), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9915), null, "69492777810", null, null, 912508368 },
                    { 255732728, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9210), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9211), null, "6949277786", null, null, 491396297 },
                    { 379478101, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8504), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8505), null, "6949277782", null, null, 291923646 },
                    { 407504896, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9033), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9034), null, "6949277785", null, null, 529740413 },
                    { 413922088, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9736), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9737), null, "6949277789", null, null, 364602110 },
                    { 424031970, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9564), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9565), null, "6949277788", null, null, 387391573 },
                    { 476978133, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8684), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8685), null, "6949277783", null, null, 306962532 },
                    { 495048166, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8307), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8308), null, "6949277781", null, null, 306492740 },
                    { 614390994, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9389), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9390), null, "6949277787", null, null, 440870912 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 621330370, 137450925, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8876), 792436675, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8877) },
                    { 621330370, 249194096, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9931), 703545139, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9932) },
                    { 621330370, 255732728, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9225), 967136360, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9226) },
                    { 621330370, 379478101, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8523), 963930181, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8524) },
                    { 621330370, 407504896, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9048), 764470207, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9049) },
                    { 621330370, 413922088, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9752), 599751330, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9753) },
                    { 621330370, 424031970, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9580), 405189068, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9581) },
                    { 621330370, 476978133, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8700), 546981404, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8701) },
                    { 621330370, 495048166, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8324), 209979785, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(8326) },
                    { 621330370, 614390994, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9405), 175373628, new DateTime(2024, 2, 24, 13, 32, 4, 437, DateTimeKind.Local).AddTicks(9406) }
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
