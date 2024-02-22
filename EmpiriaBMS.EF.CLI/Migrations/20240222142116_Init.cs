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
                    Hours = table.Column<double>(type: "float", nullable: true),
                    DailyHours = table.Column<double>(type: "float", nullable: true),
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
                    { 125893052, new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4613), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4614), 0.0, "Draw_10_3" },
                    { 139665511, new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4232), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4233), 0.0, "Draw_8_3" },
                    { 146925471, new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4018), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4019), 0.0, "Draw_7_3" },
                    { 152774361, new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3618), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3620), 0.0, "Draw_5_1" },
                    { 158137085, new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2882), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2884), 0.0, "Draw_1_5" },
                    { 178839290, new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4640), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4641), 0.0, "Draw_10_5" },
                    { 198466418, new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3658), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3660), 0.0, "Draw_5_4" },
                    { 238570616, new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3872), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3873), 0.0, "Draw_6_5" },
                    { 256721042, new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2840), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2841), 0.0, "Draw_1_2" },
                    { 269830243, new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3403), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3404), 0.0, "Draw_4_0" },
                    { 285464124, new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4371), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4373), 0.0, "Draw_9_0" },
                    { 296788292, new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4386), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4387), 0.0, "Draw_9_1" },
                    { 327278838, new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4031), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4032), 0.0, "Draw_7_4" },
                    { 330081083, new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3431), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3432), 0.0, "Draw_4_2" },
                    { 373296221, new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3256), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3257), 0.0, "Draw_3_4" },
                    { 380726221, new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2853), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2854), 0.0, "Draw_1_3" },
                    { 415722549, new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4005), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4006), 0.0, "Draw_7_2" },
                    { 430701459, new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3229), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3230), 0.0, "Draw_3_2" },
                    { 442459762, new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4572), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4573), 0.0, "Draw_10_0" },
                    { 451300704, new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4400), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4401), 0.0, "Draw_9_2" },
                    { 461845936, new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3471), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3472), 0.0, "Draw_4_5" },
                    { 462879092, new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4189), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4190), 0.0, "Draw_8_0" },
                    { 498989515, new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3243), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3244), 0.0, "Draw_3_3" },
                    { 504673660, new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4599), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4601), 0.0, "Draw_10_2" },
                    { 510362690, new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3020), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3021), 0.0, "Draw_2_0" },
                    { 519349586, new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4586), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4587), 0.0, "Draw_10_1" },
                    { 528288618, new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3780), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3781), 0.0, "Draw_6_0" },
                    { 546905143, new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3793), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3795), 0.0, "Draw_6_1" },
                    { 549093628, new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2804), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2805), 0.0, "Draw_1_0" },
                    { 556307592, new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3632), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3633), 0.0, "Draw_5_2" },
                    { 598537807, new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4449), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4451), 0.0, "Draw_9_4" },
                    { 602030483, new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3065), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3066), 0.0, "Draw_2_3" },
                    { 607663656, new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3444), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3445), 0.0, "Draw_4_3" },
                    { 612525974, new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3844), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3845), 0.0, "Draw_6_3" },
                    { 629954137, new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4463), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4464), 0.0, "Draw_9_5" },
                    { 644178073, new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3271), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3272), 0.0, "Draw_3_5" },
                    { 653182438, new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3216), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3217), 0.0, "Draw_3_1" },
                    { 680319773, new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3457), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3458), 0.0, "Draw_4_4" },
                    { 682851465, new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3417), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3418), 0.0, "Draw_4_1" },
                    { 684904277, new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4203), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4204), 0.0, "Draw_8_1" },
                    { 692145404, new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2825), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2826), 0.0, "Draw_1_1" },
                    { 694272270, new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3991), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3993), 0.0, "Draw_7_1" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 696002777, new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3807), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3808), 0.0, "Draw_6_2" },
                    { 696984646, new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4218), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4219), 0.0, "Draw_8_2" },
                    { 704369027, new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4045), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4046), 0.0, "Draw_7_5" },
                    { 709803572, new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3078), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3079), 0.0, "Draw_2_4" },
                    { 716706475, new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3645), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3646), 0.0, "Draw_5_3" },
                    { 720359657, new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4259), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4260), 0.0, "Draw_8_5" },
                    { 742802855, new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3034), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3036), 0.0, "Draw_2_1" },
                    { 746923127, new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4413), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4414), 0.0, "Draw_9_3" },
                    { 785446910, new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3858), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3859), 0.0, "Draw_6_4" },
                    { 797324499, new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4245), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4246), 0.0, "Draw_8_4" },
                    { 810000163, new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3049), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3050), 0.0, "Draw_2_2" },
                    { 824280733, new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3978), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3979), 0.0, "Draw_7_0" },
                    { 831198668, new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3202), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3203), 0.0, "Draw_3_0" },
                    { 836700205, new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3604), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3606), 0.0, "Draw_5_0" },
                    { 854696000, new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4626), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4627), 0.0, "Draw_10_4" },
                    { 861506547, new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3092), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3093), 0.0, "Draw_2_5" },
                    { 943919511, new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2867), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2868), 0.0, "Draw_1_4" },
                    { 985738893, new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3672), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3673), 0.0, "Draw_5_5" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1759066662, 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2563), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2565), 0.0, "Comm" },
                    { -1276710740, 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2597), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2598), 0.0, "Inside" },
                    { -746637655, 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2624), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2626), 0.0, "Administration" },
                    { 6077639, 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2610), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2611), 0.0, "Meeting" },
                    { 2086511770, 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2583), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2584), 0.0, "Printing" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 124895815, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2202), true, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2203), "CEO" },
                    { 197459777, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2173), true, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2174), "Engineer" },
                    { 307804155, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2209), false, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2210), "Guest" },
                    { 468916120, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2187), true, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2189), "COO" },
                    { 479772177, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2180), true, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2182), "Project Manager" },
                    { 483036950, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2216), false, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2217), "Customer" },
                    { 720938802, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2164), true, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2165), "Draftsmen" },
                    { 937924156, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2194), true, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2196), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 169182733, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3106), 8.0, "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3107), null, "6949277785", null, null, null },
                    { 276942530, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5687), 8.0, "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5688), null, "6949277784", null, null, null },
                    { 306256922, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4477), 8.0, "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", 80.0, "Alexandros_12", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4478), null, "69492777812", null, null, null },
                    { 323060398, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2447), 8.0, "Draftsman 2", "draftman2@gmail.com", "Platanios2", 16.0, "Alexandros2", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2448), null, "6949277782", null, null, null },
                    { 406316312, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2641), 8.0, "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2642), null, "6949277783", null, null, null },
                    { 425526117, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4058), 8.0, "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4059), null, "69492777810", null, null, null },
                    { 427510741, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3308), 8.0, "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3310), null, "6949277786", null, null, null },
                    { 481929019, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2317), 8.0, "Draftsman 0", "draftman0@gmail.com", "Platanios0", 0.0, "Alexandros0", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2318), null, "6949277780", null, null, null },
                    { 651392513, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2417), 8.0, "Draftsman 1", "draftman1@gmail.com", "Platanios1", 8.0, "Alexandros1", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2418), null, "6949277781", null, null, null },
                    { 676696702, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2476), 8.0, "Draftsman 3", "draftman3@gmail.com", "Platanios3", 24.0, "Alexandros3", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2477), null, "6949277783", null, null, null },
                    { 747245893, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2896), 8.0, "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2898), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 747688306, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3885), 8.0, "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3886), null, "6949277789", null, null, null },
                    { 779856501, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4272), 8.0, "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4273), null, "69492777811", null, null, null },
                    { 788498220, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2535), 8.0, "Draftsman 5", "draftman5@gmail.com", "Platanios5", 40.0, "Alexandros5", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2536), null, "6949277785", null, null, null },
                    { 840663822, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3484), 8.0, "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3485), null, "6949277787", null, null, null },
                    { 858049090, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4657), 8.0, "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4658), null, "6949277783", null, null, null },
                    { 927731480, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2504), 8.0, "Draftsman 4", "draftman4@gmail.com", "Platanios4", 32.0, "Alexandros4", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2505), null, "6949277784", null, null, null },
                    { 970673651, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3686), 8.0, "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3687), null, "6949277788", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1924286368, 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4689), 858049090, 2345L, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4691), 3425L, "ELEC" },
                    { 1222175032, 0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5718), 276942530, 2345L, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5719), 3425L, "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 307354387, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 15.0, 100, new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 100, "Test Description Project_10", "KL-10", new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 125L, 1000L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_10", 5.0, new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_60", 10.0, 306256922, new DateTime(2032, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 },
                    { 394703487, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 13.0, 64, new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 64, "Test Description Project_32", "KL-8", new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 64L, 512L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_8", 5.0, new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_32", 8.0, 425526117, new DateTime(2029, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 },
                    { 400738007, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 10.0, 25, new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 25, "Test Description Project_15", "KL-5", new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 16L, 125L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_5", 5.0, new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_10", 5.0, 840663822, new DateTime(2026, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 },
                    { 435442666, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 12.0, 49, new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 49, "Test Description Project_21", "KL-7", new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 43L, 343L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_7", 5.0, new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_7", 7.0, 747688306, new DateTime(2028, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 },
                    { 480861795, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 7.0, 4, new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 1L, 8L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_2", 5.0, new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_2", 2.0, 747245893, new DateTime(2024, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 },
                    { 626823316, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 6.0, 1, new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, 1L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_1", 5.0, new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_3", 1.0, 406316312, new DateTime(2024, 3, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 },
                    { 756044697, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 11.0, 36, new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 36, "Test Description Project_12", "KL-6", new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 27L, 216L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_6", 5.0, new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_30", 6.0, 970673651, new DateTime(2027, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 },
                    { 837218798, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 9.0, 16, new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 16, "Test Description Project_12", "KL-4", new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 8L, 64L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_4", 5.0, new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_8", 4.0, 427510741, new DateTime(2025, 6, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 },
                    { 898778512, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 8.0, 9, new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 9, "Test Description Project_6", "KL-3", new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 3L, 27L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_3", 5.0, new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_12", 3.0, 169182733, new DateTime(2024, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 },
                    { 929553021, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 14.0, 81, new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 81, "Test Description Project_36", "KL-9", new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 91L, 729L, new DateTime(2024, 2, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0L, "Project_9", 5.0, new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), "Payment Detailes For Project_45", 9.0, 779856501, new DateTime(2030, 11, 22, 16, 21, 15, 848, DateTimeKind.Local).AddTicks(4735), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 479772177, 169182733, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3122), 462370258, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3123) },
                    { 197459777, 276942530, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5705), 288959414, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5706) },
                    { 479772177, 306256922, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4493), 958734877, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4494) },
                    { 720938802, 323060398, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2463), 162495701, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2464) },
                    { 479772177, 406316312, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2685), 240338000, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2687) },
                    { 479772177, 425526117, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4075), 891985895, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4076) },
                    { 479772177, 427510741, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3325), 960464048, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3326) },
                    { 720938802, 481929019, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2394), 285317996, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2395) },
                    { 720938802, 651392513, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2434), 909481543, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2435) },
                    { 720938802, 676696702, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2491), 487250709, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2492) },
                    { 479772177, 747245893, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2914), 966810010, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2915) },
                    { 479772177, 747688306, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3901), 674241990, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3902) },
                    { 479772177, 779856501, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4288), 680332776, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4289) },
                    { 720938802, 788498220, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2550), 657467078, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2551) },
                    { 479772177, 840663822, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3499), 486114063, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3500) },
                    { 197459777, 858049090, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4676), 713728479, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4677) },
                    { 720938802, 927731480, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2521), 610717909, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2522) },
                    { 479772177, 970673651, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3702), 323475199, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3704) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1924286368, 125893052, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5650), 453306137, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5651) },
                    { -1924286368, 139665511, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5478), 556543795, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5479) },
                    { -1924286368, 146925471, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5406), 647793163, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5407) },
                    { -1924286368, 152774361, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5234), 540901635, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5236) },
                    { -1924286368, 158137085, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4964), 842974736, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4965) },
                    { -1924286368, 178839290, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5674), 522244237, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5676) },
                    { -1924286368, 198466418, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5271), 508625751, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5272) },
                    { -1924286368, 238570616, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5357), 420412831, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5358) },
                    { -1924286368, 256721042, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4926), 873520146, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4927) },
                    { -1924286368, 269830243, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5147), 507100141, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5148) },
                    { -1924286368, 285464124, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5541), 323994261, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5543) },
                    { -1924286368, 296788292, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5554), 177199519, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5555) },
                    { -1924286368, 327278838, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5418), 755047579, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5419) },
                    { -1924286368, 330081083, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5173), 194031386, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5174) },
                    { -1924286368, 373296221, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5099), 470629670, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5100) },
                    { -1924286368, 380726221, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4938), 318515538, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4939) },
                    { -1924286368, 415722549, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5393), 393025691, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5395) },
                    { -1924286368, 430701459, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5075), 216790504, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5076) },
                    { -1924286368, 442459762, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5614), 133152032, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5615) },
                    { -1924286368, 451300704, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5566), 569995518, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5567) },
                    { -1924286368, 461845936, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5210), 752173132, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5211) },
                    { -1924286368, 462879092, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5442), 977930179, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5443) },
                    { -1924286368, 498989515, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5087), 769059570, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5088) },
                    { -1924286368, 504673660, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5638), 491955015, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5639) },
                    { -1924286368, 510362690, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4976), 375667197, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4977) },
                    { -1924286368, 519349586, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5626), 214109777, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5627) },
                    { -1924286368, 528288618, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5295), 670342724, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5296) },
                    { -1924286368, 546905143, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5308), 757436124, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5309) },
                    { -1924286368, 549093628, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4896), 969810432, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4898) },
                    { -1924286368, 556307592, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5247), 183864344, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5248) },
                    { -1924286368, 598537807, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5590), 468188748, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5591) },
                    { -1924286368, 602030483, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5014), 889567597, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5015) },
                    { -1924286368, 607663656, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5186), 908042282, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5187) },
                    { -1924286368, 612525974, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5333), 748993029, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5334) },
                    { -1924286368, 629954137, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5602), 700694645, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5603) },
                    { -1924286368, 644178073, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5113), 586513770, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5114) },
                    { -1924286368, 653182438, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5063), 758393006, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5064) },
                    { -1924286368, 680319773, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5198), 501807506, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5199) },
                    { -1924286368, 682851465, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5160), 164573834, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5161) },
                    { -1924286368, 684904277, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5454), 317666112, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5455) },
                    { -1924286368, 692145404, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4913), 520706111, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4914) },
                    { -1924286368, 694272270, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5381), 308902696, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5382) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1924286368, 696002777, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5320), 183831393, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5321) },
                    { -1924286368, 696984646, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5466), 998237952, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5468) },
                    { -1924286368, 704369027, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5430), 278297380, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5431) },
                    { -1924286368, 709803572, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5026), 178565388, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5027) },
                    { -1924286368, 716706475, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5259), 249772970, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5260) },
                    { -1924286368, 720359657, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5529), 694590487, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5530) },
                    { -1924286368, 742802855, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4989), 423641563, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4990) },
                    { -1924286368, 746923127, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5578), 199601491, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5579) },
                    { -1924286368, 785446910, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5345), 845429693, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5346) },
                    { -1924286368, 797324499, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5490), 826101768, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5491) },
                    { -1924286368, 810000163, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5001), 885627851, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5002) },
                    { -1924286368, 824280733, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5369), 407319177, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5370) },
                    { -1924286368, 831198668, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5051), 508846950, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5052) },
                    { -1924286368, 836700205, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5222), 876416717, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5223) },
                    { -1924286368, 854696000, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5662), 770922808, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5663) },
                    { -1924286368, 861506547, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5038), 195490711, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5039) },
                    { -1924286368, 943919511, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4950), 234324635, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4951) },
                    { -1924286368, 985738893, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5283), 457500588, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5284) },
                    { 1222175032, 125893052, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6677), 149830421, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6678) },
                    { 1222175032, 139665511, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6533), 587441576, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6534) },
                    { 1222175032, 146925471, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6461), 847514190, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6462) },
                    { 1222175032, 152774361, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6250), 271583770, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6251) },
                    { 1222175032, 158137085, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6008), 670853887, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6009) },
                    { 1222175032, 178839290, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6748), 166970425, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6749) },
                    { 1222175032, 198466418, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6325), 886309573, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6326) },
                    { 1222175032, 238570616, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6412), 247338540, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6413) },
                    { 1222175032, 256721042, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5969), 416127375, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5970) },
                    { 1222175032, 269830243, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6165), 180827926, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6166) },
                    { 1222175032, 285464124, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6569), 860485377, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6570) },
                    { 1222175032, 296788292, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6581), 239813478, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6582) },
                    { 1222175032, 327278838, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6473), 161990593, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6474) },
                    { 1222175032, 330081083, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6189), 197366346, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6191) },
                    { 1222175032, 373296221, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6141), 798586748, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6142) },
                    { 1222175032, 380726221, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5982), 800852423, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5983) },
                    { 1222175032, 415722549, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6449), 548568892, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6450) },
                    { 1222175032, 430701459, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6117), 801183129, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6118) },
                    { 1222175032, 442459762, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6641), 363080328, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6642) },
                    { 1222175032, 451300704, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6593), 754294588, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6594) },
                    { 1222175032, 461845936, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6226), 967959083, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6227) },
                    { 1222175032, 462879092, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6497), 760134489, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6498) },
                    { 1222175032, 498989515, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6129), 266661512, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6130) },
                    { 1222175032, 504673660, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6665), 151720468, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6666) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1222175032, 510362690, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6020), 437383884, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6021) },
                    { 1222175032, 519349586, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6653), 628089960, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6654) },
                    { 1222175032, 528288618, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6350), 825745859, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6351) },
                    { 1222175032, 546905143, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6363), 577180028, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6364) },
                    { 1222175032, 549093628, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5872), 352541781, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5873) },
                    { 1222175032, 556307592, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6262), 470147275, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6263) },
                    { 1222175032, 598537807, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6617), 507688581, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6618) },
                    { 1222175032, 602030483, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6057), 532003696, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6058) },
                    { 1222175032, 607663656, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6202), 465440592, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6203) },
                    { 1222175032, 612525974, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6387), 378298884, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6388) },
                    { 1222175032, 629954137, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6629), 507321096, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6630) },
                    { 1222175032, 644178073, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6153), 956174475, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6154) },
                    { 1222175032, 653182438, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6105), 453032504, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6106) },
                    { 1222175032, 680319773, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6214), 285801348, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6215) },
                    { 1222175032, 682851465, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6178), 505588753, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6179) },
                    { 1222175032, 684904277, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6509), 620002310, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6510) },
                    { 1222175032, 692145404, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5956), 503699122, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5957) },
                    { 1222175032, 694272270, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6436), 374945908, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6437) },
                    { 1222175032, 696002777, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6375), 780934179, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6376) },
                    { 1222175032, 696984646, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6521), 398706892, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6522) },
                    { 1222175032, 704369027, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6485), 276315437, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6486) },
                    { 1222175032, 709803572, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6068), 244757544, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6070) },
                    { 1222175032, 716706475, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6274), 746917269, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6275) },
                    { 1222175032, 720359657, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6557), 213074179, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6558) },
                    { 1222175032, 742802855, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6032), 578667288, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6034) },
                    { 1222175032, 746923127, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6605), 996815031, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6606) },
                    { 1222175032, 785446910, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6399), 831932890, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6400) },
                    { 1222175032, 797324499, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6545), 921101737, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6546) },
                    { 1222175032, 810000163, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6044), 983793543, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6045) },
                    { 1222175032, 824280733, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6424), 730721633, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6425) },
                    { 1222175032, 831198668, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6093), 156594974, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6094) },
                    { 1222175032, 836700205, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6237), 726463045, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6238) },
                    { 1222175032, 854696000, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6689), 446714353, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6690) },
                    { 1222175032, 861506547, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6080), 462175534, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6082) },
                    { 1222175032, 943919511, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5994), 710694199, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5995) },
                    { 1222175032, 985738893, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6338), 348049369, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6339) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1924286368, 323060398, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4843), 1182762576, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4844) },
                    { -1924286368, 481929019, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4810), 302895289, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4811) },
                    { -1924286368, 651392513, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4829), 1459041228, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4830) },
                    { -1924286368, 676696702, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4856), -1064576591, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4857) },
                    { -1924286368, 788498220, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4882), 336445624, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4883) },
                    { -1924286368, 927731480, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4869), -1320640685, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4870) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1222175032, 323060398, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5820), -1884257203, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5821) },
                    { 1222175032, 481929019, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5794), -1856035421, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5795) },
                    { 1222175032, 651392513, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5807), 1905222717, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5808) },
                    { 1222175032, 676696702, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5834), -1593262655, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5835) },
                    { 1222175032, 788498220, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5859), -601318885, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5860) },
                    { 1222175032, 927731480, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5846), -813267184, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5847) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1924286368, -1759066662, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4709), 743800433, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4710) },
                    { -1924286368, -1276710740, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4768), 570540409, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4769) },
                    { -1924286368, -746637655, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4795), 143786592, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4796) },
                    { -1924286368, 6077639, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4781), 551753691, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4782) },
                    { -1924286368, 2086511770, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4754), 427246805, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4755) },
                    { 1222175032, -1759066662, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5731), 810995907, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5732) },
                    { 1222175032, -1276710740, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5756), 865318058, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5757) },
                    { 1222175032, -746637655, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5781), 366140572, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5782) },
                    { 1222175032, 6077639, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5768), 556343995, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5769) },
                    { 1222175032, 2086511770, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5744), 565060180, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(5745) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1924286368, 307354387, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6999), -1687288971, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(7000) },
                    { -1924286368, 394703487, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6947), 152652286, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6949) },
                    { -1924286368, 400738007, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6871), 460938915, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6872) },
                    { -1924286368, 435442666, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6922), 949424704, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6923) },
                    { -1924286368, 480861795, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6793), -535937740, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6794) },
                    { -1924286368, 626823316, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6763), -1734199744, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6764) },
                    { -1924286368, 756044697, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6897), -1187619493, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6898) },
                    { -1924286368, 837218798, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6845), -460446428, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6847) },
                    { -1924286368, 898778512, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6819), 496528636, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6820) },
                    { -1924286368, 929553021, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6973), -678580190, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6974) },
                    { 1222175032, 307354387, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(7011), 1422218398, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(7012) },
                    { 1222175032, 394703487, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6960), -720252822, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6961) },
                    { 1222175032, 400738007, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6884), -828452470, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6885) },
                    { 1222175032, 435442666, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6934), -1517391366, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6936) },
                    { 1222175032, 480861795, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6806), -1430061644, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6807) },
                    { 1222175032, 626823316, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6780), 1704721442, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6781) },
                    { 1222175032, 756044697, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6909), 59960781, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6910) },
                    { 1222175032, 837218798, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6858), -1616084982, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6859) },
                    { 1222175032, 898778512, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6832), -1333710997, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6833) },
                    { 1222175032, 929553021, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6986), 1623824508, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(6987) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 164445401, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3764), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3766), 1003000.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3765), "Signature 1423418", 57255, 756044697, 6.0, 24.0 },
                    { 184237846, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2778), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2781), 3010.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2780), "Signature 142342", 70516, 626823316, 1.0, 17.0 },
                    { 289350206, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3586), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3589), 103000.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3588), "Signature 142345", 80716, 400738007, 5.0, 17.0 },
                    { 342279965, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3387), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3389), 13000.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3388), "Signature 1423424", 52765, 837218798, 4.0, 24.0 },
                    { 445261619, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3185), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3187), 4000.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3186), "Signature 1423418", 70995, 898778512, 3.0, 17.0 },
                    { 588805324, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4355), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4357), 1000003000.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4356), "Signature 1423436", 48745, 929553021, 9.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 647971784, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3000), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3003), 3100.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3002), "Signature 1423410", 39608, 480861795, 2.0, 24.0 },
                    { 789964672, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3962), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3964), 10003000.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3963), "Signature 1423435", 68335, 435442666, 7.0, 17.0 },
                    { 892949054, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4173), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4175), 100003000.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4174), "Signature 1423440", 18321, 394703487, 8.0, 24.0 },
                    { 916894366, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4555), new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4557), 10000003000.0, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4556), "Signature 1423430", 85424, 307354387, 10.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 255997077, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4143), null, "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4144), null, "6949277788", null, null, 394703487 },
                    { 271919370, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4526), null, "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", null, "Alexandros_10", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4528), null, "69492777810", null, null, 307354387 },
                    { 389923812, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3735), null, "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3736), null, "6949277786", null, null, 756044697 },
                    { 466828908, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3359), null, "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3360), null, "6949277784", null, null, 837218798 },
                    { 484762031, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2745), null, "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2747), null, "6949277781", null, null, 626823316 },
                    { 549500956, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4326), null, "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", null, "Alexandros_9", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4327), null, "6949277789", null, null, 929553021 },
                    { 596244672, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3156), null, "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3157), null, "6949277783", null, null, 898778512 },
                    { 596514385, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3934), null, "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3935), null, "6949277787", null, null, 435442666 },
                    { 711503414, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2950), null, "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2951), null, "6949277782", null, null, 480861795 },
                    { 859141528, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3532), null, "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3533), null, "6949277785", null, null, 400738007 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 483036950, 255997077, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4160), 728591367, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4161) },
                    { 483036950, 271919370, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4542), 784731269, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4544) },
                    { 483036950, 389923812, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3751), 438171238, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3752) },
                    { 483036950, 466828908, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3375), 201430597, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3376) },
                    { 483036950, 484762031, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2764), 521918230, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2766) },
                    { 483036950, 549500956, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4342), 740554412, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(4343) },
                    { 483036950, 596244672, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3171), 544994671, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3172) },
                    { 483036950, 596514385, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3949), 659110882, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3951) },
                    { 483036950, 711503414, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2965), 223750668, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(2966) },
                    { 483036950, 859141528, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3548), 669180039, new DateTime(2024, 2, 22, 16, 21, 15, 852, DateTimeKind.Local).AddTicks(3550) }
                });

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
