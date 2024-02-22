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
                name: "DailyHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyHour", x => x.Id);
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
                    { 131892428, new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6533), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6535), 0.0, "Draw_10_2" },
                    { 144196292, new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5468), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5469), 0.0, "Draw_4_2" },
                    { 146258647, new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6153), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6154), 0.0, "Draw_8_0" },
                    { 167227493, new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5688), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5689), 0.0, "Draw_5_5" },
                    { 169739827, new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5300), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5301), 0.0, "Draw_3_3" },
                    { 173546422, new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5868), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5869), 0.0, "Draw_6_5" },
                    { 188326353, new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6181), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6182), 0.0, "Draw_8_2" },
                    { 190850575, new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5674), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5675), 0.0, "Draw_5_4" },
                    { 197575157, new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5979), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5980), 0.0, "Draw_7_0" },
                    { 210987365, new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5634), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5635), 0.0, "Draw_5_1" },
                    { 219832217, new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5106), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5107), 0.0, "Draw_2_2" },
                    { 220522694, new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6506), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6507), 0.0, "Draw_10_0" },
                    { 230337161, new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5121), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5122), 0.0, "Draw_2_3" },
                    { 246073728, new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5332), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5333), 0.0, "Draw_3_5" },
                    { 264042473, new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6331), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6332), 0.0, "Draw_9_0" },
                    { 277438231, new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5661), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5662), 0.0, "Draw_5_3" },
                    { 282373738, new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6207), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6208), 0.0, "Draw_8_4" },
                    { 290064823, new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5648), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5649), 0.0, "Draw_5_2" },
                    { 290467437, new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6387), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6388), 0.0, "Draw_9_4" },
                    { 316519841, new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5454), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5455), 0.0, "Draw_4_1" },
                    { 321349495, new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5316), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5317), 0.0, "Draw_3_4" },
                    { 344616050, new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5287), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5288), 0.0, "Draw_3_2" },
                    { 351619779, new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5508), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5509), 0.0, "Draw_4_5" },
                    { 362379860, new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6560), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6562), 0.0, "Draw_10_4" },
                    { 382595317, new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4899), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4900), 0.0, "Draw_1_1" },
                    { 400725027, new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6006), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6007), 0.0, "Draw_7_2" },
                    { 413201220, new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5273), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5274), 0.0, "Draw_3_1" },
                    { 445971092, new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6033), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6034), 0.0, "Draw_7_4" },
                    { 477195673, new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6374), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6375), 0.0, "Draw_9_3" },
                    { 480183015, new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5481), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5483), 0.0, "Draw_4_3" },
                    { 481659975, new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5841), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5842), 0.0, "Draw_6_3" },
                    { 500410208, new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5824), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5825), 0.0, "Draw_6_2" },
                    { 501370917, new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6347), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6348), 0.0, "Draw_9_1" },
                    { 521068224, new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5077), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5078), 0.0, "Draw_2_0" },
                    { 537904597, new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5149), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5150), 0.0, "Draw_2_5" },
                    { 552883634, new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5796), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5797), 0.0, "Draw_6_0" },
                    { 567324173, new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6400), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6401), 0.0, "Draw_9_5" },
                    { 579865295, new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4956), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4957), 0.0, "Draw_1_5" },
                    { 637650471, new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5855), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5856), 0.0, "Draw_6_4" },
                    { 642021294, new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4876), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4877), 0.0, "Draw_1_0" },
                    { 644409942, new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5092), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5093), 0.0, "Draw_2_1" },
                    { 646399121, new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5993), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5994), 0.0, "Draw_7_1" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { 651112065, new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5621), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5622), 0.0, "Draw_5_0" },
                    { 676474853, new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6168), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6169), 0.0, "Draw_8_1" },
                    { 680434089, new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4927), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4928), 0.0, "Draw_1_3" },
                    { 704909979, new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6220), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6222), 0.0, "Draw_8_5" },
                    { 707302186, new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6360), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6362), 0.0, "Draw_9_2" },
                    { 707749501, new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5135), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5136), 0.0, "Draw_2_4" },
                    { 715638643, new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6520), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6521), 0.0, "Draw_10_1" },
                    { 725602412, new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6194), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6195), 0.0, "Draw_8_3" },
                    { 727688881, new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6019), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6020), 0.0, "Draw_7_3" },
                    { 728582013, new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5810), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5811), 0.0, "Draw_6_1" },
                    { 794440590, new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4940), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4941), 0.0, "Draw_1_4" },
                    { 827039557, new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5259), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5260), 0.0, "Draw_3_0" },
                    { 918061643, new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5495), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5496), 0.0, "Draw_4_4" },
                    { 947772624, new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4913), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4914), 0.0, "Draw_1_2" },
                    { 959144129, new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5440), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5441), 0.0, "Draw_4_0" },
                    { 978575174, new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6574), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6575), 0.0, "Draw_10_5" },
                    { 992929749, new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6547), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6548), 0.0, "Draw_10_3" },
                    { 997783156, new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6046), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6047), 0.0, "Draw_7_5" }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1745156444, 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4677), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4678), 0.0, "Printing" },
                    { -1561749213, 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4723), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4724), 0.0, "Administration" },
                    { -1198987733, 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4694), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4695), 0.0, "Inside" },
                    { 1180387932, 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4658), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4659), 0.0, "Comm" },
                    { 1266185828, 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4709), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4710), 0.0, "Meeting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 237703801, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4294), true, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4295), "COO" },
                    { 330500794, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4287), true, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4288), "Project Manager" },
                    { 417356729, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4308), true, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4309), "CEO" },
                    { 546781993, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4322), false, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4323), "Customer" },
                    { 560678520, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4269), true, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4270), "Draftsmen" },
                    { 720637285, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4279), true, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4280), "Engineer" },
                    { 727894508, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4315), false, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4316), "Guest" },
                    { 798950973, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4301), true, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4302), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 139431095, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5882), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", "Alexandros_9", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5883), null, "6949277789", null, null, null },
                    { 142833065, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5701), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", "Alexandros_8", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5702), null, "6949277788", null, null, null },
                    { 145970463, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6413), "Test Description PM 12", "alexpl_31@gmail.com", "Platanios_PM_12", "Alexandros_12", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6415), null, "69492777812", null, null, null },
                    { 159078078, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4507), "Draftsman 1", "draftman1@gmail.com", "Platanios1", "Alexandros1", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4508), null, "6949277781", null, null, null },
                    { 190508941, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6059), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", "Alexandros_10", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6060), null, "69492777810", null, null, null },
                    { 249946276, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4596), "Draftsman 4", "draftman4@gmail.com", "Platanios4", "Alexandros4", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4597), null, "6949277784", null, null, null },
                    { 261864585, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4970), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", "Alexandros_4", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4971), null, "6949277784", null, null, null },
                    { 347114221, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4567), "Draftsman 3", "draftman3@gmail.com", "Platanios3", "Alexandros3", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4569), null, "6949277783", null, null, null },
                    { 382309111, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4740), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", "Alexandros_3", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4741), null, "6949277783", null, null, null },
                    { 469768601, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6589), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", "Alexandros_3", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6590), null, "6949277783", null, null, null },
                    { 556185464, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4426), "Draftsman 0", "draftman0@gmail.com", "Platanios0", "Alexandros0", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4427), null, "6949277780", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 611745695, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4627), "Draftsman 5", "draftman5@gmail.com", "Platanios5", "Alexandros5", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4628), null, "6949277785", null, null, null },
                    { 682176570, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7549), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", "Alexandros_4", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7550), null, "6949277784", null, null, null },
                    { 718127862, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4538), "Draftsman 2", "draftman2@gmail.com", "Platanios2", "Alexandros2", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4539), null, "6949277782", null, null, null },
                    { 724263810, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6234), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", "Alexandros_11", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6235), null, "69492777811", null, null, null },
                    { 781494114, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5522), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", "Alexandros_7", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5524), null, "6949277787", null, null, null },
                    { 864251854, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5163), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", "Alexandros_5", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5164), null, "6949277785", null, null, null },
                    { 967961411, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5346), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", "Alexandros_6", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5347), null, "6949277786", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EngineerId", "EstimatedHours", "LastUpdatedDate", "MenHours", "Name" },
                values: new object[,]
                {
                    { -1317995120, 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6624), 469768601, 2345L, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6625), 3425L, "ELEC" },
                    { 1213828352, 0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7580), 682176570, 2345L, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7581), 3425L, "HVAC" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DeadLine", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "MenHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "ProjectManagerId", "WorkPackege", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 187653646, "ALPHA", 1, "D-22-168", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 13.0, 64, new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 64, "Test Description Project_24", "KL-8", new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 64L, 512L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_8", 5.0, new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_16", 8.0, 190508941, new DateTime(2029, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 },
                    { 342599500, "ALPHA", 1, "D-22-1610", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 15.0, 100, new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 100, "Test Description Project_40", "KL-10", new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 125L, 1000L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_10", 5.0, new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_60", 10.0, 145970463, new DateTime(2032, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 },
                    { 382169516, "ALPHA", 2, "D-22-162", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 7.0, 4, new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 4, "Test Description Project_4", "KL-2", new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 1L, 8L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_2", 5.0, new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_4", 2.0, 261864585, new DateTime(2024, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 },
                    { 433749087, "NBG_IBANK", 1, "D-22-167", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 12.0, 49, new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 49, "Test Description Project_42", "KL-7", new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 43L, 343L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_7", 5.0, new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_28", 7.0, 139431095, new DateTime(2028, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 },
                    { 517779573, "NBG_IBANK", 1, "D-22-169", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 14.0, 81, new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 81, "Test Description Project_27", "KL-9", new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 91L, 729L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_9", 5.0, new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_27", 9.0, 724263810, new DateTime(2030, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 },
                    { 561790865, "ALPHA", 4, "D-22-164", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 9.0, 16, new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 16, "Test Description Project_16", "KL-4", new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 8L, 64L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_4", 5.0, new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_8", 4.0, 967961411, new DateTime(2025, 6, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 },
                    { 717620912, "NBG_IBANK", 1, "D-22-165", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 10.0, 25, new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 25, "Test Description Project_10", "KL-5", new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 16L, 125L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_5", 5.0, new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_25", 5.0, 781494114, new DateTime(2026, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 },
                    { 783796408, "ALPHA", 1, "D-22-166", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 11.0, 36, new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 36, "Test Description Project_12", "KL-6", new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 27L, 216L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_6", 5.0, new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_6", 6.0, 142833065, new DateTime(2027, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 },
                    { 889005723, "NBG_IBANK", 3, "D-22-163", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 8.0, 9, new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 9, "Test Description Project_3", "KL-3", new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 3L, 27L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_3", 5.0, new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_6", 3.0, 864251854, new DateTime(2024, 11, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 },
                    { 980878347, "NBG_IBANK", 1, "D-22-161", 0, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 6.0, 1, new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 1, "Test Description Project_5", "KL-1", new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, 1L, new DateTime(2024, 2, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0L, "Project_1", 5.0, new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), "Payment Detailes For Project_3", 1.0, 382309111, new DateTime(2024, 3, 22, 21, 17, 57, 468, DateTimeKind.Local).AddTicks(6982), 0 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 330500794, 139431095, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5899), 426406321, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5900) },
                    { 330500794, 142833065, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5719), 170230525, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5720) },
                    { 330500794, 145970463, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6430), 553031608, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6431) },
                    { 560678520, 159078078, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4524), 126011379, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4525) },
                    { 330500794, 190508941, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6076), 623003899, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6077) },
                    { 560678520, 249946276, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4614), 809121895, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4615) },
                    { 330500794, 261864585, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4988), 911773801, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4989) },
                    { 560678520, 347114221, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4583), 881369902, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4585) },
                    { 330500794, 382309111, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4762), 770082391, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4763) },
                    { 720637285, 469768601, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6608), 425339713, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6609) },
                    { 560678520, 556185464, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4489), 234997973, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4490) },
                    { 560678520, 611745695, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4643), 674765341, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4644) },
                    { 720637285, 682176570, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7566), 486114445, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7568) },
                    { 560678520, 718127862, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4554), 849315885, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4555) },
                    { 330500794, 724263810, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6250), 734311694, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6252) },
                    { 330500794, 781494114, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5538), 571116666, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5539) },
                    { 330500794, 864251854, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5179), 411159227, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5180) },
                    { 330500794, 967961411, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5362), 206249927, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5363) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1317995120, 131892428, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7500), 375100752, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7501) },
                    { -1317995120, 144196292, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7061), 559038389, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7062) },
                    { -1317995120, 146258647, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7328), 466460050, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7330) },
                    { -1317995120, 167227493, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7170), 141990672, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7171) },
                    { -1317995120, 169739827, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6995), 501111746, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6997) },
                    { -1317995120, 173546422, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7244), 267611074, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7245) },
                    { -1317995120, 188326353, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7355), 176763156, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7356) },
                    { -1317995120, 190850575, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7158), 986108995, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7159) },
                    { -1317995120, 197575157, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7256), 728153011, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7257) },
                    { -1317995120, 210987365, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7121), 485141097, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7122) },
                    { -1317995120, 219832217, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6910), 145293865, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6911) },
                    { -1317995120, 220522694, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7476), 486899447, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7477) },
                    { -1317995120, 230337161, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6923), 134019644, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6924) },
                    { -1317995120, 246073728, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7024), 955048601, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7025) },
                    { -1317995120, 264042473, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7404), 587183599, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7405) },
                    { -1317995120, 277438231, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7146), 618816068, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7147) },
                    { -1317995120, 282373738, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7380), 290140496, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7381) },
                    { -1317995120, 290064823, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7134), 746457901, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7135) },
                    { -1317995120, 290467437, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7452), 677638091, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7453) },
                    { -1317995120, 316519841, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7049), 877254336, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7050) },
                    { -1317995120, 321349495, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7010), 478675621, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7012) },
                    { -1317995120, 344616050, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6983), 301238016, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6985) },
                    { -1317995120, 351619779, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7097), 615183558, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7098) },
                    { -1317995120, 362379860, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7524), 961812313, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7525) },
                    { -1317995120, 382595317, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6822), 171742887, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6823) },
                    { -1317995120, 400725027, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7280), 629270393, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7282) },
                    { -1317995120, 413201220, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6971), 676493741, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6973) },
                    { -1317995120, 445971092, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7305), 827451469, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7306) },
                    { -1317995120, 477195673, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7440), 228969194, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7441) },
                    { -1317995120, 480183015, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7073), 975717403, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7074) },
                    { -1317995120, 481659975, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7219), 189332782, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7220) },
                    { -1317995120, 500410208, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7206), 220706348, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7207) },
                    { -1317995120, 501370917, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7415), 200526558, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7417) },
                    { -1317995120, 521068224, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6885), 300623279, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6886) },
                    { -1317995120, 537904597, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6947), 931909789, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6948) },
                    { -1317995120, 552883634, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7182), 695026818, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7183) },
                    { -1317995120, 567324173, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7464), 845763156, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7465) },
                    { -1317995120, 579865295, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6873), 174010278, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6874) },
                    { -1317995120, 637650471, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7231), 952259687, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7232) },
                    { -1317995120, 642021294, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6802), 552200404, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6803) },
                    { -1317995120, 644409942, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6898), 722190452, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6899) },
                    { -1317995120, 646399121, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7268), 261046473, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7269) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1317995120, 651112065, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7109), 307758080, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7110) },
                    { -1317995120, 676474853, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7340), 252721735, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7342) },
                    { -1317995120, 680434089, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6847), 706125036, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6848) },
                    { -1317995120, 704909979, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7392), 454999657, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7393) },
                    { -1317995120, 707302186, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7427), 604646378, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7428) },
                    { -1317995120, 707749501, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6935), 269596285, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6936) },
                    { -1317995120, 715638643, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7488), 228286500, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7489) },
                    { -1317995120, 725602412, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7367), 807768912, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7369) },
                    { -1317995120, 727688881, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7292), 999245419, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7294) },
                    { -1317995120, 728582013, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7194), 737926183, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7195) },
                    { -1317995120, 794440590, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6860), 722184905, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6861) },
                    { -1317995120, 827039557, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6959), 357546415, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6960) },
                    { -1317995120, 918061643, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7085), 631471926, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7086) },
                    { -1317995120, 947772624, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6835), 583829991, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6836) },
                    { -1317995120, 959144129, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7036), 311597946, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7037) },
                    { -1317995120, 978575174, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7536), 324850276, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7537) },
                    { -1317995120, 992929749, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7512), 452017948, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7513) },
                    { -1317995120, 997783156, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7317), 586362884, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7318) },
                    { 1213828352, 131892428, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8421), 671283646, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8422) },
                    { 1213828352, 144196292, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7982), 462866837, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7983) },
                    { 1213828352, 146258647, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8250), 723614026, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8251) },
                    { 1213828352, 167227493, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8093), 348178587, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8094) },
                    { 1213828352, 169739827, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7921), 140608254, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7922) },
                    { 1213828352, 173546422, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8166), 215089151, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8167) },
                    { 1213828352, 188326353, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8274), 214478754, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8275) },
                    { 1213828352, 190850575, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8081), 859054418, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8082) },
                    { 1213828352, 197575157, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8178), 240907266, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8179) },
                    { 1213828352, 210987365, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8044), 697699031, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8046) },
                    { 1213828352, 219832217, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7836), 375651203, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7837) },
                    { 1213828352, 220522694, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8395), 786646138, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8396) },
                    { 1213828352, 230337161, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7849), 662459570, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7850) },
                    { 1213828352, 246073728, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7945), 839580743, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7946) },
                    { 1213828352, 264042473, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8322), 522059556, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8323) },
                    { 1213828352, 277438231, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8069), 211733496, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8070) },
                    { 1213828352, 282373738, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8298), 456414044, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8299) },
                    { 1213828352, 290064823, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8056), 421704596, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8058) },
                    { 1213828352, 290467437, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8371), 866446858, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8372) },
                    { 1213828352, 316519841, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7970), 698195447, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7971) },
                    { 1213828352, 321349495, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7933), 882024761, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7934) },
                    { 1213828352, 344616050, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7909), 334093566, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7910) },
                    { 1213828352, 351619779, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8018), 833615034, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8019) },
                    { 1213828352, 362379860, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8446), 658428480, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8447) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesDraws",
                columns: new[] { "DisciplineId", "DrawId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1213828352, 382595317, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7750), 752370914, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7751) },
                    { 1213828352, 400725027, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8202), 256781536, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8203) },
                    { 1213828352, 413201220, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7897), 653262264, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7898) },
                    { 1213828352, 445971092, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8226), 766137572, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8227) },
                    { 1213828352, 477195673, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8358), 755412717, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8360) },
                    { 1213828352, 480183015, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7994), 619063674, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7995) },
                    { 1213828352, 481659975, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8141), 937557017, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8142) },
                    { 1213828352, 500410208, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8129), 932972999, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8130) },
                    { 1213828352, 501370917, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8335), 671335761, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8336) },
                    { 1213828352, 521068224, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7812), 460846732, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7813) },
                    { 1213828352, 537904597, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7873), 427422297, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7874) },
                    { 1213828352, 552883634, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8105), 208406873, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8106) },
                    { 1213828352, 567324173, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8383), 817845821, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8384) },
                    { 1213828352, 579865295, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7800), 723640913, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7801) },
                    { 1213828352, 637650471, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8153), 645482559, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8155) },
                    { 1213828352, 642021294, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7736), 226034198, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7738) },
                    { 1213828352, 644409942, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7824), 364644644, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7825) },
                    { 1213828352, 646399121, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8190), 566905825, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8191) },
                    { 1213828352, 651112065, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8030), 438782218, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8031) },
                    { 1213828352, 676474853, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8262), 468642006, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8263) },
                    { 1213828352, 680434089, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7774), 646657751, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7775) },
                    { 1213828352, 704909979, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8310), 762299482, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8311) },
                    { 1213828352, 707302186, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8346), 947563269, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8348) },
                    { 1213828352, 707749501, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7861), 656086141, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7862) },
                    { 1213828352, 715638643, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8407), 192450972, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8408) },
                    { 1213828352, 725602412, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8286), 762874660, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8287) },
                    { 1213828352, 727688881, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8214), 407683170, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8215) },
                    { 1213828352, 728582013, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8117), 432501351, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8118) },
                    { 1213828352, 794440590, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7787), 969299352, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7788) },
                    { 1213828352, 827039557, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7885), 980753008, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7886) },
                    { 1213828352, 918061643, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8006), 958564677, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8007) },
                    { 1213828352, 947772624, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7762), 317193454, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7763) },
                    { 1213828352, 959144129, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7958), 879755812, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7959) },
                    { 1213828352, 978575174, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8458), 449813271, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8459) },
                    { 1213828352, 992929749, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8434), 892443639, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8435) },
                    { 1213828352, 997783156, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8238), 705488121, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8239) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1317995120, 159078078, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6734), -848566142, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6735) },
                    { -1317995120, 249946276, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6774), 1183409163, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6775) },
                    { -1317995120, 347114221, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6761), -1828033780, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6762) },
                    { -1317995120, 556185464, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6715), -503410549, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6716) },
                    { -1317995120, 611745695, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6787), -42532658, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6789) },
                    { -1317995120, 718127862, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6748), -98514080, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6749) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEmployees",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1213828352, 159078078, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7669), -242147195, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7671) },
                    { 1213828352, 249946276, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7711), -1179954607, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7712) },
                    { 1213828352, 347114221, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7696), 1347139346, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7697) },
                    { 1213828352, 556185464, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7656), -1754580995, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7657) },
                    { 1213828352, 611745695, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7724), -621430469, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7725) },
                    { 1213828352, 718127862, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7682), -1220819107, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7683) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesOthers",
                columns: new[] { "DisciplineId", "OtherId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1317995120, -1745156444, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6661), 961725489, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6662) },
                    { -1317995120, -1561749213, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6699), 998579921, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6701) },
                    { -1317995120, -1198987733, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6674), 410166981, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6675) },
                    { -1317995120, 1180387932, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6643), 412810324, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6644) },
                    { -1317995120, 1266185828, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6687), 785796588, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6688) },
                    { 1213828352, -1745156444, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7607), 441032162, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7608) },
                    { 1213828352, -1561749213, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7644), 547926214, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7645) },
                    { 1213828352, -1198987733, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7619), 816788355, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7620) },
                    { 1213828352, 1180387932, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7594), 282220797, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7595) },
                    { 1213828352, 1266185828, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7631), 986555937, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(7632) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesPojects",
                columns: new[] { "DisciplineId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1317995120, 187653646, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8659), 1643556330, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8660) },
                    { -1317995120, 342599500, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8712), -1924333064, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8713) },
                    { -1317995120, 382169516, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8503), 1019724987, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8504) },
                    { -1317995120, 433749087, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8634), -1371463870, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8635) },
                    { -1317995120, 517779573, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8685), 1322042486, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8686) },
                    { -1317995120, 561790865, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8556), -1456767965, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8557) },
                    { -1317995120, 717620912, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8581), -1681631802, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8583) },
                    { -1317995120, 783796408, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8608), -878395622, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8609) },
                    { -1317995120, 889005723, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8529), -789775824, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8530) },
                    { -1317995120, 980878347, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8472), 1261928896, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8473) },
                    { 1213828352, 187653646, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8672), -953075072, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8673) },
                    { 1213828352, 342599500, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8725), -1361739630, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8726) },
                    { 1213828352, 382169516, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8516), -1149327402, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8517) },
                    { 1213828352, 433749087, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8647), 1218199680, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8648) },
                    { 1213828352, 517779573, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8699), -1590846439, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8700) },
                    { 1213828352, 561790865, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8569), -2263077, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8570) },
                    { 1213828352, 717620912, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8595), -931427097, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8596) },
                    { 1213828352, 783796408, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8621), -1009801859, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8622) },
                    { 1213828352, 889005723, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8543), -1116080442, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8544) },
                    { 1213828352, 980878347, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8488), -1343097992, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(8489) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 200898825, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5603), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5606), 103000.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5605), "Signature 1423420", 20013, 717620912, 5.0, 17.0 },
                    { 220861446, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4855), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4858), 3010.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4857), "Signature 142343", 56792, 980878347, 1.0, 17.0 },
                    { 401026349, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5425), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5427), 13000.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5426), "Signature 1423416", 38805, 561790865, 4.0, 24.0 },
                    { 461772736, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6315), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6317), 1000003000.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6316), "Signature 142349", 30448, 517779573, 9.0, 17.0 },
                    { 512872016, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6138), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6140), 100003000.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6139), "Signature 1423432", 70341, 187653646, 8.0, 24.0 },
                    { 547143349, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6491), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6494), 10000003000.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6493), "Signature 1423450", 58065, 342599500, 10.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 665046431, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5780), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5782), 1003000.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5781), "Signature 1423418", 45623, 783796408, 6.0, 24.0 },
                    { 814677703, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5242), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5244), 4000.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5243), "Signature 1423412", 20488, 889005723, 3.0, 17.0 },
                    { 830348323, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5964), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5967), 10003000.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5965), "Signature 1423421", 33709, 433749087, 7.0, 17.0 },
                    { 830658231, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5060), new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5062), 3100.0, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5061), "Signature 142344", 23068, 382169516, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 138161334, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5031), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5032), null, "6949277782", null, null, 382169516 },
                    { 352849077, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4822), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4823), null, "6949277781", null, null, 980878347 },
                    { 353123179, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5752), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5753), null, "6949277786", null, null, 783796408 },
                    { 688526355, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5396), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5397), null, "6949277784", null, null, 561790865 },
                    { 772342819, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6286), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", "Alexandros_9", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6287), null, "6949277789", null, null, 517779573 },
                    { 790097466, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5575), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5576), null, "6949277785", null, null, 717620912 },
                    { 854805500, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6110), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6111), null, "6949277788", null, null, 187653646 },
                    { 902849288, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6462), "Test Description Customer 10", "alexpl_10@gmail.com", "Platanios_Customer_10", "Alexandros_10", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6463), null, "69492777810", null, null, 342599500 },
                    { 910286585, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5213), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5215), null, "6949277783", null, null, 889005723 },
                    { 951470962, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5935), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5936), null, "6949277787", null, null, 433749087 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 546781993, 138161334, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5047), 577013852, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5048) },
                    { 546781993, 352849077, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4841), 556767783, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(4842) },
                    { 546781993, 353123179, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5768), 660260359, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5769) },
                    { 546781993, 688526355, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5412), 794901252, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5413) },
                    { 546781993, 772342819, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6302), 639206502, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6303) },
                    { 546781993, 790097466, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5591), 331822846, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5592) },
                    { 546781993, 854805500, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6126), 686736071, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6127) },
                    { 546781993, 902849288, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6479), 217455598, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(6480) },
                    { 546781993, 910286585, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5229), 308253279, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5230) },
                    { 546781993, 951470962, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5951), 209221578, new DateTime(2024, 2, 22, 21, 17, 57, 476, DateTimeKind.Local).AddTicks(5953) }
                });

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
