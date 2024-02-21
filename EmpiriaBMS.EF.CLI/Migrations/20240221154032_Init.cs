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
                    ManHours = table.Column<double>(type: "float", nullable: false),
                    CompletionEstimation = table.Column<int>(type: "int", nullable: true),
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
                    ManHours = table.Column<double>(type: "float", nullable: false),
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
                name: "DisciplineDraw",
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
                    table.PrimaryKey("PK_DisciplineDraw", x => new { x.DisciplineId, x.DrawId });
                    table.ForeignKey(
                        name: "FK_DisciplineDraw_Draws_DrawId",
                        column: x => x.DrawId,
                        principalTable: "Draws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineOther",
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
                    table.PrimaryKey("PK_DisciplineOther", x => new { x.DisciplineId, x.OtherId });
                    table.ForeignKey(
                        name: "FK_DisciplineOther_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
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
                    EstimatedMandays = table.Column<long>(type: "bigint", nullable: true),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: true),
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
                    Completed = table.Column<int>(type: "int", nullable: true),
                    WorkPackegedCompleted = table.Column<int>(type: "int", nullable: true),
                    ManHours = table.Column<long>(type: "bigint", nullable: true),
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
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EstimatedHours = table.Column<long>(type: "bigint", nullable: true),
                    EstimatedMenHours = table.Column<long>(type: "bigint", nullable: true),
                    Completed = table.Column<int>(type: "int", nullable: true),
                    EngineerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplines_Users_EngineerId",
                        column: x => x.EngineerId,
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
                    table.ForeignKey(
                        name: "FK_DisciplinesEmployees_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 125424378, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8203), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8204), 0.0, "Draw_6" },
                    { 129155049, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9966), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9967), 0.0, "Draw_8" },
                    { 135584307, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7091), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7093), 0.0, "Draw_4" },
                    { 136870714, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8946), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8947), 0.0, "Draw_7" },
                    { 140489700, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8894), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8896), 0.0, "Draw_7" },
                    { 142268885, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7270), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7271), 0.0, "Draw_5" },
                    { 142582586, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7038), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7039), 0.0, "Draw_4" },
                    { 142648801, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8765), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8766), 0.0, "Draw_7" },
                    { 147371673, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7371), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7372), 0.0, "Draw_5" },
                    { 148318623, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6885), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6886), 0.0, "Draw_4" },
                    { 150854325, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1111), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1112), 0.0, "Draw_10" },
                    { 153883236, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2302), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2303), 0.0, "Draw_11" },
                    { 164748791, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6284), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6285), 0.0, "Draw_3" },
                    { 184026018, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8842), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8843), 0.0, "Draw_7" },
                    { 185498615, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9310), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9311), 0.0, "Draw_7" },
                    { 186127478, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2608), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2609), 0.0, "Draw_12" },
                    { 186925853, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7710), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7711), 0.0, "Draw_5" },
                    { 208368607, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1059), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1060), 0.0, "Draw_10" },
                    { 209931558, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9677), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9678), 0.0, "Draw_8" },
                    { 225122765, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9915), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9916), 0.0, "Draw_8" },
                    { 225243687, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9991), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9992), 0.0, "Draw_8" },
                    { 233150110, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(412), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(413), 0.0, "Draw_9" },
                    { 244385540, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6334), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6335), 0.0, "Draw_3" },
                    { 247104405, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7012), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7013), 0.0, "Draw_4" },
                    { 249835409, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2172), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2173), 0.0, "Draw_11" },
                    { 255730140, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6156), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6157), 0.0, "Draw_3" },
                    { 268670313, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6309), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6310), 0.0, "Draw_3" },
                    { 270795434, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6209), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6210), 0.0, "Draw_3" },
                    { 282090611, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8557), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8558), 0.0, "Draw_6" },
                    { 287617476, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6647), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6649), 0.0, "Draw_4" },
                    { 292484908, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2637), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2638), 0.0, "Draw_12" },
                    { 299582653, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2070), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2071), 0.0, "Draw_11" },
                    { 299593054, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(569), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(570), 0.0, "Draw_9" },
                    { 309702424, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7971), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7972), 0.0, "Draw_6" },
                    { 309831204, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8505), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8507), 0.0, "Draw_6" },
                    { 310156361, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6673), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6674), 0.0, "Draw_4" },
                    { 316874448, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1859), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1860), 0.0, "Draw_11" },
                    { 320053352, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8920), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8921), 0.0, "Draw_7" },
                    { 321052122, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(748), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(749), 0.0, "Draw_9" },
                    { 323211992, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9496), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9498), 0.0, "Draw_8" },
                    { 326537878, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1546), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1547), 0.0, "Draw_10" },
                    { 326540638, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(360), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(361), 0.0, "Draw_9" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 327635124, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1007), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1008), 0.0, "Draw_10" },
                    { 328775121, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9575), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9576), 0.0, "Draw_8" },
                    { 331893785, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6753), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6754), 0.0, "Draw_4" },
                    { 333843686, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(284), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(285), 0.0, "Draw_9" },
                    { 335827705, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6622), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6623), 0.0, "Draw_4" },
                    { 336908439, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5444), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5445), 0.0, "Draw_2" },
                    { 343095173, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7768), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7770), 0.0, "Draw_5" },
                    { 344585774, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9129), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9130), 0.0, "Draw_7" },
                    { 349110715, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2146), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2147), 0.0, "Draw_11" },
                    { 353102708, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1033), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1034), 0.0, "Draw_10" },
                    { 355934799, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5869), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5870), 0.0, "Draw_3" },
                    { 358324960, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1085), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1086), 0.0, "Draw_10" },
                    { 372116733, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1401), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1402), 0.0, "Draw_10" },
                    { 376500985, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9523), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9524), 0.0, "Draw_8" },
                    { 378636249, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6962), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6963), 0.0, "Draw_4" },
                    { 388545555, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5817), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5818), 0.0, "Draw_3" },
                    { 393496036, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2096), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2097), 0.0, "Draw_11" },
                    { 397934389, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5550), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5551), 0.0, "Draw_2" },
                    { 400299939, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9284), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9285), 0.0, "Draw_7" },
                    { 403279150, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1349), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1350), 0.0, "Draw_10" },
                    { 405183198, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8051), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8052), 0.0, "Draw_6" },
                    { 407941066, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2223), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2224), 0.0, "Draw_11" },
                    { 414352804, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(437), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(438), 0.0, "Draw_9" },
                    { 414977781, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1835), 0.0, "Draw_11" },
                    { 419141959, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2481), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2482), 0.0, "Draw_12" },
                    { 421479857, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2663), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2664), 0.0, "Draw_12" },
                    { 425327971, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(621), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(622), 0.0, "Draw_9" },
                    { 430040508, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8608), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8609), 0.0, "Draw_6" },
                    { 432446371, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5471), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5472), 0.0, "Draw_2" },
                    { 438343546, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7844), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7846), 0.0, "Draw_5" },
                    { 444123494, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8178), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8179), 0.0, "Draw_6" },
                    { 445057233, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9627), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9628), 0.0, "Draw_8" },
                    { 449864917, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8363), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8364), 0.0, "Draw_6" },
                    { 450352803, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6596), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6598), 0.0, "Draw_4" },
                    { 451458039, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8076), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8077), 0.0, "Draw_6" },
                    { 454483425, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7684), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7685), 0.0, "Draw_5" },
                    { 458515426, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8582), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8583), 0.0, "Draw_6" },
                    { 470006686, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9207), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9208), 0.0, "Draw_7" },
                    { 471233428, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2506), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2507), 0.0, "Draw_12" },
                    { 479317552, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(258), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(260), 0.0, "Draw_9" },
                    { 479814511, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7396), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7398), 0.0, "Draw_5" },
                    { 487804086, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(335), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(336), 0.0, "Draw_9" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 498124385, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(956), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(957), 0.0, "Draw_10" },
                    { 498129296, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6724), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6725), 0.0, "Draw_4" },
                    { 511734188, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7118), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7119), 0.0, "Draw_4" },
                    { 511804555, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(386), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(387), 0.0, "Draw_9" },
                    { 516685529, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9601), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9602), 0.0, "Draw_8" },
                    { 528562617, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5895), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5896), 0.0, "Draw_3" },
                    { 535211374, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(773), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(774), 0.0, "Draw_9" },
                    { 535403513, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8791), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8792), 0.0, "Draw_7" },
                    { 536220769, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6359), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6360), 0.0, "Draw_3" },
                    { 537122086, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1939), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1941), 0.0, "Draw_11" },
                    { 540489240, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8480), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8481), 0.0, "Draw_6" },
                    { 544113023, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(929), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(930), 0.0, "Draw_10" },
                    { 552444399, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9181), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9182), 0.0, "Draw_7" },
                    { 557366218, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9258), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9259), 0.0, "Draw_7" },
                    { 566143250, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1324), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1325), 0.0, "Draw_10" },
                    { 570593680, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1520), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1521), 0.0, "Draw_10" },
                    { 583980774, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(672), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(673), 0.0, "Draw_9" },
                    { 587861826, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8336), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8337), 0.0, "Draw_6" },
                    { 592977060, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2429), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2431), 0.0, "Draw_12" },
                    { 598587162, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6183), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6184), 0.0, "Draw_3" },
                    { 607277136, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8427), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8429), 0.0, "Draw_6" },
                    { 612606833, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7794), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7795), 0.0, "Draw_5" },
                    { 613399923, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6542), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6543), 0.0, "Draw_4" },
                    { 614410838, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7296), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7297), 0.0, "Draw_5" },
                    { 618022966, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2198), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2199), 0.0, "Draw_11" },
                    { 619582663, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9865), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9866), 0.0, "Draw_8" },
                    { 623674570, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8026), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8027), 0.0, "Draw_6" },
                    { 624233010, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(723), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(724), 0.0, "Draw_9" },
                    { 625094350, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9702), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9703), 0.0, "Draw_8" },
                    { 628856328, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(207), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(208), 0.0, "Draw_9" },
                    { 634876731, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6516), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6517), 0.0, "Draw_4" },
                    { 635863268, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5521), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5523), 0.0, "Draw_2" },
                    { 642130593, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2557), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2558), 0.0, "Draw_12" },
                    { 645070321, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8531), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8532), 0.0, "Draw_6" },
                    { 652308917, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1375), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1376), 0.0, "Draw_10" },
                    { 653143228, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5398), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5399), 0.0, "Draw_2" },
                    { 654943240, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(981), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(982), 0.0, "Draw_10" },
                    { 655642603, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5999), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6000), 0.0, "Draw_3" },
                    { 660179186, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(16), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(17), 0.0, "Draw_8" },
                    { 663495091, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7819), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7820), 0.0, "Draw_5" },
                    { 663860058, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8971), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8972), 0.0, "Draw_7" },
                    { 663975630, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8816), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8817), 0.0, "Draw_7" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 664164262, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1572), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1573), 0.0, "Draw_10" },
                    { 665701533, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(646), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(647), 0.0, "Draw_9" },
                    { 666334130, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6698), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6699), 0.0, "Draw_4" },
                    { 670398363, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8127), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8128), 0.0, "Draw_6" },
                    { 676181393, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1783), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1784), 0.0, "Draw_11" },
                    { 679946400, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5945), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5946), 0.0, "Draw_3" },
                    { 694064679, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6987), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6988), 0.0, "Draw_4" },
                    { 702226633, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9940), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9942), 0.0, "Draw_8" },
                    { 706665583, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7063), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7064), 0.0, "Draw_4" },
                    { 712812147, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1885), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1886), 0.0, "Draw_11" },
                    { 714362651, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8000), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8002), 0.0, "Draw_6" },
                    { 722892933, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(698), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(699), 0.0, "Draw_9" },
                    { 723422448, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2121), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2122), 0.0, "Draw_11" },
                    { 726167437, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6937), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6938), 0.0, "Draw_4" },
                    { 726322713, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1136), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1138), 0.0, "Draw_10" },
                    { 752452137, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9839), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9840), 0.0, "Draw_8" },
                    { 753732222, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1297), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1298), 0.0, "Draw_10" },
                    { 755392679, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2248), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2249), 0.0, "Draw_11" },
                    { 756809049, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9103), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9104), 0.0, "Draw_7" },
                    { 759796928, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5844), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5845), 0.0, "Draw_3" },
                    { 761371821, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9892), 0.0, "Draw_8" },
                    { 776290986, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9470), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9471), 0.0, "Draw_8" },
                    { 781178766, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9335), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9336), 0.0, "Draw_7" },
                    { 786691874, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7742), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7743), 0.0, "Draw_5" },
                    { 791714958, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9155), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9156), 0.0, "Draw_7" },
                    { 792714926, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7607), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7608), 0.0, "Draw_5" },
                    { 799664820, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7658), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7659), 0.0, "Draw_5" },
                    { 806476420, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2583), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2584), 0.0, "Draw_12" },
                    { 808842392, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2455), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2456), 0.0, "Draw_12" },
                    { 814727041, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(233), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(234), 0.0, "Draw_9" },
                    { 815102037, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8101), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8102), 0.0, "Draw_6" },
                    { 823915987, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5920), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5921), 0.0, "Draw_3" },
                    { 824945805, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7425), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7426), 0.0, "Draw_5" },
                    { 829282103, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(74), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(75), 0.0, "Draw_8" },
                    { 832286994, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1706), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1707), 0.0, "Draw_11" },
                    { 832483424, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6911), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6913), 0.0, "Draw_4" },
                    { 835738967, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1732), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1733), 0.0, "Draw_11" },
                    { 838718118, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9549), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9550), 0.0, "Draw_8" },
                    { 839607623, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7452), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7453), 0.0, "Draw_5" },
                    { 846542598, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2276), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2277), 0.0, "Draw_11" },
                    { 848139046, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(595), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(596), 0.0, "Draw_9" },
                    { 848391027, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5974), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5975), 0.0, "Draw_3" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 849070291, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5496), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5497), 0.0, "Draw_2" },
                    { 852390023, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8739), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8740), 0.0, "Draw_7" },
                    { 856861886, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5627), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5628), 0.0, "Draw_2" },
                    { 858700491, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6259), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6260), 0.0, "Draw_3" },
                    { 873386933, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5791), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5792), 0.0, "Draw_3" },
                    { 883319855, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1808), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1809), 0.0, "Draw_11" },
                    { 888887331, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7244), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7246), 0.0, "Draw_5" },
                    { 899441946, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7632), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7633), 0.0, "Draw_5" },
                    { 900239218, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7321), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7322), 0.0, "Draw_5" },
                    { 902671202, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1757), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1758), 0.0, "Draw_11" },
                    { 908291504, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1494), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1495), 0.0, "Draw_10" },
                    { 913095177, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6385), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6386), 0.0, "Draw_3" },
                    { 914860846, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(45), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(46), 0.0, "Draw_8" },
                    { 915519192, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5576), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5577), 0.0, "Draw_2" },
                    { 916062552, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(799), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(800), 0.0, "Draw_9" },
                    { 918118004, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7477), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7479), 0.0, "Draw_5" },
                    { 918417325, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8868), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8869), 0.0, "Draw_7" },
                    { 923446112, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5602), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5603), 0.0, "Draw_2" },
                    { 926973593, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6024), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6025), 0.0, "Draw_3" },
                    { 927831671, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8152), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8153), 0.0, "Draw_6" },
                    { 932836394, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9232), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9233), 0.0, "Draw_7" },
                    { 941648312, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(310), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(311), 0.0, "Draw_9" },
                    { 953171745, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6568), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6569), 0.0, "Draw_4" },
                    { 960431783, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8454), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8455), 0.0, "Draw_6" },
                    { 960839138, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2532), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2533), 0.0, "Draw_12" },
                    { 961821618, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7346), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7347), 0.0, "Draw_5" },
                    { 963647594, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5656), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5657), 0.0, "Draw_2" },
                    { 978136683, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1910), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1911), 0.0, "Draw_11" },
                    { 978935663, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1162), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1163), 0.0, "Draw_10" },
                    { 982980414, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1467), new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1469), 0.0, "Draw_10" },
                    { 987964403, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6233), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6235), 0.0, "Draw_3" },
                    { 997725602, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9652), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9653), 0.0, "Draw_8" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4107), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4108), 0.0, "Comm" },
                    { -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5177), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5178), 0.0, "Administration" },
                    { -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4123), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4124), 0.0, "Printing" },
                    { -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5164), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5165), 0.0, "Meeting" },
                    { 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5151), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5152), 0.0, "Outside" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 228403650, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3990), true, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3991), "CEO" },
                    { 268830136, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4006), false, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4007), "Customer" },
                    { 313769658, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3950), true, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3951), "Draftsmen" },
                    { 383427557, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3983), true, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3984), "CTO" },
                    { 564765687, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3958), true, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3960), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 726106886, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3998), false, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3999), "Guest" },
                    { 768515225, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3967), true, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3968), "Project Manager" },
                    { 987992039, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3974), true, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(3977), "COO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 126090078, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6275), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 72.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6276), null, "69492777822", null, null, null },
                    { 134284036, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9615), 8.0, "Test Description Draftsman 28", "alexpl_28@gmail.com", "Platanios_Draftsman_28", 136.0, "Alexandros_28", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9616), null, "69492777828", null, null, null },
                    { 137947935, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3060), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 8.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3061), null, "69492777814", null, null, null },
                    { 143798336, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4330), 8.0, "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 40.0, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4332), null, "69492777810", null, null, null },
                    { 152229764, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8534), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 120.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8535), null, "69492777824", null, null, null },
                    { 155666760, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7072), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 88.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7073), null, "69492777824", null, null, null },
                    { 162691729, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4687), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 40.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4688), null, "69492777818", null, null, null },
                    { 169636388, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9929), 8.0, "Test Description Draftsman 27", "alexpl_27@gmail.com", "Platanios_Draftsman_27", 144.0, "Alexandros_27", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9930), null, "69492777827", null, null, null },
                    { 170558935, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3099), 8.0, "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 16.0, "Alexandros_6", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3100), null, "6949277786", null, null, null },
                    { 176897551, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7389), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 96.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7390), null, "69492777823", null, null, null },
                    { 178653173, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4303), 8.0, "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4304), null, "6949277784", null, null, null },
                    { 185864171, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4526), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 40.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4528), null, "69492777814", null, null, null },
                    { 191064694, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5559), 8.0, "Test Description Draftsman 13", "alexpl_13@gmail.com", "Platanios_Draftsman_13", 64.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5560), null, "69492777813", null, null, null },
                    { 200775133, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4447), 8.0, "Test Description Draftsman 13", "alexpl_13@gmail.com", "Platanios_Draftsman_13", 40.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4448), null, "69492777813", null, null, null },
                    { 202698441, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4291), 8.0, "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 40.0, "Alexandros_9", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4293), null, "6949277789", null, null, null },
                    { 203971509, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4776), 8.0, "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4778), null, "6949277789", null, null, null },
                    { 210800188, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(396), 8.0, "Test Description Draftsman 30", "alexpl_30@gmail.com", "Platanios_Draftsman_30", 152.0, "Alexandros_30", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(397), null, "69492777830", null, null, null },
                    { 215168238, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7587), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 104.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7588), null, "69492777818", null, null, null },
                    { 215293208, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5996), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 72.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5997), null, "69492777815", null, null, null },
                    { 215644833, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9728), 8.0, "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 56.0, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9729), null, "69492777810", null, null, null },
                    { 216282448, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5479), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 56.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5480), null, "69492777820", null, null, null },
                    { 216889752, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4648), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 40.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4649), null, "69492777817", null, null, null },
                    { 229322444, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(43), 8.0, "Test Description Draftsman 30", "alexpl_30@gmail.com", "Platanios_Draftsman_30", 144.0, "Alexandros_30", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(44), null, "69492777830", null, null, null },
                    { 230130259, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5676), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 64.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5677), null, "69492777816", null, null, null },
                    { 230521297, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5439), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 56.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5440), null, "69492777819", null, null, null },
                    { 236142983, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3419), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 16.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3420), null, "69492777814", null, null, null },
                    { 237486015, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(162), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 152.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(163), null, "69492777824", null, null, null },
                    { 243978488, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(239), 8.0, "Test Description Draftsman 26", "alexpl_26@gmail.com", "Platanios_Draftsman_26", 152.0, "Alexandros_26", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(240), null, "69492777826", null, null, null },
                    { 247368343, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2982), 8.0, "Test Description Draftsman 12", "alexpl_12@gmail.com", "Platanios_Draftsman_12", 8.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2983), null, "69492777812", null, null, null },
                    { 255037696, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3180), 8.0, "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 16.0, "Alexandros_8", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3182), null, "6949277788", null, null, null },
                    { 258994130, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7902), 8.0, "Test Description Draftsman 26", "alexpl_26@gmail.com", "Platanios_Draftsman_26", 104.0, "Alexandros_26", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7903), null, "69492777826", null, null, null },
                    { 262877819, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9230), 8.0, "Test Description Draftsman 27", "alexpl_27@gmail.com", "Platanios_Draftsman_27", 128.0, "Alexandros_27", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9231), null, "69492777827", null, null, null },
                    { 265098115, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8453), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 120.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8454), null, "69492777822", null, null, null },
                    { 267127597, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(5), 8.0, "Test Description Draftsman 29", "alexpl_29@gmail.com", "Platanios_Draftsman_29", 144.0, "Alexandros_29", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(6), null, "69492777829", null, null, null },
                    { 267807457, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8770), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 128.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8771), null, "69492777821", null, null, null },
                    { 272965907, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4173), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 32.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4174), null, "69492777815", null, null, null },
                    { 276900212, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6357), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 80.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6358), null, "69492777815", null, null, null },
                    { 278305567, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4135), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 32.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4136), null, "69492777814", null, null, null },
                    { 280076735, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9461), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 136.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9463), null, "69492777824", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 283286648, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2779), 8.0, "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 8.0, "Alexandros_7", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2780), null, "6949277787", null, null, null },
                    { 290348397, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9343), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 136.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9345), null, "69492777821", null, null, null },
                    { 290368339, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9696), 8.0, "Test Description Draftsman 30", "alexpl_30@gmail.com", "Platanios_Draftsman_30", 136.0, "Alexandros_30", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9697), null, "69492777830", null, null, null },
                    { 291660336, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8634), 8.0, "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 40.0, "Alexandros_9", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8635), null, "6949277789", null, null, null },
                    { 292729626, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5953), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 72.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5954), null, "69492777814", null, null, null },
                    { 299010207, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7782), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 104.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7783), null, "69492777823", null, null, null },
                    { 304072659, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3459), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 16.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3460), null, "69492777815", null, null, null },
                    { 304106052, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7862), 8.0, "Test Description Draftsman 25", "alexpl_25@gmail.com", "Platanios_Draftsman_25", 104.0, "Alexandros_25", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7863), null, "69492777825", null, null, null },
                    { 307474543, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5715), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 64.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5716), null, "69492777817", null, null, null },
                    { 307629443, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9849), 8.0, "Test Description Draftsman 25", "alexpl_25@gmail.com", "Platanios_Draftsman_25", 144.0, "Alexandros_25", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9850), null, "69492777825", null, null, null },
                    { 313419942, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6792), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 88.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6793), null, "69492777817", null, null, null },
                    { 313997180, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6233), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 72.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6234), null, "69492777821", null, null, null },
                    { 319346589, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6676), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 80.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6677), null, "69492777823", null, null, null },
                    { 322718585, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7503), 8.0, "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 32.0, "Alexandros_7", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7505), null, "6949277787", null, null, null },
                    { 330235974, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8374), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 120.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8376), null, "69492777820", null, null, null },
                    { 330712458, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5162), 8.0, "Test Description Draftsman 12", "alexpl_12@gmail.com", "Platanios_Draftsman_12", 56.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5164), null, "69492777812", null, null, null },
                    { 340810670, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9539), 8.0, "Test Description Draftsman 26", "alexpl_26@gmail.com", "Platanios_Draftsman_26", 136.0, "Alexandros_26", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9540), null, "69492777826", null, null, null },
                    { 343538230, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9268), 8.0, "Test Description Draftsman 28", "alexpl_28@gmail.com", "Platanios_Draftsman_28", 128.0, "Alexandros_28", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9269), null, "69492777828", null, null, null },
                    { 350866850, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4766), 8.0, "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 48.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4767), null, "69492777811", null, null, null },
                    { 351261797, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(278), 8.0, "Test Description Draftsman 27", "alexpl_27@gmail.com", "Platanios_Draftsman_27", 152.0, "Alexandros_27", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(279), null, "69492777827", null, null, null },
                    { 351279331, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3657), 8.0, "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 24.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3658), null, "69492777811", null, null, null },
                    { 356455722, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9577), 8.0, "Test Description Draftsman 27", "alexpl_27@gmail.com", "Platanios_Draftsman_27", 136.0, "Alexandros_27", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9578), null, "69492777827", null, null, null },
                    { 357604153, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4847), 8.0, "Test Description Draftsman 13", "alexpl_13@gmail.com", "Platanios_Draftsman_13", 48.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4849), null, "69492777813", null, null, null },
                    { 358602336, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3219), 8.0, "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 16.0, "Alexandros_9", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3220), null, "6949277789", null, null, null },
                    { 358813399, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7111), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 96.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7112), null, "69492777816", null, null, null },
                    { 360165366, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4058), 8.0, "Test Description Draftsman 12", "alexpl_12@gmail.com", "Platanios_Draftsman_12", 32.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4059), null, "69492777812", null, null, null },
                    { 361293955, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2857), 8.0, "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 8.0, "Alexandros_9", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2858), null, "6949277789", null, null, null },
                    { 366271791, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4587), 8.0, "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4588), null, "6949277787", null, null, null },
                    { 369394459, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4250), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 32.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4251), null, "69492777817", null, null, null },
                    { 370183219, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4805), 8.0, "Test Description Draftsman 12", "alexpl_12@gmail.com", "Platanios_Draftsman_12", 48.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4806), null, "69492777812", null, null, null },
                    { 371296478, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5003), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 48.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5005), null, "69492777817", null, null, null },
                    { 371458743, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5796), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 64.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5797), null, "69492777819", null, null, null },
                    { 374944394, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6555), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 80.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6556), null, "69492777820", null, null, null },
                    { 378331638, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9967), 8.0, "Test Description Draftsman 28", "alexpl_28@gmail.com", "Platanios_Draftsman_28", 144.0, "Alexandros_28", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9968), null, "69492777828", null, null, null },
                    { 379229833, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6873), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 88.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6874), null, "69492777819", null, null, null },
                    { 383171835, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(632), 8.0, "Test Description Draftsman 27", "alexpl_27@gmail.com", "Platanios_Draftsman_27", 160.0, "Alexandros_27", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(633), null, "69492777827", null, null, null },
                    { 383656646, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3935), 8.0, "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 32.0, "Alexandros_9", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3936), null, "6949277789", null, null, null },
                    { 386324389, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4964), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 48.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4965), null, "69492777816", null, null, null },
                    { 386672944, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4926), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 48.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4927), null, "69492777815", null, null, null },
                    { 392367536, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9734), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 144.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9735), null, "69492777822", null, null, null },
                    { 392678020, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(100), 8.0, "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 56.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(101), null, "69492777811", null, null, null },
                    { 393798736, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8997), 8.0, "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 48.0, "Alexandros_9", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8998), null, "6949277789", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 399136933, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9382), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 136.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9383), null, "69492777822", null, null, null },
                    { 404005877, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7704), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 104.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7705), null, "69492777821", null, null, null },
                    { 406266847, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8572), 8.0, "Test Description Draftsman 25", "alexpl_25@gmail.com", "Platanios_Draftsman_25", 120.0, "Alexandros_25", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8574), null, "69492777825", null, null, null },
                    { 409985662, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3896), 8.0, "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 32.0, "Alexandros_8", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3897), null, "6949277788", null, null, null },
                    { 418555899, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5598), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 64.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5599), null, "69492777814", null, null, null },
                    { 420440091, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6516), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 80.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6517), null, "69492777819", null, null, null },
                    { 421165971, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(870), 8.0, "Test Description Draftsman 32", "alexpl_32@gmail.com", "Platanios_Draftsman_32", 160.0, "Alexandros_32", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(871), null, "69492777832", null, null, null },
                    { 426620968, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(824), 8.0, "Test Description Engineer 12", "alexpl_12@gmail.com", "Platanios_Engineer_12", 64.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(825), null, "69492777812", null, null, null },
                    { 439400920, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9423), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 136.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9424), null, "69492777823", null, null, null },
                    { 442970399, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5279), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 56.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5280), null, "69492777815", null, null, null },
                    { 443647012, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9657), 8.0, "Test Description Draftsman 29", "alexpl_29@gmail.com", "Platanios_Draftsman_29", 136.0, "Alexandros_29", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9659), null, "69492777829", null, null, null },
                    { 450192032, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6912), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 88.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6913), null, "69492777820", null, null, null },
                    { 452169966, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5084), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 48.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5085), null, "69492777819", null, null, null },
                    { 460358536, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7666), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 104.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7667), null, "69492777820", null, null, null },
                    { 461213238, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9811), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 144.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9812), null, "69492777824", null, null, null },
                    { 468374429, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4726), 8.0, "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 48.0, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4727), null, "69492777810", null, null, null },
                    { 469090975, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9146), 8.0, "Test Description Draftsman 25", "alexpl_25@gmail.com", "Platanios_Draftsman_25", 128.0, "Alexandros_25", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9147), null, "69492777825", null, null, null },
                    { 469159795, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4870), 8.0, "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4871), null, "69492777810", null, null, null },
                    { 475782619, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3856), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 24.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3858), null, "69492777816", null, null, null },
                    { 480559478, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1601), 8.0, "Test Description Engineer 13", "alexpl_13@gmail.com", "Platanios_Engineer_13", 72.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1603), null, "69492777813", null, null, null },
                    { 485059501, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8060), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 112.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8061), null, "69492777821", null, null, null },
                    { 485263290, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3975), 8.0, "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 32.0, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3976), null, "69492777810", null, null, null },
                    { 486559565, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8137), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 112.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8138), null, "69492777823", null, null, null },
                    { 487394920, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4403), 8.0, "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4405), null, "6949277785", null, null, null },
                    { 488978159, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6152), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 72.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6153), null, "69492777819", null, null, null },
                    { 493154393, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(551), 8.0, "Test Description Draftsman 25", "alexpl_25@gmail.com", "Platanios_Draftsman_25", 160.0, "Alexandros_25", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(552), null, "69492777825", null, null, null },
                    { 493243069, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8228), 8.0, "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 40.0, "Alexandros_8", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8229), null, "6949277788", null, null, null },
                    { 496178162, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2691), 8.0, "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 8.0, "Alexandros_5", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2692), null, "6949277785", null, null, null },
                    { 506414347, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5201), 8.0, "Test Description Draftsman 13", "alexpl_13@gmail.com", "Platanios_Draftsman_13", 56.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5202), null, "69492777813", null, null, null },
                    { 508134283, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8494), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 120.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8496), null, "69492777823", null, null, null },
                    { 512207512, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5123), 8.0, "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 56.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5124), null, "69492777811", null, null, null },
                    { 515482641, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8414), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 120.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8415), null, "69492777821", null, null, null },
                    { 517059973, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5240), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 56.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5241), null, "69492777814", null, null, null },
                    { 520826540, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8611), 8.0, "Test Description Draftsman 26", "alexpl_26@gmail.com", "Platanios_Draftsman_26", 120.0, "Alexandros_26", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8612), null, "69492777826", null, null, null },
                    { 521738422, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7350), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 96.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7352), null, "69492777822", null, null, null },
                    { 526525554, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6399), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 80.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6400), null, "69492777816", null, null, null },
                    { 536357466, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4960), 8.0, "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4961), null, "69492777811", null, null, null },
                    { 544154993, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6477), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 80.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6478), null, "69492777818", null, null, null },
                    { 553545634, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7029), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 88.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7030), null, "69492777823", null, null, null },
                    { 553748900, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2738), 8.0, "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 8.0, "Alexandros_6", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2739), null, "6949277786", null, null, null },
                    { 554220349, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6779), 8.0, "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 24.0, "Alexandros_6", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6780), null, "6949277786", null, null, null },
                    { 555422472, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7627), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 104.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7628), null, "69492777819", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 556874724, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3815), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 24.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3816), null, "69492777815", null, null, null },
                    { 557061368, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3574), 8.0, "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 24.0, "Alexandros_9", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3576), null, "6949277789", null, null, null },
                    { 563417689, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(463), 8.0, "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 64.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(464), null, "69492777811", null, null, null },
                    { 563491607, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(201), 8.0, "Test Description Draftsman 25", "alexpl_25@gmail.com", "Platanios_Draftsman_25", 152.0, "Alexandros_25", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(202), null, "69492777825", null, null, null },
                    { 566839487, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(670), 8.0, "Test Description Draftsman 28", "alexpl_28@gmail.com", "Platanios_Draftsman_28", 160.0, "Alexandros_28", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(671), null, "69492777828", null, null, null },
                    { 570677903, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6314), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 80.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6315), null, "69492777814", null, null, null },
                    { 573061751, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8099), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 112.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8100), null, "69492777822", null, null, null },
                    { 574551494, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8214), 8.0, "Test Description Draftsman 25", "alexpl_25@gmail.com", "Platanios_Draftsman_25", 112.0, "Alexandros_25", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8215), null, "69492777825", null, null, null },
                    { 577698500, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5195), 8.0, "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 8.0, "Alexandros_4", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5196), null, "6949277784", null, null, null },
                    { 579864291, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1188), 8.0, "Test Description Engineer 12", "alexpl_12@gmail.com", "Platanios_Engineer_12", 72.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1189), null, "69492777812", null, null, null },
                    { 583286681, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2818), 8.0, "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 8.0, "Alexandros_8", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2819), null, "6949277788", null, null, null },
                    { 594650384, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8731), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 128.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8732), null, "69492777820", null, null, null },
                    { 598299733, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7189), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 96.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7190), null, "69492777818", null, null, null },
                    { 599060365, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7979), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 112.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7981), null, "69492777819", null, null, null },
                    { 603954692, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5836), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 64.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5837), null, "69492777820", null, null, null },
                    { 608140013, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9108), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 128.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9109), null, "69492777824", null, null, null },
                    { 610876981, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5400), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 56.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5401), null, "69492777818", null, null, null },
                    { 621537217, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7941), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 112.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7942), null, "69492777818", null, null, null },
                    { 626031882, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3536), 8.0, "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 24.0, "Alexandros_8", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3537), null, "6949277788", null, null, null },
                    { 627563141, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5757), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 64.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5758), null, "69492777818", null, null, null },
                    { 640483542, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4566), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 40.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4567), null, "69492777815", null, null, null },
                    { 656024953, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7144), 8.0, "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 24.0, "Alexandros_7", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7145), null, "6949277787", null, null, null },
                    { 660379358, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4096), 8.0, "Test Description Draftsman 13", "alexpl_13@gmail.com", "Platanios_Draftsman_13", 32.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4097), null, "69492777813", null, null, null },
                    { 664304542, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7823), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 104.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7824), null, "69492777824", null, null, null },
                    { 668844197, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6753), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 88.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6754), null, "69492777816", null, null, null },
                    { 673952718, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7870), 8.0, "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 32.0, "Alexandros_8", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7872), null, "6949277788", null, null, null },
                    { 684457778, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(828), 8.0, "Test Description Draftsman 31", "alexpl_31@gmail.com", "Platanios_Draftsman_31", 160.0, "Alexandros_31", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(829), null, "69492777831", null, null, null },
                    { 685013777, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4370), 8.0, "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 40.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4371), null, "69492777811", null, null, null },
                    { 691947675, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8335), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 120.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8337), null, "69492777819", null, null, null },
                    { 699881040, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2943), 8.0, "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 8.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2944), null, "69492777811", null, null, null },
                    { 700055225, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9361), 8.0, "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 48.0, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9363), null, "69492777810", null, null, null },
                    { 700639003, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9306), 8.0, "Test Description Draftsman 29", "alexpl_29@gmail.com", "Platanios_Draftsman_29", 128.0, "Alexandros_29", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9307), null, "69492777829", null, null, null },
                    { 700848553, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7310), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 96.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7311), null, "69492777821", null, null, null },
                    { 703120030, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6637), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 80.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6638), null, "69492777822", null, null, null },
                    { 704610586, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6073), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 72.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6074), null, "69492777817", null, null, null },
                    { 704905748, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4408), 8.0, "Test Description Draftsman 12", "alexpl_12@gmail.com", "Platanios_Draftsman_12", 40.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4409), null, "69492777812", null, null, null },
                    { 708238457, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(435), 8.0, "Test Description Draftsman 31", "alexpl_31@gmail.com", "Platanios_Draftsman_31", 152.0, "Alexandros_31", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(436), null, "69492777831", null, null, null },
                    { 708897991, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(358), 8.0, "Test Description Draftsman 29", "alexpl_29@gmail.com", "Platanios_Draftsman_29", 152.0, "Alexandros_29", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(359), null, "69492777829", null, null, null },
                    { 711811650, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(908), 8.0, "Test Description Draftsman 33", "alexpl_33@gmail.com", "Platanios_Draftsman_33", 160.0, "Alexandros_33", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(909), null, "69492777833", null, null, null },
                    { 722709556, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6990), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 88.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6991), null, "69492777822", null, null, null },
                    { 730563116, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5060), 8.0, "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", 80.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5061), null, "69492777812", null, null, null },
                    { 731152258, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3377), 8.0, "Test Description Draftsman 13", "alexpl_13@gmail.com", "Platanios_Draftsman_13", 16.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3378), null, "69492777813", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 732894643, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7228), 8.0, "Test Description Draftsman 19", "alexpl_19@gmail.com", "Platanios_Draftsman_19", 96.0, "Alexandros_19", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7229), null, "69492777819", null, null, null },
                    { 747731393, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(788), 8.0, "Test Description Draftsman 30", "alexpl_30@gmail.com", "Platanios_Draftsman_30", 160.0, "Alexandros_30", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(789), null, "69492777830", null, null, null },
                    { 748089985, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6834), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 88.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6835), null, "69492777818", null, null, null },
                    { 756944325, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3776), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 24.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3777), null, "69492777814", null, null, null },
                    { 757468405, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8297), 8.0, "Test Description Draftsman 27", "alexpl_27@gmail.com", "Platanios_Draftsman_27", 112.0, "Alexandros_27", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8298), null, "69492777827", null, null, null },
                    { 758076496, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3699), 8.0, "Test Description Draftsman 12", "alexpl_12@gmail.com", "Platanios_Draftsman_12", 24.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3700), null, "69492777812", null, null, null },
                    { 758138384, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3139), 8.0, "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 16.0, "Alexandros_7", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3140), null, "6949277787", null, null, null },
                    { 764318575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7545), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 104.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7546), null, "69492777817", null, null, null },
                    { 766218062, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6438), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 80.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6439), null, "69492777817", null, null, null },
                    { 767910259, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9029), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 128.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9030), null, "69492777822", null, null, null },
                    { 768177570, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(81), 8.0, "Test Description Draftsman 31", "alexpl_31@gmail.com", "Platanios_Draftsman_31", 144.0, "Alexandros_31", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(82), null, "69492777831", null, null, null },
                    { 772726601, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3336), 8.0, "Test Description Draftsman 12", "alexpl_12@gmail.com", "Platanios_Draftsman_12", 16.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3337), null, "69492777812", null, null, null },
                    { 780716475, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7428), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 96.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7429), null, "69492777824", null, null, null },
                    { 786029675, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5362), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 56.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5363), null, "69492777817", null, null, null },
                    { 788296494, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7743), 8.0, "Test Description Draftsman 22", "alexpl_22@gmail.com", "Platanios_Draftsman_22", 104.0, "Alexandros_22", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7744), null, "69492777822", null, null, null },
                    { 788706434, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3613), 8.0, "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 24.0, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3614), null, "69492777810", null, null, null },
                    { 789036208, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8689), 8.0, "Test Description Draftsman 28", "alexpl_28@gmail.com", "Platanios_Draftsman_28", 120.0, "Alexandros_28", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8690), null, "69492777828", null, null, null },
                    { 793259629, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5914), 8.0, "Test Description Draftsman 13", "alexpl_13@gmail.com", "Platanios_Draftsman_13", 72.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5915), null, "69492777813", null, null, null },
                    { 799041566, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(316), 8.0, "Test Description Draftsman 28", "alexpl_28@gmail.com", "Platanios_Draftsman_28", 152.0, "Alexandros_28", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(317), null, "69492777828", null, null, null },
                    { 803662679, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5322), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 56.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5323), null, "69492777816", null, null, null },
                    { 807361301, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6192), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 72.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6193), null, "69492777820", null, null, null },
                    { 819506302, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4211), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 32.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4212), null, "69492777816", null, null, null },
                    { 826297463, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(473), 8.0, "Test Description Draftsman 32", "alexpl_32@gmail.com", "Platanios_Draftsman_32", 152.0, "Alexandros_32", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(474), null, "69492777832", null, null, null },
                    { 827797316, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3498), 8.0, "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 24.0, "Alexandros_7", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3499), null, "6949277787", null, null, null },
                    { 829372223, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(708), 8.0, "Test Description Draftsman 29", "alexpl_29@gmail.com", "Platanios_Draftsman_29", 160.0, "Alexandros_29", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(710), null, "69492777829", null, null, null },
                    { 832254558, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6715), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 88.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6716), null, "69492777815", null, null, null },
                    { 832468573, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4015), 8.0, "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 32.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4016), null, "69492777811", null, null, null },
                    { 835828194, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8021), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 112.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8022), null, "69492777820", null, null, null },
                    { 840081643, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(593), 8.0, "Test Description Draftsman 26", "alexpl_26@gmail.com", "Platanios_Draftsman_26", 160.0, "Alexandros_26", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(594), null, "69492777826", null, null, null },
                    { 841400304, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9070), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 128.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9071), null, "69492777823", null, null, null },
                    { 855536730, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6034), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 72.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6036), null, "69492777816", null, null, null },
                    { 855836571, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9191), 8.0, "Test Description Draftsman 26", "alexpl_26@gmail.com", "Platanios_Draftsman_26", 128.0, "Alexandros_26", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9192), null, "69492777826", null, null, null },
                    { 859706642, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9891), 8.0, "Test Description Draftsman 26", "alexpl_26@gmail.com", "Platanios_Draftsman_26", 144.0, "Alexandros_26", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9892), null, "69492777826", null, null, null },
                    { 865256830, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9773), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 144.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9774), null, "69492777823", null, null, null },
                    { 865961158, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8176), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 112.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8177), null, "69492777824", null, null, null },
                    { 872654406, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4609), 8.0, "Test Description Draftsman 16", "alexpl_16@gmail.com", "Platanios_Draftsman_16", 40.0, "Alexandros_16", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4610), null, "69492777816", null, null, null },
                    { 877757047, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5637), 8.0, "Test Description Draftsman 15", "alexpl_15@gmail.com", "Platanios_Draftsman_15", 64.0, "Alexandros_15", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5638), null, "69492777815", null, null, null },
                    { 880228606, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8650), 8.0, "Test Description Draftsman 27", "alexpl_27@gmail.com", "Platanios_Draftsman_27", 120.0, "Alexandros_27", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8651), null, "69492777827", null, null, null },
                    { 883921546, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7467), 8.0, "Test Description Draftsman 25", "alexpl_25@gmail.com", "Platanios_Draftsman_25", 96.0, "Alexandros_25", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7468), null, "69492777825", null, null, null },
                    { 884129966, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3020), 8.0, "Test Description Draftsman 13", "alexpl_13@gmail.com", "Platanios_Draftsman_13", 8.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3021), null, "69492777813", null, null, null },
                    { 895864125, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4498), 8.0, "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4499), null, "6949277786", null, null, null },
                    { 911371951, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5682), 8.0, "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 8.0, "Alexandros_5", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5683), null, "6949277785", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 919764873, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5875), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 64.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5876), null, "69492777821", null, null, null },
                    { 923064980, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2898), 8.0, "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 8.0, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2899), null, "69492777810", null, null, null },
                    { 927071926, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9500), 8.0, "Test Description Draftsman 25", "alexpl_25@gmail.com", "Platanios_Draftsman_25", 136.0, "Alexandros_25", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9501), null, "69492777825", null, null, null },
                    { 932274789, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8258), 8.0, "Test Description Draftsman 26", "alexpl_26@gmail.com", "Platanios_Draftsman_26", 112.0, "Alexandros_26", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8259), null, "69492777826", null, null, null },
                    { 933696665, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3297), 8.0, "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 16.0, "Alexandros_11", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3298), null, "69492777811", null, null, null },
                    { 944108992, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6951), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 88.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6952), null, "69492777821", null, null, null },
                    { 947994999, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4887), 8.0, "Test Description Draftsman 14", "alexpl_14@gmail.com", "Platanios_Draftsman_14", 48.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4888), null, "69492777814", null, null, null },
                    { 952768161, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7268), 8.0, "Test Description Draftsman 20", "alexpl_20@gmail.com", "Platanios_Draftsman_20", 96.0, "Alexandros_20", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7269), null, "69492777820", null, null, null },
                    { 953243561, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1966), 8.0, "Test Description Engineer 13", "alexpl_13@gmail.com", "Platanios_Engineer_13", 80.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1967), null, "69492777813", null, null, null },
                    { 954808257, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4139), 8.0, "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4140), null, "6949277783", null, null, null },
                    { 956372084, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3257), 8.0, "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 16.0, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3259), null, "69492777810", null, null, null },
                    { 964397035, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2328), 8.0, "Test Description Engineer 14", "alexpl_14@gmail.com", "Platanios_Engineer_14", 80.0, "Alexandros_14", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2329), null, "69492777814", null, null, null },
                    { 964486386, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4687), 8.0, "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4688), null, "6949277788", null, null, null },
                    { 964821038, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6597), 8.0, "Test Description Draftsman 21", "alexpl_21@gmail.com", "Platanios_Draftsman_21", 80.0, "Alexandros_21", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6598), null, "69492777821", null, null, null },
                    { 970843530, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6112), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 72.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6113), null, "69492777818", null, null, null },
                    { 975241872, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5520), 8.0, "Test Description Draftsman 12", "alexpl_12@gmail.com", "Platanios_Draftsman_12", 64.0, "Alexandros_12", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5522), null, "69492777812", null, null, null },
                    { 982460119, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6050), 8.0, "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 16.0, "Alexandros_5", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6051), null, "6949277785", null, null, null },
                    { 985560461, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5042), 8.0, "Test Description Draftsman 18", "alexpl_18@gmail.com", "Platanios_Draftsman_18", 48.0, "Alexandros_18", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5043), null, "69492777818", null, null, null },
                    { 986767947, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(123), 8.0, "Test Description Draftsman 23", "alexpl_23@gmail.com", "Platanios_Draftsman_23", 152.0, "Alexandros_23", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(124), null, "69492777823", null, null, null },
                    { 989999630, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6410), 8.0, "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 16.0, "Alexandros_6", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6411), null, "6949277786", null, null, null },
                    { 991314908, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7150), 8.0, "Test Description Draftsman 17", "alexpl_17@gmail.com", "Platanios_Draftsman_17", 96.0, "Alexandros_17", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7151), null, "69492777817", null, null, null },
                    { 995989876, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(512), 8.0, "Test Description Draftsman 24", "alexpl_24@gmail.com", "Platanios_Draftsman_24", 160.0, "Alexandros_24", new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(513), null, "69492777824", null, null, null },
                    { 997005445, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3738), 8.0, "Test Description Draftsman 13", "alexpl_13@gmail.com", "Platanios_Draftsman_13", 24.0, "Alexandros_13", new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3739), null, "69492777813", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 143035603, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 6.0, 1, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 1, "Test Description Project_3", "KL-1", new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, 1L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_1", 5.0, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_3", 1.0, 954808257, new DateTime(2024, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 },
                    { 233519405, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 7.0, 4, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 4, "Test Description Project_12", "KL-2", new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 1L, 8L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_2", 5.0, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_12", 2.0, 178653173, new DateTime(2024, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 },
                    { 311046621, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 14.0, 81, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 81, "Test Description Project_36", "KL-9", new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 91L, 729L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_9", 5.0, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_18", 9.0, 536357466, new DateTime(2030, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 },
                    { 381492202, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 15.0, 100, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 100, "Test Description Project_40", "KL-10", new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 125L, 1000L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_10", 5.0, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_20", 10.0, 730563116, new DateTime(2032, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 },
                    { 413812024, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 11.0, 36, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 36, "Test Description Project_30", "KL-6", new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 27L, 216L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_6", 5.0, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_6", 6.0, 964486386, new DateTime(2027, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 },
                    { 490743076, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 13.0, 64, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 64, "Test Description Project_16", "KL-8", new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 64L, 512L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_8", 5.0, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_8", 8.0, 469159795, new DateTime(2029, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 },
                    { 526583567, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 8.0, 9, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 9, "Test Description Project_6", "KL-3", new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 3L, 27L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_3", 5.0, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_12", 3.0, 487394920, new DateTime(2024, 11, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 },
                    { 532065689, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 9.0, 16, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 16, "Test Description Project_16", "KL-4", new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 8L, 64L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_4", 5.0, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_8", 4.0, 895864125, new DateTime(2025, 6, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 },
                    { 753135377, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 12.0, 49, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 49, "Test Description Project_35", "KL-7", new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 43L, 343L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_7", 5.0, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_14", 7.0, 203971509, new DateTime(2028, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 },
                    { 944859420, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 10.0, 25, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 25, "Test Description Project_10", "KL-5", new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 16L, 125L, new DateTime(2024, 2, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0L, "Project_5", 5.0, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), "Payment Detailes For Project_15", 5.0, 366271791, new DateTime(2026, 3, 21, 17, 40, 32, 482, DateTimeKind.Local).AddTicks(3867), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 313769658, 126090078, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6290), 474890624, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6291) },
                    { 313769658, 134284036, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9629), 483848900, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9630) },
                    { 313769658, 137947935, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3074), 223815795, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3076) },
                    { 313769658, 143798336, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4346), 841732586, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4347) },
                    { 313769658, 152229764, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8548), 876716081, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8549) },
                    { 313769658, 155666760, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7087), 176444457, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7088) },
                    { 313769658, 162691729, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4701), 238499697, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4702) },
                    { 313769658, 169636388, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9943), 839846906, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9944) },
                    { 313769658, 170558935, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3115), 576367210, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3116) },
                    { 313769658, 176897551, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7404), 529690564, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7405) },
                    { 768515225, 178653173, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4319), 215692709, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4320) },
                    { 313769658, 185864171, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4541), 221033043, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4542) },
                    { 313769658, 191064694, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5573), 582003179, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5574) },
                    { 313769658, 200775133, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4500), 372918188, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4501) },
                    { 313769658, 202698441, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4306), 754408793, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4307) },
                    { 768515225, 203971509, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4792), 596600655, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4793) },
                    { 313769658, 210800188, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(411), 142080544, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(412) },
                    { 313769658, 215168238, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7602), 882722939, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7603) },
                    { 313769658, 215293208, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6010), 579196416, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6011) },
                    { 564765687, 215644833, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9747), 216620907, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9749) },
                    { 313769658, 216282448, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5495), 128792383, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5497) },
                    { 313769658, 216889752, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4663), 592247807, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4664) },
                    { 313769658, 229322444, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(57), 545855753, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(58) },
                    { 313769658, 230130259, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5690), 234154840, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5691) },
                    { 313769658, 230521297, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5453), 406777516, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5455) },
                    { 313769658, 236142983, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3434), 775881265, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3435) },
                    { 313769658, 237486015, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(177), 890087857, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(178) },
                    { 313769658, 243978488, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(254), 962737227, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(255) },
                    { 313769658, 247368343, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2996), 319177060, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2997) },
                    { 313769658, 255037696, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3195), 967064607, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3196) },
                    { 313769658, 258994130, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7917), 824801815, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7918) },
                    { 313769658, 262877819, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9244), 613292040, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9245) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 313769658, 265098115, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8470), 461417050, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8472) },
                    { 313769658, 267127597, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(19), 284685748, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(20) },
                    { 313769658, 267807457, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8784), 563748652, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8998) },
                    { 313769658, 272965907, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4187), 186370414, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4188) },
                    { 313769658, 276900212, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6374), 531186542, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6375) },
                    { 313769658, 278305567, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4149), 544151214, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4150) },
                    { 313769658, 280076735, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9476), 420011339, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9477) },
                    { 313769658, 283286648, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2793), 554818111, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2795) },
                    { 313769658, 290348397, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9358), 475125856, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9359) },
                    { 313769658, 290368339, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9710), 289133171, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9711) },
                    { 564765687, 291660336, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8648), 327778754, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8649) },
                    { 313769658, 292729626, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5968), 978581615, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5969) },
                    { 313769658, 299010207, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7796), 252480522, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7797) },
                    { 313769658, 304072659, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3473), 309539929, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3474) },
                    { 313769658, 304106052, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7876), 650746614, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7877) },
                    { 313769658, 307474543, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5729), 356371257, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5730) },
                    { 313769658, 307629443, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9863), 314559884, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9864) },
                    { 313769658, 313419942, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6806), 998897289, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6807) },
                    { 313769658, 313997180, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6249), 171098964, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6250) },
                    { 313769658, 319346589, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6690), 843000459, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6691) },
                    { 564765687, 322718585, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7518), 768491088, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7519) },
                    { 313769658, 330235974, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8389), 827351085, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8390) },
                    { 313769658, 330712458, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5177), 649304700, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5178) },
                    { 313769658, 340810670, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9553), 700636037, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9554) },
                    { 313769658, 343538230, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9282), 311203866, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9283) },
                    { 313769658, 350866850, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4781), 754135039, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4782) },
                    { 313769658, 351261797, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(292), 392061042, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(293) },
                    { 313769658, 351279331, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3673), 853939372, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3674) },
                    { 313769658, 356455722, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9591), 129016100, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9592) },
                    { 313769658, 357604153, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4862), 170488174, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4863) },
                    { 313769658, 358602336, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3233), 424717996, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3234) },
                    { 313769658, 358813399, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7126), 333644641, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7128) },
                    { 313769658, 360165366, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4072), 149934488, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4073) },
                    { 313769658, 361293955, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2872), 416361107, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2873) },
                    { 768515225, 366271791, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4604), 998882701, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4605) },
                    { 313769658, 369394459, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4264), 618050452, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4266) },
                    { 313769658, 370183219, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4823), 276924147, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4824) },
                    { 313769658, 371296478, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5018), 208636563, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5019) },
                    { 313769658, 371458743, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5810), 985663988, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5812) },
                    { 313769658, 374944394, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6569), 232251137, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6571) },
                    { 313769658, 378331638, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9981), 464962792, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9982) },
                    { 313769658, 379229833, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6888), 163870928, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6889) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 313769658, 383171835, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(646), 247592939, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(647) },
                    { 313769658, 383656646, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3950), 858569228, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3951) },
                    { 313769658, 386324389, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4979), 145928222, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4980) },
                    { 313769658, 386672944, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4940), 527673331, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4941) },
                    { 313769658, 392367536, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9748), 441944350, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9749) },
                    { 564765687, 392678020, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(116), 954264649, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(117) },
                    { 564765687, 393798736, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9011), 250966679, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9012) },
                    { 313769658, 399136933, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9396), 757839808, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9397) },
                    { 313769658, 404005877, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7719), 288887234, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7720) },
                    { 313769658, 406266847, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8587), 712520123, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8588) },
                    { 313769658, 409985662, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3910), 261078509, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3912) },
                    { 313769658, 418555899, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5613), 708179967, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5614) },
                    { 313769658, 420440091, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6530), 735095287, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6532) },
                    { 313769658, 421165971, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(884), 224015951, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(886) },
                    { 564765687, 426620968, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(839), 718646296, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(840) },
                    { 313769658, 439400920, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9438), 471579967, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9439) },
                    { 313769658, 442970399, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5296), 770258759, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5298) },
                    { 313769658, 443647012, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9672), 319639769, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9673) },
                    { 313769658, 450192032, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6926), 850047945, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6928) },
                    { 313769658, 452169966, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5098), 555498049, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5099) },
                    { 313769658, 460358536, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7680), 858272566, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7681) },
                    { 313769658, 461213238, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9825), 759571510, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9826) },
                    { 313769658, 468374429, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4741), 322706823, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4742) },
                    { 313769658, 469090975, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9160), 344999084, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9162) },
                    { 768515225, 469159795, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4886), 146527557, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4887) },
                    { 313769658, 475782619, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3871), 522976725, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3872) },
                    { 564765687, 480559478, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1616), 280683094, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1618) },
                    { 313769658, 485059501, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8074), 129833866, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8075) },
                    { 313769658, 485263290, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3989), 134385418, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3990) },
                    { 313769658, 486559565, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8152), 990717753, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8153) },
                    { 768515225, 487394920, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4420), 328681610, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4421) },
                    { 313769658, 488978159, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6167), 910805326, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6168) },
                    { 313769658, 493154393, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(566), 802630535, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(567) },
                    { 564765687, 493243069, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8243), 249902909, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8244) },
                    { 313769658, 496178162, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2708), 517440496, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2710) },
                    { 313769658, 506414347, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5215), 150329534, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5216) },
                    { 313769658, 508134283, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8509), 243668019, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8510) },
                    { 313769658, 512207512, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5137), 698068244, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5138) },
                    { 313769658, 515482641, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8428), 761383547, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8429) },
                    { 313769658, 517059973, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5254), 257942513, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5255) },
                    { 313769658, 520826540, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8626), 856013796, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8627) },
                    { 313769658, 521738422, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7365), 771124143, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7366) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 313769658, 526525554, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6414), 823762827, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6415) },
                    { 768515225, 536357466, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4977), 571704125, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4979) },
                    { 313769658, 544154993, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6492), 232804888, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6493) },
                    { 313769658, 553545634, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7044), 182145751, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7045) },
                    { 313769658, 553748900, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2753), 232050351, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2755) },
                    { 564765687, 554220349, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6794), 202693862, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6795) },
                    { 313769658, 555422472, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7641), 533039068, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7643) },
                    { 313769658, 556874724, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3832), 446594368, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3833) },
                    { 313769658, 557061368, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3589), 439557304, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3590) },
                    { 564765687, 563417689, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(478), 266012130, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(479) },
                    { 313769658, 563491607, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(215), 286319802, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(216) },
                    { 313769658, 566839487, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(684), 209021168, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(685) },
                    { 313769658, 570677903, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6329), 800218336, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6330) },
                    { 313769658, 573061751, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8113), 139810254, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8114) },
                    { 313769658, 574551494, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8233), 297257418, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8234) },
                    { 564765687, 577698500, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5213), 884883485, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5214) },
                    { 564765687, 579864291, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1203), 459606659, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1204) },
                    { 313769658, 583286681, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2833), 660796695, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2834) },
                    { 313769658, 594650384, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8746), 936363669, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8747) },
                    { 313769658, 598299733, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7204), 203862079, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7205) },
                    { 313769658, 599060365, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7997), 770346728, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7998) },
                    { 313769658, 603954692, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5851), 494642463, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5852) },
                    { 313769658, 608140013, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9122), 255286563, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9123) },
                    { 313769658, 610876981, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5415), 212812137, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5416) },
                    { 313769658, 621537217, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7955), 475500754, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7956) },
                    { 313769658, 626031882, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3550), 974395142, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3551) },
                    { 313769658, 627563141, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5771), 311660462, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5772) },
                    { 313769658, 640483542, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4584), 464154202, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4585) },
                    { 564765687, 656024953, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7158), 870294892, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7159) },
                    { 313769658, 660379358, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4110), 559928991, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4111) },
                    { 313769658, 664304542, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7837), 336806101, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7839) },
                    { 313769658, 668844197, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6768), 745441008, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6769) },
                    { 564765687, 673952718, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7885), 420042601, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7886) },
                    { 313769658, 684457778, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(843), 981193108, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(844) },
                    { 313769658, 685013777, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4384), 956425376, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4385) },
                    { 313769658, 691947675, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8350), 369041002, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8351) },
                    { 313769658, 699881040, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2958), 563460111, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2959) },
                    { 564765687, 700055225, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9378), 640200095, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9379) },
                    { 313769658, 700639003, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9320), 915058743, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9321) },
                    { 313769658, 700848553, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7326), 245126154, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7327) },
                    { 313769658, 703120030, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6652), 625987896, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6653) },
                    { 313769658, 704610586, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6088), 785322312, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6089) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 313769658, 704905748, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4423), 767671920, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4424) },
                    { 313769658, 708238457, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(449), 683871817, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(450) },
                    { 313769658, 708897991, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(372), 310256845, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(373) },
                    { 313769658, 711811650, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(922), 697063676, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(923) },
                    { 313769658, 722709556, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7005), 253436467, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7006) },
                    { 768515225, 730563116, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5075), 763772970, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5077) },
                    { 313769658, 731152258, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3395), 460259672, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3396) },
                    { 313769658, 732894643, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7243), 574306832, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7244) },
                    { 313769658, 747731393, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(804), 592652572, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(805) },
                    { 313769658, 748089985, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6848), 713095665, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6849) },
                    { 313769658, 756944325, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3791), 883722418, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3792) },
                    { 313769658, 757468405, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8311), 764054558, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8312) },
                    { 313769658, 758076496, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3714), 340105602, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3715) },
                    { 313769658, 758138384, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3156), 377926556, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3157) },
                    { 313769658, 764318575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7560), 209072909, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7561) },
                    { 313769658, 766218062, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6453), 315429052, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6454) },
                    { 313769658, 767910259, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9045), 153753657, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9047) },
                    { 313769658, 768177570, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(95), 969358017, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(96) },
                    { 313769658, 772726601, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3350), 448069723, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3351) },
                    { 313769658, 780716475, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7443), 862464208, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7444) },
                    { 313769658, 786029675, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5376), 850711317, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5377) },
                    { 313769658, 788296494, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7757), 401112435, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7758) },
                    { 313769658, 788706434, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3628), 719422359, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3629) },
                    { 313769658, 789036208, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8707), 692726267, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8708) },
                    { 313769658, 793259629, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5928), 809253647, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5929) },
                    { 313769658, 799041566, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(330), 290543098, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(331) },
                    { 313769658, 803662679, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5337), 365157268, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5338) },
                    { 313769658, 807361301, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6206), 493854685, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6207) },
                    { 313769658, 819506302, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4226), 652556909, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4227) },
                    { 313769658, 826297463, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(488), 367973373, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(489) },
                    { 313769658, 827797316, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3512), 319628442, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3513) },
                    { 313769658, 829372223, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(722), 650828169, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(724) },
                    { 313769658, 832254558, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6729), 243391676, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6730) },
                    { 313769658, 832468573, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4030), 779643110, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4031) },
                    { 313769658, 835828194, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8035), 659994520, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8037) },
                    { 313769658, 840081643, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(608), 688606300, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(609) },
                    { 313769658, 841400304, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9084), 219110906, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9085) },
                    { 313769658, 855536730, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6049), 537824519, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6050) },
                    { 313769658, 855836571, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9206), 582922141, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9207) },
                    { 313769658, 859706642, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9905), 490031977, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9906) },
                    { 313769658, 865256830, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9786), 182918220, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9788) },
                    { 313769658, 865961158, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8190), 458094251, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8191) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 313769658, 872654406, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4623), 770992921, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4624) },
                    { 313769658, 877757047, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5651), 377374991, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5652) },
                    { 313769658, 880228606, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8664), 666982684, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8665) },
                    { 313769658, 883921546, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7482), 798333605, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7483) },
                    { 313769658, 884129966, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3035), 895205030, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3036) },
                    { 768515225, 895864125, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4513), 850907682, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4515) },
                    { 564765687, 911371951, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5698), 369884297, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5699) },
                    { 313769658, 919764873, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5890), 395914622, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5891) },
                    { 313769658, 923064980, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2918), 497469046, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2919) },
                    { 313769658, 927071926, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9514), 361003834, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9516) },
                    { 313769658, 932274789, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8273), 786962942, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8274) },
                    { 313769658, 933696665, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3311), 678553222, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3312) },
                    { 313769658, 944108992, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6965), 959866380, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6967) },
                    { 313769658, 947994999, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4901), 202878134, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4903) },
                    { 313769658, 952768161, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7283), 239238418, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7284) },
                    { 564765687, 953243561, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1982), 661076011, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1983) },
                    { 768515225, 954808257, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4183), 172778395, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4184) },
                    { 313769658, 956372084, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3272), 814404628, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3273) },
                    { 564765687, 964397035, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2343), 304615214, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2345) },
                    { 768515225, 964486386, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4702), 699183204, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4703) },
                    { 313769658, 964821038, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6612), 509814215, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6614) },
                    { 313769658, 970843530, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6127), 978687448, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6128) },
                    { 313769658, 975241872, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5535), 500656132, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5536) },
                    { 564765687, 982460119, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6065), 587622440, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6066) },
                    { 313769658, 985560461, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5060), 506280350, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5061) },
                    { 313769658, 986767947, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(138), 980643615, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(139) },
                    { 564765687, 989999630, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6428), 261815462, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6429) },
                    { 313769658, 991314908, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7165), 907109553, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7166) },
                    { 313769658, 995989876, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(526), 156495419, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(527) },
                    { 313769658, 997005445, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3752), 298423027, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3753) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "EstimatedMenHours", "LastUpdatedDate", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 153076986, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9761), 215644833, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9762), "ELEC", 753135377 },
                    { 159468105, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6807), 554220349, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6808), "ELEC", 526583567 },
                    { 163051366, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9023), 393798736, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9024), "ELEC", 413812024 },
                    { 192594129, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6440), 989999630, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6441), "HVAC", 233519405 },
                    { 203822145, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7897), 673952718, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7898), "HVAC", 532065689 },
                    { 239738512, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8660), 291660336, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8661), "HVAC", 944859420 },
                    { 360267984, 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(129), 392678020, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(130), "HVAC", 753135377 },
                    { 419009732, 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2356), 964397035, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2357), "HVAC", 381492202 },
                    { 448335680, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5227), 577698500, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5228), "ELEC", 143035603 },
                    { 487375776, 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1219), 579864291, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1220), "ELEC", 311046621 },
                    { 614784198, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8255), 493243069, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8257), "ELEC", 944859420 },
                    { 654339883, 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1994), 953243561, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1995), "ELEC", 381492202 },
                    { 703390199, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6077), 982460119, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6078), "ELEC", 233519405 },
                    { 770545317, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9390), 700055225, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9391), "HVAC", 413812024 },
                    { 776255302, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7530), 322718585, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7532), "ELEC", 532065689 },
                    { 802145424, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7170), 656024953, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7172), "HVAC", 526583567 },
                    { 844525584, 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(851), 426620968, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(852), "HVAC", 490743076 },
                    { 923949480, 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1629), 480559478, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1630), "HVAC", 311046621 },
                    { 933220192, 0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5710), 911371951, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5711), "HVAC", 143035603 },
                    { 938927001, 0, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(490), 563417689, 2345L, 3425L, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(491), "ELEC", 490743076 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 160054278, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5136), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5138), 10000003000.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5137), "Signature 1423440", 29858, 381492202, 10.0, 24.0 },
                    { 215978977, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4571), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4574), 13000.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4572), "Signature 1423420", 84807, 532065689, 4.0, 24.0 },
                    { 229626935, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5041), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5043), 1000003000.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5042), "Signature 142349", 69039, 311046621, 9.0, 17.0 },
                    { 382751809, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4282), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4284), 3010.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4283), "Signature 142346", 51965, 143035603, 1.0, 17.0 },
                    { 389527916, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4761), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4763), 1003000.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4762), "Signature 1423430", 67823, 413812024, 6.0, 24.0 },
                    { 649550020, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4855), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4857), 10003000.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4856), "Signature 1423428", 38666, 753135377, 7.0, 17.0 },
                    { 660203276, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4386), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4388), 3100.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4387), "Signature 142348", 77032, 233519405, 2.0, 24.0 },
                    { 758618220, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4945), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4947), 100003000.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4946), "Signature 142348", 71917, 490743076, 8.0, 24.0 },
                    { 913708595, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4481), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4484), 4000.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4482), "Signature 142346", 35802, 526583567, 3.0, 17.0 },
                    { 963558874, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4670), new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4672), 103000.0, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4671), "Signature 1423430", 35594, 944859420, 5.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 142664814, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4917), null, "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4918), null, "6949277788", null, null, 490743076 },
                    { 156491962, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4453), null, "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4455), null, "6949277783", null, null, 526583567 },
                    { 181643694, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4247), null, "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4249), null, "6949277781", null, null, 143035603 },
                    { 218806901, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4643), null, "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4644), null, "6949277785", null, null, 944859420 },
                    { 389400769, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4355), null, "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4356), null, "6949277782", null, null, 233519405 },
                    { 537176897, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5013), null, "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", null, "Alexandros_9", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5015), null, "6949277789", null, null, 311046621 },
                    { 566644192, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4823), null, "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4824), null, "6949277787", null, null, 753135377 },
                    { 595567101, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4733), null, "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4734), null, "6949277786", null, null, 413812024 },
                    { 764490704, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4544), null, "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4545), null, "6949277784", null, null, 532065689 },
                    { 846898087, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5107), null, "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", null, "Alexandros_10", new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5109), null, "69492777810", null, null, 381492202 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 153076986, 129155049, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9979), 575837839, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9980) },
                    { 153076986, 225122765, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9928), 222248111, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9929) },
                    { 153076986, 225243687, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4), 833674963, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5) },
                    { 153076986, 619582663, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9878), 443728429, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9879) },
                    { 153076986, 660179186, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(32), 298750817, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(34) },
                    { 153076986, 702226633, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9954), 806805268, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9955) },
                    { 153076986, 752452137, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9853), 351664627, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9854) },
                    { 153076986, 761371821, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9903), 532550113, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9904) },
                    { 153076986, 829282103, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(88), 805210141, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(89) },
                    { 153076986, 914860846, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(60), 701345860, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(61) },
                    { 159468105, 135584307, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7105), 480298061, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7106) },
                    { 159468105, 142582586, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7051), 493241462, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7052) },
                    { 159468105, 148318623, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6899), 190213994, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6900) },
                    { 159468105, 247104405, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7026), 859545532, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7027) },
                    { 159468105, 378636249, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6975), 978213167, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6976) },
                    { 159468105, 511734188, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7131), 768653627, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7132) },
                    { 159468105, 694064679, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7000), 602441030, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7001) },
                    { 159468105, 706665583, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7079), 342521908, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7080) },
                    { 159468105, 726167437, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6950), 997745668, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6951) },
                    { 159468105, 832483424, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6924), 177373553, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6926) },
                    { 163051366, 185498615, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9323), 250663941, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9324) },
                    { 163051366, 344585774, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9143), 692828255, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9144) },
                    { 163051366, 400299939, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9298), 962140384, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9299) },
                    { 163051366, 470006686, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9220), 237971482, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9221) },
                    { 163051366, 552444399, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9195), 348706147, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9196) },
                    { 163051366, 557366218, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9271), 257593710, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9272) },
                    { 163051366, 756809049, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9117), 562645532, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9118) },
                    { 163051366, 781178766, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9349), 275937528, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9350) },
                    { 163051366, 791714958, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9168), 867006392, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9169) },
                    { 163051366, 932836394, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9246), 450159342, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9247) },
                    { 192594129, 287617476, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6661), 938759432, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6662) },
                    { 192594129, 310156361, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6686), 413143715, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6687) },
                    { 192594129, 331893785, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6766), 278835344, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6768) },
                    { 192594129, 335827705, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6635), 601155608, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6637) },
                    { 192594129, 450352803, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6610), 850690192, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6611) },
                    { 192594129, 498129296, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6741), 948068514, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6742) },
                    { 192594129, 613399923, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6555), 709183797, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6556) },
                    { 192594129, 634876731, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6530), 729415949, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6531) },
                    { 192594129, 666334130, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6711), 434688642, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6712) },
                    { 192594129, 953171745, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6583), 292553553, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6584) },
                    { 203822145, 125424378, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8216), 861407375, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8217) },
                    { 203822145, 309702424, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7985), 863029979, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7986) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 203822145, 405183198, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8064), 801879321, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8065) },
                    { 203822145, 444123494, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8191), 141892418, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8192) },
                    { 203822145, 451458039, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8089), 294017598, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8090) },
                    { 203822145, 623674570, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8039), 406400421, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8040) },
                    { 203822145, 670398363, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8140), 843809118, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8141) },
                    { 203822145, 714362651, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8013), 542699649, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8015) },
                    { 203822145, 815102037, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8114), 571164724, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8116) },
                    { 203822145, 927831671, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8165), 560583234, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8166) },
                    { 239738512, 136870714, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8959), 905027292, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8960) },
                    { 239738512, 140489700, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8908), 606010033, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8909) },
                    { 239738512, 142648801, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8779), 951604284, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8780) },
                    { 239738512, 184026018, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8855), 576394829, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8856) },
                    { 239738512, 320053352, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8933), 563363849, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8935) },
                    { 239738512, 535403513, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8804), 367874854, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8805) },
                    { 239738512, 663860058, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8984), 822042812, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8985) },
                    { 239738512, 663975630, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8829), 998115732, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8830) },
                    { 239738512, 852390023, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8753), 810928678, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8754) },
                    { 239738512, 918417325, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8882), 287530007, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8883) },
                    { 360267984, 233150110, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(425), 816793233, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(426) },
                    { 360267984, 326540638, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(374), 357960279, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(375) },
                    { 360267984, 333843686, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(297), 903616104, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(298) },
                    { 360267984, 414352804, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(450), 401897681, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(451) },
                    { 360267984, 479317552, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(272), 241912396, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(273) },
                    { 360267984, 487804086, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(348), 661778529, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(349) },
                    { 360267984, 511804555, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(400), 792477055, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(401) },
                    { 360267984, 628856328, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(221), 302275640, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(222) },
                    { 360267984, 814727041, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(246), 459924594, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(247) },
                    { 360267984, 941648312, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(323), 125117080, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(324) },
                    { 419009732, 186127478, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2624), 168415177, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2625) },
                    { 419009732, 292484908, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2651), 693288800, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2652) },
                    { 419009732, 419141959, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2494), 780053909, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2495) },
                    { 419009732, 421479857, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2676), 484270868, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2677) },
                    { 419009732, 471233428, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2520), 786709731, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2521) },
                    { 419009732, 592977060, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2443), 829383034, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2445) },
                    { 419009732, 642130593, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2570), 750259398, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2572) },
                    { 419009732, 806476420, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2596), 230645429, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2597) },
                    { 419009732, 808842392, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2469), 795852474, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2470) },
                    { 419009732, 960839138, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2545), 392347102, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2546) },
                    { 448335680, 336908439, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5458), 161779250, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5459) },
                    { 448335680, 397934389, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5563), 536470010, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5564) },
                    { 448335680, 432446371, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5484), 271666018, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5485) },
                    { 448335680, 635863268, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5536), 598360471, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5537) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 448335680, 653143228, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5419), 476442999, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5420) },
                    { 448335680, 849070291, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5509), 176735044, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5511) },
                    { 448335680, 856861886, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5642), 446185715, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5643) },
                    { 448335680, 915519192, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5590), 952417149, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5591) },
                    { 448335680, 923446112, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5615), 569988047, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5616) },
                    { 448335680, 963647594, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5669), 432097338, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5671) },
                    { 487375776, 326537878, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1559), 894222615, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1561) },
                    { 487375776, 372116733, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1453), 903550208, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1454) },
                    { 487375776, 403279150, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1363), 858121933, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1364) },
                    { 487375776, 566143250, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1337), 835381290, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1338) },
                    { 487375776, 570593680, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1534), 386191849, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1535) },
                    { 487375776, 652308917, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1388), 924256479, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1390) },
                    { 487375776, 664164262, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1585), 550006768, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1587) },
                    { 487375776, 753732222, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1311), 230716454, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1312) },
                    { 487375776, 908291504, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1508), 523576114, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1509) },
                    { 487375776, 982980414, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1482), 329219220, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1483) },
                    { 614784198, 282090611, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8570), 925531393, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8571) },
                    { 614784198, 309831204, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8519), 767764274, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8520) },
                    { 614784198, 430040508, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8621), 850672349, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8623) },
                    { 614784198, 449864917, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8376), 807453821, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8377) },
                    { 614784198, 458515426, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8596), 209253154, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8597) },
                    { 614784198, 540489240, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8493), 856363628, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8494) },
                    { 614784198, 587861826, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8350), 172441240, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8351) },
                    { 614784198, 607277136, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8442), 875908277, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8443) },
                    { 614784198, 645070321, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8545), 827284797, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8546) },
                    { 614784198, 960431783, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8468), 408654448, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8469) },
                    { 654339883, 153883236, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2316), 704273400, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2317) },
                    { 654339883, 249835409, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2185), 204134831, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2187) },
                    { 654339883, 299582653, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2084), 466367138, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2085) },
                    { 654339883, 349110715, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2159), 570142987, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2160) },
                    { 654339883, 393496036, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2109), 289473848, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2110) },
                    { 654339883, 407941066, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2236), 924540061, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2237) },
                    { 654339883, 618022966, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2211), 323452770, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2212) },
                    { 654339883, 723422448, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2134), 834256048, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2135) },
                    { 654339883, 755392679, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2262), 670791150, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2263) },
                    { 654339883, 846542598, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2290), 169196291, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2291) },
                    { 703390199, 164748791, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6297), 424297182, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6298) },
                    { 703390199, 244385540, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6347), 765031773, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6348) },
                    { 703390199, 255730140, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6170), 760305457, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6171) },
                    { 703390199, 268670313, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6322), 778419844, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6323) },
                    { 703390199, 270795434, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6221), 282139900, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6223) },
                    { 703390199, 536220769, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6373), 243927399, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6374) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 703390199, 598587162, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6196), 267629707, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6197) },
                    { 703390199, 858700491, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6272), 652314537, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6273) },
                    { 703390199, 913095177, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6398), 639743725, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6399) },
                    { 703390199, 987964403, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6247), 738347395, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6248) },
                    { 770545317, 209931558, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9690), 559945006, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9691) },
                    { 770545317, 323211992, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9510), 658331475, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9511) },
                    { 770545317, 328775121, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9589), 955097775, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9590) },
                    { 770545317, 376500985, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9536), 630479034, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9538) },
                    { 770545317, 445057233, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9640), 469108055, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9641) },
                    { 770545317, 516685529, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9614), 898010184, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9615) },
                    { 770545317, 625094350, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9715), 274814056, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9716) },
                    { 770545317, 776290986, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9484), 817862329, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9485) },
                    { 770545317, 838718118, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9563), 810669459, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9564) },
                    { 770545317, 997725602, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9665), 774801482, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9666) },
                    { 776255302, 186925853, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7728), 530111067, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7729) },
                    { 776255302, 343095173, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7782), 853876973, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7783) },
                    { 776255302, 438343546, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7858), 557501178, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7859) },
                    { 776255302, 454483425, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7698), 147700431, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7699) },
                    { 776255302, 612606833, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7807), 976468155, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7808) },
                    { 776255302, 663495091, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7832), 660587015, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7833) },
                    { 776255302, 786691874, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7756), 366168400, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7757) },
                    { 776255302, 792714926, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7620), 280246418, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7621) },
                    { 776255302, 799664820, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7672), 199006778, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7673) },
                    { 776255302, 899441946, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7646), 712411807, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7647) },
                    { 802145424, 142268885, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7283), 853853098, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7285) },
                    { 802145424, 147371673, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7385), 240706456, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7386) },
                    { 802145424, 479814511, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7410), 223889499, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7411) },
                    { 802145424, 614410838, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7309), 228701326, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7310) },
                    { 802145424, 824945805, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7438), 760525396, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7440) },
                    { 802145424, 839607623, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7465), 658558790, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7466) },
                    { 802145424, 888887331, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7258), 374066824, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7259) },
                    { 802145424, 900239218, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7334), 306181702, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7335) },
                    { 802145424, 918118004, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7491), 295383748, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7492) },
                    { 802145424, 961821618, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7359), 454240256, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7360) },
                    { 844525584, 150854325, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1125), 311093184, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1126) },
                    { 844525584, 208368607, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1072), 750413329, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1073) },
                    { 844525584, 327635124, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1021), 326017914, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1022) },
                    { 844525584, 353102708, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1047), 136430219, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1048) },
                    { 844525584, 358324960, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1099), 521266707, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1100) },
                    { 844525584, 498124385, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(969), 804886466, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(970) },
                    { 844525584, 544113023, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(943), 285190395, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(945) },
                    { 844525584, 654943240, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(994), 747628596, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(995) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 844525584, 726322713, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1150), 676463017, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1151) },
                    { 844525584, 978935663, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1176), 371183158, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1177) },
                    { 923949480, 316874448, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1873), 538141532, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1874) },
                    { 923949480, 414977781, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1847), 172522077, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1848) },
                    { 923949480, 537122086, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1953), 252615720, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1954) },
                    { 923949480, 676181393, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1796), 795041936, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1797) },
                    { 923949480, 712812147, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1898), 474461264, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1899) },
                    { 923949480, 832286994, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1720), 496771655, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1721) },
                    { 923949480, 835738967, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1745), 279020756, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1746) },
                    { 923949480, 883319855, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1821), 593174996, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1822) },
                    { 923949480, 902671202, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1770), 509556905, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1771) },
                    { 923949480, 978136683, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1924), 311768248, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1925) },
                    { 933220192, 355934799, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5882), 958777569, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5883) },
                    { 933220192, 388545555, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5830), 974076698, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5832) },
                    { 933220192, 528562617, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5908), 536708915, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5909) },
                    { 933220192, 655642603, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6012), 404712587, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6013) },
                    { 933220192, 679946400, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5960), 660582668, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5961) },
                    { 933220192, 759796928, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5857), 332255338, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5858) },
                    { 933220192, 823915987, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5933), 845672736, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5934) },
                    { 933220192, 848391027, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5987), 750304177, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5988) },
                    { 933220192, 873386933, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5805), 389192247, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5806) },
                    { 933220192, 926973593, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6037), 496681349, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6038) },
                    { 938927001, 299593054, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(582), 256817577, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(583) },
                    { 938927001, 321052122, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(761), 853594935, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(762) },
                    { 938927001, 425327971, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(634), 408880086, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(635) },
                    { 938927001, 535211374, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(787), 749497822, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(788) },
                    { 938927001, 583980774, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(685), 794673641, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(686) },
                    { 938927001, 624233010, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(736), 924449694, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(737) },
                    { 938927001, 665701533, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(660), 984927591, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(661) },
                    { 938927001, 722892933, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(711), 841367776, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(712) },
                    { 938927001, 848139046, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(608), 967659973, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(609) },
                    { 938927001, 916062552, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(812), 707465035, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(813) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineOther",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 153076986, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9774), 162613188, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9776) },
                    { 153076986, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9825), 896740914, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9826) },
                    { 153076986, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9787), 939092516, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9788) },
                    { 153076986, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9812), 693835702, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9813) },
                    { 153076986, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9799), 299613328, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9801) },
                    { 159468105, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6822), 538405085, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6823) },
                    { 159468105, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6872), 792010062, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6874) },
                    { 159468105, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6835), 636902063, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6837) },
                    { 159468105, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6860), 346470494, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6861) },
                    { 159468105, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6848), 384290431, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6849) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineOther",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 163051366, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9036), 664463749, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9037) },
                    { 163051366, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9090), 409168200, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9091) },
                    { 163051366, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9049), 269116672, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9050) },
                    { 163051366, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9077), 344625630, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9079) },
                    { 163051366, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9065), 541716414, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9066) },
                    { 192594129, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6452), 169051897, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6453) },
                    { 192594129, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6503), 963629420, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6504) },
                    { 192594129, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6465), 320982794, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6466) },
                    { 192594129, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6491), 804333334, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6492) },
                    { 192594129, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6478), 479849547, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6479) },
                    { 203822145, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7910), 757862582, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7911) },
                    { 203822145, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7958), 559574486, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7960) },
                    { 203822145, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7922), 984457770, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7923) },
                    { 203822145, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7946), 619695690, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7947) },
                    { 203822145, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7934), 126501573, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7935) },
                    { 239738512, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8674), 176350849, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8675) },
                    { 239738512, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8727), 990783983, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8728) },
                    { 239738512, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8686), 217123799, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8687) },
                    { 239738512, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8711), 554002420, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8712) },
                    { 239738512, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8699), 943572840, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8700) },
                    { 360267984, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(142), 206395163, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(143) },
                    { 360267984, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(194), 434538467, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(196) },
                    { 360267984, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(154), 424262337, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(156) },
                    { 360267984, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(179), 360405138, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(181) },
                    { 360267984, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(167), 856960248, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(168) },
                    { 419009732, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2368), 668358661, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2369) },
                    { 419009732, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2417), 879385336, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2418) },
                    { 419009732, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2381), 626925890, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2382) },
                    { 419009732, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2405), 178754202, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2407) },
                    { 419009732, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2393), 229954772, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2394) },
                    { 448335680, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5246), 683470130, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5248) },
                    { 448335680, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5312), 897190326, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5314) },
                    { 448335680, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5270), 682743256, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5272) },
                    { 448335680, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5299), 387702594, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5300) },
                    { 448335680, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5285), 201127238, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5286) },
                    { 487375776, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1234), 223321491, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1235) },
                    { 487375776, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1284), 159885529, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1285) },
                    { 487375776, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1247), 762117504, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1248) },
                    { 487375776, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1272), 765860115, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1273) },
                    { 487375776, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1259), 854476444, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1260) },
                    { 614784198, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8271), 709833809, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8272) },
                    { 614784198, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8321), 424988176, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8322) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineOther",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 614784198, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8284), 650075574, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8285) },
                    { 614784198, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8309), 352069753, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8310) },
                    { 614784198, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8296), 201082328, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(8297) },
                    { 654339883, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2007), 584554978, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2008) },
                    { 654339883, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2057), 464205366, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2058) },
                    { 654339883, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2020), 712072494, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2021) },
                    { 654339883, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2045), 620528264, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2046) },
                    { 654339883, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2032), 899912856, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2033) },
                    { 703390199, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6094), 186124832, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6095) },
                    { 703390199, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6143), 535386203, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6144) },
                    { 703390199, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6106), 330955701, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6107) },
                    { 703390199, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6131), 286072128, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6132) },
                    { 703390199, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6118), 539333231, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(6120) },
                    { 770545317, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9403), 981633172, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9404) },
                    { 770545317, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9458), 876848575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9459) },
                    { 770545317, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9420), 157177569, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9421) },
                    { 770545317, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9445), 497296600, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9446) },
                    { 770545317, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9433), 986920866, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(9434) },
                    { 776255302, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7543), 542862026, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7544) },
                    { 776255302, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7594), 857972376, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7595) },
                    { 776255302, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7555), 540879507, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7556) },
                    { 776255302, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7582), 822128578, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7583) },
                    { 776255302, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7568), 704684204, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7569) },
                    { 802145424, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7184), 965756365, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7185) },
                    { 802145424, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7232), 442138073, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7234) },
                    { 802145424, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7196), 771666488, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7197) },
                    { 802145424, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7220), 841197130, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7221) },
                    { 802145424, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7208), 455982990, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(7209) },
                    { 844525584, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(867), 221221041, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(868) },
                    { 844525584, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(917), 307679106, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(918) },
                    { 844525584, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(880), 922558632, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(881) },
                    { 844525584, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(905), 433218668, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(906) },
                    { 844525584, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(892), 743612640, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(894) },
                    { 923949480, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1643), 587538040, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1644) },
                    { 923949480, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1694), 914734766, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1695) },
                    { 923949480, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1656), 529345734, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1657) },
                    { 923949480, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1681), 595500196, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1682) },
                    { 923949480, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1669), 595279285, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(1670) },
                    { 933220192, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5724), 994817182, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5725) },
                    { 933220192, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5778), 700948081, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5779) },
                    { 933220192, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5736), 987097887, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5737) },
                    { 933220192, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5761), 793102569, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5762) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineOther",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 933220192, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5748), 621102381, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5750) },
                    { 938927001, -1282870503, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(503), 902029329, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(504) },
                    { 938927001, -988727676, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(556), 468281835, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(557) },
                    { 938927001, -497179575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(515), 857983444, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(516) },
                    { 938927001, -227014280, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(543), 135716506, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(544) },
                    { 938927001, 1757089311, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(530), 264761201, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(531) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 153076986, 215168238, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7614), 963264548, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7615) },
                    { 153076986, 258994130, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7929), 284495405, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7930) },
                    { 153076986, 299010207, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7808), 538280628, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7810) },
                    { 153076986, 304106052, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7888), 132163345, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7889) },
                    { 153076986, 404005877, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7731), 977099023, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7732) },
                    { 153076986, 460358536, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7692), 226684931, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7693) },
                    { 153076986, 555422472, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7654), 220582835, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7655) },
                    { 153076986, 664304542, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7849), 782632328, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7850) },
                    { 153076986, 764318575, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7572), 255544200, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7574) },
                    { 153076986, 788296494, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7769), 135856371, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7770) },
                    { 159468105, 143798336, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4358), 421128474, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4359) },
                    { 159468105, 162691729, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4713), 546046376, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4714) },
                    { 159468105, 185864171, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4554), 151430635, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4555) },
                    { 159468105, 200775133, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4514), 592416837, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4515) },
                    { 159468105, 202698441, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4318), 166115375, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4320) },
                    { 159468105, 216889752, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4675), 612989492, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4676) },
                    { 159468105, 640483542, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4596), 370173279, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4597) },
                    { 159468105, 685013777, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4396), 795785962, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4397) },
                    { 159468105, 704905748, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4434), 209548861, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4436) },
                    { 159468105, 872654406, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4635), 152664590, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4636) },
                    { 163051366, 155666760, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7099), 760799869, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7100) },
                    { 163051366, 313419942, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6821), 255981792, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6822) },
                    { 163051366, 379229833, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6900), 246435421, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6901) },
                    { 163051366, 450192032, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6939), 607160913, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6940) },
                    { 163051366, 553545634, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7056), 397279562, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7057) },
                    { 163051366, 668844197, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6780), 984232623, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6781) },
                    { 163051366, 722709556, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7017), 587108930, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7018) },
                    { 163051366, 748089985, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6860), 336612168, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6862) },
                    { 163051366, 832254558, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6741), 527952817, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6742) },
                    { 163051366, 944108992, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6978), 333528479, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6979) },
                    { 192594129, 272965907, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4199), 395503945, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4200) },
                    { 192594129, 278305567, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4161), 274225405, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4162) },
                    { 192594129, 360165366, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4084), 148498331, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4085) },
                    { 192594129, 369394459, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4277), 566124217, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4278) },
                    { 192594129, 383656646, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3962), 496163467, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3964) },
                    { 192594129, 409985662, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3923), 787358985, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3924) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 192594129, 485263290, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4001), 658169819, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4002) },
                    { 192594129, 660379358, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4122), 854030739, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4123) },
                    { 192594129, 819506302, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4238), 565778482, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4239) },
                    { 192594129, 832468573, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4042), 963221193, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4044) },
                    { 203822145, 191064694, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5585), 251915137, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5586) },
                    { 203822145, 230130259, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5702), 250412525, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5703) },
                    { 203822145, 307474543, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5745), 935310343, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5746) },
                    { 203822145, 371458743, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5823), 907079498, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5824) },
                    { 203822145, 418555899, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5625), 741978974, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5626) },
                    { 203822145, 603954692, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5863), 137614979, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5864) },
                    { 203822145, 627563141, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5783), 346161563, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5785) },
                    { 203822145, 877757047, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5663), 528798640, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5664) },
                    { 203822145, 919764873, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5902), 601205588, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5903) },
                    { 203822145, 975241872, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5547), 611477085, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5548) },
                    { 239738512, 276900212, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6386), 817011525, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6387) },
                    { 239738512, 319346589, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6702), 711693004, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6703) },
                    { 239738512, 374944394, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6585), 388504033, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6586) },
                    { 239738512, 420440091, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6542), 773726052, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6544) },
                    { 239738512, 526525554, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6426), 579417096, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6427) },
                    { 239738512, 544154993, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6504), 720099133, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6505) },
                    { 239738512, 570677903, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6344), 462777950, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6345) },
                    { 239738512, 703120030, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6664), 517154944, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6665) },
                    { 239738512, 766218062, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6465), 319149353, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6466) },
                    { 239738512, 964821038, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6624), 851873605, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6626) },
                    { 360267984, 485059501, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8086), 304460682, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8087) },
                    { 360267984, 486559565, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8164), 784146739, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8165) },
                    { 360267984, 573061751, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8125), 559433300, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8126) },
                    { 360267984, 574551494, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8246), 141642156, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8247) },
                    { 360267984, 599060365, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8009), 965685026, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8010) },
                    { 360267984, 621537217, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7967), 586654127, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7968) },
                    { 360267984, 757468405, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8323), 149486024, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8324) },
                    { 360267984, 835828194, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8047), 989279920, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8049) },
                    { 360267984, 865961158, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8202), 893827431, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8203) },
                    { 360267984, 932274789, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8285), 709370881, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8286) },
                    { 419009732, 383171835, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(658), 341206023, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(659) },
                    { 419009732, 421165971, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(896), 910993837, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(897) },
                    { 419009732, 493154393, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(578), 796818171, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(579) },
                    { 419009732, 566839487, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(696), 624741932, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(697) },
                    { 419009732, 684457778, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(855), 591287955, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(856) },
                    { 419009732, 711811650, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(934), 214926395, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(935) },
                    { 419009732, 747731393, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(816), 979575698, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(817) },
                    { 419009732, 829372223, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(775), 503350144, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(776) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 419009732, 840081643, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(620), 888969281, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(621) },
                    { 419009732, 995989876, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(538), 239793347, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(539) },
                    { 448335680, 137947935, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3086), 433812485, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3087) },
                    { 448335680, 247368343, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3008), 199311569, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3009) },
                    { 448335680, 283286648, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2806), 960690471, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2807) },
                    { 448335680, 361293955, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2884), 145527416, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2885) },
                    { 448335680, 496178162, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2722), 764106476, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2723) },
                    { 448335680, 553748900, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2766), 569911935, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2767) },
                    { 448335680, 583286681, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2845), 926165909, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2846) },
                    { 448335680, 699881040, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2970), 786053447, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2971) },
                    { 448335680, 884129966, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3047), 343047039, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3048) },
                    { 448335680, 923064980, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2931), 252695268, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(2932) },
                    { 487375776, 134284036, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9645), 343790249, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9646) },
                    { 487375776, 280076735, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9488), 743942578, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9489) },
                    { 487375776, 290348397, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9370), 246661947, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9371) },
                    { 487375776, 290368339, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9722), 293631697, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9723) },
                    { 487375776, 340810670, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9565), 181165525, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9566) },
                    { 487375776, 356455722, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9603), 537845347, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9604) },
                    { 487375776, 399136933, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9411), 873389064, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9412) },
                    { 487375776, 439400920, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9449), 171775314, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9450) },
                    { 487375776, 443647012, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9683), 314490542, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9685) },
                    { 487375776, 927071926, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9526), 424863627, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9528) },
                    { 614784198, 126090078, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6301), 566352799, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6303) },
                    { 614784198, 215293208, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6022), 677707116, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6023) },
                    { 614784198, 292729626, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5983), 874372292, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5984) },
                    { 614784198, 313997180, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6263), 428377189, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6264) },
                    { 614784198, 488978159, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6179), 209080882, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6180) },
                    { 614784198, 704610586, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6100), 699688197, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6101) },
                    { 614784198, 793259629, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5940), 681902500, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5941) },
                    { 614784198, 807361301, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6221), 255792542, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6222) },
                    { 614784198, 855536730, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6061), 699951056, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6062) },
                    { 614784198, 970843530, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6140), 801435325, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(6141) },
                    { 654339883, 210800188, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(423), 797332918, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(424) },
                    { 654339883, 237486015, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(189), 996069386, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(190) },
                    { 654339883, 243978488, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(265), 703446087, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(267) },
                    { 654339883, 351261797, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(304), 208609243, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(305) },
                    { 654339883, 563491607, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(227), 737967657, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(228) },
                    { 654339883, 708238457, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(460), 891542369, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(462) },
                    { 654339883, 708897991, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(384), 970338287, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(385) },
                    { 654339883, 799041566, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(342), 349663711, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(343) },
                    { 654339883, 826297463, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(500), 920528032, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(501) },
                    { 654339883, 986767947, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(150), 489161006, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(151) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 703390199, 351279331, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3687), 214079035, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3688) },
                    { 703390199, 475782619, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3883), 500320117, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3884) },
                    { 703390199, 556874724, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3844), 372366733, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3845) },
                    { 703390199, 557061368, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3601), 403289819, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3602) },
                    { 703390199, 626031882, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3562), 674573629, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3563) },
                    { 703390199, 756944325, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3803), 354924730, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3804) },
                    { 703390199, 758076496, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3726), 493614276, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3727) },
                    { 703390199, 788706434, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3644), 899844061, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3645) },
                    { 703390199, 827797316, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3524), 564507137, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3525) },
                    { 703390199, 997005445, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3764), 533069901, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3765) },
                    { 770545317, 176897551, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7416), 718020497, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7417) },
                    { 770545317, 358813399, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7138), 897854171, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7139) },
                    { 770545317, 521738422, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7377), 833076245, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7378) },
                    { 770545317, 598299733, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7216), 429644039, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7217) },
                    { 770545317, 700848553, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7338), 528871583, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7339) },
                    { 770545317, 732894643, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7256), 759673565, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7257) },
                    { 770545317, 780716475, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7455), 984807989, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7456) },
                    { 770545317, 883921546, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7531), 415837659, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7532) },
                    { 770545317, 952768161, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7295), 635448675, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7296) },
                    { 770545317, 991314908, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7177), 407906416, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(7178) },
                    { 776255302, 216282448, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5508), 957179061, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5509) },
                    { 776255302, 230521297, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5466), 155907086, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5467) },
                    { 776255302, 330712458, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5189), 255108969, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5190) },
                    { 776255302, 442970399, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5308), 808030354, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5309) },
                    { 776255302, 506414347, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5227), 477232535, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5228) },
                    { 776255302, 512207512, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5150), 340159315, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5151) },
                    { 776255302, 517059973, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5266), 664833054, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5268) },
                    { 776255302, 610876981, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5427), 328776952, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5428) },
                    { 776255302, 786029675, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5388), 737708526, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5389) },
                    { 776255302, 803662679, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5349), 485792788, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5350) },
                    { 802145424, 350866850, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4793), 340972467, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4794) },
                    { 802145424, 357604153, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4874), 246695613, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4875) },
                    { 802145424, 370183219, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4835), 965484846, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4836) },
                    { 802145424, 371296478, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5030), 977501474, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5031) },
                    { 802145424, 386324389, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4991), 452671092, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4992) },
                    { 802145424, 386672944, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4952), 482003562, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4953) },
                    { 802145424, 452169966, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5110), 261387327, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5111) },
                    { 802145424, 468374429, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4753), 637419428, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4754) },
                    { 802145424, 947994999, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4913), 662322742, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(4914) },
                    { 802145424, 985560461, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5071), 732680776, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(5073) },
                    { 844525584, 262877819, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9256), 729337790, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9257) },
                    { 844525584, 267807457, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9016), 509063973, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9017) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 844525584, 343538230, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9294), 967786880, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9295) },
                    { 844525584, 469090975, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9178), 740244676, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9180) },
                    { 844525584, 594650384, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8758), 332348944, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8759) },
                    { 844525584, 608140013, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9134), 882367499, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9135) },
                    { 844525584, 700639003, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9331), 612174284, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9333) },
                    { 844525584, 767910259, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9058), 271975430, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9059) },
                    { 844525584, 841400304, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9096), 560568709, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9097) },
                    { 844525584, 855836571, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9217), 414607443, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9218) },
                    { 923949480, 169636388, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9955), 863078526, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9956) },
                    { 923949480, 229322444, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(69), 931840993, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(70) },
                    { 923949480, 267127597, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(31), 677250784, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(32) },
                    { 923949480, 307629443, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9878), 840929381, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9879) },
                    { 923949480, 378331638, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9993), 951550712, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9994) },
                    { 923949480, 392367536, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9760), 449555221, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9761) },
                    { 923949480, 461213238, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9837), 882167618, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9838) },
                    { 923949480, 768177570, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(110), 957192085, new DateTime(2024, 2, 21, 17, 40, 32, 487, DateTimeKind.Local).AddTicks(111) },
                    { 923949480, 859706642, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9917), 468463347, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9918) },
                    { 923949480, 865256830, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9799), 724920228, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(9800) },
                    { 933220192, 170558935, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3127), 396983237, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3128) },
                    { 933220192, 236142983, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3446), 284545534, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3447) },
                    { 933220192, 255037696, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3207), 718487364, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3208) },
                    { 933220192, 304072659, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3485), 483831463, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3486) },
                    { 933220192, 358602336, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3245), 176179277, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3246) },
                    { 933220192, 731152258, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3406), 350447825, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3408) },
                    { 933220192, 758138384, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3168), 397159454, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3169) },
                    { 933220192, 772726601, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3363), 725697923, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3364) },
                    { 933220192, 933696665, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3323), 831128957, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3324) },
                    { 933220192, 956372084, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3284), 511485292, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(3286) },
                    { 938927001, 152229764, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8560), 884453201, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8561) },
                    { 938927001, 265098115, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8482), 757874559, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8483) },
                    { 938927001, 330235974, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8402), 380892994, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8403) },
                    { 938927001, 406266847, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8599), 262785194, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8600) },
                    { 938927001, 508134283, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8521), 293398101, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8523) },
                    { 938927001, 515482641, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8440), 654326177, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8441) },
                    { 938927001, 520826540, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8638), 411177672, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8639) },
                    { 938927001, 691947675, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8362), 845122854, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8363) },
                    { 938927001, 789036208, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8719), 601511321, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8720) },
                    { 938927001, 880228606, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8676), 732475442, new DateTime(2024, 2, 21, 17, 40, 32, 486, DateTimeKind.Local).AddTicks(8678) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 268830136, 142664814, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4932), 916601724, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4934) },
                    { 268830136, 156491962, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4469), 992866409, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4470) },
                    { 268830136, 181643694, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4267), 596456528, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4268) },
                    { 268830136, 218806901, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4658), 529544087, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4659) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 268830136, 389400769, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4370), 710896111, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4372) },
                    { 268830136, 537176897, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5029), 335382978, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5030) },
                    { 268830136, 566644192, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4842), 623364145, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4844) },
                    { 268830136, 595567101, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4749), 720784673, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4750) },
                    { 268830136, 764490704, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4559), 569385447, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(4560) },
                    { 268830136, 846898087, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5124), 817165220, new DateTime(2024, 2, 21, 17, 40, 32, 485, DateTimeKind.Local).AddTicks(5125) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineDraw_DrawId",
                table: "DisciplineDraw",
                column: "DrawId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineOther_OtherId",
                table: "DisciplineOther",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_EngineerId",
                table: "Disciplines",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_ProjectId",
                table: "Disciplines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesEmployees_EmployeeId",
                table: "DisciplinesEmployees",
                column: "EmployeeId");

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
                name: "FK_DisciplineDraw_Disciplines_DisciplineId",
                table: "DisciplineDraw",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineOther_Disciplines_DisciplineId",
                table: "DisciplineOther",
                column: "DisciplineId",
                principalTable: "Disciplines",
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
                name: "FK_Users_Projects_ProjectId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DisciplineDraw");

            migrationBuilder.DropTable(
                name: "DisciplineOther");

            migrationBuilder.DropTable(
                name: "DisciplinesEmployees");

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
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
