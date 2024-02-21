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
                    { 124157814, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7114), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7115), 0.0, "Draw_10_2" },
                    { 125097152, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(346), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(347), 0.0, "Draw_3_1" },
                    { 126279926, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8988), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8989), 0.0, "Draw_1_2" },
                    { 135349109, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9177), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9178), 0.0, "Draw_1_2" },
                    { 137108697, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6171), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6172), 0.0, "Draw_9_2" },
                    { 144087728, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3590), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3591), 0.0, "Draw_6_2" },
                    { 151728626, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1357), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1358), 0.0, "Draw_4_1" },
                    { 155580825, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4955), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4956), 0.0, "Draw_8_1" },
                    { 155929055, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(425), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(426), 0.0, "Draw_3_1" },
                    { 160158246, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5890), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5891), 0.0, "Draw_9_1" },
                    { 162388751, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6327), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6328), 0.0, "Draw_9_2" },
                    { 167105193, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8495), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8496), 0.0, "Draw_1_1" },
                    { 172475700, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3537), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3539), 0.0, "Draw_6_2" },
                    { 189589600, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9878), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9879), 0.0, "Draw_2_2" },
                    { 190050986, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2551), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2552), 0.0, "Draw_5_2" },
                    { 193250488, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3199), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3200), 0.0, "Draw_6_1" },
                    { 198004878, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3924), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3925), 0.0, "Draw_7_1" },
                    { 199012474, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4149), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4151), 0.0, "Draw_7_1" },
                    { 200287533, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1829), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1830), 0.0, "Draw_4_2" },
                    { 208474016, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4876), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4877), 0.0, "Draw_8_1" },
                    { 210583408, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3036), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3037), 0.0, "Draw_6_1" },
                    { 211180386, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1441), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1442), 0.0, "Draw_4_1" },
                    { 212360921, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5730), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5731), 0.0, "Draw_9_1" },
                    { 223035056, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5759), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5761), 0.0, "Draw_9_1" },
                    { 227331632, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(760), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(761), 0.0, "Draw_3_2" },
                    { 237383908, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4571), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4572), 0.0, "Draw_7_2" },
                    { 238576774, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2217), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2218), 0.0, "Draw_5_1" },
                    { 239010585, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7023), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7024), 0.0, "Draw_10_2" },
                    { 239275707, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4623), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4624), 0.0, "Draw_7_2" },
                    { 247560225, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9516), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9517), 0.0, "Draw_2_1" },
                    { 251952637, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8697), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8698), 0.0, "Draw_1_1" },
                    { 253154260, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4123), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4124), 0.0, "Draw_7_1" },
                    { 255375548, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4439), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4440), 0.0, "Draw_7_2" },
                    { 258563703, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3452), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3453), 0.0, "Draw_6_2" },
                    { 259447805, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6224), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6225), 0.0, "Draw_9_2" },
                    { 259657655, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9151), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9152), 0.0, "Draw_1_2" },
                    { 268427569, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3616), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3617), 0.0, "Draw_6_2" },
                    { 276358076, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9093), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9094), 0.0, "Draw_1_2" },
                    { 279185507, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9648), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9649), 0.0, "Draw_2_1" },
                    { 289064103, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3564), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3565), 0.0, "Draw_6_2" },
                    { 290578995, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6584), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6585), 0.0, "Draw_10_1" },
                    { 291443657, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4182), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4183), 0.0, "Draw_7_1" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 294174979, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(373), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(374), 0.0, "Draw_3_1" },
                    { 295693319, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6824), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6825), 0.0, "Draw_10_1" },
                    { 312854678, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1777), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1778), 0.0, "Draw_4_2" },
                    { 327977317, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8589), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8590), 0.0, "Draw_1_1" },
                    { 344936103, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9904), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9905), 0.0, "Draw_2_2" },
                    { 364557419, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6795), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6796), 0.0, "Draw_10_1" },
                    { 366201091, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(817), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(818), 0.0, "Draw_3_2" },
                    { 368988538, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(843), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(844), 0.0, "Draw_3_2" },
                    { 372851061, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9594), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9596), 0.0, "Draw_2_1" },
                    { 376145341, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2349), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2350), 0.0, "Draw_5_1" },
                    { 377392501, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5785), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5786), 0.0, "Draw_9_1" },
                    { 378074717, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6354), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6355), 0.0, "Draw_9_2" },
                    { 379883771, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5315), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5316), 0.0, "Draw_8_2" },
                    { 380398056, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6717), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6718), 0.0, "Draw_10_1" },
                    { 387453386, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6666), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6667), 0.0, "Draw_10_1" },
                    { 388295824, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7305), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7306), 0.0, "Draw_10_2" },
                    { 391842199, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5916), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5917), 0.0, "Draw_9_1" },
                    { 392585346, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6639), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6640), 0.0, "Draw_10_1" },
                    { 400369288, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1328), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1329), 0.0, "Draw_4_1" },
                    { 403711073, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5942), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5943), 0.0, "Draw_9_1" },
                    { 414986456, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5341), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5342), 0.0, "Draw_8_2" },
                    { 419876541, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7226), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7227), 0.0, "Draw_10_2" },
                    { 421107140, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8671), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8673), 0.0, "Draw_1_1" },
                    { 426655489, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9985), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9986), 0.0, "Draw_2_2" },
                    { 438183408, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9851), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9852), 0.0, "Draw_2_2" },
                    { 446079623, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2323), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2324), 0.0, "Draw_5_1" },
                    { 452117314, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(37), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(38), 0.0, "Draw_2_2" },
                    { 454368886, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4929), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4930), 0.0, "Draw_8_1" },
                    { 454984309, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9203), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9204), 0.0, "Draw_1_2" },
                    { 455137324, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4544), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4546), 0.0, "Draw_7_2" },
                    { 457642718, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5811), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5812), 0.0, "Draw_9_1" },
                    { 459951388, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4823), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4824), 0.0, "Draw_8_1" },
                    { 460605516, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5007), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5008), 0.0, "Draw_8_1" },
                    { 463499635, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8751), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8752), 0.0, "Draw_1_1" },
                    { 463685120, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4067), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4069), 0.0, "Draw_7_1" },
                    { 480666759, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5863), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5864), 0.0, "Draw_9_1" },
                    { 490833622, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5423), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5424), 0.0, "Draw_8_2" },
                    { 492674426, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1301), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1302), 0.0, "Draw_4_1" },
                    { 502945739, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1693), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1694), 0.0, "Draw_4_2" },
                    { 505728369, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9463), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9464), 0.0, "Draw_2_1" },
                    { 506468747, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6691), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6692), 0.0, "Draw_10_1" },
                    { 517104753, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6275), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6276), 0.0, "Draw_9_2" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 522648874, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3977), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3978), 0.0, "Draw_7_1" },
                    { 526790499, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6380), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6381), 0.0, "Draw_9_2" },
                    { 529095930, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6250), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6251), 0.0, "Draw_9_2" },
                    { 535348800, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1274), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1275), 0.0, "Draw_4_1" },
                    { 536904404, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9959), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9960), 0.0, "Draw_2_2" },
                    { 538322461, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1803), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1804), 0.0, "Draw_4_2" },
                    { 541511774, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2737), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2738), 0.0, "Draw_5_2" },
                    { 542906430, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3669), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3670), 0.0, "Draw_6_2" },
                    { 548421999, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1908), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1909), 0.0, "Draw_4_2" },
                    { 550962585, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6743), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6744), 0.0, "Draw_10_1" },
                    { 560953581, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(507), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(508), 0.0, "Draw_3_1" },
                    { 564056852, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2191), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2192), 0.0, "Draw_5_1" },
                    { 564663631, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6198), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6199), 0.0, "Draw_9_2" },
                    { 564900301, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5262), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5263), 0.0, "Draw_8_2" },
                    { 569647897, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1855), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1856), 0.0, "Draw_4_2" },
                    { 576369583, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1248), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1249), 0.0, "Draw_4_1" },
                    { 578084111, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4518), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4519), 0.0, "Draw_7_2" },
                    { 578268356, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3089), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3090), 0.0, "Draw_6_1" },
                    { 588844315, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5502), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5503), 0.0, "Draw_8_2" },
                    { 598657294, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3951), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3952), 0.0, "Draw_7_1" },
                    { 603990466, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(733), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(734), 0.0, "Draw_3_2" },
                    { 605264086, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9014), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9016), 0.0, "Draw_1_2" },
                    { 605751546, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2630), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2631), 0.0, "Draw_5_2" },
                    { 607204301, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1719), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1721), 0.0, "Draw_4_2" },
                    { 607744118, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7278), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7279), 0.0, "Draw_10_2" },
                    { 610862809, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1667), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1668), 0.0, "Draw_4_2" },
                    { 618262958, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8535), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8536), 0.0, "Draw_1_1" },
                    { 628706618, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8645), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8646), 0.0, "Draw_1_1" },
                    { 637680904, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(454), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(455), 0.0, "Draw_3_1" },
                    { 645958021, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1882), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1883), 0.0, "Draw_4_2" },
                    { 656002725, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2296), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2297), 0.0, "Draw_5_1" },
                    { 660352745, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2111), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2112), 0.0, "Draw_5_1" },
                    { 669815718, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(533), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(534), 0.0, "Draw_3_1" },
                    { 681552738, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4981), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4982), 0.0, "Draw_8_1" },
                    { 692506743, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5703), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5704), 0.0, "Draw_9_1" },
                    { 696382759, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5367), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5368), 0.0, "Draw_8_2" },
                    { 708304739, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2683), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2684), 0.0, "Draw_5_2" },
                    { 710306800, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3695), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3696), 0.0, "Draw_6_2" },
                    { 722708772, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3484), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3485), 0.0, "Draw_6_2" },
                    { 726087826, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4492), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4493), 0.0, "Draw_7_2" },
                    { 726157624, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3115), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3117), 0.0, "Draw_6_1" },
                    { 737137338, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2137), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2138), 0.0, "Draw_5_1" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 742755233, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2710), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2711), 0.0, "Draw_5_2" },
                    { 745741236, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(11), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(12), 0.0, "Draw_2_2" },
                    { 747984176, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(320), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(321), 0.0, "Draw_3_1" },
                    { 750319680, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9122), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9124), 0.0, "Draw_1_2" },
                    { 751073324, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5837), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5838), 0.0, "Draw_9_1" },
                    { 752308557, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(869), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(870), 0.0, "Draw_3_2" },
                    { 753074506, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8563), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8564), 0.0, "Draw_1_1" },
                    { 753134554, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5288), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5290), 0.0, "Draw_8_2" },
                    { 755573343, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1221), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1222), 0.0, "Draw_4_1" },
                    { 757903980, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4096), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4097), 0.0, "Draw_7_1" },
                    { 763159153, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3252), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3253), 0.0, "Draw_6_1" },
                    { 765213863, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1388), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1390), 0.0, "Draw_4_1" },
                    { 771744718, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9406), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9408), 0.0, "Draw_2_1" },
                    { 776804467, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2270), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2271), 0.0, "Draw_5_1" },
                    { 784448866, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4903), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4904), 0.0, "Draw_8_1" },
                    { 784752711, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7142), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7143), 0.0, "Draw_10_2" },
                    { 785291279, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7199), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7200), 0.0, "Draw_10_2" },
                    { 795052402, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4466), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4467), 0.0, "Draw_7_2" },
                    { 800090347, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9437), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9438), 0.0, "Draw_2_1" },
                    { 800939871, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9066), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9068), 0.0, "Draw_1_2" },
                    { 804206869, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4003), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4004), 0.0, "Draw_7_1" },
                    { 806367599, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(895), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(896), 0.0, "Draw_3_2" },
                    { 807797621, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2163), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2164), 0.0, "Draw_5_1" },
                    { 824706281, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(63), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(64), 0.0, "Draw_2_2" },
                    { 827179883, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(481), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(482), 0.0, "Draw_3_1" },
                    { 838648838, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1467), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1468), 0.0, "Draw_4_1" },
                    { 839637170, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5476), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5477), 0.0, "Draw_8_2" },
                    { 843517019, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6769), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6770), 0.0, "Draw_10_1" },
                    { 845719290, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(973), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(974), 0.0, "Draw_3_2" },
                    { 852221107, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1750), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1751), 0.0, "Draw_4_2" },
                    { 855041273, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2244), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2245), 0.0, "Draw_5_1" },
                    { 856575687, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1415), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1416), 0.0, "Draw_4_1" },
                    { 874119284, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5393), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5394), 0.0, "Draw_8_2" },
                    { 885995646, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3642), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3644), 0.0, "Draw_6_2" },
                    { 886902401, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(293), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(294), 0.0, "Draw_3_1" },
                    { 887286926, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9569), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9570), 0.0, "Draw_2_1" },
                    { 889634938, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3009), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3010), 0.0, "Draw_6_1" },
                    { 893565406, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2790), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2791), 0.0, "Draw_5_2" },
                    { 895633613, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5449), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5451), 0.0, "Draw_8_2" },
                    { 901368565, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2603), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2604), 0.0, "Draw_5_2" },
                    { 904576322, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6144), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6145), 0.0, "Draw_9_2" },
                    { 908222855, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9041), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9042), 0.0, "Draw_1_2" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 909905250, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3063), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3064), 0.0, "Draw_6_1" },
                    { 911222633, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3511), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3512), 0.0, "Draw_6_2" },
                    { 917218997, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(921), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(922), 0.0, "Draw_3_2" },
                    { 923094204, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4597), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4598), 0.0, "Draw_7_2" },
                    { 930384862, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6612), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6613), 0.0, "Draw_10_1" },
                    { 930756663, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(790), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(791), 0.0, "Draw_3_2" },
                    { 933078882, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8723), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8724), 0.0, "Draw_1_1" },
                    { 935381746, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2764), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2765), 0.0, "Draw_5_2" },
                    { 937808633, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9621), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9622), 0.0, "Draw_2_1" },
                    { 939371374, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4386), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4387), 0.0, "Draw_7_2" },
                    { 944613053, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3172), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3174), 0.0, "Draw_6_1" },
                    { 947992547, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4413), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4414), 0.0, "Draw_7_2" },
                    { 951642965, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4849), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4850), 0.0, "Draw_8_1" },
                    { 954251841, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9489), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9490), 0.0, "Draw_2_1" },
                    { 955812066, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(399), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(400), 0.0, "Draw_3_1" },
                    { 956097083, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2577), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2578), 0.0, "Draw_5_2" },
                    { 960977493, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8961), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8963), 0.0, "Draw_1_2" },
                    { 961291473, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7252), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7253), 0.0, "Draw_10_2" },
                    { 966504821, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5033), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5034), 0.0, "Draw_8_1" },
                    { 969749290, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7170), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7171), 0.0, "Draw_10_2" },
                    { 972347145, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5063), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5064), 0.0, "Draw_8_1" },
                    { 972798363, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7050), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7051), 0.0, "Draw_10_2" },
                    { 977104132, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(947), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(949), 0.0, "Draw_3_2" },
                    { 978830978, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2656), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2657), 0.0, "Draw_5_2" },
                    { 980639687, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3897), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3898), 0.0, "Draw_7_1" },
                    { 981806020, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9933), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9934), 0.0, "Draw_2_2" },
                    { 982617317, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3146), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3147), 0.0, "Draw_6_1" },
                    { 985351435, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9542), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9543), 0.0, "Draw_2_1" },
                    { 986068144, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(88), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(89), 0.0, "Draw_2_2" },
                    { 988884467, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8615), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8616), 0.0, "Draw_1_1" },
                    { 996302412, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3225), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3226), 0.0, "Draw_6_1" },
                    { 997447891, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6301), new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6302), 0.0, "Draw_9_2" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8094), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8096), 0.0, "Administration" },
                    { -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8056), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8057), 0.0, "Printing" },
                    { -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8069), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8070), 0.0, "Outside" },
                    { 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8082), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8083), 0.0, "Meeting" },
                    { 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8040), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8042), 0.0, "Comm" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 273743392, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6818), false, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6819), "Guest" },
                    { 321915116, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6778), true, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6780), "Engineer" },
                    { 420152333, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6825), false, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6826), "Customer" },
                    { 448871580, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6810), true, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6811), "CEO" },
                    { 465113989, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6770), true, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6772), "Draftsmen" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 530412918, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6803), true, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6804), "CTO" },
                    { 557983694, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6786), true, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6787), "Project Manager" },
                    { 674068515, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6793), true, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6797), "COO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 126406750, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7111), 8.0, "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7112), null, "6949277784", null, null, null },
                    { 173753612, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8782), 8.0, "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 8.0, "Alexandros_5", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8783), null, "6949277785", null, null, null },
                    { 177281747, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7212), 8.0, "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7213), null, "6949277785", null, null, null },
                    { 206426702, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7777), 8.0, "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7779), null, "69492777811", null, null, null },
                    { 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8149), 8.0, "Draftsman 1", "draftman1@gmail.com", "Platanios1", 8.0, "Alexandros1", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8151), null, "6949277781", null, null, null },
                    { 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8114), 8.0, "Draftsman 0", "draftman0@gmail.com", "Platanios0", 0.0, "Alexandros0", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8115), null, "6949277780", null, null, null },
                    { 280314330, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(118), 8.0, "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 24.0, "Alexandros_6", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(119), null, "6949277786", null, null, null },
                    { 281760633, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7595), 8.0, "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7597), null, "6949277789", null, null, null },
                    { 305089192, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(560), 8.0, "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 24.0, "Alexandros_7", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(561), null, "6949277787", null, null, null },
                    { 318890540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5089), 8.0, "Test Description Engineer 12", "alexpl_12@gmail.com", "Platanios_Engineer_12", 64.0, "Alexandros_12", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5090), null, "69492777812", null, null, null },
                    { 324944710, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3278), 8.0, "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 48.0, "Alexandros_10", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3279), null, "69492777810", null, null, null },
                    { 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8260), 8.0, "Draftsman 5", "draftman5@gmail.com", "Platanios5", 40.0, "Alexandros5", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8261), null, "6949277785", null, null, null },
                    { 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8204), 8.0, "Draftsman 3", "draftman3@gmail.com", "Platanios3", 24.0, "Alexandros3", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8205), null, "6949277783", null, null, null },
                    { 451740658, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2375), 8.0, "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 40.0, "Alexandros_9", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2376), null, "6949277789", null, null, null },
                    { 485038612, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1493), 8.0, "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 32.0, "Alexandros_8", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1494), null, "6949277788", null, null, null },
                    { 514576397, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7878), 8.0, "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", 80.0, "Alexandros_12", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7879), null, "69492777812", null, null, null },
                    { 516790722, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7686), 8.0, "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7687), null, "69492777810", null, null, null },
                    { 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8177), 8.0, "Draftsman 2", "draftman2@gmail.com", "Platanios2", 16.0, "Alexandros2", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8178), null, "6949277782", null, null, null },
                    { 547401833, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2821), 8.0, "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 48.0, "Alexandros_9", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2822), null, "6949277789", null, null, null },
                    { 611138196, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5968), 8.0, "Test Description Engineer 13", "alexpl_13@gmail.com", "Platanios_Engineer_13", 72.0, "Alexandros_13", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5969), null, "69492777813", null, null, null },
                    { 649034111, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9230), 8.0, "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 16.0, "Alexandros_5", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9231), null, "6949277785", null, null, null },
                    { 650971658, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7500), 8.0, "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7501), null, "6949277788", null, null, null },
                    { 658954403, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4209), 8.0, "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 56.0, "Alexandros_11", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4210), null, "69492777811", null, null, null },
                    { 678453667, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5529), 8.0, "Test Description Engineer 12", "alexpl_12@gmail.com", "Platanios_Engineer_12", 72.0, "Alexandros_12", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5530), null, "69492777812", null, null, null },
                    { 681907837, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4649), 8.0, "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 64.0, "Alexandros_11", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4650), null, "69492777811", null, null, null },
                    { 699182276, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7403), 8.0, "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7404), null, "6949277787", null, null, null },
                    { 708039715, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7307), 8.0, "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7308), null, "6949277786", null, null, null },
                    { 714554655, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8289), 8.0, "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 8.0, "Alexandros_4", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8290), null, "6949277784", null, null, null },
                    { 767913714, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6924), 8.0, "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6925), null, "6949277783", null, null, null },
                    { 768102896, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6407), 8.0, "Test Description Engineer 13", "alexpl_13@gmail.com", "Platanios_Engineer_13", 80.0, "Alexandros_13", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6408), null, "69492777813", null, null, null },
                    { 785641028, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1935), 8.0, "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 40.0, "Alexandros_8", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1936), null, "6949277788", null, null, null },
                    { 804178502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1040), 8.0, "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 32.0, "Alexandros_7", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1041), null, "6949277787", null, null, null },
                    { 818853204, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3721), 8.0, "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 56.0, "Alexandros_10", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3722), null, "69492777810", null, null, null },
                    { 821214298, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6850), 8.0, "Test Description Engineer 14", "alexpl_14@gmail.com", "Platanios_Engineer_14", 80.0, "Alexandros_14", new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6852), null, "69492777814", null, null, null },
                    { 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8231), 8.0, "Draftsman 4", "draftman4@gmail.com", "Platanios4", 32.0, "Alexandros4", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8232), null, "6949277784", null, null, null },
                    { 912876380, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9674), 8.0, "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 16.0, "Alexandros_6", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9675), null, "6949277786", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 213345231, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 8.0, 9, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 9, "Test Description Project_15", "KL-3", new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 3L, 27L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_3", 5.0, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_3", 3.0, 177281747, new DateTime(2024, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 },
                    { 488784035, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 15.0, 100, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 100, "Test Description Project_50", "KL-10", new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 125L, 1000L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_10", 5.0, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_50", 10.0, 514576397, new DateTime(2032, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 },
                    { 523052098, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 13.0, 64, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 64, "Test Description Project_8", "KL-8", new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 64L, 512L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_8", 5.0, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_8", 8.0, 516790722, new DateTime(2029, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 },
                    { 606653781, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 9.0, 16, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 16, "Test Description Project_4", "KL-4", new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 8L, 64L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_4", 5.0, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_20", 4.0, 708039715, new DateTime(2025, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 },
                    { 628505349, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 12.0, 49, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 49, "Test Description Project_14", "KL-7", new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 43L, 343L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_7", 5.0, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_14", 7.0, 281760633, new DateTime(2028, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 },
                    { 691344758, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 14.0, 81, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 81, "Test Description Project_36", "KL-9", new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 91L, 729L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_9", 5.0, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_54", 9.0, 206426702, new DateTime(2030, 11, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 },
                    { 770012583, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 11.0, 36, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 36, "Test Description Project_36", "KL-6", new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 27L, 216L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_6", 5.0, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_24", 6.0, 650971658, new DateTime(2027, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 },
                    { 789757372, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 10.0, 25, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 25, "Test Description Project_25", "KL-5", new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 16L, 125L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_5", 5.0, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_20", 5.0, 699182276, new DateTime(2026, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 },
                    { 798907985, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 6.0, 1, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 1, "Test Description Project_6", "KL-1", new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, 1L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_1", 5.0, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_1", 1.0, 767913714, new DateTime(2024, 3, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 },
                    { 919745685, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 7.0, 4, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 1L, 8L, new DateTime(2024, 2, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0L, "Project_2", 5.0, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), "Payment Detailes For Project_8", 2.0, 126406750, new DateTime(2024, 6, 21, 19, 57, 43, 414, DateTimeKind.Local).AddTicks(7667), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 557983694, 126406750, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7129), 535678459, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7130) },
                    { 321915116, 173753612, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8798), 473150972, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8799) },
                    { 557983694, 177281747, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7230), 534004478, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7231) },
                    { 557983694, 206426702, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7795), 547009544, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7796) },
                    { 465113989, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8164), 132008741, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8165) },
                    { 465113989, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8135), 826230438, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8136) },
                    { 321915116, 280314330, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(133), 347604454, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(134) },
                    { 557983694, 281760633, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7612), 501114744, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7613) },
                    { 321915116, 305089192, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(575), 464223048, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(576) },
                    { 321915116, 318890540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5104), 926254073, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5105) },
                    { 321915116, 324944710, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3295), 303557577, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3296) },
                    { 465113989, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8275), 173757442, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8277) },
                    { 465113989, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8219), 140681449, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8220) },
                    { 321915116, 451740658, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2391), 428363170, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2392) },
                    { 321915116, 485038612, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1509), 981308473, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1510) },
                    { 557983694, 514576397, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7895), 540021790, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7896) },
                    { 557983694, 516790722, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7703), 147500771, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7704) },
                    { 465113989, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8192), 586696821, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8193) },
                    { 321915116, 547401833, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2836), 973854044, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2837) },
                    { 321915116, 611138196, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5983), 206187159, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5985) },
                    { 321915116, 649034111, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9245), 968772353, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9246) },
                    { 557983694, 650971658, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7517), 967513388, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7518) },
                    { 321915116, 658954403, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4225), 984887034, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4226) },
                    { 321915116, 678453667, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5544), 941833888, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5545) },
                    { 321915116, 681907837, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4664), 698687518, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4665) },
                    { 557983694, 699182276, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7421), 869501581, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7422) },
                    { 557983694, 708039715, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7324), 200798120, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7325) },
                    { 321915116, 714554655, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8306), 475164062, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8307) },
                    { 557983694, 767913714, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6978), 801528322, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(6979) },
                    { 321915116, 768102896, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6422), 275413693, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6423) },
                    { 321915116, 785641028, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1950), 945902459, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1951) },
                    { 321915116, 804178502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1057), 791716046, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1058) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 321915116, 818853204, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3736), 630070226, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3737) },
                    { 321915116, 821214298, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6866), 747533738, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6867) },
                    { 465113989, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8247), 198392467, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8248) },
                    { 321915116, 912876380, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9689), 152289264, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9690) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "EstimatedMenHours", "LastUpdatedDate", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 224073926, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3307), 324944710, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3308), "HVAC", 770012583 },
                    { 268712200, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3748), 818853204, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3749), "ELEC", 628505349 },
                    { 305070547, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1962), 785641028, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1963), "ELEC", 789757372 },
                    { 330585972, 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8320), 714554655, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8321), "ELEC", 798907985 },
                    { 359898061, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5997), 611138196, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5998), "HVAC", 691344758 },
                    { 436524194, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4237), 658954403, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4238), "HVAC", 628505349 },
                    { 449561133, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5556), 678453667, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5557), "ELEC", 691344758 },
                    { 453412389, 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9701), 912876380, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9702), "HVAC", 919745685 },
                    { 565048562, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4676), 681907837, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4677), "ELEC", 523052098 },
                    { 622656893, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1071), 804178502, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1072), "ELEC", 606653781 },
                    { 623668436, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(587), 305089192, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(588), "HVAC", 213345231 },
                    { 635345089, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6437), 768102896, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6438), "ELEC", 488784035 },
                    { 725936169, 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8811), 173753612, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8812), "HVAC", 798907985 },
                    { 778088257, 0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9258), 649034111, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9259), "ELEC", 919745685 },
                    { 825595422, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2403), 451740658, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2404), "HVAC", 789757372 },
                    { 841083817, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(146), 280314330, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(147), "ELEC", 213345231 },
                    { 922915668, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1521), 485038612, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1522), "HVAC", 606653781 },
                    { 934296194, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2862), 547401833, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2863), "ELEC", 770012583 },
                    { 982722159, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6877), 821214298, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6879), "HVAC", 488784035 },
                    { 992248016, 0, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5116), 318890540, 2345L, 3425L, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5118), "HVAC", 523052098 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 233354105, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7387), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7389), 13000.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7388), "Signature 1423416", 73641, 606653781, 4.0, 24.0 },
                    { 303254052, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8024), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8026), 10000003000.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8025), "Signature 1423460", 81498, 488784035, 10.0, 24.0 },
                    { 329481683, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7083), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7085), 3010.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7084), "Signature 142343", 81013, 798907985, 1.0, 17.0 },
                    { 370597623, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7483), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7486), 103000.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7485), "Signature 142345", 68331, 789757372, 5.0, 17.0 },
                    { 384739653, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7579), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7581), 1003000.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7580), "Signature 1423436", 62027, 770012583, 6.0, 24.0 },
                    { 393759123, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7762), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7764), 100003000.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7763), "Signature 1423448", 34667, 523052098, 8.0, 24.0 },
                    { 776324171, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7861), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7863), 1000003000.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7862), "Signature 142349", 78607, 691344758, 9.0, 17.0 },
                    { 784162449, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7671), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7673), 10003000.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7672), "Signature 1423421", 70679, 628505349, 7.0, 17.0 },
                    { 790430078, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7193), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7195), 3100.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7194), "Signature 1423410", 42553, 919745685, 2.0, 24.0 },
                    { 933457512, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7291), new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7293), 4000.0, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7292), "Signature 142346", 67030, 213345231, 3.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 206770579, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7644), null, "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7645), null, "6949277787", null, null, 628505349 },
                    { 329567846, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7264), null, "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7265), null, "6949277783", null, null, 213345231 },
                    { 421853485, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7456), null, "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7457), null, "6949277785", null, null, 789757372 },
                    { 426130168, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7995), null, "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", null, "Alexandros_10", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7996), null, "69492777810", null, null, 488784035 },
                    { 472314238, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7360), null, "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7361), null, "6949277784", null, null, 606653781 },
                    { 474888181, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7834), null, "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", null, "Alexandros_9", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7835), null, "6949277789", null, null, 691344758 },
                    { 476007522, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7549), null, "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7550), null, "6949277786", null, null, 770012583 },
                    { 524346132, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7165), null, "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7166), null, "6949277782", null, null, 919745685 },
                    { 693060091, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7735), null, "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7736), null, "6949277788", null, null, 523052098 },
                    { 942891860, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7049), null, "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7050), null, "6949277781", null, null, 798907985 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 224073926, 144087728, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3603), 788277984, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3605) },
                    { 224073926, 172475700, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3551), 756912157, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3553) },
                    { 224073926, 258563703, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3466), 771152576, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3468) },
                    { 224073926, 268427569, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3630), 908250634, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3631) },
                    { 224073926, 289064103, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3578), 678458296, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3579) },
                    { 224073926, 542906430, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3683), 303139098, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3684) },
                    { 224073926, 710306800, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3709), 827622798, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3710) },
                    { 224073926, 722708772, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3498), 225823679, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3499) },
                    { 224073926, 885995646, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3656), 178239612, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3657) },
                    { 224073926, 911222633, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3525), 377743763, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3526) },
                    { 268712200, 198004878, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3938), 795256233, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3940) },
                    { 268712200, 199012474, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4168), 895554914, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4169) },
                    { 268712200, 253154260, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4137), 540752813, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4138) },
                    { 268712200, 291443657, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4196), 217284838, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4198) },
                    { 268712200, 463685120, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4084), 165422573, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4085) },
                    { 268712200, 522648874, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3991), 601177676, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3992) },
                    { 268712200, 598657294, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3965), 462879271, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3966) },
                    { 268712200, 757903980, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4110), 432373623, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4111) },
                    { 268712200, 804206869, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4017), 344099957, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4018) },
                    { 268712200, 980639687, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3911), 392449986, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3912) },
                    { 305070547, 238576774, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2231), 237266257, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2232) },
                    { 305070547, 376145341, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2363), 192633590, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2364) },
                    { 305070547, 446079623, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2337), 738037671, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2338) },
                    { 305070547, 564056852, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2205), 162594252, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2206) },
                    { 305070547, 656002725, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2310), 409589302, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2311) },
                    { 305070547, 660352745, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2125), 180432812, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2126) },
                    { 305070547, 737137338, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2151), 383220994, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2152) },
                    { 305070547, 776804467, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2284), 230110090, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2285) },
                    { 305070547, 807797621, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2177), 427088126, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2178) },
                    { 305070547, 855041273, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2257), 225281469, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2259) },
                    { 330585972, 167105193, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8515), 206330394, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8516) },
                    { 330585972, 251952637, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8711), 153961192, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8712) },
                    { 330585972, 327977317, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8602), 865524354, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8603) },
                    { 330585972, 421107140, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8685), 786093076, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8686) },
                    { 330585972, 463499635, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8768), 813588863, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8770) },
                    { 330585972, 618262958, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8549), 299780619, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8550) },
                    { 330585972, 628706618, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8659), 439861933, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8660) },
                    { 330585972, 753074506, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8576), 729883189, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8577) },
                    { 330585972, 933078882, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8738), 622190606, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8739) },
                    { 330585972, 988884467, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8630), 238971224, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8631) },
                    { 359898061, 137108697, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6185), 885433278, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6186) },
                    { 359898061, 162388751, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6341), 328168726, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6342) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 359898061, 259447805, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6237), 334541334, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6238) },
                    { 359898061, 378074717, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6368), 332467111, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6369) },
                    { 359898061, 517104753, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6289), 597616125, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6290) },
                    { 359898061, 526790499, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6394), 240877548, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6395) },
                    { 359898061, 529095930, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6263), 774405436, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6264) },
                    { 359898061, 564663631, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6211), 285055218, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6213) },
                    { 359898061, 904576322, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6158), 988094828, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6160) },
                    { 359898061, 997447891, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6315), 393859918, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6316) },
                    { 436524194, 237383908, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4584), 340969658, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4586) },
                    { 436524194, 239275707, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4637), 326651822, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4638) },
                    { 436524194, 255375548, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4453), 986509063, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4454) },
                    { 436524194, 455137324, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4558), 267410823, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4559) },
                    { 436524194, 578084111, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4532), 239872709, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4533) },
                    { 436524194, 726087826, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4505), 886915122, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4506) },
                    { 436524194, 795052402, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4479), 673461283, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4480) },
                    { 436524194, 923094204, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4611), 590891572, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4612) },
                    { 436524194, 939371374, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4401), 363806615, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4402) },
                    { 436524194, 947992547, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4427), 270194284, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4428) },
                    { 449561133, 160158246, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5903), 686994993, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5905) },
                    { 449561133, 212360921, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5746), 533286609, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5747) },
                    { 449561133, 223035056, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5773), 130716105, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5774) },
                    { 449561133, 377392501, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5799), 956755776, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5800) },
                    { 449561133, 391842199, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5930), 480318124, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5931) },
                    { 449561133, 403711073, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5956), 599555132, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5957) },
                    { 449561133, 457642718, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5825), 808503532, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5826) },
                    { 449561133, 480666759, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5877), 944897110, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5878) },
                    { 449561133, 692506743, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5717), 881709614, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5719) },
                    { 449561133, 751073324, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5851), 303182787, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5852) },
                    { 453412389, 189589600, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9891), 587436661, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9893) },
                    { 453412389, 344936103, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9919), 154596395, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9920) },
                    { 453412389, 426655489, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9999), 221244236, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local) },
                    { 453412389, 438183408, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9865), 164284469, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9866) },
                    { 453412389, 452117314, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(51), 416460222, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(52) },
                    { 453412389, 536904404, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9973), 815319566, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9974) },
                    { 453412389, 745741236, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(24), 278804016, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(25) },
                    { 453412389, 824706281, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(76), 900221181, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(77) },
                    { 453412389, 981806020, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9947), 393439735, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9948) },
                    { 453412389, 986068144, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(105), 325115379, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(106) },
                    { 565048562, 155580825, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4969), 481597104, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4970) },
                    { 565048562, 208474016, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4890), 668536005, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4891) },
                    { 565048562, 454368886, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4943), 478401156, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4944) },
                    { 565048562, 459951388, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4837), 174280054, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4838) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 565048562, 460605516, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5020), 647415104, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5022) },
                    { 565048562, 681552738, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4995), 490382985, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4996) },
                    { 565048562, 784448866, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4917), 337893547, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4918) },
                    { 565048562, 951642965, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4863), 276653696, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4864) },
                    { 565048562, 966504821, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5047), 182966122, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5048) },
                    { 565048562, 972347145, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5077), 797274574, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5078) },
                    { 622656893, 151728626, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1372), 149474675, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1373) },
                    { 622656893, 211180386, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1455), 743910490, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1456) },
                    { 622656893, 400369288, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1344), 881276895, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1345) },
                    { 622656893, 492674426, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1315), 584870285, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1316) },
                    { 622656893, 535348800, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1288), 168797920, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1289) },
                    { 622656893, 576369583, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1262), 896665184, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1263) },
                    { 622656893, 755573343, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1235), 885514270, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1236) },
                    { 622656893, 765213863, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1403), 719808952, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1404) },
                    { 622656893, 838648838, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1481), 381194791, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1482) },
                    { 622656893, 856575687, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1429), 951277582, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1430) },
                    { 623668436, 227331632, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(777), 806722042, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(778) },
                    { 623668436, 366201091, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(831), 931797616, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(832) },
                    { 623668436, 368988538, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(856), 837431321, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(858) },
                    { 623668436, 603990466, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(747), 693753967, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(749) },
                    { 623668436, 752308557, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(882), 915127504, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(884) },
                    { 623668436, 806367599, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(908), 141822779, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(909) },
                    { 623668436, 845719290, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1025), 620602782, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1026) },
                    { 623668436, 917218997, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(935), 572514069, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(936) },
                    { 623668436, 930756663, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(804), 196888026, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(805) },
                    { 623668436, 977104132, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(961), 593113675, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(962) },
                    { 635345089, 290578995, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6599), 451711006, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6600) },
                    { 635345089, 295693319, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6838), 857098835, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6839) },
                    { 635345089, 364557419, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6812), 298663096, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6813) },
                    { 635345089, 380398056, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6731), 329319207, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6732) },
                    { 635345089, 387453386, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6679), 710078376, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6680) },
                    { 635345089, 392585346, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6653), 270747433, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6654) },
                    { 635345089, 506468747, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6705), 782045247, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6706) },
                    { 635345089, 550962585, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6757), 788685634, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6758) },
                    { 635345089, 843517019, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6783), 985997359, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6784) },
                    { 635345089, 930384862, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6626), 339706208, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6627) },
                    { 725936169, 126279926, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9002), 670095923, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9003) },
                    { 725936169, 135349109, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9190), 872590041, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9191) },
                    { 725936169, 259657655, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9165), 870040436, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9166) },
                    { 725936169, 276358076, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9107), 633387657, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9108) },
                    { 725936169, 454984309, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9217), 952476665, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9218) },
                    { 725936169, 605264086, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9028), 261519450, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9029) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 725936169, 750319680, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9137), 834278315, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9138) },
                    { 725936169, 800939871, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9080), 319217928, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9081) },
                    { 725936169, 908222855, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9054), 531269002, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9055) },
                    { 725936169, 960977493, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8976), 546913298, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8977) },
                    { 778088257, 247560225, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9530), 148025118, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9531) },
                    { 778088257, 279185507, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9661), 898727361, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9662) },
                    { 778088257, 372851061, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9608), 332726004, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9609) },
                    { 778088257, 505728369, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9477), 451444225, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9478) },
                    { 778088257, 771744718, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9421), 470873261, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9422) },
                    { 778088257, 800090347, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9451), 364782269, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9452) },
                    { 778088257, 887286926, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9582), 639086037, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9583) },
                    { 778088257, 937808633, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9635), 525140864, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9636) },
                    { 778088257, 954251841, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9503), 905036661, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9505) },
                    { 778088257, 985351435, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9556), 411318296, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9557) },
                    { 825595422, 190050986, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2565), 622914035, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2566) },
                    { 825595422, 541511774, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2751), 881438602, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2752) },
                    { 825595422, 605751546, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2644), 905018135, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2645) },
                    { 825595422, 708304739, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2697), 794096620, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2698) },
                    { 825595422, 742755233, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2725), 971914747, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2726) },
                    { 825595422, 893565406, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2807), 412379164, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2808) },
                    { 825595422, 901368565, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2618), 492950734, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2619) },
                    { 825595422, 935381746, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2778), 521182698, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2779) },
                    { 825595422, 956097083, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2591), 451208714, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2592) },
                    { 825595422, 978830978, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2670), 677940453, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2671) },
                    { 841083817, 125097152, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(360), 444735057, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(361) },
                    { 841083817, 155929055, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(439), 657996604, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(440) },
                    { 841083817, 294174979, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(386), 860183918, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(387) },
                    { 841083817, 560953581, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(521), 504928504, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(522) },
                    { 841083817, 637680904, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(468), 899427039, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(469) },
                    { 841083817, 669815718, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(547), 926763254, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(548) },
                    { 841083817, 747984176, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(334), 566113660, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(335) },
                    { 841083817, 827179883, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(495), 471007410, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(496) },
                    { 841083817, 886902401, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(307), 161987165, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(308) },
                    { 841083817, 955812066, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(413), 301555972, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(414) },
                    { 922915668, 200287533, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1843), 311725114, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1844) },
                    { 922915668, 312854678, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1790), 131918048, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1792) },
                    { 922915668, 502945739, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1707), 671132182, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1708) },
                    { 922915668, 538322461, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1817), 290299887, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1818) },
                    { 922915668, 548421999, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1922), 866577026, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1923) },
                    { 922915668, 569647897, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1869), 311186767, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1870) },
                    { 922915668, 607204301, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1736), 266982645, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1737) },
                    { 922915668, 610862809, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1681), 920706204, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1682) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineDraw",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 922915668, 645958021, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1895), 902217867, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1896) },
                    { 922915668, 852221107, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1764), 443449806, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1765) },
                    { 934296194, 193250488, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3213), 449091726, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3214) },
                    { 934296194, 210583408, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3050), 236543137, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3051) },
                    { 934296194, 578268356, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3103), 432790628, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3104) },
                    { 934296194, 726157624, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3133), 841783238, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3134) },
                    { 934296194, 763159153, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3266), 914974031, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3267) },
                    { 934296194, 889634938, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3024), 449454208, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3025) },
                    { 934296194, 909905250, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3077), 310537927, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3078) },
                    { 934296194, 944613053, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3187), 932142626, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3188) },
                    { 934296194, 982617317, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3160), 178287276, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3161) },
                    { 934296194, 996302412, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3239), 760582700, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3240) },
                    { 982722159, 124157814, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7129), 360508179, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7130) },
                    { 982722159, 239010585, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7037), 411251317, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7038) },
                    { 982722159, 388295824, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7318), 501803691, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7319) },
                    { 982722159, 419876541, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7240), 221597031, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7241) },
                    { 982722159, 607744118, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7292), 757303836, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7293) },
                    { 982722159, 784752711, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7157), 736032037, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7158) },
                    { 982722159, 785291279, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7213), 573460888, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7214) },
                    { 982722159, 961291473, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7266), 261972289, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7267) },
                    { 982722159, 969749290, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7184), 954885272, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7185) },
                    { 982722159, 972798363, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7064), 235106870, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7065) },
                    { 992248016, 379883771, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5329), 394944528, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5330) },
                    { 992248016, 414986456, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5355), 209801322, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5356) },
                    { 992248016, 490833622, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5437), 687118093, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5438) },
                    { 992248016, 564900301, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5276), 794565154, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5277) },
                    { 992248016, 588844315, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5516), 943152566, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5517) },
                    { 992248016, 696382759, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5381), 533578780, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5382) },
                    { 992248016, 753134554, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5302), 324382946, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5303) },
                    { 992248016, 839637170, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5490), 964968063, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5491) },
                    { 992248016, 874119284, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5410), 686668117, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5411) },
                    { 992248016, 895633613, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5463), 863819795, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5465) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineOther",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 224073926, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3368), 367818509, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3369) },
                    { 224073926, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3332), 912329111, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3333) },
                    { 224073926, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3344), 434283059, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3345) },
                    { 224073926, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3356), 562082356, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3357) },
                    { 224073926, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3320), 218188202, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3321) },
                    { 268712200, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3809), 561216461, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3810) },
                    { 268712200, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3773), 793659892, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3774) },
                    { 268712200, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3785), 726461251, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3786) },
                    { 268712200, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3797), 583147091, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3798) },
                    { 268712200, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3760), 523143686, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3761) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineOther",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 305070547, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2025), 942978036, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2026) },
                    { 305070547, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1988), 253186829, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1989) },
                    { 305070547, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2000), 927265922, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2001) },
                    { 305070547, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2012), 830993545, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2013) },
                    { 305070547, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1976), 194486184, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1977) },
                    { 330585972, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8397), 510036877, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8398) },
                    { 330585972, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8357), 743679675, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8358) },
                    { 330585972, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8371), 879944918, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8372) },
                    { 330585972, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8384), 525856001, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8385) },
                    { 330585972, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8337), 652754280, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8338) },
                    { 359898061, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6058), 400060688, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6059) },
                    { 359898061, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6022), 576591310, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6023) },
                    { 359898061, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6034), 500922405, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6035) },
                    { 359898061, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6046), 991286007, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6047) },
                    { 359898061, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6009), 669501578, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6011) },
                    { 436524194, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4299), 237969169, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4300) },
                    { 436524194, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4262), 357089014, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4263) },
                    { 436524194, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4275), 861640731, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4276) },
                    { 436524194, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4287), 343540163, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4288) },
                    { 436524194, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4250), 754689529, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4251) },
                    { 449561133, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5619), 642702778, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5621) },
                    { 449561133, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5583), 650430180, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5584) },
                    { 449561133, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5595), 347185599, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5596) },
                    { 449561133, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5607), 463330595, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5608) },
                    { 449561133, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5571), 857597793, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5572) },
                    { 453412389, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9764), 848583811, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9765) },
                    { 453412389, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9726), 563984574, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9727) },
                    { 453412389, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9739), 285572210, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9740) },
                    { 453412389, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9752), 233260757, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9753) },
                    { 453412389, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9714), 462615776, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9715) },
                    { 565048562, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4740), 476124151, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4741) },
                    { 565048562, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4704), 648551869, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4705) },
                    { 565048562, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4716), 964638374, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4717) },
                    { 565048562, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4728), 845349025, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4729) },
                    { 565048562, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4689), 856001652, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4690) },
                    { 622656893, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1137), 229055746, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1138) },
                    { 622656893, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1096), 889263157, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1097) },
                    { 622656893, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1108), 471016600, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1109) },
                    { 622656893, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1124), 624585319, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1125) },
                    { 622656893, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1084), 575718308, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1085) },
                    { 623668436, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(648), 966798760, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(649) },
                    { 623668436, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(612), 943218402, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(613) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineOther",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 623668436, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(624), 664834765, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(625) },
                    { 623668436, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(636), 911109461, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(637) },
                    { 623668436, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(600), 994064114, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(601) },
                    { 635345089, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6499), 815702323, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6500) },
                    { 635345089, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6463), 995099403, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6464) },
                    { 635345089, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6475), 664593207, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6476) },
                    { 635345089, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6487), 716831378, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6488) },
                    { 635345089, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6450), 861975633, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6451) },
                    { 725936169, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8875), 992679586, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8876) },
                    { 725936169, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8837), 894882692, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8838) },
                    { 725936169, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8850), 190333196, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8851) },
                    { 725936169, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8862), 694244482, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8863) },
                    { 725936169, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8825), 131844533, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8826) },
                    { 778088257, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9321), 588252900, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9322) },
                    { 778088257, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9284), 706514733, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9285) },
                    { 778088257, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9296), 797662472, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9298) },
                    { 778088257, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9309), 136536184, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9310) },
                    { 778088257, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9271), 924776137, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9272) },
                    { 825595422, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2467), 272037811, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2468) },
                    { 825595422, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2431), 885784070, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2432) },
                    { 825595422, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2443), 398236989, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2444) },
                    { 825595422, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2455), 669546123, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2456) },
                    { 825595422, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2416), 159062209, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2417) },
                    { 841083817, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(208), 788823872, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(209) },
                    { 841083817, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(172), 577835832, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(173) },
                    { 841083817, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(184), 714079266, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(185) },
                    { 841083817, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(196), 963297284, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(197) },
                    { 841083817, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(159), 495348743, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(161) },
                    { 922915668, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1582), 591942026, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1583) },
                    { 922915668, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1546), 862522601, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1547) },
                    { 922915668, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1557), 313130032, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1559) },
                    { 922915668, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1570), 920140593, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1571) },
                    { 922915668, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1534), 666185346, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1535) },
                    { 934296194, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2924), 999616081, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2925) },
                    { 934296194, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2887), 806055852, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2888) },
                    { 934296194, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2899), 298232056, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2900) },
                    { 934296194, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2912), 638809951, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2913) },
                    { 934296194, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2875), 797500625, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2876) },
                    { 982722159, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6939), 801287918, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6940) },
                    { 982722159, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6902), 610204284, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6903) },
                    { 982722159, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6914), 391880247, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6916) },
                    { 982722159, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6927), 684228581, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6928) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineOther",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 982722159, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6890), 635535670, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6891) },
                    { 992248016, -1890745502, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5179), 254655170, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5180) },
                    { 992248016, -1566181790, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5142), 753025831, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5143) },
                    { 992248016, -346057395, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5154), 216063108, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5156) },
                    { 992248016, 344219329, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5166), 501316258, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5167) },
                    { 992248016, 1713946435, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5130), 771467819, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5131) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 224073926, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3393), 423751953, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3394) },
                    { 224073926, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3381), 879114085, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3382) },
                    { 224073926, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3440), 612093091, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3441) },
                    { 224073926, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3417), 715083736, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3418) },
                    { 224073926, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3405), 935538307, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3406) },
                    { 224073926, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3429), 955763450, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3430) },
                    { 268712200, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3838), 706793288, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3839) },
                    { 268712200, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3825), 256116166, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3826) },
                    { 268712200, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3885), 718803274, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3886) },
                    { 268712200, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3862), 785282966, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3863) },
                    { 268712200, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3850), 377443303, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3851) },
                    { 268712200, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3874), 517365224, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(3875) },
                    { 305070547, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2049), 529537763, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2050) },
                    { 305070547, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2037), 237896104, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2038) },
                    { 305070547, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2099), 995059057, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2100) },
                    { 305070547, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2073), 450042913, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2074) },
                    { 305070547, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2061), 918866174, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2062) },
                    { 305070547, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2087), 413174413, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2088) },
                    { 330585972, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8432), 724312791, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8433) },
                    { 330585972, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8416), 444465142, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8417) },
                    { 330585972, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8481), 270335669, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8483) },
                    { 330585972, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8457), 424040080, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8458) },
                    { 330585972, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8445), 402985947, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8446) },
                    { 330585972, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8468), 218578384, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8470) },
                    { 359898061, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6083), 894115775, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6084) },
                    { 359898061, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6070), 508924398, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6071) },
                    { 359898061, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6133), 566329550, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6134) },
                    { 359898061, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6109), 960514383, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6110) },
                    { 359898061, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6097), 434382984, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6098) },
                    { 359898061, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6121), 728741099, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6122) },
                    { 436524194, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4324), 423066983, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4325) },
                    { 436524194, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4311), 639945220, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4313) },
                    { 436524194, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4374), 916696575, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4375) },
                    { 436524194, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4347), 372979643, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4348) },
                    { 436524194, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4335), 128522646, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4336) },
                    { 436524194, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4362), 505354235, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4364) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 449561133, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5644), 191279369, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5645) },
                    { 449561133, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5632), 620670237, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5633) },
                    { 449561133, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5691), 695137334, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5692) },
                    { 449561133, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5668), 456350244, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5669) },
                    { 449561133, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5656), 598913059, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5657) },
                    { 449561133, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5679), 474143594, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5681) },
                    { 453412389, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9792), 467015895, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9793) },
                    { 453412389, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9780), 791844683, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9781) },
                    { 453412389, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9839), 255578231, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9840) },
                    { 453412389, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9816), 679496670, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9817) },
                    { 453412389, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9804), 421894331, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9805) },
                    { 453412389, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9827), 659638889, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9828) },
                    { 565048562, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4764), 482322033, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4765) },
                    { 565048562, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4752), 934109333, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4753) },
                    { 565048562, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4811), 178623968, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4812) },
                    { 565048562, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4788), 776065487, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4789) },
                    { 565048562, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4776), 608695236, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4777) },
                    { 565048562, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4799), 986275864, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(4801) },
                    { 622656893, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1162), 717990736, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1163) },
                    { 622656893, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1149), 774745401, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1150) },
                    { 622656893, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1209), 200470544, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1210) },
                    { 622656893, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1185), 937147929, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1186) },
                    { 622656893, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1174), 167836331, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1175) },
                    { 622656893, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1197), 672242123, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1198) },
                    { 623668436, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(673), 646463252, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(674) },
                    { 623668436, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(661), 501811949, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(662) },
                    { 623668436, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(721), 745468713, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(722) },
                    { 623668436, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(697), 333099238, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(699) },
                    { 623668436, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(685), 927517013, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(686) },
                    { 623668436, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(709), 799600317, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(710) },
                    { 635345089, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6524), 946669035, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6525) },
                    { 635345089, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6512), 292354699, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6513) },
                    { 635345089, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6572), 381480575, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6573) },
                    { 635345089, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6548), 373583200, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6549) },
                    { 635345089, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6536), 726052717, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6537) },
                    { 635345089, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6560), 377591687, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6561) },
                    { 725936169, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8900), 877565484, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8901) },
                    { 725936169, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8888), 599777355, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8889) },
                    { 725936169, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8949), 751144678, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8950) },
                    { 725936169, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8925), 637188548, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8926) },
                    { 725936169, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8912), 466576717, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8913) },
                    { 725936169, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8937), 580488103, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8938) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 778088257, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9345), 883732754, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9346) },
                    { 778088257, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9333), 716173035, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9334) },
                    { 778088257, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9394), 564196666, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9395) },
                    { 778088257, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9369), 488143417, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9370) },
                    { 778088257, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9357), 489370748, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9358) },
                    { 778088257, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9381), 778904784, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(9382) },
                    { 825595422, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2492), 231628920, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2493) },
                    { 825595422, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2480), 254111021, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2481) },
                    { 825595422, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2538), 385245538, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2539) },
                    { 825595422, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2515), 940362194, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2516) },
                    { 825595422, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2503), 787886778, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2504) },
                    { 825595422, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2526), 254366001, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2527) },
                    { 841083817, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(233), 227473647, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(234) },
                    { 841083817, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(221), 914038486, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(222) },
                    { 841083817, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(281), 948178876, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(282) },
                    { 841083817, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(257), 371831080, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(258) },
                    { 841083817, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(245), 498920648, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(246) },
                    { 841083817, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(269), 971867081, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(270) },
                    { 922915668, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1606), 994766829, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1607) },
                    { 922915668, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1594), 275748588, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1595) },
                    { 922915668, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1655), 937143393, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1656) },
                    { 922915668, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1631), 302641463, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1632) },
                    { 922915668, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1618), 811169550, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1620) },
                    { 922915668, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1643), 168425438, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(1644) },
                    { 934296194, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2949), 481476917, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2950) },
                    { 934296194, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2936), 832079962, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2938) },
                    { 934296194, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2997), 194276538, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2998) },
                    { 934296194, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2972), 951942521, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2973) },
                    { 934296194, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2960), 515504783, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2961) },
                    { 934296194, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2984), 842208602, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(2985) },
                    { 982722159, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6964), 631314823, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6965) },
                    { 982722159, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6951), 468045098, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6952) },
                    { 982722159, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7011), 445338412, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7012) },
                    { 982722159, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6988), 214481134, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6989) },
                    { 982722159, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6976), 275151450, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6977) },
                    { 982722159, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(6999), 922605005, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(7000) },
                    { 992248016, 265806865, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5203), 930561281, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5204) },
                    { 992248016, 278756366, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5191), 788215977, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5192) },
                    { 992248016, 354433560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5250), 791720844, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5251) },
                    { 992248016, 437668540, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5227), 149348925, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5228) },
                    { 992248016, 537175940, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5215), 364182267, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5216) },
                    { 992248016, 856309441, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5239), 670968560, new DateTime(2024, 2, 21, 19, 57, 43, 418, DateTimeKind.Local).AddTicks(5240) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 420152333, 206770579, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7659), 991768962, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7660) },
                    { 420152333, 329567846, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7280), 376193921, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7281) },
                    { 420152333, 421853485, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7471), 808070108, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7472) },
                    { 420152333, 426130168, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8012), 675186180, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(8013) },
                    { 420152333, 472314238, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7375), 971956526, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7376) },
                    { 420152333, 474888181, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7849), 905525463, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7850) },
                    { 420152333, 476007522, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7564), 676081368, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7565) },
                    { 420152333, 524346132, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7181), 459363401, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7182) },
                    { 420152333, 693060091, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7750), 937806652, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7752) },
                    { 420152333, 942891860, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7068), 633468745, new DateTime(2024, 2, 21, 19, 57, 43, 417, DateTimeKind.Local).AddTicks(7070) }
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
