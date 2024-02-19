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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drawing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedMandays = table.Column<int>(type: "int", nullable: true),
                    EstimatedHours = table.Column<int>(type: "int", nullable: true),
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
                    ManHours = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_Invoices_Projects_ProjectId",
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
                    Completed = table.Column<int>(type: "int", nullable: true),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManHours = table.Column<double>(type: "float", nullable: false),
                    Completed = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docs_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Draws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManHours = table.Column<double>(type: "float", nullable: false),
                    Completed = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Draws_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DisciplinesEngineer",
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
                    table.PrimaryKey("PK_DisciplinesEngineer", x => new { x.DisciplineId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_DisciplinesEngineer_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinesEngineer_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
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
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments" },
                values: new object[,]
                {
                    { 365199590, "ALPHA", 1, "D-22-166", 8, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8596), 11.0, -69, 33, "Test Description Project_36", "KL-6", new DateTime(2024, 4, 27, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8596), new DateTime(2024, 4, 21, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8596), 360, 45, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8596), 30, "Project_6", 5.0, new DateTime(2024, 4, 28, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8596), "Payment Detailes For Project_30", 6.0 },
                    { 386371170, "ALPHA", 4, "D-22-164", 12, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8115), 9.0, -63, 23, "Test Description Project_4", "KL-4", new DateTime(2024, 4, 21, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8115), new DateTime(2024, 4, 17, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8115), 160, 20, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8115), 20, "Project_4", 5.0, new DateTime(2024, 4, 22, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8115), "Payment Detailes For Project_24", 4.0 },
                    { 450850502, "ALPHA", 2, "D-22-162", 25, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7630), 7.0, -57, 13, "Test Description Project_10", "KL-2", new DateTime(2024, 4, 15, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7630), new DateTime(2024, 4, 13, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7630), 40, 5, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7630), 10, "Project_2", 5.0, new DateTime(2024, 4, 16, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7630), "Payment Detailes For Project_10", 2.0 },
                    { 609539112, "NBG_IBANK", 3, "D-22-163", 17, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7879), 8.0, -60, 18, "Test Description Project_9", "KL-3", new DateTime(2024, 4, 18, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7879), new DateTime(2024, 4, 15, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7879), 90, 11, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7879), 15, "Project_3", 5.0, new DateTime(2024, 4, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7879), "Payment Detailes For Project_6", 3.0 },
                    { 727341968, "NBG_IBANK", 1, "D-22-169", 6, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9300), 14.0, -78, 48, "Test Description Project_36", "KL-9", new DateTime(2024, 5, 6, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9300), new DateTime(2024, 4, 27, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9300), 810, 101, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9300), 45, "Project_9", 5.0, new DateTime(2024, 5, 7, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9300), "Payment Detailes For Project_54", 9.0 },
                    { 769668582, "ALPHA", 1, "D-22-168", 6, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9068), 13.0, -75, 43, "Test Description Project_8", "KL-8", new DateTime(2024, 5, 3, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9068), new DateTime(2024, 4, 25, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9068), 640, 80, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9068), 40, "Project_8", 5.0, new DateTime(2024, 5, 4, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9068), "Payment Detailes For Project_8", 8.0 },
                    { 783257137, "NBG_IBANK", 1, "D-22-167", 7, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8835), 12.0, -72, 38, "Test Description Project_35", "KL-7", new DateTime(2024, 4, 30, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8835), new DateTime(2024, 4, 23, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8835), 490, 61, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8835), 35, "Project_7", 5.0, new DateTime(2024, 5, 1, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8835), "Payment Detailes For Project_7", 7.0 },
                    { 800902513, "NBG_IBANK", 1, "D-22-161", 50, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7206), 6.0, -54, 8, "Test Description Project_6", "KL-1", new DateTime(2024, 4, 12, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7206), new DateTime(2024, 4, 11, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7206), 10, 1, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7206), 5, "Project_1", 5.0, new DateTime(2024, 4, 13, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7206), "Payment Detailes For Project_3", 1.0 },
                    { 868547205, "NBG_IBANK", 1, "D-22-165", 10, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8349), 10.0, -66, 28, "Test Description Project_20", "KL-5", new DateTime(2024, 4, 24, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8349), new DateTime(2024, 4, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8349), 250, 31, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8349), 25, "Project_5", 5.0, new DateTime(2024, 4, 25, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8349), "Payment Detailes For Project_15", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 156924662, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7056), true, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7057), "CTO" },
                    { 185872190, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7078), false, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7080), "Customer" },
                    { 202499663, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7022), true, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7024), "Draftsmen" },
                    { 227384047, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7031), true, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7033), "Engineer" },
                    { 654491174, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7039), true, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7040), "Project Manager" },
                    { 777812687, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7048), true, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7049), "COO" },
                    { 881544739, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7063), true, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7065), "CEO" },
                    { 930552519, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7071), false, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7072), "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 133568433, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8463), "Test Description Engineer 7", null, "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8465), null, "6949277787", null, null, null },
                    { 144695077, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8668), "Test Description PM 8", null, "alexpl_27@gmail.com", "Platanios_PM_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8670), null, "6949277788", null, null, null },
                    { 162640478, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7378), "Test Description Engineer 3", null, "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7379), null, "6949277783", null, null, null },
                    { 228353652, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9408), "Test Description Engineer 11", null, "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9410), null, "69492777811", null, null, null },
                    { 242720234, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9376), "Test Description PM 11", null, "alexpl_30@gmail.com", "Platanios_PM_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9377), null, "69492777811", null, null, null },
                    { 309481877, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8493), "Test Description Draftsman 7", null, "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8494), null, "6949277787", null, null, null },
                    { 314643106, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7741), "Test Description Engineer 4", null, "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7742), null, "6949277784", null, null, null },
                    { 318228806, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9168), "Test Description Engineer 10", null, "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9169), null, "69492777810", null, null, null },
                    { 384082415, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7489), "Test Description Draftsman 3", null, "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7490), null, "6949277783", null, null, null },
                    { 403568572, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8964), "Test Description Draftsman 9", null, "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8965), null, "6949277789", null, null, null },
                    { 409801679, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8432), "Test Description PM 7", null, "alexpl_26@gmail.com", "Platanios_PM_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8433), null, "6949277787", null, null, null },
                    { 453536418, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7771), "Test Description Draftsman 4", null, "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7772), null, "6949277784", null, null, null },
                    { 477264943, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8703), "Test Description Engineer 8", null, "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8704), null, "6949277788", null, null, null },
                    { 564243571, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9197), "Test Description Draftsman 10", null, "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9198), null, "69492777810", null, null, null },
                    { 585965500, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8935), "Test Description Engineer 9", null, "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8936), null, "6949277789", null, null, null },
                    { 619835733, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8733), "Test Description Draftsman 8", null, "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8734), null, "6949277788", null, null, null },
                    { 695640029, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8222), "Test Description Engineer 6", null, "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8223), null, "6949277786", null, null, null },
                    { 699149807, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8192), "Test Description PM 6", null, "alexpl_25@gmail.com", "Platanios_PM_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8193), null, "6949277786", null, null, null },
                    { 725714500, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7341), "Test Description PM 3", null, "alexpl_22@gmail.com", "Platanios_PM_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7343), null, "6949277783", null, null, null },
                    { 732967697, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7709), "Test Description PM 4", null, "alexpl_23@gmail.com", "Platanios_PM_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7711), null, "6949277784", null, null, null },
                    { 735117119, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7984), "Test Description Engineer 5", null, "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7985), null, "6949277785", null, null, null },
                    { 746488698, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9137), "Test Description PM 10", null, "alexpl_29@gmail.com", "Platanios_PM_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9138), null, "69492777810", null, null, null },
                    { 767503106, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8252), "Test Description Draftsman 6", null, "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8253), null, "6949277786", null, null, null },
                    { 821361376, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9438), "Test Description Draftsman 11", null, "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9440), null, "69492777811", null, null, null },
                    { 844234999, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7954), "Test Description PM 5", null, "alexpl_24@gmail.com", "Platanios_PM_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7955), null, "6949277785", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 902602948, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8905), "Test Description PM 9", null, "alexpl_28@gmail.com", "Platanios_PM_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8906), null, "6949277789", null, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 945299596, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8013), "Test Description Draftsman 5", null, "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8014), null, "6949277785", null, null, null });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "LastUpdatedDate", "Name", "ProjectId", "ProjectManagerId" },
                values: new object[,]
                {
                    { 166979752, 8, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8763), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8764), "HVAC", 365199590, 144695077 },
                    { 256918771, 7, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8998), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8999), "ELEC", 783257137, 902602948 },
                    { 302473159, 10, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8523), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8524), "ELEC", 868547205, 409801679 },
                    { 376577319, 6, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9228), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9229), "HVAC", 769668582, 746488698 },
                    { 386687989, 17, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8044), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8045), "ELEC", 609539112, 844234999 },
                    { 426573858, 12, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8282), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8283), "HVAC", 386371170, 699149807 },
                    { 485603145, 50, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7530), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7531), "ELEC", 800902513, 725714500 },
                    { 791558315, 6, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9468), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9469), "ELEC", 727341968, 242720234 },
                    { 980698608, 25, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7800), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7802), "HVAC", 450850502, 732967697 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 185992280, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8888), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8891), 10003000.0, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8890), "Signature 1423442", 45637, 783257137, 7.0, 17.0 },
                    { 305814512, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7317), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7319), 3010.0, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7318), "Signature 142342", 26390, 800902513, 1.0, 17.0 },
                    { 424507412, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7936), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7938), 4000.0, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7937), "Signature 142349", 60795, 609539112, 3.0, 17.0 },
                    { 564907502, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8174), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8177), 13000.0, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8175), "Signature 1423424", 15464, 386371170, 4.0, 24.0 },
                    { 602828211, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8651), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8653), 1003000.0, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8652), "Signature 1423436", 82327, 365199590, 6.0, 24.0 },
                    { 639710314, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8412), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8414), 103000.0, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8413), "Signature 142345", 74830, 868547205, 5.0, 17.0 },
                    { 815735098, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9121), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9123), 100003000.0, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9122), "Signature 1423416", 76730, 769668582, 8.0, 24.0 },
                    { 817917593, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9357), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9360), 1000003000.0, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9358), "Signature 1423436", 33708, 727341968, 9.0, 17.0 },
                    { 958158506, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7689), new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7692), 3100.0, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7691), "Signature 142342", 34830, 450850502, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 227384047, 133568433, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8479), 355983621, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8481) },
                    { 654491174, 144695077, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8686), 400936348, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8687) },
                    { 227384047, 162640478, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7473), 916746605, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7474) },
                    { 227384047, 228353652, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9425), 560354224, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9427) },
                    { 654491174, 242720234, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9395), 356127545, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9396) },
                    { 202499663, 309481877, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8509), 838954098, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8510) },
                    { 227384047, 314643106, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7757), 403448891, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7759) },
                    { 227384047, 318228806, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9185), 722916890, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9186) },
                    { 202499663, 384082415, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7515), 140931338, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7516) },
                    { 202499663, 403568572, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8981), 478450142, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8982) },
                    { 654491174, 409801679, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8450), 357023824, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8451) },
                    { 202499663, 453536418, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7787), 223643837, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7789) },
                    { 227384047, 477264943, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8719), 162449810, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8720) },
                    { 202499663, 564243571, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9214), 414610694, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9216) },
                    { 227384047, 585965500, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8951), 737906773, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8952) },
                    { 202499663, 619835733, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8749), 405958433, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8751) },
                    { 227384047, 695640029, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8239), 929865069, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8240) },
                    { 654491174, 699149807, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8208), 890510813, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8210) },
                    { 654491174, 725714500, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7363), 563391907, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7364) },
                    { 654491174, 732967697, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7727), 955175390, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7728) },
                    { 227384047, 735117119, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8000), 607653198, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8001) },
                    { 654491174, 746488698, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9155), 963102358, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9156) },
                    { 202499663, 767503106, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8268), 670948609, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8270) },
                    { 202499663, 821361376, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9455), 134864493, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9456) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 654491174, 844234999, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7971), 827161648, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7972) },
                    { 654491174, 902602948, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8922), 577085637, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8923) },
                    { 202499663, 945299596, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8030), 259736786, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8031) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 345907641, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8374), "Test Description Customer 5", null, "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8375), null, "6949277785", null, null, 868547205 },
                    { 411250799, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9091), "Test Description Customer 8", null, "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9093), null, "6949277788", null, null, 769668582 },
                    { 541269879, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7656), "Test Description Customer 2", null, "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7657), null, "6949277782", null, null, 450850502 },
                    { 563809108, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9325), "Test Description Customer 9", null, "alexpl_9@gmail.com", "Platanios_Customer_9", null, "Alexandros_9", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9326), null, "6949277789", null, null, 727341968 },
                    { 665053199, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8859), "Test Description Customer 7", null, "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8860), null, "6949277787", null, null, 783257137 },
                    { 779316297, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8621), "Test Description Customer 6", null, "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8622), null, "6949277786", null, null, 365199590 },
                    { 851241781, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7903), "Test Description Customer 3", null, "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7904), null, "6949277783", null, null, 609539112 },
                    { 955931752, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7256), "Test Description Customer 1", null, "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7257), null, "6949277781", null, null, 800902513 },
                    { 966604717, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8143), "Test Description Customer 4", null, "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8145), null, "6949277784", null, null, 386371170 }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 166979752, 477264943, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8778), 337489635, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8779) },
                    { 166979752, 619835733, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8792), 797030807, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8793) },
                    { 256918771, 403568572, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9026), 459957290, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9027) },
                    { 256918771, 585965500, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9013), 890960340, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9014) },
                    { 302473159, 133568433, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8538), 518425577, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8539) },
                    { 302473159, 309481877, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8553), 884844420, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8554) },
                    { 376577319, 318228806, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9242), 488201655, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9243) },
                    { 376577319, 564243571, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9254), 346586841, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9256) },
                    { 386687989, 735117119, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8058), 478927442, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8059) },
                    { 386687989, 945299596, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8072), 175706743, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8073) },
                    { 426573858, 695640029, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8297), 995697237, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8298) },
                    { 426573858, 767503106, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8310), 632353642, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8311) },
                    { 485603145, 162640478, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7550), 787493051, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7551) },
                    { 485603145, 384082415, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7570), 297813484, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7571) },
                    { 791558315, 228353652, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9484), 483653238, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9485) },
                    { 791558315, 821361376, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9498), 886018505, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9499) },
                    { 980698608, 314643106, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7815), 224056889, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7816) },
                    { 980698608, 453536418, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7827), 745254524, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7829) }
                });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "Id", "Completed", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 220932368, 3, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9283), 376577319, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9284), 16.0, "Doc_8" },
                    { 401226568, 8, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8103), 386687989, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8104), 6.0, "Doc_3" },
                    { 494481001, 25, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7608), 485603145, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7609), 2.0, "Doc_1" },
                    { 511149665, 4, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8822), 166979752, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8823), 12.0, "Doc_6" },
                    { 617833015, 4, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9056), 256918771, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9057), 14.0, "Doc_7" },
                    { 659788339, 6, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8339), 426573858, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8340), 8.0, "Doc_4" },
                    { 856247588, 5, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8583), 302473159, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8584), 10.0, "Doc_5" },
                    { 922426588, 12, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7862), 980698608, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7863), 4.0, "Doc_2" },
                    { 974797361, 3, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9533), 791558315, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9534), 18.0, "Doc_9" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "Completed", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 143962135, 3, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9512), 791558315, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9513), 27.0, "Draw_9" },
                    { 184140454, 3, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9267), 376577319, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9268), 24.0, "Draw_8" },
                    { 190609758, 12, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7845), 980698608, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7846), 6.0, "Draw_2" },
                    { 341655361, 4, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9039), 256918771, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9040), 21.0, "Draw_7" },
                    { 386942412, 25, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7585), 485603145, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7586), 3.0, "Draw_1" },
                    { 493907690, 5, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8565), 302473159, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8567), 15.0, "Draw_5" },
                    { 531157158, 4, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8806), 166979752, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8807), 18.0, "Draw_6" },
                    { 625128343, 8, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8086), 386687989, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8087), 9.0, "Draw_3" },
                    { 667887539, 6, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8323), 426573858, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8324), 12.0, "Draw_4" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 185872190, 345907641, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8393), 545598098, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8395) },
                    { 185872190, 411250799, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9108), 871569710, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9109) },
                    { 185872190, 541269879, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7675), 125239236, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7676) },
                    { 185872190, 563809108, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9343), 808902890, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(9344) },
                    { 185872190, 665053199, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8875), 914587902, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8877) },
                    { 185872190, 779316297, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8637), 684769578, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8638) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 185872190, 851241781, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7921), 417519175, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7922) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 185872190, 955931752, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7297), 305140861, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(7299) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 185872190, 966604717, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8160), 916885615, new DateTime(2024, 2, 19, 19, 46, 43, 475, DateTimeKind.Local).AddTicks(8162) });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_ProjectId",
                table: "Disciplines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_ProjectManagerId",
                table: "Disciplines",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinesEngineer_EmployeeId",
                table: "DisciplinesEngineer",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_DisciplineId",
                table: "Docs",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Draws_DisciplineId",
                table: "Draws",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DisciplineId",
                table: "Users",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectId",
                table: "Users",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Users_ProjectManagerId",
                table: "Disciplines",
                column: "ProjectManagerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Users_ProjectManagerId",
                table: "Disciplines");

            migrationBuilder.DropTable(
                name: "DisciplinesEngineer");

            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
