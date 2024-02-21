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
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 126011415, new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7986), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7987), 0.0, "Draw_5_0" },
                    { 138196524, new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8209), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8210), 0.0, "Draw_6_1" },
                    { 158941253, new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9059), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9060), 0.0, "Draw_10_2" },
                    { 235027580, new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7205), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7206), 0.0, "Draw_1_2" },
                    { 236599978, new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8452), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8453), 0.0, "Draw_7_3" },
                    { 241775461, new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7858), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7859), 0.0, "Draw_4_4" },
                    { 256226860, new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7189), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7190), 0.0, "Draw_1_1" },
                    { 269260447, new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8480), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8481), 0.0, "Draw_7_5" },
                    { 271765933, new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7873), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7874), 0.0, "Draw_4_5" },
                    { 274973626, new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8407), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8408), 0.0, "Draw_7_0" },
                    { 309736571, new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9073), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9074), 0.0, "Draw_10_3" },
                    { 361231654, new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7602), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7603), 0.0, "Draw_3_1" },
                    { 366046386, new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7372), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7373), 0.0, "Draw_2_0" },
                    { 368659021, new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8255), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8256), 0.0, "Draw_6_4" },
                    { 404832639, new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7402), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7403), 0.0, "Draw_2_2" },
                    { 405515034, new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8689), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8690), 0.0, "Draw_8_5" },
                    { 429075144, new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8437), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8438), 0.0, "Draw_7_2" },
                    { 483515630, new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9028), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9030), 0.0, "Draw_10_0" },
                    { 498663701, new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7631), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7633), 0.0, "Draw_3_3" },
                    { 503967790, new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7617), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7618), 0.0, "Draw_3_2" },
                    { 523698360, new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8847), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8849), 0.0, "Draw_9_3" },
                    { 528661070, new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8241), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8242), 0.0, "Draw_6_3" },
                    { 532521277, new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8674), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8675), 0.0, "Draw_8_4" },
                    { 533113284, new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8804), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8805), 0.0, "Draw_9_0" },
                    { 533130242, new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8606), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8607), 0.0, "Draw_8_1" },
                    { 592234764, new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8002), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8003), 0.0, "Draw_5_1" },
                    { 594060037, new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7388), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7389), 0.0, "Draw_2_1" },
                    { 620685042, new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8270), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8271), 0.0, "Draw_6_5" },
                    { 635764616, new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8620), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8621), 0.0, "Draw_8_2" },
                    { 670012285, new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8224), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8225), 0.0, "Draw_6_2" },
                    { 672934782, new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8876), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8877), 0.0, "Draw_9_5" },
                    { 691712867, new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7447), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7448), 0.0, "Draw_2_5" },
                    { 738513780, new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8423), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8424), 0.0, "Draw_7_1" },
                    { 750269041, new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8044), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8045), 0.0, "Draw_5_4" },
                    { 750833363, new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8466), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8467), 0.0, "Draw_7_4" },
                    { 779389063, new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7829), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7830), 0.0, "Draw_4_2" },
                    { 781988595, new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7663), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7664), 0.0, "Draw_3_5" },
                    { 786132524, new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8194), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8195), 0.0, "Draw_6_0" },
                    { 793635434, new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8016), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8017), 0.0, "Draw_5_2" },
                    { 798686962, new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8833), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8834), 0.0, "Draw_9_2" },
                    { 801429059, new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8819), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8820), 0.0, "Draw_9_1" },
                    { 807226522, new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7220), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7221), 0.0, "Draw_1_3" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 833235654, new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9102), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9103), 0.0, "Draw_10_5" },
                    { 833678976, new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7844), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7845), 0.0, "Draw_4_3" },
                    { 838566972, new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7646), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7647), 0.0, "Draw_3_4" },
                    { 851067792, new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7251), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7252), 0.0, "Draw_1_5" },
                    { 858204379, new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8030), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8031), 0.0, "Draw_5_3" },
                    { 876237329, new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7418), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7420), 0.0, "Draw_2_3" },
                    { 879128797, new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7799), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7801), 0.0, "Draw_4_0" },
                    { 894681149, new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9088), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9089), 0.0, "Draw_10_4" },
                    { 905157911, new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7586), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7588), 0.0, "Draw_3_0" },
                    { 916041032, new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8591), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8592), 0.0, "Draw_8_0" },
                    { 946425178, new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7433), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7434), 0.0, "Draw_2_4" },
                    { 952334337, new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7235), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7236), 0.0, "Draw_1_4" },
                    { 959718857, new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8059), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8060), 0.0, "Draw_5_5" },
                    { 962091772, new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8861), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8863), 0.0, "Draw_9_4" },
                    { 985539437, new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7168), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7169), 0.0, "Draw_1_0" },
                    { 989198723, new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8635), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8636), 0.0, "Draw_8_3" },
                    { 992832785, new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9044), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9046), 0.0, "Draw_10_1" },
                    { 993098849, new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7815), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7816), 0.0, "Draw_4_1" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { -918776116, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6944), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6945), 0.0, "Printing" },
                    { -142061299, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6986), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6987), 0.0, "Administration" },
                    { 57831449, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6958), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6960), 0.0, "Outside" },
                    { 427569166, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6924), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6925), 0.0, "Comm" },
                    { 872600582, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6972), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6973), 0.0, "Meeting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 195245210, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6550), true, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6551), "CTO" },
                    { 348144973, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6519), true, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6520), "Draftsmen" },
                    { 367770026, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6571), false, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6572), "Customer" },
                    { 367953357, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6564), false, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6565), "Guest" },
                    { 393019217, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6542), true, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6544), "COO" },
                    { 407155615, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6535), true, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6536), "Project Manager" },
                    { 547220915, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6528), true, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6529), "Engineer" },
                    { 665738853, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6557), true, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6558), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 165662568, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7487), 8.0, "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7488), null, "6949277785", null, null, null },
                    { 205856808, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7266), 8.0, "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7267), null, "6949277784", null, null, null },
                    { 227046233, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8285), 8.0, "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8286), null, "6949277789", null, null, null },
                    { 272934678, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(211), 8.0, "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(212), null, "6949277784", null, null, null },
                    { 274333420, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6743), 8.0, "Draftsman 1", "draftman1@gmail.com", "Platanios1", 8.0, "Alexandros1", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6744), null, "6949277781", null, null, null },
                    { 294983108, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7887), 8.0, "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7888), null, "6949277787", null, null, null },
                    { 369374765, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8096), 8.0, "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8097), null, "6949277788", null, null, null },
                    { 500666642, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7678), 8.0, "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7679), null, "6949277786", null, null, null },
                    { 567731357, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7004), 8.0, "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7005), null, "6949277783", null, null, null },
                    { 620246847, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6775), 8.0, "Draftsman 2", "draftman2@gmail.com", "Platanios2", 16.0, "Alexandros2", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6776), null, "6949277782", null, null, null },
                    { 632959814, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6673), 8.0, "Draftsman 0", "draftman0@gmail.com", "Platanios0", 0.0, "Alexandros0", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6674), null, "6949277780", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 637822247, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6861), 8.0, "Draftsman 4", "draftman4@gmail.com", "Platanios4", 32.0, "Alexandros4", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6862), null, "6949277784", null, null, null },
                    { 729964389, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8495), 8.0, "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8496), null, "69492777810", null, null, null },
                    { 772186262, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6831), 8.0, "Draftsman 3", "draftman3@gmail.com", "Platanios3", 24.0, "Alexandros3", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6832), null, "6949277783", null, null, null },
                    { 848423748, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9118), 8.0, "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9119), null, "6949277783", null, null, null },
                    { 925303839, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8890), 8.0, "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", 80.0, "Alexandros_12", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8891), null, "69492777812", null, null, null },
                    { 973099714, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6894), 8.0, "Draftsman 5", "draftman5@gmail.com", "Platanios5", 40.0, "Alexandros5", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6895), null, "6949277785", null, null, null },
                    { 991227594, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8704), 8.0, "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8705), null, "69492777811", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "EstimatedMenHours", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { -1841568424, 0, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(243), 272934678, 2345L, 3425L, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(244), "HVAC" },
                    { 1411016944, 0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9152), 848423748, 2345L, 3425L, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9153), "ELEC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 184704260, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 13.0, 64, new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 64, "Test Description Project_32", "KL-8", new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 64L, 512L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_8", 5.0, new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_24", 8.0, 729964389, new DateTime(2029, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 },
                    { 262757431, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 8.0, 9, new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 9, "Test Description Project_9", "KL-3", new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 3L, 27L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_3", 5.0, new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_9", 3.0, 165662568, new DateTime(2024, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 },
                    { 277245177, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 15.0, 100, new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 100, "Test Description Project_10", "KL-10", new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 125L, 1000L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_10", 5.0, new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_20", 10.0, 925303839, new DateTime(2032, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 },
                    { 412458582, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 12.0, 49, new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 49, "Test Description Project_28", "KL-7", new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 43L, 343L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_7", 5.0, new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_42", 7.0, 227046233, new DateTime(2028, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 },
                    { 424302397, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 6.0, 1, new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 1, "Test Description Project_2", "KL-1", new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, 1L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_1", 5.0, new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_4", 1.0, 567731357, new DateTime(2024, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 },
                    { 532145916, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 9.0, 16, new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 16, "Test Description Project_24", "KL-4", new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 8L, 64L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_4", 5.0, new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_24", 4.0, 500666642, new DateTime(2025, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 },
                    { 560772718, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 7.0, 4, new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 1L, 8L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_2", 5.0, new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_4", 2.0, 205856808, new DateTime(2024, 6, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 },
                    { 722938594, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 14.0, 81, new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 81, "Test Description Project_36", "KL-9", new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 91L, 729L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_9", 5.0, new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_27", 9.0, 991227594, new DateTime(2030, 11, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 },
                    { 895862963, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 11.0, 36, new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 36, "Test Description Project_24", "KL-6", new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 27L, 216L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_6", 5.0, new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_12", 6.0, 369374765, new DateTime(2027, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 },
                    { 907868420, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 10.0, 25, new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 25, "Test Description Project_30", "KL-5", new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 16L, 125L, new DateTime(2024, 2, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0L, "Project_5", 5.0, new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), "Payment Detailes For Project_10", 5.0, 294983108, new DateTime(2026, 3, 21, 20, 39, 1, 63, DateTimeKind.Local).AddTicks(840), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 407155615, 165662568, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7504), 311562121, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7505) },
                    { 407155615, 205856808, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7284), 815420845, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7285) },
                    { 407155615, 227046233, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8302), 524831230, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8303) },
                    { 547220915, 272934678, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(229), 575651383, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(230) },
                    { 348144973, 274333420, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6762), 907533343, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6763) },
                    { 407155615, 294983108, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7904), 977310542, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7905) },
                    { 407155615, 369374765, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8114), 411905910, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8115) },
                    { 407155615, 500666642, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7694), 467302537, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7695) },
                    { 407155615, 567731357, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7023), 924113831, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7025) },
                    { 348144973, 620246847, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6818), 382179305, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6819) },
                    { 348144973, 632959814, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6724), 178510899, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6725) },
                    { 348144973, 637822247, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6880), 158451627, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6881) },
                    { 407155615, 729964389, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8512), 340348655, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8513) },
                    { 348144973, 772186262, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6848), 553406086, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6849) },
                    { 547220915, 848423748, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9137), 953045395, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9139) },
                    { 407155615, 925303839, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8907), 203545262, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8908) },
                    { 348144973, 973099714, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6911), 404458478, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(6912) },
                    { 407155615, 991227594, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8721), 978870523, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8722) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1841568424, 126011415, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(724), 145062352, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(725) },
                    { -1841568424, 138196524, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(811), 365959890, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(812) },
                    { -1841568424, 158941253, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1147), 305947295, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1148) },
                    { -1841568424, 235027580, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(423), 936511835, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(424) },
                    { -1841568424, 236599978, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(934), 320301068, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(936) },
                    { -1841568424, 241775461, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(699), 311629112, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(700) },
                    { -1841568424, 256226860, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(410), 631455076, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(411) },
                    { -1841568424, 269260447, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(959), 227039179, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(961) },
                    { -1841568424, 271765933, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(711), 909427894, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(712) },
                    { -1841568424, 274973626, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(873), 403219797, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(874) },
                    { -1841568424, 309736571, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1159), 755261550, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1160) },
                    { -1841568424, 361231654, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(587), 630465495, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(588) },
                    { -1841568424, 366046386, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(499), 258246212, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(500) },
                    { -1841568424, 368659021, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(848), 283307371, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(849) },
                    { -1841568424, 404832639, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(525), 434955052, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(526) },
                    { -1841568424, 405515034, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1035), 306230357, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1036) },
                    { -1841568424, 429075144, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(921), 542189680, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(922) },
                    { -1841568424, 483515630, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1122), 363271194, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1123) },
                    { -1841568424, 498663701, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(612), 207361546, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(613) },
                    { -1841568424, 503967790, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(599), 730336870, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(601) },
                    { -1841568424, 523698360, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1085), 413901298, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1086) },
                    { -1841568424, 528661070, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(835), 655662763, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(837) },
                    { -1841568424, 532521277, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1022), 945770694, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1024) },
                    { -1841568424, 533113284, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1047), 304934775, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1049) },
                    { -1841568424, 533130242, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(985), 601117672, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(986) },
                    { -1841568424, 592234764, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(736), 338683452, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(737) },
                    { -1841568424, 594060037, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(512), 935816533, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(513) },
                    { -1841568424, 620685042, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(861), 692710756, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(862) },
                    { -1841568424, 635764616, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(997), 374247194, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(999) },
                    { -1841568424, 670012285, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(823), 912701342, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(824) },
                    { -1841568424, 672934782, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1110), 847161760, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1111) },
                    { -1841568424, 691712867, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(562), 371143524, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(563) },
                    { -1841568424, 738513780, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(907), 520817082, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(908) },
                    { -1841568424, 750269041, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(773), 928812362, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(774) },
                    { -1841568424, 750833363, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(947), 740547568, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(948) },
                    { -1841568424, 779389063, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(674), 610321867, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(675) },
                    { -1841568424, 781988595, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(637), 943400456, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(638) },
                    { -1841568424, 786132524, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(798), 587005657, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(799) },
                    { -1841568424, 793635434, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(748), 628962344, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(749) },
                    { -1841568424, 798686962, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1072), 768631414, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1073) },
                    { -1841568424, 801429059, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1060), 152018926, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1061) },
                    { -1841568424, 807226522, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(436), 368698444, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(437) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1841568424, 833235654, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1184), 229993318, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1185) },
                    { -1841568424, 833678976, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(686), 182969099, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(687) },
                    { -1841568424, 838566972, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(624), 994098527, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(625) },
                    { -1841568424, 851067792, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(462), 839982187, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(463) },
                    { -1841568424, 858204379, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(761), 791238426, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(762) },
                    { -1841568424, 876237329, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(537), 602826521, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(538) },
                    { -1841568424, 879128797, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(649), 249605093, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(650) },
                    { -1841568424, 894681149, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1172), 171322880, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1173) },
                    { -1841568424, 905157911, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(575), 852861410, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(576) },
                    { -1841568424, 916041032, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(973), 427209651, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(974) },
                    { -1841568424, 946425178, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(550), 643314973, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(551) },
                    { -1841568424, 952334337, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(448), 946831396, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(449) },
                    { -1841568424, 959718857, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(786), 793709838, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(787) },
                    { -1841568424, 962091772, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1097), 870764638, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1098) },
                    { -1841568424, 985539437, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(398), 649334295, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(399) },
                    { -1841568424, 989198723, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1010), 756175702, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1011) },
                    { -1841568424, 992832785, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1135), 551750973, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1136) },
                    { -1841568424, 993098849, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(661), 339494052, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(663) },
                    { 1411016944, 126011415, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9722), 357456982, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9723) },
                    { 1411016944, 138196524, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9832), 960317825, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9833) },
                    { 1411016944, 158941253, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(161), 972381678, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(162) },
                    { 1411016944, 235027580, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9448), 775365367, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9450) },
                    { 1411016944, 236599978, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9930), 677358709, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9932) },
                    { 1411016944, 241775461, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9697), 201759174, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9699) },
                    { 1411016944, 256226860, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9435), 317225889, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9437) },
                    { 1411016944, 269260447, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9954), 462861776, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9956) },
                    { 1411016944, 271765933, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9709), 127865641, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9710) },
                    { 1411016944, 274973626, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9894), 868644392, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9895) },
                    { 1411016944, 309736571, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(174), 267429371, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(175) },
                    { 1411016944, 361231654, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9586), 318538303, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9587) },
                    { 1411016944, 366046386, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9499), 203060943, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9501) },
                    { 1411016944, 368659021, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9870), 212062135, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9871) },
                    { 1411016944, 404832639, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9525), 461562163, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9526) },
                    { 1411016944, 405515034, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(27), 789069514, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(28) },
                    { 1411016944, 429075144, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9918), 997742284, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9920) },
                    { 1411016944, 483515630, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(113), 604608535, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(114) },
                    { 1411016944, 498663701, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9611), 690333073, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9612) },
                    { 1411016944, 503967790, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9598), 257112289, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9599) },
                    { 1411016944, 523698360, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(77), 333027173, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(78) },
                    { 1411016944, 528661070, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9858), 400999175, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9859) },
                    { 1411016944, 532521277, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(15), 519627418, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(16) },
                    { 1411016944, 533113284, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(40), 712888194, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(41) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1411016944, 533130242, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9979), 566059567, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9980) },
                    { 1411016944, 592234764, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9734), 968451385, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9735) },
                    { 1411016944, 594060037, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9512), 876075136, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9514) },
                    { 1411016944, 620685042, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9882), 915767292, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9883) },
                    { 1411016944, 635764616, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9991), 624786022, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9992) },
                    { 1411016944, 670012285, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9844), 428201483, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9845) },
                    { 1411016944, 672934782, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(101), 139849231, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(102) },
                    { 1411016944, 691712867, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9562), 978717190, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9563) },
                    { 1411016944, 738513780, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9906), 517500424, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9907) },
                    { 1411016944, 750269041, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9795), 998462133, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9797) },
                    { 1411016944, 750833363, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9942), 212737835, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9943) },
                    { 1411016944, 779389063, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9673), 753516969, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9674) },
                    { 1411016944, 781988595, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9636), 134629032, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9637) },
                    { 1411016944, 786132524, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9820), 425794874, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9821) },
                    { 1411016944, 793635434, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9746), 302625603, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9747) },
                    { 1411016944, 798686962, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(65), 240789751, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(66) },
                    { 1411016944, 801429059, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(52), 861192510, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(54) },
                    { 1411016944, 807226522, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9460), 692691025, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9462) },
                    { 1411016944, 833235654, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(199), 762853513, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(200) },
                    { 1411016944, 833678976, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9685), 404613203, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9686) },
                    { 1411016944, 838566972, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9623), 638843892, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9624) },
                    { 1411016944, 851067792, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9486), 666096388, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9488) },
                    { 1411016944, 858204379, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9782), 593215864, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9783) },
                    { 1411016944, 876237329, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9537), 360829058, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9538) },
                    { 1411016944, 879128797, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9648), 517625162, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9649) },
                    { 1411016944, 894681149, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(186), 721788961, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(188) },
                    { 1411016944, 905157911, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9574), 219717982, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9575) },
                    { 1411016944, 916041032, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9967), 778555821, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9968) },
                    { 1411016944, 946425178, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9549), 877779440, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9551) },
                    { 1411016944, 952334337, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9473), 192532972, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9474) },
                    { 1411016944, 959718857, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9808), 883701329, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9809) },
                    { 1411016944, 962091772, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(89), 595937980, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(90) },
                    { 1411016944, 985539437, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9417), 422477724, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9419) },
                    { 1411016944, 989198723, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(3), 514429103, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(4) },
                    { 1411016944, 992832785, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(125), 738006150, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(126) },
                    { 1411016944, 993098849, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9660), 548148173, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9661) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1841568424, 274333420, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(335), -1387379596, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(336) },
                    { -1841568424, 620246847, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(347), 1938131348, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(348) },
                    { -1841568424, 632959814, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(322), -914250698, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(323) },
                    { -1841568424, 637822247, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(373), 436440785, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(374) },
                    { -1841568424, 772186262, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(361), 36066961, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(362) },
                    { -1841568424, 973099714, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(385), 1987535610, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(386) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1411016944, 274333420, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9267), 311354182, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9269) },
                    { 1411016944, 620246847, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9280), -2115400270, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9282) },
                    { 1411016944, 632959814, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9247), -2058558407, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9248) },
                    { 1411016944, 637822247, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9306), -488365919, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9307) },
                    { 1411016944, 772186262, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9293), -589439951, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9294) },
                    { 1411016944, 973099714, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9401), 151904161, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9402) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1841568424, -918776116, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(269), 292711535, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(270) },
                    { -1841568424, -142061299, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(310), 552526238, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(311) },
                    { -1841568424, 57831449, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(282), 532316217, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(283) },
                    { -1841568424, 427569166, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(257), 534556309, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(258) },
                    { -1841568424, 872600582, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(297), 858561372, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(298) },
                    { 1411016944, -918776116, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9192), 834517357, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9193) },
                    { 1411016944, -142061299, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9231), 238067874, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9233) },
                    { 1411016944, 57831449, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9205), 181150268, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9206) },
                    { 1411016944, 427569166, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9173), 988297941, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9174) },
                    { 1411016944, 872600582, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9218), 723116112, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9220) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1841568424, 184704260, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1427), -330048643, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1429) },
                    { -1841568424, 262757431, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1271), 933073542, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1272) },
                    { -1841568424, 277245177, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1479), 253212340, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1480) },
                    { -1841568424, 412458582, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1401), 571246147, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1402) },
                    { -1841568424, 424302397, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1217), 1379594518, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1218) },
                    { -1841568424, 532145916, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1320), -477471349, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1322) },
                    { -1841568424, 560772718, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1244), -1379163318, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1245) },
                    { -1841568424, 722938594, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1454), -96978382, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1455) },
                    { -1841568424, 895862963, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1375), -378960610, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1376) },
                    { -1841568424, 907868420, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1349), -1290206032, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1350) },
                    { 1411016944, 184704260, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1414), -1527631840, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1415) },
                    { 1411016944, 262757431, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1257), 1976455541, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1258) },
                    { 1411016944, 277245177, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1466), 996296356, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1468) },
                    { 1411016944, 412458582, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1388), 558562654, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1389) },
                    { 1411016944, 424302397, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1198), -1658347691, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1200) },
                    { 1411016944, 532145916, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1284), 2087972299, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1285) },
                    { 1411016944, 560772718, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1230), 1549812160, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1232) },
                    { 1411016944, 722938594, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1440), -1945794892, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1441) },
                    { 1411016944, 895862963, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1362), 1109007030, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1363) },
                    { 1411016944, 907868420, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1335), 822735110, new DateTime(2024, 2, 21, 20, 39, 1, 67, DateTimeKind.Local).AddTicks(1336) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 124515250, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7119), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7121), 3010.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7120), "Signature 142341", 50735, 424302397, 1.0, 17.0 },
                    { 136223393, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8178), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8180), 1003000.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8179), "Signature 1423430", 10260, 895862963, 6.0, 24.0 },
                    { 248351255, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7783), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7785), 13000.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7784), "Signature 142344", 66152, 532145916, 4.0, 24.0 },
                    { 362265693, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7354), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7356), 3100.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7355), "Signature 1423410", 55399, 560772718, 2.0, 24.0 },
                    { 539208420, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9012), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9014), 10000003000.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9013), "Signature 1423430", 59710, 277245177, 10.0, 24.0 },
                    { 553335151, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8391), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8394), 10003000.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8392), "Signature 142347", 23438, 412458582, 7.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 683133152, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7570), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7572), 4000.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7571), "Signature 1423412", 68350, 262757431, 3.0, 17.0 },
                    { 739336827, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8786), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8789), 1000003000.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8788), "Signature 1423418", 41867, 722938594, 9.0, 17.0 },
                    { 784382094, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8574), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8577), 100003000.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8576), "Signature 1423424", 63926, 184704260, 8.0, 24.0 },
                    { 888344748, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7969), new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7971), 103000.0, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7970), "Signature 1423415", 41362, 907868420, 5.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DailyHours", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 210849466, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7085), null, "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7086), null, "6949277781", null, null, 424302397 },
                    { 214569427, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8544), null, "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8545), null, "6949277788", null, null, 184704260 },
                    { 302915512, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7323), null, "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7324), null, "6949277782", null, null, 560772718 },
                    { 377442230, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8757), null, "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", null, "Alexandros_9", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8758), null, "6949277789", null, null, 722938594 },
                    { 377574943, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8361), null, "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8362), null, "6949277787", null, null, 412458582 },
                    { 680407654, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7939), null, "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7940), null, "6949277785", null, null, 907868420 },
                    { 720768162, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8148), null, "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8149), null, "6949277786", null, null, 895862963 },
                    { 727266419, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8979), null, "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", null, "Alexandros_10", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8980), null, "69492777810", null, null, 277245177 },
                    { 810961166, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7539), null, "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7540), null, "6949277783", null, null, 262757431 },
                    { 829205787, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7729), null, "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7730), null, "6949277784", null, null, 532145916 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 367770026, 210849466, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7105), 763412575, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7106) },
                    { 367770026, 214569427, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8561), 278665877, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8562) },
                    { 367770026, 302915512, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7340), 942706184, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7342) },
                    { 367770026, 377442230, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8774), 361975268, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8775) },
                    { 367770026, 377574943, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8378), 925780931, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8379) },
                    { 367770026, 680407654, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7955), 133186814, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7956) },
                    { 367770026, 720768162, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8165), 458341978, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8166) },
                    { 367770026, 727266419, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(8998), 960336376, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(9000) },
                    { 367770026, 810961166, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7556), 809764699, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7557) },
                    { 367770026, 829205787, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7769), 200118372, new DateTime(2024, 2, 21, 20, 39, 1, 66, DateTimeKind.Local).AddTicks(7770) }
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
