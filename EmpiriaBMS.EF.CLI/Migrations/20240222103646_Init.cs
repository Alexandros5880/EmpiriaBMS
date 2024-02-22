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
                    { 136795798, new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2831), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2832), 0.0, "Draw_7_0" },
                    { 140863295, new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2417), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2418), 0.0, "Draw_5_1" },
                    { 152820258, new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2432), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2433), 0.0, "Draw_5_2" },
                    { 154257295, new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2209), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2210), 0.0, "Draw_4_0" },
                    { 185002456, new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3463), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3465), 0.0, "Draw_10_0" },
                    { 215037265, new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2861), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2862), 0.0, "Draw_7_2" },
                    { 248382408, new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3509), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3510), 0.0, "Draw_10_3" },
                    { 264457419, new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3020), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3021), 0.0, "Draw_8_0" },
                    { 272785421, new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3090), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3091), 0.0, "Draw_8_3" },
                    { 281089228, new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2646), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2648), 0.0, "Draw_6_2" },
                    { 296051370, new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2678), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2679), 0.0, "Draw_6_4" },
                    { 296262855, new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1772), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1773), 0.0, "Draw_2_0" },
                    { 300431977, new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2891), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2892), 0.0, "Draw_7_4" },
                    { 312057329, new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2846), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2847), 0.0, "Draw_7_1" },
                    { 317547701, new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3524), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3526), 0.0, "Draw_10_4" },
                    { 317870601, new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3479), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3480), 0.0, "Draw_10_1" },
                    { 340474225, new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2693), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2694), 0.0, "Draw_6_5" },
                    { 364313149, new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2038), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2039), 0.0, "Draw_3_3" },
                    { 364452338, new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2402), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2403), 0.0, "Draw_5_0" },
                    { 385065556, new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1648), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1649), 0.0, "Draw_1_5" },
                    { 403781917, new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3283), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3284), 0.0, "Draw_9_3" },
                    { 409943118, new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2008), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2010), 0.0, "Draw_3_1" },
                    { 467212888, new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2240), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2241), 0.0, "Draw_4_2" },
                    { 488045171, new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3298), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3299), 0.0, "Draw_9_4" },
                    { 501570806, new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1804), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1805), 0.0, "Draw_2_2" },
                    { 528184246, new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2631), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2633), 0.0, "Draw_6_1" },
                    { 538376701, new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2446), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2448), 0.0, "Draw_5_3" },
                    { 542336325, new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2070), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2071), 0.0, "Draw_3_5" },
                    { 554016310, new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3268), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3270), 0.0, "Draw_9_2" },
                    { 565309727, new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1860), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1861), 0.0, "Draw_2_4" },
                    { 577459944, new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3120), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3121), 0.0, "Draw_8_5" },
                    { 621577360, new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2224), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2225), 0.0, "Draw_4_1" },
                    { 644072617, new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2270), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2271), 0.0, "Draw_4_4" },
                    { 647945026, new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2876), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2877), 0.0, "Draw_7_3" },
                    { 649235027, new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2255), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2256), 0.0, "Draw_4_3" },
                    { 663050170, new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1602), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1603), 0.0, "Draw_1_2" },
                    { 695357408, new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2461), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2462), 0.0, "Draw_5_4" },
                    { 710605392, new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1586), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1587), 0.0, "Draw_1_1" },
                    { 716381046, new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1876), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1877), 0.0, "Draw_2_5" },
                    { 741102922, new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3105), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3106), 0.0, "Draw_8_4" },
                    { 751601582, new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2905), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2906), 0.0, "Draw_7_5" },
                    { 754491145, new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3035), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3037), 0.0, "Draw_8_1" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 774244312, new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2500), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2501), 0.0, "Draw_5_5" },
                    { 805797818, new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2616), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2617), 0.0, "Draw_6_0" },
                    { 827162963, new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2023), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2024), 0.0, "Draw_3_2" },
                    { 836084373, new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2053), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2054), 0.0, "Draw_3_4" },
                    { 853932493, new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2663), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2664), 0.0, "Draw_6_3" },
                    { 879344575, new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3238), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3239), 0.0, "Draw_9_0" },
                    { 886640866, new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1993), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1994), 0.0, "Draw_3_0" },
                    { 889719230, new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3494), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3495), 0.0, "Draw_10_2" },
                    { 893877102, new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1820), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1822), 0.0, "Draw_2_3" },
                    { 908192412, new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3313), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3314), 0.0, "Draw_9_5" },
                    { 918714283, new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1631), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1633), 0.0, "Draw_1_4" },
                    { 924439585, new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3050), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3051), 0.0, "Draw_8_2" },
                    { 953678601, new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2284), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2286), 0.0, "Draw_4_5" },
                    { 970331932, new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1788), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1789), 0.0, "Draw_2_1" },
                    { 974963744, new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3539), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3540), 0.0, "Draw_10_5" },
                    { 992449894, new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3254), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3255), 0.0, "Draw_9_1" },
                    { 993481001, new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1564), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1566), 0.0, "Draw_1_0" },
                    { 998819618, new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1617), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1618), 0.0, "Draw_1_3" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1169043030, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1378), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1379), 0.0, "Administration" },
                    { -666305099, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1335), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1336), 0.0, "Printing" },
                    { -191542547, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1349), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1351), 0.0, "Outside" },
                    { 92944843, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1313), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1315), 0.0, "Comm" },
                    { 248312869, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1364), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1365), 0.0, "Meeting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 172219694, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(926), true, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(927), "COO" },
                    { 281832184, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(919), true, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(920), "Project Manager" },
                    { 386471429, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(947), false, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(948), "Guest" },
                    { 453527565, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(933), true, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(934), "CTO" },
                    { 533620239, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(903), true, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(904), "Draftsmen" },
                    { 723816604, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(954), false, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(955), "Customer" },
                    { 810549321, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(940), true, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(941), "CEO" },
                    { 814070974, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(911), true, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(913), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 130761390, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1664), 8.0, "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1665), null, "6949277784", null, null, null },
                    { 157003857, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1249), 8.0, "Draftsman 4", "draftman4@gmail.com", "Platanios4", 32.0, "Alexandros4", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1250), null, "6949277784", null, null, null },
                    { 181279374, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4641), 8.0, "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4642), null, "6949277784", null, null, null },
                    { 185440021, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1188), 8.0, "Draftsman 2", "draftman2@gmail.com", "Platanios2", 16.0, "Alexandros2", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1189), null, "6949277782", null, null, null },
                    { 223565670, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2516), 8.0, "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2517), null, "6949277788", null, null, null },
                    { 338380814, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2086), 8.0, "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2087), null, "6949277786", null, null, null },
                    { 441516604, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2921), 8.0, "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2922), null, "69492777810", null, null, null },
                    { 451401070, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3556), 8.0, "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3558), null, "6949277783", null, null, null },
                    { 552960366, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1130), 8.0, "Draftsman 1", "draftman1@gmail.com", "Platanios1", 8.0, "Alexandros1", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1131), null, "6949277781", null, null, null },
                    { 635235719, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1219), 8.0, "Draftsman 3", "draftman3@gmail.com", "Platanios3", 24.0, "Alexandros3", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1220), null, "6949277783", null, null, null },
                    { 677509366, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1282), 8.0, "Draftsman 5", "draftman5@gmail.com", "Platanios5", 40.0, "Alexandros5", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1283), null, "6949277785", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 706450140, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3135), 8.0, "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3136), null, "69492777811", null, null, null },
                    { 762395180, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1058), 8.0, "Draftsman 0", "draftman0@gmail.com", "Platanios0", 0.0, "Alexandros0", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1060), null, "6949277780", null, null, null },
                    { 763332501, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2708), 8.0, "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2709), null, "6949277789", null, null, null },
                    { 868179525, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1395), 8.0, "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1397), null, "6949277783", null, null, null },
                    { 885311764, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1892), 8.0, "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1893), null, "6949277785", null, null, null },
                    { 909556150, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2300), 8.0, "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2301), null, "6949277787", null, null, null },
                    { 965401171, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3328), 8.0, "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", 80.0, "Alexandros_12", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3329), null, "69492777812", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1029524592, 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3593), 451401070, 2345L, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3594), 3425L, "ELEC" },
                    { -756168488, 0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4672), 181279374, 2345L, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4673), 3425L, "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 225935636, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 14.0, 81, new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 81, "Test Description Project_36", "KL-9", new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 91L, 729L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_9", 5.0, new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_45", 9.0, 706450140, new DateTime(2030, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 },
                    { 232295779, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 9.0, 16, new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 16, "Test Description Project_20", "KL-4", new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 8L, 64L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_4", 5.0, new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_16", 4.0, 338380814, new DateTime(2025, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 },
                    { 290767462, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 13.0, 64, new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 64, "Test Description Project_8", "KL-8", new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 64L, 512L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_8", 5.0, new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_32", 8.0, 441516604, new DateTime(2029, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 },
                    { 307125063, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 11.0, 36, new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 36, "Test Description Project_12", "KL-6", new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 27L, 216L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_6", 5.0, new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_6", 6.0, 223565670, new DateTime(2027, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 },
                    { 378553437, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 7.0, 4, new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 4, "Test Description Project_2", "KL-2", new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 1L, 8L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_2", 5.0, new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_10", 2.0, 130761390, new DateTime(2024, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 },
                    { 489504497, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 8.0, 9, new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 9, "Test Description Project_15", "KL-3", new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 3L, 27L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_3", 5.0, new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_6", 3.0, 885311764, new DateTime(2024, 11, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 },
                    { 581296924, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 15.0, 100, new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 100, "Test Description Project_60", "KL-10", new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 125L, 1000L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_10", 5.0, new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_60", 10.0, 965401171, new DateTime(2032, 6, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 },
                    { 606672875, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 10.0, 25, new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 25, "Test Description Project_30", "KL-5", new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 16L, 125L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_5", 5.0, new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_5", 5.0, 909556150, new DateTime(2026, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 },
                    { 788713125, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 6.0, 1, new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 1, "Test Description Project_5", "KL-1", new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, 1L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_1", 5.0, new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_3", 1.0, 868179525, new DateTime(2024, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 },
                    { 951796659, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 12.0, 49, new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 49, "Test Description Project_42", "KL-7", new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 43L, 343L, new DateTime(2024, 2, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0L, "Project_7", 5.0, new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), "Payment Detailes For Project_28", 7.0, 763332501, new DateTime(2028, 3, 22, 12, 36, 45, 652, DateTimeKind.Local).AddTicks(8757), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 281832184, 130761390, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1682), 495139339, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1683) },
                    { 533620239, 157003857, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1267), 564060741, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1269) },
                    { 814070974, 181279374, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4658), 837264974, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4659) },
                    { 533620239, 185440021, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1205), 202210797, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1206) },
                    { 281832184, 223565670, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2534), 283505632, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2535) },
                    { 281832184, 338380814, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2102), 692587913, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2104) },
                    { 281832184, 441516604, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2939), 645056094, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2940) },
                    { 814070974, 451401070, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3576), 424725199, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3578) },
                    { 533620239, 552960366, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1173), 327189260, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1174) },
                    { 533620239, 635235719, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1235), 903828823, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1236) },
                    { 533620239, 677509366, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1299), 507362424, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1300) },
                    { 281832184, 706450140, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3152), 329935382, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3153) },
                    { 533620239, 762395180, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1113), 797577210, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1115) },
                    { 281832184, 763332501, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2724), 846141637, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2726) },
                    { 281832184, 868179525, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1418), 336439824, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1420) },
                    { 281832184, 885311764, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1909), 775163545, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1910) },
                    { 281832184, 909556150, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2317), 649439247, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2318) },
                    { 281832184, 965401171, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3344), 505198732, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3345) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1029524592, 136795798, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4309), 786199861, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4310) },
                    { -1029524592, 140863295, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4136), 943832104, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4137) },
                    { -1029524592, 152820258, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4174), 533545349, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4175) },
                    { -1029524592, 154257295, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4045), 397607344, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4046) },
                    { -1029524592, 185002456, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4541), 681067862, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4542) },
                    { -1029524592, 215037265, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4335), 975348487, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4336) },
                    { -1029524592, 248382408, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4603), 261290470, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4604) },
                    { -1029524592, 264457419, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4387), 877774870, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4388) },
                    { -1029524592, 272785421, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4425), 934405849, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4426) },
                    { -1029524592, 281089228, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4256), 594823262, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4257) },
                    { -1029524592, 296051370, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4283), 970948481, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4284) },
                    { -1029524592, 296262855, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3889), 819556391, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3890) },
                    { -1029524592, 300431977, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4361), 145640152, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4362) },
                    { -1029524592, 312057329, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4322), 881342708, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4323) },
                    { -1029524592, 317547701, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4615), 441203295, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4616) },
                    { -1029524592, 317870601, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4577), 513740036, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4578) },
                    { -1029524592, 340474225, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4296), 394624078, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4297) },
                    { -1029524592, 364313149, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4006), 421052429, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4007) },
                    { -1029524592, 364452338, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4122), 583149528, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4124) },
                    { -1029524592, 385065556, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3876), 371823423, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3877) },
                    { -1029524592, 403781917, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4503), 797541628, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4504) },
                    { -1029524592, 409943118, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3980), 485273300, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3981) },
                    { -1029524592, 467212888, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4071), 786431472, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4072) },
                    { -1029524592, 488045171, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4515), 656209631, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4516) },
                    { -1029524592, 501570806, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3915), 794483517, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3916) },
                    { -1029524592, 528184246, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4243), 191757948, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4244) },
                    { -1029524592, 538376701, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4190), 160772829, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4191) },
                    { -1029524592, 542336325, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4032), 389951470, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4033) },
                    { -1029524592, 554016310, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4490), 831685891, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4491) },
                    { -1029524592, 565309727, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3941), 874910438, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3942) },
                    { -1029524592, 577459944, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4451), 568213227, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4452) },
                    { -1029524592, 621577360, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4058), 703360502, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4059) },
                    { -1029524592, 644072617, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4097), 948727603, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4098) },
                    { -1029524592, 647945026, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4348), 917802275, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4349) },
                    { -1029524592, 649235027, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4084), 585738498, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4085) },
                    { -1029524592, 663050170, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3836), 466462499, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3837) },
                    { -1029524592, 695357408, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4204), 431761328, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4205) },
                    { -1029524592, 710605392, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3822), 762452120, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3824) },
                    { -1029524592, 716381046, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3954), 720652743, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3955) },
                    { -1029524592, 741102922, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4438), 602179124, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4439) },
                    { -1029524592, 751601582, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4374), 953081123, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4375) },
                    { -1029524592, 754491145, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4399), 176798939, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4401) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1029524592, 774244312, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4217), 783972114, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4218) },
                    { -1029524592, 805797818, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4230), 702913521, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4231) },
                    { -1029524592, 827162963, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3993), 661121904, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3994) },
                    { -1029524592, 836084373, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4019), 344733013, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4020) },
                    { -1029524592, 853932493, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4270), 706116574, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4271) },
                    { -1029524592, 879344575, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4464), 486454771, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4465) },
                    { -1029524592, 886640866, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3967), 663704535, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3968) },
                    { -1029524592, 889719230, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4590), 430147576, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4591) },
                    { -1029524592, 893877102, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3928), 962812424, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3929) },
                    { -1029524592, 908192412, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4528), 185699804, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4529) },
                    { -1029524592, 918714283, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3862), 866311664, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3863) },
                    { -1029524592, 924439585, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4412), 879384177, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4413) },
                    { -1029524592, 953678601, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4110), 405948708, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4111) },
                    { -1029524592, 970331932, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3902), 524114544, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3903) },
                    { -1029524592, 974963744, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4628), 873638152, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4629) },
                    { -1029524592, 992449894, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4477), 522923905, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4478) },
                    { -1029524592, 993481001, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3803), 908508551, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3804) },
                    { -1029524592, 998819618, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3849), 257314792, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3850) },
                    { -756168488, 136795798, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5334), 520753780, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5335) },
                    { -756168488, 140863295, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5172), 907479400, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5173) },
                    { -756168488, 152820258, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5185), 389401989, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5186) },
                    { -756168488, 154257295, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5084), 988146668, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5085) },
                    { -756168488, 185002456, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5561), 983951213, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5562) },
                    { -756168488, 215037265, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5360), 864166877, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5361) },
                    { -756168488, 248382408, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5599), 269725333, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5600) },
                    { -756168488, 264457419, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5411), 176464508, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5412) },
                    { -756168488, 272785421, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5448), 369770577, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5449) },
                    { -756168488, 281089228, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5260), 669271703, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5261) },
                    { -756168488, 296051370, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5285), 458986847, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5286) },
                    { -756168488, 296262855, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4932), 972767506, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4933) },
                    { -756168488, 300431977, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5385), 847884197, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5387) },
                    { -756168488, 312057329, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5347), 878909265, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5348) },
                    { -756168488, 317547701, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5611), 733311153, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5612) },
                    { -756168488, 317870601, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5574), 832859961, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5575) },
                    { -756168488, 340474225, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5297), 975975564, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5298) },
                    { -756168488, 364313149, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5046), 839447583, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5047) },
                    { -756168488, 364452338, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5160), 774397827, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5161) },
                    { -756168488, 385065556, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4919), 713156502, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4920) },
                    { -756168488, 403781917, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5523), 333415541, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5525) },
                    { -756168488, 409943118, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5021), 153010621, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5022) },
                    { -756168488, 467212888, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5109), 506944517, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5110) },
                    { -756168488, 488045171, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5536), 147215388, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5537) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -756168488, 501570806, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4958), 253917817, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4959) },
                    { -756168488, 528184246, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5247), 279154763, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5249) },
                    { -756168488, 538376701, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5197), 766456461, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5199) },
                    { -756168488, 542336325, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5071), 131690535, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5072) },
                    { -756168488, 554016310, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5511), 913763444, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5512) },
                    { -756168488, 565309727, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4983), 668753510, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4984) },
                    { -756168488, 577459944, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5473), 600191882, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5475) },
                    { -756168488, 621577360, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5096), 227988120, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5097) },
                    { -756168488, 644072617, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5135), 240865046, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5136) },
                    { -756168488, 647945026, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5373), 820590649, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5374) },
                    { -756168488, 649235027, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5122), 531669339, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5123) },
                    { -756168488, 663050170, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4856), 952013380, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4858) },
                    { -756168488, 695357408, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5210), 939160826, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5211) },
                    { -756168488, 710605392, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4844), 950995534, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4845) },
                    { -756168488, 716381046, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4996), 844573818, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4997) },
                    { -756168488, 741102922, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5461), 760872763, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5462) },
                    { -756168488, 751601582, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5398), 271486157, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5399) },
                    { -756168488, 754491145, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5423), 812747199, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5424) },
                    { -756168488, 774244312, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5223), 913296886, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5224) },
                    { -756168488, 805797818, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5235), 465356377, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5236) },
                    { -756168488, 827162963, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5034), 148333798, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5035) },
                    { -756168488, 836084373, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5059), 348697685, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5060) },
                    { -756168488, 853932493, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5272), 780424954, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5274) },
                    { -756168488, 879344575, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5486), 251052208, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5487) },
                    { -756168488, 886640866, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5008), 646357991, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5010) },
                    { -756168488, 889719230, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5586), 371620026, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5587) },
                    { -756168488, 893877102, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4971), 707455308, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4972) },
                    { -756168488, 908192412, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5549), 457713325, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5550) },
                    { -756168488, 918714283, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4882), 244518326, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4883) },
                    { -756168488, 924439585, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5436), 952038026, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5437) },
                    { -756168488, 953678601, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5147), 740641166, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5148) },
                    { -756168488, 970331932, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4945), 297925387, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4946) },
                    { -756168488, 974963744, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5623), 961429609, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5625) },
                    { -756168488, 992449894, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5498), 270162695, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5500) },
                    { -756168488, 993481001, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4831), 456005162, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4832) },
                    { -756168488, 998819618, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4869), 159112969, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4870) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1029524592, 157003857, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3774), 1160069958, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3775) },
                    { -1029524592, 185440021, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3723), -88753589, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3724) },
                    { -1029524592, 552960366, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3710), 1689623451, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3711) },
                    { -1029524592, 635235719, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3736), -797528731, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3738) },
                    { -1029524592, 677509366, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3788), 855767813, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3790) },
                    { -1029524592, 762395180, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3692), 153079520, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3693) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -756168488, 157003857, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4805), 1206555188, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4806) },
                    { -756168488, 185440021, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4778), -152427221, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4779) },
                    { -756168488, 552960366, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4765), -1216870541, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4767) },
                    { -756168488, 635235719, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4792), -1318245304, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4793) },
                    { -756168488, 677509366, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4818), -1858240412, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4819) },
                    { -756168488, 762395180, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4752), 1769188878, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4754) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1029524592, -1169043030, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3676), 737993262, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3678) },
                    { -1029524592, -666305099, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3636), 725588473, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3637) },
                    { -1029524592, -191542547, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3650), 234922973, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3651) },
                    { -1029524592, 92944843, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3619), 726563235, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3620) },
                    { -1029524592, 248312869, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3663), 907123437, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3664) },
                    { -756168488, -1169043030, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4740), 889644234, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4741) },
                    { -756168488, -666305099, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4700), 893487391, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4701) },
                    { -756168488, -191542547, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4713), 266999659, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4714) },
                    { -756168488, 92944843, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4686), 278826468, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4687) },
                    { -756168488, 248312869, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4726), 423015019, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(4727) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1029524592, 225935636, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5881), 293592230, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5882) },
                    { -1029524592, 232295779, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5745), 690039894, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5746) },
                    { -1029524592, 290767462, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5855), 1018934176, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5856) },
                    { -1029524592, 307125063, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5801), -1345812196, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5803) },
                    { -1029524592, 378553437, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5669), -274483390, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5670) },
                    { -1029524592, 489504497, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5695), -671209336, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5696) },
                    { -1029524592, 581296924, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5908), 1017750544, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5909) },
                    { -1029524592, 606672875, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5774), -1300154568, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5775) },
                    { -1029524592, 788713125, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5638), -1843864436, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5639) },
                    { -1029524592, 951796659, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5828), -269705020, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5829) },
                    { -756168488, 225935636, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5895), -860187974, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5896) },
                    { -756168488, 232295779, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5760), -124895264, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5761) },
                    { -756168488, 290767462, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5868), 1308753714, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5869) },
                    { -756168488, 307125063, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5814), 413601268, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5816) },
                    { -756168488, 378553437, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5682), -861802052, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5683) },
                    { -756168488, 489504497, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5709), 371863646, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5710) },
                    { -756168488, 581296924, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5922), 1801904643, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5923) },
                    { -756168488, 606672875, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5788), -470617328, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5789) },
                    { -756168488, 788713125, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5655), -207025680, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5656) },
                    { -756168488, 951796659, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5841), -1134765696, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(5842) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 302051726, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1754), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1757), 3100.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1755), "Signature 1423412", 77733, 378553437, 2.0, 24.0 },
                    { 325430979, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1976), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1978), 4000.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1977), "Signature 142349", 79218, 489504497, 3.0, 17.0 },
                    { 401780323, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2814), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2817), 10003000.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2816), "Signature 1423435", 21743, 951796659, 7.0, 17.0 },
                    { 542538319, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2383), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2386), 103000.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2385), "Signature 1423410", 89306, 606672875, 5.0, 17.0 },
                    { 567560956, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2600), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2602), 1003000.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2601), "Signature 1423424", 28421, 307125063, 6.0, 24.0 },
                    { 627885661, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3003), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3005), 100003000.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3004), "Signature 1423432", 47737, 290767462, 8.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 719315244, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3447), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3449), 10000003000.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3448), "Signature 1423450", 59162, 581296924, 10.0, 24.0 },
                    { 793142589, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2192), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2194), 13000.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2193), "Signature 1423412", 46370, 232295779, 4.0, 24.0 },
                    { 930538377, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3220), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3223), 1000003000.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3222), "Signature 1423454", 12686, 225935636, 9.0, 17.0 },
                    { 950841115, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1542), new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1544), 3010.0, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1543), "Signature 142342", 67062, 788713125, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 136628742, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3414), null, "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", null, "Alexandros_10", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3416), null, "69492777810", null, null, 581296924 },
                    { 151279330, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2352), null, "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2353), null, "6949277785", null, null, 606672875 },
                    { 183328135, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2973), null, "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2974), null, "6949277788", null, null, 290767462 },
                    { 239571126, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1945), null, "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1946), null, "6949277783", null, null, 489504497 },
                    { 391690399, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2569), null, "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2570), null, "6949277786", null, null, 307125063 },
                    { 447408931, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2784), null, "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2785), null, "6949277787", null, null, 951796659 },
                    { 450400267, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3190), null, "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", null, "Alexandros_9", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3191), null, "6949277789", null, null, 225935636 },
                    { 569872173, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2160), null, "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2161), null, "6949277784", null, null, 232295779 },
                    { 578372510, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1722), null, "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1723), null, "6949277782", null, null, 378553437 },
                    { 636330166, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1480), null, "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1481), null, "6949277781", null, null, 788713125 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 723816604, 136628742, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3433), 949011776, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3434) },
                    { 723816604, 151279330, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2370), 192203637, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2371) },
                    { 723816604, 183328135, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2990), 476200005, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2991) },
                    { 723816604, 239571126, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1962), 283688184, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1963) },
                    { 723816604, 391690399, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2586), 708911780, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2587) },
                    { 723816604, 447408931, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2801), 376425031, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2802) },
                    { 723816604, 450400267, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3207), 960662333, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(3208) },
                    { 723816604, 569872173, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2178), 380438925, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(2179) },
                    { 723816604, 578372510, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1740), 941956269, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1741) },
                    { 723816604, 636330166, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1525), 375500275, new DateTime(2024, 2, 22, 12, 36, 45, 656, DateTimeKind.Local).AddTicks(1527) }
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
