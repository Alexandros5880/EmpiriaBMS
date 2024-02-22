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
                    { 140369617, new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6319), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6320), 0.0, "Draw_7_1" },
                    { 145081769, new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5235), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5237), 0.0, "Draw_2_0" },
                    { 149171185, new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5110), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5111), 0.0, "Draw_1_5" },
                    { 164031533, new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5093), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5094), 0.0, "Draw_1_4" },
                    { 209225458, new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5027), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5028), 0.0, "Draw_1_0" },
                    { 212695331, new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5927), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5928), 0.0, "Draw_5_4" },
                    { 223975026, new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6752), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6753), 0.0, "Draw_9_3" },
                    { 231938565, new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6145), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6146), 0.0, "Draw_6_4" },
                    { 246236096, new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5913), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5914), 0.0, "Draw_5_3" },
                    { 282275917, new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5337), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5339), 0.0, "Draw_2_5" },
                    { 284673049, new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6490), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6491), 0.0, "Draw_8_0" },
                    { 310708867, new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6130), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6131), 0.0, "Draw_6_3" },
                    { 311203621, new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5321), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5323), 0.0, "Draw_2_4" },
                    { 318379029, new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6737), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6739), 0.0, "Draw_9_2" },
                    { 365723596, new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6934), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6935), 0.0, "Draw_10_0" },
                    { 397988554, new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5898), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5899), 0.0, "Draw_5_2" },
                    { 400528461, new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5516), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5517), 0.0, "Draw_3_4" },
                    { 402713701, new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7007), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7008), 0.0, "Draw_10_5" },
                    { 417881840, new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5078), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5079), 0.0, "Draw_1_3" },
                    { 428622732, new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5048), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5049), 0.0, "Draw_1_1" },
                    { 431347500, new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6543), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6544), 0.0, "Draw_8_2" },
                    { 434361607, new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5704), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5705), 0.0, "Draw_4_2" },
                    { 453328351, new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6099), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6101), 0.0, "Draw_6_1" },
                    { 455442715, new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5251), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5252), 0.0, "Draw_2_1" },
                    { 485716866, new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6589), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6590), 0.0, "Draw_8_5" },
                    { 528477846, new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6333), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6334), 0.0, "Draw_7_2" },
                    { 558023465, new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6780), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6782), 0.0, "Draw_9_5" },
                    { 559671408, new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5733), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5734), 0.0, "Draw_4_4" },
                    { 587380689, new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6505), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6507), 0.0, "Draw_8_1" },
                    { 587682858, new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6992), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6993), 0.0, "Draw_10_4" },
                    { 589143198, new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6114), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6115), 0.0, "Draw_6_2" },
                    { 596533931, new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5748), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5749), 0.0, "Draw_4_5" },
                    { 605576493, new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6766), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6767), 0.0, "Draw_9_4" },
                    { 610838482, new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6574), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6575), 0.0, "Draw_8_4" },
                    { 644658882, new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5884), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5885), 0.0, "Draw_5_1" },
                    { 657498848, new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5472), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5473), 0.0, "Draw_3_1" },
                    { 670694284, new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5456), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5458), 0.0, "Draw_3_0" },
                    { 672876885, new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6707), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6709), 0.0, "Draw_9_0" },
                    { 677976200, new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6348), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6349), 0.0, "Draw_7_3" },
                    { 691469867, new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5966), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5967), 0.0, "Draw_5_5" },
                    { 698696963, new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6376), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6377), 0.0, "Draw_7_5" },
                    { 700664321, new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5533), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5534), 0.0, "Draw_3_5" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 714022225, new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6559), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6560), 0.0, "Draw_8_3" },
                    { 714488647, new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6084), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6085), 0.0, "Draw_6_0" },
                    { 749975388, new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5063), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5064), 0.0, "Draw_1_2" },
                    { 754193473, new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5266), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5267), 0.0, "Draw_2_2" },
                    { 775910969, new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5282), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5284), 0.0, "Draw_2_3" },
                    { 779193941, new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6723), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6724), 0.0, "Draw_9_1" },
                    { 780085267, new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5674), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5675), 0.0, "Draw_4_0" },
                    { 808181988, new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6362), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6363), 0.0, "Draw_7_4" },
                    { 818349490, new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5689), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5690), 0.0, "Draw_4_1" },
                    { 819073202, new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6159), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6160), 0.0, "Draw_6_5" },
                    { 850335749, new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6949), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6951), 0.0, "Draw_10_1" },
                    { 863644825, new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6964), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6965), 0.0, "Draw_10_2" },
                    { 871409550, new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5502), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5503), 0.0, "Draw_3_3" },
                    { 878128565, new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5487), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5488), 0.0, "Draw_3_2" },
                    { 898869970, new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6303), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6304), 0.0, "Draw_7_0" },
                    { 952055624, new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5719), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5720), 0.0, "Draw_4_3" },
                    { 970530192, new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5868), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5870), 0.0, "Draw_5_0" },
                    { 985865994, new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6978), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6979), 0.0, "Draw_10_3" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -2096253369, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4798), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4800), 0.0, "Printing" },
                    { -1817677529, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4776), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4778), 0.0, "Comm" },
                    { -642984395, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4828), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4829), 0.0, "Meeting" },
                    { 77721159, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4813), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4814), 0.0, "Inside" },
                    { 231846859, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4842), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4843), 0.0, "Administration" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 190182457, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4351), true, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4352), "Draftsmen" },
                    { 235241112, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4407), false, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4408), "Customer" },
                    { 340705478, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4396), false, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4397), "Guest" },
                    { 399444461, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4374), true, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4375), "COO" },
                    { 432800198, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4359), true, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4361), "Engineer" },
                    { 684620115, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4389), true, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4390), "CEO" },
                    { 874342217, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4367), true, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4368), "Project Manager" },
                    { 959321071, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4382), true, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4383), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 125949558, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4647), 8.0, "Draftsman 2", "draftman2@gmail.com", "Platanios2", 16.0, "Alexandros2", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4649), null, "6949277782", null, null, null },
                    { 129048112, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5125), 8.0, "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5126), null, "6949277784", null, null, null },
                    { 179986987, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5548), 8.0, "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5549), null, "6949277786", null, null, null },
                    { 213097133, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6795), 8.0, "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", 80.0, "Alexandros_12", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6796), null, "69492777812", null, null, null },
                    { 298976092, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8089), 8.0, "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8090), null, "6949277784", null, null, null },
                    { 435202197, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4679), 8.0, "Draftsman 3", "draftman3@gmail.com", "Platanios3", 24.0, "Alexandros3", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4680), null, "6949277783", null, null, null },
                    { 438040437, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7027), 8.0, "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7028), null, "6949277783", null, null, null },
                    { 451242727, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5982), 8.0, "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5983), null, "6949277788", null, null, null },
                    { 468333663, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4710), 8.0, "Draftsman 4", "draftman4@gmail.com", "Platanios4", 32.0, "Alexandros4", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4711), null, "6949277784", null, null, null },
                    { 513139273, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4860), 8.0, "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4862), null, "6949277783", null, null, null },
                    { 524964034, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4510), 8.0, "Draftsman 0", "draftman0@gmail.com", "Platanios0", 0.0, "Alexandros0", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4511), null, "6949277780", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 557000630, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6174), 8.0, "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6175), null, "6949277789", null, null, null },
                    { 563484293, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6391), 8.0, "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6392), null, "69492777810", null, null, null },
                    { 704080456, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4587), 8.0, "Draftsman 1", "draftman1@gmail.com", "Platanios1", 8.0, "Alexandros1", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4588), null, "6949277781", null, null, null },
                    { 734174517, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5352), 8.0, "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5354), null, "6949277785", null, null, null },
                    { 872436113, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4744), 8.0, "Draftsman 5", "draftman5@gmail.com", "Platanios5", 40.0, "Alexandros5", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4745), null, "6949277785", null, null, null },
                    { 890506838, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5763), 8.0, "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5764), null, "6949277787", null, null, null },
                    { 949395121, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6603), 8.0, "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6604), null, "69492777811", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1387484512, 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7062), 438040437, 2345L, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7063), 3425L, "ELEC" },
                    { -1261256488, 0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8119), 298976092, 2345L, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8121), 3425L, "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 223862972, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 8.0, 9, new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 9, "Test Description Project_3", "KL-3", new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 3L, 27L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_3", 5.0, new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_15", 3.0, 734174517, new DateTime(2024, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 },
                    { 408972073, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 13.0, 64, new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 64, "Test Description Project_40", "KL-8", new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 64L, 512L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_8", 5.0, new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_32", 8.0, 563484293, new DateTime(2029, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 },
                    { 472004373, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 7.0, 4, new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 1L, 8L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_2", 5.0, new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_10", 2.0, 129048112, new DateTime(2024, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 },
                    { 497124176, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 11.0, 36, new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 36, "Test Description Project_24", "KL-6", new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 27L, 216L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_6", 5.0, new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_30", 6.0, 451242727, new DateTime(2027, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 },
                    { 561013487, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 6.0, 1, new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 1, "Test Description Project_4", "KL-1", new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, 1L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_1", 5.0, new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_3", 1.0, 513139273, new DateTime(2024, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 },
                    { 639014498, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 9.0, 16, new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 16, "Test Description Project_8", "KL-4", new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 8L, 64L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_4", 5.0, new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_8", 4.0, 179986987, new DateTime(2025, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 },
                    { 675814806, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 14.0, 81, new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 81, "Test Description Project_18", "KL-9", new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 91L, 729L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_9", 5.0, new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_18", 9.0, 949395121, new DateTime(2030, 11, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 },
                    { 680210751, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 10.0, 25, new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 25, "Test Description Project_20", "KL-5", new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 16L, 125L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_5", 5.0, new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_10", 5.0, 890506838, new DateTime(2026, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 },
                    { 700004824, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 15.0, 100, new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 100, "Test Description Project_30", "KL-10", new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 125L, 1000L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_10", 5.0, new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_60", 10.0, 213097133, new DateTime(2032, 6, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 },
                    { 933066283, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 12.0, 49, new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 49, "Test Description Project_35", "KL-7", new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 43L, 343L, new DateTime(2024, 2, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0L, "Project_7", 5.0, new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), "Payment Detailes For Project_21", 7.0, 557000630, new DateTime(2028, 3, 22, 15, 39, 23, 346, DateTimeKind.Local).AddTicks(1878), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 190182457, 125949558, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4665), 763496055, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4666) },
                    { 874342217, 129048112, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5143), 793344456, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5144) },
                    { 874342217, 179986987, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5565), 245509824, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5566) },
                    { 874342217, 213097133, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6812), 821456064, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6813) },
                    { 432800198, 298976092, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8106), 380072111, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8107) },
                    { 190182457, 435202197, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4696), 804656785, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4697) },
                    { 432800198, 438040437, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7047), 289611286, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7048) },
                    { 874342217, 451242727, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6000), 340494293, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6001) },
                    { 190182457, 468333663, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4729), 135190897, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4730) },
                    { 874342217, 513139273, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4883), 817869748, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4884) },
                    { 190182457, 524964034, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4570), 735389314, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4571) },
                    { 874342217, 557000630, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6190), 885961881, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6192) },
                    { 874342217, 563484293, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6409), 894564635, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6410) },
                    { 190182457, 704080456, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4633), 637915009, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4634) },
                    { 874342217, 734174517, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5371), 849077378, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5372) },
                    { 190182457, 872436113, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4761), 723204758, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4762) },
                    { 874342217, 890506838, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5783), 492867194, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5784) },
                    { 874342217, 949395121, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6620), 780206853, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6621) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1387484512, 140369617, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7776), 588001912, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7777) },
                    { -1387484512, 145081769, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7357), 270479118, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7358) },
                    { -1387484512, 149171185, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7344), 197761455, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7345) },
                    { -1387484512, 164031533, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7331), 785268406, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7332) },
                    { -1387484512, 209225458, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7272), 273670378, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7273) },
                    { -1387484512, 212695331, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7662), 844188479, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7663) },
                    { -1387484512, 223975026, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7951), 289965456, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7952) },
                    { -1387484512, 231938565, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7739), 245427781, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7740) },
                    { -1387484512, 246236096, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7649), 835522203, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7651) },
                    { -1387484512, 282275917, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7420), 203451662, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7421) },
                    { -1387484512, 284673049, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7838), 857984165, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7839) },
                    { -1387484512, 310708867, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7726), 684978771, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7727) },
                    { -1387484512, 311203621, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7408), 975486005, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7409) },
                    { -1387484512, 318379029, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7939), 490108851, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7940) },
                    { -1387484512, 365723596, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8012), 268603263, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8013) },
                    { -1387484512, 397988554, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7636), 336937492, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7637) },
                    { -1387484512, 400528461, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7482), 947758935, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7483) },
                    { -1387484512, 402713701, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8076), 590777789, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8077) },
                    { -1387484512, 417881840, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7318), 618340266, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7319) },
                    { -1387484512, 428622732, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7293), 576759703, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7294) },
                    { -1387484512, 431347500, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7863), 443147059, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7864) },
                    { -1387484512, 434361607, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7533), 576142687, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7534) },
                    { -1387484512, 453328351, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7700), 875783772, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7701) },
                    { -1387484512, 455442715, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7369), 525987290, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7370) },
                    { -1387484512, 485716866, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7901), 415068888, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7902) },
                    { -1387484512, 528477846, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7788), 888207648, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7789) },
                    { -1387484512, 558023465, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7976), 701522885, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7977) },
                    { -1387484512, 559671408, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7557), 672869161, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7559) },
                    { -1387484512, 587380689, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7851), 992912914, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7852) },
                    { -1387484512, 587682858, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8063), 511289345, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8064) },
                    { -1387484512, 589143198, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7713), 323021568, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7714) },
                    { -1387484512, 596533931, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7570), 697062605, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7571) },
                    { -1387484512, 605576493, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7964), 783297911, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7965) },
                    { -1387484512, 610838482, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7888), 412095291, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7889) },
                    { -1387484512, 644658882, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7595), 246729653, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7596) },
                    { -1387484512, 657498848, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7445), 835634985, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7446) },
                    { -1387484512, 670694284, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7432), 398367708, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7434) },
                    { -1387484512, 672876885, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7914), 554503581, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7915) },
                    { -1387484512, 677976200, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7800), 362135980, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7802) },
                    { -1387484512, 691469867, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7674), 601480626, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7675) },
                    { -1387484512, 698696963, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7826), 893950018, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7827) },
                    { -1387484512, 700664321, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7495), 189857683, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7496) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1387484512, 714022225, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7876), 462308298, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7877) },
                    { -1387484512, 714488647, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7687), 585620717, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7688) },
                    { -1387484512, 749975388, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7306), 343564213, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7307) },
                    { -1387484512, 754193473, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7382), 175102811, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7383) },
                    { -1387484512, 775910969, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7395), 229930836, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7396) },
                    { -1387484512, 779193941, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7926), 881381140, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7928) },
                    { -1387484512, 780085267, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7507), 826158666, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7509) },
                    { -1387484512, 808181988, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7813), 189701835, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7814) },
                    { -1387484512, 818349490, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7520), 512955068, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7521) },
                    { -1387484512, 819073202, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7751), 613357172, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7752) },
                    { -1387484512, 850335749, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8025), 216539256, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8027) },
                    { -1387484512, 863644825, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8038), 602303675, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8039) },
                    { -1387484512, 871409550, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7469), 359776911, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7471) },
                    { -1387484512, 878128565, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7457), 619949257, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7458) },
                    { -1387484512, 898869970, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7763), 714271868, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7764) },
                    { -1387484512, 952055624, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7545), 352399040, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7546) },
                    { -1387484512, 970530192, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7582), 577888357, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7583) },
                    { -1387484512, 985865994, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8051), 837542209, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8052) },
                    { -1261256488, 140369617, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8804), 604545867, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8805) },
                    { -1261256488, 145081769, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8383), 193798050, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8384) },
                    { -1261256488, 149171185, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8370), 274497809, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8371) },
                    { -1261256488, 164031533, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8331), 349046238, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8333) },
                    { -1261256488, 209225458, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8280), 765294106, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8281) },
                    { -1261256488, 212695331, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8662), 794772997, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8664) },
                    { -1261256488, 223975026, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8978), 284289675, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8979) },
                    { -1261256488, 231938565, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8739), 883239471, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8740) },
                    { -1261256488, 246236096, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8650), 411138841, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8651) },
                    { -1261256488, 282275917, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8447), 900452307, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8448) },
                    { -1261256488, 284673049, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8866), 709265724, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8868) },
                    { -1261256488, 310708867, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8726), 909196262, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8727) },
                    { -1261256488, 311203621, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8434), 651913758, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8435) },
                    { -1261256488, 318379029, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8966), 704009114, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8967) },
                    { -1261256488, 365723596, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9015), 418466979, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9016) },
                    { -1261256488, 397988554, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8637), 493727676, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8639) },
                    { -1261256488, 400528461, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8511), 228009799, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8512) },
                    { -1261256488, 402713701, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9078), 762211531, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9079) },
                    { -1261256488, 417881840, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8319), 338002214, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8320) },
                    { -1261256488, 428622732, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8293), 842266024, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8294) },
                    { -1261256488, 431347500, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8891), 758523489, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8893) },
                    { -1261256488, 434361607, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8562), 513041590, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8563) },
                    { -1261256488, 453328351, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8701), 863409621, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8702) },
                    { -1261256488, 455442715, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8396), 357345689, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8397) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1261256488, 485716866, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8929), 726856196, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8930) },
                    { -1261256488, 528477846, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8817), 644521738, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8818) },
                    { -1261256488, 558023465, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9003), 390610014, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9004) },
                    { -1261256488, 559671408, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8587), 208980355, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8588) },
                    { -1261256488, 587380689, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8879), 569946621, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8880) },
                    { -1261256488, 587682858, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9065), 555567824, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9066) },
                    { -1261256488, 589143198, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8713), 493969545, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8715) },
                    { -1261256488, 596533931, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8600), 785087536, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8601) },
                    { -1261256488, 605576493, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8990), 372678514, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8991) },
                    { -1261256488, 610838482, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8916), 507727540, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8918) },
                    { -1261256488, 644658882, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8625), 964289543, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8626) },
                    { -1261256488, 657498848, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8473), 275043235, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8474) },
                    { -1261256488, 670694284, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8460), 583167044, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8461) },
                    { -1261256488, 672876885, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8941), 867308320, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8942) },
                    { -1261256488, 677976200, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8829), 852210445, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8830) },
                    { -1261256488, 691469867, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8675), 173282850, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8676) },
                    { -1261256488, 698696963, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8854), 774100568, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8855) },
                    { -1261256488, 700664321, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8523), 432129058, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8524) },
                    { -1261256488, 714022225, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8904), 166935647, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8905) },
                    { -1261256488, 714488647, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8688), 471578675, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8689) },
                    { -1261256488, 749975388, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8306), 191618672, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8307) },
                    { -1261256488, 754193473, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8409), 315829041, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8410) },
                    { -1261256488, 775910969, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8421), 691789972, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8422) },
                    { -1261256488, 779193941, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8953), 508249152, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8954) },
                    { -1261256488, 780085267, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8536), 665808417, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8538) },
                    { -1261256488, 808181988, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8841), 998397790, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8842) },
                    { -1261256488, 818349490, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8549), 396447901, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8550) },
                    { -1261256488, 819073202, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8778), 262831093, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8779) },
                    { -1261256488, 850335749, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9028), 380904863, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9029) },
                    { -1261256488, 863644825, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9040), 881853928, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9041) },
                    { -1261256488, 871409550, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8498), 397767198, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8499) },
                    { -1261256488, 878128565, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8485), 519733957, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8486) },
                    { -1261256488, 898869970, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8791), 714436325, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8792) },
                    { -1261256488, 952055624, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8575), 613158800, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8576) },
                    { -1261256488, 970530192, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8612), 578521124, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8613) },
                    { -1261256488, 985865994, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9052), 420535790, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9053) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1387484512, 125949558, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7191), -1852003993, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7192) },
                    { -1387484512, 435202197, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7229), 1688531468, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7230) },
                    { -1387484512, 468333663, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7243), 84164230, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7244) },
                    { -1387484512, 524964034, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7160), -1752857108, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7161) },
                    { -1387484512, 704080456, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7178), 1853466327, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7179) },
                    { -1387484512, 872436113, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7257), -853108960, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7258) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1261256488, 125949558, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8227), -1326574093, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8228) },
                    { -1261256488, 435202197, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8241), -1055091469, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8242) },
                    { -1261256488, 468333663, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8254), -1957813906, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8255) },
                    { -1261256488, 524964034, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8200), 1604068034, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8201) },
                    { -1261256488, 704080456, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8213), 408652817, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8214) },
                    { -1261256488, 872436113, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8266), 94785085, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8267) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1387484512, -2096253369, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7102), 451284024, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7103) },
                    { -1387484512, -1817677529, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7085), 350727421, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7087) },
                    { -1387484512, -642984395, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7129), 219968692, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7130) },
                    { -1387484512, 77721159, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7116), 916044737, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7117) },
                    { -1387484512, 231846859, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7143), 193086664, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(7144) },
                    { -1261256488, -2096253369, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8147), 896141040, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8148) },
                    { -1261256488, -1817677529, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8134), 415047737, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8135) },
                    { -1261256488, -642984395, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8172), 744563634, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8173) },
                    { -1261256488, 77721159, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8160), 662561497, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8161) },
                    { -1261256488, 231846859, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8186), 910989751, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(8187) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1387484512, 223862972, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9148), 674151718, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9149) },
                    { -1387484512, 408972073, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9307), -1934070364, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9309) },
                    { -1387484512, 472004373, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9122), -1289008819, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9123) },
                    { -1387484512, 497124176, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9256), 1312586210, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9257) },
                    { -1387484512, 561013487, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9092), 2001332135, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9093) },
                    { -1387484512, 639014498, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9202), 1535587917, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9203) },
                    { -1387484512, 675814806, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9333), 1551271845, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9334) },
                    { -1387484512, 680210751, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9229), -1479268080, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9230) },
                    { -1387484512, 700004824, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9359), -1032908766, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9361) },
                    { -1387484512, 933066283, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9282), 2085025988, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9283) },
                    { -1261256488, 223862972, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9162), -1621408811, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9163) },
                    { -1261256488, 408972073, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9320), -2041245856, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9321) },
                    { -1261256488, 472004373, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9135), 1529871470, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9136) },
                    { -1261256488, 497124176, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9268), -1527674562, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9270) },
                    { -1261256488, 561013487, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9109), -1924612028, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9110) },
                    { -1261256488, 639014498, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9216), 340924058, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9217) },
                    { -1261256488, 675814806, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9346), 1154245656, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9348) },
                    { -1261256488, 680210751, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9243), -1266114634, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9244) },
                    { -1261256488, 700004824, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9372), -2122546750, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9374) },
                    { -1261256488, 933066283, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9295), 1457456883, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(9296) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 133751643, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6690), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6692), 1000003000.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6691), "Signature 1423454", 19894, 675814806, 9.0, 17.0 },
                    { 182898976, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6287), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6289), 10003000.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6288), "Signature 1423435", 51477, 933066283, 7.0, 17.0 },
                    { 394947758, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5850), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5853), 103000.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5851), "Signature 1423410", 41678, 680210751, 5.0, 17.0 },
                    { 554156969, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5439), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5441), 4000.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5440), "Signature 1423415", 76882, 223862972, 3.0, 17.0 },
                    { 590254804, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6917), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6919), 10000003000.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6918), "Signature 1423430", 71839, 700004824, 10.0, 24.0 },
                    { 689228003, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5217), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5219), 3100.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5218), "Signature 142344", 87685, 472004373, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 727494837, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6474), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6476), 100003000.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6475), "Signature 142348", 29026, 408972073, 8.0, 24.0 },
                    { 842964671, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6067), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6069), 1003000.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6068), "Signature 1423418", 48035, 497124176, 6.0, 24.0 },
                    { 896810601, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5657), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5659), 13000.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5658), "Signature 1423412", 21523, 639014498, 4.0, 24.0 },
                    { 923723467, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5005), new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5007), 3010.0, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5006), "Signature 142342", 42194, 561013487, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 161574904, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5624), null, "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5626), null, "6949277784", null, null, 639014498 },
                    { 179811969, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5186), null, "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5187), null, "6949277782", null, null, 472004373 },
                    { 202194144, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6658), null, "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", null, "Alexandros_9", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6659), null, "6949277789", null, null, 675814806 },
                    { 203028785, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5407), null, "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5408), null, "6949277783", null, null, 223862972 },
                    { 231867660, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5820), null, "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5821), null, "6949277785", null, null, 680210751 },
                    { 432485989, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6255), null, "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6256), null, "6949277787", null, null, 933066283 },
                    { 447046103, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6443), null, "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6444), null, "6949277788", null, null, 408972073 },
                    { 635319638, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4944), null, "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4945), null, "6949277781", null, null, 561013487 },
                    { 888349188, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6036), null, "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6037), null, "6949277786", null, null, 497124176 },
                    { 917546259, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6884), null, "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", null, "Alexandros_10", new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6885), null, "69492777810", null, null, 700004824 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 235241112, 161574904, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5643), 171530095, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5644) },
                    { 235241112, 179811969, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5203), 515260945, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5204) },
                    { 235241112, 202194144, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6676), 308655936, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6677) },
                    { 235241112, 203028785, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5424), 498984269, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5426) },
                    { 235241112, 231867660, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5837), 851240580, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(5838) },
                    { 235241112, 432485989, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6273), 635333955, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6274) },
                    { 235241112, 447046103, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6460), 744276243, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6461) },
                    { 235241112, 635319638, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4989), 835186178, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(4990) },
                    { 235241112, 888349188, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6053), 518021473, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6055) },
                    { 235241112, 917546259, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6903), 789808910, new DateTime(2024, 2, 22, 15, 39, 23, 349, DateTimeKind.Local).AddTicks(6904) }
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
